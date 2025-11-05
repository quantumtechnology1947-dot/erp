using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_New_Details : Page, IRequiresSessionState
{
	protected GridView GridView3;

	protected Button btnProceed;

	protected Button btnCancel;

	private clsFunctions fun = new clsFunctions();

	private string fyid = "";

	private string mrnno = "";

	private int CompId;

	private string Sid = "";

	private string MId = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			fyid = base.Request.QueryString["fyid"].ToString();
			mrnno = base.Request.QueryString["mrnno"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			MId = base.Request.QueryString["Id"].ToString();
			Sid = Session["username"].ToString();
			if (!base.IsPostBack)
			{
				loadgrid();
			}
			foreach (GridViewRow row in GridView3.Rows)
			{
				((CheckBox)row.FindControl("ck")).Checked = true;
				double num = Convert.ToDouble(((Label)row.FindControl("lblretqty")).Text) - (Convert.ToDouble(((Label)row.FindControl("lblAccpQty")).Text) + Convert.ToDouble(((Label)row.FindControl("lblScrap")).Text));
				if (num > 0.0)
				{
					((CheckBox)row.FindControl("ck")).Checked = true;
					((CheckBox)row.FindControl("ck")).Visible = true;
				}
				else
				{
					((CheckBox)row.FindControl("ck")).Checked = false;
					((CheckBox)row.FindControl("ck")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadgrid()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			string cmdText = fun.select("tblInv_MaterialReturn_Details.Id,tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Master,tblInv_MaterialReturn_Details", "tblInv_MaterialReturn_Master.CompId='" + CompId + "' AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.Id='" + MId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("RetQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("RecQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Qty", typeof(double)));
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			string text = "";
			double num = 0.0;
			string text2 = "";
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					value = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(dataSet.Tables[0].Rows[i]["ItemId"].ToString()));
					value2 = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
					Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
					string cmdText3 = fun.select("Symbol", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0)
					{
						value3 = dataSet3.Tables[0].Rows[0][0].ToString();
					}
				}
				string cmdText4 = fun.select("Symbol", "tblHR_Departments", "Id='" + dataSet.Tables[0].Rows[i]["DeptId"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					value4 = dataSet4.Tables[0].Rows[0][0].ToString();
				}
				dataRow[0] = value;
				dataRow[1] = value2;
				dataRow[2] = value3;
				dataRow[3] = value4;
				if (dataSet.Tables[0].Rows[i]["WONo"].ToString() != "")
				{
					text = dataSet.Tables[0].Rows[i]["WONo"].ToString();
					dataRow[4] = text;
				}
				else
				{
					text = "NA";
					dataRow[4] = text;
				}
				num = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["RetQty"].ToString()).ToString("N3"));
				dataRow[5] = num;
				text2 = dataSet.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[6] = text2;
				dataRow[7] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string cmdText5 = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as sum_AcceptedQty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				if (dataSet5.Tables[0].Rows[0]["sum_AcceptedQty"] != DBNull.Value)
				{
					dataRow[8] = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["sum_AcceptedQty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[8] = 0;
				}
				dataRow[9] = dataSet.Tables[0].Rows[i]["ItemId"].ToString();
				string cmdText6 = fun.select("tblQC_Scrapregister.Qty As Qty ", "tblQC_Scrapregister,tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master", "tblQc_MaterialReturnQuality_Master.Id=tblQC_Scrapregister.MRQNId  And  tblQc_MaterialReturnQuality_Details.Id= tblQC_Scrapregister.MRQNDId  AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' And tblQC_Scrapregister.CompId='" + CompId + "'  ");
				SqlCommand selectCommand6 = new SqlCommand(cmdText6, connection);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count > 0)
				{
					dataRow[10] = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
				}
				else
				{
					dataRow[10] = 0;
				}
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView3.DataSource = dataTable;
			GridView3.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView3.PageIndex = e.NewPageIndex;
			loadgrid();
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialReturnQualityNote_MRQN_New.aspx?ModId=10&SubModId=49");
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = Session["username"].ToString();
			int num = Convert.ToInt32(Session["finyear"]);
			int num2 = Convert.ToInt32(Session["compid"]);
			string cmdText = fun.select("MRQNNo", "tblQc_MaterialReturnQuality_Master", "CompId='" + num2 + "' AND FinYearId='" + num + "'  Order by MRQNNo Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblQc_MaterialReturnQuality_Master");
			string text2 = "";
			text2 = ((dataSet.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			string cmdText2 = fun.select("ScrapNo", "tblQC_Scrapregister", "CompId='" + num2 + "' AND FinYearId='" + num + "'  Order by ScrapNo Desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
			new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter.Fill(dataSet2, "tblQc_MaterialReturnQuality_Master");
			string text3 = "";
			text3 = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			foreach (GridViewRow row in GridView3.Rows)
			{
				if (((CheckBox)row.FindControl("ck")).Checked)
				{
					num4++;
					Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblretqty")).Text.ToString()).ToString("N3"));
					double num6 = 0.0;
					num6 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtAccpQty")).Text.ToString()).ToString("N3"));
					double num7 = 0.0;
					num7 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblretqty")).Text.ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblAccpQty")).Text.ToString()).ToString("N3"));
					if (num6 > 0.0 && fun.NumberValidationQty(num6.ToString()) && num7 >= num6)
					{
						num3++;
					}
				}
			}
			if (num4 == num3 && num3 > 0)
			{
				int num8 = 1;
				string text4 = "";
				foreach (GridViewRow row2 in GridView3.Rows)
				{
					if (!((CheckBox)row2.FindControl("ck")).Checked)
					{
						continue;
					}
					string text5 = ((Label)row2.FindControl("lblitemid")).Text;
					string text6 = ((Label)row2.FindControl("lblId")).Text;
					int num9 = Convert.ToInt32(((DropDownList)row2.FindControl("Drptype")).SelectedValue);
					double num10 = 0.0;
					num10 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblretqty")).Text.ToString()).ToString("N3"));
					double num11 = 0.0;
					num11 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtAccpQty")).Text.ToString()).ToString("N3"));
					double num12 = 0.0;
					num12 = Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblretqty")).Text.ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)row2.FindControl("lblAccpQty")).Text.ToString()).ToString("N3"));
					double num13 = 0.0;
					if (!(num11 > 0.0) || !fun.NumberValidationQty(num11.ToString()) || !(num12 >= num11))
					{
						continue;
					}
					if (num8 == 1)
					{
						string cmdText3 = fun.insert("tblQc_MaterialReturnQuality_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,MRQNNo,MRNNo,MRNId", "'" + currDate + "','" + currTime + "','" + num2 + "','" + num + "','" + text + "','" + text2 + "','" + mrnno + "','" + MId + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
						sqlCommand.ExecuteNonQuery();
						num8 = 0;
						string cmdText4 = fun.select("Id", "tblQc_MaterialReturnQuality_Master", "CompId='" + num2 + "' Order by Id Desc");
						SqlCommand selectCommand3 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand3);
						DataSet dataSet3 = new DataSet();
						sqlDataAdapter2.Fill(dataSet3, "tblQc_MaterialReturnQuality_Master");
						text4 = dataSet3.Tables[0].Rows[0]["Id"].ToString();
					}
					string cmdText5 = fun.insert("tblQc_MaterialReturnQuality_Details", "MId,MRQNNo,MRNId,AcceptedQty", "'" + text4 + "','" + text2 + "','" + text6 + "','" + num11 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand2.ExecuteNonQuery();
					if (num9 == 1)
					{
						string cmdText6 = fun.select("Id", "tblQc_MaterialReturnQuality_Details", "MId='" + text4 + "' Order by Id Desc");
						SqlCommand selectCommand4 = new SqlCommand(cmdText6, sqlConnection);
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter3.Fill(dataSet4, "tblQc_MaterialReturnQuality_Master");
						string text7 = "";
						double num14 = 0.0;
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							text7 = dataSet4.Tables[0].Rows[0]["Id"].ToString();
						}
						string cmdText7 = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as Qty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + num2 + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + text6 + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText7, sqlConnection);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter4.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows.Count > 0)
						{
							num14 = Convert.ToDouble(decimal.Parse(dataSet5.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
						}
						double num15 = 0.0;
						num15 = num10 - num14;
						string cmdText8 = fun.insert("tblQC_Scrapregister", "SysDate,SysTime,CompId,FinYearId,SessionId,MRQNId,MRQNDId,ItemId,ScrapNo,Qty", "'" + currDate + "','" + currTime + "','" + num2 + "','" + num + "','" + Sid + "','" + text4 + "','" + text7 + "','" + text5 + "','" + text3 + "','" + num15 + "'");
						SqlCommand sqlCommand3 = new SqlCommand(cmdText8, sqlConnection);
						sqlCommand3.ExecuteNonQuery();
					}
					string cmdText9 = fun.select("StockQty", "tblDG_Item_Master", "CompId='" + num2 + "' AND Id='" + text5 + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText9, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter5.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows.Count > 0)
					{
						num13 = Convert.ToDouble(decimal.Parse(dataSet6.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) + num11;
					}
					string cmdText10 = fun.update("tblDG_Item_Master", "StockQty='" + num13 + "'", "CompId='" + num2 + "' AND Id='" + text5 + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText10, sqlConnection);
					sqlCommand4.ExecuteNonQuery();
					num5++;
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num5 > 0)
			{
				base.Response.Redirect("MaterialReturnQualityNote_MRQN_New.aspx?ModId=10&SubModId=49");
			}
		}
		catch (Exception)
		{
		}
	}
}
