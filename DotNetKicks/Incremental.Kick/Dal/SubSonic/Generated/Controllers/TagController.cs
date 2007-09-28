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
    /// Controller class for Kick_Tag
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TagController
    {
        // Preload our schema..
        Tag thisSchemaLoad = new Tag();
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
        public TagCollection FetchAll()
        {
            TagCollection coll = new TagCollection();
            Query qry = new Query(Tag.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TagCollection FetchByID(object TagID)
        {
            TagCollection coll = new TagCollection().Where("TagID", TagID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TagCollection FetchByQuery(Query qry)
        {
            TagCollection coll = new TagCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TagID)
        {
            return (Tag.Delete(TagID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TagID)
        {
            return (Tag.Destroy(TagID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string TagIdentifier)
	    {
		    Tag item = new Tag();
		    
            item.TagIdentifier = TagIdentifier;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int TagID,string TagIdentifier)
	    {
		    Tag item = new Tag();
		    
				item.TagID = TagID;
				
				item.TagIdentifier = TagIdentifier;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

