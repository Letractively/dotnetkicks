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
	/// Strongly-typed collection for the Chat class.
	/// </summary>
	[Serializable]
	public partial class ChatCollection : ActiveList<Chat, ChatCollection> 
	{	   
		public ChatCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Chat table.
	/// </summary>
	[Serializable]
	public partial class Chat : ActiveRecord<Chat>
	{
		#region .ctors and Default Settings
		
		public Chat()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Chat(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Chat(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Chat(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Chat", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarChatID = new TableSchema.TableColumn(schema);
				colvarChatID.ColumnName = "ChatID";
				colvarChatID.DataType = DbType.Int32;
				colvarChatID.MaxLength = 0;
				colvarChatID.AutoIncrement = true;
				colvarChatID.IsNullable = false;
				colvarChatID.IsPrimaryKey = true;
				colvarChatID.IsForeignKey = false;
				colvarChatID.IsReadOnly = false;
				colvarChatID.DefaultSetting = @"";
				colvarChatID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChatID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = false;
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
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 50;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = false;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 2000;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = true;
				colvarStartDate.IsPrimaryKey = false;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
				colvarEndDate.ColumnName = "EndDate";
				colvarEndDate.DataType = DbType.DateTime;
				colvarEndDate.MaxLength = 0;
				colvarEndDate.AutoIncrement = false;
				colvarEndDate.IsNullable = true;
				colvarEndDate.IsPrimaryKey = false;
				colvarEndDate.IsForeignKey = false;
				colvarEndDate.IsReadOnly = false;
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
				TableSchema.TableColumn colvarIsPrivate = new TableSchema.TableColumn(schema);
				colvarIsPrivate.ColumnName = "IsPrivate";
				colvarIsPrivate.DataType = DbType.Boolean;
				colvarIsPrivate.MaxLength = 0;
				colvarIsPrivate.AutoIncrement = false;
				colvarIsPrivate.IsNullable = false;
				colvarIsPrivate.IsPrimaryKey = false;
				colvarIsPrivate.IsForeignKey = false;
				colvarIsPrivate.IsReadOnly = false;
				colvarIsPrivate.DefaultSetting = @"";
				colvarIsPrivate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsPrivate);
				
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
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Chat",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ChatID")]
		public int ChatID 
		{
			get { return GetColumnValue<int>(Columns.ChatID); }

			set { SetColumnValue(Columns.ChatID, value); }

		}

		  
		[XmlAttribute("UserID")]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }

			set { SetColumnValue(Columns.Title, value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }

			set { SetColumnValue(Columns.Description, value); }

		}

		  
		[XmlAttribute("StartDate")]
		public DateTime? StartDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.StartDate); }

			set { SetColumnValue(Columns.StartDate, value); }

		}

		  
		[XmlAttribute("EndDate")]
		public DateTime? EndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EndDate); }

			set { SetColumnValue(Columns.EndDate, value); }

		}

		  
		[XmlAttribute("IsPrivate")]
		public bool IsPrivate 
		{
			get { return GetColumnValue<bool>(Columns.IsPrivate); }

			set { SetColumnValue(Columns.IsPrivate, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		  
		[XmlAttribute("ModifiedOn")]
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }

			set { SetColumnValue(Columns.ModifiedOn, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.ShoutCollection colShoutRecords;
		public Incremental.Kick.Dal.ShoutCollection ShoutRecords()
		{
			if(colShoutRecords == null)
				colShoutRecords = new Incremental.Kick.Dal.ShoutCollection().Where(Shout.Columns.ChatID, ChatID).Load();
			return colShoutRecords;
		}

		private Incremental.Kick.Dal.UserActionCollection colUserActionRecords;
		public Incremental.Kick.Dal.UserActionCollection UserActionRecords()
		{
			if(colUserActionRecords == null)
				colUserActionRecords = new Incremental.Kick.Dal.UserActionCollection().Where(UserAction.Columns.ChatID, ChatID).Load();
			return colUserActionRecords;
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this Chat
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
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
		public static void Insert(int varUserID,int varHostID,string varTitle,string varDescription,DateTime? varStartDate,DateTime? varEndDate,bool varIsPrivate,DateTime varCreatedOn,DateTime varModifiedOn)
		{
			Chat item = new Chat();
			
			item.UserID = varUserID;
			
			item.HostID = varHostID;
			
			item.Title = varTitle;
			
			item.Description = varDescription;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.IsPrivate = varIsPrivate;
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedOn = varModifiedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varChatID,int varUserID,int varHostID,string varTitle,string varDescription,DateTime? varStartDate,DateTime? varEndDate,bool varIsPrivate,DateTime varCreatedOn,DateTime varModifiedOn)
		{
			Chat item = new Chat();
			
				item.ChatID = varChatID;
			
				item.UserID = varUserID;
			
				item.HostID = varHostID;
			
				item.Title = varTitle;
			
				item.Description = varDescription;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.IsPrivate = varIsPrivate;
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedOn = varModifiedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ChatIDColumn
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

        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn StartDateColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn EndDateColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        public static TableSchema.TableColumn IsPrivateColumn
        {
            get { return Schema.Columns[7]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[8]; }

        }

        
        
        
        public static TableSchema.TableColumn ModifiedOnColumn
        {
            get { return Schema.Columns[9]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ChatID = @"ChatID";
			 public static string UserID = @"UserID";
			 public static string HostID = @"HostID";
			 public static string Title = @"Title";
			 public static string Description = @"Description";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string IsPrivate = @"IsPrivate";
			 public static string CreatedOn = @"CreatedOn";
			 public static string ModifiedOn = @"ModifiedOn";
						
		}

		#endregion
	}

}

