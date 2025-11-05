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

public partial class Module_SysAdmin_FinancialYear_Update : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fun.dropdownCompany(DropDownUpFYCName);
            }

            Label1.Text = "";

            if (!String.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                Label1.Text = Request.QueryString["msg"];
            }
            txtFDate.Attributes.Add("readonly", "readonly");
            txtTDate.Attributes.Add("readonly", "readonly");
        }
        catch(Exception ex)
        {}
    }
   
    protected void Update_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);        
        //msg = "";
      try
        {
            Label1.Text = "";
            con.Open();
            DateTime dd = DateTime.Now;
            string CDate = dd.ToString("yyyy-MM-dd");
            DateTime dt = DateTime.Now;
            string CTime = dt.ToString("T");
            string sId =Session["username"].ToString();
            string FD = fun.FromDate(txtFDate.Text);
            string TD = fun.ToDate(txtTDate.Text);
            string fd = fun.fYear(txtFDate.Text);
            string td = fun.tYear(txtTDate.Text);
            string fYear = string.Concat(fd, td);


            if (ListBoxUpFinYear.SelectedValue != "" && DropDownUpFYCName.SelectedValue != "Select" && txtFDate.Text != "" && txtTDate.Text != "" && fun.DateValidation(txtFDate.Text) == true && fun.DateValidation(txtTDate.Text) == true)
          {
            string cmdstr = fun.update("tblFinancial_master",
                     "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" +sId.ToString() + "',FinYearFrom='" +FD.ToString()+ "',FinYearTo='" +TD.ToString() + "',FinYear='"+fYear.ToString()+"'",
                    "CompId='" + DropDownUpFYCName.SelectedValue + "'and FinYearId='"+ListBoxUpFinYear.SelectedValue+"'");
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            cmd.ExecuteNonQuery();
            msg = "Financial year is Updated successfully.";
            Page.Response.Redirect("FinYrs_Update.aspx?msg=" + msg + "&ModId=1&SubModId=1");
          }
                   
        }

       catch (Exception ex) { }
       
       finally
        {
            con.Close();
           
        }
       
    }
   
   
    protected void ListBoxUpFinYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            msg = "";
            Label1.Text = "";
            DataSet DS = new DataSet();
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string cmdStr = "Select * from tblFinancial_master where CompId=" + DropDownUpFYCName.SelectedValue.ToString() + " AND FinYearId="+ListBoxUpFinYear.SelectedValue+" ";
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS, "Financial");                  
             string upFYF=DS.Tables[0].Rows[0]["FinYearFrom"].ToString();
             string upFYT=DS.Tables[0].Rows[0]["FinYearTo"].ToString();
             string FD = fun.FromDate(upFYF);
             string TD = fun.ToDate(upFYT);
             txtFDate.Text = FD;
             txtTDate.Text = TD;
        }
        catch (Exception ex) { }
    }
    protected void DropDownUpFYCName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            msg = "";
            Label1.Text = "";
            DataSet DS = new DataSet();
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string cmdStr = "Select * from tblFinancial_master where CompId=" + DropDownUpFYCName.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(cmdStr, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DA.Fill(DS, "Financial");
            ListBoxUpFinYear.Items.Clear();
            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                string FinYearFrD = DS.Tables[0].Rows[i]["FinYearFrom"].ToString();
                string FDY = fun.FromDateYear(FinYearFrD);
                string FinYearToD = DS.Tables[0].Rows[i]["FinYearTo"].ToString();
                string TDY = fun.ToDateYear(FinYearToD);
                string finYear = string.Concat(FDY, TDY);               
                string FinYearId = DS.Tables[0].Rows[i][0].ToString();
                ListItem L = new ListItem();
                L.Text = finYear;
                L.Value = FinYearId;
                ListBoxUpFinYear.Items.Add(L);

            }

       }
        catch (Exception ex) {}
    }
}
