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
	/// Strongly-typed collection for the UserFavourite class.
	/// </summary>
	[Serializable]
	public partial class UserFavouriteCollection : ActiveList<UserFavourite, UserFavouriteCollection> 
	{	   
		public UserFavouriteCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_UserFavourite table.
	/// </summary>
	[Serializable]
	public partial class UserFavourite : ActiveRecord<UserFavourite>
	{
		#region .ctors and Default Settings
		
		public UserFavourite()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public UserFavourite(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public UserFavourite(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public UserFavourite(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_UserFavourite", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserFavouriteID = new TableSchema.TableColumn(schema);
				colvarUserFavouriteID.ColumnName = "UserFavouriteID";
				colvarUserFavouriteID.DataType = DbType.Int32;
				colvarUserFavouriteID.MaxLength = 0;
				colvarUserFavouriteID.AutoIncrement = true;
				colvarUserFavouriteID.IsNullable = false;
				colvarUserFavouriteID.IsPrimaryKey = true;
				colvarUserFavouriteID.IsForeignKey = false;
				colvarUserFavouriteID.IsReadOnly = false;
				colvarUserFavouriteID.DefaultSetting = @"";
				colvarUserFavouriteID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUserFavouriteID);
				
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
				
				TableSchema.TableColumn colvarFavouredUserID = new TableSchema.TableColumn(schema);
				colvarFavouredUserID.ColumnName = "FavouredUserID";
				colvarFavouredUserID.DataType = DbType.Int32;
				colvarFavouredUserID.MaxLength = 0;
				colvarFavouredUserID.AutoIncrement = false;
				colvarFavouredUserID.IsNullable = false;
				colvarFavouredUserID.IsPrimaryKey = false;
				colvarFavouredUserID.IsForeignKey = true;
				colvarFavouredUserID.IsReadOnly = false;
				colvarFavouredUserID.DefaultSetting = @"";
				
					colvarFavouredUserID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarFavouredUserID);
				
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
				DataService.Providers["DotNetKicks"].AddSchema("Kick_UserFavourite",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UserFavouriteID")]
		public int UserFavouriteID 
		{
			get { return GetColumnValue<int>(Columns.UserFavouriteID); }

			set { SetColumnValue(Columns.UserFavouriteID, value); }

		}

		  
		[XmlAttribute("UserID")]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("FavouredUserID")]
		public int FavouredUserID 
		{
			get { return GetColumnValue<int>(Columns.FavouredUserID); }

			set { SetColumnValue(Columns.FavouredUserID, value); }

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
		/// Returns a User ActiveRecord object related to this UserFavourite
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.FavouredUserID); }

			set { SetColumnValue("FavouredUserID", value.UserID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this UserFavourite
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
		public static void Insert(int varUserID,int varFavouredUserID,DateTime varCreatedOn)
		{
			UserFavourite item = new UserFavourite();
			
			item.UserID = varUserID;
			
			item.FavouredUserID = varFavouredUserID;
			
			item.CreatedOn = varCreatedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserFavouriteID,int varUserID,int varFavouredUserID,DateTime varCreatedOn)
		{
			UserFavourite item = new UserFavourite();
			
				item.UserFavouriteID = varUserFavouriteID;
			
				item.UserID = varUserID;
			
				item.FavouredUserID = varFavouredUserID;
			
				item.CreatedOn = varCreatedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UserFavouriteID = @"UserFavouriteID";
			 public static string UserID = @"UserID";
			 public static string FavouredUserID = @"FavouredUserID";
			 public static string CreatedOn = @"CreatedOn";
						
		}

		#endregion
	}

}

