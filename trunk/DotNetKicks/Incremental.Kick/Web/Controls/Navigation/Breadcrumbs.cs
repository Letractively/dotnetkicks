using System;
using System.IO;
using System.Web.UI;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// The Breadcrumbs web control
    /// </summary>
    /// <example>
    /// home >> tagname >> story name
    /// </example>
    public class Breadcrumbs : KickHtmlControl
    {

        /// <summary>
        /// Writes content to render on a client to the specified <see cref="T:System.Web.UI.HtmlTextWriter"></see> object.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"></see> that contains the output stream to render on the client.</param>
        protected override void Render(HtmlTextWriter writer)
        {


            // <!-- Breadcrumbs -->
            //<div id="BreadcrumbNavigation">
            //    <ul>
            //        <li class="first">Home</li>
            //        <li>Test</li>
            //    </ul>
            //</div>

            writer.WriteBeginTag("div");
            writer.WriteAttribute("id", "BreadcrumbNavigation");
            writer.Write(HtmlTextWriter.TagRightChar);
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            RenderBreadcrumbItem("home", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);

            string categoryName = CategoryCache.GetCategory(KickPage.UrlParameters.CategoryID, KickPage.HostProfile.HostID).Name.ToLower();

            switch (KickPage.PageName)
            {

                //---------------- category trail
                case UrlFactory.PageName.ViewCategory:
                    RenderBreadcrumbItem("category", "#", writer);
                    RenderBreadcrumbItem(categoryName, writer);
                    break;

                //view popular (main) trail
                case UrlFactory.PageName.PopularToday:
                    RenderBreadcrumbItem("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    RenderBreadcrumbItem("today", writer);
                    break;
                case UrlFactory.PageName.PopularWeek:
                    RenderBreadcrumbItem("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    RenderBreadcrumbItem("this week", writer);
                    break;
                case UrlFactory.PageName.PopularTenDays:
                    RenderBreadcrumbItem("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    RenderBreadcrumbItem("past ten days", writer);
                    break;
                case UrlFactory.PageName.PopularMonth:
                    RenderBreadcrumbItem("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    RenderBreadcrumbItem("this month", writer);
                    break;
                case UrlFactory.PageName.PopularYear:
                    RenderBreadcrumbItem("popular stories", UrlFactory.CreateUrl(UrlFactory.PageName.Home), writer);
                    RenderBreadcrumbItem("this year", writer);
                    break;

                //-------------- view upcoming trail
                case UrlFactory.PageName.ViewCategoryNewStories:
                    if (KickPage.UrlParameters.CategoryIdentifierSpecified)
                    {
                        RenderBreadcrumbItem(categoryName,
                            UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, KickPage.UrlParameters.CategoryIdentifier), writer);
                    }
                    RenderBreadcrumbItem("upcoming stories", writer);
                    break;

                case UrlFactory.PageName.UpcomingWeek:
                    RenderBreadcrumbItem("upcoming stories", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories), writer);
                    RenderBreadcrumbItem("this week", writer);
                    break;
                case UrlFactory.PageName.UpcomingToday:
                    RenderBreadcrumbItem("upcoming stories", UrlFactory.CreateUrl(UrlFactory.PageName.NewStories), writer);
                    RenderBreadcrumbItem("top today", writer);
                    break;

                //----------------- view story trail
                case UrlFactory.PageName.ViewStory:
                    RenderBreadcrumbItem(categoryName,
                        UrlFactory.CreateUrl(UrlFactory.PageName.ViewCategory, KickPage.UrlParameters.CategoryIdentifier), writer);
                    RenderBreadcrumbItem("view story", writer);
                    break;

                //--------------- tag trail
                case UrlFactory.PageName.ViewTag:
                    RenderBreadcrumbItem("tags", UrlFactory.CreateUrl(UrlFactory.PageName.ViewTags), writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.TagIdentifier, writer);
                    break;

                //--------------- zeitgeist trail
                case UrlFactory.PageName.Zeitgeist:
                    if (KickPage.UrlParameters.Year == null)
                        RenderBreadcrumbItem("zeitgeist", writer);
                    else if (KickPage.UrlParameters.Month == null)
                    {
                        RenderBreadcrumbItem("zeitgeist", UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist), writer);
                        RenderBreadcrumbItem(KickPage.UrlParameters.Year.ToString(), writer);
                    }
                    else if (KickPage.UrlParameters.Day == null)
                    {
                        RenderBreadcrumbItem("zeitgeist", UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist), writer);
                        RenderBreadcrumbItem(KickPage.UrlParameters.Year.ToString(), UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, KickPage.UrlParameters.Year.ToString()), writer);
                        RenderBreadcrumbItem(new DateTime(KickPage.UrlParameters.Year.Value, KickPage.UrlParameters.Month.Value, 1).ToString("MMMM"), writer);
                    }
                    else
                    {
                        RenderBreadcrumbItem("zeitgeist", UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist), writer);
                        RenderBreadcrumbItem(KickPage.UrlParameters.Year.ToString(),
                            UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, KickPage.UrlParameters.Year.ToString()), writer);
                        RenderBreadcrumbItem(new DateTime(KickPage.UrlParameters.Year.Value,
                            
                            KickPage.UrlParameters.Month.Value, 1).ToString("MMMM"),
                            UrlFactory.CreateUrl(UrlFactory.PageName.Zeitgeist, KickPage.UrlParameters.Year.ToString(),
                            KickPage.UrlParameters.Month.ToString()), writer);
                        RenderBreadcrumbItem(KickPage.UrlParameters.Day.ToString(), writer);
                    }
                    break;

                //---------------- top level trail
                case UrlFactory.PageName.Login:
                    RenderBreadcrumbItem("login", writer);
                    break;
                case UrlFactory.PageName.Register:
                    RenderBreadcrumbItem("create an account", writer);
                    break;
                case UrlFactory.PageName.ForgotPassword:
                    RenderBreadcrumbItem("forgot password", writer);
                    break;
                case UrlFactory.PageName.About:
                    RenderBreadcrumbItem("about us", writer);
                    break;
                case UrlFactory.PageName.SubmitStory:
                    RenderBreadcrumbItem("submit story", writer);
                    break;

                //-------------- community pages
                case UrlFactory.PageName.WhoIsOnline:
                case UrlFactory.PageName.KickSpy:
                    RenderBreadcrumbItem("community", "#", writer);
                    RenderBreadcrumbItem("online users", writer);
                    break;

                //----------------- user profile trail
                case UrlFactory.PageName.UserProfile:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier, writer);
                    break;
                case UrlFactory.PageName.UserComments:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("comments", writer);
                    break;
                case UrlFactory.PageName.UserSubmittedStories:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("submitted stories", writer);
                    break;
                case UrlFactory.PageName.UserKickedStories:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("kicked stories", writer);
                    break;
                case UrlFactory.PageName.UserFriends:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("friends", writer);
                    break;
                case UrlFactory.PageName.FriendsKickedStories:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("friends",
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserFriends, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("kicked by friends", writer);
                    break;
                case UrlFactory.PageName.FriendsSubmittedStories:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("friends",
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserFriends, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("submitted by friends", writer);
                    break;
                case UrlFactory.PageName.UserTags:
                    RenderBreadcrumbItem("users", "#", writer);
                    RenderBreadcrumbItem(KickPage.UrlParameters.UserIdentifier,
                        UrlFactory.CreateUrl(UrlFactory.PageName.UserHome, KickPage.UrlParameters.UserIdentifier), writer);
                    RenderBreadcrumbItem("tags", writer);
                    break;

                    //api
                case UrlFactory.PageName.ApiOverview:
                    RenderBreadcrumbItem("API", "#", writer);               
                    break;
                case UrlFactory.PageName.ApiGenerateKey:
                    RenderBreadcrumbItem("API", UrlFactory.CreateUrl(UrlFactory.PageName.ApiOverview), writer);
                    RenderBreadcrumbItem("generate key", "#", writer);
                    break;

            }
            writer.RenderEndTag();//ul
            writer.WriteEndTag("div");//navigationbreadcrumbs
        }

        private int _currentItemNumber = 0;
        /// <summary>
        /// Renders the breadcrumb item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="url">The URL.</param>
        /// <param name="writer">The writer.</param>
        /// <example>
        /// 	<li class="first">Home</li>
        /// 	<li>Test</li>
        /// </example>
        private void RenderBreadcrumbItem(string text, string url, HtmlTextWriter writer)
        {
            writer.WriteBeginTag("li");
            if (_currentItemNumber == 0)
                writer.WriteAttribute("class", "first");
            writer.Write(HtmlTextWriter.TagRightChar);

            if (_currentItemNumber != 0)
                RenderSpacer(writer);

            if (!string.IsNullOrEmpty(url))
            {
                writer.WriteBeginTag("a");
                writer.WriteAttribute("href", url);
                writer.Write(HtmlTextWriter.TagRightChar);
                writer.Write(text);
                writer.WriteEndTag("a");
            }
            else
                writer.Write(text);

            writer.WriteEndTag("li");
            _currentItemNumber++;
        }

        /// <summary>
        /// Renders the spacer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        private static void RenderSpacer(TextWriter writer)
        {
            //HACK I really hate MSIE
            //needed to add this here, because IE doesn't support before/after in CSS
            if (System.Web.HttpContext.Current.Request.Browser.Type.StartsWith("IE"))
                writer.Write(" &#187; ");
        }

        /// <summary>
        /// Renders the breadcrumb item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="writer">The writer.</param>
        /// <example>
        /// 	<li class="first">Home</li>
        /// 	<li>Test</li>
        /// </example>
        private void RenderBreadcrumbItem(string text, HtmlTextWriter writer)
        {
            RenderBreadcrumbItem(text, null, writer);
        }

    }
}
