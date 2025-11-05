using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;
using AjaxControlToolkit;

public class Module_Inventory_Transactions_GoodsQualityNote_GQN_Print : Page, IRequiresSessionState
{
	protected DropDownList DropDownList1;

	protected TextBox txtSupplier;

	protected AutoCompleteExtender txtSupplier_AutoCompleteExtender1;

	protected TextBox Txtfield;

	protected Button btnSearch;

	protected GridView GridView2;

	private clsFunctions fun = new clsFunctions();

	private string SupId = "";

	private string GqNo = "";

	private string sId = "";

	private int FinYearId;

	private int CompId;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			CompId = Convert.ToInt32(Session["compid"]);
			if (!Page.IsPostBack)
			{
				Txtfield.Visible = false;
				loadData(SupId, GqNo);
			}
		}
		catch (Exception)
		{
		}
	}

	public void loadData(string spid, string gid)
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			string value = "";
			if (DropDownList1.SelectedValue == "1" && Txtfield.Text != "")
			{
				value = " And tblQc_MaterialQuality_Master.GQNNo='" + Txtfield.Text + "'";
			}
			if (DropDownList1.SelectedValue == "Select")
			{
				Txtfield.Visible = true;
				txtSupplier.Visible = false;
			}
			string value2 = "";
			if (DropDownList1.SelectedValue == "2" && Txtfield.Text != "")
			{
				value2 = " And tblinv_MaterialReceived_Master.GRRNo='" + Txtfield.Text + "'";
			}
			string value3 = "";
			if (DropDownList1.SelectedValue == "3" && Txtfield.Text != "")
			{
				value3 = " And tblInv_Inward_Master.PONo='" + Txtfield.Text + "'";
			}
			string value4 = "";
			if (DropDownList1.SelectedValue == "0" && txtSupplier.Text != "")
			{
				value4 = " And tblMM_PO_Master.SupplierId='" + spid + "'";
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Sp_GQN_Edit", sqlConnection);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FinYearId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = value4;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@y", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@y"].Value = value;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@p", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@p"].Value = value2;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@z", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@z"].Value = value3;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView2.DataSource = dataSet;
			GridView2.DataBind();
		}
		catch (Exception)
		{
		}
	}

	[ScriptMethod]
	[WebMethod]
	public static string[] sql(string prefixText, int count, string contextKey)
	{
		clsFunctions clsFunctions2 = new clsFunctions();
		string connectionString = clsFunctions2.Connection();
		DataSet dataSet = new DataSet();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		sqlConnection.Open();
		int num = Convert.ToInt32(HttpContext.Current.Session["compid"]);
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

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				_ = ((Label)gridViewRow.FindControl("lblsupId")).Text;
				string text = ((Label)gridViewRow.FindControl("lblgqnno")).Text;
				string text2 = ((Label)gridViewRow.FindControl("lblGrrNo")).Text;
				string text3 = ((Label)gridViewRow.FindControl("lblGin")).Text;
				string text4 = ((Label)gridViewRow.FindControl("lblpo")).Text;
				string text5 = ((Label)gridViewRow.FindControl("lblFinId")).Text;
				string text6 = ((Label)gridViewRow.FindControl("lblId")).Text;
				string text7 = ((Label)gridViewRow.FindControl("lblginid")).Text;
				SupId = ((Label)gridViewRow.FindControl("lblsupp")).Text;
				string randomAlphaNumeric = fun.GetRandomAlphaNumeric();
				base.Response.Redirect("GoodsQualityNote_GQN_Print_Details.aspx?Id=" + text6 + "&GINId=" + text7 + "&GQNNo=" + text + "&GRRNo=" + text2 + "&GINNo=" + text3 + "&PONo=" + text4 + "&FyId=" + text5 + "&Key=" + randomAlphaNumeric + "&ModId=10&SubModId=46");
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			text = fun.getCode(txtSupplier.Text);
			text2 = Txtfield.Text;
			GridView2.PageIndex = e.NewPageIndex;
			loadData(text, text2);
		}
		catch (Exception)
		{
		}
	}

	protected void btnSearch_Click(object sender, EventArgs e)
	{
		try
		{
			string text = "";
			string text2 = "";
			text = fun.getCode(txtSupplier.Text);
			text2 = Txtfield.Text;
			loadData(text, text2);
		}
		catch (Exception)
		{
		}
	}

	protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (DropDownList1.SelectedValue == "0")
			{
				Txtfield.Visible = false;
				txtSupplier.Visible = true;
				txtSupplier.Text = "";
				loadData(SupId, GqNo);
			}
			if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "Select" || DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3")
			{
				Txtfield.Visible = true;
				txtSupplier.Visible = false;
				Txtfield.Text = "";
				loadData(SupId, GqNo);
			}
		}
		catch (Exception)
		{
		}
	}
}
