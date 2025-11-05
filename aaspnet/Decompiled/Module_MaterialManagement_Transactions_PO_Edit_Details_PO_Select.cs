using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Transactions_PO_Edit_Details_PO_Select : Page, IRequiresSessionState
{
	protected Label lblprno;

	protected Label lblSprno;

	protected Label lblwono;

	protected Label lblDept;

	protected Label lblItemCode;

	protected TextBox lblItemDesc;

	protected Label lblAHId;

	protected Label lblQty;

	protected TextBox txtQty;

	protected RequiredFieldValidator ReqtxtQty;

	protected RegularExpressionValidator RegtxtQty;

	protected Label lblUnit;

	protected TextBox txtRate;

	protected HtmlAnchor rt;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected RegularExpressionValidator RegularReqQty0;

	protected TextBox txtDiscount;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected RegularExpressionValidator RegularReqQty;

	protected Label LblBudgetCode;

	protected DropDownList DrpBudgetCode;

	protected TextBox txtAddDesc;

	protected ScriptManager ScriptManager1;

	protected DropDownList DDLPF;

	protected DropDownList DDLExcies;

	protected DropDownList DDLVat;

	protected TextBox txtDelDate;

	protected CalendarExtender TxtFromDate_CalendarExtender;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Button btnProcide;

	protected Button btnCancel;

	protected Label lblPODId;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string pono = "";

	private string poid = "";

	private string code = "";

	private string MId = "";

	private int itemId;

	private int AcHead;

	private int BGWO;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			txtDelDate.Attributes.Add("readonly", "readonly");
			code = base.Request.QueryString["Code"].ToString();
			pono = base.Request.QueryString["pono"].ToString();
			poid = base.Request.QueryString["poid"].ToString();
			MId = base.Request.QueryString["mid"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			LoadData();
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
			string cmdText = fun.select("tblMM_PO_Details.Id,tblMM_PO_Details.PONo,tblMM_PO_Details.PRNo,tblMM_PO_Details.PRId,tblMM_PO_Details.SPRNo,tblMM_PO_Details.SPRId,tblMM_PO_Details.Qty,tblMM_PO_Details.Rate,tblMM_PO_Details.Discount,tblMM_PO_Details.PF,tblMM_PO_Details.ExST,tblMM_PO_Details.VAT,tblMM_PO_Master.PRSPRFlag,tblMM_PO_Details.AddDesc,tblMM_PO_Details.DelDate,tblMM_PO_Details.BudgetCode", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Master.PONo='" + pono + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.Id=tblMM_PO_Details.MId AND tblMM_PO_Details.MId='" + MId + "'  AND tblMM_PO_Master.CompId='" + CompId + "' AND  tblMM_PO_Details.Id='" + poid + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string text = "";
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			lblPODId.Text = dataSet.Tables[0].Rows[0]["Id"].ToString();
			if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
			{
				string cmdText2 = fun.select("tblMM_PR_Details.ItemId,tblMM_PR_Master.WONo,tblMM_PR_Details.AHId,tblMM_PR_Details.PRNo", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo='" + dataSet.Tables[0].Rows[0]["PRNo"].ToString() + "' AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Details.Id='" + dataSet.Tables[0].Rows[0]["PRId"].ToString() + "'    AND tblMM_PR_Master.CompId='" + CompId + "'  ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				itemId = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
				string cmdText3 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet2.Tables[0].Rows[0]["ItemId"].ToString() + "'  AND  CompId='" + CompId + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					text3 = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"].ToString()));
					text4 = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText4 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					text5 = dataSet4.Tables[0].Rows[0][0].ToString();
				}
				text6 = dataSet2.Tables[0].Rows[0]["WONo"].ToString();
				string cmdText5 = fun.select("Distinct(tblMIS_BudgetCode.Id),( tblMIS_BudgetCode.Symbol+''+tblMM_PR_Master.WONo) As Bcode", "tblMIS_BudgetCode,tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.WONo='" + dataSet2.Tables[0].Rows[0]["WONo"].ToString() + "'   AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				BGWO = 1;
				if (!base.IsPostBack)
				{
					DrpBudgetCode.DataSource = dataSet5;
					DrpBudgetCode.DataTextField = "Bcode";
					DrpBudgetCode.DataValueField = "Id";
					DrpBudgetCode.DataBind();
				}
				text7 = "NA";
				AcHead = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["AHId"]);
				text = dataSet2.Tables[0].Rows[0]["PRNo"].ToString();
				text2 = "NA";
			}
			else if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "1")
			{
				string cmdText6 = fun.select("tblMM_SPR_Details.ItemId,tblMM_SPR_Details.WONo,tblMM_SPR_Details.DeptId,tblMM_SPR_Details.AHId,tblMM_SPR_Details.SPRNo", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet.Tables[0].Rows[0]["SPRNo"].ToString() + "'  AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Details.Id='" + dataSet.Tables[0].Rows[0]["SPRId"].ToString() + "' AND  tblMM_SPR_Master.CompId='" + CompId + "'  ");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				itemId = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"]);
				string cmdText7 = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + dataSet6.Tables[0].Rows[0]["ItemId"].ToString() + "' AND CompId='" + CompId + "'  ");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				if (dataSet7.Tables[0].Rows.Count > 0)
				{
					text3 = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet6.Tables[0].Rows[0]["ItemId"].ToString()));
					text4 = dataSet7.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText8 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet7.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter8.Fill(dataSet8);
					text5 = dataSet8.Tables[0].Rows[0][0].ToString();
				}
				if (dataSet6.Tables[0].Rows[0]["DeptId"].ToString() == "0")
				{
					text6 = dataSet6.Tables[0].Rows[0]["WONo"].ToString();
					string cmdText9 = fun.select("Distinct(tblMIS_BudgetCode.Id),( tblMIS_BudgetCode.Symbol+''+tblMM_SPR_Details.WONo) As Bcode", "tblMIS_BudgetCode,tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Master.SPRNo='" + dataSet.Tables[0].Rows[0]["SPRNo"].ToString() + "'   And tblMM_SPR_Details.Id='" + dataSet.Tables[0].Rows[0]["SPRId"].ToString() + "' AND tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId AND tblMM_SPR_Master.CompId='" + CompId + "'");
					SqlCommand selectCommand9 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter9.Fill(dataSet9);
					BGWO = 1;
					if (!base.IsPostBack)
					{
						DrpBudgetCode.DataSource = dataSet9;
						DrpBudgetCode.DataTextField = "Bcode";
						DrpBudgetCode.DataValueField = "Id";
						DrpBudgetCode.DataBind();
					}
					text7 = "NA";
				}
				else
				{
					string cmdText10 = fun.select("'['+Symbol+'] '+Name AS Dept,Symbol", "BusinessGroup", "Id ='" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["DeptId"].ToString()) + "' ");
					SqlCommand selectCommand10 = new SqlCommand(cmdText10, sqlConnection);
					SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter10.Fill(dataSet10);
					text7 = dataSet10.Tables[0].Rows[0]["Dept"].ToString();
					LblBudgetCode.Text = dataSet10.Tables[0].Rows[0]["Symbol"].ToString();
					DrpBudgetCode.Visible = false;
					text6 = "NA";
				}
				AcHead = Convert.ToInt32(dataSet6.Tables[0].Rows[0]["AHId"]);
				text2 = dataSet6.Tables[0].Rows[0]["SPRNo"].ToString();
				text = "NA";
			}
			lblprno.Text = text;
			lblSprno.Text = text2;
			lblwono.Text = text6;
			lblDept.Text = text7;
			lblItemCode.Text = text3;
			lblItemDesc.Text = text4;
			lblUnit.Text = text5;
			string cmdText11 = fun.select("'['+Symbol+'] '+Description AS Head", "AccHead", "Id ='" + AcHead + "' ");
			SqlCommand selectCommand11 = new SqlCommand(cmdText11, sqlConnection);
			SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
			DataSet dataSet11 = new DataSet();
			sqlDataAdapter11.Fill(dataSet11);
			if (dataSet11.Tables[0].Rows.Count > 0)
			{
				lblAHId.Text = dataSet11.Tables[0].Rows[0]["Head"].ToString();
			}
			if (!base.IsPostBack)
			{
				txtQty.Text = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0]["Qty"]), 5).ToString();
				txtRate.Text = Math.Round(Convert.ToDouble(dataSet.Tables[0].Rows[0]["Rate"]), 5).ToString();
				txtDiscount.Text = decimal.Parse(dataSet.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2");
				txtAddDesc.Text = dataSet.Tables[0].Rows[0]["AddDesc"].ToString();
				txtDelDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["DelDate"].ToString());
				rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemId + "&CompId=" + CompId;
				rt.Target = "_blank";
				string cmdText12 = fun.select1(" Id, Terms ", "tblPacking_Master");
				SqlCommand selectCommand12 = new SqlCommand(cmdText12, sqlConnection);
				SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
				DataSet dataSet12 = new DataSet();
				sqlDataAdapter12.Fill(dataSet12, "tblPacking_Master");
				DDLPF.DataSource = dataSet12.Tables["tblPacking_Master"];
				DDLPF.DataTextField = "Terms";
				DDLPF.DataValueField = "Id";
				DDLPF.DataBind();
				DDLPF.Items.Insert(0, "Select");
				DDLPF.SelectedValue = dataSet.Tables[0].Rows[0]["PF"].ToString();
				DrpBudgetCode.SelectedValue = dataSet.Tables[0].Rows[0]["BudgetCode"].ToString();
				string cmdText13 = fun.select1("Id, Terms", " tblExciseser_Master");
				SqlCommand selectCommand13 = new SqlCommand(cmdText13, sqlConnection);
				SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
				DataSet dataSet13 = new DataSet();
				sqlDataAdapter13.Fill(dataSet13, "tblExciseser_Master");
				DDLExcies.DataSource = dataSet13.Tables["tblExciseser_Master"];
				DDLExcies.DataTextField = "Terms";
				DDLExcies.DataValueField = "Id";
				DDLExcies.DataBind();
				DDLExcies.Items.Insert(0, "Select");
				DDLExcies.SelectedValue = dataSet.Tables[0].Rows[0]["ExST"].ToString();
				string cmdText14 = fun.select1("Id, Terms ", " tblVAT_Master");
				SqlCommand selectCommand14 = new SqlCommand(cmdText14, sqlConnection);
				SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
				DataSet dataSet14 = new DataSet();
				sqlDataAdapter14.Fill(dataSet14, "tblVAT_Master");
				DDLVat.DataSource = dataSet14.Tables["tblVAT_Master"];
				DDLVat.DataTextField = "Terms";
				DDLVat.DataValueField = "Id";
				DDLVat.DataBind();
				DDLVat.Items.Insert(0, "Select");
				DDLVat.SelectedValue = dataSet.Tables[0].Rows[0]["VAT"].ToString();
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
		base.Response.Redirect("PO_Edit_Details_PO_Grid.aspx?mid=" + MId + "&Code=" + code + "&pono=" + pono);
	}

	protected void btnProcide_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			int num = 0;
			if (BGWO == 1)
			{
				num = Convert.ToInt32(DrpBudgetCode.SelectedValue);
			}
			if (!(txtDelDate.Text != "") || !fun.DateValidation(txtDelDate.Text))
			{
				return;
			}
			sId = Session["username"].ToString();
			string text = fun.FromDate(txtDelDate.Text);
			CompId = Convert.ToInt32(Session["compid"]);
			double num2 = 0.0;
			num2 = Convert.ToDouble(decimal.Parse((Convert.ToDouble(txtRate.Text) - Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtDiscount.Text) / 100.0).ToString()).ToString("N2"));
			string cmdText = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			double num3 = 0.0;
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
			{
				num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
			}
			if (txtQty.Text != "" && fun.NumberValidation(txtQty.Text))
			{
				if (num2 > 0.0 && fun.NumberValidationQty(txtDiscount.Text))
				{
					if (num3 > 0.0)
					{
						double num4 = 0.0;
						num4 = num3 - num2;
						if (num4 >= 0.0)
						{
							string cmdText2 = fun.insert("tblMM_PO_Amd_Temp", "CompId,SessionId,PONo,POId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,AHId,DelDate,BudgetCode,PODId", "'" + CompId + "','" + sId + "','" + pono + "','" + poid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + AcHead + "','" + text + "','" + num + "','" + lblPODId.Text + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							base.Response.Redirect("PO_Edit_Details_PO_Grid.aspx?mid=" + MId + "&Code=" + code + "&pono=" + pono);
							return;
						}
						string cmdText3 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemId + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='2'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							string cmdText4 = fun.insert("tblMM_PO_Amd_Temp", "CompId,SessionId,PONo,POId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,AHId,DelDate,BudgetCode,PODId,RateFlag", "'" + CompId + "','" + sId + "','" + pono + "','" + poid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + AcHead + "','" + text + "','" + num + "','" + lblPODId.Text + "','1'");
							SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
							sqlCommand2.ExecuteNonQuery();
							base.Response.Redirect("PO_Edit_Details_PO_Grid.aspx?mid=" + MId + "&Code=" + code + "&pono=" + pono);
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
						string cmdText5 = fun.insert("tblMM_PO_Amd_Temp", "CompId,SessionId,PONo,POId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,AHId,DelDate,BudgetCode,PODId", "'" + CompId + "','" + sId + "','" + pono + "','" + poid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + AcHead + "','" + text + "','" + num + "','" + lblPODId.Text + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
						base.Response.Redirect("PO_Edit_Details_PO_Grid.aspx?mid=" + MId + "&Code=" + code + "&pono=" + pono);
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
				empty3 = "Entered Qty is not acceptable!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
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
