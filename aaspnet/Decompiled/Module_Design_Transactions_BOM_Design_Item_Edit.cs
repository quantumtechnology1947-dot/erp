using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_BOM_Design_Item_Edit : Page, IRequiresSessionState
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

	protected TextBox txtRevision;

	protected RequiredFieldValidator ReqtxtRevision;

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
				string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.CId As ItemCId,tblDG_Item_Master.UOMBasic,Unit_Master.Symbol as bUOM,tblDG_Item_Master.UOMBasic,tblDG_BOM_Master.CId,tblDG_BOM_Master.WONo,tblDG_Item_Master.PartNo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,tblDG_BOM_Master.Qty,tblDG_Item_Master.FileName,tblDG_BOM_Master.Revision", "Unit_Master,tblDG_Item_Master,tblDG_BOM_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND tblDG_BOM_Master.WONo='" + wono + "' AND tblDG_BOM_Master.ItemId='" + itemId + "' AND Unit_Master.Id = tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.CompId='" + CompId + "' AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "'AND tblDG_BOM_Master.Id='" + asslyId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"].ToString()));
					lblMfDesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					lblUOMB.Text = dataSet.Tables[0].Rows[0]["bUOM"].ToString();
					txtQuntity.Text = dataSet.Tables[0].Rows[0]["Qty"].ToString();
					uom = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					ItemCId = dataSet.Tables[0].Rows[0]["ItemCId"].ToString();
					txtRevision.Text = dataSet.Tables[0].Rows[0]["Revision"].ToString();
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
			int num2 = 0;
			string cmdText = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string value = dataSet.Tables[0].Rows[0][0].ToString();
			if (Convert.ToDateTime(value) >= Convert.ToDateTime(currDate))
			{
				if (txtQuntity.Text != "" && fun.NumberValidationQty(txtQuntity.Text))
				{
					string cmdText2 = fun.select("*", "tblDG_BOM_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + num + "'");
					DataSet dataSet2 = new DataSet();
					string connectionString2 = fun.Connection();
					SqlConnection connection = new SqlConnection(connectionString2);
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					sqlDataAdapter2.Fill(dataSet2);
					string text2 = "";
					text2 = ((dataSet2.Tables[0].Rows.Count <= 0 || dataSet2.Tables[0].Rows[0]["AmdNo"] == DBNull.Value) ? "0" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0]["AmdNo"].ToString()) + 1).ToString());
					string text3 = string.Empty;
					if (ItemCId != string.Empty)
					{
						text3 = lblMfDesc.Text;
					}
					string cmdText3 = fun.insert("tblDG_BOM_Amd", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,BOMId,PId,CId,ItemId,Description,UOM,AmdNo,Qty", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + wono + "','" + dataSet2.Tables[0].Rows[0]["Id"].ToString() + "','" + dataSet2.Tables[0].Rows[0]["PId"].ToString() + "','" + dataSet2.Tables[0].Rows[0]["CId"].ToString() + "', '" + itemId + "' , '" + text3 + "', '" + uom + "','" + dataSet2.Tables[0].Rows[0]["AmdNo"].ToString() + "','" + dataSet2.Tables[0].Rows[0]["Qty"].ToString() + "' ");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					string cmdText4 = fun.update("tblDG_BOM_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sId.ToString() + "',Qty='" + Convert.ToDouble(decimal.Parse(txtQuntity.Text.ToString()).ToString("N3")) + "',AmdNo='" + text2 + "',Revision='" + txtRevision.Text + "'", "CompId='" + CompId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND Id='" + asslyId + "' AND CId='" + num + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					int num3 = 0;
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						string cmdText5 = fun.update("tblDG_BOM_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sId.ToString() + "',Qty='" + Convert.ToDouble(decimal.Parse(txtQuntity.Text.ToString()).ToString("N3")) + "',AmdNo='" + text2 + "'", "CompId='" + CompId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + num + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
						string cmdText6 = fun.update("tblDG_BOM_Master", "Revision='" + txtRevision.Text + "' ", "CompId='" + CompId + "'AND ItemId='" + itemId + "' AND WONo='" + wono + "'");
						SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
						sqlCommand4.ExecuteNonQuery();
						num3++;
					}
					text = "BOM is Updated sucessfully.";
					if (num3 > 0)
					{
						Page.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&msg=" + text + "&ModId=3&SubModId=26");
					}
				}
			}
			else if (txtQuntity.Text != "" && fun.NumberValidationQty(txtQuntity.Text))
			{
				string cmdText7 = fun.select("PId", "tblDG_BOM_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + num + "'");
				DataSet dataSet3 = new DataSet();
				string connectionString3 = fun.Connection();
				SqlConnection connection2 = new SqlConnection(connectionString3);
				SqlCommand selectCommand3 = new SqlCommand(cmdText7, connection2);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet3);
				num2 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["PId"].ToString());
				base.Response.Redirect("ECN_Master_Edit.aspx?ItemId=" + itemId + "&WONo=" + wono + "&CId=" + num + "&ParentId=" + num2 + "&Qty=" + txtQuntity.Text + "&Id=" + asslyId + "&Revision=" + txtRevision.Text);
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
		base.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
	}
}
