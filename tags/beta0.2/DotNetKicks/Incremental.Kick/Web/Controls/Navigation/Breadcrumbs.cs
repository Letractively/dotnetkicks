using System;
using System.Collections.Generic;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class Breadcrumbs : KickHtmlControl {

        protected override void Render(HtmlTextWriter writer) {

            

            writer.WriteLine("<div id=\"breadcrumbs\">");

            writer.WriteLine(@"<table class=""SimpleTable""><tr><td>");

            writer.Write("&nbsp;&nbsp;&nbsp;");

            RenderBreadcrumb("home", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);

            string categoryName = "";
            if(this.KickPage.UrlParameters.CategoryID != null)
                categoryName = CategoryCache.GetCategory(this.KickPage.UrlParameters.CategoryID, this.KickPage.HostProfile.HostID).Name.ToLower();

            switch (this.KickPage.PageName) {
                
                //---------------- category trail
                case UrlFactory.PageName.ViewCategory :
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("category", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(categoryName, writer);
                    break;

                    //view popular (main) trail
                case UrlFactory.PageName.PopularToday:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("today", writer);
                    break;
                case UrlFactory.PageName.PopularWeek:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("this week", writer);
                    break;
                case UrlFactory.PageName.PopularTenDays:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("past ten days", writer);
                    break;                    
                case UrlFactory.PageName.PopularMonth:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("this month", writer);
                    break;
                case UrlFactory.PageName.PopularYear:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("this year", writer);
                    break;

                    //-------------- view upcoming trail
                case UrlFactory.PageName.ViewCategoryNewStories :
                    this.RenderSpacer(writer);

                    if (this.KickPage.UrlParameters.CategoryIdentifierSpecified) {
                        this.RenderBreadcrumb(categoryName,
                        UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, this.KickPage.UrlParameters.CategoryIdentifier), writer);
                        this.RenderSpacer(writer);
                    }
                    this.RenderBreadcrumb("upcoming stories", writer);
                    break;

                case UrlFactory.PageName.UpcomingWeek:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("upcoming stories", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories) , writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("this week", writer);
                    break;
                case UrlFactory.PageName.UpcomingToday:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("upcoming stories", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories), writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("top today", writer);
                    break;

                //----------------- view story trail
                case UrlFactory.PageName.ViewStory :
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(categoryName,
                        UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, this.KickPage.UrlParameters.CategoryIdentifier), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("view story", writer);
                    break;

                //--------------- tag trail
                case UrlFactory.PageName.ViewTag:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("tags", UrlFactory.CreateUrl(UrlFactory.PageName.ViewTags), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.TagIdentifier, writer);
                    break;

                 //---------------- top level trail
                case UrlFactory.PageName.Login:
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("login", writer);
                    break;
                case UrlFactory.PageName.Register:
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("create an account", writer);
                    break;
                case UrlFactory.PageName.ForgotPassword:
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("forgot password", writer);
                    break;
                case UrlFactory.PageName.About:
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("about us", writer);
                    break;
                case UrlFactory.PageName.SubmitStory:
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("submit story", writer);
                    break;
                
                //-------------- community pages
                case UrlFactory.PageName.CommunityWhoIsOnline:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("community", "#", writer);
                    this.RenderSpacer(writer);
                    RenderBreadcrumb("online users", writer);
                    break;

                //----------------- user profile trail
                case UrlFactory.PageName.UserProfile:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("users", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.UserIdentifier, writer);
                    break;
                case UrlFactory.PageName.UserComments:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("users", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.UserIdentifier, UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this.KickPage.UrlParameters.UserIdentifier), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("comments", writer);
                    break;
                case UrlFactory.PageName.UserSubmittedStories:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("users", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.UserIdentifier, UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this.KickPage.UrlParameters.UserIdentifier), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("submitted stories", writer);
                    break;
                case UrlFactory.PageName.UserKickedStories:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("users", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.UserIdentifier, UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this.KickPage.UrlParameters.UserIdentifier), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("kicked stories", writer);
                    break;
                case UrlFactory.PageName.UserFriends:
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("users", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.UserIdentifier, UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this.KickPage.UrlParameters.UserIdentifier), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("friends", writer);
                    break;
                case UrlFactory.PageName.UserTags: 
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("users", "#", writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb(this.KickPage.UrlParameters.UserIdentifier, UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this.KickPage.UrlParameters.UserIdentifier), writer);
                    this.RenderSpacer(writer);
                    this.RenderBreadcrumb("tags", writer);
                    break;
            }

            writer.WriteLine(@"</td><td align=""right"">&nbsp;&nbsp;&nbsp;");
            
            if(this.KickPage.User.Identity.IsAuthenticated)
                writer.WriteLine(@"Welcome <a href=""{0}"">{1}</a>", UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, this.KickPage.KickUserProfile.Username), this.KickPage.KickUserProfile.Username);
            else
                writer.WriteLine(@"Why not <a href=""{0}"">join our community?</a>", UrlFactory.CreateUrl(UrlFactory.PageName.Register));

            writer.Write(@", there are <a href=""/whoisonline"">{0} users online</a>", UserCache.GetOnlineUsersCount(30, this.KickPage.HostProfile.HostID));

            writer.WriteLine(@"</tr></table></div>");
        }
        
        private void RenderBreadcrumb(string title, string url, HtmlTextWriter writer) {
            writer.WriteLine("<a href=\"{0}\">{1}</a>", url, title);
        }

        private void RenderBreadcrumb(string title, HtmlTextWriter writer) {
            writer.WriteLine(title);
        }

        private void RenderSpacer(HtmlTextWriter writer) {
            writer.WriteLine(" » ");
        }

    }
}
