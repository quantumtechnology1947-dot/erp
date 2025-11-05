using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_SupplierChallan_New_Details : Page, IRequiresSessionState
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

	protected GridView GridView2;

	protected Panel Panel3;

	protected TextBox txtVehicleNo;

	protected TextBox txtRemarks;

	protected TextBox txtTranspoter;

	protected Button BtnAdd;

	protected Button btnCancel;

	protected Panel Panel1;

	protected TabPanel Add;

	protected HtmlGenericControl myframe;

	protected Panel Panel2;

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
			supid = base.Request.QueryString["SupplierId"].ToString();
			sId = Session["username"].ToString();
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				fillGrid(supid);
				txtRemarks.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	public void disableCheck()
	{
		con.Open();
		foreach (GridViewRow row in GridView2.Rows)
		{
			int num = Convert.ToInt32(((Label)row.FindControl("lblprDId")).Text);
			double num2 = 0.0;
			SqlCommand sqlCommand = new SqlCommand("GetSupplier_PR_ChQty", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@SupId", SqlDbType.VarChar));
			sqlCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar));
			sqlCommand.Parameters["@SupId"].Value = supid;
			sqlCommand.Parameters["@Id"].Value = num;
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			sqlDataReader.Read();
			if (sqlDataReader.HasRows)
			{
				num2 = Convert.ToDouble(decimal.Parse(sqlDataReader[0].ToString()).ToString("N3"));
			}
			((Label)row.FindControl("lblqty")).Text = decimal.Parse(num2.ToString()).ToString("N3");
			if (num2 <= 0.0)
			{
				((CheckBox)row.FindControl("CheckBox1")).Visible = false;
			}
			else
			{
				((CheckBox)row.FindControl("CheckBox1")).Visible = true;
			}
		}
	}

	public void fillGrid(string supid)
	{
		try
		{
			con.Open();
			SqlCommand sqlCommand = new SqlCommand("GetSup_Challan", con);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(new SqlParameter("@SupId", SqlDbType.VarChar));
			sqlCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlCommand.Parameters["@SupId"].Value = supid;
			sqlCommand.Parameters["@CompId"].Value = CompId;
			SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			DataTable dataTable = new DataTable();
			dataTable.Load(reader);
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
			disableCheck();
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
		if (((CheckBox)gridViewRow.FindControl("CheckBox1")).Checked)
		{
			((RequiredFieldValidator)gridViewRow.FindControl("ReqChNo")).Visible = true;
			((RegularExpressionValidator)gridViewRow.FindControl("Reg2")).Visible = true;
			((TextBox)gridViewRow.FindControl("txtqty")).Enabled = true;
		}
		else
		{
			((RequiredFieldValidator)gridViewRow.FindControl("ReqChNo")).Visible = false;
			((RegularExpressionValidator)gridViewRow.FindControl("Reg2")).Visible = false;
			((TextBox)gridViewRow.FindControl("txtqty")).Enabled = false;
		}
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
					int num6 = Convert.ToInt32(((Label)row.FindControl("lblprDId")).Text);
					double num7 = 0.0;
					string cmdText = "SELECT  Sum(tblInv_Supplier_Challan_Details.ChallanQty) As Qty  FROM  tblInv_Supplier_Challan_Master INNER JOIN tblInv_Supplier_Challan_Details ON tblInv_Supplier_Challan_Master.Id = tblInv_Supplier_Challan_Details.MId  AND tblInv_Supplier_Challan_Master.CompId='" + CompId + "' AND tblInv_Supplier_Challan_Master.SupplierId='" + supid + "' And tblInv_Supplier_Challan_Details.PRDId=" + num6;
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
				DataSet dataSet2 = new DataSet();
				CDate = fun.getCurrDate();
				CTime = fun.getCurrTime();
				string cmdText2 = fun.select("SCNo", "tblInv_Supplier_Challan_Master", "CompId='" + CompId + "' AND FinYearId='" + fyid + "' order by Id desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2, "tblInv_Supplier_Challan_Master");
				string text = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				int num8 = fun.chkEmpCustSupplierCode(supid, 3, CompId);
				if (num8 == 1)
				{
					string cmdText3 = fun.insert("tblInv_Supplier_Challan_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,SCNo,SupplierId,Remarks,VehicleNo,Transpoter", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + fyid + "','" + text + "','" + supid + "','" + txtRemarks.Text + "','" + txtVehicleNo.Text + "','" + txtTranspoter.Text + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText4 = fun.select("Id", "tblInv_Supplier_Challan_Master", "CompId='" + CompId + "' AND SCNo='" + text + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					int num9 = Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Id"].ToString());
					foreach (GridViewRow row2 in GridView2.Rows)
					{
						if (((CheckBox)row2.FindControl("CheckBox1")).Checked && ((TextBox)row2.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)row2.FindControl("txtqty")).Text) && Convert.ToDouble(((TextBox)row2.FindControl("txtqty")).Text) != 0.0)
						{
							double num10 = Convert.ToDouble(decimal.Parse(((TextBox)row2.FindControl("txtqty")).Text).ToString("N3"));
							int num11 = Convert.ToInt32(((Label)row2.FindControl("lblprDId")).Text);
							SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblInv_Supplier_Challan_Details", "MId,PRDId,ChallanQty", num9 + "," + num11 + ",'" + num10 + "'"), con);
							con.Open();
							sqlCommand2.ExecuteNonQuery();
							con.Close();
							num3++;
						}
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
				fillGrid(supid);
				txtRemarks.Text = "";
				txtVehicleNo.Text = "";
				txtTranspoter.Text = "";
				string empty2 = string.Empty;
				empty2 = "Data inserted successfully.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Inventory/Transactions/SupplierChallan_New.aspx?ModId=9&SubModId=118");
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		if (TabContainer1.ActiveTabIndex == 1)
		{
			myframe.Attributes.Add("Src", "SupplierChallan_Clear_Details.aspx?supid=" + supid + "&ModId=9&SubModId=118");
		}
	}
}
