using System;
using Incremental.Kick.Caching;
using Incremental.Kick.Common.Enums;

namespace Incremental.Kick.Web.Helpers
{
    public class UrlParameters
    {
        private string _categoryIdentifier;
        private int? _chatID;
        private int? _day;
        private readonly string _hostName;
        private int? _month;
        private int _pageNumber = 1;
        private bool _pageNumberSpecified;
        private int _pageSize = 16;
        private bool _pageSizeSpecified;
        private string _securityToken;
        private string _skin;
        private string _storyIdentifier;
        private StoryListSortBy _storyListSortBy = StoryListSortBy.RecentlyPromoted;
        private string _tagIdentifier;
        private string _userIdentifier;
//        private StoryListSortBy _upcomingstorylistsortby = StoryListSortBy.LatestUpcoming;
        private int? _year;

        public UrlParameters(string hostName)
        {
            _hostName = hostName;
        }

        public string UserIdentifier
        {
            get { return _userIdentifier; }
            set { _userIdentifier = value; }
        }

        public bool UserIdentifierSpecified
        {
            get { return !String.IsNullOrEmpty(_userIdentifier); }
        }

        public string CategoryIdentifier
        {
            get { return _categoryIdentifier; }
            set { _categoryIdentifier = value; }
        }

        public bool CategoryIdentifierSpecified
        {
            get { return !String.IsNullOrEmpty(_categoryIdentifier); }
        }

        public short CategoryID
        {
            get { return CategoryCache.GetCategory(CategoryIdentifier, HostCache.Hosts[_hostName].HostID).CategoryID; }
        }

        public string StoryIdentifier
        {
            get { return _storyIdentifier; }
            set { _storyIdentifier = value; }
        }

        public bool StoryIdentifierSpecified
        {
            get { return !String.IsNullOrEmpty(_storyIdentifier); }
        }

        public string TagIdentifier
        {
            get { return _tagIdentifier; }
            set { _tagIdentifier = value; }
        }

        public bool TagIdentifierSpecified
        {
            get { return !String.IsNullOrEmpty(_tagIdentifier); }
        }

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        public bool PageNumberSpecified
        {
            get { return _pageNumberSpecified; }
            set { _pageNumberSpecified = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public bool PageSizeSpecified
        {
            get { return _pageSizeSpecified; }
            set { _pageSizeSpecified = value; }
        }

        public string Skin
        {
            get { return _skin; }
            set { _skin = value; }
        }

        public int? Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int? Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int? Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public int? ChatID
        {
            get { return _chatID; }
            set { _chatID = value; }
        }

        public bool SkinSpecified
        {
            get { return !String.IsNullOrEmpty(Skin); }
        }

        public string SecurityToken
        {
            get { return _securityToken; }
            set { _securityToken = value; }
        }

        public StoryListSortBy StoryListSortBy
        {
            get { return _storyListSortBy; }
            set { _storyListSortBy = value; }
        }
    }
}