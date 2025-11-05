using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public class Module_SalesDistribution_Transactions_WorkOrder_Dispatch_Details : Page, IRequiresSessionState
{
	protected UpdateProgress UpdateProgress;

	protected ModalPopupExtender modalPopup;

	protected GridView GridView1;

	protected Panel Panel1;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Panel Panel2;

	protected RadioButton FCustomer;

	protected RadioButton FSelf;

	protected RadioButton VCustomer;

	protected RadioButton VSelf;

	protected RadioButton OCustomer;

	protected RadioButton OSelf;

	protected Button Submit;

	protected Button Cancel;

	protected UpdatePanel pnlData;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private MailMessage msg = new MailMessage();

	private int CompId;

	private string wono = "";

	private string wrno = "";

	private string xmlfilename = string.Empty;

	private string pdffilename = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			wono = base.Request.QueryString["WONo"];
			wrno = base.Request.QueryString["WRNo"];
			GetValidate();
			if (!base.IsPostBack)
			{
				_ = (DataTable)ViewState["vs"];
				LoadData();
			}
		}
		catch (Exception)
		{
		}
	}

	private void LoadData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.select("*", "SD_Cust_WorkOrder_Release", "WRNo='" + wrno + "' And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ReleasedQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DATotalQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("DARemainQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(DS.Tables[0].Rows[i]["Id"]);
				string cmdText2 = fun.select("ItemCode,Description,Qty", "SD_Cust_WorkOrder_Products_Details", "Id='" + DS.Tables[0].Rows[i]["ItemId"].ToString() + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet = new DataSet();
				sqlDataAdapter2.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["Description"].ToString();
					dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
				}
				dataRow[4] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["IssuedQty"].ToString()).ToString("N3"));
				dataRow[7] = Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"]);
				string cmdText3 = fun.select("sum(DispatchQty) as sum_DispatchQty ", "SD_Cust_WorkOrder_Dispatch ", "ItemId='" + DS.Tables[0].Rows[i]["ItemId"].ToString() + "' AND WRId='" + Convert.ToInt32(DS.Tables[0].Rows[i]["Id"]) + "'And CompId='" + CompId + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				DataSet dataSet2 = new DataSet();
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				sqlDataAdapter3.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["sum_DispatchQty"] != DBNull.Value)
				{
					dataRow[5] = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["sum_DispatchQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[5] = 0;
				}
				double num = 0.0;
				if (dataSet2.Tables[0].Rows[0]["sum_DispatchQty"] != DBNull.Value)
				{
					dataRow[6] = Convert.ToDouble(decimal.Parse((Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["IssuedQty"].ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["sum_DispatchQty"].ToString()).ToString("N3"))).ToString()).ToString("N3"));
				}
				else
				{
					dataRow[5] = 0;
					dataRow[6] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["IssuedQty"].ToString()).ToString("N3"));
				}
				dataTable.Rows.Add(dataRow);
			}
			ViewState["vs"] = dataTable;
			if (ViewState["vs"] != null)
			{
				GridView1.DataSource = (DataTable)ViewState["vs"];
				GridView1.DataBind();
			}
			else
			{
				GridView1.DataSource = dataTable;
				GridView1.DataBind();
			}
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblrelqty")).Text).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbldaqty")).Text).ToString("N3")) <= 0.0)
				{
					((TextBox)row.FindControl("TextBox1")).Visible = false;
					((CheckBox)row.FindControl("CheckBox1")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}

	protected void Submit_Click(object sender, EventArgs e)
	{
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1f: Expected O, but got Unknown
		//IL_15be: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c5: Expected O, but got Unknown
		//IL_15c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cc: Expected O, but got Unknown
		string text = fun.TranNo("SD_Cust_WorkOrder_Dispatch", "DANo", CompId);
		DataTable dataTable = (DataTable)ViewState["vs"];
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("CheckBox1");
				if (checkBox.Checked && ((TextBox)row.FindControl("TextBox1")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("TextBox1")).Text))
				{
					num3++;
					num++;
					double num4 = 0.0;
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = 0.0;
					num4 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblrelqty")).Text).ToString("N3"));
					num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lbldaqty")).Text).ToString("N3"));
					num6 = Convert.ToDouble(decimal.Parse((num4 - num5).ToString()).ToString("N3"));
					num7 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TextBox1")).Text).ToString("N3"));
					num2 = ((num6 - num7 >= 0.0 && ((TextBox)row.FindControl("TextBox1")).Text != "" && Convert.ToDouble(((TextBox)row.FindControl("TextBox1")).Text) > 0.0) ? (num2 + 1) : 0);
				}
			}
			int num8 = 0;
			foreach (GridViewRow row2 in GridView2.Rows)
			{
				CheckBox checkBox2 = (CheckBox)row2.FindControl("CheckBox2");
				if (checkBox2.Checked)
				{
					num8++;
				}
			}
			int num9 = 0;
			if (num > 0 && num8 > 0 && num3 - num2 == 0)
			{
				int num10 = 0;
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string text2 = Session["username"].ToString();
				int num11 = Convert.ToInt32(Session["finyear"]);
				foreach (GridViewRow row3 in GridView1.Rows)
				{
					CheckBox checkBox3 = (CheckBox)row3.FindControl("CheckBox1");
					double num12 = 0.0;
					double num13 = 0.0;
					double num14 = 0.0;
					double num15 = 0.0;
					double num16 = 0.0;
					if (checkBox3.Checked && ((TextBox)row3.FindControl("TextBox1")).Text != "")
					{
						num16 = Convert.ToDouble(decimal.Parse(((TextBox)row3.FindControl("TextBox1")).Text).ToString("N3"));
						num15 = Convert.ToDouble(((TextBox)row3.FindControl("TextBox1")).Text);
						num12 = Convert.ToDouble(decimal.Parse(((Label)row3.FindControl("lblrelqty")).Text).ToString("N3"));
						num13 = Convert.ToDouble(decimal.Parse(((Label)row3.FindControl("lbldaqty")).Text).ToString("N3"));
						num14 = Convert.ToDouble(decimal.Parse((num12 - num13).ToString()).ToString("N3"));
						if (num14 - num16 >= 0.0 && num15 > 0.0)
						{
							string connectionString = fun.Connection();
							SqlConnection sqlConnection = new SqlConnection(connectionString);
							sqlConnection.Open();
							TextBox textBox = (TextBox)row3.FindControl("TextBox1");
							string text3 = "";
							if (FCustomer.Checked)
							{
								text3 = FCustomer.Text;
							}
							else if (FSelf.Checked)
							{
								text3 = FSelf.Text;
							}
							string text4 = "";
							if (VCustomer.Checked)
							{
								text4 = VCustomer.Text;
							}
							else if (VSelf.Checked)
							{
								text4 = VSelf.Text;
							}
							string text5 = "";
							if (OCustomer.Checked)
							{
								text5 = OCustomer.Text;
							}
							else if (OSelf.Checked)
							{
								text5 = OSelf.Text;
							}
							string cmdText = fun.insert("SD_Cust_WorkOrder_Dispatch", "SysDate,SysTime,SessionId,CompId,FinYearId,DANo,WRNo,WRId,ItemId,IssuedQty,DispatchQty,FreightCharges,Vehicleby,OctroiCharges", string.Concat("'", currDate, "','", currTime, "','", text2.ToString(), "','", CompId, "','", num11, "','", text, "','", wrno, "','", dataTable.Rows[num10][0], "','", dataTable.Rows[num10][7], "','", dataTable.Rows[num10][4], "','", textBox.Text, "','", text3, "','", text4, "','", text5, "'"));
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							sqlConnection.Close();
						}
					}
					num10++;
				}
				string cmdText2 = fun.select("*", "SD_Cust_WorkOrder_Dispatch", "DANo='" + text + "' And CompId='" + CompId + "'");
				string connectionString2 = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString2);
				SqlCommand selectCommand = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataTable dataTable2 = new DataTable();
					dataTable2.Columns.Add(new DataColumn("Id", typeof(int)));
					dataTable2.Columns.Add(new DataColumn("ItemCode", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Description", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("IssuedQty", typeof(double)));
					dataTable2.Columns.Add(new DataColumn("DispatchQty", typeof(double)));
					dataTable2.Columns.Add(new DataColumn("WONo", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("DANo", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("CompId", typeof(int)));
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						DataRow dataRow = dataTable2.NewRow();
						dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
						string cmdText3 = fun.select("SD_Cust_WorkOrder_Products_Details.ItemCode,SD_Cust_WorkOrder_Master.WONo,SD_Cust_WorkOrder_Products_Details.Description", " SD_Cust_WorkOrder_Master,SD_Cust_WorkOrder_Products_Details", "SD_Cust_WorkOrder_Products_Details.MId=SD_Cust_WorkOrder_Master.Id AND SD_Cust_WorkOrder_Products_Details.Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'  And SD_Cust_WorkOrder_Master.CompId='" + CompId + "' ");
						string connectionString3 = fun.Connection();
						SqlConnection connection2 = new SqlConnection(connectionString3);
						SqlCommand selectCommand2 = new SqlCommand(cmdText3, connection2);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						dataRow[1] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
						dataRow[2] = dataSet2.Tables[0].Rows[0]["Description"].ToString();
						dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["IssuedQty"].ToString()).ToString("N3"));
						dataRow[4] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["DispatchQty"].ToString()).ToString("N3"));
						string cmdText4 = fun.select("WONo", "SD_Cust_WorkOrder_Release", " Id='" + dataSet.Tables[0].Rows[i]["WRId"].ToString() + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText4, connection2);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						dataRow[5] = dataSet3.Tables[0].Rows[0]["WONo"].ToString();
						dataRow[6] = dataSet.Tables[0].Rows[i]["DANo"].ToString();
						dataRow[7] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CompId"]);
						dataTable2.Rows.Add(dataRow);
						dataTable2.AcceptChanges();
					}
					dataTable2.AcceptChanges();
					DataSet dataSet4 = new DataSet();
					DataSet dataSet5 = new SD_DA();
					dataSet5.Clear();
					dataSet5.Dispose();
					dataSet4.Tables.Add(dataTable2);
					xmlfilename = "WorkOrderDispatch_" + wono + "_" + wrno + "_" + text + ".xml";
					dataSet4.WriteXml(base.Server.MapPath("~\\\\tempxml\\\\" + xmlfilename));
					dataSet5.Tables[0].Merge(dataSet4.Tables[0]);
					ReportDocument val = new ReportDocument();
					val.Load(base.Server.MapPath("~\\\\Module\\\\SalesDistribution\\\\Transactions\\\\Reports\\\\WODispatchMail.rpt"));
					val.SetDataSource(dataSet5);
					string connectionString4 = fun.Connection();
					SqlConnection sqlConnection2 = new SqlConnection(connectionString4);
					sqlConnection2.Open();
					string text6 = "";
					string cmdText5 = fun.select("CustomerId ", "SD_Cust_WorkOrder_Master", "WONo='" + wono + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText5, sqlConnection2);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter4.Fill(dataSet6, "SD_Cust_WorkOrder_Master");
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						text6 = dataSet6.Tables[0].Rows[0]["CustomerId"].ToString();
					}
					string cmdText6 = fun.select("*", "SD_Cust_master", "CustomerId='" + text6 + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText6, sqlConnection2);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet7 = new DataSet();
					sqlDataAdapter5.Fill(dataSet7, "SD_Cust_master");
					if (dataSet7.Tables[0].Rows.Count > 0)
					{
						string value = dataSet7.Tables[0].Rows[0]["RegdCity"].ToString();
						string value2 = dataSet7.Tables[0].Rows[0]["RegdState"].ToString();
						string value3 = dataSet7.Tables[0].Rows[0]["RegdCountry"].ToString();
						string value4 = dataSet7.Tables[0].Rows[0]["WorkCity"].ToString();
						string value5 = dataSet7.Tables[0].Rows[0]["WorkState"].ToString();
						string value6 = dataSet7.Tables[0].Rows[0]["WorkCountry"].ToString();
						string value7 = dataSet7.Tables[0].Rows[0]["MaterialDelCity"].ToString();
						string value8 = dataSet7.Tables[0].Rows[0]["MaterialDelState"].ToString();
						string value9 = dataSet7.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
						string city = fun.getCity(Convert.ToInt32(value), 1);
						string state = fun.getState(Convert.ToInt32(value2), 1);
						string country = fun.getCountry(Convert.ToInt32(value3), 1);
						string city2 = fun.getCity(Convert.ToInt32(value4), 1);
						string state2 = fun.getState(Convert.ToInt32(value5), 1);
						string country2 = fun.getCountry(Convert.ToInt32(value6), 1);
						string city3 = fun.getCity(Convert.ToInt32(value7), 1);
						string state3 = fun.getState(Convert.ToInt32(value8), 1);
						string country3 = fun.getCountry(Convert.ToInt32(value9), 1);
						string company = fun.getCompany(CompId);
						val.SetParameterValue("Company", (object)company);
						val.SetParameterValue("RegCity", (object)city);
						val.SetParameterValue("RegState", (object)state);
						val.SetParameterValue("RegCountry", (object)country);
						val.SetParameterValue("WrkCity", (object)city2);
						val.SetParameterValue("WrkState", (object)state2);
						val.SetParameterValue("WrkCountry", (object)country2);
						val.SetParameterValue("DelCity", (object)city3);
						val.SetParameterValue("DelState", (object)state3);
						val.SetParameterValue("DelCountry", (object)country3);
					}
					string cmdText7 = fun.select("SysDate", "SD_Cust_WorkOrder_Release", "WONo='" + wono + "' and WRNo='" + wrno + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText7, sqlConnection2);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet8 = new DataSet();
					sqlDataAdapter6.Fill(dataSet8, "SD_Cust_WorkOrder_Release");
					if (dataSet8.Tables[0].Rows.Count > 0)
					{
						string text7 = fun.FromDate(dataSet8.Tables[0].Rows[0]["SysDate"].ToString());
						val.SetParameterValue("WRDate", (object)text7);
					}
					string cmdText8 = fun.select("TaskWorkOrderDate,TaskCustInspection_FDate,TaskCustInspection_TDate ", "SD_Cust_WorkOrder_Master", "WONo='" + wono + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand7 = new SqlCommand(cmdText8, sqlConnection2);
					SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
					DataSet dataSet9 = new DataSet();
					sqlDataAdapter7.Fill(dataSet9, "SD_Cust_WorkOrder_Master");
					if (dataSet9.Tables[0].Rows.Count > 0)
					{
						string text8 = fun.FromDate(dataSet9.Tables[0].Rows[0]["TaskWorkOrderDate"].ToString());
						string text9 = fun.FromDate(dataSet9.Tables[0].Rows[0]["TaskCustInspection_FDate"].ToString());
						string text10 = fun.FromDate(dataSet9.Tables[0].Rows[0]["TaskCustInspection_TDate"].ToString());
						val.SetParameterValue("WODate", (object)text8);
						val.SetParameterValue("CustInspection_FD", (object)text9);
						val.SetParameterValue("CustInspection_TD", (object)text10);
					}
					string cmdText9 = fun.select("PONo", "SD_Cust_WorkOrder_Master", "WONo='" + wono + "' And CompId='" + CompId + "'");
					SqlCommand selectCommand8 = new SqlCommand(cmdText9, sqlConnection2);
					SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
					DataSet dataSet10 = new DataSet();
					sqlDataAdapter8.Fill(dataSet10, "SD_Cust_WorkOrder_Master");
					if (dataSet10.Tables[0].Rows.Count > 0)
					{
						string text11 = dataSet10.Tables[0].Rows[0]["PONo"].ToString();
						string cmdText10 = fun.select("PODate", "SD_Cust_PO_Master", "PONo='" + text11 + "' And CompId='" + CompId + "'");
						SqlCommand selectCommand9 = new SqlCommand(cmdText10, sqlConnection2);
						SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
						DataSet dataSet11 = new DataSet();
						sqlDataAdapter9.Fill(dataSet11, "SD_Cust_PO_Master");
						if (dataSet11.Tables[0].Rows.Count > 0)
						{
							string text12 = fun.FromDate(dataSet11.Tables[0].Rows[0]["PODate"].ToString());
							val.SetParameterValue("PODate", (object)text12);
						}
					}
					string text13 = fun.CompAdd(CompId);
					val.SetParameterValue("Address", (object)text13);
					DiskFileDestinationOptions val2 = new DiskFileDestinationOptions();
					PdfRtfWordFormatOptions formatOptions = new PdfRtfWordFormatOptions();
					pdffilename = "WorkOrderDispatch_" + wono + "_" + wrno + " _ " + text + ".pdf";
					val2.DiskFileName = base.Server.MapPath("~\\\\temppdf\\\\" + pdffilename);
					ExportOptions exportOptions = val.ExportOptions;
					exportOptions.ExportDestinationType = (ExportDestinationType)1;
					exportOptions.ExportFormatType = (ExportFormatType)5;
					exportOptions.DestinationOptions = val2;
					exportOptions.FormatOptions = formatOptions;
					val.Export();
					val.Refresh();
					val.Close();
					((Component)(object)val).Dispose();
					dataTable2.Clear();
					dataTable2.Dispose();
					dataSet5.Clear();
					dataSet5.Dispose();
					string connectionString5 = fun.Connection();
					string text14 = "";
					MailAttachment value10 = new MailAttachment(base.Server.MapPath("~\\\\temppdf\\\\" + pdffilename));
					msg.Attachments.Add(value10);
					foreach (GridViewRow row4 in GridView2.Rows)
					{
						CheckBox checkBox4 = (CheckBox)row4.FindControl("CheckBox2");
						if (checkBox4.Checked && num > 0)
						{
							string cmdText11 = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
							SqlConnection connection3 = new SqlConnection(connectionString5);
							SqlCommand selectCommand10 = new SqlCommand(cmdText11, connection3);
							SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
							DataSet dataSet12 = new DataSet();
							sqlDataAdapter10.Fill(dataSet12);
							SmtpMail.SmtpServer = dataSet12.Tables[0].Rows[0]["MailServerIp"].ToString();
							if (dataSet12.Tables[0].Rows.Count > 0)
							{
								text14 = dataSet12.Tables[0].Rows[0]["ErpSysmail"].ToString();
							}
							msg.From = text14;
							if (((Label)row4.FindControl("lblEmailId")).Text != "")
							{
								msg.To = ((Label)row4.FindControl("lblEmailId")).Text + ";";
							}
							else
							{
								msg.To = text14;
							}
							msg.Subject = "Work Order Dispatch WONo: " + wono + " WRNo: " + wrno + " DANo: " + text;
							msg.Body = "Dear Sir, This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
							msg.BodyFormat = MailFormat.Html;
							SmtpMail.Send(msg);
						}
					}
					num9++;
				}
			}
			File.Delete(base.Server.MapPath("~\\\\tempxml\\\\" + xmlfilename));
			File.Delete(base.Server.MapPath("~\\\\temppdf\\\\" + pdffilename));
			Thread.Sleep(1000);
			if (num9 > 0)
			{
				base.Response.Redirect("~/Module/SalesDistribution/Transactions/WorkOrder_Dispatch.aspx?ModId=2&amp;SubModId=54&msg=Dispatch of Work order No." + wono + " is completed.");
				return;
			}
			string empty = string.Empty;
			empty = "Invalid input details are found.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
	}

	protected void Cancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("WorkOrder_Dispatch.aspx?ModId=2&SubModId=54");
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		GetValidate();
	}

	public void GetValidate()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("Req")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("Req")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
