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
	/// Strongly-typed collection for the UserAction class.
	/// </summary>
	[Serializable]
	public partial class UserActionCollection : ActiveList<UserAction, UserActionCollection> 
	{	   
		public UserActionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_UserAction table.
	/// </summary>
	[Serializable]
	public partial class UserAction : ActiveRecord<UserAction>
	{
		#region .ctors and Default Settings
		
		public UserAction()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public UserAction(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public UserAction(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public UserAction(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_UserAction", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserActionID = new TableSchema.TableColumn(schema);
				colvarUserActionID.ColumnName = "UserActionID";
				colvarUserActionID.DataType = DbType.Int32;
				colvarUserActionID.MaxLength = 0;
				colvarUserActionID.AutoIncrement = true;
				colvarUserActionID.IsNullable = false;
				colvarUserActionID.IsPrimaryKey = true;
				colvarUserActionID.IsForeignKey = false;
				colvarUserActionID.IsReadOnly = false;
				colvarUserActionID.DefaultSetting = @"";
				colvarUserActionID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserActionID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = true;
				colvarUserID.IsPrimaryKey = false;
				colvarUserID.IsForeignKey = true;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				
					colvarUserID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(schema);
				colvarHostID.ColumnName = "HostID";
				colvarHostID.DataType = DbType.Int32;
				colvarHostID.MaxLength = 0;
				colvarHostID.AutoIncrement = false;
				colvarHostID.IsNullable = false;
				colvarHostID.IsPrimaryKey = false;
				colvarHostID.IsForeignKey = false;
				colvarHostID.IsReadOnly = false;
				colvarHostID.DefaultSetting = @"";
				colvarHostID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostID);
				
				TableSchema.TableColumn colvarUserActionTypeID = new TableSchema.TableColumn(schema);
				colvarUserActionTypeID.ColumnName = "UserActionTypeID";
				colvarUserActionTypeID.DataType = DbType.Int32;
				colvarUserActionTypeID.MaxLength = 0;
				colvarUserActionTypeID.AutoIncrement = false;
				colvarUserActionTypeID.IsNullable = false;
				colvarUserActionTypeID.IsPrimaryKey = false;
				colvarUserActionTypeID.IsForeignKey = false;
				colvarUserActionTypeID.IsReadOnly = false;
				colvarUserActionTypeID.DefaultSetting = @"";
				colvarUserActionTypeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserActionTypeID);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.String;
				colvarMessage.MaxLength = 1000;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = false;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarToUserID = new TableSchema.TableColumn(schema);
				colvarToUserID.ColumnName = "ToUserID";
				colvarToUserID.DataType = DbType.Int32;
				colvarToUserID.MaxLength = 0;
				colvarToUserID.AutoIncrement = false;
				colvarToUserID.IsNullable = true;
				colvarToUserID.IsPrimaryKey = false;
				colvarToUserID.IsForeignKey = true;
				colvarToUserID.IsReadOnly = false;
				colvarToUserID.DefaultSetting = @"";
				
					colvarToUserID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarToUserID);
				
				TableSchema.TableColumn colvarStoryID = new TableSchema.TableColumn(schema);
				colvarStoryID.ColumnName = "StoryID";
				colvarStoryID.DataType = DbType.Int32;
				colvarStoryID.MaxLength = 0;
				colvarStoryID.AutoIncrement = false;
				colvarStoryID.IsNullable = true;
				colvarStoryID.IsPrimaryKey = false;
				colvarStoryID.IsForeignKey = true;
				colvarStoryID.IsReadOnly = false;
				colvarStoryID.DefaultSetting = @"";
				
					colvarStoryID.ForeignKeyTableName = "Kick_Story";
				schema.Columns.Add(colvarStoryID);
				
				TableSchema.TableColumn colvarChatID = new TableSchema.TableColumn(schema);
				colvarChatID.ColumnName = "ChatID";
				colvarChatID.DataType = DbType.Int32;
				colvarChatID.MaxLength = 0;
				colvarChatID.AutoIncrement = false;
				colvarChatID.IsNullable = true;
				colvarChatID.IsPrimaryKey = false;
				colvarChatID.IsForeignKey = true;
				colvarChatID.IsReadOnly = false;
				colvarChatID.DefaultSetting = @"";
				
					colvarChatID.ForeignKeyTableName = "Kick_Chat";
				schema.Columns.Add(colvarChatID);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_UserAction",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UserActionID")]
		public int UserActionID 
		{
			get { return GetColumnValue<int>(Columns.UserActionID); }

			set { SetColumnValue(Columns.UserActionID, value); }

		}

		  
		[XmlAttribute("UserID")]
		public int? UserID 
		{
			get { return GetColumnValue<int?>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("UserActionTypeID")]
		public int UserActionTypeID 
		{
			get { return GetColumnValue<int>(Columns.UserActionTypeID); }

			set { SetColumnValue(Columns.UserActionTypeID, value); }

		}

		  
		[XmlAttribute("Message")]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }

			set { SetColumnValue(Columns.Message, value); }

		}

		  
		[XmlAttribute("ToUserID")]
		public int? ToUserID 
		{
			get { return GetColumnValue<int?>(Columns.ToUserID); }

			set { SetColumnValue(Columns.ToUserID, value); }

		}

		  
		[XmlAttribute("StoryID")]
		public int? StoryID 
		{
			get { return GetColumnValue<int?>(Columns.StoryID); }

			set { SetColumnValue(Columns.StoryID, value); }

		}

		  
		[XmlAttribute("ChatID")]
		public int? ChatID 
		{
			get { return GetColumnValue<int?>(Columns.ChatID); }

			set { SetColumnValue(Columns.ChatID, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Chat ActiveRecord object related to this UserAction
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Chat Chat
		{
			get { return Incremental.Kick.Dal.Chat.FetchByID(this.ChatID); }

			set { SetColumnValue("ChatID", value.ChatID); }

		}

		
		
		/// <summary>
		/// Returns a Story ActiveRecord object related to this UserAction
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Story Story
		{
			get { return Incremental.Kick.Dal.Story.FetchByID(this.StoryID); }

			set { SetColumnValue("StoryID", value.StoryID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this UserAction
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.ToUserID); }

			set { SetColumnValue("ToUserID", value.UserID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this UserAction
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User UserToUserID
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.UserID); }

			set { SetColumnValue("UserID", value.UserID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varUserID,int varHostID,int varUserActionTypeID,string varMessage,int? varToUserID,int? varStoryID,int? varChatID,DateTime varCreatedOn)
		{
			UserAction item = new UserAction();
			
			item.UserID = varUserID;
			
			item.HostID = varHostID;
			
			item.UserActionTypeID = varUserActionTypeID;
			
			item.Message = varMessage;
			
			item.ToUserID = varToUserID;
			
			item.StoryID = varStoryID;
			
			item.ChatID = varChatID;
			
			item.CreatedOn = varCreatedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserActionID,int? varUserID,int varHostID,int varUserActionTypeID,string varMessage,int? varToUserID,int? varStoryID,int? varChatID,DateTime varCreatedOn)
		{
			UserAction item = new UserAction();
			
				item.UserActionID = varUserActionID;
			
				item.UserID = varUserID;
			
				item.HostID = varHostID;
			
				item.UserActionTypeID = varUserActionTypeID;
			
				item.Message = varMessage;
			
				item.ToUserID = varToUserID;
			
				item.StoryID = varStoryID;
			
				item.ChatID = varChatID;
			
				item.CreatedOn = varCreatedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UserActionIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn HostIDColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn UserActionTypeIDColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn MessageColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn ToUserIDColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn StoryIDColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        public static TableSchema.TableColumn ChatIDColumn
        {
            get { return Schema.Columns[7]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[8]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserActionID = @"UserActionID";
			 public static string UserID = @"UserID";
			 public static string HostID = @"HostID";
			 public static string UserActionTypeID = @"UserActionTypeID";
			 public static string Message = @"Message";
			 public static string ToUserID = @"ToUserID";
			 public static string StoryID = @"StoryID";
			 public static string ChatID = @"ChatID";
			 public static string CreatedOn = @"CreatedOn";
						
		}

		#endregion
	}

}

