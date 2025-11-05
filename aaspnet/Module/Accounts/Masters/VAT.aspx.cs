using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_VAT : Page, IRequiresSessionState
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
				int num = 0;
				int num2 = 0;
				if (((CheckBox)GridView1.FooterRow.FindControl("CKIsVAT")).Checked)
				{
					num = 1;
				}
				if (((CheckBox)GridView1.FooterRow.FindControl("CKIsCST")).Checked)
				{
					num2 = 1;
				}
				int num3 = 0;
				if (text != "" && text2 != "" && fun.NumberValidationQty(text2) && (!((CheckBox)GridView1.FooterRow.FindControl("CKIsCST")).Checked || !((CheckBox)GridView1.FooterRow.FindControl("CKIsVAT")).Checked))
				{
					if (((CheckBox)GridView1.FooterRow.FindControl("CheckBox2")).Checked)
					{
						num3 = 1;
						string connectionString = fun.Connection();
						SqlConnection sqlConnection = new SqlConnection(connectionString);
						string cmdText = "update tblVAT_Master Set Live=0";
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlConnection.Open();
						sqlCommand.ExecuteNonQuery();
						sqlConnection.Close();
					}
					SqlDataSource1.InsertParameters["Terms"].DefaultValue = text;
					SqlDataSource1.InsertParameters["Value"].DefaultValue = text2;
					SqlDataSource1.InsertParameters["Live"].DefaultValue = num3.ToString();
					SqlDataSource1.InsertParameters["IsVAT"].DefaultValue = num.ToString();
					SqlDataSource1.InsertParameters["IsCST"].DefaultValue = num2.ToString();
					SqlDataSource1.Insert();
					lblMessage.Text = "Record Inserted";
				}
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtTerms3")).Text;
			string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtValue3")).Text;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsVAT")).Checked)
			{
				num5 = 1;
			}
			if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsCST")).Checked)
			{
				num6 = 1;
			}
			if (text3 != "" && text4 != "" && fun.NumberValidationQty(text4) && (!((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsCST")).Checked || !((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CKIsVAT")).Checked))
			{
				if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("CheckBox_2")).Checked)
				{
					num4 = 1;
					string connectionString2 = fun.Connection();
					SqlConnection sqlConnection2 = new SqlConnection(connectionString2);
					string cmdText2 = "update tblVAT_Master Set Live=0";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection2);
					sqlConnection2.Open();
					sqlCommand2.ExecuteNonQuery();
					sqlConnection2.Close();
				}
				SqlDataSource1.InsertParameters["Terms"].DefaultValue = text3;
				SqlDataSource1.InsertParameters["Value"].DefaultValue = text4;
				SqlDataSource1.InsertParameters["Live"].DefaultValue = num4.ToString();
				SqlDataSource1.InsertParameters["IsVAT"].DefaultValue = num5.ToString();
				SqlDataSource1.InsertParameters["IsCST"].DefaultValue = num6.ToString();
				SqlDataSource1.Insert();
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
			int num2 = 0;
			if (text != "" && text2 != "" && fun.NumberValidationQty(text2))
			{
				if (((CheckBox)gridViewRow.FindControl("CheckBox02")).Checked)
				{
					num2 = 1;
					string cmdText = fun.update("tblVAT_Master", "Live=0", "Id !='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				SqlDataSource1.UpdateParameters["Terms"].DefaultValue = text;
				SqlDataSource1.UpdateParameters["Value"].DefaultValue = text2;
				SqlDataSource1.UpdateParameters["Live"].DefaultValue = num2.ToString();
				SqlDataSource1.Update();
			}
		}
		catch (Exception)
		{
		}
	}
}
