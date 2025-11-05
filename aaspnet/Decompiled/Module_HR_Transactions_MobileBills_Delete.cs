using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_MobileBills_Delete : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected DropDownList DropDownList1;

	protected GridView GridView1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		fun.getCurrDate();
		fun.getCurrTime();
		Session["username"].ToString();
		int num = Convert.ToInt32(Session["compid"]);
		int num2 = Convert.ToInt32(Session["finyear"]);
		if (!(e.CommandName == "Del"))
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
					_ = ((TextBox)row.FindControl("TxtBillAmt")).Text;
					Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					_ = ((DropDownList)row.FindControl("DDLTaxes")).SelectedValue;
					string text = ((Label)row.FindControl("lblEmpId")).Text;
					string cmdText = fun.select("Id", "tblHR_MobileBill", "CompId='" + num + "' AND FinYearId='" + num2 + "' AND EmpId='" + text + "'And BillMonth='" + DropDownList1.SelectedValue + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
					DataSet dataSet = new DataSet();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					sqlDataAdapter.Fill(dataSet, "tblHR_MobileBill");
					int num4 = 0;
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						num4 = Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString());
					}
					string cmdText2 = fun.delete("tblHR_MobileBill", "CompId='" + num + "' AND FinYearId='" + num2 + "' AND EmpId='" + text + "'And BillMonth='" + DropDownList1.SelectedValue + "' AND Id='" + num4 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					num3++;
				}
			}
			if (num3 > 0)
			{
				string selectedValue = DropDownList1.SelectedValue;
				string text2 = "Record is Deleted";
				base.Response.Redirect("MobileBills_Delete.aspx?m=" + selectedValue + "&n=" + text2 + "&ModId=12&SubModId=50");
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

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			if (((CheckBox)row.FindControl("CheckBox1")).Checked)
			{
				((Label)row.FindControl("lblBillAmt")).Visible = true;
				((Label)row.FindControl("lblTaxes")).Visible = true;
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
			if (DropDownList1.SelectedItem.Text != "Select")
			{
				GridView1.Visible = true;
				int num = Convert.ToInt32(Session["compid"]);
				int num2 = Convert.ToInt32(Session["finyear"]);
				string cmdText = fun.select("tblHR_OfficeStaff.UserID,tblHR_OfficeStaff.EmpId,tblHR_OfficeStaff.EmployeeName,tblHR_CoporateMobileNo.Id ,tblHR_CoporateMobileNo.MobileNo, tblHR_CoporateMobileNo.LimitAmt", " tblHR_OfficeStaff,tblHR_CoporateMobileNo,tblHR_MobileBill", "tblHR_MobileBill.EmpId=tblHR_OfficeStaff.EmpId and tblHR_OfficeStaff.MobileNo = tblHR_CoporateMobileNo.Id And tblHR_OfficeStaff.MobileNo!=1 and tblHR_MobileBill.BillMonth='" + DropDownList1.SelectedValue + "'and tblHR_MobileBill.FinYearId='" + num2 + "'And tblHR_MobileBill.CompId='" + num + "'");
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
						string cmdText2 = fun.select("BillAmt", "tblHR_MobileBill", "tblHR_MobileBill.BillMonth='" + num3 + "' AND CompId='" + num + "' AND EmpId='" + text + "'");
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
							string cmdText3 = fun.select("Id", "tblHR_MobileBill ", "CompId='" + num + "' AND FinYearId='" + num2 + "' AND EmpId='" + text + "'And BillMonth='" + DropDownList1.SelectedValue + "'");
							SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
							DataSet dataSet3 = new DataSet();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
							sqlDataAdapter3.Fill(dataSet3, "tblHR_MobileBill");
							int num4 = 0;
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								num4 = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString());
							}
							double num5 = 0.0;
							string cmdText4 = fun.select("tblExciseser_Master.Value,tblExciseser_Master.Id", "tblExciseser_Master,tblHR_MobileBill", "tblExciseser_Master.Id=tblHR_MobileBill.Taxes AND tblHR_MobileBill.Id='" + num4 + "' ");
							SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
							DataSet dataSet4 = new DataSet();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
							sqlDataAdapter4.Fill(dataSet4, "tblExciseser_Master");
							if (dataSet4.Tables[0].Rows.Count > 0)
							{
								((DropDownList)row.FindControl("DDLTaxes")).SelectedValue = dataSet4.Tables[0].Rows[0]["Id"].ToString();
								((DropDownList)row.FindControl("DDLTaxes")).SelectedItem.Text = dataSet4.Tables[0].Rows[0]["Value"].ToString();
								string value = (((Label)row.FindControl("lblTaxes")).Text = dataSet4.Tables[0].Rows[0][0].ToString());
								num5 = Convert.ToDouble(value);
							}
							double num6 = Convert.ToDouble(((Label)row.FindControl("lblLimitAmt")).Text);
							string value2 = (((Label)row.FindControl("lblBillAmt")).Text = dataSet2.Tables[0].Rows[0][0].ToString());
							double num7 = Convert.ToDouble(value2);
							double num8 = num7 * 100.0 / (num5 + 100.0);
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
