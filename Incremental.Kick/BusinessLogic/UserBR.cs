using System;
using Incremental.Kick.Dal;
using Incremental.Kick.Helpers;
using Incremental.Kick.Security;
using Incremental.Kick.Common.Exceptions;
using Incremental.Kick.Caching;

namespace Incremental.Kick.BusinessLogic {
    //NOTE: GJ: at some point I will be moving much of this logic into the SubSonic models
    public class UserBR {
        public User GetByUserID(int userID) {
            return GetByUserID(userID, false);
        }

        public User GetByUserID(int userID, bool skipUpdateLastActiveOn) {
            User user = User.FetchByID(userID);


            if (!skipUpdateLastActiveOn)
                if (user.LastActiveOn < System.DateTime.Now.AddHours(-1)) {
                    user.LastActiveOn = DateTime.Now;
                    user.Save();
                }

            return user;
        }

        public static UserCollection GetUsersWhoKicked(int? storyId)
        {
            UserCollection users = new UserCollection();
            users.Load(SPs.Kick_GetUsersWhoKicked(storyId).GetReader());
            return users;
        }


        public static void CreateUser(string username, string email, bool receiveEmailNewsletter, Host host) {
            //TODO: GJ: add some RegEx validation here (will come from configuration or constant value)
            username = username.Trim();
            email = email.Trim();

            //TODO: GJ: extract to method
            //ensure that the username and email is unique
            if (User.FetchByParameter(User.Columns.Username, username).Read())
                throw new KickUsernameAlreadyExistsException();
            if (User.FetchByParameter(User.Columns.Email, email).Read())
                throw new KickEmailAlreadyExistsException();

            string password = PasswordGenerator.Generate(8);
            string passwordSalt = Cipher.GenerateSalt();
            string passwordHash = Cipher.Hash(password, passwordSalt);

            User user = new User();
            user.Username = username;
            user.Email = email;
            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.IsGeneratedPassword = true;
            user.IsValidated = false;
            user.IsBanned = false;
            user.ReceiveEmailNewsletter = receiveEmailNewsletter;
            user.HostID = host.HostID;

            user.Save();

            EmailHelper.SendNewUserEmail(email, username, password, host);
        }

        public static string GetSecurityToken(string username, string password) {
            System.Diagnostics.Trace.WriteLine("AuthenticateUser: " + username);

            username = username.Trim();
            password = password.Trim();

            User user = User.FetchUserByUsername(username);
            if (user == null)
                throw new ApplicationException(string.Format("Username [{0}] not found", username));

            string passwordHash = Cipher.Hash(password, user.PasswordSalt);
            if (!passwordHash.Equals(user.Password))
                throw new ApplicationException("Invalid password for username [" + username + "]");

            if (!user.IsValidated)
                user.IsValidated = true;

            user.Save();
            return new SecurityToken(user.UserID).ToString();
        }

        public static void BanUser(string username) {
            User user = User.FetchUserByUsername(username);
            user.IsBanned = true;
            user.Save();

            //TODO: GJ :delete their stories
            //DeleteUserStories(userDS.Kick_User[0].UserID);
        }

        public static void DeleteUserStories(User user) {
            //TODO: GJ: PERFORMANCE: update to delete in one sql statement (low priority)
            throw new NotImplementedException();
        }

        public static void UpdatePassword(int userID, string newPassword, Host host) {
            newPassword = newPassword.Trim();
            string passwordSalt = Cipher.GenerateSalt();
            string passwordHash = Cipher.Hash(newPassword, passwordSalt);

            User user = User.FetchByID(userID);
            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.IsGeneratedPassword = false;
            user.Save();

            System.Diagnostics.Trace.WriteLine("UpdatePassword: " + userID);

            EmailHelper.SendChangedPasswordEmail(user.Email, user.Username, newPassword, host);
        }

        public static void UpdateAdSenseID(int userID, string adSenseID) {
            User user = User.FetchByID(userID);
            user.AdsenseID = adSenseID;
            user.Save();

            System.Diagnostics.Trace.WriteLine("UpdateAdsenseID: " + userID + " - " + adSenseID);

            //TODO: send an email
        }

        public static void SendPasswordResetEmail(int userID, Host host) {
            User user = User.FetchByID(userID);

            EmailHelper.SendPasswordResetEmail(user.Email, user.Username, user.LastActiveOn, host);
        }

        public static void ResetPassword(int userID, Host host) {
            //generate a password
            User user = User.FetchByID(userID);
            string password = PasswordGenerator.Generate(8);
            string passwordSalt = Cipher.GenerateSalt();
            string passwordHash = Cipher.Hash(password, passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.Password = passwordHash;
            user.LastActiveOn = DateTime.Now;
            user.IsGeneratedPassword = true;
            user.Save();

            EmailHelper.SendPasswordEmail(user.Email, user.Username, password, host);
        }

        public static string AuthenticateUser(string username, string password) {
            System.Diagnostics.Trace.WriteLine("AuthenticateUser: " + username);

            username = username.Trim();
            password = password.Trim();

            User user = UserBR.GetUserByUsername(username);

            if (user == null)
                throw new Exception("Username [" + username + "] not found");

            string passwordHash = Cipher.Hash(password, user.PasswordSalt);

            if (!passwordHash.Equals(user.Password))
                throw new Exception("Invalid password for username [" + username + "]");

            if (!user.IsValidated) {
                user.IsValidated = true;
            }

            user.LastActiveOn = DateTime.Now;
            user.Save();

            return new SecurityToken(user.UserID).ToString();
        }

        public static User GetUserByUsername(string username) {
            return User.FetchUserByUsername(username);
        }

        public static User GetUserByEmail(string email) {
            return User.FetchUserByParameter(User.Columns.Email, email);
        }
    }
}
