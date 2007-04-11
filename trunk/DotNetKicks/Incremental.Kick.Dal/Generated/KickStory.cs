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


//Generated on 11/04/2007 12:11:19 by gjoyce

namespace Incremental.Kick.Dal{
    /// <summary>
    /// Strongly-typed collection for the KickStory class.
    /// </summary>
    [Serializable]
    public partial class KickStoryCollection : ActiveList<KickStory> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
        public KickStoryCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

        public KickStoryCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public KickStoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return this;
        }

        public KickStoryCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

        public KickStoryCollection Where(string columnName, object value) 
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

        public KickStoryCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

        public KickStoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

        public KickStoryCollection Load() 
        {
            Query qry = new Query(KickStory.Schema);
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

        public KickStoryCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Kick_Story table.
    /// </summary>
    [Serializable]
    public partial class KickStory : ActiveRecord<KickStory>
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
                schema.Name = "Kick_Story";
                schema.SchemaName = "dbo";
                //columns
                TableSchema.TableColumn colvarStoryID = new TableSchema.TableColumn(schema);
                colvarStoryID.ColumnName = "StoryID";
                colvarStoryID.DataType = DbType.Int32;
                colvarStoryID.MaxLength = 0;
                colvarStoryID.AutoIncrement = true;
                colvarStoryID.IsNullable = false;
                colvarStoryID.IsPrimaryKey = true;
                colvarStoryID.IsForeignKey = false;
                colvarStoryID.IsReadOnly = false;
                schema.Columns.Add(colvarStoryID);
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
                TableSchema.TableColumn colvarStoryIdentifier = new TableSchema.TableColumn(schema);
                colvarStoryIdentifier.ColumnName = "StoryIdentifier";
                colvarStoryIdentifier.DataType = DbType.String;
                colvarStoryIdentifier.MaxLength = 255;
                colvarStoryIdentifier.AutoIncrement = false;
                colvarStoryIdentifier.IsNullable = false;
                colvarStoryIdentifier.IsPrimaryKey = false;
                colvarStoryIdentifier.IsForeignKey = false;
                colvarStoryIdentifier.IsReadOnly = false;
                schema.Columns.Add(colvarStoryIdentifier);
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 255;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = false;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                schema.Columns.Add(colvarTitle);
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
                TableSchema.TableColumn colvarUrl = new TableSchema.TableColumn(schema);
                colvarUrl.ColumnName = "Url";
                colvarUrl.DataType = DbType.String;
                colvarUrl.MaxLength = 1000;
                colvarUrl.AutoIncrement = false;
                colvarUrl.IsNullable = false;
                colvarUrl.IsPrimaryKey = false;
                colvarUrl.IsForeignKey = false;
                colvarUrl.IsReadOnly = false;
                schema.Columns.Add(colvarUrl);
                TableSchema.TableColumn colvarCategoryID = new TableSchema.TableColumn(schema);
                colvarCategoryID.ColumnName = "CategoryID";
                colvarCategoryID.DataType = DbType.Int16;
                colvarCategoryID.MaxLength = 0;
                colvarCategoryID.AutoIncrement = false;
                colvarCategoryID.IsNullable = false;
                colvarCategoryID.IsPrimaryKey = false;
                colvarCategoryID.IsForeignKey = true;
                colvarCategoryID.IsReadOnly = false;
				colvarCategoryID.ForeignKeyTableName = "Kick_Category";
                schema.Columns.Add(colvarCategoryID);
                TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
                colvarUserID.ColumnName = "UserID";
                colvarUserID.DataType = DbType.Int32;
                colvarUserID.MaxLength = 0;
                colvarUserID.AutoIncrement = false;
                colvarUserID.IsNullable = false;
                colvarUserID.IsPrimaryKey = false;
                colvarUserID.IsForeignKey = true;
                colvarUserID.IsReadOnly = false;
				colvarUserID.ForeignKeyTableName = "Kick_User";
                schema.Columns.Add(colvarUserID);
                TableSchema.TableColumn colvarUsername = new TableSchema.TableColumn(schema);
                colvarUsername.ColumnName = "Username";
                colvarUsername.DataType = DbType.String;
                colvarUsername.MaxLength = 50;
                colvarUsername.AutoIncrement = false;
                colvarUsername.IsNullable = false;
                colvarUsername.IsPrimaryKey = false;
                colvarUsername.IsForeignKey = false;
                colvarUsername.IsReadOnly = false;
                schema.Columns.Add(colvarUsername);
                TableSchema.TableColumn colvarKickCount = new TableSchema.TableColumn(schema);
                colvarKickCount.ColumnName = "KickCount";
                colvarKickCount.DataType = DbType.Int32;
                colvarKickCount.MaxLength = 0;
                colvarKickCount.AutoIncrement = false;
                colvarKickCount.IsNullable = false;
                colvarKickCount.IsPrimaryKey = false;
                colvarKickCount.IsForeignKey = false;
                colvarKickCount.IsReadOnly = false;
                schema.Columns.Add(colvarKickCount);
                TableSchema.TableColumn colvarSpamCount = new TableSchema.TableColumn(schema);
                colvarSpamCount.ColumnName = "SpamCount";
                colvarSpamCount.DataType = DbType.Int32;
                colvarSpamCount.MaxLength = 0;
                colvarSpamCount.AutoIncrement = false;
                colvarSpamCount.IsNullable = false;
                colvarSpamCount.IsPrimaryKey = false;
                colvarSpamCount.IsForeignKey = false;
                colvarSpamCount.IsReadOnly = false;
                schema.Columns.Add(colvarSpamCount);
                TableSchema.TableColumn colvarViewCount = new TableSchema.TableColumn(schema);
                colvarViewCount.ColumnName = "ViewCount";
                colvarViewCount.DataType = DbType.Int32;
                colvarViewCount.MaxLength = 0;
                colvarViewCount.AutoIncrement = false;
                colvarViewCount.IsNullable = false;
                colvarViewCount.IsPrimaryKey = false;
                colvarViewCount.IsForeignKey = false;
                colvarViewCount.IsReadOnly = false;
                schema.Columns.Add(colvarViewCount);
                TableSchema.TableColumn colvarCommentCount = new TableSchema.TableColumn(schema);
                colvarCommentCount.ColumnName = "CommentCount";
                colvarCommentCount.DataType = DbType.Int32;
                colvarCommentCount.MaxLength = 0;
                colvarCommentCount.AutoIncrement = false;
                colvarCommentCount.IsNullable = false;
                colvarCommentCount.IsPrimaryKey = false;
                colvarCommentCount.IsForeignKey = false;
                colvarCommentCount.IsReadOnly = false;
                schema.Columns.Add(colvarCommentCount);
                TableSchema.TableColumn colvarIsPublished = new TableSchema.TableColumn(schema);
                colvarIsPublished.ColumnName = "IsPublished";
                colvarIsPublished.DataType = DbType.Boolean;
                colvarIsPublished.MaxLength = 0;
                colvarIsPublished.AutoIncrement = false;
                colvarIsPublished.IsNullable = false;
                colvarIsPublished.IsPrimaryKey = false;
                colvarIsPublished.IsForeignKey = false;
                colvarIsPublished.IsReadOnly = false;
                schema.Columns.Add(colvarIsPublished);
                TableSchema.TableColumn colvarIsSpam = new TableSchema.TableColumn(schema);
                colvarIsSpam.ColumnName = "IsSpam";
                colvarIsSpam.DataType = DbType.Boolean;
                colvarIsSpam.MaxLength = 0;
                colvarIsSpam.AutoIncrement = false;
                colvarIsSpam.IsNullable = false;
                colvarIsSpam.IsPrimaryKey = false;
                colvarIsSpam.IsForeignKey = false;
                colvarIsSpam.IsReadOnly = false;
                schema.Columns.Add(colvarIsSpam);
                TableSchema.TableColumn colvarAdsenseID = new TableSchema.TableColumn(schema);
                colvarAdsenseID.ColumnName = "AdsenseID";
                colvarAdsenseID.DataType = DbType.String;
                colvarAdsenseID.MaxLength = 30;
                colvarAdsenseID.AutoIncrement = false;
                colvarAdsenseID.IsNullable = false;
                colvarAdsenseID.IsPrimaryKey = false;
                colvarAdsenseID.IsForeignKey = false;
                colvarAdsenseID.IsReadOnly = false;
                schema.Columns.Add(colvarAdsenseID);
                TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
                colvarCreatedOn.ColumnName = "CreatedOn";
                colvarCreatedOn.DataType = DbType.DateTime;
                colvarCreatedOn.MaxLength = 0;
                colvarCreatedOn.AutoIncrement = false;
                colvarCreatedOn.IsNullable = false;
                colvarCreatedOn.IsPrimaryKey = false;
                colvarCreatedOn.IsForeignKey = false;
                colvarCreatedOn.IsReadOnly = false;
                schema.Columns.Add(colvarCreatedOn);
                TableSchema.TableColumn colvarPublishedOn = new TableSchema.TableColumn(schema);
                colvarPublishedOn.ColumnName = "PublishedOn";
                colvarPublishedOn.DataType = DbType.DateTime;
                colvarPublishedOn.MaxLength = 0;
                colvarPublishedOn.AutoIncrement = false;
                colvarPublishedOn.IsNullable = true;
                colvarPublishedOn.IsPrimaryKey = false;
                colvarPublishedOn.IsForeignKey = false;
                colvarPublishedOn.IsReadOnly = false;
                schema.Columns.Add(colvarPublishedOn);
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["DotNetKicks"].AddSchema("Kick_Story",schema);
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
	    public KickStory()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public KickStory(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

	    public KickStory(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

	    #endregion
	    #region Props
        [XmlAttribute("StoryID")]
        public int StoryID 
	    {
		    get { return GetColumnValue<int>("StoryID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("StoryID", value);
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

        [XmlAttribute("StoryIdentifier")]
        public string StoryIdentifier 
	    {
		    get { return GetColumnValue<string>("StoryIdentifier"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("StoryIdentifier", value);
            }

        }

        [XmlAttribute("Title")]
        public string Title 
	    {
		    get { return GetColumnValue<string>("Title"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Title", value);
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

        [XmlAttribute("Url")]
        public string Url 
	    {
		    get { return GetColumnValue<string>("Url"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Url", value);
            }

        }

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

        [XmlAttribute("UserID")]
        public int UserID 
	    {
		    get { return GetColumnValue<int>("UserID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UserID", value);
            }

        }

        [XmlAttribute("Username")]
        public string Username 
	    {
		    get { return GetColumnValue<string>("Username"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Username", value);
            }

        }

        [XmlAttribute("KickCount")]
        public int KickCount 
	    {
		    get { return GetColumnValue<int>("KickCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("KickCount", value);
            }

        }

        [XmlAttribute("SpamCount")]
        public int SpamCount 
	    {
		    get { return GetColumnValue<int>("SpamCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SpamCount", value);
            }

        }

        [XmlAttribute("ViewCount")]
        public int ViewCount 
	    {
		    get { return GetColumnValue<int>("ViewCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ViewCount", value);
            }

        }

        [XmlAttribute("CommentCount")]
        public int CommentCount 
	    {
		    get { return GetColumnValue<int>("CommentCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CommentCount", value);
            }

        }

        [XmlAttribute("IsPublished")]
        public bool IsPublished 
	    {
		    get { return GetColumnValue<bool>("IsPublished"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("IsPublished", value);
            }

        }

        [XmlAttribute("IsSpam")]
        public bool IsSpam 
	    {
		    get { return GetColumnValue<bool>("IsSpam"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("IsSpam", value);
            }

        }

        [XmlAttribute("AdsenseID")]
        public string AdsenseID 
	    {
		    get { return GetColumnValue<string>("AdsenseID"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("AdsenseID", value);
            }

        }

        [XmlAttribute("CreatedOn")]
        public DateTime CreatedOn 
	    {
		    get { return GetColumnValue<DateTime>("CreatedOn"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CreatedOn", value);
            }

        }

        [XmlAttribute("PublishedOn")]
        public DateTime? PublishedOn 
	    {
		    get { return GetColumnValue<DateTime?>("PublishedOn"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishedOn", value);
            }

        }

	    #endregion
			#region PrimaryKey Methods
				public KickCommentCollection KickCommentRecords()
				{
					return new KickCommentCollection().Where(KickComment.Columns.StoryID, StoryID).Load();
				}

				public KickStoryKickCollection KickStoryKickRecords()
				{
					return new KickStoryKickCollection().Where(KickStoryKick.Columns.StoryID, StoryID).Load();
				}

				public KickStoryUserHostTagCollection KickStoryUserHostTagRecords()
				{
					return new KickStoryUserHostTagCollection().Where(KickStoryUserHostTag.Columns.StoryID, StoryID).Load();
				}

			#endregion
	    #region ForeignKey Methods
        /// <summary>
        /// Returns a KickCategory ActiveRecord object related to this KickStory
        /// </summary>
	    public KickCategory KickCategory
        {
	        get { return KickCategory.FetchByID(this.CategoryID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("CategoryID", value.CategoryID);
	        }

        }

        /// <summary>
        /// Returns a KickHost ActiveRecord object related to this KickStory
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

        /// <summary>
        /// Returns a KickUser ActiveRecord object related to this KickStory
        /// </summary>
	    public KickUser KickUser
        {
	        get { return KickUser.FetchByID(this.UserID); }

	        set
	        {
		        MarkDirty();
		        SetColumnValue("UserID", value.UserID);
	        }

        }

	    #endregion
	    //no ManyToMany tables defined (0)
	    #region ObjectDataSource support
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(int varHostID,string varStoryIdentifier,string varTitle,string varDescription,string varUrl,short varCategoryID,int varUserID,string varUsername,int varKickCount,int varSpamCount,int varViewCount,int varCommentCount,bool varIsPublished,bool varIsSpam,string varAdsenseID,DateTime varCreatedOn,DateTime? varPublishedOn)
	    {
		    KickStory item = new KickStory();
            item.HostID = varHostID;
            item.StoryIdentifier = varStoryIdentifier;
            item.Title = varTitle;
            item.Description = varDescription;
            item.Url = varUrl;
            item.CategoryID = varCategoryID;
            item.UserID = varUserID;
            item.Username = varUsername;
            item.KickCount = varKickCount;
            item.SpamCount = varSpamCount;
            item.ViewCount = varViewCount;
            item.CommentCount = varCommentCount;
            item.IsPublished = varIsPublished;
            item.IsSpam = varIsSpam;
            item.AdsenseID = varAdsenseID;
            item.CreatedOn = varCreatedOn;
            item.PublishedOn = varPublishedOn;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varStoryID,int varHostID,string varStoryIdentifier,string varTitle,string varDescription,string varUrl,short varCategoryID,int varUserID,string varUsername,int varKickCount,int varSpamCount,int varViewCount,int varCommentCount,bool varIsPublished,bool varIsSpam,string varAdsenseID,DateTime varCreatedOn,DateTime? varPublishedOn)
	    {
		    KickStory item = new KickStory();
                item.StoryID = varStoryID;
                item.HostID = varHostID;
                item.StoryIdentifier = varStoryIdentifier;
                item.Title = varTitle;
                item.Description = varDescription;
                item.Url = varUrl;
                item.CategoryID = varCategoryID;
                item.UserID = varUserID;
                item.Username = varUsername;
                item.KickCount = varKickCount;
                item.SpamCount = varSpamCount;
                item.ViewCount = varViewCount;
                item.CommentCount = varCommentCount;
                item.IsPublished = varIsPublished;
                item.IsSpam = varIsSpam;
                item.AdsenseID = varAdsenseID;
                item.CreatedOn = varCreatedOn;
                item.PublishedOn = varPublishedOn;
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
            public static string StoryID = @"StoryID";
            public static string HostID = @"HostID";
            public static string StoryIdentifier = @"StoryIdentifier";
            public static string Title = @"Title";
            public static string Description = @"Description";
            public static string Url = @"Url";
            public static string CategoryID = @"CategoryID";
            public static string UserID = @"UserID";
            public static string Username = @"Username";
            public static string KickCount = @"KickCount";
            public static string SpamCount = @"SpamCount";
            public static string ViewCount = @"ViewCount";
            public static string CommentCount = @"CommentCount";
            public static string IsPublished = @"IsPublished";
            public static string IsSpam = @"IsSpam";
            public static string AdsenseID = @"AdsenseID";
            public static string CreatedOn = @"CreatedOn";
            public static string PublishedOn = @"PublishedOn";
	    }

	    #endregion
    }

}
