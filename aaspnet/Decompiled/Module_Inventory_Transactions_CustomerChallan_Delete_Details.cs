using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_CustomerChallan_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string supid = "";

	private string str = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private int id;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button BtnAdd;

	protected Button Btncancel;

	protected Panel Panel2;

	protected TabPanel Add;

	protected GridView GridView1;

	protected Panel Panel4;

	protected Button BtnAdd1;

	protected Button BtnCancel1;

	protected Panel Panel3;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			id = Convert.ToInt32(base.Request.QueryString["Id"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				fillGrid();
				LoadGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCustomerChallan_Details", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void LoadGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCust_Challan_Clear_Edit", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = fyid;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void BtnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					int num2 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					SqlCommand sqlCommand = new SqlCommand(fun.delete("tblInv_Customer_Challan_Details", "Id='" + num2 + "'"), con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					SqlCommand sqlCommand2 = new SqlCommand(fun.delete("tblInv_Customer_Challan_Clear", "DId='" + num2 + "'"), con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					string cmdText = fun.select("tblInv_Customer_Challan_Details.Id", "tblInv_Customer_Challan_Details,tblInv_Customer_Challan_Master", "  tblInv_Customer_Challan_Master.Id= tblInv_Customer_Challan_Details.MId and tblInv_Customer_Challan_Master.FinYearId='" + fyid + "' AND tblInv_Customer_Challan_Master.CompId='" + CompId + "'  And tblInv_Customer_Challan_Details.MId='" + id + "' ");
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						string cmdText2 = fun.delete("tblInv_Customer_Challan_Master", "CompId='" + CompId + "' and FinYearId='" + fyid + "' and Id='" + id + "' ");
						con.Open();
						SqlCommand sqlCommand3 = new SqlCommand(cmdText2, con);
						sqlCommand3.ExecuteNonQuery();
						con.Close();
						base.Response.Redirect("CustomerChallan_Delete.aspx?ModId=9&SubModId=121");
					}
					num++;
				}
			}
			if (num > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/CustomerChallan_Delete.aspx?ModId=9&SubModId=121");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
	}

	protected void BtnAdd1_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox2")).Checked)
				{
					int num2 = Convert.ToInt32(((Label)row.FindControl("lblId1")).Text);
					SqlCommand sqlCommand = new SqlCommand(fun.delete("tblInv_Customer_Challan_Clear", "Id='" + num2 + "'"), con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					num++;
				}
			}
			if (num > 0)
			{
				LoadGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/CustomerChallan_Delete.aspx?ModId=9&SubModId=121");
	}
}
