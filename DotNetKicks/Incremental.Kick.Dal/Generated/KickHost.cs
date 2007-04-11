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
    /// Strongly-typed collection for the KickHost class.
    /// </summary>
    [Serializable]
    public partial class KickHostCollection : ActiveList<KickHost> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
        public KickHostCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

        public KickHostCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public KickHostCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return this;
        }

        public KickHostCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

        public KickHostCollection Where(string columnName, object value) 
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

        public KickHostCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

        public KickHostCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

        public KickHostCollection Load() 
        {
            Query qry = new Query(KickHost.Schema);
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

        public KickHostCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Kick_Host table.
    /// </summary>
    [Serializable]
    public partial class KickHost : ActiveRecord<KickHost>
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
                schema.Name = "Kick_Host";
                schema.SchemaName = "dbo";
                //columns
                TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(schema);
                colvarHostID.ColumnName = "HostID";
                colvarHostID.DataType = DbType.Int32;
                colvarHostID.MaxLength = 0;
                colvarHostID.AutoIncrement = true;
                colvarHostID.IsNullable = false;
                colvarHostID.IsPrimaryKey = true;
                colvarHostID.IsForeignKey = false;
                colvarHostID.IsReadOnly = false;
                schema.Columns.Add(colvarHostID);
                TableSchema.TableColumn colvarHostName = new TableSchema.TableColumn(schema);
                colvarHostName.ColumnName = "HostName";
                colvarHostName.DataType = DbType.String;
                colvarHostName.MaxLength = 255;
                colvarHostName.AutoIncrement = false;
                colvarHostName.IsNullable = false;
                colvarHostName.IsPrimaryKey = false;
                colvarHostName.IsForeignKey = false;
                colvarHostName.IsReadOnly = false;
                schema.Columns.Add(colvarHostName);
                TableSchema.TableColumn colvarRootUrl = new TableSchema.TableColumn(schema);
                colvarRootUrl.ColumnName = "RootUrl";
                colvarRootUrl.DataType = DbType.String;
                colvarRootUrl.MaxLength = 50;
                colvarRootUrl.AutoIncrement = false;
                colvarRootUrl.IsNullable = false;
                colvarRootUrl.IsPrimaryKey = false;
                colvarRootUrl.IsForeignKey = false;
                colvarRootUrl.IsReadOnly = false;
                schema.Columns.Add(colvarRootUrl);
                TableSchema.TableColumn colvarSiteTitle = new TableSchema.TableColumn(schema);
                colvarSiteTitle.ColumnName = "SiteTitle";
                colvarSiteTitle.DataType = DbType.String;
                colvarSiteTitle.MaxLength = 255;
                colvarSiteTitle.AutoIncrement = false;
                colvarSiteTitle.IsNullable = false;
                colvarSiteTitle.IsPrimaryKey = false;
                colvarSiteTitle.IsForeignKey = false;
                colvarSiteTitle.IsReadOnly = false;
                schema.Columns.Add(colvarSiteTitle);
                TableSchema.TableColumn colvarSiteDescription = new TableSchema.TableColumn(schema);
                colvarSiteDescription.ColumnName = "SiteDescription";
                colvarSiteDescription.DataType = DbType.String;
                colvarSiteDescription.MaxLength = 2000;
                colvarSiteDescription.AutoIncrement = false;
                colvarSiteDescription.IsNullable = false;
                colvarSiteDescription.IsPrimaryKey = false;
                colvarSiteDescription.IsForeignKey = false;
                colvarSiteDescription.IsReadOnly = false;
                schema.Columns.Add(colvarSiteDescription);
                TableSchema.TableColumn colvarTagLine = new TableSchema.TableColumn(schema);
                colvarTagLine.ColumnName = "TagLine";
                colvarTagLine.DataType = DbType.String;
                colvarTagLine.MaxLength = 255;
                colvarTagLine.AutoIncrement = false;
                colvarTagLine.IsNullable = false;
                colvarTagLine.IsPrimaryKey = false;
                colvarTagLine.IsForeignKey = false;
                colvarTagLine.IsReadOnly = false;
                schema.Columns.Add(colvarTagLine);
                TableSchema.TableColumn colvarLogoPath = new TableSchema.TableColumn(schema);
                colvarLogoPath.ColumnName = "LogoPath";
                colvarLogoPath.DataType = DbType.String;
                colvarLogoPath.MaxLength = 255;
                colvarLogoPath.AutoIncrement = false;
                colvarLogoPath.IsNullable = false;
                colvarLogoPath.IsPrimaryKey = false;
                colvarLogoPath.IsForeignKey = false;
                colvarLogoPath.IsReadOnly = false;
                schema.Columns.Add(colvarLogoPath);
                TableSchema.TableColumn colvarCreatedDateTime = new TableSchema.TableColumn(schema);
                colvarCreatedDateTime.ColumnName = "CreatedDateTime";
                colvarCreatedDateTime.DataType = DbType.DateTime;
                colvarCreatedDateTime.MaxLength = 0;
                colvarCreatedDateTime.AutoIncrement = false;
                colvarCreatedDateTime.IsNullable = false;
                colvarCreatedDateTime.IsPrimaryKey = false;
                colvarCreatedDateTime.IsForeignKey = false;
                colvarCreatedDateTime.IsReadOnly = false;
                schema.Columns.Add(colvarCreatedDateTime);
                TableSchema.TableColumn colvarBlogUrl = new TableSchema.TableColumn(schema);
                colvarBlogUrl.ColumnName = "BlogUrl";
                colvarBlogUrl.DataType = DbType.String;
                colvarBlogUrl.MaxLength = 255;
                colvarBlogUrl.AutoIncrement = false;
                colvarBlogUrl.IsNullable = false;
                colvarBlogUrl.IsPrimaryKey = false;
                colvarBlogUrl.IsForeignKey = false;
                colvarBlogUrl.IsReadOnly = false;
                schema.Columns.Add(colvarBlogUrl);
                TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
                colvarEmail.ColumnName = "Email";
                colvarEmail.DataType = DbType.String;
                colvarEmail.MaxLength = 255;
                colvarEmail.AutoIncrement = false;
                colvarEmail.IsNullable = false;
                colvarEmail.IsPrimaryKey = false;
                colvarEmail.IsForeignKey = false;
                colvarEmail.IsReadOnly = false;
                schema.Columns.Add(colvarEmail);
                TableSchema.TableColumn colvarSkin = new TableSchema.TableColumn(schema);
                colvarSkin.ColumnName = "Skin";
                colvarSkin.DataType = DbType.String;
                colvarSkin.MaxLength = 50;
                colvarSkin.AutoIncrement = false;
                colvarSkin.IsNullable = false;
                colvarSkin.IsPrimaryKey = false;
                colvarSkin.IsForeignKey = false;
                colvarSkin.IsReadOnly = false;
                schema.Columns.Add(colvarSkin);
                TableSchema.TableColumn colvarTheme = new TableSchema.TableColumn(schema);
                colvarTheme.ColumnName = "Theme";
                colvarTheme.DataType = DbType.String;
                colvarTheme.MaxLength = 50;
                colvarTheme.AutoIncrement = false;
                colvarTheme.IsNullable = false;
                colvarTheme.IsPrimaryKey = false;
                colvarTheme.IsForeignKey = false;
                colvarTheme.IsReadOnly = false;
                schema.Columns.Add(colvarTheme);
                TableSchema.TableColumn colvarShowAds = new TableSchema.TableColumn(schema);
                colvarShowAds.ColumnName = "ShowAds";
                colvarShowAds.DataType = DbType.Boolean;
                colvarShowAds.MaxLength = 0;
                colvarShowAds.AutoIncrement = false;
                colvarShowAds.IsNullable = false;
                colvarShowAds.IsPrimaryKey = false;
                colvarShowAds.IsForeignKey = false;
                colvarShowAds.IsReadOnly = false;
                schema.Columns.Add(colvarShowAds);
                TableSchema.TableColumn colvarCulture = new TableSchema.TableColumn(schema);
                colvarCulture.ColumnName = "Culture";
                colvarCulture.DataType = DbType.String;
                colvarCulture.MaxLength = 50;
                colvarCulture.AutoIncrement = false;
                colvarCulture.IsNullable = false;
                colvarCulture.IsPrimaryKey = false;
                colvarCulture.IsForeignKey = false;
                colvarCulture.IsReadOnly = false;
                schema.Columns.Add(colvarCulture);
                TableSchema.TableColumn colvarUICulture = new TableSchema.TableColumn(schema);
                colvarUICulture.ColumnName = "UICulture";
                colvarUICulture.DataType = DbType.String;
                colvarUICulture.MaxLength = 50;
                colvarUICulture.AutoIncrement = false;
                colvarUICulture.IsNullable = false;
                colvarUICulture.IsPrimaryKey = false;
                colvarUICulture.IsForeignKey = false;
                colvarUICulture.IsReadOnly = false;
                schema.Columns.Add(colvarUICulture);
                TableSchema.TableColumn colvarPublishMinimumStoryAgeInHours = new TableSchema.TableColumn(schema);
                colvarPublishMinimumStoryAgeInHours.ColumnName = "Publish_MinimumStoryAgeInHours";
                colvarPublishMinimumStoryAgeInHours.DataType = DbType.Int16;
                colvarPublishMinimumStoryAgeInHours.MaxLength = 0;
                colvarPublishMinimumStoryAgeInHours.AutoIncrement = false;
                colvarPublishMinimumStoryAgeInHours.IsNullable = false;
                colvarPublishMinimumStoryAgeInHours.IsPrimaryKey = false;
                colvarPublishMinimumStoryAgeInHours.IsForeignKey = false;
                colvarPublishMinimumStoryAgeInHours.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimumStoryAgeInHours);
                TableSchema.TableColumn colvarPublishMaximumStoryAgeInHours = new TableSchema.TableColumn(schema);
                colvarPublishMaximumStoryAgeInHours.ColumnName = "Publish_MaximumStoryAgeInHours";
                colvarPublishMaximumStoryAgeInHours.DataType = DbType.Int16;
                colvarPublishMaximumStoryAgeInHours.MaxLength = 0;
                colvarPublishMaximumStoryAgeInHours.AutoIncrement = false;
                colvarPublishMaximumStoryAgeInHours.IsNullable = false;
                colvarPublishMaximumStoryAgeInHours.IsPrimaryKey = false;
                colvarPublishMaximumStoryAgeInHours.IsForeignKey = false;
                colvarPublishMaximumStoryAgeInHours.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMaximumStoryAgeInHours);
                TableSchema.TableColumn colvarPublishMaximumSimultaneousStoryPublishCount = new TableSchema.TableColumn(schema);
                colvarPublishMaximumSimultaneousStoryPublishCount.ColumnName = "Publish_MaximumSimultaneousStoryPublishCount";
                colvarPublishMaximumSimultaneousStoryPublishCount.DataType = DbType.Int16;
                colvarPublishMaximumSimultaneousStoryPublishCount.MaxLength = 0;
                colvarPublishMaximumSimultaneousStoryPublishCount.AutoIncrement = false;
                colvarPublishMaximumSimultaneousStoryPublishCount.IsNullable = false;
                colvarPublishMaximumSimultaneousStoryPublishCount.IsPrimaryKey = false;
                colvarPublishMaximumSimultaneousStoryPublishCount.IsForeignKey = false;
                colvarPublishMaximumSimultaneousStoryPublishCount.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMaximumSimultaneousStoryPublishCount);
                TableSchema.TableColumn colvarPublishMinimumStoryScore = new TableSchema.TableColumn(schema);
                colvarPublishMinimumStoryScore.ColumnName = "Publish_MinimumStoryScore";
                colvarPublishMinimumStoryScore.DataType = DbType.Int16;
                colvarPublishMinimumStoryScore.MaxLength = 0;
                colvarPublishMinimumStoryScore.AutoIncrement = false;
                colvarPublishMinimumStoryScore.IsNullable = false;
                colvarPublishMinimumStoryScore.IsPrimaryKey = false;
                colvarPublishMinimumStoryScore.IsForeignKey = false;
                colvarPublishMinimumStoryScore.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimumStoryScore);
                TableSchema.TableColumn colvarPublishMinimumStoryKickCount = new TableSchema.TableColumn(schema);
                colvarPublishMinimumStoryKickCount.ColumnName = "Publish_MinimumStoryKickCount";
                colvarPublishMinimumStoryKickCount.DataType = DbType.Int16;
                colvarPublishMinimumStoryKickCount.MaxLength = 0;
                colvarPublishMinimumStoryKickCount.AutoIncrement = false;
                colvarPublishMinimumStoryKickCount.IsNullable = false;
                colvarPublishMinimumStoryKickCount.IsPrimaryKey = false;
                colvarPublishMinimumStoryKickCount.IsForeignKey = false;
                colvarPublishMinimumStoryKickCount.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimumStoryKickCount);
                TableSchema.TableColumn colvarPublishMinimumStoryCommentCount = new TableSchema.TableColumn(schema);
                colvarPublishMinimumStoryCommentCount.ColumnName = "Publish_MinimumStoryCommentCount";
                colvarPublishMinimumStoryCommentCount.DataType = DbType.Int16;
                colvarPublishMinimumStoryCommentCount.MaxLength = 0;
                colvarPublishMinimumStoryCommentCount.AutoIncrement = false;
                colvarPublishMinimumStoryCommentCount.IsNullable = false;
                colvarPublishMinimumStoryCommentCount.IsPrimaryKey = false;
                colvarPublishMinimumStoryCommentCount.IsForeignKey = false;
                colvarPublishMinimumStoryCommentCount.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimumStoryCommentCount);
                TableSchema.TableColumn colvarPublishMinimumAverageStoryKicksPerHour = new TableSchema.TableColumn(schema);
                colvarPublishMinimumAverageStoryKicksPerHour.ColumnName = "Publish_MinimumAverageStoryKicksPerHour";
                colvarPublishMinimumAverageStoryKicksPerHour.DataType = DbType.Int16;
                colvarPublishMinimumAverageStoryKicksPerHour.MaxLength = 0;
                colvarPublishMinimumAverageStoryKicksPerHour.AutoIncrement = false;
                colvarPublishMinimumAverageStoryKicksPerHour.IsNullable = false;
                colvarPublishMinimumAverageStoryKicksPerHour.IsPrimaryKey = false;
                colvarPublishMinimumAverageStoryKicksPerHour.IsForeignKey = false;
                colvarPublishMinimumAverageStoryKicksPerHour.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimumAverageStoryKicksPerHour);
                TableSchema.TableColumn colvarPublishMinimunAverageCommentsPerHour = new TableSchema.TableColumn(schema);
                colvarPublishMinimunAverageCommentsPerHour.ColumnName = "Publish_MinimunAverageCommentsPerHour";
                colvarPublishMinimunAverageCommentsPerHour.DataType = DbType.Int16;
                colvarPublishMinimunAverageCommentsPerHour.MaxLength = 0;
                colvarPublishMinimunAverageCommentsPerHour.AutoIncrement = false;
                colvarPublishMinimunAverageCommentsPerHour.IsNullable = false;
                colvarPublishMinimunAverageCommentsPerHour.IsPrimaryKey = false;
                colvarPublishMinimunAverageCommentsPerHour.IsForeignKey = false;
                colvarPublishMinimunAverageCommentsPerHour.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimunAverageCommentsPerHour);
                TableSchema.TableColumn colvarPublishMinimumViewCount = new TableSchema.TableColumn(schema);
                colvarPublishMinimumViewCount.ColumnName = "Publish_MinimumViewCount";
                colvarPublishMinimumViewCount.DataType = DbType.Int16;
                colvarPublishMinimumViewCount.MaxLength = 0;
                colvarPublishMinimumViewCount.AutoIncrement = false;
                colvarPublishMinimumViewCount.IsNullable = false;
                colvarPublishMinimumViewCount.IsPrimaryKey = false;
                colvarPublishMinimumViewCount.IsForeignKey = false;
                colvarPublishMinimumViewCount.IsReadOnly = false;
                schema.Columns.Add(colvarPublishMinimumViewCount);
                TableSchema.TableColumn colvarPublishKickScore = new TableSchema.TableColumn(schema);
                colvarPublishKickScore.ColumnName = "Publish_KickScore";
                colvarPublishKickScore.DataType = DbType.Int16;
                colvarPublishKickScore.MaxLength = 0;
                colvarPublishKickScore.AutoIncrement = false;
                colvarPublishKickScore.IsNullable = false;
                colvarPublishKickScore.IsPrimaryKey = false;
                colvarPublishKickScore.IsForeignKey = false;
                colvarPublishKickScore.IsReadOnly = false;
                schema.Columns.Add(colvarPublishKickScore);
                TableSchema.TableColumn colvarPublishCommentScore = new TableSchema.TableColumn(schema);
                colvarPublishCommentScore.ColumnName = "Publish_CommentScore";
                colvarPublishCommentScore.DataType = DbType.Int16;
                colvarPublishCommentScore.MaxLength = 0;
                colvarPublishCommentScore.AutoIncrement = false;
                colvarPublishCommentScore.IsNullable = false;
                colvarPublishCommentScore.IsPrimaryKey = false;
                colvarPublishCommentScore.IsForeignKey = false;
                colvarPublishCommentScore.IsReadOnly = false;
                schema.Columns.Add(colvarPublishCommentScore);
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
                TableSchema.TableColumn colvarTrackingHtml = new TableSchema.TableColumn(schema);
                colvarTrackingHtml.ColumnName = "TrackingHtml";
                colvarTrackingHtml.DataType = DbType.String;
                colvarTrackingHtml.MaxLength = 2147483647;
                colvarTrackingHtml.AutoIncrement = false;
                colvarTrackingHtml.IsNullable = false;
                colvarTrackingHtml.IsPrimaryKey = false;
                colvarTrackingHtml.IsForeignKey = false;
                colvarTrackingHtml.IsReadOnly = false;
                schema.Columns.Add(colvarTrackingHtml);
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["DotNetKicks"].AddSchema("Kick_Host",schema);
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
	    public KickHost()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public KickHost(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

	    public KickHost(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

	    #endregion
	    #region Props
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

        [XmlAttribute("HostName")]
        public string HostName 
	    {
		    get { return GetColumnValue<string>("HostName"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("HostName", value);
            }

        }

        [XmlAttribute("RootUrl")]
        public string RootUrl 
	    {
		    get { return GetColumnValue<string>("RootUrl"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("RootUrl", value);
            }

        }

        [XmlAttribute("SiteTitle")]
        public string SiteTitle 
	    {
		    get { return GetColumnValue<string>("SiteTitle"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SiteTitle", value);
            }

        }

        [XmlAttribute("SiteDescription")]
        public string SiteDescription 
	    {
		    get { return GetColumnValue<string>("SiteDescription"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("SiteDescription", value);
            }

        }

        [XmlAttribute("TagLine")]
        public string TagLine 
	    {
		    get { return GetColumnValue<string>("TagLine"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TagLine", value);
            }

        }

        [XmlAttribute("LogoPath")]
        public string LogoPath 
	    {
		    get { return GetColumnValue<string>("LogoPath"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("LogoPath", value);
            }

        }

        [XmlAttribute("CreatedDateTime")]
        public DateTime CreatedDateTime 
	    {
		    get { return GetColumnValue<DateTime>("CreatedDateTime"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("CreatedDateTime", value);
            }

        }

        [XmlAttribute("BlogUrl")]
        public string BlogUrl 
	    {
		    get { return GetColumnValue<string>("BlogUrl"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("BlogUrl", value);
            }

        }

        [XmlAttribute("Email")]
        public string Email 
	    {
		    get { return GetColumnValue<string>("Email"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Email", value);
            }

        }

        [XmlAttribute("Skin")]
        public string Skin 
	    {
		    get { return GetColumnValue<string>("Skin"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Skin", value);
            }

        }

        [XmlAttribute("Theme")]
        public string Theme 
	    {
		    get { return GetColumnValue<string>("Theme"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Theme", value);
            }

        }

        [XmlAttribute("ShowAds")]
        public bool ShowAds 
	    {
		    get { return GetColumnValue<bool>("ShowAds"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("ShowAds", value);
            }

        }

        [XmlAttribute("Culture")]
        public string Culture 
	    {
		    get { return GetColumnValue<string>("Culture"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Culture", value);
            }

        }

        [XmlAttribute("UICulture")]
        public string UICulture 
	    {
		    get { return GetColumnValue<string>("UICulture"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("UICulture", value);
            }

        }

        [XmlAttribute("PublishMinimumStoryAgeInHours")]
        public short PublishMinimumStoryAgeInHours 
	    {
		    get { return GetColumnValue<short>("PublishMinimumStoryAgeInHours"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimumStoryAgeInHours", value);
            }

        }

        [XmlAttribute("PublishMaximumStoryAgeInHours")]
        public short PublishMaximumStoryAgeInHours 
	    {
		    get { return GetColumnValue<short>("PublishMaximumStoryAgeInHours"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMaximumStoryAgeInHours", value);
            }

        }

        [XmlAttribute("PublishMaximumSimultaneousStoryPublishCount")]
        public short PublishMaximumSimultaneousStoryPublishCount 
	    {
		    get { return GetColumnValue<short>("PublishMaximumSimultaneousStoryPublishCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMaximumSimultaneousStoryPublishCount", value);
            }

        }

        [XmlAttribute("PublishMinimumStoryScore")]
        public short PublishMinimumStoryScore 
	    {
		    get { return GetColumnValue<short>("PublishMinimumStoryScore"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimumStoryScore", value);
            }

        }

        [XmlAttribute("PublishMinimumStoryKickCount")]
        public short PublishMinimumStoryKickCount 
	    {
		    get { return GetColumnValue<short>("PublishMinimumStoryKickCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimumStoryKickCount", value);
            }

        }

        [XmlAttribute("PublishMinimumStoryCommentCount")]
        public short PublishMinimumStoryCommentCount 
	    {
		    get { return GetColumnValue<short>("PublishMinimumStoryCommentCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimumStoryCommentCount", value);
            }

        }

        [XmlAttribute("PublishMinimumAverageStoryKicksPerHour")]
        public short PublishMinimumAverageStoryKicksPerHour 
	    {
		    get { return GetColumnValue<short>("PublishMinimumAverageStoryKicksPerHour"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimumAverageStoryKicksPerHour", value);
            }

        }

        [XmlAttribute("PublishMinimunAverageCommentsPerHour")]
        public short PublishMinimunAverageCommentsPerHour 
	    {
		    get { return GetColumnValue<short>("PublishMinimunAverageCommentsPerHour"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimunAverageCommentsPerHour", value);
            }

        }

        [XmlAttribute("PublishMinimumViewCount")]
        public short PublishMinimumViewCount 
	    {
		    get { return GetColumnValue<short>("PublishMinimumViewCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishMinimumViewCount", value);
            }

        }

        [XmlAttribute("PublishKickScore")]
        public short PublishKickScore 
	    {
		    get { return GetColumnValue<short>("PublishKickScore"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishKickScore", value);
            }

        }

        [XmlAttribute("PublishCommentScore")]
        public short PublishCommentScore 
	    {
		    get { return GetColumnValue<short>("PublishCommentScore"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("PublishCommentScore", value);
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

        [XmlAttribute("TrackingHtml")]
        public string TrackingHtml 
	    {
		    get { return GetColumnValue<string>("TrackingHtml"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("TrackingHtml", value);
            }

        }

	    #endregion
			#region PrimaryKey Methods
				public KickCategoryCollection KickCategoryRecords()
				{
					return new KickCategoryCollection().Where(KickCategory.Columns.HostID, HostID).Load();
				}

				public KickStoryCollection KickStoryRecords()
				{
					return new KickStoryCollection().Where(KickStory.Columns.HostID, HostID).Load();
				}

				public KickStoryUserHostTagCollection KickStoryUserHostTagRecords()
				{
					return new KickStoryUserHostTagCollection().Where(KickStoryUserHostTag.Columns.HostID, HostID).Load();
				}

			#endregion
	    //no foreign key tables defined (0)
	    //no ManyToMany tables defined (0)
	    #region ObjectDataSource support
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varHostName,string varRootUrl,string varSiteTitle,string varSiteDescription,string varTagLine,string varLogoPath,DateTime varCreatedDateTime,string varBlogUrl,string varEmail,string varSkin,string varTheme,bool varShowAds,string varCulture,string varUICulture,short varPublishMinimumStoryAgeInHours,short varPublishMaximumStoryAgeInHours,short varPublishMaximumSimultaneousStoryPublishCount,short varPublishMinimumStoryScore,short varPublishMinimumStoryKickCount,short varPublishMinimumStoryCommentCount,short varPublishMinimumAverageStoryKicksPerHour,short varPublishMinimunAverageCommentsPerHour,short varPublishMinimumViewCount,short varPublishKickScore,short varPublishCommentScore,string varAdsenseID,string varTrackingHtml)
	    {
		    KickHost item = new KickHost();
            item.HostName = varHostName;
            item.RootUrl = varRootUrl;
            item.SiteTitle = varSiteTitle;
            item.SiteDescription = varSiteDescription;
            item.TagLine = varTagLine;
            item.LogoPath = varLogoPath;
            item.CreatedDateTime = varCreatedDateTime;
            item.BlogUrl = varBlogUrl;
            item.Email = varEmail;
            item.Skin = varSkin;
            item.Theme = varTheme;
            item.ShowAds = varShowAds;
            item.Culture = varCulture;
            item.UICulture = varUICulture;
            item.PublishMinimumStoryAgeInHours = varPublishMinimumStoryAgeInHours;
            item.PublishMaximumStoryAgeInHours = varPublishMaximumStoryAgeInHours;
            item.PublishMaximumSimultaneousStoryPublishCount = varPublishMaximumSimultaneousStoryPublishCount;
            item.PublishMinimumStoryScore = varPublishMinimumStoryScore;
            item.PublishMinimumStoryKickCount = varPublishMinimumStoryKickCount;
            item.PublishMinimumStoryCommentCount = varPublishMinimumStoryCommentCount;
            item.PublishMinimumAverageStoryKicksPerHour = varPublishMinimumAverageStoryKicksPerHour;
            item.PublishMinimunAverageCommentsPerHour = varPublishMinimunAverageCommentsPerHour;
            item.PublishMinimumViewCount = varPublishMinimumViewCount;
            item.PublishKickScore = varPublishKickScore;
            item.PublishCommentScore = varPublishCommentScore;
            item.AdsenseID = varAdsenseID;
            item.TrackingHtml = varTrackingHtml;
		    if (System.Web.HttpContext.Current != null)
			    item.Save(System.Web.HttpContext.Current.User.Identity.Name);
		    else
			    item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
	    }

	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Update(int varHostID,string varHostName,string varRootUrl,string varSiteTitle,string varSiteDescription,string varTagLine,string varLogoPath,DateTime varCreatedDateTime,string varBlogUrl,string varEmail,string varSkin,string varTheme,bool varShowAds,string varCulture,string varUICulture,short varPublishMinimumStoryAgeInHours,short varPublishMaximumStoryAgeInHours,short varPublishMaximumSimultaneousStoryPublishCount,short varPublishMinimumStoryScore,short varPublishMinimumStoryKickCount,short varPublishMinimumStoryCommentCount,short varPublishMinimumAverageStoryKicksPerHour,short varPublishMinimunAverageCommentsPerHour,short varPublishMinimumViewCount,short varPublishKickScore,short varPublishCommentScore,string varAdsenseID,string varTrackingHtml)
	    {
		    KickHost item = new KickHost();
                item.HostID = varHostID;
                item.HostName = varHostName;
                item.RootUrl = varRootUrl;
                item.SiteTitle = varSiteTitle;
                item.SiteDescription = varSiteDescription;
                item.TagLine = varTagLine;
                item.LogoPath = varLogoPath;
                item.CreatedDateTime = varCreatedDateTime;
                item.BlogUrl = varBlogUrl;
                item.Email = varEmail;
                item.Skin = varSkin;
                item.Theme = varTheme;
                item.ShowAds = varShowAds;
                item.Culture = varCulture;
                item.UICulture = varUICulture;
                item.PublishMinimumStoryAgeInHours = varPublishMinimumStoryAgeInHours;
                item.PublishMaximumStoryAgeInHours = varPublishMaximumStoryAgeInHours;
                item.PublishMaximumSimultaneousStoryPublishCount = varPublishMaximumSimultaneousStoryPublishCount;
                item.PublishMinimumStoryScore = varPublishMinimumStoryScore;
                item.PublishMinimumStoryKickCount = varPublishMinimumStoryKickCount;
                item.PublishMinimumStoryCommentCount = varPublishMinimumStoryCommentCount;
                item.PublishMinimumAverageStoryKicksPerHour = varPublishMinimumAverageStoryKicksPerHour;
                item.PublishMinimunAverageCommentsPerHour = varPublishMinimunAverageCommentsPerHour;
                item.PublishMinimumViewCount = varPublishMinimumViewCount;
                item.PublishKickScore = varPublishKickScore;
                item.PublishCommentScore = varPublishCommentScore;
                item.AdsenseID = varAdsenseID;
                item.TrackingHtml = varTrackingHtml;
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
            public static string HostID = @"HostID";
            public static string HostName = @"HostName";
            public static string RootUrl = @"RootUrl";
            public static string SiteTitle = @"SiteTitle";
            public static string SiteDescription = @"SiteDescription";
            public static string TagLine = @"TagLine";
            public static string LogoPath = @"LogoPath";
            public static string CreatedDateTime = @"CreatedDateTime";
            public static string BlogUrl = @"BlogUrl";
            public static string Email = @"Email";
            public static string Skin = @"Skin";
            public static string Theme = @"Theme";
            public static string ShowAds = @"ShowAds";
            public static string Culture = @"Culture";
            public static string UICulture = @"UICulture";
            public static string PublishMinimumStoryAgeInHours = @"PublishMinimumStoryAgeInHours";
            public static string PublishMaximumStoryAgeInHours = @"PublishMaximumStoryAgeInHours";
            public static string PublishMaximumSimultaneousStoryPublishCount = @"PublishMaximumSimultaneousStoryPublishCount";
            public static string PublishMinimumStoryScore = @"PublishMinimumStoryScore";
            public static string PublishMinimumStoryKickCount = @"PublishMinimumStoryKickCount";
            public static string PublishMinimumStoryCommentCount = @"PublishMinimumStoryCommentCount";
            public static string PublishMinimumAverageStoryKicksPerHour = @"PublishMinimumAverageStoryKicksPerHour";
            public static string PublishMinimunAverageCommentsPerHour = @"PublishMinimunAverageCommentsPerHour";
            public static string PublishMinimumViewCount = @"PublishMinimumViewCount";
            public static string PublishKickScore = @"PublishKickScore";
            public static string PublishCommentScore = @"PublishCommentScore";
            public static string AdsenseID = @"AdsenseID";
            public static string TrackingHtml = @"TrackingHtml";
	    }

	    #endregion
    }

}
