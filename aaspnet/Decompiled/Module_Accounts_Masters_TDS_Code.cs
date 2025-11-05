using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_TDS_Code : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

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
				string text = ((TextBox)GridView1.FooterRow.FindControl("TextFSectionNo")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtFNatureOfPayment")).Text;
				double num = Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtFPaymentRange")).Text);
				string text3 = ((TextBox)GridView1.FooterRow.FindControl("txtFPayToIndividual")).Text;
				string text4 = ((TextBox)GridView1.FooterRow.FindControl("txtFOthers")).Text;
				string text5 = ((TextBox)GridView1.FooterRow.FindControl("txtFWithOutPAN")).Text;
				if (text.ToString() != "" && text2.ToString() != "" && text3 != "" && text4 != "" && num.ToString() != "" && text5.ToString() != "")
				{
					string cmdText = fun.insert("tblAcc_TDSCode_Master", "SectionNo,NatureOfPayment,PaymentRange,PayToIndividual,Others,WithOutPAN", "'" + text + "','" + text2 + "','" + num + "','" + text3 + "','" + text4 + "','" + text5 + "'");
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data input .";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty + "');", addScriptTags: true);
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Add1")
			{
				string text6 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtESectionNo")).Text;
				string text7 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtENatureOfPayment")).Text;
				double num2 = Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEPaymentRange")).Text);
				string text8 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEPayToIndividual")).Text;
				string text9 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtEOthers")).Text;
				string text10 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtFWithOutPAN")).Text;
				if (text6.ToString() != "" && text7.ToString() != "" && text8 != "" && text9 != "" && num2.ToString() != "")
				{
					string cmdText2 = fun.insert("tblAcc_TDSCode_Master", "SectionNo,NatureOfPayment,PaymentRange,PayToIndividual,Others,WithOutPAN", "'" + text6 + "','" + text7 + "','" + num2 + "','" + text8 + "','" + text9 + "','" + text10 + "'");
					sqlConnection.Open();
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid data input .";
					base.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + empty2 + "');", addScriptTags: true);
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
			string text = ((TextBox)gridViewRow.FindControl("TextSectionNo")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtNatureOfPayment")).Text;
			double num2 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtPaymentRange")).Text);
			string text3 = ((TextBox)gridViewRow.FindControl("txtPayToIndividual")).Text;
			string text4 = ((TextBox)gridViewRow.FindControl("txtOthers")).Text;
			string text5 = ((TextBox)gridViewRow.FindControl("txtWithOutPAN")).Text;
			if (text.ToString() != "" && text2.ToString() != "")
			{
				sqlConnection.Open();
				string cmdText = "UPDATE tblAcc_TDSCode_Master SET SectionNo ='" + text + "',NatureOfPayment='" + text2 + "',PaymentRange='" + num2 + "',PayToIndividual='" + text3 + "',Others='" + text4 + "',WithOutPAN='" + text5 + "' WHERE Id ='" + num + "'";
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
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblAcc_TDSCode_Master", "Id='" + num + "'"), sqlConnection);
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[GetTDSCode]", selectConnection);
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

	protected void GridView1_PageIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			FillGrid();
		}
		catch (Exception)
		{
		}
	}
}
