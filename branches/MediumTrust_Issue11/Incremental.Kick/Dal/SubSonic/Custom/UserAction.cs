using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;
using System.Data;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Web.Controls;
using Incremental.Common.Web.Helpers;

namespace Incremental.Kick.Dal {
    public partial class UserAction {

        public enum ActionType {
            Kick = 1,
            UnKick = 2,
            Comment = 3,
            StorySubmission = 4,
            StoryPromotion = 5,
            Tag = 6,
            Shout = 7,
            UserBan = 8,
            UserRegistration = 9,
            ChatRoomCreation = 10,
            ChatRoomOpening = 11,
            ChatRoomClosing = 12,
            UserUnBan = 13,
            StoryDeletion = 14
        }

        public ActionType UserActionType {
            get { return (ActionType)this.UserActionTypeID; }
        }

        protected override void BeforeInsert() {
            if (this.Message.Length > 1000)
                this.Message = this.Message.Substring(0, 1000);
            base.BeforeInsert();
        }

        public bool IsPublic {
            get { return ((this.UserActionType != ActionType.UserBan) && (this.UserActionType != ActionType.UserUnBan) && (this.UserActionType != ActionType.StoryDeletion)); }
        }
        
        #region Create Methods

        //NOTE: GJ: Adding custom UserAction constructors was causing funny SubSonic behaviour.
        public static UserAction Create(int hostID, int userID, ActionType userActionType) {
            UserAction userAction = new UserAction();
            userAction.HostID = hostID;
            userAction.UserID = userID;
            userAction.UserActionTypeID = (int)userActionType;
            return userAction;
        }

        public static UserAction Create(int hostID, int userID, int storyID, ActionType userActionType) {
            UserAction userAction = Create(hostID, userID, userActionType);
            userAction.StoryID = storyID;
            return userAction;
        }


