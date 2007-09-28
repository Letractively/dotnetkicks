using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Dal.Entities.Api {
    public class ApiStory {

        public ApiStory() { }

        public ApiStory(string title, string url, string description, DateTime createdOn, DateTime publishedOn, bool isPublished, int kickCount, int commentCount, ApiUser user) {
            this._title = title;
            this._url = url;
            this._description = description;
            this._createdOn = createdOn;
            if(isPublished)
                this._publishedOn = publishedOn;
            this._kickCount = kickCount;
            this._commentCount = commentCount;
            this._user = user;
        }

        private string _title;
        public string Title {
            get { return _title; }
            set { _title = value; }
        }

        private string _url;
        public string Url {
            get { return _url; }
            set { _url = value; }
        }

        private string _description;
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        private DateTime? _publishedOn;
        public DateTime? PublishedOn {
            get { return _publishedOn; }
            set { _publishedOn = value; }
        }

        private int _kickCount;
        public int KickCount {
            get { return _kickCount; }
            set { _kickCount = value; }
        }

        private int _commentCount;
        public int CommentCount {
            get { return _commentCount; }
            set { _commentCount = value; }
        }

        private ApiUser _user;
        public ApiUser User {
            get { return _user; }
            set { _user = value; }
        }
    }
}
