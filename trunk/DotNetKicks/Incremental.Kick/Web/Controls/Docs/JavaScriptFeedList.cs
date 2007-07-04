using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Incremental.Kick.Caching;


namespace Incremental.Kick.Web.Controls {
    public class JavaScriptFeedList : KickHtmlControl {
        
        protected override void Render(System.Web.UI.HtmlTextWriter writer) {
            this.RenderJavaScriptFeed("Homepage Feed", writer);

            //Kick_CategoryTable categoryTable = CategoryCache.GetCategories(this.KickPage.HostProfile.HostID);
            //foreach (Kick_CategoryRow category in categoryTable) {
            //    this.RenderJavaScriptFeed(category.Name, category.CategoryIdentifier, writer);
            //}
        }

        private void RenderJavaScriptFeed(string name, System.Web.UI.HtmlTextWriter writer) {
            this.RenderJavaScriptFeed(name, "", writer);
        }


        private void RenderJavaScriptFeed(string title, string category, System.Web.UI.HtmlTextWriter writer) {
            string javascriptUrl = this.KickPage.HostProfile.RootUrl;
            if(!String.IsNullOrEmpty(category))
                javascriptUrl += "/" + category;
            javascriptUrl += "/feeds/js";

            string script = String.Format(@"<script src=""{0}"" type=""text/javascript"" language=""javascript""></script>",
                javascriptUrl);
            
            writer.WriteLine(@"
                <p><strong>{0}</strong><br />
                <textarea rows=""1"" cols=""80"">{1}</textarea></p>
            ", title, HttpUtility.HtmlEncode(script));
        }
    }
}
