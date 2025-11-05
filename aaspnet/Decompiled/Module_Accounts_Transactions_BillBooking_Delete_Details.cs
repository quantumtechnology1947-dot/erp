using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Transactions_BillBooking_Delete_Details : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Button Button1;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private int Mid;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			Mid = Convert.ToInt32(base.Request.QueryString["Id"]);
			if (!base.IsPostBack)
			{
				loadData();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("* ", "tblACC_BillBooking_Details", "MId='" + Mid + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GQNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GSNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Descr", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PFAmt", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStBasic", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStEducess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExStShecess", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CustomDuty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VAT", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CST", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Freight", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TarrifNo", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					int num = 0;
					double num2 = 0.0;
					double num3 = 0.0;
					string cmdText2 = fun.select("tblMM_PO_Details.Rate,tblMM_PO_Details.Discount", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.Id='" + dataSet.Tables[0].Rows[i]["PODId"].ToString() + "' AND   tblMM_PO_Master.Id=tblMM_PO_Details.MId  AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						num3 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Rate"]);
						num = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Discount"]);
					}
					if (dataSet.Tables[0].Rows[i]["GQNId"].ToString() != "0")
					{
						string cmdText3 = fun.select("tblQc_MaterialQuality_Master.Id,tblQc_MaterialQuality_Master.GQNNo,tblQc_MaterialQuality_Details.AcceptedQty", "tblQc_MaterialQuality_Master,tblQc_MaterialQuality_Details", "tblQc_MaterialQuality_Master.Id=tblQc_MaterialQuality_Details.MId AND tblQc_MaterialQuality_Details.Id='" + dataSet.Tables[0].Rows[i]["GQNId"].ToString() + "' AND tblQc_MaterialQuality_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							dataRow[1] = dataSet3.Tables[0].Rows[0]["GQNNo"].ToString();
							double num4 = Convert.ToDouble(dataSet3.Tables[0].Rows[0]["AcceptedQty"].ToString());
							num2 = (num3 - num3 * (double)num / 100.0) * num4;
						}
						else
						{
							dataRow[1] = "NA";
						}
					}
					else
					{
						string cmdText4 = fun.select("tblinv_MaterialServiceNote_Master.Id,tblinv_MaterialServiceNote_Master.GSNNo,tblinv_MaterialServiceNote_Details.ReceivedQty", "tblinv_MaterialServiceNote_Master,tblinv_MaterialServiceNote_Details", "tblinv_MaterialServiceNote_Details.Id='" + dataSet.Tables[0].Rows[i]["GSNId"].ToString() + "' AND tblinv_MaterialServiceNote_Master.CompId='" + CompId + "' AND tblinv_MaterialServiceNote_Master.Id=tblinv_MaterialServiceNote_Details.MId");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow[2] = dataSet4.Tables[0].Rows[0]["GSNNo"].ToString();
							double num5 = Convert.ToDouble(dataSet4.Tables[0].Rows[0]["ReceivedQty"].ToString());
							num2 = (num3 - num3 * (double)num / 100.0) * num5;
						}
						else
						{
							dataRow[2] = "NA";
						}
					}
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					string cmdText5 = fun.select("ItemCode,ManfDesc As Descr,UOMBasic ", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet5.Tables[0].Rows[0]["ItemCode"].ToString();
						dataRow[4] = dataSet5.Tables[0].Rows[0]["Descr"].ToString();
						string cmdText6 = fun.select("Symbol As UOM ", "Unit_Master", "Id='" + dataSet5.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							dataRow[5] = dataSet6.Tables[0].Rows[0][0].ToString();
						}
						dataRow[6] = num2;
						dataRow[7] = dataSet.Tables[0].Rows[i]["PFAmt"].ToString();
						dataRow[8] = dataSet.Tables[0].Rows[i]["ExStBasic"].ToString();
						dataRow[9] = dataSet.Tables[0].Rows[i]["ExStEducess"].ToString();
						dataRow[10] = dataSet.Tables[0].Rows[i]["ExStShecess"].ToString();
						dataRow[11] = dataSet.Tables[0].Rows[i]["CustomDuty"].ToString();
						dataRow[12] = dataSet.Tables[0].Rows[i]["VAT"].ToString();
						dataRow[13] = dataSet.Tables[0].Rows[i]["CST"].ToString();
						dataRow[14] = dataSet.Tables[0].Rows[i]["Freight"].ToString();
						dataRow[15] = dataSet.Tables[0].Rows[i]["TarrifNo"].ToString();
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				string connectionString = fun.Connection();
				new DataSet();
				SqlConnection sqlConnection = new SqlConnection(connectionString);
				sqlConnection.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string cmdText = fun.delete("tblACC_BillBooking_Details", "Id='" + text + "' AND MId='" + Mid + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("MId ", "tblACC_BillBooking_Details", "MId='" + Mid + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblACC_BillBooking_Master", "Id='" + Mid + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("BillBooking_Delete.aspx?ModId=11&SubModId=62");
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BillBooking_Delete.aspx?ModId=11&SubModId=62");
	}
}
