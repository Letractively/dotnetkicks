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
using Incremental.Kick.Security;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.UI.Controls {
    public partial class VerifyEmail : Incremental.Kick.Web.Controls.KickUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hash = Convert.ToString(this.Request.QueryString["hash"]);
            hash = hash.Replace(" ", "+");
            hash = Cipher.DecryptFromBase64(hash);
            string[] hashParts = hash.Split("#".ToCharArray());

            if(hashParts.Length > 0)
            {
                if (this.KickPage.KickUserProfile.Username == hashParts[0] && this.KickPage.KickUserProfile.Email == hashParts[1])
                {
                    //update email.
                    this.KickPage.KickUserProfile.Email = hashParts[2];
                    this.KickPage.KickUserProfile.Save();
                    UserCache.RemoveUser(this.KickPage.KickUserProfile.UserID);
                    SuccessPanel.Visible = true;
                }
                else
                    FailedPanel.Visible = true;
            }
            else
                FailedPanel.Visible = true;
        }
    }
}