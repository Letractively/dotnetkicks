using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Web.Controls {
    public class TagCloud : KickHtmlControl {
        private WeightedTagList _tags;

        public void DataBind(WeightedTagList tags) {
            this._tags = tags;
        }

        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<div class=""TagCloud"">");


            if (this._tags.Count == 0) {
                writer.WriteLine("<h2>No tags</h2>");
            } else {

                string tagClass;
                bool isOdd = true;
                foreach (WeightedTag tag in this._tags) {
                    if (isOdd)
                        tagClass = "oddTag";
                    else
                        tagClass = "evenTag";

                    decimal fontSize = this._tags.GetTagWeight(tag.UsageCount);

                    string tagUrl;
                    if (this.KickPage.UrlParameters.UserIdentifierSpecified)
                        tagUrl = UrlFactory.CreateUrl(UrlFactory.PageName.UserTag, this.KickPage.UrlParameters.UserIdentifier, HttpUtility.UrlEncode(tag.TagIdentifier));
                    else
                        tagUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewTag, HttpUtility.UrlEncode(tag.TagIdentifier));

                    string tagIcons = "";
                    if (tag.IsInNamespace) {
                        tagClass += " namespaceTag";

                        foreach (string tagNamespace in tag.Namespaces) {
                            tagIcons += String.Format(@"<img src=""{0}/{1}.png"" width=""16"" height=""16"" border=""0""/>", this.KickPage.StaticIconRootUrl, tagNamespace);
                            tagClass += " " + tagNamespace + "_NamespaceTag";
                        }
                    }

                    writer.WriteLine(@"<span style=""font-size:{0}em;""><a href=""{1}"" class=""tag {3}"" rel=""tag"">{4}{2}</a></span>",
                        fontSize.ToString(), tagUrl, tag.TagName, tagClass, tagIcons);
                    //writer.WriteLine("FontSize:" + fontSize.ToString());
                    isOdd = !isOdd;
                }
            }
            writer.WriteLine("</div>");
        }
    }
}

