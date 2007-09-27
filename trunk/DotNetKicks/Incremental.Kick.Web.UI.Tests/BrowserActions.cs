using System;
using System.Collections.Generic;
using System.Text;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace Incremental.Kick.Web.UI.Tests {
    public class DnkBrowser: IE {

        private string _rootUrl = "http://localhost:8080/";
        public string RootUrl {
            get { return this._rootUrl; }
            set { this._rootUrl = value; }
        }

        public DnkBrowser() { }
        public DnkBrowser(string rootUrl) {
            this._rootUrl = rootUrl;
        }

        public DnkBrowser Login(string username, string password) {
            this.GoTo(_rootUrl + "login");
            this.TextField(Find.ByName(new Regex("Username"))).TypeText(username);
            this.TextField(Find.ByName(new Regex("Password"))).TypeText(password);
            this.Button(Find.ByName(new Regex("LogIn"))).Click();
            return this;
        }

        public DnkBrowser Logout() {
            this.GoTo(_rootUrl + "logout");
            return this;
        }
    }
}
