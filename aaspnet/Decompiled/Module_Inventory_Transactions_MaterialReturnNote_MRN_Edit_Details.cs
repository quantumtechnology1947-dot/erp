using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_MaterialReturnNote_MRN_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRNNo = "";

	private string FyId = "";

	private int CompId;

	private string sId = "";

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string MId = "";

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MId = base.Request.QueryString["Id"].ToString();
			MRNNo = base.Request.QueryString["MRNNo"].ToString();
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = base.Request.QueryString["FyId"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				LoadData();
			}
			getval();
		}
		catch (Exception)
		{
		}
	}

	public void disableEdit()
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
			string cmdText = fun.select("tblInv_MaterialReturn_Details.Id", "tblInv_MaterialReturn_Master,tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master,tblInv_MaterialReturn_Details", "tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.Id =tblQc_MaterialReturnQuality_Master.MRNId AND tblInv_MaterialReturn_Master.CompId ='" + CompId + "' AND tblInv_MaterialReturn_Details.Id=tblQc_MaterialReturnQuality_Details.MRNId AND tblInv_MaterialReturn_Details.Id='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				LinkButton linkButton = (LinkButton)row.FindControl("LinkButton1");
				linkButton.Visible = false;
				((Label)row.FindControl("lblmrqn")).Visible = true;
			}
		}
	}

	public void LoadData()
	{
		try
		{
			con.Open();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[Sp_MRN_FillGrid_EDPD]", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FyId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = MId;
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
			con.Close();
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		getval();
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			LoadData();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			((DropDownList)gridViewRow.FindControl("DropDownList1")).Visible = true;
			((Label)gridViewRow.FindControl("lblWODept")).Visible = false;
			string text = ((Label)gridViewRow.FindControl("lblDwpt")).Text;
			if (text == "1" && ((Label)gridViewRow.FindControl("lblWODept")).Text == "WONo")
			{
				((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue = "2";
				if (((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue == "2")
				{
					((TextBox)gridViewRow.FindControl("txtwono")).Visible = true;
					if (((TextBox)gridViewRow.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
					}
					((Label)gridViewRow.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((TextBox)gridViewRow.FindControl("txtwono")).Visible = false;
					if (!((TextBox)gridViewRow.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = false;
					}
				}
			}
			else
			{
				((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue = "1";
				if (((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue == "1")
				{
					((DropDownList)gridViewRow.FindControl("drpdept")).Visible = true;
					((Label)gridViewRow.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((DropDownList)gridViewRow.FindControl("drpdept")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialReturnNote_MRN_Edit.aspx?MRNNo=" + MRNNo + "&ModId=9&SubModId=48");
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		int editIndex = GridView1.EditIndex;
		GridViewRow gridViewRow = GridView1.Rows[editIndex];
		int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
		int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue);
		string text = "";
		string text2 = "";
		string text3 = decimal.Parse(((TextBox)gridViewRow.FindControl("txtqty")).Text.ToString()).ToString("N3");
		string text4 = ((TextBox)gridViewRow.FindControl("txtremarks")).Text;
		string text5 = "";
		if (num2 == 1 && fun.NumberValidationQty(text3.ToString()))
		{
			if (((DropDownList)gridViewRow.FindControl("drpdept")).SelectedValue != "0" && text3 != "")
			{
				text = ((DropDownList)gridViewRow.FindControl("drpdept")).SelectedValue;
				text5 = fun.update("tblInv_MaterialReturn_Details", "DeptId='" + text + "',WONO='" + text2 + "',RetQty='" + text3 + "',Remarks='" + text4 + "'", "Id='" + num + "' And MId='" + MId + "'");
				SqlCommand sqlCommand = new SqlCommand(text5, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText = fun.update("tblInv_MaterialReturn_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "'", "Id='" + MId + "' And CompId='" + CompId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		else
		{
			if (num2 != 2 || !fun.NumberValidationQty(text3.ToString()))
			{
				return;
			}
			text2 = ((TextBox)gridViewRow.FindControl("txtwono")).Text;
			text = "1";
			if (text2 != "" && text3 != "")
			{
				string cmdText2 = fun.select("*", "SD_Cust_WorkOrder_Master", "WONo='" + text2 + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "SD_Cust_WorkOrder_Master");
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					text5 = fun.update("tblInv_MaterialReturn_Details", "WONo='" + text2 + "',DeptId='" + text + "',RetQty='" + text3 + "',Remarks='" + text4 + "'", "Id='" + num + "' And MId='" + MId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(text5, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
					string cmdText3 = fun.update("tblInv_MaterialReturn_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "'", "Id='" + MId + "' And CompId='" + CompId + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand4.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				string empty = string.Empty;
				empty = "Invalid WONo found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			LoadData();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}

	public void getval()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "2")
				{
					((TextBox)row.FindControl("txtwono")).Visible = true;
					if (((TextBox)row.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
					}
					((Label)row.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((TextBox)row.FindControl("txtwono")).Visible = false;
					if (!((TextBox)row.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("Req1")).Visible = false;
					}
				}
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "1")
				{
					((DropDownList)row.FindControl("drpdept")).Visible = true;
					((Label)row.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((DropDownList)row.FindControl("drpdept")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
