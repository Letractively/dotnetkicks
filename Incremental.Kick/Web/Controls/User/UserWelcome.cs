using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;
using SubSonic.Sugar;

namespace Incremental.Kick.Web.Controls
{

    /// <summary>
    ///  Renders the User Welcome message
    /// </summary>
    public class UserWelcome : KickHtmlControl
    {

        /// <summary>
        /// Writes content to render on a client to the specified <see cref="T:System.Web.UI.HtmlTextWriter"></see> object.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"></see> that contains the output stream to render on the client.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("div");
            writer.WriteAttribute("id", "UserWelcome");
            writer.Write(HtmlTextWriter.TagRightChar);

            if (KickPage.User.Identity.IsAuthenticated)
            {
                writer.Write("Welcome ");
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.KickUserProfile.Username));
                writer.Write(HtmlTextWriter.TagRightChar);    
                writer.Write(KickPage.KickUserProfile.Username);
                writer.WriteEndTag("a");
            }
            else
            {
                writer.Write("Why not ");
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", UrlFactory.CreateUrl(UrlFactory.PageName.Register));
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write("join our community?");
                writer.WriteEndTag("a");              
            }

            //all users see online spy
            writer.Write(@", there are ");
            writer.WriteBeginTag("a");
            writer.WriteAttribute("href", UrlFactory.CreateUrl(UrlFactory.PageName.WhoIsOnline));
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.Write(Strings.Pluralize(UserCache.GetOnlineUsersCount(30, KickPage.HostProfile.HostID, KickPage.KickUserProfile), "user"));
            writer.Write(" online");
            writer.WriteEndTag("a");

            writer.WriteEndTag("div");
        }
    }
}
