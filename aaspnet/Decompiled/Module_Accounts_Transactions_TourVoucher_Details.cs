using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_TourVoucher_Details : Page, IRequiresSessionState
{
	protected Label lblEmpName;

	protected Label lblWONoBGGroup;

	protected Label lblWONoBGGroup1;

	protected Label lblProjectName;

	protected Label lblPlaceOfTour;

	protected Label lblSDate;

	protected Label lblSTime;

	protected Label lblEDate;

	protected Label lblETime;

	protected Label lblNoOfDays;

	protected Label lblNameAndAddress;

	protected Label lblContactPerson;

	protected Label lblContactNo;

	protected Label lblEmail;

	protected GridView GridView2;

	protected Panel Panel3;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected Panel Panel4;

	protected TabPanel TabPanel2;

	protected TabContainer TabContainer1;

	protected Label lblTAmt;

	protected Label lblTAmt1;

	protected Label lblTSAmt;

	protected Label lblTSAmt1;

	protected Label Label2;

	protected TextBox txtAmtBalTowardsCompany;

	protected RequiredFieldValidator ReqtxtAmtBalTowardsCompany;

	protected RegularExpressionValidator RegtxtAmtBalTowardsCompany;

	protected Label Label3;

	protected TextBox txtAmtBalTowardsEmployee;

	protected RequiredFieldValidator ReqtxtAmtBalTowardsEmployee;

	protected RegularExpressionValidator RegtxtAmtBalTowardsEmployee;

	protected Button btnSum;

	protected Button btnSubmit;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	private int id;

	private double TLab;

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
			if (base.IsPostBack)
			{
				return;
			}
			string cmdText = fun.select("*", "tblACC_TourIntimation_Master", "Id='" + id + "'  And   CompId='" + CompId + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			string selectCommandText = fun.select("Title+'. '+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[0]["EmpId"], "'"));
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommandText, con);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2, "tblHR_OfficeStaff");
			lblEmpName.Text = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "NA")
			{
				lblWONoBGGroup.Text = "BG Group";
				int num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["BGGroupId"].ToString());
				string cmdText2 = fun.select("Name,Symbol", " BusinessGroup", "Id='" + num + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "BusinessGroup");
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					lblWONoBGGroup1.Text = dataSet3.Tables[0].Rows[0]["Name"].ToString() + " [ " + dataSet3.Tables[0].Rows[0]["Symbol"].ToString() + " ]";
				}
			}
			else
			{
				lblWONoBGGroup.Text = "WO No";
				lblWONoBGGroup1.Text = dataSet.Tables[0].Rows[0]["WONo"].ToString();
			}
			lblProjectName.Text = dataSet.Tables[0].Rows[0]["ProjectName"].ToString();
			string cmdText3 = fun.select("CityName", "tblCity", string.Concat("CityId='", dataSet.Tables[0].Rows[0]["PlaceOfTourCity"], "'"));
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			string cmdText4 = fun.select("StateName", "tblState", string.Concat("SId='", dataSet.Tables[0].Rows[0]["PlaceOfTourState"], "' "));
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			string cmdText5 = fun.select("CountryName", "tblCountry", string.Concat("CId='", dataSet.Tables[0].Rows[0]["PlaceOfTourCountry"], "' "));
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet6 = new DataSet();
			sqlDataAdapter6.Fill(dataSet6);
			string text = "";
			if (dataSet4.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows.Count > 0 && dataSet6.Tables[0].Rows.Count > 0)
			{
				text = dataSet6.Tables[0].Rows[0]["CountryName"].ToString() + ", " + dataSet5.Tables[0].Rows[0]["StateName"].ToString() + ", " + dataSet4.Tables[0].Rows[0]["CityName"].ToString();
			}
			lblPlaceOfTour.Text = text;
			lblSDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["TourStartDate"].ToString());
			lblSTime.Text = dataSet.Tables[0].Rows[0]["TourStartTime"].ToString();
			lblEDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0]["TourEndDate"].ToString());
			lblETime.Text = dataSet.Tables[0].Rows[0]["TourEndTime"].ToString();
			lblNoOfDays.Text = dataSet.Tables[0].Rows[0]["NoOfDays"].ToString();
			lblNameAndAddress.Text = dataSet.Tables[0].Rows[0]["NameAddressSerProvider"].ToString();
			lblContactPerson.Text = dataSet.Tables[0].Rows[0]["ContactPerson"].ToString();
			lblContactNo.Text = dataSet.Tables[0].Rows[0]["ContactNo"].ToString();
			lblEmail.Text = dataSet.Tables[0].Rows[0]["Email"].ToString();
			FillGridAdvanceTo();
			fillgrid();
			lblTAmt1.Text = TLab.ToString();
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
			dataTable.Columns.Add(new DataColumn("TADId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Terms", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ExpencessId", typeof(int)));
			double num = 0.0;
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
					dataRow[1] = dataSet.Tables[0].Rows[i]["Terms"].ToString();
					string cmdText2 = fun.select("*", "tblACC_TourAdvance_Details", "ExpencessId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]) + "' AND MId='" + id + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Amount"]);
						dataRow[3] = dataSet2.Tables[0].Rows[0]["Remarks"].ToString();
						dataRow[4] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ExpencessId"]);
						num += Convert.ToDouble(dataSet2.Tables[0].Rows[0]["Amount"]);
					}
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			if (GridView2.Rows.Count > 0)
			{
				((Label)GridView2.FooterRow.FindControl("lblADTotalAmount")).Text = num.ToString();
			}
			TLab += num;
		}
		catch (Exception)
		{
		}
	}

	public void FillGridAdvanceTo()
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string cmdText = fun.select("*", "tblACC_TourAdvance", "MId='" + id + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("TATId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			double num = 0.0;
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
				num += Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			if (GridView1.Rows.Count > 0)
			{
				((Label)GridView1.FooterRow.FindControl("lblATTotalAmount")).Text = num.ToString();
			}
			TLab += num;
		}
		catch (Exception)
		{
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			con.Open();
			string cmdText = fun.select("TVNo", "tblACC_TourVoucher_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblACC_TourVoucher_Master");
			string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = 0;
			int num2 = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				num2++;
				if (((TextBox)row.FindControl("txtAmount")).Text != "")
				{
					num++;
				}
			}
			int num3 = 0;
			int num4 = 0;
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				num4++;
				if (((TextBox)row2.FindControl("txtATAmount")).Text != "")
				{
					num3++;
				}
			}
			if (txtAmtBalTowardsCompany.Text != "" && fun.NumberValidationQty(txtAmtBalTowardsCompany.Text) && txtAmtBalTowardsEmployee.Text != "" && fun.NumberValidationQty(txtAmtBalTowardsEmployee.Text) && num2 - num == 0 && num4 - num3 == 0)
			{
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				if (GridView2.Rows.Count > 0)
				{
					num8 = Convert.ToDouble(((Label)GridView2.FooterRow.FindControl("lblADTotalAmount")).Text);
				}
				if (GridView1.Rows.Count > 0)
				{
					num9 = Convert.ToDouble(((Label)GridView1.FooterRow.FindControl("lblATTotalAmount")).Text);
				}
				num7 = Math.Round(num8 + num9, 2);
				double num10 = 0.0;
				foreach (GridViewRow row3 in GridView2.Rows)
				{
					num10 += Convert.ToDouble(((TextBox)row3.FindControl("txtAmount")).Text);
				}
				double num11 = 0.0;
				foreach (GridViewRow row4 in GridView1.Rows)
				{
					num11 += Convert.ToDouble(((TextBox)row4.FindControl("txtATAmount")).Text);
				}
				double num12 = 0.0;
				num12 = Math.Round(num10 + num11, 2);
				if (num7 - num12 > 0.0)
				{
					txtAmtBalTowardsEmployee.Text = (num7 - num12).ToString();
					txtAmtBalTowardsCompany.Text = "0";
				}
				else
				{
					txtAmtBalTowardsCompany.Text = (num12 - num7).ToString();
					txtAmtBalTowardsEmployee.Text = "0";
				}
				num5 = Convert.ToDouble(decimal.Parse(txtAmtBalTowardsCompany.Text).ToString("N2"));
				num6 = Convert.ToDouble(decimal.Parse(txtAmtBalTowardsEmployee.Text).ToString("N2"));
				string cmdText2 = fun.insert("tblACC_TourVoucher_Master", "TIMId,SysDate , SysTime , SessionId, CompId , FinYearId ,TVNo , AmtBalTowardsCompany, AmtBalTowardsEmployee", "'" + id + "','" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + num5 + "','" + num6 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText3 = fun.select("Id", "tblACC_TourVoucher_Master", "CompId='" + CompId + "' Order by Id desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblACC_TourIntimation_Master");
				int num13 = 0;
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					num13 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"].ToString());
				}
				foreach (GridViewRow row5 in GridView2.Rows)
				{
					int num14 = Convert.ToInt32(((Label)row5.FindControl("lblTADId")).Text);
					string text2 = ((TextBox)row5.FindControl("txtRemarks")).Text;
					if (((TextBox)row5.FindControl("txtAmount")).Text != "" && Convert.ToDouble(decimal.Parse(((TextBox)row5.FindControl("txtAmount")).Text).ToString("N2")) >= 0.0)
					{
						double num15 = Convert.ToDouble(decimal.Parse(((TextBox)row5.FindControl("txtAmount")).Text).ToString("N2"));
						string cmdText4 = fun.insert("tblACC_TourVoucherAdvance_Details", "MId,TDMId,SanctionedAmount,Remarks", "'" + num13 + "','" + num14 + "','" + num15 + "','" + text2 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
					}
				}
				foreach (GridViewRow row6 in GridView1.Rows)
				{
					int num16 = Convert.ToInt32(((Label)row6.FindControl("lblTATId")).Text);
					string text3 = ((TextBox)row6.FindControl("txtATRemarks")).Text;
					if (((TextBox)row6.FindControl("txtATAmount")).Text != "" && Convert.ToDouble(decimal.Parse(((TextBox)row6.FindControl("txtATAmount")).Text).ToString("N2")) >= 0.0)
					{
						double num17 = Convert.ToDouble(decimal.Parse(((TextBox)row6.FindControl("txtATAmount")).Text).ToString("N2"));
						string cmdText5 = fun.insert("tblACC_TourVoucherAdvance", "MId,TAMId,SanctionedAmount,Remarks", "'" + num13 + "','" + num16 + "','" + num17 + "','" + text3 + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
						con.Open();
						sqlCommand3.ExecuteNonQuery();
						con.Close();
					}
				}
				base.Response.Redirect("TourVoucher.aspx?ModId=11&SubModId=126");
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid data entry.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TourVoucher.aspx?ModId=11&SubModId=126");
	}

	protected void btnSum_Click(object sender, EventArgs e)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			if (GridView2.Rows.Count > 0)
			{
				num2 = Convert.ToDouble(((Label)GridView2.FooterRow.FindControl("lblADTotalAmount")).Text);
			}
			if (GridView1.Rows.Count > 0)
			{
				num3 = Convert.ToDouble(((Label)GridView1.FooterRow.FindControl("lblATTotalAmount")).Text);
			}
			num = Math.Round(num2 + num3, 2);
			double num4 = 0.0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				num4 += Convert.ToDouble(((TextBox)row.FindControl("txtAmount")).Text);
			}
			double num5 = 0.0;
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				num5 += Convert.ToDouble(((TextBox)row2.FindControl("txtATAmount")).Text);
			}
			double num6 = 0.0;
			num6 = Math.Round(num4 + num5, 2);
			if (num - num6 > 0.0)
			{
				txtAmtBalTowardsEmployee.Text = (num - num6).ToString();
				txtAmtBalTowardsCompany.Text = "0";
			}
			else
			{
				txtAmtBalTowardsCompany.Text = (num6 - num).ToString();
				txtAmtBalTowardsEmployee.Text = "0";
			}
			lblTSAmt1.Text = num6.ToString();
		}
		catch (Exception)
		{
		}
	}
}
