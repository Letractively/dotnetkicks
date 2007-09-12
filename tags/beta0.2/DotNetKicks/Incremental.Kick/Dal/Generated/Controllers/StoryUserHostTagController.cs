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
    /// Controller class for Kick_StoryUserHostTag
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StoryUserHostTagController
    {
        // Preload our schema..
        StoryUserHostTag thisSchemaLoad = new StoryUserHostTag();
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
        public StoryUserHostTagCollection FetchAll()
        {
            StoryUserHostTagCollection coll = new StoryUserHostTagCollection();
            Query qry = new Query(StoryUserHostTag.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoryUserHostTagCollection FetchByID(object StoryUserHostTagID)
        {
            StoryUserHostTagCollection coll = new StoryUserHostTagCollection().Where("StoryUserHostTagID", StoryUserHostTagID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoryUserHostTagCollection FetchByQuery(Query qry)
        {
            StoryUserHostTagCollection coll = new StoryUserHostTagCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object StoryUserHostTagID)
        {
            return (StoryUserHostTag.Delete(StoryUserHostTagID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object StoryUserHostTagID)
        {
            return (StoryUserHostTag.Destroy(StoryUserHostTagID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int StoryID,int UserID,int HostID,int TagID,DateTime CreatedOn)
	    {
		    StoryUserHostTag item = new StoryUserHostTag();
		    
            item.StoryID = StoryID;
            
            item.UserID = UserID;
            
            item.HostID = HostID;
            
            item.TagID = TagID;
            
            item.CreatedOn = CreatedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int StoryUserHostTagID,int StoryID,int UserID,int HostID,int TagID,DateTime CreatedOn)
	    {
		    StoryUserHostTag item = new StoryUserHostTag();
		    
				item.StoryUserHostTagID = StoryUserHostTagID;
				
				item.StoryID = StoryID;
				
				item.UserID = UserID;
				
				item.HostID = HostID;
				
				item.TagID = TagID;
				
				item.CreatedOn = CreatedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

