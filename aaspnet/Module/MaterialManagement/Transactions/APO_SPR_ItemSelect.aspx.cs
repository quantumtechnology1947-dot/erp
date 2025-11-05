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

public partial class Module_MaterialManagement_Transactions_APO_SPR_ItemSelect : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sprno = string.Empty;
    string sprid = string.Empty;
    string code = string.Empty;
    string SheduleDate = string.Empty;
    string sId = string.Empty;

    int CompId = 0;
    int itemid = 0;
    int acid = 0;
    int BGWO = 0;
    int FyId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();

        try
        {
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            code = Request.QueryString["Code"].ToString();
            sprno = Request.QueryString["sprno"].ToString();
            sprid = Request.QueryString["sprid"].ToString();
            FyId = Convert.ToInt32(Session["finyear"]);
            txtDelDate.Attributes.Add("readonly", "readonly");

            string Code = fun.select("tblMIS_BudgetCode.Id,( tblMIS_BudgetCode.Symbol+''+tblMM_SPR_DetailsA.WONo) As Bcode,tblMM_SPR_DetailsA.WONo,tblMM_SPR_DetailsA.DeptId", "tblMIS_BudgetCode,tblMM_SPR_DetailsA,tblMM_SPR_MasterA", "tblMM_SPR_DetailsA.Id='" + sprid + "' AND tblMM_SPR_MasterA.SPRNo=tblMM_SPR_DetailsA.SPRNo AND tblMM_SPR_MasterA.Id=tblMM_SPR_DetailsA.MId AND tblMM_SPR_MasterA.CompId='" + CompId + "'");

            SqlCommand CmdCode = new SqlCommand(Code, con);
            SqlDataReader DSCode = CmdCode.ExecuteReader();
            DSCode.Read();

            if (DSCode["WONo"].ToString() != "")
            {
                BGWO = 1;
            }
            else
            {
                DrpBudgetCode.Visible = false;
            }

            if (!IsPostBack)
            {
                string Strspr = fun.select("tblMM_SPR_DetailsA.Discount,tblMM_SPR_MasterA.SPRNo,tblMM_SPR_DetailsA.Id,tblMM_SPR_DetailsA.ItemId,tblMM_SPR_DetailsA.DelDate,tblMM_SPR_DetailsA.AHId,tblMM_SPR_DetailsA.ItemId,tblMM_SPR_DetailsA.Qty,tblMM_SPR_DetailsA.WONo,tblMM_SPR_DetailsA.DeptId,tblMM_SPR_DetailsA.Rate", "tblMM_SPR_MasterA,tblMM_SPR_DetailsA", "tblMM_SPR_DetailsA.Id='" + sprid + "' AND tblMM_SPR_MasterA.SPRNo=tblMM_SPR_DetailsA.SPRNo AND tblMM_SPR_MasterA.Id=tblMM_SPR_DetailsA.MId AND tblMM_SPR_MasterA.CompId='" + CompId + "'");

                SqlCommand cmdspr = new SqlCommand(Strspr, con);
                SqlDataReader DSspr = cmdspr.ExecuteReader();
                DSspr.Read();

                if (DSspr["WONo"].ToString() != "")
                {
                    lblwono.Text = DSspr["WONo"].ToString();

                    string Code1 = fun.select("Distinct(tblMIS_BudgetCode.Id),( tblMIS_BudgetCode.Symbol+''+tblMM_SPR_DetailsA.WONo) As Bcode", "tblMIS_BudgetCode,tblMM_SPR_DetailsA,tblMM_SPR_MasterA", "tblMM_SPR_DetailsA.Id='" + sprid + "' AND tblMM_SPR_MasterA.SPRNo=tblMM_SPR_DetailsA.SPRNo AND tblMM_SPR_MasterA.Id=tblMM_SPR_DetailsA.MId AND tblMM_SPR_MasterA.CompId='" + CompId + "'");
                    SqlCommand CmdCode1 = new SqlCommand(Code1, con);
                    SqlDataAdapter daCode1 = new SqlDataAdapter(CmdCode1);
                    DataSet DSCode1 = new DataSet();
                    daCode1.Fill(DSCode1);
                    //SqlDataReader DSCode1 = CmdCode1.ExecuteReader();
                    //DSCode1.Read();
                    DrpBudgetCode.DataSource = DSCode1;
                    DrpBudgetCode.DataTextField = "Bcode";
                    DrpBudgetCode.DataValueField = "Id";
                    DrpBudgetCode.DataBind();
                }
                else
                {
                    DrpBudgetCode.Visible = false;
                    lblwono.Text = "NA";
                }

                txtDelDate.Text = fun.FromDateDMY(DSspr["DelDate"].ToString());
                //For Department Name
                int deptId = Convert.ToInt32(DSspr["DeptId"].ToString());
                string DeptName = "";

                if (deptId > 0)
                {
                    string sqlDeptName = fun.select("'['+Symbol+'] '+Name AS Dept,Symbol", "BusinessGroup", "Id ='" + Convert.ToInt32(DSspr["DeptId"].ToString()) + "' ");
                    SqlCommand cmdDeptName = new SqlCommand(sqlDeptName, con);
                    SqlDataReader DSDeptName = cmdDeptName.ExecuteReader();
                    DSDeptName.Read();

                    DeptName = DSDeptName["Dept"].ToString();
                    BGWO = 2;
                    LblBudgetCode.Text = DSDeptName["Symbol"].ToString();
                }
                else
                {
                    DeptName = "NA";

                }
                lblDept.Text = DeptName;
                itemid = Convert.ToInt32(DSspr["ItemId"].ToString());
                acid = Convert.ToInt32(DSspr["AHId"].ToString());
                lblSprno.Text = DSspr["ItemId"].ToString();

                // for Item ID  from SprDetails table
                string sqlIid = fun.select("ItemCode,ManfDesc,UOMBasic,CId,AHId", "tblDG_Item_Master", "CompId='" + CompId + "' AND Id='" + DSspr["ItemId"].ToString() + "'");
                SqlCommand cmdIid = new SqlCommand(sqlIid, con);
                SqlDataReader DSIid = cmdIid.ExecuteReader();
                DSIid.Read();

                if (DSIid.HasRows == true)
                {
                    // for  Item Code and Item Description
                    lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DSspr["ItemId"].ToString()));
                    lblItemDesc.Text = DSIid[1].ToString();

                    // for UOM Purchase  from Unit Master table
                    string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIid[2].ToString() + "'");
                    SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                    SqlDataReader DSPurch = cmdPurch.ExecuteReader();
                    DSPurch.Read();

                    lblUnit.Text = DSPurch[0].ToString();
                }

                // for Item Qty
                // lblQty.Text = decimal.Parse(DSspr.Tables[0].Rows[0]["Qty"].ToString()).ToString("N3");

                double RemTempQty = 0;
                string CheckSql = fun.select("Sum(Qty) As TempQty", "tblMM_SPR_PO_TempA", "SPRNo='" + DSspr["SPRNo"].ToString() + "' AND SPRId='" + DSspr["Id"].ToString() + "'");
                SqlCommand cmdCheck = new SqlCommand(CheckSql, con);
                SqlDataReader DSCheck = cmdCheck.ExecuteReader();
                DSCheck.Read();

                if (DSCheck.HasRows == true && DSCheck[0] != DBNull.Value)
                {
                    RemTempQty = Convert.ToDouble(DSCheck[0].ToString());
                }

                double SPRQty = 0;
                SPRQty = Convert.ToDouble(DSspr["Qty"].ToString());
                double PoQty = 0;

                string sql4 = fun.select("Sum(tblMM_PO_DetailsA.Qty)As TotPoQty", "tblMM_PO_MasterA,tblMM_PO_DetailsA", " tblMM_PO_DetailsA.SPRId='" + DSspr["Id"].ToString() + "' AND tblMM_PO_MasterA.CompId='" + CompId + "' AND tblMM_PO_MasterA.Id=tblMM_PO_DetailsA.MId ");

                SqlCommand cmd4 = new SqlCommand(sql4, con);
                SqlDataReader DS4 = cmd4.ExecuteReader();
                DS4.Read();

                if (DS4.HasRows == true && DS4[0] != DBNull.Value)
                {
                    PoQty = Convert.ToDouble(DS4[0]);
                }

                double RemQty = 0;
                RemQty = Math.Round((SPRQty - PoQty), 5);
                txtQty.Text = Math.Round((RemQty - RemTempQty), 5).ToString();
                lblQty.Text = decimal.Parse(DSspr["Qty"].ToString()).ToString("N3");
                // for Item rate               
                txtRate.Text = Math.Round(Convert.ToDouble(DSspr["Rate"]), 5).ToString();
                txtDiscount.Text = decimal.Parse(DSspr["Discount"].ToString()).ToString("N2");
                // For A/c Head
                string sql3 = fun.select("'['+AccHead.Symbol+']'+Description AS Head", "AccHead", "Id ='" + Convert.ToInt32(DSspr["AHId"].ToString()) + "'");

                SqlCommand cmd3 = new SqlCommand(sql3, con);
                SqlDataReader DS3 = cmd3.ExecuteReader();
                DS3.Read();

                lblAcHead.Text = DS3["Head"].ToString();
                // For SPRNo
                lblSprno.Text = DSspr["SPRNo"].ToString();

                rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemid + "&CompId=" + CompId + "";
                rt.Target = "_blank";
            }
        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("APO_SPR_ItemGrid.aspx?Code=" + code + "");
    }
    protected void btnProcide_Click(object sender, EventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();

        try
        {
            SheduleDate = fun.FromDate(txtDelDate.Text);
            double Rate = 0;
            int BCode = 0;


            LblDate.Text = (fun.getCurrDate());
            if (BGWO == 1)
            {
                BCode = Convert.ToInt32(DrpBudgetCode.SelectedValue);
            }


            Rate = Convert.ToDouble(decimal.Parse((Convert.ToDouble(txtRate.Text) - ((Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtDiscount.Text)) / 100)).ToString()).ToString("N2"));

            string sqlrt2 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemid + "' And CompId='" + CompId + "' ");
            SqlCommand cmdrt2 = new SqlCommand(sqlrt2, con);
            SqlDataReader DSrt2 = cmdrt2.ExecuteReader();
            DSrt2.Read();

            double rate = 0;

            if (DSrt2.HasRows == true && DSrt2["DisRate"] != DBNull.Value)
            {
                rate = Convert.ToDouble(decimal.Parse(DSrt2["DisRate"].ToString()).ToString("N2"));
            }
            if (txtQty.Text != "" && fun.NumberValidation(txtQty.Text) == true)
            {
                if (txtDelDate.Text != "" && fun.DateValidation(txtDelDate.Text) == true && Convert.ToDateTime(fun.FromDate(txtDelDate.Text)) >= Convert.ToDateTime(fun.FromDate(LblDate.Text)))
                {
                    if (Rate > 0)
                    {
                        if (rate > 0)
                        {
                            double x = 0;
                            x = Convert.ToDouble(decimal.Parse((rate - Rate).ToString()).ToString("N2"));

                            if (x >= 0)
                            {
                                string StrsprPo = fun.insert("tblMM_SPR_PO_TempA", "CompId,SessionId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + sprid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + (Convert.ToDouble(txtRate.Text)) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + SheduleDate + "','" + BCode + "'");

                                SqlCommand cmdsprPo = new SqlCommand(StrsprPo, con);
                                cmdsprPo.ExecuteNonQuery();

                                Response.Redirect("APO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
                            }
                            else
                            {
                                string sqlrate = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemid + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='2'");

                                SqlCommand cmdrate = new SqlCommand(sqlrate, con);
                                SqlDataReader dsrate = cmdrate.ExecuteReader();
                                dsrate.Read();

                                if (dsrate.HasRows == true)
                                {
                                    string StrsprPo = fun.insert("tblMM_SPR_PO_TempA", "CompId,SessionId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + sprid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + (Convert.ToDouble(txtRate.Text)) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + SheduleDate + "','" + BCode + "'");

                                    SqlCommand cmdsprPo = new SqlCommand(StrsprPo, con);
                                    cmdsprPo.ExecuteNonQuery();

                                    Response.Redirect("APO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
                                }
                                else
                                {
                                    string mystring = string.Empty;
                                    mystring = "Entered rate is not acceptable!";
                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                                }
                            }
                        }
                        else
                        {
                            string StrsprPo = fun.insert("tblMM_SPR_PO_TempA", "CompId,SessionId,SPRNo,SPRId,Qty,Rate,Discount,AddDesc,PF,VAT,ExST,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + sprid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + (Convert.ToDouble(txtRate.Text)) + "','" + Convert.ToDouble(txtDiscount.Text) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLVat.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + SheduleDate + "','" + BCode + "'");

                            SqlCommand cmdsprPo = new SqlCommand(StrsprPo, con);
                            cmdsprPo.ExecuteNonQuery();

                            Response.Redirect("APO_SPR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");

                        }
                    }
                    else
                    {
                        string mystring = string.Empty;
                        mystring = "Entered rate is not acceptable!";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                    }
                }
                else
                {

                    string mystring = string.Empty;
                    mystring = "Entered Date is not acceptable!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);

                }
            }
            else
            {
                string mystring = string.Empty;
                mystring = "Entered Qty is not acceptable!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }
    }


}
