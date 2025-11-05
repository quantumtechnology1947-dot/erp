using System;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class DBReset : Page, IRequiresSessionState
{
	protected Button Button1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string[] array = new string[93]
			{
				"Message", "PrivateMessage", "LoggedInUser", "Room", "SD_Cust_Enquiry_Attach_Master", "SD_Cust_Enquiry_Master", "SD_Cust_master", "SD_Cust_PO_Details", "SD_Cust_PO_Details_Temp", "SD_Cust_PO_Master",
				"SD_Cust_WorkOrder_Dispatch", "SD_Cust_WorkOrder_Master", "SD_Cust_WorkOrder_Products_Details", "SD_Cust_WorkOrder_Products_Temp", "SD_Cust_WorkOrder_Release", "tblACC_Budget_Dept", "tblACC_Budget_Transactions", "tblACC_Budget_WO", "tblACC_SalesInvoice_Details", "tblACC_SalesInvoice_Master",
				"tblACC_ServiceTaxInvoice_Details", "tblACC_ServiceTaxInvoice_Master", "tblAccess_Master", "tblCompany_master", "tblDG_BOM_Master", "tblDG_BOMItem_Temp", "tblDG_Category_Master", "tblDG_ECN_Master", "tblDG_Item_Master", "tblDG_Item_Master_Clone",
				"tblDG_Location_Master", "tblDG_Material", "tblDG_Revision_Master", "tblDG_Revision_Type_Master", "tblDG_SubCategory_Master", "tblDG_TPL_Master", "tblDG_TPLItem_Temp", "tblFile_Attachment", "tblFinancial_master", "tblHR_MobileBill",
				"tblHR_News_Notices", "tblHR_Offer_Master", "tblHR_OfficeStaff", "tblHR_SwapCard", "tblInv_Inward_Details", "tblInv_Inward_Master", "tblInv_MaterialIssue_Details", "tblInv_MaterialIssue_Master", "tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master",
				"tblInv_MaterialRequisition_Details", "tblInv_MaterialRequisition_Master", "tblinv_MaterialRequisition_Temp", "tblInv_MaterialReturn_Details", "tblInv_MaterialReturn_Master", "tblinv_MaterialReturn_Temp", "tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master", "tblinv_Quality_Details", "tblinv_Quality_Master",
				"tblinv_Received_Details", "tblinv_Received_Master", "tblinv_Rejection_Master", "tblInv_WIS_Details", "tblInv_WIS_Master", "tblInv_WORelease_WIS", "tblInvQc_StockAdjLog", "tblMLC_LiveCost", "tblMM_PO_Amd_Details", "tblMM_PO_Amd_Master",
				"tblMM_PO_Amd_Temp", "tblMM_PO_Details", "tblMM_PO_Master", "tblMM_PR_Details", "tblMM_PR_Master", "tblMM_PR_PO_Temp", "tblMM_PR_Temp", "tblMM_Rate_Register", "tblMM_RateLockUnLock_Master", "tblMM_SPR_Details",
				"tblMM_SPR_Master", "tblMM_SPR_PO_Temp", "tblMM_SPR_Temp", "tblMM_Supplier_master", "tblMP_Material_Master", "tblMP_Material_Process", "tblMP_Material_RawMaterial", "tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master", "tblQc_MaterialReturnQuality_Details",
				"tblQc_MaterialReturnQuality_Master", "tblAccess_Master", "tblHR_News_Notices"
			};
			for (int i = 0; i < array.Length; i++)
			{
				SqlCommand sqlCommand = new SqlCommand("delete from " + array[i], sqlConnection);
				sqlCommand.ExecuteNonQuery();
				SqlCommand sqlCommand2 = new SqlCommand("dbcc checkident(" + array[i] + ",Reseed,0)", sqlConnection);
				sqlCommand2.ExecuteNonQuery();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}
}
