using System;
using System.Data;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Transactions_TPL_Design_Assembly_Edit_Assbly : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string wono = "";

	private string wonofrm = "";

	private int CompId;

	private string SessionId = "";

	private int FinYearId;

	protected Label lblWONoFrm;

	protected Label lblWONo;

	protected DropDownList DropDownList1;

	protected TextBox txtSearchCustomer;

	protected Button btnSearch;

	protected Button btnCancel;

	protected Label lblMsg;

	protected GridView SearchGridView1;

	protected HiddenField hfSort;

	protected HiddenField hfSearchText;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			SessionId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			lblWONoFrm.Text = base.Request.QueryString["WONoSrc"].ToString();
			wono = lblWONoFrm.Text;
			lblWONo.Text = base.Request.QueryString["WONoDest"].ToString();
			wonofrm = lblWONo.Text;
			lblMsg.Text = "";
			if (base.Request.QueryString["msg"] != null)
			{
				lblMsg.Text = base.Request.QueryString["msg"].ToString();
			}
			if (!Page.IsPostBack)
			{
				string odr = " Order by tblDG_BOM_Master.Id Desc";
				fun.BindDataCustIMaster("tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", " tblDG_BOM_Master.CId,tblDG_BOM_Master.Id,tblDG_BOM_Master.ItemId,tblDG_BOM_Master.WONo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.Qty", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND tblDG_BOM_Master.PId='0' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id  AND tblDG_BOM_Master.CompId='" + CompId + "' AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "'", SearchGridView1, DropDownList1.SelectedValue, txtSearchCustomer.Text, odr);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			SearchGridView1.PageIndex = e.NewPageIndex;
			string odr = " Order by tblDG_BOM_Master.Id Desc";
			fun.BindDataCustIMaster("tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", " tblDG_BOM_Master.CId,tblDG_BOM_Master.Id,tblDG_BOM_Master.ItemId,tblDG_BOM_Master.WONo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.Qty", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND tblDG_BOM_Master.PId='0' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id  AND tblDG_BOM_Master.CompId='" + CompId + "' AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "'", SearchGridView1, DropDownList1.SelectedValue, txtSearchCustomer.Text, odr);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string odr = " Order by tblDG_BOM_Master.Id Desc";
			fun.BindDataCustIMaster("tblDG_Item_Master,tblDG_BOM_Master,Unit_Master", " tblDG_BOM_Master.CId,tblDG_BOM_Master.Id,tblDG_BOM_Master.ItemId,tblDG_BOM_Master.WONo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_BOM_Master.Qty", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND WONo='" + wono + "' AND tblDG_BOM_Master.PId='0' AND tblDG_Item_Master.UOMBasic = Unit_Master.Id  AND tblDG_BOM_Master.CompId='" + CompId + "' AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "'", SearchGridView1, DropDownList1.SelectedValue, txtSearchCustomer.Text, odr);
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("TPL_Design_WO_TreeView.aspx?WONo=" + wonofrm + "&ModId=3&SubModId=23");
	}

	protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
	{
		try
		{
			CheckBox checkBox = (CheckBox)SearchGridView1.HeaderRow.FindControl("chkSelectAll");
			if (checkBox.Checked)
			{
				foreach (GridViewRow row in SearchGridView1.Rows)
				{
					CheckBox checkBox2 = (CheckBox)row.FindControl("chkSelect");
					checkBox2.Checked = true;
				}
				return;
			}
			foreach (GridViewRow row2 in SearchGridView1.Rows)
			{
				CheckBox checkBox3 = (CheckBox)row2.FindControl("chkSelect");
				checkBox3.Checked = false;
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (!(e.CommandName == "Add"))
			{
				return;
			}
			int num = 0;
			foreach (GridViewRow row in SearchGridView1.Rows)
			{
				CheckBox checkBox = (CheckBox)row.FindControl("chkSelect");
				if (checkBox.Checked)
				{
					int rowIndex = row.RowIndex;
					int node = Convert.ToInt32(((Label)SearchGridView1.Rows[rowIndex].FindControl("CId")).Text);
					Convert.ToInt32(((Label)SearchGridView1.Rows[rowIndex].FindControl("ItemId")).Text);
					int tPLCId = fun.getTPLCId(wono, CompId, FinYearId);
					fun.getRootNode(node, wono, wonofrm, CompId, SessionId, FinYearId, 0, tPLCId);
					num++;
				}
			}
			if (num > 0)
			{
				base.Response.Redirect("TPL_Design_WO_TreeView.aspx?WONo=" + wono + "&ModId=3&SubModId=23&Msg=Copy of root assemblies are done.");
			}
		}
		catch (Exception)
		{
		}
	}
}
