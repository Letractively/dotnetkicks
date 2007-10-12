using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Security.Principal;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// KickPage is the base class for most pages within the project
    /// </summary>
    public class KickPage : System.Web.UI.Page
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

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [display ads].
        /// </summary>
        /// <value><c>true</c> if [display ads]; otherwise, <c>false</c>.</value>
        public bool DisplayAds
        {
            get
            {
                if (this._displayAds)
                    return this.HostProfile.ShowAds;
                else
                    return false;
            }
            set { this._displayAds = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [display announcement].
        /// </summary>
        /// <value><c>true</c> if [display announcement]; otherwise, <c>false</c>.</value>
        public bool DisplayAnnouncement
        {
            get { return this._displayAnnouncement; }
            set { this._displayAnnouncement = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [display side ads].
        /// </summary>
        /// <value><c>true</c> if [display side ads]; otherwise, <c>false</c>.</value>
        public bool DisplaySideAds
        {
            get { return this._displaySideAds; }
            set { this._displaySideAds = value; }
        }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public string Host
        {
            get { return HostHelper.GetHostName(this.Request.Url); }
        }

        /// <summary>
        /// Gets the host profile.
        /// </summary>
        /// <value>The host profile.</value>
        public Host HostProfile
        {
            get
            {
                if (this._hostProfile == null)
                {
                    this._hostProfile = HostCache.GetHost(HostHelper.GetHostAndPort(this.Request.Url));
                }
                return this._hostProfile;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        public bool IsAuthenticated
        {
            get { return this.User.Identity.IsAuthenticated; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is host moderator.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is host moderator; otherwise, <c>false</c>.
        /// </value>
        public bool IsHostModerator
        {
            get { return this.KickUserProfile.IsHostModerator(this.HostProfile.HostName); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is member page.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is member page; otherwise, <c>false</c>.
        /// </value>
        public bool IsMemberPage
        {
            get { return this._isMemberPage; }
            set { this._isMemberPage = value; }
        }

        /// <summary>
        /// Gets the kick user profile.
        /// </summary>
        /// <value>The kick user profile.</value>
        public User KickUserProfile
        {
            get
            {
                if (this._userProfile == null)
                {
                    this._userProfile = ((IKickPrincipal)base.User).KickUserProfile;
                }
                return this._userProfile;
            }
        }

        /// <summary>
        /// Gets the master page base CSS URL.
        /// </summary>
        /// <value>The master page base CSS URL.</value>
        public string MasterPageBaseCssUrl
        {
            get { return this.MasterPageBaseUrl + @"/Default.css"; }
        }

        /// <summary>
        /// Gets the master page base URL.
        /// </summary>
        /// <value>The master page base URL.</value>
        public string MasterPageBaseUrl
        {
            get { return this.HostProfile.RootUrl + "/Templates"; }
        }

        /// <summary>
        /// Gets the master page template CSS URL.
        /// </summary>
        /// <value>The master page template CSS URL.</value>
        public string MasterPageTemplateCssUrl
        {
            get { return this.MasterPageTemplateUrl + @"/Template.css"; }
        }

        /// <summary>
        /// Gets the master page template URL.
        /// </summary>
        /// <value>The master page template URL.</value>
        public string MasterPageTemplateUrl
        {
            get { return this.MasterPageBaseUrl + "/" + this.HostProfile.Template; }
        }

        /// <summary>
        /// Gets or sets the name of the page.
        /// </summary>
        /// <value>The name of the page.</value>
        public UrlFactory.PageName PageName
        {
            get { return this._pageName; }
            set { this._pageName = value; }
        }

        /// <summary>
        /// Gets or sets the required roles.
        /// </summary>
        /// <value>The required roles.</value>
        public List<string> RequiredRoles
        {
            get { return this._requiredRoles; }
            set { this._requiredRoles = value; }
        }

        /// <summary>
        /// Gets the static icon root URL.
        /// </summary>
        /// <value>The static icon root URL.</value>
        public string StaticIconRootUrl
        {
            get { return this.StaticImageRootUrl + "/Icons"; }
        }

        /// <summary>
        /// Gets the static emoticons root URL.
        /// </summary>
        /// <value>The static emoticons root URL.</value>
        public string StaticEmoticonsRootUrl
        {
            get { return this.StaticImageRootUrl + "/Emoticons"; }
        }

        /// <summary>
        /// Gets the static image root URL.
        /// </summary>
        /// <value>The static image root URL.</value>
        public string StaticImageRootUrl
        {
            get { return this.StaticRootUrl + "/Images"; }
        }

        /// <summary>
        /// Gets the static root URL.
        /// </summary>
        /// <value>The static root URL.</value>
        public string StaticRootUrl
        {
            get
            {
                if (this.Host == "localhost")
                    return this.ResolveUrl("http://localhost:8080/Static");
                else if (this.HostProfile.UseStaticRoot)
                    return "http://static." + this.HostProfile.HostName;
                else
                    return this.ResolveUrl("/Static");
            }
        }

        /// <summary>
        /// Gets the static script root URL.
        /// </summary>
        /// <value>The static script root URL.</value>
        public string StaticScriptRootUrl
        {
            get { return this.StaticRootUrl + "/Scripts"; }
        }

        /// <summary>
        /// Gets or sets the sub caption.
        /// </summary>
        /// <value>The sub caption.</value>
        public string SubCaption
        {
            get { return this._subCaption; }
            set { this._subCaption = value; }
        }

        /// <summary>
        /// Gets the URL parameters.
        /// </summary>
        /// <value>The URL parameters.</value>
        public UrlParameters UrlParameters
        {
            get
            {
                if (this._urlParameters == null)
                    this._urlParameters = UrlParametersHelper.GetUrlParameters(this.Request, this.HostProfile.HostName);

                return this._urlParameters;
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
            if (!this.KickUserProfile.IsAdministrator)
                this.NotAuthorisedRedirect();
        }

        /// <summary>
        /// Demands the moderator role.
        /// </summary>
        public void DemandModeratorRole()
        {
            if (!this.KickUserProfile.IsModerator)
                this.NotAuthorisedRedirect();
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
            this.RequiredRoles.Add("administrator");
        }

        /// <summary>
        /// Requireses the moderator role.
        /// </summary>
        public void RequiresModeratorRole()
        {
            this.RequiredRoles.Add("moderator");
        }

        //  Protected Methods 

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Page.InitComplete"></see> event after page initialization.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnInitComplete(EventArgs e)
        {
            this.PerformSecurityChecks();
            base.OnInitComplete(e);
        }

        //  Private Methods 

        /// <summary>
        /// Performs the security checks.
        /// </summary>
        private void PerformSecurityChecks()
        {
            if (this.IsMemberPage && !this.IsAuthenticated)
                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.Login, this.Request.Url.ToString()));

            if (!this.KickUserProfile.HasRoles(this.RequiredRoles))
                this.NotAuthorisedRedirect();
        }

        #endregion 

    }
}
