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

public class Module_HR_TourIntimation_Edit_Details : Page, IRequiresSessionState
{
	protected Label LblTINo;

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

	protected Panel Panel2;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected Panel Panel3;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected Button btnSubmit;

	protected Button btnCancel;

	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource2;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	private string wono = "";

	private int id;

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
			id = Convert.ToInt32(base.Request.QueryString["Id"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			textStartDate.Attributes.Add("readonly", "readonly");
			textEndDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("*", "tblACC_TourIntimation_Master", "Id='" + id + "'  And   CompId='" + CompId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				LblTINo.Text = dataSet.Tables[0].Rows[0]["TINo"].ToString();
				string selectCommandText = fun.select("Title+'.'+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", " EmpId='" + dataSet.Tables[0].Rows[0]["EmpId"].ToString() + "'  And CompId='" + CompId + "'");
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, con);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblHR_OfficeStaff");
				TextEmpName.Text = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
				if (dataSet.Tables[0].Rows[0]["BGGroupId"].ToString() != "1")
				{
					drpGroup.SelectedValue = dataSet.Tables[0].Rows[0]["BGGroupId"].ToString();
					RadioButtonWONoGroup.SelectedValue = "1";
				}
				else
				{
					RadioButtonWONoGroup.SelectedValue = "0";
					txtWONo.Text = dataSet.Tables[0].Rows[0]["WONo"].ToString();
				}
				WONoGroup();
				FillGridAdvanceTo();
				txtProjectName.Text = dataSet.Tables[0].Rows[0]["ProjectName"].ToString();
				fun.dropdownCountrybyId(ddlPlaceOfTourCountry, ddlPlaceOfTourState, "CId='" + dataSet.Tables[0].Rows[0]["PlaceOfTourCountry"].ToString() + "'");
				ddlPlaceOfTourCountry.SelectedIndex = 0;
				fun.dropdownCountry(ddlPlaceOfTourCountry, ddlPlaceOfTourState);
				ddlPlaceOfTourCountry.SelectedValue = dataSet.Tables[0].Rows[0]["PlaceOfTourCountry"].ToString();
				fun.dropdownState(ddlPlaceOfTourState, ddlPlaceOfTourCity, ddlPlaceOfTourCountry);
				fun.dropdownStatebyId(ddlPlaceOfTourState, "CId='" + dataSet.Tables[0].Rows[0]["PlaceOfTourCountry"].ToString() + "' AND SId='" + dataSet.Tables[0].Rows[0]["PlaceOfTourState"].ToString() + "'");
				ddlPlaceOfTourState.SelectedValue = dataSet.Tables[0].Rows[0]["PlaceOfTourState"].ToString();
				fun.dropdownCity(ddlPlaceOfTourCity, ddlPlaceOfTourState);
				fun.dropdownCitybyId(ddlPlaceOfTourCity, "SId='" + dataSet.Tables[0].Rows[0]["PlaceOfTourState"].ToString() + "' AND CityId='" + dataSet.Tables[0].Rows[0]["PlaceOfTourCity"].ToString() + "'");
				ddlPlaceOfTourCity.SelectedValue = dataSet.Tables[0].Rows[0]["PlaceOfTourCity"].ToString();
				textStartDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["TourStartDate"].ToString());
				textEndDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["TourEndDate"].ToString());
				txtNoOfDays.Text = dataSet.Tables[0].Rows[0]["NoOfDays"].ToString();
				txtNameAndAddress.Text = dataSet.Tables[0].Rows[0]["NameAddressSerProvider"].ToString();
				txtContactPerson.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
				txtContactNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
				txtEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
				string text = dataSet.Tables[0].Rows[0]["TourStartTime"].ToString();
				char[] separator = new char[2] { ':', ' ' };
				string[] array = text.Split(separator);
				string tM = array[3];
				int h = Convert.ToInt32(array[0]);
				int m = Convert.ToInt32(array[1]);
				int s = Convert.ToInt32(array[2]);
				fun.TimeSelector(h, m, s, tM, TimeSelector1);
				string text2 = dataSet.Tables[0].Rows[0]["TourEndTime"].ToString();
				char[] separator2 = new char[2] { ':', ' ' };
				string[] array2 = text2.Split(separator2);
				string tM2 = array2[3];
				int h2 = Convert.ToInt32(array2[0]);
				int m2 = Convert.ToInt32(array2[1]);
				int s2 = Convert.ToInt32(array2[2]);
				fun.TimeSelector(h2, m2, s2, tM2, TimeSelector2);
				fillgrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string cmdText = fun.select1("*", "tblACC_TourExpencessType");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Terms", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExpencessId", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					dataRow[1] = dataSet.Tables[0].Rows[i]["Terms"].ToString();
					string cmdText2 = fun.select("*", "tblACC_TourAdvance_Details", "MId='" + id + "' And ExpencessId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]) + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Amount"]);
						dataRow[3] = dataSet2.Tables[0].Rows[0]["Remarks"].ToString();
						dataRow[4] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ExpencessId"]);
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
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
		try
		{
			WONoGroup();
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
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
			string cmdText = fun.select("*", "tblACC_TourAdvance", "MId='" + id + "' Order by Id Desc ");
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
				string cmdText2 = fun.select("Title+'.'+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["EmpId"], "'"));
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
				string cmdText = fun.select("EmpId", "tblACC_TourAdvance", "EmpId='" + code + "' And MId='" + id + "'");
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
								string cmdText2 = fun.insert("tblACC_TourAdvance", "MId,EmpId,Amount,Remarks", "'" + id + "','" + code + "','" + Convert.ToDouble(decimal.Parse(num.ToString()).ToString("N3")) + "','" + text + "'");
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
						string cmdText3 = fun.insert("tblACC_TourAdvance", "MId,EmpId,Amount,Remarks", "'" + id + "','" + code2 + "','" + Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) + "','" + text3 + "'");
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
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_TourAdvance WHERE Id=" + num + " ", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			FillGridAdvanceTo();
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
			double num2 = 0.0;
			if (((TextBox)gridViewRow.FindControl("txtAmt1")).Text != "")
			{
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtAmt1")).Text).ToString("N3"));
			}
			string text = ((TextBox)gridViewRow.FindControl("txtRemark1")).Text;
			if (fun.NumberValidationQty(num2.ToString()))
			{
				if (num2 != 0.0)
				{
					string cmdText = fun.update("tblACC_TourAdvance", "Amount='" + num2 + "',Remarks='" + text + "'", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
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
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.EditIndex = -1;
		FillGridAdvanceTo();
		TabContainer1.ActiveTabIndex = 1;
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			con.Open();
			string text = "NA";
			string value = "1";
			int num = 0;
			string text2 = "";
			string code = fun.getCode(TextEmpName.Text);
			int num2 = fun.chkEmpCode(code, CompId);
			text2 = ((num2 != 1 || !(TextEmpName.Text != string.Empty)) ? string.Empty : code);
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
			string text3 = TimeSelector1.Hour.ToString("D2") + ":" + TimeSelector1.Minute.ToString("D2") + ":" + TimeSelector1.Second.ToString("D2") + ":" + TimeSelector1.AmPm;
			string text4 = TimeSelector2.Hour.ToString("D2") + ":" + TimeSelector2.Minute.ToString("D2") + ":" + TimeSelector2.Second.ToString("D2") + ":" + TimeSelector2.AmPm;
			if (num == 0)
			{
				if (text2 != string.Empty)
				{
					if (!(textStartDate.Text != "") || !fun.DateValidation(textStartDate.Text) || !(textEndDate.Text != "") || !fun.DateValidation(textEndDate.Text) || !(txtNoOfDays.Text != "") || !fun.NumberValidationQty(txtNoOfDays.Text) || !(txtProjectName.Text != "") || !(txtNoOfDays.Text != "") || !(txtNameAndAddress.Text != "") || !(txtContactPerson.Text != "") || !(txtContactNo.Text != ""))
					{
						return;
					}
					string cmdText = fun.update("tblACC_TourIntimation_Master", "SysDate='" + currDate + "' , SysTime='" + currTime + "' , SessionId='" + sId + "', CompId='" + CompId + "' , FinYearId='" + FinYearId + "' , EmpId='" + text2 + "',  WONo='" + text + "', BGGroupId='" + Convert.ToInt32(value) + "', ProjectName='" + txtProjectName.Text + "', TourStartDate='" + fun.FromDate(textStartDate.Text) + "', TourStartTime='" + text3 + "', TourEndDate ='" + fun.FromDate(textEndDate.Text) + "', TourEndTime='" + text4 + "', NoOfDays='" + Convert.ToInt32(txtNoOfDays.Text) + "', NameAddressSerProvider='" + txtNameAndAddress.Text + "', ContactPerson='" + txtContactPerson.Text + "' , ContactNo='" + txtContactNo.Text + "', Email='" + txtEmail.Text + "',PlaceOfTourCountry='" + ddlPlaceOfTourCountry.SelectedValue + "',PlaceOfTourState='" + ddlPlaceOfTourState.SelectedValue + "',PlaceOfTourCity='" + ddlPlaceOfTourCity.SelectedValue + "'", "Id='" + id + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					con.Close();
					foreach (GridViewRow row in GridView2.Rows)
					{
						int num3 = 0;
						int num4 = 0;
						if (((Label)row.FindControl("lblId")).Text != string.Empty)
						{
							num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						}
						if (((Label)row.FindControl("lblExpencessId")).Text != string.Empty)
						{
							num4 = Convert.ToInt32(((Label)row.FindControl("lblExpencessId")).Text);
						}
						if (num3 != 0 && num4 == 0 && ((TextBox)row.FindControl("txtAmount")).Text != "" && Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N2")) >= 0.0)
						{
							double num5 = 0.0;
							string empty = string.Empty;
							string empty2 = string.Empty;
							num5 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAmount")).Text).ToString("N2"));
							empty = ((TextBox)row.FindControl("txtRemarks")).Text;
							empty2 = fun.insert("tblACC_TourAdvance_Details", "MId,ExpencessId,Amount,Remarks", "'" + id + "','" + num3 + "','" + num5 + "','" + empty + "'");
							SqlCommand sqlCommand2 = new SqlCommand(empty2, con);
							con.Open();
							sqlCommand2.ExecuteNonQuery();
							con.Close();
						}
						if (num4 != 0 && ((TextBox)row.FindControl("txtAmount")).Text != "")
						{
							double num6 = 0.0;
							string empty3 = string.Empty;
							string empty4 = string.Empty;
							string empty5 = string.Empty;
							empty4 = ((TextBox)row.FindControl("txtRemarks")).Text;
							empty3 = ((Label)row.FindControl("lblExpencessId")).Text;
							num6 = Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text);
							empty5 = fun.update("tblACC_TourAdvance_Details", " Amount='" + num6 + "',Remarks='" + empty4 + "' ", " MId='" + id + "'  And  ExpencessId='" + empty3 + "'");
							SqlCommand sqlCommand3 = new SqlCommand(empty5, con);
							con.Open();
							sqlCommand3.ExecuteNonQuery();
							con.Close();
						}
					}
					base.Response.Redirect("TourIntimation_Edit.aspx?ModId=12&SubModId=124");
				}
				else
				{
					string empty6 = string.Empty;
					empty6 = "Invalid data entry.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty6 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty7 = string.Empty;
				empty7 = "Entered WO No is not valid !";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty7 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TourIntimation_Edit.aspx?ModId=12&SubModId=124");
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
