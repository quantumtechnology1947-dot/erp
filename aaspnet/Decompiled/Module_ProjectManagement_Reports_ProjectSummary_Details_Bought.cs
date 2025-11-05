using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Reports_ProjectSummary_Details_Bought : Page, IRequiresSessionState
{
	protected Label lblWo;

	protected CheckBox CheckAll;

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

	public void FillGrid_Creditors()
	{
		try
		{
			DataTable dataTable = new DataTable();
			string cmdText = string.Empty;
			if (SwitchTo == "1")
			{
				cmdText = "select distinct(tblDG_Item_Master.ItemCode),tblDG_Item_Master.PartNo,tblDG_Item_Master.CId, tblDG_Item_Master.Id,tblDG_Item_Master.StockQty,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic from tblDG_Item_Master inner join tblDG_BOM_Master on tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId inner join Unit_Master on  tblDG_Item_Master.UOMBasic=Unit_Master.Id  And tblDG_Item_Master.CId is not null And WONo='" + WONo + "' and  tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + WONo + "'  and  tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "') Order By tblDG_Item_Master.Id ASC";
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
				string cmdText2 = "SELECT tblMM_PR_Details.Id As PRId,tblMM_PR_Master.PRNo, REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As PRDate , tblMM_PR_Details.Qty As PRQty   FROM tblMM_PR_Master INNER JOIN tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId And tblMM_PR_Master.WONo='" + WONo + "' And tblMM_PR_Details.ItemId='" + sqlDataReader["Id"].ToString() + "' ";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				string text = string.Empty;
				string text2 = string.Empty;
				string text3 = string.Empty;
				string text4 = string.Empty;
				string text5 = string.Empty;
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
				while (sqlDataReader2.Read())
				{
					text = text + "<br>" + sqlDataReader2["PRNo"].ToString();
					text2 = text2 + "<br>" + sqlDataReader2["PRDate"].ToString();
					text3 = text3 + "<br>" + sqlDataReader2["PRQty"].ToString();
					dataRow[8] = text;
					dataRow[9] = text2;
					dataRow[10] = text3;
					string cmdText3 = "SELECT tblMM_PO_Details.Id, tblMM_PO_Master.PONo, tblMM_PO_Master.SysDate, tblMM_PO_Master.SupplierId, tblMM_PO_Master.Authorize,tblMM_PO_Details.Qty FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId And tblMM_PO_Details.PRId='" + sqlDataReader2["PRId"].ToString() + "' ";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, con);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					while (sqlDataReader3.Read())
					{
						string selectCommandText = fun.select("SupplierName+'['+SupplierId+']' As SupplierName ", "tblMM_Supplier_master", "CompId='" + CompId + "' And SupplierId='" + sqlDataReader3["SupplierId"].ToString() + "'");
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, con);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
						text7 = ((!(sqlDataReader3["Authorize"].ToString() == "1")) ? (text7 + "<br>No") : (text7 + "<br>Yes"));
						text4 = text4 + "<br>" + sqlDataReader3["PONo"].ToString();
						text5 = text5 + "<br>" + fun.FromDateDMY(sqlDataReader3["SysDate"].ToString());
						text6 = text6 + "<br>" + dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
						text8 = text8 + "<br>" + sqlDataReader3["Qty"].ToString();
						dataRow[11] = text4;
						dataRow[12] = text5;
						dataRow[13] = text6;
						dataRow[14] = text7;
						dataRow[15] = text8;
						string cmdText4 = "SELECT tblInv_Inward_Details.ReceivedQty As GINQty , tblInv_Inward_Master.GINNo,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As GINDate, tblInv_Inward_Master.Id,tblInv_Inward_Details.POId FROM tblInv_Inward_Master INNER JOIN tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId And tblInv_Inward_Details.POId='" + sqlDataReader3["Id"].ToString() + "' And tblInv_Inward_Master.PONo='" + sqlDataReader3["PONo"].ToString() + "' and tblInv_Inward_Master.CompId='" + CompId + "'";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, con);
						SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
						while (sqlDataReader4.Read())
						{
							text9 = text9 + "<br>" + sqlDataReader4["GINNo"].ToString();
							text10 = text10 + "<br>" + sqlDataReader4["GINDate"].ToString();
							text11 = text11 + "<br>" + sqlDataReader4["GINQty"].ToString();
							dataRow[16] = text9;
							dataRow[17] = text10;
							dataRow[18] = text11;
							string cmdText5 = "SELECT tblinv_MaterialReceived_Details.ReceivedQty As GRRQty ,tblinv_MaterialReceived_Master.GRRNo,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As GRRDate ,tblinv_MaterialReceived_Master.Id,tblinv_MaterialReceived_Details.Id As DId FROM tblinv_MaterialReceived_Master INNER JOIN tblinv_MaterialReceived_Details ON tblinv_MaterialReceived_Master.Id = tblinv_MaterialReceived_Details.MId and tblinv_MaterialReceived_Master.CompId='" + CompId + "'And tblinv_MaterialReceived_Master.GINId='" + sqlDataReader4["Id"].ToString() + "' And tblinv_MaterialReceived_Details.POId='" + sqlDataReader4["POId"].ToString() + "' ";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, con);
							SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
							while (sqlDataReader5.Read())
							{
								text12 = text12 + "<br>" + sqlDataReader5["GRRNo"].ToString();
								text13 = text13 + "<br>" + sqlDataReader5["GRRDate"].ToString();
								text14 = text14 + "<br>" + sqlDataReader5["GRRQty"].ToString();
								dataRow[19] = text12;
								dataRow[20] = text13;
								dataRow[21] = text14;
								string cmdText6 = "SELECT tblQc_MaterialQuality_Master.Id, REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(SysDate, CHARINDEX('-',SysDate) + 1, 2) + '-' + LEFT(SysDate,CHARINDEX('-', SysDate) - 1) + '-' + RIGHT(SysDate, CHARINDEX('-', REVERSE(SysDate)) - 1)), 103), '/', '-') As GQNDate, tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty As GQNQty FROM tblQc_MaterialQuality_Master INNER JOIN tblQc_MaterialQuality_Details ON tblQc_MaterialQuality_Master.Id = tblQc_MaterialQuality_Details.MId and tblQc_MaterialQuality_Master.CompId='" + CompId + "'And tblQc_MaterialQuality_Master.GRRId='" + sqlDataReader5["Id"].ToString() + "'And tblQc_MaterialQuality_Details.GRRId='" + sqlDataReader5["DId"].ToString() + "'";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, con);
								SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
								while (sqlDataReader6.Read())
								{
									text15 = text15 + "<br>" + sqlDataReader6["GQNNo"].ToString();
									text16 = text16 + "<br>" + sqlDataReader6["GQNDate"].ToString();
									text17 = text17 + "<br>" + sqlDataReader6["GQNQty"].ToString();
									dataRow[22] = text15;
									dataRow[23] = text16;
									dataRow[24] = text17;
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
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ProjectSummary.aspx?ModId=7");
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
				con.Open();
				FillGrid_Creditors();
				con.Close();
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
		}
		catch (Exception)
		{
			string empty = string.Empty;
			empty = "No Records to Export.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
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

	protected void CheckAll_CheckedChanged(object sender, EventArgs e)
	{
		try
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
		catch (Exception)
		{
		}
	}
}
