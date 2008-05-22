using System;
using System.Web.UI;
using Incremental.Kick.Caching;
using Incremental.Kick.Dal;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.Controls
{
    public class KickForStoriesMenu : KickWebControl
    {
        private bool _displayAds = false;
        private bool _displayCategories = true;
        private bool _displayEditorLinks = true;
        private bool _displayTags = true;
        private bool _displayWhatElse = true;

        public bool DisplayEditorLinks
        {
            get { return _displayEditorLinks; }
            set { _displayEditorLinks = value; }
        }

        public bool DisplayCategories
        {
            get { return _displayCategories; }
            set { _displayCategories = value; }
        }

        public bool DisplayWhatElse
        {
            get { return _displayWhatElse; }
            set { _displayWhatElse = value; }
        }

        public bool DisplayAds
        {
            get { return _displayAds; }
            set { _displayAds = value; }
        }

        public bool DisplayTags
        {
            get { return _displayTags; }
            set { _displayTags = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if(DisplayEditorLinks)
            {
                StyledPanel editorPanel = new StyledPanel();
                editorPanel.Caption = "You are the editor:";
                editorPanel.RenderTop(writer);
                writer.WriteLine(
                    @"
                <div class=""SideBarLink"">
                <a href=""{0}""><img src=""{3}/find.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{0}"">View upcoming stories</a></div>
                <div class=""SideBarLink"">
                <a href=""{1}""><img src=""{3}/submit.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{1}"">Submit a story</a></div>
                
                <div class=""SideBarLink"">
                <a href=""{2}""><img src=""{3}/community.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{2}"">How else can I help?</a></div>
            ",
                    UrlFactory.CreateUrl(UrlFactory.PageName.NewStories), UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory),
                    UrlFactory.CreateUrl(UrlFactory.PageName.Contribute), KickPage.StaticIconRootUrl);

                if(KickPage.HostProfile.ShowAds)
                    writer.WriteLine(
                        @"
                        <div class=""SideBarLink"">
                        <a href=""{0}""><img src=""{1}/adsense.png"" width=""16"" height=""16"" border=""0""/></a>
                        <a href=""{0}"">Earn money</a> </div>
                    ",
                        UrlFactory.CreateUrl(UrlFactory.PageName.EarnMoney), KickPage.StaticIconRootUrl);

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

            if(DisplayTags)
            {
                StyledPanel categoryPanel = new StyledPanel();

                string userTagsUrl;
                if(KickPage.KickUserProfile.IsValidated)
                    userTagsUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserTags, KickPage.KickUserProfile.Username);
                else
                    userTagsUrl = UrlFactory.CreateUrl(UrlFactory.PageName.Login);

                categoryPanel.Caption =
                    String.Format(
                        @"Tags: <span style=""font-size:0.7em"">  <a href=""{0}"">all tags</a> - <a href=""{1}"">your tags</a></span><br /><br />",
                        UrlFactory.CreateUrl(UrlFactory.PageName.ViewTags), userTagsUrl);
                categoryPanel.RenderTop(writer);

                TagCloud tagCloud = new TagCloud();
                Controls.Add(tagCloud);
                tagCloud.DataBind(TagCache.GetTopHostTags(KickPage.HostProfile.HostID, 80));
                tagCloud.RenderControl(writer);

                categoryPanel.RenderBottom(writer);
            }

            if(DisplayCategories)
            {
                StyledPanel categoryPanel = new StyledPanel();
                categoryPanel.Caption = "Story categories:";
                categoryPanel.RenderTop(writer);
                CategoryCollection categories = CategoryCache.GetCategories(KickPage.HostProfile.HostID);
                foreach(Category category in categories)
                {
                    string url = UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, category.CategoryIdentifier);
                    string iconHtml = "";
                    if(category.IconNameSpecified)
                        iconHtml =
                            String.Format(@"<a href=""{0}""><img src=""{1}"" width=""16"" height=""16"" border=""0""/></a>", url,
                                          KickPage.StaticIconRootUrl + "/" + category.IconName);

                    writer.WriteLine(
                        @"<div class=""SideBarLink"">{0}
                        <a href=""{1}"">{2}</a>
                        <span class=""LightLink""><a href=""{1}/upcoming"">[find]</a></span></div>",
                        iconHtml, url, category.Name);
                }

                writer.WriteLine(@"<br /><p align=""center""><a href=""mailto:{0}"">Suggest a new category</a></p>",
                                 KickPage.HostProfile.Email);
                categoryPanel.RenderBottom(writer);
            }

            if(DisplayWhatElse)
            {
                StyledPanel miscPanel = new StyledPanel();
                miscPanel.Caption = "What else?";
                miscPanel.RenderTop(writer);

                writer.WriteLine(
                    @"
                <div class=""SideBarLink"">  
                <a href=""{0}""><img src=""{1}/submit.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{0}"">Add our feeds to your site</a>
                </div>

                <div class=""SideBarLink"">
                <a href=""{2}""><img src=""{1}/community.png"" width=""16"" height=""16"" border=""0""/></a>
                <a href=""{2}"">Help us spread the word</a></div>

            ",
                    UrlFactory.CreateUrl(UrlFactory.PageName.JavaScriptFeeds), KickPage.StaticIconRootUrl,
                    UrlFactory.CreateUrl(UrlFactory.PageName.Contribute));

                miscPanel.RenderBottom(writer);
            }
        }
    }
}