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



namespace Incremental.Kick.Dal{
    
public class SPs{
        static DataProvider provider=DataService.GetInstance("DotNetKicks");
        /// <summary>
        /// Creates an object wrapper for the GetKickTags_ByHostIDAndCreatedOnRange Procedure
        /// </summary>
        public static StoredProcedure GetKickTagsByHostIDAndCreatedOnRange(int HostID, DateTime CreatedOnLower, DateTime CreatedOnUpper){
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetKickTags_ByHostIDAndCreatedOnRange" , provider);
            sp.Command.AddParameter("@HostID", HostID,DbType.Int32);
            sp.Command.AddParameter("@CreatedOn_Lower", CreatedOnLower,DbType.DateTime);
            sp.Command.AddParameter("@CreatedOn_Upper", CreatedOnUpper,DbType.DateTime);
            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the GetKickTags_ByUserIDAndHostID Procedure
        /// </summary>
        public static StoredProcedure GetKickTagsByUserIDAndHostID(int UserID, int HostID){
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("GetKickTags_ByUserIDAndHostID" , provider);
            sp.Command.AddParameter("@UserID", UserID,DbType.Int32);
            sp.Command.AddParameter("@HostID", HostID,DbType.Int32);
            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the _Kick_Get_User_Kicked_Stories_Paged Procedure
        /// </summary>
        public static StoredProcedure KickGetUserKickedStoriesPaged(int UserID, int HostID, int PageNumber, int PageSize){
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("_Kick_Get_User_Kicked_Stories_Paged" , provider);
            sp.Command.AddParameter("@UserID", UserID,DbType.Int32);
            sp.Command.AddParameter("@HostID", HostID,DbType.Int32);
            sp.Command.AddParameter("@PageNumber", PageNumber,DbType.Int32);
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
            return sp;
        }

    }

}
