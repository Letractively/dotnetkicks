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
    /// Controller class for Kick_BlockedReferral
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class BlockedReferralController
    {
        // Preload our schema..
        BlockedReferral thisSchemaLoad = new BlockedReferral();
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
        public BlockedReferralCollection FetchAll()
        {
            BlockedReferralCollection coll = new BlockedReferralCollection();
            Query qry = new Query(BlockedReferral.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public BlockedReferralCollection FetchByID(object BlockedReferralID)
        {
            BlockedReferralCollection coll = new BlockedReferralCollection().Where("BlockedReferralID", BlockedReferralID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public BlockedReferralCollection FetchByQuery(Query qry)
        {
            BlockedReferralCollection coll = new BlockedReferralCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object BlockedReferralID)
        {
            return (BlockedReferral.Delete(BlockedReferralID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object BlockedReferralID)
        {
            return (BlockedReferral.Destroy(BlockedReferralID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string BlockedReferralHostname,int? HostID)
	    {
		    BlockedReferral item = new BlockedReferral();
		    
            item.BlockedReferralHostname = BlockedReferralHostname;
            
            item.HostID = HostID;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short BlockedReferralID,string BlockedReferralHostname,int? HostID)
	    {
		    BlockedReferral item = new BlockedReferral();
		    
				item.BlockedReferralID = BlockedReferralID;
				
				item.BlockedReferralHostname = BlockedReferralHostname;
				
				item.HostID = HostID;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

