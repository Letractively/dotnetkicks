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



namespace TempGJ
{
	#region Tables Struct
	public partial struct Tables
	{
		public static string KickStory = @"Kick_Story";
		public static string KickStoryKick = @"Kick_StoryKick";
		public static string KickTag = @"Kick_Tag";
		public static string KickHost = @"Kick_Host";
		public static string KickStoryUserHostTag = @"Kick_StoryUserHostTag";
		public static string KickComment = @"Kick_Comment";
		public static string KickCategory = @"Kick_Category";
		public static string KickUser = @"Kick_User";

	}
	#endregion
}



namespace TempGJ
{
    #region View Struct
    public partial struct Views 
    {

    }
    #endregion
}


