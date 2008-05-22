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
	/// Strongly-typed collection for the Setting class.
	/// </summary>
	[Serializable]
	public partial class SettingCollection : ActiveList<Setting, SettingCollection> 
	{	   
		public SettingCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Setting table.
	/// </summary>
	[Serializable]
	public partial class Setting : ActiveRecord<Setting>
	{
		#region .ctors and Default Settings
		
		public Setting()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Setting(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Setting(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Setting(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Setting", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSettingID = new TableSchema.TableColumn(schema);
				colvarSettingID.ColumnName = "SettingID";
				colvarSettingID.DataType = DbType.Int32;
				colvarSettingID.MaxLength = 0;
				colvarSettingID.AutoIncrement = true;
				colvarSettingID.IsNullable = false;
				colvarSettingID.IsPrimaryKey = true;
				colvarSettingID.IsForeignKey = false;
				colvarSettingID.IsReadOnly = false;
				colvarSettingID.DefaultSetting = @"";
				colvarSettingID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSettingID);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 255;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarValueX = new TableSchema.TableColumn(schema);
				colvarValueX.ColumnName = "Value";
				colvarValueX.DataType = DbType.String;
				colvarValueX.MaxLength = 2147483647;
				colvarValueX.AutoIncrement = false;
				colvarValueX.IsNullable = false;
				colvarValueX.IsPrimaryKey = false;
				colvarValueX.IsForeignKey = false;
				colvarValueX.IsReadOnly = false;
				colvarValueX.DefaultSetting = @"";
				colvarValueX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarValueX);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Setting",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SettingID")]
		public int SettingID 
		{
			get { return GetColumnValue<int>(Columns.SettingID); }

			set { SetColumnValue(Columns.SettingID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("ValueX")]
		public string ValueX 
		{
			get { return GetColumnValue<string>(Columns.ValueX); }

			set { SetColumnValue(Columns.ValueX, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varValueX)
		{
			Setting item = new Setting();
			
			item.Name = varName;
			
			item.ValueX = varValueX;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSettingID,string varName,string varValueX)
		{
			Setting item = new Setting();
			
				item.SettingID = varSettingID;
			
				item.Name = varName;
			
				item.ValueX = varValueX;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn SettingIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn NameColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn ValueXColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SettingID = @"SettingID";
			 public static string Name = @"Name";
			 public static string ValueX = @"Value";
						
		}

		#endregion
	}

}

