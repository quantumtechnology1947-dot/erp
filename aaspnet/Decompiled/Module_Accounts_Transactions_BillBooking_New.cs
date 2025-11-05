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

public class Module_Accounts_Transactions_BillBooking_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string PONo = "";

	private string SId = "";

	private int CompId;

	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected Button Button1;

	protected AutoCompleteExtender AutoCompleteExtender1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			if (!Page.IsPostBack)
			{
				loadData(SupId);
			}
			string cmdText = fun.delete("tblACC_BillBooking_Attach_Temp", "CompId ='" + CompId + "' AND SessionId = '" + SId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			string cmdText2 = fun.delete("tblACC_BillBooking_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
			sqlCommand2.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string spid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			DataTable dataTable = new DataTable();
			Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			sqlConnection.Open();
			if (DropDownList1.SelectedValue == "Select")
			{
				txtSupplier.Visible = false;
			}
			string text = "";
			if (DropDownList1.SelectedValue == "0" && txtSupplier.Text != "")
			{
				text = " And SupplierId='" + spid + "'";
			}
			string cmdText = fun.select("SupId,SupplierName,SupplierId", "tblMM_Supplier_master", "FinYearId<='" + num + "' AND CompId='" + num2 + "'" + text + " AND SupId!=417 AND SupplierId!='S098' Order by SupplierId ASC");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["SupId"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["SupplierName"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			sqlConnection.Close();
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblsupId")).Text;
				string text2 = ((TextBox)gridViewRow.FindControl("txtFreight")).Text;
				string selectedValue = ((DropDownList)gridViewRow.FindControl("ddlMhOms")).SelectedValue;
				if (((DropDownList)gridViewRow.FindControl("ddlMhOms")).SelectedValue != "Select")
				{
					base.Response.Redirect("BillBooking_New_Details.aspx?SUPId=" + text + "&FGT=" + text2 + "&ST=" + selectedValue + "&ModId=11&SubModId=62");
				}
				else
				{
					string empty = string.Empty;
					empty = "Select type of Invoice!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			loadData(SupId);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			text = fun.getCode(txtSupplier.Text);
			loadData(text);
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
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				loadData(SupId);
			}
			else
			{
				txtSupplier.Visible = false;
				loadData(SupId);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void ddlMhOms_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
