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
	/// Strongly-typed collection for the Elmah_Error class.
	/// </summary>
	[Serializable]
	public partial class Elmah_ErrorCollection : ActiveList<Elmah_Error, Elmah_ErrorCollection> 
	{	   
		public Elmah_ErrorCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ELMAH_Error table.
	/// </summary>
	[Serializable]
	public partial class Elmah_Error : ActiveRecord<Elmah_Error>
	{
		#region .ctors and Default Settings
		
		public Elmah_Error()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Elmah_Error(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Elmah_Error(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Elmah_Error(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ELMAH_Error", TableType.Table, DataService.GetInstance("DotNetKicks"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarErrorId = new TableSchema.TableColumn(schema);
				colvarErrorId.ColumnName = "ErrorId";
				colvarErrorId.DataType = DbType.Guid;
				colvarErrorId.MaxLength = 0;
				colvarErrorId.AutoIncrement = false;
				colvarErrorId.IsNullable = false;
				colvarErrorId.IsPrimaryKey = true;
				colvarErrorId.IsForeignKey = false;
				colvarErrorId.IsReadOnly = false;
				
						colvarErrorId.DefaultSetting = @"(newid())";
				colvarErrorId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarErrorId);
				
				TableSchema.TableColumn colvarApplication = new TableSchema.TableColumn(schema);
				colvarApplication.ColumnName = "Application";
				colvarApplication.DataType = DbType.String;
				colvarApplication.MaxLength = 60;
				colvarApplication.AutoIncrement = false;
				colvarApplication.IsNullable = false;
				colvarApplication.IsPrimaryKey = false;
				colvarApplication.IsForeignKey = false;
				colvarApplication.IsReadOnly = false;
				colvarApplication.DefaultSetting = @"";
				colvarApplication.ForeignKeyTableName = "";
				schema.Columns.Add(colvarApplication);
				
				TableSchema.TableColumn colvarHost = new TableSchema.TableColumn(schema);
				colvarHost.ColumnName = "Host";
				colvarHost.DataType = DbType.String;
				colvarHost.MaxLength = 50;
				colvarHost.AutoIncrement = false;
				colvarHost.IsNullable = false;
				colvarHost.IsPrimaryKey = false;
				colvarHost.IsForeignKey = false;
				colvarHost.IsReadOnly = false;
				colvarHost.DefaultSetting = @"";
				colvarHost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHost);
				
				TableSchema.TableColumn colvarType = new TableSchema.TableColumn(schema);
				colvarType.ColumnName = "Type";
				colvarType.DataType = DbType.String;
				colvarType.MaxLength = 100;
				colvarType.AutoIncrement = false;
				colvarType.IsNullable = false;
				colvarType.IsPrimaryKey = false;
				colvarType.IsForeignKey = false;
				colvarType.IsReadOnly = false;
				colvarType.DefaultSetting = @"";
				colvarType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarType);
				
				TableSchema.TableColumn colvarSource = new TableSchema.TableColumn(schema);
				colvarSource.ColumnName = "Source";
				colvarSource.DataType = DbType.String;
				colvarSource.MaxLength = 60;
				colvarSource.AutoIncrement = false;
				colvarSource.IsNullable = false;
				colvarSource.IsPrimaryKey = false;
				colvarSource.IsForeignKey = false;
				colvarSource.IsReadOnly = false;
				colvarSource.DefaultSetting = @"";
				colvarSource.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSource);
				
				TableSchema.TableColumn colvarMessage = new TableSchema.TableColumn(schema);
				colvarMessage.ColumnName = "Message";
				colvarMessage.DataType = DbType.String;
				colvarMessage.MaxLength = 500;
				colvarMessage.AutoIncrement = false;
				colvarMessage.IsNullable = false;
				colvarMessage.IsPrimaryKey = false;
				colvarMessage.IsForeignKey = false;
				colvarMessage.IsReadOnly = false;
				colvarMessage.DefaultSetting = @"";
				colvarMessage.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMessage);
				
				TableSchema.TableColumn colvarUser = new TableSchema.TableColumn(schema);
				colvarUser.ColumnName = "User";
				colvarUser.DataType = DbType.String;
				colvarUser.MaxLength = 50;
				colvarUser.AutoIncrement = false;
				colvarUser.IsNullable = false;
				colvarUser.IsPrimaryKey = false;
				colvarUser.IsForeignKey = false;
				colvarUser.IsReadOnly = false;
				colvarUser.DefaultSetting = @"";
				colvarUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUser);
				
				TableSchema.TableColumn colvarStatusCode = new TableSchema.TableColumn(schema);
				colvarStatusCode.ColumnName = "StatusCode";
				colvarStatusCode.DataType = DbType.Int32;
				colvarStatusCode.MaxLength = 0;
				colvarStatusCode.AutoIncrement = false;
				colvarStatusCode.IsNullable = false;
				colvarStatusCode.IsPrimaryKey = false;
				colvarStatusCode.IsForeignKey = false;
				colvarStatusCode.IsReadOnly = false;
				colvarStatusCode.DefaultSetting = @"";
				colvarStatusCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatusCode);
				
				TableSchema.TableColumn colvarTimeUtc = new TableSchema.TableColumn(schema);
				colvarTimeUtc.ColumnName = "TimeUtc";
				colvarTimeUtc.DataType = DbType.DateTime;
				colvarTimeUtc.MaxLength = 0;
				colvarTimeUtc.AutoIncrement = false;
				colvarTimeUtc.IsNullable = false;
				colvarTimeUtc.IsPrimaryKey = false;
				colvarTimeUtc.IsForeignKey = false;
				colvarTimeUtc.IsReadOnly = false;
				colvarTimeUtc.DefaultSetting = @"";
				colvarTimeUtc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTimeUtc);
				
				TableSchema.TableColumn colvarSequence = new TableSchema.TableColumn(schema);
				colvarSequence.ColumnName = "Sequence";
				colvarSequence.DataType = DbType.Int32;
				colvarSequence.MaxLength = 0;
				colvarSequence.AutoIncrement = true;
				colvarSequence.IsNullable = false;
				colvarSequence.IsPrimaryKey = false;
				colvarSequence.IsForeignKey = false;
				colvarSequence.IsReadOnly = false;
				colvarSequence.DefaultSetting = @"";
				colvarSequence.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSequence);
				
				TableSchema.TableColumn colvarAllXml = new TableSchema.TableColumn(schema);
				colvarAllXml.ColumnName = "AllXml";
				colvarAllXml.DataType = DbType.String;
				colvarAllXml.MaxLength = 1073741823;
				colvarAllXml.AutoIncrement = false;
				colvarAllXml.IsNullable = false;
				colvarAllXml.IsPrimaryKey = false;
				colvarAllXml.IsForeignKey = false;
				colvarAllXml.IsReadOnly = false;
				colvarAllXml.DefaultSetting = @"";
				colvarAllXml.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAllXml);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["DotNetKicks"].AddSchema("ELMAH_Error",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ErrorId")]
		public Guid ErrorId 
		{
			get { return GetColumnValue<Guid>(Columns.ErrorId); }

			set { SetColumnValue(Columns.ErrorId, value); }

		}

		  
		[XmlAttribute("Application")]
		public string Application 
		{
			get { return GetColumnValue<string>(Columns.Application); }

			set { SetColumnValue(Columns.Application, value); }

		}

		  
		[XmlAttribute("Host")]
		public string Host 
		{
			get { return GetColumnValue<string>(Columns.Host); }

			set { SetColumnValue(Columns.Host, value); }

		}

		  
		[XmlAttribute("Type")]
		public string Type 
		{
			get { return GetColumnValue<string>(Columns.Type); }

			set { SetColumnValue(Columns.Type, value); }

		}

		  
		[XmlAttribute("Source")]
		public string Source 
		{
			get { return GetColumnValue<string>(Columns.Source); }

			set { SetColumnValue(Columns.Source, value); }

		}

		  
		[XmlAttribute("Message")]
		public string Message 
		{
			get { return GetColumnValue<string>(Columns.Message); }

			set { SetColumnValue(Columns.Message, value); }

		}

		  
		[XmlAttribute("User")]
		public string User 
		{
			get { return GetColumnValue<string>(Columns.User); }

			set { SetColumnValue(Columns.User, value); }

		}

		  
		[XmlAttribute("StatusCode")]
		public int StatusCode 
		{
			get { return GetColumnValue<int>(Columns.StatusCode); }

			set { SetColumnValue(Columns.StatusCode, value); }

		}

		  
		[XmlAttribute("TimeUtc")]
		public DateTime TimeUtc 
		{
			get { return GetColumnValue<DateTime>(Columns.TimeUtc); }

			set { SetColumnValue(Columns.TimeUtc, value); }

		}

		  
		[XmlAttribute("Sequence")]
		public int Sequence 
		{
			get { return GetColumnValue<int>(Columns.Sequence); }

			set { SetColumnValue(Columns.Sequence, value); }

		}

		  
		[XmlAttribute("AllXml")]
		public string AllXml 
		{
			get { return GetColumnValue<string>(Columns.AllXml); }

			set { SetColumnValue(Columns.AllXml, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(Guid varErrorId,string varApplication,string varHost,string varType,string varSource,string varMessage,string varUser,int varStatusCode,DateTime varTimeUtc,string varAllXml)
		{
			Elmah_Error item = new Elmah_Error();
			
			item.ErrorId = varErrorId;
			
			item.Application = varApplication;
			
			item.Host = varHost;
			
			item.Type = varType;
			
			item.Source = varSource;
			
			item.Message = varMessage;
			
			item.User = varUser;
			
			item.StatusCode = varStatusCode;
			
			item.TimeUtc = varTimeUtc;
			
			item.AllXml = varAllXml;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(Guid varErrorId,string varApplication,string varHost,string varType,string varSource,string varMessage,string varUser,int varStatusCode,DateTime varTimeUtc,int varSequence,string varAllXml)
		{
			Elmah_Error item = new Elmah_Error();
			
				item.ErrorId = varErrorId;
			
				item.Application = varApplication;
			
				item.Host = varHost;
			
				item.Type = varType;
			
				item.Source = varSource;
			
				item.Message = varMessage;
			
				item.User = varUser;
			
				item.StatusCode = varStatusCode;
			
				item.TimeUtc = varTimeUtc;
			
				item.Sequence = varSequence;
			
				item.AllXml = varAllXml;
			
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
			 public static string ErrorId = @"ErrorId";
			 public static string Application = @"Application";
			 public static string Host = @"Host";
			 public static string Type = @"Type";
			 public static string Source = @"Source";
			 public static string Message = @"Message";
			 public static string User = @"User";
			 public static string StatusCode = @"StatusCode";
			 public static string TimeUtc = @"TimeUtc";
			 public static string Sequence = @"Sequence";
			 public static string AllXml = @"AllXml";
						
		}

		#endregion
	}

}

