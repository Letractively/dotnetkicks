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
	/// Strongly-typed collection for the Category class.
	/// </summary>
	[Serializable]
	public partial class CategoryCollection : ActiveList<Category, CategoryCollection> 
	{	   
		public CategoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Category table.
	/// </summary>
	[Serializable]
	public partial class Category : ActiveRecord<Category>
	{
		#region .ctors and Default Settings
		
		public Category()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Category(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Category(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Category(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Category", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
				colvarCategoryID.ColumnName = "CategoryID";
				colvarCategoryID.DataType = DbType.Int16;
				colvarCategoryID.MaxLength = 0;
				colvarCategoryID.AutoIncrement = true;
				colvarCategoryID.IsNullable = false;
				colvarCategoryID.IsPrimaryKey = true;
				colvarCategoryID.IsForeignKey = false;
				colvarCategoryID.IsReadOnly = false;
				colvarCategoryID.DefaultSetting = @"";
				colvarCategoryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryID);
				
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
				
				TableSchema.TableColumn colvarCategoryIdentifier = new TableSchema.TableColumn(schema);
				colvarCategoryIdentifier.ColumnName = "CategoryIdentifier";
				colvarCategoryIdentifier.DataType = DbType.String;
				colvarCategoryIdentifier.MaxLength = 50;
				colvarCategoryIdentifier.AutoIncrement = false;
				colvarCategoryIdentifier.IsNullable = false;
				colvarCategoryIdentifier.IsPrimaryKey = false;
				colvarCategoryIdentifier.IsForeignKey = false;
				colvarCategoryIdentifier.IsReadOnly = false;
				colvarCategoryIdentifier.DefaultSetting = @"";
				colvarCategoryIdentifier.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCategoryIdentifier);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 4000;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarIconName = new TableSchema.TableColumn(schema);
				colvarIconName.ColumnName = "IconName";
				colvarIconName.DataType = DbType.String;
				colvarIconName.MaxLength = 50;
				colvarIconName.AutoIncrement = false;
				colvarIconName.IsNullable = true;
				colvarIconName.IsPrimaryKey = false;
				colvarIconName.IsForeignKey = false;
				colvarIconName.IsReadOnly = false;
				colvarIconName.DefaultSetting = @"";
				colvarIconName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIconName);
				
				TableSchema.TableColumn colvarOrderPriority = new TableSchema.TableColumn(schema);
				colvarOrderPriority.ColumnName = "OrderPriority";
				colvarOrderPriority.DataType = DbType.Int16;
				colvarOrderPriority.MaxLength = 0;
				colvarOrderPriority.AutoIncrement = false;
				colvarOrderPriority.IsNullable = false;
				colvarOrderPriority.IsPrimaryKey = false;
				colvarOrderPriority.IsForeignKey = false;
				colvarOrderPriority.IsReadOnly = false;
				
						colvarOrderPriority.DefaultSetting = @"((100))";
				colvarOrderPriority.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOrderPriority);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Category",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CategoryID")]
		public short CategoryID 
		{
			get { return GetColumnValue<short>(Columns.CategoryID); }

			set { SetColumnValue(Columns.CategoryID, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("CategoryIdentifier")]
		public string CategoryIdentifier 
		{
			get { return GetColumnValue<string>(Columns.CategoryIdentifier); }

			set { SetColumnValue(Columns.CategoryIdentifier, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }

			set { SetColumnValue(Columns.Description, value); }

		}

		  
		[XmlAttribute("IconName")]
		public string IconName 
		{
			get { return GetColumnValue<string>(Columns.IconName); }

			set { SetColumnValue(Columns.IconName, value); }

		}

		  
		[XmlAttribute("OrderPriority")]
		public short OrderPriority 
		{
			get { return GetColumnValue<short>(Columns.OrderPriority); }

			set { SetColumnValue(Columns.OrderPriority, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.StoryCollection colStoryRecords;
		public Incremental.Kick.Dal.StoryCollection StoryRecords()
		{
			if(colStoryRecords == null)
				colStoryRecords = new Incremental.Kick.Dal.StoryCollection().Where(Story.Columns.CategoryID, CategoryID).Load();
			return colStoryRecords;
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Host ActiveRecord object related to this Category
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Host Host
		{
			get { return Incremental.Kick.Dal.Host.FetchByID(this.HostID); }

			set { SetColumnValue("HostID", value.HostID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varHostID,string varCategoryIdentifier,string varName,string varDescription,string varIconName,short varOrderPriority)
		{
			Category item = new Category();
			
			item.HostID = varHostID;
			
			item.CategoryIdentifier = varCategoryIdentifier;
			
			item.Name = varName;
			
			item.Description = varDescription;
			
			item.IconName = varIconName;
			
			item.OrderPriority = varOrderPriority;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(short varCategoryID,int varHostID,string varCategoryIdentifier,string varName,string varDescription,string varIconName,short varOrderPriority)
		{
			Category item = new Category();
			
				item.CategoryID = varCategoryID;
			
				item.HostID = varHostID;
			
				item.CategoryIdentifier = varCategoryIdentifier;
			
				item.Name = varName;
			
				item.Description = varDescription;
			
				item.IconName = varIconName;
			
				item.OrderPriority = varOrderPriority;
			
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
			 public static string CategoryID = @"CategoryID";
			 public static string HostID = @"HostID";
			 public static string CategoryIdentifier = @"CategoryIdentifier";
			 public static string Name = @"Name";
			 public static string Description = @"Description";
			 public static string IconName = @"IconName";
			 public static string OrderPriority = @"OrderPriority";
						
		}

		#endregion
	}

}

