using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Transactions_SMS : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string msg = "";

	protected TextBox TextBox1;

	protected TextBox TextBox2;

	protected GridView GridView2;

	protected Button Button2;

	protected Label Label2;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			Label2.Text = "";
			sqlConnection.Open();
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("EmpId,Title,EmployeeName,Department,MobileNo", "tblHR_OfficeStaff", "CompId='" + num + "' AND ResignationDate='' AND FinYearId<='" + num2 + "' AND UserID!='1'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EmpNo", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MobileNo", typeof(string)));
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						dataRow[0] = dataSet.Tables[0].Rows[i]["Title"].ToString() + ". " + dataSet.Tables[0].Rows[i]["EmployeeName"].ToString();
						dataRow[1] = dataSet.Tables[0].Rows[i]["EmpId"].ToString();
						string cmdText2 = fun.select("Symbol", "tblHR_Departments", "Id='" + dataSet.Tables[0].Rows[i]["Department"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						dataRow[2] = dataSet2.Tables[0].Rows[0]["Symbol"].ToString();
						string cmdText3 = fun.select("MobileNo", "tblHR_CoporateMobileNo", string.Concat("Id='", dataSet.Tables[0].Rows[i]["MobileNo"], "'"));
						SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						dataRow[3] = dataSet3.Tables[0].Rows[0]["MobileNo"].ToString();
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
				GridView2.DataSource = dataTable;
				GridView2.DataBind();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				Label2.Text = base.Request.QueryString["msg"];
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			int num = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("MobileNo,Password", "tblCompany_master", "CompId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblCompany_master");
			List<string> list = new List<string>();
			if (TextBox1.Text != "")
			{
				string[] array = TextBox1.Text.Split(',');
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(send(dataSet.Tables[0].Rows[0]["MobileNo"].ToString(), dataSet.Tables[0].Rows[0]["Password"].ToString(), TextBox2.Text, array[i]));
				}
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox2")).Checked && ((Label)row.FindControl("MobileNo")).Text != "")
				{
					list.Add(send(dataSet.Tables[0].Rows[0]["MobileNo"].ToString(), dataSet.Tables[0].Rows[0]["Password"].ToString(), TextBox2.Text, ((Label)row.FindControl("MobileNo")).Text));
				}
			}
			int num2 = 0;
			while (num2 < list.Count - 1)
			{
				if (list[num2] == list[num2 + 1])
				{
					list.RemoveAt(num2);
				}
				else
				{
					num2++;
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				string text = "";
				switch (list[j])
				{
				case "1":
					text = "Message is Send Successfully, ";
					break;
				case "-1":
					text = "Server error, ";
					break;
				case "-2":
					text = "Invalid username, ";
					break;
				case "-3":
					text = "Invalid message text, ";
					break;
				case "-4":
					text = "Login failed, ";
					break;
				}
				msg += text;
			}
			if (list.Count == 0)
			{
				msg = "Server error. ";
			}
			base.Response.Redirect("~/Module/HR/Transactions/SMS.aspx?msg=" + msg);
		}
		catch (Exception)
		{
		}
	}

	public string send(string uid, string password, string message, string no)
	{
		string result = "";
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://ubaid.tk/sms/sms.aspx?uid=" + uid + "&pwd=" + password + "&msg=" + message + "&phone=" + no + "&provider=way2sms");
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
			result = streamReader.ReadToEnd();
			streamReader.Close();
			httpWebResponse.Close();
			return result;
		}
		catch (Exception)
		{
			Label2.Text = "Message sending failed.,Connection error or invalid no.";
			return result;
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			if (checkBox.Checked)
			{
				foreach (GridViewRow row in GridView2.Rows)
				{
					((CheckBox)row.FindControl("CheckBox2")).Checked = true;
				}
				return;
			}
			foreach (GridViewRow row2 in GridView2.Rows)
			{
				((CheckBox)row2.FindControl("CheckBox2")).Checked = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (!((CheckBox)row.FindControl("CheckBox2")).Checked)
				{
					((CheckBox)GridView2.HeaderRow.FindControl("CheckBox1")).Checked = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
