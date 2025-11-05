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
    clsFunctions fun = new clsFunctions();

    SqlCommand cmd;
    SqlCommand cmd1;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
    static SqlDataAdapter da;
    static DataTable dt;
    static DataSet ds;
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        sId = Session["username"].ToString();
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);


        //TextDCDate.Text = DateTime.Now.ToShortDateString();
        Display();
     
    

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
   //// For Name Extender  /////

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> Search(string prefixText)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        DataTable Result1 = new DataTable();
        string str1 = "select  EmployeeName from tblHR_OfficeStaff where EmployeeName like '" + prefixText + "%'";
        da = new SqlDataAdapter(str1, con1);
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
        String strQuery = "select SupplierName,WorkAddress,ContactNo from tblMM_Supplier_master where SupplierName='" + TextTO.Text + "'";
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
                Textaddress.Text = sdr["WorkAddress"].ToString();
               
                TextContact.Text = sdr["ContactNo"].ToString();
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
            SqlCommand cmdzs = new SqlCommand("SELECT MAX((VehNo) + 1) as VehNo FROM tblVeh_Master_Details ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            TextDCNO.Text = cmdzs.ExecuteScalar().ToString();
        }

    }
    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        Save();
        clear();
        Response.Redirect("Vehical_Information.aspx", true);
    }
    protected void  Save()
    {
        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();


            string sqlStatment = "INSERT INTO tblVeh_Master_Details(SysDate,SysTime,SessionId,CompId,FinYearId,Vehical_Name,Date,Destination,Address,FromKM,FromTo,Avg,Fluel_Date,Fluel_Rs,Material,Emp,VehNo,Contact) VALUES(@SysDate,@SysTime,@SessionId,@CompId,@FinYearId,@Vehical_Name,@Date,@Destination,@Address,@FromKM,@FromTo,@Avg,@Fluel_Date,@Fluel_Rs,@Material,@Emp,@VehNo,@Contact)";
            {
                using (SqlCommand cmd = new SqlCommand(sqlStatment, con))
                {
                    
                    cmd.Parameters.AddWithValue("@SysDate", CDate.ToString());
                    cmd.Parameters.AddWithValue("@SysTime", CTime.ToString());
                    cmd.Parameters.AddWithValue("@SessionId", sId.ToString());
                    cmd.Parameters.AddWithValue("@CompId", CompId);
                    cmd.Parameters.AddWithValue("@FinYearId", FinYearId);


                    cmd.Parameters.AddWithValue("@Destination", TextTO.Text);
                    cmd.Parameters.AddWithValue("@Address", Textaddress.Text);
                    cmd.Parameters.AddWithValue("@VehNo", TextDCNO.Text);
                    cmd.Parameters.AddWithValue("@Date", TextDCDate.Text);
                    cmd.Parameters.AddWithValue("@Contact", TextContact.Text);
                    cmd.Parameters.AddWithValue("@Emp", TextRes.Text);
                    cmd.Parameters.AddWithValue("@Vehical_Name", ddlType.Text);


                    cmd.Parameters.AddWithValue("@FromKM", TxtTrans.Text);
                    cmd.Parameters.AddWithValue("@FromTo", TxtVehicle.Text);
                    cmd.Parameters.AddWithValue("@Avg", TxtLRNo.Text);
                    cmd.Parameters.AddWithValue("@Fluel_Date", TextACK.Text);
                    cmd.Parameters.AddWithValue("@Fluel_Rs", TxtRemarkM.Text);
                    cmd.Parameters.AddWithValue("@Material", TxtTransE.Text);
                 //   cmd.Parameters.AddWithValue("@Emp", TxtTransE.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                   
                  
                    con.Close();

                }
            }
}
        catch (Exception eX)
        {
        }
    }
    
    protected void clear()
    {
        TextTO.Text = "";
        Textaddress.Text = "";
        
        TextDCNO.Text = "";
        TextDCDate.Text = "";
       // TextAttention.Text = "";
        TextContact.Text = "";
        TextRes.Text = "";
        TxtRemarkM.Text = "";
        TxtTrans.Text = "";
        TxtVehicle.Text = "";
        TxtLRNo.Text = "";
        TextACK.Text = "";
       
   
    }
    

    
}
