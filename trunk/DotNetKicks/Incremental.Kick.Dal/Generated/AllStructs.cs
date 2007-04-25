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
		
		public static string Category = @"Category";
        
		public static string Comment = @"Comment";
        
		public static string Host = @"Host";
        
		public static string Story = @"Story";
        
		public static string StoryKick = @"StoryKick";
        
		public static string StoryUserHostTag = @"StoryUserHostTag";
        
		public static string Tag = @"Tag";
        
		public static string User = @"User";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
    }

    #endregion
}


namespace TP2v3.Database2
{
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Al_Activity = @"Al_Activity";
        
		public static string Al_activity_base = @"Al_activity_base";
        
		public static string Al_Activity_ext = @"Al_Activity_ext";
        
		public static string Al_Activity_Rating = @"Al_Activity_Rating";
        
		public static string Al_activity_type = @"Al_activity_type";
        
		public static string Al_Icon = @"Al_Icon";
        
		public static string Cl_basefield = @"Cl_basefield";
        
		public static string Cl_Collate = @"Cl_Collate";
        
		public static string Cleardown_config = @"Cleardown_config";
        
		public static string Cm_command = @"Cm_command";
        
		public static string Cm_command_action = @"Cm_command_action";
        
		public static string Cm_command_value = @"Cm_command_value";
        
		public static string Cm_workstep_command = @"Cm_workstep_command";
        
		public static string Ct_context = @"Ct_context";
        
		public static string Ct_context_worktype = @"Ct_context_worktype";
        
		public static string Ct_field_definition = @"Ct_field_definition";
        
		public static string Cv_convert_parameter = @"Cv_convert_parameter";
        
		public static string Cv_dcp_convert_type = @"Cv_dcp_convert_type";
        
		public static string Cv_request = @"Cv_request";
        
		public static string D_line_non_working_day = @"D_line_non_working_day";
        
		public static string D_line_scheme = @"D_line_scheme";
        
		public static string D_line_scheme_config = @"D_line_scheme_config";
        
		public static string D_line_standard_working_time = @"D_line_standard_working_time";
        
		public static string D_line_team = @"D_line_team";
        
		public static string D_line_workitem_deadline = @"D_line_workitem_deadline";
        
		public static string D_line_worktype_duration = @"D_line_worktype_duration";
        
		public static string Dl_folder_reader_base_field_map = @"Dl_folder_reader_base_field_map";
        
		public static string Dl_folder_reader_index_datum = @"Dl_folder_reader_index_datum";
        
		public static string Dl_folder_reader_instance = @"Dl_folder_reader_instance";
        
		public static string Dl_folder_reader_type = @"Dl_folder_reader_type";
        
		public static string Dl_item_history = @"Dl_item_history";
        
		public static string Drt_query_allocation = @"Drt_query_allocation";
        
		public static string Drt_query_field_list = @"Drt_query_field_list";
        
		public static string Drt_query_list = @"Drt_query_list";
        
		public static string Drt_query_result_field_list = @"Drt_query_result_field_list";
        
		public static string Drt_Sample_List_Table = @"Drt_Sample_List_Table";
        
		public static string Dz_casedrop = @"Dz_casedrop";
        
		public static string Dz_casedrop_document_type_file = @"Dz_casedrop_document_type_file";
        
		public static string Dz_casedrop_document_type = @"Dz_casedrop_document_type";
        
		public static string Dz_casedrop_field_value = @"Dz_casedrop_field_value";
        
		public static string Dz_category_index_field = @"Dz_category_index_field";
        
		public static string Er_mailbox_config = @"Er_mailbox_config";
        
		public static string Er_processed_email = @"Er_processed_email";
        
		public static string Fw_application_basefield_extension = @"Fw_application_basefield_extension";
        
		public static string Fw_application_config_type = @"Fw_application_config_type";
        
		public static string Fw_application_instance_config = @"Fw_application_instance_config";
        
		public static string Fw_application_instance_list = @"Fw_application_instance_list";
        
		public static string Fw_application_list = @"Fw_application_list";
        
		public static string Fw_attribute_list = @"Fw_attribute_list";
        
		public static string Fw_attribute_value = @"Fw_attribute_value";
        
		public static string Fw_basefield = @"Fw_basefield";
        
		public static string Fw_basefields_category = @"Fw_basefields_category";
        
		public static string Fw_basefields_class = @"Fw_basefields_class";
        
		public static string Fw_cal_error = @"Fw_cal_error";
        
		public static string Fw_category = @"Fw_category";
        
		public static string Fw_category_allocation = @"Fw_category_allocation";
        
		public static string Fw_class = @"Fw_class";
        
		public static string Fw_config = @"Fw_config";
        
		public static string Fw_config_category = @"Fw_config_category";
        
		public static string Fw_customized_content = @"Fw_customized_content";
        
		public static string Fw_datasource_list = @"Fw_datasource_list";
        
