using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Edit_Details : Page, IRequiresSessionState
{
	protected Label lblWono;

	protected Label lblProjectTitle;

	protected Label lblCustName;

	protected GridView GridView1;

	protected Panel Panel1;

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
			string cmdText = fun.select("tblPM_MaterialCreditNote_Details.Id,tblPM_MaterialCreditNote_Master.SysDate,tblPM_MaterialCreditNote_Master.MCNNo,tblPM_MaterialCreditNote_Details.PId,tblPM_MaterialCreditNote_Details.CId,tblPM_MaterialCreditNote_Details.MCNQty", "tblPM_MaterialCreditNote_Master,tblPM_MaterialCreditNote_Details", "tblPM_MaterialCreditNote_Master.Id=tblPM_MaterialCreditNote_Details.MId AND tblPM_MaterialCreditNote_Master.WONo='" + WONo + "' AND tblPM_MaterialCreditNote_Master.FinYearId<='" + FinYearId + "' AND tblPM_MaterialCreditNote_Master.CompId='" + CompId + "' ");
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
			dataTable.Columns.Add(new DataColumn("MCNQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MCNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MCNDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("TotMCNQty", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]);
				dataRow[1] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["PId"]);
				dataRow[2] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["CId"]);
				string cmdText2 = fun.select("*", "tblDG_BOM_Master", "WONo='" + WONo + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' And  PId='" + dataSet.Tables[0].Rows[i]["PId"].ToString() + "' AND CId='" + dataSet.Tables[0].Rows[i]["CId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select("*", "tblDG_Item_Master", "Id='" + Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]) + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblDG_Item_Master");
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					if (dataSet3.Tables[0].Rows[0]["CId"] != DBNull.Value)
					{
						dataRow[3] = dataSet3.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					else
					{
						dataRow[3] = dataSet3.Tables[0].Rows[0]["PartNo"].ToString();
					}
					dataRow[4] = dataSet3.Tables[0].Rows[0]["ManfDesc"].ToString();
					string cmdText4 = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(dataSet3.Tables[0].Rows[0]["UOMBasic"]) + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4, "Unit_Master");
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow[5] = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
					}
					if (!string.IsNullOrEmpty(dataSet3.Tables[0].Rows[0]["FileName"].ToString()))
					{
						dataRow[7] = "View";
					}
					if (!string.IsNullOrEmpty(dataSet3.Tables[0].Rows[0]["AttName"].ToString()))
					{
						dataRow[8] = "View";
					}
				}
				dataRow[6] = decimal.Parse(dataSet2.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");
				dataRow[9] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
				dataRow[10] = dataSet.Tables[0].Rows[i]["MCNQty"].ToString();
				dataRow[11] = dataSet.Tables[0].Rows[i]["MCNNo"].ToString();
				dataRow[12] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				string cmdText5 = fun.select("sum(MCNQty) as TotalMCNQty", "tblPM_MaterialCreditNote_Master,tblPM_MaterialCreditNote_Details", " tblPM_MaterialCreditNote_Master.Id=tblPM_MaterialCreditNote_Details.MId AND tblPM_MaterialCreditNote_Details.PId='" + dataSet.Tables[0].Rows[i]["PId"].ToString() + "'And tblPM_MaterialCreditNote_Details.CId='" + dataSet.Tables[0].Rows[i]["CId"].ToString() + "' AND tblPM_MaterialCreditNote_Master.FinYearId<='" + FinYearId + "' AND tblPM_MaterialCreditNote_Master.CompId='" + CompId + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				dataRow[13] = dataSet5.Tables[0].Rows[0]["TotalMCNQty"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loaddata();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
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
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_Edit.aspx?ModId=7&SubModId=127");
	}

	protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = e.NewEditIndex;
			loaddata();
			int editIndex = GridView1.EditIndex;
			_ = GridView1.Rows[editIndex];
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
			if (((TextBox)gridViewRow.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtqty")).Text) > 0.0)
			{
				int num = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
				double num2 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtqty")).Text);
				double num3 = Convert.ToDouble(((Label)gridViewRow.FindControl("lblMCNQty0")).Text);
				double num4 = Convert.ToDouble(((Label)gridViewRow.FindControl("lblBOMQty")).Text);
				double num5 = Convert.ToDouble(((Label)gridViewRow.FindControl("lblTotMCNQty")).Text);
				double num6 = 0.0;
				num6 = num4 - num5;
				if (num2 <= num3 + num6)
				{
					SqlCommand sqlCommand = new SqlCommand(fun.update("tblPM_MaterialCreditNote_Details", "MCNQty='" + num2 + "'", "Id='" + num + "'"), con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid input data.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		try
		{
			GridView1.EditIndex = -1;
			loaddata();
		}
		catch (Exception)
		{
		}
	}
}
