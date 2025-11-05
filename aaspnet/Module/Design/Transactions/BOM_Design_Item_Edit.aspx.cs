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
using System.IO;
using System.Security.Cryptography;

public partial class Module_Design_Transactions_BOM_Design_Item_Edit : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string wono = "";
    int itemId = 0;
    int Category = 0;
    string asslyId = "";
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string uom = "";
    string ItemCId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        string connStr1 = fun.Connection();
        SqlConnection con1 = new SqlConnection(connStr1);
        try
        {
            asslyId = Request.QueryString["Id"];
            wono = Request.QueryString["WONo"];
            lblWONo.Text = wono;
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            DataSet DS = new DataSet();

            itemId = Convert.ToInt32(Request.QueryString["ItemId"]);

            if (!IsPostBack)
            {
                string cmdStr = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.CId As ItemCId,tblDG_Item_Master.UOMBasic,Unit_Master.Symbol as bUOM,tblDG_Item_Master.UOMBasic,tblDG_BOM_Master.CId,tblDG_BOM_Master.WONo,tblDG_Item_Master.PartNo,tblDG_Item_Master.ItemCode,tblDG_Item_Master.ManfDesc,tblDG_BOM_Master.Qty,tblDG_Item_Master.FileName,tblDG_BOM_Master.Revision,tblDG_BOM_Master.Material", "Unit_Master,tblDG_Item_Master,tblDG_BOM_Master", "tblDG_Item_Master.Id=tblDG_BOM_Master.ItemId AND tblDG_BOM_Master.WONo='" + wono + "' AND tblDG_BOM_Master.ItemId='" + itemId + "' AND Unit_Master.Id = tblDG_Item_Master.UOMBasic AND tblDG_BOM_Master.CompId='" + CompId + "' AND tblDG_BOM_Master.FinYearId<='" + FinYearId + "'AND tblDG_BOM_Master.Id='" + asslyId + "'");
                SqlCommand cmd = new SqlCommand(cmdStr, con1);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DA.Fill(DS);

                if (DS.Tables[0].Rows.Count > 0)
                {

                    lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DS.Tables[0].Rows[0]["Id"].ToString()));
                    lblMfDesc.Text = DS.Tables[0].Rows[0]["ManfDesc"].ToString();
                    lblUOMB.Text = DS.Tables[0].Rows[0]["bUOM"].ToString();
                    txtQuntity.Text = DS.Tables[0].Rows[0]["Qty"].ToString();
                    uom = DS.Tables[0].Rows[0]["UOMBasic"].ToString();
                    ItemCId = DS.Tables[0].Rows[0]["ItemCId"].ToString();
                    txtRevision.Text = DS.Tables[0].Rows[0]["Revision"].ToString();
                 //   txtremark.Text = DS.Tables[0].Rows[0]["Remark"].ToString();
                    txtmat.Text = DS.Tables[0].Rows[0]["Material"].ToString();

                }
            }



        }
        catch (Exception es)
        {

        }

        finally
        {
            con1.Close();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {

            string msg = "";
            con.Open();
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            int CId = Convert.ToInt32(Request.QueryString["CId"]);
            int PID = 0;
            string WODesignDate = fun.select(" TaskDesignFinalization_TDate", " SD_Cust_WorkOrder_Master", "WONo='" + wono + "'");
            SqlCommand CmdDate = new SqlCommand(WODesignDate, con);
            SqlDataAdapter DaDate = new SqlDataAdapter(CmdDate);
            DataSet DsDate = new DataSet();
            DaDate.Fill(DsDate);
            string Designdate = (DsDate.Tables[0].Rows[0][0].ToString());



            if (Convert.ToDateTime(Designdate) >= Convert.ToDateTime(CDate))
            {

                if (txtQuntity.Text != "" && fun.NumberValidationQty(txtQuntity.Text) == true)
                {
                    string cmdbom = fun.select("*", "tblDG_BOM_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + CId + "'");

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

                    string x = string.Empty;
                    if (ItemCId != string.Empty)
                    {
                        x = lblMfDesc.Text;
                    }

                    string StrAmd = fun.insert("tblDG_BOM_Amd", "SysDate,SysTime,SessionId,CompId,FinYearId,WONo,BOMId,PId,CId,ItemId,Description,UOM,AmdNo,Qty", "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + wono + "','" + DS10.Tables[0].Rows[0]["Id"].ToString() + "','" + DS10.Tables[0].Rows[0]["PId"].ToString() + "','" + DS10.Tables[0].Rows[0]["CId"].ToString() + "', '" + itemId + "' , '" + x + "', '" + uom + "','" + DS10.Tables[0].Rows[0]["AmdNo"].ToString() + "','" + DS10.Tables[0].Rows[0]["Qty"].ToString() + "' ");

                    SqlCommand cmdAmd = new SqlCommand(StrAmd, con);
                    cmdAmd.ExecuteNonQuery();


                    string cmdstrTplMaster = fun.update("tblDG_BOM_Master", "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',Qty='" + Convert.ToDouble(decimal.Parse((txtQuntity.Text).ToString()).ToString("N3")) + "',AmdNo='" + AmendmentNo + "',Revision='" + txtRevision.Text + "',Material='" + txtmat.Text + "'", "CompId='" + CompId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND Id='" + asslyId + "' AND CId='" + CId + "'");
                    SqlCommand cmdTplMaster = new SqlCommand(cmdstrTplMaster, con);
                    cmdTplMaster.ExecuteNonQuery();
                   
                    int j = 0;
                    if (DS10.Tables[0].Rows.Count > 0)
                    {
                        //For Qty only
                        string addtobom = fun.update("tblDG_BOM_Master",
                        "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',Qty='" + Convert.ToDouble(decimal.Parse((txtQuntity.Text).ToString()).ToString("N3")) + "',AmdNo='" + AmendmentNo + "'", "CompId='" + CompId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + CId + "'");
                        SqlCommand cmdaddtobom = new SqlCommand(addtobom, con);
                        cmdaddtobom.ExecuteNonQuery();
                        
                        //For Revision only
                        string addtobom1 = fun.update("tblDG_BOM_Master", "Revision='" + txtRevision.Text + "' ", "CompId='" + CompId + "'AND ItemId='" + itemId + "' AND WONo='" + wono + "'");
                        SqlCommand cmdaddtobom1 = new SqlCommand(addtobom1, con);
                        cmdaddtobom1.ExecuteNonQuery();
                        
                        
                        //// For Material Only
                        string addtobom2 = fun.update("tblDG_BOM_Master", "Material='" + txtmat.Text + "' ", "CompId='" + CompId + "'AND ItemId='" + itemId + "' ");
                        SqlCommand cmdaddtobom2 = new SqlCommand(addtobom2, con);
                        cmdaddtobom2.ExecuteNonQuery();
                        j++;
                        
                    }
                    msg = "BOM is Updated sucessfully.";
                    if (j > 0)
                    {
                        Page.Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&msg=" + msg + "&ModId=3&SubModId=26");
                    }
                }

            }
            else
            {


                if (txtQuntity.Text != "" && fun.NumberValidationQty(txtQuntity.Text) == true && txtmat.Text!="" && txtRevision.Text !="")
                {


                    string cmdbom = fun.select("PId", "tblDG_BOM_Master", "CompId='" + CompId + "' AND FinYearId<='" + FinYearId + "' AND ItemId='" + itemId + "' AND WONo='" + wono + "' AND CId='" + CId + "'");

                    DataSet DS10 = new DataSet();
                    string connStr10 = fun.Connection();
                    SqlConnection con10 = new SqlConnection(connStr10);
                    SqlCommand cmdBomMaster = new SqlCommand(cmdbom, con10);
                    SqlDataAdapter DA10 = new SqlDataAdapter(cmdBomMaster);
                    DA10.Fill(DS10);
                    PID = Convert.ToInt32(DS10.Tables[0].Rows[0]["PId"].ToString());
                    Response.Redirect("ECN_Master_Edit.aspx?ItemId=" + itemId + "&WONo=" + wono + "&CId=" + CId + "&ParentId=" + PID + "&Qty=" + txtQuntity.Text + "&Id=" + asslyId + "&Revision=" + txtRevision.Text + "&Material="+txtmat.Text+"");

                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("BOM_Design_WO_TreeView_Edit.aspx?WONo=" + wono + "&ModId=3&SubModId=26");
    }

}

