using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Common.Enums;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Web.Helpers {
    public class UrlParameters {

        public UrlParameters(string hostName) {
            this._hostName = hostName;
        }

        private string _userIdentifier;
        private string _categoryIdentifier;
        private string _storyIdentifier;
        private string _tagIdentifier;
        private int _pageNumber = 1;
        private bool _pageNumberSpecified;
        private int _pageSize = 16;
        private bool _pageSizeSpecified;
        private string _skin;
        private string _securityToken;
        private string _hostName;
        private StoryListSortBy _storyListSortBy = StoryListSortBy.RecentlyPromoted;
        private StoryListSortBy _upcomingstorylistsortby = StoryListSortBy.LatestUpcoming;
        private int? _year;
        private int? _month;
        private int? _day;
        private int? _chatID;

        public string UserIdentifier {
            get { return this._userIdentifier; }
            set { this._userIdentifier = value; }
        }

        public bool UserIdentifierSpecified {
            get { return !String.IsNullOrEmpty(this._userIdentifier); }
        }

        public string CategoryIdentifier {
            get { return this._categoryIdentifier; }
            set { this._categoryIdentifier = value; }
        }

        public bool CategoryIdentifierSpecified {
            get { return !String.IsNullOrEmpty(this._categoryIdentifier); }
        }

        public short CategoryID {
            get { return CategoryCache.GetCategory(this.CategoryIdentifier, HostCache.Hosts[this._hostName].HostID).CategoryID; }
        }

        public string StoryIdentifier {
            get { return this._storyIdentifier; }
            set { this._storyIdentifier = value; }
        }

        public bool StoryIdentifierSpecified {
            get { return !String.IsNullOrEmpty(this._storyIdentifier); }
        }

        public string TagIdentifier {
            get { return this._tagIdentifier; }
            set { this._tagIdentifier = value; }
        }

        public bool TagIdentifierSpecified {
            get { return !String.IsNullOrEmpty(this._tagIdentifier); }
        }

        public int PageNumber {
            get { return this._pageNumber; }
            set { this._pageNumber = value; }
        }

        public bool PageNumberSpecified {
            get { return this._pageNumberSpecified; }
            set { this._pageNumberSpecified = value; }
        }

        public int PageSize {
            get {
                return this._pageSize;
            }
            set { this._pageSize = value; }
        }

        public bool PageSizeSpecified {
            get { return this._pageSizeSpecified; }
            set { this._pageSizeSpecified = value; }
        }

        public string Skin {
            get { return this._skin; }
            set { this._skin = value; }
        }
        public int? Year {
            get { return this._year; }
            set { this._year = value; }
        }
        public int? Month {
            get { return this._month; }
            set { this._month = value; }
        }
        public int? Day {
            get { return this._day; }
            set { this._day = value; }
        }
        public int? ChatID {
            get { return this._chatID; }
            set { this._chatID = value; }
        }
        public bool SkinSpecified {
            get { return !String.IsNullOrEmpty(this.Skin); }
        }

        public string SecurityToken {
            get { return this._securityToken; }
            set { this._securityToken = value; }
        }

        public StoryListSortBy StoryListSortBy {
            get { return this._storyListSortBy; }
            set { this._storyListSortBy = value; }
        }
    }
}
