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
	/// Strongly-typed collection for the Story class.
	/// </summary>
	[Serializable]
	public partial class StoryCollection : ActiveList<Story, StoryCollection> 
	{	   
		public StoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Story table.
	/// </summary>
	[Serializable]
	public partial class Story : ActiveRecord<Story>
	{
		#region .ctors and Default Settings
		
		public Story()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Story(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Story(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Story(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Story", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
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
				colvarStoryID.DefaultSetting = @"";
				colvarStoryID.ForeignKeyTableName = "";
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
				colvarHostID.DefaultSetting = @"";
				
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
				colvarStoryIdentifier.DefaultSetting = @"";
				colvarStoryIdentifier.ForeignKeyTableName = "";
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
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
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
				colvarDescription.DefaultSetting = @"";
				colvarDescription.ForeignKeyTableName = "";
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
				colvarUrl.DefaultSetting = @"";
				colvarUrl.ForeignKeyTableName = "";
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
				colvarCategoryID.DefaultSetting = @"";
				
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
				
						colvarUserID.DefaultSetting = @"((1))";
				
					colvarUserID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarKickCount = new TableSchema.TableColumn(schema);
				colvarKickCount.ColumnName = "KickCount";
				colvarKickCount.DataType = DbType.Int32;
				colvarKickCount.MaxLength = 0;
				colvarKickCount.AutoIncrement = false;
				colvarKickCount.IsNullable = false;
				colvarKickCount.IsPrimaryKey = false;
				colvarKickCount.IsForeignKey = false;
				colvarKickCount.IsReadOnly = false;
				colvarKickCount.DefaultSetting = @"";
				colvarKickCount.ForeignKeyTableName = "";
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
				colvarSpamCount.DefaultSetting = @"";
				colvarSpamCount.ForeignKeyTableName = "";
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
				colvarViewCount.DefaultSetting = @"";
				colvarViewCount.ForeignKeyTableName = "";
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
				colvarCommentCount.DefaultSetting = @"";
				colvarCommentCount.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommentCount);
				
				TableSchema.TableColumn colvarIsPublishedToHomepage = new TableSchema.TableColumn(schema);
				colvarIsPublishedToHomepage.ColumnName = "IsPublishedToHomepage";
				colvarIsPublishedToHomepage.DataType = DbType.Boolean;
				colvarIsPublishedToHomepage.MaxLength = 0;
				colvarIsPublishedToHomepage.AutoIncrement = false;
				colvarIsPublishedToHomepage.IsNullable = false;
				colvarIsPublishedToHomepage.IsPrimaryKey = false;
				colvarIsPublishedToHomepage.IsForeignKey = false;
				colvarIsPublishedToHomepage.IsReadOnly = false;
				colvarIsPublishedToHomepage.DefaultSetting = @"";
				colvarIsPublishedToHomepage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsPublishedToHomepage);
				
				TableSchema.TableColumn colvarIsSpam = new TableSchema.TableColumn(schema);
				colvarIsSpam.ColumnName = "IsSpam";
				colvarIsSpam.DataType = DbType.Boolean;
				colvarIsSpam.MaxLength = 0;
				colvarIsSpam.AutoIncrement = false;
				colvarIsSpam.IsNullable = false;
				colvarIsSpam.IsPrimaryKey = false;
				colvarIsSpam.IsForeignKey = false;
				colvarIsSpam.IsReadOnly = false;
				colvarIsSpam.DefaultSetting = @"";
				colvarIsSpam.ForeignKeyTableName = "";
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
				
						colvarAdsenseID.DefaultSetting = @"('')";
				colvarAdsenseID.ForeignKeyTableName = "";
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
				colvarCreatedOn.DefaultSetting = @"";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarPublishedOn = new TableSchema.TableColumn(schema);
				colvarPublishedOn.ColumnName = "PublishedOn";
				colvarPublishedOn.DataType = DbType.DateTime;
				colvarPublishedOn.MaxLength = 0;
				colvarPublishedOn.AutoIncrement = false;
				colvarPublishedOn.IsNullable = false;
				colvarPublishedOn.IsPrimaryKey = false;
				colvarPublishedOn.IsForeignKey = false;
				colvarPublishedOn.IsReadOnly = false;
				colvarPublishedOn.DefaultSetting = @"";
				colvarPublishedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPublishedOn);
				
				TableSchema.TableColumn colvarUpdatedOn = new TableSchema.TableColumn(schema);
				colvarUpdatedOn.ColumnName = "UpdatedOn";
				colvarUpdatedOn.DataType = DbType.DateTime;
				colvarUpdatedOn.MaxLength = 0;
				colvarUpdatedOn.AutoIncrement = false;
				colvarUpdatedOn.IsNullable = false;
				colvarUpdatedOn.IsPrimaryKey = false;
				colvarUpdatedOn.IsForeignKey = false;
				colvarUpdatedOn.IsReadOnly = false;
				
						colvarUpdatedOn.DefaultSetting = @"(getdate())";
				colvarUpdatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUpdatedOn);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Story",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("StoryID")]
		public int StoryID 
		{
			get { return GetColumnValue<int>(Columns.StoryID); }

			set { SetColumnValue(Columns.StoryID, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("StoryIdentifier")]
		public string StoryIdentifier 
		{
			get { return GetColumnValue<string>(Columns.StoryIdentifier); }

			set { SetColumnValue(Columns.StoryIdentifier, value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }

			set { SetColumnValue(Columns.Title, value); }

		}

		  
		[XmlAttribute("Description")]
		public string Description 
		{
			get { return GetColumnValue<string>(Columns.Description); }

			set { SetColumnValue(Columns.Description, value); }

		}

		  
		[XmlAttribute("Url")]
		public string Url 
		{
			get { return GetColumnValue<string>(Columns.Url); }

			set { SetColumnValue(Columns.Url, value); }

		}

		  
		[XmlAttribute("CategoryID")]
		public short CategoryID 
		{
			get { return GetColumnValue<short>(Columns.CategoryID); }

			set { SetColumnValue(Columns.CategoryID, value); }

		}

		  
		[XmlAttribute("UserID")]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("KickCount")]
		public int KickCount 
		{
			get { return GetColumnValue<int>(Columns.KickCount); }

			set { SetColumnValue(Columns.KickCount, value); }

		}

		  
		[XmlAttribute("SpamCount")]
		public int SpamCount 
		{
			get { return GetColumnValue<int>(Columns.SpamCount); }

			set { SetColumnValue(Columns.SpamCount, value); }

		}

		  
		[XmlAttribute("ViewCount")]
		public int ViewCount 
		{
			get { return GetColumnValue<int>(Columns.ViewCount); }

			set { SetColumnValue(Columns.ViewCount, value); }

		}

		  
		[XmlAttribute("CommentCount")]
		public int CommentCount 
		{
			get { return GetColumnValue<int>(Columns.CommentCount); }

			set { SetColumnValue(Columns.CommentCount, value); }

		}

		  
		[XmlAttribute("IsPublishedToHomepage")]
		public bool IsPublishedToHomepage 
		{
			get { return GetColumnValue<bool>(Columns.IsPublishedToHomepage); }

			set { SetColumnValue(Columns.IsPublishedToHomepage, value); }

		}

		  
		[XmlAttribute("IsSpam")]
		public bool IsSpam 
		{
			get { return GetColumnValue<bool>(Columns.IsSpam); }

			set { SetColumnValue(Columns.IsSpam, value); }

		}

		  
		[XmlAttribute("AdsenseID")]
		public string AdsenseID 
		{
			get { return GetColumnValue<string>(Columns.AdsenseID); }

			set { SetColumnValue(Columns.AdsenseID, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		  
		[XmlAttribute("PublishedOn")]
		public DateTime PublishedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.PublishedOn); }

			set { SetColumnValue(Columns.PublishedOn, value); }

		}

		  
		[XmlAttribute("UpdatedOn")]
		public DateTime UpdatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.UpdatedOn); }

			set { SetColumnValue(Columns.UpdatedOn, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.CommentCollection colCommentRecords;
		public Incremental.Kick.Dal.CommentCollection CommentRecords()
		{
			if(colCommentRecords == null)
				colCommentRecords = new Incremental.Kick.Dal.CommentCollection().Where(Comment.Columns.StoryID, StoryID).Load();
			return colCommentRecords;
		}

		private Incremental.Kick.Dal.StoryKickCollection colStoryKickRecords;
		public Incremental.Kick.Dal.StoryKickCollection StoryKickRecords()
		{
			if(colStoryKickRecords == null)
				colStoryKickRecords = new Incremental.Kick.Dal.StoryKickCollection().Where(StoryKick.Columns.StoryID, StoryID).Load();
			return colStoryKickRecords;
		}

		private Incremental.Kick.Dal.StoryUserHostTagCollection colStoryUserHostTagRecords;
		public Incremental.Kick.Dal.StoryUserHostTagCollection StoryUserHostTagRecords()
		{
			if(colStoryUserHostTagRecords == null)
				colStoryUserHostTagRecords = new Incremental.Kick.Dal.StoryUserHostTagCollection().Where(StoryUserHostTag.Columns.StoryID, StoryID).Load();
			return colStoryUserHostTagRecords;
		}

		private Incremental.Kick.Dal.UserActionCollection colUserActionRecords;
		public Incremental.Kick.Dal.UserActionCollection UserActionRecords()
		{
			if(colUserActionRecords == null)
				colUserActionRecords = new Incremental.Kick.Dal.UserActionCollection().Where(UserAction.Columns.StoryID, StoryID).Load();
			return colUserActionRecords;
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Category ActiveRecord object related to this Story
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Category Category
		{
			get { return Incremental.Kick.Dal.Category.FetchByID(this.CategoryID); }

			set { SetColumnValue("CategoryID", value.CategoryID); }

		}

		
		
		/// <summary>
		/// Returns a Host ActiveRecord object related to this Story
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Host Host
		{
			get { return Incremental.Kick.Dal.Host.FetchByID(this.HostID); }

			set { SetColumnValue("HostID", value.HostID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this Story
		/// 
		/// </summary>
		public Incremental.Kick.Dal.User User
		{
			get { return Incremental.Kick.Dal.User.FetchByID(this.UserID); }

			set { SetColumnValue("UserID", value.UserID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varHostID,string varStoryIdentifier,string varTitle,string varDescription,string varUrl,short varCategoryID,int varUserID,int varKickCount,int varSpamCount,int varViewCount,int varCommentCount,bool varIsPublishedToHomepage,bool varIsSpam,string varAdsenseID,DateTime varCreatedOn,DateTime varPublishedOn,DateTime varUpdatedOn)
		{
			Story item = new Story();
			
			item.HostID = varHostID;
			
			item.StoryIdentifier = varStoryIdentifier;
			
			item.Title = varTitle;
			
			item.Description = varDescription;
			
			item.Url = varUrl;
			
			item.CategoryID = varCategoryID;
			
			item.UserID = varUserID;
			
			item.KickCount = varKickCount;
			
			item.SpamCount = varSpamCount;
			
			item.ViewCount = varViewCount;
			
			item.CommentCount = varCommentCount;
			
			item.IsPublishedToHomepage = varIsPublishedToHomepage;
			
			item.IsSpam = varIsSpam;
			
			item.AdsenseID = varAdsenseID;
			
			item.CreatedOn = varCreatedOn;
			
			item.PublishedOn = varPublishedOn;
			
			item.UpdatedOn = varUpdatedOn;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varStoryID,int varHostID,string varStoryIdentifier,string varTitle,string varDescription,string varUrl,short varCategoryID,int varUserID,int varKickCount,int varSpamCount,int varViewCount,int varCommentCount,bool varIsPublishedToHomepage,bool varIsSpam,string varAdsenseID,DateTime varCreatedOn,DateTime varPublishedOn,DateTime varUpdatedOn)
		{
			Story item = new Story();
			
				item.StoryID = varStoryID;
			
				item.HostID = varHostID;
			
				item.StoryIdentifier = varStoryIdentifier;
			
				item.Title = varTitle;
			
				item.Description = varDescription;
			
				item.Url = varUrl;
			
				item.CategoryID = varCategoryID;
			
				item.UserID = varUserID;
			
				item.KickCount = varKickCount;
			
				item.SpamCount = varSpamCount;
			
				item.ViewCount = varViewCount;
			
				item.CommentCount = varCommentCount;
			
				item.IsPublishedToHomepage = varIsPublishedToHomepage;
			
				item.IsSpam = varIsSpam;
			
				item.AdsenseID = varAdsenseID;
			
				item.CreatedOn = varCreatedOn;
			
				item.PublishedOn = varPublishedOn;
			
				item.UpdatedOn = varUpdatedOn;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn StoryIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn HostIDColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn StoryIdentifierColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn TitleColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn DescriptionColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn UrlColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn CategoryIDColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[7]; }

        }

        
        
        
        public static TableSchema.TableColumn KickCountColumn
        {
            get { return Schema.Columns[8]; }

        }

        
        
        
        public static TableSchema.TableColumn SpamCountColumn
        {
            get { return Schema.Columns[9]; }

        }

        
        
        
        public static TableSchema.TableColumn ViewCountColumn
        {
            get { return Schema.Columns[10]; }

        }

        
        
        
        public static TableSchema.TableColumn CommentCountColumn
        {
            get { return Schema.Columns[11]; }

        }

        
        
        
        public static TableSchema.TableColumn IsPublishedToHomepageColumn
        {
            get { return Schema.Columns[12]; }

        }

        
        
        
        public static TableSchema.TableColumn IsSpamColumn
        {
            get { return Schema.Columns[13]; }

        }

        
        
        
        public static TableSchema.TableColumn AdsenseIDColumn
        {
            get { return Schema.Columns[14]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[15]; }

        }

        
        
        
        public static TableSchema.TableColumn PublishedOnColumn
        {
            get { return Schema.Columns[16]; }

        }

        
        
        
        public static TableSchema.TableColumn UpdatedOnColumn
        {
            get { return Schema.Columns[17]; }

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
			 public static string KickCount = @"KickCount";
			 public static string SpamCount = @"SpamCount";
			 public static string ViewCount = @"ViewCount";
			 public static string CommentCount = @"CommentCount";
			 public static string IsPublishedToHomepage = @"IsPublishedToHomepage";
			 public static string IsSpam = @"IsSpam";
			 public static string AdsenseID = @"AdsenseID";
			 public static string CreatedOn = @"CreatedOn";
			 public static string PublishedOn = @"PublishedOn";
			 public static string UpdatedOn = @"UpdatedOn";
						
		}

		#endregion
	}

}

