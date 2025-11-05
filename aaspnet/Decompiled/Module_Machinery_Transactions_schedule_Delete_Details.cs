using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_schedule_Delete_Details : Page, IRequiresSessionState
{
	protected Label lblItemCode;

	protected Label lblunit;

	protected Label lblBomqty;

	protected Label lblDesc;

	protected Label lblWoNo;

	protected GridView GridView1;

	protected Button Btncancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private int MasterId;

	private string WoNo = "";

	private int FinYearId;

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
				MasterId = Convert.ToInt32(base.Request.QueryString["id"]);
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
			string cmdText = fun.select("ItemId", "tblMS_JobShedule_Master ", " Id='" + MasterId + "'And CompId='" + CompId + "' ");
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
			string cmdText = fun.select("*", "tblMS_JobSchedule_Details", "MId='" + MasterId + "'");
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		FillTempGrid();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string cmdText = fun.delete("tblMS_JobSchedule_Details", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText2 = fun.select("*", "tblMS_JobSchedule_Details", "MId='" + MasterId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				new DataTable();
				sqlDataAdapter.Fill(dataSet);
				string cmdText3 = fun.select("*", "tblMS_JobCompletion", "MId='" + MasterId + "' Order By Id Desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0 && dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText4 = fun.delete("tblMS_JobShedule_Master", "Id='" + MasterId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
				}
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					base.Response.Redirect("~/Module/machinery/transactions/schedule_Delete.aspx?&ModId=15&SubModId=69");
				}
				else
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
		}
		catch (SqlException)
		{
			string empty = string.Empty;
			empty = "It is being used so you can not delete it! ";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/machinery/transactions/schedule_Delete.aspx?&ModId=15&SubModId=69");
	}
}
