using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_SupplierChallan_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string str = "";

	private SqlConnection con;

	private int id;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Label lblVehicleNo;

	protected Label lblRemarks;

	protected Panel Panel5;

	protected Label lblTranspoter;

	protected Button BtnAdd;

	protected Button Btncancel;

	protected Panel Panel2;

	protected TabPanel Add;

	protected GridView GridView3;

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
			if (!base.IsPostBack)
			{
				fillGrid();
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
			con.Open();
			SqlCommand sqlCommand = new SqlCommand("GetChallan_Details", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlCommand.Parameters["@Id"].Value = id;
			sqlCommand.Parameters["@CompId"].Value = CompId;
			SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			DataTable dataTable = new DataTable();
			dataTable.Load(reader);
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			lblRemarks.Text = dataTable.Rows[0]["Remarks"].ToString();
			lblVehicleNo.Text = dataTable.Rows[0]["VehicleNo"].ToString();
			lblTranspoter.Text = dataTable.Rows[0]["Transpoter"].ToString();
			DisableChk();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void DisableChk()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = "SELECT tblInv_Supplier_Challan_Master.Id FROM tblInv_Supplier_Challan_Master INNER JOIN tblInv_Supplier_Challan_Details ON tblInv_Supplier_Challan_Master.Id = tblInv_Supplier_Challan_Details.MId INNER JOIN tblInv_Supplier_Challan_Clear ON tblInv_Supplier_Challan_Details.Id = tblInv_Supplier_Challan_Clear.DId And tblInv_Supplier_Challan_Master.Id='" + id + "' And tblInv_Supplier_Challan_Details.MId='" + id + "' And tblInv_Supplier_Challan_Details.Id='" + num + "' And tblInv_Supplier_Challan_Clear.DId='" + num + "'";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = true;
				}
				else
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSup_Challan_Clear_Edit", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = fyid;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView3.DataSource = dataSet;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
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
					SqlCommand sqlCommand = new SqlCommand(fun.delete("tblInv_Supplier_Challan_Details", "Id='" + num2 + "'"), con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					SqlCommand sqlCommand2 = new SqlCommand(fun.delete("tblInv_Supplier_Challan_Clear", "DId='" + num2 + "'"), con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					string cmdText = fun.select("tblInv_Supplier_Challan_Details.Id", "tblInv_Supplier_Challan_Details,tblInv_Supplier_Challan_Master", "  tblInv_Supplier_Challan_Master.Id= tblInv_Supplier_Challan_Details.MId and tblInv_Supplier_Challan_Master.FinYearId='" + fyid + "' AND tblInv_Supplier_Challan_Master.CompId='" + CompId + "'  And tblInv_Supplier_Challan_Details.MId='" + id + "' ");
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count == 0)
					{
						string cmdText2 = fun.delete("tblInv_Supplier_Challan_Master", "CompId='" + CompId + "' and FinYearId='" + fyid + "' and Id='" + id + "' ");
						con.Open();
						SqlCommand sqlCommand3 = new SqlCommand(cmdText2, con);
						sqlCommand3.ExecuteNonQuery();
						con.Close();
						base.Response.Redirect("SupplierChallan_Delete.aspx?ModId=9&SubModId=118");
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
		base.Response.Redirect("SupplierChallan_Delete.aspx?ModId=9&SubModId=118");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		if (TabContainer1.ActiveTabIndex == 1)
		{
			LoadGrid();
		}
	}

	protected void BtnAdd1_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			foreach (GridViewRow row in GridView3.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox2")).Checked)
				{
					int num2 = Convert.ToInt32(((Label)row.FindControl("lblId1")).Text);
					SqlCommand sqlCommand = new SqlCommand(fun.delete("tblInv_Supplier_Challan_Clear", "Id='" + num2 + "'"), con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					num++;
				}
			}
			if (num > 0)
			{
				LoadGrid();
				fillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("SupplierChallan_Delete.aspx?ModId=9&SubModId=118");
	}
}
