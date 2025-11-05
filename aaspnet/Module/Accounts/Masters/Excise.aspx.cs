using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_Excise : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

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
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtTerms2")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtValue2")).Text;
				string text3 = ((TextBox)GridView1.FooterRow.FindControl("TextBox1")).Text;
				string text4 = ((TextBox)GridView1.FooterRow.FindControl("TextBox2")).Text;
				string text5 = ((TextBox)GridView1.FooterRow.FindControl("TextBox3")).Text;
				if (fun.NumberValidationQty(text2) && fun.NumberValidationQty(text3) && fun.NumberValidationQty(text4) && fun.NumberValidationQty(text5) && text3 != "" && text4 != "" && text != "" && text2 != "" && text5 != "")
				{
					int num = 0;
					if (((CheckBox)GridView1.FooterRow.FindControl("CheckBox1")).Checked)
					{
						num = 1;
						string connectionString = fun.Connection();
						SqlConnection sqlConnection = new SqlConnection(connectionString);
						string cmdText = "update tblExciseser_Master Set Live=0";
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlConnection.Open();
						sqlCommand.ExecuteNonQuery();
						sqlConnection.Close();
					}
					int num2 = 0;
					if (((CheckBox)GridView1.FooterRow.FindControl("CheckBox2")).Checked)
					{
						num2 = 1;
						string connectionString2 = fun.Connection();
						SqlConnection sqlConnection2 = new SqlConnection(connectionString2);
						string cmdText2 = "update tblExciseser_Master Set LiveSerTax=0";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection2);
						sqlConnection2.Open();
						sqlCommand2.ExecuteNonQuery();
						sqlConnection2.Close();
					}
					SqlDataSource1.InsertParameters["Terms"].DefaultValue = text;
					SqlDataSource1.InsertParameters["Value"].DefaultValue = text2;
					SqlDataSource1.InsertParameters["AccessableValue"].DefaultValue = text3;
					SqlDataSource1.InsertParameters["EDUCess"].DefaultValue = text4;
					SqlDataSource1.InsertParameters["SHECess"].DefaultValue = text5;
					SqlDataSource1.InsertParameters["Live"].DefaultValue = num.ToString();
					SqlDataSource1.InsertParameters["LiveSerTax"].DefaultValue = num2.ToString();
					SqlDataSource1.Insert();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					lblMessage.Text = "Record Inserted";
				}
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			string text6 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
			string text7 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text;
			string text8 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox_1")).Text;
			string text9 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox_2")).Text;
			string text10 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextBox_3")).Text;
			int num3 = 0;
			if (fun.NumberValidationQty(text7) && fun.NumberValidationQty(text8) && fun.NumberValidationQty(text9) && fun.NumberValidationQty(text10) && text8 != "" && text9 != "" && text6 != "" && text7 != "" && text10 != "")
			{
				if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox_1")).Checked)
				{
					num3 = 1;
				}
				int num4 = 0;
				if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox_2")).Checked)
				{
					num4 = 1;
				}
				SqlDataSource1.InsertParameters["Terms"].DefaultValue = text6;
				SqlDataSource1.InsertParameters["Value"].DefaultValue = text7;
				SqlDataSource1.InsertParameters["AccessableValue"].DefaultValue = text8;
				SqlDataSource1.InsertParameters["EDUCess"].DefaultValue = text9;
				SqlDataSource1.InsertParameters["SHECess"].DefaultValue = text10;
				SqlDataSource1.InsertParameters["Live"].DefaultValue = num3.ToString();
				SqlDataSource1.InsertParameters["LiveSerTax"].DefaultValue = num4.ToString();
				SqlDataSource1.Insert();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				lblMessage.Text = "Record Inserted";
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
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((Label)row.FindControl("txtLive")).Text == "1")
				{
					((Label)row.FindControl("txtLive")).Text = "Live";
				}
				else if (((Label)row.FindControl("txtLive")).Text == "0")
				{
					((Label)row.FindControl("txtLive")).Text = "";
				}
				if (((Label)row.FindControl("txtLiveSerTax")).Text == "1")
				{
					((Label)row.FindControl("txtLiveSerTax")).Text = "Live";
				}
				else if (((Label)row.FindControl("txtLiveSerTax")).Text == "0")
				{
					((Label)row.FindControl("txtLiveSerTax")).Text = "";
				}
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
			string text2 = ((TextBox)gridViewRow.FindControl("txtValue1")).Text;
			string text3 = ((TextBox)gridViewRow.FindControl("txtAccessableValue0")).Text;
			string text4 = ((TextBox)gridViewRow.FindControl("txtEDUCess0")).Text;
			string text5 = ((TextBox)gridViewRow.FindControl("txtSHECess0")).Text;
			if (fun.NumberValidationQty(text2) && fun.NumberValidationQty(text3) && fun.NumberValidationQty(text4) && fun.NumberValidationQty(text5) && text3 != "" && text4 != "" && text != "" && text2 != "" && text5 != "")
			{
				int num2 = 0;
				if (((CheckBox)gridViewRow.FindControl("CheckBox01")).Checked)
				{
					num2 = 1;
					string cmdText = fun.update("tblExciseser_Master", "Live=0", "Id !='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				int num3 = 0;
				if (((CheckBox)gridViewRow.FindControl("CheckBox02")).Checked)
				{
					num3 = 1;
					string cmdText2 = fun.update("tblExciseser_Master", "LiveSerTax=0", "Id !='" + num + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlConnection.Open();
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
				}
				SqlDataSource1.UpdateParameters["Terms"].DefaultValue = text;
				SqlDataSource1.UpdateParameters["Value"].DefaultValue = text2;
				SqlDataSource1.UpdateParameters["AccessableValue"].DefaultValue = text3;
				SqlDataSource1.UpdateParameters["EDUCess"].DefaultValue = text4;
				SqlDataSource1.UpdateParameters["SHECess"].DefaultValue = text5;
				SqlDataSource1.UpdateParameters["Live"].DefaultValue = num2.ToString();
				SqlDataSource1.UpdateParameters["LiveSerTax"].DefaultValue = num3.ToString();
				SqlDataSource1.Update();
			}
		}
		catch (Exception)
		{
		}
	}
}
