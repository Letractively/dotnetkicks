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
    /// Controller class for Kick_Setting
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SettingController
    {
        // Preload our schema..
        Setting thisSchemaLoad = new Setting();
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
        public SettingCollection FetchAll()
        {
            SettingCollection coll = new SettingCollection();
            Query qry = new Query(Setting.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SettingCollection FetchByID(object SettingID)
        {
            SettingCollection coll = new SettingCollection().Where("SettingID", SettingID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SettingCollection FetchByQuery(Query qry)
        {
            SettingCollection coll = new SettingCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object SettingID)
        {
            return (Setting.Delete(SettingID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object SettingID)
        {
            return (Setting.Destroy(SettingID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string ValueX)
	    {
		    Setting item = new Setting();
		    
            item.Name = Name;
            
            item.ValueX = ValueX;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int SettingID,string Name,string ValueX)
	    {
		    Setting item = new Setting();
		    
				item.SettingID = SettingID;
				
				item.Name = Name;
				
				item.ValueX = ValueX;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

