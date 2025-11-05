using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRNNo = "";

	private string MRQNNo = "";

	private string sId = "";

	private int FyId;

	private int CompId;

	private string MId = "";

	protected GridView GridView1;

	protected Label lblmsg;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MId = base.Request.QueryString["Id"].ToString();
			MRNNo = base.Request.QueryString["MRNNo"].ToString();
			MRQNNo = base.Request.QueryString["MRQNNo"].ToString();
			FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
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
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand(fun.select("tblQc_MaterialReturnQuality_Details.Id,tblQc_MaterialReturnQuality_Details.MRNId,tblQc_MaterialReturnQuality_Details.MRQNNo,tblQc_MaterialReturnQuality_Details.AcceptedQty,tblQc_MaterialReturnQuality_Master.MRNId as MSId", "tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master", "tblQc_MaterialReturnQuality_Master.Id='" + MId + "' AND tblQc_MaterialReturnQuality_Details.MId=tblQc_MaterialReturnQuality_Master.Id  AND tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "'"), sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RetQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("AcceptedQty", typeof(float)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
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
				SqlCommand sqlCommand3 = new SqlCommand(fun.select("Id,ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + Convert.ToInt32(sqlDataReader2["ItemId"]) + "' AND  CompId='" + CompId + "' "), sqlConnection);
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
					string cmdText = fun.select("Symbol", "tblHR_Departments", "Id='" + Convert.ToInt32(sqlDataReader2["DeptId"].ToString()) + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5.HasRows)
					{
						dataRow[4] = sqlDataReader5["Symbol"].ToString();
						dataRow[5] = "NA";
					}
				}
				dataRow[6] = sqlDataReader2["RetQty"].ToString();
				dataRow[7] = sqlDataReader["AcceptedQty"].ToString();
				dataRow[8] = sqlDataReader2["Remarks"].ToString();
				dataRow[9] = sqlDataReader3["Id"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (!(e.CommandName == "Del"))
			{
				return;
			}
			CompId = Convert.ToInt32(Session["compid"]);
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			string text = ((Label)gridViewRow.FindControl("lblItemId")).Text;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			lblmsg.Text = "";
			string cmdText = fun.select("StockQty", "tblDG_Item_Master", "Id='" + text + "' AND CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			num2 = Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
			num3 = Convert.ToDouble(((Label)gridViewRow.FindControl("lblAccptQty")).Text);
			if (num2 >= num3)
			{
				num4 = num2 - num3;
				fun.StkAdjLog(CompId, FyId, sId, 1, MRQNNo, Convert.ToInt32(text), num3);
				string cmdText2 = fun.delete("tblQc_MaterialReturnQuality_Details", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText3 = fun.update("tblDG_Item_Master", "StockQty='" + num4 + "'", "Id='" + text + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				string cmdText4 = fun.select("tblQc_MaterialReturnQuality_Details.Id", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.Id='" + MId + "'  AND tblQc_MaterialReturnQuality_Details.MId= tblQc_MaterialReturnQuality_Master.Id AND tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					string cmdText5 = fun.delete("tblQc_MaterialReturnQuality_Master", "CompId='" + CompId + "'  and Id='" + MId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
					base.Response.Redirect("MaterialReturnQualityNote_MRQN_Delete.aspx?MRQNNo=" + MRQNNo + "&ModId=10&SubModId=49");
				}
				else
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else
			{
				lblmsg.Text = "Stock qty is insufficient to reverse back the GQN transaction!";
			}
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
		base.Response.Redirect("MaterialReturnQualityNote_MRQN_Delete.aspx?ModId=10&SubModId=49");
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
}
