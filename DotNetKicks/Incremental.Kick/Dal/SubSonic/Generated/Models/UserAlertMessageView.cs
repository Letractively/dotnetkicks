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

namespace Incremental.Kick.Dal{
    /// <summary>
    /// Strongly-typed collection for the UserAlertMessageView class.
    /// </summary>
    [Serializable]
    public partial class UserAlertMessageViewCollection : ReadOnlyList<UserAlertMessageView, UserAlertMessageViewCollection>
    {        
        public UserAlertMessageViewCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the Kick_UserAlertMessageView view.
    /// </summary>
    [Serializable]
    public partial class UserAlertMessageView : ReadOnlyRecord<UserAlertMessageView> 
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("Kick_UserAlertMessageView", TableType.View, DataService.GetInstance("DotNetKicks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
                //columns
                
                TableSchema.TableColumn colvarUserAlertId = new TableSchema.TableColumn(schema);
                colvarUserAlertId.ColumnName = "userAlertId";
                colvarUserAlertId.DataType = DbType.Int32;
                colvarUserAlertId.MaxLength = 0;
                colvarUserAlertId.AutoIncrement = false;
                colvarUserAlertId.IsNullable = false;
                colvarUserAlertId.IsPrimaryKey = false;
                colvarUserAlertId.IsForeignKey = false;
                colvarUserAlertId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserAlertId);
                
                TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
                colvarUserId.ColumnName = "userId";
                colvarUserId.DataType = DbType.Int32;
                colvarUserId.MaxLength = 0;
                colvarUserId.AutoIncrement = false;
                colvarUserId.IsNullable = false;
                colvarUserId.IsPrimaryKey = false;
                colvarUserId.IsForeignKey = false;
                colvarUserId.IsReadOnly = false;
                
                schema.Columns.Add(colvarUserId);
                
                TableSchema.TableColumn colvarAlertId = new TableSchema.TableColumn(schema);
                colvarAlertId.ColumnName = "alertId";
                colvarAlertId.DataType = DbType.Int32;
                colvarAlertId.MaxLength = 0;
                colvarAlertId.AutoIncrement = false;
                colvarAlertId.IsNullable = false;
                colvarAlertId.IsPrimaryKey = false;
                colvarAlertId.IsForeignKey = false;
                colvarAlertId.IsReadOnly = false;
                
                schema.Columns.Add(colvarAlertId);
                
                TableSchema.TableColumn colvarAlertCount = new TableSchema.TableColumn(schema);
                colvarAlertCount.ColumnName = "alertCount";
                colvarAlertCount.DataType = DbType.Int32;
                colvarAlertCount.MaxLength = 0;
                colvarAlertCount.AutoIncrement = false;
                colvarAlertCount.IsNullable = false;
                colvarAlertCount.IsPrimaryKey = false;
                colvarAlertCount.IsForeignKey = false;
                colvarAlertCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarAlertCount);
                
                TableSchema.TableColumn colvarAlertTypeId = new TableSchema.TableColumn(schema);
                colvarAlertTypeId.ColumnName = "alertTypeId";
                colvarAlertTypeId.DataType = DbType.Int32;
                colvarAlertTypeId.MaxLength = 0;
                colvarAlertTypeId.AutoIncrement = false;
                colvarAlertTypeId.IsNullable = false;
                colvarAlertTypeId.IsPrimaryKey = false;
                colvarAlertTypeId.IsForeignKey = false;
                colvarAlertTypeId.IsReadOnly = false;
                
                schema.Columns.Add(colvarAlertTypeId);
                
                TableSchema.TableColumn colvarSingleAlertText = new TableSchema.TableColumn(schema);
                colvarSingleAlertText.ColumnName = "singleAlertText";
                colvarSingleAlertText.DataType = DbType.String;
                colvarSingleAlertText.MaxLength = 512;
                colvarSingleAlertText.AutoIncrement = false;
                colvarSingleAlertText.IsNullable = false;
                colvarSingleAlertText.IsPrimaryKey = false;
                colvarSingleAlertText.IsForeignKey = false;
                colvarSingleAlertText.IsReadOnly = false;
                
