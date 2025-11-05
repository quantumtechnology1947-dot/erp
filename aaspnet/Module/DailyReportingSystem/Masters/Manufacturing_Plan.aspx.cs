using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


public partial class Module_Daily_Reporting_System_Masters_Manufacturing_Plan : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void submit_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);


        try
        {

            con.Open();
            if (idwono.Text == "" || idfxn.Text == "" || iditn.Text == "" || iddes.Text == "" || idqty.Text == "" || iddet.Text == "" || idtple.Text == "" || idflc.Text == "" || idfab.Text == "" || ids.Text == "" || idmcing.Text == "" || idtap.Text == "" || idfc.Text == "" || idchn.Text == "" || idlist.Text == "" || idrec.Text == "" || idpai.Text == "")
            {
                string msg = "All feilds are compulsary,please insert values.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
                string cmdid = "select count(Id) from DRTS_Manufacturing_Plan_New";
            SqlCommand comid = new SqlCommand(cmdid, con);
            int Id = (int)comid.ExecuteScalar();
           
            Id = Id + 1;
         
            if (idwono.Text != ""  && idfxn.Text != "" && iditn.Text != "" && iddes.Text != "" && idqty.Text != "" && iddet.Text != "" && idtple.Text != "" && idflc.Text != "" && idfab.Text != "" && ids.Text != "" && idmcing.Text != "" && idtap.Text != "" && idfc.Text != "" && idchn.Text != "" && idlist.Text != "" && idrec.Text != "" && idpai.Text != "")
            {
                string cmdstr = fun.insert("DRTS_Manufacturing_Plan_New", "Id,WONO,FIXTURE_NO,ITEM_NO,DESCRIPTION,QTY,DETAILING,TPL_ENTRY,FLAME_CUT,C_FLAME_CUT,CHANNLEL,LIST,RECEIVE,FABRICATION,C_SR,MC_ING,TAPPING,PAINTING", "'"+Id+"','" + idwono.Text + "','" + idfxn.Text + "','" + iditn.Text.ToUpper() + "','" + iddes.Text.ToUpper() + "','" + idqty.Text + "','" + iddet.Text + "','" + idtple.Text + "','" + idflc.Text + "','" + idfab.Text + "','" + ids.Text + "','" + idmcing.Text + "','" + idtap.Text + "','" + idfc.Text + "','" + idchn.Text + "','" + idlist.Text + "','" + idrec.Text + "','" + idpai.Text + "'");
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.ExecuteNonQuery();
               // if (k != 0)
               // {
                //    string msg1 = "Record inserted successfully.";
                 //   ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg1 + "');", true);
                //}
            }
            Page.Response.Redirect("Manufacturing_Plan.aspx?msg=Customer is registered sucessfuly&ModId=5&SubModId=");
        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();


        }
    }
}