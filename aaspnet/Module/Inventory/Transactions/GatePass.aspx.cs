using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;

using System.Linq;
using System.Collections;


public partial class GatePass : System.Web.UI.Page

{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    
    {

     if (!this.IsPostBack)
        
       {

            con.Open();
            using (SqlConnection conn = new SqlConnection(con.ConnectionString))
           
            {

                try
                {
                    int m = Int32.Parse("0");
                }
                catch (FormatException exx)
                {
                    Console.WriteLine(exx.Message);
                }

                String Ques = "SELECT Id,SrNo,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Gatepass,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark  FROM Returnable_GatePass";
                
                {
                
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    
                    {
                        SqlCommand cmds = new SqlCommand(Ques, con);
                        cmds.Connection = con;
                        da.SelectCommand = cmds;
                        cmds.ExecuteNonQuery();
                        using (DataTable dt = new DataTable())
                        {
                            
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }

                        SqlCommand cmdss = new SqlCommand(Ques, con);
                        cmdss.ExecuteReader();

                    }
                }

            }
        }
    }

  protected void Image1(object sender, EventArgs ex)
   
  {
        //  Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Insert.aspx");

 }

    protected void Image2(object sender, EventArgs ex)
    
    {
        
        Response.Redirect("~/Module/Inventory/Transactions/GatePass.aspx");
     }

    protected void Image3(object sender, EventArgs ex)
    
    {
      
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Edit.aspx");
    }

    protected void Image4(object sender, EventArgs ex)
    
    {
      
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Delete.aspx");

    }

    protected void Image5(object sender, EventArgs ex)
   
    {
       
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_CrystalReport.aspx");

    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // DataTable dt = GetData();

            DataTable dt = new DataTable();
            int Qty_Recd = int.Parse(e.Row.Cells[12].Text);
            int Total_qty = int.Parse(e.Row.Cells[9].Text);

            foreach (TableCell cell in e.Row.Cells)
            {
                if (Qty_Recd == Total_qty)
                {
                    e.Row.Cells[16].Text = ("Close");

                    //e.Row.Cells[16].ForeColor = (System.Drawing.Color.Green);

                 
                    

                }
                else
                {
                    e.Row.Cells[16].Text = ("Open");
                   // e.Row.Cells[16].ForeColor = (System.Drawing.Color.Red);
                    
                }
            }
        }


    }

    



}
