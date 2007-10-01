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
	/// Strongly-typed collection for the Comment class.
	/// </summary>
	[Serializable]
	public partial class CommentCollection : ActiveList<Comment, CommentCollection> 
	{	   
		public CommentCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Kick_Comment table.
	/// </summary>
	[Serializable]
	public partial class Comment : ActiveRecord<Comment>
	{
		#region .ctors and Default Settings
		
		public Comment()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Comment(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Comment(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Comment(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Kick_Comment", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarCommentID = new TableSchema.TableColumn(schema);
				colvarCommentID.ColumnName = "CommentID";
				colvarCommentID.DataType = DbType.Int32;
				colvarCommentID.MaxLength = 0;
				colvarCommentID.AutoIncrement = true;
				colvarCommentID.IsNullable = false;
				colvarCommentID.IsPrimaryKey = true;
				colvarCommentID.IsForeignKey = false;
				colvarCommentID.IsReadOnly = false;
				colvarCommentID.DefaultSetting = @"";
				colvarCommentID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommentID);
				
				TableSchema.TableColumn colvarStoryID = new TableSchema.TableColumn(schema);
				colvarStoryID.ColumnName = "StoryID";
				colvarStoryID.DataType = DbType.Int32;
				colvarStoryID.MaxLength = 0;
				colvarStoryID.AutoIncrement = false;
				colvarStoryID.IsNullable = false;
				colvarStoryID.IsPrimaryKey = false;
				colvarStoryID.IsForeignKey = true;
				colvarStoryID.IsReadOnly = false;
				colvarStoryID.DefaultSetting = @"";
				
					colvarStoryID.ForeignKeyTableName = "Kick_Story";
				schema.Columns.Add(colvarStoryID);
				
				TableSchema.TableColumn colvarUserID = new TableSchema.TableColumn(schema);
				colvarUserID.ColumnName = "UserID";
				colvarUserID.DataType = DbType.Int32;
				colvarUserID.MaxLength = 0;
				colvarUserID.AutoIncrement = false;
				colvarUserID.IsNullable = false;
				colvarUserID.IsPrimaryKey = false;
				colvarUserID.IsForeignKey = true;
				colvarUserID.IsReadOnly = false;
				colvarUserID.DefaultSetting = @"";
				
					colvarUserID.ForeignKeyTableName = "Kick_User";
				schema.Columns.Add(colvarUserID);
				
				TableSchema.TableColumn colvarCommentX = new TableSchema.TableColumn(schema);
				colvarCommentX.ColumnName = "Comment";
				colvarCommentX.DataType = DbType.String;
				colvarCommentX.MaxLength = 4000;
				colvarCommentX.AutoIncrement = false;
				colvarCommentX.IsNullable = false;
				colvarCommentX.IsPrimaryKey = false;
				colvarCommentX.IsForeignKey = false;
				colvarCommentX.IsReadOnly = false;
				colvarCommentX.DefaultSetting = @"";
				colvarCommentX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommentX);
				
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
				
				TableSchema.TableColumn colvarHostID = new TableSchema.TableColumn(schema);
				colvarHostID.ColumnName = "HostID";
				colvarHostID.DataType = DbType.Int32;
				colvarHostID.MaxLength = 0;
				colvarHostID.AutoIncrement = false;
				colvarHostID.IsNullable = false;
				colvarHostID.IsPrimaryKey = false;
				colvarHostID.IsForeignKey = false;
				colvarHostID.IsReadOnly = false;
				
						colvarHostID.DefaultSetting = @"((1))";
				colvarHostID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHostID);
				
				TableSchema.TableColumn colvarIsSpam = new TableSchema.TableColumn(schema);
				colvarIsSpam.ColumnName = "IsSpam";
				colvarIsSpam.DataType = DbType.Boolean;
				colvarIsSpam.MaxLength = 0;
				colvarIsSpam.AutoIncrement = false;
				colvarIsSpam.IsNullable = false;
				colvarIsSpam.IsPrimaryKey = false;
				colvarIsSpam.IsForeignKey = false;
				colvarIsSpam.IsReadOnly = false;
				
						colvarIsSpam.DefaultSetting = @"((0))";
				colvarIsSpam.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsSpam);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("Kick_Comment",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CommentID")]
		public int CommentID 
		{
			get { return GetColumnValue<int>(Columns.CommentID); }

			set { SetColumnValue(Columns.CommentID, value); }

		}

		  
		[XmlAttribute("StoryID")]
		public int StoryID 
		{
			get { return GetColumnValue<int>(Columns.StoryID); }

			set { SetColumnValue(Columns.StoryID, value); }

		}

		  
		[XmlAttribute("UserID")]
		public int UserID 
		{
			get { return GetColumnValue<int>(Columns.UserID); }

			set { SetColumnValue(Columns.UserID, value); }

		}

		  
		[XmlAttribute("CommentX")]
		public string CommentX 
		{
			get { return GetColumnValue<string>(Columns.CommentX); }

			set { SetColumnValue(Columns.CommentX, value); }

		}

		  
		[XmlAttribute("CreatedOn")]
		public DateTime CreatedOn 
		{
			get { return GetColumnValue<DateTime>(Columns.CreatedOn); }

			set { SetColumnValue(Columns.CreatedOn, value); }

		}

		  
		[XmlAttribute("HostID")]
		public int HostID 
		{
			get { return GetColumnValue<int>(Columns.HostID); }

			set { SetColumnValue(Columns.HostID, value); }

		}

		  
		[XmlAttribute("IsSpam")]
		public bool IsSpam 
		{
			get { return GetColumnValue<bool>(Columns.IsSpam); }

			set { SetColumnValue(Columns.IsSpam, value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Story ActiveRecord object related to this Comment
		/// 
		/// </summary>
		public Incremental.Kick.Dal.Story Story
		{
			get { return Incremental.Kick.Dal.Story.FetchByID(this.StoryID); }

			set { SetColumnValue("StoryID", value.StoryID); }

		}

		
		
		/// <summary>
		/// Returns a User ActiveRecord object related to this Comment
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
		public static void Insert(int varStoryID,int varUserID,string varCommentX,DateTime varCreatedOn,int varHostID,bool varIsSpam)
		{
			Comment item = new Comment();
			
			item.StoryID = varStoryID;
			
			item.UserID = varUserID;
			
			item.CommentX = varCommentX;
			
			item.CreatedOn = varCreatedOn;
			
			item.HostID = varHostID;
			
			item.IsSpam = varIsSpam;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCommentID,int varStoryID,int varUserID,string varCommentX,DateTime varCreatedOn,int varHostID,bool varIsSpam)
		{
			Comment item = new Comment();
			
				item.CommentID = varCommentID;
			
				item.StoryID = varStoryID;
			
				item.UserID = varUserID;
			
				item.CommentX = varCommentX;
			
				item.CreatedOn = varCreatedOn;
			
				item.HostID = varHostID;
			
				item.IsSpam = varIsSpam;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn CommentIDColumn
        {
            get { return Schema.Columns[0]; }

        }

        
        
        
        public static TableSchema.TableColumn StoryIDColumn
        {
            get { return Schema.Columns[1]; }

        }

        
        
        
        public static TableSchema.TableColumn UserIDColumn
        {
            get { return Schema.Columns[2]; }

        }

        
        
        
        public static TableSchema.TableColumn CommentXColumn
        {
            get { return Schema.Columns[3]; }

        }

        
        
        
        public static TableSchema.TableColumn CreatedOnColumn
        {
            get { return Schema.Columns[4]; }

        }

        
        
        
        public static TableSchema.TableColumn HostIDColumn
        {
            get { return Schema.Columns[5]; }

        }

        
        
        
        public static TableSchema.TableColumn IsSpamColumn
        {
            get { return Schema.Columns[6]; }

        }

        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string CommentID = @"CommentID";
			 public static string StoryID = @"StoryID";
			 public static string UserID = @"UserID";
			 public static string CommentX = @"Comment";
			 public static string CreatedOn = @"CreatedOn";
			 public static string HostID = @"HostID";
			 public static string IsSpam = @"IsSpam";
						
		}

		#endregion
	}

}

