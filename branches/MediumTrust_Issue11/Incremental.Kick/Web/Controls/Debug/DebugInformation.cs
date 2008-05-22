using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class DebugInformation : KickHtmlControl {

        protected override void Render(System.Web.UI.HtmlTextWriter writer) {

            writer.WriteLine("<br/>TIME:" + DateTime.Now.ToLongTimeString());

            if (this.KickPage.IsAuthenticated) {
                writer.WriteLine("<br/>User name:" + this.Page.User.Identity.Name);
                writer.WriteLine("<br/>Is User:" + this.KickPage.KickUserProfile.IsUser);
                writer.WriteLine("<br/>Is PowerUser:" + this.KickPage.KickUserProfile.IsPowerUser);
                writer.WriteLine("<br/>Is Moderator:" + this.KickPage.KickUserProfile.IsModerator);
                writer.WriteLine("<br/>Is Debugger:" + this.KickPage.KickUserProfile.IsDebugger);
                writer.WriteLine("<br/>Is Administrator:" + this.KickPage.KickUserProfile.IsAdministrator);
                writer.WriteLine("<br/>Is Host Moderator:" + this.KickPage.KickUserProfile.IsHostModerator(this.KickPage.HostProfile.HostName));
                writer.WriteLine("<br/>Is Validated:" + this.KickPage.KickUserProfile.IsValidated);
                writer.WriteLine("<br/>CreatedOn:" + this.KickPage.KickUserProfile.CreatedOn.ToLongDateString());
                writer.WriteLine("<br/>IsNew:" + this.KickPage.KickUserProfile.IsNew);
            } else {
                writer.WriteLine("<br/>Anonymous User");
            }

            writer.WriteLine("<br/>UserIdentifier: {0}", this.KickPage.UrlParameters.UserIdentifier);
            writer.WriteLine("<br/>CategoryIdentifier: {0}", this.KickPage.UrlParameters.CategoryIdentifier);
            writer.WriteLine("<br/>StoryIdentifier: {0}", this.KickPage.UrlParameters.StoryIdentifier);
            writer.WriteLine("<br/>PageNumber: {0}", this.KickPage.UrlParameters.PageNumber);
            writer.WriteLine("<br/>PageSize: {0}", this.KickPage.UrlParameters.PageSize);
            writer.WriteLine("<br/>StoryListSortBy: {0}", this.KickPage.UrlParameters.StoryListSortBy);
            writer.WriteLine("<br/>Skin: {0}", this.KickPage.UrlParameters.Skin);
            writer.WriteLine("<br/>AppDomainID: {0}", AppDomain.CurrentDomain.Id);
            writer.WriteLine("<br/>AdsenseID: {0}", this.KickUIPage.AdSenseID);
            writer.WriteLine("<br/>Url: {0}", this.KickPage.Request.Url);
        }
    }
}
