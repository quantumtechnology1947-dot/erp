using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MIS_Masters_Budget_Code : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource SqlDataSource1;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtValue2")).Text;
				if (text != "" && text2 != "")
				{
					string cmdText = fun.select("Symbol", "tblMIS_BudgetCode", "Symbol='" + text2 + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText, connection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet, "tblMIS_BudgetCode");
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						SqlDataSource1.InsertParameters["Description"].DefaultValue = text;
						SqlDataSource1.InsertParameters["Symbol"].DefaultValue = text2.ToUpper();
						SqlDataSource1.Insert();
						lblMessage.Text = "Record Inserted";
					}
					else
					{
						_ = string.Empty;
						string text3 = "Budget Code is already exists.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text3 + "');", addScriptTags: true);
					}
				}
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
			string text5 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text;
			if (text4 != "" && text5 != "")
			{
				string cmdText2 = fun.select("Symbol", "tblMIS_BudgetCode", "Symbol='" + text5 + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblMIS_BudgetCode");
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					SqlDataSource1.InsertParameters["Description"].DefaultValue = text4;
					SqlDataSource1.InsertParameters["Symbol"].DefaultValue = text5.ToUpper();
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
				else
				{
					_ = string.Empty;
					string text6 = "Budget Code is already exists.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text6 + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
				linkButton.Attributes.Add("onclick", "return confirmationUpdate();");
			}
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton linkButton2 = (LinkButton)e.Row.Cells[1].Controls[0];
				linkButton2.Attributes.Add("onclick", "return confirmationDelete();");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new DataSet();
			new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtTerms1")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtValue1")).Text;
			if (text != "" && text2 != "")
			{
				SqlDataSource1.UpdateParameters["Description"].DefaultValue = text;
				SqlDataSource1.UpdateParameters["Symbol"].DefaultValue = text2;
				SqlDataSource1.Update();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MIS/Transactions/Menu.aspx?ModId=14&SubModId=");
	}
}
