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
    /// Controller class for Kick_ReservedUsername
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class ReservedUsernameController
    {
        // Preload our schema..
        ReservedUsername thisSchemaLoad = new ReservedUsername();
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
        public ReservedUsernameCollection FetchAll()
        {
            ReservedUsernameCollection coll = new ReservedUsernameCollection();
            Query qry = new Query(ReservedUsername.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReservedUsernameCollection FetchByID(object UsernameID)
        {
            ReservedUsernameCollection coll = new ReservedUsernameCollection().Where("UsernameID", UsernameID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public ReservedUsernameCollection FetchByQuery(Query qry)
        {
            ReservedUsernameCollection coll = new ReservedUsernameCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object UsernameID)
        {
            return (ReservedUsername.Delete(UsernameID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object UsernameID)
        {
            return (ReservedUsername.Destroy(UsernameID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Username)
	    {
		    ReservedUsername item = new ReservedUsername();
		    
            item.Username = Username;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int UsernameID,string Username)
	    {
		    ReservedUsername item = new ReservedUsername();
		    
				item.UsernameID = UsernameID;
				
				item.Username = Username;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

