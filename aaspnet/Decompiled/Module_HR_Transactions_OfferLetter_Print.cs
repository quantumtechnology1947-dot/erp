using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_HR_Transactions_OfferLetter_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private string FyId = "";

	private string y = "";

	protected TextBox TextBox1;

	protected AutoCompleteExtender TxtEmpName_AutoCompleteExtender;

	protected Button Button1;

	protected Button btnViewAll;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Init(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			if (!base.IsPostBack)
			{
				binddata(y);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	public void binddata(string EmpName)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOf", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DutyHrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("InvBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GrossSal", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(string)));
			string text = "";
			if (TextBox1.Text != "")
			{
				text = "And EmployeeName='" + EmpName + "' ";
			}
			string cmdText = fun.select("*", "tblHR_Offer_Master", "CompId='" + CompId + "' And FinYearId<='" + FyId + "'" + text + " Order by OfferId Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["OfferId"];
					dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
					if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
					{
						dataRow[2] = "SAPL";
					}
					else if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
					{
						dataRow[2] = "NEHA";
					}
					string cmdText2 = fun.select("*", "tblHR_EmpType", "Id='" + dataSet.Tables[0].Rows[i]["StaffType"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2, "tblHR_EmpType");
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[3] = dataSet2.Tables[0].Rows[0]["Description"].ToString();
					}
					dataRow[4] = dataSet.Tables[0].Rows[i]["Title"].ToString() + " " + dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
					string cmdText3 = fun.select("Type AS Designation", "tblHR_Designation", string.Concat("Id='", dataSet.Tables[0].Rows[i]["Designation"], "'"));
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "tblHR_Designation");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["Designation"].ToString();
					}
					string cmdText4 = fun.select("Hours", "tblHR_DutyHour", string.Concat("Id='", dataSet.Tables[0].Rows[i]["DutyHrs"], "'"));
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "tblHR_DutyHour");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet4.Tables[0].Rows[0]["Hours"];
					}
					string cmdText5 = fun.select("EmployeeName", "tblHR_OfficeStaff", string.Concat("EmpId='", dataSet.Tables[0].Rows[i]["InterviewedBy"], "'"));
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5, "tblHR_OfficeStaff");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
					}
					dataRow[8] = dataSet.Tables[0].Rows[i]["ContactNo"];
					dataRow[9] = dataSet.Tables[0].Rows[i]["salary"];
					string cmdText6 = fun.select("*", "tblHR_OfficeStaff", string.Concat("OfferId='", dataSet.Tables[0].Rows[i]["OfferId"], "'"));
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6, "tblHR_OfficeStaff");
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						dataRow[10] = "Confirm";
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text2 = ((Label)row.FindControl("lblId")).Text;
				string cmdText7 = fun.select("Increment", "tblHR_Offer_Master", "OfferId ='" + text2 + "'");
				SqlCommand selectCommand7 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
				DataSet dataSet7 = new DataSet();
				sqlDataAdapter7.Fill(dataSet7);
				List<string> list = new List<string>();
				for (int num = Convert.ToInt32(dataSet7.Tables[0].Rows[0][0]); num >= 0; num--)
				{
					list.Add(num.ToString());
				}
				((DropDownList)row.FindControl("IncrementDropDown")).DataSource = list;
				((DropDownList)row.FindControl("IncrementDropDown")).DataBind();
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			binddata(y);
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
		string selectCommandText = clsFunctions2.select("EmployeeName", "tblHR_Offer_Master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[0].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[0].ToString();
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string value = ((DropDownList)gridViewRow.FindControl("IncrementDropDown")).SelectedItem.Value;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("~/Module/HR/Transactions/OfferLetter_Print_Details.aspx?OfferId=" + num + "&Increment=" + value + "&T=1&Key=" + randomAlphaNumeric + "&ModId=12&SubModId=25");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		if (TextBox1.Text != "")
		{
			binddata(TextBox1.Text);
		}
	}

	protected void btnViewAll_Click(object sender, EventArgs e)
	{
		DataSet dataSet = new DataSet();
		DataSet dataSet2 = new DataSet();
		DataTable dataTable = new DataTable();
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			double num = 0.0;
			text = "SELECT tblHR_Offer_Master.OfferId,tblHR_Offer_Master.Bonus, tblHR_Offer_Master.Title,tblHR_Designation.Type as Designation,tblHR_OfficeStaff.EmpId, tblHR_OfficeStaff.EmployeeName, tblHR_OfficeStaff.Department, tblHR_OfficeStaff.BGGroup, tblHR_Offer_Master.salary,  tblHR_Offer_Master.TypeOf, tblHR_Offer_Master.StaffType, tblHR_Offer_Master.ExGratia, tblHR_Offer_Master.VehicleAllowance, tblHR_Offer_Master.LTA, tblHR_Offer_Master.Loyalty, tblHR_Offer_Master.Bonus, tblHR_Offer_Master.AttBonusPer1, tblHR_Offer_Master.AttBonusPer2,tblHR_Offer_Master.PFEmployee,tblHR_Offer_Master.PFCompany, tblHR_Offer_Master.PFEmployee, tblHR_Offer_Master.PFCompany, tblHR_OTHour.Hours as OTHrs, tblHR_DutyHour.Hours as DutyHrs, tblHR_OverTime.Description as OverTime, tblHR_Grade.Symbol as Grade FROM tblHR_Offer_Master INNER JOIN  tblHR_OfficeStaff ON tblHR_Offer_Master.OfferId = tblHR_OfficeStaff.OfferId INNER JOIN tblHR_OTHour ON tblHR_Offer_Master.OTHrs = tblHR_OTHour.Id INNER JOIN tblHR_DutyHour ON tblHR_Offer_Master.DutyHrs = tblHR_DutyHour.Id INNER JOIN tblHR_OverTime ON tblHR_Offer_Master.OverTime = tblHR_OverTime.Id INNER JOIN tblHR_Grade ON tblHR_OfficeStaff.Grade = tblHR_Grade.Id INNER JOIN tblHR_Designation ON tblHR_Offer_Master.Designation = tblHR_Designation.Id  AND tblHR_OfficeStaff.ResignationDate = '' AND tblHR_OfficeStaff.EmpId!='Sapl0001'ANd tblHR_OfficeStaff.CompId='" + CompId + "' AND tblHR_OfficeStaff.FinYearId<='" + FyId + "' Order by tblHR_OfficeStaff.EmpId  ASC";
			SqlCommand selectCommand = new SqlCommand(text, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet2);
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Gross", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DutyHrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OTHrs", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OverTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Designation", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Basic", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("HRA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Conveyance", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Education", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MedicalAllowance", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AttBonus1_Per", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttendanceBonus", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AttBonus2_Per", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttendanceBonus2", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ExGratia", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PFEmpPer", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PFEmployee", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PFComPer", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PFCompany", typeof(double)));
			dataTable.Columns.Add(new DataColumn("PTAx", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TakeHome", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TakeHomeWithAttend1", typeof(double)));
			dataTable.Columns.Add(new DataColumn("TakeHomeWithAttend2", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Loyalty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("LTA", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Bonus", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Gratuity", typeof(double)));
			dataTable.Columns.Add(new DataColumn("VehicleAllowance", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CTC", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CTCAttendBonus1", typeof(double)));
			dataTable.Columns.Add(new DataColumn("CTCAttendBonus2", typeof(double)));
			for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet2.Tables[0].Rows[i]["EmpId"].ToString();
				dataRow[1] = dataSet2.Tables[0].Rows[i]["Title"].ToString() + " " + dataSet2.Tables[0].Rows[i]["EmployeeName"].ToString();
				num = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["salary"]);
				dataRow[2] = num;
				dataRow[3] = dataSet2.Tables[0].Rows[i]["DutyHrs"].ToString();
				dataRow[4] = dataSet2.Tables[0].Rows[i]["OTHrs"].ToString();
				dataRow[5] = dataSet2.Tables[0].Rows[i]["OverTime"].ToString();
				dataRow[6] = dataSet2.Tables[0].Rows[i]["Designation"].ToString();
				dataRow[7] = fun.Offer_Cal(num, 1, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["StaffType"]));
				dataRow[8] = fun.Offer_Cal(num, 2, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["StaffType"]));
				dataRow[9] = fun.Offer_Cal(num, 2, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["TypeOf"]));
				dataRow[10] = fun.Offer_Cal(num, 4, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["TypeOf"]));
				dataRow[11] = fun.Offer_Cal(num, 5, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["TypeOf"]));
				dataRow[12] = fun.Offer_Cal(num, 6, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["TypeOf"]));
				dataRow[13] = dataSet2.Tables[0].Rows[i]["AttBonusPer1"].ToString();
				double num2 = num * Convert.ToDouble(dataSet2.Tables[0].Rows[0]["AttBonusPer1"]) / 100.0;
				dataRow[14] = num2;
				dataRow[15] = dataSet2.Tables[0].Rows[i]["AttBonusPer2"].ToString();
				double num3 = num * Convert.ToDouble(dataSet2.Tables[0].Rows[0]["AttBonusPer2"]) / 100.0;
				dataRow[16] = num3;
				dataRow[17] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["ExGratia"]);
				dataRow[18] = dataSet2.Tables[0].Rows[i]["PFEmployee"].ToString();
				double num4 = fun.Pf_Cal(num, 1, Convert.ToDouble(dataSet2.Tables[0].Rows[0]["PFEmployee"]));
				dataRow[19] = num4;
				dataRow[20] = dataSet2.Tables[0].Rows[i]["PFCompany"].ToString();
				double num5 = fun.Pf_Cal(num, 2, Convert.ToDouble(dataSet2.Tables[0].Rows[0]["PFCompany"]));
				dataRow[21] = num5.ToString();
				double num6 = fun.PTax_Cal(num + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Bonus"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["ExGratia"]), "0");
				dataRow[22] = num6.ToString();
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				string cmdText = fun.select("*", "tblHR_Offer_Accessories", "MId='" + dataSet2.Tables[0].Rows[i]["OfferId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter2.Fill(dataSet3);
				for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
				{
					switch (dataSet3.Tables[0].Rows[j]["IncludesIn"].ToString())
					{
					case "1":
						num7 += Convert.ToDouble(dataSet3.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet3.Tables[0].Rows[j]["Amount"]);
						break;
					case "2":
						num8 += Convert.ToDouble(dataSet3.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet3.Tables[0].Rows[j]["Amount"]);
						break;
					case "3":
						num9 += Convert.ToDouble(dataSet3.Tables[0].Rows[j]["Qty"]) * Convert.ToDouble(dataSet3.Tables[0].Rows[j]["Amount"]);
						break;
					}
				}
				double num10 = Math.Round(num + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["ExGratia"]) + num8 + num9 - (num4 + num6));
				dataRow[23] = num10.ToString();
				double num11 = 0.0;
				dataRow[24] = Convert.ToDouble(decimal.Parse(Math.Round(num10 + num2).ToString()).ToString("N2"));
				double num12 = 0.0;
				dataRow[25] = Convert.ToDouble(decimal.Parse(Math.Round(num10 + num3).ToString()).ToString("N2"));
				dataRow[26] = dataSet2.Tables[0].Rows[i]["Loyalty"].ToString();
				dataRow[27] = dataSet2.Tables[0].Rows[i]["LTA"].ToString();
				dataRow[28] = dataSet2.Tables[0].Rows[i]["Bonus"].ToString();
				double num13 = fun.Gratuity_Cal(num, 1, Convert.ToInt32(dataSet2.Tables[0].Rows[i]["TypeOf"]));
				dataRow[29] = num13;
				dataRow[30] = Convert.ToDouble(dataSet2.Tables[0].Rows[i]["VehicleAllowance"]);
				double num14 = 0.0;
				num14 = Math.Round(num + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Bonus"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["Loyalty"]) + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["LTA"]) + num13 + num5 + Convert.ToDouble(dataSet2.Tables[0].Rows[i]["ExGratia"])) + num7 + num9;
				dataRow[31] = num14;
				double num15 = 0.0;
				dataRow[32] = decimal.Parse(Math.Round(num14 + num2).ToString()).ToString("N2");
				double num16 = 0.0;
				dataRow[33] = decimal.Parse(Math.Round(num14 + num3).ToString()).ToString("N2");
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			dataSet.Tables.Add(dataTable);
			if (dataTable == null)
			{
				throw new Exception("No Records to Export");
			}
			string text2 = "D:\\ImportExcelFromDatabase\\OfferData_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xls";
			FileInfo fileInfo = new FileInfo(text2);
			StringWriter stringWriter = new StringWriter();
			HtmlTextWriter writer = new HtmlTextWriter(stringWriter);
			DataGrid dataGrid = new DataGrid();
			dataGrid.DataSource = dataSet;
			dataGrid.DataBind();
			dataGrid.RenderControl(writer);
			string path = text2.Substring(0, text2.LastIndexOf("\\"));
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			StreamWriter streamWriter = new StreamWriter(text2, append: true);
			stringWriter.ToString().Normalize();
			streamWriter.Write(stringWriter.ToString());
			streamWriter.Flush();
			streamWriter.Close();
			WriteAttachment(fileInfo.Name, "application/vnd.ms-excel", stringWriter.ToString());
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
			sqlConnection.Dispose();
		}
	}

	public static void WriteAttachment(string FileName, string FileType, string content)
	{
		try
		{
			HttpResponse response = HttpContext.Current.Response;
			response.ClearHeaders();
			response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
			response.ContentType = FileType;
			response.Write(content);
			response.End();
		}
		catch (Exception)
		{
		}
	}
}
