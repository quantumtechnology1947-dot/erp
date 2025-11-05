using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Transactions_PO_SPR_ItemSelect : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sprno = string.Empty;

	private string sprid = string.Empty;

	private string code = string.Empty;

	private string SheduleDate = string.Empty;

	private string sId = string.Empty;

	private int CompId;

	private int itemid;

	private int acid;

	private int BGWO;

	private int FyId;

	protected Label lblSprno;

	protected Label lblQty;

	protected Label lblwono;

	protected Label lblDept;

	protected Label lblItemCode;

	protected TextBox lblItemDesc;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource3;

	protected Label lblAcHead;

	protected TextBox txtQty;

	protected RequiredFieldValidator ReqtxtQty;

	protected RegularExpressionValidator RegtxtQty;

	protected Label lblUnit;

	protected TextBox txtRate;

	protected HtmlAnchor rt;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularReqQty;

	protected TextBox txtDiscount;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected RegularExpressionValidator RegularReqQty0;

	protected Label LblBudgetCode;

	protected DropDownList DrpBudgetCode;

	protected TextBox txtAddDesc;

	protected SqlDataSource SqlDataSource1;

	protected ScriptManager ScriptManager1;

	protected DropDownList DDLPF;

	protected DropDownList DDLExcies;

	protected DropDownList DDLVat;

	protected TextBox txtDelDate;

	protected CalendarExtender txtDelDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox LblDate;

	protected Button btnProcide;

	protected Button btnCancel;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			code = base.Request.QueryString["Code"].ToString();
			sprno = base.Request.QueryString["sprno"].ToString();
			sprid = base.Request.QueryString["sprid"].ToString();
			FyId = Convert.ToInt32(Session["finyear"]);
			txtDelDate.Attributes.Add("readonly", "readonly");
			string cmdText = fun.select("tblMIS_BudgetCode.Id,( tblMIS_BudgetCode.Symbol+''+tblMM_SPR_Details.WONo) As Bcode,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId", "tblMIS_BudgetCode,tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Details.Id='" + sprid + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader["WONo"].ToString() != "")
			{
				BGWO = 1;
			}
			else
			{
				DrpBudgetCode.Visible = false;
			}
			if (!base.IsPostBack)
			{
				string cmdText2 = fun.select("tblMM_SPR_Details.Discount,tblMM_SPR_Master.SPRNo,tblMM_SPR_Details.Id,tblMM_SPR_Details.ItemId,tblMM_SPR_Details.DelDate,tblMM_SPR_Details.AHId,tblMM_SPR_Details.ItemId,tblMM_SPR_Details.Qty,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.Rate", "tblMM_SPR_Master,tblMM_SPR_Details", "tblMM_SPR_Details.Id='" + sprid + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
				sqlDataReader2.Read();
				if (sqlDataReader2["WONo"].ToString() != "")
				{
					lblwono.Text = sqlDataReader2["WONo"].ToString();
					string cmdText3 = fun.select("Distinct(tblMIS_BudgetCode.Id),( tblMIS_BudgetCode.Symbol+''+tblMM_SPR_Details.WONo) As Bcode", "tblMIS_BudgetCode,tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Details.Id='" + sprid + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					DrpBudgetCode.DataSource = dataSet;
					DrpBudgetCode.DataTextField = "Bcode";
					DrpBudgetCode.DataValueField = "Id";
					DrpBudgetCode.DataBind();
				}
				else
				{
					DrpBudgetCode.Visible = false;
					lblwono.Text = "NA";
				}
				txtDelDate.Text = fun.FromDateDMY(sqlDataReader2["DelDate"].ToString());
				int num = Convert.ToInt32(sqlDataReader2["DeptId"].ToString());
				string text = "";
				if (num > 0)
				{
					string cmdText4 = fun.select("'['+Symbol+'] '+Name AS Dept,Symbol", "BusinessGroup", "Id ='" + Convert.ToInt32(sqlDataReader2["DeptId"].ToString()) + "' ");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					sqlDataReader3.Read();
					text = sqlDataReader3["Dept"].ToString();
					BGWO = 2;
					LblBudgetCode.Text = sqlDataReader3["Symbol"].ToString();
				}
				else
				{
					text = "NA";
				}
				lblDept.Text = text;
				itemid = Convert.ToInt32(sqlDataReader2["ItemId"].ToString());
				acid = Convert.ToInt32(sqlDataReader2["AHId"].ToString());
				lblSprno.Text = sqlDataReader2["ItemId"].ToString();
				string cmdText5 = fun.select("ItemCode,ManfDesc,UOMBasic,CId,AHId", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + sqlDataReader2["ItemId"].ToString() + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
				sqlDataReader4.Read();
				if (sqlDataReader4.HasRows)
				{
					lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader2["ItemId"].ToString()));
					lblItemDesc.Text = sqlDataReader4[1].ToString();
					string cmdText6 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader4[2].ToString() + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					lblUnit.Text = sqlDataReader5[0].ToString();
				}
				double num2 = 0.0;
				string cmdText7 = fun.select("Sum(Qty) As TempQty", "tblMM_SPR_PO_Temp", "SPRNo='" + sqlDataReader2["SPRNo"].ToString() + "' AND SPRId='" + sqlDataReader2["Id"].ToString() + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
				sqlDataReader6.Read();
				if (sqlDataReader6.HasRows && sqlDataReader6[0] != DBNull.Value)
				{
					num2 = Convert.ToDouble(sqlDataReader6[0].ToString());
				}
				double num3 = 0.0;
				num3 = Convert.ToDouble(sqlDataReader2["Qty"].ToString());
				double num4 = 0.0;
				string cmdText8 = fun.select("Sum(tblMM_PO_Details.Qty)As TotPoQty", "tblMM_PO_Master,tblMM_PO_Details", " tblMM_PO_Details.SPRId='" + sqlDataReader2["Id"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Master.Id=tblMM_PO_Details.MId ");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataReader sqlDataReader7 = sqlCommand7.ExecuteReader();
				sqlDataReader7.Read();
				if (sqlDataReader7.HasRows && sqlDataReader7[0] != DBNull.Value)
				{
					num4 = Convert.ToDouble(sqlDataReader7[0]);
				}
				double num5 = 0.0;
				num5 = Math.Round(num3 - num4, 5);
				txtQty.Text = Math.Round(num5 - num2, 5).ToString();
				lblQty.Text = decimal.Parse(sqlDataReader2["Qty"].ToString()).ToString("N3");
				txtRate.Text = Math.Round(Convert.ToDouble(sqlDataReader2["Rate"]), 5).ToString();
				txtDiscount.Text = decimal.Parse(sqlDataReader2["Discount"].ToString()).ToString("N2");
				string cmdText9 = fun.select("'['+AccHead.Symbol+']'+Description AS Head", "AccHead", "Id ='" + Convert.ToInt32(sqlDataReader2["AHId"].ToString()) + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText9, sqlConnection);
				SqlDataReader sqlDataReader8 = sqlCommand8.ExecuteReader();
				sqlDataReader8.Read();
				lblAcHead.Text = sqlDataReader8["Head"].ToString();
				lblSprno.Text = sqlDataReader2["SPRNo"].ToString();
				rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemid + "&CompId=" + CompId;
				rt.Target = "_blank";
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

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
	}

	protected void btnProcide_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			SheduleDate = fun.FromDate(txtDelDate.Text);
			double num = 0.0;
			int num2 = 0;
			LblDate.Text = fun.getCurrDate();
			if (BGWO == 1)
			{
				num2 = Convert.ToInt32(DrpBudgetCode.SelectedValue);
			}
			num = Convert.ToDouble(decimal.Parse((Convert.ToDouble(txtRate.Text) - Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtDiscount.Text) / 100.0).ToString()).ToString("N2"));
			string cmdText = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemid + "' And CompId='" + CompId + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			double num3 = 0.0;
			if (sqlDataReader.HasRows && sqlDataReader["DisRate"] != DBNull.Value)
			{
				num3 = Convert.ToDouble(decimal.Parse(sqlDataReader["DisRate"].ToString()).ToString("N2"));
			}
			if (txtQty.Text != "" && fun.NumberValidation(txtQty.Text))
			{
				if (txtDelDate.Text != "" && fun.DateValidation(txtDelDate.Text) && Convert.ToDateTime(fun.FromDate(txtDelDate.Text)) >= Convert.ToDateTime(fun.FromDate(LblDate.Text)))
				{
					if (num > 0.0)
					{
						if (num3 > 0.0)
						{
							double num4 = 0.0;
							num4 = Convert.ToDouble(decimal.Parse((num3 - num).ToString()).ToString("N2"));
							if (num4 >= 0.0)
							{
								string cmdText2 = fun.insert("tblMM_SPR_PO_Temp", "CompId,SessionId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + sprid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(txtRate.Text) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + SheduleDate + "','" + num2 + "'");
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
								sqlCommand2.ExecuteNonQuery();
								base.Response.Redirect("PO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
								return;
							}
							string cmdText3 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemid + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='2'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
							SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
							sqlDataReader2.Read();
							if (sqlDataReader2.HasRows)
							{
								string cmdText4 = fun.insert("tblMM_SPR_PO_Temp", "CompId,SessionId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + sprid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(txtRate.Text) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + SheduleDate + "','" + num2 + "'");
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
								sqlCommand4.ExecuteNonQuery();
								base.Response.Redirect("PO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
							}
							else
							{
								string empty = string.Empty;
								empty = "Entered rate is not acceptable!";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
						else
						{
							string cmdText5 = fun.insert("tblMM_SPR_PO_Temp", "CompId,SessionId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + sprid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(txtRate.Text) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + SheduleDate + "','" + num2 + "'");
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
							sqlCommand5.ExecuteNonQuery();
							base.Response.Redirect("PO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Entered rate is not acceptable!";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Entered Date is not acceptable!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "Entered Qty is not acceptable!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
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
}
