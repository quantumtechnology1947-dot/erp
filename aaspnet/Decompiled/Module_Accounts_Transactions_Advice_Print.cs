using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_Advice_Print : Page, IRequiresSessionState
{
	protected GridView GridView3;

	protected Panel Panel1;

	protected TabPanel Add;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

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
			sId = Session["username"].ToString();
			if (!Page.IsPostBack)
			{
				FillGrid_Creditors();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Creditors()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT * FROM tblACC_Advice_Payment_Master where CompId='" + CompId + "' And FinYearId<='" + FinYearId + "' Order By Id desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ADNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOfVoucher", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PaidTo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ChequeNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ChequeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bank", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["ADNo"].ToString();
				switch (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Type"]))
				{
				case 1:
					dataRow[1] = "Advance";
					break;
				case 2:
					dataRow[1] = "Salary";
					break;
				case 3:
					dataRow[1] = "Others";
					break;
				case 4:
					dataRow[1] = "Creditors";
					break;
				}
				string value;
				if (dataSet.Tables[0].Rows[i]["NameOnCheque"].ToString() == "" || dataSet.Tables[0].Rows[i]["NameOnCheque"] == DBNull.Value)
				{
					if (int.TryParse(dataSet.Tables[i].Rows[0]["PaidType"].ToString(), out var _))
					{
						string cmdText2 = fun.select("*", "tblACC_PaidType", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["PaidType"]) + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						value = dataSet2.Tables[0].Rows[0]["Particulars"].ToString();
					}
					else
					{
						value = fun.ECSNames(Convert.ToInt32(dataSet.Tables[0].Rows[i]["ECSType"].ToString()), dataSet.Tables[0].Rows[i]["PayTo"].ToString(), CompId);
					}
				}
				else
				{
					value = dataSet.Tables[0].Rows[i]["NameOnCheque"].ToString();
				}
				dataRow[2] = value;
				dataRow[3] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ChequeDate"].ToString());
				dataRow[4] = dataSet.Tables[0].Rows[i]["ChequeNo"].ToString();
				double num = 0.0;
				string cmdText3 = "Select Sum(Amount)As Amt from tblACC_Advice_Payment_Details inner join tblACC_Advice_Payment_Master on tblACC_Advice_Payment_Details.MId=tblACC_Advice_Payment_Master.Id And CompId='" + CompId + "' AND tblACC_Advice_Payment_Details.MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And tblACC_Advice_Payment_Master.Type='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Type"]) + "'";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0]["Amt"] != DBNull.Value)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["Amt"].ToString()).ToString("N3"));
				}
				dataRow[6] = num;
				string cmdText4 = "Select Name from tblACC_Bank inner join tblACC_Advice_Payment_Master on tblACC_Bank.Id=tblACC_Advice_Payment_Master.Bank And tblACC_Advice_Payment_Master.CompId='" + CompId + "'";
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
				{
					dataRow[7] = dataSet4.Tables[0].Rows[0]["Name"].ToString();
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView3.PageIndex = e.NewPageIndex;
		FillGrid_Creditors();
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				base.Response.Redirect("Advice_Print_Details.aspx?Id=" + num + "&ModId=11&SubModId=119&Key=" + randomAlphaNumeric);
			}
			if (e.CommandName == "Adv")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num2 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblId")).Text);
				base.Response.Redirect("Advice_Print_Advice.aspx?Id=" + num2 + "&ModId=11&SubModId=119&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}
}
