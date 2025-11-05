using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SysAdmin_FinancialYear_FinYear_New_Details : Page, IRequiresSessionState
{
	private clsFunctions fun = new clsFunctions();

	private int CompId;

	private int FinYearId;

	private int Company;

	private string finYr = "";

	private string finFrm = "";

	private string finDt = "";

	private string msg = "";

	private string sId = "";

	private string CDate = "";

	private string CTime = "";

	protected Label Label2;

	protected Label lblcompNm;

	protected Label Label3;

	protected Label lblfyear;

	protected Label lblfrom;

	protected Label lblFrmDt;

	protected Label Label4;

	protected Label lblToDt;

	protected Button btnSubmit;

	protected Button btnCancel;

	protected Label lblmsg;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			lblmsg.Text = "";
			if (!string.IsNullOrEmpty(base.Request.QueryString["msg"]))
			{
				lblmsg.Text = base.Request.QueryString["msg"];
			}
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			sId = Session["username"].ToString();
			CDate = DateTime.Now.ToString("yyyy-MM-dd");
			CTime = DateTime.Now.ToString("T");
			if (!string.IsNullOrEmpty(base.Request.QueryString["finyear"]))
			{
				finYr = base.Request.QueryString["finyear"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["fd"]))
			{
				finFrm = base.Request.QueryString["fd"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["td"]))
			{
				finDt = base.Request.QueryString["td"].ToString();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["comp"]))
			{
				Company = Convert.ToInt32(base.Request.QueryString["comp"]);
			}
			lblFrmDt.Text = fun.FromDateDMY(finFrm.ToString());
			lblToDt.Text = fun.FromDateDMY(finDt.ToString());
			lblcompNm.Text = fun.getCompany(Company);
			lblfyear.Text = finYr;
		}
		catch (Exception)
		{
		}
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("FinYrs_New.aspx?ModId=1&SubModId=1");
	}

	protected void btnSubmit_Click(object sender, EventArgs e)
	{
		string connectionString = fun.Connection();
		SqlConnection sqlConnection = new SqlConnection(connectionString);
		try
		{
			sqlConnection.Open();
			int num = 0;
			string cmdText = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + Company + "' and FinYear='" + finYr + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				msg = "Selected financial year already exists.";
				num++;
			}
			else if (finFrm != "" && finDt != "")
			{
				string cmdText2 = fun.insert("tblFinancial_master", "SysDate,SysTime,SessionId,CompId,FinYearFrom,FinYearTo,FinYear", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + Company + "','" + finFrm.ToString() + "','" + finDt.ToString() + "','" + finYr.ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlCommand.ExecuteNonQuery();
				shiftQty();
				msg = "Financial year is entered successfully.";
				num++;
			}
			if (num > 0)
			{
				Page.Response.Redirect("FinYear_New_Details.aspx?msg=" + msg + "&fd=" + finFrm + "&td=" + finDt + "&finyear=" + finYr + "&comp=" + Company + "&ModId=1&SubModId=1");
			}
			else
			{
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

	public void shiftQty()
	{
		try
		{
			int num = 0;
			string connectionString = fun.Connection();
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			string cmdText = fun.select("Id,StockQty,FinYearId,OpeningBalDate,OpeningBalQty", "tblDG_Item_Master", "CompId='" + CompId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, sqlConnection);
			DataSet dataSet = new DataSet();
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			sqlDataAdapter.Fill(dataSet, "tblFinancial_master");
			for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
			{
				string cmdText2 = fun.insert("tblDG_Item_Master_Clone", "SysDate,SysTime,SessionId,CompId,FinYearId,ItemId,StockQty,OpeningQty,OpeningDate", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + Convert.ToInt32(dataSet.Tables[0].Rows[i]["Id"]) + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[i]["StockQty"]) + "','" + Convert.ToDouble(dataSet.Tables[0].Rows[i]["OpeningBalQty"]) + "','" + dataSet.Tables[0].Rows[i]["OpeningBalDate"].ToString() + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText2, sqlConnection);
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlConnection.Close();
			}
			string cmdText3 = fun.update("tblDG_Item_Master", "OpeningBalQty=StockQty,OpeningBalDate='" + CDate + "'", "CompId='" + CompId + "'");
			SqlCommand sqlCommand2 = new SqlCommand(cmdText3, sqlConnection);
			sqlConnection.Open();
			sqlCommand2.ExecuteNonQuery();
			sqlConnection.Close();
			string cmdText4 = fun.select("FinYearId", "tblFinancial_master", "CompId='" + Company + "'Order By FinYearId Desc");
			SqlCommand selectCommand2 = new SqlCommand(cmdText4, sqlConnection);
			DataSet dataSet2 = new DataSet();
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			sqlDataAdapter2.Fill(dataSet2, "tblFinancial_master");
			if (dataSet2.Tables[0].Rows.Count > 0)
			{
				num = Convert.ToInt32(dataSet2.Tables[0].Rows[0]["FinYearId"]);
			}
			string cmdText5 = fun.select("*", "tblAccess_Master", "CompId='" + Company + "' AND FinYearId='" + FinYearId + "'");
			SqlCommand selectCommand3 = new SqlCommand(cmdText5, sqlConnection);
			DataSet dataSet3 = new DataSet();
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
			sqlDataAdapter3.Fill(dataSet3, "tblFinancial_master");
			if (dataSet3.Tables[0].Rows.Count > 0)
			{
				for (int j = 0; j < dataSet3.Tables[0].Rows.Count; j++)
				{
					string cmdText6 = fun.insert("tblAccess_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,EmpId,ModId,SubModId,AccessType,Access", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + num + "','" + dataSet3.Tables[0].Rows[j]["EmpId"].ToString() + "','" + Convert.ToInt32(dataSet3.Tables[0].Rows[j]["ModId"]) + "','" + Convert.ToInt32(dataSet3.Tables[0].Rows[j]["SubModId"]) + "','" + Convert.ToInt32(dataSet3.Tables[0].Rows[j]["AccessType"]) + "','" + Convert.ToInt32(dataSet3.Tables[0].Rows[j]["Access"]) + "'");
					SqlCommand sqlCommand3 = new SqlCommand(cmdText6, sqlConnection);
					sqlConnection.Open();
					sqlCommand3.ExecuteNonQuery();
					sqlConnection.Close();
				}
			}
			string cmdText7 = fun.update("tblAccess_Master", "Access=0", " Access!=4  AND  CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'");
			SqlCommand sqlCommand4 = new SqlCommand(cmdText7, sqlConnection);
			sqlConnection.Open();
			sqlCommand4.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception)
		{
		}
	}
}
