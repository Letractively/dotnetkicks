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
    /// Controller class for Kick_Shout
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ShoutController
    {
        // Preload our schema..
        Shout thisSchemaLoad = new Shout();
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
        public ShoutCollection FetchAll()
        {
            ShoutCollection coll = new ShoutCollection();
            Query qry = new Query(Shout.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShoutCollection FetchByID(object ShoutID)
        {
            ShoutCollection coll = new ShoutCollection().Where("ShoutID", ShoutID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShoutCollection FetchByQuery(Query qry)
        {
            ShoutCollection coll = new ShoutCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ShoutID)
        {
            return (Shout.Delete(ShoutID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ShoutID)
        {
            return (Shout.Destroy(ShoutID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int FromUserID,int? ToUserID,int HostID,string Message,DateTime CreatedOn,bool IsSpam,int? ChatID)
	    {
		    Shout item = new Shout();
		    
            item.FromUserID = FromUserID;
            
            item.ToUserID = ToUserID;
            
            item.HostID = HostID;
            
            item.Message = Message;
            
            item.CreatedOn = CreatedOn;
            
            item.IsSpam = IsSpam;
            
            item.ChatID = ChatID;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ShoutID,int FromUserID,int? ToUserID,int HostID,string Message,DateTime CreatedOn,bool IsSpam,int? ChatID)
	    {
		    Shout item = new Shout();
		    
				item.ShoutID = ShoutID;
				
				item.FromUserID = FromUserID;
				
				item.ToUserID = ToUserID;
				
				item.HostID = HostID;
				
				item.Message = Message;
				
				item.CreatedOn = CreatedOn;
				
				item.IsSpam = IsSpam;
				
				item.ChatID = ChatID;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

