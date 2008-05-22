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
            this.GoToLogin();
            this.TextField(Find.ByName(new Regex("Username"))).TypeText(username);
            this.TextField(Find.ByName(new Regex("Password"))).TypeText(password);
            this.Button(Find.ByName(new Regex("LogIn"))).Click();
            return this;
        }

        public DnkBrowser AdminLogin() {
            return this.Login("admin", "admin");
        }
        public DnkBrowser ModeratorLogin() {
            return this.Login("moderator", "moderator");
        }
        public DnkBrowser UserLogin() {
            return this.Login("user1", "user1");
        }

        public DnkBrowser Logout() {
            this.GoTo(_rootUrl + "logout");
            return this;
        }

        public DnkBrowser GoToLogin() {
            this.GoTo(_rootUrl + "login");
            return this;
        }

        public DnkBrowser GoToAdmin() {
            this.GoTo(_rootUrl + "admin");
            return this;
        }


        public bool IsAdminPage {
            get { return this.Url.EndsWith("/admin"); }
        }

        public bool IsNotAuthorisedPage {
            get { return this.Url.EndsWith("/notauthorised"); }
        }
    }
}
