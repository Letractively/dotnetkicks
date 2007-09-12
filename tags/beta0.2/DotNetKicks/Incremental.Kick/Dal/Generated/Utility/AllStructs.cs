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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Elmah_Error = @"ELMAH_Error";
        
		public static string Category = @"Kick_Category";
        
		public static string Comment = @"Kick_Comment";
        
		public static string Host = @"Kick_Host";
        
		public static string Setting = @"Kick_Setting";
        
		public static string Story = @"Kick_Story";
        
		public static string StoryKick = @"Kick_StoryKick";
        
		public static string StoryUserHostTag = @"Kick_StoryUserHostTag";
        
		public static string Tag = @"Kick_Tag";
        
		public static string User = @"Kick_User";
        
		public static string UserFriend = @"Kick_UserFriend";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	
	public static string DotNetKicks = @"DotNetKicks";
    
}

#endregion
