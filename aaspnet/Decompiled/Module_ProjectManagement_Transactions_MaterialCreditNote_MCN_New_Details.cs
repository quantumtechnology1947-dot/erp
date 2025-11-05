using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_New_Details : Page, IRequiresSessionState
{
	protected Label lblWono;

	protected Label lblProjectTitle;

	protected Label lblCustName;

	protected GridView GridView1;

	protected Panel Panel1;

	protected Button btnSubmit;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	public int pid;

	public int cid;

	private string sId = "";

	private int CompId;

	private int FinYearId;

	private int WOId;

	private string WONo = "";

	private string connStr = string.Empty;

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!string.IsNullOrEmpty(base.Request.QueryString["WOId"]))
			{
				WOId = Convert.ToInt32(base.Request.QueryString["WOId"].ToString());
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = base.Request.QueryString["WONo"].ToString();
			}
			lblWono.Text = WONo;
			string cmdText = fun.select("TaskProjectTitle,CustomerId", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND Id='" + WOId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				lblProjectTitle.Text = dataSet.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
				string cmdText2 = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + dataSet.Tables[0].Rows[0]["CustomerId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					lblCustName.Text = dataSet2.Tables[0].Rows[0]["CustomerName"].ToString() + " [ " + dataSet2.Tables[0].Rows[0]["CustomerId"].ToString() + " ]";
				}
			}
			if (!Page.IsPostBack)
			{
				loaddata();
			}
		}
		catch (Exception)
		{
		}
	}

	public void loaddata()
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			string cmdText = fun.select("*", "tblDG_BOM_Master", "WONo='" + WONo + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And  PId='0' Order By PId");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("PId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("CId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Download", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DownloadSpec", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotalMCNQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MCNQty", typeof(double)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[1] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]);
				dataRow[2] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]);
				string cmdText2 = fun.select("*", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]) + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					if (dataSet2.Tables[0].Rows[0]["CId"] != DBNull.Value)
					{
						dataRow[3] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					else
					{
						dataRow[3] = dataSet2.Tables[0].Rows[0]["PartNo"].ToString();
					}
					dataRow[4] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText3 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["UOMBasic"]) + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3, "Unit_Master");
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
					}
					if (!string.IsNullOrEmpty(dataSet2.Tables[0].Rows[0]["FileName"].ToString()))
					{
						dataRow[7] = "View";
					}
					if (!string.IsNullOrEmpty(dataSet2.Tables[0].Rows[0]["AttName"].ToString()))
					{
						dataRow[8] = "View";
					}
				}
				string cmdText4 = fun.select("Qty", "tblDG_BOM_Master", string.Concat("WONo='", WONo, "' AND PId='", dataRow[1], "'And CId='", dataRow[2], "'"));
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4, "tblDG_BOM_Master");
				double num = 0.0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					num = Convert.ToDouble(decimal.Parse(dataSet4.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
				}
				dataRow[6] = decimal.Parse(num.ToString()).ToString("N3");
				dataRow[9] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"]);
				string cmdText5 = fun.select("sum(MCNQty) as TotalMCNQty", "tblPM_MaterialCreditNote_Master,tblPM_MaterialCreditNote_Details", string.Concat(" tblPM_MaterialCreditNote_Master.Id=tblPM_MaterialCreditNote_Details.MId AND tblPM_MaterialCreditNote_Details.PId='", dataRow[1], "'And tblPM_MaterialCreditNote_Details.CId='", dataRow[2], "' AND tblPM_MaterialCreditNote_Master.FinYearId<='", FinYearId, "' AND tblPM_MaterialCreditNote_Master.CompId='", CompId, "' "));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0]["TotalMCNQty"] != DBNull.Value)
				{
					dataRow[10] = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["TotalMCNQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[10] = 0;
				}
				dataRow[11] = 0;
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				double num2 = 0.0;
				if (((Label)row.FindControl("lblTotalMCNQty")).Text != "")
				{
					num2 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblBOMQty")).Text).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotalMCNQty")).Text).ToString("N3"));
					if (num2 == 0.0)
					{
						((TextBox)row.FindControl("txtqty")).Visible = false;
					}
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
		loaddata();
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		if (e.CommandName == "Download")
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=fileName&qct=ContentType");
		}
		if (e.CommandName == "DownloadSpec")
		{
			GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num2 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblItemId")).Text);
			base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num2 + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
		}
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		string cmdText = fun.select("MCNNo", "tblPM_MaterialCreditNote_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet, "tblPM_MaterialCreditNote_Master");
		string text = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		foreach (GridViewRow row in GridView1.Rows)
		{
			double num4 = 0.0;
			double num5 = 0.0;
			num4 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblBOMQty")).Text).ToString("N3"));
			num5 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtqty")).Text).ToString("N3"));
			if (((TextBox)row.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtqty")).Text) > 0.0)
			{
				num3++;
				if (num4 - num5 >= 0.0)
				{
					num++;
				}
			}
		}
		if (num3 - num == 0)
		{
			string cmdText2 = fun.insert("tblPM_MaterialCreditNote_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,MCNNo,WONo", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + text + "','" + WONo + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
			con.Open();
			sqlCommand.ExecuteNonQuery();
			con.Close();
			string cmdText3 = fun.select("Id", "tblPM_MaterialCreditNote_Master", "CompId='" + CompId + "'  Order By Id Desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			int num6 = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["Id"].ToString());
			foreach (GridViewRow row2 in GridView1.Rows)
			{
				double num7 = 0.0;
				double num8 = 0.0;
				num7 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblBOMQty")).Text).ToString("N3"));
				num8 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
				if (((TextBox)row2.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) > 0.0 && num7 - num8 >= 0.0)
				{
					int num9 = Convert.ToInt32(((Label)row2.FindControl("lblPId")).Text);
					int num10 = Convert.ToInt32(((Label)row2.FindControl("lblCId")).Text);
					double num11 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
					SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblPM_MaterialCreditNote_Details", "MId,PId,CId,MCNQty", num6 + ",'" + num9 + "','" + num10 + "','" + num11 + "'"), con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					num2++;
				}
			}
			if (num2 > 0)
			{
				base.Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_New.aspx?ModId=7&SubModId=127");
			}
		}
		else
		{
			string empty = string.Empty;
			empty = "Invalid input data.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_New.aspx?ModId=7&SubModId=127");
	}
}
