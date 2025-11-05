using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialManagement_Transactions_RateLockUnLock : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private int CompId;

	private int FinYearId;

	private string sId = "";

	private string connStr = "";

	private SqlConnection con;

	private string CDate = "";

	private string CTime = "";

	protected DropDownList DrpType;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected TextBox txtSearchItemCode;

	protected Button btnSearch0;

	protected GridView GridView2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = fun.getCurrDate();
			CTime = fun.getCurrTime();
			if (!base.IsPostBack && DrpType.SelectedValue == "Select")
			{
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			string selectedValue = DrpCategory1.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				if (((RadioButtonList)gridViewRow.FindControl("RadioButtonList1")).SelectedValue != "")
				{
					int num2 = Convert.ToInt32(((RadioButtonList)gridViewRow.FindControl("RadioButtonList1")).SelectedValue);
					con.Open();
					string cmdText = fun.insert("tblMM_RateLockUnLock_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,ItemId,Type,LockUnlock", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + num + "','" + num2 + "','1'");
					SqlCommand sqlCommand = new SqlCommand(cmdText, con);
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string selectedValue = DrpCategory1.SelectedValue;
					string selectedValue2 = DrpSearchCode.SelectedValue;
					string text = txtSearchItemCode.Text;
					string selectedValue3 = DrpType.SelectedValue;
					Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
				}
				else
				{
					string empty = string.Empty;
					empty = "Invalid data input.!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
			}
			if (e.CommandName == "Sel1")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num3 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblLockUnlock")).Text);
				con.Open();
				string cmdText2 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',LockedbyTranaction='" + sId + "',LockDate='" + CDate + "',LockTime='" + CTime + "'", "Id='" + num3 + "' AND CompId='" + CompId + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, con);
				sqlCommand2.ExecuteNonQuery();
				string selectedValue4 = DrpCategory1.SelectedValue;
				string selectedValue5 = DrpSearchCode.SelectedValue;
				string text2 = txtSearchItemCode.Text;
				string selectedValue6 = DrpType.SelectedValue;
				Fillgrid(selectedValue4, selectedValue5, text2, selectedValue6);
				con.Close();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpType_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			switch (DrpType.SelectedValue)
			{
			case "Category":
			{
				DrpSearchCode.Visible = true;
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				DrpCategory1.Visible = true;
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("CId,Symbol+'-'+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
				DrpCategory1.DataSource = dataSet.Tables["tblDG_Category_Master"];
				DrpCategory1.DataTextField = "Category";
				DrpCategory1.DataValueField = "CId";
				DrpCategory1.DataBind();
				DrpCategory1.Items.Insert(0, "Select");
				DrpCategory1.ClearSelection();
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				break;
			}
			case "WOItems":
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				DrpSearchCode.Visible = true;
				DrpCategory1.Visible = false;
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				break;
			case "Select":
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public void Fillgrid(string sd, string B, string s, string drptype)
	{
		try
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			if (DrpType.SelectedValue != "Select")
			{
				if (DrpType.SelectedValue == "Category")
				{
					if (sd != "Select")
					{
						value = " AND tblDG_Item_Master.CId='" + sd + "'";
						if (B != "Select")
						{
							if (B == "tblDG_Item_Master.ItemCode")
							{
								txtSearchItemCode.Visible = true;
								value2 = " And tblDG_Item_Master.ItemCode Like '" + s + "%'";
							}
							if (B == "tblDG_Item_Master.ManfDesc")
							{
								txtSearchItemCode.Visible = true;
								value2 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
							}
						}
						value3 = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
					}
				}
				else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems" && B != "Select")
				{
					if (B == "tblDG_Item_Master.ItemCode")
					{
						txtSearchItemCode.Visible = true;
						value2 = " And tblDG_Item_Master.ItemCode Like '%" + s + "%'";
					}
					if (B == "tblDG_Item_Master.ManfDesc")
					{
						txtSearchItemCode.Visible = true;
						value2 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
					}
				}
				new SqlCommand();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetRateLockUnlockItem", con);
				sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@startIndex"].Value = sd;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@pageSize"].Value = value;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@startIndex1", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@startIndex1"].Value = value2;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@pageSize1", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@pageSize1"].Value = value3;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpType", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@drpType"].Value = drptype;
				sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@drpCode", SqlDbType.VarChar));
				sqlDataAdapter.SelectCommand.Parameters["@drpCode"].Value = B;
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				GridView2.DataSource = dataSet;
				GridView2.DataBind();
				RunOnGrid();
			}
			else
			{
				string empty = string.Empty;
				empty = "Please Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory1.SelectedValue != "Select")
			{
				string selectedValue = DrpCategory1.SelectedValue;
				string selectedValue2 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				string selectedValue3 = DrpType.SelectedValue;
				Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
				DrpSearchCode.Visible = true;
				txtSearchItemCode.Text = "";
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpSearchCode_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			txtSearchItemCode.Visible = true;
			string selectedValue = DrpCategory1.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory1.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string selectedValue = DrpCategory1.SelectedValue;
			string selectedValue2 = DrpSearchCode.SelectedValue;
			string text = txtSearchItemCode.Text;
			string selectedValue3 = DrpType.SelectedValue;
			Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
		}
		catch (Exception)
		{
		}
	}

	public void RunOnGrid()
	{
		try
		{
			foreach (GridViewRow row in GridView2.Rows)
			{
				if (!(((Label)row.FindControl("lblLockUnlock")).Text != ""))
				{
					continue;
				}
				int num = Convert.ToInt32(((Label)row.FindControl("lblLockUnlock")).Text);
				string cmdText = fun.select("*", "tblMM_RateLockUnLock_Master", "CompId='" + CompId + "' And Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				if (Convert.ToInt32(dataSet.Tables[0].Rows[0]["LockUnlock"]) == 1)
				{
					((LinkButton)row.FindControl("LinkButton1")).Visible = true;
					((LinkButton)row.FindControl("btnsel")).Visible = false;
					switch (Convert.ToInt32(dataSet.Tables[0].Rows[0]["Type"]))
					{
					case 0:
						((RadioButtonList)row.FindControl("RadioButtonList1")).Items[0].Selected = true;
						break;
					case 1:
						((RadioButtonList)row.FindControl("RadioButtonList1")).Items[1].Selected = true;
						break;
					case 2:
						((RadioButtonList)row.FindControl("RadioButtonList1")).Items[2].Selected = true;
						break;
					}
					((RadioButtonList)row.FindControl("RadioButtonList1")).Enabled = false;
				}
				else
				{
					((RadioButtonList)row.FindControl("RadioButtonList1")).Enabled = true;
					((LinkButton)row.FindControl("LinkButton1")).Visible = false;
					((LinkButton)row.FindControl("btnsel")).Visible = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
