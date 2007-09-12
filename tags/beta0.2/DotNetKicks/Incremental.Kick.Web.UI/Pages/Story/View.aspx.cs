using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Pages.Story {
    public partial class View : Incremental.Kick.Web.Controls.KickUIPage {
        protected View() {
            // this.IsCachedPage = true;
        }

        protected void Page_Init(object sender, EventArgs e) {
            this.PageName = UrlFactory.PageName.ViewStory;
        }

        protected void Page_Load(object sender, EventArgs e) {
            Incremental.Kick.Dal.Story story = StoryCache.GetStory(this.UrlParameters.StoryIdentifier);

            if (story == null)
                Response.Redirect("/missingstory");

            this.Title = story.Title;
            this.Caption = "";
            this.UsersWhoKicked.DataBind(UserCache.GetUsersWhoKicked(story.StoryID));
            this.StorySummary.DataBind(story);
            this.StorySummary.ShowMoreLink = false;
            this.CommentList.DataBind(StoryCache.GetComments(story.StoryID));
            this.AddComment.DataBind(story.StoryID);
            this.DisplayAds = true;

            this.KickMenu.DisplayAds = true;
            this.KickMenu.DisplayCategories = false;    
            this.KickMenu.DisplayWhatElse = false;

            if (!String.IsNullOrEmpty(story.AdsenseID)) {
                if (this.KickUserProfile.UserID != story.UserID) {
                    //flick a coin
                    if (ThreadSafeRandom.FlickCoin()) {
                        System.Diagnostics.Debug.WriteLine("Showing author ads " + story.AdsenseID);
                        this.AdSenseID = story.AdsenseID;
                    }
                }
            }
        }
    }
}