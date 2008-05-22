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
    /// Controller class for Kick_BannedUrlPattern
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BannedUrlPatternController
    {
        // Preload our schema..
        BannedUrlPattern thisSchemaLoad = new BannedUrlPattern();
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
        public BannedUrlPatternCollection FetchAll()
        {
            BannedUrlPatternCollection coll = new BannedUrlPatternCollection();
            Query qry = new Query(BannedUrlPattern.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BannedUrlPatternCollection FetchByID(object PatternId)
        {
            BannedUrlPatternCollection coll = new BannedUrlPatternCollection().Where("PatternId", PatternId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BannedUrlPatternCollection FetchByQuery(Query qry)
        {
            BannedUrlPatternCollection coll = new BannedUrlPatternCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PatternId)
        {
            return (BannedUrlPattern.Delete(PatternId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PatternId)
        {
            return (BannedUrlPattern.Destroy(PatternId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int? HostId,string Description,string BannedUrlRegex)
	    {
		    BannedUrlPattern item = new BannedUrlPattern();
		    
            item.HostId = HostId;
            
            item.Description = Description;
            
            item.BannedUrlRegex = BannedUrlRegex;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int PatternId,int? HostId,string Description,string BannedUrlRegex)
	    {
		    BannedUrlPattern item = new BannedUrlPattern();
		    
				item.PatternId = PatternId;
				
				item.HostId = HostId;
				
				item.Description = Description;
				
				item.BannedUrlRegex = BannedUrlRegex;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

