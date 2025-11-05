using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Design_Masters_ItemMaster_Edit_Details : Page, IRequiresSessionState
{
	protected Label Label2;

	protected DropDownList DrpCategory;

	protected Label Label4;

	protected TextBox TxtPartNo;

	protected Label Label7;

	protected TextBox TxtManfDesc;

	protected RequiredFieldValidator RequiredFieldValidator4;

	protected Label Label9;

	protected DropDownList DrpUOMBasic;

	protected RequiredFieldValidator ReqUOM;

	protected Label Label19;

	protected RadioButtonList RadioButtonList1;

	protected Label Label13;

	protected TextBox TxtStockQty;

	protected RegularExpressionValidator RegStkQty;

	protected Label Label20;

	protected DropDownList drpclass;

	protected Label Label11;

	protected TextBox TxtMinorderQty;

	protected RegularExpressionValidator RegStkQty2;

	protected Label Label22;

	protected TextBox txtInspdays;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected Label Label12;

	protected TextBox TxtMinStockQty;

	protected RegularExpressionValidator RegStkQty1;

	protected Label Label14;

	protected DropDownList DrpLocation;

	protected RequiredFieldValidator ReqLoc;

	protected Label Label18;

	protected TextBox TxtOpeningBalQty;

	protected RegularExpressionValidator RegStkQty0;

	protected Label Label17;

	protected TextBox TxtOpeningBalDate;

	protected CalendarExtender TxtOpeningBalDate_CalendarExtender;

	protected Label Label21;

	protected TextBox txtleaddays;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected Label Label23;

	protected RadioButtonList RadioButtonList2;

	protected Label Label24;

	protected RadioButtonList RadioButtonList3;

	protected Label Label16;

	protected CheckBox CheckAbsolute;

	protected Label Label25;

	protected FileUpload FileUpload3;

	protected Label lbldownload;

	protected ImageButton imgUpload0;

	protected DropDownList DrpBuyer;

	protected Label Label15;

	protected FileUpload FileUpload1;

	protected Label lbluploadImg;

	protected ImageButton imgUpload;

	protected Label lblAHId;

	protected RadioButtonList RadioButtonList4;

	protected DropDownList DrpAChead;

	protected Panel Panel1;

	protected Button BtnUpdate;

	protected Button BtnCancel;

	protected SqlDataSource SqlDataSource3;

	protected SqlDataSource SqlDataSource2;

	protected GridView GridView2;

	protected Panel Panel2;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS1 = new DataSet();

	private int CompId;

	private int id;

	private string sId = "";

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			id = Convert.ToInt32(base.Request.QueryString["ItemId"]);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			TxtOpeningBalDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				string cmdText = fun.select("CId,Symbol+'-'+CName as cat", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS1, "tblDG_Category_Master");
				DrpCategory.DataSource = DS1.Tables["tblDG_Category_Master"];
				DrpCategory.DataTextField = "cat";
				DrpCategory.DataValueField = "CId";
				DrpCategory.DataBind();
				DrpCategory.Items.Insert(0, "Select");
				string cmdText2 = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.Buyer,tblDG_Item_Master.PartNo,tblDG_Item_Master.Excise ,tblDG_Item_Master.ImportLocal,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.CId,tblDG_Item_Master.UOMBasic,tblDG_Item_Master.MinOrderQty ,tblDG_Item_Master.MinStockQty,tblDG_Item_Master.StockQty ,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate  ,tblDG_Item_Master.OpeningBalQty ,tblDG_Item_Master.Absolute,tblDG_Item_Master.UOMConFact,tblDG_Item_Master.FileName,tblDG_Item_Master.Location,tblDG_Item_Master.AttName,Class", "tblDG_Item_Master", "tblDG_Item_Master.Id='" + id + "'And CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet = new DataSet();
				sqlDataAdapter2.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					DrpCategory.SelectedValue = dataSet.Tables[0].Rows[0]["CId"].ToString();
					if (dataSet.Tables[0].Rows[0]["Buyer"] != DBNull.Value)
					{
						DrpBuyer.SelectedValue = dataSet.Tables[0].Rows[0]["Buyer"].ToString();
					}
					TxtPartNo.Text = dataSet.Tables[0].Rows[0]["PartNo"].ToString();
					TxtManfDesc.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
					fun.drpunit(DrpUOMBasic);
					DrpUOMBasic.SelectedValue = dataSet.Tables[0].Rows[0]["UOMBasic"].ToString();
					TxtMinorderQty.Text = dataSet.Tables[0].Rows[0]["MinOrderQty"].ToString();
					TxtMinStockQty.Text = dataSet.Tables[0].Rows[0]["MinStockQty"].ToString();
					TxtStockQty.Text = dataSet.Tables[0].Rows[0]["StockQty"].ToString();
					fun.drpLocat(DrpLocation);
					string cmdText3 = fun.select("Id", "tblDG_Location_Master", "Id='" + dataSet.Tables[0].Rows[0]["Location"].ToString() + "'");
					SqlCommand selectCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
					DataSet dataSet2 = new DataSet();
					sqlDataAdapter3.Fill(dataSet2);
					if (dataSet2.Tables[0].Rows.Count > 0)
					{
						DrpLocation.SelectedValue = dataSet2.Tables[0].Rows[0]["Id"].ToString();
					}
					int num = Convert.ToInt32(dataSet.Tables[0].Rows[0]["Absolute"].ToString());
					if (num > 0)
					{
						CheckAbsolute.Checked = true;
					}
					TxtOpeningBalDate.Text = dataSet.Tables[0].Rows[0]["OpenBalDate"].ToString();
					TxtOpeningBalQty.Text = dataSet.Tables[0].Rows[0]["OpeningBalQty"].ToString();
					if (dataSet.Tables[0].Rows[0]["UOMConFact"] != DBNull.Value)
					{
						if (dataSet.Tables[0].Rows[0]["UOMConFact"].ToString() == "1")
						{
							RadioButtonList1.SelectedValue = "1";
						}
						else
						{
							RadioButtonList1.SelectedValue = "0";
						}
					}
					if (dataSet.Tables[0].Rows[0]["Class"] != DBNull.Value && dataSet.Tables[0].Rows[0]["Class"].ToString() != "")
					{
						if (dataSet.Tables[0].Rows[0]["Class"].ToString() != "0")
						{
							drpclass.SelectedValue = dataSet.Tables[0].Rows[0]["Class"].ToString();
						}
						else
						{
							drpclass.Items.Insert(0, "NA");
						}
					}
					if (dataSet.Tables[0].Rows[0]["Excise"] != DBNull.Value)
					{
						if (dataSet.Tables[0].Rows[0]["Excise"].ToString() == "1")
						{
							RadioButtonList3.SelectedValue = "1";
						}
						else
						{
							RadioButtonList3.SelectedValue = "0";
						}
					}
					if (dataSet.Tables[0].Rows[0]["ImportLocal"] != DBNull.Value)
					{
						if (dataSet.Tables[0].Rows[0]["ImportLocal"].ToString() == "1")
						{
							RadioButtonList2.SelectedValue = "1";
						}
						else
						{
							RadioButtonList2.SelectedValue = "0";
						}
					}
					imgUpload.Visible = false;
					FileUpload1.Visible = true;
					if (dataSet.Tables[0].Rows[0]["FileName"].ToString() != "" && dataSet.Tables[0].Rows[0]["FileName"] != DBNull.Value)
					{
						imgUpload.Visible = true;
						lbluploadImg.Text = "&nbsp;<a href='../../../Controls/DownloadFile.aspx?Id=" + id + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType'>" + dataSet.Tables[0].Rows[0]["FileName"].ToString() + "</a>";
						FileUpload1.Visible = false;
					}
					imgUpload0.Visible = false;
					FileUpload3.Visible = true;
					if (dataSet.Tables[0].Rows[0]["AttName"].ToString() != "" && dataSet.Tables[0].Rows[0]["AttName"] != DBNull.Value)
					{
						imgUpload0.Visible = true;
						lbldownload.Text = "&nbsp;<a href='../../../Controls/DownloadFile.aspx?Id=" + id + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType'>" + dataSet.Tables[0].Rows[0]["AttName"].ToString() + "</a>";
						FileUpload3.Visible = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["CId"] != DBNull.Value)
				{
					string cmdText4 = fun.select("AHId", " tblDG_Item_Master ", " Id='" + id + "' ");
					SqlCommand selectCommand4 = new SqlCommand(cmdText4, sqlConnection);
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
					DataSet dataSet3 = new DataSet();
					sqlDataAdapter4.Fill(dataSet3);
					if (dataSet3.Tables[0].Rows.Count > 0 && dataSet3.Tables[0].Rows[0][0] != DBNull.Value)
					{
						int num2 = Convert.ToInt32(dataSet3.Tables[0].Rows[0][0].ToString());
						string cmdText5 = fun.select("Category", " AccHead ", "Id='" + num2 + "'");
						SqlCommand selectCommand5 = new SqlCommand(cmdText5, sqlConnection);
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
						DataSet dataSet4 = new DataSet();
						sqlDataAdapter5.Fill(dataSet4);
						if (dataSet4.Tables[0].Rows.Count > 0)
						{
							switch (dataSet4.Tables[0].Rows[0][0].ToString())
							{
							case "Labour":
								RadioButtonList4.SelectedValue = "1";
								fun.AcHead(DrpAChead, 1);
								break;
							case "With Material":
								RadioButtonList4.SelectedValue = "2";
								fun.AcHead(DrpAChead, 2);
								break;
							case "Expenses":
								RadioButtonList4.SelectedValue = "3";
								fun.AcHead(DrpAChead, 3);
								break;
							case "Service Material":
								RadioButtonList4.SelectedValue = "4";
								fun.AcHead(DrpAChead, 4);
								break;
							}
						}
						DrpAChead.SelectedValue = dataSet3.Tables[0].Rows[0][0].ToString();
					}
				}
				else
				{
					lblAHId.Enabled = false;
					RadioButtonList4.Enabled = false;
					DrpAChead.Enabled = false;
					drpclass.Enabled = false;
					RadioButtonList1.Enabled = false;
					RadioButtonList2.Enabled = false;
					RadioButtonList3.Enabled = false;
					TxtStockQty.Enabled = false;
					TxtMinorderQty.Enabled = false;
					TxtMinStockQty.Enabled = false;
					txtInspdays.Enabled = false;
					txtleaddays.Enabled = false;
					TxtOpeningBalDate.Enabled = false;
					TxtOpeningBalQty.Enabled = false;
					CheckAbsolute.Enabled = false;
					DrpBuyer.Enabled = false;
					DrpLocation.Enabled = false;
				}
			}
			Fillgrid();
		}
		catch (Exception)
		{
		}
		finally
		{
			sqlConnection.Close();
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		Fillgrid();
	}

	public void Fillgrid()
	{
		string connectionString = fun.Connection();
		SqlConnection connection = new SqlConnection(connectionString);
		DataTable dataTable = new DataTable();
		try
		{
			string cmdText = fun.select("Id,ItemCode,ImportLocal,ManfDesc,Excise,MinOrderQty,MinStockQty,StockQty,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( tblDG_Item_Master.OpeningBalDate , CHARINDEX('-',tblDG_Item_Master.OpeningBalDate ) + 1, 2) + '-' + LEFT(tblDG_Item_Master.OpeningBalDate,CHARINDEX('-',tblDG_Item_Master.OpeningBalDate) - 1) + '-' + RIGHT(tblDG_Item_Master.OpeningBalDate, CHARINDEX('-', REVERSE(tblDG_Item_Master.OpeningBalDate)) - 1)), 103), '/', '-') AS  OpenBalDate,OpeningBalQty,Absolute,UOMConFact,CId,UOMBasic,Location,AHId", "tblDG_Item_Master", "Id='" + id + "'And CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'Order By Id Desc");
			SqlCommand selectCommand = new SqlCommand(cmdText, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			dataTable.Columns.Add(new DataColumn("Id", typeof(int)));
			dataTable.Columns.Add(new DataColumn("Category", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Excise", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ImportLocal", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ManfDesc", typeof(string)));
			dataTable.Columns.Add(new DataColumn("UOMBasic", typeof(string)));
			dataTable.Columns.Add(new DataColumn("MinOrderQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("MinStockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("StockQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("Location", typeof(string)));
			dataTable.Columns.Add(new DataColumn("Absolute", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpenBalDate", typeof(string)));
			dataTable.Columns.Add(new DataColumn("OpeningBalQty", typeof(double)));
			dataTable.Columns.Add(new DataColumn("UOMConFact", typeof(string)));
			dataTable.Columns.Add(new DataColumn("ItemCode", typeof(string)));
			dataTable.Columns.Add(new DataColumn("AHId", typeof(string)));
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				DataRow dataRow = dataTable.NewRow();
				string cmdText2 = fun.select("Symbol+'-'+CName as Category ", "tblDG_Category_Master", string.Concat("CId='", dataSet.Tables[0].Rows[i]["CId"], "'And CompId='", CompId, "'"));
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				string cmdText3 = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Id='" + dataSet.Tables[0].Rows[i]["AHId"].ToString() + "'");
				SqlCommand selectCommand3 = new SqlCommand(cmdText3, connection);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				if (dataSet3.Tables[0].Rows.Count > 0)
				{
					dataRow[15] = dataSet3.Tables[0].Rows[0]["Head"].ToString();
				}
				else
				{
					dataRow[15] = "NA";
				}
				string cmdText4 = fun.select("Symbol As UOMBasic ", "Unit_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["UOMBasic"], "'"));
				SqlCommand selectCommand4 = new SqlCommand(cmdText4, connection);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				string cmdText5 = fun.select("LocationLabel+'-'+tblDG_Location_Master.LocationNo As Location ", "tblDG_Location_Master", string.Concat("Id='", dataSet.Tables[0].Rows[i]["Location"], "'"));
				SqlCommand selectCommand5 = new SqlCommand(cmdText5, connection);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				dataRow[0] = dataSet.Tables[0].Rows[i]["Id"];
				if (dataSet2.Tables[0].Rows.Count > 0)
				{
					dataRow[1] = dataSet2.Tables[0].Rows[0]["Category"].ToString();
				}
				if (dataSet.Tables[0].Rows[i]["Excise"].ToString() != "0")
				{
					dataRow[2] = "Yes";
				}
				else
				{
					dataRow[2] = "NO";
				}
				if (dataSet.Tables[0].Rows[i]["ImportLocal"].ToString() != "0")
				{
					dataRow[3] = "Yes";
				}
				else
				{
					dataRow[3] = "NO";
				}
				dataRow[4] = dataSet.Tables[0].Rows[i]["ManfDesc"].ToString();
				dataRow[5] = dataSet4.Tables[0].Rows[0]["UOMBasic"].ToString();
				dataRow[6] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["MinOrderQty"].ToString()).ToString("N3"));
				dataRow[7] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["MinStockQty"].ToString()).ToString("N3"));
				dataRow[8] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["StockQty"].ToString()).ToString("N3"));
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					dataRow[9] = dataSet5.Tables[0].Rows[0]["Location"].ToString();
				}
				else
				{
					dataRow[9] = "NA";
				}
				if (dataSet.Tables[0].Rows[i]["Absolute"].ToString() != "0")
				{
					dataRow[10] = "Yes";
				}
				else
				{
					dataRow[10] = "NO";
				}
				dataRow[11] = dataSet.Tables[0].Rows[i]["OpenBalDate"].ToString();
				dataRow[12] = Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["OpeningBalQty"].ToString()).ToString("N3"));
				if (dataSet.Tables[0].Rows[i]["UOMConFact"].ToString() != "0")
				{
					dataRow[13] = "Yes";
				}
				else
				{
					dataRow[13] = "NO";
				}
				dataRow[14] = dataSet.Tables[0].Rows[i]["ItemCode"].ToString();
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

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void BtnUpdate_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		try
		{
			if (FileUpload1.Visible)
			{
				byte[] array = new byte[0];
				int contentLength = FileUpload1.PostedFile.ContentLength;
				string text = "";
				MemoryStream memoryStream = new MemoryStream();
				string text2 = "";
				int num = 0;
				int num2 = 0;
				if (contentLength > 0)
				{
					text = FileUpload1.PostedFile.ContentType;
					System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
					num = image.Height;
					num2 = image.Width;
					int num3 = 135;
					num = 62;
					num2 = num3;
					Bitmap bitmap = new Bitmap(image, num2, num);
					bitmap.Save(memoryStream, ImageFormat.Jpeg);
					memoryStream.Position = 0L;
					array = new byte[contentLength];
					memoryStream.Read(array, 0, contentLength);
					text2 = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
				}
				string cmdText = fun.update("tblDG_Item_Master", "tblDG_Item_Master.FileSize='" + contentLength + "',tblDG_Item_Master.FileData=@pic,tblDG_Item_Master.ContentType='" + text + "',tblDG_Item_Master.FileName='" + text2 + "'", "tblDG_Item_Master.Id='" + id + "' And tblDG_Item_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				sqlCommand.Parameters.AddWithValue("@pic", array);
				sqlCommand.ExecuteNonQuery();
			}
			if (FileUpload3.Visible)
			{
				string text3 = "";
				double num4 = 0.0;
				string text4 = "";
				HttpPostedFile postedFile = FileUpload3.PostedFile;
				byte[] array2 = null;
				if (FileUpload3.PostedFile != null)
				{
					Stream inputStream = FileUpload3.PostedFile.InputStream;
					BinaryReader binaryReader = new BinaryReader(inputStream);
					array2 = binaryReader.ReadBytes((int)inputStream.Length);
					text3 = Path.GetFileName(postedFile.FileName);
					num4 = array2.Length;
					text4 = postedFile.ContentType;
					string cmdText2 = fun.update("tblDG_Item_Master", "tblDG_Item_Master.AttSize='" + num4 + "',tblDG_Item_Master.AttContentType='" + text4 + "',tblDG_Item_Master.AttData=@AttData,tblDG_Item_Master.AttName='" + text3 + "'", "tblDG_Item_Master.Id='" + id + "'And tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					sqlCommand2.Parameters.AddWithValue("@AttData", array2);
					sqlCommand2.ExecuteNonQuery();
				}
			}
			string cmdText3 = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.CId", "tblDG_Item_Master", "tblDG_Item_Master.Id='" + id + "'And CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText3, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			if (dataSet.Tables[0].Rows.Count <= 0)
			{
				return;
			}
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			if (dataSet.Tables[0].Rows[0]["CId"] != DBNull.Value)
			{
				if (DrpUOMBasic.SelectedValue != "Select" && DrpLocation.SelectedValue != "Select" && fun.NumberValidationQty(TxtStockQty.Text) && fun.NumberValidationQty(TxtOpeningBalQty.Text) && fun.NumberValidationQty(TxtMinorderQty.Text) && fun.NumberValidationQty(TxtMinStockQty.Text) && fun.DateValidation(TxtOpeningBalDate.Text))
				{
					string text5 = fun.ToDateDMY(TxtOpeningBalDate.Text);
					string text6 = "";
					if (DrpAChead.Visible)
					{
						text6 = DrpAChead.SelectedValue;
					}
					int num5 = (CheckAbsolute.Checked ? 1 : 0);
					string cmdText4 = fun.update("tblDG_Item_Master", "tblDG_Item_Master.SysDate='" + currDate + "',tblDG_Item_Master.SysTime='" + currTime + "',tblDG_Item_Master.CompId='" + CompId + "',tblDG_Item_Master.finYearId='" + FinYearId + "',tblDG_Item_Master.SessionId='" + sId.ToString() + "',tblDG_Item_Master.ManfDesc='" + TxtManfDesc.Text + "',tblDG_Item_Master.UOMBasic='" + DrpUOMBasic.SelectedValue + "',tblDG_Item_Master.MinOrderQty='" + Convert.ToDouble(decimal.Parse(TxtMinorderQty.Text.ToString()).ToString("N3")) + "',tblDG_Item_Master.MinStockQty='" + Convert.ToDouble(decimal.Parse(TxtMinStockQty.Text.ToString()).ToString("N3")) + "',tblDG_Item_Master.StockQty='" + Convert.ToDouble(decimal.Parse(TxtStockQty.Text.ToString()).ToString("N3")) + "' ,tblDG_Item_Master.Location='" + DrpLocation.SelectedValue + "',tblDG_Item_Master.OpeningBalDate='" + text5 + "',tblDG_Item_Master.OpeningBalQty='" + Convert.ToDouble(decimal.Parse(TxtOpeningBalQty.Text.ToString()).ToString("N3")) + "' ,tblDG_Item_Master.Absolute='" + num5 + "',tblDG_Item_Master.UOMConFact='" + RadioButtonList1.SelectedValue + "',tblDG_Item_Master.Excise='" + RadioButtonList3.SelectedValue + "',tblDG_Item_Master.ImportLocal='" + RadioButtonList2.SelectedValue + "',Buyer='" + DrpBuyer.SelectedValue + "',AHId='" + text6 + "',Class='" + drpclass.SelectedValue + "'", "tblDG_Item_Master.Id='" + id + "'And tblDG_Item_Master.CompId='" + CompId + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText4, sqlConnection);
					sqlCommand3.ExecuteNonQuery();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			else if (DrpUOMBasic.SelectedValue != "Select" && TxtManfDesc.Text != "")
			{
				string cmdText5 = fun.update("tblDG_Item_Master", "tblDG_Item_Master.SysDate='" + currDate + "',tblDG_Item_Master.SysTime='" + currTime + "',tblDG_Item_Master.CompId='" + CompId + "',tblDG_Item_Master.finYearId='" + FinYearId + "',tblDG_Item_Master.SessionId='" + sId.ToString() + "',tblDG_Item_Master.ManfDesc='" + TxtManfDesc.Text + "',tblDG_Item_Master.UOMBasic='" + DrpUOMBasic.SelectedValue + "'", "tblDG_Item_Master.Id='" + id + "'And tblDG_Item_Master.CompId='" + CompId + "'");
				SqlCommand sqlCommand4 = new SqlCommand(cmdText5, sqlConnection);
				sqlCommand4.ExecuteNonQuery();
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
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

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ItemMaster_Edit.aspx?ModId=3&SubModId=21");
	}

	protected void imgUpload_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.update("tblDG_Item_Master", "FileName=NULL,FileData=NULL,FileSize=NULL,ContentType=NULL", "Id='" + id + "' And CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void imgUpload0_Click(object sender, ImageClickEventArgs e)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string cmdText = fun.update("tblDG_Item_Master", "AttName=NULL,AttData=NULL,AttSize=NULL,AttContentType=NULL", "Id='" + id + "' And CompId='" + CompId + "'");
			SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
			Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
		}
		catch (Exception)
		{
		}
	}

	protected void RadioButtonList4_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RadioButtonList4.SelectedValue == "1")
		{
			fun.AcHead(DrpAChead, 1);
		}
		else if (RadioButtonList4.SelectedValue == "2")
		{
			fun.AcHead(DrpAChead, 2);
		}
		else if (RadioButtonList4.SelectedValue == "3")
		{
			fun.AcHead(DrpAChead, 3);
		}
		else if (RadioButtonList4.SelectedValue == "4")
		{
			fun.AcHead(DrpAChead, 4);
		}
	}
}
