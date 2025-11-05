using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP;

public class Module_SalesDistribution_Transactions_Dispatch_Gunrail_Details : Page, IRequiresSessionState
{
	protected Label lblWono;

	protected GridView SearchGridView1;

	protected SqlDataSource SqlDataSource1;

	protected GridView GridView1;

	protected SqlDataSource SqlDataSource2;

	protected Panel Panel1;

	protected Label lblType;

	protected RadioButtonList RadioButtonList1;

	protected Label lblSupportPitch;

	protected TextBox txtPitch;

	protected RequiredFieldValidator ReqPitch;

	protected RegularExpressionValidator RegPitch;

	protected Button btnProceed;

	protected Button btncancel;

	private int CompId;

	private int FinYearId;

	private string SId = string.Empty;

	private string WONo = string.Empty;

	private clsFunctions fun = new clsFunctions();

	private SqlConnection con;

	private string ConnStr = string.Empty;

	protected ProfileCommon Profile => (ProfileCommon)Context.Profile;

	protected global_asax ApplicationInstance => (global_asax)Context.ApplicationInstance;

	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CompId = Convert.ToInt32(Session["compid"]);
			FinYearId = Convert.ToInt32(Session["finyear"]);
			SId = Session["username"].ToString();
			ConnStr = fun.Connection();
			con = new SqlConnection(ConnStr);
			if (!string.IsNullOrEmpty(base.Request.QueryString["WONo"]))
			{
				WONo = base.Request.QueryString["WONo"].ToString();
				lblWono.Text = WONo;
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
			double num = 0.0;
			double num2 = 0.0;
			if (e.CommandName == "AddCRF")
			{
				num = Convert.ToDouble(((TextBox)SearchGridView1.FooterRow.FindControl("txtLenMTR")).Text);
				num2 = Convert.ToDouble(((TextBox)SearchGridView1.FooterRow.FindControl("txtNoRows")).Text);
				if (num != 0.0 && num2 != 0.0 && SId != "" && CompId != 0)
				{
					SqlDataSource1.InsertParameters["CompId"].DefaultValue = CompId.ToString();
					SqlDataSource1.InsertParameters["SessionId"].DefaultValue = SId;
					SqlDataSource1.InsertParameters["Length"].DefaultValue = num.ToString();
					SqlDataSource1.InsertParameters["No"].DefaultValue = num2.ToString();
					SqlDataSource1.Insert();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "AddECR")
			{
				num = Convert.ToDouble(((TextBox)SearchGridView1.Controls[0].Controls[0].FindControl("txtLenMtrECR")).Text);
				num2 = Convert.ToDouble(((TextBox)SearchGridView1.Controls[0].Controls[0].FindControl("txtNRowECR")).Text);
				if (num != 0.0 && num2 != 0.0 && SId != "" && CompId != 0)
				{
					SqlDataSource1.InsertParameters["CompId"].DefaultValue = CompId.ToString();
					SqlDataSource1.InsertParameters["SessionId"].DefaultValue = SId;
					SqlDataSource1.InsertParameters["Length"].DefaultValue = num.ToString();
					SqlDataSource1.InsertParameters["No"].DefaultValue = num2.ToString();
					SqlDataSource1.Insert();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void SearchGridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationDelete();");
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = (LinkButton)e.Row.Cells[0].Controls[0];
			linkButton.Attributes.Add("onclick", "return confirmationDelete();");
		}
	}

	protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			if (e.CommandName == "AddLRF")
			{
				num = Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtLenMTR")).Text);
				num2 = Convert.ToDouble(((TextBox)GridView1.FooterRow.FindControl("txtNoRows")).Text);
				if (num != 0.0 && num2 != 0.0 && SId != "" && CompId != 0)
				{
					SqlDataSource2.InsertParameters["CompId"].DefaultValue = CompId.ToString();
					SqlDataSource2.InsertParameters["SessionId"].DefaultValue = SId;
					SqlDataSource2.InsertParameters["Length"].DefaultValue = num.ToString();
					SqlDataSource2.InsertParameters["No"].DefaultValue = num2.ToString();
					SqlDataSource2.Insert();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
			if (e.CommandName == "AddELR")
			{
				num = Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtLenMtrELR")).Text);
				num2 = Convert.ToDouble(((TextBox)GridView1.Controls[0].Controls[0].FindControl("txtNRowELR")).Text);
				if (num != 0.0 && num2 != 0.0 && SId != "" && CompId != 0)
				{
					SqlDataSource2.InsertParameters["CompId"].DefaultValue = CompId.ToString();
					SqlDataSource2.InsertParameters["SessionId"].DefaultValue = SId;
					SqlDataSource2.InsertParameters["Length"].DefaultValue = num.ToString();
					SqlDataSource2.InsertParameters["No"].DefaultValue = num2.ToString();
					SqlDataSource2.Insert();
					Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btnProceed_Click(object sender, EventArgs e)
	{
		try
		{
			string currDate = fun.getCurrDate();
			string currTime = fun.getCurrTime();
			double num = 0.0;
			int num2 = 0;
			num2 = Convert.ToInt32(RadioButtonList1.SelectedValue);
			string cmdText = fun.select("*", "tblDG_Gunrail_CrossRail_Dispatch_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
			SqlCommand selectCommand = new SqlCommand(cmdText, con);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataSet dataSet = new DataSet();
			sqlDataAdapter.Fill(dataSet);
			string cmdText2 = fun.select("*", "tblDG_Gunrail_LongRail_Dispatch_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
			SqlCommand selectCommand2 = new SqlCommand(cmdText2, con);
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand2);
			DataSet dataSet2 = new DataSet();
			sqlDataAdapter2.Fill(dataSet2);
			if (dataSet.Tables[0].Rows.Count > 0 && dataSet2.Tables[0].Rows.Count > 0 && txtPitch.Text != string.Empty)
			{
				num = Convert.ToDouble(txtPitch.Text);
				string cmdText3 = fun.insert("tblDG_Gunrail_Pitch_Dispatch_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,Pitch,WONo,Type", "'" + currDate + "','" + currTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + num + "','" + WONo + "','" + num2 + "'");
				SqlCommand sqlCommand = new SqlCommand(cmdText3, con);
				con.Open();
				sqlCommand.ExecuteNonQuery();
				con.Close();
				string cmdText4 = fun.select("Id", "tblDG_Gunrail_Pitch_Dispatch_Master", "CompId='" + CompId + "' Order By Id Desc");
				SqlCommand selectCommand3 = new SqlCommand(cmdText4, con);
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(selectCommand3);
				DataSet dataSet3 = new DataSet();
				sqlDataAdapter3.Fill(dataSet3);
				string text = dataSet3.Tables[0].Rows[0]["Id"].ToString();
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string cmdText5 = fun.insert("tblDG_Gunrail_CrossRail_Dispatch", "MId,Length,No", "'" + text + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["Length"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet.Tables[0].Rows[i]["No"].ToString()).ToString("N3")) + "'");
					SqlCommand sqlCommand2 = new SqlCommand(cmdText5, con);
					con.Open();
					sqlCommand2.ExecuteNonQuery();
					con.Close();
				}
				string cmdText6 = fun.delete("tblDG_Gunrail_CrossRail_Dispatch_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
				SqlCommand sqlCommand3 = new SqlCommand(cmdText6, con);
				con.Open();
				sqlCommand3.ExecuteNonQuery();
				con.Close();
				for (int j = 0; j < dataSet2.Tables[0].Rows.Count; j++)
				{
					string cmdText7 = fun.insert("tblDG_Gunrail_LongRail_Dispatch", "MId,Length,No", "'" + text + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[j]["Length"].ToString()).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(dataSet2.Tables[0].Rows[j]["No"].ToString()).ToString("N3")) + "'");
					SqlCommand sqlCommand4 = new SqlCommand(cmdText7, con);
					con.Open();
					sqlCommand4.ExecuteNonQuery();
					con.Close();
				}
				string cmdText8 = fun.delete("tblDG_Gunrail_LongRail_Dispatch_Temp", "CompId='" + CompId + "' AND SessionId='" + SId + "'");
				SqlCommand sqlCommand5 = new SqlCommand(cmdText8, con);
				con.Open();
				sqlCommand5.ExecuteNonQuery();
				con.Close();
				string cmdText9 = fun.select("Length,No,Pitch", "tblDG_Gunrail_LongRail_Dispatch,tblDG_Gunrail_Pitch_Dispatch_Master ", "tblDG_Gunrail_Pitch_Dispatch_Master.WONo='" + WONo + "' And tblDG_Gunrail_Pitch_Dispatch_Master.Id=tblDG_Gunrail_LongRail_Dispatch.MId ");
				SqlCommand selectCommand4 = new SqlCommand(cmdText9, con);
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(selectCommand4);
				DataSet dataSet4 = new DataSet();
				sqlDataAdapter4.Fill(dataSet4);
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				if (dataSet4.Tables[0].Rows.Count > 0)
				{
					for (int k = 0; k < dataSet4.Tables[0].Rows.Count; k++)
					{
						double num11 = 0.0;
						double num12 = 0.0;
						double num13 = Convert.ToDouble(dataSet4.Tables[0].Rows[k]["Length"]);
						double num14 = Convert.ToDouble(dataSet4.Tables[0].Rows[k]["No"]);
						num3 = fun.get(num13 / 6.0);
						num11 = num3 + 1.0 - 2.0;
						num5 += num11 * num14;
						num7 = Convert.ToDouble(dataSet4.Tables[0].Rows[k]["Pitch"]);
						num4 = fun.get(num13 / num7 + 1.0);
						num12 = num4 - num11;
						num6 += num12 * num14;
						num8 += num13 * num14;
						num9 += num14 * num14;
						num10 += num14;
					}
				}
				string cmdText10 = fun.select("Length,No", "tblDG_Gunrail_CrossRail_Dispatch,tblDG_Gunrail_Pitch_Dispatch_Master ", "tblDG_Gunrail_Pitch_Dispatch_Master.WONo='" + WONo + "'  And tblDG_Gunrail_Pitch_Dispatch_Master.Id=tblDG_Gunrail_CrossRail_Dispatch.MId ");
				SqlCommand selectCommand5 = new SqlCommand(cmdText10, con);
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(selectCommand5);
				DataSet dataSet5 = new DataSet();
				sqlDataAdapter5.Fill(dataSet5);
				double num15 = 0.0;
				double num16 = 0.0;
				if (dataSet5.Tables[0].Rows.Count > 0)
				{
					for (int l = 0; l < dataSet5.Tables[0].Rows.Count; l++)
					{
						double num17 = Convert.ToDouble(dataSet5.Tables[0].Rows[l]["Length"]);
						double num18 = Convert.ToDouble(dataSet5.Tables[0].Rows[l]["No"]);
						num15 += num17 * num18;
						num16 += num18;
					}
				}
				int bOMCId = fun.getBOMCId(WONo, CompId, FinYearId);
				string cmdText11 = fun.select("CId", "tblDG_GUNRAIL_BOM_Master", " PId='0'");
				SqlCommand selectCommand6 = new SqlCommand(cmdText11, con);
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(selectCommand6);
				DataSet dataSet6 = new DataSet();
				sqlDataAdapter6.Fill(dataSet6, "tblDG_GUNRAIL_BOM_Master");
				for (int m = 0; m < dataSet6.Tables[0].Rows.Count; m++)
				{
					int num19 = Convert.ToInt32(dataSet6.Tables[0].Rows[m][0]);
					if (num19 != 16 && num19 != 46)
					{
						fun.CopyGunRailToWO_Dispatch(num19, WONo, CompId, SId, FinYearId, 0, bOMCId, num16, num6, num5, num10, num15, num8);
					}
				}
				Page.Response.Redirect(Page.Request.Url.ToString(), endResponse: true);
			}
			else
			{
				string empty = string.Empty;
				empty = "Invalid data entry.";
				base.ClientScript.RegisterStartupScript(GetType(), "myalert", "alert('" + empty + "');", addScriptTags: true);
			}
		}
		catch (Exception)
		{
		}
	}

	protected void btncancel_Click(object sender, EventArgs e)
	{
		base.Response.Redirect("~/Module/SalesDistribution/Transactions/Dispatch_Gunrail_WO_Grid.aspx?ModId=2&SubModId=132");
	}
}
