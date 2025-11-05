using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using MKB.TimePicker;

public class Module_Inventory_Transactions_GoodsInwardNote_GIN_Edit_Details : Page, IRequiresSessionState
{
	protected Label Label1;

	protected Label Lblgnno;

	protected Label Label4;

	protected Label LblChallanDate;

	protected Label Label3;

	protected Label lblChallanNo;

	protected Label LblWODept;

	protected Label LblWONo;

	protected TextBox TxtGateentryNo;

	protected TextBox TxtGDate;

	protected CalendarExtender TxtChallanDate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidatorChallanDate;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TimeSelector TimeSelector1;

	protected TextBox TxtModeoftransport;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox TxtVehicleNo;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected GridView GridView1;

	protected Label lblMessage;

	protected Button btnCancel;

	protected SqlDataSource SqlDataSource2;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = "";

	private string po = "";

	private string ChNo = "";

	private string GINNo = "";

	private string ChDt = "";

	private string fyid = "";

	private int CompId;

	private string Sid = "";

	private int FyId;

	private string supId = "";

	private string GINId = "";

	private string SessionFyId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		new DataSet();
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			con.Open();
			po = base.Request.QueryString["PoNo"].ToString();
			GINId = base.Request.QueryString["Id"].ToString();
			supId = base.Request.QueryString["SupId"].ToString();
			lblChallanNo.Text = base.Request.QueryString["ChNo"].ToString();
			ChNo = base.Request.QueryString["ChNo"].ToString();
			fyid = base.Request.QueryString["fyid"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			Sid = Session["username"].ToString();
			Lblgnno.Text = base.Request.QueryString["GNo"].ToString();
			GINNo = base.Request.QueryString["GNo"].ToString();
			LblChallanDate.Text = base.Request.QueryString["ChDt"].ToString();
			ChDt = fun.FromDate(LblChallanDate.Text);
			SessionFyId = Session["finyear"].ToString();
			TxtGDate.Attributes.Add("readonly", "readonly");
			string cmdText = fun.select("FinYearId", "tblFinancial_master", "FinYear='" + fyid + "' AND CompId ='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				FyId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["FinYearId"]);
			}
			lblMessage.Text = "";
			if (!Page.IsPostBack)
			{
				loadData();
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", " Id='" + GINId + "' And   FinYearId<='" + FyId + "' AND CompId='" + CompId + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				TxtGateentryNo.Text = dataSet2.Tables[0].Rows[0]["GateEntryNo"].ToString();
				TxtGDate.Text = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["GDate"].ToString());
				string text = dataSet2.Tables[0].Rows[0]["GTime"].ToString();
				char[] separator = new char[2] { ':', ' ' };
				string[] array = text.Split(separator);
				string tM = array[3];
				int h = Convert.ToInt32(array[0]);
				int m = Convert.ToInt32(array[1]);
				int s = Convert.ToInt32(array[2]);
				fun.TimeSelector(h, m, s, tM, TimeSelector1);
				TxtModeoftransport.Text = dataSet2.Tables[0].Rows[0]["ModeofTransport"].ToString();
				TxtVehicleNo.Text = dataSet2.Tables[0].Rows[0]["VehicleNo"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableEdit()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				_ = ((Label)row.FindControl("lblId")).Text;
				int num = Convert.ToInt32(((Label)row.FindControl("lblPOId")).Text);
				string cmdText = fun.select("tblinv_MaterialReceived_Details.Id", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GINId='" + GINId + "' AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId AND tblinv_MaterialReceived_Details.POId='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				new DataTable();
				sqlDataAdapter.Fill(dataSet);
				string cmdText2 = fun.select("tblinv_MaterialServiceNote_Details.Id", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.GSNNo=tblinv_MaterialServiceNote_Details.GSNNo AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId AND tblinv_MaterialServiceNote_Master.GINId='" + GINId + "' AND tblinv_MaterialServiceNote_Details.POId='" + num + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				new DataTable();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					((Label)row.FindControl("lblgrr")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblgrr")).Visible = true;
				}
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					((Label)row.FindControl("lblgsn")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblgsn")).Visible = true;
				}
				if (dataSet.Tables[0].Rows.Count > 0 || dataSet2.Tables[0].Rows.Count > 0)
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsInwardNote_GIN_Edit.aspx?ModId=9&SubModId=37");
	}

	public void loadData()
	{
		try
		{
			string cmdText = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Details.Id,tblInv_Inward_Details.ACategoyId,tblInv_Inward_Details.ASubCategoyId,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.Qty,tblInv_Inward_Details.ReceivedQty,tblInv_Inward_Details.POId", " tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.FinYearId<='" + SessionFyId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Details.GINId='" + GINId + "' Order by  tblInv_Inward_Master.Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("poqty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RecedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ChallanQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotRecdQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("POId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCategory", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CategoryId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SubCategoryId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AHId", typeof(string)));
			string value = "";
			int num = 0;
			string value2 = "";
			string value3 = "";
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = 0;
			string text = string.Empty;
			string text2 = string.Empty;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet.Tables[0].Rows[i]["PONo"].ToString() + "' AND tblMM_PO_Master.FinYearId <='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_PO_Master.CompId='" + dataSet.Tables[0].Rows[i]["CompId"].ToString() + "' AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText3 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet2.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Details.Id='" + dataSet2.Tables[0].Rows[0]["PRId"].ToString() + "' And tblMM_PR_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						text = dataSet3.Tables[0].Rows[0]["WONo"].ToString();
						num = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["ItemId"]);
						string cmdText4 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet3.Tables[0].Rows[0]["ItemId"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							if (dataSet4.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet4.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[9] = "View";
							}
							else
							{
								dataRow[9] = "";
							}
							if (dataSet4.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet4.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[10] = "View";
							}
							else
							{
								dataRow[10] = "";
							}
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet3.Tables[0].Rows[0]["ItemId"].ToString()));
							value3 = dataSet4.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText5 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet4.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5);
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								value2 = dataSet5.Tables[0].Rows[0][0].ToString();
							}
							num4 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["AHId"]);
						}
					}
				}
				else if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet2.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + dataSet2.Tables[0].Rows[0]["SPRId"].ToString() + "' And tblMM_SPR_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"]);
						string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7);
						if (dataSet7.Tables[0].Rows.Count > 0)
						{
							if (dataSet7.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet7.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[9] = "View";
							}
							else
							{
								dataRow[9] = "";
							}
							if (dataSet7.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet7.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[10] = "View";
							}
							else
							{
								dataRow[10] = "";
							}
							value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
							value3 = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet8 = new DataSet();
							sqlDataAdapter8.Fill(dataSet8);
							if (dataSet8.Tables[0].Rows.Count > 0)
							{
								value2 = dataSet8.Tables[0].Rows[0][0].ToString();
							}
							num4 = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["AHId"]);
							if (dataSet6.Tables[0].Rows[0]["WONo"] != DBNull.Value && dataSet6.Tables[0].Rows[0]["WONo"].ToString() != string.Empty)
							{
								text = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
							}
							else
							{
								string cmdText9 = fun.select("Symbol", "BusinessGroup", "Id='" + dataSet6.Tables[0].Rows[0]["DeptId"].ToString() + "'");
								SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
								SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
								DataSet dataSet9 = new DataSet();
								sqlDataAdapter9.Fill(dataSet9);
								if (dataSet9.Tables[0].Rows.Count > 0)
								{
									text2 = dataSet9.Tables[0].Rows[0]["Symbol"].ToString();
								}
							}
						}
					}
				}
				if (text != "")
				{
					LblWODept.Text = "WONO";
					LblWONo.Text = text;
				}
				else
				{
					LblWODept.Text = "Bussiness Group";
					LblWONo.Text = text2;
				}
				dataRow[0] = value;
				dataRow[1] = value3;
				dataRow[2] = value2;
				num2 = ((dataSet2.Tables[0].Rows[0]["Qty"] != DBNull.Value) ? Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) : 0.0);
				dataRow[3] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[4] = num2;
				num3 = ((!(dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString() == "")) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["ReceivedQty"].ToString()).ToString("N3")) : 0.0);
				dataRow[5] = num3;
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
				string cmdText10 = fun.select("sum(tblInv_Inward_Details.ReceivedQty) as sum_ReceivedQty", " tblInv_Inward_Details,tblInv_Inward_Master", "tblInv_Inward_Master.PONo='" + po + "'  and tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo and tblInv_Inward_Details.POId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]) + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId AND tblInv_Inward_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet10.Tables[0].Rows.Count > 0)
				{
					double num5 = ((!(dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"].ToString() == "")) ? Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"].ToString()).ToString("N3")) : 0.0);
					dataRow[7] = num5;
					dataRow[8] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["POId"]);
					dataRow[11] = num;
				}
				if (dataSet.Tables[0].Rows[i]["ACategoyId"].ToString() != "0" && dataSet.Tables[0].Rows[i]["ACategoyId"] != DBNull.Value)
				{
					string cmdText11 = "select Abbrivation from tblACC_Asset_Category where Id='" + dataSet.Tables[0].Rows[i]["ACategoyId"].ToString() + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText11, con);
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						if (sqlDataReader.HasRows)
						{
							dataRow[12] = sqlDataReader["Abbrivation"].ToString();
						}
					}
				}
				else
				{
					dataRow[12] = "NA";
				}
				if (dataSet.Tables[0].Rows[i]["ASubCategoyId"].ToString() != "0" && dataSet.Tables[0].Rows[i]["ASubCategoyId"] != DBNull.Value)
				{
					string cmdText12 = "select Abbrivation from tblACC_Asset_SubCategory where Id='" + dataSet.Tables[0].Rows[i]["ASubCategoyId"].ToString() + "'";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText12, con);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						if (sqlDataReader2.HasRows)
						{
							dataRow[13] = sqlDataReader2["Abbrivation"].ToString();
						}
					}
				}
				else
				{
					dataRow[13] = "NA";
				}
				dataRow[14] = dataSet.Tables[0].Rows[i]["ACategoyId"].ToString();
				dataRow[15] = dataSet.Tables[0].Rows[i]["ASubCategoyId"].ToString();
				dataRow[16] = num4;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			disableEdit();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			loadData();
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
			loadData();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			DropDownList dropDownList = gridViewRow.FindControl("ddCategory") as DropDownList;
			DropDownList dropDownList2 = gridViewRow.FindControl("ddSubCategory") as DropDownList;
			string text = ((Label)gridViewRow.FindControl("lblCategoyId")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblSubCategoryId")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblAHId")).Text;
			if (text3 != "33")
			{
				dropDownList.Visible = false;
				dropDownList2.Visible = false;
				((Label)gridViewRow.FindControl("lblCategory1")).Text = "NA";
				((Label)gridViewRow.FindControl("lblSubCategory1")).Text = "NA";
			}
			else
			{
				((Label)gridViewRow.FindControl("lblCategory1")).Visible = false;
				((Label)gridViewRow.FindControl("lblSubCategory1")).Visible = false;
			}
			dropDownList.SelectedValue = text;
			string cmdText = fun.select("Id,(CASE WHEN MId!= 0 THEN Abbrivation ELSE 'Select'  END ) AS SubCat", " tblACC_Asset_SubCategory ", "MId='" + dropDownList.SelectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_Asset_SubCategory");
			dropDownList2.DataSource = dataSet;
			dropDownList2.DataTextField = "SubCat";
			dropDownList2.DataValueField = "Id";
			dropDownList2.DataBind();
			dropDownList2.Items.Insert(0, "Select");
			dropDownList2.SelectedValue = text2;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = 0;
			int num2 = 0;
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num3 = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text2 = ((Label)gridViewRow.FindControl("lblAHId")).Text;
			int num4 = 0;
			if (((DropDownList)gridViewRow.FindControl("ddCategory")).SelectedValue != "Select")
			{
				num4 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("ddCategory")).SelectedValue);
			}
			int num5 = 0;
			if (((DropDownList)gridViewRow.FindControl("ddSubCategory")).SelectedValue != "Select")
			{
				num5 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("ddSubCategory")).SelectedValue);
			}
			if (text2 != "33")
			{
				num = 0;
			}
			if (text2 == "33" && (num4 == 0 || num5 == 0))
			{
				num2++;
				num++;
			}
			Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblPOQty")).Text.ToString()).ToString("N3"));
			double num6 = 0.0;
			num6 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("TxtChallanQty")).Text.ToString()).ToString("N3"));
			double num7 = 0.0;
			num7 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("TxtRecedQty")).Text.ToString()).ToString("N3"));
			double num8 = 0.0;
			num8 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblChnQty")).Text.ToString()).ToString("N3"));
			double num9 = 0.0;
			num9 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblRecQty")).Text.ToString()).ToString());
			if (TxtGateentryNo.Text != "" && TxtModeoftransport.Text != "" && TxtVehicleNo.Text != "" && fun.DateValidation(TxtGDate.Text) && TxtGDate.Text != "" && fun.DateValidation(fun.FromDateDMY(ChDt)))
			{
				if (num6 <= num8 && num7 <= num9 && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("TxtChallanQty")).Text) && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("TxtRecedQty")).Text) && num == 0 && num2 == 0)
				{
					string text3 = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + " " + TimeSelector1.AmPm;
					string cmdText = fun.update("tblInv_Inward_Master", "SysDate='" + currDate + "' ,SysTime='" + currTime + "',SessionId='" + text + "',ChallanNo='" + ChNo + "',ChallanDate='" + ChDt + "',GateEntryNo='" + TxtGateentryNo.Text + "',GDate='" + fun.FromDate(TxtGDate.Text) + "',GTime='" + text3 + "',ModeofTransport='" + TxtModeoftransport.Text + "',VehicleNo='" + TxtVehicleNo.Text + "'", "CompId='" + CompId + "'  AND  FinYearId='" + FyId + "' AND GINNo='" + GINNo + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					if (text2 == "33")
					{
						string cmdText2 = fun.select("ACategoyId,ASubCategoyId", "tblInv_Inward_Details", "Id='" + num3 + "' AND GINNo='" + GINNo + "'");
						SqlCommand selectCommand = new SqlCommand(cmdText2, con);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet, "tblInv_Inward_Master");
						if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["ACategoyId"].ToString() == num4.ToString() && dataSet.Tables[0].Rows[0]["ASubCategoyId"].ToString() == num5.ToString())
						{
							num4 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ACategoyId"]);
							num5 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ASubCategoyId"]);
						}
					}
					string cmdText3 = fun.update("tblInv_Inward_Details", "Qty='" + decimal.Parse(num6.ToString()).ToString("N3") + "',ReceivedQty='" + decimal.Parse(num7.ToString()).ToString("N3") + "',ACategoyId='" + num4 + "',ASubCategoyId='" + num5 + "'", "Id='" + num3 + "' AND GINNo='" + GINNo + "' ");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					GridView1.EditIndex = -1;
					loadData();
				}
				else
				{
					string empty = string.Empty;
					empty = ((num <= 0 && num2 <= 0) ? "Entered qty is exceed the limit!" : "Please Select Category and Subcategory of Asset.");
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
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
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated Sucessfully!";
	}

	protected void GridView1_PageIndexChanging1(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "downloadImg")
			{
				foreach (GridViewRow row in GridView1.Rows)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
					base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
				}
			}
			if (!(e.CommandName == "downloadSpec"))
			{
				return;
			}
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				int num2 = Convert.ToInt32(((Label)row2.FindControl("lblItemId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DropDownList dropDownList = (DropDownList)sender;
			GridViewRow gridViewRow = (GridViewRow)dropDownList.Parent.Parent;
			_ = gridViewRow.RowIndex;
			DropDownList dropDownList2 = (DropDownList)sender;
			GridViewRow gridViewRow2 = (GridViewRow)dropDownList2.Parent.Parent;
			DropDownList dropDownList3 = (DropDownList)gridViewRow2.FindControl("ddCategory");
			DropDownList dropDownList4 = (DropDownList)gridViewRow.FindControl("ddSubCategory");
			string cmdText = fun.select("Id,(CASE WHEN MId!= 0 THEN Abbrivation ELSE 'Select'  END ) AS SubCat", " tblACC_Asset_SubCategory ", "MId='" + dropDownList3.SelectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblACC_Asset_SubCategory");
			dropDownList4.DataSource = dataSet;
			dropDownList4.DataTextField = "SubCat";
			dropDownList4.DataValueField = "Id";
			dropDownList4.DataBind();
			dropDownList4.Items.Insert(0, "Select");
		}
		catch (Exception)
		{
		}
	}
}
