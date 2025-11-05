using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_CustomerChallan_Edit_Details : Page, IRequiresSessionState
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

	protected GridView GridView2;

	protected Panel Panel1;

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
			disableCheck();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				fillGrid();
				LoadGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableCheck()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				double num = 0.0;
				double num2 = 0.0;
				int num3 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.select("tblInv_Customer_Challan_Details.PRDId,tblInv_Customer_Challan_Master.CustomerId", "  tblInv_Customer_Challan_Details,tblInv_Customer_Challan_Master ", " tblInv_Customer_Challan_Master.Id= tblInv_Customer_Challan_Details.MId And tblInv_Customer_Challan_Details.Id=" + num3);
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText2 = "SELECT  tblMM_PR_Details.Qty FROM  tblMM_PR_Master INNER JOIN tblMM_PR_Details ON tblMM_PR_Master.Id = tblMM_PR_Details.MId  AND tblMM_PR_Master.CompId='" + CompId + "' AND tblMM_PR_Details.CustomerId='" + dataSet.Tables[0].Rows[0]["CustomerId"].ToString() + "' And tblMM_PR_Details.Id=" + dataSet.Tables[0].Rows[0]["PRDId"].ToString();
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						num = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
				}
				string cmdText3 = "SELECT  Sum(tblInv_Customer_Challan_Details.ChallanQty) As Qty  FROM  tblInv_Customer_Challan_Master INNER JOIN tblInv_Customer_Challan_Details ON tblInv_Customer_Challan_Master.Id = tblInv_Customer_Challan_Details.MId  AND tblInv_Customer_Challan_Master.CompId='" + CompId + "'  And tblInv_Customer_Challan_Details.PRDId=" + dataSet.Tables[0].Rows[0]["PRDId"].ToString() + " And tblInv_Customer_Challan_Master.CustomerId='" + dataSet.Tables[0].Rows[0]["CustomerId"].ToString() + "'";
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				((Label)row.FindControl("lblrmnqty")).Text = decimal.Parse((num - num2).ToString()).ToString("N3");
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
				string cmdText = "SELECT  Sum(tblInv_Customer_Challan_Clear.ClearQty) As Qty  FROM  tblInv_Customer_Challan_Clear INNER JOIN tblInv_Customer_Challan_Details ON tblInv_Customer_Challan_Clear.DId = tblInv_Customer_Challan_Details.Id   And tblInv_Customer_Challan_Clear.DId=" + num;
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
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCustomerChallan_Details", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
			disableCheck();
			GetValidate();
		}
		catch (Exception)
		{
		}
	}

	public void LoadGrid()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCust_Challan_Clear_Edit", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = fyid;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			GetValidates();
		}
		catch (Exception)
		{
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
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					num2++;
					if (((CheckBox)row.FindControl("CheckBox1")).Checked && ((TextBox)row.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtqty")).Text) != 0.0)
					{
						Convert.ToDouble(decimal.Parse(((Label)row.FindControl("LblCHQty")).Text).ToString("N3"));
						Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtqty")).Text).ToString("N3"));
						Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
						num++;
					}
				}
			}
			if (num2 == num && num > 0)
			{
				new DataSet();
				string cmdText = fun.update("tblInv_Customer_Challan_Master", "SysDate='" + CDate + "',SysTime='" + CTime + "',SessionId='" + sId + "',CompId='" + CompId + "',FinYearId='" + fyid + "'", "Id='" + id + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					int num4 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
					if (((CheckBox)row2.FindControl("CheckBox1")).Checked && ((TextBox)row2.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) != 0.0)
					{
						double num5 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
						string cmdText2 = fun.update("tblInv_Customer_Challan_Details", "ChallanQty='" + num5 + "'", "Id='" + num4 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
						con.Open();
						sqlCommand2.ExecuteNonQuery();
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
				fillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/CustomerChallan_Edit.aspx?ModId=9&SubModId=121");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
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
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("LblClearQty")).Text).ToString("N3"));
					double num6 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblprqty")).Text).ToString("N3"));
					int num7 = Convert.ToInt32(((Label)row.FindControl("lblDId1")).Text);
					double num8 = 0.0;
					string cmdText = "SELECT  Sum(tblInv_Customer_Challan_Clear.ClearQty) As Qty  FROM  tblInv_Customer_Challan_Clear INNER JOIN tblInv_Customer_Challan_Details ON tblInv_Customer_Challan_Clear.DId = tblInv_Customer_Challan_Details.Id   And tblInv_Customer_Challan_Clear.DId=" + num7;
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num8 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					if (Convert.ToDouble(decimal.Parse((num6 - (num4 + num8 - num5)).ToString()).ToString("N3")) >= 0.0)
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
						double num9 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
						int num10 = Convert.ToInt32(((Label)row2.FindControl("lblId1")).Text);
						SqlCommand sqlCommand = new SqlCommand(fun.update("tblInv_Customer_Challan_Clear", "SysDate='" + CDate + "',SysTime='" + CTime + "',CompId=" + CompId + ",FinYearId=" + fyid + ",SessionId='" + sId + "',ClearQty=" + num9, "Id=" + num10), con);
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
		base.Response.Redirect("~/Module/Inventory/Transactions/CustomerChallan_Edit.aspx?ModId=9&SubModId=121");
	}
}
