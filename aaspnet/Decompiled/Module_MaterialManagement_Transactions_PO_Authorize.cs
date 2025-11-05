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

public class Module_MaterialManagement_Transactions_PO_Authorize : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int FinYear;

	private string spr = "";

	private string emp = "";

	private string FyId = "";

	private string parentPage = "PO_Authorize.aspx";

	protected DropDownList drpfield;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender;

	protected TextBox txtPONo;

	protected Button Button1;

	protected Button Auth;

	protected GridView GridView2;

	protected Panel Panel1;

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
			string cmdText = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "'    AND Approve='1'" + text + " AND Authorize='0' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["SessionId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string text2 = "";
				text2 = ((!(drpfield.SelectedValue == "0")) ? (" AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'") : ((!(txtSupplier.Text != "")) ? (" AND SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "'") : (" AND SupplierId='" + fun.getCode(txtSupplier.Text) + "'")));
				string cmdText3 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'" + text2);
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
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
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
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
			fun.getCurrDate();
			fun.getCurrTime();
			if (e.CommandName == "view")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string text = ((Label)gridViewRow.FindControl("lblsprno")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblsupcode")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblAmendmentNo")).Text;
				string cmdText = fun.select("PRSPRFlag", "tblMM_PO_Master", "Id='" + text3 + "' AND SupplierId='" + text2 + "' And PONo='" + text + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows[0][0].ToString() == "0")
				{
					string empty = string.Empty;
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_PR_View_Print_Details.aspx?mid=" + text3 + "&pono=" + text + "&Code=" + text2 + "&AmdNo=" + text4 + "&Key=" + randomAlphaNumeric + "&Trans=" + empty + "&ModId=6&SubModId=35&parentpage=" + parentPage);
				}
				else
				{
					string randomAlphaNumeric2 = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("PO_SPR_View_Print_Details.aspx?mid=" + text3 + "&pono=" + text + "&Code=" + text2 + "&AmdNo=" + text4 + "&Key=" + randomAlphaNumeric2 + "&ModId=6&SubModId=35&parentpage=" + parentPage);
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
			if (drpfield.SelectedValue == "1")
			{
				txtPONo.Visible = true;
				txtPONo.Text = "";
				txtSupplier.Visible = false;
				makegrid(spr, emp);
			}
			else
			{
				txtPONo.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				makegrid(spr, emp);
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

	protected void Auth_Click(object sender, EventArgs e)
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
			int num = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("CK");
				if (!checkBox.Checked)
				{
					continue;
				}
				string text = ((Label)row.FindControl("lblsprno")).Text;
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.update("tblMM_PO_Master", "Authorize='1',AuthorizedBy='" + sId + "',AuthorizeDate='" + currDate + "',AuthorizeTime='" + currTime + "'", "CompId='" + CompId + "' AND PONo='" + text + "' And Id='" + num2 + "' ");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("PRSPRFlag,AmendmentNo", "tblMM_PO_Master", "Id='" + num2 + "' AND CompId='" + CompId + "' AND PONo='" + text + "'And FinYearId='" + FinYear + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText3 = fun.select("*", "tblMM_PO_Details", "MId='" + num2 + "' AND PONo='" + text + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0")
				{
					for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
					{
						string cmdText4 = fun.select("tblMM_PR_Details.ItemId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo='" + dataSet2.Tables[0].Rows[i]["PRNo"].ToString() + "' And tblMM_PR_Details.Id='" + dataSet2.Tables[0].Rows[i]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter3.Fill(dataSet3);
						if (dataSet3.Tables[0].Rows.Count > 0)
						{
							string cmdText5 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,PONo,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,POId,PRId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYear + "','" + sId + "','" + text + "','" + dataSet3.Tables[0].Rows[0][0].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Rate"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["Discount"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["PF"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["ExST"].ToString() + "','" + dataSet2.Tables[0].Rows[i]["VAT"].ToString() + "','" + dataSet.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + num2 + "','" + dataSet2.Tables[0].Rows[i]["PRId"].ToString() + "'");
							SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
							sqlCommand2.ExecuteNonQuery();
							string cmdText6 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',Type='2', LockedbyTranaction='" + sId + "',LockDate='" + currDate + "',LockTime='" + currTime + "'", "ItemId='" + dataSet3.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
							sqlCommand3.ExecuteNonQuery();
							num++;
						}
					}
				}
				else
				{
					if (!(dataSet.Tables[0].Rows[0][0].ToString() == "1"))
					{
						continue;
					}
					for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
					{
						string cmdText7 = fun.select("tblMM_SPR_Details.ItemId", "tblMM_SPR_Details,tblMM_SPR_Master", " tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblMM_SPR_Master.SPRNo='" + dataSet2.Tables[0].Rows[j]["SPRNo"].ToString() + "'And tblMM_SPR_Details.Id='" + dataSet2.Tables[0].Rows[j]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							string cmdText8 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,PONo,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,POId,SPRId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + FinYear + "','" + sId + "','" + text + "','" + dataSet4.Tables[0].Rows[0][0].ToString() + "','" + dataSet2.Tables[0].Rows[j]["Rate"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["Discount"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["PF"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["ExST"].ToString() + "','" + dataSet2.Tables[0].Rows[j]["VAT"].ToString() + "','" + dataSet.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + num2 + "','" + dataSet2.Tables[0].Rows[j]["SPRId"].ToString() + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText8, sqlConnection);
							sqlCommand4.ExecuteNonQuery();
							string cmdText9 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',Type='2',LockedbyTranaction='" + sId + "',LockDate='" + currDate + "',LockTime='" + currTime + "'", "ItemId='" + dataSet4.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + CompId + "'");
							SqlCommand sqlCommand5 = new SqlCommand(cmdText9, sqlConnection);
							sqlCommand5.ExecuteNonQuery();
							num++;
						}
					}
				}
			}
			if (num > 0)
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				return;
			}
			string empty = string.Empty;
			empty = "No record is found to authorized.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
	}
}
