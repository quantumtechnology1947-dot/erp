using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using MKB.TimePicker;

public class Module_Machinery_Transactions_PMBM_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int itemId;

	private int PMBMId;

	private int MachineId;

	protected Label lblItemCode;

	protected Label lblUOM;

	protected Label lblName;

	protected Label lblModel;

	protected Label lblMake;

	protected Label lblCapacity;

	protected Label lblLocation;

	protected DropDownList DDLMaintenance;

	protected TextBox txtFromDate;

	protected CalendarExtender CalendarFromDate;

	protected RequiredFieldValidator ReqFromDate;

	protected RegularExpressionValidator RegularFromDate;

	protected TextBox txtToDate;

	protected CalendarExtender CalendarExtender1;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TimeSelector TSFromTime;

	protected TimeSelector TSToTime;

	protected TextBox txtNameOfAgency;

	protected RequiredFieldValidator ReqFromDate0;

	protected TextBox txtNameOfEngineer;

	protected RequiredFieldValidator ReqFromDate1;

	protected TextBox txtNextPMDueOn;

	protected CalendarExtender CalendarExtender2;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected TextBox txtRemarks;

	protected RequiredFieldValidator ReqFromDate2;

	protected Label Label2;

	protected GridView GridView5;

	protected Button btnProceed;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string value = base.Request.QueryString["PMBMId"];
			PMBMId = Convert.ToInt32(value);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			ValidateTextBox();
			if (base.IsPostBack)
			{
				return;
			}
			string cmdText = fun.select("MachineId", "tblMS_PMBM_Master", "Id='" + PMBMId + "' AND CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				MachineId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["MachineId"]);
				string cmdText2 = fun.select("ItemId", "tblMS_Master", "Id='" + MachineId + "'AND CompId='" + CompId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					itemId = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
				}
				string cmdText3 = fun.select("*", "tblMS_Master", " ItemId='" + itemId + "'AND Id='" + MachineId + "' AND CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					lblModel.Text = dataSet3.Tables[0].Rows[0]["Model"].ToString();
					lblMake.Text = dataSet3.Tables[0].Rows[0]["Make"].ToString();
					lblCapacity.Text = dataSet3.Tables[0].Rows[0]["Capacity"].ToString();
					lblLocation.Text = dataSet3.Tables[0].Rows[0]["Location"].ToString();
				}
			}
			string cmdText4 = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic, tblDG_Item_Master.ItemCode ", " tblDG_Category_Master,tblDG_Item_Master,Unit_Master", " tblDG_Item_Master.CId=tblDG_Category_Master.CId AND Unit_Master.Id=tblDG_Item_Master.UOMBasic  AND tblDG_Item_Master.Id='" + itemId + "' AND tblDG_Item_Master.CompId='" + CompId + "'  ");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			if (dataSet4.Tables[0].Rows.Count > 0)
			{
				lblItemCode.Text = dataSet4.Tables[0].Rows[0]["ItemCode"].ToString();
				lblUOM.Text = dataSet4.Tables[0].Rows[0]["UOMBasic"].ToString();
				lblName.Text = dataSet4.Tables[0].Rows[0]["ManfDesc"].ToString();
			}
			string cmdText5 = fun.select("*", "tblMS_PMBM_Master", " MachineId='" + MachineId + "' AND Id ='" + PMBMId + "' AND  CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			if (dataSet5.Tables[0].Rows.Count > 0)
			{
				txtFromDate.Text = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["FromDate"].ToString());
				txtToDate.Text = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["ToDate"].ToString());
				txtNameOfAgency.Text = dataSet5.Tables[0].Rows[0]["NameOfAgency"].ToString();
				txtNameOfEngineer.Text = dataSet5.Tables[0].Rows[0]["NameOfEngineer"].ToString();
				txtNextPMDueOn.Text = fun.FromDateDMY(dataSet5.Tables[0].Rows[0]["NextPMDueOn"].ToString());
				txtRemarks.Text = dataSet5.Tables[0].Rows[0]["Remarks"].ToString();
				DDLMaintenance.SelectedValue = dataSet5.Tables[0].Rows[0]["PMBM"].ToString();
				fun.TimeSelectorDatabase(dataSet5.Tables[0].Rows[0]["FromTime"].ToString(), TSFromTime);
				fun.TimeSelectorDatabase(dataSet5.Tables[0].Rows[0]["ToTime"].ToString(), TSToTime);
			}
			LoadDataSpareMaster();
		}
		catch (Exception)
		{
		}
	}

	public void LoadDataSpareMaster()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AvailedQty", typeof(string)));
			string cmdText = fun.select("tblMS_Spares.Id,tblMS_Spares.MId,tblMS_Spares.ItemId,tblMS_Spares.Qty", "tblMS_Spares,tblMS_Master", " tblMS_Spares.MId=tblMS_Master.Id And tblMS_Master.ItemId='" + itemId + "' order By tblMS_Spares.Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["ItemId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.StockQty", "tblDG_Item_Master,Unit_Master,vw_Unit_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "' AND Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[2] = dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString();
					dataRow[5] = dataSet2.Tables[0].Rows[0]["StockQty"].ToString();
				}
				dataRow[3] = dataSet.Tables[0].Rows[i]["Qty"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView5.DataSource = dataTable;
			GridView5.DataBind();
			foreach (GridViewRow row in GridView5.Rows)
			{
				string cmdText3 = fun.select("tblMS_PMBM_Details.SpareId,tblMS_PMBM_Details.Qty AS AvailedQty ", "tblMS_PMBM_Details,tblMS_PMBM_Master", " tblMS_PMBM_Details.MId=tblMS_PMBM_Master.Id And tblMS_PMBM_Details.MId='" + PMBMId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
				{
					if (Convert.ToInt32(((Label)row.FindControl("lblId")).Text) == Convert.ToInt32(dataSet3.Tables[0].Rows[j]["SpareId"]))
					{
						((CheckBox)row.FindControl("chkSpare")).Checked = true;
						((TextBox)row.FindControl("txtQty")).Text = dataSet3.Tables[0].Rows[j]["AvailedQty"].ToString();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = TSFromTime.Hour.ToString("D2") + ":" + TSFromTime.Minute.ToString("D2") + ":" + TSFromTime.Second.ToString("D2") + " " + TSFromTime.AmPm;
			string text2 = TSToTime.Hour.ToString("D2") + ":" + TSToTime.Minute.ToString("D2") + ":" + TSToTime.Second.ToString("D2") + " " + TSToTime.AmPm;
			if (txtFromDate.Text != "" && fun.DateValidation(txtFromDate.Text) && txtToDate.Text != "" && fun.DateValidation(txtToDate.Text) && txtNameOfAgency.Text != "" && txtNameOfEngineer.Text != "" && txtNextPMDueOn.Text != "" && fun.DateValidation(txtNextPMDueOn.Text) && txtRemarks.Text != "")
			{
				string cmdText = fun.update("tblMS_PMBM_Master", "SysDate='" + currDate + "', SysTime='" + currTime + "', SessionId='" + sId + "', PMBM='" + DDLMaintenance.SelectedValue + "', FromDate='" + fun.FromDate(txtFromDate.Text) + "', ToDate='" + fun.FromDate(txtToDate.Text) + "', FromTime='" + text + "', ToTime='" + text2 + "', NameOfAgency='" + txtNameOfAgency.Text + "', NameOfEngineer='" + txtNameOfEngineer.Text + "' , NextPMDueOn='" + fun.FromDate(txtNextPMDueOn.Text) + "',Remarks='" + txtRemarks.Text + "'", "Id='" + PMBMId + "' AND CompId='" + CompId + "' ");
				int num = 0;
				int num2 = 0;
				ValidateTextBox();
				foreach (GridViewRow row in GridView5.Rows)
				{
					if (((CheckBox)row.FindControl("chkSpare")).Checked)
					{
						if (((TextBox)row.FindControl("txtQty")).Text != "" && fun.NumberValidation(((TextBox)row.FindControl("txtQty")).Text))
						{
							num2++;
							continue;
						}
						num++;
						num2 = 0;
					}
				}
				if (num > 0)
				{
					string empty = string.Empty;
					empty = "Invalid data found.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					return;
				}
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
				foreach (GridViewRow row2 in GridView5.Rows)
				{
					if (((CheckBox)row2.FindControl("chkSpare")).Checked && ((TextBox)row2.FindControl("txtQty")).Text != "" && fun.NumberValidation(((TextBox)row2.FindControl("txtQty")).Text))
					{
						string cmdText2 = fun.select("tblMS_PMBM_Details.Id,tblMS_PMBM_Details.SpareId", "tblMS_PMBM_Details,tblMS_PMBM_Master", " tblMS_PMBM_Details.MId=tblMS_PMBM_Master.Id AND tblMS_PMBM_Master.Id='" + PMBMId + "' AND CompId='" + CompId + "'  AND tblMS_PMBM_Details.SpareId='" + ((Label)row2.FindControl("lblId")).Text + "'");
						SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet);
						if (dataSet.Tables[0].Rows.Count > 0)
						{
							int num3 = 0;
							num3 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
							double num4 = 0.0;
							num4 = Convert.ToDouble(((TextBox)row2.FindControl("txtQty")).Text);
							string cmdText3 = fun.update("tblMS_PMBM_Details", "Qty='" + num4 + "'", " SpareId='" + num3 + "' AND Id= '" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'");
							SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
							sqlConnection.Open();
							sqlCommand2.ExecuteNonQuery();
							sqlConnection.Close();
						}
						else
						{
							int num5 = 0;
							num5 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
							double num6 = 0.0;
							num6 = Convert.ToDouble(((TextBox)row2.FindControl("txtQty")).Text);
							string cmdText4 = fun.insert("tblMS_PMBM_Details", "MId,SpareId,Qty", "'" + PMBMId + "','" + num5 + "','" + num6 + "'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
							sqlConnection.Open();
							sqlCommand3.ExecuteNonQuery();
							sqlConnection.Close();
						}
					}
					else
					{
						string cmdText5 = fun.select("tblMS_PMBM_Details.Id,tblMS_PMBM_Details.SpareId", "tblMS_PMBM_Details,tblMS_PMBM_Master", " tblMS_PMBM_Details.MId=tblMS_PMBM_Master.Id AND tblMS_PMBM_Master.Id='" + PMBMId + "' AND CompId='" + CompId + "'  AND tblMS_PMBM_Details.SpareId='" + ((Label)row2.FindControl("lblId")).Text + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							int num7 = 0;
							num7 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
							string cmdText6 = fun.delete("tblMS_PMBM_Details", " SpareId='" + num7 + "' AND Id= '" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
							sqlConnection.Open();
							sqlCommand4.ExecuteNonQuery();
							sqlConnection.Close();
						}
					}
				}
				base.Response.Redirect("~/Module/Machinery/Transactions/PMBM_Edit.aspx?ModId=15&SubModId=68");
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid data found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void ValidateTextBox()
	{
		foreach (GridViewRow row in GridView5.Rows)
		{
			if (((CheckBox)row.FindControl("chkSpare")).Checked && ((TextBox)row.FindControl("txtQty")).Text == "")
			{
				((RequiredFieldValidator)row.FindControl("ReqQty")).Visible = true;
			}
		}
	}

	public void uncheckBoxSpare()
	{
		foreach (GridViewRow row in GridView5.Rows)
		{
			((CheckBox)row.FindControl("chkSpare")).Checked = false;
			((TextBox)row.FindControl("txtQty")).Text = "";
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Machinery/Transactions/PMBM_Edit.aspx?ModId=15&SubModId=68");
	}
}
