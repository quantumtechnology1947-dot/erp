using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_MaterialPlanning_Transactions_pdt : Page, IRequiresSessionState
{
	protected Label lblWono;

	protected GridView SearchGridView1;

	protected Label lblItemCode;

	protected Label lblItemCode0;

	protected Label lblBomQty;

	protected Label lblBomQty0;

	protected Label lblRawMaterial;

	protected GridView GridView3;

	protected Panel Panel2;

	protected Label lblProcess;

	protected GridView GridView4;

	protected Panel Panel3;

	protected Label lblFinish;

	protected GridView GridView5;

	protected Panel Panel4;

	protected Button RadButton1;

	protected Button RadButton2;

	protected Button BtnAddTemp;

	private string wono = "";

	private int CompId;

	private string SId = "";

	private int fyid;

	private string WomfDate = "";

	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private string SupplierName = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			SId = Session["username"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			wono = base.Request.QueryString["WONo"].ToString();
			fyid = Convert.ToInt32(Session["finyear"]);
			lblWono.Text = wono;
			WomfDate = fun.WOmfgdate(wono, CompId, fyid);
			string cmdText = fun.select("SupplierName+' ['+SupplierId+' ]' As SupplierName", "tblMM_Supplier_master", "SupplierId='S047'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				SupplierName = dataSet.Tables[0].Rows[0]["SupplierName"].ToString();
			}
			if (!Page.IsPostBack)
			{
				string cmdText2 = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + SId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					string cmdText3 = "delete from tblMP_Material_Process_Temp where DMid='" + dataSet2.Tables[0].Rows[i]["Id"].ToString() + "' ";
					SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText4 = "delete from tblMP_Material_RawMaterial_Temp where DMid='" + dataSet2.Tables[0].Rows[i]["Id"].ToString() + "' ";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText4, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					string cmdText5 = "delete from tblMP_Material_Finish_Temp where DMid='" + dataSet2.Tables[0].Rows[i]["Id"].ToString() + "' ";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
				}
				string cmdText6 = "delete from tblMP_Material_Detail_Temp where SessionId='" + SId + "' ";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText6, con);
				con.Open();
				sqlCommand4.ExecuteNonQuery();
				con.Close();
				MP_GRID(wono, CompId, SearchGridView1, fyid, " And tblDG_Item_Master.CId is null");
				GridColour();
			}
			foreach (GridViewRow row in GridView3.Rows)
			{
				((TextBox)row.FindControl("txtRMDeliDate")).Attributes.Add("readonly", "readonly");
			}
			foreach (GridViewRow row2 in GridView4.Rows)
			{
				((TextBox)row2.FindControl("txtProDeliDate")).Attributes.Add("readonly", "readonly");
			}
			foreach (GridViewRow row3 in GridView5.Rows)
			{
				((TextBox)row3.FindControl("txtFinDeliDate")).Attributes.Add("readonly", "readonly");
			}
		}
		catch (Exception)
		{
		}
	}

	public void MP_GRID(string wono, int CompId, GridView GridView2, int finid, string param)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("ItemCode", typeof(string));
			dataTable.Columns.Add("ManfDesc", typeof(string));
			dataTable.Columns.Add("UOMBasic", typeof(string));
			dataTable.Columns.Add("UnitQty", typeof(string));
			dataTable.Columns.Add("BOMQty", typeof(string));
			dataTable.Columns.Add(new DataColumn("FileName", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AttName", typeof(string)));
			dataTable.Columns.Add("ItemId", typeof(int));
			dataTable.Columns.Add("PRQty", typeof(string));
			dataTable.Columns.Add("WISQty", typeof(string));
			dataTable.Columns.Add("GQNQty", typeof(string));
			string cmdText = fun.select("Distinct ItemId", "tblDG_BOM_Master", "WONo='" + wono + "'and  CompId='" + CompId + "'And FinYearId<='" + finid + "' And ECNFlag=0 AND CId not in (Select PId from tblDG_BOM_Master where WONo='" + wono + "'and  CompId='" + CompId + "'And FinYearId<='" + finid + "')  ");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.PartNo,tblDG_Item_Master.CId,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName", " tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic And  tblDG_Item_Master.Id='" + sqlDataReader["ItemId"].ToString() + "'" + param);
				DataSet dataSet = new DataSet();
				SqlCommand selectCommand = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					string cmdText3 = fun.select("tblDG_Item_Master.Process,tblDG_Item_Master.ItemCode", " tblDG_Item_Master", " tblDG_Item_Master.PartNo='" + dataSet.Tables[0].Rows[0]["PartNo"].ToString() + "' And CompId='" + CompId + "' " + param + " And tblDG_Item_Master.Process is not  null");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
					string text = "";
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					while (sqlDataReader2.Read())
					{
						text = text + "/" + sqlDataReader2["Process"].ToString();
					}
					if (dataSet.Tables[0].Rows[0]["CId"] == DBNull.Value)
					{
						dataRow[0] = dataSet.Tables[0].Rows[0]["PartNo"].ToString() + text;
					}
					else
					{
						dataRow[0] = dataSet.Tables[0].Rows[0]["ItemCode"].ToString();
					}
					dataRow[1] = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					dataRow[2] = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					double num = 0.0;
					dataRow[3] = num;
					double num2 = 0.0;
					num2 = fun.AllComponentBOMQty(CompId, wono, sqlDataReader["ItemId"].ToString(), finid);
					dataRow[4] = num2;
					dataRow[7] = sqlDataReader["ItemId"].ToString();
					double num3 = 0.0;
					num3 = fun.CalPRQty(CompId, wono, Convert.ToInt32(sqlDataReader["ItemId"]));
					dataRow[8] = num3.ToString();
					double num4 = 0.0;
					num4 = fun.CalWISQty(CompId.ToString(), wono, sqlDataReader["ItemId"].ToString());
					dataRow[9] = num4.ToString();
					double num5 = 0.0;
					num5 = fun.GQNQTY(CompId, wono, sqlDataReader["ItemId"].ToString());
					dataRow[10] = num5.ToString();
					if (dataSet.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[0]["FileName"] != DBNull.Value)
					{
						dataRow[5] = "View";
					}
					else
					{
						dataRow[5] = "";
					}
					if (dataSet.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet.Tables[0].Rows[0]["AttName"] != DBNull.Value)
					{
						dataRow[6] = "View";
					}
					else
					{
						dataRow[6] = "";
					}
					double num6 = 0.0;
					string cmdText4 = string.Concat("SELECT SUM(tblMP_Material_RawMaterial_Temp.Qty) AS RawQty FROM tblMP_Material_Detail_Temp INNER JOIN               tblMP_Material_RawMaterial_Temp ON tblMP_Material_Detail_Temp.Id = tblMP_Material_RawMaterial_Temp.DMid And  tblMP_Material_Detail_Temp.ItemId='", sqlDataReader["ItemId"], "'  And SessionId!='", SId, "' ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num6 = Convert.ToDouble(dataSet2.Tables[0].Rows[0][0]);
					}
					double num7 = 0.0;
					string cmdText5 = string.Concat("SELECT SUM(tblMP_Material_Process_Temp.Qty) AS ProQty FROM tblMP_Material_Detail_Temp INNER JOIN               tblMP_Material_Process_Temp ON tblMP_Material_Detail_Temp.Id = tblMP_Material_Process_Temp.DMid And  tblMP_Material_Detail_Temp.ItemId='", sqlDataReader["ItemId"], "'  And SessionId!='", SId, "' ");
					SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num7 = Convert.ToDouble(dataSet3.Tables[0].Rows[0][0]);
					}
					double num8 = 0.0;
					string cmdText6 = string.Concat("SELECT SUM(tblMP_Material_Finish_Temp.Qty) AS FinQty FROM tblMP_Material_Detail_Temp INNER JOIN               tblMP_Material_Finish_Temp ON tblMP_Material_Detail_Temp.Id = tblMP_Material_Finish_Temp.DMid And  tblMP_Material_Detail_Temp.ItemId='", sqlDataReader["ItemId"], "'  And SessionId!='", SId, "' ");
					SqlCommand selectCommand4 = new SqlCommand(cmdText6, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0 && dataSet4.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num8 = Convert.ToDouble(dataSet4.Tables[0].Rows[0][0]);
					}
					double num9 = 0.0;
					string cmdText7 = string.Concat("SELECT SUM(tblMP_Material_Process.Qty) AS ProQty FROM tblMP_Material_Detail INNER JOIN               tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid And tblMP_Material_Detail.ItemId='", sqlDataReader["ItemId"], "'  And WONo='", wono, "'");
					SqlCommand selectCommand5 = new SqlCommand(cmdText7, sqlConnection);
					SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
					DataSet dataSet5 = new DataSet();
					sqlDataAdapter5.Fill(dataSet5);
					if (dataSet5.Tables[0].Rows.Count > 0 && dataSet5.Tables[0].Rows[0][0] != DBNull.Value)
					{
						num9 = Convert.ToDouble(dataSet5.Tables[0].Rows[0][0]);
					}
					if (num2 - num6 > 0.0 && num2 - num7 > 0.0 && num2 - num8 > 0.0 && num2 - num9 > 0.0 && num2 - num3 - num4 + num5 > 0.0)
					{
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
				}
			}
			GridView2.DataSource = dataTable;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void abc()
	{
		try
		{
			string text = ViewState["ItemId"].ToString();
			double num = Convert.ToDouble(ViewState["BOMQty"]);
			CheckBox checkBox = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
			CheckBox checkBox2 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
			CheckBox checkBox3 = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
			if (checkBox3.Checked)
			{
				GridView3.Enabled = false;
				GridView4.Enabled = false;
			}
			else
			{
				GridView3.Enabled = true;
				GridView4.Enabled = true;
				checkBox.Enabled = true;
				checkBox2.Enabled = true;
			}
			if (!checkBox.Checked && !checkBox2.Checked)
			{
				checkBox3.Enabled = true;
			}
			string cmdText = " SELECT  tblMP_Material_Process.ItemId,tblMP_Material_Process.Qty FROM tblMP_Material_Master INNER JOIN tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid And tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId='" + CompId + "' And tblMP_Material_Detail.ItemId='" + text + "'";
			DataSet dataSet = new DataSet();
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("tblDG_Item_Master.PartNo,tblDG_Item_Master.Process", " tblDG_Item_Master", "tblDG_Item_Master.Id='" + dataSet.Tables[0].Rows[0][0].ToString() + "' And tblDG_Item_Master.CId is null And tblDG_Item_Master.Process is not  null ");
				DataSet dataSet2 = new DataSet();
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					GridView5.Enabled = false;
				}
				else
				{
					GridView5.Enabled = true;
				}
				double num2 = 0.0;
				num2 = fun.RMQty(text, wono, CompId, "tblMP_Material_Process");
				if (num - num2 == 0.0)
				{
					GridView4.Enabled = false;
				}
				else
				{
					GridView4.Enabled = true;
				}
			}
			else
			{
				GridView5.Enabled = true;
			}
			string cmdText3 = " SELECT  tblMP_Material_RawMaterial.ItemId FROM tblMP_Material_Master INNER JOIN tblMP_Material_Detail ON tblMP_Material_Master.Id = tblMP_Material_Detail.Mid INNER JOIN tblMP_Material_RawMaterial ON tblMP_Material_Detail.Id = tblMP_Material_RawMaterial.DMid And tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId='" + CompId + "' And tblMP_Material_Detail.ItemId='" + text + "'";
			DataSet dataSet3 = new DataSet();
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				string cmdText4 = fun.select("tblDG_Item_Master.PartNo,tblDG_Item_Master.Process", " tblDG_Item_Master", "tblDG_Item_Master.Id='" + dataSet3.Tables[0].Rows[0][0].ToString() + "' And tblDG_Item_Master.CId is null And tblDG_Item_Master.Process is not  null ");
				DataSet dataSet4 = new DataSet();
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					GridView5.Enabled = false;
				}
				else
				{
					GridView5.Enabled = true;
				}
				double num3 = 0.0;
				num3 = fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial");
				if (num - num3 == 0.0)
				{
					GridView3.Enabled = false;
				}
				else
				{
					GridView3.Enabled = true;
				}
			}
			else
			{
				GridView5.Enabled = true;
			}
			string cmdText5 = "SELECT tblMP_Material_Finish.ItemId ,tblMP_Material_Master.PLNo FROM tblMP_Material_Detail INNER JOIN tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Finish ON tblMP_Material_Detail.Id = tblMP_Material_Finish.DMid And tblMP_Material_Master.WONo='" + wono + "' And tblMP_Material_Master.CompId=" + CompId + " And tblMP_Material_Finish.ItemId='" + text + "'";
			DataSet dataSet5 = new DataSet();
			SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			sqlDataAdapter5.Fill(dataSet5);
			if (dataSet5.Tables[0].Rows.Count > 0)
			{
				double num4 = 0.0;
				num4 = fun.RMQty(text, wono, CompId, "tblMP_Material_Finish");
				if (num - num4 == 0.0)
				{
					GridView3.Enabled = false;
					GridView4.Enabled = false;
					GridView5.Enabled = false;
				}
				else
				{
					GridView5.Enabled = true;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void FillRM()
	{
		DataTable dataTable = new DataTable();
		DataRow dataRow = null;
		dataTable.Columns.Add(new DataColumn("Column1", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Column2", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Column3", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Column4", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Id", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Did", typeof(string)));
		dataTable.Columns.Add(new DataColumn("Column5", typeof(string)));
		string text = ViewState["ItemId"].ToString();
		double num = Convert.ToDouble(ViewState["BOMQty"]);
		double num2 = 0.0;
		string cmdText = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And RM='1' And SessionId='" + SId + "'");
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0)
		{
			string cmdText2 = fun.select("DMid", "tblMP_Material_RawMaterial_Temp", "DMid='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				string cmdText3 = fun.select("*", "tblMP_Material_RawMaterial_Temp", "DMid='" + dataSet2.Tables[0].Rows[0]["DMid"].ToString() + "' Order By Id Desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				DataTable dataTable2 = new DataTable();
				DataRow dataRow2 = null;
				dataTable2.Columns.Add(new DataColumn("Column1", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Column2", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Column3", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Column4", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Id", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Did", typeof(string)));
				dataTable2.Columns.Add(new DataColumn("Column5", typeof(string)));
				double num3 = 0.0;
				for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
				{
					dataRow2 = dataTable2.NewRow();
					string cmdText4 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + dataSet3.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet4 = new DataSet();
					sqlDataAdapter4.Fill(dataSet4);
					if (dataSet4.Tables[0].Rows.Count > 0)
					{
						dataRow2["Column1"] = dataSet4.Tables[0].Rows[0]["SupplierName"].ToString();
					}
					dataRow2["Column2"] = dataSet3.Tables[0].Rows[i]["Qty"].ToString();
					dataRow2["Column3"] = dataSet3.Tables[0].Rows[i]["Rate"].ToString();
					dataRow2["Column4"] = fun.FromDateDMY(dataSet3.Tables[0].Rows[i]["DelDate"].ToString());
					dataRow2["Id"] = dataSet3.Tables[0].Rows[i]["Id"].ToString();
					dataRow2["Did"] = dataSet3.Tables[0].Rows[i]["DMid"].ToString();
					num2 += Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
					dataRow2["Column5"] = dataSet3.Tables[0].Rows[i]["Discount"].ToString();
					dataTable2.Rows.Add(dataRow2);
					dataTable2.AcceptChanges();
				}
				DataSet dataSet5 = new DataSet();
				dataSet5.Tables.Add(dataTable2);
				dataRow = dataTable.NewRow();
				dataRow["Column1"] = string.Empty;
				dataRow["Column2"] = string.Empty;
				dataRow["Column3"] = string.Empty;
				dataRow["Column4"] = string.Empty;
				dataRow["Id"] = string.Empty;
				dataRow["Did"] = string.Empty;
				dataRow["Column5"] = string.Empty;
				dataTable.Rows.Add(dataRow);
				DataSet dataSet6 = new DataSet();
				dataSet6.Tables.Add(dataTable);
				dataSet5.Merge(dataSet6);
				GridView3.DataSource = dataSet5;
				GridView3.DataBind();
				GridViewRow gridViewRow = GridView3.Rows[GridView3.Rows.Count - 1];
				if (Math.Round(num - (num2 + fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial")), 5) == 0.0)
				{
					GridView3.Rows[GridView3.Rows.Count - 1].Visible = false;
				}
				((ImageButton)gridViewRow.FindControl("ImageButton1")).Visible = false;
				dataSet5.Clear();
				CheckBox checkBox = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
				checkBox.Checked = true;
				if (!checkBox.Checked)
				{
					return;
				}
				foreach (GridViewRow row in GridView3.Rows)
				{
					if (((TextBox)row.FindControl("txtRMQty")).Text != "")
					{
						num3 += Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtRMQty")).Text).ToString("N3"));
					}
					((TextBox)row.FindControl("txtRMQty")).Enabled = false;
					((TextBox)gridViewRow.FindControl("txtRMQty")).Enabled = true;
					((TextBox)row.FindControl("txtRMRate")).Enabled = false;
					((TextBox)gridViewRow.FindControl("txtRMRate")).Enabled = true;
					((TextBox)row.FindControl("TxtDiscount")).Enabled = false;
					((TextBox)gridViewRow.FindControl("TxtDiscount")).Enabled = true;
					((TextBox)row.FindControl("txtSupplierRM")).Enabled = false;
					((TextBox)gridViewRow.FindControl("txtSupplierRM")).Enabled = true;
					((TextBox)row.FindControl("txtRMDeliDate")).Enabled = false;
					((TextBox)gridViewRow.FindControl("txtRMDeliDate")).Enabled = true;
				}
				double num4 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial") + num3).ToString()).ToString("N3"));
				((TextBox)gridViewRow.FindControl("txtRMQty")).Text = decimal.Parse((num - num4).ToString()).ToString("N3");
				((TextBox)gridViewRow.FindControl("txtRMDeliDate")).Text = WomfDate;
				((TextBox)gridViewRow.FindControl("txtRMRate")).Text = "0";
				((TextBox)gridViewRow.FindControl("TxtDiscount")).Text = "0";
				return;
			}
			dataRow = dataTable.NewRow();
			dataRow["Column1"] = string.Empty;
			dataRow["Column2"] = string.Empty;
			dataRow["Column3"] = string.Empty;
			dataRow["Column4"] = string.Empty;
			dataRow["Id"] = string.Empty;
			dataRow["Did"] = string.Empty;
			dataRow["Column5"] = string.Empty;
			dataTable.Rows.Add(dataRow);
			DataSet dataSet7 = new DataSet();
			dataSet7.Tables.Add(dataTable);
			GridView3.DataSource = dataSet7;
			GridView3.DataBind();
			GridViewRow gridViewRow3 = GridView3.Rows[GridView3.Rows.Count - 1];
			((ImageButton)gridViewRow3.FindControl("ImageButton1")).Visible = false;
			CheckBox checkBox2 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
			if (!checkBox2.Checked)
			{
				return;
			}
			double num5 = 0.0;
			foreach (GridViewRow row2 in GridView3.Rows)
			{
				_ = row2;
				if (((TextBox)gridViewRow3.FindControl("txtRMQty")).Text != "")
				{
					num5 += Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow3.FindControl("txtRMQty")).Text).ToString("N3"));
				}
			}
			double num6 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial") + num5).ToString()).ToString("N3"));
			((TextBox)gridViewRow3.FindControl("txtRMQty")).Text = decimal.Parse((num - num6).ToString()).ToString("N3");
			((TextBox)gridViewRow3.FindControl("txtRMDeliDate")).Text = WomfDate;
			((TextBox)gridViewRow3.FindControl("txtRMRate")).Text = "0";
			((TextBox)gridViewRow3.FindControl("TxtDiscount")).Text = "0";
			return;
		}
		dataRow = dataTable.NewRow();
		dataRow["Column1"] = string.Empty;
		dataRow["Column2"] = string.Empty;
		dataRow["Column3"] = string.Empty;
		dataRow["Column4"] = string.Empty;
		dataRow["Id"] = string.Empty;
		dataRow["Did"] = string.Empty;
		dataRow["Column5"] = string.Empty;
		dataTable.Rows.Add(dataRow);
		DataSet dataSet8 = new DataSet();
		dataSet8.Tables.Add(dataTable);
		GridView3.DataSource = dataSet8;
		GridView3.DataBind();
		GridViewRow gridViewRow4 = GridView3.Rows[GridView3.Rows.Count - 1];
		((ImageButton)gridViewRow4.FindControl("ImageButton1")).Visible = false;
		CheckBox checkBox3 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
		if (!checkBox3.Checked)
		{
			return;
		}
		double num7 = 0.0;
		foreach (GridViewRow row3 in GridView3.Rows)
		{
			_ = row3;
			if (((TextBox)gridViewRow4.FindControl("txtRMQty")).Text != "")
			{
				num7 += Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow4.FindControl("txtRMQty")).Text).ToString("N3"));
			}
		}
		double num8 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial") + num7).ToString()).ToString("N3"));
		((TextBox)gridViewRow4.FindControl("txtRMQty")).Text = decimal.Parse((num - num8).ToString()).ToString("N3");
		((TextBox)gridViewRow4.FindControl("txtRMDeliDate")).Text = WomfDate;
		((TextBox)gridViewRow4.FindControl("txtRMRate")).Text = "0";
		((TextBox)gridViewRow4.FindControl("TxtDiscount")).Text = "0";
	}

	public void FillPRO()
	{
		try
		{
			DataTable dataTable = new DataTable();
			DataRow dataRow = null;
			dataTable.Columns.Add(new DataColumn("Column11", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column21", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column31", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column41", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Did1", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column51", typeof(string)));
			string text = ViewState["ItemId"].ToString();
			double num = Convert.ToDouble(ViewState["BOMQty"]);
			double num2 = 0.0;
			string cmdText = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And PRO='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("DMid", "tblMP_Material_Process_Temp", "DMid='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string cmdText3 = fun.select("*", "tblMP_Material_Process_Temp", "DMid='" + dataSet2.Tables[0].Rows[0]["DMid"].ToString() + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					DataTable dataTable2 = new DataTable();
					DataRow dataRow2 = null;
					dataTable2.Columns.Add(new DataColumn("Column11", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column21", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column31", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column41", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Id1", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Did1", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column51", typeof(string)));
					for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
					{
						dataRow2 = dataTable2.NewRow();
						string cmdText4 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + dataSet3.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow2["Column11"] = dataSet4.Tables[0].Rows[0]["SupplierName"].ToString();
						}
						dataRow2["Column21"] = dataSet3.Tables[0].Rows[i]["Qty"].ToString();
						dataRow2["Column31"] = dataSet3.Tables[0].Rows[i]["Rate"].ToString();
						dataRow2["Column41"] = fun.FromDateDMY(dataSet3.Tables[0].Rows[i]["DelDate"].ToString());
						dataRow2["Id1"] = dataSet3.Tables[0].Rows[i]["Id"].ToString();
						dataRow2["Did1"] = dataSet3.Tables[0].Rows[i]["DMid"].ToString();
						dataRow2["Column51"] = dataSet3.Tables[0].Rows[i]["Discount"].ToString();
						num2 += Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
						dataTable2.Rows.Add(dataRow2);
						dataTable2.AcceptChanges();
					}
					DataSet dataSet5 = new DataSet();
					dataSet5.Tables.Add(dataTable2);
					dataRow = dataTable.NewRow();
					dataRow["Column11"] = string.Empty;
					dataRow["Column21"] = string.Empty;
					dataRow["Column31"] = string.Empty;
					dataRow["Column41"] = string.Empty;
					dataRow["Column51"] = string.Empty;
					dataRow["Id1"] = string.Empty;
					dataRow["Did1"] = string.Empty;
					dataTable.Rows.Add(dataRow);
					DataSet dataSet6 = new DataSet();
					dataSet6.Tables.Add(dataTable);
					dataSet5.Merge(dataSet6);
					GridView4.DataSource = dataSet5;
					GridView4.DataBind();
					GridViewRow gridViewRow = GridView4.Rows[GridView4.Rows.Count - 1];
					if (Math.Round(num - (num2 + fun.RMQty(text, wono, CompId, "tblMP_Material_Process")), 5) == 0.0)
					{
						GridView4.Rows[GridView4.Rows.Count - 1].Visible = false;
					}
					((ImageButton)gridViewRow.FindControl("ImageButton2")).Visible = false;
					dataSet5.Clear();
					CheckBox checkBox = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
					checkBox.Checked = true;
					double num3 = 0.0;
					if (!checkBox.Checked)
					{
						return;
					}
					foreach (GridViewRow row in GridView4.Rows)
					{
						if (((TextBox)row.FindControl("txtProQty")).Text != "")
						{
							num3 += Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtProQty")).Text).ToString("N3"));
						}
						((TextBox)row.FindControl("txtProQty")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtProQty")).Enabled = true;
						((TextBox)row.FindControl("txtProRate")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtProRate")).Enabled = true;
						((TextBox)row.FindControl("TxtProDiscount")).Enabled = false;
						((TextBox)gridViewRow.FindControl("TxtProDiscount")).Enabled = true;
						((TextBox)row.FindControl("txtSupplierPro")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtSupplierPro")).Enabled = true;
						((TextBox)row.FindControl("txtProDeliDate")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtProDeliDate")).Enabled = true;
					}
					double num4 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_Process") + num3).ToString()).ToString("N3"));
					((TextBox)gridViewRow.FindControl("txtProQty")).Text = decimal.Parse((num - num4).ToString()).ToString("N3");
					((TextBox)gridViewRow.FindControl("txtProDeliDate")).Text = WomfDate;
					((TextBox)gridViewRow.FindControl("txtProRate")).Text = "0";
					((TextBox)gridViewRow.FindControl("TxtProDiscount")).Text = "0";
					return;
				}
				dataRow = dataTable.NewRow();
				dataRow["Column11"] = string.Empty;
				dataRow["Column21"] = string.Empty;
				dataRow["Column31"] = string.Empty;
				dataRow["Column41"] = string.Empty;
				dataRow["Id1"] = string.Empty;
				dataRow["Did1"] = string.Empty;
				dataRow["Column51"] = string.Empty;
				dataTable.Rows.Add(dataRow);
				DataSet dataSet7 = new DataSet();
				dataSet7.Tables.Add(dataTable);
				GridView4.DataSource = dataSet7;
				GridView4.DataBind();
				GridViewRow gridViewRow3 = GridView4.Rows[GridView4.Rows.Count - 1];
				((ImageButton)gridViewRow3.FindControl("ImageButton2")).Visible = false;
				CheckBox checkBox2 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
				if (!checkBox2.Checked)
				{
					return;
				}
				double num5 = 0.0;
				foreach (GridViewRow row2 in GridView4.Rows)
				{
					_ = row2;
					if (((TextBox)gridViewRow3.FindControl("txtProQty")).Text != "")
					{
						num5 += Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow3.FindControl("txtProQty")).Text).ToString("N3"));
					}
				}
				double num6 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_Process") + num5).ToString()).ToString("N3"));
				((TextBox)gridViewRow3.FindControl("txtProQty")).Text = decimal.Parse((num - num6).ToString()).ToString("N3");
				((TextBox)gridViewRow3.FindControl("txtProDeliDate")).Text = WomfDate;
				((TextBox)gridViewRow3.FindControl("txtProRate")).Text = "0";
				((TextBox)gridViewRow3.FindControl("TxtProDiscount")).Text = "0";
				return;
			}
			dataRow = dataTable.NewRow();
			dataRow["Column11"] = string.Empty;
			dataRow["Column21"] = string.Empty;
			dataRow["Column31"] = string.Empty;
			dataRow["Column41"] = string.Empty;
			dataRow["Id1"] = string.Empty;
			dataRow["Did1"] = string.Empty;
			dataRow["Column51"] = string.Empty;
			dataTable.Rows.Add(dataRow);
			DataSet dataSet8 = new DataSet();
			dataSet8.Tables.Add(dataTable);
			GridView4.DataSource = dataSet8;
			GridView4.DataBind();
			GridViewRow gridViewRow4 = GridView4.Rows[GridView4.Rows.Count - 1];
			((ImageButton)gridViewRow4.FindControl("ImageButton2")).Visible = false;
			CheckBox checkBox3 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
			if (!checkBox3.Checked)
			{
				return;
			}
			double num7 = 0.0;
			foreach (GridViewRow row3 in GridView4.Rows)
			{
				_ = row3;
				if (((TextBox)gridViewRow4.FindControl("txtProQty")).Text != "")
				{
					num7 += Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow4.FindControl("txtProQty")).Text).ToString("N3"));
				}
			}
			double num8 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_Process") + num7).ToString()).ToString("N3"));
			((TextBox)gridViewRow4.FindControl("txtProQty")).Text = decimal.Parse((num - num8).ToString()).ToString("N3");
			((TextBox)gridViewRow4.FindControl("txtProDeliDate")).Text = WomfDate;
			((TextBox)gridViewRow4.FindControl("txtProRate")).Text = "0";
			((TextBox)gridViewRow4.FindControl("TxtProDiscount")).Text = "0";
		}
		catch (Exception)
		{
		}
	}

	public void FillFIN()
	{
		try
		{
			DataTable dataTable = new DataTable();
			DataRow dataRow = null;
			dataTable.Columns.Add(new DataColumn("Column111", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column211", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column311", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column411", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Id11", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Did11", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Column511", typeof(string)));
			string text = ViewState["ItemId"].ToString();
			double num = Convert.ToDouble(ViewState["BOMQty"]);
			double num2 = 0.0;
			string cmdText = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And FIN='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("DMid", "tblMP_Material_Finish_Temp", "DMid='" + dataSet.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					string cmdText3 = fun.select("*", "tblMP_Material_Finish_Temp", "DMid='" + dataSet2.Tables[0].Rows[0]["DMid"].ToString() + "' Order By Id Desc");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter3.Fill(dataSet3);
					DataTable dataTable2 = new DataTable();
					DataRow dataRow2 = null;
					dataTable2.Columns.Add(new DataColumn("Column111", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column211", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column311", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column411", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Id11", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Did11", typeof(string)));
					dataTable2.Columns.Add(new DataColumn("Column511", typeof(string)));
					for (int i = 0; i < dataSet3.Tables[0].Rows.Count; i++)
					{
						dataRow2 = dataTable2.NewRow();
						string cmdText4 = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + dataSet3.Tables[0].Rows[i]["SupplierId"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							dataRow2["Column111"] = dataSet4.Tables[0].Rows[0]["SupplierName"].ToString();
						}
						dataRow2["Column211"] = dataSet3.Tables[0].Rows[i]["Qty"].ToString();
						dataRow2["Column311"] = dataSet3.Tables[0].Rows[i]["Rate"].ToString();
						dataRow2["Column411"] = fun.FromDateDMY(dataSet3.Tables[0].Rows[i]["DelDate"].ToString());
						dataRow2["Id11"] = dataSet3.Tables[0].Rows[i]["Id"].ToString();
						dataRow2["Did11"] = dataSet3.Tables[0].Rows[i]["DMid"].ToString();
						num2 += Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[i]["Qty"].ToString()).ToString("N3"));
						dataRow2["Column511"] = Convert.ToDouble(dataSet3.Tables[0].Rows[i]["Discount"].ToString());
						dataTable2.Rows.Add(dataRow2);
						dataTable2.AcceptChanges();
					}
					DataSet dataSet5 = new DataSet();
					dataSet5.Tables.Add(dataTable2);
					dataRow = dataTable.NewRow();
					dataRow["Column111"] = string.Empty;
					dataRow["Column211"] = string.Empty;
					dataRow["Column311"] = string.Empty;
					dataRow["Column411"] = string.Empty;
					dataRow["Id11"] = string.Empty;
					dataRow["Did11"] = string.Empty;
					dataRow["Column511"] = string.Empty;
					dataTable.Rows.Add(dataRow);
					DataSet dataSet6 = new DataSet();
					dataSet6.Tables.Add(dataTable);
					dataSet5.Merge(dataSet6);
					GridView5.DataSource = dataSet5;
					GridView5.DataBind();
					GridViewRow gridViewRow = GridView5.Rows[GridView5.Rows.Count - 1];
					if (Math.Round(num - (num2 + fun.RMQty(text, wono, CompId, "tblMP_Material_Finish")), 5) == 0.0)
					{
						GridView5.Rows[GridView5.Rows.Count - 1].Visible = false;
					}
					((ImageButton)gridViewRow.FindControl("ImageButton3")).Visible = false;
					dataSet5.Clear();
					CheckBox checkBox = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
					checkBox.Checked = true;
					double num3 = 0.0;
					CheckBox checkBox2 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
					CheckBox checkBox3 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
					if (checkBox2.Checked || checkBox3.Checked)
					{
						checkBox.Enabled = false;
					}
					if (!checkBox.Checked)
					{
						return;
					}
					foreach (GridViewRow row in GridView5.Rows)
					{
						if (((TextBox)row.FindControl("txtQtyFin")).Text != "")
						{
							num3 += Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtQtyFin")).Text).ToString("N3"));
						}
						((TextBox)row.FindControl("txtQtyFin")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtQtyFin")).Enabled = true;
						((TextBox)row.FindControl("txtFinRate")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtFinRate")).Enabled = true;
						((TextBox)row.FindControl("TxtFinDiscount")).Enabled = false;
						((TextBox)gridViewRow.FindControl("TxtFinDiscount")).Enabled = true;
						((TextBox)row.FindControl("txtSupplierFin")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtSupplierFin")).Enabled = true;
						((TextBox)row.FindControl("txtFinDeliDate")).Enabled = false;
						((TextBox)gridViewRow.FindControl("txtFinDeliDate")).Enabled = true;
					}
					double num4 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_Finish") + num3).ToString()).ToString("N3"));
					((TextBox)gridViewRow.FindControl("txtQtyFin")).Text = decimal.Parse((num - num4).ToString()).ToString("N3");
					((TextBox)gridViewRow.FindControl("txtFinDeliDate")).Text = WomfDate;
					((TextBox)gridViewRow.FindControl("txtFinRate")).Text = "0";
					((TextBox)gridViewRow.FindControl("TxtFinDiscount")).Text = "0";
					return;
				}
				dataRow = dataTable.NewRow();
				dataRow["Column111"] = string.Empty;
				dataRow["Column211"] = string.Empty;
				dataRow["Column311"] = string.Empty;
				dataRow["Column411"] = string.Empty;
				dataRow["Id11"] = string.Empty;
				dataRow["Did11"] = string.Empty;
				dataRow["Column511"] = string.Empty;
				dataTable.Rows.Add(dataRow);
				DataSet dataSet7 = new DataSet();
				dataSet7.Tables.Add(dataTable);
				GridView5.DataSource = dataSet7;
				GridView5.DataBind();
				GridViewRow gridViewRow3 = GridView5.Rows[GridView5.Rows.Count - 1];
				((ImageButton)gridViewRow3.FindControl("ImageButton3")).Visible = false;
				CheckBox checkBox4 = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
				CheckBox checkBox5 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
				CheckBox checkBox6 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
				if (checkBox5.Checked || checkBox6.Checked)
				{
					checkBox4.Enabled = false;
				}
				if (!checkBox4.Checked)
				{
					return;
				}
				double num5 = 0.0;
				foreach (GridViewRow row2 in GridView5.Rows)
				{
					_ = row2;
					if (((TextBox)gridViewRow3.FindControl("txtQtyFin")).Text != "")
					{
						num5 += Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow3.FindControl("txtQtyFin")).Text).ToString("N3"));
					}
				}
				double num6 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_Finish") + num5).ToString()).ToString("N3"));
				((TextBox)gridViewRow3.FindControl("txtQtyFin")).Text = decimal.Parse((num - num6).ToString()).ToString("N3");
				((TextBox)gridViewRow3.FindControl("txtFinDeliDate")).Text = WomfDate;
				((TextBox)gridViewRow3.FindControl("txtFinRate")).Text = "0";
				((TextBox)gridViewRow3.FindControl("TxtFinDiscount")).Text = "0";
				return;
			}
			dataRow = dataTable.NewRow();
			dataRow["Column111"] = string.Empty;
			dataRow["Column211"] = string.Empty;
			dataRow["Column311"] = string.Empty;
			dataRow["Column411"] = string.Empty;
			dataRow["Id11"] = string.Empty;
			dataRow["Did11"] = string.Empty;
			dataRow["Column511"] = string.Empty;
			dataTable.Rows.Add(dataRow);
			DataSet dataSet8 = new DataSet();
			dataSet8.Tables.Add(dataTable);
			GridView5.DataSource = dataSet8;
			GridView5.DataBind();
			GridViewRow gridViewRow4 = GridView5.Rows[GridView5.Rows.Count - 1];
			((ImageButton)gridViewRow4.FindControl("ImageButton3")).Visible = false;
			CheckBox checkBox7 = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
			CheckBox checkBox8 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
			CheckBox checkBox9 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
			if (checkBox8.Checked || checkBox9.Checked)
			{
				checkBox7.Enabled = false;
			}
			if (!checkBox7.Checked)
			{
				return;
			}
			double num7 = 0.0;
			foreach (GridViewRow row3 in GridView5.Rows)
			{
				_ = row3;
				if (((TextBox)gridViewRow4.FindControl("txtQtyFin")).Text != "")
				{
					num7 += Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow4.FindControl("txtQtyFin")).Text).ToString("N3"));
				}
			}
			double num8 = Convert.ToDouble(decimal.Parse((fun.RMQty(text, wono, CompId, "tblMP_Material_Finish") + num7).ToString()).ToString("N3"));
			((TextBox)gridViewRow4.FindControl("txtQtyFin")).Text = decimal.Parse((num - num8).ToString()).ToString("N3");
			((TextBox)gridViewRow4.FindControl("txtFinDeliDate")).Text = WomfDate;
			((TextBox)gridViewRow4.FindControl("txtFinRate")).Text = "0";
			((TextBox)gridViewRow4.FindControl("TxtFinDiscount")).Text = "0";
		}
		catch (Exception)
		{
		}
	}

	public void GridColour()
	{
		try
		{
			foreach (GridViewRow row in SearchGridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
				string cmdText = " Select SessionId,ItemId from tblMP_Material_Detail_Temp where SessionId='" + SId + "'  And ItemId='" + num + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					row.BackColor = Color.Pink;
				}
				else
				{
					row.BackColor = Color.Transparent;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		SearchGridView1.PageIndex = e.NewPageIndex;
		try
		{
			MP_GRID(wono, CompId, SearchGridView1, fyid, " And tblDG_Item_Master.CId is null");
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
			int num = 0;
			double num2 = 0.0;
			string text = ((LinkButton)gridViewRow.FindControl("btnCode")).Text;
			num2 = Convert.ToDouble(((Label)gridViewRow.FindControl("lblbomqty")).Text);
			num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblItemId")).Text);
			if (e.CommandName == "Show")
			{
				string cmdText = "SELECT ItemId FROM tblMP_Material_Detail_Temp  where  tblMP_Material_Detail_Temp.ItemId='" + num + "'  And SessionId!='" + SId + "' ";
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
				{
					string empty = string.Empty;
					empty = "This item is in use.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				}
				else
				{
					ViewState["ItemId"] = num;
					ViewState["BOMQty"] = num2;
					FillRM();
					FillPRO();
					FillFIN();
					lblItemCode.Visible = true;
					lblItemCode0.Visible = true;
					lblBomQty.Visible = true;
					lblBomQty0.Visible = true;
					lblRawMaterial.Visible = true;
					lblProcess.Visible = true;
					lblFinish.Visible = true;
					lblItemCode0.Text = text;
					lblBomQty0.Text = num2.ToString();
					BtnAddTemp.Visible = true;
					abc();
				}
			}
			if (e.CommandName == "viewImg")
			{
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
			}
			if (e.CommandName == "viewSpec")
			{
				base.Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + num + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			int index = gridViewRow.RowIndex + 1;
			GridView gridView = (GridView)gridViewRow.NamingContainer;
			TextBox textBox = gridView.Rows[index].FindControl("txtSupplierRM") as TextBox;
			TextBox textBox2 = gridView.Rows[index].FindControl("txtRMQty") as TextBox;
			TextBox textBox3 = gridView.Rows[index].FindControl("txtRMDeliDate") as TextBox;
			TextBox textBox4 = gridView.Rows[index].FindControl("txtRMRate") as TextBox;
			TextBox textBox5 = gridView.Rows[index].FindControl("TxtDiscount") as TextBox;
			CheckBox checkBox2 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
			CheckBox checkBox3 = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
			int num = Convert.ToInt32(ViewState["ItemId"]);
			double num2 = Convert.ToDouble(ViewState["BOMQty"]);
			double num3 = 0.0;
			double num4 = 0.0;
			if (checkBox.Checked)
			{
				string cmdText = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + num + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num4 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
					num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
				else
				{
					string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + num + "' And CompId='" + CompId + "'  order by DisRate Asc ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
					{
						num4 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
						num3 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
					}
				}
				if (checkBox.Checked || checkBox2.Checked)
				{
					checkBox3.Enabled = false;
					checkBox3.Checked = false;
				}
				else
				{
					checkBox3.Enabled = true;
				}
				if (textBox2.Text == "" && textBox3.Text == "")
				{
					textBox.Text = SupplierName;
					textBox2.Text = (num2 - fun.RMQty(num.ToString(), wono, CompId, "tblMP_Material_RawMaterial") - fun.CalWISQty(CompId.ToString(), wono, num.ToString()) + fun.GQNQTY(CompId, wono, num.ToString())).ToString();
					textBox3.Text = WomfDate;
					textBox4.Text = num3.ToString();
					textBox5.Text = num4.ToString();
				}
				return;
			}
			textBox.Text = string.Empty;
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
			textBox4.Text = string.Empty;
			textBox5.Text = string.Empty;
			if (checkBox.Checked || checkBox2.Checked)
			{
				checkBox3.Enabled = false;
				checkBox3.Checked = false;
			}
			else
			{
				checkBox3.Enabled = true;
			}
			string cmdText3 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + num + "' And RM='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				string cmdText4 = fun.select("DMid", "tblMP_Material_RawMaterial_Temp", "DMid='" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					string cmdText5 = "delete from tblMP_Material_RawMaterial_Temp where DMid='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText6 = fun.delete("tblMP_Material_Detail_Temp", "Id='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillRM();
					GridColour();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			int index = gridViewRow.RowIndex + 1;
			GridView gridView = (GridView)gridViewRow.NamingContainer;
			TextBox textBox = gridView.Rows[index].FindControl("txtSupplierPro") as TextBox;
			TextBox textBox2 = gridView.Rows[index].FindControl("txtProQty") as TextBox;
			TextBox textBox3 = gridView.Rows[index].FindControl("txtProDeliDate") as TextBox;
			TextBox textBox4 = gridView.Rows[index].FindControl("txtProRate") as TextBox;
			TextBox textBox5 = gridView.Rows[index].FindControl("TxtProDiscount") as TextBox;
			CheckBox checkBox2 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
			CheckBox checkBox3 = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
			int num = Convert.ToInt32(ViewState["ItemId"]);
			double num2 = Convert.ToDouble(ViewState["BOMQty"]);
			double num3 = 0.0;
			double num4 = 0.0;
			if (checkBox.Checked)
			{
				string cmdText = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + num + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num4 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
					num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
				else
				{
					string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + num + "' And CompId='" + CompId + "'  order by DisRate Asc ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
					{
						num4 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
						num3 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
					}
				}
				if (checkBox.Checked || checkBox2.Checked)
				{
					checkBox3.Enabled = false;
					checkBox3.Checked = false;
				}
				else
				{
					checkBox3.Enabled = true;
				}
				if (textBox2.Text == "" && textBox3.Text == "")
				{
					textBox.Text = SupplierName;
					textBox2.Text = (num2 - fun.RMQty(num.ToString(), wono, CompId, "tblMP_Material_Process") - fun.CalWISQty(CompId.ToString(), wono, num.ToString()) + fun.GQNQTY(CompId, wono, num.ToString())).ToString();
					textBox3.Text = WomfDate;
					textBox4.Text = num3.ToString();
					textBox5.Text = num4.ToString();
				}
				return;
			}
			textBox.Text = string.Empty;
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
			textBox4.Text = string.Empty;
			textBox5.Text = string.Empty;
			if (checkBox.Checked || checkBox2.Checked)
			{
				checkBox3.Enabled = false;
				checkBox3.Checked = false;
			}
			else
			{
				checkBox3.Enabled = true;
			}
			string cmdText3 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + num + "' And PRO='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				string cmdText4 = fun.select("DMid", "tblMP_Material_Process_Temp", "DMid='" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					string cmdText5 = "delete from tblMP_Material_Process_Temp where DMid='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText6 = fun.delete("tblMP_Material_Detail_Temp", "Id='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillPRO();
					GridColour();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)sender;
			GridViewRow gridViewRow = (GridViewRow)checkBox.NamingContainer;
			int index = gridViewRow.RowIndex + 1;
			GridView gridView = (GridView)gridViewRow.NamingContainer;
			TextBox textBox = gridView.Rows[index].FindControl("txtSupplierFin") as TextBox;
			TextBox textBox2 = gridView.Rows[index].FindControl("txtQtyFin") as TextBox;
			TextBox textBox3 = gridView.Rows[index].FindControl("txtFinDeliDate") as TextBox;
			TextBox textBox4 = gridView.Rows[index].FindControl("txtFinRate") as TextBox;
			TextBox textBox5 = gridView.Rows[index].FindControl("TxtFinDiscount") as TextBox;
			CheckBox checkBox2 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
			CheckBox checkBox3 = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
			int num = Convert.ToInt32(ViewState["ItemId"]);
			double num2 = Convert.ToDouble(ViewState["BOMQty"]);
			double num3 = 0.0;
			double num4 = 0.0;
			if (checkBox.Checked)
			{
				string cmdText = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + num + "' And CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
				{
					num4 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
					num3 = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
				}
				else
				{
					string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + num + "' And CompId='" + CompId + "'  order by DisRate Asc ");
					SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter2.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
					{
						num4 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["Discount"].ToString()).ToString("N2"));
						num3 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
					}
				}
				if (textBox2.Text == "" && textBox3.Text == "")
				{
					textBox.Text = SupplierName;
					textBox2.Text = (num2 - fun.RMQty(num.ToString(), wono, CompId, "tblMP_Material_Finish") - fun.CalWISQty(CompId.ToString(), wono, num.ToString()) + fun.GQNQTY(CompId, wono, num.ToString())).ToString();
					textBox3.Text = WomfDate;
					textBox4.Text = num3.ToString();
					textBox5.Text = num4.ToString();
					checkBox3.Enabled = false;
					checkBox2.Enabled = false;
				}
				return;
			}
			textBox.Text = string.Empty;
			textBox2.Text = string.Empty;
			textBox3.Text = string.Empty;
			textBox4.Text = string.Empty;
			textBox5.Text = string.Empty;
			checkBox3.Enabled = true;
			checkBox2.Enabled = true;
			string cmdText3 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + num + "' And FIN='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				string cmdText4 = fun.select("DMid", "tblMP_Material_Finish_Temp", "DMid='" + dataSet3.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					string cmdText5 = "delete from tblMP_Material_Finish_Temp where DMid='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'";
					SqlCommand sqlCommand = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
					string cmdText6 = fun.delete("tblMP_Material_Detail_Temp", "Id='" + dataSet4.Tables[0].Rows[0][0].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText6, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
					FillFIN();
					GridColour();
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblRMId")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblRMDMid")).Text;
			if (e.CommandName == "RMDelete")
			{
				string cmdText = fun.delete("tblMP_Material_RawMaterial_Temp", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText2 = fun.select("*", "tblMP_Material_RawMaterial_Temp", " DMid='" + text2 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblMP_Material_Detail_Temp", "Id='" + text2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
				}
				FillRM();
				abc();
				GridColour();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblProId")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblProDMid")).Text;
			if (e.CommandName == "ProDelete")
			{
				string cmdText = fun.delete("tblMP_Material_Process_Temp", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText2 = fun.select("*", "tblMP_Material_Process_Temp", " DMid='" + text2 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblMP_Material_Detail_Temp", "Id='" + text2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
				}
				FillPRO();
				abc();
				GridColour();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			GridViewRow gridViewRow = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
			string text = ((Label)gridViewRow.FindControl("lblFinId")).Text;
			string text2 = ((Label)gridViewRow.FindControl("lblFinDMid")).Text;
			if (e.CommandName == "FinDelete")
			{
				string cmdText = fun.delete("tblMP_Material_Finish_Temp", "Id='" + text + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText2 = fun.select("*", "tblMP_Material_Finish_Temp", " DMid='" + text2 + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string cmdText3 = fun.delete("tblMP_Material_Detail_Temp", "Id='" + text2 + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
				}
				FillFIN();
				abc();
				GridColour();
			}
		}
		catch (Exception)
		{
		}
	}

	[WebMethod]
	[ScriptMethod]
	public static string[] GetCompletionList(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
		sqlConnection.Open();
		string selectCommandText = clsFunctions2.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + num + "'");
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConnection);
		sqlDataAdapter.Fill(dataSet, "tblMM_Supplier_master");
		sqlConnection.Close();
		string[] array = new string[0];
		for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
		{
			if (dataSet.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
			{
				Array.Resize(ref array, array.Length + 1);
				array[array.Length - 1] = dataSet.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + dataSet.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
			}
		}
		Array.Sort(array);
		return array;
	}

	protected void BtnAddTemp_Click(object sender, EventArgs e)
	{
		string text = ViewState["ItemId"].ToString();
		double num = Convert.ToDouble(ViewState["BOMQty"]);
		CheckBox checkBox = GridView3.HeaderRow.Cells[0].FindControl("CheckBox1") as CheckBox;
		CheckBox checkBox2 = GridView4.HeaderRow.Cells[0].FindControl("CheckBox2") as CheckBox;
		CheckBox checkBox3 = GridView5.HeaderRow.Cells[0].FindControl("CheckBox3") as CheckBox;
		string cmdText = "SELECT ItemId FROM tblMP_Material_Detail_Temp  where  tblMP_Material_Detail_Temp.ItemId='" + text + "'  And SessionId!='" + SId + "' ";
		SqlCommand selectCommand = new SqlCommand(cmdText, con);
		SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
		DataSet dataSet = new DataSet();
		sqlDataAdapter.Fill(dataSet);
		if (dataSet.Tables[0].Rows.Count > 0 && dataSet.Tables[0].Rows[0][0] != DBNull.Value)
		{
			string empty = string.Empty;
			empty = "This item is in use.";
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			return;
		}
		double num2 = 0.0;
		string cmdText2 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + text + "' And CompId='" + CompId + "'");
		SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
		SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
		DataSet dataSet2 = new DataSet();
		sqlDataAdapter2.Fill(dataSet2);
		if (dataSet2.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
		{
			num2 = Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
		}
		else
		{
			string cmdText3 = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + text + "' And CompId='" + CompId + "'  order by DisRate Asc ");
			SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet3 = new DataSet();
			sqlDataAdapter3.Fill(dataSet3);
			if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
			{
				num2 = Convert.ToDouble(decimal.Parse(dataSet3.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
			}
		}
		string text2 = "";
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		string text3 = "";
		GridViewRow gridViewRow = GridView3.Rows[GridView3.Rows.Count - 1];
		string text4 = "";
		string text5 = "";
		string text6 = "";
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		if (checkBox.Checked && ((TextBox)gridViewRow.FindControl("txtSupplierRM")).Text != "" && ((TextBox)gridViewRow.FindControl("txtRMQty")).Text != "0" && ((TextBox)gridViewRow.FindControl("txtRMRate")).Text != "")
		{
			_ = ((TextBox)gridViewRow.FindControl("txtSupplierRM")).Text;
			text2 = fun.getCode(((TextBox)gridViewRow.FindControl("txtSupplierRM")).Text);
			num3 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtRMQty")).Text);
			num5 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("TxtDiscount")).Text);
			num4 = Convert.ToDouble(((TextBox)gridViewRow.FindControl("txtRMRate")).Text);
			text3 = fun.FromDateDMY(((TextBox)gridViewRow.FindControl("txtRMDeliDate")).Text);
			_ = ((TextBox)gridViewRow.FindControl("txtRMDeliDate")).Text;
			num6 = Convert.ToDouble(decimal.Parse((num4 - num4 * num5 / 100.0).ToString()).ToString("N2"));
			string cmdText4 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And RM='1' AND SessionId='" + SId + "' ");
			SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			if (dataSet4.Tables[0].Rows.Count == 0)
			{
				if (Math.Round(num - (fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial") + num3 + fun.RMQty_Temp(text, "tblMP_Material_RawMaterial_Temp")), 5) >= 0.0 && num4 > 0.0)
				{
					string cmdText5 = fun.insert("tblMP_Material_Detail_Temp", "SessionId,ItemId,RM", "'" + SId + "','" + text + "','1'");
					SqlCommand sqlCommand = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand.ExecuteNonQuery();
					con.Close();
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = " Invalid data!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			string cmdText6 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And RM='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand5 = new SqlCommand(cmdText6, con);
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
			DataSet dataSet5 = new DataSet();
			sqlDataAdapter5.Fill(dataSet5);
			if (dataSet5.Tables[0].Rows.Count > 0)
			{
				string cmdText7 = fun.select("*", "tblMP_Material_RawMaterial_Temp", "SupplierId='" + text2 + "' And DelDate='" + text3 + "' And DMid='" + dataSet5.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText7, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6);
				if (dataSet6.Tables[0].Rows.Count == 0)
				{
					if (Math.Round(num - (fun.RMQty(text, wono, CompId, "tblMP_Material_RawMaterial") + num3 + fun.RMQty_Temp(text, "tblMP_Material_RawMaterial_Temp")), 5) >= 0.0)
					{
						if (num6 > 0.0)
						{
							if (num2 > 0.0)
							{
								double num10 = 0.0;
								num10 = Convert.ToDouble(decimal.Parse((num2 - num6).ToString()).ToString("N2"));
								if (num10 >= 0.0)
								{
									Insfun("tblMP_Material_RawMaterial_Temp", Convert.ToInt32(dataSet5.Tables[0].Rows[0]["Id"]), text2, num3, num4, text3, num5);
								}
								else
								{
									string cmdText8 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");
									SqlCommand selectCommand7 = new SqlCommand(cmdText8, con);
									SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
									DataSet dataSet7 = new DataSet();
									sqlDataAdapter7.Fill(dataSet7);
									if (dataSet7.Tables[0].Rows.Count > 0)
									{
										Insfun("tblMP_Material_RawMaterial_Temp", Convert.ToInt32(dataSet5.Tables[0].Rows[0]["Id"]), text2, num3, num4, text3, num5);
									}
									else
									{
										string empty3 = string.Empty;
										empty3 = "Entered rate is not acceptable!";
										base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
									}
								}
							}
							else
							{
								Insfun("tblMP_Material_RawMaterial_Temp", Convert.ToInt32(dataSet5.Tables[0].Rows[0]["Id"]), text2, num3, num4, text3, num5);
							}
							FillRM();
						}
						else
						{
							string empty4 = string.Empty;
							empty4 = "Entered rate is not acceptable!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty4 + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					text4 = " Raw Material[A]";
					num7++;
				}
			}
		}
		string text7 = "";
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		double num14 = 0.0;
		string text8 = "";
		GridViewRow gridViewRow2 = GridView4.Rows[GridView4.Rows.Count - 1];
		if (checkBox2.Checked && ((TextBox)gridViewRow2.FindControl("txtSupplierPro")).Text != "" && ((TextBox)gridViewRow2.FindControl("txtProQty")).Text != "0" && ((TextBox)gridViewRow2.FindControl("txtProRate")).Text != "")
		{
			_ = ((TextBox)gridViewRow2.FindControl("txtSupplierPro")).Text;
			text7 = fun.getCode(((TextBox)gridViewRow2.FindControl("txtSupplierPro")).Text);
			num11 = Convert.ToDouble(((TextBox)gridViewRow2.FindControl("txtProQty")).Text);
			num12 = Convert.ToDouble(((TextBox)gridViewRow2.FindControl("txtProRate")).Text);
			num13 = Convert.ToDouble(((TextBox)gridViewRow2.FindControl("TxtProDiscount")).Text);
			num14 = Convert.ToDouble(decimal.Parse((num12 - num12 * num13 / 100.0).ToString()).ToString("N2"));
			text8 = fun.FromDateDMY(((TextBox)gridViewRow2.FindControl("txtProDeliDate")).Text);
			_ = ((TextBox)gridViewRow2.FindControl("txtProDeliDate")).Text;
			string cmdText9 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And PRO='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand8 = new SqlCommand(cmdText9, con);
			SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
			DataSet dataSet8 = new DataSet();
			sqlDataAdapter8.Fill(dataSet8);
			if (dataSet8.Tables[0].Rows.Count == 0)
			{
				if (Math.Round(num - (fun.RMQty(text, wono, CompId, "tblMP_Material_Process") + num11 + fun.RMQty_Temp(text, "tblMP_Material_Process_Temp")), 5) >= 0.0 && num12 > 0.0)
				{
					string cmdText10 = fun.insert("tblMP_Material_Detail_Temp", "SessionId,ItemId,PRO", "'" + SId + "','" + text + "','1'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText10, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
				}
				else
				{
					string empty5 = string.Empty;
					empty5 = " Invalid data!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
				}
			}
			string cmdText11 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And PRO='1' And SessionId='" + SId + "' ");
			SqlCommand selectCommand9 = new SqlCommand(cmdText11, con);
			SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
			DataSet dataSet9 = new DataSet();
			sqlDataAdapter9.Fill(dataSet9);
			if (dataSet9.Tables[0].Rows.Count > 0)
			{
				string cmdText12 = fun.select("*", "tblMP_Material_Process_Temp", "SupplierId='" + text7 + "' And DelDate='" + text8 + "' And DMid='" + dataSet9.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand10 = new SqlCommand(cmdText12, con);
				SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
				DataSet dataSet10 = new DataSet();
				sqlDataAdapter10.Fill(dataSet10);
				if (dataSet10.Tables[0].Rows.Count == 0)
				{
					if (Math.Round(num - (fun.RMQty(text, wono, CompId, "tblMP_Material_Process") + num11 + fun.RMQty_Temp(text, "tblMP_Material_Process_Temp")), 5) >= 0.0)
					{
						if (num14 > 0.0)
						{
							if (num2 > 0.0)
							{
								double num15 = 0.0;
								num15 = Convert.ToDouble(decimal.Parse((num2 - num14).ToString()).ToString("N2"));
								if (num15 >= 0.0)
								{
									Insfun("tblMP_Material_Process_Temp", Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Id"]), text7, num11, num12, text8, num13);
								}
								else
								{
									string cmdText13 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");
									SqlCommand selectCommand11 = new SqlCommand(cmdText13, con);
									SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
									DataSet dataSet11 = new DataSet();
									sqlDataAdapter11.Fill(dataSet11);
									if (dataSet11.Tables[0].Rows.Count > 0)
									{
										Insfun("tblMP_Material_Process_Temp", Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Id"]), text7, num11, num12, text8, num13);
									}
									else
									{
										string empty6 = string.Empty;
										empty6 = "Entered rate is not acceptable!";
										base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty6 + "');", addScriptTags: true);
									}
								}
							}
							else
							{
								Insfun("tblMP_Material_Process_Temp", Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Id"]), text7, num11, num12, text8, num13);
							}
							FillPRO();
						}
						else
						{
							string empty7 = string.Empty;
							empty7 = "Entered rate is not acceptable!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty7 + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					text5 = " Process[o]";
					num8++;
				}
			}
		}
		string text9 = "";
		double num16 = 0.0;
		double num17 = 0.0;
		double num18 = 0.0;
		double num19 = 0.0;
		string text10 = "";
		GridViewRow gridViewRow3 = GridView5.Rows[GridView5.Rows.Count - 1];
		if (checkBox3.Checked && ((TextBox)gridViewRow3.FindControl("txtSupplierFin")).Text != "" && ((TextBox)gridViewRow3.FindControl("txtQtyFin")).Text != "0" && ((TextBox)gridViewRow3.FindControl("txtFinRate")).Text != "")
		{
			_ = ((TextBox)gridViewRow3.FindControl("txtSupplierFin")).Text;
			text9 = fun.getCode(((TextBox)gridViewRow3.FindControl("txtSupplierFin")).Text);
			num16 = Convert.ToDouble(((TextBox)gridViewRow3.FindControl("txtQtyFin")).Text);
			num17 = Convert.ToDouble(((TextBox)gridViewRow3.FindControl("txtFinRate")).Text);
			num18 = Convert.ToDouble(((TextBox)gridViewRow3.FindControl("TxtFinDiscount")).Text);
			text10 = fun.FromDateDMY(((TextBox)gridViewRow3.FindControl("txtFinDeliDate")).Text);
			_ = ((TextBox)gridViewRow3.FindControl("txtFinDeliDate")).Text;
			num19 = Convert.ToDouble(decimal.Parse((num17 - num17 * num18 / 100.0).ToString()).ToString("N2"));
			string cmdText14 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And FIN='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand12 = new SqlCommand(cmdText14, con);
			SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
			DataSet dataSet12 = new DataSet();
			sqlDataAdapter12.Fill(dataSet12);
			if (dataSet12.Tables[0].Rows.Count == 0)
			{
				if (Math.Round(num - (fun.RMQty(text, wono, CompId, "tblMP_Material_Finish") + num16 + fun.RMQty_Temp(text, "tblMP_Material_Finish_Temp")), 5) >= 0.0 && num17 > 0.0)
				{
					string cmdText15 = fun.insert("tblMP_Material_Detail_Temp", "SessionId,ItemId,FIN", "'" + SId + "','" + text + "','1'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText15, con);
					con.Open();
					sqlCommand3.ExecuteNonQuery();
					con.Close();
				}
				else
				{
					string empty8 = string.Empty;
					empty8 = " Invalid data!";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty8 + "');", addScriptTags: true);
				}
			}
			string cmdText16 = fun.select("*", "tblMP_Material_Detail_Temp", "ItemId='" + text + "' And FIN='1' And SessionId='" + SId + "'");
			SqlCommand selectCommand13 = new SqlCommand(cmdText16, con);
			SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
			DataSet dataSet13 = new DataSet();
			sqlDataAdapter13.Fill(dataSet13);
			if (dataSet13.Tables[0].Rows.Count > 0)
			{
				string cmdText17 = fun.select("*", "tblMP_Material_Finish_Temp", "SupplierId='" + text9 + "' And DelDate='" + text10 + "' And DMid='" + dataSet13.Tables[0].Rows[0]["Id"].ToString() + "'");
				SqlCommand selectCommand14 = new SqlCommand(cmdText17, con);
				SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
				DataSet dataSet14 = new DataSet();
				sqlDataAdapter14.Fill(dataSet14);
				if (dataSet14.Tables[0].Rows.Count == 0)
				{
					if (Math.Round(num - (fun.RMQty(text, wono, CompId, "tblMP_Material_Finish") + num16 + fun.RMQty_Temp(text, "tblMP_Material_Finish_Temp")), 5) >= 0.0)
					{
						if (num19 > 0.0)
						{
							if (num2 > 0.0)
							{
								double num20 = 0.0;
								num20 = Convert.ToDouble(decimal.Parse((num2 - num19).ToString()).ToString("N2"));
								if (num20 >= 0.0)
								{
									Insfun("tblMP_Material_Finish_Temp", Convert.ToInt32(dataSet13.Tables[0].Rows[0]["Id"]), text9, num16, num17, text10, num18);
								}
								else
								{
									string cmdText18 = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");
									SqlCommand selectCommand15 = new SqlCommand(cmdText18, con);
									SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
									DataSet dataSet15 = new DataSet();
									sqlDataAdapter15.Fill(dataSet15);
									if (dataSet15.Tables[0].Rows.Count > 0)
									{
										Insfun("tblMP_Material_Finish_Temp", Convert.ToInt32(dataSet13.Tables[0].Rows[0]["Id"]), text9, num16, num17, text10, num18);
									}
									else
									{
										string empty9 = string.Empty;
										empty9 = "Entered rate is not acceptable!";
										base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty9 + "');", addScriptTags: true);
									}
								}
							}
							else
							{
								Insfun("tblMP_Material_Finish_Temp", Convert.ToInt32(dataSet13.Tables[0].Rows[0]["Id"]), text9, num16, num17, text10, num18);
							}
							FillFIN();
						}
						else
						{
							string empty10 = string.Empty;
							empty10 = "Entered rate is not acceptable!";
							base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty10 + "');", addScriptTags: true);
						}
					}
				}
				else
				{
					text6 = " Finish[0]";
					num9++;
				}
			}
		}
		if (num7 > 0 || num8 > 0)
		{
			string empty11 = string.Empty;
			empty11 = "Invalid data entry in " + text4 + " " + text5;
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty11 + "');", addScriptTags: true);
		}
		else if (num9 > 0)
		{
			string empty12 = string.Empty;
			empty12 = "Invalid data entry in " + text6;
			base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty12 + "');", addScriptTags: true);
		}
		GridColour();
	}

	protected void RadButton1_Click(object sender, EventArgs e)
	{
		try
		{
			double num = 0.0;
			con.Open();
			string cmdText = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + SId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = "";
			int num6 = 0;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("PLNo", "tblMP_Material_Master", "CompId='" + CompId + "' AND FinYearId='" + fyid + "' Order by PLNo desc");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblMP_Material_Master");
				text = ((dataSet2.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet2.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				string cmdText3 = fun.select("PRNo", "tblMM_PR_Master", "CompId='" + CompId + "' AND FinYearId='" + fyid + "' order by PRNo desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3, "tblMM_PR_Master");
				string text2 = "";
				text2 = ((dataSet3.Tables[0].Rows.Count <= 0) ? "0001" : (Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString()) + 1).ToString("D4"));
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					num = Convert.ToDouble(decimal.Parse(fun.AllComponentBOMQty(CompId, wono, dataSet.Tables[0].Rows[i]["ItemId"].ToString(), fyid).ToString()).ToString("N3"));
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["RM"]) == 1)
					{
						string cmdText4 = fun.select("sum(Qty) as RM_Qty", "tblMP_Material_RawMaterial_Temp", "DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
						SqlCommand selectCommand4 = new SqlCommand(cmdText4, con);
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter4.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows[0]["RM_Qty"] != DBNull.Value)
						{
							if (dataSet4.Tables[0].Rows.Count > 0 && Math.Round(num - (Convert.ToDouble(dataSet4.Tables[0].Rows[0]["RM_Qty"]) + fun.RMQty(dataSet.Tables[0].Rows[i]["ItemId"].ToString(), wono, CompId, "tblMP_Material_RawMaterial")), 5) > 0.0)
							{
								num2++;
							}
						}
						else
						{
							num5++;
						}
					}
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["PRO"]) == 1)
					{
						string cmdText5 = fun.select("sum(Qty) as PRO_Qty", "tblMP_Material_Process_Temp", "DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, con);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet5 = new DataSet();
						sqlDataAdapter5.Fill(dataSet5);
						if (dataSet5.Tables[0].Rows[0]["PRO_Qty"] != DBNull.Value)
						{
							if (dataSet5.Tables[0].Rows.Count > 0 && Math.Round(num - (Convert.ToDouble(dataSet5.Tables[0].Rows[0]["PRO_Qty"]) + fun.RMQty(dataSet.Tables[0].Rows[i]["ItemId"].ToString(), wono, CompId, "tblMP_Material_Process")), 5) > 0.0)
							{
								num3++;
							}
						}
						else
						{
							num5++;
						}
					}
					if (Convert.ToInt32(dataSet.Tables[0].Rows[i]["FIN"]) != 1)
					{
						continue;
					}
					string cmdText6 = fun.select("sum(Qty) as FIN_Qty", "tblMP_Material_Finish_Temp", "DMid='" + dataSet.Tables[0].Rows[i]["Id"].ToString() + "'");
					SqlCommand selectCommand6 = new SqlCommand(cmdText6, con);
					SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
					DataSet dataSet6 = new DataSet();
					sqlDataAdapter6.Fill(dataSet6);
					if (dataSet6.Tables[0].Rows[0]["FIN_Qty"] != DBNull.Value)
					{
						if (dataSet6.Tables[0].Rows.Count > 0 && Math.Round(num - (Convert.ToDouble(dataSet6.Tables[0].Rows[0]["FIN_Qty"]) + fun.RMQty(dataSet.Tables[0].Rows[i]["ItemId"].ToString(), wono, CompId, "tblMP_Material_Finish")), 5) > 0.0)
						{
							num4++;
						}
					}
					else
					{
						num5++;
					}
				}
				if (num5 == 0)
				{
					if (num2 > 0 || num3 > 0 || num4 > 0)
					{
						string empty = string.Empty;
						empty = "Invalid data entry found.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
						return;
					}
					int num7 = 1;
					int num8 = 1;
					int num9 = 1;
					for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
					{
						num = Convert.ToDouble(decimal.Parse(fun.AllComponentBOMQty(CompId, wono, dataSet.Tables[0].Rows[j]["ItemId"].ToString(), fyid).ToString()).ToString("N3"));
						if (Convert.ToInt32(dataSet.Tables[0].Rows[j]["RM"]) == 1)
						{
							string cmdText7 = fun.select("sum(Qty) as RM_Qty", "tblMP_Material_RawMaterial_Temp", "DMid='" + dataSet.Tables[0].Rows[j]["Id"].ToString() + "'");
							SqlCommand selectCommand7 = new SqlCommand(cmdText7, con);
							SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(selectCommand7);
							DataSet dataSet7 = new DataSet();
							sqlDataAdapter7.Fill(dataSet7);
							if (dataSet7.Tables[0].Rows.Count > 0)
							{
								int num10 = 0;
								DataSet dataSet8 = new DataSet();
								if (num7 == 1)
								{
									SqlCommand sqlCommand = new SqlCommand(fun.insert("tblMP_Material_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,PLNo,WONo", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + text + "','" + wono + "'"), con);
									sqlCommand.ExecuteNonQuery();
									string cmdText8 = fun.select("Id", "tblMP_Material_Master", "CompId='" + CompId + "' Order by Id desc");
									SqlCommand selectCommand8 = new SqlCommand(cmdText8, con);
									SqlDataAdapter sqlDataAdapter8 = new SqlDataAdapter(selectCommand8);
									sqlDataAdapter8.Fill(dataSet8, "tblMP_Material_Master");
									if (dataSet8.Tables[0].Rows.Count > 0)
									{
										num6 = Convert.ToInt32(dataSet8.Tables[0].Rows[0]["Id"].ToString());
										SqlCommand sqlCommand2 = new SqlCommand(fun.insert("tblMM_PR_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WONo,PRNo,PLNId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + wono + "','" + text2 + "','" + num6 + "'"), con);
										sqlCommand2.ExecuteNonQuery();
									}
									num7 = 0;
								}
								string cmdText9 = fun.select("Id", "tblMM_PR_Master", "CompId='" + CompId + "' order by Id desc");
								SqlCommand selectCommand9 = new SqlCommand(cmdText9, con);
								SqlDataAdapter sqlDataAdapter9 = new SqlDataAdapter(selectCommand9);
								DataSet dataSet9 = new DataSet();
								sqlDataAdapter9.Fill(dataSet9, "tblMM_PR_Master");
								if (dataSet9.Tables[0].Rows.Count > 0)
								{
									num10 = Convert.ToInt32(dataSet9.Tables[0].Rows[0]["Id"].ToString());
								}
								string cmdText10 = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + SId + "' And ItemId='" + dataSet.Tables[0].Rows[j]["ItemId"].ToString() + "' And RM='1'");
								SqlCommand selectCommand10 = new SqlCommand(cmdText10, con);
								SqlDataAdapter sqlDataAdapter10 = new SqlDataAdapter(selectCommand10);
								DataSet dataSet10 = new DataSet();
								sqlDataAdapter10.Fill(dataSet10);
								for (int k = 0; k < dataSet10.Tables[0].Rows.Count; k++)
								{
									SqlCommand sqlCommand3 = new SqlCommand(fun.insert("tblMP_Material_Detail", "Mid,ItemId,RM", "'" + num6 + "','" + dataSet10.Tables[0].Rows[k]["ItemId"].ToString() + "','" + dataSet10.Tables[0].Rows[k]["RM"].ToString() + "'"), con);
									sqlCommand3.ExecuteNonQuery();
									string cmdText11 = fun.select("Id", "tblMP_Material_Detail", "MId='" + num6 + "' AND RM='1' Order by Id desc");
									SqlCommand selectCommand11 = new SqlCommand(cmdText11, con);
									SqlDataAdapter sqlDataAdapter11 = new SqlDataAdapter(selectCommand11);
									DataSet dataSet11 = new DataSet();
									sqlDataAdapter11.Fill(dataSet11, "tblMP_Material_Detail");
									int num11 = 0;
									if (dataSet11.Tables[0].Rows.Count > 0)
									{
										num11 = Convert.ToInt32(dataSet11.Tables[0].Rows[0]["Id"].ToString());
									}
									string cmdText12 = fun.select("*", "tblMP_Material_RawMaterial_Temp", "DMid='" + dataSet10.Tables[0].Rows[k]["Id"].ToString() + "'");
									SqlCommand selectCommand12 = new SqlCommand(cmdText12, con);
									SqlDataAdapter sqlDataAdapter12 = new SqlDataAdapter(selectCommand12);
									DataSet dataSet12 = new DataSet();
									sqlDataAdapter12.Fill(dataSet12);
									int num12 = 1;
									string text3 = "";
									for (int l = 0; l < dataSet12.Tables[0].Rows.Count; l++)
									{
										if (num12 == 1)
										{
											string cmdText13 = fun.select("*", "tblDG_Item_Master", "Id='" + dataSet10.Tables[0].Rows[k]["ItemId"].ToString() + "'");
											SqlCommand selectCommand13 = new SqlCommand(cmdText13, con);
											SqlDataAdapter sqlDataAdapter13 = new SqlDataAdapter(selectCommand13);
											DataSet dataSet13 = new DataSet();
											sqlDataAdapter13.Fill(dataSet13, "tblDG_Item_Master");
											string text4 = dataSet13.Tables[0].Rows[0]["PartNo"].ToString() + "A";
											string cmdText14 = fun.select("ItemCode", "tblDG_Item_Master", "ItemCode='" + text4 + "'And CompId='" + CompId + "'");
											SqlCommand selectCommand14 = new SqlCommand(cmdText14, con);
											SqlDataAdapter sqlDataAdapter14 = new SqlDataAdapter(selectCommand14);
											DataSet dataSet14 = new DataSet();
											sqlDataAdapter14.Fill(dataSet14, "tblDG_Item_Master");
											if (dataSet14.Tables[0].Rows.Count == 0)
											{
												string cmdText15 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PartNo,ManfDesc,UOMBasic,MinOrderQty,MinStockQty,StockQty,Location,Absolute,OpeningBalDate,OpeningBalQty,ItemCode,Class,Process,InspectionDays,Excise,ImportLocal,UOMConFact,Buyer,AHId", "'" + currDate + "','" + currTime + "','" + SId + "','" + CompId + "','" + fyid + "','" + dataSet13.Tables[0].Rows[0]["PartNo"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["ManfDesc"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["UOMBasic"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0]["MinOrderQty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0]["MinStockQty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) + "','" + dataSet13.Tables[0].Rows[0]["Location"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["Absolute"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["OpeningBalDate"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet13.Tables[0].Rows[0]["OpeningBalQty"].ToString()).ToString("N3")) + "','" + text4 + "','" + dataSet13.Tables[0].Rows[0]["Class"].ToString() + "','1','" + dataSet13.Tables[0].Rows[0]["InspectionDays"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["Excise"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["ImportLocal"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["UOMConFact"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["Buyer"].ToString() + "','" + dataSet13.Tables[0].Rows[0]["AHId"].ToString() + "'");
												SqlCommand sqlCommand4 = new SqlCommand(cmdText15, con);
												sqlCommand4.ExecuteNonQuery();
											}
											string cmdText16 = fun.select("Id", "tblDG_Item_Master", "ItemCode='" + text4 + "'And CompId='" + CompId + "'");
											SqlCommand selectCommand15 = new SqlCommand(cmdText16, con);
											SqlDataAdapter sqlDataAdapter15 = new SqlDataAdapter(selectCommand15);
											DataSet dataSet15 = new DataSet();
											sqlDataAdapter15.Fill(dataSet15, "tblDG_Item_Master");
											if (dataSet15.Tables[0].Rows.Count > 0)
											{
												text3 = dataSet15.Tables[0].Rows[0][0].ToString();
											}
											num12 = 0;
										}
										SqlCommand sqlCommand5 = new SqlCommand(fun.insert("tblMP_Material_RawMaterial", "DMid,SupplierId,Qty,Rate,DelDate,ItemId,Discount", "'" + num11 + "','" + dataSet12.Tables[0].Rows[l]["SupplierId"].ToString() + "','" + dataSet12.Tables[0].Rows[l]["Qty"].ToString() + "','" + dataSet12.Tables[0].Rows[l]["Rate"].ToString() + "','" + dataSet12.Tables[0].Rows[l]["DelDate"].ToString() + "','" + text3 + "','" + dataSet12.Tables[0].Rows[l]["Discount"].ToString() + "'"), con);
										sqlCommand5.ExecuteNonQuery();
										SqlCommand sqlCommand6 = new SqlCommand(fun.insert("tblMM_PR_Details", "MId,PRNo,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Discount", "'" + num10 + "','" + text2 + "','" + text3 + "','" + dataSet12.Tables[0].Rows[l]["Qty"].ToString() + "','" + dataSet12.Tables[0].Rows[l]["SupplierId"].ToString() + "','" + dataSet12.Tables[0].Rows[l]["Rate"].ToString() + "','42','" + dataSet12.Tables[0].Rows[l]["DelDate"].ToString() + "','" + dataSet12.Tables[0].Rows[l]["Discount"].ToString() + "'"), con);
										sqlCommand6.ExecuteNonQuery();
									}
								}
							}
						}
						if (Convert.ToInt32(dataSet.Tables[0].Rows[j]["PRO"]) == 1)
						{
							string cmdText17 = fun.select("sum(Qty) as PRO_Qty", "tblMP_Material_Process_Temp", "DMid='" + dataSet.Tables[0].Rows[j]["Id"].ToString() + "'");
							SqlCommand selectCommand16 = new SqlCommand(cmdText17, con);
							SqlDataAdapter sqlDataAdapter16 = new SqlDataAdapter(selectCommand16);
							DataSet dataSet16 = new DataSet();
							sqlDataAdapter16.Fill(dataSet16);
							if (dataSet16.Tables[0].Rows.Count > 0)
							{
								int num13 = 0;
								DataSet dataSet17 = new DataSet();
								if (num8 == 1 && num7 == 1)
								{
									SqlCommand sqlCommand7 = new SqlCommand(fun.insert("tblMP_Material_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,PLNo,WONo", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + text + "','" + wono + "'"), con);
									sqlCommand7.ExecuteNonQuery();
									string cmdText18 = fun.select("Id", "tblMP_Material_Master", "CompId='" + CompId + "' Order by Id desc");
									SqlCommand selectCommand17 = new SqlCommand(cmdText18, con);
									SqlDataAdapter sqlDataAdapter17 = new SqlDataAdapter(selectCommand17);
									sqlDataAdapter17.Fill(dataSet17, "tblMP_Material_Master");
									if (dataSet17.Tables[0].Rows.Count > 0)
									{
										num6 = Convert.ToInt32(dataSet17.Tables[0].Rows[0]["Id"].ToString());
										SqlCommand sqlCommand8 = new SqlCommand(fun.insert("tblMM_PR_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WONo,PRNo,PLNId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + wono + "','" + text2 + "','" + num6 + "'"), con);
										sqlCommand8.ExecuteNonQuery();
									}
									num8 = 0;
									num7 = 0;
								}
								string cmdText19 = fun.select("Id", "tblMM_PR_Master", "CompId='" + CompId + "' order by Id desc");
								SqlCommand selectCommand18 = new SqlCommand(cmdText19, con);
								SqlDataAdapter sqlDataAdapter18 = new SqlDataAdapter(selectCommand18);
								DataSet dataSet18 = new DataSet();
								sqlDataAdapter18.Fill(dataSet18, "tblMM_PR_Master");
								if (dataSet18.Tables[0].Rows.Count > 0)
								{
									num13 = Convert.ToInt32(dataSet18.Tables[0].Rows[0]["Id"].ToString());
								}
								string cmdText20 = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + SId + "' And ItemId='" + dataSet.Tables[0].Rows[j]["ItemId"].ToString() + "' And PRO='1'");
								SqlCommand selectCommand19 = new SqlCommand(cmdText20, con);
								SqlDataAdapter sqlDataAdapter19 = new SqlDataAdapter(selectCommand19);
								DataSet dataSet19 = new DataSet();
								sqlDataAdapter19.Fill(dataSet19);
								for (int m = 0; m < dataSet19.Tables[0].Rows.Count; m++)
								{
									string cmdText21 = fun.insert("tblMP_Material_Detail", "Mid,ItemId,PRO", "'" + num6 + "','" + dataSet19.Tables[0].Rows[m]["ItemId"].ToString() + "','" + dataSet19.Tables[0].Rows[m]["PRO"].ToString() + "'");
									SqlCommand sqlCommand9 = new SqlCommand(cmdText21, con);
									sqlCommand9.ExecuteNonQuery();
									string cmdText22 = fun.select("Id", "tblMP_Material_Detail", "MId='" + num6 + "' AND PRO='1' Order by Id desc");
									SqlCommand selectCommand20 = new SqlCommand(cmdText22, con);
									SqlDataAdapter sqlDataAdapter20 = new SqlDataAdapter(selectCommand20);
									DataSet dataSet20 = new DataSet();
									sqlDataAdapter20.Fill(dataSet20, "tblMP_Material_Detail");
									int num14 = 0;
									if (dataSet20.Tables[0].Rows.Count > 0)
									{
										num14 = Convert.ToInt32(dataSet20.Tables[0].Rows[0]["Id"].ToString());
									}
									string cmdText23 = fun.select("*", "tblMP_Material_Process_Temp", "DMid='" + dataSet19.Tables[0].Rows[m]["Id"].ToString() + "'");
									SqlCommand selectCommand21 = new SqlCommand(cmdText23, con);
									SqlDataAdapter sqlDataAdapter21 = new SqlDataAdapter(selectCommand21);
									DataSet dataSet21 = new DataSet();
									sqlDataAdapter21.Fill(dataSet21);
									int num15 = 1;
									string text5 = "";
									for (int n = 0; n < dataSet21.Tables[0].Rows.Count; n++)
									{
										if (num15 == 1)
										{
											string cmdText24 = fun.select("*", "tblDG_Item_Master", "Id='" + dataSet19.Tables[0].Rows[m]["ItemId"].ToString() + "'");
											SqlCommand selectCommand22 = new SqlCommand(cmdText24, con);
											SqlDataAdapter sqlDataAdapter22 = new SqlDataAdapter(selectCommand22);
											DataSet dataSet22 = new DataSet();
											sqlDataAdapter22.Fill(dataSet22, "tblDG_Item_Master");
											string text6 = dataSet22.Tables[0].Rows[0]["PartNo"].ToString() + "O";
											string cmdText25 = fun.select("ItemCode", "tblDG_Item_Master", "ItemCode='" + text6 + "'And CompId='" + CompId + "'");
											SqlCommand selectCommand23 = new SqlCommand(cmdText25, con);
											SqlDataAdapter sqlDataAdapter23 = new SqlDataAdapter(selectCommand23);
											DataSet dataSet23 = new DataSet();
											sqlDataAdapter23.Fill(dataSet23, "tblDG_Item_Master");
											if (dataSet23.Tables[0].Rows.Count == 0)
											{
												string cmdText26 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PartNo,ManfDesc,UOMBasic,MinOrderQty,MinStockQty,StockQty,Location,Absolute,OpeningBalDate,OpeningBalQty,ItemCode,Class,Process,InspectionDays,Excise,ImportLocal,UOMConFact,Buyer,AHId", "'" + currDate + "','" + currTime + "','" + SId + "','" + CompId + "','" + fyid + "','" + dataSet22.Tables[0].Rows[0]["PartNo"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["ManfDesc"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["UOMBasic"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[0]["MinOrderQty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[0]["MinStockQty"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3")) + "','" + dataSet22.Tables[0].Rows[0]["Location"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["Absolute"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["OpeningBalDate"].ToString() + "','" + Convert.ToDouble(decimal.Parse(dataSet22.Tables[0].Rows[0]["OpeningBalQty"].ToString()).ToString("N3")) + "','" + text6 + "','" + dataSet22.Tables[0].Rows[0]["Class"].ToString() + "','2','" + dataSet22.Tables[0].Rows[0]["InspectionDays"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["Excise"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["ImportLocal"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["UOMConFact"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["Buyer"].ToString() + "','" + dataSet22.Tables[0].Rows[0]["AHId"].ToString() + "'");
												SqlCommand sqlCommand10 = new SqlCommand(cmdText26, con);
												sqlCommand10.ExecuteNonQuery();
											}
											string cmdText27 = fun.select("Id", "tblDG_Item_Master", "ItemCode='" + text6 + "'And CompId='" + CompId + "'");
											SqlCommand selectCommand24 = new SqlCommand(cmdText27, con);
											SqlDataAdapter sqlDataAdapter24 = new SqlDataAdapter(selectCommand24);
											DataSet dataSet24 = new DataSet();
											sqlDataAdapter24.Fill(dataSet24, "tblDG_Item_Master");
											if (dataSet24.Tables[0].Rows.Count > 0)
											{
												text5 = dataSet24.Tables[0].Rows[0][0].ToString();
											}
											num15 = 0;
										}
										SqlCommand sqlCommand11 = new SqlCommand(fun.insert("tblMP_Material_Process", "DMid,SupplierId,Qty,Rate,DelDate,ItemId,Discount", "'" + num14 + "','" + dataSet21.Tables[0].Rows[n]["SupplierId"].ToString() + "','" + dataSet21.Tables[0].Rows[n]["Qty"].ToString() + "','" + dataSet21.Tables[0].Rows[n]["Rate"].ToString() + "','" + dataSet21.Tables[0].Rows[n]["DelDate"].ToString() + "','" + text5 + "','" + dataSet21.Tables[0].Rows[n]["Discount"].ToString() + "'"), con);
										sqlCommand11.ExecuteNonQuery();
										SqlCommand sqlCommand12 = new SqlCommand(fun.insert("tblMM_PR_Details", "MId,PRNo,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Discount", "'" + num13 + "','" + text2 + "','" + text5 + "','" + dataSet21.Tables[0].Rows[n]["Qty"].ToString() + "','" + dataSet21.Tables[0].Rows[n]["SupplierId"].ToString() + "','" + dataSet21.Tables[0].Rows[n]["Rate"].ToString() + "','42','" + dataSet21.Tables[0].Rows[n]["DelDate"].ToString() + "','" + dataSet21.Tables[0].Rows[n]["Discount"].ToString() + "'"), con);
										sqlCommand12.ExecuteNonQuery();
									}
								}
							}
						}
						if (Convert.ToInt32(dataSet.Tables[0].Rows[j]["FIN"]) != 1)
						{
							continue;
						}
						string cmdText28 = fun.select("sum(Qty) as FIN_Qty", "tblMP_Material_Finish_Temp", "DMid='" + dataSet.Tables[0].Rows[j]["Id"].ToString() + "'");
						SqlCommand selectCommand25 = new SqlCommand(cmdText28, con);
						SqlDataAdapter sqlDataAdapter25 = new SqlDataAdapter(selectCommand25);
						DataSet dataSet25 = new DataSet();
						sqlDataAdapter25.Fill(dataSet25);
						if (dataSet25.Tables[0].Rows.Count <= 0)
						{
							continue;
						}
						int num16 = 0;
						if (num9 == 1 && num7 == 1)
						{
							SqlCommand sqlCommand13 = new SqlCommand(fun.insert("tblMP_Material_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,PLNo,WONo", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + text + "','" + wono + "'"), con);
							sqlCommand13.ExecuteNonQuery();
							string cmdText29 = fun.select("Id", "tblMP_Material_Master", "CompId='" + CompId + "' Order by Id desc");
							SqlCommand selectCommand26 = new SqlCommand(cmdText29, con);
							SqlDataAdapter sqlDataAdapter26 = new SqlDataAdapter(selectCommand26);
							DataSet dataSet26 = new DataSet();
							sqlDataAdapter26.Fill(dataSet26, "tblMP_Material_Master");
							if (dataSet26.Tables[0].Rows.Count > 0)
							{
								num6 = Convert.ToInt32(dataSet26.Tables[0].Rows[0]["Id"].ToString());
								SqlCommand sqlCommand14 = new SqlCommand(fun.insert("tblMM_PR_Master", "SysDate,SysTime,CompId,SessionId,FinYearId,WONo,PRNo,PLNId", "'" + currDate + "','" + currTime + "','" + CompId + "','" + SId + "','" + fyid + "','" + wono + "','" + text2 + "','" + num6 + "'"), con);
								sqlCommand14.ExecuteNonQuery();
							}
							num9 = 0;
							num7 = 0;
						}
						string cmdText30 = fun.select("Id", "tblMM_PR_Master", "CompId='" + CompId + "' order by Id desc");
						SqlCommand selectCommand27 = new SqlCommand(cmdText30, con);
						SqlDataAdapter sqlDataAdapter27 = new SqlDataAdapter(selectCommand27);
						DataSet dataSet27 = new DataSet();
						sqlDataAdapter27.Fill(dataSet27, "tblMM_PR_Master");
						if (dataSet27.Tables[0].Rows.Count > 0)
						{
							num16 = Convert.ToInt32(dataSet27.Tables[0].Rows[0]["Id"].ToString());
						}
						string cmdText31 = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + SId + "' And ItemId='" + dataSet.Tables[0].Rows[j]["ItemId"].ToString() + "' And FIN='1'");
						SqlCommand selectCommand28 = new SqlCommand(cmdText31, con);
						SqlDataAdapter sqlDataAdapter28 = new SqlDataAdapter(selectCommand28);
						DataSet dataSet28 = new DataSet();
						sqlDataAdapter28.Fill(dataSet28);
						for (int num17 = 0; num17 < dataSet28.Tables[0].Rows.Count; num17++)
						{
							SqlCommand sqlCommand15 = new SqlCommand(fun.insert("tblMP_Material_Detail", "Mid,ItemId,FIN", "'" + num6 + "','" + dataSet28.Tables[0].Rows[num17]["ItemId"].ToString() + "','" + dataSet28.Tables[0].Rows[num17]["FIN"].ToString() + "'"), con);
							sqlCommand15.ExecuteNonQuery();
							string cmdText32 = fun.select("Id", "tblMP_Material_Detail", "MId='" + num6 + "' AND FIN='1' Order by Id desc");
							SqlCommand selectCommand29 = new SqlCommand(cmdText32, con);
							SqlDataAdapter sqlDataAdapter29 = new SqlDataAdapter(selectCommand29);
							DataSet dataSet29 = new DataSet();
							sqlDataAdapter29.Fill(dataSet29, "tblMP_Material_Detail");
							int num18 = 0;
							if (dataSet29.Tables[0].Rows.Count > 0)
							{
								num18 = Convert.ToInt32(dataSet29.Tables[0].Rows[0]["Id"].ToString());
							}
							string cmdText33 = fun.select("*", "tblMP_Material_Finish_Temp", "DMid='" + dataSet28.Tables[0].Rows[num17]["Id"].ToString() + "'");
							SqlCommand selectCommand30 = new SqlCommand(cmdText33, con);
							SqlDataAdapter sqlDataAdapter30 = new SqlDataAdapter(selectCommand30);
							DataSet dataSet30 = new DataSet();
							sqlDataAdapter30.Fill(dataSet30);
							for (int num19 = 0; num19 < dataSet30.Tables[0].Rows.Count; num19++)
							{
								SqlCommand sqlCommand16 = new SqlCommand(fun.insert("tblMP_Material_Finish", "DMid,SupplierId,Qty,Rate,DelDate,ItemId,Discount", "'" + num18 + "','" + dataSet30.Tables[0].Rows[num19]["SupplierId"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["Qty"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["Rate"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["DelDate"].ToString() + "','" + dataSet28.Tables[0].Rows[num17]["ItemId"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["Discount"].ToString() + "'"), con);
								sqlCommand16.ExecuteNonQuery();
								SqlCommand sqlCommand17 = new SqlCommand(fun.insert("tblMM_PR_Details", "MId,PRNo,ItemId,Qty,SupplierId,Rate,AHId,DelDate,Discount", "'" + num16 + "','" + text2 + "','" + dataSet28.Tables[0].Rows[num17]["ItemId"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["Qty"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["SupplierId"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["Rate"].ToString() + "','28','" + dataSet30.Tables[0].Rows[num19]["DelDate"].ToString() + "','" + dataSet30.Tables[0].Rows[num19]["Discount"].ToString() + "'"), con);
								sqlCommand17.ExecuteNonQuery();
							}
						}
					}
					con.Close();
					string text7 = text + " and PRNo:" + text2;
					Page.Response.Redirect("Planning_New.aspx?ModId=4&SubModId=33&msg=" + text7);
				}
				else
				{
					string empty2 = string.Empty;
					empty2 = "Invalid data entry found.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty3 = string.Empty;
				empty3 = "Invalid data entry found.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	public void Insfun(string tbl, int DMid, string SupId, double Qty, double Rate, string DelDate, double Discount)
	{
		string cmdText = fun.insert(tbl, "DMid,SupplierId,Qty,Rate,DelDate,Discount", DMid + ",'" + SupId + "','" + Qty + "','" + Rate + "','" + DelDate + "','" + Discount + "'");
		SqlCommand sqlCommand = new SqlCommand(cmdText, con);
		con.Open();
		sqlCommand.ExecuteNonQuery();
		con.Close();
	}

	protected void RadButton2_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("Planning_New.aspx?ModId=4&SubModId=33");
	}
}
