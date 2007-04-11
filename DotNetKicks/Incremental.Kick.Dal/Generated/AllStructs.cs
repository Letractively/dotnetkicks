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



namespace TP2v3.Database2
{
	#region Tables Struct
	public partial struct Tables
	{
		public static string AlActivity = @"AlActivity";
		public static string Alactivitybase = @"Alactivitybase";
		public static string AlActivityext = @"AlActivityext";
		public static string AlActivityRating = @"AlActivityRating";
		public static string Alactivitytype = @"Alactivitytype";
		public static string AlIcon = @"AlIcon";
		public static string Clbasefield = @"Clbasefield";
		public static string ClCollate = @"ClCollate";
		public static string Cleardownconfig = @"Cleardownconfig";
		public static string Cmcommand = @"Cmcommand";
		public static string Cmcommandaction = @"Cmcommandaction";
		public static string Cmcommandvalue = @"Cmcommandvalue";
		public static string Cmworkstepcommand = @"Cmworkstepcommand";
		public static string Ctcontext = @"Ctcontext";
		public static string Ctcontextworktype = @"Ctcontextworktype";
		public static string Ctfielddefinition = @"Ctfielddefinition";
		public static string Cvconvertparameter = @"Cvconvertparameter";
		public static string Cvdcpconverttype = @"Cvdcpconverttype";
		public static string Cvrequest = @"Cvrequest";
		public static string Dlinenonworkingday = @"Dlinenonworkingday";
		public static string Dlinescheme = @"Dlinescheme";
		public static string Dlineschemeconfig = @"Dlineschemeconfig";
		public static string Dlinestandardworkingtime = @"Dlinestandardworkingtime";
		public static string Dlineteam = @"Dlineteam";
		public static string Dlineworkitemdeadline = @"Dlineworkitemdeadline";
		public static string Dlineworktypeduration = @"Dlineworktypeduration";
		public static string Dlfolderreaderbasefieldmap = @"Dlfolderreaderbasefieldmap";
		public static string Dlfolderreaderindexdatum = @"Dlfolderreaderindexdatum";
		public static string Dlfolderreaderinstance = @"Dlfolderreaderinstance";
		public static string Dlfolderreadertype = @"Dlfolderreadertype";
		public static string Dlitemhistory = @"Dlitemhistory";
		public static string Drtqueryallocation = @"Drtqueryallocation";
		public static string Drtqueryfieldlist = @"Drtqueryfieldlist";
		public static string Drtquerylist = @"Drtquerylist";
		public static string Drtqueryresultfieldlist = @"Drtqueryresultfieldlist";
		public static string DrtSampleListTable = @"DrtSampleListTable";
		public static string Dzcasedrop = @"Dzcasedrop";
		public static string Dzcasedropdocumenttypefile = @"Dzcasedropdocumenttypefile";
		public static string Dzcasedropdocumenttype = @"Dzcasedropdocumenttype";
		public static string Dzcasedropfieldvalue = @"Dzcasedropfieldvalue";
		public static string Dzcategoryindexfield = @"Dzcategoryindexfield";
		public static string Ermailboxconfig = @"Ermailboxconfig";
		public static string Erprocessedemail = @"Erprocessedemail";
		public static string Fwapplicationbasefieldextension = @"Fwapplicationbasefieldextension";
		public static string Fwapplicationconfigtype = @"Fwapplicationconfigtype";
		public static string Fwapplicationinstanceconfig = @"Fwapplicationinstanceconfig";
		public static string Fwapplicationinstancelist = @"Fwapplicationinstancelist";
		public static string Fwapplicationlist = @"Fwapplicationlist";
		public static string Fwattributelist = @"Fwattributelist";
		public static string Fwattributevalue = @"Fwattributevalue";
		public static string Fwbasefield = @"Fwbasefield";
		public static string Fwbasefieldscategory = @"Fwbasefieldscategory";
		public static string Fwbasefieldsclass = @"Fwbasefieldsclass";
		public static string Fwcalerror = @"Fwcalerror";
		public static string Fwcategory = @"Fwcategory";
		public static string Fwcategoryallocation = @"Fwcategoryallocation";
		public static string Fwclass = @"Fwclass";
		public static string Fwconfig = @"Fwconfig";
		public static string Fwconfigcategory = @"Fwconfigcategory";
		public static string Fwdatasourcelist = @"Fwdatasourcelist";
		public static string Fwdatasourcesqlconnection = @"Fwdatasourcesqlconnection";
		public static string Fwdirective = @"Fwdirective";
		public static string Fwdocumenttypedescription = @"Fwdocumenttypedescription";
		public static string Fwdocumenttype = @"Fwdocumenttype";
		public static string Fwframeworkversion = @"Fwframeworkversion";
		public static string Fwheartbeat = @"Fwheartbeat";
		public static string Fwimagebinary = @"Fwimagebinary";
		public static string Fwmajorbusinesskey = @"Fwmajorbusinesskey";
		public static string Fwmajorbusinesskeyfield = @"Fwmajorbusinesskeyfield";
		public static string Fwpermissionallocation = @"Fwpermissionallocation";
		public static string Fwpermissionlist = @"Fwpermissionlist";
		public static string Fwpoolusergroup = @"Fwpoolusergroup";
		public static string Fwpooluserlist = @"Fwpooluserlist";
		public static string Fwprocessormapping = @"Fwprocessormapping";
		public static string Fwqueueallocation = @"Fwqueueallocation";
		public static string Fwqueuelist = @"Fwqueuelist";
		public static string Fwrequest = @"Fwrequest";
		public static string Fwrequestobjectstream = @"Fwrequestobjectstream";
		public static string Fwrequeststatehistory = @"Fwrequeststatehistory";
		public static string Fwrequesttracking = @"Fwrequesttracking";
		public static string Fwroletypelist = @"Fwroletypelist";
		public static string Fwsecuritytoken = @"Fwsecuritytoken";
		public static string Fwserverlist = @"Fwserverlist";
		public static string Fwstate = @"Fwstate";
		public static string Fwstaticuser = @"Fwstaticuser";
		public static string Fwsynclogdatum = @"Fwsynclogdatum";
		public static string Fwsyncpending = @"Fwsyncpending";
		public static string Fwsystembasefieldsmap = @"Fwsystembasefieldsmap";
		public static string Fwsystemfield = @"Fwsystemfield";
		public static string Fwuseralias = @"Fwuseralias";
		public static string Fwuserappsetting = @"Fwuserappsetting";
		public static string Fwuserdefinedfield = @"Fwuserdefinedfield";
		public static string Fwuserdefinedfieldsinstance = @"Fwuserdefinedfieldsinstance";
		public static string Fwusergroupmembership = @"Fwusergroupmembership";
		public static string Fwusergroup = @"Fwusergroup";
		public static string Fwuserlist = @"Fwuserlist";
		public static string Fwuserrole = @"Fwuserrole";
		public static string Fwworkitemdatum = @"Fwworkitemdatum";
		public static string Fwworkitemfield = @"Fwworkitemfield";
		public static string FwworkitemFTIdatum = @"FwworkitemFTIdatum";
		public static string Fwworkitemlockhistory = @"Fwworkitemlockhistory";
		public static string Fwworkstep = @"Fwworkstep";
		public static string Islogmessage = @"Islogmessage";
		public static string Ismanagerrequestfield = @"Ismanagerrequestfield";
		public static string Ismanagerrequest = @"Ismanagerrequest";
		public static string Ismanagertemplate = @"Ismanagertemplate";
		public static string Isrequest = @"Isrequest";
		public static string Isrequestsgroup = @"Isrequestsgroup";
		public static string Isupdatefield = @"Isupdatefield";
		public static string Logerror = @"Logerror";
		public static string Logexdocumentlink = @"Logexdocumentlink";
		public static string Logheader = @"Logheader";
		public static string Loglevel = @"Loglevel";
		public static string Logtype = @"Logtype";
		public static string Tpmsqltestdef = @"Tpmsqltestdef";
		public static string Tpmsqltesthistory = @"Tpmsqltesthistory";
		public static string Tpmsqltestparam = @"Tpmsqltestparam";
		public static string WrAttribute = @"WrAttribute";
		public static string WrRatingValue = @"WrRatingValue";
		public static string WrWorkRating = @"WrWorkRating";
		public static string Wtdescriptionmapping = @"Wtdescriptionmapping";
		public static string Wtfielddefinition = @"Wtfielddefinition";
		public static string Wtworktype = @"Wtworktype";
		public static string Wtworktypeallocation = @"Wtworktypeallocation";
		public static string Wtworktypedescription = @"Wtworktypedescription";
		public static string Wtworktyperelation = @"Wtworktyperelation";
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		public static string Sysconstraint = @"Sysconstraint";
		public static string Syssegment = @"Syssegment";
    }

