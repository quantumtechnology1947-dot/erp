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
using System.Globalization;

public partial class Module_SysAdmin_FinancialYear_FinYrs_New : System.Web.UI.Page
{
   clsFunctions fun = new clsFunctions();
   DataSet DS = new DataSet();

   
   protected void Page_Load(object sender, EventArgs e)
   {
       if (!IsPostBack)
       {
           fun.dropdownCompany(DropDownNewFYCName);
       }
       txtFDate.Attributes.Add("readonly", "readonly");
       txtTDate.Attributes.Add("readonly", "readonly");
   }
   protected void btnNewSubmit_Click(object sender, EventArgs e)
   {

       try
       {
           Label1.Text = "";
           string FD = fun.FromDate(txtFDate.Text);
           string TD = fun.ToDate(txtTDate.Text);
           string fd = fun.fYear(txtFDate.Text);
           string td = fun.tYear(txtTDate.Text);
           string fYear = string.Concat(fd, td);
           string comp = DropDownNewFYCName.SelectedValue;

           if (txtFDate.Text != "" && txtTDate.Text != "" && DropDownNewFYCName.SelectedValue != "Select" && fun.DateValidation(txtFDate.Text) == true && fun.DateValidation(txtTDate.Text) == true)
           {
               Response.Redirect("FinYear_New_Details.aspx?finyear=" + fYear + "&comp=" + comp + "&fd=" + FD + "&td=" + TD + "");

               
           }
       }
       catch (Exception ex)
       {

       }
       finally
       {

       }
   }

   protected void DropDownNewFYCName_SelectedIndexChanged(object sender, EventArgs e)
   {
       try
       {
          
           Label1.Text = "";
           DataSet DS = new DataSet();
           string connStr = fun.Connection();
           SqlConnection con = new SqlConnection(connStr);
           string cmdStr = "Select * from tblFinancial_master where CompId=" + DropDownNewFYCName.SelectedValue.ToString() + "";
           SqlCommand cmd = new SqlCommand(cmdStr, con);
           SqlDataAdapter DA = new SqlDataAdapter(cmd);
           DA.Fill(DS, "Financial");
           ListBoxFinYear.Items.Clear();
           for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
           {
               string FinYearFrD = DS.Tables[0].Rows[i]["FinYearFrom"].ToString();
               string FDY = fun.FromDateYear(FinYearFrD);
               string FinYearToD = DS.Tables[0].Rows[i]["FinYearTo"].ToString();
               string TDY = fun.ToDateYear(FinYearToD);
               string finYear = string.Concat(FDY, TDY);
               ListBoxFinYear.Items.Add(finYear);
           }
       }
       catch (Exception ex) { }
   }

}

