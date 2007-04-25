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


//Generated on 25/04/2007 16:27:25 by gjoyce

namespace Incremental.Kick.Dal{
    /// <summary>
    /// Strongly-typed collection for the Host class.
    /// </summary>
    [Serializable]
    public partial class HostCollection : ActiveList<Host> 
    {
        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
    	
        public HostCollection OrderByAsc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }

    	
        public HostCollection OrderByDesc(string columnName) 
	    {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }

	    public HostCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) 
	    {
            return this;
        }

        public HostCollection Where(Where where) 
	    {
            wheres.Add(where);
            return this;
        }

    	
        public HostCollection Where(string columnName, object value) 
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

    	
        public HostCollection Where(string columnName, Comparison comp, object value) 
	    {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;
        }

    	
        public HostCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) 
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

    	
        public HostCollection Load() 
        {
            Query qry = new Query(Host.Schema);
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

        
        public HostCollection() 
	    {
        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the Kick_Host table.
    /// </summary>
    [Serializable]
    public partial class Host : ActiveRecord<Host>
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Host", TableType.Table, DataService.GetInstance("Kick"));
                schema.Columns = new TableSchema.TableColumnCollection();
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
                
                TableSchema.TableColumn colvarPublish_MinimumStoryAgeInHours = new TableSchema.TableColumn(schema);
                colvarPublish_MinimumStoryAgeInHours.ColumnName = "Publish_MinimumStoryAgeInHours";
                colvarPublish_MinimumStoryAgeInHours.DataType = DbType.Int16;
                colvarPublish_MinimumStoryAgeInHours.MaxLength = 0;
                colvarPublish_MinimumStoryAgeInHours.AutoIncrement = false;
                colvarPublish_MinimumStoryAgeInHours.IsNullable = false;
                colvarPublish_MinimumStoryAgeInHours.IsPrimaryKey = false;
                colvarPublish_MinimumStoryAgeInHours.IsForeignKey = false;
                colvarPublish_MinimumStoryAgeInHours.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimumStoryAgeInHours);
                
                TableSchema.TableColumn colvarPublish_MaximumStoryAgeInHours = new TableSchema.TableColumn(schema);
                colvarPublish_MaximumStoryAgeInHours.ColumnName = "Publish_MaximumStoryAgeInHours";
                colvarPublish_MaximumStoryAgeInHours.DataType = DbType.Int16;
                colvarPublish_MaximumStoryAgeInHours.MaxLength = 0;
                colvarPublish_MaximumStoryAgeInHours.AutoIncrement = false;
                colvarPublish_MaximumStoryAgeInHours.IsNullable = false;
                colvarPublish_MaximumStoryAgeInHours.IsPrimaryKey = false;
                colvarPublish_MaximumStoryAgeInHours.IsForeignKey = false;
                colvarPublish_MaximumStoryAgeInHours.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MaximumStoryAgeInHours);
                
                TableSchema.TableColumn colvarPublish_MaximumSimultaneousStoryPublishCount = new TableSchema.TableColumn(schema);
                colvarPublish_MaximumSimultaneousStoryPublishCount.ColumnName = "Publish_MaximumSimultaneousStoryPublishCount";
                colvarPublish_MaximumSimultaneousStoryPublishCount.DataType = DbType.Int16;
                colvarPublish_MaximumSimultaneousStoryPublishCount.MaxLength = 0;
                colvarPublish_MaximumSimultaneousStoryPublishCount.AutoIncrement = false;
                colvarPublish_MaximumSimultaneousStoryPublishCount.IsNullable = false;
                colvarPublish_MaximumSimultaneousStoryPublishCount.IsPrimaryKey = false;
                colvarPublish_MaximumSimultaneousStoryPublishCount.IsForeignKey = false;
                colvarPublish_MaximumSimultaneousStoryPublishCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MaximumSimultaneousStoryPublishCount);
                
                TableSchema.TableColumn colvarPublish_MinimumStoryScore = new TableSchema.TableColumn(schema);
                colvarPublish_MinimumStoryScore.ColumnName = "Publish_MinimumStoryScore";
                colvarPublish_MinimumStoryScore.DataType = DbType.Int16;
                colvarPublish_MinimumStoryScore.MaxLength = 0;
                colvarPublish_MinimumStoryScore.AutoIncrement = false;
                colvarPublish_MinimumStoryScore.IsNullable = false;
                colvarPublish_MinimumStoryScore.IsPrimaryKey = false;
                colvarPublish_MinimumStoryScore.IsForeignKey = false;
                colvarPublish_MinimumStoryScore.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimumStoryScore);
                
                TableSchema.TableColumn colvarPublish_MinimumStoryKickCount = new TableSchema.TableColumn(schema);
                colvarPublish_MinimumStoryKickCount.ColumnName = "Publish_MinimumStoryKickCount";
                colvarPublish_MinimumStoryKickCount.DataType = DbType.Int16;
                colvarPublish_MinimumStoryKickCount.MaxLength = 0;
                colvarPublish_MinimumStoryKickCount.AutoIncrement = false;
                colvarPublish_MinimumStoryKickCount.IsNullable = false;
                colvarPublish_MinimumStoryKickCount.IsPrimaryKey = false;
                colvarPublish_MinimumStoryKickCount.IsForeignKey = false;
                colvarPublish_MinimumStoryKickCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimumStoryKickCount);
                
                TableSchema.TableColumn colvarPublish_MinimumStoryCommentCount = new TableSchema.TableColumn(schema);
                colvarPublish_MinimumStoryCommentCount.ColumnName = "Publish_MinimumStoryCommentCount";
                colvarPublish_MinimumStoryCommentCount.DataType = DbType.Int16;
                colvarPublish_MinimumStoryCommentCount.MaxLength = 0;
                colvarPublish_MinimumStoryCommentCount.AutoIncrement = false;
                colvarPublish_MinimumStoryCommentCount.IsNullable = false;
                colvarPublish_MinimumStoryCommentCount.IsPrimaryKey = false;
                colvarPublish_MinimumStoryCommentCount.IsForeignKey = false;
                colvarPublish_MinimumStoryCommentCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimumStoryCommentCount);
                
                TableSchema.TableColumn colvarPublish_MinimumAverageStoryKicksPerHour = new TableSchema.TableColumn(schema);
                colvarPublish_MinimumAverageStoryKicksPerHour.ColumnName = "Publish_MinimumAverageStoryKicksPerHour";
                colvarPublish_MinimumAverageStoryKicksPerHour.DataType = DbType.Int16;
                colvarPublish_MinimumAverageStoryKicksPerHour.MaxLength = 0;
                colvarPublish_MinimumAverageStoryKicksPerHour.AutoIncrement = false;
                colvarPublish_MinimumAverageStoryKicksPerHour.IsNullable = false;
                colvarPublish_MinimumAverageStoryKicksPerHour.IsPrimaryKey = false;
                colvarPublish_MinimumAverageStoryKicksPerHour.IsForeignKey = false;
                colvarPublish_MinimumAverageStoryKicksPerHour.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimumAverageStoryKicksPerHour);
                
                TableSchema.TableColumn colvarPublish_MinimunAverageCommentsPerHour = new TableSchema.TableColumn(schema);
                colvarPublish_MinimunAverageCommentsPerHour.ColumnName = "Publish_MinimunAverageCommentsPerHour";
                colvarPublish_MinimunAverageCommentsPerHour.DataType = DbType.Int16;
                colvarPublish_MinimunAverageCommentsPerHour.MaxLength = 0;
                colvarPublish_MinimunAverageCommentsPerHour.AutoIncrement = false;
                colvarPublish_MinimunAverageCommentsPerHour.IsNullable = false;
                colvarPublish_MinimunAverageCommentsPerHour.IsPrimaryKey = false;
                colvarPublish_MinimunAverageCommentsPerHour.IsForeignKey = false;
                colvarPublish_MinimunAverageCommentsPerHour.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimunAverageCommentsPerHour);
                
                TableSchema.TableColumn colvarPublish_MinimumViewCount = new TableSchema.TableColumn(schema);
                colvarPublish_MinimumViewCount.ColumnName = "Publish_MinimumViewCount";
                colvarPublish_MinimumViewCount.DataType = DbType.Int16;
                colvarPublish_MinimumViewCount.MaxLength = 0;
                colvarPublish_MinimumViewCount.AutoIncrement = false;
                colvarPublish_MinimumViewCount.IsNullable = false;
                colvarPublish_MinimumViewCount.IsPrimaryKey = false;
                colvarPublish_MinimumViewCount.IsForeignKey = false;
                colvarPublish_MinimumViewCount.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_MinimumViewCount);
                
                TableSchema.TableColumn colvarPublish_KickScore = new TableSchema.TableColumn(schema);
                colvarPublish_KickScore.ColumnName = "Publish_KickScore";
                colvarPublish_KickScore.DataType = DbType.Int16;
                colvarPublish_KickScore.MaxLength = 0;
                colvarPublish_KickScore.AutoIncrement = false;
                colvarPublish_KickScore.IsNullable = false;
                colvarPublish_KickScore.IsPrimaryKey = false;
                colvarPublish_KickScore.IsForeignKey = false;
                colvarPublish_KickScore.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_KickScore);
                
                TableSchema.TableColumn colvarPublish_CommentScore = new TableSchema.TableColumn(schema);
                colvarPublish_CommentScore.ColumnName = "Publish_CommentScore";
                colvarPublish_CommentScore.DataType = DbType.Int16;
                colvarPublish_CommentScore.MaxLength = 0;
                colvarPublish_CommentScore.AutoIncrement = false;
                colvarPublish_CommentScore.IsNullable = false;
                colvarPublish_CommentScore.IsPrimaryKey = false;
                colvarPublish_CommentScore.IsForeignKey = false;
                colvarPublish_CommentScore.IsReadOnly = false;
                
                schema.Columns.Add(colvarPublish_CommentScore);
                
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
                DataService.Providers["Kick"].AddSchema("Kick_Host",schema);
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
	    public Host()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

	    public Host(object keyID)
	    {
		    SetSQLProps();
            SetDefaults();
		    LoadByKey(keyID);
	    }

    	 
	    public Host(string columnName, object columnValue)
        {
            SetSQLProps();
            SetDefaults();
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

	      
        [XmlAttribute("Publish_MinimumStoryAgeInHours")]
        public short Publish_MinimumStoryAgeInHours 
	    {
		    get { return GetColumnValue<short>("Publish_MinimumStoryAgeInHours"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimumStoryAgeInHours", value);
            }

        }

	      
        [XmlAttribute("Publish_MaximumStoryAgeInHours")]
        public short Publish_MaximumStoryAgeInHours 
	    {
		    get { return GetColumnValue<short>("Publish_MaximumStoryAgeInHours"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MaximumStoryAgeInHours", value);
            }

        }

	      
        [XmlAttribute("Publish_MaximumSimultaneousStoryPublishCount")]
        public short Publish_MaximumSimultaneousStoryPublishCount 
	    {
		    get { return GetColumnValue<short>("Publish_MaximumSimultaneousStoryPublishCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MaximumSimultaneousStoryPublishCount", value);
            }

        }

	      
        [XmlAttribute("Publish_MinimumStoryScore")]
        public short Publish_MinimumStoryScore 
	    {
		    get { return GetColumnValue<short>("Publish_MinimumStoryScore"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimumStoryScore", value);
            }

        }

	      
        [XmlAttribute("Publish_MinimumStoryKickCount")]
        public short Publish_MinimumStoryKickCount 
	    {
		    get { return GetColumnValue<short>("Publish_MinimumStoryKickCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimumStoryKickCount", value);
            }

        }

	      
        [XmlAttribute("Publish_MinimumStoryCommentCount")]
        public short Publish_MinimumStoryCommentCount 
	    {
		    get { return GetColumnValue<short>("Publish_MinimumStoryCommentCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimumStoryCommentCount", value);
            }

        }

	      
        [XmlAttribute("Publish_MinimumAverageStoryKicksPerHour")]
        public short Publish_MinimumAverageStoryKicksPerHour 
	    {
		    get { return GetColumnValue<short>("Publish_MinimumAverageStoryKicksPerHour"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimumAverageStoryKicksPerHour", value);
            }

        }

	      
        [XmlAttribute("Publish_MinimunAverageCommentsPerHour")]
        public short Publish_MinimunAverageCommentsPerHour 
	    {
		    get { return GetColumnValue<short>("Publish_MinimunAverageCommentsPerHour"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimunAverageCommentsPerHour", value);
            }

        }

	      
        [XmlAttribute("Publish_MinimumViewCount")]
        public short Publish_MinimumViewCount 
	    {
		    get { return GetColumnValue<short>("Publish_MinimumViewCount"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_MinimumViewCount", value);
            }

        }

	      
        [XmlAttribute("Publish_KickScore")]
        public short Publish_KickScore 
	    {
		    get { return GetColumnValue<short>("Publish_KickScore"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_KickScore", value);
            }

        }

	      
        [XmlAttribute("Publish_CommentScore")]
        public short Publish_CommentScore 
	    {
		    get { return GetColumnValue<short>("Publish_CommentScore"); }

            set 
		    {
			    MarkDirty();
			    SetColumnValue("Publish_CommentScore", value);
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
	    
		public Incremental.Kick.Dal.CategoryCollection CategoryRecords()
		{
			return new Incremental.Kick.Dal.CategoryCollection().Where(Category.Columns.HostID, HostID).Load();
		}

		public Incremental.Kick.Dal.StoryCollection StoryRecords()
		{
			return new Incremental.Kick.Dal.StoryCollection().Where(Story.Columns.HostID, HostID).Load();
		}

		public Incremental.Kick.Dal.StoryUserHostTagCollection StoryUserHostTagRecords()
		{
			return new Incremental.Kick.Dal.StoryUserHostTagCollection().Where(StoryUserHostTag.Columns.HostID, HostID).Load();
		}

		#endregion
		
	 	
			
	    
	    //no foreign key tables defined (0)
	    
	    
	    
	    //no ManyToMany tables defined (0)
	    
	    #region ObjectDataSource support
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
	    public static void Insert(string varHostName,string varRootUrl,string varSiteTitle,string varSiteDescription,string varTagLine,string varLogoPath,DateTime varCreatedDateTime,string varBlogUrl,string varEmail,string varSkin,string varTheme,bool varShowAds,string varCulture,string varUICulture,short varPublish_MinimumStoryAgeInHours,short varPublish_MaximumStoryAgeInHours,short varPublish_MaximumSimultaneousStoryPublishCount,short varPublish_MinimumStoryScore,short varPublish_MinimumStoryKickCount,short varPublish_MinimumStoryCommentCount,short varPublish_MinimumAverageStoryKicksPerHour,short varPublish_MinimunAverageCommentsPerHour,short varPublish_MinimumViewCount,short varPublish_KickScore,short varPublish_CommentScore,string varAdsenseID,string varTrackingHtml)
	    {
		    Host item = new Host();
		    
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
            
            item.Publish_MinimumStoryAgeInHours = varPublish_MinimumStoryAgeInHours;
            
            item.Publish_MaximumStoryAgeInHours = varPublish_MaximumStoryAgeInHours;
            
            item.Publish_MaximumSimultaneousStoryPublishCount = varPublish_MaximumSimultaneousStoryPublishCount;
            
            item.Publish_MinimumStoryScore = varPublish_MinimumStoryScore;
            
            item.Publish_MinimumStoryKickCount = varPublish_MinimumStoryKickCount;
            
            item.Publish_MinimumStoryCommentCount = varPublish_MinimumStoryCommentCount;
            
            item.Publish_MinimumAverageStoryKicksPerHour = varPublish_MinimumAverageStoryKicksPerHour;
            
            item.Publish_MinimunAverageCommentsPerHour = varPublish_MinimunAverageCommentsPerHour;
            
            item.Publish_MinimumViewCount = varPublish_MinimumViewCount;
            
            item.Publish_KickScore = varPublish_KickScore;
            
            item.Publish_CommentScore = varPublish_CommentScore;
            
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
	    public static void Update(int varHostID,string varHostName,string varRootUrl,string varSiteTitle,string varSiteDescription,string varTagLine,string varLogoPath,DateTime varCreatedDateTime,string varBlogUrl,string varEmail,string varSkin,string varTheme,bool varShowAds,string varCulture,string varUICulture,short varPublish_MinimumStoryAgeInHours,short varPublish_MaximumStoryAgeInHours,short varPublish_MaximumSimultaneousStoryPublishCount,short varPublish_MinimumStoryScore,short varPublish_MinimumStoryKickCount,short varPublish_MinimumStoryCommentCount,short varPublish_MinimumAverageStoryKicksPerHour,short varPublish_MinimunAverageCommentsPerHour,short varPublish_MinimumViewCount,short varPublish_KickScore,short varPublish_CommentScore,string varAdsenseID,string varTrackingHtml)
	    {
		    Host item = new Host();
		    
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
				
                item.Publish_MinimumStoryAgeInHours = varPublish_MinimumStoryAgeInHours;
				
                item.Publish_MaximumStoryAgeInHours = varPublish_MaximumStoryAgeInHours;
				
                item.Publish_MaximumSimultaneousStoryPublishCount = varPublish_MaximumSimultaneousStoryPublishCount;
				
                item.Publish_MinimumStoryScore = varPublish_MinimumStoryScore;
				
                item.Publish_MinimumStoryKickCount = varPublish_MinimumStoryKickCount;
				
                item.Publish_MinimumStoryCommentCount = varPublish_MinimumStoryCommentCount;
				
                item.Publish_MinimumAverageStoryKicksPerHour = varPublish_MinimumAverageStoryKicksPerHour;
				
                item.Publish_MinimunAverageCommentsPerHour = varPublish_MinimunAverageCommentsPerHour;
				
                item.Publish_MinimumViewCount = varPublish_MinimumViewCount;
				
                item.Publish_KickScore = varPublish_KickScore;
				
                item.Publish_CommentScore = varPublish_CommentScore;
				
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
            
            public static string Publish_MinimumStoryAgeInHours = @"Publish_MinimumStoryAgeInHours";
            
            public static string Publish_MaximumStoryAgeInHours = @"Publish_MaximumStoryAgeInHours";
            
            public static string Publish_MaximumSimultaneousStoryPublishCount = @"Publish_MaximumSimultaneousStoryPublishCount";
            
            public static string Publish_MinimumStoryScore = @"Publish_MinimumStoryScore";
            
            public static string Publish_MinimumStoryKickCount = @"Publish_MinimumStoryKickCount";
            
            public static string Publish_MinimumStoryCommentCount = @"Publish_MinimumStoryCommentCount";
            
            public static string Publish_MinimumAverageStoryKicksPerHour = @"Publish_MinimumAverageStoryKicksPerHour";
            
            public static string Publish_MinimunAverageCommentsPerHour = @"Publish_MinimunAverageCommentsPerHour";
            
            public static string Publish_MinimumViewCount = @"Publish_MinimumViewCount";
            
            public static string Publish_KickScore = @"Publish_KickScore";
            
            public static string Publish_CommentScore = @"Publish_CommentScore";
            
            public static string AdsenseID = @"AdsenseID";
            
            public static string TrackingHtml = @"TrackingHtml";
            
	    }

	    #endregion
    }

}
