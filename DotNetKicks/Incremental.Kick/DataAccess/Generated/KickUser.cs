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
/// Strongly-typed collection for the KickUser class.
/// </summary>

[Serializable]
public partial class KickUserCollection : ActiveList<KickUser> 
{
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
	
    public KickUserCollection OrderByAsc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
	
    public KickUserCollection OrderByDesc(string columnName) 
	{
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }

	public KickUserCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        return this;
    }

    public KickUserCollection Where(Where where) 
	{
        wheres.Add(where);
        return this;
    }
	
    public KickUserCollection Where(string columnName, object value) 
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
	
    public KickUserCollection Where(string columnName, Comparison comp, object value) 
	{
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
	
    public KickUserCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
	{
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
	
    public KickUserCollection Load() 
	{
		Query qry = new Query(KickUser.Schema);
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
    public KickUserCollection() 
	{
        

    }
}

/// <summary>
/// This is an ActiveRecord class which wraps the Kick_User table.
/// </summary>
[Serializable]
public partial class KickUser : ActiveRecord<KickUser> 
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
		BaseSchema = new TableSchema.Table("Kick_User", DataService.GetInstance("TempGJ"));
		TableSchema.TableColumnCollection columns = new TableSchema.TableColumnCollection();
		BaseSchema.Name = "Kick_User";
		BaseSchema.SchemaName = "dbo";

		TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(BaseSchema);
		colvarUserID.ColumnName = "UserID";
		colvarUserID.DataType = DbType.Int32;
		colvarUserID.MaxLength = 0;
		colvarUserID.AutoIncrement = true;
		colvarUserID.IsNullable = false;
		colvarUserID.IsPrimaryKey = true;
		colvarUserID.IsForeignKey = false;
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

		TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(BaseSchema);
		colvarEmail.ColumnName = "Email";
		colvarEmail.DataType = DbType.String;
		colvarEmail.MaxLength = 255;
		colvarEmail.AutoIncrement = false;
		colvarEmail.IsNullable = false;
		colvarEmail.IsPrimaryKey = false;
		colvarEmail.IsForeignKey = false;
		colvarEmail.IsReadOnly = false;
		columns.Add(colvarEmail);

		TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(BaseSchema);
		colvarPassword.ColumnName = "Password";
		colvarPassword.DataType = DbType.String;
		colvarPassword.MaxLength = 50;
		colvarPassword.AutoIncrement = false;
		colvarPassword.IsNullable = false;
		colvarPassword.IsPrimaryKey = false;
		colvarPassword.IsForeignKey = false;
		colvarPassword.IsReadOnly = false;
		columns.Add(colvarPassword);

		TableSchema.TableColumn colvarPasswordSalt = new TableSchema.TableColumn(BaseSchema);
		colvarPasswordSalt.ColumnName = "PasswordSalt";
		colvarPasswordSalt.DataType = DbType.String;
		colvarPasswordSalt.MaxLength = 50;
		colvarPasswordSalt.AutoIncrement = false;
		colvarPasswordSalt.IsNullable = false;
		colvarPasswordSalt.IsPrimaryKey = false;
		colvarPasswordSalt.IsForeignKey = false;
		colvarPasswordSalt.IsReadOnly = false;
		columns.Add(colvarPasswordSalt);

		TableSchema.TableColumn colvarIsGeneratedPassword = new TableSchema.TableColumn(BaseSchema);
		colvarIsGeneratedPassword.ColumnName = "IsGeneratedPassword";
		colvarIsGeneratedPassword.DataType = DbType.Boolean;
		colvarIsGeneratedPassword.MaxLength = 0;
		colvarIsGeneratedPassword.AutoIncrement = false;
		colvarIsGeneratedPassword.IsNullable = false;
		colvarIsGeneratedPassword.IsPrimaryKey = false;
		colvarIsGeneratedPassword.IsForeignKey = false;
		colvarIsGeneratedPassword.IsReadOnly = false;
		columns.Add(colvarIsGeneratedPassword);

		TableSchema.TableColumn colvarIsValidated = new TableSchema.TableColumn(BaseSchema);
		colvarIsValidated.ColumnName = "IsValidated";
		colvarIsValidated.DataType = DbType.Boolean;
		colvarIsValidated.MaxLength = 0;
		colvarIsValidated.AutoIncrement = false;
		colvarIsValidated.IsNullable = false;
		colvarIsValidated.IsPrimaryKey = false;
		colvarIsValidated.IsForeignKey = false;
		colvarIsValidated.IsReadOnly = false;
		columns.Add(colvarIsValidated);

		TableSchema.TableColumn colvarIsBanned = new TableSchema.TableColumn(BaseSchema);
		colvarIsBanned.ColumnName = "IsBanned";
		colvarIsBanned.DataType = DbType.Boolean;
		colvarIsBanned.MaxLength = 0;
		colvarIsBanned.AutoIncrement = false;
		colvarIsBanned.IsNullable = false;
		colvarIsBanned.IsPrimaryKey = false;
		colvarIsBanned.IsForeignKey = false;
		colvarIsBanned.IsReadOnly = false;
		columns.Add(colvarIsBanned);

		TableSchema.TableColumn colvarAdsenseID = new TableSchema.TableColumn(BaseSchema);
		colvarAdsenseID.ColumnName = "AdsenseID";
		colvarAdsenseID.DataType = DbType.String;
		colvarAdsenseID.MaxLength = 30;
		colvarAdsenseID.AutoIncrement = false;
		colvarAdsenseID.IsNullable = false;
		colvarAdsenseID.IsPrimaryKey = false;
		colvarAdsenseID.IsForeignKey = false;
		colvarAdsenseID.IsReadOnly = false;
		columns.Add(colvarAdsenseID);

		TableSchema.TableColumn colvarReceiveEmailNewsletter = new TableSchema.TableColumn(BaseSchema);
		colvarReceiveEmailNewsletter.ColumnName = "ReceiveEmailNewsletter";
		colvarReceiveEmailNewsletter.DataType = DbType.Boolean;
		colvarReceiveEmailNewsletter.MaxLength = 0;
		colvarReceiveEmailNewsletter.AutoIncrement = false;
		colvarReceiveEmailNewsletter.IsNullable = false;
		colvarReceiveEmailNewsletter.IsPrimaryKey = false;
		colvarReceiveEmailNewsletter.IsForeignKey = false;
		colvarReceiveEmailNewsletter.IsReadOnly = false;
		columns.Add(colvarReceiveEmailNewsletter);

		TableSchema.TableColumn colvarRoles = new TableSchema.TableColumn(BaseSchema);
		colvarRoles.ColumnName = "Roles";
		colvarRoles.DataType = DbType.String;
		colvarRoles.MaxLength = 100;
		colvarRoles.AutoIncrement = false;
		colvarRoles.IsNullable = false;
		colvarRoles.IsPrimaryKey = false;
		colvarRoles.IsForeignKey = false;
		colvarRoles.IsReadOnly = false;
		columns.Add(colvarRoles);

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

		TableSchema.TableColumn colvarLastActiveOn = new TableSchema.TableColumn(BaseSchema);
		colvarLastActiveOn.ColumnName = "LastActiveOn";
		colvarLastActiveOn.DataType = DbType.DateTime;
		colvarLastActiveOn.MaxLength = 0;
		colvarLastActiveOn.AutoIncrement = false;
		colvarLastActiveOn.IsNullable = false;
		colvarLastActiveOn.IsPrimaryKey = false;
		colvarLastActiveOn.IsForeignKey = false;
		colvarLastActiveOn.IsReadOnly = false;
		columns.Add(colvarLastActiveOn);

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

		TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(BaseSchema);
		colvarModifiedOn.ColumnName = "ModifiedOn";
		colvarModifiedOn.DataType = DbType.DateTime;
		colvarModifiedOn.MaxLength = 0;
		colvarModifiedOn.AutoIncrement = false;
		colvarModifiedOn.IsNullable = false;
		colvarModifiedOn.IsPrimaryKey = false;
		colvarModifiedOn.IsForeignKey = false;
		colvarModifiedOn.IsReadOnly = false;
		columns.Add(colvarModifiedOn);

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
	public KickUser()
	{
        SetSQLProps();
        SetDefaults();
        MarkNew();
    }

	public KickUser(object keyID)
	{
		SetSQLProps();
		LoadByKey(keyID);
	}
	 
	public KickUser(string columnName, object columnValue)
    {
        SetSQLProps();
        LoadByParam(columnName,columnValue);
    }
    
	#endregion

	#region Public Properties
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
    [XmlAttribute("Email")]
    public string Email 
	{
		get
		{
			return GetColumnValue<string>("Email");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("Email", value);

        }
    }
    [XmlAttribute("Password")]
    public string Password 
	{
		get
		{
			return GetColumnValue<string>("Password");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("Password", value);

        }
    }
    [XmlAttribute("PasswordSalt")]
    public string PasswordSalt 
	{
		get
		{
			return GetColumnValue<string>("PasswordSalt");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("PasswordSalt", value);

        }
    }
    [XmlAttribute("IsGeneratedPassword")]
    public bool IsGeneratedPassword 
	{
		get
		{
			return GetColumnValue<bool>("IsGeneratedPassword");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("IsGeneratedPassword", value);

        }
    }
    [XmlAttribute("IsValidated")]
    public bool IsValidated 
	{
		get
		{
			return GetColumnValue<bool>("IsValidated");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("IsValidated", value);

        }
    }
    [XmlAttribute("IsBanned")]
    public bool IsBanned 
	{
		get
		{
			return GetColumnValue<bool>("IsBanned");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("IsBanned", value);

        }
    }
    [XmlAttribute("AdsenseID")]
    public string AdsenseID 
	{
		get
		{
			return GetColumnValue<string>("AdsenseID");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("AdsenseID", value);

        }
    }
    [XmlAttribute("ReceiveEmailNewsletter")]
    public bool ReceiveEmailNewsletter 
	{
		get
		{
			return GetColumnValue<bool>("ReceiveEmailNewsletter");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("ReceiveEmailNewsletter", value);

        }
    }
    [XmlAttribute("Roles")]
    public string Roles 
	{
		get
		{
			return GetColumnValue<string>("Roles");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("Roles", value);

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
    [XmlAttribute("LastActiveOn")]
    public DateTime LastActiveOn 
	{
		get
		{
			return GetColumnValue<DateTime>("LastActiveOn");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("LastActiveOn", value);

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
    [XmlAttribute("ModifiedOn")]
    public DateTime ModifiedOn 
	{
		get
		{
			return GetColumnValue<DateTime>("ModifiedOn");
		}
        set 
		{
			MarkDirty();
			SetColumnValue("ModifiedOn", value);

        }
    }

	#endregion

	#region Public Methods
	
	
	#endregion

	#region ObjectDataSource support
	
	/// <summary>
	/// Inserts a record, can be used with the Object Data Source
	/// </summary>
	public static void Insert(string varUsername, string varEmail, string varPassword, string varPasswordSalt, bool varIsGeneratedPassword, bool varIsValidated, bool varIsBanned, string varAdsenseID, bool varReceiveEmailNewsletter, string varRoles, int varHostID, DateTime varLastActiveOn)
	{
		KickUser item = new KickUser();
		item.Username = varUsername;
		item.Email = varEmail;
		item.Password = varPassword;
		item.PasswordSalt = varPasswordSalt;
		item.IsGeneratedPassword = varIsGeneratedPassword;
		item.IsValidated = varIsValidated;
		item.IsBanned = varIsBanned;
		item.AdsenseID = varAdsenseID;
		item.ReceiveEmailNewsletter = varReceiveEmailNewsletter;
		item.Roles = varRoles;
		item.HostID = varHostID;
		item.LastActiveOn = varLastActiveOn;
		if (System.Web.HttpContext.Current != null)
			item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		else
			item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	}

	
	/// <summary>
	/// Updates a record, can be used with the Object Data Source
	/// </summary>
	public static void Update(int varUserID, string varUsername, string varEmail, string varPassword, string varPasswordSalt, bool varIsGeneratedPassword, bool varIsValidated, bool varIsBanned, string varAdsenseID, bool varReceiveEmailNewsletter, string varRoles, int varHostID, DateTime varLastActiveOn)
	{
		KickUser item = new KickUser();
		item.UserID = varUserID;
		item.Username = varUsername;
		item.Email = varEmail;
		item.Password = varPassword;
		item.PasswordSalt = varPasswordSalt;
		item.IsGeneratedPassword = varIsGeneratedPassword;
		item.IsValidated = varIsValidated;
		item.IsBanned = varIsBanned;
		item.AdsenseID = varAdsenseID;
		item.ReceiveEmailNewsletter = varReceiveEmailNewsletter;
		item.Roles = varRoles;
		item.HostID = varHostID;
		item.LastActiveOn = varLastActiveOn;
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
		public static string UserID = @"UserID";
		public static string Username = @"Username";
		public static string Email = @"Email";
		public static string Password = @"Password";
		public static string PasswordSalt = @"PasswordSalt";
		public static string IsGeneratedPassword = @"IsGeneratedPassword";
		public static string IsValidated = @"IsValidated";
		public static string IsBanned = @"IsBanned";
		public static string AdsenseID = @"AdsenseID";
		public static string ReceiveEmailNewsletter = @"ReceiveEmailNewsletter";
		public static string Roles = @"Roles";
		public static string HostID = @"HostID";
		public static string LastActiveOn = @"LastActiveOn";
		public static string CreatedOn = @"CreatedOn";
		public static string ModifiedOn = @"ModifiedOn";

	}
	#endregion

}
}

