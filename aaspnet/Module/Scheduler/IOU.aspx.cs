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

public class Module_Scheduler_IOU : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected SqlDataSource SqlDataSource1;

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

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
			if (!base.IsPostBack)
			{
				BindDataGrid();
				NED();
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
				int num = Convert.ToInt32(((Label)row.FindControl("Label2")).Text);
				string cmdText = fun.select("Authorize", "tblACC_IOU_Master", "Id='" + num + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && Convert.ToInt32(dataSet.Tables[0].Rows[0]["Authorize"]) == 1)
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
					((LinkButton)row.FindControl("LinkButton4")).Visible = false;
				}
			}
			if (GridView2.Rows.Count == 0)
			{
				((TextBox)GridView2.Controls[0].Controls[0].FindControl("textDate")).Attributes.Add("readonly", "readonly");
				return;
			}
			((TextBox)GridView2.FooterRow.FindControl("txtDate2")).Attributes.Add("readonly", "readonly");
			GridViewRow gridViewRow2 = GridView2.Rows[GridView2.EditIndex];
			((TextBox)gridViewRow2.FindControl("txtDate")).Attributes.Add("readonly", "readonly");
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
			string cmdText = fun.select("*", "tblACC_IOU_Master", "FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And SessionId='" + sId + "' Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("SysDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("SysTime", typeof(string)));
			dataTable.Columns.Add(new DataColumn("EmpName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Amount", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Reason", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Narration", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ReasonId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Sanctioned", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Date", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[1] = dataSet.Tables[0].Rows[i]["SysTime"].ToString();
				string cmdText2 = fun.select("Terms", "tblACC_IOU_Reasons", "Id='" + dataSet.Tables[0].Rows[i]["Reason"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet2.Tables[0].Rows[0]["Terms"].ToString();
				}
				string cmdText3 = fun.select("Title+'.'+EmployeeName+ ' ['+ EmpId +'] ' As EmpLoyeeName", "tblHR_OfficeStaff", string.Concat("CompId='", CompId, "'AND FinYearId<='", FinYearId, "' AND EmpId='", dataSet.Tables[0].Rows[i]["EmpId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[2] = dataSet3.Tables[0].Rows[0]["EmployeeName"].ToString();
				}
				dataRow[3] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Amount"].ToString()).ToString("N3"));
				dataRow[5] = dataSet.Tables[0].Rows[i]["Narration"].ToString();
				dataRow[6] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["Reason"].ToString();
				if (dataSet.Tables[0].Rows[i]["Authorize"].ToString() == "1" && dataSet.Tables[0].Rows[i]["Authorize"] != DBNull.Value)
				{
					dataRow[8] = "Yes";
				}
				else
				{
					dataRow[8] = "No";
				}
				dataRow[9] = fun.FromDate(dataSet.Tables[0].Rows[i]["PaymentDate"].ToString());
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
		GridView2.PageIndex = e.NewPageIndex;
		GridView2.EditIndex = -1;
		BindDataGrid();
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
			NED();
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
			string code = fun.getCode(((TextBox)gridViewRow.FindControl("TextBox1")).Text);
			double num2 = 0.0;
			if (((TextBox)gridViewRow.FindControl("TextBox2")).Text != "")
			{
				num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("TextBox2")).Text).ToString("N3"));
			}
			string text = fun.FromDate(((TextBox)gridViewRow.FindControl("txtDate")).Text);
			int num3 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DrpReason2")).SelectedValue);
			string text2 = ((TextBox)gridViewRow.FindControl("TextBox4")).Text;
			if (!fun.NumberValidationQty(num2.ToString()) || !fun.DateValidation(((TextBox)gridViewRow.FindControl("txtDate")).Text) || !(((TextBox)gridViewRow.FindControl("txtDate")).Text != ""))
			{
				return;
			}
			if (code != "")
			{
				if (num2 != 0.0)
				{
					string cmdText = fun.update("tblACC_IOU_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',EmpId='" + code + "',PaymentDate='" + text + "',Amount='" + num2 + "',Reason='" + num3 + "',Narration='" + text2 + "'", "Id='" + num + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					GridView2.EditIndex = -1;
					BindDataGrid();
					NED();
				}
				else
				{
					string empty = string.Empty;
					empty = "Insert Valid Amount.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "Invalid Employee Name.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Add")
			{
				int num = Convert.ToInt32(((DropDownList)GridView2.FooterRow.FindControl("DrpReason")).SelectedValue);
				string code = fun.getCode(((TextBox)GridView2.FooterRow.FindControl("TxtEmp1")).Text);
				double num2 = 0.0;
				if (((TextBox)GridView2.FooterRow.FindControl("TxtAmt")).Text != "")
				{
					num2 = Convert.ToDouble(((TextBox)GridView2.FooterRow.FindControl("TxtAmt")).Text);
				}
				string text = ((TextBox)GridView2.FooterRow.FindControl("TxtNarrat")).Text;
				string text2 = fun.FromDate(((TextBox)GridView2.FooterRow.FindControl("txtDate2")).Text);
				if (fun.NumberValidationQty(num2.ToString()) && fun.DateValidation(((TextBox)GridView2.FooterRow.FindControl("txtDate2")).Text) && ((TextBox)GridView2.FooterRow.FindControl("txtDate2")).Text != "")
				{
					if (code != "")
					{
						if (num2 != 0.0)
						{
							string cmdText = fun.insert("tblACC_IOU_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,PaymentDate,Amount,Reason,Narration", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + code + "','" + text2 + "','" + Convert.ToDouble(decimal.Parse(num2.ToString()).ToString("N3")) + "','" + num + "','" + text + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText, con);
							con.Open();
							sqlCommand.ExecuteNonQuery();
							con.Close();
							BindDataGrid();
							NED();
						}
						else
						{
							string empty = string.Empty;
							empty = "Insert Valid Amount.";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Invalid Employee Name.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
			}
			if (!(e.CommandName == "Add1"))
			{
				return;
			}
			int num3 = Convert.ToInt32(((DropDownList)GridView2.Controls[0].Controls[0].FindControl("DrpReason1")).SelectedValue);
			string code2 = fun.getCode(((TextBox)GridView2.Controls[0].Controls[0].FindControl("TxtEmp")).Text);
			double num4 = 0.0;
			if (((TextBox)GridView2.Controls[0].Controls[0].FindControl("TxtAmt1")).Text != "")
			{
				num4 = Convert.ToDouble(((TextBox)GridView2.Controls[0].Controls[0].FindControl("TxtAmt1")).Text);
			}
			string text3 = ((TextBox)GridView2.Controls[0].Controls[0].FindControl("TxtNarrat1")).Text;
			string text4 = fun.FromDate(((TextBox)GridView2.Controls[0].Controls[0].FindControl("textDate")).Text);
			if (!fun.NumberValidationQty(num4.ToString()) || !fun.DateValidation(((TextBox)GridView2.Controls[0].Controls[0].FindControl("textDate")).Text) || !(((TextBox)GridView2.Controls[0].Controls[0].FindControl("textDate")).Text != ""))
			{
				return;
			}
			if (code2 != "")
			{
				if (num4 != 0.0)
				{
					string cmdText2 = fun.insert("tblACC_IOU_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,PaymentDate,Amount,Reason,Narration", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + code2 + "','" + text4 + "','" + Convert.ToDouble(decimal.Parse(num4.ToString()).ToString("N3")) + "','" + num3 + "','" + text3 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Insert Valid Amount.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty4 = string.Empty;
				empty4 = "Invalid Employee Name.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
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
}
