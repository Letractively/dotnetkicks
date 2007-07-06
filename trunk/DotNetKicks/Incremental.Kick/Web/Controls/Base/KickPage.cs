using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Common.Entities;
using Incremental.Kick.Config;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;
//using Incremental.Kick.Config;
//using Incremental.Kick.Caching;
//using Incremental.Kick.Common.DataSets.Rows;
//using Incremental.Kick.Common.Entities;
//using Incremental.Kick.Security.Principal;

namespace Incremental.Kick.Web.Controls {
    public class KickPage : System.Web.UI.Page {



        private bool _isMemberPage = false;
        //private bool _isCachedPage = false;   
        //private bool _isCachedAuthenticatedPage = false;

        private UrlFactory.PageName _pageName;
        public UrlFactory.PageName PageName {
            get { return this._pageName; }
            set { this._pageName = value; }
        }

        public bool IsAuthenticated {
            get { return this.User.Identity.IsAuthenticated; }
        }

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

        public string MasterPageSkinUrl {
            get { return this.MasterPageBaseUrl + "/" + this.HostProfile.Skin; }
        }

        public string MasterPageSkinCssUrl {
            get { return this.MasterPageSkinUrl + @"/Template.css"; }
        }
        private bool _displayAds = true;
        public bool DisplayAds {
            get {
                if (this._displayAds) {
                    //TEMP: remove when we have added a show ads to the KickUserProfile
                    if (this.IsAuthenticated) {
                        if (this.KickUserProfile.Username == "gavinjoyce") {
                            return false;
                        }
                    }

                    return this.HostProfile.ShowAds;
                } else {
                    return false;
                }
            }
            set { this._displayAds = value; }
        }

        private bool _displaySideAds = false;
        public bool DisplaySideAds {
            get {
                if (this._displaySideAds) {
                    return this.WebUIConfig.ShowGoogleAds;
                } else {
                    return false;
                }
            }
            set { this._displaySideAds = value; }
        }

        protected override void OnInitComplete(EventArgs e) {
            //perform permission checks here
            if (this.IsMemberPage && !this.IsAuthenticated)
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.Login)); //TODO: pass the current url here so we can redirect



            base.OnInitComplete(e);
        }

        protected override void OnLoad(EventArgs e) {

            // if (this.IsCachedPage)
            //    Response.Cache.AddValidationCallback(new HttpCacheValidateHandler(this.CacheValidator), null);

            base.OnLoad(e);
        }

        /* public void CacheValidator(HttpContext context, Object data, ref HttpValidationStatus status) {
             if (context.User.Identity.IsAuthenticated)
                 status = HttpValidationStatus.IgnoreThisRequest;
             else
                 status = HttpValidationStatus.Valid;
         }*/



    }
}
