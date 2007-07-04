using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Dal;

namespace Incremental.Kick.Common.Entities {
    public class HostProfile {

        //TODO: This can be removed - use Host active record instead 
        public int HostID;
        public string HostName;
        public string RootUrl;
        public string SiteTitle;
        public string SiteDescription;
        public string TagLine;
        public string BlogUrl;
        public string Email;
        public string Skin;
        public string Theme;
        public bool ShowAds;
        public string AdsenseID;
        public string TrackingHtml;

        public short Publish_MinimumStoryAgeInHours;
        public short Publish_MaximumStoryAgeInHours;
        public short Publish_MaximumSimiltanousStoryPublishCount;
        public short Publish_MinimumStoryScore;
        public short Publish_MinimumStoryKickCount;
        public short Publish_MinimumStoryCommentCount;
        public short Publish_MinimumAverageStoryKicksPerHour;
        public short Publish_MinimunAverageCommentsPerHour;
        public short Publish_MinimumViewCount;
        public short Publish_KickScore;
        public short Publish_CommentScore;
 

        public HostProfile(Host host) {
            this.HostID = host.HostID;
            this.HostName = host.HostName;
            this.RootUrl = host.RootUrl;
            this.SiteTitle = host.SiteTitle;
            this.SiteDescription = host.SiteDescription;
            this.TagLine = host.TagLine;
            this.BlogUrl = host.BlogUrl;
            this.Email = host.Email;
            this.Skin = host.Skin;
            this.Theme = host.Theme;
            this.ShowAds = host.ShowAds;
            this.Publish_MinimumStoryAgeInHours = host.Publish_MinimumStoryAgeInHours;
            this.Publish_MaximumStoryAgeInHours = host.Publish_MaximumStoryAgeInHours;
            this.Publish_MaximumSimiltanousStoryPublishCount = host.Publish_MaximumSimultaneousStoryPublishCount;
            this.Publish_MinimumStoryScore = host.Publish_MinimumStoryScore;
            this.Publish_MinimumStoryKickCount = host.Publish_MinimumStoryKickCount;
            this.Publish_MinimumStoryCommentCount = host.Publish_MinimumStoryCommentCount;
            this.Publish_MinimumAverageStoryKicksPerHour = host.Publish_MinimumAverageStoryKicksPerHour;
            this.Publish_MinimunAverageCommentsPerHour = host.Publish_MinimunAverageCommentsPerHour;
            this.Publish_MinimumViewCount = host.Publish_MinimumViewCount;
            this.Publish_KickScore = host.Publish_KickScore;
            this.Publish_CommentScore = host.Publish_CommentScore;
            this.AdsenseID = host.AdsenseID;
            this.TrackingHtml = host.TrackingHtml;
        }
    }
}
