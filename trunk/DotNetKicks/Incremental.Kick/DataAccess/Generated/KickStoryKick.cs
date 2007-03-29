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
/// Strongly-typed collection for the KickStoryKick class.
/// </summary>

[Serializable]
public partial class KickStoryKickCollection : ActiveList<KickStoryKick> 
{
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
	
    public KickStoryKickCollection OrderByAsc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
	
    public KickStoryKickCollection OrderByDesc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }

	public KickStoryKickCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        return this;
    }

    public KickStoryKickCollection Where(Where where) 
	{
        wheres.Add(where);
        return this;
    }
	
    public KickStoryKickCollection Where(string columnName, object value) 
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
	
    public KickStoryKickCollection Where(string columnName, Comparison comp, object value) 
	{
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
	
    public KickStoryKickCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
	
    public KickStoryKickCollection Load() 
	{
		Query qry = new Query(KickStoryKick.Schema);
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
    public KickStoryKickCollection() 
	{
        

    }
}

/// <summary>
/// This is an ActiveRecord class which wraps the Kick_StoryKick table.
/// </summary>
[Serializable]
public partial class KickStoryKick : ActiveRecord<KickStoryKick> 
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
		BaseSchema = new TableSchema.Table("Kick_StoryKick", DataService.GetInstance("TempGJ"));
		TableSchema.TableColumnCollection columns = new TableSchema.TableColumnCollection();
		BaseSchema.Name = "Kick_StoryKick";
		BaseSchema.SchemaName = "dbo";

		TableSchema.TableColumn colvarStoryKickID = new TableSchema.TableColumn(BaseSchema);
		colvarStoryKickID.ColumnName = "StoryKickID";
		colvarStoryKickID.DataType = DbType.Int32;
		colvarStoryKickID.MaxLength = 0;
		colvarStoryKickID.AutoIncrement = true;
		colvarStoryKickID.IsNullable = false;
		colvarStoryKickID.IsPrimaryKey = true;
		colvarStoryKickID.IsForeignKey = false;
		colvarStoryKickID.IsReadOnly = false;
		columns.Add(colvarStoryKickID);

		TableSchema.TableColumn colvarStoryID = new TableSchema.TableColumn(BaseSchema);
		colvarStoryID.ColumnName = "StoryID";
		colvarStoryID.DataType = DbType.Int32;
		colvarStoryID.MaxLength = 0;
		colvarStoryID.AutoIncrement = false;
		colvarStoryID.IsNullable = false;
		colvarStoryID.IsPrimaryKey = false;
		colvarStoryID.IsForeignKey = true;
		colvarStoryID.IsReadOnly = false;
		columns.Add(colvarStoryID);

		TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(BaseSchema);
		colvarUserID.ColumnName = "UserID";
		colvarUserID.DataType = DbType.Int32;
		colvarUserID.MaxLength = 0;
		colvarUserID.AutoIncrement = false;
		colvarUserID.IsNullable = false;
		colvarUserID.IsPrimaryKey = false;
		colvarUserID.IsForeignKey = true;
		colvarUserID.IsReadOnly = false;
		columns.Add(colvarUserID);

		TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(BaseSchema);
		colvarHostID.ColumnName = "HostID";
		colvarHostID.DataType = DbType.Int32;
		colvarHostID.MaxLength = 0;
		colvarHostID.AutoIncrement = false;
		colvarHostID.IsNullable = false;
		colvarHostID.IsPrimaryKey = false;
		colvarHostID.IsForeignKey = false;
		colvarHostID.IsReadOnly = false;
		columns.Add(colvarHostID);

		TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(BaseSchema);
		colvarCreatedOn.ColumnName = "CreatedOn";
		colvarCreatedOn.DataType = DbType.DateTime;
		colvarCreatedOn.MaxLength = 0;
		colvarCreatedOn.AutoIncrement = false;
		colvarCreatedOn.IsNullable = false;
		colvarCreatedOn.IsPrimaryKey = false;
		colvarCreatedOn.IsForeignKey = false;
		colvarCreatedOn.IsReadOnly = false;
		columns.Add(colvarCreatedOn);

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
	public KickStoryKick()
	{
        SetSQLProps();
        SetDefaults();
        MarkNew();
    }

	public KickStoryKick(object keyID)
	{
		SetSQLProps();
		LoadByKey(keyID);
	}
	 
	public KickStoryKick(string columnName, object columnValue)
    {
        SetSQLProps();
        LoadByParam(columnName,columnValue);
    }
    
	#endregion

	#region Public Properties
	    [XmlAttribute("StoryKickID")]
    public int StoryKickID 
	{
		get
		{
			return GetColumnValue<int>("StoryKickID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("StoryKickID", value);

        }
    }
    [XmlAttribute("StoryID")]
    public int StoryID 
	{
		get
		{
			return GetColumnValue<int>("StoryID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("StoryID", value);

        }
    }
    [XmlAttribute("UserID")]
    public int UserID 
	{
		get
		{
			return GetColumnValue<int>("UserID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("UserID", value);

        }
    }
    [XmlAttribute("HostID")]
    public int HostID 
	{
		get
		{
			return GetColumnValue<int>("HostID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("HostID", value);

        }
    }
    [XmlAttribute("CreatedOn")]
    public DateTime CreatedOn 
	{
		get
		{
			return GetColumnValue<DateTime>("CreatedOn");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("CreatedOn", value);

        }
    }

	#endregion

	#region Public Methods
	
	
	#endregion

	#region ObjectDataSource support
	
	/// <summary>
	/// Inserts a record, can be used with the Object Data Source
	/// </summary>
	public static void Insert(int varStoryID, int varUserID, int varHostID)
	{
		KickStoryKick item = new KickStoryKick();
		item.StoryID = varStoryID;
		item.UserID = varUserID;
		item.HostID = varHostID;
		if (System.Web.HttpContext.Current != null)
			item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		else
			item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	}

	
	/// <summary>
	/// Updates a record, can be used with the Object Data Source
	/// </summary>
	public static void Update(int varStoryKickID, int varStoryID, int varUserID, int varHostID)
	{
		KickStoryKick item = new KickStoryKick();
		item.StoryKickID = varStoryKickID;
		item.StoryID = varStoryID;
		item.UserID = varUserID;
		item.HostID = varHostID;
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
		public static string StoryKickID = @"StoryKickID";
		public static string StoryID = @"StoryID";
		public static string UserID = @"UserID";
		public static string HostID = @"HostID";
		public static string CreatedOn = @"CreatedOn";

	}
	#endregion

}
}


