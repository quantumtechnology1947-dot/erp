using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_Stock_Statement : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private string cid = "";

	private string scid = "";

	private string it = "";

	private double OverHeads;

	protected Label lblFromDate;

	protected Label lblToDate;

	protected TextBox Txtfromdate;

	protected CalendarExtender Txtfromdate_CalendarExtender;

	protected RequiredFieldValidator ReqFrDate;

	protected RegularExpressionValidator RegularExpressionValidator1;

	protected TextBox TxtTodate;

	protected CalendarExtender TxtTodate_CalendarExtender;

	protected RequiredFieldValidator ReqTODate;

	protected RegularExpressionValidator RegularExpressionValidator2;

	protected RadioButtonList RadRate;

	protected TextBox txtOverheads;

	protected RegularExpressionValidator RegtxtOverheads;

	protected RequiredFieldValidator ReqtxtOverheads;

	protected DropDownList DrpType;

	protected RequiredFieldValidator ReqCategory;

	protected DropDownList DrpCategory1;

	protected DropDownList DrpSearchCode;

	protected DropDownList DropDownList3;

	protected TextBox txtSearchItemCode;

	protected Button BtnView;

	protected Label lblMessage;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (txtOverheads.Text != "" && fun.NumberValidationQty(txtOverheads.Text))
			{
				OverHeads = Convert.ToDouble(txtOverheads.Text);
			}
			Txtfromdate.Attributes.Add("readonly", "readonly");
			TxtTodate.Attributes.Add("readonly", "readonly");
			string connectionString = fun.Connection();
			SqlConnection connection = new SqlConnection(connectionString);
			lblMessage.Text = "";
			SqlCommand selectCommand = new SqlCommand("Select FinYearFrom,FinYearTo From tblFinancial_master Where CompId='" + CompId + "' And FinYearId='" + FinYearId + "'", connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (!base.IsPostBack)
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblFromDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0][0].ToString());
					lblToDate.Text = fun.FromDateDMY(dataSet.Tables[0].Rows[0][1].ToString());
				}
				DrpCategory1.Items.Clear();
				DrpCategory1.Items.Insert(0, "Select");
				DropDownList3.Visible = false;
				DrpCategory1.Visible = false;
				DrpSearchCode.Visible = false;
				txtSearchItemCode.Visible = false;
				string cmdText = fun.select("CId,'['+Symbol+'] - '+CName as Category", "tblDG_Category_Master", "CompId='" + CompId + "'");
				SqlCommand selectCommand2 = new SqlCommand(cmdText, connection);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2, "tblDG_Category_Master");
				DrpCategory1.DataSource = dataSet2.Tables["tblDG_Category_Master"];
				DrpCategory1.DataTextField = "Category";
				DrpCategory1.DataValueField = "CId";
				DrpCategory1.DataBind();
				DrpCategory1.Items.Insert(0, "Select");
				Txtfromdate.Text = lblFromDate.Text;
				TxtTodate.Text = fun.FromDateDMY(fun.getCurrDate());
			}
		}
		catch (Exception)
		{
		}
	}

	protected void BtnView_Click(object sender, EventArgs e)
	{
		try
		{
			if (DrpType.SelectedValue != "Select")
			{
				string selectedValue = DrpCategory1.SelectedValue;
				string text = Txtfromdate.Text;
				string text2 = TxtTodate.Text;
				string text3 = "";
				string text4 = "";
				string text5 = "";
				string text6 = txtSearchItemCode.Text;
				if (DrpType.SelectedValue == "Category")
				{
					if (selectedValue != "Select")
					{
						text3 = " AND CId='" + selectedValue + "'";
						if (DrpSearchCode.SelectedValue != "Select")
						{
							if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ItemCode")
							{
								txtSearchItemCode.Visible = true;
								text4 = " And ItemCode Like '" + text6.Trim() + "%'";
							}
							if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ManfDesc")
							{
								txtSearchItemCode.Visible = true;
								text4 = " And Description Like '" + text6.Trim() + "%'";
							}
							if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.Location")
							{
								txtSearchItemCode.Visible = false;
								DropDownList3.Visible = true;
								if (DropDownList3.SelectedValue != "Select")
								{
									text4 = " And Location='" + DropDownList3.SelectedValue + "'";
								}
							}
						}
						_ = "And CompId='" + CompId + "' And tblDG_Item_Master.FinYearId<='" + FinYearId + "'";
						text5 = " And CId is not null";
					}
					else
					{
						text5 = " And CId is not null";
					}
				}
				else if (DrpType.SelectedValue != "Select" && DrpType.SelectedValue == "WOItems")
				{
					if (DrpSearchCode.SelectedValue != "Select")
					{
						if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ItemCode")
						{
							txtSearchItemCode.Visible = true;
							text4 = " And ItemCode Like '" + text6.Trim() + "%'";
						}
						if (DrpSearchCode.SelectedValue == "tblDG_Item_Master.ManfDesc")
						{
							txtSearchItemCode.Visible = true;
							text4 = " And Description Like '" + text6.Trim() + "%'";
						}
					}
					text5 = " And CId is null";
				}
				int num = Convert.ToInt32(RadRate.SelectedValue);
				if (Convert.ToDateTime(fun.FromDate(TxtTodate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) <= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)) && fun.DateValidation(Txtfromdate.Text) && fun.DateValidation(TxtTodate.Text))
				{
					string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
					base.Response.Redirect("Stock_Statement_Details.aspx?Cid=" + text3 + "&RadVal=" + num.ToString() + "&FDate=" + text + "&TDate=" + text2 + "&OpeningDt=" + fun.FromDate(lblFromDate.Text) + "&p=" + text4 + "&r=" + text5 + "&OverHeads=" + OverHeads + "&Key=" + randomAlphaNumeric);
				}
				else if (Convert.ToDateTime(fun.FromDate(lblFromDate.Text)) >= Convert.ToDateTime(fun.FromDate(Txtfromdate.Text)))
				{
					lblMessage.Text = "From date should not be Less than Opening Date!";
				}
				else
				{
					lblMessage.Text = "From date should be Less than or Equal to To Date!";
				}
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

	protected void DrpCategory_SelectedIndexChanged(object sender, EventArgs e)
	{
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

	protected void DrpCategory1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DrpCategory1.SelectedValue != "Select")
			{
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
}
