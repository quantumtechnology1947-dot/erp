using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_SupplierChallan_Clear : Page, IRequiresSessionState
{
	protected GridView GridView2;

	protected Panel Panel3;

	protected Button BtnAdd;

	protected Button BtnCancel;

	protected Panel Panel1;

	protected HtmlForm form1;

	private clsFunctions fun = new clsFunctions();

	private string sId = "";

	private int CompId;

	private int fyid;

	private string id = "";

	private string str = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	private string supid = "";

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			fyid = Convert.ToInt32(Session["finyear"]);
			id = base.Request.QueryString["Id"].ToString();
			supid = base.Request.QueryString["SupId"].ToString();
			sId = Session["username"].ToString();
			str = fun.Connection();
			con = new SqlConnection(str);
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack)
			{
				fillGrid(id);
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
					((TextBox)row.FindControl("txtqty")).Enabled = true;
				}
				else
				{
					((RequiredFieldValidator)row.FindControl("ReqChNo")).Visible = false;
					((TextBox)row.FindControl("txtqty")).Enabled = false;
				}
				double num2 = 0.0;
				double num3 = 0.0;
				num3 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblprqty")).Text).ToString("N3"));
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
				if (num3 - num2 <= 0.0)
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = false;
				}
				else
				{
					((CheckBox)row.FindControl("CheckBox1")).Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillGrid(string supid)
	{
		try
		{
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetSup_Challan_Clear", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinYearId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@Id"].Value = id;
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters["@FinYearId"].Value = fyid;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
			GetValidate();
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
				if (!((CheckBox)row.FindControl("CheckBox1")).Checked)
				{
					continue;
				}
				num2++;
				if (((CheckBox)row.FindControl("CheckBox1")).Checked && ((TextBox)row.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row.FindControl("txtqty")).Text) != 0.0)
				{
					double num4 = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtqty")).Text).ToString("N3"));
					double num5 = Convert.ToDouble(decimal.Parse(((Label)row.FindControl("lblprqty")).Text).ToString("N3"));
					int num6 = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
					double num7 = 0.0;
					string cmdText = "SELECT  Sum(tblInv_Supplier_Challan_Clear.ClearedQty) As Qty  FROM  tblInv_Supplier_Challan_Clear INNER JOIN tblInv_Supplier_Challan_Details ON tblInv_Supplier_Challan_Clear.DId = tblInv_Supplier_Challan_Details.Id   And tblInv_Supplier_Challan_Clear.DId=" + num6;
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
				foreach (GridViewRow row2 in GridView2.Rows)
				{
					if (((CheckBox)row2.FindControl("CheckBox1")).Checked && ((TextBox)row2.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) != 0.0)
					{
						double num8 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
						int num9 = Convert.ToInt32(((Label)row2.FindControl("lblId")).Text);
						SqlCommand sqlCommand = new SqlCommand(fun.insert("tblInv_Supplier_Challan_Clear", "SysDate,SysTime,CompId,FinYearId,SessionId,DId,ClearedQty", "'" + CDate + "','" + CTime + "'," + CompId + "," + fyid + ",'" + sId + "'," + num9 + "," + num8), con);
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
				fillGrid(id);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/SupplierChallan_Clear_Details.aspx?supid=" + supid + "&ModId=9&SubModId=118");
	}
}
