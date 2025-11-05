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
using System.Collections.Generic;

public partial class Challan : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlCommand cmd1;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
    static SqlDataAdapter da;
    static DataTable dt;
    static DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
          

        //TextDCDate.Text = DateTime.Now.ToShortDateString();
        Display();
        calculateamt();
        Caltotal();
        Calqty();
        //DisplayRecord();
        //GridView1.Visible = false;

    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetSearch(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        DataTable Result = new DataTable();
        string str = "select Distinct SupplierName from tblMM_Supplier_master where SupplierName like '" + prefixText + "%'";
        da = new SqlDataAdapter(str, con);
        dt = new DataTable();
        da.Fill(dt);
        List<string> Output = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
            Output.Add(dt.Rows[i][0].ToString());
        return Output;
    }
    protected void TextTO_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        String strQuery = "select SupplierName,WorkAddress,ContactPerson,TinVatNo,ContactNo from tblMM_Supplier_master where SupplierName='" + TextTO.Text + "'";
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@SupplierName", TextTO.Text);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               // Textaddress.Text = sdr["WorkAddress"].ToString();
              //  TextAttention.Text = sdr["ContactPerson"].ToString();
                //TextGST.Text = sdr["TinVatNo"].ToString();
                //TextContact.Text = sdr["ContactNo"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> Get(string prefixText)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        DataTable Result = new DataTable();
        string str = "select Distinct ItemCode from tblDG_Item_Master where ItemCode like '" + prefixText + "%'";
        da = new SqlDataAdapter(str, con);
        dt = new DataTable();
        da.Fill(dt);
        List<string> Output = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
            Output.Add(dt.Rows[i][0].ToString());
        return Output;
    }
    protected void TxtItemCode_TextChanged(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        String strQuery = "select ItemCode,ManfDesc from tblDG_Item_Master where ItemCode='" + TxtItemCode.Text + "'";
        SqlCommand cmd = new SqlCommand();
        cmd.Parameters.AddWithValue("@ItemCode", TxtItemCode.Text);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
              //  TxtDesc.Text = sdr["ManfDesc"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }
    }

    public void Display()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("SELECT MAX (DCNo) + 1 as DCNo FROM Challan ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            TextDCNO.Text = cmdzs.ExecuteScalar().ToString();
        }

    }
    public void calculateamt()
    {
        try
        {
            int A;
            A = Convert.ToInt32(TxtQty.Text);
            Double B = Convert.ToDouble(TxtRate.Text);
            //Double C = Convert.ToDouble(TxtAmt.Text);

            TxtAmt.Text = (A * B).ToString();
        }
        catch (Exception ex)
        {
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        con.Open();

        //TextBox tbb1 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Text1");
        //TextBox tbb2 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Text2");
        //TextBox tbb3 = (TextBox)Gantt.Rows[1].Cells[1].FindControl("Text3");

        cmd = new SqlCommand("INSERT INTO Challantemp (DCNo,ItemCode,Description ,HSN ,Quantity,Rate,Amount) values(@DCNo,@ItemCode,@Description ,@HSN ,@Quantity,@Rate,@Amount)", con);
        cmd.Parameters.AddWithValue("@ItemCode", TxtItemCode.Text);
        cmd.Parameters.AddWithValue("@Description", TxtDesc.Text);
        cmd.Parameters.AddWithValue("@HSN", TxtHsn.Text);
        cmd.Parameters.AddWithValue("@Quantity", TxtQty.Text);
        cmd.Parameters.AddWithValue("@Rate", TxtRate.Text);
        cmd.Parameters.AddWithValue("@Amount", TxtAmt.Text);
        cmd.Parameters.AddWithValue("@DCNo", TextDCNO.Text);

        cmd.ExecuteNonQuery();
        con.Close();
        DisplayRecord();
        Caltotal();
        Calqty();
        cleargrid();
        
        //Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    //protected void cal_Click(object sender, EventArgs e)
    //{
    //    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
    //    string sqlStatment1 = "INSERT INTO Challancalculation(DCNo,Totalamt,Totalqty) VALUES(@DCNo,@Totalamt,@Totalqty)";
    //    {
    //        using (SqlCommand cmd1 = new SqlCommand(sqlStatment1, con1))
    //        {
    //            cmd1.Parameters.AddWithValue("@DCNo", TextDCNO.Text);
    //            cmd1.Parameters.AddWithValue("@Totalamt", total.Text);
    //            cmd1.Parameters.AddWithValue("@Totalqty", qty.Text);
    //            con1.Open();
    //            cmd1.ExecuteNonQuery();
    //            con1.Close();

    //        }
    //    }

    //}

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int no = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["DCNo"].ToString());
        string i = GridView1.DataKeys[e.RowIndex].Values["ItemCode"].ToString();
        SqlCommand cmd = new SqlCommand("DELETE FROM [Challantemp] WHERE [DCNo] = @DCNo and [ItemCode] = @ItemCode ", con);
        cmd.Parameters.AddWithValue("@DCNo", no);
        cmd.Parameters.AddWithValue("@ItemCode", i);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        DisplayRecord();
        //total.Text = "";
        //qty.Text = "";
    }

    public void DisplayRecord()
    {
        
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        string sql1 =string.Format ("select DCNo,ItemCode,Description,HSN,Quantity,Rate,Amount from Challantemp where DCNo = '"+TextDCNO.Text+"'");
        //using (SqlCommand cmd = new SqlCommand(sql1, con))
        //{
            //cmd.Parameters.AddWithValue("@DCNo", TextDCNO.Text);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();


            da = new SqlDataAdapter(sql1, con);
            ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
           
            //TxtB.Text = "try";
            //GridView1.Visible = true;
        //}
    }
    
    public void Caltotal()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("select sum(amount) as Total from Challantemp where DCNo='" + TextDCNO.Text + "'", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            total.Text = cmdzs.ExecuteScalar().ToString();
        }
        
    }
    public void Calqty()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {
            SqlCommand cmdzs = new SqlCommand("select sum(quantity) as qty from Challantemp where DCNo='" + TextDCNO.Text + "'", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            qty.Text = cmdzs.ExecuteScalar().ToString();
        }

    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        string Item = string.Empty;
        string Desc = string.Empty;
        string Qty = string.Empty;
        string hsn = string.Empty;
        string r = string.Empty;
        string amt = string.Empty;

        foreach (GridViewRow row in this.GridView1.Rows)
        {
            Item = row.Cells[2].Text.ToString();
            Desc = row.Cells[3].Text.ToString();
            hsn = row.Cells[4].Text.ToString();
            Qty = row.Cells[5].Text.ToString();
            r = row.Cells[6].Text.ToString();
            amt = row.Cells[7].Text.ToString();

            this.Save(Item, Desc, hsn, Qty, r,amt);
        }
        //MessageBox.Show("Data Added");
        clear();
        Response.Redirect("ChallanInfo.aspx", true);

    }
    protected void Save(string Item, string Desc, string hsn, string Qty, string r, string amt)
    {
        //try
        //{

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
            string sqlStatment = "INSERT INTO Challan(CustomerName,Address,GST,DCNo,DCDate,Attention,Contact,Responsible_By,Type,ItemCode,Description,HSN,Quantity,Rate,Amount,TQty,TAmt,Gst_per,GTotal,Remark,Transport,vehicleNo,LRNo,Acknowledgement) VALUES(@CustomerName,@Address,@GST,@DCNo,@DCDate,@Attention,@Contact,@Responsible_By,@Type,@ItemCode,@Description,@HSN,@Quantity,@Rate,@Amount,@TQty,@TAmt,@Gst_per,@GTotal,@Remark,@Transport,@vehicleNo,@LRNo,@Acknowledgement)";
            {
                using (SqlCommand cmd = new SqlCommand(sqlStatment, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerName", TextTO.Text);
                    cmd.Parameters.AddWithValue("@Address", Textaddress.Text);
                    cmd.Parameters.AddWithValue("@GST", TextGST.Text);
                    cmd.Parameters.AddWithValue("@DCNo", TextDCNO.Text);
                    cmd.Parameters.AddWithValue("@DCDate", TextDCDate.Text);
                    cmd.Parameters.AddWithValue("@Attention", TextAttention.Text);
                    cmd.Parameters.AddWithValue("@Contact", TextContact.Text);                   
                    cmd.Parameters.AddWithValue("@Responsible_By", TextRes.Text);
                    cmd.Parameters.AddWithValue("@Type", ddlType.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@ItemCode", Item);
                    cmd.Parameters.AddWithValue("@Description", Desc);
                    cmd.Parameters.AddWithValue("@HSN", hsn);
                    cmd.Parameters.AddWithValue("@Quantity", Qty);
                    cmd.Parameters.AddWithValue("@Rate", r);
                    
                    cmd.Parameters.AddWithValue("@Amount", amt);
                    cmd.Parameters.AddWithValue("@TQty", qty.Text);
                    cmd.Parameters.AddWithValue("@TAmt", total.Text);
                    cmd.Parameters.AddWithValue("@Gst_per", Gst.Text);
                    cmd.Parameters.AddWithValue("@GTotal", Gt.Text);

                    cmd.Parameters.AddWithValue("@Remark", TxtRemark.Text);
                    cmd.Parameters.AddWithValue("@Transport", TxtTrans.Text);
                    cmd.Parameters.AddWithValue("@vehicleNo", TxtVehicle.Text);
                    cmd.Parameters.AddWithValue("@LRNo", TxtLRNo.Text);
                    cmd.Parameters.AddWithValue("@Acknowledgement", TextACK.Text);
                    //TxtTry.Text = "DSS";
                    GridView1.Visible = false;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                }
            }

        
        //catch (Exception e)
        //{
        //}
    }
    protected void clear()
    {
        TextTO.Text = "";
        Textaddress.Text = "";
        TextGST.Text = "";
        TextDCNO.Text = "";
        TextDCDate.Text = "";
        TextAttention.Text = "";
        TextContact.Text = "";
        TextRes.Text = "";
        TxtRemark.Text = "";
        TxtTrans.Text = "";
        TxtVehicle.Text = "";
        TxtLRNo.Text = "";
        TextACK.Text = "";
   
    }
    protected void cleargrid()
    {
        TxtItemCode.Text = "";
        TxtDesc.Text = "";
        TxtHsn.Text = "";
        TxtQty.Text = "";
        TxtRate.Text = "";
        TxtAmt.Text = "";
       

    }

    
}
