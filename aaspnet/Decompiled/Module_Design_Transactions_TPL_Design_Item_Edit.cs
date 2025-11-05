using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_TPL_Design_Item_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string wono = "";

	private int itemId;

	private int Category;

	private string asslyId = "";

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private string uom = "";

	private string ItemCId = string.Empty;

	protected Label lblWONo;

	protected Label lblItemCode;

	protected Label lblMfDesc;

	protected Label lblUOMB;

	protected TextBox txtQuntity;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegQty;

	protected Button btnUpdate;

	protected Button btncancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			asslyId = base.Request.QueryString["Id"];
			wono = base.Request.QueryString["WONo"];
			lblWONo.Text = wono;
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			DataSet dataSet = new DataSet();
			itemId = Convert.ToInt32(base.Request.QueryString["ItemId"]);
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.CId As ItemCId,tblDG_Item_Master.UOMBasic,Unit_Master.Symbol as bUOM,tblDG_Item_Master.UOMBasic,tblDG_TPL_Master.CId,tblDG_TPL_Master.WONo,tblDG_Item_Master.PartNo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,tblDG_TPL_Master.Qty,tblDG_Item_Master.FileName", "Unit_Master,tblDG_Item_Master,tblDG_TPL_Master", "tblDG_Item_Master.Id=tblDG_TPL_Master.ItemId AND tblDG_TPL_Master.WONo='" + wono + "' AND tblDG_TPL_Master.ItemId='" + itemId + "' AND Unit_Master.Id = tblDG_Item_Master.UOMBasic AND tblDG_TPL_Master.CompId='" + CompId + "' AND tblDG_TPL_Master.FinYearId<='" + FinYearId + "'AND tblDG_TPL_Master.Id='" + asslyId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblItemCode.Text = dataSet.Tables[0].Rows[0]["ItemCode"].ToString().Trim();
					lblMfDesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					lblUOMB.Text = dataSet.Tables[0].Rows[0]["bUOM"].ToString();
					txtQuntity.Text = dataSet.Tables[0].Rows[0]["Qty"].ToString();
					uom = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					ItemCId = dataSet.Tables[0].Rows[0]["ItemCId"].ToString();
				}
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

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num = Convert.ToInt32(base.Request.QueryString["CId"]);
			if (txtQuntity.Text != "" && fun.NumberValidationQty(txtQuntity.Text))
			{
				string cmdText = fun.select("*", "tblDG_TPL_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + num + "'");
				DataSet dataSet = new DataSet();
				string connectionString2 = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString2);
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				string text2 = "";
				text2 = ((dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0]["AmdNo"] == DBNull.Value) ? "0" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["AmdNo"].ToString()) + 1).ToString());
				string text3 = string.Empty;
				if (ItemCId != string.Empty)
				{
					text3 = lblMfDesc.Text;
				}
				string cmdText2 = fun.insert("tblDG_TPL_Amd", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,TPLId,PId,CId,ItemId,Description,UOM,AmdNo,Qty", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + wono + "','" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet.Tables[0].Rows[0]["PId"].ToString() + "','" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "', '" + itemId + "' , '" + text3 + "', '" + uom + "','" + dataSet.Tables[0].Rows[0]["AmdNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Qty"].ToString() + "' ");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText3 = fun.update("tblDG_TPL_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sId.ToString() + "',Qty='" + Convert.ToDouble(decimal.Parse(txtQuntity.Text.ToString()).ToString("N3")) + "',AmdNo='" + text2 + "'", "CompId='" + CompId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND Id='" + asslyId + "' AND CId='" + num + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				int num2 = 0;
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText4 = fun.update("tblDG_TPL_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sId.ToString() + "',Qty='" + Convert.ToDouble(decimal.Parse(txtQuntity.Text.ToString()).ToString("N3")) + "',AmdNo='" + text2 + "' ", "CompId='" + CompId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + num + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
					num2++;
				}
				text = "TPL is Updated sucessfully.";
				if (num2 > 0)
				{
					Page.Response.Redirect("TPL_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&msg=" + text + "&ModId=3&SubModId=23");
				}
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

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&ModId=3&SubModId=23");
	}
}
