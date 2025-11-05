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

public class Module_MaterialPlanning_Transactions_Plannning_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int FinYearId;

	private int CompId;

	private string CId2 = "";

	private string Eid = "";

	private string sId = "";

	private int h;

	private string str = "";

	private SqlConnection con;

	protected DropDownList DropDownList1;

	protected TextBox txtSearchCustomer;

	protected TextBox TxtSearchValue;

	protected AutoCompleteExtender TxtSearchValue_AutoCompleteExtender;

	protected DropDownList DDLTaskWOType;

	protected Button btnSearch;

	protected GridView SearchGridView1;

	protected HiddenField hfSort;

	protected HiddenField hfSearchText;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + sId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = "delete from tblMP_Material_Process_Temp where DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText3 = "delete from tblMP_Material_RawMaterial_Temp where DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					string cmdText4 = "delete from tblMP_Material_Finish_Temp where DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
				}
				string cmdText5 = "delete from tblMP_Material_Detail_Temp where SessionId='" + sId + "' ";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText5, con);
				con.Open();
				sqlCommand4.ExecuteNonQuery();
				con.Close();
				string cmdText6 = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText6, con);
				DataSet dataSet2 = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = dataSet2.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				BindDataCust(CId2, Eid, h);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		SearchGridView1.PageIndex = e.NewPageIndex;
		try
		{
			BindDataCust(CId2, Eid, h);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			BindDataCust(CId2, Eid, h);
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Dashboard.aspx?ModId=3&SubModId=23");
	}

	protected void DropDownList1_SelectedIndexChanged2(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				txtSearchCustomer.Visible = false;
				TxtSearchValue.Visible = true;
				TxtSearchValue.Text = "";
				BindDataCust(CId2, Eid, h);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "Select")
			{
				txtSearchCustomer.Visible = true;
				TxtSearchValue.Visible = false;
				txtSearchCustomer.Text = "";
				BindDataCust(CId2, Eid, h);
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindDataCust(string Cid, string EID, int C)
	{
		try
		{
			new DataTable();
			con.Open();
			string value = "";
			if (DropDownList1.SelectedValue == "1" && txtSearchCustomer.Text != "")
			{
				value = " AND EnqId='" + txtSearchCustomer.Text + "'";
			}
			if (DropDownList1.SelectedValue == "2" && txtSearchCustomer.Text != "")
			{
				value = " AND PONo='" + txtSearchCustomer.Text + "'";
			}
			if (DropDownList1.SelectedValue == "3" && txtSearchCustomer.Text != "")
			{
				value = " AND WONo='" + txtSearchCustomer.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				txtSearchCustomer.Visible = true;
				TxtSearchValue.Visible = false;
			}
			string value2 = "";
			if (DropDownList1.SelectedValue == "0" && TxtSearchValue.Text != "")
			{
				string code = fun.getCode(TxtSearchValue.Text);
				value2 = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value3 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				value3 = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			string value4 = " And SD_Cust_WorkOrder_Master.WONo in (select WONo from tblDG_BOM_Master)";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_WONO_NotInBom", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value3;
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

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			BindDataCust(CId2, Eid, c);
		}
		else
		{
			BindDataCust(CId2, Eid, h);
		}
	}
}
