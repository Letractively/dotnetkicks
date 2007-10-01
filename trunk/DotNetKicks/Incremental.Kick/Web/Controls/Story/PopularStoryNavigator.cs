using System.Web.UI;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Web.Controls {
    public class PopularStoryNavigator : KickWebControl {


        private readonly StoryList _storyList = new StoryList();
        public StoryList StoryList {
            get { return this._storyList; }
        }

        private Paging _paging;
        public Paging Paging {
            get { return this._paging; }
        }

        public string RootUrl;

        public void DataBind(StoryCollection stories, int recordCount) {
            this._paging = new Paging(this.KickPage.UrlParameters.PageSize, this.KickPage.UrlParameters.PageNumber, recordCount);
            this.Controls.Add(this.StoryList);
            this.Controls.Add(this.Paging);

            this.StoryList.DataBind(stories);

            if(this.KickPage.UrlParameters.StoryListSortBy != Incremental.Kick.Common.Enums.StoryListSortBy.RecentlyPromoted) {
                this._paging.BaseUrl = "/popular/" + this.KickPage.UrlParameters.StoryListSortBy.ToString().ToLower();
            }
        }


        protected override void Render(HtmlTextWriter writer) {
            writer.WriteLine(@"<div><div id=""PopularStoryListDiv"">");

            this.StoryList.RenderControl(writer);
            this.Paging.RenderControl(writer);

            writer.WriteLine("</div></div>");
        }
    }
}
