using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_HR_Transactions_OfferLetter_New : Page, IRequiresSessionState
{
	protected DropDownList DrpDesignation;

	protected DropDownList DrpTitle;

	protected TextBox TxtName;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected TextBox txtHeader;

	protected RequiredFieldValidator RequiredFieldValidator19;

	protected TextBox txtFooter;

	protected RequiredFieldValidator RequiredFieldValidator20;

	protected DropDownList DrpDutyHrs;

	protected TextBox TxtContactNo;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected DropDownList DrpOTHrs;

	protected TextBox TxtAddress;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected DropDownList DrpOvertime;

	protected DropDownList DrpEmpTypeOf;

	protected RequiredFieldValidator RequiredFieldValidator18;

	protected DropDownList DrpEmpType;

	protected TextBox TxtEmail;

	protected RequiredFieldValidator RequiredFieldValidator5;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox Txtinterviewedby;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected RequiredFieldValidator RequiredFieldValidator6;

	protected TextBox TxtAuthorizedby;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected RequiredFieldValidator RequiredFieldValidator7;

	protected TextBox TxtReferencedby;

	protected TextBox TxtGrossSalry;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected SqlDataSource SqlDataSource5;

	protected SqlDataSource SqlDataSource2;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource3;

	protected SqlDataSource SqlDataSource4;

	protected SqlDataSource SqlDataSource6;

	protected Label lblTH;

	protected Label lblTHAnn;

	protected Label lblTH1;

	protected Label lblTHAnn1;

	protected Label lblTH2;

	protected Label lblTHAnn2;

	protected Label lblCTC;

	protected Label lblCTCAnn;

	protected Label lblCTC1;

	protected Label lblCTCAnn1;

	protected Label lblCTC2;

	protected Label lblCTCAnn2;

	protected GridView GridView1;

	protected Label TxtGSal;

	protected Label TxtANNualSal;

	protected TextBox TxtGLTA;

	protected RegularExpressionValidator RegularExpressionValidator9;

	protected RequiredFieldValidator RequiredFieldValidator14;

	protected Label TxtGBasic;

	protected Label TxtAnBasic;

	protected TextBox TxtGGratia;

	protected RegularExpressionValidator RegularExpressionValidator4;

	protected RequiredFieldValidator RequiredFieldValidator9;

	protected Label TxtGDA;

	protected Label TxtAnDA;

	protected TextBox TxtAnnLOYAlty;

	protected RegularExpressionValidator RegularExpressionValidator10;

	protected RequiredFieldValidator RequiredFieldValidator15;

	protected Label TxtGHRA;

	protected Label TxtANHRA;

	protected TextBox TxtGVehAll;

	protected RegularExpressionValidator RegularExpressionValidator6;

	protected RequiredFieldValidator RequiredFieldValidator11;

	protected Label TxtGConvenience;

	protected Label TxtANConvenience;

	protected TextBox TxtAnnpaidleaves;

	protected RegularExpressionValidator RegularExpressionValidator11;

	protected RequiredFieldValidator RequiredFieldValidator16;

	protected Label TxtGEdu;

	protected Label TxtANEDU;

	protected TextBox txtPFEmployee;

	protected RequiredFieldValidator ReqtxtPFEmployee;

	protected RegularExpressionValidator RegutxtPFEmployee;

	protected Label TxtGEmpPF;

	protected Label TxtGWash;

	protected Label TxtANWash;

	protected TextBox txtPFCompany;

	protected RequiredFieldValidator ReqtxtPFCompany;

	protected RegularExpressionValidator RegutxtPFCompany;

	protected Label TxtGCompPF;

	protected TextBox txtAttB1;

	protected RequiredFieldValidator RequiredFieldValidator22;

	protected RegularExpressionValidator RegularExpressionValidator12;

	protected Label TxtGATTBN1;

	protected Label TxtGPTax;

	protected TextBox txtAttB2;

	protected RequiredFieldValidator RequiredFieldValidator23;

	protected RegularExpressionValidator RegularExpressionValidator13;

	protected Label TxtGATTBN2;

	protected TextBox txtBonus;

	protected RequiredFieldValidator RequiredFieldValidator21;

	protected RegularExpressionValidator RegularExpressionValidator14;

	protected Label TxtAnnBonus;

	protected Label lblGratuaty;

	protected Label TxtAnnGratuaty;

	protected TextBox TxtRemarks;

	protected Button ButtonSubmit;

	protected Button BtnSubmit;

	protected Label Label2;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private int CompId;

	private int FinYearId;

	private string SessionId = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SessionId = Session["username"].ToString();
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (!base.IsPostBack)
			{
				Label2.Text = "";
				if (base.Request.QueryString["msg"] != null)
				{
					Label2.Text = base.Request.QueryString["msg"].ToString();
				}
				string cmdText = fun.select("*", "tblHR_PF_Slab", "Active=1");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				txtPFEmployee.Text = dataSet.Tables[0].Rows[0]["PFEmployee"].ToString();
				txtPFCompany.Text = dataSet.Tables[0].Rows[0]["PFCompany"].ToString();
				FillAccegrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ButtonSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			CalSalary();
		}
		catch (Exception)
		{
		}
	}

	public void CalSalary()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (TxtGrossSalry.Text != "")
			{
				double num = Convert.ToDouble(TxtGrossSalry.Text);
				double num2 = num * 12.0;
				TxtGSal.Text = num.ToString();
				TxtANNualSal.Text = num2.ToString();
				TxtGBasic.Text = fun.Offer_Cal(num, 1, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtAnBasic.Text = fun.Offer_Cal(num, 1, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtGDA.Text = fun.Offer_Cal(num, 2, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtAnDA.Text = fun.Offer_Cal(num, 2, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtGHRA.Text = fun.Offer_Cal(num, 3, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtANHRA.Text = fun.Offer_Cal(num, 3, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtGConvenience.Text = fun.Offer_Cal(num, 4, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtANConvenience.Text = fun.Offer_Cal(num, 4, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtGEdu.Text = fun.Offer_Cal(num, 5, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtANEDU.Text = fun.Offer_Cal(num, 5, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtGWash.Text = fun.Offer_Cal(num, 6, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtANWash.Text = fun.Offer_Cal(num, 6, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				if (DrpEmpType.SelectedItem.Text != "Casuals")
				{
					num3 = num * Convert.ToDouble(txtAttB1.Text) / 100.0;
					num4 = num * Convert.ToDouble(txtAttB2.Text) / 100.0;
					TxtGATTBN1.Text = num3.ToString();
					TxtGATTBN2.Text = num4.ToString();
					num5 = fun.Pf_Cal(num, 1, Convert.ToDouble(txtPFEmployee.Text));
					TxtGEmpPF.Text = num5.ToString();
					num6 = fun.Pf_Cal(num, 2, Convert.ToDouble(txtPFCompany.Text));
					TxtGCompPF.Text = num6.ToString();
					num7 = fun.PTax_Cal(num + num3 + Convert.ToDouble(TxtGGratia.Text), "0");
					TxtGPTax.Text = num7.ToString();
					txtPFEmployee.Enabled = true;
					txtPFCompany.Enabled = true;
					txtBonus.Enabled = true;
					txtAttB1.Enabled = true;
					txtAttB2.Enabled = true;
					txtBonus.Enabled = true;
					lblGratuaty.Text = fun.Gratuity_Cal(num, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
					TxtAnnGratuaty.Text = fun.Gratuity_Cal(num, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				}
				else
				{
					txtBonus.Text = "0";
					txtBonus.Enabled = false;
					TxtGATTBN1.Text = "0";
					txtAttB1.Text = "0";
					txtAttB1.Enabled = false;
					TxtGATTBN2.Text = "0";
					txtAttB2.Text = "0";
					txtAttB2.Enabled = false;
					txtBonus.Text = "0";
					txtBonus.Enabled = false;
					TxtGEmpPF.Text = "0";
					TxtGCompPF.Text = "0";
					txtPFEmployee.Text = "0";
					txtPFEmployee.Enabled = false;
					txtPFCompany.Text = "0";
					txtPFCompany.Enabled = false;
					TxtGPTax.Text = "0";
					lblGratuaty.Text = "0";
					TxtAnnGratuaty.Text = "0";
				}
				if (DrpEmpTypeOf.SelectedValue == "2")
				{
					lblGratuaty.Text = "0";
					TxtAnnGratuaty.Text = "0";
				}
				double num8 = 0.0;
				num8 = Convert.ToDouble(txtBonus.Text) * 12.0;
				TxtAnnBonus.Text = num8.ToString();
				double num9 = 0.0;
				double num10 = 0.0;
				double num11 = 0.0;
				string cmdText = fun.select("*", "tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						switch (dataSet.Tables[0].Rows[i]["IncludesIn"].ToString())
						{
						case "1":
							num9 += Convert.ToDouble(dataSet.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
							break;
						case "2":
							num10 += Convert.ToDouble(dataSet.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
							break;
						case "3":
							num11 += Convert.ToDouble(dataSet.Tables[0].Rows[i]["Qty"]) * Convert.ToDouble(dataSet.Tables[0].Rows[i]["Amount"]);
							break;
						}
					}
				}
				double num12 = 0.0;
				num12 = Math.Round(num + Convert.ToDouble(TxtGGratia.Text) + num10 + num11 - (num5 + num7));
				lblTH.Text = decimal.Parse(num12.ToString()).ToString("N2");
				double num13 = 0.0;
				num13 = Math.Round(num12 + num3);
				lblTH1.Text = decimal.Parse(num13.ToString()).ToString("N2");
				double num14 = 0.0;
				num14 = Math.Round(num12 + num4);
				lblTH2.Text = decimal.Parse(num14.ToString()).ToString("N2");
				lblTHAnn.Text = decimal.Parse(Math.Round(num12 * 12.0).ToString()).ToString("N2");
				lblTHAnn1.Text = decimal.Parse(Math.Round(num13 * 12.0).ToString()).ToString("N2");
				lblTHAnn2.Text = decimal.Parse(Math.Round(num14 * 12.0).ToString()).ToString("N2");
				double num15 = 0.0;
				num15 = Math.Round(num + Convert.ToDouble(txtBonus.Text) + Convert.ToDouble(TxtAnnLOYAlty.Text) + Convert.ToDouble(TxtGLTA.Text) + Convert.ToDouble(lblGratuaty.Text) + num6 + Convert.ToDouble(TxtGGratia.Text)) + num9 + num11;
				lblCTC.Text = decimal.Parse(num15.ToString()).ToString("N2");
				double num16 = 0.0;
				num16 = Math.Round(num15 + num3);
				lblCTC1.Text = decimal.Parse(num16.ToString()).ToString("N2");
				double num17 = 0.0;
				num17 = Math.Round(num15 + num4);
				lblCTC2.Text = decimal.Parse(num17.ToString()).ToString("N2");
				lblCTCAnn.Text = decimal.Parse(Math.Round(num15 * 12.0).ToString()).ToString("N2");
				lblCTCAnn1.Text = decimal.Parse(Math.Round(num16 * 12.0).ToString()).ToString("N2");
				lblCTCAnn2.Text = decimal.Parse(Math.Round(num17 * 12.0).ToString()).ToString("N2");
			}
			else
			{
				string empty = string.Empty;
				empty = "Input data is invalid.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			if (txtFooter.Text != "" && txtHeader.Text != "" && TxtGrossSalry.Text != "" && TxtName.Text != "" && TxtAddress.Text != "" && DrpEmpTypeOf.SelectedValue != "0")
			{
				string cmdText = fun.insert("tblHR_Offer_Master", "SysDate,SysTime,FinYearId,CompId,SessionId,Title,EmployeeName,TypeOf,StaffType,salary,DutyHrs,OTHrs,OverTime , Address , ContactNo, EmailId , InterviewedBy  , AuthorizedBy, ReferenceBy  , Designation , ExGratia , VehicleAllowance , LTA  , Loyalty  , PaidLeaves,HeaderText,FooterText,Remarks,Bonus,AttBonusPer1,AttBonusPer2,PFEmployee,PFCompany", "'" + currDate + "','" + currTime + "','" + FinYearId + "','" + CompId + "','" + text + "','" + DrpTitle.SelectedValue + "','" + TxtName.Text + "','" + DrpEmpTypeOf.SelectedValue + "','" + DrpEmpType.SelectedValue + "','" + TxtGrossSalry.Text + "','" + DrpDutyHrs.SelectedValue + "','" + DrpOTHrs.SelectedValue + "','" + DrpOvertime.SelectedValue + "','" + TxtAddress.Text + "','" + TxtContactNo.Text + "','" + TxtEmail.Text + "','" + fun.getCode(Txtinterviewedby.Text) + "','" + fun.getCode(TxtAuthorizedby.Text) + "','" + TxtReferencedby.Text + "','" + DrpDesignation.SelectedValue + "','" + TxtGGratia.Text + "','" + TxtGVehAll.Text + "','" + TxtGLTA.Text + "','" + TxtAnnLOYAlty.Text + "','" + TxtAnnpaidleaves.Text + "','" + txtHeader.Text + "','" + txtFooter.Text + "','" + TxtRemarks.Text + "','" + txtBonus.Text + "','" + txtAttB1.Text + "','" + txtAttB2.Text + "','" + txtPFEmployee.Text + "','" + txtPFCompany.Text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("OfferId", "tblHR_Offer_Master", "CompId='" + CompId + "' order by OfferId DESC");
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string cmdText3 = fun.select("*", "tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					string cmdText4 = fun.insert("tblHR_Offer_Accessories", "MId,Perticulars,Qty,Amount,IncludesIn", "'" + dataSet.Tables[0].Rows[0][0].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Perticulars"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Qty"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Amount"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["IncludesIn"].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
				}
				string cmdText5 = fun.delete("tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
				sqlCommand3.ExecuteNonQuery();
				sqlConnection.Close();
				base.Response.Redirect("OfferLetter_New.aspx?ModId=12&SubModId=25&msg=Employee data is entered.");
			}
			else
			{
				string empty = string.Empty;
				empty = "Please fill Data properly.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
				if (array.Length == 10)
				{
					break;
				}
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void DrpEmpTypeOf_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpEmpTypeOf.SelectedValue == "1")
		{
			txtAttB1.Text = "10";
			txtAttB2.Text = "20";
		}
		else if (DrpEmpTypeOf.SelectedValue == "2")
		{
			txtAttB1.Text = "5";
			txtAttB2.Text = "15";
		}
		CalSalary();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string text = Session["username"].ToString();
			if (e.CommandName == "Add")
			{
				string empty = string.Empty;
				double num = 0.0;
				double num2 = 0.0;
				string empty2 = string.Empty;
				if (((TextBox)GridView1.FooterRow.FindControl("txtPerticulars")).Text != "" && ((TextBox)GridView1.FooterRow.FindControl("txtAccAmount")).Text != "" && ((TextBox)GridView1.FooterRow.FindControl("txtAccQty")).Text != "" && fun.NumberValidationQty(((TextBox)GridView1.FooterRow.FindControl("txtAccAmount")).Text) && fun.NumberValidationQty(((TextBox)GridView1.FooterRow.FindControl("txtAccQty")).Text))
				{
					empty = ((TextBox)GridView1.FooterRow.FindControl("txtPerticulars")).Text;
					num = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAccQty")).Text).ToString("N2"));
					num2 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.FooterRow.FindControl("txtAccAmount")).Text).ToString("N2"));
					empty2 = ((DropDownList)GridView1.FooterRow.FindControl("IncludeIn")).SelectedValue.ToString();
					string cmdText = fun.insert("tblHR_Offer_Accessories_Temp", "SessionId,CompId,Perticulars,Qty,Amount,IncludesIn", "'" + text + "','" + CompId + "','" + empty + "','" + num + "','" + num2 + "','" + empty2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					FillAccegrid();
				}
			}
			else if (e.CommandName == "Add1")
			{
				string empty3 = string.Empty;
				double num3 = 0.0;
				double num4 = 0.0;
				string empty4 = string.Empty;
				if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPerticulars1")).Text != "" && ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text != "" && ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text != "" && fun.NumberValidationQty(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text) && fun.NumberValidationQty(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text))
				{
					empty3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPerticulars1")).Text;
					num3 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccQty1")).Text).ToString("N2"));
					num4 = Convert.ToDouble(decimal.Parse(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtAccAmount1")).Text).ToString("N2"));
					empty4 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("IncludeIn0")).SelectedValue;
					string cmdText2 = fun.insert("tblHR_Offer_Accessories_Temp", "SessionId,CompId,Perticulars,Qty,Amount,IncludesIn", "'" + text + "','" + CompId + "','" + empty3 + "','" + num3 + "','" + num4 + "','" + empty4 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlConnection.Open();
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
					FillAccegrid();
				}
			}
			CalSalary();
		}
		catch (Exception)
		{
		}
	}

	public void FillAccegrid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			new DataTable();
			string cmdText = fun.select("SessionId,CompId,[Id],[Perticulars],[Qty],[Amount],Round(([Qty]*[Amount]),2)As Total,IncludesIn", "tblHR_Offer_Accessories_Temp", "SessionId='" + SessionId + "' Order by Id DESC");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				string text = ((Label)row.FindControl("lblIncludesInId")).Text;
				string cmdText2 = fun.select("*", "tblHR_IncludesIn", "Id='" + text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				((Label)row.FindControl("lblIncludesIn")).Text = dataSet2.Tables[0].Rows[0]["IncludesIn"].ToString();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpEmpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			double gamt = Convert.ToDouble(TxtGrossSalry.Text);
			if (DrpEmpType.SelectedItem.Text != "Casuals")
			{
				txtPFEmployee.Enabled = true;
				txtPFCompany.Enabled = true;
				txtBonus.Enabled = true;
				txtAttB1.Enabled = true;
				txtAttB2.Enabled = true;
				txtBonus.Enabled = true;
				string cmdText = fun.select("*", "tblHR_PF_Slab", "Active=1");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				txtPFEmployee.Text = dataSet.Tables[0].Rows[0]["PFEmployee"].ToString();
				txtPFCompany.Text = dataSet.Tables[0].Rows[0]["PFCompany"].ToString();
				if (DrpEmpTypeOf.SelectedValue == "1")
				{
					txtAttB1.Text = "10";
					txtAttB2.Text = "20";
				}
				else if (DrpEmpTypeOf.SelectedValue == "2")
				{
					txtAttB1.Text = "5";
					txtAttB2.Text = "15";
				}
				lblGratuaty.Text = fun.Gratuity_Cal(gamt, 1, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
				TxtAnnGratuaty.Text = fun.Gratuity_Cal(gamt, 2, Convert.ToInt32(DrpEmpTypeOf.SelectedValue)).ToString();
			}
			else
			{
				txtBonus.Text = "0";
				txtBonus.Enabled = false;
				TxtGATTBN1.Text = "0";
				txtAttB1.Text = "0";
				txtAttB1.Enabled = false;
				TxtGATTBN2.Text = "0";
				txtAttB2.Text = "0";
				txtAttB2.Enabled = false;
				txtBonus.Text = "0";
				txtBonus.Enabled = false;
				TxtGEmpPF.Text = "0";
				TxtGCompPF.Text = "0";
				txtPFEmployee.Text = "0";
				txtPFEmployee.Enabled = false;
				txtPFCompany.Text = "0";
				txtPFCompany.Enabled = false;
				TxtGPTax.Text = "0";
				lblGratuaty.Text = "0";
				TxtAnnGratuaty.Text = "0";
			}
			CalSalary();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblHR_Offer_Accessories_Temp", "Id='" + num + "' AND SessionId='" + SessionId + "'"), sqlConnection);
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			FillAccegrid();
			CalSalary();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			GridView1.EditIndex = -1;
			FillAccegrid();
			CalSalary();
		}
		catch (Exception)
		{
		}
	}
}
