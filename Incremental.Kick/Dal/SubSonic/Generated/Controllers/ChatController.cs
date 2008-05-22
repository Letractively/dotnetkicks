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
    /// Controller class for Kick_Chat
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ChatController
    {
        // Preload our schema..
        Chat thisSchemaLoad = new Chat();
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
        public ChatCollection FetchAll()
        {
            ChatCollection coll = new ChatCollection();
            Query qry = new Query(Chat.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ChatCollection FetchByID(object ChatID)
        {
            ChatCollection coll = new ChatCollection().Where("ChatID", ChatID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ChatCollection FetchByQuery(Query qry)
        {
            ChatCollection coll = new ChatCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ChatID)
        {
            return (Chat.Delete(ChatID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ChatID)
        {
            return (Chat.Destroy(ChatID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int UserID,int HostID,string Title,string Description,DateTime? StartDate,DateTime? EndDate,bool IsPrivate,DateTime CreatedOn,DateTime ModifiedOn)
	    {
		    Chat item = new Chat();
		    
            item.UserID = UserID;
            
            item.HostID = HostID;
            
            item.Title = Title;
            
            item.Description = Description;
            
            item.StartDate = StartDate;
            
            item.EndDate = EndDate;
            
            item.IsPrivate = IsPrivate;
            
            item.CreatedOn = CreatedOn;
            
            item.ModifiedOn = ModifiedOn;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int ChatID,int UserID,int HostID,string Title,string Description,DateTime? StartDate,DateTime? EndDate,bool IsPrivate,DateTime CreatedOn,DateTime ModifiedOn)
	    {
		    Chat item = new Chat();
		    
				item.ChatID = ChatID;
				
				item.UserID = UserID;
				
				item.HostID = HostID;
				
				item.Title = Title;
				
				item.Description = Description;
				
				item.StartDate = StartDate;
				
				item.EndDate = EndDate;
				
				item.IsPrivate = IsPrivate;
				
				item.CreatedOn = CreatedOn;
				
				item.ModifiedOn = ModifiedOn;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

