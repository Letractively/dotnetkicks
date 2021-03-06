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
    /// Controller class for Kick_Category
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class CategoryController
    {
        // Preload our schema..
        Category thisSchemaLoad = new Category();
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
        public CategoryCollection FetchAll()
        {
            CategoryCollection coll = new CategoryCollection();
            Query qry = new Query(Category.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public CategoryCollection FetchByID(object CategoryID)
        {
            CategoryCollection coll = new CategoryCollection().Where("CategoryID", CategoryID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public CategoryCollection FetchByQuery(Query qry)
        {
            CategoryCollection coll = new CategoryCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object CategoryID)
        {
            return (Category.Delete(CategoryID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object CategoryID)
        {
            return (Category.Destroy(CategoryID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int HostID,string CategoryIdentifier,string Name,string Description,string IconName,short OrderPriority,string TagIdentifier)
	    {
		    Category item = new Category();
		    
            item.HostID = HostID;
            
            item.CategoryIdentifier = CategoryIdentifier;
            
            item.Name = Name;
            
            item.Description = Description;
            
            item.IconName = IconName;
            
            item.OrderPriority = OrderPriority;
            
            item.TagIdentifier = TagIdentifier;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short CategoryID,int HostID,string CategoryIdentifier,string Name,string Description,string IconName,short OrderPriority,string TagIdentifier)
	    {
		    Category item = new Category();
		    
				item.CategoryID = CategoryID;
				
				item.HostID = HostID;
				
				item.CategoryIdentifier = CategoryIdentifier;
				
				item.Name = Name;
				
				item.Description = Description;
				
				item.IconName = IconName;
				
				item.OrderPriority = OrderPriority;
				
				item.TagIdentifier = TagIdentifier;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