    #endregion
}


namespace Northwind
{
	#region Tables Struct
	public partial struct Tables
	{
		public static string Category = @"Category";
		public static string CustomerCustomerDemo = @"CustomerCustomerDemo";
		public static string CustomerDemographic = @"CustomerDemographic";
		public static string Customer = @"Customer";
		public static string Employee = @"Employee";
		public static string EmployeeTerritory = @"EmployeeTerritory";
		public static string OrderDetail = @"OrderDetail";
		public static string Order = @"Order";
		public static string Product = @"Product";
		public static string Region = @"Region";
		public static string Shipper = @"Shipper";
		public static string Supplier = @"Supplier";
		public static string Territory = @"Territory";
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		public static string Alphabeticallistofproduct = @"Alphabeticallistofproduct";
		public static string CategorySalesfor1997 = @"CategorySalesfor1997";
		public static string CurrentProductList = @"CurrentProductList";
		public static string CustomerandSuppliersbyCity = @"CustomerandSuppliersbyCity";
		public static string Invoice = @"Invoice";
		public static string OrderDetailsExtended = @"OrderDetailsExtended";
		public static string OrderSubtotal = @"OrderSubtotal";
		public static string OrdersQry = @"OrdersQry";
		public static string ProductSalesfor1997 = @"ProductSalesfor1997";
		public static string ProductsAboveAveragePrice = @"ProductsAboveAveragePrice";
		public static string ProductsbyCategory = @"ProductsbyCategory";
		public static string QuarterlyOrder = @"QuarterlyOrder";
		public static string SalesbyCategory = @"SalesbyCategory";
		public static string SalesTotalsbyAmount = @"SalesTotalsbyAmount";
		public static string SummaryofSalesbyQuarter = @"SummaryofSalesbyQuarter";
		public static string SummaryofSalesbyYear = @"SummaryofSalesbyYear";
    }

    #endregion
}


namespace Incremental.Kick.Dal
{
	#region Tables Struct
	public partial struct Tables
	{
		public static string KickCategory = @"KickCategory";
		public static string KickComment = @"KickComment";
		public static string KickHost = @"KickHost";
		public static string KickStory = @"KickStory";
		public static string KickStoryKick = @"KickStoryKick";
		public static string KickStoryUserHostTag = @"KickStoryUserHostTag";
		public static string KickTag = @"KickTag";
		public static string KickUser = @"KickUser";
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
	public static string TP2v3_DB = @"TP2v3_DB";
	public static string Northwind = @"Northwind";
	public static string DotNetKicks = @"DotNetKicks";
}

#endregion