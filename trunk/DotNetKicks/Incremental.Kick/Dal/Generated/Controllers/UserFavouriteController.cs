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
    /// Controller class for Kick_UserFavourite
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class UserFavouriteController
    {
        // Preload our schema..
        UserFavourite thisSchemaLoad = new UserFavourite();
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
        public UserFavouriteCollection FetchAll()
        {
            UserFavouriteCollection coll = new UserFavouriteCollection();
            Query qry = new Query(UserFavourite.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserFavouriteCollection FetchByID(object UserFavouriteID)
        {
            UserFavouriteCollection coll = new UserFavouriteCollection().Where("UserFavouriteID", UserFavouriteID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public UserFavouriteCollection FetchByQuery(Query qry)
        {
            UserFavouriteCollection coll = new UserFavouriteCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UserFavouriteID)
        {
            return (UserFavourite.Delete(UserFavouriteID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UserFavouriteID)
        {
            return (UserFavourite.Destroy(UserFavouriteID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserID,int FavouredUserID,DateTime CreatedOn)
	    {
		    UserFavourite item = new UserFavourite();
		    
            item.UserID = UserID;
            
            item.FavouredUserID = FavouredUserID;
            
            item.CreatedOn = CreatedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UserFavouriteID,int UserID,int FavouredUserID,DateTime CreatedOn)
	    {
		    UserFavourite item = new UserFavourite();
		    
				item.UserFavouriteID = UserFavouriteID;
				
				item.UserID = UserID;
				
				item.FavouredUserID = FavouredUserID;
				
				item.CreatedOn = CreatedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

