using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Config;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;

namespace Incremental.Kick.Web.Controls {
    public class KickPage : System.Web.UI.Page {
        private UrlFactory.PageName _pageName;
        public UrlFactory.PageName PageName {
            get { return this._pageName; }
            set { this._pageName = value; }
        }

        private List<string> _requiredRoles = new List<string>();
        public List<string> RequiredRoles {
            get { return this._requiredRoles; }
            set { this._requiredRoles = value; }
        }
        public void RequiresAdministratorRole() {
            this.RequiredRoles.Add("administrator");
        }
        public void RequiresModeratorRole() {
            this.RequiredRoles.Add("moderator");
        }

        public bool IsAuthenticated {
            get { return this.User.Identity.IsAuthenticated; }
        }

        private bool _isMemberPage = false;
        public bool IsMemberPage {
            get { return this._isMemberPage; }
            set { this._isMemberPage = value; }
        }

        private string _caption = "";
        public string Caption {
            get { return this._caption; }
            set { this._caption = value; }
        }

        private string _subCaption = "";
        public string SubCaption {
            get { return this._subCaption; }
            set { this._subCaption = value; }
        }

        /*public bool IsCachedPage {
            get { return this._isCachedPage; }
            set { this._isCachedPage = value; }
        }
        
        public bool IsCachedAuthenticatedPage {
            get { return this._isCachedAuthenticatedPage; }
            set { this._isCachedAuthenticatedPage = value; }
        }*/

        private User _userProfile;
        public User KickUserProfile {
            get {
                if (this._userProfile == null) {
                    this._userProfile = ((IKickPrincipal)base.User).KickUserProfile;
                }
                return this._userProfile;
            }
        }

        public bool IsHostModerator {
            get { return this.KickUserProfile.IsHostModerator(this.HostProfile.HostName); }
        }

        private UrlParameters _urlParameters;
        public UrlParameters UrlParameters {
            get {
                if (this._urlParameters == null)
                    this._urlParameters = UrlParametersHelper.GetUrlParameters(this.Request, this.HostProfile.HostName);

                return this._urlParameters;
            }
        }


        public string Host {
            get { return HostHelper.GetHostName(this.Request.Url); }
        }

        private Host _hostProfile;
        public Host HostProfile {
            get {
                if (this._hostProfile == null) {
                    this._hostProfile = HostCache.GetHost(HostHelper.GetHostAndPort(this.Request.Url));
                }

                return this._hostProfile;
            }
        }

        private WebUIConfig _webUIConfig;
        public WebUIConfig WebUIConfig {
            get {
                if (this._webUIConfig == null) {
                    this._webUIConfig = WebUIConfigReader.GetConfig();
                }

                return this._webUIConfig;
            }
        }

        public string StaticRootUrl {
            get {
                if (this.Host == "localhost")
                    return this.ResolveUrl("http://localhost:8080/Static");
                else
                    return "http://static." + this.Host;
            }
        }

        public string StaticScriptRootUrl {
            get { return this.StaticRootUrl + "/Scripts"; }
        }

        public string StaticImageRootUrl {
            get { return this.StaticRootUrl + "/Images"; }
        }

        public string StaticIconRootUrl {
            get { return this.StaticImageRootUrl + "/Icons"; }
        }

        public string MasterPageBaseUrl {
            get { return this.HostProfile.RootUrl + "/Templates"; }
        }

        public string MasterPageBaseCssUrl {
            get { return this.MasterPageBaseUrl + @"/Default.css"; }
        }

        public string MasterPageTemplateUrl {
            get { return this.MasterPageBaseUrl + "/" + this.HostProfile.Template; }
        }

        public string MasterPageTemplateCssUrl {
            get { return this.MasterPageTemplateUrl + @"/Template.css"; }
        }
        private bool _displayAds = true;
        public bool DisplayAds {
            get {
                if (this._displayAds) 
                    return this.HostProfile.ShowAds;
                else 
                    return false;
            }
            set { this._displayAds = value; }
        }

        private bool _displaySideAds = true;
        public bool DisplaySideAds {
            get { return this._displaySideAds; }
            set { this._displaySideAds = value; }
        }

        private bool _displayAnnouncement = true;
        public bool DisplayAnnouncement {
            get { return this._displayAnnouncement; }
            set { this._displayAnnouncement = value; }
        }

        protected override void OnInitComplete(EventArgs e) {
            this.PerformSecurityChecks();
            base.OnInitComplete(e);
        }

        private void PerformSecurityChecks() {
            if (this.IsMemberPage && !this.IsAuthenticated)
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.Login, this.Request.Url.ToString()));

            if (!this.KickUserProfile.HasRoles(this.RequiredRoles))
                this.NotAuthorisedRedirect();
        }

        public void NotAuthorisedRedirect() {
            Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.NotAuthorised));
        }
    }
}
