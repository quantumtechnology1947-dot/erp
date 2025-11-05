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

public class Module_Scheduler_GatePass_New : Page, IRequiresSessionState
{
	protected SqlDataSource SqlDataSource1;

	protected SqlDataSource SqlDataSource2;

	protected GridView GridView3;

	protected Button BtnSubmit;

	protected TabPanel TabPanel1;

	protected GridView GridView1;

	protected Button Button2;

	protected TabPanel TabPanel2;

	protected GridView GridView2;

	protected UpdatePanel UpdatePanel1;

	protected TabPanel TabPanel3;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private string sId = string.Empty;

	private int FinYearId;

	private int CompId;

	private string connStr = string.Empty;

	private SqlConnection con;

	private string CDate = string.Empty;

	private string CTime = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString().Trim();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				loaddata();
				loadGrid();
				FillGrid();
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("lblId1")).Text;
				string cmdText = fun.select("Authorize", "tblGate_Pass", "  Id='" + text + "' And Authorize='1'  And CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					((TextBox)row.FindControl("TxtFeedback")).Visible = true;
					((LinkButton)row.FindControl("LinkButton3")).Visible = false;
				}
				else
				{
					((TextBox)row.FindControl("TxtFeedback")).Visible = false;
					((LinkButton)row.FindControl("LinkButton3")).Visible = true;
				}
				string text2 = ((Label)row.FindControl("lblDId")).Text;
				string cmdText2 = fun.select("Feedback", "tblGatePass_Details", "  MId='" + text + "' And Id='" + text2 + "'  ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					if (dataSet2.Tables[0].Rows[0]["Feedback"] != DBNull.Value && dataSet2.Tables[0].Rows[0]["Feedback"].ToString() != "")
					{
						((Label)row.FindControl("LblFeedback")).Visible = true;
						((TextBox)row.FindControl("TxtFeedback")).Visible = false;
					}
					else
					{
						((Label)row.FindControl("LblFeedback")).Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		try
		{
			string cmdText = fun.select("*", "tblGatePass_Temp", "  EmpId is  null  And SessionId='" + sId + "' And CompId='" + CompId + "'   Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Place", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOf", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeFor", typeof(string)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = fun.FromDate(dataSet.Tables[0].Rows[i]["FromDate"].ToString());
					dataRow[2] = dataSet.Tables[0].Rows[i]["FromTime"].ToString();
					dataRow[3] = dataSet.Tables[0].Rows[i]["ToTime"].ToString();
					dataRow[4] = dataSet.Tables[0].Rows[i]["Place"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["ContactPerson"].ToString();
					dataRow[6] = dataSet.Tables[0].Rows[i]["ContactNo"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
					string cmdText2 = fun.select("*", "tblGatePass_Reason", "Id='" + dataSet.Tables[0].Rows[i]["Type"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[8] = dataSet2.Tables[0].Rows[0]["Reason"].ToString();
					string value = "";
					if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
					{
						value = "WONo";
					}
					if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
					{
						value = "Enquiry";
					}
					if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "3")
					{
						value = "Others";
					}
					dataRow[9] = value;
					dataRow[10] = dataSet.Tables[0].Rows[i]["TypeFor"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
			if (GridView3.Rows.Count == 0)
			{
				((TextBox)GridView3.Controls[0].Controls[0].FindControl("TxtDate2")).Attributes.Add("readonly", "readonly");
			}
			else
			{
				((TextBox)GridView3.FooterRow.FindControl("TxtDate1")).Attributes.Add("readonly", "readonly");
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadGrid()
	{
		try
		{
			string cmdText = fun.select("*", "tblGatePass_Temp", " EmpId is  not null And  SessionId='" + sId + "' And CompId='" + CompId + "'   Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Place", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactPerson", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ContactNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeOf", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeFor", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDate(dataSet.Tables[0].Rows[i]["FromDate"].ToString());
				dataRow[2] = dataSet.Tables[0].Rows[i]["FromTime"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["ToTime"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["Place"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["ContactPerson"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["ContactNo"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
				string cmdText2 = fun.select("*", "tblGatePass_Reason", "Id='" + dataSet.Tables[0].Rows[i]["Type"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				dataRow[8] = dataSet2.Tables[0].Rows[0]["Reason"].ToString();
				string value = "";
				if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
				{
					value = "WONo";
				}
				if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
				{
					value = "Enquiry";
				}
				if (dataSet.Tables[0].Rows[i]["TypeOf"].ToString() == "3")
				{
					value = "Others";
				}
				dataRow[9] = value;
				dataRow[10] = dataSet.Tables[0].Rows[i]["TypeFor"].ToString();
				if (dataSet.Tables[0].Rows[i]["EmpId"] != DBNull.Value)
				{
					string cmdText3 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["EmpId"].ToString() + "'And CompId='" + CompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[11] = dataSet3.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				else
				{
					dataRow[11] = "";
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			if (GridView1.Rows.Count == 0)
			{
				((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtDate4")).Attributes.Add("readonly", "readonly");
			}
			else
			{
				((TextBox)GridView1.FooterRow.FindControl("TxtDate3")).Attributes.Add("readonly", "readonly");
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			string cmdText = fun.select("tblGate_Pass.Authorize,tblGate_Pass.SysDate,tblGate_Pass.EmpId As SelfEId,tblGate_Pass.Id,tblGate_Pass.FinYearId,tblGate_Pass.GPNo,tblGate_Pass.Authorize,tblGate_Pass.AuthorizedBy,tblGate_Pass.AuthorizeDate,tblGate_Pass.AuthorizeTime,tblGatePass_Details.FromDate,tblGatePass_Details.FromTime,tblGatePass_Details.ToTime,tblGatePass_Details.Type,tblGatePass_Details.TypeFor,tblGatePass_Details.Reason,tblGatePass_Details.Feedback,tblGatePass_Details.Id As DId,tblGatePass_Details.EmpId As OtherEId", "tblGate_Pass,tblGatePass_Details", "tblGate_Pass.Id=tblGatePass_Details.MId And tblGate_Pass.SessionId='" + sId + "' And tblGatePass_Details.Feedback is null AND  tblGate_Pass.CompId='" + CompId + "'   Order By tblGate_Pass.Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GPNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FromTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ToTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TypeFor", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizedBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizeDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizeTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Feedback", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SelfEId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Authorize", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					string value = "";
					string value2 = "";
					string value3 = "";
					string cmdText2 = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet2.Tables[0].Rows[0]["FinYear"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["GPNo"].ToString();
					dataRow[3] = fun.FromDate(dataSet.Tables[0].Rows[i]["FromDate"].ToString());
					dataRow[4] = dataSet.Tables[0].Rows[i]["FromTime"].ToString();
					dataRow[5] = dataSet.Tables[0].Rows[i]["ToTime"].ToString();
					dataRow[7] = dataSet.Tables[0].Rows[i]["TypeFor"].ToString();
					dataRow[8] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
					string cmdText3 = fun.select("*", "tblGatePass_Reason", "Id='" + dataSet.Tables[0].Rows[i]["Type"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					dataRow[6] = dataSet3.Tables[0].Rows[0]["Reason"].ToString();
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Authorize"]) == 1)
					{
						string cmdText4 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["AuthorizedBy"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						value = dataSet4.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet4.Tables[0].Rows[0]["EmployeeName"].ToString();
						value2 = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["AuthorizeDate"].ToString());
						value3 = dataSet.Tables[0].Rows[i]["AuthorizeTime"].ToString();
					}
					dataRow[9] = value;
					dataRow[10] = value2;
					dataRow[11] = value3;
					if (dataSet.Tables[0].Rows[i]["Feedback"] != DBNull.Value)
					{
						dataSet.Tables[0].Rows[i]["Feedback"].ToString();
					}
					dataRow[12] = dataSet.Tables[0].Rows[i]["Feedback"].ToString();
					dataRow[13] = dataSet.Tables[0].Rows[i]["DId"].ToString();
					string value4 = "";
					if (dataSet.Tables[0].Rows[i]["SelfEId"] != DBNull.Value)
					{
						string cmdText5 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["SelfEId"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							value4 = dataSet5.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet5.Tables[0].Rows[0]["EmployeeName"].ToString();
						}
					}
					else
					{
						string cmdText6 = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["OtherEId"].ToString() + "'And CompId='" + CompId + "'");
						SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							value4 = dataSet6.Tables[0].Rows[0]["Title"].ToString() + ". " + dataSet6.Tables[0].Rows[0]["EmployeeName"].ToString();
						}
					}
					dataRow[14] = value4;
					dataRow[16] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
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

	protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		con.Open();
		try
		{
			int num = 0;
			if (e.CommandName == "Submit")
			{
				foreach (GridViewRow row in GridView2.Rows)
				{
					string text = ((Label)row.FindControl("lblDId")).Text;
					string text2 = ((Label)row.FindControl("lblId1")).Text;
					string text3 = ((TextBox)row.FindControl("TxtFeedback")).Text;
					if (text3 != "")
					{
						string cmdText = fun.update("tblGatePass_Details", "Feedback='" + text3 + "'", " Id ='" + text + "' AND MId='" + text2 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
						sqlCommand.ExecuteNonQuery();
						num++;
					}
				}
				if (num > 0)
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					TabContainer1.ActiveTab = TabContainer1.Tabs[2];
				}
				else
				{
					string empty = string.Empty;
					empty = "Please fill Feedback.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Del3")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text4 = ((Label)gridViewRow2.FindControl("lblDId")).Text;
				string text5 = ((Label)gridViewRow2.FindControl("lblId1")).Text;
				SqlCommand sqlCommand2 = new SqlCommand(fun.delete("tblGatePass_Details", " Id=" + text4 + "    "), con);
				sqlCommand2.ExecuteNonQuery();
				string cmdText2 = fun.select("*", "tblGatePass_Details", "MId='" + text5 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					SqlCommand sqlCommand3 = new SqlCommand(fun.delete("tblGate_Pass", " Id=" + text5 + "    "), con);
					sqlCommand3.ExecuteNonQuery();
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Print")
			{
				GridViewRow gridViewRow3 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text6 = ((Label)gridViewRow3.FindControl("lblDId")).Text;
				string text7 = ((Label)gridViewRow3.FindControl("lblId1")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("GatePass_Print.aspx?Id=" + text7 + "&DId=" + text6 + "&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "add1")
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text = ((TimeSelector)gridViewRow.FindControl("TimeSelector3")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector3")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector3")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector3")).AmPm;
				string text2 = ((TimeSelector)gridViewRow.FindControl("TimeSelector4")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector4")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector4")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector4")).AmPm;
				string text3 = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtDate2")).Text);
				string text4 = ((TextBox)gridViewRow.FindControl("TxtPlace2")).Text;
				string text5 = ((TextBox)gridViewRow.FindControl("TxtContPerson2")).Text;
				string text6 = ((TextBox)gridViewRow.FindControl("TxtContNo2")).Text;
				string text7 = ((TextBox)gridViewRow.FindControl("TxtReason2")).Text;
				string selectedValue = ((DropDownList)gridViewRow.FindControl("DropDownList3")).SelectedValue;
				string selectedValue2 = ((DropDownList)gridViewRow.FindControl("DropDownList4")).SelectedValue;
				string text8 = ((TextBox)gridViewRow.FindControl("TxtDetails2")).Text;
				int num = 0;
				switch (selectedValue2)
				{
				case "WONo":
					num = 1;
					break;
				case "Enquiry":
					num = 2;
					break;
				case "Others":
					num = 3;
					break;
				}
				if (((TextBox)gridViewRow.FindControl("TxtDate2")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("TxtDate2")).Text))
				{
					if (num == 1)
					{
						if (text8 != "" && fun.CheckValidWONo(((TextBox)gridViewRow.FindControl("TxtDetails2")).Text, CompId, FinYearId))
						{
							SqlCommand sqlCommand = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + text3 + "','" + text + "','" + text2 + "','" + text4 + "','" + text5 + "','" + text6 + "','" + text7 + "','" + selectedValue + "','" + num + "','" + text8 + "'"), con);
							sqlCommand.ExecuteNonQuery();
							con.Close();
							loaddata();
							TabContainer1.ActiveTab = TabContainer1.Tabs[0];
						}
						else
						{
							string empty = string.Empty;
							empty = "Invalid WONo.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
					else
					{
						SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + text3 + "','" + text + "','" + text2 + "','" + text4 + "','" + text5 + "','" + text6 + "','" + text7 + "','" + selectedValue + "','" + num + "','" + text8 + "'"), con);
						sqlCommand2.ExecuteNonQuery();
						con.Close();
						loaddata();
						TabContainer1.ActiveTab = TabContainer1.Tabs[0];
					}
				}
			}
			if (e.CommandName == "add")
			{
				con.Open();
				GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text9 = ((TimeSelector)gridViewRow2.FindControl("TimeSelector1")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector1")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector1")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector1")).AmPm;
				string text10 = ((TimeSelector)gridViewRow2.FindControl("TimeSelector2")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector2")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector2")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector2")).AmPm;
				string text11 = fun.FromDate(((TextBox)gridViewRow2.FindControl("TxtDate1")).Text);
				string text12 = ((TextBox)gridViewRow2.FindControl("TxtPlace1")).Text;
				string text13 = ((TextBox)gridViewRow2.FindControl("TxtContPerson1")).Text;
				string text14 = ((TextBox)gridViewRow2.FindControl("TxtContNo1")).Text;
				string text15 = ((TextBox)gridViewRow2.FindControl("TxtReason1")).Text;
				string selectedValue3 = ((DropDownList)gridViewRow2.FindControl("DropDownList1")).SelectedValue;
				string selectedValue4 = ((DropDownList)gridViewRow2.FindControl("DropDownList2")).SelectedValue;
				string text16 = ((TextBox)gridViewRow2.FindControl("TxtDetails1")).Text;
				int num2 = 0;
				switch (selectedValue4)
				{
				case "WONo":
					num2 = 1;
					break;
				case "Enquiry":
					num2 = 2;
					break;
				case "Others":
					num2 = 3;
					break;
				}
				if (((TextBox)gridViewRow2.FindControl("TxtDate1")).Text != "" && fun.DateValidation(((TextBox)gridViewRow2.FindControl("TxtDate1")).Text))
				{
					if (num2 == 1)
					{
						if (text16 != "" && fun.CheckValidWONo(((TextBox)gridViewRow2.FindControl("TxtDetails1")).Text, CompId, FinYearId))
						{
							SqlCommand sqlCommand3 = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + text11 + "','" + text9 + "','" + text10 + "','" + text12 + "','" + text13 + "','" + text14 + "','" + text15 + "','" + selectedValue3 + "','" + num2 + "','" + text16 + "'"), con);
							sqlCommand3.ExecuteNonQuery();
							con.Close();
							loaddata();
							TabContainer1.ActiveTab = TabContainer1.Tabs[0];
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Invalid WONo.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
					else
					{
						SqlCommand sqlCommand4 = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + text11 + "','" + text9 + "','" + text10 + "','" + text12 + "','" + text13 + "','" + text14 + "','" + text15 + "','" + selectedValue3 + "','" + num2 + "','" + text16 + "'"), con);
						sqlCommand4.ExecuteNonQuery();
						con.Close();
						loaddata();
						TabContainer1.ActiveTab = TabContainer1.Tabs[0];
					}
				}
			}
			if (e.CommandName == "Del1")
			{
				GridViewRow gridViewRow3 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text17 = ((Label)gridViewRow3.FindControl("lblId")).Text;
				SqlCommand sqlCommand5 = new SqlCommand(fun.delete("tblGatePass_Temp", " Id=" + text17 + " And CompId='" + CompId + "'"), con);
				con.Open();
				sqlCommand5.ExecuteNonQuery();
				con.Close();
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList3")).SelectedValue;
			string cmdText = fun.select("*", "tblGatePass_Reason", "Id='" + selectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("WONo");
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Enquiry");
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("WONo");
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Enquiry");
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "0")
			{
				((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();
			}
			TabContainer1.ActiveTab = TabContainer1.Tabs[0];
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = ((DropDownList)GridView3.FooterRow.FindControl("DropDownList1")).SelectedValue;
			string cmdText = fun.select("*", "tblGatePass_Reason", "Id='" + selectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("WONo");
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Enquiry");
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("WONo");
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Enquiry");
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "0")
			{
				((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();
			}
			TabContainer1.ActiveTab = TabContainer1.Tabs[0];
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList7")).SelectedValue;
			string cmdText = fun.select("*", "tblGatePass_Reason", "Id='" + selectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("WONo");
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Enquiry");
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("WONo");
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Enquiry");
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "0")
			{
				((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();
			}
			TabContainer1.ActiveTab = TabContainer1.Tabs[1];
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList5")).SelectedValue;
			string cmdText = fun.select("*", "tblGatePass_Reason", "Id='" + selectedValue + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("WONo");
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Enquiry");
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("WONo");
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "1")
			{
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Enquiry");
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Others");
			}
			if (dataSet.Tables[0].Rows[0]["WONo"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && dataSet.Tables[0].Rows[0]["Other"].ToString() == "0")
			{
				((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();
			}
			TabContainer1.ActiveTab = TabContainer1.Tabs[1];
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
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void BtnFeedback_Click(object sender, EventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "add3")
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text = ((TimeSelector)gridViewRow.FindControl("TimeSelector7")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector7")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector7")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector7")).AmPm;
				string text2 = ((TimeSelector)gridViewRow.FindControl("TimeSelector8")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector8")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector8")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow.FindControl("TimeSelector8")).AmPm;
				string text3 = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtDate4")).Text);
				string text4 = ((TextBox)gridViewRow.FindControl("TxtPlace4")).Text;
				string text5 = ((TextBox)gridViewRow.FindControl("TxtContPerson4")).Text;
				string text6 = ((TextBox)gridViewRow.FindControl("TxtContNo4")).Text;
				string text7 = ((TextBox)gridViewRow.FindControl("TxtReason4")).Text;
				string selectedValue = ((DropDownList)gridViewRow.FindControl("DropDownList7")).SelectedValue;
				string selectedValue2 = ((DropDownList)gridViewRow.FindControl("DropDownList8")).SelectedValue;
				string text8 = ((TextBox)gridViewRow.FindControl("TxtDetails4")).Text;
				string code = fun.getCode(((TextBox)gridViewRow.FindControl("TxtEmp2")).Text);
				int num = 0;
				switch (selectedValue2)
				{
				case "WONo":
					num = 1;
					break;
				case "Enquiry":
					num = 2;
					break;
				case "Others":
					num = 3;
					break;
				}
				string cmdText = fun.select("EmpId", "tblHR_OfficeStaff", "EmpId='" + code + "'And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (((TextBox)gridViewRow.FindControl("TxtDate4")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("TxtDate4")).Text))
				{
					if (code != "" && dataSet.Tables[0].Rows.Count > 0)
					{
						if (num == 1)
						{
							if (text8 != "" && fun.CheckValidWONo(((TextBox)gridViewRow.FindControl("TxtDetails4")).Text, CompId, FinYearId))
							{
								SqlCommand sqlCommand = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + text3 + "','" + text + "','" + text2 + "','" + text4 + "','" + text5 + "','" + text6 + "','" + text7 + "','" + selectedValue + "','" + num + "','" + text8 + "','" + code + "'"), con);
								sqlCommand.ExecuteNonQuery();
								con.Close();
								loadGrid();
								TabContainer1.ActiveTab = TabContainer1.Tabs[1];
							}
							else
							{
								string empty = string.Empty;
								empty = "Invalid WONo.";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
						else
						{
							SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + text3 + "','" + text + "','" + text2 + "','" + text4 + "','" + text5 + "','" + text6 + "','" + text7 + "','" + selectedValue + "','" + num + "','" + text8 + "','" + code + "'"), con);
							sqlCommand2.ExecuteNonQuery();
							con.Close();
							loadGrid();
							TabContainer1.ActiveTab = TabContainer1.Tabs[1];
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Employee Name is Invalid.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
			}
			if (e.CommandName == "add2")
			{
				con.Open();
				GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string text9 = ((TimeSelector)gridViewRow2.FindControl("TimeSelector5")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector5")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector5")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector5")).AmPm;
				string text10 = ((TimeSelector)gridViewRow2.FindControl("TimeSelector6")).Hour.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector6")).Minute.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector6")).Second.ToString("D2") + ":" + ((TimeSelector)gridViewRow2.FindControl("TimeSelector6")).AmPm;
				string text11 = fun.FromDate(((TextBox)gridViewRow2.FindControl("TxtDate3")).Text);
				string text12 = ((TextBox)gridViewRow2.FindControl("TxtPlace3")).Text;
				string text13 = ((TextBox)gridViewRow2.FindControl("TxtContPerson3")).Text;
				string text14 = ((TextBox)gridViewRow2.FindControl("TxtContNo3")).Text;
				string text15 = ((TextBox)gridViewRow2.FindControl("TxtReason3")).Text;
				string selectedValue3 = ((DropDownList)gridViewRow2.FindControl("DropDownList5")).SelectedValue;
				string selectedValue4 = ((DropDownList)gridViewRow2.FindControl("DropDownList6")).SelectedValue;
				string text16 = ((TextBox)gridViewRow2.FindControl("TxtDetails3")).Text;
				string code2 = fun.getCode(((TextBox)gridViewRow2.FindControl("TxtEmp1")).Text);
				int num2 = 0;
				switch (selectedValue4)
				{
				case "WONo":
					num2 = 1;
					break;
				case "Enquiry":
					num2 = 2;
					break;
				case "Others":
					num2 = 3;
					break;
				}
				string cmdText2 = fun.select("EmpId", "tblHR_OfficeStaff", "EmpId='" + code2 + "'And CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (((TextBox)gridViewRow2.FindControl("TxtDate3")).Text != "" && fun.DateValidation(((TextBox)gridViewRow2.FindControl("TxtDate3")).Text))
				{
					if (code2 != "" && dataSet2.Tables[0].Rows.Count > 0)
					{
						if (num2 == 1)
						{
							if (text16 != "" && fun.CheckValidWONo(((TextBox)gridViewRow2.FindControl("TxtDetails3")).Text, CompId, FinYearId))
							{
								SqlCommand sqlCommand3 = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + text11 + "','" + text9 + "','" + text10 + "','" + text12 + "','" + text13 + "','" + text14 + "','" + text15 + "','" + selectedValue3 + "','" + num2 + "','" + text16 + "','" + code2 + "'"), con);
								sqlCommand3.ExecuteNonQuery();
								con.Close();
								loadGrid();
								TabContainer1.ActiveTab = TabContainer1.Tabs[1];
							}
							else
							{
								string empty3 = string.Empty;
								empty3 = "Invalid WONo.";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
							}
						}
						else
						{
							SqlCommand sqlCommand4 = new SqlCommand(fun.insert("tblGatePass_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + text11 + "','" + text9 + "','" + text10 + "','" + text12 + "','" + text13 + "','" + text14 + "','" + text15 + "','" + selectedValue3 + "','" + num2 + "','" + text16 + "','" + code2 + "'"), con);
							sqlCommand4.ExecuteNonQuery();
							con.Close();
							loadGrid();
							TabContainer1.ActiveTab = TabContainer1.Tabs[1];
						}
					}
					else
					{
						string empty4 = string.Empty;
						empty4 = "Employee Name is Invalid.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
					}
				}
			}
			if (e.CommandName == "Del2")
			{
				GridViewRow gridViewRow3 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text17 = ((Label)gridViewRow3.FindControl("lblId")).Text;
				SqlCommand sqlCommand5 = new SqlCommand(fun.delete("tblGatePass_Temp", " Id=" + text17 + " And CompId='" + CompId + "'"), con);
				con.Open();
				sqlCommand5.ExecuteNonQuery();
				con.Close();
				loadGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string cmdText = fun.select("GPNo", "tblGate_Pass", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GPNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblGate_Pass");
			string text2 = "";
			string text3 = string.Empty;
			text2 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("*", "tblGatePass_Temp", " EmpId is null And  CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				con.Open();
				string cmdText3 = fun.insert("tblGate_Pass", "SysDate,SysTime,CompId,FinYearId,SessionId,EmpId,GPNo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + sId + "','" + text2 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText4 = fun.select("Id", "tblGate_Pass", "CompId='" + CompId + "' Order by Id desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblGate_Pass");
				text = dataSet3.Tables[0].Rows[0]["Id"].ToString();
				int num = 0;
				string text4 = string.Empty;
				_ = string.Empty;
				string text5 = string.Empty;
				string text6 = string.Empty;
				string text7 = string.Empty;
				string text8 = string.Empty;
				string text9 = string.Empty;
				string text10 = string.Empty;
				string text11 = string.Empty;
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					string text12 = "";
					text12 = fun.select("Title+'.'+EmployeeName As EmpName,Symbol", "tblHR_OfficeStaff,BusinessGroup", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   EmpId='" + sId + "' And BusinessGroup.Id=tblHR_OfficeStaff.BGGroup");
					SqlCommand selectCommand4 = new SqlCommand(text12, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						text3 = dataSet4.Tables[0].Rows[0][0].ToString() + '[' + dataSet4.Tables[0].Rows[0][1].ToString() + ']' + "<br>" + text3;
						num++;
						text4 = num + "<br>" + text4;
						_ = text2 + "<br>" + text2;
					}
					text5 = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["FromDate"].ToString()) + "<br>" + text5;
					text6 = dataSet2.Tables[0].Rows[i]["FromTime"].ToString() + "<br>" + text6;
					text7 = dataSet2.Tables[0].Rows[i]["ToTime"].ToString() + "<br>" + text7;
					text8 = dataSet2.Tables[0].Rows[i]["Place"].ToString() + "<br>" + text8;
					text9 = dataSet2.Tables[0].Rows[i]["ContactPerson"].ToString() + "<br>" + text9;
					text10 = dataSet2.Tables[0].Rows[i]["ContactNo"].ToString() + "<br>" + text10;
					text11 = dataSet2.Tables[0].Rows[i]["Reason"].ToString() + "<br>" + text11;
					SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblGatePass_Details", "MId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + text + "','" + dataSet2.Tables[0].Rows[i]["FromDate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["FromTime"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ToTime"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Place"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ContactPerson"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ContactNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Reason"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Type"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["TypeOf"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["TypeFor"].ToString() + "'"), con);
					sqlCommand2.ExecuteNonQuery();
				}
				string cmdText5 = fun.delete("tblGatePass_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And EmpId is  null");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
				sqlCommand3.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty = string.Empty;
				empty = "Please click on Add button.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string cmdText = fun.select("GPNo", "tblGate_Pass", "  CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GPNo desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblGate_Pass");
			string text2 = "";
			text2 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("*", "tblGatePass_Temp", " EmpId is not  null And   CompId='" + CompId + "' AND SessionId='" + sId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				con.Open();
				string cmdText3 = fun.insert("tblGate_Pass", "SysDate,SysTime,CompId,FinYearId,SessionId,GPNo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + text2 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText4 = fun.select("Id", "tblGate_Pass", "CompId='" + CompId + "' Order by Id desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblGate_Pass");
				text = dataSet3.Tables[0].Rows[0]["Id"].ToString();
				string text3 = string.Empty;
				int num = 0;
				string text4 = string.Empty;
				_ = string.Empty;
				string text5 = string.Empty;
				string text6 = string.Empty;
				string text7 = string.Empty;
				string text8 = string.Empty;
				string text9 = string.Empty;
				string text10 = string.Empty;
				string text11 = string.Empty;
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblGatePass_Details", "MId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + text + "','" + dataSet2.Tables[0].Rows[i]["FromDate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["FromTime"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ToTime"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Place"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ContactPerson"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ContactNo"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Reason"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Type"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["TypeOf"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["TypeFor"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "'"), con);
					sqlCommand2.ExecuteNonQuery();
					string text12 = "";
					text12 = fun.select("Title+'.'+EmployeeName As EmpName,Symbol", "tblHR_OfficeStaff,BusinessGroup", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   EmpId='" + dataSet2.Tables[0].Rows[i]["EmpId"].ToString() + "' And BusinessGroup.Id=tblHR_OfficeStaff.BGGroup");
					SqlCommand selectCommand4 = new SqlCommand(text12, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						text3 = dataSet4.Tables[0].Rows[0][0].ToString() + '[' + dataSet4.Tables[0].Rows[0][1].ToString() + ']' + "<br>" + text3;
						num++;
						text4 = num + "<br>" + text4;
						_ = text2 + "<br>" + text2;
					}
					text5 = fun.FromDateDMY(dataSet2.Tables[0].Rows[i]["FromDate"].ToString()) + "<br>" + text5;
					text6 = dataSet2.Tables[0].Rows[i]["FromTime"].ToString() + "<br>" + text6;
					text7 = dataSet2.Tables[0].Rows[i]["ToTime"].ToString() + "<br>" + text7;
					text8 = dataSet2.Tables[0].Rows[i]["Place"].ToString() + "<br>" + text8;
					text9 = dataSet2.Tables[0].Rows[i]["ContactPerson"].ToString() + "<br>" + text9;
					text10 = dataSet2.Tables[0].Rows[i]["ContactNo"].ToString() + "<br>" + text10;
					text11 = dataSet2.Tables[0].Rows[i]["Reason"].ToString() + "<br>" + text11;
				}
				string cmdText5 = fun.delete("tblGatePass_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And EmpId is not null ");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
				sqlCommand3.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty = string.Empty;
				empty = "please click Add button.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}
}
