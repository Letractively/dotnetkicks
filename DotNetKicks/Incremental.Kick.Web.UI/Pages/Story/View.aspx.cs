using System;
using Incremental.Kick.Caching;
using Incremental.Kick.Helpers;
using Incremental.Kick.Web.Helpers;

namespace Incremental.Kick.Web.UI.Pages.Story {
    public partial class View : Web.Controls.KickUIPage {
        protected View() {
            // this.IsCachedPage = true;
        }

        protected void Page_Init(object sender, EventArgs e) {
            PageName = UrlFactory.PageName.ViewStory;
        }

        protected void Page_Load(object sender, EventArgs e) {
            Dal.Story story = StoryCache.GetStory(UrlParameters.StoryIdentifier, HostProfile.HostID);

            if (story == null || story.IsSpam && !this.KickUserProfile.IsModerator)
                Response.Redirect("/missingstory");


            Title = story.Title;
            Caption = "";
            UsersWhoKicked.DataBind(story.UsersWhoKicked);
            StorySummary.DataBind(story);
            StorySummary.ShowMoreLink = false;
            StorySummary.ShowGetKickImageCodeLink = true;
            CommentList.DataBind(StoryCache.GetComments(story.StoryID));
            AddComment.DataBind(story.StoryID);
            DisplayAds = true;

            KickMenu.DisplayAds = true;
            KickMenu.DisplayCategories = false;    
            KickMenu.DisplayWhatElse = false;

            KickItImagePersonalization.StoryUrl = story.Url;

            if (!String.IsNullOrEmpty(story.AdsenseID)) {
                if (KickUserProfile.UserID != story.UserID) {
                    //flick a coin
                    if (ThreadSafeRandom.FlickCoin()) {
                        System.Diagnostics.Debug.WriteLine("Showing author ads " + story.AdsenseID);
                        AdSenseID = story.AdsenseID;
                    }
                }
            }
        }
    }
}