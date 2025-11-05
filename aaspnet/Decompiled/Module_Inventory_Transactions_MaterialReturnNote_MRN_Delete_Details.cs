using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_Inventory_Transactions_MaterialReturnNote_MRN_Delete_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private DataSet DS = new DataSet();

	private string MRNNo = "";

	private string FyId = "";

	private int CompId;

	private string connStr = "";

	private SqlConnection con;

	private string MId = "";

	protected GridView GridView1;

	protected Button BtnCancel;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			MId = base.Request.QueryString["Id"].ToString();
			CompId = Convert.ToInt32(Session["compid"]);
			FyId = base.Request.QueryString["FyId"].ToString();
			connStr = fun.Connection();
			con = new SqlConnection(connStr);
			MRNNo = base.Request.QueryString["MRNNo"].ToString();
			if (!Page.IsPostBack)
			{
				loadData();
			}
			con.Open();
			foreach (GridViewRow row in GridView1.Rows)
			{
				int num = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
				string cmdText = fun.select("tblInv_MaterialReturn_Details.Id", "tblInv_MaterialReturn_Master,tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master,tblInv_MaterialReturn_Details", "tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.Id =tblQc_MaterialReturnQuality_Master.MRNId AND tblInv_MaterialReturn_Master.CompId ='" + CompId + "' AND tblInv_MaterialReturn_Details.Id=tblQc_MaterialReturnQuality_Details.MRNId AND tblInv_MaterialReturn_Details.Id='" + num + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					LinkButton linkButton = (LinkButton)row.FindControl("LinkButton1");
					linkButton.Visible = false;
					((Label)row.FindControl("lblmrqn")).Visible = true;
				}
				else
				{
					LinkButton linkButton2 = (LinkButton)row.FindControl("LinkButton1");
					linkButton2.Visible = true;
					((Label)row.FindControl("lblmrqn")).Visible = false;
				}
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

	public void loadData()
	{
		try
		{
			con.Open();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("[Sp_MRN_FillGrid_EDPD]", con);
			sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@CompId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@CompId"].Value = CompId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@FinId", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@FinId"].Value = FyId;
			sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@x", SqlDbType.VarChar));
			sqlDataAdapter.SelectCommand.Parameters["@x"].Value = MId;
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			GridView1.DataSource = dataSet;
			GridView1.DataBind();
		}
		catch (Exception)
		{
		}
		finally
		{
			con.Close();
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Del")
			{
				con.Open();
				GridViewRow gridViewRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
				int num = Convert.ToInt32(((Label)gridViewRow.FindControl("lblId")).Text);
				string cmdText = fun.delete("tblInv_MaterialReturn_Details", "Id='" + num + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText, con);
				sqlCommand.ExecuteNonQuery();
				string cmdText2 = fun.select("tblInv_MaterialReturn_Details.Id", "tblInv_MaterialReturn_Details,tblInv_MaterialReturn_Master", " tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.CompId='" + CompId + "' AND tblInv_MaterialReturn_Master.Id='" + MId + "'");
				SqlCommand selectCommand = new SqlCommand(cmdText2, con);
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				if (dataSet.Tables[0].Rows.Count == 0)
				{
					string text = fun.delete("tblInv_MaterialReturn_Master", "CompId='" + CompId + "' and Id='" + MId + "'");
					SqlCommand sqlCommand2 = new SqlCommand(text, con);
					base.Response.Write(text);
					sqlCommand2.ExecuteNonQuery();
					base.Response.Redirect("MaterialReturnNote_MRN_Delete.aspx?ModId=9&SubModId=48");
				}
				else
				{
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
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

	protected void BtnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("MaterialReturnNote_MRN_Delete.aspx?MRNNo=" + MRNNo + "&ModId=9&SubModId=48");
	}

	protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		try
		{
			GridView1.PageIndex = e.NewPageIndex;
			loadData();
		}
		catch (Exception)
		{
		}
	}
}
