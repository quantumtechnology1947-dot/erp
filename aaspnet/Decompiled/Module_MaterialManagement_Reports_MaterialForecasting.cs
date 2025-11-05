using System;
using System.Collections.Generic;
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

public class Module_MaterialManagement_Reports_MaterialForecasting : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string connStr = "";

	private string sid = "";

	private int CompId;

	private int FinYearId;

	private int h;

	protected DropDownList DDLTaskWOType;

	protected DropDownList DropDownList_Trans;

	protected DropDownList DropDownList2;

	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected CheckBox SelectAll;

	protected Button Button1;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnPrint;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sid = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			connStr = fun.Connection();
			new DataSet();
			con = new SqlConnection(connStr);
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet, "tblSD_WO_Category");
				DDLTaskWOType.DataSource = dataSet.Tables["tblSD_WO_Category"];
				DDLTaskWOType.DataTextField = "Category";
				DDLTaskWOType.DataValueField = "CId";
				DDLTaskWOType.DataBind();
				DDLTaskWOType.Items.Insert(0, "WO Category");
				loaddata(h);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata(int c)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string value = "";
			if (drpfield.SelectedValue == "0" && txtSupplier.Text != "")
			{
				string code = fun.getCode(txtSupplier.Text);
				value = " AND SD_Cust_WorkOrder_Master.CustomerId='" + code + "'";
			}
			string value2 = "";
			if (drpfield.SelectedValue == "1" && txtPONo.Text != "")
			{
				value2 = " AND SD_Cust_WorkOrder_Master.WONo='" + txtPONo.Text + "'";
			}
			if (drpfield.SelectedValue == "2" && txtPONo.Text != "")
			{
				value2 = " AND SD_Cust_WorkOrder_Master.TaskProjectTitle Like '%" + txtPONo.Text + "%'";
			}
			string value3 = "";
			if (DDLTaskWOType.SelectedValue != "WO Category")
			{
				value3 = " AND SD_Cust_WorkOrder_Master.CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_ForeCast", con);
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
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (DDLTaskWOType.SelectedValue != "WO Category")
		{
			int c = Convert.ToInt32(DDLTaskWOType.SelectedValue);
			loaddata(c);
		}
		else
		{
			loaddata(h);
		}
	}

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "0")
			{
				txtPONo.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				loaddata(h);
			}
			if (drpfield.SelectedValue == "1" || drpfield.SelectedValue == "2")
			{
				txtPONo.Visible = true;
				txtPONo.Text = "";
				txtSupplier.Visible = false;
				loaddata(h);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		loaddata(h);
	}

	protected void btnPrint_Click(object sender, EventArgs e)
	{
		try
		{
			List<string> list = new List<string>();
			string text = string.Empty;
			string empty = string.Empty;
			string empty2 = string.Empty;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					list.Add(Convert.ToString(((Label)row.FindControl("lblWONo")).Text + ","));
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				text += list[i].ToString();
			}
			Session["WorkOrderId"] = text;
			empty = DropDownList2.SelectedValue;
			empty2 = DropDownList_Trans.SelectedValue;
			if (Session["WorkOrderId"] != null && !string.IsNullOrEmpty(Session["WorkOrderId"].ToString()) && empty != string.Empty)
			{
				base.Response.Redirect("ProjectSummary_Shortage.aspx?ModId=6&SwitchTo=" + empty + "&Trans=" + empty2);
				return;
			}
			string empty3 = string.Empty;
			empty3 = "Select Workorder.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
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

	protected void SelectAll_CheckedChanged(object sender, EventArgs e)
	{
		if (SelectAll.Checked)
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				((CheckBox)row.FindControl("CheckBox1")).Checked = true;
			}
		}
		if (SelectAll.Checked)
		{
			return;
		}
		foreach (GridViewRow row2 in GridView1.Rows)
		{
			((CheckBox)row2.FindControl("CheckBox1")).Checked = false;
		}
	}
}
