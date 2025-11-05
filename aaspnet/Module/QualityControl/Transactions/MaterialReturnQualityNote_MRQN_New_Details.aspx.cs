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

public partial class Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    string fyid = "";
    string mrnno = "";
    int CompId = 0;
    string Sid = "";
    string MId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            fyid = Request.QueryString["fyid"].ToString();
            mrnno = Request.QueryString["mrnno"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            MId = Request.QueryString["Id"].ToString();
            Sid = Session["username"].ToString();

            if (!IsPostBack)
            {
                this.loadgrid();
            }

            foreach (GridViewRow grv1 in GridView3.Rows)
            {
                ((CheckBox)grv1.FindControl("ck")).Checked = true;
                double Qty = Convert.ToDouble(((Label)grv1.FindControl("lblretqty")).Text) - (Convert.ToDouble(((Label)grv1.FindControl("lblAccpQty")).Text) + Convert.ToDouble(((Label)grv1.FindControl("lblScrap")).Text));


                if (Qty > 0)
                {
                    ((CheckBox)grv1.FindControl("ck")).Checked = true;
                    ((CheckBox)grv1.FindControl("ck")).Visible = true;
                }
                else
                {
                    ((CheckBox)grv1.FindControl("ck")).Checked = false;
                    ((CheckBox)grv1.FindControl("ck")).Visible = false;
                }
            }
        }
        catch (Exception ex) { }
    }

    public void loadgrid()
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            string StrSql = fun.select("tblInv_MaterialReturn_Details.Id,tblInv_MaterialReturn_Details.ItemId,tblInv_MaterialReturn_Details.DeptId,tblInv_MaterialReturn_Details.WONo,tblInv_MaterialReturn_Details.RetQty,tblInv_MaterialReturn_Details.Remarks", "tblInv_MaterialReturn_Master,tblInv_MaterialReturn_Details", "tblInv_MaterialReturn_Master.CompId='" + CompId + "' AND tblInv_MaterialReturn_Master.Id=tblInv_MaterialReturn_Details.MId AND tblInv_MaterialReturn_Master.Id='" + MId + "'");

            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
            DataSet DSSql = new DataSet();
            DataTable dt = new DataTable();

            dasupId.Fill(DSSql);
            
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ManfDesc", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("UOMBasic", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Dept", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("RetQty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("RecQty", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ItemId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Qty", typeof(double)));

            DataRow dr;
            string ItemCode = "";
            string ManfDesc = "";
            string UomBasic = "";
            double StockQty = 0;
            string Dept = "";
            string wono = "";
            double RetQty = 0;
            string Remark = "";
            for (int i = 0; i < DSSql.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();
                string StrIcode = fun.select("ItemCode,ManfDesc,UOMBasic,StockQty", "tblDG_Item_Master", "Id='" + DSSql.Tables[0].Rows[i]["ItemId"].ToString() + "' AND CompId='" + CompId + "'");
                SqlCommand cmdIcode = new SqlCommand(StrIcode, con);
                SqlDataAdapter daIcode = new SqlDataAdapter(cmdIcode);
                DataSet DSIcode = new DataSet();
                daIcode.Fill(DSIcode);
                // For ItemCode

                if (DSIcode.Tables[0].Rows.Count > 0)
                {
                    ItemCode = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DSSql.Tables[0].Rows[i]["ItemId"].ToString()));

                    // For Purch Desc
                    ManfDesc = DSIcode.Tables[0].Rows[0]["ManfDesc"].ToString();
                    // For Manf. Desc
                    StockQty =Convert.ToDouble(decimal.Parse( DSIcode.Tables[0].Rows[0]["StockQty"].ToString()).ToString("N3"));
                    // for UOM Purchase  from Unit Master table
                    string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIcode.Tables[0].Rows[0]["UOMBasic"].ToString() + "'");
                    SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                    SqlDataAdapter daPurch = new SqlDataAdapter(cmdPurch);
                    DataSet DSPurch = new DataSet();
                    daPurch.Fill(DSPurch);
                    if (DSPurch.Tables[0].Rows.Count > 0)
                    {
                        UomBasic = DSPurch.Tables[0].Rows[0][0].ToString();
                    }
                }
                // for Department from Dept Master table
                string sqlDept = fun.select("Symbol", "tblHR_Departments", "Id='" + DSSql.Tables[0].Rows[i]["DeptId"].ToString() + "'");
                SqlCommand cmdDept = new SqlCommand(sqlDept, con);
                SqlDataAdapter daDept = new SqlDataAdapter(cmdDept);
                DataSet DSDept = new DataSet();
                daDept.Fill(DSDept);
                if (DSDept.Tables[0].Rows.Count > 0)
                {
                    Dept = DSDept.Tables[0].Rows[0][0].ToString();
                }

                // For ItemCode
                dr[0] = ItemCode;

                // For ManfDesc 
                dr[1] = ManfDesc;
                // For UOMBasic 
                dr[2] = UomBasic;
                dr[3] = Dept;
                if (DSSql.Tables[0].Rows[i]["WONo"].ToString() != "")
                {
                    wono = DSSql.Tables[0].Rows[i]["WONo"].ToString();
                    dr[4] = wono;
                }
                else
                {
                    wono = "NA";
                    dr[4] = wono;
                }

                RetQty =Convert.ToDouble(decimal.Parse((DSSql.Tables[0].Rows[i]["RetQty"]).ToString()).ToString("N3"));
                dr[5] = RetQty;
                Remark = DSSql.Tables[0].Rows[i]["Remarks"].ToString();
                dr[6] = Remark;
                dr[7] = DSSql.Tables[0].Rows[i]["Id"].ToString();

                string sqlmindetails = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as sum_AcceptedQty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + DSSql.Tables[0].Rows[i]["Id"].ToString() + "'");

                SqlCommand cmdmindetails = new SqlCommand(sqlmindetails, con);
                SqlDataAdapter damindetails = new SqlDataAdapter(cmdmindetails);
                DataSet DSmindetails = new DataSet();
                damindetails.Fill(DSmindetails);

                if (DSmindetails.Tables[0].Rows[0]["sum_AcceptedQty"] != DBNull.Value)
                {
                    dr[8] = Convert.ToDouble(decimal.Parse((DSmindetails.Tables[0].Rows[0]["sum_AcceptedQty"]).ToString()).ToString("N3"));
                }
                else
                {
                    dr[8] = 0;
                }

                dr[9] = DSSql.Tables[0].Rows[i]["ItemId"].ToString();
                string sqlscr = fun.select("tblQC_Scrapregister.Qty As Qty ", "tblQC_Scrapregister,tblQc_MaterialReturnQuality_Details,tblQc_MaterialReturnQuality_Master", "tblQc_MaterialReturnQuality_Master.Id=tblQC_Scrapregister.MRQNId  And  tblQc_MaterialReturnQuality_Details.Id= tblQC_Scrapregister.MRQNDId  AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + DSSql.Tables[0].Rows[i]["Id"].ToString() + "' And tblQC_Scrapregister.CompId='" + CompId + "'  ");
                SqlCommand cmdsc = new SqlCommand(sqlscr, con);
                SqlDataAdapter dasc = new SqlDataAdapter(cmdsc);
                DataSet dssc = new DataSet();
                dasc.Fill(dssc);

                if (dssc.Tables[0].Rows.Count > 0)
                {
                    dr[10] = Convert.ToDouble(decimal.Parse((dssc.Tables[0].Rows[0]["Qty"]).ToString()).ToString("N3"));
                }
                else
                {

                    dr[10] = 0;
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView3.DataSource = dt;
            GridView3.DataBind();

        }
       catch (Exception ex) { }
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView3.PageIndex = e.NewPageIndex;
            this.loadgrid();
        }
        catch (Exception ex) { }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaterialReturnQualityNote_MRQN_New.aspx?ModId=10&SubModId=49");
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
       try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            con.Open();

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            int CompId = Convert.ToInt32(Session["compid"]);

            string sqlmin = fun.select("MRQNNo", "tblQc_MaterialReturnQuality_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by MRQNNo Desc");

            SqlCommand cmdmin = new SqlCommand(sqlmin, con);
            SqlDataAdapter damin = new SqlDataAdapter(cmdmin);
            DataSet DSmin = new DataSet();
            damin.Fill(DSmin, "tblQc_MaterialReturnQuality_Master");
            string MRQNno = "";
            if (DSmin.Tables[0].Rows.Count > 0)
            {
                int MRQNstr = Convert.ToInt32(DSmin.Tables[0].Rows[0][0].ToString()) + 1;
                MRQNno = MRQNstr.ToString("D4");
            }
            else
            {
                MRQNno = "0001";
            }

            // for scrap no....
            string sqls = fun.select("ScrapNo", "tblQC_Scrapregister", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "'  Order by ScrapNo Desc");

            SqlCommand cmds = new SqlCommand(sqls, con);
            SqlDataAdapter das = new SqlDataAdapter(cmds);
            DataSet DSs = new DataSet();
            damin.Fill(DSs, "tblQc_MaterialReturnQuality_Master");
            string scrno = "";
            if (DSs.Tables[0].Rows.Count > 0)
            {
                int Scrstr = Convert.ToInt32(DSmin.Tables[0].Rows[0][0].ToString()) + 1;
                scrno = Scrstr.ToString("D4");
            }
            else
            {
                scrno = "0001";
            }

                int y=0;                
                int x = 0;
                int k = 0;
                foreach (GridViewRow grv in GridView3.Rows)
                {
                    if (((CheckBox)grv.FindControl("ck")).Checked == true)
                    {
                        x++;
                        double RetQty = 0;
                        RetQty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblretqty")).Text).ToString()).ToString("N3"));
                        double AccpQty = 0;
                        AccpQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("txtAccpQty")).Text).ToString()).ToString("N3"));

                        double Qty = 0;
                        Qty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblretqty")).Text).ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblAccpQty")).Text).ToString()).ToString("N3"));

                        double BalStkQty = 0;

                        if (AccpQty > 0 && fun.NumberValidationQty(AccpQty.ToString()) == true && (Qty >= AccpQty))
                        {
                            y++;
                        }

                    }
                }
                

                if (x == y && y > 0)
                {


                    int u = 1;
                    string TransId = "";
                    foreach (GridViewRow grv in GridView3.Rows)
                    {
                        if (((CheckBox)grv.FindControl("ck")).Checked == true)
                        {
                            string ItemId = ((Label)grv.FindControl("lblitemid")).Text;
                            string Id = ((Label)grv.FindControl("lblId")).Text;
                            int type = Convert.ToInt32(((DropDownList)grv.FindControl("Drptype")).SelectedValue);

                            double RetQty = 0;
                            RetQty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblretqty")).Text).ToString()).ToString("N3"));

                            double AccpQty = 0;
                            AccpQty = Convert.ToDouble(decimal.Parse((((TextBox)grv.FindControl("txtAccpQty")).Text).ToString()).ToString("N3"));

                            double Qty = 0;
                            Qty = Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblretqty")).Text).ToString()).ToString("N3")) - Convert.ToDouble(decimal.Parse((((Label)grv.FindControl("lblAccpQty")).Text).ToString()).ToString("N3"));

                            double BalStkQty = 0;

                            if (AccpQty > 0 && fun.NumberValidationQty(AccpQty.ToString()) == true && (Qty>= AccpQty))
                            {
                                if (u == 1)
                                {
                                    string insert = fun.insert("tblQc_MaterialReturnQuality_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,MRQNNo,MRNNo,MRNId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + MRQNno + "','" + mrnno + "','" + MId + "'");
                                    SqlCommand cmd = new SqlCommand(insert, con);
                                    cmd.ExecuteNonQuery();
                                    u = 0;

                                    string sqlid = fun.select("Id", "tblQc_MaterialReturnQuality_Master", "CompId='" + CompId + "' Order by Id Desc");
                                    SqlCommand cmdid = new SqlCommand(sqlid, con);
                                    SqlDataAdapter daid = new SqlDataAdapter(cmdid);
                                    DataSet DSid = new DataSet();
                                    daid.Fill(DSid, "tblQc_MaterialReturnQuality_Master");

                                    TransId = DSid.Tables[0].Rows[0]["Id"].ToString();
                                }

                                string insert2 = fun.insert("tblQc_MaterialReturnQuality_Details", "MId,MRQNNo,MRNId,AcceptedQty", "'" + TransId + "','" + MRQNno + "','" + Id + "','" + AccpQty + "'");
                                SqlCommand cmd2 = new SqlCommand(insert2, con);
                                cmd2.ExecuteNonQuery();

                                if (type == 1)
                                {
                                    string sqlid1 = fun.select("Id", "tblQc_MaterialReturnQuality_Details", "MId='" + TransId + "' Order by Id Desc");
                                    SqlCommand cmdid1 = new SqlCommand(sqlid1, con);
                                    SqlDataAdapter daid1 = new SqlDataAdapter(cmdid1);
                                    DataSet DSid1 = new DataSet();
                                    daid1.Fill(DSid1, "tblQc_MaterialReturnQuality_Master");
                                    string DId = "";
                                    double Acqty = 0;
                                    if (DSid1.Tables[0].Rows.Count > 0)
                                    {
                                        DId = DSid1.Tables[0].Rows[0]["Id"].ToString();
                                    }

                                    string sqlmindetails = fun.select("sum(tblQc_MaterialReturnQuality_Details.AcceptedQty) as Qty", "tblQc_MaterialReturnQuality_Master,tblQc_MaterialReturnQuality_Details", "tblQc_MaterialReturnQuality_Master.CompId='" + CompId + "' AND tblQc_MaterialReturnQuality_Master.Id=tblQc_MaterialReturnQuality_Details.MId AND tblQc_MaterialReturnQuality_Details.MRNId='" + Id + "'");
                                    SqlCommand cmdmindetails = new SqlCommand(sqlmindetails, con);
                                    SqlDataAdapter damindetails = new SqlDataAdapter(cmdmindetails);
                                    DataSet DSmindetails = new DataSet();
                                    damindetails.Fill(DSmindetails);

                                    if (DSmindetails.Tables[0].Rows.Count > 0)
                                    {
                                        Acqty = Convert.ToDouble(decimal.Parse((DSmindetails.Tables[0].Rows[0]["Qty"]).ToString()).ToString("N3"));
                                    }

                                    double srcqty = 0;
                                    srcqty = RetQty - Acqty;

                                    string insertscrap = fun.insert("tblQC_Scrapregister", "SysDate,SysTime,CompId,FinYearId,SessionId,MRQNId,MRQNDId,ItemId,ScrapNo,Qty", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + Sid + "','" + TransId + "','" + DId + "','" + ItemId + "','" + scrno + "','" + srcqty + "'");
                                    SqlCommand cmdscrsp = new SqlCommand(insertscrap, con);
                                    cmdscrsp.ExecuteNonQuery();
                                }

                                string sqlstkqty = fun.select("StockQty", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + ItemId + "'");
                                SqlCommand cmd5 = new SqlCommand(sqlstkqty, con);
                                SqlDataAdapter dastk5 = new SqlDataAdapter(cmd5);
                                DataSet dsstk5 = new DataSet();
                                dastk5.Fill(dsstk5);

                                if (dsstk5.Tables[0].Rows.Count > 0)
                                {
                                    BalStkQty = Convert.ToDouble(decimal.Parse((dsstk5.Tables[0].Rows[0]["StockQty"]).ToString()).ToString("N3")) + AccpQty;
                                }

                                string update = fun.update("tblDG_Item_Master", "StockQty='" + BalStkQty + "'", "CompId='" + CompId + "' AND Id='" + ItemId + "'");
                                SqlCommand cmd4 = new SqlCommand(update, con);
                                cmd4.ExecuteNonQuery();
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    string myStringVariable = string.Empty;
                    myStringVariable = "Invalid input data.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }

                if (k > 0)
                {
                    Response.Redirect("MaterialReturnQualityNote_MRQN_New.aspx?ModId=10&SubModId=49");
                }
                
        }

      catch (Exception es) { }
    }

}

