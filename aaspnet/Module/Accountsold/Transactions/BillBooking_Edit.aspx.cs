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

public partial class Module_Accounts_Transactions_BillBooking_Edit : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string SupId = "";
    string PONo = "";
    string sId = "";
    int FinYearId = 0;
    int CompId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        {

            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);

            if (!Page.IsPostBack)
            {
                Txtfield.Visible = false;
                this.loadData(SupId, PONo);
            }
        }
        //catch(Exception ex){}
    }

    public void loadData(string spid, string pono)
    {
        //try
        {
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);

            DataTable dt = new DataTable();

            con.Open();
            string x = "";
            if (DropDownList1.SelectedValue == "2")
            {
                if (Txtfield.Text != "")
                {
                    x = " And PVEVNo='" + Txtfield.Text + "'";
                }
            }
            string y = "";
            if (DropDownList1.SelectedValue == "1")
            {
                if (txtSupplier.Text != "")
                {
                    string Sid = fun.getCode(txtSupplier.Text);
                    y = " And SupplierId='" + Sid + "'";
                }
            }

            if (DropDownList1.SelectedValue == "0")
            {
                Txtfield.Visible = true;
                txtSupplier.Visible = false;
            }
            //else if(DropDownList1.SelectedValue != "Select")
            //{
            //    Txtfield.Enabled = true;
            //}

            string StrSql = fun.select("Id,FinYearId,PVEVNo,SysDate, BillNo, BillDate ,SupplierId", "tblACC_BillBooking_Master", "CompId='" + CompId + "'AND FinYearId<='" + FinYearId + "'" + x + y + " Order by Id Desc");

            SqlCommand cmdsupId = new SqlCommand(StrSql, con);
            SqlDataReader Sdr = cmdsupId.ExecuteReader();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYearId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PODate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Supplier", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PVEVNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PVEVDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BillDate", typeof(string)));

            DataRow dr;

            while (Sdr.Read())
            {
                dr = dt.NewRow();

                int FinYr = Convert.ToInt32(Sdr["FinYearId"]);
                string SysDt = fun.FromDateDMY(Sdr["SysDate"].ToString());

                string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + FinYr + "'");
                SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                SqlDataReader rdFinYr = cmdFinYr.ExecuteReader();
                rdFinYr.Read();

                string sqlSup = fun.select("SupplierName", "tblMM_Supplier_master", "SupplierId='" + Sdr["SupplierId"].ToString() + "'");
                SqlCommand cmdSupId = new SqlCommand(sqlSup, con);
                SqlDataReader rdSupId = cmdSupId.ExecuteReader();
                rdSupId.Read();

                string z = "";
                if (DropDownList1.SelectedValue == "3")
                {
                    if (Txtfield.Text != "")
                    {
                        z = " And tblMM_PO_Master.PONo='" + Txtfield.Text + "'";
                    }
                }

                dr[0] = Sdr["Id"].ToString();
                dr[1] = Sdr["FinYearId"].ToString();
                dr[2] = rdFinYr["FinYear"].ToString();
                dr[6] = Sdr["SupplierId"].ToString();
                dr[5] = rdSupId["SupplierName"].ToString() + " [" + Sdr[0].ToString() + "]";
                dr[7] = Sdr["PVEVNo"].ToString();
                dr[8] = SysDt;
                dr[9] = Sdr["BillNo"].ToString();
                dr[10] = fun.FromDateDMY(Sdr["BillDate"].ToString());
                
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
            con.Close();

        }
        //catch (Exception et)
        {

        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_master", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_master");
        con.Close();
        string[] main = new string[0];
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i].ItemArray[1].ToString().ToLower().StartsWith(prefixText.ToLower()))
            {
                Array.Resize(ref main, main.Length + 1);
                main[main.Length - 1] = ds.Tables[0].Rows[i].ItemArray[1].ToString() + " [" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "]";
                //if (main.Length == 10)
                //    break;
            }
        }
        Array.Sort(main);
        return main;
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView2.PageIndex = e.NewPageIndex;
            this.loadData(SupId, PONo);

        }
        catch (Exception ex) { }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string Spid = "";
            string No = "";
            Spid = fun.getCode(txtSupplier.Text);
            No = Txtfield.Text;
            this.loadData(Spid, No);
        }
        catch (Exception ex) { }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "1")
            {
                Txtfield.Visible = false;
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                this.loadData(SupId, PONo);
            }
            if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "3" || DropDownList1.SelectedValue == "0")
            {
                Txtfield.Visible = true;
                txtSupplier.Visible = false;
                Txtfield.Text = "";
                this.loadData(SupId, PONo);
            }
        
        }
        catch (Exception ex) { }
    }
}
