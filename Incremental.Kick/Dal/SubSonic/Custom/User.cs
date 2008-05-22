using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SubSonic;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Web.Controls;
using Incremental.Kick.Dal.Entities.Api;

namespace Incremental.Kick.Dal {
    public partial class User {
        public static User FetchUserByUsername(string username) {
            return User.FetchUserByParameter(User.Columns.Username, username);
        }

        public static User FetchUserByParameter(string columnName, object value) {
            //NOTE: GJ: maybe we should add support for this in SubSonic? (like rails does)
            UserCollection users = new UserCollection();
            users.Load(User.FetchByParameter(columnName, value));

            if (users.Count == 1)
                return users[0];
            else
                return null;
        }

        public static UserCollection FetchOnlineUsers(int minutesSinceLastActivity, int hostID) {
            Query query = new Query(User.Schema).WHERE(User.Columns.HostID, hostID).AddBetweenValues(User.Columns.LastActiveOn, DateTime.Now.AddMinutes(-minutesSinceLastActivity), DateTime.Now);
            query.OrderBy = SubSonic.OrderBy.Desc(User.Columns.LastActiveOn);
            UserCollection users = new UserCollection();
            users.Load(query.ExecuteReader());
            return users;
        }

        public static int GetTotalCount() {
            Query query = new Query(User.Schema);
            return query.GetCount(User.Columns.UserID);
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

        public bool IsGuest {
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


        public void UpdateStoryCommentShoutSpamStatus(bool isSpam) {
            //TODO: GJ: PERFORMANCE: update in one sql statement (low priority)
            foreach (Story story in this.StoryRecords()) {
                story.IsSpam = isSpam;
                //fix to Issue 22 where banned users stories are included in the
                //search results.
                story.UpdatedOn = DateTime.Now;
                story.Save();
            }
            foreach (Comment comment in this.CommentRecords()) {
                comment.IsSpam = isSpam;
                comment.Save();
            }
            foreach (Shout shout in this.ShoutRecords()) {
                shout.IsSpam = isSpam;
                shout.Save();
            }
        }

        public void Ban(User moderator, Host host) {
            this.IsBanned = true;
            this.Save();
            this.UpdateStoryCommentShoutSpamStatus(true);

            EmailHelper.SendUserBanEmail(this, host);
            UserAction.RecordUserBan(this.HostID, this, moderator);
            UserCache.RemoveUser(this.UserID);
        }

        public void UnBan(User moderator, Host host) {
            this.IsBanned = false;
            this.Save();
            this.UpdateStoryCommentShoutSpamStatus(false);

            EmailHelper.SendUserUnBanEmail(this, host);
            UserAction.RecordUserUnBan(this.HostID, this, moderator);
            UserCache.RemoveUser(this.UserID);
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
                //TODO: GJ: call a custom query to get non-banned friends
                UserCollection friendsBy = new UserCollection();
                foreach (UserFriend friend in this.UserFriendRecords()) {
                    User user = UserCache.GetUser(friend.UserID);
                    if (!user.IsBanned)
                        friendsBy.Add(user);
                }
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

        public ApiUser ToApi(Host host) {
            return new ApiUser(this.Username, host.RootUrl + UrlFactory.CreateUrl(UrlFactory.PageName.UserProfile, this.Username), new Gravatar(this, 50).GravatarUrl(host));
        }
    }
}
