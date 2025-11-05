using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_ProjectManagement_Reports_ProjectSummary_Sup_M : Page, IRequiresSessionState
{
	protected Label lblWo;

	protected CheckBox CheckAll;

	protected TextBox Txtfromdate;

	protected CalendarExtender Txtfromdate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtTodate;

	protected CalendarExtender TxtTodate_CalendarExtender;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected CheckBoxList CheckBoxList1;

	protected Button btnExport;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string WONo = "";

	private string SwitchTo = string.Empty;

	private string fd = "";

	private string td = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			con.Open();
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				lblWo.Text = base.Request.QueryString["WONo"].ToString();
				WONo = base.Request.QueryString["WONo"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["SwitchTo"]))
			{
				SwitchTo = base.Request.QueryString["SwitchTo"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid_Creditors(string fDate, string tDate)
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = string.Empty;
			if (SwitchTo == "2")
			{
				string text = "";
				if (fDate != "" && tDate != "")
				{
					text = " And tblDG_BOM_Master.SysDate   between '" + fDate + "' And '" + tDate + "'";
				}
				cmdText = "select distinct(tblDG_Item_Master.ItemCode),tblDG_Item_Master.StockQty, tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic from tblDG_Item_Master inner join tblDG_BOM_Master on tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId inner join Unit_Master on  tblDG_Item_Master.UOMBasic=Unit_Master.Id  And tblDG_Item_Master.CId is null And WONo='" + WONo + "' and  tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + WONo + "' and  tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "')   " + text + " Order By Id ASC";
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("Sn", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("WISQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PlnNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PlnDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PlnItem", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PlnQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Authorized", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GRRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GRRDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GRRQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNQty", typeof(string)));
			int num = 1;
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				dataRow[1] = sqlDataReader["ItemCode"].ToString();
				dataRow[2] = sqlDataReader["ManfDesc"].ToString();
				dataRow[3] = sqlDataReader["UOMBasic"].ToString();
				num2 = fun.AllComponentBOMQty(CompId, WONo, sqlDataReader["Id"].ToString(), FinYearId);
				dataRow[4] = num2;
				dataRow[5] = Convert.ToInt32(sqlDataReader["Id"].ToString());
				dataRow[0] = num.ToString();
				num++;
				num3 = fun.CalWISQty(CompId.ToString(), WONo, sqlDataReader["Id"].ToString());
				num4 = Convert.ToDouble(sqlDataReader["StockQty"].ToString());
				dataRow[6] = num3;
				dataRow[7] = num4;
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				string text5 = string.Empty;
				string cmdText2 = "SELECT tblMP_Material_Master.Id, tblMP_Material_Detail.Id As DMid,tblMP_Material_Master.PLNo,tblMP_Material_Master.SysDate,tblMP_Material_Detail.ItemId, tblMP_Material_Detail.RM, tblMP_Material_Detail.PRO, tblMP_Material_Detail.FIN FROM tblMP_Material_Master INNER JOIN  tblMP_Material_Detail ON  tblMP_Material_Master.Id=tblMP_Material_Detail.Mid  And tblMP_Material_Detail.ItemId='" + sqlDataReader["Id"].ToString() + "'";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				while (sqlDataReader2.Read())
				{
					string cmdText3 = "";
					if (sqlDataReader2["FIN"].ToString() == "1")
					{
						cmdText3 = "SELECT  tblMP_Material_Finish.Qty, tblMP_Material_Finish.ItemId,SupplierId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Finish ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.PLNo='" + sqlDataReader2["PLNo"].ToString() + "' AND tblMP_Material_Master.WONo='" + WONo + "' And tblMP_Material_Finish.DMid='" + sqlDataReader2["DMid"].ToString() + "' ";
					}
					if (sqlDataReader2["RM"].ToString() == "1")
					{
						cmdText3 = "SELECT tblMP_Material_RawMaterial.Qty,tblMP_Material_RawMaterial.ItemId,SupplierId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_RawMaterial ON tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid And tblMP_Material_Master.WONo='" + WONo + "' And tblMP_Material_Master.CompId=" + CompId + "  and tblMP_Material_Master.PLNo='" + sqlDataReader2["PLNo"].ToString() + "'And tblMP_Material_RawMaterial.DMid='" + sqlDataReader2["DMid"].ToString() + "'";
					}
					if (sqlDataReader2["PRO"].ToString() == "1")
					{
						cmdText3 = "SELECT tblMP_Material_Process.Qty,tblMP_Material_Process.ItemId,SupplierId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid and tblMP_Material_Master.PLNo='" + sqlDataReader2["PLNo"].ToString() + "' And tblMP_Material_Master.WONo='" + WONo + "' And tblMP_Material_Master.CompId=" + CompId + " And tblMP_Material_Process.DMid='" + sqlDataReader2["DMid"].ToString() + "'";
					}
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					while (sqlDataReader3.Read())
					{
						string cmdText4 = fun.select("ItemCode", " tblDG_Item_Master", "Id='" + sqlDataReader3["ItemId"].ToString() + "'");
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
						SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
						text2 = text2 + "<br>" + sqlDataReader2["PLNo"].ToString();
						text3 = text3 + "<br>" + fun.FromDateDMY(sqlDataReader2["SysDate"].ToString());
						while (sqlDataReader4.Read())
						{
							text4 = text4 + "<br>" + sqlDataReader4["ItemCode"].ToString();
						}
						text5 = text5 + "<br>" + sqlDataReader3["Qty"].ToString();
						dataRow[8] = text2;
						dataRow[9] = text3;
						dataRow[10] = text4;
						dataRow[11] = text5;
						string cmdText5 = "SELECT tblMM_PR_Details.Id As PRId, tblMM_PR_Master.PRNo, REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As PRDate , tblMM_PR_Details.Qty As PRQty   FROM tblMM_PR_Master INNER JOIN tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId And tblMM_PR_Master.PLNId='" + sqlDataReader2["Id"].ToString() + "' And tblMM_PR_Details.ItemId='" + sqlDataReader3["ItemId"].ToString() + "' And tblMM_PR_Details.SupplierId='" + sqlDataReader3["SupplierId"].ToString() + "' ";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
						SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
						string text6 = string.Empty;
						string text7 = string.Empty;
						string text8 = string.Empty;
						string text9 = string.Empty;
						string text10 = string.Empty;
						string text11 = string.Empty;
						string text12 = string.Empty;
						string text13 = string.Empty;
						string text14 = string.Empty;
						string text15 = string.Empty;
						string text16 = string.Empty;
						string text17 = string.Empty;
						string text18 = string.Empty;
						string text19 = string.Empty;
						string text20 = string.Empty;
						string text21 = string.Empty;
						string text22 = string.Empty;
						while (sqlDataReader5.Read())
						{
							text6 = text6 + "<br>" + sqlDataReader5["PRNo"].ToString();
							text7 = text7 + "<br>" + sqlDataReader5["PRDate"].ToString();
							text8 = text8 + "<br>" + sqlDataReader5["PRQty"].ToString();
							dataRow[12] = text6;
							dataRow[13] = text7;
							dataRow[14] = text8;
							string cmdText6 = "SELECT tblMM_PO_Details.Id, tblMM_PO_Master.PONo, tblMM_PO_Master.SysDate, tblMM_PO_Master.SupplierId, tblMM_PO_Master.Authorize,tblMM_PO_Details.Qty FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId And tblMM_PO_Details.PRId='" + sqlDataReader5["PRId"].ToString() + "' ";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
							SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
							while (sqlDataReader6.Read())
							{
								string selectCommandText = fun.select("SupplierName+'['+SupplierId+']' As SupplierName ", "tblMM_Supplier_master", "CompId='" + CompId + "' And SupplierId='" + sqlDataReader6["SupplierId"].ToString() + "'");
								SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
								DataSet dataSet = new DataSet();
								sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
								text12 = ((!(sqlDataReader6["Authorize"].ToString() == "1")) ? (text12 + "<br>No") : (text12 + "<br>Yes"));
								text9 = text9 + "<br>" + sqlDataReader6["PONo"].ToString();
								text10 = text10 + "<br>" + fun.FromDateDMY(sqlDataReader6["SysDate"].ToString());
								text11 = text11 + "<br>" + dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
								text13 = text13 + "<br>" + sqlDataReader6["Qty"].ToString();
								dataRow[15] = text9;
								dataRow[16] = text10;
								dataRow[17] = text11;
								dataRow[18] = text12;
								dataRow[19] = text13;
								string cmdText7 = "SELECT tblInv_Inward_Details.ReceivedQty As GINQty , tblInv_Inward_Master.GINNo,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As GINDate, tblInv_Inward_Master.Id,tblInv_Inward_Details.POId FROM tblInv_Inward_Master INNER JOIN tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId And tblInv_Inward_Details.POId='" + sqlDataReader6["Id"].ToString() + "' And tblInv_Inward_Master.PONo='" + sqlDataReader6["PONo"].ToString() + "' and tblInv_Inward_Master.CompId='" + CompId + "'";
								SqlCommand sqlCommand7 = new SqlCommand(cmdText7, con);
								SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
								while (sqlDataReader7.Read())
								{
									text14 = text14 + "<br>" + sqlDataReader7["GINNo"].ToString();
									text15 = text15 + "<br>" + sqlDataReader7["GINDate"].ToString();
									text16 = text16 + "<br>" + sqlDataReader7["GINQty"].ToString();
									dataRow[20] = text14;
									dataRow[21] = text15;
									dataRow[22] = text16;
									string cmdText8 = "SELECT tblinv_MaterialReceived_Details.ReceivedQty As GRRQty ,tblinv_MaterialReceived_Master.GRRNo,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As GRRDate ,tblinv_MaterialReceived_Master.Id,tblinv_MaterialReceived_Details.Id As DId FROM tblinv_MaterialReceived_Master INNER JOIN tblinv_MaterialReceived_Details ON tblinv_MaterialReceived_Master.Id = tblinv_MaterialReceived_Details.MId and tblinv_MaterialReceived_Master.CompId='" + CompId + "'And tblinv_MaterialReceived_Master.GINId='" + sqlDataReader7["Id"].ToString() + "' And tblinv_MaterialReceived_Details.POId='" + sqlDataReader7["POId"].ToString() + "' ";
									SqlCommand sqlCommand8 = new SqlCommand(cmdText8, con);
									SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
									while (sqlDataReader8.Read())
									{
										text17 = text17 + "<br>" + sqlDataReader8["GRRNo"].ToString();
										text18 = text18 + "<br>" + sqlDataReader8["GRRDate"].ToString();
										text19 = text19 + "<br>" + sqlDataReader8["GRRQty"].ToString();
										dataRow[23] = text17;
										dataRow[24] = text18;
										dataRow[25] = text19;
										string cmdText9 = "SELECT tblQc_MaterialQuality_Master.Id, REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As GQNDate, tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty As GQNQty FROM tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId and tblQc_MaterialQuality_Master.CompId='" + CompId + "'And tblQc_MaterialQuality_Master.GRRId='" + sqlDataReader8["Id"].ToString() + "'And tblQc_MaterialQuality_Details.GRRId='" + sqlDataReader8["DId"].ToString() + "'";
										SqlCommand sqlCommand9 = new SqlCommand(cmdText9, con);
										SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
										while (sqlDataReader9.Read())
										{
											text20 = text20 + "<br>" + sqlDataReader9["GQNNo"].ToString();
											text21 = text21 + "<br>" + sqlDataReader9["GQNDate"].ToString();
											text22 = text22 + "<br>" + sqlDataReader9["GQNQty"].ToString();
											dataRow[26] = text20;
											dataRow[27] = text21;
											dataRow[28] = text22;
										}
									}
								}
							}
						}
					}
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			dataTable.Columns.Remove(dataTable.Columns["Id"]);
			dataTable.AcceptChanges();
			ViewState["dtList"] = dataTable;
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void btnExport_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			foreach (ListItem item in CheckBoxList1.Items)
			{
				if (item.Value != "Sr.No" && item.Selected)
				{
					num++;
				}
			}
			DataTable dataTable = new DataTable();
			if (num > 0)
			{
				if (TxtTodate.Text != "")
				{
					if (Convert.ToDateTime(fun.FromDate(TxtTodate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && fun.DateValidation(Txtfromdate.Text) && fun.DateValidation(TxtTodate.Text))
					{
						FillGrid_Creditors(fun.FromDate(Txtfromdate.Text), fun.FromDate(TxtTodate.Text));
					}
					else
					{
						string empty = string.Empty;
						empty = "From date should not be Less than Opening Date! ";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else
				{
					FillGrid_Creditors(fd, td);
				}
				dataTable = (DataTable)ViewState["dtList"];
				foreach (ListItem item2 in CheckBoxList1.Items)
				{
					if (!item2.Selected)
					{
						if (item2.Value == "Sr.No")
						{
							dataTable.Columns.Remove(dataTable.Columns["Sr.No"]);
						}
						if (item2.Value == "0")
						{
							dataTable.Columns.Remove(dataTable.Columns["ItemCode"]);
						}
						if (item2.Value == "1")
						{
							dataTable.Columns.Remove(dataTable.Columns["Description"]);
						}
						if (item2.Value == "2")
						{
							dataTable.Columns.Remove(dataTable.Columns["UOM"]);
						}
						if (item2.Value == "3")
						{
							dataTable.Columns.Remove(dataTable.Columns["BOMQty"]);
						}
						if (item2.Value == "4")
						{
							dataTable.Columns.Remove(dataTable.Columns["WISQty"]);
						}
						if (item2.Value == "5")
						{
							dataTable.Columns.Remove(dataTable.Columns["StockQty"]);
						}
						if (item2.Value == "6")
						{
							dataTable.Columns.Remove(dataTable.Columns["PlnNo"]);
						}
						if (item2.Value == "7")
						{
							dataTable.Columns.Remove(dataTable.Columns["PlnDate"]);
						}
						if (item2.Value == "8")
						{
							dataTable.Columns.Remove(dataTable.Columns["PlnItem"]);
						}
						if (item2.Value == "9")
						{
							dataTable.Columns.Remove(dataTable.Columns["PlnQty"]);
						}
						if (item2.Value == "10")
						{
							dataTable.Columns.Remove(dataTable.Columns["PRNo"]);
						}
						if (item2.Value == "11")
						{
							dataTable.Columns.Remove(dataTable.Columns["PRDate"]);
						}
						if (item2.Value == "12")
						{
							dataTable.Columns.Remove(dataTable.Columns["PRQty"]);
						}
						if (item2.Value == "13")
						{
							dataTable.Columns.Remove(dataTable.Columns["PONo"]);
						}
						if (item2.Value == "14")
						{
							dataTable.Columns.Remove(dataTable.Columns["PODate"]);
						}
						if (item2.Value == "15")
						{
							dataTable.Columns.Remove(dataTable.Columns["Supplier"]);
						}
						if (item2.Value == "16")
						{
							dataTable.Columns.Remove(dataTable.Columns["Authorized"]);
						}
						if (item2.Value == "17")
						{
							dataTable.Columns.Remove(dataTable.Columns["POQty"]);
						}
						if (item2.Value == "18")
						{
							dataTable.Columns.Remove(dataTable.Columns["GINNo"]);
						}
						if (item2.Value == "19")
						{
							dataTable.Columns.Remove(dataTable.Columns["GINDate"]);
						}
						if (item2.Value == "20")
						{
							dataTable.Columns.Remove(dataTable.Columns["GINQty"]);
						}
						if (item2.Value == "21")
						{
							dataTable.Columns.Remove(dataTable.Columns["GRRNo"]);
						}
						if (item2.Value == "22")
						{
							dataTable.Columns.Remove(dataTable.Columns["GRRDate"]);
						}
						if (item2.Value == "23")
						{
							dataTable.Columns.Remove(dataTable.Columns["GRRQty"]);
						}
						if (item2.Value == "24")
						{
							dataTable.Columns.Remove(dataTable.Columns["GQNNo"]);
						}
						if (item2.Value == "25")
						{
							dataTable.Columns.Remove(dataTable.Columns["GQNDate"]);
						}
						if (item2.Value == "26")
						{
							dataTable.Columns.Remove(dataTable.Columns["GQNQty"]);
						}
					}
				}
			}
			if (dataTable == null)
			{
				throw new Exception("No Records to Export");
			}
			string text = "D:\\ImportExcelFromDatabase\\WONo" + WONo + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".xls";
			FileInfo fileInfo = new FileInfo(text);
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
			DataGrid dataGrid = new DataGrid();
			dataGrid.DataSource = dataTable;
			dataGrid.DataBind();
			dataGrid.RenderControl(writer);
			string path = text.Substring(0, text.LastIndexOf("\\"));
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			StreamWriter streamWriter = new StreamWriter(text, append: true);
			stringWriter.ToString().Normalize();
			streamWriter.Write(stringWriter.ToString());
			streamWriter.Flush();
			streamWriter.Close();
			WriteAttachment(fileInfo.Name, "application/vnd.ms-excel", stringWriter.ToString());
			con.Close();
		}
		catch (Exception)
		{
			string empty2 = string.Empty;
			empty2 = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
		}
	}

	public static void WriteAttachment(string FileName, string FileType, string content)
	{
		try
		{
			HttpResponse response = HttpContext.Current.Response;
			response.ClearHeaders();
			response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
			response.ContentType = FileType;
			response.Write(content);
			response.End();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProjectSummary.aspx?ModId=7");
	}

	protected void CheckAll_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckAll.Checked)
		{
			foreach (ListItem item in CheckBoxList1.Items)
			{
				item.Selected = true;
			}
			return;
		}
		foreach (ListItem item2 in CheckBoxList1.Items)
		{
			if (item2.Value != "Sr.No")
			{
				item2.Selected = false;
			}
		}
	}
}
