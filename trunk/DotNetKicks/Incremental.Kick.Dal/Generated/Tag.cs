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


//Generated on 25/04/2007 16:27:26 by gjoyce

namespace Incremental.Kick.Dal{
    /// <summary>
    /// Strongly-typed collection for the Tag class.
    /// </summary>
    [Serializable]
    public partial class TagCollection : ActiveList<Tag> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public TagCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public TagCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public TagCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return this;
        }

        public TagCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public TagCollection Where(string columnName, object value) 
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

    	
        public TagCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public TagCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public TagCollection Load() 
        {
            Query qry = new Query(Tag.Schema);
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

        
        public TagCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Kick_Tag table.
    /// </summary>
    [Serializable]
    public partial class Tag : ActiveRecord<Tag>
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Tag", TableType.Table, DataService.GetInstance("Kick"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "dbo";
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
                
                schema.Columns.Add(colvarTagIdentifier);
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Kick"].AddSchema("Kick_Tag",schema);
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
	    public Tag()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Tag(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Tag(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("TagID")]
        public int TagID 
	    {
		    get { return GetColumnValue<int>("TagID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TagID", value);
            }

        }

	      
        [XmlAttribute("TagIdentifier")]
        public string TagIdentifier 
	    {
		    get { return GetColumnValue<string>("TagIdentifier"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TagIdentifier", value);
            }

        }

	    
	    #endregion
	    
	    
	    #region PrimaryKey Methods
	    
		public Incremental.Kick.Dal.StoryUserHostTagCollection StoryUserHostTagRecords()
		{
			return new Incremental.Kick.Dal.StoryUserHostTagCollection().Where(StoryUserHostTag.Columns.TagID, TagID).Load();
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
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string TagID = @"TagID";
            
            public static string TagIdentifier = @"TagIdentifier";
            
	    }

	    #endregion
    }

}
