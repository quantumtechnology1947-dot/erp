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

public class Module_Accounts_Transactions_IOU_PaymentReceipt : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	protected GridView GridView2;

	protected Panel Panel1;

	protected TabPanel Add;

	protected GridView GridView1;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!Page.IsPostBack)
			{
				BindDataGrid();
				NED();
				BindDataGrid_Receipt();
				NED1();
			}
		}
		catch (Exception)
		{
		}
	}

	public void NED()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("Label1")).Text);
				string cmdText = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					if (dataSet.Tables[0].Rows[0]["Authorize"].ToString() == "1" && dataSet.Tables[0].Rows[0]["Authorize"] != DBNull.Value)
					{
						((CheckBox)row.FindControl("CheckBox1")).Enabled = false;
						((CheckBox)row.FindControl("CheckBox1")).Checked = true;
						((LinkButton)row.FindControl("LinkButton4")).Visible = false;
					}
					else
					{
						((CheckBox)row.FindControl("CheckBox1")).Enabled = true;
						((CheckBox)row.FindControl("CheckBox1")).Checked = false;
						((LinkButton)row.FindControl("LinkButton4")).Visible = true;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void NED1()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblIdR")).Text);
				string cmdText = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					if (Convert.ToDouble(dataSet.Tables[0].Rows[0]["Recieved"].ToString()) == 1.0 && dataSet.Tables[0].Rows[0]["Recieved"] != DBNull.Value)
					{
						((TextBox)row.FindControl("txtRecivedAmtR")).Visible = false;
						((Button)row.FindControl("btnAddReceipt")).Enabled = false;
						((TextBox)row.FindControl("txtReceiptDate")).Visible = false;
						((LinkButton)row.FindControl("LinkButton4")).Visible = true;
						((LinkButton)row.FindControl("LinkButton1")).Visible = true;
						((Label)row.FindControl("lblRecivedAmtR")).Visible = true;
					}
					else
					{
						((TextBox)row.FindControl("txtRecivedAmtR")).Visible = true;
						((Button)row.FindControl("btnAddReceipt")).Visible = true;
						((Button)row.FindControl("btnAddReceipt")).Enabled = true;
						((Label)row.FindControl("lblRecivedAmtR")).Visible = false;
						((TextBox)row.FindControl("txtReceiptDate")).Visible = true;
						((LinkButton)row.FindControl("LinkButton4")).Visible = false;
						((LinkButton)row.FindControl("LinkButton1")).Visible = false;
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void BindDataGrid()
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string cmdText = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'And Recieved='0' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PaymentDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ReasonId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Narration", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Authorized", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["PaymentDate"].ToString());
				string cmdText2 = fun.select("Title+'.'+EmployeeName+ ' ['+ EmpId +']' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["EmpId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
				dataRow[4] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
				string cmdText3 = fun.select("Terms", "tblACC_IOU_Reasons", "Id='" + dataSet.Tables[0].Rows[i]["Reason"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[5] = dataSet3.Tables[0].Rows[0]["Terms"].ToString();
				}
				dataRow[6] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Authorize"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	public void BindDataGrid_Receipt()
	{
		try
		{
			DataTable dataTable = new DataTable();
			con.Open();
			string cmdText = fun.select("*", "tblACC_IOU_Master", " Authorize='1' And FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("IdR", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PaymentDateR", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpNameR", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AmountR", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ReasonIdR", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ReasonR", typeof(string)));
			dataTable.Columns.Add(new DataColumn("NarrationR", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AuthorizedR", typeof(int)));
			dataTable.Columns.Add(new DataColumn("RecivedAmtR", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ReceiptDateR", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DIdR", typeof(int)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				string cmdText2 = fun.select("Title+'.'+EmployeeName+ '['+ EmpId +' ]' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["EmpId"], "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet2.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
				dataRow[4] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
				string cmdText3 = fun.select("Terms", "tblACC_IOU_Reasons", "Id='" + dataSet.Tables[0].Rows[i]["Reason"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[5] = dataSet3.Tables[0].Rows[0]["Terms"].ToString();
				}
				dataRow[6] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Authorize"].ToString();
				string cmdText4 = fun.select("*", "tblACC_IOU_Receipt", " MId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And FinYearId<='" + FinYearId + "'And CompId='" + CompId + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[8] = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["RecievedAmount"].ToString()).ToString("N3"));
					dataRow[9] = fun.FromDate(dataSet4.Tables[0].Rows[0]["ReceiptDate"].ToString());
					dataRow[10] = Convert.ToInt32(dataSet4.Tables[0].Rows[0]["Id"]);
				}
				else
				{
					dataRow[8] = 0;
					dataRow[9] = "";
					dataRow[10] = 0;
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
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
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		string selectCommandText = clsFunctions2.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblHR_OfficeStaff");
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
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView2.EditIndex = -1;
		BindDataGrid();
		NED();
	}

	protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView2.EditIndex = e.NewEditIndex;
			BindDataGrid();
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			string text = ((Label)gridViewRow.FindControl("lblReason2")).Text;
			((DropDownList)gridViewRow.FindControl("DrpReason2")).SelectedValue = text.ToString();
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblAuth")).Text);
			if (num == 1)
			{
				((CheckBox)gridViewRow.FindControl("CheckBox2")).Checked = true;
				((CheckBox)gridViewRow.FindControl("CheckBox1")).Visible = false;
			}
			else
			{
				((CheckBox)gridViewRow.FindControl("CheckBox2")).Checked = false;
				((CheckBox)gridViewRow.FindControl("CheckBox1")).Visible = false;
			}
			NED();
			BindDataGrid_Receipt();
			NED1();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView2.EditIndex;
			GridViewRow gridViewRow = GridView2.Rows[editIndex];
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			string code = fun.getCode(((Label)gridViewRow.FindControl("lblEmpName")).Text);
			double num2 = 0.0;
			if (((TextBox)gridViewRow.FindControl("TextBox2")).Text != "")
			{
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("TextBox2")).Text).ToString("N3"));
			}
			int num3 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpReason2")).SelectedValue);
			string text = ((TextBox)gridViewRow.FindControl("TextBox4")).Text;
			int num4 = 0;
			if (((CheckBox)gridViewRow.FindControl("CheckBox2")).Checked)
			{
				num4 = 1;
			}
			if (fun.NumberValidationQty(num2.ToString()) && ((TextBox)gridViewRow.FindControl("TextBox2")).Text != "")
			{
				if (num2 != 0.0)
				{
					string cmdText = fun.update("tblACC_IOU_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',EmpId='" + code + "',Amount='" + num2 + "',Reason='" + num3 + "',Narration='" + text + "',AuthorizedDate='" + CDate + "',AuthorizedTime='" + CTime + "',AuthorizedBy='" + sId + "',Authorize='" + num4 + "'", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					GridView2.EditIndex = -1;
					BindDataGrid();
					NED();
					BindDataGrid_Receipt();
					NED1();
				}
				else
				{
					string empty = string.Empty;
					empty = "Insert Valid Amount.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			int num = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value);
			SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblACC_IOU_Master WHERE Id=" + num + " And CompId='" + CompId + "'", con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			BindDataGrid();
			NED();
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("Label1")).Text);
			double cashClBalAmt = fun.getCashClBalAmt("=", fun.getCurrDate(), CompId, FinYearId);
			double num2 = Convert.ToDouble(((Label)gridViewRow.FindControl("lblAmt")).Text);
			if (((CheckBox)gridViewRow.FindControl("CheckBox1")).Checked)
			{
				if (Math.Round(cashClBalAmt - num2, 2) > 0.0)
				{
					string cmdText = fun.update("tblACC_IOU_Master", "AuthorizedDate='" + CDate + "',AuthorizedTime='" + CTime + "',AuthorizedBy='" + sId + "',Authorize='1'", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					BindDataGrid();
					NED();
					BindDataGrid_Receipt();
					NED1();
				}
				else
				{
					string empty = string.Empty;
					empty = "Insufficient Cash";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		GridView1.EditIndex = -1;
		BindDataGrid_Receipt();
		NED1();
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridView1.EditIndex = -1;
		BindDataGrid_Receipt();
		NED1();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblIdR")).Text);
				double num2 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblAmountR")).Text).ToString("N3"));
				double num3 = 0.0;
				if (((TextBox)gridViewRow.FindControl("txtRecivedAmtR")).Text != "")
				{
					num3 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtRecivedAmtR")).Text);
				}
				string text = fun.FromDate(((TextBox)gridViewRow.FindControl("txtReceiptDate")).Text);
				if (((TextBox)gridViewRow.FindControl("txtRecivedAmtR")).Text != "")
				{
					if (((TextBox)gridViewRow.FindControl("txtRecivedAmtR")).Text != "" && fun.NumberValidationQty(num3.ToString()))
					{
						if (num2 - num3 >= 0.0)
						{
							if (((TextBox)gridViewRow.FindControl("txtReceiptDate")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("txtReceiptDate")).Text))
							{
								string cmdText = fun.insert("tblACC_IOU_Receipt", "MId,SysDate,SysTime,SessionId,CompId,FinYearId,ReceiptDate,RecievedAmount", "'" + num + "','" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + num3 + "'");
								SqlCommand sqlCommand = new SqlCommand(cmdText, con);
								con.Open();
								sqlCommand.ExecuteNonQuery();
								con.Close();
								string cmdText2 = fun.update("tblACC_IOU_Master", "Recieved='1'", "Id='" + num + "'");
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
								con.Open();
								sqlCommand2.ExecuteNonQuery();
								con.Close();
								BindDataGrid_Receipt();
								NED1();
								BindDataGrid();
								NED();
							}
							else
							{
								string empty = string.Empty;
								empty = "Invalid Date.";
								base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
							}
						}
						else
						{
							string empty2 = string.Empty;
							empty2 = "Amount exceeds limit.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty3 = string.Empty;
						empty3 = "Incorrect Input.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty4 = string.Empty;
					empty4 = "Blank input not allowed.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "del")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num4 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblIdR")).Text);
				int num5 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblDIdR")).Text);
				SqlCommand sqlCommand3 = new SqlCommand("DELETE FROM tblACC_IOU_Receipt WHERE Id=" + num5 + " And CompId='" + CompId + "'", con);
				con.Open();
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				string cmdText3 = fun.update("tblACC_IOU_Master", "Recieved='0'", "Id='" + num4 + "' And CompId='" + CompId + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText3, con);
				con.Open();
				sqlCommand4.ExecuteNonQuery();
				con.Close();
				BindDataGrid_Receipt();
				NED1();
				BindDataGrid();
				NED();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			BindDataGrid_Receipt();
			NED1();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		try
		{
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			double num2 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblAmountR")).Text).ToString("N3"));
			double num3 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtRecivedAmtR1")).Text).ToString("N3"));
			string text = fun.FromDate(((TextBox)gridViewRow.FindControl("txtReceiptDate1")).Text);
			if (((TextBox)gridViewRow.FindControl("txtRecivedAmtR1")).Text != "")
			{
				if (((TextBox)gridViewRow.FindControl("txtRecivedAmtR1")).Text != "" && fun.NumberValidationQty(num3.ToString()))
				{
					if (num2 - num3 >= 0.0)
					{
						if (((TextBox)gridViewRow.FindControl("txtReceiptDate1")).Text != "" && fun.DateValidation(((TextBox)gridViewRow.FindControl("txtReceiptDate1")).Text))
						{
							string cmdText = fun.update("tblACC_IOU_Receipt", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',ReceiptDate='" + text + "',RecievedAmount='" + num3 + "'", "MId='" + num + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText, con);
							con.Open();
							sqlCommand.ExecuteNonQuery();
							con.Close();
							GridView1.EditIndex = -1;
							BindDataGrid_Receipt();
							NED1();
						}
						else
						{
							string empty = string.Empty;
							empty = "Invalid Date.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Amount exceeds limit.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Incorrect Input.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "Blank input not allowed.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}
