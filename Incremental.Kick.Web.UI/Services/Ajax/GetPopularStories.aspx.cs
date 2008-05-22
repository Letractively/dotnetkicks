using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Incremental.Kick.Web.Controls;
using Incremental.Common.Web.Helpers;
using Incremental.Kick.BusinessLogic;
using Incremental.Kick.Caching;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Web.UI.Services.Ajax {
    public partial class GetPopularStories : Incremental.Kick.Web.Controls.KickApiPage {
        protected void Page_Load(object sender, EventArgs e) {
            

            //TODO: GJ: parse the enum
            //StoryList storyList = new StoryList();
            //this.Controls.Add(storyList);


            PopularStoryNavigator storyNavigator = new PopularStoryNavigator();
            this.Controls.Add(storyNavigator);

            
            switch (this.UrlParameters.StoryListSortBy) {
                case StoryListSortBy.RecentlyPromoted:
                    storyNavigator.DataBind(StoryCache.GetAllStories(true, this.HostProfile.HostID, this.UrlParameters.PageNumber, this.UrlParameters.PageSize), StoryCache.GetStoryCount(this.HostProfile.HostID, true));
                    break;
                default:
                    storyNavigator.DataBind(StoryCache.GetPopularStories(this.HostProfile.HostID, true, this.UrlParameters.StoryListSortBy, this.UrlParameters.PageNumber, this.UrlParameters.PageSize), StoryCache.GetPopularStoriesCount(this.HostProfile.HostID, true, this.UrlParameters.StoryListSortBy));
                    break;
            }
	            
                //case "Today" :
                  //  storyList.DataBind(StoryCache.GetSortedPopularStories(true, this.HostProfile.HostID, pageNumber, 10)); //TODO: GJ: add url params for the api page
                    //break;
        }

        

            //this.Paging.RecordCount = StoryCache.GetStoryCount(true, this.HostProfile.HostID);
        
    }
}
