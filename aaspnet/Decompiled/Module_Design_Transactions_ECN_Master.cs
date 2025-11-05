using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_ECN_Master : Page, IRequiresSessionState
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

	private double Qty;

	private int PId;

	private int AssblyNo;

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
		AssblyNo = Convert.ToInt32(base.Request.QueryString["asslyNo"]);
		childId = Convert.ToInt32(base.Request.QueryString["CId"]);
		PId = Convert.ToInt32(base.Request.QueryString["ParentId"]);
		Qty = Convert.ToDouble(base.Request.QueryString["Qty"]);
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
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					sqlConnection.Open();
					string text2 = ((Label)row.FindControl("lblId")).Text;
					string text3 = ((TextBox)row.FindControl("TxtRemarks")).Text;
					if (num == 1)
					{
						int num3 = 0;
						string cmdText = fun.insert("tblDG_BOMItem_Temp", "CompId,SessionId,WONo,ItemId,Qty,ChildId,ECNFlag", "'" + CompId + "','" + sid + "','" + WONo + "','" + ItemId + "','" + Qty + "','" + childId + "','1'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						string cmdText2 = fun.select("Id", "tblDG_BOMItem_Temp", "CompId='" + CompId + "' Order by Id Desc");
						SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet);
						num3 = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
						string cmdText3 = fun.insert("tblDG_ECN_Master_Temp", "MId,SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId", "'" + num3 + "','" + currDate + "','" + currTime + "','" + CompId + "','" + FinYearId + "','" + sid + "','" + ItemId + "','" + WONo + "','" + PId + "','" + childId + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
						sqlCommand2.ExecuteNonQuery();
						num = 0;
						string cmdText4 = fun.select("Id", "tblDG_ECN_Master_Temp", "CompId='" + CompId + "' Order by Id Desc");
						SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						text = dataSet2.Tables[0].Rows[0]["Id"].ToString();
					}
					string cmdText5 = fun.insert("tblDG_ECN_Details_Temp", "MId,ECNReason,Remarks", "'" + text + "','" + text2 + "','" + text3 + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
					num2++;
				}
			}
			if (num2 > 0)
			{
				base.Response.Redirect("BOM_WoItems.aspx?WONo=" + WONo + "&PId=" + PId + "&CId=" + childId + "&ItemId=" + AssblyNo + "&ModId=3&SubModId=26");
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
		base.Response.Redirect("BOM_WoItems.aspx?WONo=" + WONo + "&PId=" + PId + "&CId=" + childId + "&ItemId=" + AssblyNo + "&ModId=3&SubModId=26");
	}
}
