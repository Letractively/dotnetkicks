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
	/// Strongly-typed collection for the BlockedReferral class.
	/// </summary>
	[Serializable]
	public partial class BlockedReferralCollection : ActiveList<BlockedReferral, BlockedReferralCollection> 
	{	   
		public BlockedReferralCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_BlockedReferral table.
	/// </summary>
	[Serializable]
	public partial class BlockedReferral : ActiveRecord<BlockedReferral>
	{
		#region .ctors and Default Settings
		
		public BlockedReferral()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BlockedReferral(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BlockedReferral(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public BlockedReferral(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_BlockedReferral", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarBlockedReferralID = new TableSchema.TableColumn(schema);
				colvarBlockedReferralID.ColumnName = "BlockedReferralID";
				colvarBlockedReferralID.DataType = DbType.Int16;
				colvarBlockedReferralID.MaxLength = 0;
				colvarBlockedReferralID.AutoIncrement = true;
				colvarBlockedReferralID.IsNullable = false;
				colvarBlockedReferralID.IsPrimaryKey = true;
				colvarBlockedReferralID.IsForeignKey = false;
				colvarBlockedReferralID.IsReadOnly = false;
				colvarBlockedReferralID.DefaultSetting = @"";
				colvarBlockedReferralID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBlockedReferralID);
				
				TableSchema.TableColumn colvarBlockedReferralHostname = new TableSchema.TableColumn(schema);
				colvarBlockedReferralHostname.ColumnName = "BlockedReferralHostname";
				colvarBlockedReferralHostname.DataType = DbType.String;
				colvarBlockedReferralHostname.MaxLength = 50;
				colvarBlockedReferralHostname.AutoIncrement = false;
				colvarBlockedReferralHostname.IsNullable = false;
				colvarBlockedReferralHostname.IsPrimaryKey = false;
				colvarBlockedReferralHostname.IsForeignKey = false;
				colvarBlockedReferralHostname.IsReadOnly = false;
				colvarBlockedReferralHostname.DefaultSetting = @"";
				colvarBlockedReferralHostname.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBlockedReferralHostname);
				
				TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(schema);
				colvarHostID.ColumnName = "HostID";
				colvarHostID.DataType = DbType.Int32;
				colvarHostID.MaxLength = 0;
				colvarHostID.AutoIncrement = false;
				colvarHostID.IsNullable = true;
				colvarHostID.IsPrimaryKey = false;
				colvarHostID.IsForeignKey = false;
				colvarHostID.IsReadOnly = false;
				colvarHostID.DefaultSetting = @"";
				colvarHostID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostID);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_BlockedReferral",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("BlockedReferralID")]
		public short BlockedReferralID 
		{
			get { return GetColumnValue<short>(Columns.BlockedReferralID); }

			set { SetColumnValue(Columns.BlockedReferralID, value); }

		}

		  
		[XmlAttribute("BlockedReferralHostname")]
		public string BlockedReferralHostname 
		{
			get { return GetColumnValue<string>(Columns.BlockedReferralHostname); }

			set { SetColumnValue(Columns.BlockedReferralHostname, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int? HostID 
		{
			get { return GetColumnValue<int?>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varBlockedReferralHostname,int? varHostID)
		{
			BlockedReferral item = new BlockedReferral();
			
			item.BlockedReferralHostname = varBlockedReferralHostname;
			
			item.HostID = varHostID;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(short varBlockedReferralID,string varBlockedReferralHostname,int? varHostID)
		{
			BlockedReferral item = new BlockedReferral();
			
				item.BlockedReferralID = varBlockedReferralID;
			
				item.BlockedReferralHostname = varBlockedReferralHostname;
			
				item.HostID = varHostID;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn BlockedReferralIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn BlockedReferralHostnameColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn HostIDColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string BlockedReferralID = @"BlockedReferralID";
			 public static string BlockedReferralHostname = @"BlockedReferralHostname";
			 public static string HostID = @"HostID";
						
		}

		#endregion
	}

}

