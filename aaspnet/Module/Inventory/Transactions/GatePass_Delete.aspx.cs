using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class GatePass_Delete : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
  
  {

    }

    protected void Insert(object sender, EventArgs e)
    {

        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                con.Open();
                SqlConnection sql = new SqlConnection(con.ConnectionString);
                String Ques = "SELECT COUNT(*) FROM tbl_Gatepass";
                SqlCommand cmds = new SqlCommand(Ques, con);
                Int32 count = (Int32)cmds.ExecuteScalar();
                count = count + 1;

                // TextBox tb1 = (TextBox)GridView1.FooterRow.FindControl("Text1");
                TextBox tb2 = (TextBox)GridView1.FooterRow.FindControl("Text2");
                DropDownList tb3 = (DropDownList)GridView1.FooterRow.FindControl("Text3");
                TextBox tb4 = (TextBox)GridView1.FooterRow.FindControl("Text4");
                TextBox tb5 = (TextBox)GridView1.FooterRow.FindControl("Text5");
                TextBox tb6 = (TextBox)GridView1.FooterRow.FindControl("Text6");
                DropDownList tb7 = (DropDownList)GridView1.FooterRow.FindControl("Text7");

                TextBox tb8 = (TextBox)GridView1.FooterRow.FindControl("Text8");
                TextBox tb9 = (TextBox)GridView1.FooterRow.FindControl("Text9");
                TextBox tb10 = (TextBox)GridView1.FooterRow.FindControl("Text10");
                DropDownList tb11 = (DropDownList)GridView1.FooterRow.FindControl("Text11");
                TextBox tb12 = (TextBox)GridView1.FooterRow.FindControl("Text12");
                TextBox tb13 = (TextBox)GridView1.FooterRow.FindControl("Text13");
                TextBox tb14 = (TextBox)GridView1.FooterRow.FindControl("Text14");

                TextBox tb15 = (TextBox)GridView1.FooterRow.FindControl("Text15");
                TextBox tb16 = (TextBox)GridView1.FooterRow.FindControl("Text16");

                // text1.Text = tb11.Text;
                int sr = count;
                String Query = "INSERT INTO tbl_Gatepass (Id,SrNO,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Qty,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark)VALUES('" + sr + "','" + count + "','" + count + "','" + tb2.Text + "','" + tb3.SelectedValue + "','" + tb4.Text + "','" + tb5.Text + "','" + tb6.Text + "','" + tb7.SelectedValue + "','" + tb8.Text + "','" + tb9.Text + "','" + tb10.Text + "','" + tb11.SelectedValue + "','" + tb12.Text + "','" + tb13.Text + "','" + tb14.Text + "','" + tb15.Text + "','" + tb16.Text + "')";
                // text1.Text = count.ToString();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);


            }

        }
        catch (Exception ex)
        {

        }

        finally
        {
            if (con != null)
            {

            }
        }
    }

   // protected void Add(object sender, EventArgs e)
   // {
   //     try
   //     {
   //         for (int i = 0; i < Gantt.Rows.Count; i++)
   //         {
   //             con.Open();
   //             SqlConnection sql = new SqlConnection(con.ConnectionString);
   //             String Ques = "SELECT COUNT(*) FROM tbl_Gatepass";
   //             SqlCommand cmds = new SqlCommand(Ques, con);
   //             Int32 count = (Int32)cmds.ExecuteScalar();
   //             count = count + 1;
   //             TextBox tb1 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox1");
   //             //text1.Text = tb1.Text;
   //             DropDownList tb2 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox2");

   //             TextBox tb3 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox3");
   //             TextBox tb4 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox4");
   //             TextBox tb5 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox5");

   //             DropDownList tb6 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox6");
   //             TextBox tb7 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox7");
   //             TextBox tb8 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox8");

   //             TextBox tb9 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox9");
   //             DropDownList tb10 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox10");
   //             TextBox tb11 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox11");
   //             TextBox tb12 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox12");
   //             TextBox tb13 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox13");
   //             TextBox tb14 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox14");
   //             TextBox tb15 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox15");

   //             int sr = count;


   //             // int sr = count;
   //             String Query = "INSERT INTO tbl_Gatepass (Id,SrNO,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Qty,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark)VALUES('" + sr + "','" + count + "','" + count + "','" + tb1.Text + "','" + tb2.SelectedValue + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "','" + tb6.SelectedValue + "','" + tb7.Text + "','" + tb8.Text + "','" + tb9.Text + "','" + tb10.SelectedValue + "','" + tb11.Text + "','" + tb12.Text + "','" + tb13.Text + "','" + tb14.Text + "','" + tb15.Text + "')";
   //             // text1.Text = count.ToString();
   //             SqlCommand cmd = new SqlCommand(Query, con);
   //             cmd.ExecuteNonQuery();
   //             Page.Response.Redirect(Page.Request.Url.ToString(), true);


   //         }
   //     }
   //     catch (Exception ex)
   //     {
   //  }
   //}


    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //    GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
    //    //Label lbldeleteid = (Label)row.FindControl("Id");
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand("delete FROM Returnable_GatePass where Id='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
    //    cmd.ExecuteNonQuery();
    //    con.Close();
    //    // gvbind();
    //}  


    protected void Image1(object sender, EventArgs ex)
   
    {
        //Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Insert.aspx");
 }

  protected void Image2(object sender, EventArgs ex)
    {
        //Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass.aspx");
  }

  protected void Image3(object sender, EventArgs ex)
    {
       // Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Edit.aspx");
    }

    protected void Image4(object sender, EventArgs ex)
    
    {
       // Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Delete.aspx");
    }

    protected void Image5(object sender, EventArgs ex)
    {
        // Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_CrystalReport.aspx");
    }

}
