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
using System.IO;
using System.Data.SqlClient;

public partial class Download : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            SqlConnection dbConn = new SqlConnection(connStr);

            string qid = Request.QueryString.Get("Id");
            string qstr = Request.QueryString.Get("tbl");
            string qfd = Request.QueryString.Get("qfd");
            string qfn = Request.QueryString.Get("qfn");
            string qct = Request.QueryString.Get("qct");

            string strcmd = fun.select("*", qstr, "Id='" + qid + "'");
            SqlCommand cmd = new SqlCommand(strcmd);

            DataTable dt = fun.GetData(cmd);

            if (dt != null)
            {
                download(dt, qfd, qfn, qct);
            }
          
        }
        catch (Exception ex)
        {

        }
    }


    private void download(DataTable dt, string fd, string fn, string ct)
    {
    try
        {
            Byte[] bytes = (Byte[])dt.Rows[0][fd];

            Response.Buffer = true;

            Response.Charset = "";

            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = dt.Rows[0][ct].ToString();

            Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0][fn].ToString());

           Response.BinaryWrite(bytes);

          //  Response.Flush();
        
            Response.End();
           

        }
       catch (Exception ep)
        {

        }
    }
}