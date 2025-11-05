using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Accounts_Masters_Bank : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = string.Empty;

	protected GridView GridView1;

	protected Label lblMessage;

	protected SqlDataSource SqlDataSource2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		lblMessage.Text = "";
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		try
		{
			if (!base.IsPostBack)
			{
				FillGrid();
				if (GridView1.Rows.Count > 0)
				{
					fillState1();
				}
				else
				{
					fillState2();
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			if (e.CommandName == "Add")
			{
				string text = ((TextBox)GridView1.FooterRow.FindControl("txtBank1")).Text;
				string text2 = ((TextBox)GridView1.FooterRow.FindControl("txtAddress1")).Text;
				int num = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpCountry1")).SelectedValue);
				int num2 = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("Drpstate1")).SelectedValue);
				int num3 = Convert.ToInt32(((DropDownList)GridView1.FooterRow.FindControl("DrpCity1")).SelectedValue);
				string text3 = ((TextBox)GridView1.FooterRow.FindControl("txtPINNo1")).Text;
				string text4 = ((TextBox)GridView1.FooterRow.FindControl("txtContactNo1")).Text;
				string text5 = ((TextBox)GridView1.FooterRow.FindControl("txtFaxNo1")).Text;
				string text6 = ((TextBox)GridView1.FooterRow.FindControl("txtIFSC1")).Text;
				if (text != "")
				{
					string cmdText = fun.insert("tblACC_Bank", "Name,  Address, Country ,State,City , PINNo , ContactNo , FaxNo , IFSC ", "'" + text + "','" + text2 + "','" + num + "','" + num2 + "','" + num3 + "','" + text3 + "','" + text4 + "','" + text5 + "','" + text6 + "'");
					sqlConnection.Open();
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					sqlConnection.Close();
					base.Response.Redirect("Bank.aspx");
				}
			}
			if (e.CommandName == "Add1")
			{
				string text7 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtName2")).Text;
				string text8 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextAdddress2")).Text;
				int num4 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCountry2")).SelectedValue);
				int num5 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("Drpstate2")).SelectedValue);
				int num6 = Convert.ToInt32(((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DrpCity2")).SelectedValue);
				string text9 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextPinNo2")).Text;
				string text10 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextContactNo2")).Text;
				string text11 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextFaxNo2")).Text;
				string text12 = ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TextIFSC2")).Text;
				if (text7 != "" && text8 != "" && text9 != "" && text10 != "" && text11 != "" && text12 != "")
				{
					string cmdText2 = fun.insert("tblACC_Bank", "Name,  Address, Country ,State,City , PINNo , ContactNo , FaxNo , IFSC ", "'" + text7 + "','" + text8 + "','" + num4 + "','" + num5 + "','" + num6 + "','" + text9 + "','" + text10 + "','" + text11 + "','" + text12 + "'");
					sqlConnection.Open();
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					sqlConnection.Close();
					base.Response.Redirect("Bank.aspx");
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
			string text = ((TextBox)gridViewRow.FindControl("txtBank")).Text;
			string text2 = ((TextBox)gridViewRow.FindControl("txtAddress")).Text;
			int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpCountry")).SelectedValue);
			int num3 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("Drpstate")).SelectedValue);
			int num4 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpCity")).SelectedValue);
			string text3 = ((TextBox)gridViewRow.FindControl("txtPINNo")).Text;
			string text4 = ((TextBox)gridViewRow.FindControl("txtContactNo")).Text;
			string text5 = ((TextBox)gridViewRow.FindControl("txtFaxNo")).Text;
			string text6 = ((TextBox)gridViewRow.FindControl("txtIFSC")).Text;
			if (text != "" && text2 != "" && text3 != "" && text4 != "" && text5 != "" && text6 != "")
			{
				sqlConnection.Open();
				string cmdText = "UPDATE tblACC_Bank SET Name='" + text + "',  Address='" + text2 + "', Country='" + num2 + "' ,State='" + num3 + "',City='" + num4 + "' , PINNo='" + text3 + "' , ContactNo='" + text4 + "' , FaxNo='" + text5 + "' , IFSC='" + text6 + "' WHERE Id ='" + num + "'";
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

	protected void DrpCountry_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DropDownList dropDownList = (DropDownList)sender;
			GridViewRow gridViewRow = (GridViewRow)dropDownList.Parent.Parent;
			DropDownList dpdlState = gridViewRow.FindControl("Drpstate") as DropDownList;
			DropDownList dropDownList2 = gridViewRow.FindControl("DrpCity") as DropDownList;
			fun.dropdownState(dpdlState, dropDownList2, dropDownList);
			dropDownList2.Items.Clear();
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCountry1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			fillState1();
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCountry2_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			fillState2();
		}
		catch (Exception)
		{
		}
	}

	protected void Drpstate1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			fillCity1();
		}
		catch (Exception)
		{
		}
	}

	protected void Drpstate2_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			fillCity2();
		}
		catch (Exception)
		{
		}
	}

	protected void Drpstate_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			DropDownList dropDownList = (DropDownList)sender;
			GridViewRow gridViewRow = (GridViewRow)dropDownList.Parent.Parent;
			DropDownList dpdlCity = gridViewRow.FindControl("DrpCity") as DropDownList;
			fun.dropdownCity(dpdlCity, dropDownList);
		}
		catch (Exception)
		{
		}
	}

	public void fillState1()
	{
		DropDownList dpdlCountry = GridView1.FooterRow.FindControl("DrpCountry1") as DropDownList;
		DropDownList dpdlState = GridView1.FooterRow.FindControl("Drpstate1") as DropDownList;
		DropDownList dropDownList = GridView1.FooterRow.FindControl("DrpCity1") as DropDownList;
		fun.dropdownState(dpdlState, dropDownList, dpdlCountry);
		dropDownList.Items.Clear();
	}

	public void fillCity1()
	{
		DropDownList dpdlState = GridView1.FooterRow.FindControl("Drpstate1") as DropDownList;
		DropDownList dpdlCity = GridView1.FooterRow.FindControl("DrpCity1") as DropDownList;
		fun.dropdownCity(dpdlCity, dpdlState);
	}

	public void fillState2()
	{
		DropDownList dpdlCountry = GridView1.Controls[0].Controls[0].FindControl("DrpCountry2") as DropDownList;
		DropDownList dpdlState = GridView1.Controls[0].Controls[0].FindControl("Drpstate2") as DropDownList;
		DropDownList dpdlCity = GridView1.Controls[0].Controls[0].FindControl("DrpCity2") as DropDownList;
		fun.dropdownState(dpdlState, dpdlCity, dpdlCountry);
	}

	public void fillCity2()
	{
		DropDownList dpdlState = GridView1.Controls[0].Controls[0].FindControl("Drpstate2") as DropDownList;
		DropDownList dpdlCity = GridView1.Controls[0].Controls[0].FindControl("DrpCity2") as DropDownList;
		fun.dropdownCity(dpdlCity, dpdlState);
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			FillGrid();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			DropDownList dropDownList = gridViewRow.FindControl("DrpCountry") as DropDownList;
			DropDownList dropDownList2 = gridViewRow.FindControl("Drpstate") as DropDownList;
			DropDownList dropDownList3 = gridViewRow.FindControl("DrpCity") as DropDownList;
			string text = ((Label)gridViewRow.FindControl("lblCountryE")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblState1")).Text;
			string text3 = ((Label)gridViewRow.FindControl("lblCIty1")).Text;
			dropDownList.SelectedValue = text;
			fun.dropdownState(dropDownList2, dropDownList3, dropDownList);
			dropDownList2.SelectedValue = text2;
			fun.dropdownCity(dropDownList3, dropDownList2);
			dropDownList3.SelectedValue = text3;
		}
		catch (Exception)
		{
		}
	}

	public void FillGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[GetBank_Details]", con);
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

	protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand(fun.delete("tblACC_Bank", "Id='" + num + "'"), con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}
}
