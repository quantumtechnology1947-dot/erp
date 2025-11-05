using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_BOM_Design_Assembly_Edit : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string wono = "";

	private string sId = "";

	private int CompId;

	private int ItemId;

	private int FinYearId;

	private string msg = "";

	protected Label lblWONo;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView2;

	protected Button Button2;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sId = Session["username"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			wono = base.Request.QueryString["WONo"].ToString();
			ItemId = Convert.ToInt32(base.Request.QueryString["ItemId"].ToString());
			lblWONo.Text = wono;
			string sql = fun.select("tblDG_BOM_Master.Id,tblDG_Item_Master.UOMBasic,tblDG_BOM_Master.AmdNo,tblDG_BOM_Master.EquipmentNo,tblDG_BOM_Master.UnitNo,tblDG_BOM_Master.PartNo,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOM,tblDG_BOM_Master.Qty,tblDG_BOM_Master.Revision", "tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND PId='0' AND tblDG_BOM_Master.CompId='" + CompId + "'AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And tblDG_Item_Master.Id='" + ItemId + "' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id Order by tblDG_BOM_Master.ItemId Desc");
			if (!base.IsPostBack)
			{
				fun.fillGrid(sql, GridView2);
			}
			foreach (GridViewRow row in GridView2.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
				string cmdText = fun.select("tblDG_Item_Master.FileName,tblDG_Item_Master.AttName ", "tblDG_Item_Master,tblDG_BOM_Master", "tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId     And tblDG_BOM_Master.WONo='" + wono + "' and tblDG_Item_Master.FinYearId<='" + FinYearId + "'   And  tblDG_BOM_Master.ItemId='" + num + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[0]["FileName"] != DBNull.Value)
				{
					((ImageButton)row.FindControl("ImageButton1")).Visible = true;
				}
				else
				{
					((ImageButton)row.FindControl("ImageButton1")).Visible = false;
				}
				if (dataSet.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet.Tables[0].Rows[0]["AttName"] != DBNull.Value)
				{
					((ImageButton)row.FindControl("ImageButton2")).Visible = true;
				}
				else
				{
					((ImageButton)row.FindControl("ImageButton2")).Visible = false;
				}
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

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView2.PageIndex = e.NewPageIndex;
			string sql = fun.select("tblDG_BOM_Master.Id,,tblDG_Item_Master.UOMBasic,tblDG_BOM_Master.AmdNo,tblDG_BOM_Master.EquipmentNo,tblDG_BOM_Master.UnitNo,tblDG_BOM_Master.PartNo,tblDG_BOM_Master.CId,tblDG_BOM_Master.ItemId,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOM,tblDG_BOM_Master.Qty", "tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND PId='0' AND tblDG_BOM_Master.CompId='" + CompId + "'AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "' And tblDG_Item_Master.Id='" + ItemId + "' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id Order by tblDG_BOM_Master.ItemId Desc");
			fun.fillGrid(sql, GridView2);
		}
		catch (Exception)
		{
		}
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			if (e.CommandName == "Edt")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				((TextBox)gridViewRow.FindControl("txtQuntity")).Visible = true;
				((TextBox)gridViewRow.FindControl("txtRevision")).Visible = true;
				((TextBox)gridViewRow.FindControl("txtManfDescription")).Visible = true;
				((DropDownList)gridViewRow.FindControl("DDLUnitBasic")).Visible = true;
				((DropDownList)gridViewRow.FindControl("DDLUnitBasic")).SelectedValue = ((Label)gridViewRow.FindControl("LblUom")).Text;
				((LinkButton)gridViewRow.FindControl("BtnUpdate")).Visible = true;
				((LinkButton)gridViewRow.FindControl("BtnCancel")).Visible = true;
				((LinkButton)gridViewRow.FindControl("BtnEdIt")).Visible = false;
				((Label)gridViewRow.FindControl("Label3")).Visible = false;
				((Label)gridViewRow.FindControl("Label4")).Visible = false;
				((Label)gridViewRow.FindControl("Label5")).Visible = false;
				((Label)gridViewRow.FindControl("lblRevision")).Visible = false;
				if (!((ImageButton)gridViewRow.FindControl("ImageButton2")).Visible)
				{
					((FileUpload)gridViewRow.FindControl("OtherUpload")).Visible = true;
					((HyperLink)gridViewRow.FindControl("HyperLink2")).Visible = false;
				}
				if (!((ImageButton)gridViewRow.FindControl("ImageButton1")).Visible)
				{
					((FileUpload)gridViewRow.FindControl("DrwUpload")).Visible = true;
					((HyperLink)gridViewRow.FindControl("HyperLink1")).Visible = false;
				}
			}
			if (e.CommandName == "Can")
			{
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Upd")
			{
				GridViewRow gridViewRow2 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				string currDate = fun.getCurrDate();
				string currTime = fun.getCurrTime();
				sqlConnection.Open();
				if (fun.NumberValidationQty(((TextBox)gridViewRow2.FindControl("txtQuntity")).Text) && ((TextBox)gridViewRow2.FindControl("txtQuntity")).Text != "" && ((TextBox)gridViewRow2.FindControl("txtManfDescription")).Text != "" && ((TextBox)gridViewRow2.FindControl("txtRevision")).Text != "")
				{
					double num = Convert.ToDouble(decimal.Parse(((TextBox)gridViewRow2.FindControl("txtQuntity")).Text.ToString()).ToString("N3"));
					string text = ((TextBox)gridViewRow2.FindControl("txtRevision")).Text;
					string text2 = ((TextBox)gridViewRow2.FindControl("txtManfDescription")).Text;
					string selectedValue = ((DropDownList)gridViewRow2.FindControl("DDLUnitBasic")).SelectedValue;
					int num2 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblId")).Text);
					int num3 = Convert.ToInt32(((Label)gridViewRow2.FindControl("lblItemId")).Text);
					string text3 = "";
					HttpPostedFile postedFile = ((FileUpload)gridViewRow2.FindControl("DrwUpload")).PostedFile;
					byte[] array = null;
					if (((FileUpload)gridViewRow2.FindControl("DrwUpload")).PostedFile != null)
					{
						Stream inputStream = ((FileUpload)gridViewRow2.FindControl("DrwUpload")).PostedFile.InputStream;
						BinaryReader binaryReader = new BinaryReader(inputStream);
						array = binaryReader.ReadBytes((int)inputStream.Length);
						text3 = Path.GetFileName(postedFile.FileName);
						string cmdText = fun.update("tblDG_Item_Master", "FileName='" + text3 + "',FileSize='" + array.Length + "',ContentType='" + postedFile.ContentType + "',FileData= @Data  ", "Id='" + num3 + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
						sqlCommand.Parameters.AddWithValue("@Data", array);
						sqlCommand.ExecuteNonQuery();
					}
					string text4 = "";
					double num4 = 0.0;
					string text5 = "";
					HttpPostedFile postedFile2 = ((FileUpload)gridViewRow2.FindControl("OtherUpload")).PostedFile;
					byte[] array2 = null;
					if (((FileUpload)gridViewRow2.FindControl("OtherUpload")).PostedFile != null)
					{
						Stream inputStream2 = ((FileUpload)gridViewRow2.FindControl("OtherUpload")).PostedFile.InputStream;
						BinaryReader binaryReader2 = new BinaryReader(inputStream2);
						array2 = binaryReader2.ReadBytes((int)inputStream2.Length);
						text4 = Path.GetFileName(postedFile2.FileName);
						num4 = array2.Length;
						text5 = postedFile2.ContentType;
						string cmdText2 = fun.update("tblDG_Item_Master", "AttName='" + text4 + "',AttSize='" + num4 + "',AttContentType='" + text5 + "',AttData= @AttData  ", "Id='" + num3 + "'");
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
						sqlCommand2.Parameters.AddWithValue("@AttData", array2);
						sqlCommand2.ExecuteNonQuery();
					}
					string text6 = fun.FromDate(fun.getOpeningDate(CompId, FinYearId));
					string cmdText3 = fun.select("*", "tblDG_BOM_Master", "Id='" + num2 + "'");
					SqlCommand selectCommand = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					string text7 = ((Label)gridViewRow2.FindControl("Label3")).Text;
					string text8 = ((Label)gridViewRow2.FindControl("LblUom")).Text;
					string text9 = "";
					text9 = ((dataSet.Tables[0].Rows.Count <= 0 || dataSet.Tables[0].Rows[0]["AmdNo"] == DBNull.Value) ? "0" : (Convert.ToInt32(dataSet.Tables[0].Rows[0]["AmdNo"].ToString()) + 1).ToString());
					string cmdText4 = fun.insert("tblDG_BOM_Amd", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,BOMId,PId,CId,ItemId,Description,UOM,AmdNo,Qty", "'" + currDate.ToString() + "','" + currTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + wono + "','" + num2 + "','" + dataSet.Tables[0].Rows[0]["PId"].ToString() + "','" + dataSet.Tables[0].Rows[0]["CId"].ToString() + "', '" + dataSet.Tables[0].Rows[0]["ItemId"].ToString() + "' , '" + text7 + "', '" + text8 + "','" + dataSet.Tables[0].Rows[0]["AmdNo"].ToString() + "','" + dataSet.Tables[0].Rows[0]["Qty"].ToString() + "' ");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
					string cmdText5 = fun.update("tblDG_Item_Master", "SysDate='" + currDate.ToString() + "',SysTime='" + currTime.ToString() + "',SessionId='" + sId.ToString() + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',ManfDesc='" + text2.ToString() + "',UOMBasic='" + selectedValue + "',OpeningBalDate='" + text6 + "',OpeningBalQty='0'", "Id='" + num3 + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText5, sqlConnection);
					sqlCommand4.ExecuteNonQuery();
					string cmdText6 = fun.update("tblDG_BOM_Master", "SessionId='" + sId.ToString() + "',CompId='" + CompId + "',FinYearId='" + FinYearId + "',WONo='" + wono + "',Qty='" + num + "',AmdNo='" + text9 + "',Revision='" + text + "'", "Id='" + num2 + "'");
					SqlCommand sqlCommand5 = new SqlCommand(cmdText6, sqlConnection);
					sqlCommand5.ExecuteNonQuery();
					msg = "BOM is Updated sucessfully.";
					sqlConnection.Close();
					Page.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&msg=" + msg + "&ModId=3&SubModId=26");
				}
			}
			if (e.CommandName == "Del")
			{
				sqlConnection.Open();
				GridViewRow gridViewRow3 = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num5 = Convert.ToInt32(((Label)gridViewRow3.FindControl("lblItemId")).Text);
				int num6 = Convert.ToInt32(((Label)gridViewRow3.FindControl("lblId")).Text);
				string cmdText7 = fun.delete("tblDG_Item_Master", "Id='" + num5 + "'");
				SqlCommand sqlCommand6 = new SqlCommand(cmdText7, sqlConnection);
				sqlCommand6.ExecuteNonQuery();
				string cmdText8 = fun.delete("tblDG_BOM_Master", "Id='" + num6 + "'");
				new SqlCommand(cmdText8, sqlConnection);
				sqlCommand6.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Del1")
			{
				sqlConnection.Open();
				GridViewRow gridViewRow4 = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
				int num7 = Convert.ToInt32(((Label)gridViewRow4.FindControl("lblItemId")).Text);
				string cmdText9 = fun.update("tblDG_Item_Master", "FileName=NULL,FileSize=NULL,ContentType=NULL,FileData=NULL", "Id='" + num7 + "'");
				SqlCommand sqlCommand7 = new SqlCommand(cmdText9, sqlConnection);
				sqlCommand7.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			if (e.CommandName == "Del2")
			{
				sqlConnection.Open();
				GridViewRow gridViewRow5 = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
				int num8 = Convert.ToInt32(((Label)gridViewRow5.FindControl("lblItemId")).Text);
				string cmdText10 = fun.update("tblDG_Item_Master", "AttName=NULL,AttSize=NULL,AttContentType=NULL,AttData=NULL", "Id='" + num8 + "'");
				SqlCommand sqlCommand8 = new SqlCommand(cmdText10, sqlConnection);
				sqlCommand8.ExecuteNonQuery();
				sqlConnection.Close();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void Button2_Click(object sender, EventArgs e)
	{
		Page.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
	}
}
