
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

public partial class Module_MaterialManagement_Transactions_PR_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    string sId = "";
    int CompId = 0;
    int FyId = 0;
    string w = "";
    int h = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            con.Open();
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Convert.ToInt32(Session["finyear"]);

            string deltemp = fun.delete("tblMM_PLN_PR_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd4 = new SqlCommand(deltemp, con);
            cmd4.ExecuteNonQuery();
           
            if (!IsPostBack)
                 {
                     string StrCat = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
                     SqlCommand Cmd = new SqlCommand(StrCat, con);
                     SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                     DataSet DS = new DataSet();
                     DA.Fill(DS, "tblSD_WO_Category");
                     DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
                     DDLTaskWOType.DataTextField = "Category";
                     DDLTaskWOType.DataValueField = "CId";
                     DDLTaskWOType.DataBind();
                     DDLTaskWOType.Items.Insert(0, "WO Category");
                
                
                con.Close();
                this.getItemTot(w,h);
            }

            
        }
        catch(Exception ex){}
    }

    public void getItemTot(string wo, int c)
    {
        try
        {

            string str = fun.Connection();
            SqlConnection con = new SqlConnection(str);

            con.Open();

            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("WONo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ProjectTitle", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Release", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Run", typeof(string)));

            DataRow dr;

            string x = "";
            if (TxtWONo.Text != "")
            {
                x = " And WONo='" + TxtWONo.Text + "'";
            }
            string Z = "";
            if (DDLTaskWOType.SelectedValue != "WO Category")
            {

                Z = " AND CId='" + Convert.ToInt32(DDLTaskWOType.SelectedValue) + "'";
            }

            string sqlwo = fun.select("WONo,TaskProjectTitle", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "' AND CloseOpen='0'" + x +Z+ " Order by WONo");

            SqlCommand cmdwo = new SqlCommand(sqlwo, con);
            SqlDataAdapter dawo = new SqlDataAdapter(cmdwo);
            DataSet DSwo = new DataSet();
            dawo.Fill(DSwo);
           
            for (int k = 0; k < DSwo.Tables[0].Rows.Count; k++)
            {
                dr = dt.NewRow();

                dr[0] = DSwo.Tables[0].Rows[k]["WONo"].ToString();
                dr[1] = DSwo.Tables[0].Rows[k]["TaskProjectTitle"].ToString();

                //if (DSwo.Tables[0].Rows[k]["ReleaseWIS"].ToString() == "1")
                //{
                //   // dr[2] = "Released";
                //}
                //else
                //{
                //    if (DSwo.Tables[0].Rows[k]["DryActualRun"].ToString() == "1")
                //    {
                //      //  dr[2] = "Stop";
                //    }
                //    else
                //    {
                //      //  dr[2] = "Not Release";
                //    }
                //}


                //if (DSwo.Tables[0].Rows[k]["DryActualRun"].ToString() == "1")
                //{
                //    dr[3] = "Yes";
                //}
                //else
                //{
                //    dr[3] = "No";
                //}

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();

            foreach (GridViewRow grv in GridView2.Rows)
            {
                //if (((Label)grv.FindControl("lblrun")).Text == "No")
                //{
                //    ((LinkButton)grv.FindControl("LinkButton1")).Visible = false;
                //}
                //else
                //{
                //    if (((Label)grv.FindControl("lblrel")).Text == "Released")
                //    {
                //        ((LinkButton)grv.FindControl("LinkButton1")).Visible = true;
                //    }
                //    else
                //    {
                //        ((LinkButton)grv.FindControl("LinkButton1")).Visible = false;
                //    }
                //}
            }

            con.Close();
        }
       catch (Exception ess)
        {

        }
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
        
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string WONo = "";
            WONo = ((Label)row.FindControl("lblwono")).Text;

            Response.Redirect("~/Module/Report/Reports/PR_New_Details.aspx?WONo=" + WONo + "");            
        }

    }


    protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLTaskWOType.SelectedValue != "WO Category")
        {
            int k = Convert.ToInt32(DDLTaskWOType.SelectedValue);
            this.getItemTot(w,k);
        }
        else
        {
            this.getItemTot(w,h);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      
        this.getItemTot(TxtWONo.Text,h);
        foreach (GridViewRow grv in GridView2.Rows)
        {
            if (((Label)grv.FindControl("lblrun")).Text == "No")
            {
                ((LinkButton)grv.FindControl("LinkButton1")).Visible = false;
            }
            else
            {
                if (((Label)grv.FindControl("lblrel")).Text == "Released")
                {
                    ((LinkButton)grv.FindControl("LinkButton1")).Visible = true;
                }
                else
                {
                    ((LinkButton)grv.FindControl("LinkButton1")).Visible = false;
                }
            }
        }
    }
   
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        
        this.getItemTot(w,h);
    }

}
