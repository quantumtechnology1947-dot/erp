using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialPlanning_Transactions_Planning_Delete_Plan : Page, IRequiresSessionState
{
	protected Label lblWono;

	protected TextBox Txtsearch;

	protected Button Button1;

	protected Button btnCancel;

	protected GridView GridView1;

	protected GridView GridView2;

	protected Panel Up;

	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string No = "";

	private string Wono = "";

	private string str = "";

	private SqlConnection con;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			Wono = base.Request.QueryString["WONo"].ToString();
			lblWono.Text = Wono;
			str = fun.Connection();
			con = new SqlConnection(str);
			if (!base.IsPostBack)
			{
				fillgrid(No);
				Up.Visible = true;
			}
		}
		catch (Exception)
		{
		}
	}

	public void fillgrid(string no)
	{
		try
		{
			con.Open();
			string text = "";
			if (Txtsearch.Text != "")
			{
				text = " AND PLNo='" + Txtsearch.Text + "'";
			}
			string cmdText = fun.select("Id,SysDate,SessionId,WONo,PLNo,FinYearId", "tblMP_Material_Master", "CompId='" + CompId + "' and FinYearId<='" + FinYearId + "'" + text + " And WONo='" + Wono + "' Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("FinYear", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PlanDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("GenBy", typeof(string)));
			dataTable.Columns.Add(new DataColumn("PLNo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("WONo", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ProjectTitle", typeof(string)));
			dataTable.Columns.Add(new DataColumn("FinYearId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Title+'. '+EmployeeName AS GenBy", "tblHR_OfficeStaff", "EmpId='" + dataSet.Tables[0].Rows[i]["SessionId"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[3] = dataSet2.Tables[0].Rows[0]["GenBy"].ToString();
				}
				dataRow[2] = fun.FromDateDMY(dataSet.Tables[0].Rows[i]["SysDate"].ToString());
				dataRow[6] = fun.getProjectTitle(dataSet.Tables[0].Rows[i]["WONo"].ToString());
				string cmdText3 = fun.select("FinYear", "tblFinancial_master", string.Concat("FinYearId='", dataSet.Tables[0].Rows[i]["FinYearId"], "'"));
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				ViewState["Id"] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				dataRow[1] = dataSet3.Tables[0].Rows[0]["FinYear"].ToString();
				dataRow[4] = dataSet.Tables[0].Rows[i]["PLNo"].ToString();
				ViewState["Plan"] = dataSet.Tables[0].Rows[i]["PLNo"].ToString();
				dataRow[5] = dataSet.Tables[0].Rows[i]["WONo"].ToString();
				dataRow[7] = dataSet.Tables[0].Rows[i]["FinYearId"].ToString();
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView1.DataSource = dataTable;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	public void fillgrid2()
	{
		try
		{
			string text = "";
			int num = 0;
			if (!string.IsNullOrEmpty(ViewState["Id"].ToString()))
			{
				num = Convert.ToInt32(ViewState["Id"]);
			}
			if (!string.IsNullOrEmpty(ViewState["Plan"].ToString()))
			{
				text = ViewState["Plan"].ToString();
			}
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Symbol", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("BOMQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("TypeOfPlan", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MId", typeof(int)));
			dataTable.Columns.Add(new DataColumn("ItemCode1", typeof(string)));
			string cmdText = "SELECT tblMP_Material_Master.SysDate,tblMP_Material_Master.Id As MId,tblMP_Material_Detail.ItemId,tblMP_Material_Detail.Id,tblMP_Material_Detail.RM,tblMP_Material_Detail.PRO,tblMP_Material_Detail.FIN FROM tblMP_Material_Master,tblMP_Material_Detail where tblMP_Material_Master.Id=tblMP_Material_Detail.Mid And  tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_Master.CompId=" + CompId + " And  tblMP_Material_Master.Id='" + num + "'  and tblMP_Material_Master.PLNo='" + text + "'";
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("ItemCode,UOMBasic,ManfDesc", "tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i]["ItemId"].ToString() + "' ");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count <= 0)
				{
					continue;
				}
				string cmdText3 = fun.select("Id,Symbol ", "Unit_Master", "Id='" + dataSet2.Tables[0].Rows[0]["UOMBasic"].ToString() + "' ");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet3.Tables[0].Rows[0]["Symbol"].ToString();
				}
				dataRow[0] = dataSet2.Tables[0].Rows[0]["ItemCode"].ToString();
				dataRow[2] = dataSet2.Tables[0].Rows[0]["ManfDesc"].ToString();
				dataRow[3] = Convert.ToDouble(decimal.Parse(fun.AllComponentBOMQty(CompId, Wono, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), FinYearId).ToString()).ToString("N3"));
				dataRow[4] = dataSet.Tables[0].Rows[i]["Id"].ToString();
				string value = "";
				string cmdText4 = "";
				if (dataSet.Tables[0].Rows[i]["FIN"].ToString() == "1")
				{
					value = "Finish";
					cmdText4 = "SELECT  tblMP_Material_Finish.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Finish ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.PLNo='" + text + "' AND tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_Finish.DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
				}
				if (dataSet.Tables[0].Rows[i]["RM"].ToString() == "1")
				{
					value = "RM";
					cmdText4 = "SELECT  tblMP_Material_RawMaterial.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_RawMaterial ON tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.PLNo='" + text + "' AND tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_RawMaterial.DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
				}
				if (dataSet.Tables[0].Rows[i]["PRO"].ToString() == "1")
				{
					value = "Process";
					cmdText4 = "SELECT  tblMP_Material_Process.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.PLNo='" + text + "' AND tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_Process.DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "' ";
				}
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				for (int j = 0; j < dataSet4.Tables[0].Rows.Count; j++)
				{
					string cmdText5 = fun.select("ItemCode", "tblDG_Item_Master", "Id='" + dataSet4.Tables[0].Rows[j]["ItemId"].ToString() + "' ");
					SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0)
					{
						dataRow[7] = dataSet5.Tables[0].Rows[0]["ItemCode"].ToString();
					}
				}
				dataRow[5] = value;
				dataRow[6] = Convert.ToInt32(dataSet.Tables[0].Rows[i]["MId"].ToString());
				dataTable.Rows.Add(dataRow);
				dataTable.AcceptChanges();
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		try
		{
			fillgrid(Txtsearch.Text);
		}
		catch (Exception)
		{
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string text = ((LinkButton)gridViewRow.FindControl("btnSel")).Text;
				ViewState["Plan"] = text;
				ViewState["Id"] = num;
				fillgrid2();
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	protected void GridView1_PageIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView1.PageIndex = e.NewPageIndex;
		fillgrid(No);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/MaterialPlanning/Transactions/Planning_Delete.aspx?ModId=4&SubModId=33");
	}

	protected void GridView2_PageIndexChanged(object sender, EventArgs e)
	{
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		fillgrid2();
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			if (!(e.CommandName == "Del"))
			{
				return;
			}
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
			int num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblMId")).Text);
			switch (((Label)gridViewRow.FindControl("lblplantype")).Text)
			{
			case "Finish":
			{
				string cmdText7 = "SELECT  tblMP_Material_Finish.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Finish ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.Id='" + num2 + "' AND tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_Finish.DMid='" + num + "' ";
				SqlCommand selectCommand3 = new SqlCommand(cmdText7, sqlConnection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				for (int k = 0; k < dataSet3.Tables[0].Rows.Count; k++)
				{
					string cmdText8 = fun.select("tblMM_PR_Details.ItemId", "tblMM_PR_Master,tblMP_Material_Master,tblMM_PR_Details", "tblMM_PR_Master.PLNId = tblMP_Material_Master.Id And tblMM_PR_Master.PLNId='" + num2 + "'And tblMM_PR_Master.Id=tblMM_PR_Details.MId  And tblMM_PR_Master.CompId='" + CompId + "' And tblMP_Material_Master.WONo='" + Wono + "' And tblMM_PR_Details.ItemId='" + dataSet3.Tables[0].Rows[k][0].ToString() + "' ");
					SqlCommand selectCommand4 = new SqlCommand(cmdText8, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count == 0)
					{
						string cmdText9 = fun.delete("tblMP_Material_Finish", "DMid='" + num + "'");
						SqlCommand sqlCommand5 = new SqlCommand(cmdText9, sqlConnection);
						sqlCommand5.ExecuteNonQuery();
					}
				}
				break;
			}
			case "RM":
			{
				string cmdText4 = "SELECT  tblMP_Material_RawMaterial.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_RawMaterial ON tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.Id='" + num2 + "' AND tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_RawMaterial.DMid='" + num + "' ";
				SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					string cmdText5 = fun.delete("tblDG_Item_Master", "Id='" + dataSet2.Tables[0].Rows[j][0].ToString() + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
				}
				string cmdText6 = fun.delete("tblMP_Material_RawMaterial", "DMid='" + num + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText6, sqlConnection);
				sqlCommand4.ExecuteNonQuery();
				break;
			}
			case "Process":
			{
				string cmdText = "SELECT  tblMP_Material_Process.ItemId FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid AND tblMP_Material_Master.CompId=" + CompId + " AND tblMP_Material_Master.Id='" + num2 + "' AND tblMP_Material_Master.WONo='" + Wono + "' And tblMP_Material_Process.DMid='" + num + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText2 = fun.delete("tblDG_Item_Master", "Id='" + dataSet.Tables[0].Rows[i][0].ToString() + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand.ExecuteNonQuery();
				}
				string cmdText3 = fun.delete("tblMP_Material_Process", "DMid='" + num + "'");
				SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
				sqlCommand2.ExecuteNonQuery();
				break;
			}
			}
			string cmdText10 = fun.select("*", "tblMP_Material_Process", "DMid='" + num + "' ");
			SqlCommand selectCommand5 = new SqlCommand(cmdText10, sqlConnection);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			string cmdText11 = fun.select("*", "tblMP_Material_RawMaterial", "DMid='" + num + "' ");
			SqlCommand selectCommand6 = new SqlCommand(cmdText11, sqlConnection);
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
			DataSet dataSet6 = new DataSet();
			sqlDataAdapter6.Fill(dataSet6);
			string cmdText12 = fun.select("*", "tblMP_Material_RawMaterial", "DMid='" + num + "' ");
			SqlCommand selectCommand7 = new SqlCommand(cmdText12, sqlConnection);
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
			DataSet dataSet7 = new DataSet();
			sqlDataAdapter7.Fill(dataSet7);
			if (dataSet5.Tables[0].Rows.Count == 0 && dataSet6.Tables[0].Rows.Count == 0 && dataSet7.Tables[0].Rows.Count == 0)
			{
				string cmdText13 = fun.delete("tblMP_Material_Detail", "Id='" + num + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText13, sqlConnection);
				sqlCommand6.ExecuteNonQuery();
			}
			string cmdText14 = fun.select("*", "tblMP_Material_Detail", "Mid='" + num2 + "' ");
			SqlCommand selectCommand8 = new SqlCommand(cmdText14, sqlConnection);
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
			DataSet dataSet8 = new DataSet();
			sqlDataAdapter8.Fill(dataSet8);
			if (dataSet8.Tables[0].Rows.Count == 0)
			{
				string cmdText15 = fun.delete("tblMP_Material_Master", "Id='" + num2 + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText15, sqlConnection);
				sqlCommand7.ExecuteNonQuery();
			}
			string cmdText16 = fun.select1("*", "tblMP_Material_Master");
			SqlCommand selectCommand9 = new SqlCommand(cmdText16, sqlConnection);
			SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
			DataSet dataSet9 = new DataSet();
			sqlDataAdapter9.Fill(dataSet9);
			if (dataSet9.Tables[0].Rows.Count == 0)
			{
				base.Response.Redirect("~/Module/MaterialPlanning/Transactions/Planning_Delete.aspx?ModId=4&SubModId=33");
			}
			fillgrid2();
			fillgrid(No);
		}
		catch (SqlException)
		{
			string empty = string.Empty;
			empty = "item is being used,you can not delete it.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}
}
