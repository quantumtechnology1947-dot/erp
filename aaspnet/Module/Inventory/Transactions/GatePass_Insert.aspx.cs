using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;

public partial class GatePass_Insert : System.Web.UI.Page

{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

  protected void Page_Load(object sender, EventArgs e)
    {
      DateTime dt=DateTime.Now;
    Textbox1.Text = System.DateTime.Now.ToString("dd-M-yyyy");
      
    }

    protected void Add(object sender, EventArgs e)
    
    {
        try
        {
            for (int i = 0; i < Gantt.Rows.Count; i++)
            {
                con.Open();
                SqlConnection sql = new SqlConnection(con.ConnectionString);
                String Ques = "SELECT COUNT(*) FROM Returnable_GatePass";
                SqlCommand cmds = new SqlCommand(Ques, con);
                Int32 count = (Int32)cmds.ExecuteScalar();
                count = count + 1;
                TextBox tb1 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox1");
                //text1.Text = tb1.Text;
                DropDownList tb2 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox2");

                DropDownList tb3 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox3");
                TextBox tb4 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox4");
                TextBox tb5 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox5");

                DropDownList tb6 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox6");
                DropDownList tb7 = (DropDownList)Gantt.Rows[1].Cells[1].FindControl("Textbox7");
                TextBox tb8 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox8");
                TextBox tb9 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox9");
                TextBox tb10 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox10");
                TextBox tb11 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox11");
                TextBox tb12 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox12");
                TextBox tb13 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox13");
                TextBox tb14 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox14");
                TextBox tb15 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Textbox15");

                int sr = count;
                // int sr = count;
                String Query = "INSERT INTO Returnable_GatePass (Id,SrNO,ChalanNo,Date,WoNo,Des_Name,CodeNo,Description,Unit,Gatepass,Total_qty,IssueTo,AthoriseBy,Rec_Date,Qty_Recd,Qty_pend,RecdBy,Remark)VALUES('" + sr + "','" + count + "','" + count + "','" + tb1.Text + "','" + tb2.SelectedValue + "','" + tb3.SelectedValue + "','" + tb4.Text + "','" + tb5.Text + "','" + tb6.SelectedValue + "','" + tb7.SelectedValue + "','" + tb8.Text + "','" + tb9.Text + "','" + tb10.Text + "','" + tb11.Text + "','" + tb12.Text + "','" + tb13.Text + "','" + tb14.Text + "','" + tb15.Text + "')";
                // text1.Text = count.ToString();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
        }
        catch (Exception ex)
        {

        }

    }

  protected void Image1(object sender, EventArgs ex)
    {
        
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Insert.aspx");
  }

    protected void Image2(object sender, EventArgs ex)
    {
      Gantt.Visible = true;
      Response.Redirect("~/Module/Inventory/Transactions/GatePass.aspx");

    }

  protected void Image3(object sender, EventArgs ex)
    {
        Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Edit.aspx");
    }

    protected void Image4(object sender, EventArgs ex)
    {
        Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_Delete.aspx");

    }

 protected void Image5(object sender, EventArgs ex)
   
    {
        Gantt.Visible = true;
        Response.Redirect("~/Module/Inventory/Transactions/GatePass_CrystalReport.aspx");
     }

}
