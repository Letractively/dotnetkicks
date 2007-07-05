using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Helpers;

namespace Incremental.Kick.Web.Controls {
    public class Comment : KickWebControl {
        private Incremental.Kick.Dal.Comment _commentRow;
        private bool _useAlternativeStyle;

        public void DataBind(Incremental.Kick.Dal.Comment commentRow, bool useAlternativeStyle) {
            this._commentRow = commentRow;
            this._useAlternativeStyle = useAlternativeStyle;
        }

        public void DataBind(Incremental.Kick.Dal.Comment commentRow) {
            this._commentRow = commentRow;
        }

        protected override void Render(HtmlTextWriter writer) {
            string alternativeCssClass = "";
            if (this._useAlternativeStyle)
                alternativeCssClass = "CommentAlt";

            writer.WriteLine(@"<div class=""Comment {0}"">
                    <div class=""CommentText"">{1}</div>
                    <div class=""CommentAuthor"">posted by 
            ", alternativeCssClass, this._commentRow);

            UserLink userLink = new UserLink();
            userLink.DataBind(this._commentRow.Username);
            userLink.RenderControl(writer);

            writer.WriteLine(@"{0}</div></div>", DateHelper.ConverDateToTimeAgo(this._commentRow.CreatedOn));
            
            
        }
    }
}
