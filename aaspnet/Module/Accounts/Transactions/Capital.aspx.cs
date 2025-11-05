using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_Capital : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FyId;

	private string SId = "";

	private string CDate = "";

	private string CTime = "";

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Panel Panel1;

	protected Label Label2;

	protected Panel Panel3;

	protected GridView GridView3;

	protected SqlDataSource SqlDataSource2;

	protected Panel Panel2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!base.IsPostBack)
			{
				FillData();
				Panel3.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			FillData();
		}
		catch (Exception)
		{
		}
	}

	public void FillData()
	{
		try
		{
			con.Open();
			string cmdText = fun.select("*", "tblACC_Capital_Master", "FinYearId<='" + FyId + "' AND CompId='" + CompId + "' Order by Id DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Perticulars", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["Particulars"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("lblId")).Text;
				string cmdText2 = fun.select("MId", "tblACC_Capital_Details", "MId='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					if (sqlDataReader.HasRows)
					{
						((LinkButton)row.FindControl("LinkBtnDel")).Visible = false;
					}
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView2.FooterRow.FindControl("TextPerticulars2")).Text;
				if (text != "")
				{
					string cmdText = fun.insert("tblACC_Capital_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, Particulars", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillData();
				}
			}
			if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("TextPerticulars1")).Text;
				if (text2 != "")
				{
					string cmdText2 = fun.insert("tblACC_Capital_Master", "SysDate, SysTime , CompId, FinYearId , SessionId, Particulars", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FyId + "','" + SId + "','" + text2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillData();
				}
			}
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				con.Open();
				string cmdText3 = fun.delete("tblACC_Capital_Master", "Id='" + num + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				FillData();
				Panel3.Visible = true;
				GridView3.Visible = false;
			}
			if (e.CommandName == "HpPerticulars")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num2 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblId")).Text);
				ViewState["MId"] = num2;
				FillDataCredit();
				NODataToDisplay(GridView2);
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillDataCredit()
	{
		try
		{
			con.Open();
			string cmdText = fun.select("*", "tblACC_Capital_Details", " MId='" + Convert.ToInt32(ViewState["MId"].ToString()) + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Perticulars", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CreditAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["Particulars"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["CreditAmt"].ToString();
				dataRow[3] = ViewState["MId"].ToString();
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

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			FillDataCredit();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Addp")
			{
				string text = ((TextBox)GridView3.FooterRow.FindControl("TextPerticularsp2")).Text;
				double num = 0.0;
				if (fun.NumberValidationQty(((TextBox)GridView3.FooterRow.FindControl("TextCreditAmtp2")).Text) && ((TextBox)GridView3.FooterRow.FindControl("TextCreditAmtp2")).Text != "")
				{
					num = Convert.ToDouble(((TextBox)GridView3.FooterRow.FindControl("TextCreditAmtp2")).Text);
				}
				if (text != "" && num != 0.0)
				{
					string cmdText = fun.insert("tblACC_Capital_Details", "MId, Particulars,CreditAmt", "'" + Convert.ToInt32(ViewState["MId"].ToString()) + "','" + text + "','" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillDataCredit();
				}
			}
			if (e.CommandName == "Addp1")
			{
				string text2 = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextPerticularsp1")).Text;
				double num2 = 0.0;
				if (fun.NumberValidationQty(((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextCreditAmtp1")).Text) && ((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextCreditAmtp1")).Text != "")
				{
					num2 = Convert.ToDouble(((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextCreditAmtp1")).Text);
				}
				if (text2 != "" && num2 != 0.0)
				{
					string cmdText2 = fun.insert("tblACC_Capital_Details", "MId, Particulars,CreditAmt", "'" + Convert.ToInt32(ViewState["MId"].ToString()) + "','" + text2 + "','" + num2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillDataCredit();
					FillData();
				}
			}
			if (e.CommandName == "Delp")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblIdp")).Text);
				con.Open();
				string cmdText3 = fun.delete("tblACC_Capital_Details", "Id='" + num3 + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				FillDataCredit();
				FillData();
				NODataToDisplay(GridView3);
			}
		}
		catch (Exception)
		{
		}
	}

	public void NODataToDisplay(GridView grv)
	{
		if (grv.Rows.Count == 0)
		{
			Panel3.Visible = true;
			GridView3.Visible = false;
		}
		else
		{
			Panel3.Visible = false;
			GridView3.Visible = true;
		}
	}
}
