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

public class Module_MaterialPlanning_Transactions_Planning_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string No = "";

	private string Suid = "";

	protected DropDownList DrpField;

	protected TextBox Txtsearch;

	protected TextBox txtCustName;

	protected AutoCompleteExtender txtCustName_AutoCompleteExtender;

	protected Button Button1;

	protected GridView GridView1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!base.IsPostBack)
			{
				txtCustName.Visible = false;
				fillgrid(No, Suid);
			}
			validateText();
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid(string no, string SuId)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			string text = "";
			if (DrpField.SelectedValue == "2" && Txtsearch.Text != "")
			{
				text = " AND PLNo='" + Txtsearch.Text + "'";
			}
			string text2 = "";
			if (DrpField.SelectedValue == "1" && txtCustName.Text != "")
			{
				text2 = " AND SupplierId='" + fun.getCode(txtCustName.Text) + "'";
			}
			string cmdText = fun.select("*", "tblMP_Material_Master", "CompId='" + CompId + "' and FinYearId<='" + FinYearId + "'" + text + text2 + "Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText2 = fun.select("SupplierName,SupplierId", "tblMM_Supplier_master", "SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet.Tables[0].Rows[i]["SupplierId"] != DBNull.Value)
				{
					dataRow[3] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet2.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + "]";
					}
				}
				if (dataSet.Tables[0].Rows[i]["CompDate"] != DBNull.Value)
				{
					dataRow[6] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["CompDate"].ToString());
				}
				string cmdText3 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", dataSet.Tables[0].Rows[i]["FinYearId"], "'AND CompId='", CompId, "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
				}
				dataRow[4] = dataSet.Tables[0].Rows[i]["PLNo"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["PId"].ToString();
				dataRow[8] = dataSet.Tables[0].Rows[i]["CId"].ToString();
				dataRow[9] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			disableEdit();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void disableEdit()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			foreach (GridViewRow row in GridView1.Rows)
			{
				string text = ((Label)row.FindControl("lblWONo")).Text;
				string text2 = ((Label)row.FindControl("lblItem")).Text;
				string text3 = ((Label)row.FindControl("lblPid")).Text;
				string text4 = ((Label)row.FindControl("lblCid")).Text;
				string text5 = ((Label)row.FindControl("lblsupl")).Text;
				string cmdText = fun.select("tblMM_PR_Details.Id", "tblMM_PR_Master,tblMM_PR_Details", " tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.PId='" + text3 + "'AND tblMM_PR_Details.ItemId='" + text2 + "' AND tblMM_PR_Master.WONo='" + text + "' AND tblMM_PR_Details.CId='" + text4 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (text5 != "")
				{
					if (dataSet.Tables[0].Rows.Count > 0)
					{
						((LinkButton)row.FindControl("btnEdit")).Visible = false;
						((Label)row.FindControl("lblPR")).Visible = true;
						((LinkButton)row.FindControl("btnSel")).Visible = false;
					}
					else
					{
						((LinkButton)row.FindControl("btnEdit")).Visible = true;
						((Label)row.FindControl("lblPR")).Visible = false;
						((LinkButton)row.FindControl("btnSel")).Visible = false;
					}
				}
				else
				{
					((LinkButton)row.FindControl("btnEdit")).Visible = false;
					((Label)row.FindControl("lblPR")).Visible = false;
					((LinkButton)row.FindControl("btnSel")).Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpField_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpField.SelectedValue == "1")
			{
				Txtsearch.Visible = false;
				txtCustName.Visible = true;
				txtCustName.Text = "";
				fillgrid(No, Suid);
			}
			else
			{
				Txtsearch.Visible = true;
				Txtsearch.Text = "";
				txtCustName.Visible = false;
				fillgrid(No, Suid);
			}
		}
		catch (Exception)
		{
		}
	}

	public void validateText()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((LinkButton)row.FindControl("btnSave")).Visible)
				{
					((RequiredFieldValidator)row.FindControl("ReqSupNm")).Visible = true;
					((RequiredFieldValidator)row.FindControl("ReqCompDt")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqSupNm")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqCompDt")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			string code = fun.getCode(txtCustName.Text);
			fillgrid(Txtsearch.Text, code);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblPLNo")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblId")).Text;
			sqlConnection.Open();
			if (e.CommandName == "Sel")
			{
				base.Response.Redirect("Planning_Edit_Details.aspx?plno=" + text + "&MId=" + text2 + "&ModId=4&SubModId=33");
			}
			if (e.CommandName == "edt")
			{
				string cmdText = fun.select("SupplierId", "tblMP_Material_Master", "PLNo='" + text + "' And CompId='" + CompId + "' And Id='" + text2 + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[i]["SupplierId"] != DBNull.Value)
					{
						((TextBox)gridViewRow.FindControl("txtSupName")).Visible = true;
						((TextBox)gridViewRow.FindControl("TxtCompDate")).Visible = true;
						((Label)gridViewRow.FindControl("lblCompDate")).Visible = false;
						((Label)gridViewRow.FindControl("lblsupl")).Visible = false;
						((LinkButton)gridViewRow.FindControl("btnSave")).Visible = true;
						((LinkButton)gridViewRow.FindControl("btnCancel")).Visible = true;
						((LinkButton)gridViewRow.FindControl("btnEdit")).Visible = false;
					}
					else
					{
						((LinkButton)gridViewRow.FindControl("btnSave")).Visible = false;
						((LinkButton)gridViewRow.FindControl("btnCancel")).Visible = false;
						((LinkButton)gridViewRow.FindControl("btnEdit")).Visible = true;
					}
				}
			}
			if (e.CommandName == "save")
			{
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				string text3 = fun.FromDate(((TextBox)gridViewRow.FindControl("TxtCompDate")).Text);
				string code = fun.getCode(((TextBox)gridViewRow.FindControl("txtSupName")).Text);
				if (text3 != "" && code != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("TxtCompDate")).Text))
				{
					string cmdText2 = fun.update("tblMP_Material_Master", "SupplierId='" + code + "',CompDate='" + text3 + "',SysDate='" + currDate + "',SysTime='" + currTime + "'", "PLNO='" + text + "' AND Id='" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					base.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "Cancel")
			{
				base.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	[ScriptMethod]
	[WebMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		SqlConnection sqlConnection = new SqlConnection(connectionString);
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

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		fillgrid(No, Suid);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		validateText();
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
