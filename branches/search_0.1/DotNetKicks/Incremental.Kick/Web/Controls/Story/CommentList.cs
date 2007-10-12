using System.Web.UI;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class CommentList : KickWebControl {
        private CommentCollection _commentTable;

        public void DataBind(CommentCollection commentTable) {
            _commentTable = commentTable;            
        }

        public bool DisplayStoryTitle
        {
            get { return _displayStoryTitle; }
            set { _displayStoryTitle = value; }
        }

        private bool _displayStoryTitle=false;

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<br /><div id=""comments"" class=""PageSmallCaption"">Comments:</div>");

            bool isOddRow = true;

            if (_commentTable.Count == 0) {
                writer.WriteLine(" <h2>No comments so far</h2>");
            } else {
                foreach (Dal.Comment commentRow in _commentTable) {
                    Comment comment = new Comment();
                    comment.DisplayStoryTitle = _displayStoryTitle;
                    Controls.Add(comment);
                    comment.DataBind(commentRow, isOddRow);
                    comment.RenderControl(writer);
                    isOddRow = !isOddRow;
                }
            }
        }
    }
}

