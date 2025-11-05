using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Reports_ProjectSummary_Shortage : Page, IRequiresSessionState
{
	protected Label lblWo;

	protected DataList GridView3;

	protected UpdatePanel UpdatePanel1;

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

	private string shree = string.Empty;

	private string Trans = string.Empty;

	private string parentPage = "~/Module/MaterialManagement/Reports/ProjectSummary_Shortage.aspx";

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
			shree = Session["WorkOrderId"].ToString();
			lblWo.Text = shree;
			if (!string.IsNullOrEmpty(base.Request.QueryString["SwitchTo"]))
			{
				SwitchTo = base.Request.QueryString["SwitchTo"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["Trans"]))
			{
				Trans = base.Request.QueryString["Trans"].ToString();
			}
			if (!Page.IsPostBack)
			{
				FillGrid_Creditors();
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
			string[] array = shree.Split(',');
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Sn", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ShortQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WISQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PODate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PORate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POAmount", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ScheduledDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GINQty", typeof(string)));
			int num = 1;
			for (int i = 0; i < array.Length - 1; i++)
			{
				string cmdText = string.Empty;
				switch (SwitchTo)
				{
				case "1":
					cmdText = "select distinct(tblDG_Item_Master.ItemCode),tblDG_Item_Master.PartNo,tblDG_Item_Master.CId,tblDG_Item_Master.StockQty ,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.WONo from tblDG_Item_Master inner join tblDG_BOM_Master on tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId inner join Unit_Master on  tblDG_Item_Master.UOMBasic=Unit_Master.Id  And tblDG_Item_Master.CId is not null And WONo='" + array[i].ToString() + "' and  tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "'  AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + array[i].ToString() + "' and  tblDG_Item_Master.CompId='" + CompId + "'  And tblDG_Item_Master.FinYearId<='" + FinYearId + "')  Order By tblDG_Item_Master.ItemCode ASC";
					break;
				case "2":
					cmdText = "select distinct(tblDG_Item_Master.ItemCode),tblDG_Item_Master.PartNo,tblDG_Item_Master.CId,tblDG_Item_Master.StockQty ,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.WONo from tblDG_Item_Master inner join tblDG_BOM_Master on tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId inner join Unit_Master on  tblDG_Item_Master.UOMBasic=Unit_Master.Id  And tblDG_Item_Master.CId is null And WONo='" + array[i].ToString() + "' and  tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + array[i].ToString() + "' and  tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "') Order By tblDG_Item_Master.ItemCode ASC";
					break;
				}
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				foreach (DataRow row3 in dataSet.Tables[0].Rows)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = row3.Field<string>("ItemCode");
					dataRow[1] = row3.Field<string>("ManfDesc");
					dataRow[2] = row3.Field<string>("UOMBasic");
					num5 = fun.AllComponentBOMQty(CompId, row3.Field<string>("WONo"), row3.Field<int>("Id").ToString(), FinYearId);
					dataRow[3] = num5;
					dataRow[4] = row3.Field<int>("Id");
					dataRow[5] = num.ToString();
					double num6 = 0.0;
					num6 = fun.CalWISQty(CompId.ToString(), row3.Field<string>("WONo"), row3.Field<int>("Id").ToString());
					fun.CalPRQty(CompId, row3.Field<string>("WONo"), row3.Field<int>("Id"));
					num4 = fun.GINQTY(CompId, row3.Field<string>("WONo"), row3.Field<int>("Id").ToString());
					num3 = fun.GQNQTY(CompId, row3.Field<string>("WONo"), row3.Field<int>("Id").ToString());
					num2 = Math.Round(num5 - num6 - num4 + num3, 3);
					string text = string.Empty;
					string cmdText2 = "select distinct(tblDG_BOM_Master.ItemId),tblDG_BOM_Master.SysDate from tblDG_BOM_Master where tblDG_BOM_Master.WONo='" + row3.Field<string>("WONo") + "' and tblDG_BOM_Master.CompId='" + CompId + "'And tblDG_BOM_Master.FinYearId<='" + FinYearId + "' AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + row3.Field<string>("WONo") + "' and tblDG_BOM_Master.CompId='" + CompId + "' And tblDG_BOM_Master.FinYearId<='" + FinYearId + "') And tblDG_BOM_Master.ItemId='" + row3.Field<int>("Id") + "'Order By tblDG_BOM_Master.ItemId ASC ";
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					foreach (DataRow row4 in dataSet2.Tables[0].Rows)
					{
						text = text + " " + fun.FromDateDMY(row4.Field<string>("SysDate"));
					}
					dataRow[8] = text;
					dataRow[6] = num2;
					dataRow[9] = num6;
					dataRow[7] = row3.Field<string>("WONo");
					switch (Trans)
					{
					case "1":
						if (num2 > 0.0)
						{
							num++;
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
						break;
					case "2":
						if (num2 == 0.0)
						{
							num++;
							dataTable.Rows.Add(dataRow);
							dataTable.AcceptChanges();
						}
						break;
					case "3":
						num++;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
						break;
					}
				}
				GridView3.DataSource = dataTable;
				GridView3.DataBind();
			}
			for (int j = 0; j < dataTable.Rows.Count; j++)
			{
				DataTable dataTable2 = new DataTable();
				dataTable2.Columns.Add(new DataColumn("PRNo", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("PRQty", typeof(double)));
				string cmdText3 = "SELECT tblMM_PR_Details.Id As PRId, tblMM_PR_Master.PRNo,tblMM_PR_Details.Qty As PRQty   FROM tblMM_PR_Master INNER JOIN tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId And tblMM_PR_Master.WONo='" + dataTable.Rows[j]["WONo"].ToString() + "' And tblMM_PR_Details.ItemId='" + dataTable.Rows[j]["Id"].ToString() + "' ";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				DataListItem dataListItem = GridView3.Items[j];
				DataList dataList = dataListItem.FindControl("DataList2") as DataList;
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataList.DataSource = dataSet3;
					dataList.DataBind();
					if (dataSet3.Tables[0].Rows.Count > 1)
					{
						string text2 = string.Empty;
						string text3 = string.Empty;
						for (int k = 0; k < dataSet3.Tables[0].Rows.Count; k++)
						{
							text2 = text2 + "," + dataSet3.Tables[0].Rows[k]["PRNo"];
							dataTable.Rows[j]["PRNo"] = text2;
							text3 = text3 + "," + dataSet3.Tables[0].Rows[k]["PRQty"].ToString();
							dataTable.Rows[j]["PRQty"] = text3;
							dataTable.AcceptChanges();
						}
					}
					else
					{
						_ = string.Empty;
						dataTable.Rows[j]["PRNo"] = dataSet3.Tables[0].Rows[0]["PRNo"];
						dataTable.Rows[j]["PRQty"] = dataSet3.Tables[0].Rows[0]["PRQty"];
						dataTable.AcceptChanges();
					}
				}
				else
				{
					DataRow dataRow2 = dataTable2.NewRow();
					dataRow2[0] = " ";
					dataRow2[1] = 0;
					dataTable2.Rows.Add(dataRow2);
					dataTable2.AcceptChanges();
					dataList.DataSource = dataTable2;
					dataList.DataBind();
					dataTable.Rows[j]["PRNo"] = dataTable2.Rows[0]["PRNo"];
					dataTable.Rows[j]["PRQty"] = dataTable2.Rows[0]["PRQty"];
				}
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					string text4 = string.Empty;
					string text5 = string.Empty;
					string text6 = string.Empty;
					string text7 = string.Empty;
					string text8 = string.Empty;
					string text9 = string.Empty;
					string text10 = string.Empty;
					for (int l = 0; l < dataSet3.Tables[0].Rows.Count; l++)
					{
						DataTable dataTable3 = new DataTable();
						dataTable3.Columns.Add(new DataColumn("POId", typeof(string)));
						dataTable3.Columns.Add(new DataColumn("PONo", typeof(string)));
						dataTable3.Columns.Add(new DataColumn("PORate", typeof(double)));
						dataTable3.Columns.Add(new DataColumn("Supplier", typeof(string)));
						dataTable3.Columns.Add(new DataColumn("POQty", typeof(double)));
						dataTable3.Columns.Add(new DataColumn("POAmount", typeof(double)));
						dataTable3.Columns.Add(new DataColumn("PODate", typeof(string)));
						dataTable3.Columns.Add(new DataColumn("PODelDate", typeof(string)));
						string cmdText4 = "SELECT tblMM_PO_Details.Id,tblMM_PO_Details.DelDate,tblMM_PO_Master.SysDate,tblMM_PO_Master.PONo,tblMM_PO_Details.Discount,tblMM_PO_Details.Rate,  tblMM_PO_Master.SupplierId, tblMM_PO_Details.Qty FROM tblMM_PO_Master INNER JOIN tblMM_PO_Details ON tblMM_PO_Master.Id = tblMM_PO_Details.MId And tblMM_PO_Details.PRId='" + dataSet3.Tables[0].Rows[l]["PRId"].ToString() + "' ";
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						for (int m = 0; m < dataSet4.Tables[0].Rows.Count; m++)
						{
							double num7 = 0.0;
							double num8 = 0.0;
							double num9 = 0.0;
							DataRow dataRow3 = dataTable3.NewRow();
							dataRow3[0] = dataSet4.Tables[0].Rows[m]["Id"].ToString();
							dataRow3[1] = dataSet4.Tables[0].Rows[m]["PONo"].ToString();
							num7 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[m]["Rate"].ToString()).ToString("N2"));
							num8 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[m]["Discount"].ToString()).ToString("N2"));
							dataRow3[2] = num7;
							string selectCommandText = fun.select("SupplierName+' '+'[' +SupplierId+']' As SupplierName ", "tblMM_Supplier_master", "CompId='" + CompId + "' And SupplierId='" + dataSet4.Tables[0].Rows[m]["SupplierId"].ToString() + "'");
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommandText, con);
							DataSet dataSet5 = new DataSet();
							sqlDataAdapter5.Fill(dataSet5, "tblMM_Supplier_master");
							if (dataSet5.Tables[0].Rows.Count > 0)
							{
								dataRow3[3] = dataSet5.Tables[0].Rows[0]["SupplierName"].ToString();
							}
							num9 = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[m]["Qty"].ToString()).ToString("N3"));
							dataRow3[4] = num9;
							dataRow3[5] = num9 * (num7 - num7 * num8 / 100.0);
							dataRow3[6] = fun.FromDateDMY(dataSet4.Tables[0].Rows[m]["SysDate"].ToString());
							dataRow3[7] = fun.FromDateDMY(dataSet4.Tables[0].Rows[m]["DelDate"].ToString());
							dataTable3.Rows.Add(dataRow3);
							dataTable3.AcceptChanges();
							if (dataSet3.Tables[0].Rows.Count > 1)
							{
								text4 = text4 + "," + dataSet4.Tables[0].Rows[m]["PONo"];
								dataTable.Rows[j]["PONo"] = text4;
								text5 = text5 + "," + dataSet4.Tables[0].Rows[m]["Rate"].ToString();
								dataTable.Rows[j]["PORate"] = text5;
								text6 = text6 + "," + dataRow3[3].ToString();
								dataTable.Rows[j]["Supplier"] = text6;
								text7 = text7 + "," + dataSet4.Tables[0].Rows[m]["Qty"].ToString();
								dataTable.Rows[j]["POQty"] = text7;
								text8 = text8 + "," + num9 * (num7 - num7 * num8 / 100.0);
								dataTable.Rows[j]["POAmount"] = text8;
								text9 = text9 + "," + fun.FromDateDMY(dataSet4.Tables[0].Rows[m]["SysDate"].ToString());
								dataTable.Rows[j]["PODate"] = text9;
								text10 = text10 + "," + fun.FromDateDMY(dataSet4.Tables[0].Rows[m]["DelDate"].ToString());
								dataTable.Rows[j]["ScheduledDate"] = text10;
								dataTable.AcceptChanges();
							}
							else
							{
								dataTable.Rows[j]["PONo"] = dataSet4.Tables[0].Rows[m]["PONo"].ToString();
								dataTable.Rows[j]["PORate"] = dataSet4.Tables[0].Rows[m]["Rate"].ToString();
								dataTable.Rows[j]["Supplier"] = dataRow3[3].ToString();
								dataTable.Rows[j]["POQty"] = dataSet4.Tables[0].Rows[m]["Qty"].ToString();
								dataTable.Rows[j]["POAmount"] = num9 * (num7 - num7 * num8 / 100.0);
								dataTable.Rows[j]["PODate"] = fun.FromDateDMY(dataSet4.Tables[0].Rows[m]["SysDate"].ToString());
								dataTable.Rows[j]["ScheduledDate"] = fun.FromDateDMY(dataSet4.Tables[0].Rows[m]["DelDate"].ToString());
								dataTable.AcceptChanges();
							}
						}
						DataListItem dataListItem2 = dataList.Items[l];
						DataList dataList2 = dataListItem2.FindControl("DataList3") as DataList;
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataList2.DataSource = dataTable3;
							dataList2.DataBind();
						}
						string text11 = string.Empty;
						string text12 = string.Empty;
						if (dataTable3.Rows.Count <= 0)
						{
							continue;
						}
						for (int n = 0; n < dataTable3.Rows.Count; n++)
						{
							string cmdText5 = string.Concat("SELECT tblInv_Inward_Details.ReceivedQty As GINQty , tblInv_Inward_Master.GINNo FROM tblInv_Inward_Master INNER JOIN tblInv_Inward_Details ON tblInv_Inward_Master.Id = tblInv_Inward_Details.GINId And tblInv_Inward_Details.POId='", dataTable3.Rows[n]["POId"], "' And tblInv_Inward_Master.PONo='", dataTable3.Rows[n]["PONo"].ToString(), "' and tblInv_Inward_Master.CompId='", CompId, "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet6 = new DataSet();
							sqlDataAdapter6.Fill(dataSet6);
							DataListItem dataListItem3 = dataList2.Items[n];
							DataList dataList3 = dataListItem3.FindControl("DataList4") as DataList;
							if (dataSet6.Tables[0].Rows.Count <= 0)
							{
								continue;
							}
							dataList3.DataSource = dataSet6.Tables[0];
							dataList3.DataBind();
							if (dataSet6.Tables[0].Rows.Count > 1)
							{
								for (int num10 = 0; num10 < dataSet6.Tables[0].Rows.Count; num10++)
								{
									text11 = text11 + "," + dataSet6.Tables[0].Rows[num10]["GINNo"];
									text12 = text12 + "," + dataSet6.Tables[0].Rows[num10]["GINQty"].ToString();
									dataTable.Rows[j]["GINNo"] = text11;
									dataTable.Rows[j]["GINQty"] = text12;
									dataTable.AcceptChanges();
								}
							}
							else
							{
								dataTable.Rows[j]["GINNo"] = dataSet6.Tables[0].Rows[0]["GINNo"];
								dataTable.Rows[j]["GINQty"] = dataSet6.Tables[0].Rows[0]["GINQty"];
								dataTable.AcceptChanges();
							}
						}
					}
				}
				else
				{
					DataListItem dataListItem4 = dataList.Items[0];
					DataList dataList4 = dataListItem4.FindControl("DataList3") as DataList;
					DataTable dataTable4 = new DataTable();
					dataTable4.Columns.Add(new DataColumn("POId", typeof(string)));
					dataTable4.Columns.Add(new DataColumn("PONo", typeof(string)));
					dataTable4.Columns.Add(new DataColumn("PORate", typeof(double)));
					dataTable4.Columns.Add(new DataColumn("Supplier", typeof(string)));
					dataTable4.Columns.Add(new DataColumn("POQty", typeof(double)));
					dataTable4.Columns.Add(new DataColumn("POAmount", typeof(double)));
					dataTable4.Columns.Add(new DataColumn("PODate", typeof(string)));
					dataTable4.Columns.Add(new DataColumn("PODelDate", typeof(string)));
					DataRow dataRow4 = dataTable4.NewRow();
					dataRow4[0] = 0;
					dataRow4[1] = " ";
					dataRow4[2] = 0;
					dataRow4[3] = " ";
					dataRow4[4] = 0;
					dataRow4[5] = 0;
					dataRow4[6] = "-";
					dataRow4[7] = "-";
					dataTable4.Rows.Add(dataRow4);
					dataTable4.AcceptChanges();
					dataList4.DataSource = dataTable4;
					dataList4.DataBind();
					dataTable.Rows[j]["PONo"] = dataTable4.Rows[0]["PONo"];
					dataTable.Rows[j]["PORate"] = dataTable4.Rows[0]["PORate"].ToString();
					dataTable.Rows[j]["Supplier"] = dataTable4.Rows[0]["Supplier"].ToString();
					dataTable.Rows[j]["POQty"] = dataTable4.Rows[0]["POQty"].ToString();
					dataTable.Rows[j]["POAmount"] = dataTable4.Rows[0]["POAmount"].ToString();
					dataTable.Rows[j]["PODate"] = dataTable4.Rows[0]["PODate"].ToString();
					dataTable.Rows[j]["ScheduledDate"] = dataTable4.Rows[0]["PODelDate"].ToString();
					dataTable.AcceptChanges();
				}
			}
			DataSet dataSet7 = new ForeCasting();
			dataSet7.Tables[0].Merge(dataTable);
			dataSet7.Tables[0].Columns.Remove(dataSet7.Tables[0].Columns["Id"]);
			dataSet7.Tables[0].Columns.Remove(dataSet7.Tables[0].Columns["Sn"]);
			dataSet7.AcceptChanges();
			if (dataSet7 != null)
			{
				ViewState["dtList"] = dataSet7.Tables[0];
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnExport_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)ViewState["dtList"];
			if (dataTable == null)
			{
				throw new Exception("No Records to Export");
			}
			string text = "D:\\ImportExcelFromDatabase\\myexcelfile_" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".xls";
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MaterialManagement/Reports/MaterialForecasting.aspx?ModId=6");
	}

	protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
	{
		try
		{
			if (!(e.CommandName == "NavTo"))
			{
				return;
			}
			DataListItem dataListItem = (DataListItem)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((LinkButton)dataListItem.FindControl("lblPONo")).Text;
			string code = fun.getCode(((Label)dataListItem.FindControl("lblSupplier")).Text);
			string text2 = ((Label)dataListItem.FindControl("lblPOId")).Text;
			string cmdText = fun.select("MId", "tblMM_PO_Details", "Id='" + text2 + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			string cmdText2 = fun.select("PRSPRFlag,AmendmentNo", "tblMM_PO_Master", "Id='" + dataSet.Tables[0].Rows[0]["MId"].ToString() + "' AND FinYearId<='" + FinYearId + "' AND SupplierId='" + code + "' And PONo='" + text + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string text3 = "";
				text3 = dataSet2.Tables[0].Rows[0]["AmendmentNo"].ToString();
				if (dataSet2.Tables[0].Rows[0][0].ToString() == "0")
				{
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("~/Module/MaterialManagement/Transactions/PO_PR_View_Print_Details.aspx?mid=" + dataSet.Tables[0].Rows[0]["MId"].ToString() + "&pono=" + text + "&Code=" + code + "&AmdNo=" + text3 + "&Swto=" + SwitchTo + "&Key=" + randomAlphaNumeric + "&Trans=" + Trans + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
				else
				{
					string randomAlphaNumeric2 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("~/Module/MaterialManagement/Transactions/PO_SPR_View_Print_Details.aspx?mid=" + dataSet.Tables[0].Rows[0]["MId"].ToString() + "&pono=" + text + "&Code=" + code + "&AmdNo=" + text3 + "&Swto=" + SwitchTo + "&Key=" + randomAlphaNumeric2 + "&Trans=" + Trans + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_UnLoad(object sender, EventArgs e)
	{
		GC.Collect();
	}
}
