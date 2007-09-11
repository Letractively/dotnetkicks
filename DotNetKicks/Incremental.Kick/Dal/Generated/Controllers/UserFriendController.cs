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
    /// Controller class for Kick_UserFriend
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserFriendController
    {
        // Preload our schema..
        UserFriend thisSchemaLoad = new UserFriend();
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
        public UserFriendCollection FetchAll()
        {
            UserFriendCollection coll = new UserFriendCollection();
            Query qry = new Query(UserFriend.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserFriendCollection FetchByID(object UserFriendID)
        {
            UserFriendCollection coll = new UserFriendCollection().Where("UserFriendID", UserFriendID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserFriendCollection FetchByQuery(Query qry)
        {
            UserFriendCollection coll = new UserFriendCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserFriendID)
        {
            return (UserFriend.Delete(UserFriendID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserFriendID)
        {
            return (UserFriend.Destroy(UserFriendID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserID,int FriendID,DateTime CreatedOn)
	    {
		    UserFriend item = new UserFriend();
		    
            item.UserID = UserID;
            
            item.FriendID = FriendID;
            
            item.CreatedOn = CreatedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserFriendID,int UserID,int FriendID,DateTime CreatedOn)
	    {
		    UserFriend item = new UserFriend();
		    
				item.UserFriendID = UserFriendID;
				
				item.UserID = UserID;
				
				item.FriendID = FriendID;
				
				item.CreatedOn = CreatedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

