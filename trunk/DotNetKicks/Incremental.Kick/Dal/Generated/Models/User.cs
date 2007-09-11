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
	/// Strongly-typed collection for the User class.
	/// </summary>
	[Serializable]
	public partial class UserCollection : ActiveList<User, UserCollection> 
	{	   
		public UserCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_User table.
	/// </summary>
	[Serializable]
	public partial class User : ActiveRecord<User>
	{
		#region .ctors and Default Settings
		
		public User()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public User(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public User(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public User(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_User", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = true;
				colvarUserID.IsNullable = false;
				colvarUserID.IsPrimaryKey = true;
				colvarUserID.IsForeignKey = false;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				colvarUserID.ForeignKeyTableName = "";
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
				colvarUsername.DefaultSetting = @"";
				colvarUsername.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUsername);
				
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
				
				TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
				colvarPassword.ColumnName = "Password";
				colvarPassword.DataType = DbType.String;
				colvarPassword.MaxLength = 50;
				colvarPassword.AutoIncrement = false;
				colvarPassword.IsNullable = false;
				colvarPassword.IsPrimaryKey = false;
				colvarPassword.IsForeignKey = false;
				colvarPassword.IsReadOnly = false;
				colvarPassword.DefaultSetting = @"";
				colvarPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPassword);
				
				TableSchema.TableColumn colvarPasswordSalt = new TableSchema.TableColumn(schema);
				colvarPasswordSalt.ColumnName = "PasswordSalt";
				colvarPasswordSalt.DataType = DbType.String;
				colvarPasswordSalt.MaxLength = 50;
				colvarPasswordSalt.AutoIncrement = false;
				colvarPasswordSalt.IsNullable = false;
				colvarPasswordSalt.IsPrimaryKey = false;
				colvarPasswordSalt.IsForeignKey = false;
				colvarPasswordSalt.IsReadOnly = false;
				colvarPasswordSalt.DefaultSetting = @"";
				colvarPasswordSalt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPasswordSalt);
				
				TableSchema.TableColumn colvarIsGeneratedPassword = new TableSchema.TableColumn(schema);
				colvarIsGeneratedPassword.ColumnName = "IsGeneratedPassword";
				colvarIsGeneratedPassword.DataType = DbType.Boolean;
				colvarIsGeneratedPassword.MaxLength = 0;
				colvarIsGeneratedPassword.AutoIncrement = false;
				colvarIsGeneratedPassword.IsNullable = false;
				colvarIsGeneratedPassword.IsPrimaryKey = false;
				colvarIsGeneratedPassword.IsForeignKey = false;
				colvarIsGeneratedPassword.IsReadOnly = false;
				
						colvarIsGeneratedPassword.DefaultSetting = @"((1))";
				colvarIsGeneratedPassword.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsGeneratedPassword);
				
				TableSchema.TableColumn colvarIsValidated = new TableSchema.TableColumn(schema);
				colvarIsValidated.ColumnName = "IsValidated";
				colvarIsValidated.DataType = DbType.Boolean;
				colvarIsValidated.MaxLength = 0;
				colvarIsValidated.AutoIncrement = false;
				colvarIsValidated.IsNullable = false;
				colvarIsValidated.IsPrimaryKey = false;
				colvarIsValidated.IsForeignKey = false;
				colvarIsValidated.IsReadOnly = false;
				colvarIsValidated.DefaultSetting = @"";
				colvarIsValidated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsValidated);
				
				TableSchema.TableColumn colvarIsBanned = new TableSchema.TableColumn(schema);
				colvarIsBanned.ColumnName = "IsBanned";
				colvarIsBanned.DataType = DbType.Boolean;
				colvarIsBanned.MaxLength = 0;
				colvarIsBanned.AutoIncrement = false;
				colvarIsBanned.IsNullable = false;
				colvarIsBanned.IsPrimaryKey = false;
				colvarIsBanned.IsForeignKey = false;
				colvarIsBanned.IsReadOnly = false;
				colvarIsBanned.DefaultSetting = @"";
				colvarIsBanned.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsBanned);
				
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
				
				TableSchema.TableColumn colvarReceiveEmailNewsletter = new TableSchema.TableColumn(schema);
				colvarReceiveEmailNewsletter.ColumnName = "ReceiveEmailNewsletter";
				colvarReceiveEmailNewsletter.DataType = DbType.Boolean;
				colvarReceiveEmailNewsletter.MaxLength = 0;
				colvarReceiveEmailNewsletter.AutoIncrement = false;
				colvarReceiveEmailNewsletter.IsNullable = false;
				colvarReceiveEmailNewsletter.IsPrimaryKey = false;
				colvarReceiveEmailNewsletter.IsForeignKey = false;
				colvarReceiveEmailNewsletter.IsReadOnly = false;
				
						colvarReceiveEmailNewsletter.DefaultSetting = @"((1))";
				colvarReceiveEmailNewsletter.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReceiveEmailNewsletter);
				
				TableSchema.TableColumn colvarRoles = new TableSchema.TableColumn(schema);
				colvarRoles.ColumnName = "Roles";
				colvarRoles.DataType = DbType.String;
				colvarRoles.MaxLength = 100;
				colvarRoles.AutoIncrement = false;
				colvarRoles.IsNullable = false;
				colvarRoles.IsPrimaryKey = false;
				colvarRoles.IsForeignKey = false;
				colvarRoles.IsReadOnly = false;
				colvarRoles.DefaultSetting = @"";
				colvarRoles.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRoles);
				
				TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(schema);
				colvarHostID.ColumnName = "HostID";
				colvarHostID.DataType = DbType.Int32;
				colvarHostID.MaxLength = 0;
				colvarHostID.AutoIncrement = false;
				colvarHostID.IsNullable = false;
				colvarHostID.IsPrimaryKey = false;
				colvarHostID.IsForeignKey = false;
				colvarHostID.IsReadOnly = false;
				colvarHostID.DefaultSetting = @"";
				colvarHostID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostID);
				
				TableSchema.TableColumn colvarLastActiveOn = new TableSchema.TableColumn(schema);
				colvarLastActiveOn.ColumnName = "LastActiveOn";
				colvarLastActiveOn.DataType = DbType.DateTime;
				colvarLastActiveOn.MaxLength = 0;
				colvarLastActiveOn.AutoIncrement = false;
				colvarLastActiveOn.IsNullable = false;
				colvarLastActiveOn.IsPrimaryKey = false;
				colvarLastActiveOn.IsForeignKey = false;
				colvarLastActiveOn.IsReadOnly = false;
				colvarLastActiveOn.DefaultSetting = @"";
				colvarLastActiveOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastActiveOn);
				
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
				
				TableSchema.TableColumn colvarModifiedOn = new TableSchema.TableColumn(schema);
				colvarModifiedOn.ColumnName = "ModifiedOn";
				colvarModifiedOn.DataType = DbType.DateTime;
				colvarModifiedOn.MaxLength = 0;
				colvarModifiedOn.AutoIncrement = false;
				colvarModifiedOn.IsNullable = false;
				colvarModifiedOn.IsPrimaryKey = false;
				colvarModifiedOn.IsForeignKey = false;
				colvarModifiedOn.IsReadOnly = false;
				colvarModifiedOn.DefaultSetting = @"";
				colvarModifiedOn.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedOn);
				
				TableSchema.TableColumn colvarLocation = new TableSchema.TableColumn(schema);
				colvarLocation.ColumnName = "Location";
				colvarLocation.DataType = DbType.String;
				colvarLocation.MaxLength = 255;
				colvarLocation.AutoIncrement = false;
				colvarLocation.IsNullable = true;
				colvarLocation.IsPrimaryKey = false;
				colvarLocation.IsForeignKey = false;
				colvarLocation.IsReadOnly = false;
				colvarLocation.DefaultSetting = @"";
				colvarLocation.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocation);
				
				TableSchema.TableColumn colvarUseGravatar = new TableSchema.TableColumn(schema);
				colvarUseGravatar.ColumnName = "UseGravatar";
				colvarUseGravatar.DataType = DbType.Boolean;
				colvarUseGravatar.MaxLength = 0;
				colvarUseGravatar.AutoIncrement = false;
				colvarUseGravatar.IsNullable = false;
				colvarUseGravatar.IsPrimaryKey = false;
				colvarUseGravatar.IsForeignKey = false;
				colvarUseGravatar.IsReadOnly = false;
				
						colvarUseGravatar.DefaultSetting = @"((0))";
				colvarUseGravatar.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUseGravatar);
				
				TableSchema.TableColumn colvarGravatarCustomEmail = new TableSchema.TableColumn(schema);
				colvarGravatarCustomEmail.ColumnName = "GravatarCustomEmail";
				colvarGravatarCustomEmail.DataType = DbType.String;
				colvarGravatarCustomEmail.MaxLength = 255;
				colvarGravatarCustomEmail.AutoIncrement = false;
				colvarGravatarCustomEmail.IsNullable = true;
				colvarGravatarCustomEmail.IsPrimaryKey = false;
				colvarGravatarCustomEmail.IsForeignKey = false;
				colvarGravatarCustomEmail.IsReadOnly = false;
				colvarGravatarCustomEmail.DefaultSetting = @"";
				colvarGravatarCustomEmail.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGravatarCustomEmail);
				
				TableSchema.TableColumn colvarWebsiteURL = new TableSchema.TableColumn(schema);
				colvarWebsiteURL.ColumnName = "WebsiteURL";
				colvarWebsiteURL.DataType = DbType.String;
				colvarWebsiteURL.MaxLength = 1000;
				colvarWebsiteURL.AutoIncrement = false;
				colvarWebsiteURL.IsNullable = true;
				colvarWebsiteURL.IsPrimaryKey = false;
				colvarWebsiteURL.IsForeignKey = false;
				colvarWebsiteURL.IsReadOnly = false;
				colvarWebsiteURL.DefaultSetting = @"";
				colvarWebsiteURL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarWebsiteURL);
				
				TableSchema.TableColumn colvarBlogURL = new TableSchema.TableColumn(schema);
				colvarBlogURL.ColumnName = "BlogURL";
				colvarBlogURL.DataType = DbType.String;
				colvarBlogURL.MaxLength = 1000;
				colvarBlogURL.AutoIncrement = false;
				colvarBlogURL.IsNullable = true;
				colvarBlogURL.IsPrimaryKey = false;
				colvarBlogURL.IsForeignKey = false;
				colvarBlogURL.IsReadOnly = false;
				colvarBlogURL.DefaultSetting = @"";
				colvarBlogURL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBlogURL);
				
				TableSchema.TableColumn colvarBlogFeedURL = new TableSchema.TableColumn(schema);
				colvarBlogFeedURL.ColumnName = "BlogFeedURL";
				colvarBlogFeedURL.DataType = DbType.String;
				colvarBlogFeedURL.MaxLength = 1000;
				colvarBlogFeedURL.AutoIncrement = false;
				colvarBlogFeedURL.IsNullable = true;
				colvarBlogFeedURL.IsPrimaryKey = false;
				colvarBlogFeedURL.IsForeignKey = false;
				colvarBlogFeedURL.IsReadOnly = false;
				colvarBlogFeedURL.DefaultSetting = @"";
				colvarBlogFeedURL.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBlogFeedURL);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_User",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UserID")]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("Username")]
		public string Username 
		{
			get { return GetColumnValue<string>(Columns.Username); }

			set { SetColumnValue(Columns.Username, value); }

		}

		  
		[XmlAttribute("Email")]
		public string Email 
		{
			get { return GetColumnValue<string>(Columns.Email); }

			set { SetColumnValue(Columns.Email, value); }

		}

		  
		[XmlAttribute("Password")]
		public string Password 
		{
			get { return GetColumnValue<string>(Columns.Password); }

			set { SetColumnValue(Columns.Password, value); }

		}

		  
		[XmlAttribute("PasswordSalt")]
		public string PasswordSalt 
		{
			get { return GetColumnValue<string>(Columns.PasswordSalt); }

			set { SetColumnValue(Columns.PasswordSalt, value); }

		}

		  
		[XmlAttribute("IsGeneratedPassword")]
		public bool IsGeneratedPassword 
		{
			get { return GetColumnValue<bool>(Columns.IsGeneratedPassword); }

			set { SetColumnValue(Columns.IsGeneratedPassword, value); }

		}

		  
		[XmlAttribute("IsValidated")]
		public bool IsValidated 
		{
			get { return GetColumnValue<bool>(Columns.IsValidated); }

			set { SetColumnValue(Columns.IsValidated, value); }

		}

		  
		[XmlAttribute("IsBanned")]
		public bool IsBanned 
		{
			get { return GetColumnValue<bool>(Columns.IsBanned); }

			set { SetColumnValue(Columns.IsBanned, value); }

		}

		  
		[XmlAttribute("AdsenseID")]
		public string AdsenseID 
		{
			get { return GetColumnValue<string>(Columns.AdsenseID); }

			set { SetColumnValue(Columns.AdsenseID, value); }

		}

		  
		[XmlAttribute("ReceiveEmailNewsletter")]
		public bool ReceiveEmailNewsletter 
		{
			get { return GetColumnValue<bool>(Columns.ReceiveEmailNewsletter); }

			set { SetColumnValue(Columns.ReceiveEmailNewsletter, value); }

		}

		  
		[XmlAttribute("Roles")]
		public string Roles 
		{
			get { return GetColumnValue<string>(Columns.Roles); }

			set { SetColumnValue(Columns.Roles, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("LastActiveOn")]
		public DateTime LastActiveOn 
		{
			get { return GetColumnValue<DateTime>(Columns.LastActiveOn); }

			set { SetColumnValue(Columns.LastActiveOn, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		  
		[XmlAttribute("ModifiedOn")]
		public DateTime ModifiedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedOn); }

			set { SetColumnValue(Columns.ModifiedOn, value); }

		}

		  
		[XmlAttribute("Location")]
		public string Location 
		{
			get { return GetColumnValue<string>(Columns.Location); }

			set { SetColumnValue(Columns.Location, value); }

		}

		  
		[XmlAttribute("UseGravatar")]
		public bool UseGravatar 
		{
			get { return GetColumnValue<bool>(Columns.UseGravatar); }

			set { SetColumnValue(Columns.UseGravatar, value); }

		}

		  
		[XmlAttribute("GravatarCustomEmail")]
		public string GravatarCustomEmail 
		{
			get { return GetColumnValue<string>(Columns.GravatarCustomEmail); }

			set { SetColumnValue(Columns.GravatarCustomEmail, value); }

		}

		  
		[XmlAttribute("WebsiteURL")]
		public string WebsiteURL 
		{
			get { return GetColumnValue<string>(Columns.WebsiteURL); }

			set { SetColumnValue(Columns.WebsiteURL, value); }

		}

		  
		[XmlAttribute("BlogURL")]
		public string BlogURL 
		{
			get { return GetColumnValue<string>(Columns.BlogURL); }

			set { SetColumnValue(Columns.BlogURL, value); }

		}

		  
		[XmlAttribute("BlogFeedURL")]
		public string BlogFeedURL 
		{
			get { return GetColumnValue<string>(Columns.BlogFeedURL); }

			set { SetColumnValue(Columns.BlogFeedURL, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		private Incremental.Kick.Dal.CommentCollection colCommentRecords;
		public Incremental.Kick.Dal.CommentCollection CommentRecords()
		{
			if(colCommentRecords == null)
				colCommentRecords = new Incremental.Kick.Dal.CommentCollection().Where(Comment.Columns.UserID, UserID).Load();
			return colCommentRecords;
		}

		private Incremental.Kick.Dal.StoryCollection colStoryRecords;
		public Incremental.Kick.Dal.StoryCollection StoryRecords()
		{
			if(colStoryRecords == null)
				colStoryRecords = new Incremental.Kick.Dal.StoryCollection().Where(Story.Columns.UserID, UserID).Load();
			return colStoryRecords;
		}

		private Incremental.Kick.Dal.StoryKickCollection colStoryKickRecords;
		public Incremental.Kick.Dal.StoryKickCollection StoryKickRecords()
		{
			if(colStoryKickRecords == null)
				colStoryKickRecords = new Incremental.Kick.Dal.StoryKickCollection().Where(StoryKick.Columns.UserID, UserID).Load();
			return colStoryKickRecords;
		}

		private Incremental.Kick.Dal.StoryUserHostTagCollection colStoryUserHostTagRecords;
		public Incremental.Kick.Dal.StoryUserHostTagCollection StoryUserHostTagRecords()
		{
			if(colStoryUserHostTagRecords == null)
				colStoryUserHostTagRecords = new Incremental.Kick.Dal.StoryUserHostTagCollection().Where(StoryUserHostTag.Columns.UserID, UserID).Load();
			return colStoryUserHostTagRecords;
		}

		private Incremental.Kick.Dal.UserFriendCollection colUserFriendRecords;
		public Incremental.Kick.Dal.UserFriendCollection UserFriendRecords()
		{
			if(colUserFriendRecords == null)
				colUserFriendRecords = new Incremental.Kick.Dal.UserFriendCollection().Where(UserFriend.Columns.FriendID, UserID).Load();
			return colUserFriendRecords;
		}

		private Incremental.Kick.Dal.UserFriendCollection colUserFriendRecordsFromUser;
		public Incremental.Kick.Dal.UserFriendCollection UserFriendRecordsFromUser()
		{
			if(colUserFriendRecordsFromUser == null)
				colUserFriendRecordsFromUser = new Incremental.Kick.Dal.UserFriendCollection().Where(UserFriend.Columns.UserID, UserID).Load();
			return colUserFriendRecordsFromUser;
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUsername,string varEmail,string varPassword,string varPasswordSalt,bool varIsGeneratedPassword,bool varIsValidated,bool varIsBanned,string varAdsenseID,bool varReceiveEmailNewsletter,string varRoles,int varHostID,DateTime varLastActiveOn,DateTime varCreatedOn,DateTime varModifiedOn,string varLocation,bool varUseGravatar,string varGravatarCustomEmail,string varWebsiteURL,string varBlogURL,string varBlogFeedURL)
		{
			User item = new User();
			
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
			
			item.CreatedOn = varCreatedOn;
			
			item.ModifiedOn = varModifiedOn;
			
			item.Location = varLocation;
			
			item.UseGravatar = varUseGravatar;
			
			item.GravatarCustomEmail = varGravatarCustomEmail;
			
			item.WebsiteURL = varWebsiteURL;
			
			item.BlogURL = varBlogURL;
			
			item.BlogFeedURL = varBlogFeedURL;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varUserID,string varUsername,string varEmail,string varPassword,string varPasswordSalt,bool varIsGeneratedPassword,bool varIsValidated,bool varIsBanned,string varAdsenseID,bool varReceiveEmailNewsletter,string varRoles,int varHostID,DateTime varLastActiveOn,DateTime varCreatedOn,DateTime varModifiedOn,string varLocation,bool varUseGravatar,string varGravatarCustomEmail,string varWebsiteURL,string varBlogURL,string varBlogFeedURL)
		{
			User item = new User();
			
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
			
				item.CreatedOn = varCreatedOn;
			
				item.ModifiedOn = varModifiedOn;
			
				item.Location = varLocation;
			
				item.UseGravatar = varUseGravatar;
			
				item.GravatarCustomEmail = varGravatarCustomEmail;
			
				item.WebsiteURL = varWebsiteURL;
			
				item.BlogURL = varBlogURL;
			
				item.BlogFeedURL = varBlogFeedURL;
			
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
			 public static string Location = @"Location";
			 public static string UseGravatar = @"UseGravatar";
			 public static string GravatarCustomEmail = @"GravatarCustomEmail";
			 public static string WebsiteURL = @"WebsiteURL";
			 public static string BlogURL = @"BlogURL";
			 public static string BlogFeedURL = @"BlogFeedURL";
						
		}

		#endregion
	}

}

