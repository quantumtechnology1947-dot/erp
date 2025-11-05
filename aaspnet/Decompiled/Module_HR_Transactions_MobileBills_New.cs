using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_MobileBills_New : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected GridView GridView1;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		getValData();
		if (!base.IsPostBack)
		{
			string connectionString = fun.Connection();
			new SqlConnection(connectionString);
			try
			{
				new DataSet();
				int compId = Convert.ToInt32(Session["compid"]);
				int finYearId = Convert.ToInt32(Session["finyear"]);
				fun.GetMonth(DropDownList1, compId, finYearId);
			}
			catch (Exception)
			{
			}
			lblMessage.Text = "";
			if (base.Request.QueryString["m"] != null)
			{
				string selectedValue = base.Request.QueryString["m"].ToString();
				DropDownList1.SelectedValue = selectedValue;
				lblMessage.Text = base.Request.QueryString["n"].ToString();
				DDLMonth();
			}
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		if (!(e.CommandName == "Insert"))
		{
			return;
		}
		sqlConnection.Open();
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			int num3 = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((TextBox)row.FindControl("TxtBillAmt")).Text != "")
				{
					string text2 = decimal.Parse(((TextBox)row.FindControl("TxtBillAmt")).Text.ToString()).ToString("N2");
					Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					string selectedValue = ((DropDownList)row.FindControl("DDLTaxes")).SelectedValue;
					string text3 = ((Label)row.FindControl("lblEmpId")).Text;
					string text4 = decimal.Parse(((Label)row.FindControl("lblLimitAmt")).Text.ToString()).ToString("N2");
					if (((CheckBox)row.FindControl("CheckBox1")).Checked && selectedValue != "" && text2 != "" && text4 != "0")
					{
						string cmdText = fun.insert("tblHR_MobileBill", "SysDate,SysTime,CompId,FinYearId,SessionId,EmpId,BillMonth,BillAmt,Taxes ", "'" + currDate + "','" + currTime + "','" + num + "','" + num2 + "','" + text + "','" + text3 + "','" + DropDownList1.SelectedValue + "','" + Convert.ToDouble(text2) + "','" + Convert.ToDouble(selectedValue) + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						num3++;
					}
				}
			}
			if (num3 > 0)
			{
				string selectedValue2 = DropDownList1.SelectedValue;
				string text5 = "Record is Inserted";
				base.Response.Redirect("MobileBills_New.aspx?m=" + selectedValue2 + "&n=" + text5 + "&ModId=12&SubModId=50");
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

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		getValData();
	}

	public void getValData()
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((CheckBox)row.FindControl("CheckBox1")).Checked)
			{
				((TextBox)row.FindControl("TxtBillAmt")).Visible = true;
				((DropDownList)row.FindControl("DDLTaxes")).Visible = true;
				((RegularExpressionValidator)row.FindControl("RegularExpressionValidator1")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
			}
			else
			{
				((TextBox)row.FindControl("TxtBillAmt")).Visible = false;
				((DropDownList)row.FindControl("DDLTaxes")).Visible = false;
				((RegularExpressionValidator)row.FindControl("RegularExpressionValidator1")).Visible = false;
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = false;
			}
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		DDLMonth();
	}

	public void DDLMonth()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			if (DropDownList1.SelectedItem.Text != "Select")
			{
				GridView1.Visible = true;
				string cmdText = fun.select("tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.EmpId,tblHR_OfficeStaff.EmployeeName,tblHR_CoporateMobileNo.Id ,tblHR_CoporateMobileNo.MobileNo, tblHR_CoporateMobileNo.LimitAmt", "tblHR_OfficeStaff,tblHR_CoporateMobileNo", "tblHR_OfficeStaff.MobileNo = tblHR_CoporateMobileNo.Id And tblHR_OfficeStaff.MobileNo!=1 And tblHR_OfficeStaff.CompId='" + num + "' AND tblHR_CoporateMobileNo.LimitAmt>0");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				GridView1.DataSource = dataSet;
				GridView1.DataBind();
				int num3 = Convert.ToInt32(DropDownList1.SelectedValue);
				{
					foreach (GridViewRow row in GridView1.Rows)
					{
						string text = ((Label)row.FindControl("lblEmpId")).Text;
						string cmdText2 = fun.select("BillAmt", "tblHR_MobileBill", "BillMonth='" + num3 + "' AND CompId='" + num + "' AND EmpId='" + text + "' And FinYearId='" + num2 + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
						DataSet dataSet2 = new DataSet();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						sqlDataAdapter2.Fill(dataSet2, "tblHR_MobileBill");
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							((Label)row.FindControl("lblBillAmt")).Text = dataSet2.Tables[0].Rows[0][0].ToString();
							((TextBox)row.FindControl("TxtBillAmt")).Visible = false;
							((CheckBox)row.FindControl("CheckBox1")).Visible = false;
							((Label)row.FindControl("lblExcessAmount")).Visible = true;
							string cmdText3 = fun.select("Id", "tblHR_MobileBill", "CompId='" + num + "' AND FinYearId='" + num2 + "' AND EmpId='" + text + "'And BillMonth='" + DropDownList1.SelectedValue + "'");
							SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
							DataSet dataSet3 = new DataSet();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							sqlDataAdapter3.Fill(dataSet3, "tblHR_MobileBill");
							int num4 = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString());
							string cmdText4 = fun.select("tblExciseser_Master.Value", "tblExciseser_Master,tblHR_MobileBill", " tblExciseser_Master.Id=tblHR_MobileBill.Taxes AND tblHR_MobileBill.Id='" + num4 + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
							DataSet dataSet4 = new DataSet();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							sqlDataAdapter4.Fill(dataSet4, "tblExciseser_Master");
							double num5 = 0.0;
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								((Label)row.FindControl("lblTaxes")).Text = dataSet4.Tables[0].Rows[0][0].ToString();
								string value = (((Label)row.FindControl("lblTaxes")).Text = dataSet4.Tables[0].Rows[0][0].ToString());
								num5 = Convert.ToDouble(value);
							}
							double num6 = Convert.ToDouble(((Label)row.FindControl("lblLimitAmt")).Text);
							string value2 = (((Label)row.FindControl("lblBillAmt")).Text = dataSet2.Tables[0].Rows[0][0].ToString());
							double num7 = Convert.ToDouble(value2);
							double num8 = num7 - num7 * num5 / (num5 + 100.0);
							if (num8 - num6 > 0.0)
							{
								((Label)row.FindControl("lblExcessAmount")).Text = Convert.ToString(Math.Round(num8 - num6, 2));
							}
							else
							{
								((Label)row.FindControl("lblExcessAmount")).Text = "0";
							}
						}
						else
						{
							((CheckBox)row.FindControl("CheckBox1")).Visible = true;
						}
						string cmdText5 = fun.select("Id", "tblExciseser_Master", "Live = 1");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
						DataSet dataSet5 = new DataSet();
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						sqlDataAdapter5.Fill(dataSet5, "tblExciseser_Master");
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							((DropDownList)row.FindControl("DDLTaxes")).SelectedValue = dataSet5.Tables[0].Rows[0][0].ToString();
						}
					}
					return;
				}
			}
			GridView1.Visible = false;
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		DDLMonth();
	}
}
