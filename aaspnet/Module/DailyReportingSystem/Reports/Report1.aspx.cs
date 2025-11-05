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

public partial class Module_DailyReportingSystem_Reports_Report1 : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    int CompId = 0;
    int FinYearId = 0;  
    string fd1 = "";
    string td1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            lblMessage.Text = "";
            TxtFromDate.Attributes.Add("readonly", "readonly");
            TxtToDate.Attributes.Add("readonly", "readonly");
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            string sql = fun.select("FinYearFrom,FinYearTo", "tblFinancial_master", "CompId='" + CompId + "' And FinYearId='" + FinYearId + "'");
            SqlCommand CmdFinYear = new SqlCommand(sql, con);            
            SqlDataAdapter DAFin = new SqlDataAdapter(CmdFinYear);
            DataSet DSFin = new DataSet();
            DAFin.Fill(DSFin, "tblFinancial_master");
            if (DSFin.Tables[0].Rows.Count > 0)
            {
                fd1 = fun.FromDateDMY(DSFin.Tables[0].Rows[0][0].ToString());
                td1 = fun.FromDateDMY(DSFin.Tables[0].Rows[0][1].ToString());
            }
            TxtToDate.Text = fun.FromDateDMY(fun.getCurrDate());
            lblToDate.Text = td1;
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        catch (Exception ex) { }

    }

    /* public void Fillgrid(string d1 ,string d2, string d3, string s1)
     {

         string connStr = fun.Connection();
         SqlConnection con = new SqlConnection(connStr);
         DataTable dt = new DataTable();
         try
         {
             con.Open();
             string d21 = DropDownList3.SelectedItem.Text;
             string d22 = DropDownList2.SelectedItem.Text;
             string d23 = DropDownList1.SelectedItem.Text;
             string s21 = TextBox2.Text;
             string d11 = "";
             string d12= "";
             string d13= "";
             string s11 = "";
             if (d21 != "ERP System")
             {
                 if (d22!= "Not Applicable")
                 {

                     if (d23 != "Not Applicable")
                     {                       
                            string cmdstr = fun.select("DRT_Sys_New", "ID,E_name,Designation,Department,DOR,SALW,TCW,APC,APNC,AUC,PNW,IdDate,IdWo,IdActivity,IDET,IdStatus,IDperc,Idrmk", "E_name='" + d21 + "',Designation='" + d22 + "',Department'" + d23 + "'");
                            SqlCommand cmdd = new SqlCommand(cmdstr, con);
                             int k = cmdd.ExecuteNonQuery();
                             if (k == 0)
                             {
                                 string msg1 = "Record is not found.";
                                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg1 + "');", true);

                             }                                                   
                      }
                  }
              }
                 SqlCommand cmd = new SqlCommand();
                 SqlDataAdapter da = new SqlDataAdapter("GetAllItem", con);                
                 DataSet DSitem = new DataSet();
                 da.Fill(DSitem);
                 GridView1.DataSource = DSitem;
                 GridView1.DataBind();
         }
         catch (Exception ex)
         {
         }
         finally
         {
             con.Close();

         }

     }*/

    protected void search_Click(object sender, EventArgs e)
    {
        /*  string connStr = fun.Connection();
          SqlConnection con = new SqlConnection(connStr);
         // DataTable dt = new DataTable();

          try
          {
              con.Open();
              string d21 = DropDownList3.SelectedItem.Text;
              string d22 = DropDownList2.SelectedItem.Text;
              string d23 = DropDownList1.SelectedItem.Text;
              string s21 = TextBox2.Text;
              // string d11 = "";
              // string d12 = "";
              // string d13 = "";
              // string s11 = "";

              if (d21 != "ERP System")
              {

                  if (d22 != "Not Applicable")
                  {

                      if (d23 != "Not Applicable")
                      {
                         // if (!IsPostBack)
                         // {
                              DataTable dt = new DataTable();
                              string cmdstr = "select * from DRT_Sys_New where E_name='" + d21 + "' AND Designation='" + d22 + "' AND Department'" + d23 + "'";                       
                          SqlCommand cmdd = new SqlCommand(cmdstr, con);                 
                          // string msg1 = "Record is not found.";
                          // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg1 + "');", true);
                          SqlDataAdapter adapter = new SqlDataAdapter(cmdd);
                          DataSet ds = new DataSet(cmdstr);                       
                          adapter.Fill(ds,"DRT_Sys_New");
                         // dt.Columns.Add(new System.Data.DataColumn("SalesId", typeof(int)));//0
                         // dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(int)));//1
                         // dt.Columns.Add(new System.Data.DataColumn("CustomerName", typeof(string)));//2
                         /// dt.Columns.Add(new System.Data.DataColumn("Code", typeof(string)));//3
                         // dt.Columns.Add(new System.Data.DataColumn("RegdAdd", typeof(string)));//4
                         // dt.Columns.Add(new System.Data.DataColumn("ContactPerson", typeof(string)));//5
                          //dt.Columns.Add(new System.Data.DataColumn("MobileNo", typeof(string)));//6
                         // dt.Columns.Add(new System.Data.DataColumn("Email", typeof(string)));//7
                             // DataRow dr;                                                                     //TextBox3.Text = "test";
                             // for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                             // {
                                 // dr = dt.NewRow();
                                  GridView1.DataSource = ds;
                                  GridView1.DataBind();
                               //}                   

                              TextBox3.Text = "test";

                         // }
                      }
                  }
              }          
          }
          catch (Exception ex)
          {
          }
          finally
          {
              con.Close();

          } */
        this.BindGrid();
    }
    private void BindGrid()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();
        try
        {
            con.Open();
            string d21 = DropDownList3.SelectedItem.Text;
            string d22 = DropDownList2.SelectedItem.Text;
            string d23 = DropDownList1.SelectedItem.Text;
            string s21 = TextBox2.Text;
            // string d11 = "";
            // string d12 = "";
            // string d13 = "";
            // string s11 = "";

            if (d21 != "ERP System")
            {

                if (d22 != "Not Applicable")
                {

                    if (d23 != "Not Applicable")
                    {
                       
                        string cmdstr = "select * from DRT_Sys_New where E_name like'" + d21 + "%' AND Designation like'" + d22 + "%' AND Department like '" + d23 + "%'";
                        SqlCommand cmd = new SqlCommand();
                        SqlDataAdapter da = new SqlDataAdapter(cmdstr, con);
                        TextBox3.Text = "test";                        
                        DataSet DSitem = new DataSet();
                        da.Fill(DSitem);
                        GridView1.DataSource = DSitem;
                        GridView1.DataBind();
                    }
                }
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

    //protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
   // {
     //  GridView1.PageIndex = e.NewPageIndex;
     //   this.BindGrid();
   // }

   // protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
   // {
     //   if (e.Row.RowType == DataControlRowType.DataRow)
      //  {
        //    e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, DropDownList3.SelectedItem.Text, delegate (Match match)
         //   {
              //  return string.Format("<span style = 'background-color:#D9EDF7'>{0}</span>", match.Value);
            //}, RegexOptions.IgnoreCase);
       // }
   // }

}