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
	/// Strongly-typed collection for the Tag class.
	/// </summary>
	[Serializable]
	public partial class TagCollection : ActiveList<Tag, TagCollection> 
	{	   
		public TagCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Tag table.
	/// </summary>
	[Serializable]
	public partial class Tag : ActiveRecord<Tag>
	{
		#region .ctors and Default Settings
		
		public Tag()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Tag(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Tag(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Tag(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Tag", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarTagID = new TableSchema.TableColumn(schema);
				colvarTagID.ColumnName = "TagID";
				colvarTagID.DataType = DbType.Int32;
				colvarTagID.MaxLength = 0;
				colvarTagID.AutoIncrement = true;
				colvarTagID.IsNullable = false;
				colvarTagID.IsPrimaryKey = true;
				colvarTagID.IsForeignKey = false;
				colvarTagID.IsReadOnly = false;
				colvarTagID.DefaultSetting = @"";
				colvarTagID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTagID);
				
				TableSchema.TableColumn colvarTagIdentifier = new TableSchema.TableColumn(schema);
				colvarTagIdentifier.ColumnName = "TagIdentifier";
				colvarTagIdentifier.DataType = DbType.String;
				colvarTagIdentifier.MaxLength = 60;
				colvarTagIdentifier.AutoIncrement = false;
				colvarTagIdentifier.IsNullable = false;
				colvarTagIdentifier.IsPrimaryKey = false;
				colvarTagIdentifier.IsForeignKey = false;
				colvarTagIdentifier.IsReadOnly = false;
				colvarTagIdentifier.DefaultSetting = @"";
				colvarTagIdentifier.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTagIdentifier);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Tag",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("TagID")]
		public int TagID 
		{
			get { return GetColumnValue<int>(Columns.TagID); }

			set { SetColumnValue(Columns.TagID, value); }

		}

		  
		[XmlAttribute("TagIdentifier")]
		public string TagIdentifier 
		{
			get { return GetColumnValue<string>(Columns.TagIdentifier); }

			set { SetColumnValue(Columns.TagIdentifier, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.StoryUserHostTagCollection colStoryUserHostTagRecords;
		public Incremental.Kick.Dal.StoryUserHostTagCollection StoryUserHostTagRecords()
		{
			if(colStoryUserHostTagRecords == null)
				colStoryUserHostTagRecords = new Incremental.Kick.Dal.StoryUserHostTagCollection().Where(StoryUserHostTag.Columns.TagID, TagID).Load();
			return colStoryUserHostTagRecords;
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTagIdentifier)
		{
			Tag item = new Tag();
			
			item.TagIdentifier = varTagIdentifier;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varTagID,string varTagIdentifier)
		{
			Tag item = new Tag();
			
				item.TagID = varTagID;
			
				item.TagIdentifier = varTagIdentifier;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn TagIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn TagIdentifierColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string TagID = @"TagID";
			 public static string TagIdentifier = @"TagIdentifier";
						
		}

		#endregion
	}

}

