using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls {
    public class CreateUserWizard : System.Web.UI.WebControls.CreateUserWizard {

        public override string Password {
            get {
                return Incremental.Kick.Helpers.PasswordGenerator.Generate(8);
              }
        }

        //protected override 

        protected override void OnCreatingUser(System.Web.UI.WebControls.LoginCancelEventArgs e) {
            this.UserNameRequiredErrorMessage = "lal lgsdhsdhsd ala ";
            //base.OnCreatingUser(e);
        }
            
        protected override void OnNextButtonClick(System.Web.UI.WebControls.WizardNavigationEventArgs e) {
            this.UserNameRequiredErrorMessage = "lal lala ";


            //base.OnNextButtonClick(e);
        }


    }
}
