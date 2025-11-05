using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string poNo = "";

	private string GINNo = "";

	private string FyId = "";

	private string SupplierNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string CDate = "";

	private string CTime = "";

	private string MId = "";

	private string connStr = string.Empty;

	private SqlConnection con;

	protected Label lblGIn;

	protected Label lblChNo;

	protected Label lblDate;

	protected Label lblSupplier;

	protected TextBox txtTaxInvoice;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtDate;

	protected CalendarExtender txtDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected DropDownList drpModVat;

	protected RequiredFieldValidator ReqModVat;

	protected DropDownList drpModVatInvoice;

	protected RequiredFieldValidator ReqModVatInvoice;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button btnInsert;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			GINNo = base.Request.QueryString["GINNo"].ToString();
			SupplierNo = base.Request.QueryString["SupId"].ToString();
			poNo = base.Request.QueryString["PONo"].ToString();
			FyId = base.Request.QueryString["FyId"].ToString();
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			MId = base.Request.QueryString["Id"].ToString();
			txtDate.Attributes.Add("readonly", "readonly");
			con.Open();
			GetValidate();
			if (!Page.IsPostBack)
			{
				lblGIn.Text = GINNo;
				string cmdText = fun.select("SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "' AND SupplierId='" + SupplierNo + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblSupplier.Text = dataSet.Tables[0].Rows[0][0].ToString();
				}
				string cmdText2 = fun.select("*", "tblInv_Inward_Master", "GINNo='" + GINNo + "' AND CompId='" + CompId + "' AND Id='" + MId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					lblChNo.Text = dataSet2.Tables[0].Rows[0]["ChallanNo"].ToString();
					lblDate.Text = fun.FromDateDMY(dataSet2.Tables[0].Rows[0]["ChallanDate"].ToString());
				}
				loadData();
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				double num = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
				double num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbltotrecevdqty")).Text.ToString()).ToString("N3"));
				if (num - num2 == 0.0)
				{
					((CheckBox)row.FindControl("ck")).Visible = false;
				}
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

	public void GetValidate()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			if (((CheckBox)row.FindControl("ck")).Checked)
			{
				((RequiredFieldValidator)row.FindControl("ReqRecQty")).Visible = true;
			}
			else
			{
				((RequiredFieldValidator)row.FindControl("ReqRecQty")).Visible = false;
			}
		}
	}

	public void loadData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("tblInv_Inward_Master.PONo,tblInv_Inward_Master.FinYearId,tblInv_Inward_Master.CompId,tblInv_Inward_Details.ReceivedQty as sum_ReceivedQty,tblInv_Inward_Details.POId", "tblInv_Inward_Master,tblInv_Inward_Details", "tblInv_Inward_Master.GINNo=tblInv_Inward_Details.GINNo AND tblInv_Inward_Master.GINNo='" + GINNo + "' AND tblInv_Inward_Master.CompId='" + CompId + "' AND tblInv_Inward_Master.Id='" + MId + "' AND tblInv_Inward_Master.Id=tblInv_Inward_Details.GINId");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotRecQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotRemainQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			string value = "";
			int num = 0;
			string value2 = "";
			string value3 = "";
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = 0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.Qty,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Master.FinYearId", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + dataSet.Tables[0].Rows[i]["PONo"].ToString() + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.FinYearId<='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_PO_Master.CompId='" + dataSet.Tables[0].Rows[i]["CompId"].ToString() + "' AND tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
					{
						string cmdText3 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet2.Tables[0].Rows[0]["PRNo"].ToString() + "'  AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet2.Tables[0].Rows[0]["PRId"].ToString() + "'AND tblMM_PR_Master.FinYearId<='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							string cmdText4 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet3.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
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
								value2 = dataSet4.Tables[0].Rows[0]["ManfDesc"].ToString();
								num = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["ItemId"]);
								string cmdText5 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet4.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
								DataSet dataSet5 = new DataSet();
								sqlDataAdapter5.Fill(dataSet5);
								if (dataSet5.Tables[0].Rows.Count > 0)
								{
									value3 = dataSet5.Tables[0].Rows[0][0].ToString();
								}
								num4 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["AHId"]);
							}
						}
					}
					else if (dataSet2.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
					{
						string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet2.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Details.Id='" + dataSet2.Tables[0].Rows[0]["SPRId"].ToString() + "'AND tblMM_SPR_Master.FinYearId<='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "' AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic,AttName,FileName", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
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
								value2 = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
								num = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"]);
								string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
								SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
								SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
								DataSet dataSet8 = new DataSet();
								sqlDataAdapter8.Fill(dataSet8);
								if (dataSet8.Tables[0].Rows.Count > 0)
								{
									value3 = dataSet8.Tables[0].Rows[0][0].ToString();
								}
								num4 = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["AHId"]);
							}
						}
					}
				}
				string cmdText9 = fun.select("Category", "AccHead", "Id='" + num4 + "'");
				SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
				DataSet dataSet9 = new DataSet();
				sqlDataAdapter9.Fill(dataSet9);
				if (dataSet9.Tables[0].Rows.Count > 0 && dataSet9.Tables[0].Rows[0]["Category"].ToString() == "With Material")
				{
					dataRow[0] = value;
					dataRow[1] = value2;
					dataRow[2] = value3;
					dataRow[5] = dataSet.Tables[0].Rows[i]["POId"].ToString();
					num2 = ((dataSet2.Tables[0].Rows[0]["Qty"] != DBNull.Value) ? Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3")) : 0.0);
					dataRow[3] = num2;
					num3 = ((!(dataSet.Tables[0].Rows[i]["sum_ReceivedQty"].ToString() == "")) ? Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["sum_ReceivedQty"].ToString()).ToString("N3")) : 0.0);
					dataRow[4] = num3;
					string cmdText10 = fun.select("sum(tblinv_MaterialReceived_Details.ReceivedQty) as sum_ReceivedQty", "tblinv_MaterialReceived_Master,tblinv_MaterialReceived_Details", "tblinv_MaterialReceived_Master.CompId='" + CompId + "' AND tblinv_MaterialReceived_Master.GRRNo=tblinv_MaterialReceived_Details.GRRNo AND tblinv_MaterialReceived_Details.POId='" + dataSet.Tables[0].Rows[i]["POId"].ToString() + "' AND tblinv_MaterialReceived_Master.GINId='" + MId + "' AND tblinv_MaterialReceived_Master.Id=tblinv_MaterialReceived_Details.MId");
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					double num5 = 0.0;
					if (dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"] != DBNull.Value)
					{
						num5 = Convert.ToDouble(decimal.Parse(dataSet10.Tables[0].Rows[0]["sum_ReceivedQty"].ToString()).ToString("N3"));
						dataRow[6] = num5;
					}
					else
					{
						dataRow[6] = num5;
					}
					dataRow[7] = num;
					dataRow[8] = num3 - num5;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "downloadImg")
			{
				foreach (GridViewRow row in GridView2.Rows)
				{
					int num = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
					base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
				}
			}
			if (!(e.CommandName == "downloadSpec"))
			{
				return;
			}
			foreach (GridViewRow row2 in GridView2.Rows)
			{
				int num2 = Convert.ToInt32(((Label)row2.FindControl("lblItemId")).Text);
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			if (((CheckBox)gridViewRow.FindControl("ck")).Checked)
			{
				((TextBox)gridViewRow.FindControl("txtrecQty")).Visible = true;
				((Label)gridViewRow.FindControl("lblrecevdqty")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqRecQty")).Visible = true;
			}
			else
			{
				((Label)gridViewRow.FindControl("lblrecevdqty")).Visible = true;
				((TextBox)gridViewRow.FindControl("txtrecQty")).Visible = false;
				((RequiredFieldValidator)gridViewRow.FindControl("ReqRecQty")).Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("GoodsReceivedReceipt_GRR_New.aspx?ModId=9&SubModId=38");
	}

	protected void btnInsert_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			GINNo = lblGIn.Text;
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			string cmdText = fun.select("GRRNo", "tblinv_MaterialReceived_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GRRNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblinv_MaterialReceived_Master");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (!((CheckBox)row.FindControl("ck")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("ck")).Checked && ((TextBox)row.FindControl("txtrecQty")).Text != "" && txtTaxInvoice.Text != "" && txtDate.Text != "" && fun.DateValidation(txtDate.Text))
				{
					num7 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtrecQty")).Text.ToString()).ToString("N3"));
					num8 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
					num9 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbltotrecevdqty")).Text.ToString()).ToString("N3"));
					if (num7 > 0.0 && num7 <= num8 - num9 && fun.NumberValidationQty(num7.ToString()))
					{
						num++;
					}
				}
			}
			if (num2 == num && num > 0)
			{
				int num10 = 1;
				string text2 = "";
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (!((CheckBox)row2.FindControl("ck")).Checked || !(((TextBox)row2.FindControl("txtrecQty")).Text != "") || !(txtTaxInvoice.Text != "") || !(txtDate.Text != "") || !fun.DateValidation(txtDate.Text))
					{
						continue;
					}
					num4 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtrecQty")).Text.ToString()).ToString("N3"));
					num5 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblInwrdqty")).Text.ToString()).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lbltotrecevdqty")).Text.ToString()).ToString("N3"));
					_ = ((Label)row2.FindControl("lblItemId")).Text;
					if (num4 > 0.0 && num4 <= num5 - num6 && fun.NumberValidationQty(num4.ToString()))
					{
						if (num10 == 1)
						{
							SqlCommand sqlCommand = new SqlCommand(fun.insert("tblinv_MaterialReceived_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,GRRNo,GINNo,GINId,TaxInvoiceNo,TaxInvoiceDate,ModVatApp,ModVatInv", "'" + CDate + "','" + CTime + "','" + CompId + "','" + sId + "','" + FinYearId + "','" + text + "','" + GINNo + "','" + MId + "','" + txtTaxInvoice.Text + "','" + fun.FromDate(txtDate.Text) + "','" + drpModVat.SelectedValue + "','" + drpModVatInvoice.SelectedValue + "'"), con);
							sqlCommand.ExecuteNonQuery();
							num10 = 0;
							string cmdText2 = fun.select("Id", "tblinv_MaterialReceived_Master", "CompId='" + CompId + "' Order by Id desc");
							SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2, "tblinv_MaterialReceived_Master");
							text2 = dataSet2.Tables[0].Rows[0]["Id"].ToString();
						}
						int num11 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
						SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblinv_MaterialReceived_Details", "MId,GRRNo,POId,ReceivedQty", "'" + text2 + "','" + text + "','" + num11 + "','" + num4 + "'"), con);
						sqlCommand2.ExecuteNonQuery();
						num3++;
					}
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid data input .";
				base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
			}
			Session.Remove("CHECKED_ITEMS_GRR");
			if (num3 > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
}
