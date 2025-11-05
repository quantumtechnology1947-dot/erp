using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_MobileBills_Edit : Page, IRequiresSessionState
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
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		string text = Session["username"].ToString();
		int num = Convert.ToInt32(Session["compid"]);
		int num2 = Convert.ToInt32(Session["finyear"]);
		if (!(e.CommandName == "Update"))
		{
			return;
		}
		sqlConnection.Open();
		try
		{
			int num3 = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					string value = decimal.Parse(((TextBox)row.FindControl("TxtBillAmt")).Text.ToString()).ToString("N2");
					Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					string selectedValue = ((DropDownList)row.FindControl("DDLTaxes")).SelectedValue;
					string text2 = ((Label)row.FindControl("lblEmpId")).Text;
					string cmdText = fun.select("Id", "tblHR_MobileBill", "CompId='" + num + "' AND FinYearId='" + num2 + "' AND EmpId='" + text2 + "'And BillMonth='" + DropDownList1.SelectedValue + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
					DataSet dataSet = new DataSet();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet, "tblHR_MobileBill");
					int num4 = Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString());
					string cmdText2 = fun.update("tblHR_MobileBill", "SysDate='" + currDate + "',SysTime='" + currTime + "',CompId='" + num + "',FinYearId='" + num2 + "',SessionId='" + text + "',EmpId='" + text2 + "',BillMonth='" + DropDownList1.SelectedValue + "',BillAmt='" + Convert.ToDouble(value) + "',Taxes='" + Convert.ToDouble(selectedValue) + "'", "CompId='" + num + "' AND FinYearId='" + num2 + "' AND EmpId='" + text2 + "'And BillMonth='" + DropDownList1.SelectedValue + "' AND Id='" + num4 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					num3++;
				}
			}
			if (num3 > 0)
			{
				string selectedValue2 = DropDownList1.SelectedValue;
				string text3 = "Record is Updated";
				base.Response.Redirect("MobileBills_Edit.aspx?m=" + selectedValue2 + "&n=" + text3 + "&ModId=12&SubModId=50");
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
				((Label)row.FindControl("lblBillAmt")).Visible = false;
				((Label)row.FindControl("lblTaxes")).Visible = false;
				((RegularExpressionValidator)row.FindControl("RegularExpressionValidator1")).Visible = true;
				((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
			}
			else
			{
				((TextBox)row.FindControl("TxtBillAmt")).Visible = false;
				((DropDownList)row.FindControl("DDLTaxes")).Visible = false;
				((Label)row.FindControl("lblBillAmt")).Visible = true;
				((Label)row.FindControl("lblTaxes")).Visible = true;
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
			string text = Session["compid"].ToString();
			int num = Convert.ToInt32(DropDownList1.SelectedValue);
			string text2 = Session["finyear"].ToString();
			if (DropDownList1.SelectedItem.Text != "Select")
			{
				GridView1.Visible = true;
				string cmdText = fun.select("tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.EmpId,tblHR_OfficeStaff.EmployeeName,tblHR_CoporateMobileNo.Id ,tblHR_CoporateMobileNo.MobileNo, tblHR_CoporateMobileNo.LimitAmt", " tblHR_OfficeStaff,tblHR_CoporateMobileNo,tblHR_MobileBill", "tblHR_MobileBill.EmpId=tblHR_OfficeStaff.EmpId and tblHR_OfficeStaff.MobileNo = tblHR_CoporateMobileNo.Id and tblHR_MobileBill.FinYearId='" + text2 + "' and tblHR_MobileBill.BillMonth='" + DropDownList1.SelectedValue + "' And tblHR_OfficeStaff.MobileNo!=1 and tblHR_MobileBill.CompId='" + text + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				GridView1.DataSource = dataSet;
				GridView1.DataBind();
				{
					foreach (GridViewRow row in GridView1.Rows)
					{
						string text3 = ((Label)row.FindControl("lblEmpId")).Text;
						string cmdText2 = fun.select("BillAmt", "tblHR_MobileBill", "tblHR_MobileBill.BillMonth='" + num + "' AND CompId='" + text + "' AND EmpId='" + text3 + "' And FinYearId='" + text2 + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
						DataSet dataSet2 = new DataSet();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						sqlDataAdapter2.Fill(dataSet2, "tblHR_MobileBill");
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							((TextBox)row.FindControl("TxtBillAmt")).Text = dataSet2.Tables[0].Rows[0][0].ToString();
							((Label)row.FindControl("lblBillAmt")).Visible = true;
							((TextBox)row.FindControl("TxtBillAmt")).Visible = false;
							((Label)row.FindControl("lblExcessAmount")).Visible = true;
							string cmdText3 = fun.select("Id", "tblHR_MobileBill", "CompId='" + text + "' AND FinYearId='" + text2 + "' AND EmpId='" + text3 + "'And BillMonth='" + DropDownList1.SelectedValue + "'");
							SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
							DataSet dataSet3 = new DataSet();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							sqlDataAdapter3.Fill(dataSet3, "tblHR_MobileBill");
							int num2 = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString());
							string cmdText4 = fun.select("tblExciseser_Master.Value,tblExciseser_Master.Id", "tblExciseser_Master,tblHR_MobileBill", "tblExciseser_Master.Id=tblHR_MobileBill.Taxes AND tblHR_MobileBill.Id='" + num2 + "'");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
							DataSet dataSet4 = new DataSet();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							sqlDataAdapter4.Fill(dataSet4, "tblExciseser_Master");
							dataSet4.Tables[0].Rows[0][0].ToString();
							((DropDownList)row.FindControl("DDLTaxes")).SelectedValue = dataSet4.Tables[0].Rows[0]["Id"].ToString();
							((DropDownList)row.FindControl("DDLTaxes")).SelectedItem.Text = dataSet4.Tables[0].Rows[0]["Value"].ToString();
							double num3 = Convert.ToDouble(((Label)row.FindControl("lblLimitAmt")).Text);
							string value = (((Label)row.FindControl("lblBillAmt")).Text = dataSet2.Tables[0].Rows[0][0].ToString());
							double num4 = Convert.ToDouble(value);
							string value2 = (((Label)row.FindControl("lblTaxes")).Text = dataSet4.Tables[0].Rows[0][0].ToString());
							double num5 = Convert.ToDouble(value2);
							double num6 = num4 * 100.0 / (num5 + 100.0);
							if (num6 - num3 > 0.0)
							{
								((Label)row.FindControl("lblExcessAmount")).Text = Convert.ToString(Math.Round(num6 - num3, 2));
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

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		DDLMonth();
	}
}
