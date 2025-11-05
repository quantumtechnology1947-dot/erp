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
using MKB.TimePicker;

public class Module_HR_TourIntimation : Page, IRequiresSessionState
{
	protected RadioButtonList RadioButtonList1;

	protected TextBox TextEmpName;

	protected AutoCompleteExtender Txt_AutoCompleteExtender;

	protected RequiredFieldValidator ReqTextEmpName;

	protected RadioButtonList RadioButtonWONoGroup;

	protected TextBox txtWONo;

	protected RequiredFieldValidator RequiredFieldtxtWONo;

	protected DropDownList drpGroup;

	protected TextBox txtProjectName;

	protected RequiredFieldValidator ReqtxtProjectName;

	protected DropDownList ddlPlaceOfTourCountry;

	protected RequiredFieldValidator PlaceOfTourCountry;

	protected DropDownList ddlPlaceOfTourState;

	protected RequiredFieldValidator PlaceOfTourState;

	protected DropDownList ddlPlaceOfTourCity;

	protected RequiredFieldValidator PlaceOfTourCity;

	protected TextBox textStartDate;

	protected CalendarExtender textStartDate_CalendarExtender;

	protected RequiredFieldValidator ReqtextStartDate;

	protected RegularExpressionValidator RegtextStartDate;

	protected TimeSelector TimeSelector1;

	protected TextBox textEndDate;

	protected CalendarExtender textEndDate_CalendarExtender0;

	protected RequiredFieldValidator ReqtextEndDate;

	protected RegularExpressionValidator RegtextEndDate;

	protected TimeSelector TimeSelector2;

	protected TextBox txtNoOfDays;

	protected RequiredFieldValidator ReqNoOfDays;

	protected RegularExpressionValidator RegtxtNoOfDays;

	protected TextBox txtNameAndAddress;

	protected RequiredFieldValidator ReqtxtNameAndAddress;

	protected TextBox txtContactPerson;

	protected RequiredFieldValidator ReqtxtContactPerson;

	protected TextBox txtContactNo;

	protected RequiredFieldValidator ReqtxtContactNo;

	protected TextBox txtEmail;

	protected GridView GridView2;

	protected Panel Panel1;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected Panel Panel2;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected Button btnSubmit;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource2;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	private string wono = "";

