using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRNNo = "";

	private string MRQNNo = "";

	private int FyId;

	private int CompId;

	private string MId = "";

	protected GridView GridView1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MRNNo = base.Request.QueryString["MRNNo"].ToString();
			MRQNNo = base.Request.QueryString["MRQNNo"].ToString();
			FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
			CompId = Convert.ToInt32(Session["compid"]);
			MId = base.Request.QueryString["Id"].ToString();
			if (!Page.IsPostBack)
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
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("RetQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotalAccptedQty", typeof(double)));
			SqlCommand sqlCommand = new SqlCommand(fun.select("tblQc_MaterialReturnQuality_Details.Id,tblQc_MaterialReturnQuality_Details.MRNId,tblQc_MaterialReturnQuality_Details.MRQNNo,tblQc_MaterialReturnQuality_Details.AcceptedQty,tblQc_MaterialReturnQuality_Master.MRNId as MSId", "tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master", "tblQc_MaterialReturnQuality_Master.Id='" + MId + "' AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id  AND tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "'"), sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(sqlDataReader["Id"]);
				SqlCommand sqlCommand2 = new SqlCommand(fun.select("tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", "tblInv_MaterialReturn_Details.Id='" + Convert.ToInt32(sqlDataReader["MRNId"]) + "' AND tblInv_MaterialReturn_Master.CompId='" + CompId + "'AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId"), sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (!sqlDataReader2.HasRows)
				{
					continue;
				}
				SqlCommand sqlCommand3 = new SqlCommand(fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(sqlDataReader2["ItemId"]) + "' AND  CompId='" + CompId + "' "), sqlConnection);
				SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
				sqlDataReader3.Read();
				if (!sqlDataReader3.HasRows)
				{
					continue;
				}
				SqlCommand sqlCommand4 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(sqlDataReader3["UOMBasic"]) + "'"), sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader2["ItemId"].ToString()));
				dataRow[2] = sqlDataReader3["ManfDesc"].ToString();
				if (sqlDataReader4.HasRows)
				{
					dataRow[3] = sqlDataReader4["UOM"].ToString();
				}
				if (sqlDataReader2["DeptId"].ToString() == "0")
				{
					dataRow[4] = "NA";
					dataRow[5] = sqlDataReader2["WONo"].ToString();
				}
				else
				{
					string cmdText = fun.select("Symbol", "tblHR_Departments", "Id='" + Convert.ToInt32(sqlDataReader2["DeptId"]) + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5.HasRows)
					{
						dataRow[4] = sqlDataReader5["Symbol"].ToString();
						dataRow[5] = "NA";
					}
				}
				dataRow[7] = Convert.ToDouble(decimal.Parse(sqlDataReader2["RetQty"].ToString()).ToString("N3"));
				dataRow[6] = Convert.ToDouble(decimal.Parse(sqlDataReader["AcceptedQty"].ToString()).ToString("N3"));
				dataRow[8] = sqlDataReader2["Remarks"].ToString();
				dataRow[9] = Convert.ToInt32(sqlDataReader2["ItemId"]).ToString();
				string cmdText2 = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as sum_AcceptedQty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + sqlDataReader["MRNId"].ToString() + "' AND tblQc_MaterialReturnQuality_Master.MRNId='" + sqlDataReader["MSId"].ToString() + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				if (sqlDataReader6["sum_AcceptedQty"] != DBNull.Value)
				{
					dataRow[10] = Convert.ToDouble(decimal.Parse(sqlDataReader6["sum_AcceptedQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[10] = "0";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialReturnQualityNote_MRQN_Edit.aspx?ModId=10&SubModId=49");
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			LoadData();
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
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int editIndex = GridView1.EditIndex;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblItemId")).Text);
			_ = ((TextBox)gridViewRow.FindControl("txtRemark")).Text;
			double num4 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblAccptQty1")).Text.ToString()).ToString("N3"));
			double num5 = 0.0;
			double num6 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAccQty")).Text.ToString()).ToString("N3"));
			sqlConnection.Open();
			if (!(num4 >= num6) || !fun.NumberValidationQty(num6.ToString()))
			{
				return;
			}
			double num7 = num4 - num6;
			string cmdText = fun.select("StockQty", "tblDG_Item_Master", "CompId='" + num + "' AND Id='" + num3 + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				double num8 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				if (num8 >= num7)
				{
					string cmdText2 = fun.update("tblQc_MaterialReturnQuality_Details", "AcceptedQty='" + num6 + "'", "Id='" + num2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					string cmdText3 = fun.update("tblQc_MaterialReturnQuality_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + text + "'", "Id='" + MId + "' And CompId='" + num + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					num5 = num8 - num7;
					string cmdText4 = fun.update("tblDG_Item_Master", "StockQty='" + num5 + "'", "CompId='" + num + "' AND Id='" + num3 + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
				}
			}
			sqlConnection.Close();
			GridView1.EditIndex = -1;
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
		}
	}
}
