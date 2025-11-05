using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Reports_WorkOrder_Issue : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtEnqId;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected DropDownList DDLTaskWOType;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string CId = "";

	private string Eid = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				txtEnqId.Visible = false;
				BindDataCust(CId, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			BindDataCust(CId, Eid);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(TxtSearchValue.Text, txtEnqId.Text);
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID)
	{
		try
		{
			string value = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				value = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			new DataTable();
			con.Open();
			string value2 = "";
			if (DropDownList1.SelectedValue == "1" && txtEnqId.Text != "")
			{
				value2 = " AND EnqId='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2" && txtEnqId.Text != "")
			{
				value2 = " AND PONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "3" && txtEnqId.Text != "")
			{
				value2 = " AND WONo='" + txtEnqId.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
			}
			string value3 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				value3 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value4 = " And SD_Cust_WorkOrder_Master.WONo in (select WONo from tblDG_BOM_Master)";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WONO_NotInBom", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value3;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@l", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@l"].Value = value4;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			SearchGridView1.DataSource = dataSet;
			SearchGridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtEnqId.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				BindDataCust(CId, Eid);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtEnqId.Visible = true;
				TxtSearchValue.Visible = false;
				txtEnqId.Text = "";
				BindDataCust(CId, Eid);
			}
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("CustomerId,CustomerName", "SD_Cust_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "SD_Cust_master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (!(e.CommandName == "Sel"))
		{
			return;
		}
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblWONo")).Text;
			string selectedValue = ((DropDownList)gridViewRow.FindControl("DrpWorkOrderType")).SelectedValue;
			string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
			if (selectedValue == "0")
			{
				base.Response.Redirect("WorkOrder_Issue_Details.aspx?wono=" + text + "&Key=" + randomAlphaNumeric);
			}
			else
			{
				base.Response.Redirect("WorkOrder_Shortage_Details.aspx?wono=" + text + "&Key=" + randomAlphaNumeric);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			Convert.ToInt32(DDLTaskWOType.SelectedValue);
			BindDataCust(CId, Eid);
		}
		else
		{
			BindDataCust(CId, Eid);
		}
	}
}
