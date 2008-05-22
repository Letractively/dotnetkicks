using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Dal.Entities.Api {
    public class ApiChat {
        public ApiChat() { }

        public ApiChat(int chatID, string title, string description, List<ApiShout> shouts) {
            this._chatID = chatID;
            this._title = title;
            this._description = description;
            this._shouts = shouts;
        }

        private int _chatID;
        public int ChatID {
            get { return _chatID; }
            set { _chatID = value; }
        }

        private string _title;
        public string Title {
            get { return _title; }
            set { _title = value; }
        }

        private string _description;
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        private List<ApiShout> _shouts = new List<ApiShout>();
        public List<ApiShout> Shouts {
            get { return _shouts; }
            set { _shouts = value; }
        }
    }
}