		public static string Fw_datasource_sql_connection = @"Fw_datasource_sql_connection";
        
		public static string Fw_directive = @"Fw_directive";
        
		public static string Fw_document_type_description = @"Fw_document_type_description";
        
		public static string Fw_document_type = @"Fw_document_type";
        
		public static string Fw_framework_version = @"Fw_framework_version";
        
		public static string Fw_heartbeat = @"Fw_heartbeat";
        
		public static string Fw_image_binary = @"Fw_image_binary";
        
		public static string Fw_major_business_key = @"Fw_major_business_key";
        
		public static string Fw_major_business_key_field = @"Fw_major_business_key_field";
        
		public static string Fw_permission_allocation = @"Fw_permission_allocation";
        
		public static string Fw_permission_list = @"Fw_permission_list";
        
		public static string Fw_pool_user_group = @"Fw_pool_user_group";
        
		public static string Fw_pool_user_list = @"Fw_pool_user_list";
        
		public static string Fw_processor_mapping = @"Fw_processor_mapping";
        
		public static string Fw_queue_allocation = @"Fw_queue_allocation";
        
		public static string Fw_queue_list = @"Fw_queue_list";
        
		public static string Fw_request = @"Fw_request";
        
		public static string Fw_request_object_stream = @"Fw_request_object_stream";
        
		public static string Fw_request_state_history = @"Fw_request_state_history";
        
		public static string Fw_request_tracking = @"Fw_request_tracking";
        
		public static string Fw_role_type_list = @"Fw_role_type_list";
        
		public static string Fw_security_token = @"Fw_security_token";
        
		public static string Fw_server_list = @"Fw_server_list";
        
		public static string Fw_state = @"Fw_state";
        
		public static string Fw_static_user = @"Fw_static_user";
        
		public static string Fw_sync_log_datum = @"Fw_sync_log_datum";
        
		public static string Fw_sync_pending = @"Fw_sync_pending";
        
		public static string Fw_system_basefields_map = @"Fw_system_basefields_map";
        
		public static string Fw_system_field = @"Fw_system_field";
        
		public static string Fw_user_alias = @"Fw_user_alias";
        
		public static string Fw_user_app_setting = @"Fw_user_app_setting";
        
		public static string Fw_user_defined_field = @"Fw_user_defined_field";
        
		public static string Fw_user_defined_fields_instance = @"Fw_user_defined_fields_instance";
        
		public static string Fw_user_group_membership = @"Fw_user_group_membership";
        
		public static string Fw_user_group = @"Fw_user_group";
        
		public static string Fw_user_list = @"Fw_user_list";
        
		public static string Fw_user_role = @"Fw_user_role";
        
		public static string Fw_workitem_datum = @"Fw_workitem_datum";
        
		public static string Fw_workitem_field = @"Fw_workitem_field";
        
		public static string Fw_workitem_FTI_datum = @"Fw_workitem_FTI_datum";
        
		public static string Fw_workitem_lock_history = @"Fw_workitem_lock_history";
        
		public static string Fw_workstep = @"Fw_workstep";
        
		public static string Is_log_message = @"Is_log_message";
        
		public static string Is_manager_request_field = @"Is_manager_request_field";
        
		public static string Is_manager_request = @"Is_manager_request";
        
		public static string Is_manager_template = @"Is_manager_template";
        
		public static string Is_request = @"Is_request";
        
		public static string Is_requests_group = @"Is_requests_group";
        
		public static string Is_update_field = @"Is_update_field";
        
		public static string ListCategory = @"ListCategory";
        
		public static string ListValue = @"ListValue";
        
		public static string Log_error = @"Log_error";
        
		public static string Log_ex_document_link = @"Log_ex_document_link";
        
		public static string Log_header = @"Log_header";
        
		public static string Log_level = @"Log_level";
        
		public static string Log_type = @"Log_type";
        
		public static string Tpm_sqltestdef = @"Tpm_sqltestdef";
        
		public static string Tpm_sqltesthistory = @"Tpm_sqltesthistory";
        
		public static string Tpm_sqltestparam = @"Tpm_sqltestparam";
        
		public static string Wr_Attribute = @"Wr_Attribute";
        
		public static string Wr_RatingValue = @"Wr_RatingValue";
        
		public static string Wr_WorkRating = @"Wr_WorkRating";
        
		public static string Wt_description_mapping = @"Wt_description_mapping";
        
		public static string Wt_field_definition = @"Wt_field_definition";
        
		public static string Wt_worktype = @"Wt_worktype";
        
		public static string Wt_worktype_allocation = @"Wt_worktype_allocation";
        
		public static string Wt_worktype_description = @"Wt_worktype_description";
        
		public static string Wt_worktype_relation = @"Wt_worktype_relation";
        
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

#region Databases
public partial struct Databases 
{
	
	public static string Kick = @"Kick";
    
	public static string TP2v3_DB = @"TP2v3_DB";
    
	public static string Northwind = @"Northwind";
    
}

#endregion