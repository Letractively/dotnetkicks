using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SubSonic;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Dal {
    public partial class User {
        public static User FetchUserByUsername(string username) {
            return User.FetchUserByParameter(User.Columns.Username, username);
        }

        public static User FetchUserByParameter(string columnName, object value) {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            UserCollection f = new UserCollection();
            f.Load(User.FetchByParameter(columnName, value));
            return f[0];
        }

        public static UserCollection FetchOnlineUsers(int minutesSinceLastActivity, int hostID) {
            Query query = new Query(User.Schema).WHERE(User.Columns.HostID, hostID).AddBetweenValues(User.Columns.LastActiveOn, DateTime.Now.AddMinutes(-minutesSinceLastActivity), DateTime.Now);
            query.OrderBy = SubSonic.OrderBy.Desc(User.Columns.LastActiveOn);
            UserCollection users = new UserCollection();
            users.Load(query.ExecuteReader());
            return users;
        }

        public void UpdateLastActiveOn() {
            if (this.LastActiveOn.AddMinutes(15) < DateTime.Now) {
                this.LastActiveOn = DateTime.Now;
                this.Save();
            }
        }

        public string GravatarEmail {
            get {
                if (this.UseGravatar) {
                    if (String.IsNullOrEmpty(this.GravatarCustomEmail))
                        return this.Email;
                    else
                        return this.GravatarCustomEmail;
                } else {
                    return "";
                }
            }
        }

        public bool IsNewMember {
            get { return this.CreatedOn.AddDays(1) > DateTime.Now; }
        }

        public bool HasAdSense {
            get { return !String.IsNullOrEmpty(this.AdsenseID); }
        }

        public bool IsInRole(string role) {
            foreach (string r in this.Roles.Split("|".ToCharArray())) {
                if (role == r)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is guest.
        /// </summary>
        /// <value><c>true</c> if this instance is guest; otherwise, <c>false</c>.</value>
        /// <remarks>
        /// Returns true if Identity.IsAuthenticated == false
        /// Returns false if Identity.IsAuthenticated == true
        /// </remarks>
        public bool IsGuest
        {
            get { return !System.Web.HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public bool IsUser {
            get { return this.IsInRole("user"); }
        }

        public bool IsPowerUser {
            get { return this.IsInRole("poweruser"); }
        }

        public bool IsModerator {
            get { return this.IsInRole("moderator"); }
        }

        public bool IsDebugger {
            get { return this.IsInRole("debugger"); }
        }

        public bool IsAdministrator {
            get { return this.IsInRole("administrator"); }
        }

        public bool IsHostModerator(string hostName) {
            return IsModerator || this.IsInRole(hostName + ":moderator");
        }

        public bool HasRoles(List<string> roles) {
            foreach (string role in roles)
                if (!this.IsInRole(role))
                    return false;
            return true;
        }

        public UserCollection Friends {
            get {
                UserCollection friends = new UserCollection();
                foreach (UserFriend friend in this.UserFriendRecordsFromUser())
                    friends.Add(UserCache.GetUser(friend.FriendID));
                return friends;
            }
        }

        public UserCollection FriendsBy {
            get {
                UserCollection friendsBy = new UserCollection();
                foreach (UserFriend friend in this.UserFriendRecords())
                    friendsBy.Add(UserCache.GetUser(friend.UserID));
                return friendsBy;
            }
        }

        public bool IsFriendOf(int userID) {
            foreach (UserFriend friend in this.UserFriendRecordsFromUser()) {
                if (friend.FriendID == userID)
                    return true;
            }
            return false;
        }

        public bool IsFriendBy(int userID) {
            foreach (UserFriend friend in this.UserFriendRecords()) {
                if (friend.UserID == userID)
                    return true;
            }
            return false;
        }

        public void AddFriend(int friendID) {
            UserFriend.Insert(this.UserID, friendID, DateTime.Now);
            UserCache.RemoveUser(this.UserID);
            UserCache.RemoveUser(friendID);
        }

        public void RemoveFriend(int friendID) {
            Query query = new Query(UserFriend.Schema).WHERE(UserFriend.Columns.UserID, this.UserID).AND(UserFriend.Columns.FriendID, friendID);
            UserFriend friend = new UserFriend();
            friend.LoadAndCloseReader(UserFriend.FetchByQuery(query));
            UserFriend.Destroy(friend.UserFriendID);
                         
            UserCache.RemoveUser(this.UserID);
            UserCache.RemoveUser(friendID);
        }
    }
}
