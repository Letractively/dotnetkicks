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
    /// Controller class for ELMAH_Error
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class Elmah_ErrorController
    {
        // Preload our schema..
        Elmah_Error thisSchemaLoad = new Elmah_Error();
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
        public Elmah_ErrorCollection FetchAll()
        {
            Elmah_ErrorCollection coll = new Elmah_ErrorCollection();
            Query qry = new Query(Elmah_Error.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Elmah_ErrorCollection FetchByID(object ErrorId)
        {
            Elmah_ErrorCollection coll = new Elmah_ErrorCollection().Where("ErrorId", ErrorId).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public Elmah_ErrorCollection FetchByQuery(Query qry)
        {
            Elmah_ErrorCollection coll = new Elmah_ErrorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object ErrorId)
        {
            return (Elmah_Error.Delete(ErrorId) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object ErrorId)
        {
            return (Elmah_Error.Destroy(ErrorId) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(Guid ErrorId,string Application,string Host,string Type,string Source,string Message,string User,int StatusCode,DateTime TimeUtc,string AllXml)
	    {
		    Elmah_Error item = new Elmah_Error();
		    
            item.ErrorId = ErrorId;
            
            item.Application = Application;
            
            item.Host = Host;
            
            item.Type = Type;
            
            item.Source = Source;
            
            item.Message = Message;
            
            item.User = User;
            
            item.StatusCode = StatusCode;
            
            item.TimeUtc = TimeUtc;
            
            item.AllXml = AllXml;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(Guid ErrorId,string Application,string Host,string Type,string Source,string Message,string User,int StatusCode,DateTime TimeUtc,int Sequence,string AllXml)
	    {
		    Elmah_Error item = new Elmah_Error();
		    
				item.ErrorId = ErrorId;
				
				item.Application = Application;
				
				item.Host = Host;
				
				item.Type = Type;
				
				item.Source = Source;
				
				item.Message = Message;
				
				item.User = User;
				
				item.StatusCode = StatusCode;
				
				item.TimeUtc = TimeUtc;
				
				item.Sequence = Sequence;
				
				item.AllXml = AllXml;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

