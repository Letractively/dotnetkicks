using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
//using Incremental.Kick.Web.Helpers;
//using Incremental.Kick.Config;
//using Incremental.Kick.Common.DataSets.Rows;
//using Incremental.Kick.Common.Entities;

namespace Incremental.Kick.Web.Controls {
    public class KickUIPage : KickPage {

        private string _adSenseID;
        public string AdSenseID {
            get {
                if (string.IsNullOrEmpty(this._adSenseID))
                    return this.HostProfile.AdsenseID;
                else
                    return this._adSenseID;
            }
            set { this._adSenseID = value; }
        }



        private string _rssFeedUrl;
        public string RssFeedUrl {
            get { return this._rssFeedUrl; }
            set { this._rssFeedUrl = value.Replace(@"//", @"/"); }
        }

        public bool HasRssFeed {
            get { return !String.IsNullOrEmpty(this.RssFeedUrl); }
        }















        public void AddJavaScript(string relativeUrl) {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = this.ResolveUrl(relativeUrl);

            this.Header.Controls.Add(script);

            Literal literal = new Literal();
            literal.Text = "\n";
            this.Header.Controls.Add(literal);
        }

        public void AddStyleSheet(string relativeUrl) {
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = this.ResolveUrl(relativeUrl);
            cssLink.Attributes["type"] = "text/css";
            cssLink.Attributes["rel"] = "stylesheet";

            this.Header.Controls.Add(cssLink);

            Literal literal = new Literal();
            literal.Text = "\n";
            this.Header.Controls.Add(literal);
        }

        public void AddRssUrl(string relativeUrl) {
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = this.ResolveUrl(relativeUrl);
            cssLink.Attributes["type"] = "application/rss+xml";
            cssLink.Attributes["rel"] = "alternate";

            this.Header.Controls.Add(cssLink);

            Literal literal = new Literal();
            literal.Text = "\n";
            this.Header.Controls.Add(literal);
        }

        protected override void OnPreInit(EventArgs e) {
            this.MasterPageFile = "~/Templates/" + this.HostProfile.Skin + "/MasterPage.master";
            // System.Diagnostics.Trace.WriteLine("The masterpage is " + this.MasterPageFile);
            //this.Theme = this.HostProfile.Skin; //NOTE: GJ: should we remove themes?
            // System.Diagnostics.Trace.WriteLine("The page theme is " + this.HostProfile.Skin);

            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e) {
            this.AddStyleSheet(this.MasterPageBaseCssUrl);
            this.AddStyleSheet(this.MasterPageSkinCssUrl);

            this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Dojo/Dojo.js");
            this.AddJavaScript(this.ResolveUrl("~/Scripts/Constants.aspx"));
            this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Ajax.js");
            this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Common.js");
            this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Tagging.js");

            //TODO: GJ: add some booleans
            this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Controls/PopularStoryHeader.js");
            this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Controls/PopularStoryNavigator.js");

            if (this.IsHostModerator)
                this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Moderator/HostModerator.js");

            if (this.KickUserProfile.IsAdministrator)
                this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Admin/Kick.js");

            if (!String.IsNullOrEmpty(this.RssFeedUrl))
                this.AddRssUrl(this.HostProfile.RootUrl + this.RssFeedUrl);

            if (this.KickUserProfile.IsDebugger) {
                DebugInformation debugInfo = new DebugInformation();
                this.Controls.Add(debugInfo);

                // this.AddJavaScript(this.StaticScriptRootUrl + "/2.0.1/Dojo/jsTrace.js");

            }

            base.OnPreRender(e);
        }
    }
}