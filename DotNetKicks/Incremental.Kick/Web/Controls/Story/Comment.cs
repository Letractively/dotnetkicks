using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls {
    public class Comment : KickWebControl {
        private Incremental.Kick.Dal.Comment _comment;
        private bool _useAlternativeStyle;

        public void DataBind(Incremental.Kick.Dal.Comment comment, bool useAlternativeStyle) {
            this._comment = comment;
            this._useAlternativeStyle = useAlternativeStyle;
        }

        public void DataBind(Incremental.Kick.Dal.Comment comment) {
            this._comment = comment;
        }

        protected override void Render(HtmlTextWriter writer) {
            string alternativeCssClass = "";
            if (this._useAlternativeStyle)
                alternativeCssClass = "CommentAlt";

            writer.WriteLine(@"<div class=""Comment {0}"">
                    <div class=""CommentText"">{1}</div>
                    <div class=""CommentAuthor"">posted by 
            ", alternativeCssClass, this._comment.CommentX);

            UserLink userLink = new UserLink();
            userLink.DataBind(UserCache.GetUserByUsername(this._comment.Username));
            userLink.RenderControl(writer);

            writer.WriteLine(@"{0}</div></div>", DateHelper.ConverDateToTimeAgo(this._comment.CreatedOn));
            
            
        }
    }
}
