using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;

public class Module_Machinery_Transactions_Schedule_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string SId = "";

	private string MachinId = "";

	private string Id = "";

	private int FinYearId;

	protected Label lblMachineName;

	protected TextBox TextBox4;

	protected TextBox TextBox2;

	protected TextBox TextBox3;

	protected RadCalendar RadCalendar1;

	protected GridView GridView1;

	protected Button BtnCancel;

	protected TabPanel PR;

	protected TabContainer TabContainer1;

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
			if (!string.IsNullOrEmpty(base.Request.QueryString["ProcessId"].ToString()))
			{
				Id = base.Request.QueryString["ProcessId"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["MachineId"].ToString()))
			{
				MachinId = base.Request.QueryString["MachineId"].ToString();
				string cmdText = fun.select("tblDG_Item_Master.ManfDesc", " tblDG_Item_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(MachinId) + "' And tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblMachineName.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				}
			}
			if (!Page.IsPostBack)
			{
				RadCalendar1.SelectedDate = Convert.ToDateTime(fun.getCurrDate());
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
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("JobNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BomQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InputQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("OutputQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Process", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Shift", typeof(string)));
			string selectCommandText = fun.select("tblMS_JobSchedule_Details.FromDate,tblMS_JobSchedule_Details.ToDate", "tblMS_JobSchedule_Details,tblMS_JobShedule_Master", "tblMS_JobSchedule_Details.Process='" + Id + "' And tblMS_JobShedule_Master.Id=tblMS_JobSchedule_Details.MId And tblMS_JobShedule_Master.CompId='" + CompId + "' And tblMS_JobSchedule_Details.Released!='1'");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					int days = (Convert.ToDateTime(dataSet.Tables[0].Rows[i][1].ToString()) - Convert.ToDateTime(dataSet.Tables[0].Rows[i][0].ToString())).Days;
					DateTime dateTime = Convert.ToDateTime(dataSet.Tables[0].Rows[i][0].ToString());
					DateTime dateTime2 = Convert.ToDateTime(RadCalendar1.SelectedDate);
					for (int j = 0; j <= days; j++)
					{
						DateTime dateTime3 = Convert.ToDateTime(dateTime.Date.AddDays(j).ToString("MM-dd-yyyy"));
						if (!(dateTime2 == dateTime3))
						{
							continue;
						}
						string cmdText = fun.select("tblMS_JobShedule_Master.Id As MasterId,tblMS_JobSchedule_Details.Id As DetailsId,tblMS_JobShedule_Master.JobNo,tblMS_JobShedule_Master.WONo,tblMS_JobShedule_Master.ItemId,tblMS_JobSchedule_Details.FromDate,tblMS_JobSchedule_Details.ToDate,tblMS_JobSchedule_Details.FromTime,tblMS_JobSchedule_Details.ToTime,tblMS_JobSchedule_Details.Qty As InputQty,tblMS_JobCompletion.OutputQty,tblMS_JobCompletion.UOM,tblMS_JobSchedule_Details.Operator,tblMS_JobSchedule_Details.Process,tblMS_JobSchedule_Details.Shift", "tblMS_JobSchedule_Details,tblMS_JobShedule_Master,tblMS_JobCompletion", " tblMS_JobSchedule_Details.MachineId='" + MachinId + "'And tblMS_JobShedule_Master.CompId='" + CompId + "'And tblMS_JobShedule_Master.FinYearId<='" + FinYearId + "'And tblMS_JobSchedule_Details.FromDate ='" + dataSet.Tables[0].Rows[i][0].ToString() + "'And tblMS_JobSchedule_Details.ToDate ='" + dataSet.Tables[0].Rows[i][1].ToString() + "'And tblMS_JobSchedule_Details.MId=tblMS_JobShedule_Master.Id And tblMS_JobShedule_Master.Id=tblMS_JobCompletion.MId And tblMS_JobCompletion.DId= tblMS_JobSchedule_Details.Id order by tblMS_JobShedule_Master.Id desc ");
						SqlCommand selectCommand = new SqlCommand(cmdText, con);
						DataSet dataSet2 = new DataSet();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count <= 0)
						{
							continue;
						}
						for (int k = 0; k < dataSet2.Tables[0].Rows.Count; k++)
						{
							DataRow dataRow = dataTable.NewRow();
							string cmdText2 = fun.select("tblDG_Item_Master.ManfDesc,tblDG_Item_Master.ItemCode,tblDG_Item_Master.StockQty", " tblDG_Item_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[k]["ItemId"]) + "' And tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' ");
							SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
							DataSet dataSet3 = new DataSet();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
							sqlDataAdapter3.Fill(dataSet3);
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								dataRow[3] = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
								dataRow[4] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
								dataRow[5] = Convert.ToDouble(dataSet3.Tables[0].Rows[0]["StockQty"]);
							}
							string cmdText3 = fun.select("Symbol", " Unit_Master", " Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[k]["UOM"]) + "'");
							SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
							DataSet dataSet4 = new DataSet();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand3);
							sqlDataAdapter4.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								dataRow[6] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							}
							string selectCommandText2 = fun.select("EmployeeName As Operator", "tblHR_OfficeStaff", "CompId='" + CompId + "' And EmpId='" + dataSet2.Tables[0].Rows[k]["Operator"].ToString() + "'");
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText2, con);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5, "tblHR_OfficeStaff");
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								dataRow[13] = dataSet5.Tables[0].Rows[0]["Operator"].ToString();
							}
							string selectCommandText3 = fun.select("ProcessName", "tblPln_Process_Master", "Id='" + dataSet2.Tables[0].Rows[k]["Process"].ToString() + "'");
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommandText3, con);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6, "tblPln_Process_Master");
							if (dataSet6.Tables[0].Rows.Count > 0)
							{
								dataRow[14] = dataSet6.Tables[0].Rows[0]["ProcessName"].ToString();
							}
							dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[k]["MasterId"]);
							dataRow[1] = dataSet2.Tables[0].Rows[k]["WONo"].ToString();
							dataRow[2] = dataSet2.Tables[0].Rows[k]["JobNo"].ToString();
							dataRow[7] = Convert.ToDouble(dataSet2.Tables[0].Rows[k]["InputQty"]);
							dataRow[8] = Convert.ToDouble(dataSet2.Tables[0].Rows[k]["OutputQty"]);
							dataRow[9] = fun.FromDateDMY(dataSet2.Tables[0].Rows[k]["FromDate"].ToString());
							dataRow[10] = fun.FromDateDMY(dataSet2.Tables[0].Rows[k]["ToDate"].ToString());
							dataRow[11] = dataSet2.Tables[0].Rows[k]["FromTime"].ToString();
							dataRow[12] = dataSet2.Tables[0].Rows[k]["ToTime"].ToString();
							if (dataSet2.Tables[0].Rows[0]["Shift"].ToString() == "0")
							{
								dataRow[15] = "Day";
							}
							else
							{
								dataRow[15] = "Night";
							}
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
					}
				}
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		fillgrid();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Schedule_Process_Dashboard.aspx?Id=" + MachinId + "&ModId=15&SubModId=70");
	}

	protected void Page_Init(object sender, EventArgs e)
	{
		RadCalendar1.DayRender += RadCalendar1_DayRender;
	}

	protected void RadCalendar1_DayRender(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
	{
		try
		{
			if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
			{
				e.Cell.Font.Bold = true;
				e.Cell.BackColor = Color.Red;
			}
			string selectCommandText = fun.select("tblMS_JobSchedule_Details.FromDate,tblMS_JobSchedule_Details.ToDate", "tblMS_JobSchedule_Details,tblMS_JobShedule_Master,tblMS_JobCompletion", "tblMS_JobSchedule_Details.Process='" + Id + "' And  tblMS_JobCompletion.DId= tblMS_JobSchedule_Details.Id And tblMS_JobShedule_Master.Id=tblMS_JobSchedule_Details.MId And tblMS_JobSchedule_Details.Released!='1' Order by tblMS_JobSchedule_Details.FromDate Asc");
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblMS_JobSchedule_Details");
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				int days = (Convert.ToDateTime(dataSet.Tables[0].Rows[i][1].ToString()) - Convert.ToDateTime(dataSet.Tables[0].Rows[i][0].ToString())).Days;
				DateTime dateTime = Convert.ToDateTime(dataSet.Tables[0].Rows[i][0].ToString());
				DateTime dateTime2 = Convert.ToDateTime(dataSet.Tables[0].Rows[i][1].ToString());
				Convert.ToDateTime(RadCalendar1.SelectedDate);
				for (int j = 0; j <= days; j++)
				{
					DateTime dateTime3 = Convert.ToDateTime(dateTime.Date.AddDays(j).ToString("MM-dd-yyyy"));
					if (e.Day.Date == dateTime3)
					{
						e.Cell.Font.Bold = true;
						e.Cell.BackColor = Color.Orange;
						if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
						{
							e.Cell.Font.Bold = true;
							e.Cell.BackColor = Color.Red;
						}
					}
					else if (e.Day.Date > dateTime2)
					{
						e.Cell.Font.Bold = true;
						e.Cell.BackColor = Color.PaleGreen;
						if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
						{
							e.Cell.Font.Bold = true;
							e.Cell.BackColor = Color.Red;
						}
					}
				}
			}
			fillgrid();
		}
		catch (Exception)
		{
		}
	}

	protected void RadCalendar1_PreRender(object sender, EventArgs e)
	{
	}
}
