using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialPlanning_Transactions_Planning_Print : Page, IRequiresSessionState
{
	protected DropDownList DrpField;

	protected TextBox Txtsearch;

	protected Button Button1;

	protected GridView GridView1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string No = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				fillgrid(No);
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid(string no)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string value = "";
			if (DrpField.SelectedValue == "1" && Txtsearch.Text != "")
			{
				value = " AND tblMP_Material_Master.PLNo='" + Txtsearch.Text + "'";
			}
			string value2 = "";
			if (DrpField.SelectedValue == "0" && Txtsearch.Text != "")
			{
				value2 = " AND tblMP_Material_Master.WONo='" + Txtsearch.Text + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_Plan_WOGrid", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DrpField.SelectedValue == "0")
		{
			Txtsearch.Text = "";
			fillgrid(No);
		}
		else
		{
			Txtsearch.Text = "";
			fillgrid(No);
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			if (Txtsearch.Text != "")
			{
				fillgrid(Txtsearch.Text);
			}
			else
			{
				fillgrid(No);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblPLNo")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblFinYearId")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblWONo")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("Planning_Print_Details.aspx?MId=" + text + "&plno=" + text2 + "&FinYearId=" + text3 + "&WONo=" + text4 + "&Key=" + randomAlphaNumeric + "&ModId=4&SubModId=33");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView1_PageIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		fillgrid(No);
	}
}
