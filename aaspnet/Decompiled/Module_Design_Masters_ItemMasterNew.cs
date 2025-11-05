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

public class Module_Design_Masters_ItemMasterNew : Page, IRequiresSessionState
{
	protected Label Label2;

	protected DropDownList DrpCategory;

	protected RequiredFieldValidator ReqCat;

	protected Label Label4;

	protected TextBox TxtPartNo;

	protected RequiredFieldValidator RequiredFieldValidator2;

	protected CompareValidator CompareValidator3;

	protected TextBox TextBox1;

	protected RequiredFieldValidator RequiredFieldValidator3;

	protected CompareValidator CompareValidator2;

	protected TextBox TextBox2;

	protected RequiredFieldValidator RequiredFieldValidator1;

	protected CompareValidator CompareValidator1;

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

	protected Label Label15;

	protected FileUpload FileUpload1;

	protected DropDownList DrpBuyer;

	protected SqlDataSource SqlDataSource3;

	protected FileUpload FileUpload2;

	protected RadioButton RbtnLabour;

	protected RadioButton RbtnWithMaterial;

	protected RadioButton RbtnExpenses;

	protected RadioButton RbtnServiceProvider;

	protected DropDownList DrpACHead;

	protected SqlDataSource SqlDataSource2;

	protected Button BtnSubmit;

	protected Panel Panel1;

	protected TabPanel Add;

	protected DropDownList DrpType;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button BtnSearch;

	protected GridView GridView2;

	protected Panel Panel2;

	protected TabPanel View;

	protected TabContainer TabContainer1;

	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private DataSet DS2 = new DataSet();

	private DataSet DS3 = new DataSet();

	private int CompId;

