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



namespace Incremental.Kick.Dal{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the GetKickTags_ByHostIDAndCreatedOnRange Procedure
        /// </summary>
        public static StoredProcedure GetKickTags_ByHostIDAndCreatedOnRange(int HostID, DateTime CreatedOn_Lower, DateTime CreatedOn_Upper)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetKickTags_ByHostIDAndCreatedOnRange" , DataService.GetInstance("Kick"));
        	
            sp.Command.AddParameter("@HostID", HostID,DbType.Int32);
        	    
            sp.Command.AddParameter("@CreatedOn_Lower", CreatedOn_Lower,DbType.DateTime);
        	    
            sp.Command.AddParameter("@CreatedOn_Upper", CreatedOn_Upper,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the GetKickTags_ByUserIDAndHostID Procedure
        /// </summary>
        public static StoredProcedure GetKickTags_ByUserIDAndHostID(int UserID, int HostID)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetKickTags_ByUserIDAndHostID" , DataService.GetInstance("Kick"));
        	
            sp.Command.AddParameter("@UserID", UserID,DbType.Int32);
        	    
            sp.Command.AddParameter("@HostID", HostID,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the _Kick_Get_User_Kicked_Stories_Paged Procedure
        /// </summary>
        public static StoredProcedure _Kick_Get_User_Kicked_Stories_Paged(int UserID, int HostID, int PageNumber, int PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("_Kick_Get_User_Kicked_Stories_Paged" , DataService.GetInstance("Kick"));
        	
            sp.Command.AddParameter("@UserID", UserID,DbType.Int32);
        	    
            sp.Command.AddParameter("@HostID", HostID,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageNumber", PageNumber,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
        	    
            return sp;
        }

        
    }

    
}
