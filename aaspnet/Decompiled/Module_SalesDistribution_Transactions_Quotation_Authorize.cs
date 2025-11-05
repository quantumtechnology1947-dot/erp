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

public class Module_SalesDistribution_Transactions_Quotation_Authorize : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYear;

	private string spr = "";

	private string emp = "";

	private string FyId = "";

	private string parentPage = "Quotation_Authorize.aspx";

	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected Button Button1;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			if (!base.IsPostBack)
			{
				makegrid(spr, emp);
			}
		}
		catch (Exception)
		{
		}
	}

	public void makegrid(string sprno, string empid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			CompId = Convert.ToInt32(Session["compid"]);
			string value = "";
			string value2 = " And SD_Cust_Quotation_Master.Approve=1";
			if (drpfield.SelectedValue == "0")
			{
				if (txtPONo.Text != "")
				{
					value = " AND SD_Cust_Quotation_Master.QuotationNo='" + txtPONo.Text + "'";
				}
			}
			else if (txtSupplier.Text != "")
			{
				value = " AND SD_Cust_Quotation_Master.CustomerId='" + fun.getCode(txtSupplier.Text) + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_Quatation_Grid", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FyId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value2;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((Label)row.FindControl("lblAutho")).Text != "")
				{
					CheckBox checkBox = (CheckBox)row.FindControl("CK");
					checkBox.Visible = false;
				}
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYear = Convert.ToInt32(Session["finyear"]);
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (e.CommandName == "Auth")
			{
				foreach (GridViewRow row in GridView2.Rows)
				{
					CheckBox checkBox = (CheckBox)row.FindControl("CK");
					if (checkBox.Checked)
					{
						string text = ((Label)row.FindControl("lblQuotationNo")).Text;
						string text2 = ((Label)row.FindControl("lblId")).Text;
						string cmdText = fun.update("SD_Cust_Quotation_Master", "Authorize='1',AuthorizedBy='" + sId + "',AuthorizeDate='" + currDate + "',AuthorizeTime='" + currTime + "'", "CompId='" + CompId + "' AND QuotationNo='" + text + "' And Id='" + text2 + "' ");
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.ExecuteNonQuery();
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "view")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text3 = ((Label)gridViewRow2.FindControl("lblQuotationNo")).Text;
				string text4 = ((Label)gridViewRow2.FindControl("lblCustcode")).Text;
				string text5 = ((Label)gridViewRow2.FindControl("lblId")).Text;
				string cmdText2 = fun.select("EnqId", "SD_Cust_Quotation_Master", "Id='" + text5 + "' AND CustomerId='" + text4 + "' And QuotationNo='" + text3 + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					base.Response.Redirect("Quotation_Print_Details.aspx?ModId=2&SubModId=63&Id=" + text5 + "&QuotationNo=" + text3 + "&EnqId=" + dataSet.Tables[0].Rows[0]["EnqId"].ToString() + "&CustomerId=" + text4 + "&parentpage=4");
				}
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

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "0")
			{
				txtPONo.Visible = true;
				txtPONo.Text = "";
				txtSupplier.Visible = false;
			}
			else
			{
				txtPONo.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		makegrid(txtPONo.Text, txtSupplier.Text);
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

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			makegrid(spr, emp);
		}
		catch (Exception)
		{
		}
	}
}
