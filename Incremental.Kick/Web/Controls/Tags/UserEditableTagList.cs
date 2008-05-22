using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Web.Controls {
    public class UserEditableTagList : KickHtmlControl {
        private WeightedTagList _tags;
        private int _storyID;
        private string _username;

        public void DataBind(int storyID, string username) {
            this.DataBind(new WeightedTagList(), storyID, username);
        }

        public void DataBind(WeightedTagList tags, int storyID, string username) {
            this._tags = tags;
            this._storyID = storyID;
            this._username = username;
        }

        protected override void Render(HtmlTextWriter writer) {
            if (this._tags.Count == 0) {
                writer.WriteLine("");
            } else {

                string tagClass; bool isEven = false;
                foreach (WeightedTag tag in this._tags) {
                    string spanID = this._storyID + "_" + tag.TagID + "_EditableTag";
                    if (isEven)
                        tagClass = "evenTag";
                    else
                        tagClass = "oddTag";

                    writer.WriteLine(@"<span class=""EditableTag {3}"" id=""{0}""><a href=""{1}"" class=""tag {3}"">{2}</a>",
                        spanID, UrlFactory.CreateUrl(UrlFactory.PageName.UserTag, _username, tag.TagIdentifier), tag.TagName, tagClass);

                    writer.WriteLine(@" [<a href=""javascript:RemoveUserStoryTag({0}, {1});"">x</a>]<br /></span>",
                        this._storyID, tag.TagID);
                    isEven = !isEven;
                }
            }
        }
    }
}

