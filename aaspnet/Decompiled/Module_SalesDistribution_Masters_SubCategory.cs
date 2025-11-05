using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Masters_SubCategory : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected SqlDataSource LocalSqlServer;

	protected SqlDataSource SqlDataSource1;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				int num = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("ddCategory")).SelectedValue);
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtSCName")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtSymbol")).Text;
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				string cmdText = fun.select("Symbol", "tblSD_WO_SubCategory", " CId='" + num + "' AND  Symbol='" + text2 + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					if (text != "" && text2 != "")
					{
						LocalSqlServer.InsertParameters["CId"].DefaultValue = num.ToString();
						LocalSqlServer.InsertParameters["SCName"].DefaultValue = text;
						LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text2.ToUpper();
						LocalSqlServer.Insert();
						lblMessage.Text = "Record Inserted.";
					}
				}
				else
				{
					string empty = string.Empty;
					empty = "SubCategory symbol is already used.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else if (e.CommandName == "Add1")
			{
				int num2 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("ddCategory")).SelectedValue);
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSCName")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtSymbol")).Text;
				if (text3 != "" && text4 != "")
				{
					LocalSqlServer.InsertParameters["CId"].DefaultValue = num2.ToString();
					LocalSqlServer.InsertParameters["SCName"].DefaultValue = text3;
					LocalSqlServer.InsertParameters["Symbol"].DefaultValue = text4.ToUpper();
					LocalSqlServer.Insert();
					lblMessage.Text = "Record Inserted";
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
			foreach (GridViewRow row in GridView1.Rows)
			{
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				int num = Convert.ToInt32(((Label)row.FindControl("lblCId2")).Text);
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblSCId0")).Text);
				string cmdText = "SELECT  SCId FROM  SD_Cust_WorkOrder_Master where   CId='" + num + "' And SCId='" + num2 + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					LinkButton linkButton3 = (LinkButton)row.Cells[1].Controls[0];
					linkButton3.Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted";
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			DropDownList dropDownList = (DropDownList)gridViewRow.FindControl("ddCategory1");
			string selectedValue = dropDownList.SelectedValue;
			string text = selectedValue;
			string text2 = ((TextBox)gridViewRow.FindControl("txtSCName1")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblSymbol1")).Text;
			_ = ((Label)gridViewRow.FindControl("lblSCId")).Text;
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("Symbol", "tblSD_WO_SubCategory", " CId='" + text + "' AND  Symbol='" + text3 + "' ");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count == 0)
			{
				if (text2 != "" && text3 != "")
				{
					LocalSqlServer.UpdateParameters["CId"].DefaultValue = text;
					LocalSqlServer.UpdateParameters["SCName"].DefaultValue = text2;
					LocalSqlServer.Update();
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "SubCategory symbol is already used.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
	}
}
