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
using MKB.TimePicker;

public class Module_Machinery_Transactions_Schedule_New_Items : Page, IRequiresSessionState
{
	protected Label lblItemCode;

	protected Label lblunit;

	protected Label lblBomqty;

	protected Label lblDesc;

	protected Label lblWoNo;

	protected GridView GridView1;

	protected GridView GridView2;

	protected Button btnSubmit;

	protected Button Btncancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int itemId;

	private string WoNo = "";

	private int FinYearId;

	private string Type = "";

	private int j;

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
			if (!string.IsNullOrEmpty(base.Request.QueryString["Item"]))
			{
				itemId = Convert.ToInt32(base.Request.QueryString["Item"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WoNo = base.Request.QueryString["WONo"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Type"]))
			{
				Type = base.Request.QueryString["Type"].ToString();
			}
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			DataSet dataSet2 = new DataSet();
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add(new DataColumn("BatchNo", typeof(double)));
			dataTable2.Columns.Add(new DataColumn("Id", typeof(int)));
			if (base.IsPostBack)
			{
				return;
			}
			PrintItem();
			fillDropDown();
			FillTempGrid();
			Databind();
			string cmdText = fun.select("Batches", "SD_Cust_WorkOrder_Master", " WONo='" + WoNo + "'   and   CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter.Fill(dataSet3);
			double num = 0.0;
			if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0]["Batches"] != DBNull.Value)
			{
				double num2 = Convert.ToDouble(dataSet3.Tables[0].Rows[0]["Batches"].ToString());
				for (int i = 1; (double)i <= num2; i++)
				{
					num = i;
					DataRow dataRow = dataTable2.NewRow();
					dataRow[0] = num;
					dataRow[1] = num;
					dataTable2.Rows.Add(dataRow);
					dataTable2.AcceptChanges();
				}
			}
			string cmdText2 = fun.select("tblMS_Master.ItemId,tblMS_Master.Id,tblDG_Item_Master.ManfDesc", "tblMS_Master,tblDG_Item_Master", " tblDG_Item_Master.Id=tblMS_Master.ItemId  And  tblMS_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter2.Fill(dataSet4);
			for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
			{
				string cmdText3 = fun.select("tblPln_Process_Master.Id,tblPln_Process_Master.ProcessName", "tblMS_Process,tblPln_Process_Master", "tblMS_Process.MId='" + dataSet4.Tables[0].Rows[j][1].ToString() + "' AND tblPln_Process_Master.Id=tblMS_Process.PId ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter3.Fill(dataSet5);
				for (int k = 0; k < dataSet5.Tables[0].Rows.Count; k++)
				{
					string cmdText4 = fun.select("tblMS_JobSchedule_Details_Temp.Process", "tblMS_JobSchedule_Details_Temp", "tblMS_JobSchedule_Details_Temp.MachineId='" + dataSet4.Tables[0].Rows[j][0].ToString() + "' AND tblMS_JobSchedule_Details_Temp.Process='" + dataSet5.Tables[0].Rows[k][0].ToString() + "'  And CompId='" + CompId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter4.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count == 0)
					{
						this.j++;
					}
				}
				if (this.j > 0)
				{
					DataRow dataRow2 = dataTable.NewRow();
					dataRow2[0] = dataSet4.Tables[0].Rows[j][2].ToString();
					dataRow2[1] = dataSet4.Tables[0].Rows[j][0].ToString();
					dataTable.Rows.Add(dataRow2);
					dataTable.AcceptChanges();
				}
			}
			dataSet.Tables.Add(dataTable);
			dataSet2.Tables.Add(dataTable2);
			foreach (GridViewRow row in GridView1.Rows)
			{
				((DropDownList)row.FindControl("DrpMachine")).DataSource = dataSet.Tables[0];
				((DropDownList)row.FindControl("DrpMachine")).DataTextField = "ManfDesc";
				((DropDownList)row.FindControl("DrpMachine")).DataValueField = "ItemId";
				((DropDownList)row.FindControl("DrpMachine")).DataBind();
				((DropDownList)row.FindControl("DrpMachine")).Items.Insert(0, "Select");
				((DropDownList)row.FindControl("DrpBatchNO")).DataSource = dataSet2.Tables[0];
				((DropDownList)row.FindControl("DrpBatchNO")).DataTextField = "BatchNo";
				((DropDownList)row.FindControl("DrpBatchNO")).DataValueField = "Id";
				((DropDownList)row.FindControl("DrpBatchNO")).DataBind();
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
			string cmdText = fun.select("tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.ItemCode,tblDG_BOM_Master.Qty", " tblDG_BOM_Master,tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic and tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.WONo='" + WoNo + "' and  tblDG_BOM_Master.ItemId='" + itemId + "' And tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblItemCode.Text = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				List<double> list = new List<double>();
				list = fun.BOMTreeQty(WoNo, Convert.ToInt32(dataSet.Tables[0].Rows[0]["PId"]), Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"]));
				double num = 1.0;
				for (int i = 0; i < list.Count; i++)
				{
					num *= list[i];
				}
				lblBomqty.Text = num.ToString();
				lblDesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				lblunit.Text = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
				lblWoNo.Text = WoNo;
			}
		}
		catch (Exception)
		{
		}
	}

	public void Databind()
	{
		try
		{
			DataTable dataTable = new DataTable();
			DataRow row = dataTable.NewRow();
			dataTable.Rows.Add(row);
			dataTable.AcceptChanges();
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void FillTempGrid()
	{
		try
		{
			string cmdText = fun.select("*", "tblMS_JobSchedule_Details_Temp", "CompId='" + CompId + "'And ItemId='" + itemId + "'");
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
			dataTable.Columns.Add(new DataColumn("Incharge", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("BatchNo", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblDG_Item_Master.ManfDesc", " tblDG_Item_Master", " tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[i]["MachineId"].ToString() + "'  And    tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				DataSet dataSet2 = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				}
				string cmdText3 = fun.select("'['+Symbol+'] '+ProcessName As Process,Id", "tblPln_Process_Master", "Symbol!='0' And Id='" + dataSet.Tables[0].Rows[i]["Process"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet3.Tables[0].Rows[0]["Process"].ToString();
				}
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Type"].ToString()) == 0)
				{
					dataRow[2] = "Fresh";
				}
				else
				{
					dataRow[2] = "Rework";
				}
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Shift"].ToString()) == 0)
				{
					dataRow[3] = "Day";
				}
				else
				{
					dataRow[3] = "Night";
				}
				dataRow[4] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["FromDate"].ToString());
				dataRow[6] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ToDate"].ToString());
				dataRow[7] = dataSet.Tables[0].Rows[i]["FromTime"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["ToTime"].ToString();
				string selectCommandText = fun.select("EmployeeName As Incharge", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet.Tables[0].Rows[i]["Incharge"].ToString() + "'");
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText, con);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblHR_OfficeStaff");
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[9] = dataSet4.Tables[0].Rows[0]["Incharge"].ToString();
				}
				string selectCommandText2 = fun.select("EmployeeName As Operator", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet.Tables[0].Rows[i]["Operator"].ToString() + "'");
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText2, con);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5, "tblHR_OfficeStaff");
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[10] = dataSet5.Tables[0].Rows[0]["Operator"].ToString();
				}
				dataRow[11] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["BatchNo"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
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

	protected void DrpMachine_SelectedIndexChanged(object sender, EventArgs e)
	{
		fillDropDown();
	}

	public void fillDropDown()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((DropDownList)row.FindControl("DrpMachine")).SelectedItem.Text != "Select")
				{
					int num = Convert.ToInt32(((DropDownList)row.FindControl("DrpMachine")).SelectedValue);
					string cmdText = fun.select("Id", "tblMS_Master", " ItemId='" + num + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						string cmdText2 = fun.select("tblPln_Process_Master.Id,tblPln_Process_Master.ProcessName", "tblMS_Process,tblPln_Process_Master", "tblMS_Process.MId='" + dataSet.Tables[0].Rows[0][0].ToString() + "' AND tblPln_Process_Master.Id=tblMS_Process.PId AND tblPln_Process_Master.Id not in (Select Process from tblMS_JobSchedule_Details_Temp where CompId='" + CompId + "' And ItemId='" + itemId + "')");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							((DropDownList)row.FindControl("DrpProcess")).DataSource = dataSet2.Tables[0];
							((DropDownList)row.FindControl("DrpProcess")).DataTextField = "ProcessName";
							((DropDownList)row.FindControl("DrpProcess")).DataValueField = "Id";
							((DropDownList)row.FindControl("DrpProcess")).DataBind();
						}
						else
						{
							((DropDownList)row.FindControl("DrpProcess")).Items.Clear();
						}
					}
					else
					{
						((DropDownList)row.FindControl("DrpProcess")).Items.Clear();
					}
					string cmdText3 = fun.select("*", "tblMS_JobSchedule_Details_Temp", "MachineId='" + ((DropDownList)row.FindControl("DrpMachine")).SelectedValue + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count == 0)
					{
						string cmdText4 = fun.select("ToTime", "tblMS_JobSchedule_Details", "MachineId='" + ((DropDownList)row.FindControl("DrpMachine")).SelectedValue + "' Order By ToTime Desc");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							fun.TimeSelectorDatabase1(dataSet4.Tables[0].Rows[0][0].ToString(), (TimeSelector)row.FindControl("Fdate"));
						}
					}
					else
					{
						string cmdText5 = fun.select("ToTime", "tblMS_JobSchedule_Details_Temp", "MachineId='" + ((DropDownList)row.FindControl("DrpMachine")).SelectedValue + "' Order By ToTime Desc");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							fun.TimeSelectorDatabase1(dataSet5.Tables[0].Rows[0][0].ToString(), (TimeSelector)row.FindControl("Fdate"));
						}
					}
				}
				else
				{
					((DropDownList)row.FindControl("DrpProcess")).Items.Clear();
				}
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
			if (e.CommandName == "Add")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpMachine")).SelectedValue);
				int shift = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("drpshift")).SelectedValue);
				int type = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpType")).SelectedValue);
				double batch = Convert.ToDouble(((DropDownList)gridViewRow.FindControl("DrpBatchNO")).SelectedValue);
				int proId = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpProcess")).SelectedValue);
				string fromDt = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtFdate")).Text);
				string toDt = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtTdate")).Text);
				string fromTime = ((TimeSelector)gridViewRow.FindControl("Fdate")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Fdate")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Fdate")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("Fdate")).AmPm;
				string toTime = ((TimeSelector)gridViewRow.FindControl("Tdate")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Tdate")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Tdate")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("Tdate")).AmPm;
				double qty = Convert.ToDouble(((TextBox)gridViewRow.FindControl("TxtBatchQty")).Text);
				string code = fun.getCode(((TextBox)gridViewRow.FindControl("TxtIncharge")).Text);
				string code2 = fun.getCode(((TextBox)gridViewRow.FindControl("TxtOperator")).Text);
				string lastDate = "";
				string lastTime = "";
				string cmdText = fun.select("*", "tblMS_JobSchedule_Details_Temp", "MachineId='" + num + "' Order By Id Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					AddToTemp("tblMS_JobSchedule_Details", num, shift, type, batch, proId, fromDt, toDt, fromTime, toTime, qty, code, code2, lastDate, lastTime, "And Released!=1");
				}
				else
				{
					AddToTemp("tblMS_JobSchedule_Details_Temp", num, shift, type, batch, proId, fromDt, toDt, fromTime, toTime, qty, code, code2, lastDate, lastTime, "");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				con.Open();
				string cmdText = fun.delete("tblMS_JobSchedule_Details_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "' AND Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		FillTempGrid();
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string cmdText = fun.select("JobNo", "tblMS_JobShedule_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by JobNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("*", "tblMS_JobSchedule_Details_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "' Order by Id desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblMS_JobSchedule_Details_Temp");
			int num = 0;
			int num2 = 0;
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string cmdText3 = fun.insert("tblMS_JobShedule_Master", "SysDate ,SysTime,SessionId,CompId,FinYearId,JobNo ,WONo,ItemId", "'" + currDate + "','" + currTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + WoNo + "','" + itemId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText4 = fun.select("Id", "tblMS_JobShedule_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by Id desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				int num3 = 0;
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					num3 = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString());
				}
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					string cmdText5 = fun.insert("tblMS_JobSchedule_Details", "MId,Shift,MachineId,Type,FromDate,ToDate,FromTime,ToTime,Process,Qty,Incharge,Operator,BatchNo", "'" + num3 + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Shift"]) + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["MachineId"]) + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Type"]) + "','" + dataSet2.Tables[0].Rows[i]["FromDate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ToDate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["FromTime"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ToTime"].ToString() + "','" + Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Process"]) + "','" + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Qty"]) + "','" + dataSet2.Tables[0].Rows[i]["Incharge"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Operator"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["BatchNo"].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					num2++;
				}
				if (num2 > 0)
				{
					string cmdText6 = fun.delete("tblMS_JobSchedule_Details_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
				}
				num++;
			}
			else
			{
				string empty = string.Empty;
				empty = "No records found to proceed.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num > 0)
			{
				base.Response.Redirect("~/Module/Machinery/Transactions/Schedule_New_Details.aspx?WONo=" + WoNo + "&Type=" + Type + "&Item=" + itemId + "&ModId=15&SubModId=69");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Machinery/Transactions/Schedule_New_Details.aspx?WONo=" + WoNo + "&Type=" + Type + "&ModId=15&SubModId=69");
	}

	public void AddToTemp(string tblName, int MachineId, int Shift, int Type, double Batch, int ProId, string FromDt, string ToDt, string FromTime, string ToTime, double Qty, string Incharge, string Operator, string LastDate, string LastTime, string IsReleased)
	{
		try
		{
			if (Convert.ToDateTime(FromDt.ToString()) < Convert.ToDateTime(ToDt.ToString()))
			{
				string cmdText = fun.select("ToDate,ToTime", tblName ?? "", "MachineId='" + MachineId + "' " + IsReleased + " Order By ToDate Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					LastDate = dataSet.Tables[0].Rows[0][0].ToString();
					LastTime = dataSet.Tables[0].Rows[0][1].ToString();
					if (Convert.ToDateTime(dataSet.Tables[0].Rows[0][0].ToString()).Date <= Convert.ToDateTime(FromDt).Date && Convert.ToDateTime(dataSet.Tables[0].Rows[0][1].ToString()).TimeOfDay < Convert.ToDateTime(FromTime).TimeOfDay)
					{
						string cmdText2 = fun.insert("tblMS_JobSchedule_Details_Temp", "CompId,SessionId,Shift,Type,FromDate,ToDate,FromTime,ToTime,Process,Qty,Incharge,Operator,MachineId,ItemId,BatchNo", "'" + CompId + "','" + SId + "','" + Shift + "','" + Type + "','" + FromDt + "','" + ToDt + "','" + FromTime + "','" + ToTime + "','" + ProId + "','" + Qty + "','" + Incharge + "','" + Operator + "','" + MachineId + "','" + itemId + "','" + Batch + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
						con.Open();
						sqlCommand.ExecuteNonQuery();
						con.Close();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						empty = "Machine is busy upto " + fun.FromDateDMY(LastDate) + "," + LastTime;
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else
				{
					string cmdText3 = fun.insert("tblMS_JobSchedule_Details_Temp", "CompId,SessionId,Shift,Type,FromDate,ToDate,FromTime,ToTime,Process,Qty,Incharge,Operator,MachineId,ItemId,BatchNo", "'" + CompId + "','" + SId + "','" + Shift + "','" + Type + "','" + FromDt + "','" + ToDt + "','" + FromTime + "','" + ToTime + "','" + ProId + "','" + Qty + "','" + Incharge + "','" + Operator + "','" + MachineId + "','" + itemId + "','" + Batch + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else if (Convert.ToDateTime(FromDt.ToString()) == Convert.ToDateTime(ToDt.ToString()))
			{
				string cmdText4 = fun.select("ToDate,ToTime", tblName ?? "", "MachineId='" + MachineId + "' " + IsReleased + " Order By ToDate Desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					LastDate = dataSet2.Tables[0].Rows[0][0].ToString();
					LastTime = dataSet2.Tables[0].Rows[0][1].ToString();
					if (Convert.ToDateTime(dataSet2.Tables[0].Rows[0][0].ToString()).Date <= Convert.ToDateTime(FromDt).Date && Convert.ToDateTime(dataSet2.Tables[0].Rows[0][1].ToString()).TimeOfDay < Convert.ToDateTime(FromTime).TimeOfDay && Convert.ToDateTime(FromTime).TimeOfDay < Convert.ToDateTime(ToTime).TimeOfDay)
					{
						string cmdText5 = fun.insert("tblMS_JobSchedule_Details_Temp", "CompId,SessionId,Shift,Type,FromDate,ToDate,FromTime,ToTime,Process,Qty,Incharge,Operator,MachineId,ItemId,BatchNo", "'" + CompId + "','" + SId + "','" + Shift + "','" + Type + "','" + FromDt + "','" + ToDt + "','" + FromTime + "','" + ToTime + "','" + ProId + "','" + Qty + "','" + Incharge + "','" + Operator + "','" + MachineId + "','" + itemId + "','" + Batch + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
						con.Open();
						sqlCommand3.ExecuteNonQuery();
						con.Close();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "From Time Should Be Less than To Time.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string cmdText6 = fun.insert("tblMS_JobSchedule_Details_Temp", "CompId,SessionId,Shift,Type,FromDate,ToDate,FromTime,ToTime,Process,Qty,Incharge,Operator,MachineId,ItemId,BatchNo", "'" + CompId + "','" + SId + "','" + Shift + "','" + Type + "','" + FromDt + "','" + ToDt + "','" + FromTime + "','" + ToTime + "','" + ProId + "','" + Qty + "','" + Incharge + "','" + Operator + "','" + MachineId + "','" + itemId + "','" + Batch + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand4.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "From Date Should Be Less than To Date.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}
