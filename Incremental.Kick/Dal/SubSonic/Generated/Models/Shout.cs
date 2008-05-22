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
	/// Strongly-typed collection for the Shout class.
	/// </summary>
	[Serializable]
	public partial class ShoutCollection : ActiveList<Shout, ShoutCollection> 
	{	   
		public ShoutCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Shout table.
	/// </summary>
	[Serializable]
	public partial class Shout : ActiveRecord<Shout>
	{
		#region .ctors and Default Settings
		
		public Shout()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Shout(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Shout(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Shout(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Shout", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarShoutID = new TableSchema.TableColumn(schema);
				colvarShoutID.ColumnName = "ShoutID";
				colvarShoutID.DataType = DbType.Int32;
				colvarShoutID.MaxLength = 0;
				colvarShoutID.AutoIncrement = true;
				colvarShoutID.IsNullable = false;
				colvarShoutID.IsPrimaryKey = true;
				colvarShoutID.IsForeignKey = false;
				colvarShoutID.IsReadOnly = false;
				colvarShoutID.DefaultSetting = @"";
				colvarShoutID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShoutID);
				
				TableSchema.TableColumn colvarFromUserID = new TableSchema.TableColumn(schema);
				colvarFromUserID.ColumnName = "FromUserID";
				colvarFromUserID.DataType = DbType.Int32;
				colvarFromUserID.MaxLength = 0;
				colvarFromUserID.AutoIncrement = false;
				colvarFromUserID.IsNullable = false;
				colvarFromUserID.IsPrimaryKey = false;
				colvarFromUserID.IsForeignKey = true;
				colvarFromUserID.IsReadOnly = false;
				colvarFromUserID.DefaultSetting = @"";
				
					colvarFromUserID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarFromUserID);
				
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
				
				TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(schema);
				colvarHostID.ColumnName = "HostID";
				colvarHostID.DataType = DbType.Int32;
				colvarHostID.MaxLength = 0;
				colvarHostID.AutoIncrement = false;
				colvarHostID.IsNullable = false;
				colvarHostID.IsPrimaryKey = false;
				colvarHostID.IsForeignKey = true;
				colvarHostID.IsReadOnly = false;
				colvarHostID.DefaultSetting = @"";
				
					colvarHostID.ForeignKeyTableName = "Kick_Host";
				schema.Columns.Add(colvarHostID);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.String;
				colvarMessage.MaxLength = 4000;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = false;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
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
				
				TableSchema.TableColumn colvarIsSpam = new TableSchema.TableColumn(schema);
				colvarIsSpam.ColumnName = "IsSpam";
				colvarIsSpam.DataType = DbType.Boolean;
				colvarIsSpam.MaxLength = 0;
				colvarIsSpam.AutoIncrement = false;
				colvarIsSpam.IsNullable = false;
				colvarIsSpam.IsPrimaryKey = false;
				colvarIsSpam.IsForeignKey = false;
				colvarIsSpam.IsReadOnly = false;
				
						colvarIsSpam.DefaultSetting = @"((0))";
				colvarIsSpam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsSpam);
				
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
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Shout",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ShoutID")]
		public int ShoutID 
		{
			get { return GetColumnValue<int>(Columns.ShoutID); }

			set { SetColumnValue(Columns.ShoutID, value); }

		}

		  
		[XmlAttribute("FromUserID")]
		public int FromUserID 
		{
			get { return GetColumnValue<int>(Columns.FromUserID); }

			set { SetColumnValue(Columns.FromUserID, value); }

		}

		  
		[XmlAttribute("ToUserID")]
		public int? ToUserID 
		{
			get { return GetColumnValue<int?>(Columns.ToUserID); }

			set { SetColumnValue(Columns.ToUserID, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("Message")]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }

			set { SetColumnValue(Columns.Message, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		  
		[XmlAttribute("IsSpam")]
		public bool IsSpam 
		{
			get { return GetColumnValue<bool>(Columns.IsSpam); }

			set { SetColumnValue(Columns.IsSpam, value); }

		}

		  
		[XmlAttribute("ChatID")]
		public int? ChatID 
		{
			get { return GetColumnValue<int?>(Columns.ChatID); }

			set { SetColumnValue(Columns.ChatID, value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Chat ActiveRecord object related to this Shout
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Chat Chat
		{
			get { return Incremental.Kick.Dal.Chat.FetchByID(this.ChatID); }

			set { SetColumnValue("ChatID", value.ChatID); }

		}

		
		
		/// <summary>
		/// Returns a Host ActiveRecord object related to this Shout
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Host Host
		{
			get { return Incremental.Kick.Dal.Host.FetchByID(this.HostID); }

			set { SetColumnValue("HostID", value.HostID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this Shout
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.FromUserID); }

			set { SetColumnValue("FromUserID", value.UserID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this Shout
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User UserToToUserID
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.ToUserID); }

			set { SetColumnValue("ToUserID", value.UserID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varFromUserID,int? varToUserID,int varHostID,string varMessage,DateTime varCreatedOn,bool varIsSpam,int? varChatID)
		{
			Shout item = new Shout();
			
			item.FromUserID = varFromUserID;
			
			item.ToUserID = varToUserID;
			
			item.HostID = varHostID;
			
			item.Message = varMessage;
			
			item.CreatedOn = varCreatedOn;
			
			item.IsSpam = varIsSpam;
			
			item.ChatID = varChatID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varShoutID,int varFromUserID,int? varToUserID,int varHostID,string varMessage,DateTime varCreatedOn,bool varIsSpam,int? varChatID)
		{
			Shout item = new Shout();
			
				item.ShoutID = varShoutID;
			
				item.FromUserID = varFromUserID;
			
				item.ToUserID = varToUserID;
			
				item.HostID = varHostID;
			
				item.Message = varMessage;
			
				item.CreatedOn = varCreatedOn;
			
				item.IsSpam = varIsSpam;
			
				item.ChatID = varChatID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn ShoutIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn FromUserIDColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn ToUserIDColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn HostIDColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn MessageColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn IsSpamColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        public static TableSchema.TableColumn ChatIDColumn
        {
            get { return Schema.Columns[7]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string ShoutID = @"ShoutID";
			 public static string FromUserID = @"FromUserID";
			 public static string ToUserID = @"ToUserID";
			 public static string HostID = @"HostID";
			 public static string Message = @"Message";
			 public static string CreatedOn = @"CreatedOn";
			 public static string IsSpam = @"IsSpam";
			 public static string ChatID = @"ChatID";
						
		}

		#endregion
	}

}

