using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Reports_ProjectSummary_Shortage_M : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string WONo = "";

	private string SwitchTo = string.Empty;

	protected Label lblWo;

	protected DataList GridView3;

	protected Button btnExport;

	protected Button btnCancel;

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
			string cmdText = string.Empty;
			if (SwitchTo == "2")
			{
				cmdText = "select distinct(tblDG_Item_Master.ItemCode),tblDG_Item_Master.StockQty, tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic from tblDG_Item_Master inner join tblDG_BOM_Master on tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId inner join Unit_Master on  tblDG_Item_Master.UOMBasic=Unit_Master.Id  And tblDG_Item_Master.CId is null And WONo='" + WONo + "' and  tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + WONo + "' and  tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "') Order By Id ASC";
			}
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SN", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WISQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ShortQty", typeof(double)));
			int num = 1;
			double num2 = 0.0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["UOMBasic"].ToString();
				num3 = fun.AllComponentBOMQty(CompId, WONo, dataSet.Tables[0].Rows[i]["Id"].ToString(), FinYearId);
				dataRow[4] = num3;
				dataRow[0] = num.ToString();
				num4 = fun.CalWISQty(CompId.ToString(), WONo, dataSet.Tables[0].Rows[i]["Id"].ToString());
				num5 = Convert.ToDouble(dataSet.Tables[0].Rows[i]["StockQty"].ToString());
				dataRow[5] = num4;
				dataRow[6] = num5;
				double num6 = 0.0;
				num6 = Math.Round(num3 - num4, 3);
				dataRow[7] = num6;
				num2 += num6;
				if (num6 > 0.0)
				{
					num++;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			Control control = GridView3.Controls[GridView3.Controls.Count - 1].Controls[0];
			Label label = control.FindControl("lblShortQty1") as Label;
			label.Text = "Tot Short Qty - " + num2;
			ViewState["dtList"] = dataTable;
		}
		catch (Exception)
		{
		}
	}

	protected void btnExpor_Click(object sender, EventArgs e)
	{
		try
		{
			DataTable dataTable = (DataTable)ViewState["dtList"];
			dataTable.Columns[1].ColumnName = "Item Code";
			dataTable.Columns[2].ColumnName = "Description";
			dataTable.Columns[3].ColumnName = "UOM";
			dataTable.Columns[4].ColumnName = "BOM Qty";
			dataTable.Columns[5].ColumnName = "WIS Qty";
			dataTable.Columns[6].ColumnName = "Stock Qty";
			dataTable.Columns[7].ColumnName = "Short Qty";
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
		base.Response.Redirect("ProjectSummary.aspx?ModId=7");
	}
}
