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

public partial class Module_Daily_Reporting_System_Masters_VENDOR_PLAN : System.Web.UI.Page
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
            if (idwono.Text == "" || idsr.Text == "" || idfxn.Text == "" || idnpm.Text == "" || idpln.Text == "" || idfcl.Text == "" || idpri.Text == "" || idwef.Text == "" || idwl.Text == "" || idnpr.Text == "" || idnap.Text == "" || idpmp.Text == "" || idbpt.Text == "" || idpbp.Text == "" || idnpc.Text == "" || idnprap.Text == "")
            {
                string msg = "All feilds are compulsary,please insert values.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
                string cmdid = "select count(ID) from DRTS_VENDOR_PLAN";
            SqlCommand comid = new SqlCommand(cmdid, con);
            int ID = (int)comid.ExecuteScalar();           
            ID = ID + 1;
            idsr.Text = ID.ToString();
            if (idwono.Text != "" && idsr.Text != "" && idfxn.Text != "" && idnpm.Text != "" && idpln.Text != "" && idfcl.Text != "" && idpri.Text != "" && idwef.Text != "" && idwl.Text != "" && idnpr.Text != "" && idnap.Text != "" && idpmp.Text != "" && idbpt.Text != "" && idpbp.Text != "" && idnpc.Text != "" && idnprap.Text != "")
            {
                string cmdstr = fun.insert("DRTS_VENDOR_PLAN", "idwono,idsr,idfxn,idnpm,idpln,idfcl,idpri,idwef,idwl,idnpr,idnap,idpmp,idbpt,idpbp,idnpc,idnprap,ID", "'" + idwono.Text + "','" + idsr.Text + "','" + idfxn.Text + "','" + idnpm.Text+ "','" + idpln.Text + "','" + idfcl.Text + "','" + idpri.Text + "','" + idwef.Text + "','" + idwl.Text + "','" + idnpr.Text + "','" + idnap.Text + "','" + idpmp.Text + "','" + idbpt.Text + "','" + idpbp.Text + "','" + idnpc.Text + "','" + idnprap.Text + "','"+ID+"'");
                SqlCommand cmd = new SqlCommand(cmdstr, con);
               // cmd.ExecuteNonQuery();
                int k = cmd.ExecuteNonQuery();
                if (k != 0)
                {
                    string msg1 = "Record inserted successfully.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg1 + "');", true);
                    
                }               
            }
            Page.Response.Redirect("VENDOR_PLAN.aspx?msg=Customer is registered sucessfuly&ModId=5&SubModId=");
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