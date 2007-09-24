using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Web.Controls {
    public class EditableTagList : KickHtmlControl {
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
            if (this.Page.User.Identity.IsAuthenticated) {
                writer.WriteLine(@"<div class=""EditableTagList Hidden"" id=""{0}_EditableTagList"">", this._storyID);
                UserEditableTagList userTagList = new UserEditableTagList();
                userTagList.DataBind(this._tags, this._storyID, this._username);
                userTagList.RenderControl(writer);
                writer.WriteLine("</div>");


                writer.WriteLine(@"<br /><input id=""{0}_TagInput"" type=""text"" />
                <input id=""{0}_SubmitNewTags"" type=""button"" value=""Add Tag"" onclick=""AddUserStoryTags({0});"" />",
                    this._storyID);
            } else {
                //TODO: GJ: add a login control here
                writer.WriteLine(@"<table width=""200""><tr><td>");
                LoginOrCreateAccount loginOrCreateAccount = new LoginOrCreateAccount();
                loginOrCreateAccount.RenderControl(writer);
                writer.WriteLine(@"</td></tr></table>");
            } 
        }
    }
}

