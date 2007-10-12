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
    /// Controller class for Kick_StoryKick
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class StoryKickController
    {
        // Preload our schema..
        StoryKick thisSchemaLoad = new StoryKick();
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
        public StoryKickCollection FetchAll()
        {
            StoryKickCollection coll = new StoryKickCollection();
            Query qry = new Query(StoryKick.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoryKickCollection FetchByID(object StoryKickID)
        {
            StoryKickCollection coll = new StoryKickCollection().Where("StoryKickID", StoryKickID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public StoryKickCollection FetchByQuery(Query qry)
        {
            StoryKickCollection coll = new StoryKickCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object StoryKickID)
        {
            return (StoryKick.Delete(StoryKickID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object StoryKickID)
        {
            return (StoryKick.Destroy(StoryKickID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int StoryID,int UserID,int HostID,DateTime CreatedOn)
	    {
		    StoryKick item = new StoryKick();
		    
            item.StoryID = StoryID;
            
            item.UserID = UserID;
            
            item.HostID = HostID;
            
            item.CreatedOn = CreatedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int StoryKickID,int StoryID,int UserID,int HostID,DateTime CreatedOn)
	    {
		    StoryKick item = new StoryKick();
		    
				item.StoryKickID = StoryKickID;
				
				item.StoryID = StoryID;
				
				item.UserID = UserID;
				
				item.HostID = HostID;
				
				item.CreatedOn = CreatedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

