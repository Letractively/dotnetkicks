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
    /// Controller class for Kick_UserAction
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserActionController
    {
        // Preload our schema..
        UserAction thisSchemaLoad = new UserAction();
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
        public UserActionCollection FetchAll()
        {
            UserActionCollection coll = new UserActionCollection();
            Query qry = new Query(UserAction.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserActionCollection FetchByID(object UserActionID)
        {
            UserActionCollection coll = new UserActionCollection().Where("UserActionID", UserActionID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserActionCollection FetchByQuery(Query qry)
        {
            UserActionCollection coll = new UserActionCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserActionID)
        {
            return (UserAction.Delete(UserActionID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserActionID)
        {
            return (UserAction.Destroy(UserActionID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? UserID,int HostID,int UserActionTypeID,string Message,int? ToUserID,int? StoryID,int? ChatID,DateTime CreatedOn)
	    {
		    UserAction item = new UserAction();
		    
            item.UserID = UserID;
            
            item.HostID = HostID;
            
            item.UserActionTypeID = UserActionTypeID;
            
            item.Message = Message;
            
            item.ToUserID = ToUserID;
            
            item.StoryID = StoryID;
            
            item.ChatID = ChatID;
            
            item.CreatedOn = CreatedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserActionID,int? UserID,int HostID,int UserActionTypeID,string Message,int? ToUserID,int? StoryID,int? ChatID,DateTime CreatedOn)
	    {
		    UserAction item = new UserAction();
		    
				item.UserActionID = UserActionID;
				
				item.UserID = UserID;
				
				item.HostID = HostID;
				
				item.UserActionTypeID = UserActionTypeID;
				
				item.Message = Message;
				
				item.ToUserID = ToUserID;
				
				item.StoryID = StoryID;
				
				item.ChatID = ChatID;
				
				item.CreatedOn = CreatedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

