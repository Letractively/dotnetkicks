using System;
using System.Collections.Generic;
using System.Text;
//using Atweb.Kick.Common.Entities;
//using Atweb.Kick.Common.DataSets.Tables;
//using Atweb.Kick.Common.DataSets.Rows;
//using Atweb.Kick.Web.Helpers;
//using Atweb.Kick.Caching;
using Rss;

namespace Atweb.Kick.Web.Helpers.Rss {
    public class StoryDataTableToRss {

//        public static RssChannel ConvertToRssChannel(Kick_StoryTable storyTable, string title, string description, string link, HostProfile hostProfile) {
//            RssChannel channel = new RssChannel();
//            channel.Title = title;
//            channel.Description = description;
//            channel.Link = new System.Uri(link);
//            channel.Language = "en-us";
//            channel.Generator = hostProfile.SiteTitle + " - " + hostProfile.TagLine;
//            channel.Docs = "";
//            channel.TimeToLive = 30;
//            channel.Copyright = "Atweb Publishing Ltd.";

//            if (storyTable.Count == 0) {
//                RssItem item = new RssItem();
//                item.Title = " ";
//                item.Description = " ";
//                item.PubDate = DateTime.Now.ToUniversalTime();

//                channel.Items.Add(item);
//            } else {

//                foreach (Kick_StoryRow story in storyTable) {
//                    string storyUrl = hostProfile.RootUrl + UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategoryIdentifier(story.CategoryID, hostProfile.HostID));

//                    //TODO: GJ: add category info

//                    RssItem item = new RssItem();
//                    item.Title = story.Title;
//                    item.Description = story.Description + " <br /><br /><br />" + Atweb.Common.Web.Helpers.ControlHelper.RenderControl(new Atweb.Kick.Web.Controls.StoryDynamicImage(story.Url, hostProfile));
//                    item.PubDate = story.PublishedDateTime.ToUniversalTime();
//                    RssGuid guid = new RssGuid();
//                    guid.Name = storyUrl;
//                    guid.PermaLink = true;
//                    item.Guid = guid;
//                    item.Link = new Uri(storyUrl);

//                    channel.Items.Add(item);
//                }
//            }

//            return channel;
//        }

//       /* public static string ConvertToRss2(Kick_StoryTable storyTable, string title, string description, string link, int hostID) {
//            StringBuilder rss = new StringBuilder();

//            rss.Append(String.Format(@"<?xml version=""1.0""?>
//<rss version=""2.0"">
//<channel>
//<title>{0}</title>
//<description>{1}</description>
//<language>en-ie</language>
//<link>{2}</link>", title, description, link));

//            foreach(Kick_StoryRow story in storyTable) {
//                //TODO: add the host root url
//                string storyUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategoryIdentifier(story.CategoryID, hostID));

//                rss.Append(String.Format(@"
//<item>
//<title>{0}</title>
//<link>{1}</link>
//<description>{2}</description>
//<guid isPermaLink=""true"">{1}</guid>
//<pubDate>{3}</pubDate>
//</item>", story.Title, storyUrl, story.Description, story.PostedDateTime)); //TODO: change to published date
//            }

//            rss.Append(@"
//</channel>
//</rss>");

//            return rss.ToString();
//        }*/
    }
}
