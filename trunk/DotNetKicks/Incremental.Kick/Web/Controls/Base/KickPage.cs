using System;
using System.Collections.Generic;
using System.Web.UI;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// KickPage is the base class for most pages within the project
    /// </summary>
    public class KickPage : Page
    {
        #region Fields

        private string _caption = "";
        private bool _displayAds = true;
        private bool _displayAnnouncement = true;
        private bool _displaySideAds = true;
        private Host _hostProfile;
        private bool _isMemberPage = false;
        private UrlFactory.PageName _pageName;
        private List<string> _requiredRoles = new List<string>();
        private string _subCaption = "";
        private UrlParameters _urlParameters;
        private User _userProfile;

        #endregion

        #region Properties

        /*public bool IsCachedPage {
            get { return this._isCachedPage; }
            set { this._isCachedPage = value; }
        }
        public bool IsCachedAuthenticatedPage {
            get { return this._isCachedAuthenticatedPage; }
            set { this._isCachedAuthenticatedPage = value; }
        }*/

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public bool DisplayAds
        {
            get
            {
                if(_displayAds)
                    return HostProfile.ShowAds;
                else
                    return false;
            }
            set { _displayAds = value; }
        }

        public bool DisplayAnnouncement
        {
            get { return _displayAnnouncement; }
            set { _displayAnnouncement = value; }
        }

        public bool DisplaySideAds
        {
            get { return _displaySideAds; }
            set { _displaySideAds = value; }
        }

        public string Host
        {
            get { return HostHelper.GetHostName(Request.Url); }
        }

        public Host HostProfile
        {
            get
            {
                if(_hostProfile == null)
                    _hostProfile = HostCache.GetHost(HostHelper.GetHostAndPort(Request.Url));
                return _hostProfile;
            }
        }

        public bool IsAuthenticated
        {
            get { return User.Identity.IsAuthenticated; }
        }

        public bool IsHostModerator
        {
            get { return KickUserProfile.IsHostModerator(HostProfile.HostName); }
        }

        public bool IsMemberPage
        {
            get { return _isMemberPage; }
            set { _isMemberPage = value; }
        }

        public User KickUserProfile
        {
            get
            {
                if(_userProfile == null)
                    _userProfile = ((IKickPrincipal) User).KickUserProfile;
                return _userProfile;
            }
        }

        public string MasterPageBaseCssUrl
        {
            get { return MasterPageBaseUrl + @"/Default.css"; }
        }

        public string MasterPageBaseUrl
        {
            get { return HostProfile.RootUrl + "/Templates"; }
        }

        public string MasterPageTemplateCssUrl
        {
            get { return MasterPageTemplateUrl + @"/Template.css"; }
        }

        public string MasterPageTemplateUrl
        {
            get { return MasterPageBaseUrl + "/" + HostProfile.Template; }
        }

        public UrlFactory.PageName PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        public List<string> RequiredRoles
        {
            get { return _requiredRoles; }
            set { _requiredRoles = value; }
        }

        public string StaticIconRootUrl
        {
            get { return StaticImageRootUrl + "/Icons"; }
        }

        public string StaticEmoticonsRootUrl
        {
            get { return StaticImageRootUrl + "/Emoticons"; }
        }

        public string StaticImageRootUrl
        {
            get { return StaticRootUrl + "/Images"; }
        }

        public string StaticRootUrl
        {
            get
            {
                if(Host == "localhost")
                    return ResolveUrl("http://localhost:8080/Static");
                else if(HostProfile.UseStaticRoot)
                    return "http://static." + HostProfile.HostName;
                else
                    return ResolveUrl("/Static");
            }
        }

        public string StaticScriptRootUrl
        {
            get { return StaticRootUrl + "/Scripts"; }
        }

        public string SubCaption
        {
            get { return _subCaption; }
            set { _subCaption = value; }
        }

        public UrlParameters UrlParameters
        {
            get
            {
                if(_urlParameters == null)
                    _urlParameters = UrlParametersHelper.GetUrlParameters(Request, HostProfile.HostName);

                return _urlParameters;
            }
        }

        #endregion

        #region  Methods 

        //  Public Methods 

        /// <summary>
        /// Demands the administrator role.
        /// </summary>
        public void DemandAdministratorRole()
        {
            if(!KickUserProfile.IsAdministrator)
                NotAuthorisedRedirect();
        }

        /// <summary>
        /// Demands the moderator role.
        /// </summary>
        public void DemandModeratorRole()
        {
            if(!KickUserProfile.IsModerator)
                NotAuthorisedRedirect();
        }

        /// <summary>
        /// Nots the authorised redirect.
        /// </summary>
        public void NotAuthorisedRedirect()
        {
            Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.NotAuthorised));
        }

        /// <summary>
        /// Requireses the administrator role.
        /// </summary>
        public void RequiresAdministratorRole()
        {
            RequiredRoles.Add("administrator");
        }

        /// <summary>
        /// Requireses the moderator role.
        /// </summary>
        public void RequiresModeratorRole()
        {
            RequiredRoles.Add("moderator");
        }

        //  Protected Methods 

        protected override void OnInitComplete(EventArgs e)
        {
            PerformSecurityChecks();
            base.OnInitComplete(e);
        }

        //  Private Methods 

        /// <summary>
        /// Performs the security checks.
        /// </summary>
        private void PerformSecurityChecks()
        {
            if(IsMemberPage && !IsAuthenticated)
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.Login, Request.Url.ToString()));

            if(!KickUserProfile.HasRoles(RequiredRoles))
                NotAuthorisedRedirect();
        }

        #endregion
    }
}