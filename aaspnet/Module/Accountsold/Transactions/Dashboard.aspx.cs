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

public partial class Module_Accounts_Transactions_Dashboard : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;
    int CompId = 0;
    int FyId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Convert.ToInt32(Session["finyear"]);
            if (!IsPostBack)
            {
                this.FillGrid();
            }
        }
        catch (Exception et)
        {
        }
    }

    public void FillGrid()
    {
       try
        {
            DataTable dt = new DataTable();
            string sql = fun.select1("Id,Name", "tblACC_Bank order by OrdNo Asc");
            SqlCommand cmdsql = new SqlCommand(sql, con);
            SqlDataAdapter dasql = new SqlDataAdapter(cmdsql);
            DataSet dssql = new DataSet();
            dasql.Fill(dssql);
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Trans", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("OpAmt", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("ClAmt", typeof(double)));
            DataRow dr;

            for (int d = 0; d < dssql.Tables[0].Rows.Count; d++)
            {
                dr = dt.NewRow();

                dr[0] = dssql.Tables[0].Rows[d]["Id"].ToString();
                dr[1] = dssql.Tables[0].Rows[d]["Name"].ToString();
                if (dssql.Tables[0].Rows[d]["Name"].ToString() == "Cash")
                {
                    dr[2] = fun.getCashOpBalAmt("<", fun.getCurrDate(), CompId, FyId).ToString();
                    dr[3] = fun.getCashClBalAmt("=", fun.getCurrDate(), CompId, FyId).ToString();
                }
                else
                {
                    dr[2] = fun.getBankOpBalAmt("<", fun.getCurrDate(), CompId, FyId, Convert.ToInt32(dssql.Tables[0].Rows[d]["Id"])).ToString();
                    dr[3] = fun.getBankClBalAmt("=", fun.getCurrDate(), CompId, FyId, Convert.ToInt32(dssql.Tables[0].Rows[d]["Id"])).ToString();
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();

            }
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

        catch (Exception ex)
        { }
    }
    

    

}
