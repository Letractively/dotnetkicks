using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class CommentList : KickWebControl {
        private CommentCollection _commentTable;
        public void DataBind(CommentCollection commentTable) {
            this._commentTable = commentTable;
        }

        protected override void Render(HtmlTextWriter writer) {
            
            writer.WriteLine(@"<br /><div class=""PageSmallCaption"">Comments:</div>");

            bool isOddRow = true;

            if (this._commentTable.Count == 0) {
                writer.WriteLine(" <h2>No comments so far</h2>");
            } else {
                foreach (Incremental.Kick.Dal.Comment commentRow in this._commentTable) {
                    Comment comment = new Comment();
                    this.Controls.Add(comment);
                    comment.DataBind(commentRow, isOddRow);
                    comment.RenderControl(writer);
                    isOddRow = !isOddRow;
                }
            }
        }
    }
}

