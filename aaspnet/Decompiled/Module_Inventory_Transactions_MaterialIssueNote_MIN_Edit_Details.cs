using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_MaterialIssueNote_MIN_Edit_Details : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Button BtnCancel;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MINNo = "";

	private string MRSNo = "";

	private int FyId;

	private int CompId;

	private string sId = "";

	private string MId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MINNo = base.Request.QueryString["MINNo"].ToString();
			MRSNo = base.Request.QueryString["MRSNo"].ToString();
			FyId = Convert.ToInt32(base.Request.QueryString["FYId"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
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
			SqlCommand selectCommand = new SqlCommand(fun.select("tblInv_MaterialIssue_Details.Id,tblInv_MaterialIssue_Details.MRSId,tblInv_MaterialIssue_Master.MRSId as MMId,tblInv_MaterialIssue_Details.IssueQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master", "tblInv_MaterialIssue_Master.Id='" + MId + "' AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Master.CompId='" + CompId + "'"), sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("IssueQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(DS.Tables[0].Rows[i]["Id"]);
				SqlCommand selectCommand2 = new SqlCommand(fun.select("tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", string.Concat("tblInv_MaterialRequisition_Details.Id='", Convert.ToInt32(DS.Tables[0].Rows[i]["MRSId"]), "' AND tblInv_MaterialRequisition_Master.CompId='", CompId, "' AND tblInv_MaterialRequisition_Master.Id='", DS.Tables[0].Rows[i]["MMId"], "' AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId")), sqlConnection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					SqlCommand selectCommand3 = new SqlCommand(fun.select("ItemCode,PurchDesc,UOMPurchase", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]) + "' AND  CompId='" + CompId + "'"), sqlConnection);
					DataSet dataSet2 = new DataSet();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						SqlCommand selectCommand4 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMPurchase"]) + "'"), sqlConnection);
						DataSet dataSet3 = new DataSet();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						sqlDataAdapter4.Fill(dataSet3);
						dataRow[1] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"].ToString()));
						dataRow[2] = dataSet2.Tables[0].Rows[0]["PurchDesc"].ToString();
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[3] = dataSet3.Tables[0].Rows[0]["UOM"].ToString();
						}
						if (dataSet.Tables[0].Rows[0]["DeptId"].ToString() == "1")
						{
							dataRow[4] = "NA";
							dataRow[5] = dataSet.Tables[0].Rows[0]["WONo"].ToString();
						}
						else
						{
							string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["DeptId"]) + "'");
							SqlCommand selectCommand5 = new SqlCommand(cmdText, sqlConnection);
							DataSet dataSet4 = new DataSet();
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							sqlDataAdapter5.Fill(dataSet4);
							dataRow[4] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
							dataRow[5] = "NA";
						}
						dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["ReqQty"].ToString()).ToString("N3"));
						dataRow[7] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["IssueQty"].ToString()).ToString("N3"));
						dataRow[8] = dataSet.Tables[0].Rows[0]["Remarks"].ToString();
						dataRow[9] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["ItemId"]);
					}
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
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialIssueNote_MIN_Edit.aspx?ModId=9&SubModId=41");
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
			double num = 0.0;
			double num2 = 0.0;
			int editIndex = GridView1.EditIndex;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num3 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			int num4 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblItemId")).Text);
			double num5 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblIssueQty1")).Text.ToString()).ToString("N3"));
			double num6 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAccQty")).Text.ToString()).ToString("N3"));
			sqlConnection.Open();
			if (num5 >= num6 && fun.NumberValidationQty(num6.ToString()))
			{
				string cmdText = fun.select("StockQty", "tblDG_Item_Master", "Id='" + num4 + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
				}
				num2 = num5 - num6 + num;
				string cmdText2 = fun.update("tblDG_Item_Master", "StockQty='" + num2 + "'", "CompId='" + CompId + "' AND Id='" + num4 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText3 = fun.update("tblInv_MaterialIssue_Details", "IssueQty='" + num6 + "'", "Id='" + num3 + "' And MId='" + MId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				string cmdText4 = fun.update("tblInv_MaterialIssue_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + sId + "'", "Id='" + MId + "' And CompId='" + CompId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				sqlConnection.Close();
				GridView1.EditIndex = -1;
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
		}
		catch (Exception)
		{
		}
	}
}
