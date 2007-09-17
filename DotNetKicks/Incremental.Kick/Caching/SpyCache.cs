using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Caching {
   public class SpyCache {
       public static Spy GetSpy(int hostID) {
           CacheManager<string, Spy> hostSpyCache = GetSpyCache();
           string cacheKey = String.Format("HostSpy_{0}", hostID);
           Spy spy = hostSpyCache[cacheKey];

           if (spy == null) {
               spy = new Spy();
               hostSpyCache.Insert(cacheKey, spy, 999999, System.Web.Caching.CacheItemPriority.NotRemovable); //TODO: GJ: allow caching for ever
           }

           return spy;
       }

       private static CacheManager<string, Spy> GetSpyCache() {
           return CacheManager<string, Spy>.GetInstance();
       }
    }

    public class Spy {
        private SpyList<SpyItem> _allSpyItems = new SpyList<SpyItem>();
        private SpyList<SpyItem> _kickSpyItems = new SpyList<SpyItem>();

        public SpyList<SpyItem> AllItems {
            get { return this._allSpyItems; }
        }

        public void Kick(int userID, int storyID) {
            this.Kick(UserCache.GetUser(userID), Story.FetchByID(storyID));
        }
        public void Kick(int userID, string storyIdentifier) {
            this.Kick(UserCache.GetUser(userID), Story.FetchStoryByIdentifier(storyIdentifier));
        }
        public void Kick(User user, Story story) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.Kick;
            spyItem.UserID = user.UserID;
            spyItem.Message = String.Format("kicked {0}", this.GetStoryLink(story));
            this.AddSpyItem(spyItem);
        }

        public void UnKick(int userID, int storyID) {
            this.UnKick(UserCache.GetUser(userID), Story.FetchByID(storyID));
        }
        public void UnKick(int userID, string storyIdentifier) {
            this.UnKick(UserCache.GetUser(userID), Story.FetchStoryByIdentifier(storyIdentifier));
        }
        public void UnKick(User user, Story story) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.UnKick;
            spyItem.UserID = user.UserID;
            spyItem.Message = String.Format("un-kicked {0}", this.GetStoryLink(story));
            this.AddSpyItem(spyItem);
        }

        public void Comment(int userID, int commentID, int storyID) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.Comment;
            spyItem.UserID = userID;
            spyItem.Message = String.Format("commented on {0}", this.GetStoryLink(Story.FetchByID(storyID)));
            this.AddSpyItem(spyItem);
        }

        public void StorySubmission(User user, string storyIdentifier) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.StorySubmission;
            spyItem.UserID = user.UserID;
            spyItem.Message = String.Format("submitted {0}", this.GetStoryLink(Story.FetchStoryByIdentifier(storyIdentifier)));
            this.AddSpyItem(spyItem);
        }

        public void Shout(User user, string message, User forUser) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.Shout;
            spyItem.UserID = user.UserID;
            spyItem.Message = String.Format("shouted something on {0}'s profile", forUser.Username);
            this.AddSpyItem(spyItem);
        }

        public void Shout(User user, string message) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.Shout;
            spyItem.UserID = user.UserID;
            spyItem.Message = String.Format("shouted something");
            this.AddSpyItem(spyItem);
        }

        public void UserRegistration(User user) {
            SpyItem spyItem = new SpyItem();
            spyItem.Type = SpyItemType.UserRegistration;
            spyItem.UserID = user.UserID;
            spyItem.Message = String.Format("has joined the site. Welcome!!");
            this.AddSpyItem(spyItem);
        }

        private void AddSpyItem(SpyItem item) {
            this._allSpyItems.Add(item);
            //TODO: GJ: add the item to the categorised list based on SpyItemType
        }

        private string GetStoryLink(Story story) {//TODO: GJ: create a StoryLink server control
            string kickStoryUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, story.Category.CategoryIdentifier);
            return string.Format(@"<a href=""{0}"" />{1}</a>", kickStoryUrl, story.Title);
        }
    }

    public enum SpyItemType {
        Kick,
        UnKick,
        Comment,
        StorySubmission,
        Tag,
        Shout,
        UserRegistration
    }

    public class SpyItem {
        private SpyItemType _spyItemType;
        private DateTime _createdOn = DateTime.Now;
        private int _userID;
        private string _message = "";
        
        public SpyItemType Type {
            get { return this._spyItemType; }
            set { this._spyItemType = value; }
        }
        public DateTime CreatedOn {
            get { return this._createdOn; }
            set { this._createdOn = value; }
        }
        public int UserID {
            get { return this._userID; }
            set { this._userID = value; }
        }
        public string Message {
            get { return this._message; }
            set { this._message = value; }
        }
    }

    public class SpyList<T> :  IEnumerable<T> {
        private List<T> _list = new List<T>();
        private int _maxSize = 120;

        public int MaxSize {
            get { return this._maxSize; }
            set { this._maxSize = value; }
        }

        public int Count {
            get { return this._list.Count; }
        }

        public T this[int index] {
            get { return this._list[index]; }
        }

        public void Add(T item) {
            this._list.Insert(0, item);
            if (this._list.Count > this._maxSize)
                this._list.RemoveAt(this._maxSize);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this._list.GetEnumerator();
        }      
    }
}
