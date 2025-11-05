using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
public partial class Stock_Month : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);


    protected void Page_Load(object sender, EventArgs e)
   
    {
        
    }

  
    protected void Griedview(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();


            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = " SrNo.";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = " NAME OF ACTIVITY.";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = " REV. NO";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");


            HeaderCell = new TableCell();
            HeaderCell.Text = "NO OF DAYS";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = "AS PER PLAN";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = "ACTUAL";
            HeaderCell.ColumnSpan = 2;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");

            HeaderCell = new TableCell();
            HeaderCell.Text = "REASON FOR DELAY";
            HeaderCell.ColumnSpan = 0;
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell.Style.Add("font-weight", "bold");



            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }






    protected void Insert_click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                con.Open();
                SqlConnection sql = new SqlConnection(con.ConnectionString);
                String Ques = "SELECT COUNT(*) FROM tbl_Stock_Month";
                SqlCommand cmds = new SqlCommand(Ques, con);
                Int32 count = (Int32)cmds.ExecuteScalar();
                count = count + 1;

                TextBox tb1 = (TextBox)GridView1.FooterRow.FindControl("Text1");
                
                TextBox tb2 = (TextBox)GridView1.FooterRow.FindControl("Text2");
                text22.Text = tb2.Text;
                TextBox tb3 = (TextBox)GridView1.FooterRow.FindControl("Text3");
                TextBox tb4 = (TextBox)GridView1.FooterRow.FindControl("Text4");

                TextBox tb5 = (TextBox)GridView1.FooterRow.FindControl("Text5");
                TextBox tb6 = (TextBox)GridView1.FooterRow.FindControl("Text6");
                TextBox tb7 = (TextBox)GridView1.FooterRow.FindControl("Text7");
                TextBox tb8 = (TextBox)GridView1.FooterRow.FindControl("Text8");

                // text.Text = tb11.Text;
                int sr = count;
                // int WONo = 1;
                String Query = "INSERT INTO tbl_Stock_Month(Id,SrNO,Item_code,Group,Description,Unit,Qty_month,ReOrder,Min_order)VALUES('" + sr + "','" + count + "','" + tb1.Text + "','" + tb2.Text + "','" + tb3.Text + "','" + tb4.Text + "','" + tb5.Text + "','" + tb6.Text + "','" + tb7.Text + "','" + tb8.Text + "')";
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






}
    
  

