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
	/// Strongly-typed collection for the UserFriend class.
	/// </summary>
	[Serializable]
	public partial class UserFriendCollection : ActiveList<UserFriend, UserFriendCollection> 
	{	   
		public UserFriendCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_UserFriend table.
	/// </summary>
	[Serializable]
	public partial class UserFriend : ActiveRecord<UserFriend>
	{
		#region .ctors and Default Settings
		
		public UserFriend()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public UserFriend(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public UserFriend(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public UserFriend(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_UserFriend", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserFriendID = new TableSchema.TableColumn(schema);
				colvarUserFriendID.ColumnName = "UserFriendID";
				colvarUserFriendID.DataType = DbType.Int32;
				colvarUserFriendID.MaxLength = 0;
				colvarUserFriendID.AutoIncrement = true;
				colvarUserFriendID.IsNullable = false;
				colvarUserFriendID.IsPrimaryKey = true;
				colvarUserFriendID.IsForeignKey = false;
				colvarUserFriendID.IsReadOnly = false;
				colvarUserFriendID.DefaultSetting = @"";
				colvarUserFriendID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserFriendID);
				
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
				
				TableSchema.TableColumn colvarFriendID = new TableSchema.TableColumn(schema);
				colvarFriendID.ColumnName = "FriendID";
				colvarFriendID.DataType = DbType.Int32;
				colvarFriendID.MaxLength = 0;
				colvarFriendID.AutoIncrement = false;
				colvarFriendID.IsNullable = false;
				colvarFriendID.IsPrimaryKey = false;
				colvarFriendID.IsForeignKey = true;
				colvarFriendID.IsReadOnly = false;
				colvarFriendID.DefaultSetting = @"";
				
					colvarFriendID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarFriendID);
				
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
				DataService.Providers["DotNetKicks"].AddSchema("Kick_UserFriend",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UserFriendID")]
		public int UserFriendID 
		{
			get { return GetColumnValue<int>(Columns.UserFriendID); }

			set { SetColumnValue(Columns.UserFriendID, value); }

		}

		  
		[XmlAttribute("UserID")]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("FriendID")]
		public int FriendID 
		{
			get { return GetColumnValue<int>(Columns.FriendID); }

			set { SetColumnValue(Columns.FriendID, value); }

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
		/// Returns a User ActiveRecord object related to this UserFriend
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.FriendID); }

			set { SetColumnValue("FriendID", value.UserID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this UserFriend
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
		public static void Insert(int varUserID,int varFriendID,DateTime varCreatedOn)
		{
			UserFriend item = new UserFriend();
			
			item.UserID = varUserID;
			
			item.FriendID = varFriendID;
			
			item.CreatedOn = varCreatedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserFriendID,int varUserID,int varFriendID,DateTime varCreatedOn)
		{
			UserFriend item = new UserFriend();
			
				item.UserFriendID = varUserFriendID;
			
				item.UserID = varUserID;
			
				item.FriendID = varFriendID;
			
				item.CreatedOn = varCreatedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UserFriendIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn FriendIDColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserFriendID = @"UserFriendID";
			 public static string UserID = @"UserID";
			 public static string FriendID = @"FriendID";
			 public static string CreatedOn = @"CreatedOn";
						
		}

		#endregion
	}

}

