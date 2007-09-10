using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace Incremental.Kick.Dal
{
    /// <summary>
    /// Controller class for Kick_Host
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class HostController
    {
        // Preload our schema..
        Host thisSchemaLoad = new Host();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public HostCollection FetchAll()
        {
            HostCollection coll = new HostCollection();
            Query qry = new Query(Host.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public HostCollection FetchByID(object HostID)
        {
            HostCollection coll = new HostCollection().Where("HostID", HostID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public HostCollection FetchByQuery(Query qry)
        {
            HostCollection coll = new HostCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object HostID)
        {
            return (Host.Delete(HostID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object HostID)
        {
            return (Host.Destroy(HostID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string HostName,string RootUrl,string SiteTitle,string SiteDescription,string TagLine,string LogoPath,DateTime CreatedOn,string BlogUrl,string Email,string Template,bool ShowAds,string Culture,string UICulture,short Publish_MinimumStoryAgeInHours,short Publish_MaximumStoryAgeInHours,short Publish_MaximumSimultaneousStoryPublishCount,short Publish_MinimumStoryScore,short Publish_MinimumStoryKickCount,short Publish_MinimumStoryCommentCount,short Publish_MinimumAverageStoryKicksPerHour,short Publish_MinimunAverageCommentsPerHour,short Publish_MinimumViewCount,short Publish_KickScore,short Publish_CommentScore,string AdsenseID,string TrackingHtml,string AnnouncementHtml,string SmtpHost,int? SmtpPort,string SmtpUsername,string SmtpPassword,bool? SmtpEnableSsl,string FeedBurnerMainRssFeedUrl,string FeedBurnerMainRssFeedCountHtml,bool? UseStaticRoot)
	    {
		    Host item = new Host();
		    
            item.HostName = HostName;
            
            item.RootUrl = RootUrl;
            
            item.SiteTitle = SiteTitle;
            
            item.SiteDescription = SiteDescription;
            
            item.TagLine = TagLine;
            
            item.LogoPath = LogoPath;
            
            item.CreatedOn = CreatedOn;
            
            item.BlogUrl = BlogUrl;
            
            item.Email = Email;
            
            item.Template = Template;
            
            item.ShowAds = ShowAds;
            
            item.Culture = Culture;
            
            item.UICulture = UICulture;
            
            item.Publish_MinimumStoryAgeInHours = Publish_MinimumStoryAgeInHours;
            
            item.Publish_MaximumStoryAgeInHours = Publish_MaximumStoryAgeInHours;
            
            item.Publish_MaximumSimultaneousStoryPublishCount = Publish_MaximumSimultaneousStoryPublishCount;
            
            item.Publish_MinimumStoryScore = Publish_MinimumStoryScore;
            
            item.Publish_MinimumStoryKickCount = Publish_MinimumStoryKickCount;
            
            item.Publish_MinimumStoryCommentCount = Publish_MinimumStoryCommentCount;
            
            item.Publish_MinimumAverageStoryKicksPerHour = Publish_MinimumAverageStoryKicksPerHour;
            
            item.Publish_MinimunAverageCommentsPerHour = Publish_MinimunAverageCommentsPerHour;
            
            item.Publish_MinimumViewCount = Publish_MinimumViewCount;
            
            item.Publish_KickScore = Publish_KickScore;
            
            item.Publish_CommentScore = Publish_CommentScore;
            
            item.AdsenseID = AdsenseID;
            
            item.TrackingHtml = TrackingHtml;
            
            item.AnnouncementHtml = AnnouncementHtml;
            
            item.SmtpHost = SmtpHost;
            
            item.SmtpPort = SmtpPort;
            
            item.SmtpUsername = SmtpUsername;
            
            item.SmtpPassword = SmtpPassword;
            
            item.SmtpEnableSsl = SmtpEnableSsl;
            
            item.FeedBurnerMainRssFeedUrl = FeedBurnerMainRssFeedUrl;
            
            item.FeedBurnerMainRssFeedCountHtml = FeedBurnerMainRssFeedCountHtml;
            
            item.UseStaticRoot = UseStaticRoot;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int HostID,string HostName,string RootUrl,string SiteTitle,string SiteDescription,string TagLine,string LogoPath,DateTime CreatedOn,string BlogUrl,string Email,string Template,bool ShowAds,string Culture,string UICulture,short Publish_MinimumStoryAgeInHours,short Publish_MaximumStoryAgeInHours,short Publish_MaximumSimultaneousStoryPublishCount,short Publish_MinimumStoryScore,short Publish_MinimumStoryKickCount,short Publish_MinimumStoryCommentCount,short Publish_MinimumAverageStoryKicksPerHour,short Publish_MinimunAverageCommentsPerHour,short Publish_MinimumViewCount,short Publish_KickScore,short Publish_CommentScore,string AdsenseID,string TrackingHtml,string AnnouncementHtml,string SmtpHost,int? SmtpPort,string SmtpUsername,string SmtpPassword,bool? SmtpEnableSsl,string FeedBurnerMainRssFeedUrl,string FeedBurnerMainRssFeedCountHtml,bool? UseStaticRoot)
	    {
		    Host item = new Host();
		    
				item.HostID = HostID;
				
				item.HostName = HostName;
				
				item.RootUrl = RootUrl;
				
				item.SiteTitle = SiteTitle;
				
				item.SiteDescription = SiteDescription;
				
				item.TagLine = TagLine;
				
				item.LogoPath = LogoPath;
				
				item.CreatedOn = CreatedOn;
				
				item.BlogUrl = BlogUrl;
				
				item.Email = Email;
				
				item.Template = Template;
				
				item.ShowAds = ShowAds;
				
				item.Culture = Culture;
				
				item.UICulture = UICulture;
				
				item.Publish_MinimumStoryAgeInHours = Publish_MinimumStoryAgeInHours;
				
				item.Publish_MaximumStoryAgeInHours = Publish_MaximumStoryAgeInHours;
				
				item.Publish_MaximumSimultaneousStoryPublishCount = Publish_MaximumSimultaneousStoryPublishCount;
				
				item.Publish_MinimumStoryScore = Publish_MinimumStoryScore;
				
				item.Publish_MinimumStoryKickCount = Publish_MinimumStoryKickCount;
				
				item.Publish_MinimumStoryCommentCount = Publish_MinimumStoryCommentCount;
				
				item.Publish_MinimumAverageStoryKicksPerHour = Publish_MinimumAverageStoryKicksPerHour;
				
				item.Publish_MinimunAverageCommentsPerHour = Publish_MinimunAverageCommentsPerHour;
				
				item.Publish_MinimumViewCount = Publish_MinimumViewCount;
				
				item.Publish_KickScore = Publish_KickScore;
				
				item.Publish_CommentScore = Publish_CommentScore;
				
				item.AdsenseID = AdsenseID;
				
				item.TrackingHtml = TrackingHtml;
				
				item.AnnouncementHtml = AnnouncementHtml;
				
				item.SmtpHost = SmtpHost;
				
				item.SmtpPort = SmtpPort;
				
				item.SmtpUsername = SmtpUsername;
				
				item.SmtpPassword = SmtpPassword;
				
				item.SmtpEnableSsl = SmtpEnableSsl;
				
				item.FeedBurnerMainRssFeedUrl = FeedBurnerMainRssFeedUrl;
				
				item.FeedBurnerMainRssFeedCountHtml = FeedBurnerMainRssFeedCountHtml;
				
				item.UseStaticRoot = UseStaticRoot;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

