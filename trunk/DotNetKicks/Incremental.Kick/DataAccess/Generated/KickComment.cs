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
/// Strongly-typed collection for the KickComment class.
/// </summary>

[Serializable]
public partial class KickCommentCollection : ActiveList<KickComment> 
{
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
	
    public KickCommentCollection OrderByAsc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
	
    public KickCommentCollection OrderByDesc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }

	public KickCommentCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        return this;
    }

    public KickCommentCollection Where(Where where) 
	{
        wheres.Add(where);
        return this;
    }
	
    public KickCommentCollection Where(string columnName, object value) 
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
	
    public KickCommentCollection Where(string columnName, Comparison comp, object value) 
	{
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
	
    public KickCommentCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
	
    public KickCommentCollection Load() 
	{
		Query qry = new Query(KickComment.Schema);
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
    public KickCommentCollection() 
	{
        

    }
}

/// <summary>
/// This is an ActiveRecord class which wraps the Kick_Comment table.
/// </summary>
[Serializable]
public partial class KickComment : ActiveRecord<KickComment> 
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
		BaseSchema = new TableSchema.Table("Kick_Comment", DataService.GetInstance("TempGJ"));
		TableSchema.TableColumnCollection columns = new TableSchema.TableColumnCollection();
		BaseSchema.Name = "Kick_Comment";
		BaseSchema.SchemaName = "dbo";

		TableSchema.TableColumn colvarCommentID = new TableSchema.TableColumn(BaseSchema);
		colvarCommentID.ColumnName = "CommentID";
		colvarCommentID.DataType = DbType.Int32;
		colvarCommentID.MaxLength = 0;
		colvarCommentID.AutoIncrement = true;
		colvarCommentID.IsNullable = false;
		colvarCommentID.IsPrimaryKey = true;
		colvarCommentID.IsForeignKey = false;
		colvarCommentID.IsReadOnly = false;
		columns.Add(colvarCommentID);

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

		TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(BaseSchema);
		colvarUsername.ColumnName = "Username";
		colvarUsername.DataType = DbType.String;
		colvarUsername.MaxLength = 50;
		colvarUsername.AutoIncrement = false;
		colvarUsername.IsNullable = false;
		colvarUsername.IsPrimaryKey = false;
		colvarUsername.IsForeignKey = false;
		colvarUsername.IsReadOnly = false;
		columns.Add(colvarUsername);

		TableSchema.TableColumn colvarComment = new TableSchema.TableColumn(BaseSchema);
		colvarComment.ColumnName = "Comment";
		colvarComment.DataType = DbType.String;
		colvarComment.MaxLength = 4000;
		colvarComment.AutoIncrement = false;
		colvarComment.IsNullable = false;
		colvarComment.IsPrimaryKey = false;
		colvarComment.IsForeignKey = false;
		colvarComment.IsReadOnly = false;
		columns.Add(colvarComment);

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
	public KickComment()
	{
        SetSQLProps();
        SetDefaults();
        MarkNew();
    }

	public KickComment(object keyID)
	{
		SetSQLProps();
		LoadByKey(keyID);
	}
	 
	public KickComment(string columnName, object columnValue)
    {
        SetSQLProps();
        LoadByParam(columnName,columnValue);
    }
    
	#endregion

	#region Public Properties
	    [XmlAttribute("CommentID")]
    public int CommentID 
	{
		get
		{
			return GetColumnValue<int>("CommentID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("CommentID", value);

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
    [XmlAttribute("Username")]
    public string Username 
	{
		get
		{
			return GetColumnValue<string>("Username");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("Username", value);

        }
    }
    [XmlAttribute("Comment")]
    public string Comment 
	{
		get
		{
			return GetColumnValue<string>("Comment");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("Comment", value);

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
	public static void Insert(int varStoryID, int varUserID, string varUsername, string varComment)
	{
		KickComment item = new KickComment();
		item.StoryID = varStoryID;
		item.UserID = varUserID;
		item.Username = varUsername;
		item.Comment = varComment;
		if (System.Web.HttpContext.Current != null)
			item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		else
			item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	}

	
	/// <summary>
	/// Updates a record, can be used with the Object Data Source
	/// </summary>
	public static void Update(int varCommentID, int varStoryID, int varUserID, string varUsername, string varComment)
	{
		KickComment item = new KickComment();
		item.CommentID = varCommentID;
		item.StoryID = varStoryID;
		item.UserID = varUserID;
		item.Username = varUsername;
		item.Comment = varComment;
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
		public static string CommentID = @"CommentID";
		public static string StoryID = @"StoryID";
		public static string UserID = @"UserID";
		public static string Username = @"Username";
		public static string Comment = @"Comment";
		public static string CreatedOn = @"CreatedOn";

	}
	#endregion

}
}