	private string connStr = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			textStartDate.Attributes.Add("readonly", "readonly");
			textEndDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				fun.dropdownCountry(ddlPlaceOfTourCountry, ddlPlaceOfTourState);
				WONoGroup();
				FillGridAdvanceTo();
				string cmdText = fun.delete("tblACC_TourAdvance_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'AND FinYearId='" + FinYearId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				FillGridAdvanceTo();
			}
			if (RadioButtonList1.SelectedValue.ToString() == "0")
			{
				ReqTextEmpName.Visible = false;
			}
			else
			{
				ReqTextEmpName.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void WONoGroup()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			if (RadioButtonWONoGroup.SelectedValue.ToString() == "0")
			{
				wono = txtWONo.Text;
				drpGroup.Visible = false;
				txtWONo.Visible = true;
				RequiredFieldtxtWONo.Visible = true;
			}
			if (RadioButtonWONoGroup.SelectedValue.ToString() == "1")
			{
				drpGroup.Visible = true;
				txtWONo.Visible = false;
				txtWONo.Text = "";
				RequiredFieldtxtWONo.Visible = false;
				string cmdText = fun.select1("Symbol,Id ", " BusinessGroup");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "BusinessGroup");
				drpGroup.DataSource = dataSet;
				drpGroup.DataTextField = "Symbol";
				drpGroup.DataValueField = "Id";
				drpGroup.DataBind();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RadioButtonWONoGroup_SelectedIndexChanged(object sender, EventArgs e)
	{
		WONoGroup();
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
			}
		}
		Array.Sort(array);
		return array;
	}

	public void FillGridAdvanceTo()
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string cmdText = fun.select("*", "tblACC_TourAdvance_Temp", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And SessionId='" + sId + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText2 = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["EmpId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				dataRow[2] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
				dataRow[3] = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string code = fun.getCode(((TextBox)GridView1.FooterRow.FindControl("TextEmpName")).Text);
				double num = 0.0;
				if (((TextBox)GridView1.FooterRow.FindControl("txtAmt")).Text != "")
				{
					num = Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtAmt")).Text);
				}
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtRemark")).Text;
				string cmdText = fun.select("EmpId", "tblACC_TourAdvance_Temp", "EmpId='" + code + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					if (fun.NumberValidationQty(num.ToString()))
					{
						if (code != "")
						{
							if (num != 0.0)
							{
								string cmdText2 = fun.insert("tblACC_TourAdvance_Temp", "SessionId,CompId,FinYearId,EmpId,Amount,Remarks", "'" + sId + "','" + CompId + "','" + FinYearId + "','" + code + "','" + Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N3")) + "','" + text + "'");
								SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
								con.Open();
								sqlCommand.ExecuteNonQuery();
								con.Close();
								FillGridAdvanceTo();
							}
							else
							{
								string empty = string.Empty;
								empty = "Insert Valid Amount.";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Invalid Employee Name.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					_ = string.Empty;
					string text2 = "Employee is already exist";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text2 + "');", addScriptTags: true);
				}
				TabContainer1.ActiveTabIndex = 1;
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			string code2 = fun.getCode(((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEmp")).Text);
			double num2 = 0.0;
			if (((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtAmt2")).Text != "")
			{
				num2 = Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtAmt2")).Text);
			}
			string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtRemarks2")).Text;
			if (fun.NumberValidationQty(num2.ToString()))
			{
				if (code2 != "")
				{
					if (num2 != 0.0)
					{
						string cmdText3 = fun.insert("tblACC_TourAdvance_Temp", "SessionId,CompId,FinYearId,EmpId,Amount,Remarks", "'" + sId + "','" + CompId + "','" + FinYearId + "','" + code2 + "','" + Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) + "','" + text3 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
						FillGridAdvanceTo();
					}
					else
					{
						string empty3 = string.Empty;
						empty3 = "Insert Valid Amount.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty4 = string.Empty;
					empty4 = "Invalid Employee Name.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
				}
			}
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_TourAdvance_Temp WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGridAdvanceTo();
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string code = fun.getCode(((TextBox)gridViewRow.FindControl("txtEmpName1")).Text);
			double num2 = 0.0;
			if (((TextBox)gridViewRow.FindControl("txtAmt1")).Text != "")
			{
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAmt1")).Text).ToString("N3"));
			}
			string text = ((TextBox)gridViewRow.FindControl("txtRemark1")).Text;
			string cmdText = fun.select("EmpId", "tblACC_TourAdvance_Temp", "EmpId='" + code + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				if (fun.NumberValidationQty(num2.ToString()))
				{
					if (code != "")
					{
						if (num2 > 0.0)
						{
							string cmdText2 = fun.update("tblACC_TourAdvance_Temp", "SessionId='" + sId + "',EmpId='" + code + "',Amount='" + num2 + "',Remarks='" + text + "'", "Id='" + num + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
							con.Open();
							sqlCommand.ExecuteNonQuery();
							con.Close();
							GridView1.EditIndex = -1;
							FillGridAdvanceTo();
						}
						else
						{
							string empty = string.Empty;
							empty = "Insert Valid Amount.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Invalid Employee Name.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
			}
			else
			{
				_ = string.Empty;
				string text2 = "Employee is already exist";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text2 + "');", addScriptTags: true);
			}
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			FillGridAdvanceTo();
			TabContainer1.ActiveTabIndex = 1;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		FillGridAdvanceTo();
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.EditIndex = -1;
		FillGridAdvanceTo();
	}

	protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RadioButtonList1.SelectedValue.ToString() == "0")
		{
			TextEmpName.Enabled = false;
			TextEmpName.Text = string.Empty;
		}
		if (RadioButtonList1.SelectedValue.ToString() == "1")
		{
			TextEmpName.Enabled = true;
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = "NA";
			string value = "1";
			int num = 0;
			if (RadioButtonWONoGroup.SelectedValue.ToString() == "0")
			{
				if (txtWONo.Text != "")
				{
					if (fun.CheckValidWONo(txtWONo.Text, CompId, FinYearId))
					{
						text = txtWONo.Text;
					}
					else
					{
						num++;
					}
				}
				else
				{
					num++;
				}
			}
			else
			{
				value = drpGroup.SelectedValue.ToString();
			}
			string text2 = string.Empty;
			int num2 = 0;
			if (RadioButtonList1.SelectedValue.ToString() == "0")
			{
				text2 = sId;
				num2 = 0;
				ReqTextEmpName.Visible = false;
			}
			if (RadioButtonList1.SelectedValue.ToString() == "1")
			{
				string code = fun.getCode(TextEmpName.Text);
				int num3 = fun.chkEmpCode(code, CompId);
				if (num3 == 1 && TextEmpName.Text != string.Empty)
				{
					text2 = code;
					num2 = 1;
				}
				else
				{
					text2 = string.Empty;
				}
			}
			string text3 = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + ":" + TimeSelector1.AmPm;
			string text4 = TimeSelector2.Hour.ToString("D2") + ":" + TimeSelector2.Minute.ToString("D2") + ":" + TimeSelector2.Second.ToString("D2") + ":" + TimeSelector2.AmPm;
			string cmdText = fun.select("TINo", "tblACC_TourIntimation_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_TourIntimation_Master");
			string text5 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			if (num == 0)
			{
				if (text2 != string.Empty)
				{
					if (textStartDate.Text != "" && fun.DateValidation(textStartDate.Text) && textEndDate.Text != "" && fun.DateValidation(textEndDate.Text) && txtNoOfDays.Text != "" && fun.NumberValidationQty(txtNoOfDays.Text) && txtProjectName.Text != "" && txtNoOfDays.Text != "" && txtNameAndAddress.Text != "" && txtContactPerson.Text != "" && txtContactNo.Text != "" && ddlPlaceOfTourCountry.SelectedValue != "Select" && ddlPlaceOfTourState.SelectedValue != "Select" && ddlPlaceOfTourCity.SelectedValue != "Select")
					{
						string cmdText2 = fun.insert("tblACC_TourIntimation_Master", "SysDate , SysTime , SessionId, CompId , FinYearId ,TINo ,EmpId, Type, WONo, BGGroupId, ProjectName,  TourStartDate, TourStartTime, TourEndDate , TourEndTime, NoOfDays, NameAddressSerProvider, ContactPerson , ContactNo, Email,PlaceOfTourCountry,PlaceOfTourState,PlaceOfTourCity", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text5 + "','" + text2 + "','" + num2 + "','" + text.ToUpper() + "','" + Convert.ToInt32(value) + "','" + txtProjectName.Text + "','" + fun.FromDate(textStartDate.Text) + "','" + text3 + "','" + fun.FromDate(textEndDate.Text) + "','" + text4 + "','" + Convert.ToInt32(txtNoOfDays.Text) + "','" + txtNameAndAddress.Text + "','" + txtContactPerson.Text + "','" + txtContactNo.Text + "','" + txtEmail.Text + "','" + ddlPlaceOfTourCountry.SelectedValue + "','" + ddlPlaceOfTourState.SelectedValue + "','" + ddlPlaceOfTourCity.SelectedValue + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
						con.Open();
						sqlCommand.ExecuteNonQuery();
						con.Close();
						string cmdText3 = fun.select("Id", "tblACC_TourIntimation_Master", "CompId='" + CompId + "' Order by Id desc");
						SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2, "tblACC_TourIntimation_Master");
						int num4 = 0;
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							num4 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"].ToString());
						}
						foreach (GridViewRow row in GridView2.Rows)
						{
							int num5 = Convert.ToInt32(((Label)row.FindControl("lblAdId")).Text);
							string text6 = ((TextBox)row.FindControl("txtRemarks")).Text;
							if (((TextBox)row.FindControl("txtAmount")).Text != "" && Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N2")) >= 0.0)
							{
								double num6 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N2"));
								string cmdText4 = fun.insert("tblACC_TourAdvance_Details", "MId,ExpencessId,Amount,Remarks", "'" + num4 + "','" + num5 + "','" + num6 + "','" + text6 + "'");
								SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
								con.Open();
								sqlCommand2.ExecuteNonQuery();
								con.Close();
							}
						}
						foreach (GridViewRow row2 in GridView2.Rows)
						{
							((TextBox)row2.FindControl("txtRemarks")).Text = "";
							((TextBox)row2.FindControl("txtAmount")).Text = "";
						}
						string cmdText5 = fun.select("*", "tblACC_TourAdvance_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' AND FinYearId='" + FinYearId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
							{
								string cmdText6 = fun.insert("tblACC_TourAdvance", "MId,EmpId,Amount,Remarks", "'" + num4 + "','" + dataSet3.Tables[0].Rows[i]["EmpId"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Amount"].ToString()).ToString("N2")) + "','" + dataSet3.Tables[0].Rows[i]["Remarks"].ToString() + "'");
								SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
								con.Open();
								sqlCommand3.ExecuteNonQuery();
								con.Close();
							}
							string cmdText7 = fun.delete("tblACC_TourAdvance_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'AND FinYearId='" + FinYearId + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText7, con);
							con.Open();
							sqlCommand4.ExecuteNonQuery();
							con.Close();
							FillGridAdvanceTo();
						}
						WONoGroup();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
					else
					{
						string empty = string.Empty;
						empty = "Invalid data entry.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid Employee Name.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Entered WO No is not valid !";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlPlaceOfTourCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownState(ddlPlaceOfTourState, ddlPlaceOfTourCity, ddlPlaceOfTourCountry);
	}

	protected void ddlPlaceOfTourState_SelectedIndexChanged(object sender, EventArgs e)
	{
		fun.dropdownCity(ddlPlaceOfTourCity, ddlPlaceOfTourState);
	}
}
