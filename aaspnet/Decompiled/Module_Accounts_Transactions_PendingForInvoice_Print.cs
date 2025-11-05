using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Transactions_PendingForInvoice_Print : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	protected DropDownList DropDownList1;

	protected TextBox txtCustName;

	protected AutoCompleteExtender txtCustName_AutoCompleteExtender;

	protected TextBox txtpoNo;

	protected Button btnSearch;

	protected HtmlGenericControl Iframe1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!Page.IsPostBack)
			{
				txtpoNo.Visible = false;
				txtCustName.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtpoNo.Visible = false;
				txtCustName.Visible = false;
				txtCustName.Text = string.Empty;
				txtpoNo.Text = string.Empty;
				Iframe1.Visible = false;
			}
			if (DropDownList1.SelectedValue == "1")
			{
				txtpoNo.Visible = false;
				txtCustName.Visible = true;
				txtCustName.Text = string.Empty;
				Iframe1.Visible = false;
			}
			if (DropDownList1.SelectedValue == "2")
			{
				txtpoNo.Visible = true;
				txtCustName.Visible = false;
				txtpoNo.Text = string.Empty;
				Iframe1.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
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

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			string text = "";
			string text2 = "";
			if (DropDownList1.SelectedValue.ToString() == "0")
			{
				text = string.Empty;
				text2 = string.Empty;
				Iframe1.Attributes.Add("src", "PendingForInvoice_Print_Details.aspx?C=" + text + "&W=" + text2 + "&Val=" + DropDownList1.SelectedValue + "&Key=" + randomAlphaNumeric);
				Iframe1.Visible = true;
			}
			if (DropDownList1.SelectedValue.ToString() == "1")
			{
				if (txtCustName.Text != string.Empty)
				{
					string code = fun.getCode(txtCustName.Text);
					int num = fun.chkCustomerCode(code);
					if (num == 1)
					{
						text = code;
						Iframe1.Attributes.Add("src", "PendingForInvoice_Print_Details.aspx?C=" + text + "&W=" + text2 + "&Val=" + DropDownList1.SelectedValue + "&Key=" + randomAlphaNumeric);
						Iframe1.Visible = true;
					}
					else
					{
						_ = string.Empty;
						string text3 = "Customer is not valid";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text3 + "');", addScriptTags: true);
					}
				}
				if (txtCustName.Text == string.Empty)
				{
					_ = string.Empty;
					string text4 = "Customer is not valid";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text4 + "');", addScriptTags: true);
				}
			}
			if (!(DropDownList1.SelectedValue.ToString() == "2"))
			{
				return;
			}
			if (txtpoNo.Text != string.Empty)
			{
				if (fun.CheckValidWONo(txtpoNo.Text, CompId, FinYearId))
				{
					text2 = txtpoNo.Text;
					Iframe1.Attributes.Add("src", "PendingForInvoice_Print_Details.aspx?C=" + text + "&W=" + text2 + "&Val=" + DropDownList1.SelectedValue + "&Key=" + randomAlphaNumeric);
					Iframe1.Visible = true;
				}
				else
				{
					_ = string.Empty;
					string text5 = "WONo is not valid";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text5 + "');", addScriptTags: true);
				}
			}
			if (txtpoNo.Text == string.Empty)
			{
				_ = string.Empty;
				string text6 = "WONo is not valid";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text6 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}
