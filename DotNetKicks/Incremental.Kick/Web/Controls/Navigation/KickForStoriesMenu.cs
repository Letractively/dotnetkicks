using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class KickForStoriesMenu : KickWebControl {

        private bool _displayEditorLinks = true;
        private bool _displayCategories = true;
        private bool _displayOtherKickSites = true;
        private bool _displayWhatElse = true;
        private bool _displayAds = false;
        private bool _displayTags = true;

        public bool DisplayEditorLinks {
            get { return this._displayEditorLinks; }
            set { this._displayEditorLinks = value; }
        }
        public bool DisplayCategories {
            get { return this._displayCategories; }
            set { this._displayCategories = value; }
        }
        public bool DisplayOtherKickSites {
            get { return this._displayOtherKickSites; }
            set { this._displayOtherKickSites = value; }
        }
        public bool DisplayWhatElse {
            get { return this._displayWhatElse; }
            set { this._displayWhatElse = value; }
        }
        public bool DisplayAds {
            get { return this._displayAds; }
            set { this._displayAds = value; }
        }

        public bool DisplayTags {
            get { return this._displayTags; }
            set { this._displayTags = value; }
        }

        protected override void Render(HtmlTextWriter writer) {

            if (this.DisplayEditorLinks) {
                StyledPanel editorPanel = new StyledPanel();
                editorPanel.Caption = "You are the editor:";
                editorPanel.RenderTop(writer);
                writer.WriteLine(@"
                <div class=""SideBarLink"">
                <a href=""{0}""><img src=""{3}/find.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{0}"">View upcoming stories</a></div>
                <div class=""SideBarLink"">
                <a href=""{1}""><img src=""{3}/submit.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{1}"">Submit a story</a></div>
                
                <div class=""SideBarLink"">
                <a href=""{2}""><img src=""{3}/community.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{2}"">How else can I help?</a></div>
            ", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories),
                 UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory),
                 UrlFactory.CreateUrl(UrlFactory.PageName.Contribute),
                this.KickPage.StaticIconRootUrl);

                if (this.KickPage.HostProfile.ShowAds) {
                    writer.WriteLine(@"
                        <div class=""SideBarLink"">
                        <a href=""{0}""><img src=""{1}/adsense.png"" width=""16"" height=""16"" border=""0""/></a>
                        <a href=""{0}"">Earn money</a> </div>
                    ", UrlFactory.CreateUrl(UrlFactory.PageName.EarnMoney),
                    this.KickPage.StaticIconRootUrl);
                }
 
                editorPanel.RenderBottom(writer);
            }

            /* NOTE: GJ: removing ads from here - they should be set in the template
             * if (this.DisplayAds && this.KickPage.DisplayAds) {
                StyledPanel adsPanel = new StyledPanel();
                adsPanel.StyledPanelStyle = StyledPanelStyle.GreenPanelPlain;
                adsPanel.Caption = "";
                adsPanel.RenderTop(writer);

                GoogleWideSkyscraper googleAds = new GoogleWideSkyscraper();
                this.Controls.Add(googleAds);
                googleAds.RenderControl(writer);

                adsPanel.RenderBottom(writer);
            }*/

            if (this.DisplayTags) {
                StyledPanel categoryPanel = new StyledPanel();

                string userTagsUrl;
                if(this.KickPage.KickUserProfile.IsValidated)
                    userTagsUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserTags, this.KickPage.KickUserProfile.Username);
                else
                    userTagsUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Login);

                categoryPanel.Caption = String.Format(@"Tags: <span style=""font-size:0.7em"">  <a href=""{0}"">all tags</a> - <a href=""{1}"">your tags</a></span><br /><br />", UrlFactory.CreateUrl(UrlFactory.PageName.ViewTags), userTagsUrl);
                categoryPanel.RenderTop(writer);

                TagCloud tagCloud = new TagCloud();
                this.Controls.Add(tagCloud);
                tagCloud.DataBind(TagCache.GetTopHostTags(this.KickPage.HostProfile.HostID, 80));
                tagCloud.RenderControl(writer);

                categoryPanel.RenderBottom(writer);
            }

            if (this.DisplayCategories) {
                StyledPanel categoryPanel = new StyledPanel();
                categoryPanel.Caption = "Story categories:";
                categoryPanel.RenderTop(writer);
                CategoryCollection categories = CategoryCache.GetCategories(this.KickPage.HostProfile.HostID);
                foreach (Category category in categories) {
                    writer.WriteLine(@"<div class=""SideBarLink""><a href=""{0}""><img src=""{1}"" width=""16"" height=""16"" border=""0""/></a>
                    <a href=""{0}"">{2}</a>
                    <span class=""LightLink""><a href=""{0}/upcoming"">[find]</a></span></div>",
                        UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, category.CategoryIdentifier),
                        this.KickPage.StaticIconRootUrl + "/" + category.IconName,
                        category.Name);
                }

                writer.WriteLine(@"<br /><p align=""center""><a href=""mailto:{0}"">Suggest a new category</a></p>", this.KickPage.HostProfile.Email);
                categoryPanel.RenderBottom(writer);
            }


