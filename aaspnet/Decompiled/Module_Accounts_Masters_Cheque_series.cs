using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_Cheque_series : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource SqlDataSource2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			FillGrid();
		}
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
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				int num = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpBank1")).SelectedValue);
				int num2 = Convert.ToInt32(((TextBox)GridView1.FooterRow.FindControl("txtStartNo1")).Text);
				int num3 = Convert.ToInt32(((TextBox)GridView1.FooterRow.FindControl("txtEndNo1")).Text);
				if (num2.ToString() != "" && num3.ToString() != "")
				{
					string cmdText = fun.insert("tblACC_ChequeNo", "BankId,StartNo,EndNo", "'" + num + "','" + num2 + "','" + num3 + "'");
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Add1")
			{
				int num4 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpBank2")).SelectedValue);
				int num5 = Convert.ToInt32(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtStartNo3")).Text);
				int num6 = Convert.ToInt32(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtEndNo3")).Text);
				if (num5.ToString() != "" && num6.ToString() != "")
				{
					string cmdText2 = fun.insert("tblACC_ChequeNo", "BankId,StartNo,EndNo", "'" + num4 + "','" + num5 + "','" + num6 + "'");
					sqlConnection.Open();
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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
			int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpBank")).SelectedValue);
			int num3 = Convert.ToInt32(((TextBox)gridViewRow.FindControl("txtStartNo")).Text);
			int num4 = Convert.ToInt32(((TextBox)gridViewRow.FindControl("txtEndNo")).Text);
			if (num3.ToString() != "" && num4.ToString() != "")
			{
				sqlConnection.Open();
				string cmdText = "UPDATE tblACC_ChequeNo SET BankId ='" + num2 + "',StartNo='" + num3 + "',EndNo='" + num4 + "' WHERE Id ='" + num + "'";
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_ChequeNo", "Id='" + num + "'"), sqlConnection);
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			FillGrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			DropDownList dropDownList = gridViewRow.FindControl("DrpBank") as DropDownList;
			string text = ((Label)gridViewRow.FindControl("lblBankId")).Text;
			dropDownList.SelectedValue = text;
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection selectConnection = new SqlConnection(connectionString);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[GetChequeNo]", selectConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			FillGrid();
		}
		catch (Exception)
		{
		}
	}
}
