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

public class Module_Machinery_Transactions_Schedule_Edit_Details : Page, IRequiresSessionState
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
			WoNo = base.Request.QueryString["WONo"].ToString();
			if (!string.IsNullOrEmpty(base.Request.QueryString["id"].ToString()))
			{
				itemId = Convert.ToInt32(base.Request.QueryString["id"]);
			}
			if (!base.IsPostBack)
			{
				PrintItem();
				FillTempGrid();
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
			string cmdText = fun.select("*", "tblMS_JobSchedule_Details", "MId='" + itemId + "' order By Id Desc");
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
				string selectCommandText = fun.select("EmployeeName+'['+EmpId+'] ' As Incharge", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet.Tables[0].Rows[i]["Incharge"].ToString() + "'");
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText, con);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblHR_OfficeStaff");
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[9] = dataSet4.Tables[0].Rows[0]["Incharge"].ToString();
				}
				string selectCommandText2 = fun.select("EmployeeName+'['+EmpId+'] ' As Operator", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet.Tables[0].Rows[i]["Operator"].ToString() + "'");
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
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/machinery/transactions/schedule_Edit.aspx?&ModId=15&SubModId=69");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		FillTempGrid();
	}

	protected void DrpMachine_SelectedIndexChanged(object sender, EventArgs e)
	{
		fillDropDown();
	}

	public void fillDropDown()
	{
		try
		{
			if (GridView1.EditIndex == -1)
			{
				return;
			}
			if (((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpMachine")).SelectedItem.Text != "Select")
			{
				int num = Convert.ToInt32(((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpMachine")).SelectedValue);
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
						((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).DataSource = dataSet2.Tables[0];
						((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).DataTextField = "ProcessName";
						((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).DataValueField = "Id";
						((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).DataBind();
					}
					else
					{
						((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).Items.Clear();
					}
				}
				else
				{
					((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).Items.Clear();
				}
			}
			else
			{
				((DropDownList)GridView1.Rows[GridView1.EditIndex].FindControl("DrpProcess")).Items.Clear();
			}
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
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("BatchNo", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			string cmdText = fun.select("Batches", "SD_Cust_WorkOrder_Master", " WONo='" + WoNo + "'   and   CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter.Fill(dataSet2);
			double num = 0.0;
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				double num2 = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Batches"]);
				for (int i = 1; (double)i <= num2; i++)
				{
					num = i;
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = num;
					dataRow[1] = num;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			dataSet.Tables.Add(dataTable);
			string cmdText2 = fun.select("tblMS_Master.ItemId,tblDG_Item_Master.ManfDesc", "tblMS_Master,tblDG_Item_Master", " tblDG_Item_Master.Id=tblMS_Master.ItemId  And  tblMS_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter2.Fill(dataSet3);
			GridViewRow gridViewRow = GridView1.Rows[e.NewEditIndex];
			((DropDownList)gridViewRow.FindControl("DrpBatchNO")).DataSource = dataSet.Tables[0];
			((DropDownList)gridViewRow.FindControl("DrpBatchNO")).DataTextField = "BatchNo";
			((DropDownList)gridViewRow.FindControl("DrpBatchNO")).DataValueField = "Id";
			((DropDownList)gridViewRow.FindControl("DrpBatchNO")).DataBind();
			((DropDownList)gridViewRow.FindControl("DrpBatchNO")).Items.Insert(0, "Select");
			((DropDownList)gridViewRow.FindControl("DrpMachine")).DataSource = dataSet3.Tables[0];
			((DropDownList)gridViewRow.FindControl("DrpMachine")).DataTextField = "ManfDesc";
			((DropDownList)gridViewRow.FindControl("DrpMachine")).DataValueField = "ItemId";
			((DropDownList)gridViewRow.FindControl("DrpMachine")).DataBind();
			((DropDownList)gridViewRow.FindControl("DrpMachine")).Items.Insert(0, "Select");
			int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			string cmdText3 = fun.select("*", "tblMS_JobSchedule_Details", "Id='" + num3 + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter3.Fill(dataSet4);
			if (dataSet4.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			((DropDownList)gridViewRow.FindControl("DrpMachine")).SelectedValue = dataSet4.Tables[0].Rows[0]["MachineId"].ToString();
			if (((DropDownList)gridViewRow.FindControl("DrpMachine")).SelectedItem.Text != "Select")
			{
				Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpMachine")).SelectedValue);
				fillDropDown();
				((DropDownList)gridViewRow.FindControl("DrpProcess")).SelectedValue = dataSet4.Tables[0].Rows[0]["Process"].ToString();
				((DropDownList)gridViewRow.FindControl("DrpBatchNO")).SelectedValue = dataSet4.Tables[0].Rows[0]["BatchNO"].ToString();
				((DropDownList)gridViewRow.FindControl("DrpShift")).SelectedValue = dataSet4.Tables[0].Rows[0]["Shift"].ToString();
				((DropDownList)gridViewRow.FindControl("DrpType")).SelectedValue = dataSet4.Tables[0].Rows[0]["Type"].ToString();
				((TextBox)gridViewRow.FindControl("TxtBatchQty")).Text = dataSet4.Tables[0].Rows[0]["Qty"].ToString();
				((TextBox)gridViewRow.FindControl("TxtFdate")).Text = fun.FromDate(dataSet4.Tables[0].Rows[0]["FromDate"].ToString());
				((TextBox)gridViewRow.FindControl("TxtTdate")).Text = fun.FromDate(dataSet4.Tables[0].Rows[0]["ToDate"].ToString());
				string selectCommandText = fun.select("EmployeeName+'['+EmpId+']' As Incharge", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet4.Tables[0].Rows[0]["Incharge"].ToString() + "'");
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommandText, con);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter4.Fill(dataSet5, "tblHR_OfficeStaff");
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					((TextBox)gridViewRow.FindControl("TxtIncharge")).Text = dataSet5.Tables[0].Rows[0]["Incharge"].ToString();
				}
				string selectCommandText2 = fun.select("EmployeeName+'['+EmpId+'] ' As Operator", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet4.Tables[0].Rows[0]["Operator"].ToString() + "'");
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText2, con);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter5.Fill(dataSet6, "tblHR_OfficeStaff");
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					((TextBox)gridViewRow.FindControl("TxtOperator")).Text = dataSet6.Tables[0].Rows[0]["Operator"].ToString();
				}
				string cmdText4 = fun.select("FromDate,FromTime", "tblMS_JobSchedule_Details", "MachineId='" + dataSet4.Tables[0].Rows[0]["MachineId"].ToString() + "'And Process='" + dataSet4.Tables[0].Rows[0]["Process"].ToString() + "'And Released!='1' And FromDate >='" + dataSet4.Tables[0].Rows[0]["ToDate"].ToString() + "'  Order By FromDate Asc");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter6.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0 && Convert.ToDateTime(fun.FromDate(((TextBox)gridViewRow.FindControl("TxtTdate")).Text)).Date == Convert.ToDateTime(dataSet7.Tables[0].Rows[0][0].ToString()).Date)
				{
					fun.TimeSelectorDatabase2(dataSet7.Tables[0].Rows[0]["FromTime"].ToString(), (TimeSelector)gridViewRow.FindControl("Tdate"));
				}
			}
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

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			int machineId = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpMachine")).SelectedValue);
			int proId = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpProcess")).SelectedValue);
			int type = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpType")).SelectedValue);
			int shift = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpShift")).SelectedValue);
			int num = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpBatchNO")).SelectedValue);
			double qty = Convert.ToDouble(((TextBox)gridViewRow.FindControl("TxtBatchQty")).Text);
			string fromDt = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtFdate")).Text);
			string toDt = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtTdate")).Text);
			string fromTime = ((TimeSelector)gridViewRow.FindControl("Fdate")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Fdate")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Fdate")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("Fdate")).AmPm;
			string toTime = ((TimeSelector)gridViewRow.FindControl("Tdate")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Tdate")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("Tdate")).Second.ToString("D2") + " " + ((TimeSelector)gridViewRow.FindControl("Tdate")).AmPm;
			string code = fun.getCode(((TextBox)gridViewRow.FindControl("TxtIncharge")).Text);
			string code2 = fun.getCode(((TextBox)gridViewRow.FindControl("TxtOperator")).Text);
			string lastDate = "";
			string lastTime = "";
			AddToTemp("tblMS_JobSchedule_Details", machineId, shift, type, num, proId, fromDt, toDt, fromTime, toTime, qty, code, code2, lastDate, lastTime, "And Released!=1", id);
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
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

	public void AddToTemp(string tblName, int MachineId, int Shift, int Type, double Batch, int ProId, string FromDt, string ToDt, string FromTime, string ToTime, double Qty, string Incharge, string Operator, string LastDate, string LastTime, string IsReleased, int Id)
	{
		try
		{
			string text = "";
			int num = 0;
			if (Convert.ToDateTime(FromDt.ToString()) < Convert.ToDateTime(ToDt.ToString()))
			{
				string cmdText = fun.select("ToDate,ToTime,FromDate", "tblMS_JobSchedule_Details", "MachineId='" + MachineId + "'And Id='" + Id + "' " + IsReleased + " Order By ToDate Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					return;
				}
				LastDate = dataSet.Tables[0].Rows[0][0].ToString();
				string text2 = "";
				text2 = ((!(Convert.ToDateTime(dataSet.Tables[0].Rows[0][2].ToString()).Date == Convert.ToDateTime(LastDate).Date)) ? fun.select("FromDate,FromTime", tblName ?? "", "MachineId='" + MachineId + "'And Process='" + ProId + "' " + IsReleased + " And FromDate >='" + LastDate + "'  Order By FromDate Asc") : fun.select("FromDate,FromTime", tblName ?? "", "MachineId='" + MachineId + "'And Process='" + ProId + "' " + IsReleased + " And FromDate >'" + LastDate + "'  Order By FromDate Asc"));
				SqlCommand selectCommand2 = new SqlCommand(text2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					text = dataSet2.Tables[0].Rows[0][0].ToString();
					num = (Convert.ToDateTime(text) - Convert.ToDateTime(LastDate)).Days;
					if (num >= 0 && Convert.ToDateTime(ToDt).Date <= Convert.ToDateTime(text).Date)
					{
						string cmdText2 = fun.update("tblMS_JobSchedule_Details", "Shift='" + Shift + "',Type='" + Type + "',FromDate='" + FromDt + "',ToDate='" + ToDt + "',FromTime='" + FromTime + "',ToTime='" + ToTime + "',Process='" + ProId + "',Qty='" + Qty + "',Incharge='" + Incharge + "',Operator='" + Operator + "',MachineId='" + MachineId + "',BatchNo='" + Batch + "'", "Id='" + Id + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
						con.Open();
						sqlCommand.ExecuteNonQuery();
						con.Close();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						empty = "Machine is busy upto " + fun.FromDateDMY(text) + "," + LastTime;
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else if (dataSet2.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.update("tblMS_JobSchedule_Details", "Shift='" + Shift + "',Type='" + Type + "',FromDate='" + FromDt + "',ToDate='" + ToDt + "',FromTime='" + FromTime + "',ToTime='" + ToTime + "',Process='" + ProId + "',Qty='" + Qty + "',Incharge='" + Incharge + "',Operator='" + Operator + "',MachineId='" + MachineId + "',BatchNo='" + Batch + "'", "Id='" + Id + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else if (Convert.ToDateTime(FromDt.ToString()) == Convert.ToDateTime(ToDt.ToString()))
			{
				string text3 = "";
				string cmdText4 = fun.select("ToDate,ToTime,FromDate", tblName ?? "", "MachineId='" + MachineId + "' And Id='" + Id + "'" + IsReleased + " Order By ToDate Desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count <= 0)
				{
					return;
				}
				text3 = dataSet3.Tables[0].Rows[0][2].ToString();
				LastDate = dataSet3.Tables[0].Rows[0][0].ToString();
				LastTime = dataSet3.Tables[0].Rows[0][1].ToString();
				string cmdText5 = fun.select("FromDate,FromTime", tblName ?? "", "MachineId='" + MachineId + "'And Process='" + ProId + "' " + IsReleased + " And FromDate >='" + LastDate + "'  Order By FromDate Asc");
				SqlCommand selectCommand4 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					text = dataSet4.Tables[0].Rows[0][0].ToString();
					num = (Convert.ToDateTime(text) - Convert.ToDateTime(LastDate)).Days;
					if (num >= 0)
					{
						if (Convert.ToDateTime(FromTime).TimeOfDay < Convert.ToDateTime(ToTime).TimeOfDay)
						{
							string cmdText6 = fun.update("tblMS_JobSchedule_Details", "Shift='" + Shift + "',Type='" + Type + "',FromDate='" + FromDt + "',ToDate='" + ToDt + "',FromTime='" + FromTime + "',ToTime='" + ToTime + "',Process='" + ProId + "',Qty='" + Qty + "',Incharge='" + Incharge + "',Operator='" + Operator + "',MachineId='" + MachineId + "',BatchNo='" + Batch + "'", "Id='" + Id + "'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
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
						string empty3 = string.Empty;
						empty3 = "Machine is busy  from " + fun.FromDateDMY(text3) + " to " + fun.FromDateDMY(LastDate) + "," + LastTime;
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
					}
				}
				else if (dataSet4.Tables[0].Rows.Count == 0)
				{
					string cmdText7 = fun.update("tblMS_JobSchedule_Details", "Shift='" + Shift + "',Type='" + Type + "',FromDate='" + FromDt + "',ToDate='" + ToDt + "',FromTime='" + FromTime + "',ToTime='" + ToTime + "',Process='" + ProId + "',Qty='" + Qty + "',Incharge='" + Incharge + "',Operator='" + Operator + "',MachineId='" + MachineId + "',BatchNo='" + Batch + "'", "Id='" + Id + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText7, con);
					con.Open();
					sqlCommand4.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "From Date Should Be Less than To Date.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}