//            if (this.DisplayOtherKickSites) {
//                StyledPanel otherLinksPanel = new StyledPanel();
//                otherLinksPanel.Caption = "Other kick sites:";
//                otherLinksPanel.RenderTop(writer);

//                writer.WriteLine(@"
//
//                <div class=""SideBarLink""><img src=""{0}/teamsystem.png"" width=""16"" height=""16"" border=""0""/>
//                <a href=""http://www.dotnetkicks.com/"">DotNetKicks.com</a></div>
//
//                <div class=""SideBarLink""><img src=""{0}/customization.png"" width=""16"" height=""16"" border=""0""/>
//                <a href=""http://www.sharepointkicks.com/"">SharePointKicks.com</a></div>
//               
//                <div class=""SideBarLink""><img src=""{0}/security.png"" width=""16"" height=""16"" border=""0""/>
//                <a href=""http://www.securitykicks.com/"">SecurityKicks.com</a></div>
//
//                <div class=""SideBarLink""><img src=""{0}/community.png"" width=""16"" height=""16"" border=""0""/>
//                <a href=""http://www.kick.ie/"">Kick.ie</a></div>
//
//                <br />
//                Your login will work with all these sites.
// 
//                </div>
//            ", this.KickPage.StaticIconRootUrl);
//                otherLinksPanel.RenderBottom(writer);
//            }

//            StyledPanel friendsPanel = new StyledPanel();
//            friendsPanel.Caption = "Our friends:";
//            friendsPanel.RenderTop(writer);

//            writer.WriteLine(@"
//                <div class=""SideBarLink"">  
//                <img src=""{1}/external.png"" width=""10"" height=""10"" border=""0""/>
//                <a href=""{0}"">SubSonic</a></div>
//            ", "http://www.codeplex.com/actionpack/", this.KickPage.StaticIconRootUrl);
//            friendsPanel.RenderBottom(writer);


            if (this.DisplayWhatElse) {
                StyledPanel miscPanel = new StyledPanel();
                miscPanel.Caption = "What else?";
                miscPanel.RenderTop(writer);

                writer.WriteLine(@"
                <div class=""SideBarLink"">  
                <a href=""{0}""><img src=""{1}/submit.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{0}"">Add our feeds to your site</a>
                </div>

                <div class=""SideBarLink"">
                <a href=""{2}""><img src=""{1}/community.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{2}"">Help us spread the word</a></div>

            ", UrlFactory.CreateUrl(UrlFactory.PageName.JavaScriptFeeds), this.KickPage.StaticIconRootUrl, UrlFactory.CreateUrl(UrlFactory.PageName.Contribute));

                miscPanel.RenderBottom(writer);
            }
        }
    }
}
