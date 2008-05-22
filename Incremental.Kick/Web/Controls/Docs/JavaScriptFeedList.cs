using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Incremental.Kick.Web.Controls
{
    public class JavaScriptFeedList : KickHtmlControl
    {
        private int entryCount = 0;
        private string title = "Homepage Feed";

        [DefaultValue(0)]
        public int EntryCount
        {
            get { return entryCount; }
            set { entryCount = value; }
        }

        [DefaultValue("Homepage Feed")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            RenderJavaScriptFeed(writer);

            //Kick_CategoryTable categoryTable = CategoryCache.GetCategories(this.KickPage.HostProfile.HostID);
            //foreach (Kick_CategoryRow category in categoryTable) {
            //    this.RenderJavaScriptFeed(category.Name, category.CategoryIdentifier, writer);
            //}
        }

        private void RenderJavaScriptFeed(HtmlTextWriter writer)
        {
            RenderJavaScriptFeed("", writer);
        }

        private void RenderJavaScriptFeed(string category, HtmlTextWriter writer)
        {
            StringBuilder javascriptUrl = new StringBuilder(KickPage.HostProfile.RootUrl);

            if(!String.IsNullOrEmpty(category))
                javascriptUrl.Append("/").Append(category);

            javascriptUrl.Append("/feeds/js");

            if(entryCount != 0)
                javascriptUrl.AppendFormat("?count={0}", entryCount);

            string script =
                String.Format(@"<script src=""{0}"" type=""text/javascript"" language=""javascript""></script>", javascriptUrl);

            writer.WriteLine(
                @"
                <p><strong>{0}</strong><br />
                <textarea rows=""1"" cols=""80"" onclick=""this.select();"">{1}</textarea></p>
            ",
                title, HttpUtility.HtmlEncode(script));
        }
    }
}