using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Design_Reports_ItemHistory_BOM_View : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FYId;

	private string sId = string.Empty;

	protected Label Label2;

	protected Label LblCode;

	protected Label Label5;

	protected Label LblUOMBasic;

	protected Label Label3;

	protected Label lblManfdesc;

	protected Button btnCancel;

	protected GridView GridView2;

	protected Panel Panel1;

	protected Label Label6;

	protected Label lblTot;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	public void bindData()
	{
		try
		{
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			if (base.Request.QueryString["Id"].ToString() != "")
			{
				int num = Convert.ToInt32(base.Request.QueryString["Id"]);
				string cmdText = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc ,tblDG_Item_Master.UOMBasic,tblDG_BOM_Master.WONo,tblDG_BOM_Master.PId,tblDG_BOM_Master.CId,tblDG_BOM_Master.Qty ", "tblDG_Item_Master,tblDG_BOM_Master", " tblDG_BOM_Master.ItemId=tblDG_Item_Master.Id AND tblDG_BOM_Master.CompId='" + CompId + "' AND tblDG_BOM_Master.ItemId='" + num + "'AND tblDG_Item_Master.Id='" + num + "'And tblDG_Item_Master.FinYearId<='" + FYId + "' And tblDG_BOM_Master.PId!='0'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
				SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
				sqlDataReader.Read();
				if (sqlDataReader.HasRows)
				{
					if (sqlDataReader["ItemCode"].ToString() != "")
					{
						LblCode.Text = sqlDataReader["ItemCode"].ToString();
					}
					else
					{
						LblCode.Text = "NA";
					}
					if (sqlDataReader["ManfDesc"].ToString() != "")
					{
						lblManfdesc.Text = sqlDataReader["ManfDesc"].ToString();
					}
					else
					{
						lblManfdesc.Text = "NA";
					}
					string cmdText2 = fun.select("Unit_Master.Symbol", "Unit_Master", "Unit_Master.Id='" + sqlDataReader["UOMBasic"].ToString() + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection);
					SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
					sqlDataReader2.Read();
					if (sqlDataReader2.HasRows)
					{
						LblUOMBasic.Text = sqlDataReader2["Symbol"].ToString();
					}
					else
					{
						LblUOMBasic.Text = "NA";
					}
					DataTable dataTable = new DataTable();
					dataTable.Columns.Add("AssemblyNo", typeof(string));
					dataTable.Columns.Add("ManfDesc", typeof(string));
					dataTable.Columns.Add("UOMBasic", typeof(string));
					dataTable.Columns.Add("UnitQty", typeof(string));
					dataTable.Columns.Add("BOMQty", typeof(string));
					dataTable.Columns.Add("WONo", typeof(string));
					dataTable.Columns.Add("Date", typeof(string));
					dataTable.Columns.Add("Time", typeof(string));
					dataTable.Columns.Add("ItemId", typeof(int));
					dataTable.Columns.Add("PId", typeof(int));
					dataTable.Columns.Add("CId", typeof(int));
					dataTable.Columns.Add("Id", typeof(string));
					string cmdText3 = fun.select("SysDate,SysTime,WONo,PId,CId,Qty", "tblDG_BOM_Master", "CompId='" + CompId + "' AND ItemId='" + num + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, sqlConnection);
					SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
					double num2 = 0.0;
					double num3 = 0.0;
					while (sqlDataReader3.Read())
					{
						DataRow dataRow = dataTable.NewRow();
						string cmdText4 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,tblDG_Item_Master.UOMBasic", "tblDG_BOM_Master,tblDG_Item_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND tblDG_BOM_Master.CId='" + Convert.ToInt32(sqlDataReader3["PId"].ToString()) + "'And tblDG_Item_Master.CompId='" + CompId + "'AND tblDG_Item_Master.FinYearId<='" + FYId + "' AND tblDG_BOM_Master.WONo='" + sqlDataReader3["WONo"].ToString() + "'");
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, sqlConnection);
						SqlDataReader sqlDataReader4 = sqlCommand4.ExecuteReader();
						sqlDataReader4.Read();
						if (sqlDataReader4.HasRows)
						{
							dataRow[0] = sqlDataReader4["ItemCode"].ToString();
							dataRow[1] = sqlDataReader4["ManfDesc"].ToString();
							string cmdText5 = fun.select("Symbol", "Unit_Master", "Id='" + sqlDataReader4["UOMBasic"].ToString() + "'");
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, sqlConnection);
							SqlDataReader sqlDataReader5 = sqlCommand5.ExecuteReader();
							sqlDataReader5.Read();
							if (sqlDataReader5.HasRows)
							{
								dataRow[2] = sqlDataReader5["Symbol"].ToString();
							}
						}
						num2 = fun.BOMRecurQty(sqlDataReader3["WONo"].ToString(), Convert.ToInt32(sqlDataReader3["PId"].ToString()), Convert.ToInt32(sqlDataReader3["CId"].ToString()), 1.0, CompId, FYId);
						dataRow[4] = decimal.Parse(num2.ToString()).ToString("N3");
						dataRow[5] = sqlDataReader3["WONo"].ToString();
						dataRow[6] = fun.FromDateDMY(sqlDataReader3["SysDate"].ToString());
						dataRow[7] = sqlDataReader3["SysTime"].ToString();
						num3 += num2;
						dataTable.Rows.Add(dataRow);
						dataTable.AcceptChanges();
					}
					GridView2.DataSource = dataTable;
					GridView2.DataBind();
					lblTot.Text = num3.ToString();
				}
				else
				{
					LblCode.Text = "NA";
					lblManfdesc.Text = "NA";
					LblUOMBasic.Text = "NA";
				}
			}
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		sId = Session["username"].ToString();
		CompId = Convert.ToInt32(Session["compid"]);
		FYId = Convert.ToInt32(Session["finyear"]);
		if (!base.IsPostBack)
		{
			bindData();
		}
	}

	public void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridView2.PageIndex = e.NewPageIndex;
		bindData();
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("ItemHistory_BOM.aspx?ModId=3");
	}
}
