using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_CustomerChallan_Clear : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string supid = "";

	private string str = "";

	private string wono = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	protected HtmlHead Head1;

	protected GridView GridView1;

	protected GridView GridView2;

	protected Panel Panel2;

	protected Button BtnAdd;

	protected ScriptManager ScriptManager1;

	protected HtmlForm form1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			wono = base.Request.QueryString["WONo"].ToString();
			sId = Session["username"].ToString();
			str = fun.Connection();
			con = new SqlConnection(str);
			BindData();
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
			BindData();
		}
		catch (Exception)
		{
		}
	}

	public void BindData()
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCCWO", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@WONo", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@WONo"].Value = wono;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = fyid;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
			con.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				if (num.ToString() != string.Empty)
				{
					ViewState["Id"] = num;
					LoadData();
					GetValidate();
					BtnAdd.Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void LoadData()
	{
		try
		{
			con.Open();
			string value = "";
			if (!string.IsNullOrEmpty(ViewState["Id"].ToString()))
			{
				value = ViewState["Id"].ToString();
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetCustChallan_Details", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = value;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
			GetValidate();
			con.Close();
		}
		catch (Exception)
		{
		}
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
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("CheckBox1")).Checked && ((TextBox)row.FindControl("TxtQty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("TxtQty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("TxtQty")).Text) != 0.0)
				{
					double num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("TxtQty")).Text).ToString("N3"));
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblChallanQty")).Text).ToString("N3"));
					int num6 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					double num7 = 0.0;
					string cmdText = "SELECT  Sum(tblInv_Customer_Challan_Clear.ClearQty) As ClearedQty  FROM  tblInv_Customer_Challan_Clear INNER JOIN tblInv_Customer_Challan_Details ON tblInv_Customer_Challan_Clear.DId = tblInv_Customer_Challan_Details.Id   And tblInv_Customer_Challan_Clear.DId=" + num6;
					SqlCommand selectCommand = new SqlCommand(cmdText, con);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num7 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
					}
					if (Convert.ToDouble(decimal.Parse((num5 - (num4 + num7)).ToString()).ToString("N3")) >= 0.0)
					{
						num++;
					}
				}
			}
			if (num2 == num && num > 0)
			{
				new DataSet();
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (((CheckBox)row2.FindControl("CheckBox1")).Checked && ((TextBox)row2.FindControl("TxtQty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("TxtQty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("TxtQty")).Text) != 0.0)
					{
						int num8 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
						double num9 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("TxtQty")).Text).ToString("N3"));
						SqlCommand sqlCommand = new SqlCommand(fun.insert("tblInv_Customer_Challan_Clear", "SysDate,SysTime,SessionId,CompId,FinYearId,DId,ClearQty", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + fyid + "','" + num8 + "','" + num9 + "'"), con);
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
				LoadData();
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
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				if (((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = true;
					((TextBox)row.FindControl("TxtQty")).Enabled = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = false;
					((TextBox)row.FindControl("TxtQty")).Enabled = false;
				}
				double num2 = 0.0;
				double num3 = 0.0;
				num3 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblChallanQty")).Text).ToString("N3"));
				string cmdText = "SELECT  Sum(tblInv_Customer_Challan_Clear.ClearQty) As ClearedQty  FROM  tblInv_Customer_Challan_Clear INNER JOIN tblInv_Customer_Challan_Details ON tblInv_Customer_Challan_Clear.DId = tblInv_Customer_Challan_Details.Id   And tblInv_Customer_Challan_Clear.DId=" + num;
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
				{
					num2 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0][0].ToString()).ToString("N3"));
				}
				((Label)row.FindControl("lblClearedQty")).Text = decimal.Parse(num2.ToString()).ToString("N3");
				if (num3 - num2 > 0.0)
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = true;
				}
				else
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("CustomerChallan_New.aspx");
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
	}
}
