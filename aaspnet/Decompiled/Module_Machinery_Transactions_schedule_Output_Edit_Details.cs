using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_schedule_Output_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int itemId;

	private string WoNo = "";

	private int FinYearId;

	protected Label lblItemCode;

	protected Label lblunit;

	protected Label lblBomqty;

	protected Label lblDesc;

	protected Label lblWoNo;

	protected GridView GridView1;

	protected Button Btncancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			itemId = Convert.ToInt32(base.Request.QueryString["id"]);
			WoNo = base.Request.QueryString["WONo"].ToString();
			if (!base.IsPostBack)
			{
				PrintItem();
				FillTempGrid();
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblID")).Text);
				string cmdText = fun.select("tblMS_JobSchedule_Details.Released", "tblMS_JobSchedule_Details,tblMS_JobShedule_Master", "tblMS_JobShedule_Master.CompId=" + CompId + "And  tblMS_JobShedule_Master.Id=tblMS_JobSchedule_Details.MId And tblMS_JobSchedule_Details.Id='" + num + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				new DataTable();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0][0].ToString() == "1")
					{
						((LinkButton)row.FindControl("LinkButton1")).Visible = false;
						((LinkButton)row.FindControl("linkRelease")).Visible = false;
						((LinkButton)row.FindControl("linkUnRelease")).Visible = true;
					}
					else
					{
						((LinkButton)row.FindControl("LinkButton1")).Visible = true;
						((LinkButton)row.FindControl("linkRelease")).Visible = true;
						((LinkButton)row.FindControl("linkUnRelease")).Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void PrintItem()
	{
		try
		{
			string cmdText = fun.select("ItemId", "tblMS_JobShedule_Master ", " Id='" + itemId + "'And CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			string cmdText2 = fun.select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty", " tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + WoNo + "' and  tblDG_BOM_Master.ItemId='" + dataSet.Tables[0].Rows[0][0].ToString() + "' And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			DataSet dataSet2 = new DataSet();
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				lblItemCode.Text = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(WoNo, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet2.Tables[0].Rows[0]["CId"]));
				double num = 1.0;
				for (int i = 0; i < list.Count; i++)
				{
					num *= list[i];
				}
				lblBomqty.Text = num.ToString();
				lblDesc.Text = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				lblunit.Text = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
			}
			lblWoNo.Text = WoNo;
		}
		catch (Exception)
		{
		}
	}

	public void FillTempGrid()
	{
		try
		{
			string cmdText = fun.select("*", "tblMS_JobCompletion", "MId='" + itemId + "' Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("MachineName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Shift", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BatchNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OutPutQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("outputId", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblMS_JobSchedule_Details.MachineId,tblMS_JobSchedule_Details.Process,tblMS_JobSchedule_Details.Type,tblMS_JobSchedule_Details.Shift,tblMS_JobSchedule_Details.Qty,tblMS_JobSchedule_Details.FromDate,tblMS_JobSchedule_Details.ToDate,tblMS_JobSchedule_Details.FromTime,tblMS_JobSchedule_Details.ToTime,tblMS_JobSchedule_Details.Operator,tblMS_JobSchedule_Details.BatchNo,tblMS_JobSchedule_Details.Id,tblMS_JobSchedule_Details.MId", "tblMS_JobSchedule_Details,tblMS_JobShedule_Master", "tblMS_JobShedule_Master.CompId=" + CompId + "And tblMS_JobShedule_Master.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["MId"]) + "' AND tblMS_JobShedule_Master.Id=tblMS_JobSchedule_Details.MId And tblMS_JobSchedule_Details.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["DId"]) + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string cmdText3 = fun.select("tblDG_Item_Master.ManfDesc", " tblDG_Item_Master", " tblDG_Item_Master.Id='" + dataSet2.Tables[0].Rows[0]["MachineId"].ToString() + "' And tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					DataSet dataSet3 = new DataSet();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
					string cmdText4 = fun.select("'['+Symbol+'] '+ProcessName As Process,Id", "tblPln_Process_Master", "Symbol!='0' And Id='" + dataSet2.Tables[0].Rows[0]["Process"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[1] = dataSet4.Tables[0].Rows[0]["Process"].ToString();
					}
					int num = 0;
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Type"].ToString()) == 0)
					{
						dataRow[2] = "Fresh";
					}
					else
					{
						dataRow[2] = "Rework";
					}
					int num2 = 0;
					if (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Shift"]) == 0)
					{
						dataRow[3] = "Day";
					}
					else
					{
						dataRow[3] = "Night";
					}
					double num3 = 0.0;
					num3 = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Qty"]);
					dataRow[4] = num3;
					dataRow[5] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["FromDate"].ToString());
					dataRow[6] = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["ToDate"].ToString());
					dataRow[7] = dataSet2.Tables[0].Rows[0]["FromTime"].ToString();
					dataRow[8] = dataSet2.Tables[0].Rows[0]["ToTime"].ToString();
					dataRow[9] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["MId"]);
					string selectCommandText = fun.select("EmployeeName As Operator", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet2.Tables[0].Rows[0]["Operator"].ToString() + "'");
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText, con);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "tblHR_OfficeStaff");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = dataSet5.Tables[0].Rows[0]["Operator"].ToString();
					}
					dataRow[11] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"]);
					if (!string.IsNullOrEmpty(dataSet2.Tables[0].Rows[0]["BatchNo"].ToString()))
					{
						dataRow[12] = dataSet2.Tables[0].Rows[0]["BatchNo"].ToString();
					}
					else
					{
						dataRow[12] = "";
					}
				}
				dataRow[13] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["OutputQty"]);
				string selectCommandText2 = fun.select("Symbol", "Unit_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["UOM"], "' "));
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText2, con);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6, "Unit_Master");
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					dataRow[14] = dataSet6.Tables[0].Rows[0]["Symbol"].ToString();
				}
				dataRow[15] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable.DefaultView;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
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

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Machinery/Transactions/Schedule_Output_Edit.aspx?ModId=15&SubModId=70");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		FillTempGrid();
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("Drpunit")).SelectedValue);
			double num3 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("TxtoutputQty")).Text);
			con.Open();
			string cmdText = "UPDATE tblMS_JobCompletion SET OutputQty='" + num3 + "', UOM = '" + num2 + "' WHERE Id ='" + num + "'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
			FillTempGrid();
			GridViewRow gridViewRow = GridView1.Rows[e.NewEditIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lbloutputId")).Text);
			string cmdText = fun.select("*", "tblMS_JobCompletion", "Id='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			DataSet dataSet2 = new DataSet();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			string cmdText2 = fun.select1("Symbol,Id", "Unit_Master");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter2.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet3.Tables[0].Rows[i]["Symbol"].ToString();
					dataRow[1] = Convert.ToInt32(dataSet3.Tables[0].Rows[i]["Id"]);
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			dataSet2.Tables.Add(dataTable);
			GridViewRow gridViewRow2 = GridView1.Rows[e.NewEditIndex];
			((DropDownList)gridViewRow2.FindControl("DrpUnit")).DataSource = dataSet2.Tables[0];
			((DropDownList)gridViewRow2.FindControl("DrpUnit")).DataTextField = "Symbol";
			((DropDownList)gridViewRow2.FindControl("DrpUnit")).DataValueField = "Id";
			((DropDownList)gridViewRow2.FindControl("DrpUnit")).DataBind();
			((DropDownList)gridViewRow2.FindControl("DrpUnit")).Items.Insert(0, "Select");
			((DropDownList)gridViewRow.FindControl("Drpunit")).SelectedValue = dataSet.Tables[0].Rows[0]["UOM"].ToString();
			((TextBox)gridViewRow.FindControl("TxtoutputQty")).Text = dataSet.Tables[0].Rows[0]["OutputQty"].ToString();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			FillTempGrid();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Release")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblID")).Text);
				con.Open();
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string cmdText = "UPDATE tblMS_JobSchedule_Details SET Released='1', ReleasedDate = '" + currDate + "',ReleasedTime='" + currTime + "',ReleasedBy='" + SId + "' WHERE Id ='" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Unrelease")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num2 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblID")).Text);
				con.Open();
				string cmdText2 = "UPDATE tblMS_JobSchedule_Details SET Released='0',ReleasedDate ='',ReleasedTime='',ReleasedBy='' WHERE Id ='" + num2 + "'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}
}
