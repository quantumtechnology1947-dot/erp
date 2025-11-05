using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_SupplierChallan_Edit_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string supid = "";

	private string str = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private int id;

	private int popup;

	protected GridView GridView2;

	protected Panel Panel1;

	protected TextBox txtVehicleNo;

	protected TextBox txtRemarks;

	protected TextBox txtTranspoter;

	protected Button BtnAdd;

	protected Button Btncancel;

	protected Panel Panel2;

	protected TabPanel Add;

	protected GridView GridView1;

	protected Panel Panel4;

	protected Button BtnAdd1;

	protected Button BtnCancel1;

	protected Panel Panel3;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			id = Convert.ToInt32(base.Request.QueryString["Id"]);
			str = fun.Connection();
			con = new SqlConnection(str);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				fillGrid();
			}
			disableCheck();
		}
		catch (Exception)
		{
		}
	}

	public void disableCheck()
	{
		try
		{
			con.Open();
			foreach (GridViewRow row in GridView2.Rows)
			{
				double num = 0.0;
				int num2 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.select("tblInv_Supplier_Challan_Details.PRDId,tblInv_Supplier_Challan_Master.SupplierId", "  tblInv_Supplier_Challan_Details,tblInv_Supplier_Challan_Master ", " tblInv_Supplier_Challan_Master.Id= tblInv_Supplier_Challan_Details.MId And tblInv_Supplier_Challan_Details.Id=" + num2);
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					SqlCommand sqlCommand = new SqlCommand("GetSupplier_PR_ChQty", con);
					sqlCommand.CommandType = CommandType.StoredProcedure;
					sqlCommand.Parameters.Add(new SqlParameter("@SupId", SqlDbType.VarChar));
					sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
					sqlCommand.Parameters["@SupId"].Value = dataSet.Tables[0].Rows[0]["SupplierId"].ToString();
					sqlCommand.Parameters["@Id"].Value = dataSet.Tables[0].Rows[0]["PRDId"].ToString();
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
					sqlDataReader.Read();
					if (sqlDataReader.HasRows)
					{
						num = Convert.ToDouble(decimal.Parse(sqlDataReader[0].ToString()).ToString("N3"));
					}
				}
				((Label)row.FindControl("lblrmnqty")).Text = decimal.Parse(num.ToString()).ToString("N3");
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
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
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = true;
					((TextBox)row.FindControl("txtqty")).Enabled = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = false;
					((TextBox)row.FindControl("txtqty")).Enabled = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void GetValidates()
	{
		try
		{
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblDId1")).Text);
				if (((CheckBox)row.FindControl("CheckBox2")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = true;
					((TextBox)row.FindControl("txtqty")).Enabled = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = false;
					((TextBox)row.FindControl("txtqty")).Enabled = false;
				}
				double num2 = 0.0;
				Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblprqty")).Text).ToString("N3"));
				string cmdText = "SELECT  Sum(tblInv_Supplier_Challan_Clear.ClearedQty) As Qty  FROM  tblInv_Supplier_Challan_Clear INNER JOIN tblInv_Supplier_Challan_Details ON tblInv_Supplier_Challan_Clear.DId = tblInv_Supplier_Challan_Details.Id   And tblInv_Supplier_Challan_Clear.DId=" + num;
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				((Label)row.FindControl("lblqty")).Text = decimal.Parse(num2.ToString()).ToString("N3");
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid()
	{
		try
		{
			con.Open();
			SqlCommand sqlCommand = new SqlCommand("GetChallan_Details", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlCommand.Parameters["@Id"].Value = id;
			sqlCommand.Parameters["@CompId"].Value = CompId;
			SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			DataTable dataTable = new DataTable();
			dataTable.Load(reader);
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			disableCheck();
			GetValidate();
			txtRemarks.Text = dataTable.Rows[0]["Remarks"].ToString();
			txtVehicleNo.Text = dataTable.Rows[0]["VehicleNo"].ToString();
			txtTranspoter.Text = dataTable.Rows[0]["Transpoter"].ToString();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void LoadGrid()
	{
		con.Open();
		try
		{
			SqlCommand sqlCommand = new SqlCommand("GetSup_Challan_Clear_Edit", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlCommand.Parameters["@Id"].Value = id;
			sqlCommand.Parameters["@CompId"].Value = CompId;
			sqlCommand.Parameters["@FinYearId"].Value = fyid;
			SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			DataTable dataTable = new DataTable();
			dataTable.Load(reader);
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
			GetValidates();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		GetValidate();
	}

	protected void BtnAdd_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("CheckBox1")).Checked && ((TextBox)row.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtqty")).Text) != 0.0)
				{
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("LblCHQty")).Text).ToString("N3"));
					double num6 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblrmnqty")).Text).ToString("N3"));
					double num7 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtqty")).Text).ToString("N3"));
					double num8 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblprqty")).Text).ToString("N3"));
					int num9 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					double num10 = 0.0;
					string cmdText = "select ChallanQty From View_Sup_PR_Challan_Calc where SupplierId='" + supid + "' And Id=" + num9;
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num10 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					if (Convert.ToDouble(decimal.Parse((num8 - (num7 + num10)).ToString()).ToString("N3")) >= 0.0 && num6 + num5 - num7 >= 0.0)
					{
						num++;
					}
				}
			}
			if (num2 == num && num2 == 0 && num == 0)
			{
				string cmdText2 = fun.update("tblInv_Supplier_Challan_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',Remarks='" + txtRemarks.Text + "',VehicleNo='" + txtVehicleNo.Text + "',Transpoter='" + txtTranspoter.Text + "'", "Id='" + id + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				num4++;
				popup++;
			}
			if (num2 == num && num > 0)
			{
				new DataSet();
				string cmdText3 = fun.update("tblInv_Supplier_Challan_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',Remarks='" + txtRemarks.Text + "',VehicleNo='" + txtVehicleNo.Text + "',Transpoter='" + txtTranspoter.Text + "'", "Id='" + id + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
				con.Open();
				sqlCommand2.ExecuteNonQuery();
				con.Close();
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					int num11 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					if (((CheckBox)row2.FindControl("CheckBox1")).Checked && ((TextBox)row2.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) != 0.0)
					{
						double num12 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
						SqlCommand sqlCommand3 = new SqlCommand(fun.update("tblInv_Supplier_Challan_Details", "ChallanQty='" + num12 + "'", "Id='" + num11 + "'"), con);
						con.Open();
						sqlCommand3.ExecuteNonQuery();
						con.Close();
						num3++;
					}
				}
			}
			else if (num4 == 0)
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num3 > 0)
			{
				fillGrid();
				popup++;
			}
			PopUp(popup);
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/SupplierChallan_Edit.aspx?ModId=9&SubModId=118");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		if (TabContainer1.ActiveTabIndex == 1)
		{
			LoadGrid();
		}
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		GetValidates();
	}

	protected void BtnAdd1_Click(object sender, EventArgs e)
	{
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (GridViewRow row in GridView1.Rows)
			{
				if (!((CheckBox)row.FindControl("CheckBox2")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("CheckBox2")).Checked && ((TextBox)row.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtqty")).Text) != 0.0)
				{
					double num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtqty")).Text).ToString("N3"));
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblprqty")).Text).ToString("N3"));
					int num6 = Convert.ToInt32(((Label)row.FindControl("lblDId1")).Text);
					string cmdText = "SELECT  Sum(tblInv_Supplier_Challan_Clear.ClearedQty) As Qty  FROM  tblInv_Supplier_Challan_Clear INNER JOIN tblInv_Supplier_Challan_Details ON tblInv_Supplier_Challan_Clear.DId = tblInv_Supplier_Challan_Details.Id   And tblInv_Supplier_Challan_Clear.DId=" + num6;
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
					{
						Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					if (num5 - num4 >= 0.0)
					{
						num++;
					}
				}
			}
			if (num2 == num && num > 0)
			{
				foreach (GridViewRow row2 in GridView1.Rows)
				{
					if (((CheckBox)row2.FindControl("CheckBox2")).Checked && ((TextBox)row2.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) != 0.0)
					{
						double num7 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
						int num8 = Convert.ToInt32(((Label)row2.FindControl("lblId1")).Text);
						SqlCommand sqlCommand = new SqlCommand(fun.update("tblInv_Supplier_Challan_Clear", "SysDate='" + CDate + "',SysTime='" + CTime + "',CompId=" + CompId + ",FinYearId=" + fyid + ",SessionId='" + sId + "',ClearedQty=" + num7, "Id=" + num8), con);
						con.Open();
						sqlCommand.ExecuteNonQuery();
						con.Close();
						num3++;
					}
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid input data.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
			if (num3 > 0)
			{
				LoadGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel1_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/SupplierChallan_Edit.aspx?ModId=9&SubModId=118");
	}

	public void PopUp(int popup)
	{
		if (popup > 0)
		{
			string empty = string.Empty;
			empty = "Data updated successfully.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			popup = 0;
		}
		else
		{
			popup = 0;
		}
	}
}
