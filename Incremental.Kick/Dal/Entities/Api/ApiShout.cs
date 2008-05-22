using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal.Entities.Api {
    public class ApiShout {
        public ApiShout() {}

        public ApiShout(int shoutID, ApiUser user, string message, DateTime createdOn) {
            this._shoutID = shoutID;
            this._user = user;
            this._message = message;
            this._createdOn = createdOn;
        }

        private int _shoutID;
        public int ShoutID {
            get { return _shoutID; }
            set { _shoutID = value; }
        }

        private ApiUser _user;
        public ApiUser User {
            get { return _user; }
            set { _user = value; }
        }

        private string _message;
        public string Message {
            get { return _message; }
            set { _message = value; }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
    }
}
