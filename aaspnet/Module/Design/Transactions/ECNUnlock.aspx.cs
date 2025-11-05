using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mail;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_ECNUnlock : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string connStr = "";

	private string WONo = "";

	protected Label lblWono;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button Button1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			WONo = base.Request.QueryString["WONo"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblWono.Text = WONo;
			if (!base.IsPostBack)
			{
				loaddata();
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
			string cmdText = "SELECT Distinct(tblDG_ECN_Master.ItemId),Unit_Master.Symbol,tblDG_Item_Master.ItemCode, tblDG_Item_Master.ManfDesc, tblDG_ECN_Master.WONo FROM tblDG_ECN_Master INNER JOIN tblDG_Item_Master ON tblDG_ECN_Master.ItemId = tblDG_Item_Master.Id INNER JOIN Unit_Master ON tblDG_Item_Master.UOMBasic = Unit_Master.Id And tblDG_ECN_Master.WONo='" + WONo + "' And Flag=0 order by tblDG_ECN_Master.ItemId Desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string text = string.Empty;
				string text2 = string.Empty;
				double num = 0.0;
				num = fun.AllComponentBOMQty(CompId, WONo, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), FinYearId);
				dataRow[6] = num;
				string cmdText2 = "SELECT Id  FROM tblDG_ECN_Master Where WONo='" + WONo + "' And ItemId='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "'";
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					string cmdText3 = "SELECT  Remarks,Types FROM tblDG_ECN_Master INNER JOIN tblDG_ECN_Details ON tblDG_ECN_Master.Id = tblDG_ECN_Details.MId INNER JOIN tblDG_ECN_Reason ON tblDG_ECN_Reason.Id = tblDG_ECN_Details.ECNReason And tblDG_ECN_Details.MId='" + Convert.ToInt32(dataSet2.Tables[0].Rows[j]["Id"]) + "'";
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					for (int k = 0; k < dataSet3.Tables[0].Rows.Count; k++)
					{
						string text3 = string.Empty;
						if (text != "")
						{
							text3 = ", ";
						}
						string text4 = string.Empty;
						if (text2 != "")
						{
							text4 = ", ";
						}
						text = text + text3 + dataSet3.Tables[0].Rows[k]["Types"].ToString();
						text2 = text2 + text4 + dataSet3.Tables[0].Rows[k]["Remarks"].ToString();
					}
				}
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]);
				dataRow[1] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[3] = dataSet.Tables[0].Rows[i]["Symbol"].ToString();
				dataRow[4] = text;
				dataRow[5] = text2;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			_ = (GridViewRow)checkBox.NamingContainer;
			if (checkBox.Checked)
			{
				foreach (GridViewRow row in GridView1.Rows)
				{
					((CheckBox)row.FindControl("CheckBox1")).Checked = true;
				}
				return;
			}
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				((CheckBox)row2.FindControl("CheckBox1")).Checked = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Design/Transactions/ECN_WO.aspx");
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			int num = 0;
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			string empty6 = string.Empty;
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("SRNo", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					DataRow dataRow = dataTable.NewRow();
					num++;
					int num2 = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
					string cmdText = fun.update("tblDG_BOM_Master", "ECNFlag=0", "ItemId='" + num2 + "' And WONo='" + WONo + "' And CompId='" + CompId + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					string cmdText2 = fun.update("tblDG_ECN_Master", "Flag=1", "ItemId='" + num2 + "'And WONo='" + WONo + "' And CompId='" + CompId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					sqlCommand2.ExecuteNonQuery();
					empty = ((Label)row.FindControl("lblItemCode")).Text;
					empty2 = ((Label)row.FindControl("lblManfDesc")).Text;
					empty3 = ((Label)row.FindControl("lblUOM")).Text;
					empty4 = ((Label)row.FindControl("lblBOMQty")).Text;
					empty5 = ((Label)row.FindControl("lblReason")).Text;
					empty6 = ((Label)row.FindControl("lblRemarks")).Text;
					dataRow[0] = num;
					dataRow[1] = empty;
					dataRow[2] = empty2;
					dataRow[3] = empty3;
					dataRow[4] = empty4;
					dataRow[5] = empty5;
					dataRow[6] = empty6;
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				MailMessage mailMessage = new MailMessage();
				string text = "<table width='100%' border='1' style='font-size:10pt'>";
				text += "<tr>";
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					string text2 = string.Empty;
					if (dataTable.Columns[i].ColumnName == "ItemCode")
					{
						text2 = "width='10%'";
					}
					string text3 = text;
					text = text3 + "<td align='center'" + text2 + ">" + dataTable.Columns[i].ColumnName + "</td>";
				}
				text += "</tr>";
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					text += "<tr>";
					for (int k = 0; k < dataTable.Columns.Count; k++)
					{
						text = text + "<td>" + dataTable.Rows[j][k].ToString() + "</td>";
					}
					text += "</tr>";
				}
				text += "</table>";
				string text4 = "";
				string cmdText3 = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					SmtpMail.SmtpServer = dataSet.Tables[0].Rows[0]["MailServerIp"].ToString();
					text4 = dataSet.Tables[0].Rows[0]["ErpSysmail"].ToString();
				}
				mailMessage.From = text4;
				mailMessage.Bcc = "shridhar@sapl.com,kumar@sapl.com,shrikrishna@sapl.com";
				mailMessage.Subject = "ECN Unlock";
				mailMessage.Body = "Work Order No :  " + WONo + "<br><br>" + text + "<br><br><br>This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
				mailMessage.BodyFormat = MailFormat.Html;
				SmtpMail.Send(mailMessage);
			}
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			con.Close();
		}
		catch (Exception)
		{
		}
	}
}
