using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_AuthorizedMCN_Details : Page, IRequiresSessionState
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
			string cmdText = fun.select("tblPM_MaterialCreditNote_Details.Id,tblPM_MaterialCreditNote_Master.SysDate,tblPM_MaterialCreditNote_Master.Id AS MCNId,tblPM_MaterialCreditNote_Master.MCNNo,tblPM_MaterialCreditNote_Details.PId,tblPM_MaterialCreditNote_Details.CId,tblPM_MaterialCreditNote_Details.MCNQty", "tblPM_MaterialCreditNote_Master,tblPM_MaterialCreditNote_Details", "tblPM_MaterialCreditNote_Master.Id=tblPM_MaterialCreditNote_Details.MId AND tblPM_MaterialCreditNote_Master.WONo='" + WONo + "' AND tblPM_MaterialCreditNote_Master.FinYearId<='" + FinYearId + "' AND tblPM_MaterialCreditNote_Master.CompId='" + CompId + "' ");
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
			dataTable.Columns.Add(new DataColumn("Download", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DownloadSpec", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MCNQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MCNNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MCNDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MCNId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TotQAQty", typeof(double)));
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
						dataRow[6] = "View";
					}
					if (!string.IsNullOrEmpty(dataSet3.Tables[0].Rows[0]["AttName"].ToString()))
					{
						dataRow[7] = "View";
					}
				}
				dataRow[8] = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["ItemId"]);
				dataRow[9] = Convert.ToDouble(dataSet.Tables[0].Rows[i]["MCNQty"].ToString());
				dataRow[10] = dataSet.Tables[0].Rows[i]["MCNNo"].ToString();
				dataRow[11] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[12] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["MCNId"]);
				string cmdText5 = fun.select("sum(QAQty)as TotQAQty", "tblQc_AuthorizedMCN", "FinYearId<='" + FinYearId + "' AND CompId='" + CompId + "' AND MCNId ='" + dataSet.Tables[0].Rows[i]["MCNId"].ToString() + "'AND MCNDId ='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0][0] != DBNull.Value)
				{
					dataRow[13] = Convert.ToDouble(dataSet5.Tables[0].Rows[0]["TotQAQty"].ToString());
				}
				else
				{
					dataRow[13] = 0;
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			foreach (GridViewRow row in GridView1.Rows)
			{
				double num = 0.0;
				if (((Label)row.FindControl("lblTotQAQty")).Text != "")
				{
					num = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblMCNQty")).Text).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotQAQty")).Text).ToString("N3"));
					if (num == 0.0)
					{
						((CheckBox)row.FindControl("CheckBox1")).Visible = false;
						((TextBox)row.FindControl("txtqty")).Enabled = false;
					}
				}
			}
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

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			int num = 0;
			int num2 = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num2++;
					double num3 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblMCNQty")).Text).ToString("N3"));
					double num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtqty")).Text).ToString("N3"));
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblTotQAQty")).Text).ToString("N3"));
					if (((TextBox)row.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtqty")).Text) > 0.0 && num3 - num5 - num4 >= 0.0)
					{
						num++;
					}
				}
			}
			if (num2 - num == 0)
			{
				foreach (GridViewRow row2 in GridView1.Rows)
				{
					int num6 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					int num7 = Convert.ToInt32(((Label)row2.FindControl("lblMCNId")).Text);
					double num8 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblMCNQty")).Text).ToString("N3"));
					double num9 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
					double num10 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblTotQAQty")).Text).ToString("N3"));
					if (!((CheckBox)row2.FindControl("CheckBox1")).Checked || !(((TextBox)row2.FindControl("txtqty")).Text != "") || !fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) || !(Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) > 0.0) || !(num8 - num10 - num9 >= 0.0))
					{
						continue;
					}
					string cmdText = fun.insert("tblQc_AuthorizedMCN", "SysDate,SysTime,SessionId,CompId,FinYearId,MCNId,MCNDId,QAQty", "'" + currDate + "','" + currTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + num7 + "','" + num6 + "','" + num9 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText2 = "SELECT tblPM_MaterialCreditNote_Master.Id, tblDG_BOM_Master.ItemId FROM  tblDG_BOM_Master INNER JOIN tblPM_MaterialCreditNote_Master ON tblDG_BOM_Master.WONo = tblPM_MaterialCreditNote_Master.WONo INNER JOIN  tblPM_MaterialCreditNote_Details ON tblPM_MaterialCreditNote_Master.Id = tblPM_MaterialCreditNote_Details.MId AND  tblDG_BOM_Master.PId = tblPM_MaterialCreditNote_Details.PId AND tblDG_BOM_Master.CId = tblPM_MaterialCreditNote_Details.CId where tblDG_BOM_Master.FinYearId<='" + FinYearId + "' AND tblDG_BOM_Master.CompId='" + CompId + "' And tblPM_MaterialCreditNote_Details.Id='" + num6 + "' AND tblPM_MaterialCreditNote_Details.MId='" + num7 + "'";
					SqlCommand selectCommand = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
					{
						string cmdText3 = fun.select("StockQty", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "'");
						SqlCommand selectCommand2 = new SqlCommand(cmdText3, con);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
						DataSet dataSet2 = new DataSet();
						sqlDataAdapter2.Fill(dataSet2);
						double num11 = 0.0;
						if (dataSet2.Tables[0].Rows.Count > 0)
						{
							num11 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) + num9;
						}
						string cmdText4 = fun.update("tblDG_Item_Master", "StockQty='" + num11 + "'", "CompId='" + CompId + "' AND Id='" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
						con.Close();
					}
				}
				loaddata();
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("AuthorizedMCN.aspx?ModId=10&SubModId=128");
	}
}
