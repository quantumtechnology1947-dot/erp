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

public class Module_MaterialManagement_Transactions_PO_Approve : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private string CDate = "";

	private string CTime = "";

	private string str = "";

	private string FyId = "";

	private SqlConnection con;

	private string parentPage = "PO_Approve.aspx";

	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected Button Button1;

	protected Button App;

	protected GridView GridView2;

	protected Panel Panel1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			FyId = Session["finyear"].ToString();
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				txtPONo.Visible = false;
				makegrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void makegrid()
	{
		try
		{
			con.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("PONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmdNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CheckedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ApprovedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizedDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Sup", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Code", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmendmentNo", typeof(string)));
			CompId = Convert.ToInt32(Session["compid"]);
			string text = "";
			if (drpfield.SelectedValue == "1" && txtPONo.Text != "")
			{
				text = " AND PONo='" + txtPONo.Text + "'";
			}
			string cmdText = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "'   And FinYearId<='" + FyId + "' AND Checked='1'" + text + " AND Approve='0' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string text2 = "";
				text2 = ((!(drpfield.SelectedValue == "0")) ? (" AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'") : ((!(txtSupplier.Text != "")) ? (" AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'") : (" AND SupplierId='" + fun.getCode(txtSupplier.Text) + "'")));
				string cmdText3 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'" + text2);
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[0] = dataSet.Tables[0].Rows[i]["PONo"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[2] = dataSet.Tables[0].Rows[i]["AmendmentNo"].ToString();
				dataRow[3] = dataSet2.Tables[0].Rows[0]["EmpName"].ToString();
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Checked"]) == 1)
				{
					dataRow[4] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["CheckedDate"].ToString());
				}
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Approve"]) == 1)
				{
					dataRow[5] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["ApproveDate"].ToString());
				}
				if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["Authorize"]) == 1)
				{
					dataRow[6] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["AuthorizeDate"].ToString());
				}
				dataRow[7] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[8] = dataSet3.Tables[0].Rows[0]["SupplierName"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
				string cmdText4 = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + dataSet.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[10] = dataSet4.Tables[0].Rows[0]["FinYear"].ToString();
				}
				dataRow[11] = dataSet.Tables[0].Rows[i]["AmendmentNo"].ToString();
				if (dataSet.Tables[0].Rows[i]["SupplierId"].ToString() == dataSet3.Tables[0].Rows[0]["SupplierId"].ToString())
				{
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((Label)row.FindControl("lblApproved")).Text != "")
				{
					CheckBox checkBox = (CheckBox)row.FindControl("CK");
					checkBox.Visible = false;
				}
			}
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			con.Open();
			if (e.CommandName == "App")
			{
				foreach (GridViewRow row in GridView2.Rows)
				{
					CheckBox checkBox = (CheckBox)row.FindControl("CK");
					if (checkBox.Checked)
					{
						string text = ((Label)row.FindControl("lblId")).Text;
						string text2 = ((Label)row.FindControl("lblsprno")).Text;
						string cmdText = fun.update("tblMM_PO_Master", "Approve='1',ApprovedBy='" + sId + "',ApproveDate='" + CDate + "',ApproveTime='" + CTime + "'", "CompId='" + CompId + "'   AND Id='" + text + "'  AND PONo='" + text2 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, con);
						sqlCommand.ExecuteNonQuery();
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "view")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text3 = ((Label)gridViewRow2.FindControl("lblsprno")).Text;
				string text4 = ((Label)gridViewRow2.FindControl("lblsupcode")).Text;
				string text5 = ((Label)gridViewRow2.FindControl("lblId")).Text;
				string text6 = ((Label)gridViewRow2.FindControl("lblAmendmentNo")).Text;
				string cmdText2 = fun.select("PRSPRFlag", "tblMM_PO_Master", "SupplierId='" + text4 + "' And PONo='" + text3 + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows[0][0].ToString() == "0")
				{
					string empty = string.Empty;
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_PR_View_Print_Details.aspx?mid=" + text5 + "&pono=" + text3 + "&Code=" + text4 + "&AmdNo=" + text6 + "&Key=" + randomAlphaNumeric + "&Trans=" + empty + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
				else
				{
					string randomAlphaNumeric2 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_SPR_View_Print_Details.aspx?mid=" + text5 + "&pono=" + text3 + "&Code=" + text4 + "&AmdNo=" + text6 + "&Key=" + randomAlphaNumeric2 + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
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

	protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (drpfield.SelectedValue == "1")
			{
				txtPONo.Visible = true;
				txtPONo.Text = "";
				txtSupplier.Visible = false;
				makegrid();
			}
			else
			{
				txtPONo.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				makegrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		makegrid();
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			makegrid();
		}
		catch (Exception)
		{
		}
	}

	protected void App_Click(object sender, EventArgs e)
	{
		try
		{
			con.Open();
			int num = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("CK");
				if (checkBox.Checked)
				{
					string text = ((Label)row.FindControl("lblId")).Text;
					string text2 = ((Label)row.FindControl("lblsprno")).Text;
					string cmdText = fun.update("tblMM_PO_Master", "Approve='1',ApprovedBy='" + sId + "',ApproveDate='" + CDate + "',ApproveTime='" + CTime + "'", "CompId='" + CompId + "'   AND Id='" + text + "'  AND PONo='" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					num++;
				}
			}
			if (num > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				return;
			}
			string empty = string.Empty;
			empty = "No record is found to approved.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}
}
