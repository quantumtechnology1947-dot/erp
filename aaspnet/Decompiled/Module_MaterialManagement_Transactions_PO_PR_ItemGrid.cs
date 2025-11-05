using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_PO_PR_ItemGrid : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private string SupCode = "";

	private int Id;

	private string FyId = "";

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			SupCode = base.Request.QueryString["Code"].ToString();
			FyId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("tblMM_PR_Master.PRNo,tblMM_PR_Master.FinYearId,tblMM_PR_Master.SysDate,tblMM_PR_Master.SessionId,tblMM_PR_Master.WONo,tblMM_PR_Details.Id,tblMM_PR_Details.ItemId,tblMM_PR_Details.DelDate,tblMM_PR_Details.AHId,tblMM_PR_Details.Qty", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Details.SupplierId='" + SupCode + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.FinYearId<='" + FyId + "'  AND  tblMM_PR_Master.CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			dataTable.Columns.Add(new DataColumn("PRNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMPurch", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AcHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeliDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("POQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RemainQty", typeof(double)));
			while (sqlDataReader.Read())
			{
				string cmdText2 = fun.select("Id", "tblMM_PR_PO_Temp", "PRNo='" + sqlDataReader["PRNo"].ToString() + "' AND PRId='" + sqlDataReader["Id"].ToString() + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				num3 = Convert.ToDouble(sqlDataReader["Qty"].ToString());
				double num4 = 0.0;
				string empty = string.Empty;
				empty = fun.select("Sum(tblMM_PO_Details.Qty)As TotPoQty", "tblMM_PO_Master,tblMM_PO_Details", " tblMM_PO_Details.PRId='" + sqlDataReader["Id"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "'  AND tblMM_PO_Master.Id=tblMM_PO_Details.MId ");
				SqlCommand sqlCommand3 = new SqlCommand(empty, sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (sqlDataReader3.HasRows && sqlDataReader3[0] != DBNull.Value)
				{
					num4 = Convert.ToDouble(sqlDataReader3[0].ToString());
				}
				num2 = Math.Round(num3 - num4, 5);
				if (!(num2 > 0.0) || sqlDataReader2.HasRows)
				{
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = sqlDataReader["PRNo"].ToString();
				dataRow[5] = Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3"));
				dataRow[9] = sqlDataReader["Id"].ToString();
				Id = Convert.ToInt32(dataRow[9]);
				string cmdText3 = fun.select("'['+AccHead.Symbol+']'+AccHead.Description AS Head", "AccHead", "Id ='" + Convert.ToInt32(sqlDataReader["AHId"].ToString()) + "' ");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				if (sqlDataReader4.HasRows)
				{
					dataRow[6] = sqlDataReader4["Head"].ToString();
				}
				string value = fun.FromDateDMY(sqlDataReader["SysDate"].ToString());
				dataRow[1] = value;
				string cmdText4 = fun.select("Title+'. '+EmployeeName", "tblHR_OfficeStaff", "EmpId='" + sqlDataReader["SessionId"].ToString() + "' AND  CompId='" + CompId + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
				sqlDataReader5.Read();
				if (sqlDataReader5.HasRows)
				{
					dataRow[8] = sqlDataReader5[0].ToString();
				}
				string cmdText5 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader["ItemId"].ToString() + "' AND CompId='" + CompId + "'  ");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				if (sqlDataReader6.HasRows)
				{
					dataRow[2] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
					dataRow[3] = sqlDataReader6[1].ToString();
					string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader6["UOMBasic"].ToString() + "'");
					SqlCommand sqlCommand7 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
					sqlDataReader7.Read();
					if (sqlDataReader7.HasRows)
					{
						dataRow[4] = sqlDataReader7[0].ToString();
					}
				}
				dataRow[7] = fun.FromDateDMY(sqlDataReader["DelDate"].ToString());
				dataRow[10] = sqlDataReader["WONo"].ToString();
				string cmdText7 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + sqlDataReader["FinYearId"].ToString() + "' AND CompId='" + CompId + "' ");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				sqlDataReader8.Read();
				if (sqlDataReader8.HasRows)
				{
					dataRow[11] = sqlDataReader8["FinYear"].ToString();
				}
				dataRow[12] = Math.Round(Convert.ToDouble(decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3")) - num2, 5);
				dataRow[13] = Convert.ToDouble(num2 - num);
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
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
		LoadData();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "sel")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblprno")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblwono")).Text;
			if (text != "" && text2 != "" && text3 != "")
			{
				base.Response.Redirect("PO_PR_ItemSelect.aspx?wono=" + text3 + "&prno=" + text + "&prid=" + text2 + "&Code=" + SupCode + "&ModId=6&SubModId=35");
			}
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}
