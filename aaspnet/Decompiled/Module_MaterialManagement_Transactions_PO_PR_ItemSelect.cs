using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Transactions_PO_PR_ItemSelect : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string prno = "";

	private string prid = "";

	private string wono = "";

	private string code = "";

	private int itemid;

	private int acid;

	private int FyId;

	protected Label lblSprno;

	protected Label lblprQty;

	protected Label lblwono;

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

	protected DropDownList DrpBudgetCode;

	protected TextBox txtAddDesc;

	protected ScriptManager ScriptManager1;

	protected SqlDataSource SqlDataSource1;

	protected DropDownList DDLPF;

	protected DropDownList DDLExcies;

	protected Label LblItemId;

	protected DropDownList DDLVat;

	protected TextBox txtDelDate;

	protected CalendarExtender txtDelDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Button btnProcide;

	protected Button btnCancel;

	protected TextBox LblDate;

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
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			code = base.Request.QueryString["Code"].ToString();
			prno = base.Request.QueryString["prno"].ToString();
			prid = base.Request.QueryString["prid"].ToString();
			wono = base.Request.QueryString["wono"].ToString();
			lblwono.Text = wono;
			txtDelDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("tblMM_PR_Master.PRNo,tblMM_PR_Master.WONo,tblMM_PR_Details.Id,tblMM_PR_Details.AHId,tblMM_PR_Details.ItemId,tblMM_PR_Details.Qty,tblMM_PR_Details.Rate,tblMM_PR_Details.DelDate", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Details.Id='" + prid + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo  AND tblMM_PR_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				if (sqlDataReader.HasRows)
				{
					string cmdText2 = fun.select("Distinct(tblMIS_BudgetCode.Id),Symbol,( ( tblMIS_BudgetCode.Symbol+''+tblMM_PR_Master.WONo)) As Bcode", "tblMIS_BudgetCode,tblMM_PR_Master", "  tblMM_PR_Master.WONo='" + wono + "'  AND tblMM_PR_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					DrpBudgetCode.DataSource = dataSet;
					DrpBudgetCode.DataTextField = "Bcode";
					DrpBudgetCode.DataValueField = "Id";
					DrpBudgetCode.DataBind();
					itemid = Convert.ToInt32(sqlDataReader["ItemId"].ToString());
					LblItemId.Text = sqlDataReader["ItemId"].ToString();
					acid = Convert.ToInt32(sqlDataReader["AHId"].ToString());
					string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + sqlDataReader["ItemId"].ToString() + "' AND CompId='" + CompId + "'  ");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					if (sqlDataReader2.HasRows)
					{
						lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
						lblItemDesc.Text = sqlDataReader2[1].ToString();
						string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader2[2].ToString() + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
						sqlDataReader3.Read();
						if (sqlDataReader3.HasRows)
						{
							lblUnit.Text = sqlDataReader3[0].ToString();
						}
					}
					double num = 0.0;
					string cmdText5 = fun.select("Sum(Qty) As TempQty", "tblMM_PR_PO_Temp", "PRNo='" + sqlDataReader["PRNo"].ToString() + "' AND PRId='" + sqlDataReader["Id"].ToString() + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
					sqlDataReader4.Read();
					if (sqlDataReader4.HasRows && sqlDataReader4[0] != DBNull.Value)
					{
						num = Convert.ToDouble(sqlDataReader4[0].ToString());
					}
					double num2 = 0.0;
					num2 = Convert.ToDouble(sqlDataReader["Qty"].ToString());
					double num3 = 0.0;
					string cmdText6 = fun.select("Sum(tblMM_PO_Details.Qty)As TotPoQty", "tblMM_PO_Master,tblMM_PO_Details", " tblMM_PO_Details.PRId='" + sqlDataReader["Id"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "'  AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
					sqlDataReader5.Read();
					if (sqlDataReader5.HasRows && sqlDataReader5[0] != DBNull.Value)
					{
						num3 = Convert.ToDouble(sqlDataReader5[0].ToString());
					}
					double num4 = 0.0;
					num4 = Math.Round(num2 - num3, 5);
					txtQty.Text = Math.Round(num4 - num, 5).ToString();
					lblprQty.Text = decimal.Parse(sqlDataReader["Qty"].ToString()).ToString("N3");
					txtRate.Text = Math.Round(Convert.ToDouble(sqlDataReader["Rate"]), 5).ToString();
					string cmdText7 = fun.select("'['+Symbol+']'+Description AS Head", "AccHead", "Id ='" + Convert.ToInt32(sqlDataReader["AHId"].ToString()) + "' ");
					SqlCommand sqlCommand6 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataReader sqlDataReader6 = sqlCommand6.ExecuteReader();
					sqlDataReader6.Read();
					lblAcHead.Text = sqlDataReader6["Head"].ToString();
					lblSprno.Text = sqlDataReader["PRNo"].ToString();
					txtDelDate.Text = fun.FromDateDMY(sqlDataReader["DelDate"].ToString());
				}
			}
			rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemid + "&CompId=" + CompId;
			rt.Target = "_blank";
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
		base.Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
	}

	protected void btnProcide_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			string text = "";
			LblDate.Text = fun.getCurrDate();
			num = Convert.ToDouble(decimal.Parse((Convert.ToDouble(txtRate.Text) - Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtDiscount.Text) / 100.0).ToString()).ToString("N2"));
			string cmdText = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + LblItemId.Text + "' And CompId='" + CompId + "' ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			if (sqlDataReader.HasRows && sqlDataReader["DisRate"] != DBNull.Value)
			{
				num2 = Convert.ToDouble(decimal.Parse(sqlDataReader["DisRate"].ToString()).ToString("N2"));
			}
			if (txtQty.Text != "" && fun.NumberValidation(txtQty.Text) && txtQty.Text != "0")
			{
				if (txtDelDate.Text != "" && fun.DateValidation(txtDelDate.Text) && fun.NumberValidationQty(txtDiscount.Text) && Convert.ToDateTime(fun.FromDate(txtDelDate.Text)) >= Convert.ToDateTime(fun.FromDate(LblDate.Text)) && txtQty.Text != "" && fun.NumberValidation(txtQty.Text))
				{
					text = fun.FromDate(txtDelDate.Text);
					if (num > 0.0)
					{
						if (num2 > 0.0)
						{
							double num3 = 0.0;
							num3 = Convert.ToDouble(decimal.Parse((num2 - num).ToString()).ToString("N2"));
							if (num3 >= 0.0)
							{
								string cmdText2 = fun.insert("tblMM_PR_PO_Temp", "CompId,SessionId,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + prid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + DDLVat.SelectedValue + "','" + text + "','" + Convert.ToInt32(DrpBudgetCode.SelectedValue) + "'");
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
								sqlCommand2.ExecuteNonQuery();
								base.Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
								return;
							}
							string cmdText3 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + LblItemId.Text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='2'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
							SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
							sqlDataReader2.Read();
							if (sqlDataReader2.HasRows)
							{
								string cmdText4 = fun.insert("tblMM_PR_PO_Temp", "CompId,SessionId,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + prid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + DDLVat.SelectedValue + "','" + text + "','" + Convert.ToInt32(DrpBudgetCode.SelectedValue) + "'");
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
								sqlCommand4.ExecuteNonQuery();
								base.Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
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
							string cmdText5 = fun.insert("tblMM_PR_PO_Temp", "CompId,SessionId,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + prid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + DDLVat.SelectedValue + "','" + text + "','" + Convert.ToInt32(DrpBudgetCode.SelectedValue) + "'");
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
							sqlCommand5.ExecuteNonQuery();
							base.Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
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
