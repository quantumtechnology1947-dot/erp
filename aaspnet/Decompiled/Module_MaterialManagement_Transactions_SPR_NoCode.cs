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

public class Module_MaterialManagement_Transactions_SPR_NoCode : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int itemId;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	protected Label lbltIemCode;

	protected Label lblManfDescription;

	protected Label lblUOMBasic;

	protected TextBox txtQty;

	protected RequiredFieldValidator RequiredFieldValidator8;

	protected RegularExpressionValidator RegQty;

	protected TextBox txtRate;

	protected HtmlAnchor rt;

	protected RequiredFieldValidator RequiredFieldValidator10;

	protected RegularExpressionValidator RegRate;

	protected TextBox txtDiscount;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected RegularExpressionValidator RegDisc;

	protected TextBox txtNewCustomerName;

	protected AutoCompleteExtender txtNewCustomerName_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected RadioButton RbtnLabour;

	protected RadioButton RbtnWithMaterial;

	protected DropDownList DropDownList1;

	protected Label lblAHId;

	protected RadioButton rdwono;

	protected TextBox txtwono;

	protected RadioButton rddept;

	protected DropDownList drpdept;

	protected TextBox textDelDate;

	protected CalendarExtender textDelDate_CalendarExtender;

	protected RequiredFieldValidator ReqDelDate;

	protected RegularExpressionValidator RegDelverylDate;

	protected TextBox txtRemark;

	protected SqlDataSource SqlDataSource1;

	protected Button btnAdd;

	protected Button btnCancel2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string value = base.Request.QueryString["Id"];
			itemId = Convert.ToInt32(value);
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sqlConnection.Open();
			textDelDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				AcHead();
				string cmdText = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + itemId + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
					txtRate.Text = dataSet.Tables[0].Rows[0]["Rate"].ToString();
					txtDiscount.Text = dataSet.Tables[0].Rows[0]["Discount"].ToString();
				}
				else
				{
					string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "'  order by DisRate Asc ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
					{
						Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
						txtRate.Text = dataSet2.Tables[0].Rows[0]["Rate"].ToString();
						txtDiscount.Text = dataSet2.Tables[0].Rows[0]["Discount"].ToString();
					}
				}
			}
			rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemId + "&CompId=" + CompId;
			rt.Target = "_blank";
			if (rddept.Checked)
			{
				txtwono.Text = "";
			}
			fun.getCurrDate();
			fun.getCurrTime();
			string cmdText3 = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.AHId,tblDG_Item_Master.CId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic, tblDG_Item_Master.ItemCode ", "tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.Id='" + itemId + "' AND tblDG_Item_Master.CompId='" + CompId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			lbltIemCode.Text = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
			lblUOMBasic.Text = dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString();
			lblManfDescription.Text = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
			if (dataSet3.Tables[0].Rows[0]["CId"] != DBNull.Value)
			{
				lblAHId.Visible = true;
				RbtnLabour.Visible = false;
				RbtnWithMaterial.Visible = false;
				DropDownList1.Visible = false;
				string cmdText4 = fun.select("Category,'['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Id='" + Convert.ToInt32(dataSet3.Tables[0].Rows[0]["AHId"]) + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "AccHead");
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					lblAHId.Text = dataSet4.Tables[0].Rows[0]["Category"].ToString() + " - " + dataSet4.Tables[0].Rows[0]["Head"].ToString();
				}
			}
			else
			{
				lblAHId.Visible = false;
				RbtnLabour.Visible = true;
				RbtnWithMaterial.Visible = true;
				DropDownList1.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SPR_New.aspx?ModId=6&SubModId=31");
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			string code = fun.getCode(txtNewCustomerName.Text);
			sqlConnection.Open();
			int num3 = 0;
			string cmdText = fun.select("AHId,CId", "tblDG_Item_Master", "tblDG_Item_Master.Id='" + itemId + "' AND CompId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				num3 = ((dataSet.Tables[0].Rows[0]["CId"] == DBNull.Value) ? Convert.ToInt32(DropDownList1.SelectedValue) : Convert.ToInt32(dataSet.Tables[0].Rows[0]["AHId"]));
			}
			string text2 = "";
			string text3 = "";
			int num4 = 0;
			if (rdwono.Checked && txtwono.Text != "" && fun.CheckValidWONo(txtwono.Text, num, num2))
			{
				text2 = txtwono.Text;
				num4 = 1;
			}
			if (rddept.Checked)
			{
				text3 = drpdept.SelectedValue.ToString();
				num4 = 1;
			}
			fun.chkItemId(itemId);
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			num5 = Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2"));
			num7 = Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2"));
			num6 = Convert.ToDouble(decimal.Parse((num5 - num5 * num7 / 100.0).ToString()).ToString("N2"));
			double num8 = 0.0;
			string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + itemId + "' And CompId='" + num + "'   ");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
			{
				num8 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
			}
			else
			{
				string cmdText3 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + num + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num8 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
			}
			if (num4 == 1)
			{
				if (num6 > 0.0)
				{
					if (num8 > 0.0)
					{
						double num9 = 0.0;
						num9 = Convert.ToDouble(decimal.Parse((num8 - num6).ToString()).ToString("N2"));
						if (num9 >= 0.0)
						{
							int num10 = fun.chkSupplierCode(code);
							if (num10 == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) && fun.NumberValidationQty(txtQty.Text) && fun.NumberValidationQty(txtDiscount.Text) && fun.NumberValidationQty(num5.ToString()))
							{
								string cmdText4 = fun.insert("tblMM_SPR_Temp", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,SupplierId,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + currDate + "','" + currTime + "','" + num + "','" + num2 + "','" + text + "','" + itemId + "','" + code + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + num5 + "','" + num3 + "','" + text2 + "','" + text3 + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + num7 + "'");
								SqlCommand sqlCommand = new SqlCommand(cmdText4, sqlConnection);
								sqlCommand.ExecuteNonQuery();
								base.Response.Redirect("SPR_New.aspx?ModId=6&SubModId=31");
							}
						}
						else
						{
							string cmdText5 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemId + "' And CompId='" + num + "' And LockUnlock='1'  And Type='1'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection);
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							DataSet dataSet4 = new DataSet();
							sqlDataAdapter4.Fill(dataSet4);
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								int num11 = fun.chkSupplierCode(code);
								if (num11 == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) && fun.NumberValidationQty(txtQty.Text) && fun.NumberValidationQty(num5.ToString()))
								{
									string cmdText6 = fun.insert("tblMM_SPR_Temp", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,SupplierId,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + currDate + "','" + currTime + "','" + num + "','" + num2 + "','" + text + "','" + itemId + "','" + code + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + num5 + "','" + num3 + "','" + text2 + "','" + text3 + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + num7 + "'");
									SqlCommand sqlCommand2 = new SqlCommand(cmdText6, sqlConnection);
									sqlCommand2.ExecuteNonQuery();
									base.Response.Redirect("SPR_New.aspx?ModId=6&SubModId=31");
								}
							}
							else
							{
								string empty = string.Empty;
								empty = "Entered rate is not acceptable!";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
					}
					else
					{
						int num12 = fun.chkSupplierCode(code);
						if (num12 == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) && fun.NumberValidationQty(txtQty.Text) && fun.NumberValidationQty(num5.ToString()))
						{
							string cmdText7 = fun.insert("tblMM_SPR_Temp", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,SupplierId,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + currDate + "','" + currTime + "','" + num + "','" + num2 + "','" + text + "','" + itemId + "','" + code + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + num5 + "','" + num3 + "','" + text2 + "','" + text3 + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + num7 + "'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText7, sqlConnection);
							sqlCommand3.ExecuteNonQuery();
							base.Response.Redirect("SPR_New.aspx?ModId=6&SubModId=31");
						}
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
				empty3 = "WONo or Dept is not found!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
			}
			sqlConnection.Close();
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

	protected void txtEditCustomerName_TextChanged(object sender, EventArgs e)
	{
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	public void AcHead()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (RbtnLabour.Checked)
			{
				text = "Labour";
			}
			if (RbtnWithMaterial.Checked)
			{
				text = "With Material";
			}
			string cmdText = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			DropDownList1.DataSource = dataSet;
			DropDownList1.DataTextField = "Head";
			DropDownList1.DataValueField = "Id";
			DropDownList1.DataBind();
		}
		catch (Exception)
		{
		}
	}
}
