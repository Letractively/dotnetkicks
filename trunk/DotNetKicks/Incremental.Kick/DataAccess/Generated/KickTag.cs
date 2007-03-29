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


namespace Incremental.Kick.DataAccess
{
/// <summary>
/// Strongly-typed collection for the KickTag class.
/// </summary>

[Serializable]
public partial class KickTagCollection : ActiveList<KickTag> 
{
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
	
    public KickTagCollection OrderByAsc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
	
    public KickTagCollection OrderByDesc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }

	public KickTagCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        return this;
    }

    public KickTagCollection Where(Where where) 
	{
        wheres.Add(where);
        return this;
    }
	
    public KickTagCollection Where(string columnName, object value) 
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
	
    public KickTagCollection Where(string columnName, Comparison comp, object value) 
	{
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
	
    public KickTagCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
	
    public KickTagCollection Load() 
	{
		Query qry = new Query(KickTag.Schema);
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
    public KickTagCollection() 
	{
        

    }
}

/// <summary>
/// This is an ActiveRecord class which wraps the Kick_Tag table.
/// </summary>
[Serializable]
public partial class KickTag : ActiveRecord<KickTag> 
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
		BaseSchema = new TableSchema.Table("Kick_Tag", DataService.GetInstance("TempGJ"));
		TableSchema.TableColumnCollection columns = new TableSchema.TableColumnCollection();
		BaseSchema.Name = "Kick_Tag";
		BaseSchema.SchemaName = "dbo";

		TableSchema.TableColumn colvarTagID = new TableSchema.TableColumn(BaseSchema);
		colvarTagID.ColumnName = "TagID";
		colvarTagID.DataType = DbType.Int32;
		colvarTagID.MaxLength = 0;
		colvarTagID.AutoIncrement = true;
		colvarTagID.IsNullable = false;
		colvarTagID.IsPrimaryKey = true;
		colvarTagID.IsForeignKey = false;
		colvarTagID.IsReadOnly = false;
		columns.Add(colvarTagID);

		TableSchema.TableColumn colvarTagIdentifier = new TableSchema.TableColumn(BaseSchema);
		colvarTagIdentifier.ColumnName = "TagIdentifier";
		colvarTagIdentifier.DataType = DbType.String;
		colvarTagIdentifier.MaxLength = 60;
		colvarTagIdentifier.AutoIncrement = false;
		colvarTagIdentifier.IsNullable = false;
		colvarTagIdentifier.IsPrimaryKey = false;
		colvarTagIdentifier.IsForeignKey = false;
		colvarTagIdentifier.IsReadOnly = false;
		columns.Add(colvarTagIdentifier);

		BaseSchema.Columns = columns;

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
	public KickTag()
	{
        SetSQLProps();
        SetDefaults();
        MarkNew();
    }

	public KickTag(object keyID)
	{
		SetSQLProps();
		LoadByKey(keyID);
	}
	 
	public KickTag(string columnName, object columnValue)
    {
        SetSQLProps();
        LoadByParam(columnName,columnValue);
    }
    
	#endregion

	#region Public Properties
	    [XmlAttribute("TagID")]
    public int TagID 
	{
		get
		{
			return GetColumnValue<int>("TagID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("TagID", value);

        }
    }
    [XmlAttribute("TagIdentifier")]
    public string TagIdentifier 
	{
		get
		{
			return GetColumnValue<string>("TagIdentifier");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("TagIdentifier", value);

        }
    }

	#endregion

	#region Public Methods
	
	
	#endregion

	#region ObjectDataSource support
	
	/// <summary>
	/// Inserts a record, can be used with the Object Data Source
	/// </summary>
	public static void Insert(string varTagIdentifier)
	{
		KickTag item = new KickTag();
		item.TagIdentifier = varTagIdentifier;
		if (System.Web.HttpContext.Current != null)
			item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		else
			item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	}

	
	/// <summary>
	/// Updates a record, can be used with the Object Data Source
	/// </summary>
	public static void Update(int varTagID, string varTagIdentifier)
	{
		KickTag item = new KickTag();
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


