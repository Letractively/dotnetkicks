using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Web.Controls
{
    /// <summary>
    /// Webcontrol used to generate paging for search results.
    /// </summary>
    /// <remarks>This overrides the normal Paging class since we need
    /// to supply the parameters in the querystring part of the url and not
    /// the normal path part.
    /// <para>The reason being that the search query may contain "*? characters all of which
    /// are banned from the path part of the url. Making a request would return a HTTP400 code.</para>
    /// <para>Therefore the search results url that is created by the this control is
    /// <code>/search?q={0}&amp;user={1}&amp;page={2}</code></para>
    /// </remarks>
    public class SearchPaging : Paging
    {
        protected override string PageUrl(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > this.PageCount)
                return "#";
            
            //issue 164: searching for "C#" or "C++" would cause a problem with the
            //paging since the outputted queryterm wasnt URLencoded.
            //Also fixed missing User parameter which allows the search to be limited
            //to stories that have been kicked by that user.
            string queryTerm = Context.Server.UrlEncode(Context.Request.QueryString["q"]);
            string userKickedStories = Context.Request.QueryString["user"];

            return string.Format("/search?q={0}&user={1}&page={2}", queryTerm, userKickedStories, pageNumber);
        }
    }
}
