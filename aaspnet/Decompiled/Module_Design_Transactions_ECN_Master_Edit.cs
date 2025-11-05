using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_ECN_Master_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sid = "";

	private string connStr = "";

	private string WONo = "";

	private int ItemId;

	private int childId;

	private string Qty = "";

	private int PId;

	private int AssId;

	private string Revision = "";

	protected GridView GridView1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		FinYearId = Convert.ToInt32(Session["finyear"]);
		CompId = Convert.ToInt32(Session["compid"]);
		sid = Session["username"].ToString();
		WONo = base.Request.QueryString["WONo"].ToString();
		ItemId = Convert.ToInt32(base.Request.QueryString["ItemId"]);
		childId = Convert.ToInt32(base.Request.QueryString["CId"]);
		Qty = base.Request.QueryString["Qty"].ToString();
		Revision = base.Request.QueryString["Revision"].ToString();
		PId = Convert.ToInt32(base.Request.QueryString["ParentId"]);
		AssId = Convert.ToInt32(base.Request.QueryString["Id"]);
		if (!Page.IsPostBack)
		{
			loaddata();
		}
	}

	public void loaddata()
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		string cmdText = fun.select("*", "tblDG_ECN_Reason", "CompId='" + CompId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		GridView1.DataSource = dataSet;
		GridView1.DataBind();
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			int num = 1;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = "";
			int num2 = 0;
			if (!(e.CommandName == "Ins"))
			{
				return;
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				sqlConnection.Open();
				string text2 = ((Label)row.FindControl("lblId")).Text;
				string text3 = ((TextBox)row.FindControl("TxtRemarks")).Text;
				if (num == 1)
				{
					string cmdText = fun.select("*", "tblDG_BOM_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' AND CId='" + childId + "'");
					DataSet dataSet = new DataSet();
					string connectionString2 = fun.Connection();
					SqlConnection connection = new SqlConnection(connectionString2);
					SqlCommand selectCommand = new SqlCommand(cmdText, connection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet);
					string text4 = "";
					text4 = ((dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0]["AmdNo"] == DBNull.Value) ? "0" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["AmdNo"].ToString()) + 1).ToString());
					string cmdText2 = fun.insert("tblDG_BOM_Amd", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,BOMId,PId,CId,ItemId,AmdNo,Qty", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sid + "','" + CompId + "','" + FinYearId + "','" + WONo + "','" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PId"].ToString() + "','" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "', '" + ItemId + "' ,'" + dataSet.Tables[0].Rows[0]["AmdNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Qty"].ToString() + "' ");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					string cmdText3 = fun.update("tblDG_BOM_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sid + "',Qty='" + Qty + "',AmdNo='" + text4 + "',Revision='" + Revision + "' ,ECNFlag=1", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' AND Id='" + AssId + "' AND CId='" + childId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					int num3 = 0;
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						string cmdText4 = fun.update("tblDG_BOM_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sid + "',Qty='" + Qty + "',AmdNo='" + text4 + "' ", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' AND CId='" + childId + "'  And ECNFlag=1");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
						string cmdText5 = fun.update("tblDG_BOM_Master", "Revision='" + Revision + "'", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' And ECNFlag=1");
						SqlCommand sqlCommand4 = new SqlCommand(cmdText5, sqlConnection);
						sqlCommand4.ExecuteNonQuery();
						num3++;
					}
					string cmdText6 = fun.insert("tblDG_ECN_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + sid + "','" + ItemId + "','" + WONo + "','" + PId + "','" + childId + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText6, sqlConnection);
					sqlCommand5.ExecuteNonQuery();
					num = 0;
					string cmdText7 = fun.select("Id", "tblDG_ECN_Master", "CompId='" + CompId + "' Order by Id Desc");
					SqlCommand selectCommand2 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblDG_ECN_Master");
					text = dataSet2.Tables[0].Rows[0]["Id"].ToString();
				}
				string cmdText8 = fun.insert("tblDG_ECN_Details", "MId,ECNReason,Remarks", "'" + text + "','" + text2 + "','" + text3 + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText8, sqlConnection);
				sqlCommand6.ExecuteNonQuery();
				sqlConnection.Close();
				num2++;
			}
			if (num2 > 0)
			{
				base.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + WONo + "&ModId=3&SubModId=26");
			}
			else
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_Item_Edit.aspx?ItemId=" + ItemId + "&WONo=" + WONo + "&PId=" + PId + "&CId=" + childId + "&Id=" + AssId + "&PgUrl=BOM_Design_WO_TreeView_Edit.aspx&ModId=3&SubModId=26");
	}
}
