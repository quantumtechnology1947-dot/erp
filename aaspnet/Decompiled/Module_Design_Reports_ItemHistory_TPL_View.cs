using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Reports_ItemHistory_TPL_View : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FyId;

	protected Label Label2;

	protected Label LblCode;

	protected Label Label3;

	protected Label lblManfdesc;

	protected Label Label4;

	protected Label lblPDesc;

	protected Label Label5;

	protected Label LblUOMBasic;

	protected Label Label10;

	protected Label LblUOMPurchase;

	protected Button Button1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			int num = 0;
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			if (base.Request.QueryString["Id"].ToString() != "")
			{
				num = Convert.ToInt32(base.Request.QueryString["Id"]);
			}
			string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc ,tblDG_Item_Master.UOMPurchase,tblDG_Item_Master.UOMBasic,tblDG_Item_Master.PurchDesc ,tblDG_TPL_Master.WONo,tblDG_TPL_Master.PId,tblDG_TPL_Master.CId,tblDG_TPL_Master.Qty ", "tblDG_Item_Master,tblDG_TPL_Master", " tblDG_TPL_Master.ItemId=tblDG_Item_Master.Id AND tblDG_TPL_Master.CompId='" + CompId + "' AND tblDG_TPL_Master.FinYearId<='" + FyId + "'AND tblDG_TPL_Master.ItemId='" + num + "'AND tblDG_Item_Master.Id='" + num + "' And tblDG_TPL_Master.PId!='0'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ItemCode"].ToString() != "")
				{
					LblCode.Text = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
				}
				else
				{
					LblCode.Text = "NA";
				}
				if (dataSet.Tables[0].Rows[0]["ManfDesc"].ToString() != "")
				{
					lblManfdesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				}
				else
				{
					lblManfdesc.Text = "NA";
				}
				if (dataSet.Tables[0].Rows[0]["PurchDesc"].ToString() != "")
				{
					lblPDesc.Text = dataSet.Tables[0].Rows[0]["PurchDesc"].ToString();
				}
				else
				{
					lblPDesc.Text = "NA";
				}
				string cmdText2 = fun.select("Unit_Master.Symbol", "Unit_Master", "Unit_Master.Id='" + dataSet.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					LblUOMBasic.Text = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
				}
				else
				{
					LblUOMBasic.Text = "NA";
				}
				string cmdText3 = fun.select("Unit_Master.Symbol", "Unit_Master", "Unit_Master.Id='" + dataSet.Tables[0].Rows[0]["UOMPurchase"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					LblUOMPurchase.Text = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
				else
				{
					LblUOMPurchase.Text = "NA";
				}
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					if (dataSet.Tables[0].Rows[i]["PId"].ToString() != "0")
					{
						fun.ItemHistory_TPL(dataSet.Tables[0].Rows[i]["WONo"].ToString(), dataSet.Tables[0].Rows[i]["PId"].ToString(), dataSet.Tables[0].Rows[i]["CId"].ToString(), CompId, GridView2, Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3")), FyId);
					}
				}
			}
			else
			{
				LblCode.Text = "NA";
				lblManfdesc.Text = "NA";
				lblPDesc.Text = "NA";
				LblUOMBasic.Text = "NA";
				LblUOMPurchase.Text = "NA";
				fun.ItemHistory_TPL("0", "0", "0", CompId, GridView2, 0.0, FyId);
			}
		}
		catch (Exception)
		{
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ItemHistory_TPL.aspx?ModId=3");
	}
}
