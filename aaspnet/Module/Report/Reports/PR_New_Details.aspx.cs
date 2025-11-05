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
using System.Collections.Generic;
using Telerik.Web.UI;

public partial class Module_MaterialManagement_Transactions_PR_New_Detail : System.Web.UI.Page
{
    SqlCommand cmd1;
    string wono = "";
    int CompId = 0;
    string SId = "";
    int fyid = 0;
    string WomfDate = "";
    string SupplierName = string.Empty;
    clsFunctions fun = new clsFunctions();   
    string connStr = "";
    SqlConnection con;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Display();
        lblreportdate.Text = DateTime.Today.ToString("dd/MM/yyyy");
     try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            SId = Session["username"].ToString();
            fyid = Convert.ToInt32(Session["finyear"]);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            wono = Request.QueryString["WONo"].ToString();
            
            lblWono.Text = wono;
            WomfDate = this.WOmfgdate(wono, CompId, fyid);            
            if (!Page.IsPostBack)
            {
                //fun.MP_Tree1(wono, CompId, RadGrid1, fyid, "And tblDG_Item_Master.CId is not null"); 
                this.MP_Tree1(wono, CompId, RadGrid1, fyid, "And tblDG_Item_Master.CId is not null"); 
               // this.FillFIN();
            }


            foreach (GridDataItem gv1 in RadGrid1.Items)
            {
                GridView RadGrid5 = (GridView)gv1.FindControl("GridView5");
                foreach (GridViewRow gv in RadGrid5.Rows)
                {
                    ((TextBox)gv.FindControl("txtFinDeliDate")).Attributes.Add("readonly", "readonly");
                }
            }
        }
      catch (Exception ex) { }
    }
    public void MP_Tree1(string wono, int CompId, RadGrid GridView2, int finid, string param)
    {


        try
        {
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("ManfDesc", typeof(string));
            dt.Columns.Add("UOMBasic", typeof(string));
            dt.Columns.Add("UnitQty", typeof(string));
            dt.Columns.Add("BOMQty", typeof(string));
          //  dt.Columns.Add(new System.Data.DataColumn("FileName", typeof(string)));
           // dt.Columns.Add(new System.Data.DataColumn("AttName", typeof(string)));
            dt.Columns.Add("ItemId", typeof(int));
            dt.Columns.Add("SysDate", typeof(string));
        //    dt.Columns.Add("PRQty", typeof(string));
           // dt.Columns.Add("WISQty", typeof(string));
           // dt.Columns.Add("GQNQty", typeof(string));
            DataRow dr;
            string sql = "select Distinct ItemId,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,(SELECT sum(IssuedQty)FROM tblInv_WIS_Details inner join tblInv_WIS_Master on tblInv_WIS_Master.Id=tblInv_WIS_Details.MId And tblInv_WIS_Details.ItemId=tblDG_Item_Master.Id And tblInv_WIS_Master.WONo='" + wono + "')As WISQty,(SELECT sum(Qty) FROM tblMM_PR_Details inner join tblMM_PR_Master on tblMM_PR_Master.Id=tblMM_PR_Details.MId And tblMM_PR_Details.ItemId=tblDG_Item_Master.Id And tblMM_PR_Master.WONo='" + wono + "')As PRQty,(select Sum(tblQc_MaterialQuality_Details.AcceptedQty)As Sum_GQN_Qty from tblQc_MaterialQuality_Details,tblinv_MaterialReceived_Details,tblMM_PO_Details,tblMM_PR_Details,tblMM_PR_Master where tblQc_MaterialQuality_Details.GRRId=tblinv_MaterialReceived_Details.Id And tblinv_MaterialReceived_Details.POId=tblMM_PO_Details.Id  And tblMM_PR_Master.Id=tblMM_PR_Details.MId  And tblMM_PO_Details.PRId=tblMM_PR_Details.Id And tblMM_PR_Details.ItemId=tblDG_Item_Master.Id  And tblMM_PR_Master.WONo='" + wono + "') As GQNQty from tblDG_BOM_Master,tblDG_Item_Master,Unit_Master where WONo='" + wono + "'" + param + " And Unit_Master.Id=tblDG_Item_Master.UOMBasic And  tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId and tblDG_BOM_Master.CompId='" + CompId + "' And tblDG_BOM_Master.FinYearId<='" + finid + "' And ECNFlag=0 AND tblDG_BOM_Master.CId not in (Select PId from tblDG_BOM_Master where WONo='" + wono + "' and CompId='" + CompId + "' And FinYearId<='" + finid + "')";

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dr = dt.NewRow();
                dr[0] = rdr["ItemCode"].ToString();
                dr[1] = rdr["ManfDesc"].ToString();
                dr[2] = rdr["UOMBasic"].ToString();
                double tqty = 0;
                dr[3] = tqty;
                double liQty = 0;
                liQty = fun.AllComponentBOMQty(CompId, wono, rdr["ItemId"].ToString(), finid);
                dr[4] = liQty;
                dr[5] = rdr["ItemId"].ToString();

               // dr[6] = rdr["SysDate"].ToString(); 
                //PR Qty
                double PRQty = 0;
                //if (rdr["PRQty"] != DBNull.Value)
                //{
                //    PRQty = Convert.ToDouble(rdr["PRQty"]);
                //}
                dr[5] = PRQty.ToString();
                ////WIS Qty
                //double WISQty = 0;
                //if (rdr["WISQty"] != DBNull.Value)
                //{
                //    WISQty = Convert.ToDouble(rdr["WISQty"]);
                //}
                //dr[9] = WISQty.ToString();
                ////GQN Qty
                //double GQNQty = 0;
                //if (rdr["GQNQty"] != DBNull.Value)
                //{
                //    GQNQty = Convert.ToDouble(rdr["GQNQty"]);
                //}
                //dr[10] = GQNQty.ToString();
                //if (rdr["FileName"].ToString() != "" && rdr["FileName"] != DBNull.Value)
                //{
                //    dr[5] = "View";
                //}
                //else
                //{
                //    dr[5] = "";
                //}

                //if (rdr["AttName"].ToString() != "" && rdr["AttName"] != DBNull.Value)
                //{
                //    dr[6] = "View";
                //}
                //else
                //{
                //    dr[6] = "";
                //}

                //if (Math.Round((liQty - PRQty - WISQty + GQNQty), 3) > 0)
                //{
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
               // }

            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            rdr.Close();

        }
        catch (Exception ch)
        {
        }
        finally
        {
            con.Close();
        }

    }
    public string WOmfgdate(string wono, int compid, int finid)
    {
        string WomfgDt = "";
        try
        {
            string StrSql = fun.select("SD_Cust_WorkOrder_Master.BoughtoutMaterialDate", "SD_Cust_WorkOrder_Master", "SD_Cust_WorkOrder_Master.WONo='" + wono + "' AND SD_Cust_WorkOrder_Master.FinYearId<='" + finid + "'And SD_Cust_WorkOrder_Master.CompId='" + compid + "'");
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(StrSql, con);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
           
            if (dt.Tables[0].Rows.Count > 0 && dt.Tables[0].Rows[0]["BoughtoutMaterialDate"] != DBNull.Value)
            {
                WomfgDt = fun.FromDateDMY(dt.Tables[0].Rows[0]["BoughtoutMaterialDate"].ToString());

            }
            return WomfgDt;
        }
        catch (Exception ex){}
        return WomfgDt;
    }
   
    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }


    public void Display()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {


            SqlCommand cmdzs = new SqlCommand("SELECT MAX((PRJCTNO) + 1) as PRJCTNO FROM tblPM_Project_Hardware_MasterD ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            lblreport.Text = cmdzs.ExecuteScalar().ToString();
        }

    }

    public void GridColour()
    {

        try
        {
            foreach (GridDataItem grv2 in RadGrid1.Items)
            {
                CheckBox chkitems = (grv2.Cells[0].FindControl("chkitems") as CheckBox);
                if (chkitems.Checked)
                {
                    grv2.BackColor = System.Drawing.Color.Pink;
                }
                else
                {
                    grv2.BackColor = System.Drawing.Color.Transparent;
                }

            }
        }
        catch (Exception ex)
        {
        }
    }    



    protected void RadButton2_Click_Cancel(object sender, EventArgs e)
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        con.Open();

        foreach (GridDataItem grv2 in RadGrid1.Items)
        {
            CheckBox CK = grv2.Cells[0].FindControl("chkitems") as CheckBox;
            TextBox txtdesign = grv2.Cells[6].FindControl("txtdesign") as TextBox;
            RadioButton rd = grv2.Cells[5].FindControl("rdoemail") as RadioButton;
            Label lblCode=grv2.Cells[1].FindControl("lblCode")as Label;
            Label lblDesc = grv2.Cells[2].FindControl("lblDesc") as Label;
            Label lbluombasic = grv2.Cells[3].FindControl("lbluombasic") as Label;
            Label lblbomqty = grv2.Cells[4].FindControl("lblbomqty") as Label;
            TextBox txtremark = grv2.Cells[7].FindControl("txtremark") as TextBox;
            TextBox txtven1 = grv2.Cells[8].FindControl("txtven1") as TextBox;
            TextBox txtven2 = grv2.Cells[9].FindControl("txtven2") as TextBox;

            if (CK.Checked == true)
            {
                grv2.BackColor = System.Drawing.Color.Pink;
                cmd1 = new SqlCommand("INSERT INTO tblPM_Project_Hardware_Master_Detail(PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Rdesign,Design) values(@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Rdesign,@Design)", con);
                cmd1.Parameters.AddWithValue("@ItemCode", lblCode.Text);
                cmd1.Parameters.AddWithValue("@Description", lblDesc.Text);
                cmd1.Parameters.AddWithValue("@UOM", lbluombasic.Text);
                cmd1.Parameters.AddWithValue("@BOMQ", lblbomqty.Text);
                cmd1.Parameters.AddWithValue("@Design", txtdesign.Text);
                cmd1.Parameters.AddWithValue("@Rdesign", rd.Text);
                cmd1.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
                cmd1.Parameters.AddWithValue("@WONo", lblWono.Text);
               



                cmd1.ExecuteNonQuery();
                txtdesign.Enabled = false;
                lblbomqty.Enabled = false;
            }
        }

        con.Close();


    }

    protected void Selected_chk_Changed(object sender, EventArgs e)
    {
        foreach (GridDataItem grv2 in RadGrid1.Items)
        {
            CheckBox CK = grv2.Cells[0].FindControl("chkitems") as CheckBox;
            TextBox lblbomqty = grv2.Cells[5].FindControl("lblbomqty") as TextBox;
            TextBox txtdesign = grv2.Cells[6].FindControl("txtdesign") as TextBox;
            if (CK.Checked == true)
            {
                txtdesign.Enabled = true;
               // lblbomqty.Enabled = true;

            }
            else
            {
                txtdesign.Enabled = false;
                //lblbomqty.Enabled = false;
            }
        }
    }
    
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/Report/Reports/PR_New.aspx?ModId=18&SubModId=154", true);
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            string sqlStatment = "INSERT INTO tblPM_Project_Hardware_MasterD(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,GenDate) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@GenDate)";
            // string sqlStatment = "INSERT INTO tblPM_Project_Site_Master(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Design,Manf,BOP,Assemly) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Design,@Manf,@BOP,@Assemly)";
            {
                using (SqlCommand cmds = new SqlCommand(sqlStatment, con))
                {
                    cmds.Parameters.AddWithValue("@SysDate", CDate.ToString());
                    cmds.Parameters.AddWithValue("@SysTime", CTime.ToString());
                    cmds.Parameters.AddWithValue("@CompId", CompId);
                    cmds.Parameters.AddWithValue("@SessionId", SId.ToString());
                    cmds.Parameters.AddWithValue("@FinYearId", fyid);
                    cmds.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
                    cmds.Parameters.AddWithValue("@WONo", lblWono.Text);
                    cmds.Parameters.AddWithValue("@GenDate", lblreportdate.Text);
                    con.Open();
                    cmds.ExecuteNonQuery();

                    con.Close();
                    Response.Redirect("~/Module/Report/Reports/PR_New.aspx?ModId=18&SubModId=154", true);

                   // Response.Redirect("~/Module/ProjectManagement/Transactions/PR_New.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
   
    

}
