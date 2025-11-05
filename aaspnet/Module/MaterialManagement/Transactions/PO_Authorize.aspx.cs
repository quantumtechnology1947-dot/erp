using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Module_MaterialManagement_Transactions_PO_Authorize : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    int FinYear = 0;
    string spr = "";
    string emp = "";
    string FyId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            FyId = Session["finyear"].ToString();
            if (!IsPostBack)
            {
                this.makegrid(spr, emp);
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void makegrid(string sprno, string empid)
    {
        try
        {
            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);
            con.Open();

            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmdNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GenBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("CheckedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ApprovedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Sup", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Code", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AmendmentNo", typeof(string)));
            DataRow dr;

            CompId = Convert.ToInt32(Session["compid"]);

            string x = "";

            if (drpfield.SelectedValue == "1")
            {
                if (txtPONo.Text != "")
                {
                    x = " AND PONo='" + txtPONo.Text + "'";
                }
            }

            string sql = fun.select("*", "tblMM_PO_Master", "CompId='" + CompId + "' AND FinYearId<='" + FyId + "'    AND Approve='1'" + x + " AND Authorize='0' Order by Id Desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS);
            for (int p = 0; p < DS.Tables[0].Rows.Count; p++)
            {
                dr = dt.NewRow();

                string sql2 = fun.select("Title+'. '+EmployeeName As EmpName", "tblHR_OfficeStaff", "CompId='" + CompId + "' AND EmpId='" + DS.Tables[0].Rows[p]["SessionId"] + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                da2.Fill(DS2);

                string z = "";

                if (drpfield.SelectedValue == "0")
                {
                    if (txtSupplier.Text != "")
                    {
                        z = " AND SupplierId='" + fun.getCode(txtSupplier.Text) + "'";
                    }
                    else
                    {
                        z = " AND SupplierId='" + DS.Tables[0].Rows[p]["SupplierId"].ToString() + "'";
                    }
                }
                else
                {
                    z = " AND SupplierId='" + DS.Tables[0].Rows[p]["SupplierId"].ToString() + "'";
                }

                string sql3 = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'" + z);
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                DataSet DS3 = new DataSet();
                da3.Fill(DS3);

                dr[0] = DS.Tables[0].Rows[p]["PONo"].ToString();
                dr[1] = fun.FromDateDMY(DS.Tables[0].Rows[p]["SysDate"].ToString());
                dr[2] = DS.Tables[0].Rows[p]["AmendmentNo"].ToString();
                dr[3] = DS2.Tables[0].Rows[0]["EmpName"].ToString();

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Checked"]) == 1)
                {
                    dr[4] = fun.FromDateDMY(DS.Tables[0].Rows[p]["CheckedDate"].ToString());
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Approve"]) == 1)
                {
                    dr[5] = fun.FromDateDMY(DS.Tables[0].Rows[p]["ApproveDate"].ToString());
                }

                if (Convert.ToInt32(DS.Tables[0].Rows[p]["Authorize"]) == 1)
                {
                    dr[6] = fun.FromDateDMY(DS.Tables[0].Rows[p]["AuthorizeDate"].ToString());
                }

                dr[7] = DS.Tables[0].Rows[p]["Id"].ToString(); 
                dr[8] = DS3.Tables[0].Rows[0]["SupplierName"].ToString();
                dr[9] = DS.Tables[0].Rows[p]["SupplierId"].ToString();

                string stryr = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DS.Tables[0].Rows[p]["FinYearId"].ToString() + "'");
                SqlCommand cmdyr = new SqlCommand(stryr, con);
                SqlDataAdapter dayr = new SqlDataAdapter(cmdyr);
                DataSet DSyr = new DataSet();
                dayr.Fill(DSyr);

                if (DSyr.Tables[0].Rows.Count > 0)
                {
                    dr[10] = DSyr.Tables[0].Rows[0]["FinYear"].ToString();
                }
                dr[11] = DS.Tables[0].Rows[p]["AmendmentNo"].ToString();
                if (DS.Tables[0].Rows[p]["SupplierId"].ToString() == DS3.Tables[0].Rows[0]["SupplierId"].ToString())
                {
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            foreach (GridViewRow grv in GridView2.Rows)
            {
                if (((Label)grv.FindControl("lblAutho")).Text != "")
                {
                    CheckBox chk = (CheckBox)grv.FindControl("CK");
                    chk.Visible = false;
                }
            }

            con.Close();
        }
        catch (Exception ess)
        {

        }
    }

    string parentPage = "PO_Authorize.aspx";
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();

        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYear = Convert.ToInt32(Session["finyear"]);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();



            if (e.CommandName == "view")
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                string pocode = ((Label)row.FindControl("lblsprno")).Text;
                string supcode = ((Label)row.FindControl("lblsupcode")).Text;
                string Id = ((Label)row.FindControl("lblId")).Text;
                string AmdNo = ((Label)row.FindControl("lblAmendmentNo")).Text;

                string StrFlag = fun.select("PRSPRFlag", "tblMM_PO_Master", "Id='" + Id + "' AND SupplierId='" + supcode + "' And PONo='" + pocode + "' AND CompId='" + CompId + "'");

                SqlCommand cmdFlag = new SqlCommand(StrFlag, con);
                SqlDataAdapter daFlag = new SqlDataAdapter(cmdFlag);
                DataSet DSFlag = new DataSet();
                daFlag.Fill(DSFlag);

                if (DSFlag.Tables[0].Rows[0][0].ToString() == "0")
                {
                    string Trans = string.Empty;
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("PO_PR_View_Print_Details.aspx?mid=" + Id + "&pono=" + pocode + "&Code=" + supcode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "&Trans=" + Trans + "&ModId=6&SubModId=35&parentpage=" + parentPage);
                }
                else
                {
                    string getRandomKey = fun.GetRandomAlphaNumeric();
                    Response.Redirect("PO_SPR_View_Print_Details.aspx?mid=" + Id + "&pono=" + pocode + "&Code=" + supcode + "&AmdNo=" + AmdNo + "&Key=" + getRandomKey + "&ModId=6&SubModId=35&parentpage=" + parentPage);
                }

                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

        }
        catch (Exception es)
        {

        }

        finally
        {
            con.Close();
        }
    }

    protected void drpfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpfield.SelectedValue == "1")
            {
                txtPONo.Visible = true;
                txtPONo.Text = "";
                txtSupplier.Visible = false;
                this.makegrid(spr, emp);
            }
            else
            {
                txtPONo.Visible = false;
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                this.makegrid(spr, emp);
            }
        }

        catch (Exception ex) { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        this.makegrid(txtPONo.Text, txtSupplier.Text);
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_master");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.makegrid(spr, emp);
        }
        catch (Exception ex) { }
    }

    protected void Auth_Click(object sender, EventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();

        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYear = Convert.ToInt32(Session["finyear"]);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            int i = 0;

            foreach (GridViewRow grv in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)grv.FindControl("CK");

                if (chk.Checked == true)
                {
                    string pono = ((Label)grv.FindControl("lblsprno")).Text;
                    int id = Convert.ToInt32(((Label)grv.FindControl("lblId")).Text);

                    string sql3 = fun.update("tblMM_PO_Master", "Authorize='1',AuthorizedBy='" + sId + "',AuthorizeDate='" + CDate + "',AuthorizeTime='" + CTime + "'", "CompId='" + CompId + "' AND PONo='" + pono + "' And Id='" + id + "' ");
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.ExecuteNonQuery();

                    string sql = fun.select("PRSPRFlag,AmendmentNo", "tblMM_PO_Master", "Id='" + id + "' AND CompId='" + CompId + "' AND PONo='" + pono + "'And FinYearId='" + FinYear + "'");

                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    da.Fill(DS);

                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        string sql4 = fun.select("*", "tblMM_PO_Details", "MId='" + id + "' AND PONo='" + pono + "'");
                        SqlCommand cmd4 = new SqlCommand(sql4, con);
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                        DataSet DS4 = new DataSet();
                        da4.Fill(DS4);

                        if (DS.Tables[0].Rows[0]["PRSPRFlag"].ToString() == "0") // For PR
                        {
                            for (int k = 0; k < DS4.Tables[0].Rows.Count; k++)
                            {
                                string sql6 = fun.select("tblMM_PR_Details.ItemId", "tblMM_PR_Details,tblMM_PR_Master", "tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo AND tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Master.PRNo='" + DS4.Tables[0].Rows[k]["PRNo"].ToString() + "' And tblMM_PR_Details.Id='" + DS4.Tables[0].Rows[k]["PRId"].ToString() + "' AND tblMM_PR_Master.CompId='" + CompId + "'");

                                SqlCommand cmd6 = new SqlCommand(sql6, con);
                                SqlDataAdapter da6 = new SqlDataAdapter(cmd6);
                                DataSet DS6 = new DataSet();
                                da6.Fill(DS6);

                                if (DS6.Tables[0].Rows.Count > 0)
                                {
                                    string sql8 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,PONo,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,POId,PRId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYear + "','" + sId + "','" + pono + "','" + DS6.Tables[0].Rows[0][0].ToString() + "','" + DS4.Tables[0].Rows[k]["Rate"].ToString() + "','" + DS4.Tables[0].Rows[k]["Discount"].ToString() + "','" + DS4.Tables[0].Rows[k]["PF"].ToString() + "','" + DS4.Tables[0].Rows[k]["ExST"].ToString() + "','" + DS4.Tables[0].Rows[k]["VAT"].ToString() + "','" + DS.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + id + "','" + DS4.Tables[0].Rows[k]["PRId"].ToString() + "'");

                                    SqlCommand cmd8 = new SqlCommand(sql8, con);
                                    cmd8.ExecuteNonQuery();
                                    string sql21 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',Type='2', LockedbyTranaction='" + sId + "',LockDate='" + CDate + "',LockTime='" + CTime + "'", "ItemId='" + DS6.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + CompId + "'");
                                    SqlCommand cmd21 = new SqlCommand(sql21, con);
                                    cmd21.ExecuteNonQuery();
                                    i++;
                                }
                            }
                        }
                        else if (DS.Tables[0].Rows[0][0].ToString() == "1") // For SPR
                        {

                            for (int k = 0; k < DS4.Tables[0].Rows.Count; k++)
                            {
                                string sql7 = fun.select("tblMM_SPR_Details.ItemId", "tblMM_SPR_Details,tblMM_SPR_Master", " tblMM_SPR_Master.SPRNo=tblMM_SPR_Details.SPRNo AND tblMM_SPR_Master.Id=tblMM_SPR_Details.MId And tblMM_SPR_Master.SPRNo='" + DS4.Tables[0].Rows[k]["SPRNo"].ToString() + "'And tblMM_SPR_Details.Id='" + DS4.Tables[0].Rows[k]["SPRId"].ToString() + "' AND tblMM_SPR_Master.CompId='" + CompId + "'");

                                SqlCommand cmd7 = new SqlCommand(sql7, con);
                                SqlDataAdapter da7 = new SqlDataAdapter(cmd7);
                                DataSet DS7 = new DataSet();
                                da7.Fill(DS7);

                                if (DS7.Tables[0].Rows.Count > 0)
                                {
                                    string sql8 = fun.insert("tblMM_Rate_Register", "SysDate,SysTime,CompId,FinYearId,SessionId,PONo,ItemId,Rate,Discount,PF,ExST,VAT,AmendmentNo,POId,SPRId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYear + "','" + sId + "','" + pono + "','" + DS7.Tables[0].Rows[0][0].ToString() + "','" + DS4.Tables[0].Rows[k]["Rate"].ToString() + "','" + DS4.Tables[0].Rows[k]["Discount"].ToString() + "','" + DS4.Tables[0].Rows[k]["PF"].ToString() + "','" + DS4.Tables[0].Rows[k]["ExST"].ToString() + "','" + DS4.Tables[0].Rows[k]["VAT"].ToString() + "','" + DS.Tables[0].Rows[0]["AmendmentNo"].ToString() + "','" + id + "','" + DS4.Tables[0].Rows[k]["SPRId"].ToString() + "'");
                                    SqlCommand cmd8 = new SqlCommand(sql8, con);
                                    cmd8.ExecuteNonQuery();


                                    string sql21 = fun.update("tblMM_RateLockUnLock_Master", "LockUnlock='0',Type='2',LockedbyTranaction='" + sId + "',LockDate='" + CDate + "',LockTime='" + CTime + "'", "ItemId='" + DS7.Tables[0].Rows[0][0].ToString() + "' AND CompId='" + CompId + "'");
                                    SqlCommand cmd21 = new SqlCommand(sql21, con);
                                    cmd21.ExecuteNonQuery();

                                    i++;
                                }
                            }

                        }
                    }
                }
            }

            if (i > 0)
            {
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                string mystring = string.Empty;
                mystring = "No record is found to authorized.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
        }
        catch (Exception es)
        {

        }
    }

}
