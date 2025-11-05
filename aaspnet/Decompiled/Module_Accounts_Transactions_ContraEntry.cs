using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_ContraEntry : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string Sid = string.Empty;

	private int Cid;

	private int Fyid;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			con = new SqlConnection(connectionString);
			Sid = Session["username"].ToString();
			Cid = Convert.ToInt32(Session["compid"]);
			Fyid = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				fillgrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Cr", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dr", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amt", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Narr", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CrId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DrId", typeof(string)));
			string cmdText = fun.select("*", "tblACC_Contra_Entry", "CompId='" + Cid + "' AND FinYearId<='" + Fyid + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["Date"].ToString());
				string cmdText2 = fun.select("*", "tblACC_Bank", "Id='" + dataSet.Tables[0].Rows[i]["Cr"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataRow[2] = dataSet2.Tables[0].Rows[0]["Name"].ToString();
				string cmdText3 = fun.select("*", "tblACC_Bank", "Id='" + dataSet.Tables[0].Rows[i]["Dr"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[3] = dataSet3.Tables[0].Rows[0]["Name"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Amount"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Cr"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Dr"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			if (GridView1.Rows.Count == 0)
			{
				DropDownList dropDownList = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr");
				dropdownCrDr2(dropDownList);
				DropDownList dropDownList2 = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListDr");
				if (dropDownList.SelectedItem.Text != "Select")
				{
					int selItem = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr")).SelectedValue);
					dropdownCrDr(dropDownList2, selItem);
				}
				else
				{
					dropDownList2.Items.Insert(0, "Select");
				}
			}
			else
			{
				DropDownList dropDownList3 = (DropDownList)GridView1.FooterRow.FindControl("DrpListCr");
				dropdownCrDr2(dropDownList3);
				DropDownList dropDownList4 = (DropDownList)GridView1.FooterRow.FindControl("DrpListDr");
				if (dropDownList3.SelectedItem.Text != "Select")
				{
					int selItem2 = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpListCr")).SelectedValue);
					dropdownCrDr(dropDownList4, selItem2);
				}
				else
				{
					dropDownList4.Items.Insert(0, "Select");
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	public void dropdownCrDr(DropDownList DDLCrDr, int SelItem)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string text = "";
			text = fun.select("*", "tblACC_Bank", "Id!='" + SelItem + "'");
			SqlCommand selectCommand = new SqlCommand(text, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_Bank");
			DDLCrDr.DataSource = dataSet.Tables["tblACC_Bank"];
			DDLCrDr.DataTextField = "Name";
			DDLCrDr.DataValueField = "Id";
			DDLCrDr.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void dropdownCrDr2(DropDownList DDLCr)
	{
		try
		{
			DataSet dataSet = new DataSet();
			string text = "";
			text = fun.select1("*", "tblACC_Bank");
			SqlCommand selectCommand = new SqlCommand(text, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_Bank");
			DDLCr.DataSource = dataSet.Tables["tblACC_Bank"];
			DDLCr.DataTextField = "Name";
			DDLCr.DataValueField = "Id";
			DDLCr.DataBind();
			DDLCr.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (e.CommandName == "Add")
			{
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text = ((TextBox)gridViewRow.FindControl("txtDate0")).Text;
				string selectedValue = ((DropDownList)gridViewRow.FindControl("DrpListCr0")).SelectedValue;
				string selectedValue2 = ((DropDownList)gridViewRow.FindControl("DrpListDr0")).SelectedValue;
				string text2 = ((TextBox)gridViewRow.FindControl("txtAmt0")).Text;
				string text3 = ((TextBox)gridViewRow.FindControl("txtNarr0")).Text;
				string cmdText = fun.insert("tblACC_Contra_Entry", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,Cr,Dr,Amount,Narration", "'" + currDate + "','" + currTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + fun.FromDate(text) + "','" + selectedValue + "','" + selectedValue2 + "','" + text2 + "','" + text3 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Add1")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text4 = ((TextBox)gridViewRow2.FindControl("txtDate")).Text;
				string selectedValue3 = ((DropDownList)gridViewRow2.FindControl("DrpListCr")).SelectedValue;
				string selectedValue4 = ((DropDownList)gridViewRow2.FindControl("DrpListDr")).SelectedValue;
				string text5 = ((TextBox)gridViewRow2.FindControl("txtAmt")).Text;
				string text6 = ((TextBox)gridViewRow2.FindControl("txtNarr")).Text;
				if (((DropDownList)gridViewRow2.FindControl("DrpListDr")).SelectedItem.Text != "Select")
				{
					string cmdText2 = fun.insert("tblACC_Contra_Entry", "SysDate,SysTime,CompId,SessionId,FinYearId,Date,Cr,Dr,Amount,Narration", "'" + currDate + "','" + currTime + "','" + Cid + "','" + Sid + "','" + Fyid + "','" + fun.FromDate(text4) + "','" + selectedValue3 + "','" + selectedValue4 + "','" + text5 + "','" + text6 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			fillgrid();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			fillgrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			((DropDownList)gridViewRow.FindControl("DrpListCr0")).SelectedValue = ((Label)gridViewRow.FindControl("lblCr0")).Text;
			((DropDownList)gridViewRow.FindControl("DrpListDr0")).SelectedValue = ((Label)gridViewRow.FindControl("lblDr0")).Text;
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("DrpListCr0");
			DropDownList dropDownList2 = (DropDownList)gridViewRow.FindControl("DrpListDr0");
			if (dropDownList.SelectedItem.Text != "Select")
			{
				int selItem = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpListCr0")).SelectedValue);
				dropdownCrDr(dropDownList2, selItem);
			}
			else
			{
				dropDownList2.Items.Insert(0, "Select");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		int editIndex = GridView1.EditIndex;
		GridViewRow gridViewRow = GridView1.Rows[editIndex];
		int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
		string text = ((TextBox)gridViewRow.FindControl("txtDate0")).Text;
		string selectedValue = ((DropDownList)gridViewRow.FindControl("DrpListCr0")).SelectedValue;
		string selectedValue2 = ((DropDownList)gridViewRow.FindControl("DrpListDr0")).SelectedValue;
		string text2 = ((TextBox)gridViewRow.FindControl("txtAmt0")).Text;
		string text3 = ((TextBox)gridViewRow.FindControl("txtNarr0")).Text;
		if (text != "" && text2 != "")
		{
			string cmdText = fun.update("tblACC_Contra_Entry", "Date='" + text + "',Cr='" + selectedValue + "',Dr='" + selectedValue2 + "',Amount='" + text2 + "',Narration='" + text3 + "'", "Id=" + num + " And CompId='" + Cid + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			GridView1.EditIndex = -1;
			fillgrid();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_Contra_Entry", "Id='" + num + "' And CompId='" + Cid + "'"), con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		fillgrid();
	}

	protected void DrpListCr_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DropDownList dropDownList = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListDr");
			DropDownList dropDownList2 = (DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr");
			if (dropDownList2.SelectedItem.Text == "Select")
			{
				dropDownList.Items.Clear();
				dropDownList.Items.Insert(0, "Select");
				dropDownList.SelectedValue = "Select";
			}
			else
			{
				int selItem = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpListCr")).SelectedValue);
				dropdownCrDr(dropDownList, selItem);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpListCrF_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DropDownList dropDownList = (DropDownList)GridView1.FooterRow.FindControl("DrpListDr");
			DropDownList dropDownList2 = (DropDownList)GridView1.FooterRow.FindControl("DrpListCr");
			if (dropDownList2.SelectedItem.Text == "Select")
			{
				dropDownList.Items.Clear();
				dropDownList.Items.Insert(0, "Select");
				dropDownList.SelectedValue = "Select";
			}
			else
			{
				int selItem = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpListCr")).SelectedValue);
				dropdownCrDr(dropDownList, selItem);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpListCrE_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("DrpListDr0");
			DropDownList dropDownList2 = (DropDownList)gridViewRow.FindControl("DrpListCr0");
			if (dropDownList2.SelectedItem.Text == "Select")
			{
				dropDownList.Items.Clear();
				dropDownList.Items.Insert(0, "Select");
				dropDownList.SelectedValue = "Select";
			}
			else
			{
				int selItem = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpListCr0")).SelectedValue);
				dropdownCrDr(dropDownList, selItem);
			}
		}
		catch (Exception)
		{
		}
	}
}
