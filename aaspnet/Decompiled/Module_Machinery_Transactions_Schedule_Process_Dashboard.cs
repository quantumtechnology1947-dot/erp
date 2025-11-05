using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Machinery_Transactions_Schedule_Process_Dashboard : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private string connStr = "";

	private SqlConnection con;

	private int CompId;

	private string sId = "";

	private string MachinId = "";

	private int FinYearId;

	protected Label lblMachine;

	protected GridView GridView2;

	protected Button btnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			CompId = Convert.ToInt32(Session["compid"]);
			sId = Session["username"].ToString();
			FinYearId = Convert.ToInt32(Session["finyear"]);
			if (!string.IsNullOrEmpty(base.Request.QueryString["Id"].ToString()))
			{
				MachinId = base.Request.QueryString["Id"].ToString();
			}
			if (!Page.IsPostBack)
			{
				string cmdText = fun.select("tblDG_Item_Master.ManfDesc", " tblDG_Item_Master", " tblDG_Item_Master.Id='" + Convert.ToInt32(MachinId) + "' And tblDG_Item_Master.CompId='" + CompId + "'And tblDG_Item_Master.FinYearId<='" + FinYearId + "' ");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				DataSet dataSet = new DataSet();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					lblMachine.Text = dataSet.Tables[0].Rows[0]["ManfDesc"].ToString();
				}
				fillGrid();
			}
		}
		catch (Exception)
		{
		}
	}

	protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		fillGrid();
	}

	public void fillGrid()
	{
		try
		{
			string cmdText = fun.select("Id", "tblMS_Master", " ItemId='" + MachinId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Id", typeof(int));
			dataTable.Columns.Add("MachineId", typeof(int));
			dataTable.Columns.Add("Process", typeof(string));
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				string cmdText2 = fun.select("tblPln_Process_Master.Id,tblPln_Process_Master.ProcessName", "tblMS_Process,tblPln_Process_Master", "tblMS_Process.MId='" + dataSet.Tables[0].Rows[0][0].ToString() + "' AND tblPln_Process_Master.Id=tblMS_Process.PId");
				SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
				DataSet dataSet2 = new DataSet();
				sqlDataAdapter2.Fill(dataSet2);
				for (int i = 0; i < dataSet2.Tables[0].Rows.Count; i++)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow[0] = Convert.ToInt32(dataSet2.Tables[0].Rows[i]["Id"]);
					dataRow[1] = MachinId;
					dataRow[2] = dataSet2.Tables[0].Rows[i]["ProcessName"].ToString();
					dataTable.Rows.Add(dataRow);
					dataTable.AcceptChanges();
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
			con.Close();
		}
	}

	protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sel")
			{
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = 0;
				num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				int num2 = 0;
				num2 = Convert.ToInt32(((Label)gridViewRow.FindControl("lblMachineId")).Text);
				if (num != 0 && num2 != 0)
				{
					base.Response.Redirect("~/Module/Machinery/Transactions/Schedule_Dashboard.aspx?ProcessId=" + num + "&MachineId=" + MachinId + "&ModId=15&SubModId=70");
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/Machinery/Transactions/Schedule_Machine_Dashboard.aspx?ModId=15&SubModId=70");
	}
}
