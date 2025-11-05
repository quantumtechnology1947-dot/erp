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
using Telerik.Web.UI;
using System.Collections.Generic;

public partial class Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    public int pid = 0;
    public int cid = 0;

    string sId = "";
    int CompId = 0;
    int FinYearId = 0;

    int WOId = 0;
    string WONo = "";
    string connStr = string.Empty;

    SqlConnection con;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);

            connStr = fun.Connection();
            con = new SqlConnection(connStr);

            if (!string.IsNullOrEmpty(Request.QueryString["WOId"]))
            {
                WOId = Convert.ToInt32(Request.QueryString["WOId"].ToString());
            }

            if (!string.IsNullOrEmpty(Request.QueryString["WONo"]))
            {
                WONo = Request.QueryString["WONo"].ToString();
            }
            lblWono.Text = WONo;
            string StrSql = fun.select("TaskProjectTitle,CustomerId", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND Id='" + WOId + "'");

            SqlCommand cmdwono = new SqlCommand(StrSql, con);
            SqlDataAdapter DAwono = new SqlDataAdapter(cmdwono);
            DataSet DSwono = new DataSet();
            DAwono.Fill(DSwono);
            if (DSwono.Tables[0].Rows.Count > 0)
            {
                lblProjectTitle.Text = DSwono.Tables[0].Rows[0]["TaskProjectTitle"].ToString();
                string StrCust = fun.select("CustomerName,CustomerId", "SD_Cust_Master", "CompId='" + CompId + "'  AND  CustomerId='" + DSwono.Tables[0].Rows[0]["CustomerId"].ToString() + "'");

                SqlCommand cmdCust = new SqlCommand(StrCust, con);
                SqlDataAdapter daCust = new SqlDataAdapter(cmdCust);
                DataSet DSCust = new DataSet();
                daCust.Fill(DSCust);
                if (DSCust.Tables[0].Rows.Count > 0)
                {
                    lblCustName.Text = DSCust.Tables[0].Rows[0]["CustomerName"].ToString() + " [ " + DSCust.Tables[0].Rows[0]["CustomerId"].ToString() + " ]";
                }
            }

            if (!Page.IsPostBack)
            {
                this.loaddata();
            }

        }
         catch (Exception ex)
        {

        }
    }


    public void loaddata()
    {
       try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            string StrSql = fun.select("*", "tblDG_BOM_Master", "WONo='" + WONo + "' AND FinYearId<='" + FinYearId + "'And CompId='" + CompId + "' ");

            SqlCommand cmdwono = new SqlCommand(StrSql, con);
            SqlDataAdapter DAwono = new SqlDataAdapter(cmdwono);
            DataSet DSwono = new DataSet();
            DAwono.Fill(DSwono);
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));//0
            dt.Columns.Add(new System.Data.DataColumn("PId", typeof(int)));//1
            dt.Columns.Add(new System.Data.DataColumn("CId", typeof(int)));//2
            dt.Columns.Add(new System.Data.DataColumn("ItemCode", typeof(string)));//3
            dt.Columns.Add(new System.Data.DataColumn("Description", typeof(string)));//4
            dt.Columns.Add(new System.Data.DataColumn("UOM", typeof(string)));//5
            dt.Columns.Add(new System.Data.DataColumn("BOMQty", typeof(string)));//6
            dt.Columns.Add(new System.Data.DataColumn("Download", typeof(string)));//7
            dt.Columns.Add(new System.Data.DataColumn("DownloadSpec", typeof(string)));//8           
            dt.Columns.Add(new System.Data.DataColumn("ItemId", typeof(int)));//9
            dt.Columns.Add(new System.Data.DataColumn("TotalMCNQty", typeof(double)));//10
            dt.Columns.Add(new System.Data.DataColumn("MCNQty", typeof(double)));//11
            DataRow dr;
            for (int i = 0; i < DSwono.Tables[0].Rows.Count; i++)
            {
                dr = dt.NewRow();

                dr[0] = Convert.ToInt32(DSwono.Tables[0].Rows[i]["Id"]);
                dr[1] = Convert.ToInt32(DSwono.Tables[0].Rows[i]["PId"]);
                dr[2] = Convert.ToInt32(DSwono.Tables[0].Rows[i]["CId"]);

                string icSql = fun.select("*", "tblDG_Item_Master", "Id='" + Convert.ToInt32(DSwono.Tables[0].Rows[i]["ItemId"]) + "'");
                SqlCommand cmditemCode = new SqlCommand(icSql, con);
                SqlDataAdapter Dr = new SqlDataAdapter(cmditemCode);
                DataSet DsIt = new DataSet();
                Dr.Fill(DsIt, "tblDG_Item_Master");
                if (DsIt.Tables[0].Rows.Count > 0)
                {
                    if (DsIt.Tables[0].Rows[0]["CId"] != DBNull.Value)
                    {
                        dr[3] = DsIt.Tables[0].Rows[0]["ItemCode"].ToString();
                    }

                    else
                    {
                        dr[3] = DsIt.Tables[0].Rows[0]["PartNo"].ToString();
                    }
                    dr[4] = DsIt.Tables[0].Rows[0]["ManfDesc"].ToString();

                    string utSql = fun.select("*", "Unit_Master", "Id='" + Convert.ToInt32(DsIt.Tables[0].Rows[0]["UOMBasic"]) + "'");
                    SqlCommand cmdut = new SqlCommand(utSql, con);
                    SqlDataAdapter Drut = new SqlDataAdapter(cmdut);
                    DataSet Dsut = new DataSet();
                    Drut.Fill(Dsut, "Unit_Master");
                    if (Dsut.Tables[0].Rows.Count > 0)
                    {
                        dr[5] = Dsut.Tables[0].Rows[0]["Symbol"].ToString();
                    }

                    if (!string.IsNullOrEmpty(DsIt.Tables[0].Rows[0]["FileName"].ToString()))
                    {
                        dr[7] = "View";
                    }

                    if (!string.IsNullOrEmpty(DsIt.Tables[0].Rows[0]["AttName"].ToString()))
                    {
                        dr[8] = "View";
                    }
                }

                string cmdStr1 = fun.select("Qty", "tblDG_BOM_Master", "WONo='" + WONo + "' AND PId='" + dr[1] + "'And CId='" + dr[2] + "'");
                SqlCommand cmd1 = new SqlCommand(cmdStr1, con);
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1, "tblDG_BOM_Master");
                double z = 0;
                if (DS1.Tables[0].Rows.Count > 0)
                {
                    z = Convert.ToDouble(decimal.Parse(DS1.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3"));
                }

                dr[6] = decimal.Parse(z.ToString()).ToString("N3");
                dr[9] = Convert.ToInt32(DSwono.Tables[0].Rows[i]["ItemId"]);


                string cmdStr2 = fun.select("sum(MCNQty) as TotalMCNQty", "tblPM_MaterialCreditNote_Master,tblPM_MaterialCreditNote_Details", " tblPM_MaterialCreditNote_Master.Id=tblPM_MaterialCreditNote_Details.MId AND tblPM_MaterialCreditNote_Details.PId='" + dr[1] + "'And tblPM_MaterialCreditNote_Details.CId='" + dr[2] + "' AND tblPM_MaterialCreditNote_Master.FinYearId<='" + FinYearId + "' AND tblPM_MaterialCreditNote_Master.CompId='" + CompId + "' ");
                SqlCommand cmd2 = new SqlCommand(cmdStr2, con);
                SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2);

                if (DS2.Tables[0].Rows.Count > 0 && DS2.Tables[0].Rows[0]["TotalMCNQty"] != DBNull.Value)
                {
                    dr[10] = Convert.ToDouble(decimal.Parse(DS2.Tables[0].Rows[0]["TotalMCNQty"].ToString()).ToString("N3"));
                    //dr[11] =z- Convert.ToDouble(decimal.Parse(DS2.Tables[0].Rows[0]["TotalMCNQty"].ToString()).ToString("N3"));
                }
                else
                {
                    dr[10] = 0;

                }
                dr[11] = 0;


                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            foreach (GridViewRow grv in GridView1.Rows)
            {
                double Diff = 0;                

                if (((Label)grv.FindControl("lblTotalMCNQty")).Text != "")
                {
                    Diff = (Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblBOMQty")).Text).ToString("N3")) - Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblTotalMCNQty")).Text).ToString("N3")));

                    if (Diff == 0)
                    {
                        ((TextBox)grv.FindControl("txtqty")).Visible = false;
                    }
                }
            }

        }
        catch (Exception ex) { }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.loaddata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
            Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + id + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=fileName&qct=ContentType");
        }

        if (e.CommandName == "DownloadSpec")
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int id = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
            Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + id + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string CDate = fun.getCurrDate();
        string CTime = fun.getCurrTime();

        string cmdStr = fun.select("MCNNo", "tblPM_MaterialCreditNote_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' order by Id desc");
        SqlCommand cmd1 = new SqlCommand(cmdStr, con);
        SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
        DataSet DS1 = new DataSet();
        DA1.Fill(DS1, "tblPM_MaterialCreditNote_Master");
        string MCNNo;
        if (DS1.Tables[0].Rows.Count > 0)
        {
            int scno = Convert.ToInt32(DS1.Tables[0].Rows[0][0].ToString()) + 1;
            MCNNo = scno.ToString("D4");
        }
        else
        {
            MCNNo = "0001";
        }

        int k = 0;
        int s = 0;
        int count = 0;

        foreach (GridViewRow grv in GridView1.Rows)
        {
            double bomqty = 0;
            double txtqty = 0;
            
            bomqty = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblBOMQty")).Text).ToString("N3"));
            txtqty = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtqty")).Text).ToString("N3"));

            if (((TextBox)grv.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)grv.FindControl("txtqty")).Text) == true && Convert.ToDouble(((TextBox)grv.FindControl("txtqty")).Text) > 0)
            {
                count++;

                if ((bomqty - txtqty) >= 0)
                {
                    k++;
                }
            }
        }

        if ((count-k) == 0)
        {
            string StrSCMaster = fun.insert("tblPM_MaterialCreditNote_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,MCNNo,WONo", "'" + CDate + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + MCNNo + "','" + WONo + "'");
            SqlCommand cmd11 = new SqlCommand(StrSCMaster, con);
            con.Open();
            cmd11.ExecuteNonQuery();
            con.Close();

            string sqlMId = fun.select("Id", "tblPM_MaterialCreditNote_Master", "CompId='" + CompId + "'  Order By Id Desc");
            SqlCommand cmdMId = new SqlCommand(sqlMId, con);
            SqlDataAdapter DAMId = new SqlDataAdapter(cmdMId);
            DataSet DSMId = new DataSet();
            DAMId.Fill(DSMId);
            int MId = Convert.ToInt32(DSMId.Tables[0].Rows[0]["Id"].ToString());

            foreach (GridViewRow grv in GridView1.Rows)
            {
                double bomqty =0;
               double txtqty =0;
                 bomqty = Convert.ToDouble(decimal.Parse(((Label)grv.FindControl("lblBOMQty")).Text).ToString("N3"));
                 txtqty = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtqty")).Text).ToString("N3"));
                 
                if (((TextBox)grv.FindControl("txtqty")).Text != "" && fun.NumberValidationQty(((TextBox)grv.FindControl("txtqty")).Text) == true && Convert.ToDouble(((TextBox)grv.FindControl("txtqty")).Text) > 0 && (bomqty - txtqty)>=0 )
                {
                    int PId = Convert.ToInt32(((Label)grv.FindControl("lblPId")).Text);
                    int CId = Convert.ToInt32(((Label)grv.FindControl("lblCId")).Text);
                    double Qty = Convert.ToDouble(decimal.Parse(((TextBox)grv.FindControl("txtqty")).Text).ToString("N3"));

                    SqlCommand exeme2 = new SqlCommand(fun.insert("tblPM_MaterialCreditNote_Details", "MId,PId,CId,MCNQty", "" + MId + ",'" + PId + "','" + CId + "','" + Qty + "'"), con);
                    con.Open();
                    exeme2.ExecuteNonQuery();
                    con.Close();
                    s++;
                }
            }
            if(s>0)
            {
                Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_New.aspx?ModId=7&SubModId=127");
            }
        }
        else
        {
            string myStringVariable = string.Empty;
            myStringVariable = "Invalid input data.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/MaterialCreditNote_MCN_New.aspx?ModId=7&SubModId=127");
    }
}
