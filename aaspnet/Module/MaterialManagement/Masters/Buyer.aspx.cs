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

public class Module_MaterialManagement_Masters_Buyer : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			lblMessage.Text = "";
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string selectedValue = ((DropDownList)GridView1.FooterRow.FindControl("DropCategory")).SelectedValue;
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtNos")).Text;
				string code = fun.getCode(((TextBox)GridView1.FooterRow.FindControl("txtBuyer")).Text);
				if (selectedValue != "Select" && text != "" && code != "")
				{
					string cmdText = fun.select("Nos", "tblMM_Buyer_Master", "Nos='" + text + "' And Category='" + selectedValue + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						SqlDataSource1.InsertParameters["Category"].DefaultValue = selectedValue;
						SqlDataSource1.InsertParameters["Nos"].DefaultValue = text;
						SqlDataSource1.InsertParameters["EmpId"].DefaultValue = code;
						SqlDataSource1.Insert();
						lblMessage.Text = "Record Inserted";
					}
					else
					{
						string empty = string.Empty;
						empty = "Record already exists.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			else
			{
				if (!(e.CommandName == "Add1"))
				{
					return;
				}
				string selectedValue2 = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropCategory")).SelectedValue;
				string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtNos")).Text;
				string code2 = fun.getCode(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtBuyer0")).Text);
				if (selectedValue2 != "Select" && text2 != "" && code2 != "")
				{
					string cmdText2 = fun.select("Nos", "tblMM_Buyer_Master", "Nos='" + text2 + "' And Category='" + selectedValue2 + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count == 0)
					{
						SqlDataSource1.InsertParameters["Category"].DefaultValue = selectedValue2;
						SqlDataSource1.InsertParameters["Nos"].DefaultValue = text2;
						SqlDataSource1.InsertParameters["EmpId"].DefaultValue = code2;
						SqlDataSource1.Insert();
						lblMessage.Text = "Record Inserted";
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Record already exists.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[2].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
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

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string code = fun.getCode(((TextBox)gridViewRow.FindControl("lblBuyer0")).Text);
			if (code != "")
			{
				SqlDataSource1.UpdateParameters["EmpId"].DefaultValue = code;
				SqlDataSource1.Update();
			}
		}
		catch (Exception)
		{
		}
	}
}
