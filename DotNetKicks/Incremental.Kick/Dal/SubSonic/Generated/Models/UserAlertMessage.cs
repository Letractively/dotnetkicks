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
	/// Strongly-typed collection for the UserAlertMessage class.
	/// </summary>
	[Serializable]
	public partial class UserAlertMessageCollection : ActiveList<UserAlertMessage, UserAlertMessageCollection> 
	{	   
		public UserAlertMessageCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_UserAlertMessage table.
	/// </summary>
	[Serializable]
	public partial class UserAlertMessage : ActiveRecord<UserAlertMessage>
	{
		#region .ctors and Default Settings
		
		public UserAlertMessage()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public UserAlertMessage(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public UserAlertMessage(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public UserAlertMessage(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_UserAlertMessage", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserAlertID = new TableSchema.TableColumn(schema);
				colvarUserAlertID.ColumnName = "userAlertID";
				colvarUserAlertID.DataType = DbType.Int32;
				colvarUserAlertID.MaxLength = 0;
				colvarUserAlertID.AutoIncrement = true;
				colvarUserAlertID.IsNullable = false;
				colvarUserAlertID.IsPrimaryKey = true;
				colvarUserAlertID.IsForeignKey = false;
				colvarUserAlertID.IsReadOnly = false;
				colvarUserAlertID.DefaultSetting = @"";
				colvarUserAlertID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserAlertID);
				
				TableSchema.TableColumn colvarUserId = new TableSchema.TableColumn(schema);
				colvarUserId.ColumnName = "userId";
				colvarUserId.DataType = DbType.Int32;
				colvarUserId.MaxLength = 0;
				colvarUserId.AutoIncrement = false;
				colvarUserId.IsNullable = false;
				colvarUserId.IsPrimaryKey = false;
				colvarUserId.IsForeignKey = true;
				colvarUserId.IsReadOnly = false;
				colvarUserId.DefaultSetting = @"";
				
					colvarUserId.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarUserId);
				
				TableSchema.TableColumn colvarAlertId = new TableSchema.TableColumn(schema);
				colvarAlertId.ColumnName = "alertId";
				colvarAlertId.DataType = DbType.Int32;
				colvarAlertId.MaxLength = 0;
				colvarAlertId.AutoIncrement = false;
				colvarAlertId.IsNullable = false;
				colvarAlertId.IsPrimaryKey = false;
				colvarAlertId.IsForeignKey = true;
				colvarAlertId.IsReadOnly = false;
				colvarAlertId.DefaultSetting = @"";
				
					colvarAlertId.ForeignKeyTableName = "Kick_AlertMessage";
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
				colvarAlertCount.DefaultSetting = @"";
				colvarAlertCount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAlertCount);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_UserAlertMessage",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UserAlertID")]
		public int UserAlertID 
		{
			get { return GetColumnValue<int>(Columns.UserAlertID); }

			set { SetColumnValue(Columns.UserAlertID, value); }

		}

		  
		[XmlAttribute("UserId")]
		public int UserId 
		{
			get { return GetColumnValue<int>(Columns.UserId); }

			set { SetColumnValue(Columns.UserId, value); }

		}

		  
		[XmlAttribute("AlertId")]
		public int AlertId 
		{
			get { return GetColumnValue<int>(Columns.AlertId); }

			set { SetColumnValue(Columns.AlertId, value); }

		}

		  
		[XmlAttribute("AlertCount")]
		public int AlertCount 
		{
			get { return GetColumnValue<int>(Columns.AlertCount); }

			set { SetColumnValue(Columns.AlertCount, value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a AlertMessage ActiveRecord object related to this UserAlertMessage
		/// 
		/// </summary>
		public Incremental.Kick.Dal.AlertMessage AlertMessage
		{
			get { return Incremental.Kick.Dal.AlertMessage.FetchByID(this.AlertId); }

			set { SetColumnValue("alertId", value.AlertID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this UserAlertMessage
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.UserId); }

			set { SetColumnValue("userId", value.UserID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varUserId,int varAlertId,int varAlertCount)
		{
			UserAlertMessage item = new UserAlertMessage();
			
			item.UserId = varUserId;
			
			item.AlertId = varAlertId;
			
			item.AlertCount = varAlertCount;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserAlertID,int varUserId,int varAlertId,int varAlertCount)
		{
			UserAlertMessage item = new UserAlertMessage();
			
				item.UserAlertID = varUserAlertID;
			
				item.UserId = varUserId;
			
				item.AlertId = varAlertId;
			
				item.AlertCount = varAlertCount;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UserAlertIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn UserIdColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn AlertIdColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn AlertCountColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserAlertID = @"userAlertID";
			 public static string UserId = @"userId";
			 public static string AlertId = @"alertId";
			 public static string AlertCount = @"alertCount";
						
		}

		#endregion
	}

}

