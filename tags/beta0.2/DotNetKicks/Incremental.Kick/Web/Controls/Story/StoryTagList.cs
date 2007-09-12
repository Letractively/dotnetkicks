using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Web.Controls {
    public class StoryTagList : KickWebControl {
        private WeightedTagList _tags;
        private int _storyID;
        public void DataBind(WeightedTagList tags, int storyID) {
            this._tags = tags;
            this._storyID = storyID;
        }

        protected override void Render(HtmlTextWriter writer) {

            writer.WriteLine(@"<div id=""{0}"" class=""StoryTags Hidden"">", this._storyID + "_StoryTags");

            writer.WriteLine(@"<table><tr><td width=""100%""><h3>Everyones tags:</h3></td><td class=""editableTagListTD""><h3>Your tags:</h3></td></tr><tr><td valign=""top"">");
            TagCloud tagCloud = new TagCloud();
            this.Controls.Add(tagCloud);
            tagCloud.DataBind(this._tags);
            tagCloud.RenderControl(writer);
            writer.WriteLine(@"</td><td class=""editableTagListTD"">");

            EditableTagList editableTagList = new EditableTagList();
            editableTagList.DataBind(this._storyID);
            this.Controls.Add(editableTagList);
            editableTagList.RenderControl(writer);

            writer.WriteLine("</td></tr></table></div>");

        }
    }
}