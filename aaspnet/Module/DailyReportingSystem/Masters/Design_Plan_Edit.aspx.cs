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

public partial class Module_DailyReportingSystem_Masters_Design_Plan_Edit : System.Web.UI.Page
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
            string cmdid = "select count(Id) from DRTS_Desing_Plan_New";
            SqlCommand comid = new SqlCommand(cmdid, con);
            int Id = (int)comid.ExecuteScalar();
           
            Id = Id + 1;

            if (idwono.Text != "" && idsr.Text != "" && idfxn.Text != "" && idconcpd.Text != "" && idintrnrw.Text != "" && iddaps.Text != "" && iddapr.Text != "" && idcrr.Text != "" && idfdap.Text != "" && idboulst.Text != "" && iddrwrls.Text != "" && idcncd.Text != "" && idcmmdt.Text != "" && idftlst.Text != "" && idmnl.Text != "" && iddtal.Text != "" && idtpletr.Text != "")
            {
                string cmdstr = fun.update("DRTS_Desing_Plan_New", "idwono,idsr,idfxn,idconcpd,idintrnrw,iddaps,iddapr,idcrr,idfdap,idboulst,iddrwrls,idcncd,idcmmdt,idftlst,idmnl,iddtal,idtpletr,Id", "'" + idwono.Text + "','" + idsr.Text + "','" + idfxn.Text + "','" + idconcpd.Text.ToUpper() + "','" + idintrnrw.Text.ToUpper() + "','" + iddaps.Text + "','" + iddapr.Text + "','" + idcrr.Text + "','" + idfdap.Text + "','" + idboulst.Text + "','" + iddrwrls.Text + "','" + idcncd.Text + "','" + idcmmdt.Text + "','" + idftlst.Text + "','" + idmnl.Text + "','" + iddtal.Text + "','" + idtpletr.Text + "','" + Id + "'");
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("Design_Plan_Edit_Details.aspx?ModId=5&SubModId=2");
            }
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