                schema.Columns.Add(colvarSingleAlertText);
                
                TableSchema.TableColumn colvarMultipleAlertText = new TableSchema.TableColumn(schema);
                colvarMultipleAlertText.ColumnName = "multipleAlertText";
                colvarMultipleAlertText.DataType = DbType.String;
                colvarMultipleAlertText.MaxLength = 512;
                colvarMultipleAlertText.AutoIncrement = false;
                colvarMultipleAlertText.IsNullable = false;
                colvarMultipleAlertText.IsPrimaryKey = false;
                colvarMultipleAlertText.IsForeignKey = false;
                colvarMultipleAlertText.IsReadOnly = false;
                
                schema.Columns.Add(colvarMultipleAlertText);
                
                TableSchema.TableColumn colvarAlertOrder = new TableSchema.TableColumn(schema);
                colvarAlertOrder.ColumnName = "alertOrder";
                colvarAlertOrder.DataType = DbType.Int32;
                colvarAlertOrder.MaxLength = 0;
                colvarAlertOrder.AutoIncrement = false;
                colvarAlertOrder.IsNullable = false;
                colvarAlertOrder.IsPrimaryKey = false;
                colvarAlertOrder.IsForeignKey = false;
                colvarAlertOrder.IsReadOnly = false;
                
                schema.Columns.Add(colvarAlertOrder);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["DotNetKicks"].AddSchema("Kick_UserAlertMessageView",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public UserAlertMessageView()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public UserAlertMessageView(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public UserAlertMessageView(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public UserAlertMessageView(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("UserAlertId")]
        public int UserAlertId 
	    {
		    get
		    {
			    return GetColumnValue<int>("userAlertId");
		    }

            set 
		    {
			    SetColumnValue("userAlertId", value);
            }

        }

	      
        [XmlAttribute("UserId")]
        public int UserId 
	    {
		    get
		    {
			    return GetColumnValue<int>("userId");
		    }

            set 
		    {
			    SetColumnValue("userId", value);
            }

        }

	      
        [XmlAttribute("AlertId")]
        public int AlertId 
	    {
		    get
		    {
			    return GetColumnValue<int>("alertId");
		    }

            set 
		    {
			    SetColumnValue("alertId", value);
            }

        }

	      
        [XmlAttribute("AlertCount")]
        public int AlertCount 
	    {
		    get
		    {
			    return GetColumnValue<int>("alertCount");
		    }

            set 
		    {
			    SetColumnValue("alertCount", value);
            }

        }

	      
        [XmlAttribute("AlertTypeId")]
        public int AlertTypeId 
	    {
		    get
		    {
			    return GetColumnValue<int>("alertTypeId");
		    }

            set 
		    {
			    SetColumnValue("alertTypeId", value);
            }

        }

	      
        [XmlAttribute("SingleAlertText")]
        public string SingleAlertText 
	    {
		    get
		    {
			    return GetColumnValue<string>("singleAlertText");
		    }

            set 
		    {
			    SetColumnValue("singleAlertText", value);
            }

        }

	      
        [XmlAttribute("MultipleAlertText")]
        public string MultipleAlertText 
	    {
		    get
		    {
			    return GetColumnValue<string>("multipleAlertText");
		    }

            set 
		    {
			    SetColumnValue("multipleAlertText", value);
            }

        }

	      
        [XmlAttribute("AlertOrder")]
        public int AlertOrder 
	    {
		    get
		    {
			    return GetColumnValue<int>("alertOrder");
		    }

            set 
		    {
			    SetColumnValue("alertOrder", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string UserAlertId = @"userAlertId";
            
            public static string UserId = @"userId";
            
            public static string AlertId = @"alertId";
            
            public static string AlertCount = @"alertCount";
            
            public static string AlertTypeId = @"alertTypeId";
            
            public static string SingleAlertText = @"singleAlertText";
            
            public static string MultipleAlertText = @"multipleAlertText";
            
            public static string AlertOrder = @"alertOrder";
            
	    }

	    #endregion
    }

}