	private int FinYearId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			TxtOpeningBalDate.Attributes.Add("readonly", "readonly");
			if (!base.IsPostBack)
			{
				fun.AcHead(DrpACHead, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnServiceProvider);
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
				string cmdText = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(DS, "tblDG_Category_Master");
				DrpCategory.DataSource = DS.Tables["tblDG_Category_Master"];
				DrpCategory.DataTextField = "Category";
				DrpCategory.DataValueField = "CId";
				DrpCategory.DataBind();
				DrpCategory.Items.Insert(0, "Select");
				fun.drpunit(DrpUOMBasic);
				fun.drpLocat(DrpLocation);
				TxtOpeningBalDate.Text = fun.getOpeningDate(CompId, FinYearId);
				TabContainer1.OnClientActiveTabChanged = "OnChanged";
				TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DrpACHead, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnServiceProvider);
	}

	protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DrpACHead, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnServiceProvider);
	}

	protected void RbtnExpenses_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DrpACHead, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnServiceProvider);
	}

	protected void RbtnServiceProvider_CheckedChanged(object sender, EventArgs e)
	{
		fun.AcHead(DrpACHead, RbtnLabour, RbtnWithMaterial, RbtnExpenses, RbtnServiceProvider);
	}

	public void Fillgrid(string sd, string B, string s, string drptype)
	{
		string connectionString = fun.Connection();
		SqlConnection selectConnection = new SqlConnection(connectionString);
		new DataTable();
		try
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			if (!(DrpType.SelectedValue != "Select"))
			{
				return;
			}
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
						if (B == "tblDG_Item_Master.Location")
						{
							txtSearchItemCode.Visible = false;
							DropDownList3.Visible = true;
							if (DropDownList3.SelectedValue != "Select")
							{
								value2 = " And tblDG_Item_Master.Location='" + DropDownList3.SelectedValue + "'";
							}
						}
					}
					value3 = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
				}
				else if (sd == "Select" && B == "Select" && s != string.Empty)
				{
					value4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
				}
			}
			else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems")
			{
				if (B != "Select")
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
				else if (B == "Select" && s != string.Empty)
				{
					value4 = " And tblDG_Item_Master.ManfDesc Like '%" + s + "%'";
				}
				value3 = "And tblDG_Item_Master.CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
			}
			new SqlCommand();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetAllItem", selectConnection);
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
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value4;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		string selectedValue = DrpCategory1.SelectedValue;
		string selectedValue2 = DrpSearchCode.SelectedValue;
		string text = txtSearchItemCode.Text;
		string selectedValue3 = DrpType.SelectedValue;
		Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
	}

	protected void BtnSubmit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			if (!(DrpCategory.SelectedValue != "Select") || !(DrpUOMBasic.SelectedValue != "Select") || !(DrpLocation.SelectedValue != "Select") || !fun.NumberValidationQty(TxtStockQty.Text) || !fun.NumberValidationQty(TxtOpeningBalQty.Text) || !fun.NumberValidationQty(TxtMinorderQty.Text) || !fun.NumberValidationQty(TxtMinStockQty.Text) || !(TxtManfDesc.Text != ""))
			{
				return;
			}
			sqlConnection.Open();
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			string text = fun.ToDate(TxtOpeningBalDate.Text);
			string text2 = Session["username"].ToString();
			int num = Convert.ToInt32(Session["compid"]);
			int num2 = Convert.ToInt32(Session["finyear"]);
			int contentLength = FileUpload1.PostedFile.ContentLength;
			string text3 = "";
			string text4 = "";
			byte[] array;
			if (contentLength > 0)
			{
				System.Drawing.Image image = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
				text4 = FileUpload1.PostedFile.ContentType;
				int height = image.Height;
				int width = image.Width;
				int num3 = 135;
				height = 62;
				width = num3;
				Bitmap bitmap = new Bitmap(image, width, height);
				MemoryStream memoryStream = new MemoryStream();
				bitmap.Save(memoryStream, ImageFormat.Jpeg);
				memoryStream.Position = 0L;
				array = new byte[contentLength];
				memoryStream.Read(array, 0, contentLength);
				text3 = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
			}
			else
			{
				array = new byte[0];
			}
			string text5 = "";
			string text6 = "";
			double num4 = 0.0;
			string text7 = "";
			HttpPostedFile postedFile = FileUpload2.PostedFile;
			byte[] array2 = null;
			if (FileUpload2.PostedFile != null)
			{
				Stream inputStream = FileUpload2.PostedFile.InputStream;
				BinaryReader binaryReader = new BinaryReader(inputStream);
				array2 = binaryReader.ReadBytes((int)inputStream.Length);
				text6 = Path.GetFileName(postedFile.FileName);
				num4 = array2.Length;
				text7 = postedFile.ContentType;
			}
			int num5 = (CheckAbsolute.Checked ? 1 : 0);
			int num6 = ((RadioButtonList2.SelectedValue == "1") ? 1 : 0);
			int num7 = ((RadioButtonList3.SelectedValue == "1") ? 1 : 0);
			int num8 = ((RadioButtonList1.SelectedValue == "1") ? 1 : 0);
			int num9 = fun.ItemCodeLimit(num);
			string cmdText = fun.select("Symbol", "tblDG_Category_Master", "CId='" + DrpCategory.SelectedValue + "'And CompId='" + num + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
			string text8 = "";
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				text8 = dataSet.Tables[0].Rows[0][0].ToString();
			}
			string text9 = TxtPartNo.Text + "-" + TextBox1.Text + "-" + TextBox2.Text;
			text5 = text8 + text9;
			if (text5 != "" && text5.Length == num9)
			{
				string cmdText2 = fun.select("ItemCode", "tblDG_Item_Master", "ItemCode='" + text5 + "'And CompId='" + num + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, sqlConnection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Item_Master");
				if (dataSet2.Tables[0].Rows.Count == 0)
				{
					if (TxtPartNo.Text.Length == TxtPartNo.MaxLength)
					{
						string cmdText3 = fun.insert("tblDG_Item_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CId,PartNo,ManfDesc,UOMBasic,MinOrderQty,MinStockQty,StockQty,Location,FileData,Absolute,OpeningBalDate,OpeningBalQty,ItemCode,Class,LeadDays,InspectionDays,FileName,FileSize,ContentType,Excise,ImportLocal,UOMConFact,AttName,AttSize,AttContentType,AttData,Buyer,AHId", "'" + currDate + "','" + currTime + "','" + text2 + "','" + num + "','" + num2 + "','" + DrpCategory.SelectedValue + "','" + text9 + "','" + TxtManfDesc.Text + "','" + DrpUOMBasic.SelectedValue + "','" + Convert.ToDouble(decimal.Parse(TxtMinorderQty.Text.ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(TxtMinStockQty.Text.ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(TxtStockQty.Text.ToString()).ToString("N3")) + "','" + DrpLocation.SelectedValue + "',@pic,'" + num5 + "','" + text + "','" + Convert.ToDouble(decimal.Parse(TxtOpeningBalQty.Text.ToString()).ToString("N3")) + "','" + text5 + "','" + drpclass.SelectedValue + "','" + txtleaddays.Text + "','" + txtInspdays.Text + "','" + text3 + "','" + contentLength + "','" + text4 + "','" + num7 + "','" + num6 + "','" + num8 + "','" + text6 + "','" + num4 + "','" + text7 + "',@AttData,'" + DrpBuyer.SelectedValue + "','" + DrpACHead.SelectedValue + "'");
						SqlCommand sqlCommand = new SqlCommand(cmdText3, sqlConnection);
						sqlCommand.Parameters.AddWithValue("@pic", array);
						sqlCommand.Parameters.AddWithValue("@AttData", array2);
						sqlCommand.ExecuteNonQuery();
						_ = string.Empty;
						string text10 = "Record Inserted Succesfully.";
						base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text10 + "');", addScriptTags: true);
						DrpCategory.SelectedValue = "Select";
						TxtPartNo.Text = "";
						TextBox1.Text = "";
						TextBox2.Text = "";
						TxtManfDesc.Text = "";
						DrpUOMBasic.SelectedValue = "Select";
						DrpLocation.SelectedValue = "Select";
						drpclass.SelectedValue = "1";
					}
				}
				else
				{
					_ = string.Empty;
					string text11 = "Item is already exists.";
					base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + text11 + "');", addScriptTags: true);
				}
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid Part number.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
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

	protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
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
			}
			else
			{
				string sd = "";
				string b = "";
				string s = "";
				string drptype = "";
				Fillgrid(sd, b, s, drptype);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
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
		if (DrpSearchCode.SelectedItem.Text == "Location")
		{
			DropDownList3.Visible = true;
			txtSearchItemCode.Visible = false;
			txtSearchItemCode.Text = "";
		}
		else
		{
			DropDownList3.Visible = false;
			txtSearchItemCode.Visible = true;
			txtSearchItemCode.Text = "";
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
				DropDownList3.Visible = true;
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				DrpCategory1.Visible = true;
				string connectionString = fun.Connection();
				SqlConnection connection = new SqlConnection(connectionString);
				DataSet dataSet = new DataSet();
				string cmdText = fun.select("CId,Symbol+'-'+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet, "tblDG_Category_Master");
				DrpCategory1.DataSource = dataSet.Tables["tblDG_Category_Master"];
				DrpCategory1.DataTextField = "Category";
				DrpCategory1.DataValueField = "CId";
				DrpCategory1.DataBind();
				DrpCategory1.Items.Insert(0, "Select");
				DrpCategory1.ClearSelection();
				fun.drpLocat(DropDownList3);
				if (DrpSearchCode.SelectedItem.Text == "Location")
				{
					DropDownList3.Visible = true;
					txtSearchItemCode.Visible = false;
					txtSearchItemCode.Text = "";
				}
				else
				{
					DropDownList3.Visible = false;
					txtSearchItemCode.Visible = true;
					txtSearchItemCode.Text = "";
				}
				break;
			}
			case "WOItems":
				txtSearchItemCode.Visible = true;
				txtSearchItemCode.Text = "";
				DrpSearchCode.Visible = true;
				DrpCategory1.Visible = false;
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DropDownList3.Items.Clear();
				DropDownList3.Items.Insert(0, "Select");
				break;
			case "Select":
			{
				string empty = string.Empty;
				empty = "Please Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
				break;
			}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
	{
		Session.Remove("TabIndex");
	}

	protected void BtnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			if (DrpType.SelectedValue != "Select")
			{
				string selectedValue = DrpCategory1.SelectedValue;
				string selectedValue2 = DrpSearchCode.SelectedValue;
				string text = txtSearchItemCode.Text;
				string selectedValue3 = DrpType.SelectedValue;
				Fillgrid(selectedValue, selectedValue2, text, selectedValue3);
			}
			else
			{
				string empty = string.Empty;
				empty = "Select Category or WO Items.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}
}
