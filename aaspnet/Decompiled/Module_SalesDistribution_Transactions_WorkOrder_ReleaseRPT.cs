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

public class Module_SalesDistribution_Transactions_WorkOrder_ReleaseRPT : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private MailMessage msg = new MailMessage();

	private string wono = "";

	private string Id = "";

	private int SessionCompId;

	private string xmlfilename = string.Empty;

	private string pdffilename = string.Empty;

	protected UpdateProgress UpdateProgress;

	protected ModalPopupExtender modalPopup;

	protected Label Label2;

	protected GridView GridView1;

	protected Panel Panel1;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	protected Panel Panel2;

	protected Button Submit;

	protected Button Button2;

	protected UpdatePanel pnlData;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		SessionCompId = Convert.ToInt32(Session["compid"]);
		GetValidate();
		if (!base.IsPostBack)
		{
			_ = (DataTable)ViewState["vs"];
			LoadData();
		}
	}

	public void LoadData()
	{
		try
		{
			wono = base.Request.QueryString["WONo"];
			Id = base.Request.QueryString["Id"];
			Label2.Text = wono;
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("*", "SD_Cust_WorkOrder_Products_Details", " MId='" + Id + "' And CompId='" + SessionCompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReleasedQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RemainQty", typeof(string)));
			for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = DS.Tables[0].Rows[i][0];
				dataRow[1] = DS.Tables[0].Rows[i][5].ToString();
				dataRow[2] = DS.Tables[0].Rows[i][6].ToString();
				dataRow[3] = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i][7].ToString()).ToString("N3"));
				string cmdText2 = fun.select("sum(IssuedQty) as sum_IssuedQty", "SD_Cust_WorkOrder_Release", string.Concat("ItemId='", dataRow[0], "' And CompId='", SessionCompId, "' AND WONo='", wono, "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet = new DataSet();
				sqlDataAdapter2.Fill(dataSet);
				double num = 0.0;
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				dataRow[4] = num;
				if (dataRow[4] != DBNull.Value)
				{
					dataRow[5] = Convert.ToDouble(decimal.Parse((Convert.ToDouble(DS.Tables[0].Rows[i][7]) - num).ToString()).ToString("N3"));
				}
				else
				{
					dataRow[5] = num;
				}
				dataTable.Rows.Add(dataRow);
				ViewState["r"] = dataRow[5];
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
				if (Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblQty")).Text).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblReleasedQty")).Text).ToString("N3")) == 0.0)
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = false;
					((TextBox)row.FindControl("TextBox1")).Visible = false;
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
		//IL_0a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Expected O, but got Unknown
		//IL_13d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d7: Expected O, but got Unknown
		//IL_13d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13de: Expected O, but got Unknown
		wono = base.Request.QueryString["WONo"];
		Id = base.Request.QueryString["Id"];
		DataTable dataTable = (DataTable)ViewState["vs"];
		string text = fun.TranNo("SD_Cust_WorkOrder_Release", "WRNo", SessionCompId);
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
					num4 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblQty")).Text).ToString("N3"));
					num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblReleasedQty")).Text).ToString("N3"));
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
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string text2 = Session["username"].ToString();
				int num10 = Convert.ToInt32(Session["compid"]);
				int num11 = Convert.ToInt32(Session["finyear"]);
				int num12 = 0;
				foreach (GridViewRow row3 in GridView1.Rows)
				{
					CheckBox checkBox3 = (CheckBox)row3.FindControl("CheckBox1");
					_ = (TextBox)row3.FindControl("TextBox1");
					double num13 = 0.0;
					double num14 = 0.0;
					double num15 = 0.0;
					double num16 = 0.0;
					if (checkBox3.Checked && num8 > 0 && ((TextBox)row3.FindControl("TextBox1")).Text != "")
					{
						num13 = Convert.ToDouble(decimal.Parse(((Label)row3.FindControl("lblQty")).Text).ToString("N3"));
						num14 = Convert.ToDouble(decimal.Parse(((Label)row3.FindControl("lblReleasedQty")).Text).ToString("N3"));
						num15 = Convert.ToDouble(decimal.Parse((num13 - num14).ToString()).ToString("N3"));
						num16 = Convert.ToDouble(((TextBox)row3.FindControl("TextBox1")).Text);
						if (num15 - num16 >= 0.0)
						{
							string connectionString = fun.Connection();
							SqlConnection sqlConnection = new SqlConnection(connectionString);
							sqlConnection.Open();
							string cmdText = fun.insert("SD_Cust_WorkOrder_Release", "SysDate,SysTime,SessionId,CompId,FinYearId,WRNo,WONo,ItemId,IssuedQty", string.Concat("'", currDate.ToString(), "','", currTime.ToString(), "','", text2.ToString(), "','", num10, "','", num11, "','", text, "','", wono, "','", dataTable.Rows[num12][0], "','", ((TextBox)row3.FindControl("TextBox1")).Text, "'"));
							SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
							sqlCommand.ExecuteNonQuery();
							sqlConnection.Close();
						}
					}
					num12++;
				}
				string cmdText2 = fun.select("WRNo", "SD_Cust_WorkOrder_Release", "WRNo='" + text + "' And CompId='" + SessionCompId + "'");
				string connectionString2 = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString2);
				SqlCommand selectCommand = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DataTable dataTable2 = new DataTable();
					dataTable2.Columns.Add(new DataColumn("Id", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("ItemCode", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Description", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Qty", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("ReleasedQty", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("WONo", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("WRNo", typeof(string)));
					foreach (GridViewRow row4 in GridView1.Rows)
					{
						CheckBox checkBox4 = (CheckBox)row4.FindControl("CheckBox1");
						if (checkBox4.Checked)
						{
							DataRow dataRow = dataTable2.NewRow();
							dataRow[0] = ((Label)row4.FindControl("lblId")).Text;
							dataRow[1] = ((Label)row4.FindControl("lblItemCode")).Text;
							dataRow[2] = ((Label)row4.FindControl("lblDesc")).Text;
							dataRow[3] = ((Label)row4.FindControl("lblQty")).Text;
							string cmdText3 = fun.select("IssuedQty", "SD_Cust_WorkOrder_Release", string.Concat("ItemId='", dataRow[0], "' AND WRNo='", text, "' And CompId='", SessionCompId, "'"));
							string connectionString3 = fun.Connection();
							SqlConnection connection2 = new SqlConnection(connectionString3);
							SqlCommand selectCommand2 = new SqlCommand(cmdText3, connection2);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							if (dataSet2.Tables[0].Rows.Count > 0)
							{
								dataRow[4] = dataSet2.Tables[0].Rows[0][0].ToString();
							}
							dataRow[5] = wono;
							dataRow[6] = text;
							dataTable2.Rows.Add(dataRow);
						}
					}
					dataTable2.AcceptChanges();
					DataSet dataSet3 = new DataSet();
					DataSet dataSet4 = new SD_WR();
					dataSet4.Clear();
					dataSet4.Dispose();
					dataSet3.Tables.Add(dataTable2);
					xmlfilename = "WorkOrderRelease_" + wono + "_" + text + ".xml";
					dataSet3.WriteXml(base.Server.MapPath("~\\\\tempxml\\\\" + xmlfilename));
					dataSet4.Tables[0].Merge(dataSet3.Tables[0]);
					ReportDocument val = new ReportDocument();
					val.Load(base.Server.MapPath("~\\\\Module\\\\SalesDistribution\\\\Transactions\\\\Reports\\\\WOReleaseMail.rpt"));
					val.SetDataSource(dataSet4);
					string connectionString4 = fun.Connection();
					SqlConnection connection3 = new SqlConnection(connectionString4);
					string text3 = "";
					string cmdText4 = fun.select("*", "SD_Cust_WorkOrder_Master", "Id='" + Id + "' And CompId='" + SessionCompId + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, connection3);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter3.Fill(dataSet5, "SD_Cust_WorkOrder_Master");
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						text3 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskWorkOrderDate"].ToString());
						string connectionString5 = fun.Connection();
						SqlConnection connection4 = new SqlConnection(connectionString5);
						string cmdText5 = fun.select("*", "SD_Cust_PO_Master", "POId='" + dataSet5.Tables[0].Rows[0]["POId"].ToString() + "' And CompId='" + SessionCompId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText5, connection4);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter4.Fill(dataSet6, "SD_Cust_WorkOrder_Master");
						if (dataSet6.Tables[0].Rows.Count > 0)
						{
							string text4 = fun.FromDate(dataSet6.Tables[0].Rows[0]["PODate"].ToString());
							string text5 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskDesignFinalization_FDate"].ToString());
							string text6 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskDesignFinalization_TDate"].ToString());
							string text7 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetDAP_FDate"].ToString());
							string text8 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetDAP_TDate"].ToString());
							string text9 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetManufg_FDate"].ToString());
							string text10 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetManufg_TDate"].ToString());
							string text11 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetTryOut_FDate"].ToString());
							string text12 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetTryOut_TDate"].ToString());
							string text13 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetDespach_FDate"].ToString());
							string text14 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetDespach_TDate"].ToString());
							string text15 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetAssembly_FDate"].ToString());
							string text16 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetAssembly_TDate"].ToString());
							string text17 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetInstalation_FDate"].ToString());
							string text18 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskTargetInstalation_TDate"].ToString());
							string text19 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskCustInspection_FDate"].ToString());
							string text20 = fun.FromDate(dataSet5.Tables[0].Rows[0]["TaskCustInspection_TDate"].ToString());
							SqlCommand selectCommand5 = new SqlCommand(fun.select("Symbol+' - '+CName as Category", "tblSD_WO_Category", "CId='" + dataSet5.Tables[0].Rows[0]["CId"].ToString() + "'"), connection3);
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter5.Fill(dataSet7, "tblSD_WO_Category");
							if (dataSet7.Tables[0].Rows.Count > 0)
							{
								val.SetParameterValue("Category", (object)dataSet7.Tables[0].Rows[0]["Category"].ToString());
							}
							else
							{
								val.SetParameterValue("Category", (object)"NA");
							}
							SqlCommand selectCommand6 = new SqlCommand(fun.select("Symbol+' - '+SCName as SubCategory", "tblSD_WO_SubCategory", "SCId='" + dataSet5.Tables[0].Rows[0]["SCId"].ToString() + "'"), connection3);
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
							DataSet dataSet8 = new DataSet();
							sqlDataAdapter6.Fill(dataSet8, "tblSD_WO_Category");
							if (dataSet8.Tables[0].Rows.Count > 0)
							{
								val.SetParameterValue("SubCategory", (object)dataSet8.Tables[0].Rows[0]["SubCategory"].ToString());
							}
							else
							{
								val.SetParameterValue("SubCategory", (object)"NA");
							}
							val.SetParameterValue("podate", (object)text4);
							val.SetParameterValue("dsgfd", (object)text5);
							val.SetParameterValue("dsgtd", (object)text6);
							val.SetParameterValue("dapfd", (object)text7);
							val.SetParameterValue("daptd", (object)text8);
							val.SetParameterValue("mgfd", (object)text9);
							val.SetParameterValue("mgtd", (object)text10);
							val.SetParameterValue("tryfd", (object)text11);
							val.SetParameterValue("trytd", (object)text12);
							val.SetParameterValue("desfd", (object)text13);
							val.SetParameterValue("destd", (object)text14);
							val.SetParameterValue("assfd", (object)text15);
							val.SetParameterValue("asstd", (object)text16);
							val.SetParameterValue("instfd", (object)text17);
							val.SetParameterValue("insttd", (object)text18);
							val.SetParameterValue("inspfd", (object)text19);
							val.SetParameterValue("insptd", (object)text20);
						}
						val.SetParameterValue("wodate", (object)text3);
						string company = fun.getCompany(SessionCompId);
						val.SetParameterValue("Company", (object)company);
						string text21 = "";
						if (Convert.ToInt32(dataSet5.Tables[0].Rows[0]["InstractionPrimerPainting"]) == 1)
						{
							text21 += "Primer Painting,";
						}
						if (Convert.ToInt32(dataSet5.Tables[0].Rows[0]["InstractionPainting"]) == 1)
						{
							text21 += " Painting,";
						}
						if (Convert.ToInt32(dataSet5.Tables[0].Rows[0]["InstractionSelfCertRept"]) == 1)
						{
							text21 += " Self Certification Report ";
						}
						text21 += dataSet5.Tables[0].Rows[0]["InstractionOther"].ToString();
						val.SetParameterValue("instruction", (object)text21);
					}
					string text22 = fun.CompAdd(SessionCompId);
					val.SetParameterValue("Address", (object)text22);
					DiskFileDestinationOptions val2 = new DiskFileDestinationOptions();
					PdfRtfWordFormatOptions formatOptions = new PdfRtfWordFormatOptions();
					pdffilename = "WorkOrderRelease_" + wono + "_" + text + ".pdf";
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
					dataSet4.Clear();
					dataSet4.Dispose();
					string connectionString6 = fun.Connection();
					string text23 = "";
					MailAttachment value = new MailAttachment(base.Server.MapPath("~\\\\temppdf\\\\" + pdffilename));
					msg.Attachments.Add(value);
					foreach (GridViewRow row5 in GridView2.Rows)
					{
						CheckBox checkBox5 = (CheckBox)row5.FindControl("CheckBox2");
						if (checkBox5.Checked && num > 0)
						{
							string cmdText6 = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + num10 + "'");
							SqlConnection connection5 = new SqlConnection(connectionString6);
							SqlCommand selectCommand7 = new SqlCommand(cmdText6, connection5);
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
							DataSet dataSet9 = new DataSet();
							sqlDataAdapter7.Fill(dataSet9);
							if (dataSet9.Tables[0].Rows.Count > 0)
							{
								SmtpMail.SmtpServer = dataSet9.Tables[0].Rows[0]["MailServerIp"].ToString();
								text23 = dataSet9.Tables[0].Rows[0]["ErpSysmail"].ToString();
							}
							msg.From = text23;
							if (((Label)row5.FindControl("lblEmailId")).Text != "")
							{
								msg.To = ((Label)row5.FindControl("lblEmailId")).Text + ";";
							}
							else
							{
								msg.To = text23;
							}
							msg.Subject = "Work Order Release WONo:" + wono + "WRNo:" + text;
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
				base.Response.Redirect("WorkOrder_Release.aspx?ModId=2&SubModId=15&msg=Release of Work Order No. " + wono + " is completed.");
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

	protected void TextBox1_OnTextChanged(object sender, EventArgs e)
	{
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("WorkOrder_Release.aspx?ModId=2&SubModId=15");
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
