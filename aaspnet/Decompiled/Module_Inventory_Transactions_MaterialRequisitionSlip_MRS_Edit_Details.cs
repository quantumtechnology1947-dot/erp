using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_MaterialRequisitionSlip_MRS_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRSNo = "";

	private int FyId;

	private int CompId;

	private string sId = "";

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string MId = "";

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			MRSNo = base.Request.QueryString["MRSNo"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = Convert.ToInt32(base.Request.QueryString["FyId"].ToString());
			MId = base.Request.QueryString["Id"].ToString();
			sId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			if (!base.IsPostBack)
			{
				LoadData();
			}
			getval();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void disableEdit()
	{
		foreach (GridViewRow row in GridView1.Rows)
		{
			int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
			string cmdText = fun.select("tblInv_MaterialRequisition_Details.Id", "tblInv_MaterialIssue_Master,tblInv_MaterialIssue_Details,tblInv_MaterialRequisition_Master,tblInv_MaterialRequisition_Details", "tblInv_MaterialIssue_Master.Id=tblInv_MaterialIssue_Details.MId AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.Id =tblInv_MaterialIssue_Master.MRSId AND tblInv_MaterialRequisition_Master.CompId ='" + CompId + "' AND tblInv_MaterialRequisition_Details.Id=tblInv_MaterialIssue_Details.MRSId AND tblInv_MaterialRequisition_Details.Id='" + num + "' And tblInv_MaterialIssue_Master.MRSNo='" + MRSNo + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				((LinkButton)row.FindControl("LinkButton1")).Visible = false;
				((Label)row.FindControl("lblmin")).Visible = true;
			}
		}
	}

	public void LoadData()
	{
		try
		{
			con.Open();
			SqlCommand selectCommand = new SqlCommand(fun.select("tblInv_MaterialRequisition_Details.Id,tblInv_MaterialRequisition_Details.MRSNo,tblInv_MaterialRequisition_Details.ItemId,tblInv_MaterialRequisition_Details.DeptId,tblInv_MaterialRequisition_Details.WONo,tblInv_MaterialRequisition_Details.ReqQty,tblInv_MaterialRequisition_Details.Remarks", "tblInv_MaterialRequisition_Details,tblInv_MaterialRequisition_Master", "tblInv_MaterialRequisition_Master.Id='" + MId + "' AND tblInv_MaterialRequisition_Master.MRSNo=tblInv_MaterialRequisition_Details.MRSNo AND tblInv_MaterialRequisition_Master.Id=tblInv_MaterialRequisition_Details.MId AND tblInv_MaterialRequisition_Master.CompId='" + CompId + "' "), con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(DS);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("MRSNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOM", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Dept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DW", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ReqQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Remarks", typeof(string)));
			dataTable.Columns.Add(new DataColumn("DeptId", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WODept", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WO", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			string value = "";
			string text = "";
			double num = 0.0;
			string text2 = "";
			string value2 = "";
			string value3 = "";
			for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow[0] = Convert.ToInt32(DS.Tables[0].Rows[i]["Id"]);
				dataRow[1] = DS.Tables[0].Rows[i]["MRSNo"].ToString();
				SqlCommand selectCommand2 = new SqlCommand(fun.select("Id,ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"]) + "' AND CompId='" + CompId + "'"), con);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					SqlCommand selectCommand3 = new SqlCommand(fun.select("Symbol As UOM", "Unit_Master", "Id='" + Convert.ToInt32(dataSet.Tables[0].Rows[0]["UOMBasic"]) + "'"), con);
					DataSet dataSet2 = new DataSet();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					sqlDataAdapter3.Fill(dataSet2);
					dataRow[2] = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS.Tables[0].Rows[i]["ItemId"].ToString()));
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						dataRow[4] = dataSet2.Tables[0].Rows[0]["UOM"].ToString();
					}
					dataRow[3] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[12] = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Id"]);
					dataRow[13] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
				}
				string cmdText = fun.select("Symbol", "BusinessGroup", "Id='" + DS.Tables[0].Rows[i]["DeptId"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter4.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					value = dataSet3.Tables[0].Rows[0][0].ToString();
				}
				if (DS.Tables[0].Rows[i]["DeptId"].ToString() == "1")
				{
					value2 = DS.Tables[0].Rows[i]["WONo"].ToString();
					value3 = "WONo";
				}
				else if (DS.Tables[0].Rows[0]["DeptId"] != DBNull.Value)
				{
					string cmdText2 = fun.select("Symbol", "BusinessGroup", "Id='" + Convert.ToInt32(DS.Tables[0].Rows[i]["DeptId"]) + "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText2, con);
					DataSet dataSet4 = new DataSet();
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					sqlDataAdapter5.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						value2 = dataSet4.Tables[0].Rows[0]["Symbol"].ToString();
						value3 = "BG Group";
					}
				}
				else
				{
					value2 = DS.Tables[0].Rows[0]["WONo"].ToString();
					value3 = "NA";
				}
				dataRow[5] = value;
				dataRow[6] = value2;
				text = DS.Tables[0].Rows[i]["WONo"].ToString();
				num = Convert.ToDouble(decimal.Parse(DS.Tables[0].Rows[i]["ReqQty"].ToString()).ToString("N3"));
				dataRow[7] = num;
				text2 = DS.Tables[0].Rows[i]["Remarks"].ToString();
				dataRow[8] = text2;
				if (DS.Tables[0].Rows[0]["DeptId"] != DBNull.Value)
				{
					dataRow[9] = Convert.ToInt32(DS.Tables[0].Rows[i]["DeptId"]);
				}
				else
				{
					dataRow[9] = 0;
				}
				dataRow[10] = value3;
				dataRow[11] = text;
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
			con.Close();
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		getval();
	}

	public void getval()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "2")
				{
					((TextBox)row.FindControl("txtwono")).Visible = true;
					if (((TextBox)row.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("Req1")).Visible = true;
					}
					((Label)row.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((TextBox)row.FindControl("txtwono")).Visible = false;
					if (!((TextBox)row.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)row.FindControl("Req1")).Visible = false;
					}
				}
				if (((DropDownList)row.FindControl("DropDownList1")).SelectedValue == "1")
				{
					((DropDownList)row.FindControl("drpdept")).Visible = true;
					((Label)row.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((DropDownList)row.FindControl("drpdept")).Visible = false;
				}
			}
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
			LoadData();
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
			LoadData();
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
			LoadData();
			int editIndex = GridView1.EditIndex;
			GridViewRow gridViewRow = GridView1.Rows[editIndex];
			((DropDownList)gridViewRow.FindControl("DropDownList1")).Visible = true;
			((Label)gridViewRow.FindControl("lblWODept")).Visible = false;
			string text = ((Label)gridViewRow.FindControl("lblDwpt")).Text;
			if (text == "1")
			{
				((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue = "2";
				if (((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue == "2")
				{
					((TextBox)gridViewRow.FindControl("txtwono")).Visible = true;
					if (((TextBox)gridViewRow.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = true;
					}
					((Label)gridViewRow.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((TextBox)gridViewRow.FindControl("txtwono")).Visible = false;
					if (!((TextBox)gridViewRow.FindControl("txtwono")).Visible)
					{
						((RequiredFieldValidator)gridViewRow.FindControl("Req1")).Visible = false;
					}
				}
			}
			else
			{
				((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue = "1";
				if (((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue == "1")
				{
					((DropDownList)gridViewRow.FindControl("drpdept")).Visible = true;
					((Label)gridViewRow.FindControl("lblDW")).Visible = false;
				}
				else
				{
					((DropDownList)gridViewRow.FindControl("drpdept")).Visible = false;
				}
			}
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
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			int num2 = Convert.ToInt32(((DropDownList)gridViewRow.FindControl("DropDownList1")).SelectedValue);
			string text = "0";
			string text2 = "";
			double num3 = Convert.ToDouble(decimal.Parse(((Label)gridViewRow.FindControl("lblStockQty")).Text.ToString()).ToString("N3"));
			double num4 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtqty")).Text.ToString()).ToString("N3"));
			string text3 = ((TextBox)gridViewRow.FindControl("txtremarks")).Text;
			text2 = ((TextBox)gridViewRow.FindControl("txtwono")).Text;
			con.Open();
			string text4 = "";
			if (num3 >= num4)
			{
				if (num2 == 1 && fun.NumberValidationQty(num4.ToString()))
				{
					if (((DropDownList)gridViewRow.FindControl("drpdept")).SelectedValue != "0")
					{
						text = ((DropDownList)gridViewRow.FindControl("drpdept")).SelectedValue;
						text4 = fun.update("tblInv_MaterialRequisition_Details", "DeptId='" + text + "',WONo='" + text2 + "',ReqQty='" + num4 + "',Remarks='" + text3 + "'", "Id='" + num + "' And MId='" + MId + "'");
						SqlCommand sqlCommand = new SqlCommand(text4, con);
						sqlCommand.ExecuteNonQuery();
						string cmdText = fun.update("tblInv_MaterialRequisition_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "'", "Id='" + MId + "' And CompId='" + CompId + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText, con);
						sqlCommand2.ExecuteNonQuery();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
				}
				else
				{
					if (num2 != 2 || !fun.NumberValidationQty(num4.ToString()))
					{
						return;
					}
					if (fun.CheckValidWONo(text2, CompId, FyId))
					{
						string cmdText2 = fun.select("*", "SD_Cust_WorkOrder_Master", "WONo='" + text2 + "' And CompId='" + CompId + "'");
						SqlCommand selectCommand = new SqlCommand(cmdText2, con);
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
						DataSet dataSet = new DataSet();
						sqlDataAdapter.Fill(dataSet, "SD_Cust_WorkOrder_Master");
						if (dataSet.Tables[0].Rows.Count > 0)
						{
							text4 = fun.update("tblInv_MaterialRequisition_Details", "DeptId='" + text + "',WONo='" + text2 + "',ReqQty='" + num4 + "',Remarks='" + text3 + "'", "Id='" + num + "' And MId='" + MId + "'");
							SqlCommand sqlCommand3 = new SqlCommand(text4, con);
							sqlCommand3.ExecuteNonQuery();
							string cmdText3 = fun.update("tblInv_MaterialRequisition_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "'", "Id='" + MId + "' And CompId='" + CompId + "'");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText3, con);
							sqlCommand4.ExecuteNonQuery();
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
					}
					else
					{
						string empty = string.Empty;
						empty = "WONo or BG Group is not found!";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
					}
				}
			}
			else
			{
				string empty2 = string.Empty;
				empty2 = "ReqQty should be less than Stock Qty. ";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialRequisitionSlip_MRS_Edit.aspx?ModId=9&SubModId=40");
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
	}
}
