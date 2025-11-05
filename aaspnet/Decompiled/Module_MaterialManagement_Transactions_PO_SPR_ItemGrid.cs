using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_SPR_ItemGrid : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private string SupCode = string.Empty;

	private string FyId = string.Empty;

	private string CompId = string.Empty;

	private int Id;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			SupCode = base.Request.QueryString["Code"].ToString();
			FyId = Session["finyear"].ToString();
			CompId = Session["compid"].ToString();
			LoadSPRData();
		}
		catch (Exception)
		{
		}
	}

	public void LoadSPRData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("tblMM_SPR_Master.SysDate,tblMM_SPR_Master.SessionId,tblMM_SPR_Master.SPRNo,tblMM_SPR_Master.FinYearId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.Id,tblMM_SPR_Details.ItemId,tblMM_SPR_Details.AHId,tblMM_SPR_Details.Qty,tblMM_SPR_Details.DelDate", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Details.SupplierId='" + SupCode + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblMM_SPR_Master.Authorize='1' AND tblMM_SPR_Master.FinYearId<='" + FyId + "' AND tblMM_SPR_Master.CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("SPRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeliDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RemainQty", typeof(double)));
			while (sqlDataReader.Read())
			{
				string cmdText2 = fun.select("*", "tblMM_SPR_PO_Temp", "CompId='" + CompId + "' AND SPRNo='" + sqlDataReader["SPRNo"].ToString() + "' AND SPRId='" + sqlDataReader["Id"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				num3 = Convert.ToDouble(sqlDataReader["Qty"].ToString());
				double num4 = 0.0;
				string cmdText3 = fun.select("Sum(tblMM_PO_Details.Qty)As TotPoQty", "tblMM_PO_Master,tblMM_PO_Details", "tblMM_PO_Details.SPRId='" + sqlDataReader["Id"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3.HasRows && sqlDataReader3[0] != DBNull.Value)
				{
					num4 = Convert.ToDouble(sqlDataReader3[0].ToString());
				}
				num2 = Math.Round(num3 - num4, 5);
				if (num2 > 0.0 && !sqlDataReader2.HasRows)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = sqlDataReader["SPRNo"].ToString();
					dataRow[5] = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
					dataRow[9] = sqlDataReader["Id"].ToString();
					Id = Convert.ToInt32(dataRow[9]);
					string cmdText4 = fun.select("Symbol AS Head", "AccHead", "Id ='" + Convert.ToInt32(sqlDataReader["AHId"].ToString()) + "' ");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					dataRow[6] = sqlDataReader4["Head"].ToString();
					string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
					dataRow[1] = value;
					string cmdText5 = fun.select("EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + sqlDataReader["SessionId"].ToString() + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					dataRow[8] = sqlDataReader5[0].ToString();
					string cmdText6 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + sqlDataReader["ItemId"].ToString() + "'");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					if (sqlDataReader6.HasRows)
					{
						dataRow[2] = fun.GetItemCode_PartNo(Convert.ToInt32(CompId), Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
						dataRow[3] = sqlDataReader6[1].ToString();
						string cmdText7 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader6[2].ToString() + "'");
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
						sqlDataReader7.Read();
						dataRow[4] = sqlDataReader7[0].ToString();
					}
					string text = "";
					string text2 = "";
					text2 = ((!(sqlDataReader["WONo"].ToString() != "")) ? "NA" : sqlDataReader["WONo"].ToString());
					int num5 = Convert.ToInt32(sqlDataReader["DeptId"].ToString());
					if (num5 > 0)
					{
						string cmdText8 = fun.select("Symbol AS Dept", "BusinessGroup", "Id ='" + Convert.ToInt32(sqlDataReader["DeptId"].ToString()) + "' ");
						SqlCommand sqlCommand8 = new SqlCommand(cmdText8, sqlConnection);
						SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
						sqlDataReader8.Read();
						text = sqlDataReader8["Dept"].ToString();
					}
					else
					{
						text = "NA";
					}
					dataRow[10] = text2;
					dataRow[11] = text;
					dataRow[7] = fun.FromDateDMY(sqlDataReader["DelDate"].ToString());
					string cmdText9 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + sqlDataReader["FinYearId"].ToString() + "'");
					SqlCommand sqlCommand9 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataReader sqlDataReader9 = sqlCommand9.ExecuteReader();
					sqlDataReader9.Read();
					dataRow[12] = sqlDataReader9["FinYear"].ToString();
					dataRow[13] = Math.Round(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")) - num2, 5);
					dataRow[14] = Convert.ToDouble(num2 - num);
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

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		LoadSPRData();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblsprno")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
				base.Response.Redirect("PO_SPR_ItemSelect.aspx?sprno=" + text + "&sprid=" + text2 + "&Code=" + SupCode + "&ModId=6&SubModId=35");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}
