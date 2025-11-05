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

public partial class Module_Design_Transactions_ECN_Master_Edit : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;

    int CompId = 0;
    int FinYearId = 0;
    string sid = "";
    string connStr = "";
    string WONo = "";
    int ItemId = 0;
    int childId = 0;
    string Qty = "";
    int PId = 0;
    int AssId = 0;
    string Revision = "";
    string Material = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        FinYearId = Convert.ToInt32(Session["finyear"]);
        CompId = Convert.ToInt32(Session["compid"]);
        sid = Session["username"].ToString();
        WONo = Request.QueryString["WONo"].ToString();
        ItemId = Convert.ToInt32(Request.QueryString["ItemId"]);
        childId = Convert.ToInt32(Request.QueryString["CId"]);
        Qty = Request.QueryString["Qty"].ToString();
        Revision = Request.QueryString["Revision"].ToString();
        Material = Request.QueryString["Material"].ToString();
        PId = Convert.ToInt32(Request.QueryString["ParentId"]);
        AssId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!Page.IsPostBack)
        {
            this.loaddata();
        }
    }

    public void loaddata()
    {
        connStr = fun.Connection();
        con = new SqlConnection(connStr);
        string StrSql = fun.select("*", "tblDG_ECN_Reason", "CompId='" + CompId + "'");

        SqlCommand cmdsupId = new SqlCommand(StrSql, con);
        SqlDataAdapter dasupId = new SqlDataAdapter(cmdsupId);
        DataSet DSSql = new DataSet();
        dasupId.Fill(DSSql);
        GridView1.DataSource = DSSql;
        GridView1.DataBind();

    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            int u = 1;
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string MId = "";
            int y = 0;
            if (e.CommandName == "Ins")
            {

                foreach (GridViewRow grv in GridView1.Rows)
                {
                    if (((CheckBox)grv.FindControl("CheckBox1")).Checked == true)
                    {
                        con.Open();
                        string Id = ((Label)grv.FindControl("lblId")).Text;
                        string remarks = ((TextBox)grv.FindControl("TxtRemarks")).Text;
                        if (u == 1)
                        {

                            //// Amendment of BOM.................... 

                            string cmdbom = fun.select("*", "tblDG_BOM_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' AND CId='" + childId + "'");

                            DataSet DS10 = new DataSet();
                            string connStr10 = fun.Connection();
                            SqlConnection con10 = new SqlConnection(connStr10);
                            SqlCommand cmdBomMaster = new SqlCommand(cmdbom, con10);
                            SqlDataAdapter DA10 = new SqlDataAdapter(cmdBomMaster);
                            DA10.Fill(DS10);
                            string AmendmentNo = "";
                            if (DS10.Tables[0].Rows.Count > 0 && DS10.Tables[0].Rows[0]["AmdNo"] != DBNull.Value)
                            {

                                int PONstr = Convert.ToInt32(DS10.Tables[0].Rows[0]["AmdNo"].ToString()) + 1;
                                AmendmentNo = PONstr.ToString();
                            }
                            else
                            {
                                AmendmentNo = "0";
                            }

                            string StrAmd = fun.insert("tblDG_BOM_Amd", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,BOMId,PId,CId,ItemId,AmdNo,Qty", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sid + "','" + CompId + "','" + FinYearId + "','" + WONo + "','" + DS10.Tables[0].Rows[0]["Id"].ToString() + "','" + DS10.Tables[0].Rows[0]["PId"].ToString() + "','" + DS10.Tables[0].Rows[0]["CId"].ToString() + "', '" + ItemId + "' ,'" + DS10.Tables[0].Rows[0]["AmdNo"].ToString() + "','" + DS10.Tables[0].Rows[0]["Qty"].ToString() + "' ");

                            SqlCommand cmdAmd = new SqlCommand(StrAmd, con);
                            cmdAmd.ExecuteNonQuery();


                            string cmdstrTplMaster = fun.update("tblDG_BOM_Master", "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sid + "',Qty='" + Qty + "',AmdNo='" + AmendmentNo + "',Revision='" + Revision + "',Material='" + Material + "' ,ECNFlag=1", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' AND Id='" + AssId + "' AND CId='" + childId + "'");
                            SqlCommand cmdTplMaster = new SqlCommand(cmdstrTplMaster, con);
                            cmdTplMaster.ExecuteNonQuery();

                            int j = 0;

                            if (DS10.Tables[0].Rows.Count > 0)
                            {
                                string addtobom = fun.update("tblDG_BOM_Master",
                                "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sid + "',Qty='" + Qty + "',AmdNo='" + AmendmentNo + "' ", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' AND CId='" + childId + "'  And ECNFlag=1");
                                SqlCommand cmdaddtobom = new SqlCommand(addtobom, con);
                                cmdaddtobom.ExecuteNonQuery();


                                //--------------
                                string addtobom1 = fun.update("tblDG_BOM_Master",
                                "Revision='" + Revision + "'", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' And ECNFlag=1");
                                SqlCommand cmdaddtobom1 = new SqlCommand(addtobom1, con);
                                cmdaddtobom1.ExecuteNonQuery();


                                string addtobom2 = fun.update("tblDG_BOM_Master",
                               "Material='" + Material + "'", "CompId='" + CompId + "' AND ItemId='" + ItemId + "' AND WONo='" + WONo + "' And ECNFlag=1");
                                SqlCommand cmdaddtobom2 = new SqlCommand(addtobom2, con);
                                cmdaddtobom2.ExecuteNonQuery();


                                j++;
                            }


                            string sqlecn = fun.insert("tblDG_ECN_Master", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,WONo,PId,CId", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sid + "','" + ItemId + "','" + WONo + "','" + PId + "','" + childId + "'");
                            SqlCommand cmdECN = new SqlCommand(sqlecn, con);
                            cmdECN.ExecuteNonQuery();

                            u = 0;
                            string getId = fun.select("Id", "tblDG_ECN_Master", "CompId='" + CompId + "' Order by Id Desc");
                            SqlCommand cmd5 = new SqlCommand(getId, con);
                            SqlDataAdapter daAmd5 = new SqlDataAdapter(cmd5);
                            DataSet DSAmd5 = new DataSet();
                            daAmd5.Fill(DSAmd5, "tblDG_ECN_Master");
                            MId = DSAmd5.Tables[0].Rows[0]["Id"].ToString();
                        }

                        string sqlecn1 = fun.insert("tblDG_ECN_Details", "MId,ECNReason,Remarks", "'" + MId + "','" + Id + "','" + remarks + "'");
                        SqlCommand cmdECN1 = new SqlCommand(sqlecn1, con);
                        cmdECN1.ExecuteNonQuery();
                        con.Close();
                        y++;

                    }
                }
                if (y > 0)
                {
                    Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + WONo + "&ModId=3&SubModId=26");

                }
                else
                {
                    this.loaddata();
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_Item_Edit.aspx?ItemId=" + ItemId + "&WONo=" + WONo + "&PId=" + PId + "&CId=" + childId + "&Id=" + AssId + "&PgUrl=BOM_Design_WO_TreeView_Edit.aspx&ModId=3&SubModId=26");
    }
}

