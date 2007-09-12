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

namespace Incremental.Kick.Web.UI.Controls {

    public partial class AddComment : Incremental.Kick.Web.Controls.KickUserControl {

        private int _storyID;

        protected string LoginUrl {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Login, this.Request.Url.ToString()); }
        }

        protected string RegisterUrl {
            get { return UrlFactory.CreateUrl(UrlFactory.PageName.Register); }
        }

        public void DataBind(int storyID) {
            this._storyID = storyID;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (this.KickPage.IsAuthenticated) {
                this.AddCommentPanel.Visible = true;
                this.LoginToCommentPanel.Visible = false;
            } else {
                this.AddCommentPanel.Visible = false;
                this.LoginToCommentPanel.Visible = true;
            }
        }

        protected void AddComment_Click(object sender, EventArgs e) {
            //TODO: ensure that the comment length is less than 2500 characters
            // we can use the smstopia script to do this (we can also show haw many chars are left when it is less that 100!!)

            Comment.Text = Comment.Text.Trim();

            if (Comment.Text.Length < 4) {
                InvalidComment.Visible = true;
            } else {
                int commentID = CommentBR.CreateComment(this.KickPage.HostProfile.HostID, this._storyID, this.KickPage.KickUserProfile.UserID, this.KickPage.KickUserProfile.Username, Comment.Text);

                //now clear the cache for this story (NOTE: in the future, we can just update the cache too)
                StoryCache.RemoveStory(this._storyID, this.KickPage.UrlParameters.StoryIdentifier);


                Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory,
                    this.KickPage.UrlParameters.StoryIdentifier, this.KickPage.UrlParameters.CategoryIdentifier,
                    commentID));
            }
        }
    }
}