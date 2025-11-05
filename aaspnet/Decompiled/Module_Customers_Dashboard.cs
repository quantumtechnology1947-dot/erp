using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using Telerik.Web.UI;

public class Module_Customers_Dashboard : Page, IRequiresSessionState
{
	protected Label Label3;

	protected Label Label2;

	protected Label lblTitle;

	protected GridView GridView3;

	protected Panel Panel2;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = "";

	private int CompId;

	private int FyId;

	private string SId = "";

	private string wono = "";

	private string wnup = "";

	private string CustId = "";

	private string Id = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Label label = base.Master.FindControl("lblEmpName") as Label;
			label.Visible = false;
			LoginStatus loginStatus = base.Master.FindControl("LoginStatus1") as LoginStatus;
			loginStatus.LoginText = "Logout";
			RadPane radPane = base.Master.FindControl("Radpane1") as RadPane;
			radPane.Visible = false;
			RadSplitBar radSplitBar = base.Master.FindControl("Radsplitbar3") as RadSplitBar;
			radSplitBar.Visible = false;
			RadSplitBar radSplitBar2 = base.Master.FindControl("Radsplitbar2") as RadSplitBar;
			radSplitBar2.Visible = false;
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			CustId = base.Request.QueryString["CustId"];
			Id = base.Request.QueryString["Id"];
			if (!base.IsPostBack)
			{
				FillDataUpLoad(Id);
			}
			string cmdText = fun.select("*", "SD_Cust_master", "CustomerId='" + CustId + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			Label2.Text = dataSet.Tables[0].Rows[0]["CustomerName"].ToString() + " [" + dataSet.Tables[0].Rows[0]["CustomerId"].ToString() + "]";
			string cmdText2 = fun.select("Title", "tblPM_ForCustomer_Master", "Id='" + Id + "' ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			lblTitle.Text = dataSet2.Tables[0].Rows[0]["Title"].ToString();
		}
		catch (Exception)
		{
		}
	}

	public void FillDataUpLoad(string Id)
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Time", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MailTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("msg", typeof(string)));
			string cmdText = fun.select("tblPM_ForCustomer_Master.Id,tblPM_ForCustomer_Details.MailTo,tblPM_ForCustomer_Details.Message,tblPM_ForCustomer_Details.Id as DId,tblPM_ForCustomer_Master.SysDate,tblPM_ForCustomer_Master.SysTime,tblPM_ForCustomer_Details.FileName,tblPM_ForCustomer_Details.Remarks,tblPM_ForCustomer_Master.EmpId,tblPM_ForCustomer_Master.Title", "tblPM_ForCustomer_Master,tblPM_ForCustomer_Details", "tblPM_ForCustomer_Master.Id=tblPM_ForCustomer_Details.MId AND tblPM_ForCustomer_Master.FinYearId<='" + FyId + "' AND tblPM_ForCustomer_Master.CompId='" + CompId + "' AND tblPM_ForCustomer_Master.CustId='" + CustId + "'AND tblPM_ForCustomer_Master.EmpId='" + SId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["DId"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				if (dataSet.Tables[0].Rows[i]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[i]["FileName"] != DBNull.Value)
				{
					dataRow[2] = dataSet.Tables[0].Rows[i]["FileName"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["MailTo"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Message"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			fun.getCurrDate();
			fun.getCurrTime();
			if (e.CommandName == "downloadImg")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId0")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblPM_ForCustomer_Details&qfd=FileData&qfn=FileName&qct=ContentType");
			}
		}
		catch (Exception)
		{
		}
	}
}
