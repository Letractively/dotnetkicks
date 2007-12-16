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
	/// Strongly-typed collection for the Host class.
	/// </summary>
	[Serializable]
	public partial class HostCollection : ActiveList<Host, HostCollection> 
	{	   
		public HostCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Host table.
	/// </summary>
	[Serializable]
	public partial class Host : ActiveRecord<Host>
	{
		#region .ctors and Default Settings
		
		public Host()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Host(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Host(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Host(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Host", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
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
				colvarHostID.DefaultSetting = @"";
				colvarHostID.ForeignKeyTableName = "";
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
				colvarHostName.DefaultSetting = @"";
				colvarHostName.ForeignKeyTableName = "";
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
				colvarRootUrl.DefaultSetting = @"";
				colvarRootUrl.ForeignKeyTableName = "";
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
				colvarSiteTitle.DefaultSetting = @"";
				colvarSiteTitle.ForeignKeyTableName = "";
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
				colvarSiteDescription.DefaultSetting = @"";
				colvarSiteDescription.ForeignKeyTableName = "";
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
				colvarTagLine.DefaultSetting = @"";
				colvarTagLine.ForeignKeyTableName = "";
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
				
						colvarLogoPath.DefaultSetting = @"('')";
				colvarLogoPath.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLogoPath);
				
				TableSchema.TableColumn colvarCreatedOn = new TableSchema.TableColumn(schema);
				colvarCreatedOn.ColumnName = "CreatedOn";
				colvarCreatedOn.DataType = DbType.DateTime;
				colvarCreatedOn.MaxLength = 0;
				colvarCreatedOn.AutoIncrement = false;
				colvarCreatedOn.IsNullable = false;
				colvarCreatedOn.IsPrimaryKey = false;
				colvarCreatedOn.IsForeignKey = false;
				colvarCreatedOn.IsReadOnly = false;
				
						colvarCreatedOn.DefaultSetting = @"(getdate())";
				colvarCreatedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreatedOn);
				
				TableSchema.TableColumn colvarBlogUrl = new TableSchema.TableColumn(schema);
				colvarBlogUrl.ColumnName = "BlogUrl";
				colvarBlogUrl.DataType = DbType.String;
				colvarBlogUrl.MaxLength = 255;
				colvarBlogUrl.AutoIncrement = false;
				colvarBlogUrl.IsNullable = false;
				colvarBlogUrl.IsPrimaryKey = false;
				colvarBlogUrl.IsForeignKey = false;
				colvarBlogUrl.IsReadOnly = false;
				colvarBlogUrl.DefaultSetting = @"";
				colvarBlogUrl.ForeignKeyTableName = "";
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
				colvarEmail.DefaultSetting = @"";
				colvarEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmail);
				
				TableSchema.TableColumn colvarTemplate = new TableSchema.TableColumn(schema);
				colvarTemplate.ColumnName = "Template";
				colvarTemplate.DataType = DbType.String;
				colvarTemplate.MaxLength = 50;
				colvarTemplate.AutoIncrement = false;
				colvarTemplate.IsNullable = false;
				colvarTemplate.IsPrimaryKey = false;
				colvarTemplate.IsForeignKey = false;
				colvarTemplate.IsReadOnly = false;
				colvarTemplate.DefaultSetting = @"";
				colvarTemplate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTemplate);
				
				TableSchema.TableColumn colvarShowAds = new TableSchema.TableColumn(schema);
				colvarShowAds.ColumnName = "ShowAds";
				colvarShowAds.DataType = DbType.Boolean;
				colvarShowAds.MaxLength = 0;
				colvarShowAds.AutoIncrement = false;
				colvarShowAds.IsNullable = false;
				colvarShowAds.IsPrimaryKey = false;
				colvarShowAds.IsForeignKey = false;
				colvarShowAds.IsReadOnly = false;
				colvarShowAds.DefaultSetting = @"";
				colvarShowAds.ForeignKeyTableName = "";
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
				colvarCulture.DefaultSetting = @"";
				colvarCulture.ForeignKeyTableName = "";
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
				colvarUICulture.DefaultSetting = @"";
				colvarUICulture.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimumStoryAgeInHours.DefaultSetting = @"((0))";
				colvarPublish_MinimumStoryAgeInHours.ForeignKeyTableName = "";
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
				
						colvarPublish_MaximumStoryAgeInHours.DefaultSetting = @"((48))";
				colvarPublish_MaximumStoryAgeInHours.ForeignKeyTableName = "";
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
				
						colvarPublish_MaximumSimultaneousStoryPublishCount.DefaultSetting = @"((1))";
				colvarPublish_MaximumSimultaneousStoryPublishCount.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimumStoryScore.DefaultSetting = @"((50))";
				colvarPublish_MinimumStoryScore.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimumStoryKickCount.DefaultSetting = @"((5))";
				colvarPublish_MinimumStoryKickCount.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimumStoryCommentCount.DefaultSetting = @"((0))";
				colvarPublish_MinimumStoryCommentCount.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimumAverageStoryKicksPerHour.DefaultSetting = @"((0))";
				colvarPublish_MinimumAverageStoryKicksPerHour.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimunAverageCommentsPerHour.DefaultSetting = @"((0))";
				colvarPublish_MinimunAverageCommentsPerHour.ForeignKeyTableName = "";
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
				
						colvarPublish_MinimumViewCount.DefaultSetting = @"((0))";
				colvarPublish_MinimumViewCount.ForeignKeyTableName = "";
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
				
						colvarPublish_KickScore.DefaultSetting = @"((5))";
				colvarPublish_KickScore.ForeignKeyTableName = "";
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
				
						colvarPublish_CommentScore.DefaultSetting = @"((2))";
				colvarPublish_CommentScore.ForeignKeyTableName = "";
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
				
						colvarAdsenseID.DefaultSetting = @"('')";
				colvarAdsenseID.ForeignKeyTableName = "";
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
				
						colvarTrackingHtml.DefaultSetting = @"('')";
				colvarTrackingHtml.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTrackingHtml);
				
				TableSchema.TableColumn colvarAnnouncementHtml = new TableSchema.TableColumn(schema);
				colvarAnnouncementHtml.ColumnName = "AnnouncementHtml";
				colvarAnnouncementHtml.DataType = DbType.String;
				colvarAnnouncementHtml.MaxLength = 2147483647;
				colvarAnnouncementHtml.AutoIncrement = false;
				colvarAnnouncementHtml.IsNullable = true;
				colvarAnnouncementHtml.IsPrimaryKey = false;
				colvarAnnouncementHtml.IsForeignKey = false;
				colvarAnnouncementHtml.IsReadOnly = false;
				colvarAnnouncementHtml.DefaultSetting = @"";
				colvarAnnouncementHtml.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAnnouncementHtml);
				
				TableSchema.TableColumn colvarFeedBurnerMainRssFeedUrl = new TableSchema.TableColumn(schema);
				colvarFeedBurnerMainRssFeedUrl.ColumnName = "FeedBurnerMainRssFeedUrl";
				colvarFeedBurnerMainRssFeedUrl.DataType = DbType.String;
				colvarFeedBurnerMainRssFeedUrl.MaxLength = 255;
				colvarFeedBurnerMainRssFeedUrl.AutoIncrement = false;
				colvarFeedBurnerMainRssFeedUrl.IsNullable = true;
				colvarFeedBurnerMainRssFeedUrl.IsPrimaryKey = false;
				colvarFeedBurnerMainRssFeedUrl.IsForeignKey = false;
				colvarFeedBurnerMainRssFeedUrl.IsReadOnly = false;
				colvarFeedBurnerMainRssFeedUrl.DefaultSetting = @"";
				colvarFeedBurnerMainRssFeedUrl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeedBurnerMainRssFeedUrl);
				
				TableSchema.TableColumn colvarFeedBurnerMainRssFeedCountHtml = new TableSchema.TableColumn(schema);
				colvarFeedBurnerMainRssFeedCountHtml.ColumnName = "FeedBurnerMainRssFeedCountHtml";
				colvarFeedBurnerMainRssFeedCountHtml.DataType = DbType.String;
				colvarFeedBurnerMainRssFeedCountHtml.MaxLength = 500;
				colvarFeedBurnerMainRssFeedCountHtml.AutoIncrement = false;
				colvarFeedBurnerMainRssFeedCountHtml.IsNullable = true;
				colvarFeedBurnerMainRssFeedCountHtml.IsPrimaryKey = false;
				colvarFeedBurnerMainRssFeedCountHtml.IsForeignKey = false;
				colvarFeedBurnerMainRssFeedCountHtml.IsReadOnly = false;
				colvarFeedBurnerMainRssFeedCountHtml.DefaultSetting = @"";
				colvarFeedBurnerMainRssFeedCountHtml.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFeedBurnerMainRssFeedCountHtml);
				
				TableSchema.TableColumn colvarUseStaticRoot = new TableSchema.TableColumn(schema);
				colvarUseStaticRoot.ColumnName = "UseStaticRoot";
				colvarUseStaticRoot.DataType = DbType.Boolean;
				colvarUseStaticRoot.MaxLength = 0;
				colvarUseStaticRoot.AutoIncrement = false;
				colvarUseStaticRoot.IsNullable = false;
				colvarUseStaticRoot.IsPrimaryKey = false;
				colvarUseStaticRoot.IsForeignKey = false;
				colvarUseStaticRoot.IsReadOnly = false;
				
						colvarUseStaticRoot.DefaultSetting = @"((0))";
				colvarUseStaticRoot.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUseStaticRoot);
				
				TableSchema.TableColumn colvarSmtpHost = new TableSchema.TableColumn(schema);
				colvarSmtpHost.ColumnName = "SmtpHost";
				colvarSmtpHost.DataType = DbType.String;
				colvarSmtpHost.MaxLength = 255;
				colvarSmtpHost.AutoIncrement = false;
				colvarSmtpHost.IsNullable = false;
				colvarSmtpHost.IsPrimaryKey = false;
				colvarSmtpHost.IsForeignKey = false;
				colvarSmtpHost.IsReadOnly = false;
				
						colvarSmtpHost.DefaultSetting = @"('')";
				colvarSmtpHost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmtpHost);
				
				TableSchema.TableColumn colvarSmtpPort = new TableSchema.TableColumn(schema);
				colvarSmtpPort.ColumnName = "SmtpPort";
				colvarSmtpPort.DataType = DbType.Int32;
				colvarSmtpPort.MaxLength = 0;
				colvarSmtpPort.AutoIncrement = false;
				colvarSmtpPort.IsNullable = false;
				colvarSmtpPort.IsPrimaryKey = false;
				colvarSmtpPort.IsForeignKey = false;
				colvarSmtpPort.IsReadOnly = false;
				
						colvarSmtpPort.DefaultSetting = @"((25))";
				colvarSmtpPort.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmtpPort);
				
				TableSchema.TableColumn colvarSmtpUsername = new TableSchema.TableColumn(schema);
				colvarSmtpUsername.ColumnName = "SmtpUsername";
				colvarSmtpUsername.DataType = DbType.String;
				colvarSmtpUsername.MaxLength = 50;
				colvarSmtpUsername.AutoIncrement = false;
				colvarSmtpUsername.IsNullable = false;
				colvarSmtpUsername.IsPrimaryKey = false;
				colvarSmtpUsername.IsForeignKey = false;
				colvarSmtpUsername.IsReadOnly = false;
				
						colvarSmtpUsername.DefaultSetting = @"('')";
				colvarSmtpUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmtpUsername);
				
				TableSchema.TableColumn colvarSmtpPassword = new TableSchema.TableColumn(schema);
				colvarSmtpPassword.ColumnName = "SmtpPassword";
				colvarSmtpPassword.DataType = DbType.String;
				colvarSmtpPassword.MaxLength = 50;
				colvarSmtpPassword.AutoIncrement = false;
				colvarSmtpPassword.IsNullable = false;
				colvarSmtpPassword.IsPrimaryKey = false;
				colvarSmtpPassword.IsForeignKey = false;
				colvarSmtpPassword.IsReadOnly = false;
				
						colvarSmtpPassword.DefaultSetting = @"('')";
				colvarSmtpPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmtpPassword);
				
				TableSchema.TableColumn colvarSmtpEnableSsl = new TableSchema.TableColumn(schema);
				colvarSmtpEnableSsl.ColumnName = "SmtpEnableSsl";
				colvarSmtpEnableSsl.DataType = DbType.Boolean;
				colvarSmtpEnableSsl.MaxLength = 0;
				colvarSmtpEnableSsl.AutoIncrement = false;
				colvarSmtpEnableSsl.IsNullable = false;
				colvarSmtpEnableSsl.IsPrimaryKey = false;
				colvarSmtpEnableSsl.IsForeignKey = false;
				colvarSmtpEnableSsl.IsReadOnly = false;
				
						colvarSmtpEnableSsl.DefaultSetting = @"((1))";
				colvarSmtpEnableSsl.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSmtpEnableSsl);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Host",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("HostName")]
		public string HostName 
		{
			get { return GetColumnValue<string>(Columns.HostName); }

			set { SetColumnValue(Columns.HostName, value); }

		}

		  
		[XmlAttribute("RootUrl")]
		public string RootUrl 
		{
			get { return GetColumnValue<string>(Columns.RootUrl); }

			set { SetColumnValue(Columns.RootUrl, value); }

		}

		  
		[XmlAttribute("SiteTitle")]
		public string SiteTitle 
		{
			get { return GetColumnValue<string>(Columns.SiteTitle); }

			set { SetColumnValue(Columns.SiteTitle, value); }

		}

		  
		[XmlAttribute("SiteDescription")]
		public string SiteDescription 
		{
			get { return GetColumnValue<string>(Columns.SiteDescription); }

			set { SetColumnValue(Columns.SiteDescription, value); }

		}

		  
		[XmlAttribute("TagLine")]
		public string TagLine 
		{
			get { return GetColumnValue<string>(Columns.TagLine); }

			set { SetColumnValue(Columns.TagLine, value); }

		}

		  
		[XmlAttribute("LogoPath")]
		public string LogoPath 
		{
			get { return GetColumnValue<string>(Columns.LogoPath); }

			set { SetColumnValue(Columns.LogoPath, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		  
		[XmlAttribute("BlogUrl")]
		public string BlogUrl 
		{
			get { return GetColumnValue<string>(Columns.BlogUrl); }

			set { SetColumnValue(Columns.BlogUrl, value); }

		}

		  
		[XmlAttribute("Email")]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }

			set { SetColumnValue(Columns.Email, value); }

		}

		  
		[XmlAttribute("Template")]
		public string Template 
		{
			get { return GetColumnValue<string>(Columns.Template); }

			set { SetColumnValue(Columns.Template, value); }

		}

		  
		[XmlAttribute("ShowAds")]
		public bool ShowAds 
		{
			get { return GetColumnValue<bool>(Columns.ShowAds); }

			set { SetColumnValue(Columns.ShowAds, value); }

		}

		  
		[XmlAttribute("Culture")]
		public string Culture 
		{
			get { return GetColumnValue<string>(Columns.Culture); }

			set { SetColumnValue(Columns.Culture, value); }

		}

		  
		[XmlAttribute("UICulture")]
		public string UICulture 
		{
			get { return GetColumnValue<string>(Columns.UICulture); }

			set { SetColumnValue(Columns.UICulture, value); }

		}

		  
		[XmlAttribute("Publish_MinimumStoryAgeInHours")]
		public short Publish_MinimumStoryAgeInHours 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimumStoryAgeInHours); }

			set { SetColumnValue(Columns.Publish_MinimumStoryAgeInHours, value); }

		}

		  
		[XmlAttribute("Publish_MaximumStoryAgeInHours")]
		public short Publish_MaximumStoryAgeInHours 
		{
			get { return GetColumnValue<short>(Columns.Publish_MaximumStoryAgeInHours); }

			set { SetColumnValue(Columns.Publish_MaximumStoryAgeInHours, value); }

		}

		  
		[XmlAttribute("Publish_MaximumSimultaneousStoryPublishCount")]
		public short Publish_MaximumSimultaneousStoryPublishCount 
		{
			get { return GetColumnValue<short>(Columns.Publish_MaximumSimultaneousStoryPublishCount); }

			set { SetColumnValue(Columns.Publish_MaximumSimultaneousStoryPublishCount, value); }

		}

		  
		[XmlAttribute("Publish_MinimumStoryScore")]
		public short Publish_MinimumStoryScore 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimumStoryScore); }

			set { SetColumnValue(Columns.Publish_MinimumStoryScore, value); }

		}

		  
		[XmlAttribute("Publish_MinimumStoryKickCount")]
		public short Publish_MinimumStoryKickCount 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimumStoryKickCount); }

			set { SetColumnValue(Columns.Publish_MinimumStoryKickCount, value); }

		}

		  
		[XmlAttribute("Publish_MinimumStoryCommentCount")]
		public short Publish_MinimumStoryCommentCount 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimumStoryCommentCount); }

			set { SetColumnValue(Columns.Publish_MinimumStoryCommentCount, value); }

		}

		  
		[XmlAttribute("Publish_MinimumAverageStoryKicksPerHour")]
		public short Publish_MinimumAverageStoryKicksPerHour 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimumAverageStoryKicksPerHour); }

			set { SetColumnValue(Columns.Publish_MinimumAverageStoryKicksPerHour, value); }

		}

		  
		[XmlAttribute("Publish_MinimunAverageCommentsPerHour")]
		public short Publish_MinimunAverageCommentsPerHour 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimunAverageCommentsPerHour); }

			set { SetColumnValue(Columns.Publish_MinimunAverageCommentsPerHour, value); }

		}

		  
		[XmlAttribute("Publish_MinimumViewCount")]
		public short Publish_MinimumViewCount 
		{
			get { return GetColumnValue<short>(Columns.Publish_MinimumViewCount); }

			set { SetColumnValue(Columns.Publish_MinimumViewCount, value); }

		}

		  
		[XmlAttribute("Publish_KickScore")]
		public short Publish_KickScore 
		{
			get { return GetColumnValue<short>(Columns.Publish_KickScore); }

			set { SetColumnValue(Columns.Publish_KickScore, value); }

		}

		  
		[XmlAttribute("Publish_CommentScore")]
		public short Publish_CommentScore 
		{
			get { return GetColumnValue<short>(Columns.Publish_CommentScore); }

			set { SetColumnValue(Columns.Publish_CommentScore, value); }

		}

		  
		[XmlAttribute("AdsenseID")]
		public string AdsenseID 
		{
			get { return GetColumnValue<string>(Columns.AdsenseID); }

			set { SetColumnValue(Columns.AdsenseID, value); }

		}

		  
		[XmlAttribute("TrackingHtml")]
		public string TrackingHtml 
		{
			get { return GetColumnValue<string>(Columns.TrackingHtml); }

			set { SetColumnValue(Columns.TrackingHtml, value); }

		}

		  
		[XmlAttribute("AnnouncementHtml")]
		public string AnnouncementHtml 
		{
			get { return GetColumnValue<string>(Columns.AnnouncementHtml); }

			set { SetColumnValue(Columns.AnnouncementHtml, value); }

		}

		  
		[XmlAttribute("FeedBurnerMainRssFeedUrl")]
		public string FeedBurnerMainRssFeedUrl 
		{
			get { return GetColumnValue<string>(Columns.FeedBurnerMainRssFeedUrl); }

			set { SetColumnValue(Columns.FeedBurnerMainRssFeedUrl, value); }

		}

		  
		[XmlAttribute("FeedBurnerMainRssFeedCountHtml")]
		public string FeedBurnerMainRssFeedCountHtml 
		{
			get { return GetColumnValue<string>(Columns.FeedBurnerMainRssFeedCountHtml); }

			set { SetColumnValue(Columns.FeedBurnerMainRssFeedCountHtml, value); }

		}

		  
		[XmlAttribute("UseStaticRoot")]
		public bool UseStaticRoot 
		{
			get { return GetColumnValue<bool>(Columns.UseStaticRoot); }

			set { SetColumnValue(Columns.UseStaticRoot, value); }

		}

		  
		[XmlAttribute("SmtpHost")]
		public string SmtpHost 
		{
			get { return GetColumnValue<string>(Columns.SmtpHost); }

			set { SetColumnValue(Columns.SmtpHost, value); }

		}

		  
		[XmlAttribute("SmtpPort")]
		public int SmtpPort 
		{
			get { return GetColumnValue<int>(Columns.SmtpPort); }

			set { SetColumnValue(Columns.SmtpPort, value); }

		}

		  
		[XmlAttribute("SmtpUsername")]
		public string SmtpUsername 
		{
			get { return GetColumnValue<string>(Columns.SmtpUsername); }

			set { SetColumnValue(Columns.SmtpUsername, value); }

		}

		  
		[XmlAttribute("SmtpPassword")]
		public string SmtpPassword 
		{
			get { return GetColumnValue<string>(Columns.SmtpPassword); }

			set { SetColumnValue(Columns.SmtpPassword, value); }

		}

		  
		[XmlAttribute("SmtpEnableSsl")]
		public bool SmtpEnableSsl 
		{
			get { return GetColumnValue<bool>(Columns.SmtpEnableSsl); }

			set { SetColumnValue(Columns.SmtpEnableSsl, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.BannedUrlPatternCollection colBannedUrlPatternRecords;
		public Incremental.Kick.Dal.BannedUrlPatternCollection BannedUrlPatternRecords()
		{
			if(colBannedUrlPatternRecords == null)
				colBannedUrlPatternRecords = new Incremental.Kick.Dal.BannedUrlPatternCollection().Where(BannedUrlPattern.Columns.HostId, HostID).Load();
			return colBannedUrlPatternRecords;
		}

		private Incremental.Kick.Dal.CategoryCollection colCategoryRecords;
		public Incremental.Kick.Dal.CategoryCollection CategoryRecords()
		{
			if(colCategoryRecords == null)
				colCategoryRecords = new Incremental.Kick.Dal.CategoryCollection().Where(Category.Columns.HostID, HostID).Load();
			return colCategoryRecords;
		}

		private Incremental.Kick.Dal.ShoutCollection colShoutRecords;
		public Incremental.Kick.Dal.ShoutCollection ShoutRecords()
		{
			if(colShoutRecords == null)
				colShoutRecords = new Incremental.Kick.Dal.ShoutCollection().Where(Shout.Columns.HostID, HostID).Load();
			return colShoutRecords;
		}

		private Incremental.Kick.Dal.StoryCollection colStoryRecords;
		public Incremental.Kick.Dal.StoryCollection StoryRecords()
		{
			if(colStoryRecords == null)
				colStoryRecords = new Incremental.Kick.Dal.StoryCollection().Where(Story.Columns.HostID, HostID).Load();
			return colStoryRecords;
		}

		private Incremental.Kick.Dal.StoryUserHostTagCollection colStoryUserHostTagRecords;
		public Incremental.Kick.Dal.StoryUserHostTagCollection StoryUserHostTagRecords()
		{
			if(colStoryUserHostTagRecords == null)
				colStoryUserHostTagRecords = new Incremental.Kick.Dal.StoryUserHostTagCollection().Where(StoryUserHostTag.Columns.HostID, HostID).Load();
			return colStoryUserHostTagRecords;
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varHostName,string varRootUrl,string varSiteTitle,string varSiteDescription,string varTagLine,string varLogoPath,DateTime varCreatedOn,string varBlogUrl,string varEmail,string varTemplate,bool varShowAds,string varCulture,string varUICulture,short varPublish_MinimumStoryAgeInHours,short varPublish_MaximumStoryAgeInHours,short varPublish_MaximumSimultaneousStoryPublishCount,short varPublish_MinimumStoryScore,short varPublish_MinimumStoryKickCount,short varPublish_MinimumStoryCommentCount,short varPublish_MinimumAverageStoryKicksPerHour,short varPublish_MinimunAverageCommentsPerHour,short varPublish_MinimumViewCount,short varPublish_KickScore,short varPublish_CommentScore,string varAdsenseID,string varTrackingHtml,string varAnnouncementHtml,string varFeedBurnerMainRssFeedUrl,string varFeedBurnerMainRssFeedCountHtml,bool varUseStaticRoot,string varSmtpHost,int varSmtpPort,string varSmtpUsername,string varSmtpPassword,bool varSmtpEnableSsl)
		{
			Host item = new Host();
			
			item.HostName = varHostName;
			
			item.RootUrl = varRootUrl;
			
			item.SiteTitle = varSiteTitle;
			
			item.SiteDescription = varSiteDescription;
			
			item.TagLine = varTagLine;
			
			item.LogoPath = varLogoPath;
			
			item.CreatedOn = varCreatedOn;
			
			item.BlogUrl = varBlogUrl;
			
			item.Email = varEmail;
			
			item.Template = varTemplate;
			
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
			
			item.AnnouncementHtml = varAnnouncementHtml;
			
			item.FeedBurnerMainRssFeedUrl = varFeedBurnerMainRssFeedUrl;
			
			item.FeedBurnerMainRssFeedCountHtml = varFeedBurnerMainRssFeedCountHtml;
			
			item.UseStaticRoot = varUseStaticRoot;
			
			item.SmtpHost = varSmtpHost;
			
			item.SmtpPort = varSmtpPort;
			
			item.SmtpUsername = varSmtpUsername;
			
			item.SmtpPassword = varSmtpPassword;
			
			item.SmtpEnableSsl = varSmtpEnableSsl;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varHostID,string varHostName,string varRootUrl,string varSiteTitle,string varSiteDescription,string varTagLine,string varLogoPath,DateTime varCreatedOn,string varBlogUrl,string varEmail,string varTemplate,bool varShowAds,string varCulture,string varUICulture,short varPublish_MinimumStoryAgeInHours,short varPublish_MaximumStoryAgeInHours,short varPublish_MaximumSimultaneousStoryPublishCount,short varPublish_MinimumStoryScore,short varPublish_MinimumStoryKickCount,short varPublish_MinimumStoryCommentCount,short varPublish_MinimumAverageStoryKicksPerHour,short varPublish_MinimunAverageCommentsPerHour,short varPublish_MinimumViewCount,short varPublish_KickScore,short varPublish_CommentScore,string varAdsenseID,string varTrackingHtml,string varAnnouncementHtml,string varFeedBurnerMainRssFeedUrl,string varFeedBurnerMainRssFeedCountHtml,bool varUseStaticRoot,string varSmtpHost,int varSmtpPort,string varSmtpUsername,string varSmtpPassword,bool varSmtpEnableSsl)
		{
			Host item = new Host();
			
				item.HostID = varHostID;
			
				item.HostName = varHostName;
			
				item.RootUrl = varRootUrl;
			
				item.SiteTitle = varSiteTitle;
			
				item.SiteDescription = varSiteDescription;
			
				item.TagLine = varTagLine;
			
				item.LogoPath = varLogoPath;
			
				item.CreatedOn = varCreatedOn;
			
				item.BlogUrl = varBlogUrl;
			
				item.Email = varEmail;
			
				item.Template = varTemplate;
			
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
			
				item.AnnouncementHtml = varAnnouncementHtml;
			
				item.FeedBurnerMainRssFeedUrl = varFeedBurnerMainRssFeedUrl;
			
				item.FeedBurnerMainRssFeedCountHtml = varFeedBurnerMainRssFeedCountHtml;
			
				item.UseStaticRoot = varUseStaticRoot;
			
				item.SmtpHost = varSmtpHost;
			
				item.SmtpPort = varSmtpPort;
			
				item.SmtpUsername = varSmtpUsername;
			
				item.SmtpPassword = varSmtpPassword;
			
				item.SmtpEnableSsl = varSmtpEnableSsl;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn HostIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn HostNameColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn RootUrlColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn SiteTitleColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn SiteDescriptionColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn TagLineColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn LogoPathColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[7]; }

        }

        
        
        
        public static TableSchema.TableColumn BlogUrlColumn
        {
            get { return Schema.Columns[8]; }

        }

        
        
        
        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[9]; }

        }

        
        
        
        public static TableSchema.TableColumn TemplateColumn
        {
            get { return Schema.Columns[10]; }

        }

        
        
        
        public static TableSchema.TableColumn ShowAdsColumn
        {
            get { return Schema.Columns[11]; }

        }

        
        
        
        public static TableSchema.TableColumn CultureColumn
        {
            get { return Schema.Columns[12]; }

        }

        
        
        
        public static TableSchema.TableColumn UICultureColumn
        {
            get { return Schema.Columns[13]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimumStoryAgeInHoursColumn
        {
            get { return Schema.Columns[14]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MaximumStoryAgeInHoursColumn
        {
            get { return Schema.Columns[15]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MaximumSimultaneousStoryPublishCountColumn
        {
            get { return Schema.Columns[16]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimumStoryScoreColumn
        {
            get { return Schema.Columns[17]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimumStoryKickCountColumn
        {
            get { return Schema.Columns[18]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimumStoryCommentCountColumn
        {
            get { return Schema.Columns[19]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimumAverageStoryKicksPerHourColumn
        {
            get { return Schema.Columns[20]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimunAverageCommentsPerHourColumn
        {
            get { return Schema.Columns[21]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_MinimumViewCountColumn
        {
            get { return Schema.Columns[22]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_KickScoreColumn
        {
            get { return Schema.Columns[23]; }

        }

        
        
        
        public static TableSchema.TableColumn Publish_CommentScoreColumn
        {
            get { return Schema.Columns[24]; }

        }

        
        
        
        public static TableSchema.TableColumn AdsenseIDColumn
        {
            get { return Schema.Columns[25]; }

        }

        
        
        
        public static TableSchema.TableColumn TrackingHtmlColumn
        {
            get { return Schema.Columns[26]; }

        }

        
        
        
        public static TableSchema.TableColumn AnnouncementHtmlColumn
        {
            get { return Schema.Columns[27]; }

        }

        
        
        
        public static TableSchema.TableColumn FeedBurnerMainRssFeedUrlColumn
        {
            get { return Schema.Columns[28]; }

        }

        
        
        
        public static TableSchema.TableColumn FeedBurnerMainRssFeedCountHtmlColumn
        {
            get { return Schema.Columns[29]; }

        }

        
        
        
        public static TableSchema.TableColumn UseStaticRootColumn
        {
            get { return Schema.Columns[30]; }

        }

        
        
        
        public static TableSchema.TableColumn SmtpHostColumn
        {
            get { return Schema.Columns[31]; }

        }

        
        
        
        public static TableSchema.TableColumn SmtpPortColumn
        {
            get { return Schema.Columns[32]; }

        }

        
        
        
        public static TableSchema.TableColumn SmtpUsernameColumn
        {
            get { return Schema.Columns[33]; }

        }

        
        
        
        public static TableSchema.TableColumn SmtpPasswordColumn
        {
            get { return Schema.Columns[34]; }

        }

        
        
        
        public static TableSchema.TableColumn SmtpEnableSslColumn
        {
            get { return Schema.Columns[35]; }

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
			 public static string CreatedOn = @"CreatedOn";
			 public static string BlogUrl = @"BlogUrl";
			 public static string Email = @"Email";
			 public static string Template = @"Template";
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
			 public static string AnnouncementHtml = @"AnnouncementHtml";
			 public static string FeedBurnerMainRssFeedUrl = @"FeedBurnerMainRssFeedUrl";
			 public static string FeedBurnerMainRssFeedCountHtml = @"FeedBurnerMainRssFeedCountHtml";
			 public static string UseStaticRoot = @"UseStaticRoot";
			 public static string SmtpHost = @"SmtpHost";
			 public static string SmtpPort = @"SmtpPort";
			 public static string SmtpUsername = @"SmtpUsername";
			 public static string SmtpPassword = @"SmtpPassword";
			 public static string SmtpEnableSsl = @"SmtpEnableSsl";
						
		}

		#endregion
	}

}

