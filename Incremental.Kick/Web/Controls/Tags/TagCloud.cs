using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web;
using Incremental.Kick.Web.Helpers;
using Incremental.Kick.Dal.Entities;

namespace Incremental.Kick.Web.Controls {
    public class TagCloud : KickHtmlControl {
        
		#region  Properties and variables (1)

        /// <summary>
        /// The list of weighted tags that this tag cloud displays
        /// </summary>
		private WeightedTagList _tags;

		#endregion 

		#region  Methods (2)

		/// <summary>
        /// Binds this tag cloud control to a list of weighted tags.
        /// </summary>
        /// <remarks>Callers can use the TagCache to retrieve a current list of tags for the current host:
        /// <code>this.TagCloud.DataBind(TagCache.GetHostTags(this.HostProfile.HohstID));</code></remarks>
        /// <param name="tags">The <seealso cref="WeightedTagList"/> to bind to.</param>
        public void DataBind(WeightedTagList tags) {
            this._tags = tags;
        }

        /// <summary>
        /// Writes content to render on a client to the specified <see cref="T:System.Web.UI.HtmlTextWriter"></see> object.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"></see> that contains the output stream to render on the client.</param>
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
                            //tagIcons += String.Format(@"<img src=""{0}/{1}_{2}.png"" width=""16"" height=""16"" border=""0""/> ", this.KickPage.StaticIconRootUrl, tagNamespace, tag.TagName);
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
		
		#endregion 

    }
}

