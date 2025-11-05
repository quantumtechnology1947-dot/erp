using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_MailMerge : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FyId;

	protected GridView SearchGridView1;

	protected Panel Panel1;

	protected Label Label2;

	protected TextBox txtFrom;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Label Label4;

	protected TextBox txtSub;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected Label Label3;

	protected TextBox txtMsg;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected Button Button1;

	protected Label lblerror;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		CompId = Convert.ToInt32(Session["compid"]);
		FyId = Convert.ToInt32(Session["finyear"]);
		_ = Page.IsPostBack;
	}

	public void BindData()
	{
		string connectionString = fun.Connection();
		con = new SqlConnection(connectionString);
		con.Open();
		string cmdText = "Select tblMM_Supplier_master.Email,tblMM_Supplier_master.SupplierName,tblMM_Supplier_master.SupplierId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(tblMM_Supplier_master.SysDate, CHARINDEX('-', tblMM_Supplier_master.SysDate) + 1, 2) + '-' + LEFT(tblMM_Supplier_master.SysDate,CHARINDEX('-', tblMM_Supplier_master.SysDate) - 1) + '-' + RIGHT(tblMM_Supplier_master.SysDate, CHARINDEX('-', REVERSE(tblMM_Supplier_master.SysDate)) - 1)), 103), '/', '-')AS SysDate,FinYear,EmployeeName from tblMM_Supplier_master inner join tblFinancial_master on tblMM_Supplier_master.FinYearId=tblFinancial_master.FinYearId inner join tblHR_OfficeStaff on tblMM_Supplier_master.SessionId=tblHR_OfficeStaff.EmpId And tblMM_Supplier_master.CompId='" + CompId + "' And tblMM_Supplier_master.FinYearId<='" + FyId + "' Order by tblMM_Supplier_master.SupplierName Asc";
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		SearchGridView1.DataSource = dataSet;
		SearchGridView1.DataBind();
		con.Close();
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		SearchGridView1.PageIndex = e.NewPageIndex;
		BindData();
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		MailMessage mailMessage = new MailMessage();
		SmtpMail.SmtpServer = "smtp.synergytechs.com";
		mailMessage.From = txtFrom.Text;
		mailMessage.Subject = txtSub.Text;
		mailMessage.Body = txtMsg.Text;
		mailMessage.BodyFormat = MailFormat.Html;
		base.Response.Write(mailMessage.From);
		mailMessage.To = "ashish.mahindre@synergytechs.com";
		SmtpMail.Send(mailMessage);
	}
}
