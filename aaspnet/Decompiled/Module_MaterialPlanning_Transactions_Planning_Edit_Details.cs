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

public class Module_MaterialPlanning_Transactions_Planning_Edit_Details : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected GridView GridView1;

	protected Button btnCancel1;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string PLNo = "";

	private string MId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			PLNo = base.Request.QueryString["plno"].ToString();
			MId = base.Request.QueryString["MId"].ToString();
			if (!base.IsPostBack)
			{
				fillprocess();
				fillRawMaterial();
			}
			validateText();
		}
		catch (Exception)
		{
		}
	}

	public void disableEdit()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("lblItemId")).Text;
				string text2 = ((Label)row.FindControl("lblPid")).Text;
				string text3 = ((Label)row.FindControl("lblCid")).Text;
				string cmdText = fun.select("tblMM_PR_Details.Id", "tblMM_PR_Master,tblMM_PR_Details", " tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.PId='" + text2 + "'AND tblMM_PR_Details.ItemId='" + text + "' AND tblMM_PR_Details.CId='" + text3 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					((CheckBox)row.FindControl("Ck")).Visible = false;
					((Label)row.FindControl("lblDel")).Visible = true;
				}
				else
				{
					((CheckBox)row.FindControl("Ck")).Visible = true;
					((Label)row.FindControl("lblDel")).Visible = false;
				}
			}
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				string text4 = ((Label)row2.FindControl("lblItemId")).Text;
				string text5 = ((Label)row2.FindControl("lblPid")).Text;
				string text6 = ((Label)row2.FindControl("lblCid")).Text;
				string cmdText2 = fun.select("tblMM_PR_Details.Id", "tblMM_PR_Master,tblMM_PR_Details", " tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.PId='" + text5 + "'AND tblMM_PR_Details.ItemId='" + text4 + "' AND tblMM_PR_Details.CId='" + text6 + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					((CheckBox)row2.FindControl("ck")).Visible = false;
					((Label)row2.FindControl("lblDel")).Visible = true;
				}
				else
				{
					((CheckBox)row2.FindControl("ck")).Visible = true;
					((Label)row2.FindControl("lblDel")).Visible = false;
				}
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
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((RegularExpressionValidator)row.FindControl("RegularExpressionValidatorTxtCompDate")).Visible = true;
					((RegularExpressionValidator)row.FindControl("ReqRawSupNM")).Visible = true;
				}
				else
				{
					((RegularExpressionValidator)row.FindControl("RegularExpressionValidatorTxtCompDate")).Visible = false;
					((RegularExpressionValidator)row.FindControl("ReqRawSupNM")).Visible = false;
				}
			}
			foreach (GridViewRow row2 in GridView2.Rows)
			{
				if (((CheckBox)row2.FindControl("CK")).Checked)
				{
					((RequiredFieldValidator)row2.FindControl("ReqSupNM")).Visible = true;
					((RequiredFieldValidator)row2.FindControl("RegularExpressionValidatorTxtCompDate1")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row2.FindControl("ReqSupNM")).Visible = false;
					((RequiredFieldValidator)row2.FindControl("RegularExpressionValidatorTxtCompDate1")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillprocess()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("*", "tblMP_Material_Process", " PLNo='" + PLNo + "' AND MId='" + MId + "'Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(string)));
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
				string cmdText3 = fun.select("ItemCode,UOMBasic,ManfDesc", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'AND CompId='" + CompId + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					string cmdText4 = fun.select("Id,Symbol ", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					dataRow[3] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					dataRow[5] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[6] = dataSet2.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + "]";
				}
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
				dataRow[2] = dataSet.Tables[0].Rows[i]["PLNo"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataRow[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["CompDate"].ToString());
				dataRow[9] = dataSet.Tables[0].Rows[i]["PId"].ToString();
				dataRow[10] = dataSet.Tables[0].Rows[i]["CId"].ToString();
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

	public void fillRawMaterial()
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			string cmdText = fun.select("*", "tblMP_Material_RawMaterial", "PLNo='" + PLNo + "' AND MId='" + MId + "'Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("SupplierId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SupplierName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CompDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = fun.select("SupplierName,SupplierId", "tblMM_Supplier_master", "SupplierId='" + dataSet.Tables[0].Rows[i]["SupplierId"].ToString() + "' AND CompId='" + CompId + "'");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					string cmdText3 = fun.select("ItemCode,UOMBasic,ManfDesc", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'AND CompId='" + CompId + "' ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					string cmdText4 = fun.select("Id,Symbol ", "Unit_Master", "Id='" + dataSet3.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
					dataRow[1] = dataSet.Tables[0].Rows[i]["SupplierId"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[i]["PLNo"].ToString();
					dataRow[3] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
					}
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
					}
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[6] = dataSet2.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + dataSet2.Tables[0].Rows[0]["SupplierId"].ToString() + "]";
					}
					dataRow[7] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
					dataRow[8] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["CompDate"].ToString());
					dataRow[9] = dataSet.Tables[0].Rows[i]["PId"].ToString();
					dataRow[10] = dataSet.Tables[0].Rows[i]["CId"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
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

	protected void btnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Planning_Edit.aspx?ModId=4&SubModId=33");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			fillprocess();
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
			fillRawMaterial();
		}
		catch (Exception)
		{
		}
	}

	protected void ck_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					((TextBox)row.FindControl("txtSupName")).Visible = true;
					((TextBox)row.FindControl("TxtCompDate")).Visible = true;
					((Label)row.FindControl("lblCompDate")).Visible = false;
					((Label)row.FindControl("lblsupl")).Visible = false;
				}
				else
				{
					((TextBox)row.FindControl("txtSupName")).Visible = false;
					((TextBox)row.FindControl("TxtCompDate")).Visible = false;
					((Label)row.FindControl("lblCompDate")).Visible = true;
					((Label)row.FindControl("lblsupl")).Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CK_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("Ck")).Checked)
				{
					((TextBox)row.FindControl("txtSupName")).Visible = true;
					((TextBox)row.FindControl("TxtCompDate")).Visible = true;
					((Label)row.FindControl("lblCompDate")).Visible = false;
					((Label)row.FindControl("lblsupl")).Visible = false;
				}
				else
				{
					((TextBox)row.FindControl("txtSupName")).Visible = false;
					((TextBox)row.FindControl("TxtCompDate")).Visible = false;
					((Label)row.FindControl("lblCompDate")).Visible = true;
					((Label)row.FindControl("lblsupl")).Visible = true;
				}
			}
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (!(e.CommandName == "editRawMate"))
			{
				return;
			}
			int num = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				string text = ((Label)row.FindControl("lblPLNo")).Text;
				string text2 = ((Label)row.FindControl("lblId")).Text;
				string text3 = ((Label)row.FindControl("lblItemId")).Text;
				string code = fun.getCode(((TextBox)row.FindControl("txtSupName")).Text);
				string text4 = fun.FromDate(((TextBox)row.FindControl("TxtCompDate")).Text);
				if (((CheckBox)row.FindControl("Ck")).Checked && code != "" && text4 != "" && fun.DateValidation(((TextBox)row.FindControl("TxtCompDate")).Text))
				{
					string cmdText = fun.update("tblMP_Material_RawMaterial", "tblMP_Material_RawMaterial.SupplierId='" + code + "',tblMP_Material_RawMaterial.CompDate='" + text4 + "'", "tblMP_Material_RawMaterial.PLNO=(" + fun.select("tblMP_Material_Master.PLNO", "tblMP_Material_Master", "tblMP_Material_Master.PLNO='" + text + "' And tblMP_Material_Master.CompId='" + CompId + "'") + ") And tblMP_Material_RawMaterial.ItemId='" + text3 + "'AND tblMP_Material_RawMaterial.Id='" + text2 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					num++;
				}
				else
				{
					string empty = string.Empty;
					empty = "Please select one of record to update record  or insert Date.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (num > 0)
			{
				base.Response.Redirect("Planning_Edit.aspx?ModId=4&SubModId=33");
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

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (!(e.CommandName == "editProMate"))
			{
				return;
			}
			int num = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				string text = ((Label)row.FindControl("lblPLNo")).Text;
				string text2 = ((Label)row.FindControl("lblItemId")).Text;
				string text3 = ((Label)row.FindControl("lblId")).Text;
				string code = fun.getCode(((TextBox)row.FindControl("txtSupName")).Text);
				string text4 = fun.FromDate(((TextBox)row.FindControl("TxtCompDate")).Text);
				if (((CheckBox)row.FindControl("ck")).Checked && code != "" && text4 != "" && fun.DateValidation(((TextBox)row.FindControl("TxtCompDate")).Text))
				{
					string cmdText = fun.update("tblMP_Material_Process", "tblMP_Material_Process.SupplierId='" + code + "',tblMP_Material_Process.CompDate='" + text4 + "'", "tblMP_Material_Process.PLNO=(" + fun.select("tblMP_Material_Master.PLNO", "tblMP_Material_Master", "tblMP_Material_Master.PLNO='" + text + "' And tblMP_Material_Master.CompId='" + CompId + "'") + ") And tblMP_Material_Process.ItemId='" + text2 + "'AND tblMP_Material_Process.Id='" + text3 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
					sqlCommand.ExecuteNonQuery();
					num++;
				}
				else
				{
					string empty = string.Empty;
					empty = "Please select one of record to update  or insert Date.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (num > 0)
			{
				base.Response.Redirect("Planning_Edit.aspx?ModId=4&SubModId=33");
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

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
