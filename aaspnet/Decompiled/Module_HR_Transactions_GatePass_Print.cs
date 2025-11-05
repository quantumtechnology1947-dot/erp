using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_HR_Transactions_GatePass_Print : Page, IRequiresSessionState
{
	protected TextBox txtFromDate;

	protected CalendarExtender txtFromDate_CalendarExtender;

	protected TextBox txtToDate;

	protected CalendarExtender txtToDate_CalendarExtender;

	protected TextBox txtEmpCode;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected Button BtnSearch;

	protected HtmlGenericControl Iframe1;

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			txtFromDate.Attributes.Add("readonly", "readonly");
			txtToDate.Attributes.Add("readonly", "readonly");
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		if (txtFromDate.Text != string.Empty && txtToDate.Text != string.Empty)
		{
			text3 = txtFromDate.Text;
			text4 = txtToDate.Text;
			text = " And tblGatePass_Details.FromDate Between '" + fun.FromDate(txtFromDate.Text) + "' And '" + fun.FromDate(txtToDate.Text) + "' ";
		}
		if (txtEmpCode.Text != string.Empty)
		{
			text6 = " And tblGate_Pass.EmpId='" + fun.getCode(txtEmpCode.Text) + "' ";
			string cmdText = fun.select("tblGate_Pass.SessionId,tblGate_Pass.CompId,tblGate_Pass.SysDate,tblGate_Pass.Authorize,tblGate_Pass.EmpId As SelfEId,tblGate_Pass.Id,tblGate_Pass.FinYearId,tblGate_Pass.GPNo,tblGate_Pass.Authorize,tblGate_Pass.AuthorizedBy,tblGate_Pass.AuthorizeDate,tblGate_Pass.AuthorizeTime,tblGatePass_Details.FromDate,tblGatePass_Details.FromTime,tblGatePass_Details.ToTime,tblGatePass_Details.Type,tblGatePass_Details.TypeFor,tblGatePass_Details.Reason,tblGatePass_Details.Feedback,tblGatePass_Details.Id As DId,tblGatePass_Details.EmpId As OtherEId,tblGatePass_Details.Place,tblGatePass_Details.ContactPerson,tblGatePass_Details.ContactNo", "tblGate_Pass,tblGatePass_Details", "tblGate_Pass.Id=tblGatePass_Details.MId " + text6);
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				text2 = " And tblGate_Pass.EmpId='" + fun.getCode(txtEmpCode.Text) + "' ";
			}
			else
			{
				text5 = " And tblGatePass_Details.EmpId='" + fun.getCode(txtEmpCode.Text) + "' ";
			}
		}
		string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
		Iframe1.Attributes.Add("src", "GatePass_Print_Details.aspx?z=" + text + "&p=" + text2 + "&FDate=" + text3 + "&TDate=" + text4 + "&q=" + text5 + "&Key=" + randomAlphaNumeric);
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql3(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}
}
