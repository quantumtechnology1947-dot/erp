using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_MaterialManagement_Transactions_SPR_Edit_Details_Item : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int itemId;

	private string SPRNo = "";

	private int SelectIcode;

	private int Iid;

	private string mid = "";

	private int CompId;

	protected Label lblItemCode;

	protected TextBox txtManfDesc;

	protected DropDownList DDLUomBasic;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected TextBox txtQty;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected CompareValidator CompareValidator2;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected TextBox txtRate;

	protected HtmlAnchor rt;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected CompareValidator CompareValidator3;

	protected TextBox txtDiscount;

	protected CompareValidator CompareValidator4;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected TextBox txtNewCustomerName;

	protected AutoCompleteExtender txtNewCustomerName_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected RadioButtonList RadioButtonList1;

	protected DropDownList DropDownList1;

	protected RadioButton rddept;

	protected DropDownList drpdept;

	protected RadioButton rdwono;

	protected TextBox txtwono;

	protected TextBox textDelDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected TextBox txtRemark;

	protected SqlDataSource SqlDataSource1;

	protected Button btnUpdate;

	protected Button btnCancel2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			string value = base.Request.QueryString["recId"];
			mid = base.Request.QueryString["Id"];
			itemId = Convert.ToInt32(value);
			SPRNo = base.Request.QueryString["SPRNo"];
			textDelDate.Attributes.Add("readonly", "readonly");
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.CId,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.ItemCode", " tblDG_Item_Master,tblMM_SPR_Details", " tblDG_Item_Master.Id=tblMM_SPR_Details.ItemId  AND tblMM_SPR_Details.Id='" + itemId + "' AND tblMM_SPR_Details.SPRNo='" + SPRNo + "'  AND tblDG_Item_Master.CompId='" + CompId + "'  ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["CId"] != DBNull.Value)
			{
				SelectIcode = Convert.ToInt32(dataSet.Tables[0].Rows[0]["CId"].ToString());
			}
			string cmdText2 = fun.select("ItemId", " tblMM_SPR_Details ", "Id='" + itemId + "' AND SPRNo='" + SPRNo + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			Iid = Convert.ToInt32(dataSet2.Tables[0].Rows[0][0].ToString());
			if (rddept.Checked)
			{
				txtwono.Text = "";
			}
			if (!base.IsPostBack)
			{
				sqlConnection.Open();
				txtManfDesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"].ToString()));
				fun.getCurrDate();
				fun.getCurrTime();
				Session["username"].ToString();
				Convert.ToInt32(Session["finyear"]);
				string cmdText3 = fun.select("tblMM_SPR_Details.Qty,tblMM_SPR_Details.Rate,tblMM_SPR_Details.Remarks,tblMM_SPR_Details.DelDate,tblMM_SPR_Details.Discount", "tblMM_SPR_Details,tblMM_SPR_Master", "tblMM_SPR_Details.SPRNo=tblMM_SPR_Master.SPRNo AND tblMM_SPR_Details.Id='" + itemId + "' AND tblMM_SPR_Details.SPRNo='" + SPRNo + "'AND tblMM_SPR_Master.CompId='" + CompId + "'  AND tblMM_SPR_Details.MId=tblMM_SPR_Master.Id");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				txtQty.Text = dataSet3.Tables[0].Rows[0]["Qty"].ToString();
				txtRate.Text = decimal.Parse(dataSet3.Tables[0].Rows[0]["Rate"].ToString()).ToString("N2");
				txtDiscount.Text = decimal.Parse(dataSet3.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2");
				txtRemark.Text = dataSet3.Tables[0].Rows[0]["Remarks"].ToString();
				textDelDate.Text = fun.FromDateDMY(dataSet3.Tables[0].Rows[0]["DelDate"].ToString());
				string cmdText4 = fun.select(" UOMBasic", " tblDG_Item_Master ", "  Id='" + Iid + "'AND CompId='" + CompId + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string selectedValue = dataSet4.Tables[0].Rows[0][0].ToString();
				fun.drpunit(DDLUomBasic);
				DDLUomBasic.SelectedValue = selectedValue;
				string cmdText5 = fun.select("tblMM_Supplier_master.SupplierName+'['+tblMM_Supplier_master.SupplierId+']' AS SupplierName ", "tblMM_SPR_Details,tblMM_Supplier_master ", "tblMM_SPR_Details.SupplierId=tblMM_Supplier_master.SupplierId AND tblMM_SPR_Details.Id='" + itemId + "' AND tblMM_SPR_Details.SPRNo='" + SPRNo + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				txtNewCustomerName.Text = dataSet5.Tables[0].Rows[0]["SupplierName"].ToString();
				string cmdText6 = fun.select("AHId", " tblMM_SPR_Details ", " Id='" + itemId + "' AND SPRNo='" + SPRNo + "'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				int num = Convert.ToInt32(dataSet6.Tables[0].Rows[0][0].ToString());
				string cmdText7 = fun.select("Category", " AccHead ", "Id='" + num + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				switch (dataSet7.Tables[0].Rows[0][0].ToString())
				{
				case "Labour":
					RadioButtonList1.SelectedValue = "1";
					fun.AcHead(DropDownList1, 1);
					break;
				case "With Material":
					RadioButtonList1.SelectedValue = "2";
					fun.AcHead(DropDownList1, 2);
					break;
				case "Expenses":
					RadioButtonList1.SelectedValue = "3";
					fun.AcHead(DropDownList1, 3);
					break;
				case "Service Provider":
					RadioButtonList1.SelectedValue = "4";
					fun.AcHead(DropDownList1, 4);
					break;
				}
				DropDownList1.SelectedValue = dataSet6.Tables[0].Rows[0][0].ToString();
				string cmdText8 = fun.select("WONo, DeptId ", " tblMM_SPR_Details ", "Id='" + itemId + "' AND SPRNo='" + SPRNo + "'");
				SqlCommand selectCommand8 = new SqlCommand(cmdText8, sqlConnection);
				SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
				DataSet dataSet8 = new DataSet();
				sqlDataAdapter8.Fill(dataSet8);
				dataSet8.Tables[0].Rows[0]["WONo"].ToString();
				if (Convert.ToInt32(dataSet8.Tables[0].Rows[0]["DeptId"].ToString()) == 0)
				{
					rdwono.Checked = true;
					txtwono.Text = dataSet8.Tables[0].Rows[0]["WONo"].ToString();
				}
				else
				{
					rddept.Checked = true;
					drpdept.SelectedValue = dataSet8.Tables[0].Rows[0]["DeptId"].ToString();
				}
				if (SelectIcode == 5)
				{
					txtManfDesc.ReadOnly = false;
					DDLUomBasic.Enabled = true;
				}
				else
				{
					txtManfDesc.ReadOnly = true;
					DDLUomBasic.Enabled = false;
				}
			}
			rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + Iid + "&CompId=" + CompId;
			rt.Target = "_blank";
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SPR_Edit_Details.aspx?SPRNo=" + SPRNo + "&ModId=6&SubModId=31&Id=" + mid);
	}

	protected void btnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int finYearId = Convert.ToInt32(Session["finyear"]);
			string code = fun.getCode(txtNewCustomerName.Text);
			sqlConnection.Open();
			string text2 = "";
			string text3 = "0";
			int num2 = 0;
			if (rdwono.Checked)
			{
				if (txtwono.Text != "" && fun.CheckValidWONo(txtwono.Text, num, finYearId))
				{
					text2 = txtwono.Text;
					num2 = 1;
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid WONo.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (rddept.Checked)
			{
				text3 = drpdept.SelectedValue.ToString();
				txtwono.Text = "";
				num2 = 1;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			num3 = Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2"));
			num5 = Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2"));
			num4 = num3 - num3 * num5 / 100.0;
			string cmdText = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + Iid + "' And CompId='" + num + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			double num6 = 0.0;
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
			{
				num6 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
			}
			int num7 = 0;
			if (num4 > 0.0)
			{
				if (num6 > 0.0)
				{
					double num8 = 0.0;
					num8 = Math.Round(num6 - num4, 2);
					if (num8 >= 0.0)
					{
						num7 = 1;
					}
					else
					{
						string cmdText2 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + Iid + "' And CompId='" + num + "' And LockUnlock='1'  And Type='1'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							num7 = 1;
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Entered rate is not acceptable!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					num7 = 1;
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Entered rate is not acceptable!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
			}
			if (txtQty.Text != "" && fun.NumberValidationQty(txtQty.Text) && num7 == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) && num2 == 1)
			{
				if (SelectIcode == 3)
				{
					string cmdText3 = fun.update("tblMM_SPR_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + text + "'", "tblMM_SPR_Master.SPRNo='" + SPRNo + "'AND CompId='" + num + "' AND Id='" + mid + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					string cmdText4 = fun.update("tblMM_SPR_Details", "Qty='" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "',Rate='" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "',SupplierId='" + code + "',AHId='" + DropDownList1.SelectedValue + "',WONo='" + text2 + "',DeptId='" + text3 + "',Remarks='" + txtRemark.Text + "',DelDate='" + fun.FromDate(textDelDate.Text) + "' ,Discount='" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "'    ", "tblMM_SPR_Details.SPRNo='" + SPRNo + "' AND tblMM_SPR_Details.Id='" + itemId + "' AND MId='" + mid + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					string cmdText5 = fun.update("tblDG_Item_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + text + "',ManfDesc='" + txtManfDesc.Text + "',UOMBasic='" + DDLUomBasic.SelectedValue + "'", "tblDG_Item_Master.Id='" + Iid + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
				}
				else
				{
					string cmdText6 = fun.update("tblMM_SPR_Master", "SysDate='" + currDate + "',SysTime='" + currTime + "',SessionId='" + text + "'", "tblMM_SPR_Master.SPRNo='" + SPRNo + "'AND CompId='" + num + "'AND Id='" + mid + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
					sqlCommand4.ExecuteNonQuery();
					string cmdText7 = fun.update("tblMM_SPR_Details", "Qty='" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "',Rate='" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "',SupplierId='" + code + "',AHId='" + DropDownList1.SelectedValue + "',WONo='" + text2 + "',DeptId='" + text3 + "',Remarks='" + txtRemark.Text + "',DelDate='" + fun.FromDate(textDelDate.Text) + "'   ,Discount='" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "' ", "tblMM_SPR_Details.SPRNo='" + SPRNo + "' AND tblMM_SPR_Details.Id='" + itemId + "'AND MId='" + mid + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText7, sqlConnection);
					sqlCommand5.ExecuteNonQuery();
				}
				base.Response.Redirect("SPR_Edit_Details.aspx?SPRNo=" + SPRNo + "&ModId=6&SubModId=31&Id=" + mid);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RadioButtonList1.SelectedValue == "1")
		{
			fun.AcHead(DropDownList1, 1);
		}
		else if (RadioButtonList1.SelectedValue == "2")
		{
			fun.AcHead(DropDownList1, 2);
		}
		else if (RadioButtonList1.SelectedValue == "3")
		{
			fun.AcHead(DropDownList1, 3);
		}
		else if (RadioButtonList1.SelectedValue == "4")
		{
			fun.AcHead(DropDownList1, 4);
		}
	}
}
