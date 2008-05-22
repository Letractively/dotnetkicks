using System;
using System.Collections.Generic;
using System.Text;
//using Incremental.Kick.Common.Entities;
//using Incremental.Kick.Common.DataSets.Tables;
//using Incremental.Kick.Common.DataSets.Rows;
//using Incremental.Kick.Web.Helpers;
//using Incremental.Kick.Caching;
using Rss;
using Incremental.Kick.Dal;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Helpers.Rss {
    public class StoryDataTableToRss {

        public static RssChannel ConvertToRssChannel(StoryCollection stories, string title, string description, string link, Host host) {
            RssChannel channel = new RssChannel();
            channel.Title = title;
            channel.Description = description;
            channel.Link = new System.Uri(link);
            channel.Language = "en-us";
            channel.Generator = host.SiteTitle + " - " + host.TagLine;
            channel.Docs = "";
            channel.TimeToLive = 30;
            channel.Copyright = "Atweb Publishing Ltd.";

            if (stories.Count == 0) {
                RssItem item = new RssItem();
                item.Title = " ";
                item.Description = " ";
                item.PubDate = DateTime.Now.ToUniversalTime();

                channel.Items.Add(item);
            } else {

                foreach (Story story in stories) {
                    string storyUrl = host.RootUrl + UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategory(story.CategoryID, host.HostID).CategoryIdentifier);

                    //TODO: GJ: add category info

                    RssItem item = new RssItem();
                    item.Title = story.Title;
                    item.Description = story.Description + " <br /><br /><br />" + Incremental.Common.Web.Helpers.ControlHelper.RenderControl(new Incremental.Kick.Web.Controls.StoryDynamicImage(story.Url, host));
                    item.PubDate = story.PublishedOn.ToUniversalTime();
                    RssGuid guid = new RssGuid();
                    guid.Name = storyUrl;
                    guid.PermaLink = true;
                    item.Guid = guid;
                    item.Link = new Uri(storyUrl);

                    channel.Items.Add(item);
                }
            }

            return channel;
        }

        /* public static string ConvertToRss2(Kick_StoryTable storyTable, string title, string description, string link, int hostID) {
             StringBuilder rss = new StringBuilder();

             rss.Append(String.Format(@"<?xml version=""1.0""?>
 <rss version=""2.0"">
 <channel>
 <title>{0}</title>
 <description>{1}</description>
 <language>en-ie</language>
 <link>{2}</link>", title, description, link));

             foreach(Kick_StoryRow story in storyTable) {
                 //TODO: add the host root url
                 string storyUrl = UrlFactory.CreateUrl(UrlFactory.PageName.ViewStory, story.StoryIdentifier, CategoryCache.GetCategoryIdentifier(story.CategoryID, hostID));

                 rss.Append(String.Format(@"
 <item>
 <title>{0}</title>
 <link>{1}</link>
 <description>{2}</description>
 <guid isPermaLink=""true"">{1}</guid>
 <pubDate>{3}</pubDate>
 </item>", story.Title, storyUrl, story.Description, story.PostedDateTime)); //TODO: change to published date
             }

             rss.Append(@"
 </channel>
 </rss>");

             return rss.ToString();
         }*/
    }
}
