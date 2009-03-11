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
    /// Controller class for Kick_UserAlertMessage
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserAlertMessageController
    {
        // Preload our schema..
        UserAlertMessage thisSchemaLoad = new UserAlertMessage();
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
        public UserAlertMessageCollection FetchAll()
        {
            UserAlertMessageCollection coll = new UserAlertMessageCollection();
            Query qry = new Query(UserAlertMessage.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserAlertMessageCollection FetchByID(object UserAlertID)
        {
            UserAlertMessageCollection coll = new UserAlertMessageCollection().Where("userAlertID", UserAlertID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserAlertMessageCollection FetchByQuery(Query qry)
        {
            UserAlertMessageCollection coll = new UserAlertMessageCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserAlertID)
        {
            return (UserAlertMessage.Delete(UserAlertID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserAlertID)
        {
            return (UserAlertMessage.Destroy(UserAlertID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserId,int AlertId,int AlertCount)
	    {
		    UserAlertMessage item = new UserAlertMessage();
		    
            item.UserId = UserId;
            
            item.AlertId = AlertId;
            
            item.AlertCount = AlertCount;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserAlertID,int UserId,int AlertId,int AlertCount)
	    {
		    UserAlertMessage item = new UserAlertMessage();
		    
				item.UserAlertID = UserAlertID;
				
				item.UserId = UserId;
				
				item.AlertId = AlertId;
				
				item.AlertCount = AlertCount;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

