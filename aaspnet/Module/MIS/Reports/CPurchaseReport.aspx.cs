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
using System.Web.UI.DataVisualization.Charting;
using System.Drawing; 

public partial class Module_MIS_Reports_CPurchaseReport : System.Web.UI.Page
{
   clsFunctions fun = new clsFunctions();
    int FinYearId = 0;
    int CompId = 0;
    string CId = "";
    string WN = "";

    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
        {
            string sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            if (!Page.IsPostBack)
            {
                txtpoNo.Visible = false;
                this.Drpcheckchange();
                this.bindgrid(CId, WN);
            }
            this.drawgraph();
            this.drawgraphBasic();
        }
         catch (Exception ex) { }

    }
    public string Monthly(string FD)
    {
        string NFD = "";
        try
        {
            string a = FD;
            string[] b = a.Split('-');
            string d = b[0];
            string m = b[1];
            string y = b[2];
            NFD = m;
            return NFD;
        }
        catch (Exception ex) { }
        return NFD;
    }

    public void bindgrid(string Cid, string wn)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        DataTable dt = new DataTable();
        try
        {
            con.Open();

            if (DropDownList1.SelectedValue == "0")
            {
                txtpoNo.Visible = true;

                txtSupplier.Visible = false;
            }

            string I = "";
            if (DropDownList1.SelectedValue == "1")
            {
                if (txtSupplier.Text != "")
                {
                    string Supid = fun.getCode(txtSupplier.Text);
                    I = " AND SupplierId ='" + Supid + "'";
                }
            }


            string z = "";
            if (DropDownList1.SelectedValue == "2")
            {
                if (txtpoNo.Text != "")
                {
                    z = " AND PONo='" + txtpoNo.Text + "'";
                }
            }



            string sqlInv = fun.select("Id,FinYearId,SysDate,PONo,SupplierId", "tblMM_PO_Master", "CompId='" + CompId + "' And Authorize='1' And FinYearId='" + FinYearId + "'" + I + z + " Order by Id Desc ");

            SqlCommand cmdInv = new SqlCommand(sqlInv, con);
            SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
            DataSet DSInv = new DataSet();
            DAInv.Fill(DSInv);

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("PONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupplierName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("SupplierId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(double)));
            dt.Columns.Add(new System.Data.DataColumn("POMonth", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("BAmount", typeof(double)));
            if (DSInv.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                for (int i = 0; i < DSInv.Tables[0].Rows.Count; i++)
                {

                    dr = dt.NewRow();
                    string sqlrate = fun.select("sum( (Rate*Qty) -(rate*Discount)/100) as Total", " tblMM_PO_Details", " MId='" + DSInv.Tables[0].Rows[i]["Id"] + "'");
                    SqlCommand cmdrate = new SqlCommand(sqlrate, con);
                    SqlDataAdapter DArate = new SqlDataAdapter(cmdrate);
                    DataSet DSrate = new DataSet();
                    DArate.Fill(DSrate);
                    double Total =Math.Round( Convert.ToDouble(DSrate.Tables[0].Rows[0]["Total"]),2);

                    string sqlFin = fun.select("FinYear", "tblFinancial_master", "FinYearId='" + DSInv.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                    SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                    SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                    DataSet DSFin = new DataSet();
                    daFin.Fill(DSFin);

                    string Sysdt = fun.FromDateDMY(DSInv.Tables[0].Rows[i]["SysDate"].ToString());
                    string mo = this.Monthly(DSInv.Tables[0].Rows[i]["SysDate"].ToString());


                    string sqlCust = fun.select("SupplierName,SupplierId", "tblMM_Supplier_master", "SupplierId='" + DSInv.Tables[0].Rows[i]["SupplierId"] + "' And CompId='" + CompId + "'");
                    SqlCommand cmdCust = new SqlCommand(sqlCust, con);
                    SqlDataAdapter DACust = new SqlDataAdapter(cmdCust);
                    DataSet DSCust = new DataSet();
                    DACust.Fill(DSCust);

                    string sql = fun.select("PF,ExST,VAT", " tblMM_PO_Details", " MId='" + DSInv.Tables[0].Rows[i]["Id"] + "'");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                    int pf = Convert.ToInt32(DS.Tables[0].Rows[0]["PF"]);
                    int ex = Convert.ToInt32(DS.Tables[0].Rows[0]["ExST"]);
                    int vat = Convert.ToInt32(DS.Tables[0].Rows[0]["VAT"]);
                    double VAT = 0;
                    double stax = 0;
                    double PF = 0;
                    double Amount1 = 0;
                    string sqlpf = fun.select("Value", "tblPacking_Master", "Id='" + pf + "'");
                    SqlCommand cmdpf = new SqlCommand(sqlpf, con);
                    SqlDataAdapter dapf = new SqlDataAdapter(cmdpf);
                    DataSet dspf = new DataSet();
                    dapf.Fill(dspf);
                    PF = Convert.ToDouble(dspf.Tables[0].Rows[0]["Value"]);

                    Amount1 = ((Total * PF) / 100);

                    string service = fun.select("Id,Terms,Value,AccessableValue,EDUCess,SHECess,Live,LiveSerTax", "tblExciseser_Master", "Id='" + ex + "'");
                    SqlCommand cmdser = new SqlCommand(service, con);
                    SqlDataAdapter daser = new SqlDataAdapter(cmdser);
                    DataSet dsser = new DataSet();
                    daser.Fill(dsser);
                    stax = Convert.ToDouble(dsser.Tables[0].Rows[0]["Value"]);
                    double ServiceTax = (((Total + Amount1) * stax) / 100);
                    double Amount2 = 0;
                    string vt = fun.select("Id  , Terms, Value ", "tblVAT_Master", "Id='" + vat + "'");
                    SqlCommand cmdvt = new SqlCommand(vt, con);
                    SqlDataAdapter davt = new SqlDataAdapter(cmdvt);
                    DataSet dsvt = new DataSet();
                    davt.Fill(dsvt);
                    VAT = Convert.ToDouble(dsvt.Tables[0].Rows[0]["Value"]);

                    Amount2 = (((Total + Amount1 ) * VAT) / 100);

                    double Amount = Total + Amount1 + ServiceTax + Amount2;
                    double BAmt = Math.Round(Amount, 2);
                    dr[0] = DSInv.Tables[0].Rows[i]["Id"].ToString();
                    dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                    dr[2] = DSInv.Tables[0].Rows[i]["PONo"].ToString();
                    dr[3] = Sysdt;
                    dr[4] = DSCust.Tables[0].Rows[0]["SupplierName"].ToString() + "[" + DSCust.Tables[0].Rows[0]["SupplierId"].ToString() + "]";

                    dr[5] = DSCust.Tables[0].Rows[0]["SupplierId"].ToString();
                    dr[6] = Math.Round(BAmt, 2);
                    dr[7] = mo;
                    dr[8] = Math.Round(Total);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            
        }
    }
    public void drawgraph()
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);

        // ===================================== Monthly Purchase =============================


        int fyid = Convert.ToInt32(Session["finyear"]);
        int cid = Convert.ToInt32(Session["compid"]);

        string sql3 = "Select FinYear from tblfinancial_master Where FinYearId='" + fyid + "'";

        SqlCommand cmd3 = new SqlCommand(sql3, con);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        Chart1.Series[0].ChartType = SeriesChartType.Column;
        Chart1.Series[0]["DrawingStyle"] = "Cylinder";
        Chart1.Series[0]["PointWidth"] = "0.3";
        Chart1.Series[0].IsValueShownAsLabel = true;
        Chart1.ChartAreas[0].AxisX.Title = "Fin. Year  " + ds3.Tables[0].Rows[0][0].ToString();
        Chart1.ChartAreas[0].BackColor = Color.LightGreen;
        Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        Chart1.ChartAreas[0].Area3DStyle.PointDepth = 250;
        Chart1.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
        Chart1.ChartAreas[0].AxisY.IsStartedFromZero = true;

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataRow dr;

        dt.Columns.Add(new System.Data.DataColumn("ct", typeof(string)));

        string[] mthno = new string[] { "04", "05", "06", "07", "08", "09", "10", "11", "12", "01", "02", "03" };

        int k;
        double Turnover = 0;
        for (k = 0; k < mthno.Length; k++)
        {
            double TotAmt = 0;
            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((Label)grv.FindControl("lblPOMonth")).Text == mthno[k])
                {
                    TotAmt += Convert.ToDouble(((Label)grv.FindControl("lblAmt")).Text);                  
                
                }               
            }
            Turnover += TotAmt;

            dr = dt.NewRow();
            dr[0] = TotAmt;
            //dt.Clear();
            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }

        lblTaxturn.Text = "Total Tax. Purchase Amt. : " + Turnover.ToString();

        Chart1.ChartAreas[0].AxisX.Interval = 1;
        Chart1.ChartAreas[0].AxisY.Title = "Amount in  Rs.";
        Chart1.Series[0].YValueMembers = dt.Columns[0].ToString();
        Chart1.DataSource = dt;
        Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);
        Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(2, 0.1, "APR");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(4, 0.1, "MAY");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(6, 0.1, "JUN");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(8, 0.1, "JUL");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(10, 0.1, "AUG");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(12, 0.1, "SEP");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(14, 0.1, "OCT");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(16, 0.1, "NOV");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(18, 0.1, "DEC");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(20, 0.1, "JAN");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(22, 0.1, "FEB");
        Chart1.ChartAreas[0].AxisX.CustomLabels.Add(24, 0.1, "MAR");
        Chart1.DataBind();
        Chart1.Visible = true;

    } 

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
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
      
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bindgrid(CId, WN);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         try
        {
            this.bindgrid(txtSupplier.Text, txtpoNo.Text);
            this.drawgraph();
            this.drawgraphBasic();
        }
       catch (Exception ex) { }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {         

        this.Drpcheckchange();
    }

    public void Drpcheckchange()
    {
       // try
        {
            if (DropDownList1.SelectedValue == "1")
            {
                txtpoNo.Visible = false;
                txtSupplier.Visible = true;
                txtSupplier.Text = "";
                //this.bindgrid(CId, WN);
            }


            if (DropDownList1.SelectedValue == "2" || DropDownList1.SelectedValue == "0")
            {
                txtpoNo.Visible = true;
                txtSupplier.Visible = false;
                txtpoNo.Text = "";
                //this.bindgrid(CId, WN);
            }
        }

       // catch (Exception ex) { }
    }

    public void drawgraphBasic()
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);

        // Monthly Purchase =========================================================================


        int fyid = Convert.ToInt32(Session["finyear"]);
        int cid = Convert.ToInt32(Session["compid"]);

        string sql3 = "Select FinYear from tblfinancial_master Where FinYearId='" + fyid + "'";

        SqlCommand cmd3 = new SqlCommand(sql3, con);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataSet ds3 = new DataSet();
        da3.Fill(ds3);
        Chart2.Series[0].ChartType = SeriesChartType.Column;
        Chart2.Series[0]["DrawingStyle"] = "Cylinder";
        Chart2.Series[0]["PointWidth"] = "0.3";
        Chart2.Series[0].IsValueShownAsLabel = true;
        Chart2.ChartAreas[0].AxisX.Title = "Fin. Year  " + ds3.Tables[0].Rows[0][0].ToString();
        Chart2.ChartAreas[0].BackColor = Color.LightGreen;
        Chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
        Chart2.ChartAreas[0].Area3DStyle.PointDepth = 250;
        Chart2.ChartAreas[0].Area3DStyle.PointGapDepth = 0;
        Chart2.ChartAreas[0].AxisY.IsStartedFromZero = true;

        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataRow dr;

        dt.Columns.Add(new System.Data.DataColumn("ct", typeof(string)));

        string[] mthno = new string[] { "04", "05", "06", "07", "08", "09", "10", "11", "12", "01", "02", "03" };

        int k;
        double Turnover = 0;
        for (k = 0; k < mthno.Length; k++)
        {
            double TotAmt = 0;
            foreach (GridViewRow grv in GridView1.Rows)
            {
                if (((Label)grv.FindControl("lblPOMonth")).Text == mthno[k])
                {
                    TotAmt += Convert.ToDouble(((Label)grv.FindControl("lblBAmt")).Text);

                }
            }
            Turnover += TotAmt;

            dr = dt.NewRow();
            dr[0] = TotAmt;
            //dt.Clear();
            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }

        lblturn.Text = "Total Basic Purchase Amt. : " + Turnover.ToString();

        Chart2.ChartAreas[0].AxisX.Interval = 1;
        Chart2.ChartAreas[0].AxisY.Title = "Amount in  Rs.";
        Chart2.Series[0].YValueMembers = dt.Columns[0].ToString();
        Chart2.DataSource = dt;
        Chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);
        Chart2.ChartAreas[0].AxisX.LabelStyle.Angle = 45;
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(2, 0.1, "APR");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(4, 0.1, "MAY");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(6, 0.1, "JUN");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(8, 0.1, "JUL");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(10, 0.1, "AUG");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(12, 0.1, "SEP");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(14, 0.1, "OCT");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(16, 0.1, "NOV");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(18, 0.1, "DEC");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(20, 0.1, "JAN");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(22, 0.1, "FEB");
        Chart2.ChartAreas[0].AxisX.CustomLabels.Add(24, 0.1, "MAR");
        Chart2.DataBind();
        Chart2.Visible = true;

    } 

}

