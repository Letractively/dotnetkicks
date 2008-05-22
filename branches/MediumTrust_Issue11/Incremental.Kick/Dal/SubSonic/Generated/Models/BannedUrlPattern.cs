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
	/// Strongly-typed collection for the BannedUrlPattern class.
	/// </summary>
	[Serializable]
	public partial class BannedUrlPatternCollection : ActiveList<BannedUrlPattern, BannedUrlPatternCollection> 
	{	   
		public BannedUrlPatternCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_BannedUrlPattern table.
	/// </summary>
	[Serializable]
	public partial class BannedUrlPattern : ActiveRecord<BannedUrlPattern>
	{
		#region .ctors and Default Settings
		
		public BannedUrlPattern()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public BannedUrlPattern(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public BannedUrlPattern(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public BannedUrlPattern(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_BannedUrlPattern", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPatternId = new TableSchema.TableColumn(schema);
				colvarPatternId.ColumnName = "PatternId";
				colvarPatternId.DataType = DbType.Int32;
				colvarPatternId.MaxLength = 0;
				colvarPatternId.AutoIncrement = true;
				colvarPatternId.IsNullable = false;
				colvarPatternId.IsPrimaryKey = true;
				colvarPatternId.IsForeignKey = false;
				colvarPatternId.IsReadOnly = false;
				colvarPatternId.DefaultSetting = @"";
				colvarPatternId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPatternId);
				
				TableSchema.TableColumn colvarHostId = new TableSchema.TableColumn(schema);
				colvarHostId.ColumnName = "HostId";
				colvarHostId.DataType = DbType.Int32;
				colvarHostId.MaxLength = 0;
				colvarHostId.AutoIncrement = false;
				colvarHostId.IsNullable = true;
				colvarHostId.IsPrimaryKey = false;
				colvarHostId.IsForeignKey = true;
				colvarHostId.IsReadOnly = false;
				colvarHostId.DefaultSetting = @"";
				
					colvarHostId.ForeignKeyTableName = "Kick_Host";
				schema.Columns.Add(colvarHostId);
				
				TableSchema.TableColumn colvarDescription = new TableSchema.TableColumn(schema);
				colvarDescription.ColumnName = "Description";
				colvarDescription.DataType = DbType.String;
				colvarDescription.MaxLength = 100;
				colvarDescription.AutoIncrement = false;
				colvarDescription.IsNullable = false;
				colvarDescription.IsPrimaryKey = false;
				colvarDescription.IsForeignKey = false;
				colvarDescription.IsReadOnly = false;
				
						colvarDescription.DefaultSetting = @"(N'(No description given)')";
				colvarDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDescription);
				
				TableSchema.TableColumn colvarBannedUrlRegex = new TableSchema.TableColumn(schema);
				colvarBannedUrlRegex.ColumnName = "BannedUrlRegex";
				colvarBannedUrlRegex.DataType = DbType.String;
				colvarBannedUrlRegex.MaxLength = 100;
				colvarBannedUrlRegex.AutoIncrement = false;
				colvarBannedUrlRegex.IsNullable = false;
				colvarBannedUrlRegex.IsPrimaryKey = false;
				colvarBannedUrlRegex.IsForeignKey = false;
				colvarBannedUrlRegex.IsReadOnly = false;
				colvarBannedUrlRegex.DefaultSetting = @"";
				colvarBannedUrlRegex.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBannedUrlRegex);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_BannedUrlPattern",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("PatternId")]
		public int PatternId 
		{
			get { return GetColumnValue<int>(Columns.PatternId); }

			set { SetColumnValue(Columns.PatternId, value); }

		}

		  
		[XmlAttribute("HostId")]
		public int? HostId 
		{
			get { return GetColumnValue<int?>(Columns.HostId); }

			set { SetColumnValue(Columns.HostId, value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }

			set { SetColumnValue(Columns.Description, value); }

		}

		  
		[XmlAttribute("BannedUrlRegex")]
		public string BannedUrlRegex 
		{
			get { return GetColumnValue<string>(Columns.BannedUrlRegex); }

			set { SetColumnValue(Columns.BannedUrlRegex, value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Host ActiveRecord object related to this BannedUrlPattern
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Host Host
		{
			get { return Incremental.Kick.Dal.Host.FetchByID(this.HostId); }

			set { SetColumnValue("HostId", value.HostID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int? varHostId,string varDescription,string varBannedUrlRegex)
		{
			BannedUrlPattern item = new BannedUrlPattern();
			
			item.HostId = varHostId;
			
			item.Description = varDescription;
			
			item.BannedUrlRegex = varBannedUrlRegex;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varPatternId,int? varHostId,string varDescription,string varBannedUrlRegex)
		{
			BannedUrlPattern item = new BannedUrlPattern();
			
				item.PatternId = varPatternId;
			
				item.HostId = varHostId;
			
				item.Description = varDescription;
			
				item.BannedUrlRegex = varBannedUrlRegex;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PatternIdColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn HostIdColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn BannedUrlRegexColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PatternId = @"PatternId";
			 public static string HostId = @"HostId";
			 public static string Description = @"Description";
			 public static string BannedUrlRegex = @"BannedUrlRegex";
						
		}

		#endregion
	}

}

