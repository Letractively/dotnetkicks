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
	/// Strongly-typed collection for the ReservedUsername class.
	/// </summary>
	[Serializable]
	public partial class ReservedUsernameCollection : ActiveList<ReservedUsername, ReservedUsernameCollection> 
	{	   
		public ReservedUsernameCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_ReservedUsername table.
	/// </summary>
	[Serializable]
	public partial class ReservedUsername : ActiveRecord<ReservedUsername>
	{
		#region .ctors and Default Settings
		
		public ReservedUsername()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ReservedUsername(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ReservedUsername(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ReservedUsername(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_ReservedUsername", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUsernameID = new TableSchema.TableColumn(schema);
				colvarUsernameID.ColumnName = "UsernameID";
				colvarUsernameID.DataType = DbType.Int32;
				colvarUsernameID.MaxLength = 0;
				colvarUsernameID.AutoIncrement = true;
				colvarUsernameID.IsNullable = false;
				colvarUsernameID.IsPrimaryKey = true;
				colvarUsernameID.IsForeignKey = false;
				colvarUsernameID.IsReadOnly = false;
				colvarUsernameID.DefaultSetting = @"";
				colvarUsernameID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsernameID);
				
				TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
				colvarUsername.ColumnName = "Username";
				colvarUsername.DataType = DbType.String;
				colvarUsername.MaxLength = 50;
				colvarUsername.AutoIncrement = false;
				colvarUsername.IsNullable = false;
				colvarUsername.IsPrimaryKey = false;
				colvarUsername.IsForeignKey = false;
				colvarUsername.IsReadOnly = false;
				colvarUsername.DefaultSetting = @"";
				colvarUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsername);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_ReservedUsername",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UsernameID")]
		public int UsernameID 
		{
			get { return GetColumnValue<int>(Columns.UsernameID); }

			set { SetColumnValue(Columns.UsernameID, value); }

		}

		  
		[XmlAttribute("Username")]
		public string Username 
		{
			get { return GetColumnValue<string>(Columns.Username); }

			set { SetColumnValue(Columns.Username, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUsername)
		{
			ReservedUsername item = new ReservedUsername();
			
			item.Username = varUsername;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUsernameID,string varUsername)
		{
			ReservedUsername item = new ReservedUsername();
			
				item.UsernameID = varUsernameID;
			
				item.Username = varUsername;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn UsernameIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn UsernameColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string UsernameID = @"UsernameID";
			 public static string Username = @"Username";
						
		}

		#endregion
	}

}

