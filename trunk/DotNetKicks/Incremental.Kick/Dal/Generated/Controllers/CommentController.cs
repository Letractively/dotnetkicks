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
    /// Controller class for Kick_Comment
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CommentController
    {
        // Preload our schema..
        Comment thisSchemaLoad = new Comment();
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
        public CommentCollection FetchAll()
        {
            CommentCollection coll = new CommentCollection();
            Query qry = new Query(Comment.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CommentCollection FetchByID(object CommentID)
        {
            CommentCollection coll = new CommentCollection().Where("CommentID", CommentID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CommentCollection FetchByQuery(Query qry)
        {
            CommentCollection coll = new CommentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CommentID)
        {
            return (Comment.Delete(CommentID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CommentID)
        {
            return (Comment.Destroy(CommentID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int StoryID,int UserID,string Username,string CommentX,DateTime CreatedOn,int HostID)
	    {
		    Comment item = new Comment();
		    
            item.StoryID = StoryID;
            
            item.UserID = UserID;
            
            item.Username = Username;
            
            item.CommentX = CommentX;
            
            item.CreatedOn = CreatedOn;
            
            item.HostID = HostID;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int CommentID,int StoryID,int UserID,string Username,string CommentX,DateTime CreatedOn,int HostID)
	    {
		    Comment item = new Comment();
		    
				item.CommentID = CommentID;
				
				item.StoryID = StoryID;
				
				item.UserID = UserID;
				
				item.Username = Username;
				
				item.CommentX = CommentX;
				
				item.CreatedOn = CreatedOn;
				
				item.HostID = HostID;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

