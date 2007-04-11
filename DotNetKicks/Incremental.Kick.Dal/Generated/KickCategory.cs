using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;


//Generated on 11/04/2007 12:11:18 by gjoyce

namespace Incremental.Kick.Dal{
    /// <summary>
    /// Strongly-typed collection for the KickCategory class.
    /// </summary>
    [Serializable]
    public partial class KickCategoryCollection : ActiveList<KickCategory> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
        public KickCategoryCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

        public KickCategoryCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public KickCategoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return this;
        }

        public KickCategoryCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

        public KickCategoryCollection Where(string columnName, object value) 
	    {
		    if(value != DBNull.Value && value != null)
		    {	
			    return Where(columnName, Comparison.Equals, value);
		    }

		    else
		    {
			    return Where(columnName, Comparison.Is, DBNull.Value);
		    }

        }

        public KickCategoryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

        public KickCategoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            between.StartParameterName = "start" + columnName; 
            between.EndParameterName = "end" + columnName; 
            betweens.Add(between);
            return this;
        }

        public KickCategoryCollection Load() 
        {
            Query qry = new Query(KickCategory.Schema);
            CheckLogicalDelete(qry);
            foreach (Where where in wheres) 
            {
                qry.AddWhere(where);
            }

            foreach (BetweenAnd between in betweens)
            {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
            {
                qry.OrderBy = orderBy;
            }

            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }

        public KickCategoryCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Kick_Category table.
    /// </summary>
    [Serializable]
    public partial class KickCategory : ActiveRecord<KickCategory>
    {
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

        private static void GetTableSchema() 
	    {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
				TableSchema.Table schema = new TableSchema.Table(DataService.GetInstance("DotNetKicks"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.Name = "Kick_Category";
                schema.SchemaName = "dbo";
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
                schema.Columns.Add(colvarDescription);
                TableSchema.TableColumn colvarOrderPriority = new TableSchema.TableColumn(schema);
                colvarOrderPriority.ColumnName = "OrderPriority";
                colvarOrderPriority.DataType = DbType.Int16;
                colvarOrderPriority.MaxLength = 0;
                colvarOrderPriority.AutoIncrement = false;
                colvarOrderPriority.IsNullable = false;
                colvarOrderPriority.IsPrimaryKey = false;
                colvarOrderPriority.IsForeignKey = false;
                colvarOrderPriority.IsReadOnly = false;
                schema.Columns.Add(colvarOrderPriority);
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["DotNetKicks"].AddSchema("Kick_Category",schema);
            }

        }

        #endregion
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    #region .ctors
	    public KickCategory()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public KickCategory(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

	    public KickCategory(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

	    #endregion
	    #region Props
        [XmlAttribute("CategoryID")]
        public short CategoryID 
	    {
		    get { return GetColumnValue<short>("CategoryID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryID", value);
            }

        }

        [XmlAttribute("HostID")]
        public int HostID 
	    {
		    get { return GetColumnValue<int>("HostID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("HostID", value);
            }

        }

        [XmlAttribute("CategoryIdentifier")]
        public string CategoryIdentifier 
	    {
		    get { return GetColumnValue<string>("CategoryIdentifier"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CategoryIdentifier", value);
            }

        }

        [XmlAttribute("Name")]
        public string Name 
	    {
		    get { return GetColumnValue<string>("Name"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Name", value);
            }

        }

        [XmlAttribute("Description")]
        public string Description 
	    {
		    get { return GetColumnValue<string>("Description"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Description", value);
            }

        }

        [XmlAttribute("OrderPriority")]
        public short OrderPriority 
	    {
		    get { return GetColumnValue<short>("OrderPriority"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("OrderPriority", value);
            }

        }

	    #endregion
			#region PrimaryKey Methods
				public KickStoryCollection KickStoryRecords()
				{
					return new KickStoryCollection().Where(KickStory.Columns.CategoryID, CategoryID).Load();
				}

			#endregion
	    #region ForeignKey Methods
        /// <summary>
        /// Returns a KickHost ActiveRecord object related to this KickCategory
        /// </summary>
	    public KickHost KickHost
        {
	        get { return KickHost.FetchByID(this.HostID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("HostID", value.HostID);
	        }

        }

	    #endregion
	    //no ManyToMany tables defined (0)
	    #region ObjectDataSource support
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(int varHostID,string varCategoryIdentifier,string varName,string varDescription,short varOrderPriority)
	    {
		    KickCategory item = new KickCategory();
            item.HostID = varHostID;
            item.CategoryIdentifier = varCategoryIdentifier;
            item.Name = varName;
            item.Description = varDescription;
            item.OrderPriority = varOrderPriority;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(short varCategoryID,int varHostID,string varCategoryIdentifier,string varName,string varDescription,short varOrderPriority)
	    {
		    KickCategory item = new KickCategory();
                item.CategoryID = varCategoryID;
                item.HostID = varHostID;
                item.CategoryIdentifier = varCategoryIdentifier;
                item.Name = varName;
                item.Description = varDescription;
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
            public static string OrderPriority = @"OrderPriority";
	    }

	    #endregion
    }

}