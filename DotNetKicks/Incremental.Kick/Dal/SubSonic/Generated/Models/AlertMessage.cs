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
	/// Strongly-typed collection for the AlertMessage class.
	/// </summary>
	[Serializable]
	public partial class AlertMessageCollection : ActiveList<AlertMessage, AlertMessageCollection> 
	{	   
		public AlertMessageCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_AlertMessage table.
	/// </summary>
	[Serializable]
	public partial class AlertMessage : ActiveRecord<AlertMessage>
	{
		#region .ctors and Default Settings
		
		public AlertMessage()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public AlertMessage(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public AlertMessage(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public AlertMessage(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor
		public static Query CreateQuery() { return new Query(Schema); }

		
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("Kick_AlertMessage", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarAlertID = new TableSchema.TableColumn(schema);
				colvarAlertID.ColumnName = "alertID";
				colvarAlertID.DataType = DbType.Int32;
				colvarAlertID.MaxLength = 0;
				colvarAlertID.AutoIncrement = true;
				colvarAlertID.IsNullable = false;
				colvarAlertID.IsPrimaryKey = true;
				colvarAlertID.IsForeignKey = false;
				colvarAlertID.IsReadOnly = false;
				colvarAlertID.DefaultSetting = @"";
				colvarAlertID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlertID);
				
				TableSchema.TableColumn colvarAlertTypeId = new TableSchema.TableColumn(schema);
				colvarAlertTypeId.ColumnName = "alertTypeId";
				colvarAlertTypeId.DataType = DbType.Int32;
				colvarAlertTypeId.MaxLength = 0;
				colvarAlertTypeId.AutoIncrement = false;
				colvarAlertTypeId.IsNullable = false;
				colvarAlertTypeId.IsPrimaryKey = false;
				colvarAlertTypeId.IsForeignKey = false;
				colvarAlertTypeId.IsReadOnly = false;
				colvarAlertTypeId.DefaultSetting = @"";
				colvarAlertTypeId.ForeignKeyTableName = "";
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
				colvarSingleAlertText.DefaultSetting = @"";
				colvarSingleAlertText.ForeignKeyTableName = "";
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
				colvarMultipleAlertText.DefaultSetting = @"";
				colvarMultipleAlertText.ForeignKeyTableName = "";
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
				colvarAlertOrder.DefaultSetting = @"";
				colvarAlertOrder.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlertOrder);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_AlertMessage",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("AlertID")]
		public int AlertID 
		{
			get { return GetColumnValue<int>(Columns.AlertID); }

			set { SetColumnValue(Columns.AlertID, value); }

		}

		  
		[XmlAttribute("AlertTypeId")]
		public int AlertTypeId 
		{
			get { return GetColumnValue<int>(Columns.AlertTypeId); }

			set { SetColumnValue(Columns.AlertTypeId, value); }

		}

		  
		[XmlAttribute("SingleAlertText")]
		public string SingleAlertText 
		{
			get { return GetColumnValue<string>(Columns.SingleAlertText); }

			set { SetColumnValue(Columns.SingleAlertText, value); }

		}

		  
		[XmlAttribute("MultipleAlertText")]
		public string MultipleAlertText 
		{
			get { return GetColumnValue<string>(Columns.MultipleAlertText); }

			set { SetColumnValue(Columns.MultipleAlertText, value); }

		}

		  
		[XmlAttribute("AlertOrder")]
		public int AlertOrder 
		{
			get { return GetColumnValue<int>(Columns.AlertOrder); }

			set { SetColumnValue(Columns.AlertOrder, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.UserAlertMessageCollection colUserAlertMessageRecords;
		public Incremental.Kick.Dal.UserAlertMessageCollection UserAlertMessageRecords()
		{
			if(colUserAlertMessageRecords == null)
				colUserAlertMessageRecords = new Incremental.Kick.Dal.UserAlertMessageCollection().Where(UserAlertMessage.Columns.AlertId, AlertID).Load();
			return colUserAlertMessageRecords;
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varAlertTypeId,string varSingleAlertText,string varMultipleAlertText,int varAlertOrder)
		{
			AlertMessage item = new AlertMessage();
			
			item.AlertTypeId = varAlertTypeId;
			
			item.SingleAlertText = varSingleAlertText;
			
			item.MultipleAlertText = varMultipleAlertText;
			
			item.AlertOrder = varAlertOrder;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varAlertID,int varAlertTypeId,string varSingleAlertText,string varMultipleAlertText,int varAlertOrder)
		{
			AlertMessage item = new AlertMessage();
			
				item.AlertID = varAlertID;
			
				item.AlertTypeId = varAlertTypeId;
			
				item.SingleAlertText = varSingleAlertText;
			
				item.MultipleAlertText = varMultipleAlertText;
			
				item.AlertOrder = varAlertOrder;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn AlertIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn AlertTypeIdColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn SingleAlertTextColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn MultipleAlertTextColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn AlertOrderColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string AlertID = @"alertID";
			 public static string AlertTypeId = @"alertTypeId";
			 public static string SingleAlertText = @"singleAlertText";
			 public static string MultipleAlertText = @"multipleAlertText";
			 public static string AlertOrder = @"alertOrder";
						
		}

		#endregion
	}

}

