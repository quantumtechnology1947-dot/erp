using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Accounts_Masters_Payement_Receipt_Against : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Panel Panel1;

	protected TabPanel Add;

	protected GridView GridView2;

	protected SqlDataSource SqlDataSource2;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text;
				if (text != "")
				{
					SqlDataSource1.InsertParameters["Description"].DefaultValue = text;
					SqlDataSource1.Insert();
				}
			}
			if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
				if (text2 != "")
				{
					SqlDataSource1.InsertParameters["Description"].DefaultValue = text2;
					SqlDataSource1.Insert();
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
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtTerms1")).Text;
			if (text != "")
			{
				sqlConnection.Open();
				string cmdText = "UPDATE tblACC_PaymentAgainst SET Description ='" + text + "' WHERE Id ='" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView2.FooterRow.FindControl("txtTerms2")).Text;
				if (text != "")
				{
					SqlDataSource2.InsertParameters["Description"].DefaultValue = text;
					SqlDataSource2.Insert();
				}
			}
			if (e.CommandName == "Add1")
			{
				string text2 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
				if (text2 != "")
				{
					SqlDataSource2.InsertParameters["Description"].DefaultValue = text2;
					SqlDataSource2.Insert();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			new DataSet();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtTerms1")).Text;
			if (text != "")
			{
				sqlConnection.Open();
				string cmdText = "UPDATE tblACC_ReceiptAgainst SET description ='" + text + "' WHERE Id ='" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
		}
		catch (Exception)
		{
		}
	}
}