        public static UserAction RecordKick(int hostID, User user, Story story) {
            UserAction userAction = Create(hostID, user.UserID, story.StoryID, ActionType.Kick);
            userAction.Message = String.Format("kicked {0}", GetStoryLink(story));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordUnKick(int hostID, User user, Story story) {
            UserAction userAction = Create(hostID, user.UserID, story.StoryID, ActionType.Kick);
            userAction.Message = String.Format("un-kicked {0}", GetStoryLink(story));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordComment(int hostID, User user, Story story, int commentID) {
            UserAction userAction = Create(hostID, user.UserID, story.StoryID, ActionType.Comment);
            userAction.Message = String.Format("commented on {0}", GetStoryLink(story, commentID));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordStorySubmission(int hostID, User user, Story story) {
            UserAction userAction = Create(hostID, user.UserID, story.StoryID, ActionType.StorySubmission);
            userAction.Message = String.Format("submitted {0}", GetStoryLink(story));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordStoryPromotion(int hostID, Story story) {
            UserAction userAction = new UserAction();
            userAction.HostID = hostID;
            userAction.StoryID = story.StoryID;
            userAction.UserActionTypeID = (int)ActionType.StoryPromotion;
            userAction.Message = String.Format("{0} was published to homepage", GetStoryLink(story));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordTag(int hostID, User user, Story story, WeightedTagList tags) {
            UserAction userAction = Create(hostID, user.UserID, story.StoryID, ActionType.Tag);

            if (tags.Count > 0) {
                TagCommaList tagList = new TagCommaList();
                tagList.DataBind(tags, story.StoryID, false);

                userAction.Message = String.Format("tagged {0} with {1}", GetStoryLink(story), ControlHelper.RenderControl(tagList));
                userAction.Save();
            }
            return userAction;
        }

        public static UserAction RecordShout(int hostID, User user) {
            UserAction userAction = Create(hostID, user.UserID, ActionType.Shout);
            userAction.Message = "shouted something";
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordShout(int hostID, User user, User toUser) {
            UserAction userAction = Create(hostID, user.UserID, ActionType.Shout);
            UserLink userLink = new UserLink(toUser);
            userAction.Message = String.Format("shouted something on {0}'s profile", ControlHelper.RenderControl(userLink));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordUserBan(int hostID, User user, User moderator) {
            UserAction userAction = Create(hostID, moderator.UserID, ActionType.UserBan);
            userAction.ToUserID = user.UserID;
            UserLink userLink = new UserLink(user);
            userAction.Message = String.Format(" banned {0}", ControlHelper.RenderControl(userLink));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordUserUnBan(int hostID, User user, User moderator) {
            UserAction userAction = Create(hostID, moderator.UserID, ActionType.UserUnBan);
            userAction.ToUserID = user.UserID;
            UserLink userLink = new UserLink(user);
            userAction.Message = String.Format(" un-banned {0}", ControlHelper.RenderControl(userLink));
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordUserRegistration(int hostID, User user) {
            UserAction userAction = Create(hostID, user.UserID, ActionType.UserRegistration);
            userAction.Message = "has joined the site. Welcome!!";
            userAction.Save();
            return userAction;
        }

        public static UserAction RecordStoryDeletion(int hostID, Story story, User moderator) {
            UserAction userAction = Create(hostID, moderator.UserID, ActionType.StoryDeletion);
            userAction.Message = String.Format(" deleted {0}", GetStoryLink(story));
            userAction.Save();
            return userAction;
        }

        private static string GetStoryLink(Story story) {
            return string.Format(@"<a href=""/{0}/{1}"">{2}</a>", story.Category.CategoryIdentifier, story.StoryIdentifier, story.Title);
        }

        private static string GetStoryLink(Story story, int commentID) {
            return string.Format(@"<a href=""/{0}/{1}#Comment_{3}"">{2}</a>", story.Category.CategoryIdentifier, story.StoryIdentifier, story.Title, commentID);
        }


        #endregion

        #region Fetch Methods

        public static UserActionCollection FetchCollection(int hostID, int pageIndex, int pageSize, int? userID, Nullable<ActionType> actionType, int? storyID, int? chatID) {
            return FetchCollection(GetPagedQuery(hostID, pageIndex, pageSize, userID, actionType, storyID, chatID));
        }
        public static int GetCount(int hostID, int? userID, Nullable<ActionType> actionType, int? storyID, int? chatID) {
            return GetCount(GetQuery(hostID, userID, actionType, storyID, chatID));
        }
        public static UserActionCollection FetchCollection(Query query) { //NOTE: GJ: it would be useful to have this in the SubSonic generated type
            UserActionCollection collection = new UserActionCollection();
            collection.Load(query.ExecuteReader());
            return collection;
        }
        public static int GetCount(Query query) {
            return query.GetCount(UserAction.Columns.UserActionID);
        }

        public static Query GetPagedQuery(int hostID, int pageIndex, int pageSize, int? userID, Nullable<ActionType> actionType, int? storyID, int? chatID) {
            Query query = GetQuery(hostID, userID, actionType, storyID, chatID);
            query.PageIndex = pageIndex;
            query.PageSize = pageSize;
            return query;
        }
        public static Query GetQuery(int hostID, int? userID, Nullable<ActionType> actionType, int? storyID, int? chatID) {
            Query query = new Query(UserAction.Schema).WHERE(UserAction.Columns.HostID, hostID).ORDER_BY(UserAction.Columns.CreatedOn, "DESC");
            if (userID.HasValue)
                query = query.AND(UserAction.Columns.UserID, userID);
            if (actionType.HasValue)
                query = query.AND(UserAction.Columns.UserActionTypeID, (int)actionType.Value);
            if (storyID.HasValue)
                query = query.AND(UserAction.Columns.StoryID, storyID);
            if (chatID.HasValue)
                query = query.AND(UserAction.Columns.ChatID, chatID);
            return query;
        }

        #endregion
    }
}
