using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_TPL_Design_Assembly_New : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string sId = "";

	private string wono = "";

	private string PageUrl = "";

	private string connStr = "";

	private int CompId;

	private int FinYearId;

	protected Label Label9;

	protected Label lblWo;

	protected GridView GridView2;

	protected Button btncancel;

	protected Label lblMsg1;

	protected Label lblMsg;

	protected SqlDataSource SqlDataSource1;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			PageUrl = base.Request.QueryString["PgUrl"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			con.Open();
			wono = base.Request.QueryString["WONo"].ToString();
			lblWo.Text = wono;
			string cmdText = fun.select1("EquipmentNo", "tblDG_BOM_Master Order by Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string empty = string.Empty;
			empty = ((dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0]["EquipmentNo"] == "" || dataSet.Tables[0].Rows[0]["EquipmentNo"] == DBNull.Value) ? "00001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["EquipmentNo"]) + 1).ToString("D4"));
			string text = fun.select("tblDG_BOM_Master.EquipmentNo,tblDG_BOM_Master.UnitNo,tblDG_BOM_Master.PartNo,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.Qty", "tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND PId='0' AND tblDG_BOM_Master.CompId='" + CompId + "'AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id Order by tblDG_BOM_Master.ItemId Desc");
			if (!base.IsPostBack)
			{
				fun.fillGrid(text, GridView2);
			}
			SqlCommand sqlCommand = new SqlCommand(text, con);
			sqlCommand.ExecuteNonQuery();
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					if (dataSet2.Tables[0].Rows[i]["FileName"].ToString() == "" && dataSet2.Tables[0].Rows[i]["FileName"] == DBNull.Value)
					{
						GridView2.Rows[i].Cells[11].Text = string.Concat("&nbsp;<a href='BOM_UploadDrw.aspx?WONo=", wono, "&PgUrl=BOM_Design_WO_TreeView.aspx&ModId=3&SubModId=26&Id=", dataSet2.Tables[0].Rows[i]["Id"], "' target='_self'>[ Upload ]</a>");
					}
				}
			}
			else
			{
				((Label)GridView2.Controls[0].Controls[0].FindControl("lblEquipNo1")).Text = empty;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		string text = base.Request.QueryString["PgUrl"].ToString();
		string text2 = base.Request.QueryString["WONo"].ToString();
		base.Response.Redirect(text + "?WONo=" + text2 + "&ModId=3&SubModId=26");
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		string sql = fun.select("tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.FileName,tblDG_Item_Master.ItemCode,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.Qty", "tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND PId='0' AND tblDG_BOM_Master.CompId='" + CompId + "'AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id  Order by tblDG_BOM_Master.ItemId Desc");
		fun.fillGrid(sql, GridView2);
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		connStr = fun.Connection();
		con = new SqlConnection(connStr);
		con.Open();
		string currDate = fun.getCurrDate();
		string currTime = fun.getCurrTime();
		if (e.CommandName == "Insert1")
		{
			try
			{
				GridViewRow gridViewRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
				string cmdText = fun.select1("EquipmentNo", "tblDG_BOM_Master Order by Id Desc");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string empty = string.Empty;
				empty = ((dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0]["EquipmentNo"] == DBNull.Value) ? "00001" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["EquipmentNo"]) + 1).ToString("D5"));
				string text = ((TextBox)gridViewRow.FindControl("txtUnitNo1")).Text;
				string text2 = ((TextBox)gridViewRow.FindControl("txtPartNo1")).Text;
				string text3 = empty + "-" + text + "-" + text2 + "0";
				string text4 = empty + "-" + text + "-" + text2;
				string text5 = "0";
				int num = fun.ItemCodeLimit(CompId);
				if (num == text3.Length)
				{
					DataSet dataSet2 = new DataSet();
					string cmdText2 = fun.select("*", "tblDG_Item_Master", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' AND ItemCode='" + text3 + "'");
					SqlCommand sqlCommand = new SqlCommand(cmdText2, con);
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand);
					sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
					sqlCommand.ExecuteNonQuery();
					if (dataSet2.Tables[0].Rows.Count == 0)
					{
						if (fun.NumberValidationQty(((TextBox)gridViewRow.FindControl("txtQuntity1")).Text) && ((TextBox)gridViewRow.FindControl("txtQuntity1")).Text != "")
						{
							double num2 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow.FindControl("txtQuntity1")).Text.ToString()).ToString("N3"));
							string text6 = "";
							HttpPostedFile postedFile = ((FileUpload)gridViewRow.FindControl("DrwUpload1")).PostedFile;
							byte[] array = null;
							if (((FileUpload)gridViewRow.FindControl("DrwUpload1")).PostedFile != null)
							{
								Stream inputStream = ((FileUpload)gridViewRow.FindControl("DrwUpload1")).PostedFile.InputStream;
								BinaryReader binaryReader = new BinaryReader(inputStream);
								array = binaryReader.ReadBytes((int)inputStream.Length);
								text6 = Path.GetFileName(postedFile.FileName);
							}
							string text7 = "";
							double num3 = 0.0;
							string text8 = "";
							HttpPostedFile postedFile2 = ((FileUpload)gridViewRow.FindControl("OtherUpload1")).PostedFile;
							byte[] array2 = null;
							if (((FileUpload)gridViewRow.FindControl("OtherUpload1")).PostedFile != null)
							{
								Stream inputStream2 = ((FileUpload)gridViewRow.FindControl("OtherUpload1")).PostedFile.InputStream;
								BinaryReader binaryReader2 = new BinaryReader(inputStream2);
								array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
								text7 = Path.GetFileName(postedFile2.FileName);
								num3 = array2.Length;
								text8 = postedFile2.ContentType;
							}
							string text9 = fun.FromDate(fun.getOpeningDate(CompId, FinYearId));
							string cmdText3 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PartNo,Process,ItemCode,ManfDesc,UOMBasic,FileName,FileSize,ContentType,FileData,OpeningBalDate,OpeningBalQty,AttName,AttSize,AttContentType,AttData", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + text4 + "','" + text5 + "','" + text3 + "','" + ((TextBox)gridViewRow.FindControl("txtManfDescription1")).Text + "','" + ((DropDownList)gridViewRow.FindControl("DDLUnitBasic1")).SelectedValue + "','" + text6 + "','" + array.Length + "','" + postedFile.ContentType + "',@Data,'" + text9 + "','0','" + text7 + "','" + num3 + "','" + text8 + "',@AttData");
							SqlCommand sqlCommand2 = new SqlCommand(cmdText3, con);
							sqlCommand2.Parameters.AddWithValue("@Data", array);
							sqlCommand2.Parameters.AddWithValue("@AttData", array2);
							fun.InsertUpdateData(sqlCommand2);
							string cmdText4 = fun.select("tblDG_Item_Master.Id", "tblDG_Item_Master", "  tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'  Order by tblDG_Item_Master.Id Desc");
							SqlCommand selectCommand2 = new SqlCommand(cmdText4, con);
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand2);
							DataSet dataSet3 = new DataSet();
							sqlDataAdapter3.Fill(dataSet3);
							int bOMCId = fun.getBOMCId(wono, CompId, FinYearId);
							if (dataSet3.Tables[0].Rows.Count > 0)
							{
								string cmdText5 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,EquipmentNo,UnitNo,PartNo,ItemId,Qty,CId,PId", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + wono + "','" + empty + "','" + text + "','" + text2 + "','" + Convert.ToInt32(dataSet3.Tables[0].Rows[0]["Id"]) + "','" + num2 + "','" + bOMCId + "','0'");
								SqlCommand sqlCommand3 = new SqlCommand(cmdText5, con);
								sqlCommand3.ExecuteNonQuery();
							}
							string cmdText6 = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + wono + "' And  CompId='" + CompId + "' ");
							SqlCommand sqlCommand4 = new SqlCommand(cmdText6, con);
							sqlCommand4.ExecuteNonQuery();
							Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
						}
					}
					else
					{
						string empty2 = string.Empty;
						empty2 = "Equipment is Already exists.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty2 + "');", addScriptTags: true);
					}
				}
				else
				{
					string empty3 = string.Empty;
					empty3 = "Item code is invalid.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty3 + "');", addScriptTags: true);
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
		if (!(e.CommandName == "Insert"))
		{
			return;
		}
		try
		{
			GridViewRow gridViewRow2 = (GridViewRow)((Button)e.CommandSource).NamingContainer;
			string cmdText7 = fun.select1("EquipmentNo", "tblDG_BOM_Master Order by Id Desc");
			SqlCommand selectCommand3 = new SqlCommand(cmdText7, con);
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand3);
			DataSet dataSet4 = new DataSet();
			sqlDataAdapter4.Fill(dataSet4);
			string empty4 = string.Empty;
			empty4 = ((dataSet4.Tables[0].Rows.Count <= 0 || dataSet4.Tables[0].Rows[0]["EquipmentNo"] == DBNull.Value) ? "00001" : (Convert.ToInt32(dataSet4.Tables[0].Rows[0]["EquipmentNo"]) + 1).ToString("D5"));
			string text10 = ((TextBox)gridViewRow2.FindControl("txtUnitNo")).Text;
			string text11 = ((TextBox)gridViewRow2.FindControl("txtPartNo")).Text;
			string text12 = empty4 + "-" + text10 + "-" + text11 + "0";
			string text13 = empty4 + "-" + text10 + "-" + text11;
			string text14 = "0";
			int num4 = fun.ItemCodeLimit(CompId);
			if (num4 == text12.Length)
			{
				DataSet dataSet5 = new DataSet();
				string cmdText8 = fun.select("*", "tblDG_Item_Master", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "' AND ItemCode='" + text12 + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText8, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
				sqlDataAdapter5.Fill(dataSet5, "tblDG_Item_Master");
				sqlCommand5.ExecuteNonQuery();
				if (dataSet5.Tables[0].Rows.Count == 0)
				{
					if (fun.NumberValidationQty(((TextBox)gridViewRow2.FindControl("txtQuntity")).Text) && ((TextBox)gridViewRow2.FindControl("txtQuntity")).Text != "")
					{
						double num5 = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow2.FindControl("txtQuntity")).Text.ToString()).ToString("N3"));
						string text15 = "";
						HttpPostedFile postedFile3 = ((FileUpload)gridViewRow2.FindControl("DrwUpload")).PostedFile;
						byte[] array3 = null;
						if (((FileUpload)gridViewRow2.FindControl("DrwUpload")).PostedFile != null)
						{
							Stream inputStream3 = ((FileUpload)gridViewRow2.FindControl("DrwUpload")).PostedFile.InputStream;
							BinaryReader binaryReader3 = new BinaryReader(inputStream3);
							array3 = binaryReader3.ReadBytes((int)inputStream3.Length);
							text15 = Path.GetFileName(postedFile3.FileName);
						}
						string text16 = "";
						double num6 = 0.0;
						string text17 = "";
						HttpPostedFile postedFile4 = ((FileUpload)gridViewRow2.FindControl("OtherUpload")).PostedFile;
						byte[] array4 = null;
						if (((FileUpload)gridViewRow2.FindControl("OtherUpload")).PostedFile != null)
						{
							Stream inputStream4 = ((FileUpload)gridViewRow2.FindControl("OtherUpload")).PostedFile.InputStream;
							BinaryReader binaryReader4 = new BinaryReader(inputStream4);
							array4 = binaryReader4.ReadBytes((int)inputStream4.Length);
							text16 = Path.GetFileName(postedFile4.FileName);
							num6 = array4.Length;
							text17 = postedFile4.ContentType;
						}
						string text18 = fun.FromDate(fun.getOpeningDate(CompId, FinYearId));
						string cmdText9 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,PartNo,Process,ItemCode,ManfDesc,UOMBasic,FileName,FileSize,ContentType,FileData,OpeningBalDate,OpeningBalQty,AttName,AttSize,AttContentType,AttData", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + text13 + "','" + text14 + "','" + text12 + "','" + ((TextBox)gridViewRow2.FindControl("txtManfDescription")).Text + "','" + ((DropDownList)gridViewRow2.FindControl("DDLUnitBasic")).SelectedValue + "','" + text15 + "','" + array3.Length + "','" + postedFile3.ContentType + "',@Data,'" + text18 + "','0','" + text16 + "','" + num6 + "','" + text17 + "',@AttData");
						SqlCommand sqlCommand6 = new SqlCommand(cmdText9, con);
						sqlCommand6.Parameters.AddWithValue("@Data", array3);
						sqlCommand6.Parameters.AddWithValue("@AttData", array4);
						fun.InsertUpdateData(sqlCommand6);
						string cmdText10 = fun.select("tblDG_Item_Master.Id", "tblDG_Item_Master", "  tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FinYearId + "'  Order by tblDG_Item_Master.Id Desc");
						SqlCommand selectCommand4 = new SqlCommand(cmdText10, con);
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand4);
						DataSet dataSet6 = new DataSet();
						sqlDataAdapter6.Fill(dataSet6);
						int bOMCId2 = fun.getBOMCId(wono, CompId, FinYearId);
						string cmdText11 = fun.insert("tblDG_BOM_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,EquipmentNo,UnitNo,PartNo,ItemId,Qty,CId,PId", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + wono + "','" + empty4 + "','" + text10 + "','" + text11 + "','" + Convert.ToInt32(dataSet6.Tables[0].Rows[0]["Id"]) + "','" + num5 + "','" + bOMCId2 + "','0'");
						SqlCommand sqlCommand7 = new SqlCommand(cmdText11, con);
						sqlCommand7.ExecuteNonQuery();
						string cmdText12 = fun.update("SD_Cust_WorkOrder_Master", "UpdateWO='1'", "WONo='" + wono + "' And  CompId='" + CompId + "' ");
						SqlCommand sqlCommand8 = new SqlCommand(cmdText12, con);
						sqlCommand8.ExecuteNonQuery();
						Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
					}
				}
				else
				{
					string empty5 = string.Empty;
					empty5 = "Equipment is Already exists.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty5 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty6 = string.Empty;
				empty6 = "Item code is invalid.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty6 + "');", addScriptTags: true);
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
}
