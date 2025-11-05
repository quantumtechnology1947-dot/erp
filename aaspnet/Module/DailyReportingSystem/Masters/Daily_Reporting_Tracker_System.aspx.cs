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

public partial class Module_Daily_Reporting_System_Masters_Daily_Reporting_Tracker_System : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        for (int i = 0; i < 100; i++)
        {
            IDperc.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        IDperc.Items.Add(new ListItem("100", "100"));


    }
    protected void Submit_Click1(object sender, EventArgs e)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            con.Open();

            if (E_name.SelectedItem.Text == "" || Designation.SelectedItem.Text == "" || Department.SelectedItem.Text == "" || DOR.Text == "" || SALW.Text == "" || TCW.Text == "" || APC.Text == "" || APNC.Text == "" || AUC.Text == "" || PNW.Text == "" || IdDate.Text == "" || IdWo.Text == "" || IdActivity.Text == "" || IDET.Text == "" || IdStatus.Text == "" || IDperc.Text == "" || Idrmk.Text == "")
            {
                string msg = "All feilds are compulsary,please insert values.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            string cmdid = "select count(ID) from DRT_Sys_New";
            SqlCommand comid = new SqlCommand(cmdid, con);
            int ID = (int)comid.ExecuteScalar();
            ID = ID + 1;

            if (E_name.SelectedItem.Text != "" && Designation.SelectedItem.Text != "" && Department.SelectedItem.Text != "" && DOR.Text != "" && SALW.Text != "" && TCW.Text != "" && APC.Text != "" && APNC.Text != "" && AUC.Text != "" && PNW.Text != "" && IdDate.Text != "" && IdWo.Text != "" && IdActivity.Text != "" && IDET.Text != "" && IdStatus.Text != "" && IDperc.Text != "" && Idrmk.Text != "")
            {
                string cmdstr = fun.insert("DRT_Sys_New", "ID,E_name,Designation,Department,DOR,SALW,TCW,APC,APNC,AUC,PNW,IdDate,IdWo,IdActivity,IDET,IdStatus,IDperc,Idrmk", "'" + ID + "','" + E_name.Text + "','" + Designation.Text + "','" + Department.Text + "','" + DOR.Text + "','" + SALW.Text + "','" + TCW.Text + "','" + APC.Text + "','" + APNC.Text + "','" + AUC.Text + "','" + PNW.Text + "','" + IdDate.Text + "','" + IdWo.Text + "','" + IdActivity.Text + "','" + IDET.Text + "','" + IdStatus.Text + "','" + IDperc.Text + "','" + Idrmk.Text + "'");

                SqlCommand cmd = new SqlCommand(cmdstr, con);              
                cmd.ExecuteNonQuery();             
              
            }
           Page.Response.Redirect("Daily_Reporting_Tracker_System.aspx?msg=Customer is registered sucessfuly&ModId=5&SubModId=");
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
