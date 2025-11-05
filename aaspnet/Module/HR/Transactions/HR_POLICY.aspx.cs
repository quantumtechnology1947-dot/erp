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
using MKB.TimePicker;
using System.Web.Mail;
using System.Net;
using System.IO;

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

        BindGrid();
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select Id,CVDate,CVName,CVFileName from tblHR_POLICY";
                cmd.Connection = con;
                con.Open();
                GridView.DataSource = cmd.ExecuteReader();
                GridView.DataBind();
                con.Close();

            }
        }
    }

    protected void Btnsubmit_Click(object sender, EventArgs e)
    {
        Save();
        // clear();
        Response.Redirect("HR_POLICY.aspx", true);
    }
    protected void Save()
    {
        try
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

           

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            con.Open();


            //string strfilename = "";
            //HttpPostedFile myfile = FileUpload1.PostedFile;
            //Byte[] mydata = null;

            //if (FileUpload1.PostedFile != null)
            //{
            //    Stream fs = FileUpload1.PostedFile.InputStream;
            //    BinaryReader br = new BinaryReader(fs);
            //    mydata = br.ReadBytes((Int32)fs.Length);
            //    strfilename = Path.GetFileName(myfile.FileName);
            //}

            /////// For pdf////

            string strcv = "";
            HttpPostedFile mycv = FileUploadControl.PostedFile;
            Byte[] mycvdata = null;

            if (FileUploadControl.PostedFile != null)
            {
                Stream fscv = FileUploadControl.PostedFile.InputStream;
                BinaryReader brcv = new BinaryReader(fscv);
                mycvdata = brcv.ReadBytes((Int32)fscv.Length);
                strcv = Path.GetFileName(mycv.FileName);
            }



            string StrAdd = fun.insert("tblHR_POLICY", "SysDate,SysTime,CompId,FinYearId,SessionId,CVFileName,CVSize,CVContentType,CVData,CVDate,CVName", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + strcv + "','" + mycvdata.Length + "','" + mycv.ContentType + "',@CV,'" + txtfileDate.Text + "','" + txtpdf.Text + "'");
            SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
           // cmdAdd.Parameters.AddWithValue("@Data", mydata);
            cmdAdd.Parameters.AddWithValue("@CV", mycvdata);

            cmdAdd.ExecuteNonQuery();
            con.Close();

        }


        catch (Exception eX)
        {
        }
    }



    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {
            int Name = Convert.ToInt32((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string filename, contentType;
            string constr1 = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr1))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.CommandText = "select CVFileName,CVContentType,CVData from  tblHR_POLICY where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", Name);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader str = cmd.ExecuteReader();
                    
                        str.Read();
                        bytes = (byte[])str["CVData"];
                        contentType = str["CVContentType"].ToString();
                        filename = str["CVFileName"].ToString();
                    
                    con.Close();


                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = contentType;
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();

                }
            }
        }
        catch (Exception ex)
        {

        }
    }



    //protected void DownloadFile(object sender, EventArgs e)
    //{

        
 
    //        int ImageId = int.Parse((sender as LinkButton).CommandArgument);
    //        byte[] bytes;
    //        string fileName, contentType;
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand("tblHR_POLICY", con);
    //        //cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@Id", ImageId);
    //        SqlDataReader sdr = cmd.ExecuteReader();
    //        sdr.Read();
    //        fileName = sdr["FileName"].ToString();
    //        bytes = (byte[])sdr["FileData"];
    //        contentType = sdr["ContentType"].ToString();
    //        con.Close();
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "";
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        Response.ContentType = contentType;
    //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
    //        Response.BinaryWrite(bytes);
    //        Response.Flush();
    //        Response.End();
 
    //    }
 

    }
    

    

 

