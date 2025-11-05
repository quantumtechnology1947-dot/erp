using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_HR_Masters_PF_Slab : Page, IRequiresSessionState
{
	protected GridView GridView1;

	protected Label lblMessage;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		if (!base.IsPostBack)
		{
			FillAccegrid();
		}
	}

	protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
	{
		lblMessage.Text = "Record Updated.";
	}

	protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
	{
		lblMessage.Text = "Record Deleted.";
	}

	public void FillAccegrid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			new DataTable();
			string cmdText = "SELECT * FROM [tblHR_PF_Slab] order by [Id] desc";
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			string cmdText2 = "SELECT Active FROM [tblHR_PF_Slab] where Active=1 order by [Id] desc";
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				((CheckBox)GridView1.FooterRow.FindControl("ChkActive")).Enabled = false;
			}
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
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtPFEmployee")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtPFCompany")).Text;
				int num = 0;
				if (((CheckBox)GridView1.FooterRow.FindControl("ChkActive")).Checked)
				{
					num = 1;
				}
				if (text != "" && text2 != "" && fun.NumberValidation(((TextBox)GridView1.FooterRow.FindControl("txtPFEmployee")).Text) && fun.NumberValidation(((TextBox)GridView1.FooterRow.FindControl("txtPFCompany")).Text))
				{
					string cmdText = fun.insert("tblHR_PF_Slab", "PFEmployee,PFCompany,Active ", "'" + text + "','" + text2 + "','" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					FillAccegrid();
				}
			}
			else if (e.CommandName == "Add1")
			{
				string text3 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPFEmployee1")).Text;
				string text4 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPFCompany1")).Text;
				int num2 = 0;
				if (((CheckBox)GridView1.Controls[0].Controls[0].FindControl("ChkActive1")).Checked)
				{
					num2 = 1;
				}
				if (text3 != "" && text4 != "" && fun.NumberValidation(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPFEmployee1")).Text) && fun.NumberValidation(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtPFCompany1")).Text))
				{
					string cmdText2 = fun.insert("tblHR_PF_Slab", "PFEmployee,PFCompany,Active ", "'" + text3 + "','" + text4 + "','" + num2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillAccegrid();
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

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			string text = ((TextBox)gridViewRow.FindControl("txtPFEmployee0")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtPFCompany0")).Text;
			int num2 = 0;
			if (((CheckBox)gridViewRow.FindControl("ChkActive0")).Checked)
			{
				num2 = 1;
			}
			if (text != "" && text2 != "" && fun.NumberValidation(((TextBox)gridViewRow.FindControl("txtPFEmployee0")).Text) && fun.NumberValidation(((TextBox)gridViewRow.FindControl("txtPFCompany0")).Text))
			{
				string cmdText = fun.update("tblHR_PF_Slab", "PFEmployee='" + text + "',PFCompany='" + text2 + "',Active='" + num2 + "'", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				GridView1.EditIndex = -1;
				FillAccegrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			FillAccegrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblIDE")).Text);
			string cmdText = fun.select("*", "tblHR_PF_Slab", "Id='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Active"]) == 1)
			{
				((CheckBox)gridViewRow.FindControl("ChkActive0")).Checked = true;
				((CheckBox)gridViewRow.FindControl("ChkActive0")).Enabled = true;
				return;
			}
			((CheckBox)gridViewRow.FindControl("ChkActive0")).Checked = false;
			string cmdText2 = "SELECT Active FROM [tblHR_PF_Slab] where Active=1 order by [Id] desc";
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				((CheckBox)gridViewRow.FindControl("ChkActive0")).Enabled = false;
			}
			else
			{
				((CheckBox)gridViewRow.FindControl("ChkActive0")).Enabled = true;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		FillAccegrid();
	}

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblHR_PF_Slab", "Id='" + num + "'"), sqlConnection);
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			FillAccegrid();
		}
		catch (Exception)
		{
		}
	}
}
