using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.BusinessLogic;

namespace Incremental.Kick.Web.UI.Pages.User {
    public partial class UserTest : Incremental.Kick.Web.Controls.KickUserProfilePage {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                checkboxList.Items.Add("enum");
                checkboxList.Items.Add("garnish");
                checkboxList.Items.Add("elongated");
                checkboxList.Items.Add("private");
                checkboxList.Items.Add("rivet");
                checkboxList.Items.Add("namespace");
                checkboxList.Items.Add("class");
                checkboxList.Items.Add("indo");
                checkboxList.Items.Add("crass");
                checkboxList.Items.Add("dash");
                checkboxList.Items.Add("attend");
                checkboxList.Items.Add("meet");
                checkboxList.Items.Add("gloom");
                checkboxList.Items.Add("bilate");
                checkboxList.Items.Add("decimal");

            }
        }

        protected void TestMe_Click(object sender, EventArgs e) {
            Message.Text = "";

            List<string> answers = new List<string>();
            foreach (ListItem item in checkboxList.Items)
                if (item.Selected)
                    answers.Add(item.Value);

            bool isCorrect = true;

            if (answers.Count != 5) {
                Message.Text = "Please select 5 answers";
                isCorrect = false;
            } else {
                List<string> correctAnswers = new List<string>();
                correctAnswers.Add("enum");
                correctAnswers.Add("private");
                correctAnswers.Add("namespace");
                correctAnswers.Add("class");
                correctAnswers.Add("decimal");

                foreach (string correctAnswer in correctAnswers) {
                    if (!answers.Contains(correctAnswer)) {
                        Message.Text = "Incorrect Answers";
                        isCorrect = false;
                    }
                }

                if (isCorrect) {
                    UserBR.UserPassedTest(this.KickUserProfile, this.HostProfile);

                    Response.Redirect(UrlFactory.CreateUrl(UrlFactory.PageName.SubmitStory));
                }
            }
        }
    }
}