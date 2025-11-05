using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_MaterialIssueNote_MIN_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private MailMessage msg = new MailMessage();

	private string fyid = "";

	private string mrsno = "";

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string Sid = "";

	private int FinYearId;

	private string CDate = "";

	private string CTime = "";

	private string MId = "";

	protected UpdateProgress UpdateProgress;

	protected ModalPopupExtender modalPopup;

	protected GridView GridView3;

	protected Panel Panel1;

	protected Button btnProceed;

	protected Button btnCancel;

	protected UpdatePanel pnlData;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			fyid = base.Request.QueryString["fyid"].ToString();
			mrsno = base.Request.QueryString["mrsno"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			Sid = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			MId = base.Request.QueryString["Id"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				loadgrid();
			}
			foreach (GridViewRow row in GridView3.Rows)
			{
				double num = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblreqty")).Text).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblissty")).Text).ToString("N3"));
				double num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblstkqty")).Text).ToString("N3"));
				if (num == 0.0 || num2 == 0.0)
				{
					((CheckBox)row.FindControl("ck")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadgrid()
	{
		try
		{
			con.Open();
			string cmdText = fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialRequisition_Master.CompId='" + CompId + "' AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id='" + MId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, con);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("IssQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			string value = "";
			string value2 = "";
			string value3 = "";
			double num = 0.0;
			double num2 = 0.0;
			string text = "";
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + sqlDataReader["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(sqlDataReader["ItemId"].ToString()));
					value2 = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
					string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						value3 = dataSet2.Tables[0].Rows[0][0].ToString();
					}
				}
				string cmdText4 = fun.select("Symbol", "BusinessGroup", "Id='" + sqlDataReader["DeptId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet3.Tables[0].Rows[0][0].ToString();
					dataRow[5] = "NA";
				}
				else
				{
					dataRow[4] = "NA";
					dataRow[5] = sqlDataReader["WONo"].ToString();
				}
				dataRow[0] = value;
				dataRow[1] = value2;
				dataRow[2] = value3;
				if (num == 0.0)
				{
					dataRow[3] = 0;
				}
				else
				{
					dataRow[3] = num;
				}
				num2 = Convert.ToDouble(decimal.Parse(sqlDataReader["ReqQty"].ToString()).ToString("N3"));
				dataRow[6] = num2;
				text = sqlDataReader["Remarks"].ToString();
				dataRow[7] = text;
				dataRow[8] = sqlDataReader["Id"].ToString();
				string cmdText5 = fun.select("sum(tblInv_MaterialIssue_Details.IssueQty) as sum_IssuedQty", "tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details", "tblInv_MaterialIssue_Master.CompId='" + CompId + "' AND tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialIssue_Details.MRSId='" + sqlDataReader["Id"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows[0]["sum_IssuedQty"] != DBNull.Value)
				{
					dataRow[9] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["sum_IssuedQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[9] = "0";
				}
				dataRow[10] = sqlDataReader["ItemId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			loadgrid();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialIssueNote_MIN_New.aspx?ModId=9&SubModId=41");
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			string cmdText = fun.select("MINNo", "tblInv_MaterialIssue_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by MINNo Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblInv_MaterialIssue_Master");
			string text = "";
			text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num = 1;
			string text2 = "";
			int num2 = 0;
			int num3 = 0;
			con.Open();
			string text3 = string.Empty;
			foreach (GridViewRow row in GridView3.Rows)
			{
				if (!((CheckBox)row.FindControl("ck")).Checked)
				{
					continue;
				}
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				int num7 = Convert.ToInt32(((Label)row.FindControl("lblitemid")).Text);
				int num8 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				num6 = Math.Round(Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblreqty")).Text.ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblissty")).Text.ToString()).ToString("N3")), 5);
				string cmdText2 = fun.select("StockQty", "tblDG_Item_Master", "Id='" + num7 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
				{
					num4 = Math.Round(Convert.ToDouble(decimal.Parse(sqlDataReader["StockQty"].ToString()).ToString("N3")), 5);
				}
				if (!(num4 > 0.0) || !(num6 > 0.0))
				{
					continue;
				}
				double num9 = 0.0;
				double num10 = 0.0;
				if (num4 >= num6)
				{
					num9 = Math.Round(num4 - num6, 5);
					num10 = num6;
				}
				else
				{
					num9 = 0.0;
					num10 = num4;
				}
				if (num == 1)
				{
					string cmdText3 = fun.insert("tblInv_MaterialIssue_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,MINNo,MRSNo,MRSId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + Sid + "','" + text + "','" + mrsno + "','" + MId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					sqlCommand2.ExecuteNonQuery();
					num = 0;
					string cmdText4 = fun.select("Id", "tblInv_MaterialIssue_Master", "CompId='" + CompId + "' Order by Id Desc");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, con);
					SqlDataReader sqlDataReader2 = sqlCommand3.ExecuteReader();
					sqlDataReader2.Read();
					text2 = sqlDataReader2["Id"].ToString();
				}
				string cmdText5 = fun.insert("tblInv_MaterialIssue_Details", "MId,MINNo,MRSId,IssueQty", "'" + text2 + "','" + text + "','" + num8 + "','" + num10 + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText5, con);
				sqlCommand4.ExecuteNonQuery();
				string cmdText6 = fun.update("tblDG_Item_Master", "StockQty='" + num9 + "'", "Id='" + num7 + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText6, con);
				sqlCommand5.ExecuteNonQuery();
				num3++;
				string cmdText7 = fun.select("StockQty,ItemCode", "tblDG_Item_Master", "Id='" + num7 + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText7, con);
				SqlDataReader sqlDataReader3 = sqlCommand6.ExecuteReader();
				while (sqlDataReader3.Read())
				{
					num5 = Math.Round(Convert.ToDouble(decimal.Parse(sqlDataReader3["StockQty"].ToString()).ToString("N3")), 5);
					double num11 = 0.0;
					num11 = num5 - num9;
					if (num11 != 0.0)
					{
						object obj = text3;
						text3 = string.Concat(obj, "ItemCode:", sqlDataReader3["ItemCode"].ToString(), "StockQty:", num5, ";");
						num2++;
					}
				}
			}
			if (num2 > 0)
			{
				string text4 = "";
				string cmdText8 = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText8, con);
				SqlDataReader sqlDataReader4 = sqlCommand7.ExecuteReader();
				sqlDataReader4.Read();
				SmtpMail.SmtpServer = sqlDataReader4["MailServerIp"].ToString();
				text4 = sqlDataReader4["ErpSysmail"].ToString();
				msg.From = text4;
				msg.To = "ashish@sapl.com";
				msg.Subject = "Stock Tracing If wrong operation in MIN";
				msg.Body = text3 + "\nDear Sir, This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
				msg.BodyFormat = MailFormat.Html;
				SmtpMail.Send(msg);
			}
			Thread.Sleep(1000);
			if (num3 > 0)
			{
				base.Response.Redirect("~/Module/Inventory/Transactions/MaterialIssueNote_MIN_New.aspx?ModId=9&SubModId=41");
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
