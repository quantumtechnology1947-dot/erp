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

public class Module_MaterialManagement_Transactions_PR_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string WONO = "";

	private string sId = "";

	private int CompId;

	private string prno = "";

	private int fyid;

	private string supid = "";

	private string MId = "";

	private string str = "";

	private SqlConnection con;

	protected Label lblwo;

	protected Label lbltype;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Button Btnupdate;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			prno = base.Request.QueryString["PRNo"].ToString();
			WONO = base.Request.QueryString["WONo"].ToString();
			MId = base.Request.QueryString["Id"].ToString();
			sId = Session["username"].ToString();
			str = fun.Connection();
			con = new SqlConnection(str);
			lblwo.Text = prno;
			GetValidate();
			if (!base.IsPostBack)
			{
				fillGrid(supid);
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				((TextBox)row.FindControl("TxtDelDate")).Attributes.Add("readonly", "readonly");
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableCheck()
	{
		foreach (GridViewRow row in GridView2.Rows)
		{
			string text = ((Label)row.FindControl("lblid")).Text;
			string cmdText = fun.select("tblMM_PO_Details.Id", "tblMM_PO_Details,tblMM_PO_Master", "tblMM_PO_Details.PRNo='" + prno + "' AND tblMM_PO_Master.PONo=tblMM_PO_Details.PONo AND tblMM_PO_Master.CompId='" + CompId + "' AND tblMM_PO_Details.PRId='" + text + "' AND tblMM_PO_Details.MId=tblMM_PO_Master.Id");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				((CheckBox)row.FindControl("CheckBox1")).Visible = false;
				((Label)row.FindControl("lblEdit")).Visible = true;
			}
			else
			{
				((CheckBox)row.FindControl("CheckBox1")).Visible = true;
				((Label)row.FindControl("lblEdit")).Visible = false;
			}
		}
	}

	public void fillGrid(string supid)
	{
		try
		{
			con.Open();
			string cmdText = fun.select("tblMM_PR_Details.Id,tblMM_PR_Details.Discount,tblMM_PR_Details.Qty,tblMM_PR_Details.AHId,tblMM_PR_Details.SupplierId,tblMM_PR_Details.PId,tblMM_PR_Details.DelDate,tblMM_PR_Details.CId,tblMM_PR_Details.Rate,tblMM_PR_Details.PRNo,tblMM_PR_Details.ItemId,tblMM_PR_Details.Type,tblMM_PR_Details.Remarks,tblMM_PR_Master.Id", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId AND tblMM_PR_Master.PRNo='" + prno + "' AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.MId='" + MId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PurchDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Supplier", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DelDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PRQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Rate", typeof(double)));
			dataTable.Columns.Add(new DataColumn("AccHead", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MINQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Discount", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("ManfDesc,UOMBasic", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[0] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					dataRow[1] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[2] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					}
				}
				double num = 0.0;
				dataRow[3] = Convert.ToDouble(decimal.Parse(Convert.ToDouble(decimal.Parse(fun.AllComponentBOMQty(CompId, WONO, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), fyid).ToString()).ToString("N3")).ToString()).ToString("N3"));
				string cmdText4 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", string.Concat("SupplierId='", dataSet.Tables[0].Rows[i]["SupplierId"], "' AND CompId='", CompId, "'"));
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					dataRow[4] = dataSet4.Tables[0].Rows[0].ItemArray[1].ToString() + " [" + dataSet4.Tables[0].Rows[0].ItemArray[0].ToString() + "]";
				}
				dataRow[5] = fun.ToDateDMY(dataSet.Tables[0].Rows[i]["DelDate"].ToString());
				dataRow[6] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				dataRow[9] = decimal.Parse(dataSet.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3");
				dataRow[10] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Rate"].ToString()).ToString("N2"));
				string cmdText5 = fun.select("Symbol", "AccHead", string.Concat("Id='", dataSet.Tables[0].Rows[i]["AHId"], "'"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				dataRow[11] = dataSet5.Tables[0].Rows[0]["Symbol"].ToString();
				dataRow[12] = dataSet.Tables[0].Rows[i]["Remarks"];
				dataRow[15] = dataSet.Tables[0].Rows[i]["Id"];
				string cmdText6 = fun.select("sum(IssueQty)As MinQty", "tblInv_MaterialIssue_Details,tblInv_MaterialIssue_Master,tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialIssue_Details.MINNo=tblInv_MaterialIssue_Master.MINNo And tblInv_MaterialRequisition_Details.MRSNo=tblInv_MaterialRequisition_Master.MRSNo and tblInv_MaterialRequisition_Details.ItemId='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' And tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId And tblInv_MaterialIssue_Master.MRSNo =tblInv_MaterialRequisition_Details.MRSNo And tblInv_MaterialRequisition_Details.WONo='" + WONO + "' And tblInv_MaterialIssue_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0 && dataSet6.Tables[0].Rows[0][0] != DBNull.Value)
				{
					dataRow[16] = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[16] = 0.0;
				}
				dataRow[17] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Discount"].ToString()).ToString("N2"));
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			disableCheck();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "rate")
			{
				GridViewRow gridViewRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblitemid")).Text);
				base.Response.Redirect("~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + num + "&CompId=" + CompId);
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidate()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("ReqSuppler")).Visible = true;
					((RequiredFieldValidator)row.FindControl("ReqRate")).Visible = true;
					((RequiredFieldValidator)row.FindControl("ReqDelDate")).Visible = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqSuppler")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqRate")).Visible = false;
					((RequiredFieldValidator)row.FindControl("ReqDelDate")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		fillGrid(supid);
		GetValidate();
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
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

	protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("PR_Edit.aspx?ModId=6&SubModId=34");
	}

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void Btnupdate_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			fun.getCurrDate();
			fun.getCurrTime();
			Session["username"].ToString();
			Convert.ToInt32(Session["finyear"]);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			double num4 = 0.0;
			double num5 = 0.0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				num2++;
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked || !(((TextBox)row.FindControl("TxtSupplier")).Text != "") || !(((TextBox)row.FindControl("TxtRate")).Text != "") || !(((TextBox)row.FindControl("TxtDelDate")).Text != "") || !fun.NumberValidationQty(((TextBox)row.FindControl("TxtRate")).Text) || !(Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtRate")).Text).ToString("N2")) > 0.0))
				{
					continue;
				}
				double num6 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtRate")).Text).ToString("N2"));
				num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtDiscount")).Text).ToString("N2"));
				num5 = Convert.ToDouble(decimal.Parse((num6 - num6 * num4 / 100.0).ToString()).ToString("N2"));
				string text = ((Label)row.FindControl("lblitemid")).Text;
				string cmdText = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + text + "' And CompId='" + CompId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				double num7 = 0.0;
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num7 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
				int num8 = 0;
				if (num5 > 0.0)
				{
					if (num7 > 0.0)
					{
						double num9 = 0.0;
						num9 = Convert.ToDouble(decimal.Parse((num7 - num5).ToString()).ToString("N2"));
						if (num9 >= 0.0)
						{
							num8 = 1;
						}
						else
						{
							string cmdText2 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='0'");
							SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet2 = new DataSet();
							sqlDataAdapter2.Fill(dataSet2);
							if (dataSet2.Tables[0].Rows.Count > 0)
							{
								num8 = 1;
							}
						}
					}
					else
					{
						num8 = 1;
					}
				}
				if (num8 == 1 && num5 > 0.0)
				{
					num++;
				}
			}
			if (num2 == num && num > 0)
			{
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (((CheckBox)row2.FindControl("CheckBox1")).Checked)
					{
						int num10 = Convert.ToInt32(((Label)row2.FindControl("LblId")).Text);
						string code = fun.getCode(((TextBox)row2.FindControl("TxtSupplier")).Text);
						double num11 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtRate")).Text).ToString("N2"));
						double num12 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtDiscount")).Text).ToString("N2"));
						string text2 = fun.ToDate(((TextBox)row2.FindControl("TxtDelDate")).Text);
						string text3 = ((TextBox)row2.FindControl("TxtRmk")).Text;
						if (text2 != "" && fun.chkSupplierCode(code) == 1 && fun.DateValidation(((TextBox)row2.FindControl("TxtDelDate")).Text) && fun.NumberValidationQty(num11.ToString()))
						{
							string cmdText3 = fun.update("tblMM_PR_Details", "SupplierId='" + code + "' ,Rate='" + num11 + "'  , DelDate='" + text2 + "', Remarks='" + text3 + "',Discount='" + num12 + "'", "Id='" + num10 + "'");
							SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
							sqlConnection.Open();
							sqlCommand.ExecuteNonQuery();
							sqlConnection.Close();
							num3++;
						}
					}
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid data input.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num3 > 0)
			{
				base.Response.Redirect("PR_Edit.aspx?ModId=6&SubModId=34");
			}
		}
		catch (Exception)
		{
		}
	}
}
