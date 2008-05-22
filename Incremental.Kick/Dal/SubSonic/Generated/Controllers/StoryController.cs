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
    /// Controller class for Kick_Story
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StoryController
    {
        // Preload our schema..
        Story thisSchemaLoad = new Story();
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
        public StoryCollection FetchAll()
        {
            StoryCollection coll = new StoryCollection();
            Query qry = new Query(Story.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoryCollection FetchByID(object StoryID)
        {
            StoryCollection coll = new StoryCollection().Where("StoryID", StoryID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoryCollection FetchByQuery(Query qry)
        {
            StoryCollection coll = new StoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object StoryID)
        {
            return (Story.Delete(StoryID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object StoryID)
        {
            return (Story.Destroy(StoryID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int HostID,string StoryIdentifier,string Title,string Description,string Url,short CategoryID,int UserID,int KickCount,int SpamCount,int ViewCount,int CommentCount,bool IsPublishedToHomepage,bool IsSpam,string AdsenseID,DateTime CreatedOn,DateTime PublishedOn,DateTime UpdatedOn)
	    {
		    Story item = new Story();
		    
            item.HostID = HostID;
            
            item.StoryIdentifier = StoryIdentifier;
            
            item.Title = Title;
            
            item.Description = Description;
            
            item.Url = Url;
            
            item.CategoryID = CategoryID;
            
            item.UserID = UserID;
            
            item.KickCount = KickCount;
            
            item.SpamCount = SpamCount;
            
            item.ViewCount = ViewCount;
            
            item.CommentCount = CommentCount;
            
            item.IsPublishedToHomepage = IsPublishedToHomepage;
            
            item.IsSpam = IsSpam;
            
            item.AdsenseID = AdsenseID;
            
            item.CreatedOn = CreatedOn;
            
            item.PublishedOn = PublishedOn;
            
            item.UpdatedOn = UpdatedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int StoryID,int HostID,string StoryIdentifier,string Title,string Description,string Url,short CategoryID,int UserID,int KickCount,int SpamCount,int ViewCount,int CommentCount,bool IsPublishedToHomepage,bool IsSpam,string AdsenseID,DateTime CreatedOn,DateTime PublishedOn,DateTime UpdatedOn)
	    {
		    Story item = new Story();
		    
				item.StoryID = StoryID;
				
				item.HostID = HostID;
				
				item.StoryIdentifier = StoryIdentifier;
				
				item.Title = Title;
				
				item.Description = Description;
				
				item.Url = Url;
				
				item.CategoryID = CategoryID;
				
				item.UserID = UserID;
				
				item.KickCount = KickCount;
				
				item.SpamCount = SpamCount;
				
				item.ViewCount = ViewCount;
				
				item.CommentCount = CommentCount;
				
				item.IsPublishedToHomepage = IsPublishedToHomepage;
				
				item.IsSpam = IsSpam;
				
				item.AdsenseID = AdsenseID;
				
				item.CreatedOn = CreatedOn;
				
				item.PublishedOn = PublishedOn;
				
				item.UpdatedOn = UpdatedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

