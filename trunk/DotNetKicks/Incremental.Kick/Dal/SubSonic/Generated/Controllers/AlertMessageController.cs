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
    /// Controller class for Kick_AlertMessage
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class AlertMessageController
    {
        // Preload our schema..
        AlertMessage thisSchemaLoad = new AlertMessage();
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
        public AlertMessageCollection FetchAll()
        {
            AlertMessageCollection coll = new AlertMessageCollection();
            Query qry = new Query(AlertMessage.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlertMessageCollection FetchByID(object AlertID)
        {
            AlertMessageCollection coll = new AlertMessageCollection().Where("alertID", AlertID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public AlertMessageCollection FetchByQuery(Query qry)
        {
            AlertMessageCollection coll = new AlertMessageCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object AlertID)
        {
            return (AlertMessage.Delete(AlertID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object AlertID)
        {
            return (AlertMessage.Destroy(AlertID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(int AlertTypeId,string SingleAlertText,string MultipleAlertText,int AlertOrder)
	    {
		    AlertMessage item = new AlertMessage();
		    
            item.AlertTypeId = AlertTypeId;
            
            item.SingleAlertText = SingleAlertText;
            
            item.MultipleAlertText = MultipleAlertText;
            
            item.AlertOrder = AlertOrder;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(int AlertID,int AlertTypeId,string SingleAlertText,string MultipleAlertText,int AlertOrder)
	    {
		    AlertMessage item = new AlertMessage();
		    
				item.AlertID = AlertID;
				
				item.AlertTypeId = AlertTypeId;
				
				item.SingleAlertText = SingleAlertText;
				
				item.MultipleAlertText = MultipleAlertText;
				
				item.AlertOrder = AlertOrder;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

