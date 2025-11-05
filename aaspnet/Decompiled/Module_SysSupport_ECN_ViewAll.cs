using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysSupport_ECN_ViewAll : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string connStr = "";

	private string WONo = "";

	protected Label lblWono;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			WONo = base.Request.QueryString["WONo"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblWono.Text = WONo;
			if (!base.IsPostBack)
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		try
		{
			string cmdText = "SELECT Distinct(tblDG_ECN_Master.ItemId),Unit_Master.Symbol,tblDG_Item_Master.ItemCode, tblDG_Item_Master.ManfDesc, tblDG_ECN_Master.WONo FROM tblDG_ECN_Master INNER JOIN tblDG_Item_Master ON tblDG_ECN_Master.ItemId = tblDG_Item_Master.Id INNER JOIN Unit_Master ON tblDG_Item_Master.UOMBasic = Unit_Master.Id And tblDG_ECN_Master.WONo='" + WONo + "' And Flag=0 order by tblDG_ECN_Master.ItemId Desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string text = string.Empty;
				string text2 = string.Empty;
				double num = 0.0;
				num = fun.AllComponentBOMQty(CompId, WONo, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), FinYearId);
				dataRow[6] = num;
				string cmdText2 = "SELECT Id  FROM tblDG_ECN_Master Where WONo='" + WONo + "' And ItemId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					string cmdText3 = "SELECT  Remarks,Types FROM tblDG_ECN_Master INNER JOIN tblDG_ECN_Details ON tblDG_ECN_Master.Id = tblDG_ECN_Details.MId INNER JOIN tblDG_ECN_Reason ON tblDG_ECN_Reason.Id = tblDG_ECN_Details.ECNReason And tblDG_ECN_Details.MId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[j]["Id"]) + "'";
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					for (int k = 0; k < dataSet3.Tables[0].Rows.Count; k++)
					{
						string text3 = string.Empty;
						if (text != "")
						{
							text3 = ", ";
						}
						string text4 = string.Empty;
						if (text2 != "")
						{
							text4 = ", ";
						}
						text = text + text3 + dataSet3.Tables[0].Rows[k]["Types"].ToString();
						text2 = text2 + text4 + dataSet3.Tables[0].Rows[k]["Remarks"].ToString();
					}
				}
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]);
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[4] = text;
				dataRow[5] = text2;
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
		base.Response.Redirect("~/Module/SysSupport/ECN_WO_ViewAll.aspx");
	}
}
