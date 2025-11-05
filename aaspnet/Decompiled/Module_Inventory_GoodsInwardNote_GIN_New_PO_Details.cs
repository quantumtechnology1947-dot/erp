using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using MKB.TimePicker;

public class Module_Inventory_GoodsInwardNote_GIN_New_PO_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string ChNo = "";

	private string po = "";

	private string ChDt = "";

	private string fyid = "";

	private int CompId;

	private int FinYearId;

	private string sid = "";

	private string connStr = "";

	private string Mid = "";

	protected Label Label1;

	protected Label LblPONo;

	protected Label Label3;

	protected Label lblChallanNo;

	protected Label Label4;

	protected Label LblChallanDate;

	protected TextBox TxtModeoftransport;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox TxtVehicleNo;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox TxtGateentryNo;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected TextBox TxtGDate;

	protected CalendarExtender TxtChallanDate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidatorChallanDate;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected TimeSelector TimeSelector1;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button BtnInsert;

	protected Button BtnCancel;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sid = base.Request.QueryString["SID"].ToString();
			Mid = base.Request.QueryString["mid"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			lblChallanNo.Text = base.Request.QueryString["ChNo"].ToString();
			ChNo = base.Request.QueryString["ChNo"].ToString();
			po = base.Request.QueryString["PoNo"].ToString();
			fyid = base.Request.QueryString["fyid"].ToString();
			LblPONo.Text = po;
			LblChallanDate.Text = fun.FromDateDMY(base.Request.QueryString["ChDt"].ToString());
			ChDt = base.Request.QueryString["ChDt"].ToString();
			TxtGDate.Attributes.Add("readonly", "readonly");
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			GetValidate();
			if (!Page.IsPostBack)
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((CheckBox)row.FindControl("CheckBox1")).Checked)
			{
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req2")).Visible = true;
			}
			else
			{
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req2")).Visible = false;
			}
		}
	}

	public void loaddata()
	{
		try
		{
			string cmdText = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "   tblMM_PO_Master.PONo='" + po + "' AND tblMM_PO_Master.FinYearId<='" + FinYearId + "' And tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "'And tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.MId='" + Mid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotRecdQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotRemainQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotGINQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotRejQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TotGSNQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AHId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string value = "";
				string value2 = "";
				int num = 0;
				string value3 = "";
				string value4 = "";
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "0")
				{
					string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet.Tables[0].Rows[i]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet.Tables[0].Rows[i]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'And tblMM_PR_Master.Id=tblMM_PR_Details.MId");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						value = dataSet2.Tables[0].Rows[0]["AHId"].ToString();
						num = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
						string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet2.Tables[0].Rows[0]["ItemId"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							value2 = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"].ToString()));
							if (dataSet3.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet3.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[7] = "View";
							}
							else
							{
								dataRow[7] = "";
							}
							if (dataSet3.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet3.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[8] = "View";
							}
							else
							{
								dataRow[8] = "";
							}
							value3 = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
							string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet4 = new DataSet();
							sqlDataAdapter4.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								value4 = dataSet4.Tables[0].Rows[0][0].ToString();
							}
							string cmdText5 = fun.select("Category", "AccHead", "Id='" + dataSet2.Tables[0].Rows[0]["AHId"].ToString() + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5);
							if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0]["Category"].ToString() == "Labour")
							{
								num7 = fun.GSN_QTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 0);
							}
							num4 = fun.GQNQTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 0);
							num5 = fun.GINQTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 0);
							num6 = fun.GQN_Reject_QTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 0);
						}
					}
				}
				else if (dataSet.Tables[0].Rows[i]["PRSPRFlag"].ToString() == "1")
				{
					string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet.Tables[0].Rows[i]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet.Tables[0].Rows[i]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "'And tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						value = dataSet6.Tables[0].Rows[0]["AHId"].ToString();
						num = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"]);
						string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "'And tblDG_Item_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
						DataSet dataSet7 = new DataSet();
						sqlDataAdapter7.Fill(dataSet7);
						if (dataSet7.Tables[0].Rows.Count > 0)
						{
							value2 = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
							value3 = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
							if (dataSet7.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet7.Tables[0].Rows[0]["FileName"] != DBNull.Value)
							{
								dataRow[7] = "View";
							}
							else
							{
								dataRow[7] = "";
							}
							if (dataSet7.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet7.Tables[0].Rows[0]["AttName"] != DBNull.Value)
							{
								dataRow[8] = "View";
							}
							else
							{
								dataRow[8] = "";
							}
							string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
							SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
							SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
							DataSet dataSet8 = new DataSet();
							sqlDataAdapter8.Fill(dataSet8);
							if (dataSet8.Tables[0].Rows.Count > 0)
							{
								value4 = dataSet8.Tables[0].Rows[0][0].ToString();
							}
							string cmdText9 = fun.select("Category", "AccHead", "Id='" + dataSet6.Tables[0].Rows[0]["AHId"].ToString() + "'");
							SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
							SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter9.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0 && dataSet9.Tables[0].Rows[0]["Category"].ToString() == "Labour")
							{
								num7 = fun.GSN_QTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 1);
							}
							num4 = fun.GQNQTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 1);
							num5 = fun.GINQTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 1);
							num6 = fun.GQN_Reject_QTY_PO(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]), num, 1);
						}
					}
				}
				dataRow[0] = value2;
				dataRow[1] = value3;
				dataRow[2] = value4;
				dataRow[9] = num;
				dataRow[3] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				num2 = ((!(dataSet.Tables[0].Rows[i]["Qty"].ToString() == "")) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")) : 0.0);
				dataRow[4] = num2;
				num3 = num4;
				dataRow[5] = num3;
				dataRow[6] = Math.Round(num2 - num3, 5);
				dataRow[10] = num5;
				dataRow[11] = num6;
				dataRow[12] = num7;
				dataRow[13] = value;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				_ = string.Empty;
				((Label)row.FindControl("lblAHId")).Text.ToString();
				if (((Label)row.FindControl("lblAHId")).Text.ToString() != "33")
				{
					((Label)row.FindControl("lblCategory")).Visible = true;
					((Label)row.FindControl("lblSubCategory")).Visible = true;
					((DropDownList)row.FindControl("ddCategory")).Visible = false;
					((DropDownList)row.FindControl("ddSubCategory")).Visible = false;
				}
				else
				{
					((Label)row.FindControl("lblCategory")).Visible = false;
					((Label)row.FindControl("lblSubCategory")).Visible = false;
					((DropDownList)row.FindControl("ddCategory")).Visible = true;
					((DropDownList)row.FindControl("ddSubCategory")).Visible = true;
					((DropDownList)row.FindControl("ddCategory")).Enabled = false;
					((DropDownList)row.FindControl("ddSubCategory")).Enabled = false;
				}
				double num8 = 0.0;
				num8 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblPOQty")).Text.ToString()).ToString("N3"));
				double num9 = 0.0;
				num9 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotRecdQty")).Text.ToString()).ToString("N3"));
				double num10 = 0.0;
				num10 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotGINQty")).Text.ToString()).ToString("N3"));
				double num11 = 0.0;
				num11 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotGSNQty")).Text.ToString()).ToString("N3"));
				double num12 = 0.0;
				num12 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotRejQty")).Text.ToString()).ToString("N3"));
				if (num12 == 0.0)
				{
					if (Math.Round(num8 - num11, 5) == 0.0 || Math.Round(num8 - num9, 5) == 0.0 || Math.Round(num8 - num10, 5) == 0.0)
					{
						((CheckBox)row.FindControl("CheckBox1")).Visible = false;
						continue;
					}
					((CheckBox)row.FindControl("CheckBox1")).Visible = true;
					((TextBox)row.FindControl("TxtReceivedQty")).Text = Math.Round(num8 - num10 + num12, 5).ToString();
				}
				else
				{
					if (!(num12 > 0.0))
					{
						continue;
					}
					if (Math.Round(num8 - num10, 5) <= 0.0)
					{
						if (Math.Round(num8 - num9, 5) == 0.0)
						{
							((CheckBox)row.FindControl("CheckBox1")).Visible = false;
							continue;
						}
						if (Math.Round(num8 - num10 + num12, 5) == 0.0)
						{
							((CheckBox)row.FindControl("CheckBox1")).Visible = false;
							continue;
						}
						((CheckBox)row.FindControl("CheckBox1")).Visible = true;
						((TextBox)row.FindControl("TxtReceivedQty")).Text = Math.Round(num8 - num10 + num12, 5).ToString();
					}
					else
					{
						((CheckBox)row.FindControl("CheckBox1")).Visible = true;
						((TextBox)row.FindControl("TxtReceivedQty")).Text = Math.Round(num8 - num10 + num12, 5).ToString();
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			if (((CheckBox)gridViewRow.FindControl("CheckBox1")).Checked)
			{
				((TextBox)gridViewRow.FindControl("TxtChallanQty")).Visible = true;
				((Label)gridViewRow.FindControl("lblChallanQty")).Visible = false;
				((TextBox)gridViewRow.FindControl("TxtReceivedQty")).Visible = true;
				((Label)gridViewRow.FindControl("lblReceivedQty")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req2")).Visible = true;
				((DropDownList)gridViewRow.FindControl("ddCategory")).Enabled = true;
				((DropDownList)gridViewRow.FindControl("ddSubCategory")).Enabled = true;
			}
			else
			{
				((Label)gridViewRow.FindControl("lblChallanQty")).Visible = true;
				((TextBox)gridViewRow.FindControl("TxtChallanQty")).Visible = false;
				((Label)gridViewRow.FindControl("lblReceivedQty")).Visible = true;
				((TextBox)gridViewRow.FindControl("TxtReceivedQty")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
				((RequiredFieldValidator)gridViewRow.FindControl("Req2")).Visible = true;
				((DropDownList)gridViewRow.FindControl("ddCategory")).Enabled = false;
				((DropDownList)gridViewRow.FindControl("ddSubCategory")).Enabled = false;
				((DropDownList)gridViewRow.FindControl("ddCategory")).SelectedValue = "1";
				((DropDownList)gridViewRow.FindControl("ddSubCategory")).Items.Insert(0, "Select");
				((DropDownList)gridViewRow.FindControl("ddSubCategory")).ClearSelection();
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
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_DataBound(object sender, EventArgs e)
	{
	}

	public void GetTextvalue()
	{
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("row_index");
			dataTable.Columns.Add("edited_value");
			dataTable.Columns.Add("Id");
			dataTable.Columns.Add("PageIndex");
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (Session["retain"] != null)
				{
					dataTable = (DataTable)Session["retain"];
				}
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					TextBox textBox = (TextBox)row.FindControl("TxtReceivedQty");
					TextBox textBox2 = (TextBox)row.FindControl("TxtChallanQty");
					int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					int num2 = 0;
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						if (num == Convert.ToInt32(dataTable.Rows[i][2]))
						{
							num2 = 1;
						}
					}
					if (num2 == 0)
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow[0] = textBox.Text;
						dataRow[1] = textBox2.Text;
						dataRow[2] = num.ToString();
						dataRow[3] = row.RowIndex;
						dataTable.Rows.Add(dataRow);
					}
					if (dataTable.Rows.Count == 0)
					{
						Session["retain"] = null;
					}
					else
					{
						Session["retain"] = dataTable;
					}
					continue;
				}
				int num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				int num4 = 0;
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					if (num3 == Convert.ToInt32(dataTable.Rows[j][2]))
					{
						num4 = 1;
					}
				}
				if (num4 == 1)
				{
					dataTable.Rows[row.RowIndex].Delete();
					dataTable.AcceptChanges();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsInwardNote_GIN_New.aspx?ModId=9&SubModId=37", endResponse: false);
	}

	protected void BtnInsert_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = 0;
			string text2 = "";
			string cmdText = fun.select("GINNo", "tblInv_Inward_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GINNo Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblInv_Inward_Master");
			text2 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num2 = 1;
			con.Open();
			string text3 = "";
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				num4++;
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				double num11 = 0.0;
				double num12 = 0.0;
				_ = ((Label)row.FindControl("lblItemId")).Text;
				string text4 = ((Label)row.FindControl("lblAHId")).Text;
				int num13 = 0;
				if (((DropDownList)row.FindControl("ddCategory")).SelectedValue != "Select")
				{
					num13 = Convert.ToInt32(((DropDownList)row.FindControl("ddCategory")).SelectedValue);
				}
				int num14 = 0;
				if (((DropDownList)row.FindControl("ddSubCategory")).SelectedValue != "Select")
				{
					num14 = Convert.ToInt32(((DropDownList)row.FindControl("ddSubCategory")).SelectedValue);
				}
				if (text4 != "33")
				{
					num6 = 0;
				}
				if (text4 == "33" && (num13 == 0 || num14 == 0))
				{
					num7++;
					num6++;
				}
				if (((TextBox)row.FindControl("TxtChallanQty")).Text != "")
				{
					num8 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtChallanQty")).Text.ToString()).ToString("N3"));
				}
				if (((TextBox)row.FindControl("TxtReceivedQty")).Text != "")
				{
					num9 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtReceivedQty")).Text.ToString()).ToString("N3"));
				}
				if (num8 > 0.0 && num9 > 0.0 && ((CheckBox)row.FindControl("CheckBox1")).Checked && fun.NumberValidationQty(((TextBox)row.FindControl("TxtChallanQty")).Text) && fun.NumberValidationQty(((TextBox)row.FindControl("TxtReceivedQty")).Text))
				{
					num11 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblPOQty")).Text.ToString()).ToString("N3"));
					num12 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotRecdQty")).Text.ToString()).ToString("N3"));
					num10 = num11 - num12;
					if (Math.Round(num10, 5) >= Math.Round(num9, 5))
					{
						num3++;
					}
				}
			}
			if (num4 == num3 && num3 > 0 && TxtGateentryNo.Text != "" && TxtModeoftransport.Text != "" && TxtVehicleNo.Text != "" && fun.DateValidation(TxtGDate.Text) && TxtGDate.Text != "" && fun.DateValidation(fun.FromDateDMY(ChDt)) && num6 == 0 && num7 == 0)
			{
				foreach (GridViewRow row2 in GridView1.Rows)
				{
					if (!((CheckBox)row2.FindControl("CheckBox1")).Checked)
					{
						continue;
					}
					double num15 = 0.0;
					double num16 = 0.0;
					double num17 = 0.0;
					double num18 = 0.0;
					double num19 = 0.0;
					_ = ((Label)row2.FindControl("lblItemId")).Text;
					_ = ((Label)row2.FindControl("lblAHId")).Text;
					int num20 = 0;
					if (((DropDownList)row2.FindControl("ddCategory")).SelectedValue != "Select")
					{
						num20 = Convert.ToInt32(((DropDownList)row2.FindControl("ddCategory")).SelectedValue);
					}
					int num21 = 0;
					if (((DropDownList)row2.FindControl("ddSubCategory")).SelectedValue != "Select")
					{
						num21 = Convert.ToInt32(((DropDownList)row2.FindControl("ddSubCategory")).SelectedValue);
					}
					num = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					num15 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtChallanQty")).Text.ToString()).ToString("N3"));
					num16 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtReceivedQty")).Text.ToString()).ToString("N3"));
					if (!(num15 >= 0.0) || !(num16 >= 0.0) || !fun.NumberValidationQty(((TextBox)row2.FindControl("TxtChallanQty")).Text) || !fun.NumberValidationQty(((TextBox)row2.FindControl("TxtReceivedQty")).Text))
					{
						continue;
					}
					num18 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblPOQty")).Text.ToString()).ToString("N3"));
					num19 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblTotRecdQty")).Text.ToString()).ToString("N3"));
					num17 = num18 - num19;
					if (Math.Round(num17, 5) >= Math.Round(num16, 5))
					{
						if (num2 == 1)
						{
							string text5 = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + " " + TimeSelector1.AmPm;
							string cmdText2 = fun.insert("tblInv_Inward_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,GINNo,PONo,ChallanNo,ChallanDate,GateEntryNo,GDate,GTime,ModeofTransport,VehicleNo,POMId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + text + "','" + text2 + "','" + po + "','" + ChNo + "','" + ChDt + "','" + TxtGateentryNo.Text + "','" + fun.FromDate(TxtGDate.Text) + "','" + text5 + "','" + TxtModeoftransport.Text + "','" + TxtVehicleNo.Text + "','" + Mid + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
							sqlCommand.ExecuteNonQuery();
							num2 = 0;
							string cmdText3 = fun.select("Id", "tblInv_Inward_Master", "CompId='" + CompId + "' Order by Id Desc");
							SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2, "tblInv_Inward_Master");
							text3 = dataSet2.Tables[0].Rows[0]["Id"].ToString();
						}
						string cmdText4 = fun.insert("tblInv_Inward_Details", "GINNo,GINId,POId,Qty,ReceivedQty,ACategoyId,ASubCategoyId", "'" + text2 + "','" + text3 + "','" + num + "','" + num15 + "','" + num16 + "','" + num20 + "','" + num21 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
						sqlCommand2.ExecuteNonQuery();
						num5++;
					}
				}
				if (num5 > 0)
				{
					loaddata();
				}
			}
			else
			{
				string empty = string.Empty;
				empty = ((num6 <= 0 && num7 <= 0) ? "Invalid input data." : "Please Select Category and Subcategory of Asset.");
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			Session.Remove("CHECKED_ITEMS");
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
