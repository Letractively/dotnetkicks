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
    /// <code>/search?q={0}&amp;page={1}</code></para>
    /// </remarks>
    public class SearchPaging : Paging
    {
        protected override string PageUrl(int pageNumber)
        {
            if (pageNumber < 1 || pageNumber > this.PageCount)
                return "#";
            return string.Concat(this.BaseUrl, "&page=", pageNumber);
        }
    }
}
