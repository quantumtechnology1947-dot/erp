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

public class Module_Accounts_Reports_Search : Page, IRequiresSessionState
{
	protected DropDownList Drpoption;

	protected TextBox txtNo;

	protected RadioButton radGqn;

	protected RadioButton radgsn;

	protected CheckBox CkItem;

	protected TextBox txtItemcode;

	protected CheckBox CKwono;

	protected TextBox txtwono;

	protected CheckBox CkSupplier;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected CheckBox CkACCHead;

	protected RadioButton RbtnLabour;

	protected RadioButton RbtnWithMaterial;

	protected RadioButton RbtnExpenses;

	protected RadioButton RbtnServiceProvider;

	protected DropDownList DropDownList1;

	protected TextBox textFromDate;

	protected CalendarExtender textFromDate_CalendarExtender;

	protected RegularExpressionValidator ReqTDate;

	protected TextBox TextToDate;

	protected CalendarExtender cd1;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected CompareValidator CompareValidator1;

	protected RadioButton RadGin;

	protected RadioButton RadPO;

	protected Button BtnSearch;

	protected TabPanel PVEVId;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!base.IsPostBack)
			{
				AcHead();
			}
			if (Drpoption.SelectedValue == "0")
			{
				txtNo.Enabled = false;
			}
			else
			{
				txtNo.Enabled = true;
			}
			if (radGqn.Checked)
			{
				Drpoption.Items[2].Enabled = false;
				Drpoption.Items[1].Enabled = true;
			}
			else
			{
				Drpoption.Items[2].Enabled = true;
				Drpoption.Items[1].Enabled = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			string text = "";
			if (txtNo.Text != "")
			{
				text = txtNo.Text;
			}
			string text2 = "";
			if (CkItem.Checked)
			{
				text2 = txtItemcode.Text;
			}
			string text3 = "";
			if (CKwono.Checked)
			{
				text3 = txtwono.Text;
			}
			string text4 = "";
			if (CkSupplier.Checked)
			{
				text4 = fun.getCode(TxtSearchValue.Text);
			}
			string text5 = "";
			string text6 = "";
			if (textFromDate.Text != "" && TextToDate.Text != "")
			{
				text5 = textFromDate.Text;
				text6 = TextToDate.Text;
			}
			int num3 = 0;
			if (textFromDate.Text != "" && TextToDate.Text == "")
			{
				num3++;
			}
			if (textFromDate.Text == "" && TextToDate.Text != "")
			{
				num3++;
			}
			int num4 = 0;
			if (CkACCHead.Checked)
			{
				num4 = Convert.ToInt32(DropDownList1.SelectedValue);
			}
			num = (RadGin.Checked ? 1 : 0);
			num2 = (radGqn.Checked ? 1 : 0);
			if (num3 == 0)
			{
				if ((Drpoption.SelectedItem.Text != "All" && txtNo.Text != "") || (Drpoption.SelectedItem.Text == "All" && !txtNo.Enabled))
				{
					if ((CkItem.Checked && txtItemcode.Text != "") || (!CkItem.Checked && txtItemcode.Text == ""))
					{
						if ((CKwono.Checked && txtwono.Text != "") || (!CKwono.Checked && txtwono.Text == ""))
						{
							if ((CkSupplier.Checked && TxtSearchValue.Text != "") || (!CkSupplier.Checked && TxtSearchValue.Text == ""))
							{
								base.Response.Redirect("Search_details.aspx?type=" + Drpoption.SelectedValue + "&No=" + text + "&RAd2=" + num2 + "&RAd=" + num + "&Code=" + text2 + "&WONo=" + text3 + "&SupId=" + text4 + "&accval=" + num4 + "&FDate=" + text5 + "&TDate=" + text6);
							}
							else
							{
								string empty = string.Empty;
								empty = "Enter valid  " + CkSupplier.Text + "!";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Enter valid  " + CKwono.Text + "!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty3 = string.Empty;
						empty3 = "Enter valid  " + CkItem.Text + "!";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty4 = string.Empty;
					if (Drpoption.SelectedValue == "1" || Drpoption.SelectedValue == "2" || Drpoption.SelectedValue == "3" || Drpoption.SelectedValue == "4")
					{
						empty4 = "Enter valid  " + Drpoption.SelectedItem.Text + "!";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
					}
				}
			}
			else
			{
				string empty5 = string.Empty;
				empty5 = "Incorrect date entry!";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	public void AcHead()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		try
		{
			string text = "";
			if (RbtnLabour.Checked)
			{
				text = "Labour";
			}
			if (RbtnWithMaterial.Checked)
			{
				text = "With Material";
			}
			if (RbtnExpenses.Checked)
			{
				text = "Expenses";
			}
			if (RbtnServiceProvider.Checked)
			{
				text = "Service Provider";
			}
			string cmdText = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + text + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "AccHead");
			DropDownList1.DataSource = dataSet;
			DropDownList1.DataTextField = "Head";
			DropDownList1.DataValueField = "Id";
			DropDownList1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	protected void RbtnExpenses_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	protected void RbtnServiceProvider_CheckedChanged(object sender, EventArgs e)
	{
		AcHead();
	}

	[WebMethod]
	[ScriptMethod]
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

	protected void CkItem_CheckedChanged(object sender, EventArgs e)
	{
		if (CkItem.Checked)
		{
			txtItemcode.Enabled = true;
		}
		else
		{
			txtItemcode.Enabled = false;
		}
	}

	protected void CKwono_CheckedChanged(object sender, EventArgs e)
	{
		if (CKwono.Checked)
		{
			txtwono.Enabled = true;
		}
		else
		{
			txtwono.Enabled = false;
		}
	}

	protected void CkSupplier_CheckedChanged(object sender, EventArgs e)
	{
		if (CkSupplier.Checked)
		{
			TxtSearchValue.Enabled = true;
		}
		else
		{
			TxtSearchValue.Enabled = false;
		}
	}

	protected void radGqn_CheckedChanged(object sender, EventArgs e)
	{
		if (radGqn.Checked)
		{
			Drpoption.Items[2].Enabled = false;
			Drpoption.Items[1].Enabled = true;
		}
	}

	protected void radgsn_CheckedChanged(object sender, EventArgs e)
	{
		if (radgsn.Checked)
		{
			Drpoption.Items[1].Enabled = false;
			Drpoption.Items[2].Enabled = true;
		}
	}
}
