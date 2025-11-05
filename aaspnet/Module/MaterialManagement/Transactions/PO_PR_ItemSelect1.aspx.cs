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

public partial class Module_MaterialManagement_Transactions_PO_PR_ItemSelect : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = "";
    int CompId = 0;
    string prno = "";
    string prid = "";
    string wono = "";
    string code = "";
    int itemid = 0;
    int acid = 0;
    int FyId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();


        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Convert.ToInt32(Session["finyear"]);
            sId = Session["username"].ToString();
            code = Request.QueryString["Code"].ToString();
            prno = Request.QueryString["prno"].ToString();
            prid = Request.QueryString["prid"].ToString();
            wono = Request.QueryString["wono"].ToString();
            lblwono.Text = wono;
            txtDelDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                string Strspr = fun.select("tblMM_PR_Master.PRNo,tblMM_PR_Master.WONo,tblMM_PR_Details.Id,tblMM_PR_Details.AHId,tblMM_PR_Details.ItemId,tblMM_PR_Details.Qty,tblMM_PR_Details.Rate,tblMM_PR_Details.DelDate", "tblMM_PR_Master,tblMM_PR_Details", "tblMM_PR_Details.Id='" + prid + "' AND tblMM_PR_Master.PRNo=tblMM_PR_Details.PRNo  AND tblMM_PR_Master.CompId='" + CompId + "'");

                SqlCommand cmdspr = new SqlCommand(Strspr, con);
                SqlDataReader DSspr = cmdspr.ExecuteReader();
                DSspr.Read();                
                
                if (DSspr.HasRows == true)
                {
                    string Code1 = fun.select("Distinct(tblMIS_BudgetCode.Id),Symbol,( ( tblMIS_BudgetCode.Symbol+''+tblMM_PR_Master.WONo)) As Bcode", "tblMIS_BudgetCode,tblMM_PR_Master", "  tblMM_PR_Master.WONo='" + wono + "'  AND tblMM_PR_Master.CompId='" + CompId + "'");
                    SqlCommand CmdCode1 = new SqlCommand(Code1, con);
                    SqlDataAdapter daCode = new SqlDataAdapter(CmdCode1);
                    DataSet DSCode1 = new DataSet();
                    daCode.Fill(DSCode1);
                    //SqlDataReader DSCode1 = CmdCode1.ExecuteReader();
                    //DSCode1.Read();
                   
                    DrpBudgetCode.DataSource = DSCode1;
                    DrpBudgetCode.DataTextField = "Bcode";
                    DrpBudgetCode.DataValueField = "Id";
                    //DrpBudgetCode.Dispose();
                    DrpBudgetCode.DataBind();

                    itemid = Convert.ToInt32(DSspr["ItemId"].ToString());

                    LblItemId.Text = DSspr["ItemId"].ToString();
                    acid = Convert.ToInt32(DSspr["AHId"].ToString());                    
                    
                    // for Item ID  from SprDetails table
                    string sqlIid = fun.select("ItemCode,ManfDesc,UOMBasic", "tblDG_Item_Master", "Id='" + DSspr["ItemId"].ToString() + "' AND CompId='" + CompId + "'  ");
                    SqlCommand cmdIid = new SqlCommand(sqlIid, con);
                    SqlDataReader DSIid = cmdIid.ExecuteReader();
                    DSIid.Read();
                    
                    // for  Item Code and Item Description
                    if (DSIid.HasRows == true)
                    {
                        lblItemCode.Text = fun.GetItemCode_PartNo(CompId, Convert.ToInt32(DSspr["ItemId"].ToString()));
                        lblItemDesc.Text = DSIid[1].ToString();
                        
                        //For UOM Purchase  from Unit Master table
                        string sqlPurch = fun.select("Symbol", "Unit_Master", "Id='" + DSIid[2].ToString() + "'");
                        SqlCommand cmdPurch = new SqlCommand(sqlPurch, con);
                        SqlDataReader DSPurch = cmdPurch.ExecuteReader();
                        DSPurch.Read();

                        if (DSPurch.HasRows == true)
                        {
                            lblUnit.Text = DSPurch[0].ToString();
                        }
                    }

                    double RemTempQty = 0;
                    string CheckSql = fun.select("Sum(Qty) As TempQty", "tblMM_PR_PO_Temp", "PRNo='" + DSspr["PRNo"].ToString() + "' AND PRId='" + DSspr["Id"].ToString() + "'");
                    SqlCommand cmdCheck = new SqlCommand(CheckSql, con);
                    SqlDataReader DSCheck = cmdCheck.ExecuteReader();
                    DSCheck.Read();
                   
                    if (DSCheck.HasRows == true && DSCheck[0] != DBNull.Value)
                    {
                        RemTempQty = Convert.ToDouble(DSCheck[0].ToString());
                    }

                    double PRQty = 0;
                    PRQty = Convert.ToDouble(DSspr["Qty"].ToString());
                    
                    double PoQty = 0;
                    
                    string sql4 = fun.select("Sum(tblMM_PO_Details.Qty)As TotPoQty", "tblMM_PO_Master,tblMM_PO_Details", " tblMM_PO_Details.PRId='" + DSspr["Id"].ToString() + "' AND tblMM_PO_Master.CompId='" + CompId + "'  AND tblMM_PO_Master.Id=tblMM_PO_Details.MId");
                    SqlCommand cmd4 = new SqlCommand(sql4, con);
                    SqlDataReader DS4 = cmd4.ExecuteReader();
                    DS4.Read();

                    if (DS4.HasRows == true && DS4[0] != DBNull.Value)
                    {
                        PoQty = Convert.ToDouble(DS4[0].ToString());
                    }

                    double RemQty = 0;
                    RemQty = Math.Round((PRQty - PoQty), 5);
                    txtQty.Text = Math.Round((RemQty - RemTempQty), 5).ToString();                   
                    lblprQty.Text = decimal.Parse(DSspr["Qty"].ToString()).ToString("N3");
                    txtRate.Text = Math.Round(Convert.ToDouble(DSspr["Rate"]), 5).ToString(); 
                    
                    // For A/c Head
                    string sql3 = fun.select("'['+Symbol+']'+Description AS Head", "AccHead", "Id ='" + Convert.ToInt32(DSspr["AHId"].ToString()) + "' ");
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    SqlDataReader DS3 = cmd3.ExecuteReader();
                    DS3.Read();

                    lblAcHead.Text = DS3["Head"].ToString();
                    // For PRNo
                    lblSprno.Text = DSspr["PRNo"].ToString();
                    txtDelDate.Text = fun.FromDateDMY(DSspr["DelDate"].ToString());
                }
            }
            
            rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemid + "&CompId=" + CompId + "";
            rt.Target = "_blank";

        }
        catch (Exception ex) { }
        finally
        {
            con.Close();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
    }

    protected void btnProcide_Click(object sender, EventArgs e)
    {
        string str = fun.Connection();
        SqlConnection con = new SqlConnection(str);
        con.Open();

        try
        {   double Rate = 0;
            double rate = 0;
            string SheduleDate = "";
         
            LblDate.Text = (fun.getCurrDate());

            Rate = Convert.ToDouble(decimal.Parse((Convert.ToDouble(txtRate.Text) - ((Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtDiscount.Text)) / 100)).ToString()).ToString("N2"));

            string sqlrt2 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + LblItemId.Text + "' And CompId='" + CompId + "' ");
            SqlCommand cmdrt2 = new SqlCommand(sqlrt2, con);
            SqlDataReader DSrt2 = cmdrt2.ExecuteReader();
            DSrt2.Read();

            if (DSrt2.HasRows == true && DSrt2["DisRate"] != DBNull.Value)
            {
                rate = Convert.ToDouble(decimal.Parse(DSrt2["DisRate"].ToString()).ToString("N2"));
            }            
         
            if (txtQty.Text != "" && fun.NumberValidation(txtQty.Text) == true && txtQty.Text !="0")
            {
                if (txtDelDate.Text != "" && fun.DateValidation(txtDelDate.Text) == true && fun.NumberValidationQty(txtDiscount.Text) == true && Convert.ToDateTime(fun.FromDate(txtDelDate.Text)) >= Convert.ToDateTime(fun.FromDate(LblDate.Text)) && txtQty.Text != "" && fun.NumberValidation(txtQty.Text) == true)
                {

                    SheduleDate = fun.FromDate(txtDelDate.Text);
                    if (Rate > 0)
                    {                       
                        if (rate > 0)
                        {  
                            double x = 0;
                            x = Convert.ToDouble(decimal.Parse((rate - Rate).ToString()).ToString("N2"));

                            if (x >= 0)
                            {
                                
                                string StrsprPo = fun.insert("tblMM_PR_PO_Temp", "CompId,SessionId,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + prid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + DDLVat.SelectedValue + "','" + SheduleDate + "','" + Convert.ToInt32(DrpBudgetCode.SelectedValue) + "'");
                                SqlCommand cmdsprPo = new SqlCommand(StrsprPo, con);
                                cmdsprPo.ExecuteNonQuery();
                                
                                Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
                            }
                            else
                            {
                                string sqlrate = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + LblItemId.Text + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='2'");

                                SqlCommand cmdrate = new SqlCommand(sqlrate, con);
                                SqlDataReader dsrate = cmdrate.ExecuteReader();
                                dsrate.Read();

                                if (dsrate.HasRows == true)
                                {                                    
                                    string StrsprPo = fun.insert("tblMM_PR_PO_Temp", "CompId,SessionId,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + prid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + DDLVat.SelectedValue + "','" + SheduleDate + "','" + Convert.ToInt32(DrpBudgetCode.SelectedValue) + "'");

                                    SqlCommand cmdsprPo = new SqlCommand(StrsprPo, con);
                                    cmdsprPo.ExecuteNonQuery();

                                    Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
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
                            
                            string StrsprPo = fun.insert("tblMM_PR_PO_Temp", "CompId,SessionId,PRNo,PRId,Qty,Rate,Discount,AddDesc,PF,ExST,VAT,DelDate,BudgetCode", "'" + CompId + "','" + sId + "','" + lblSprno.Text + "','" + prid + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2")) + "','" + txtAddDesc.Text + "','" + DDLPF.SelectedValue + "','" + DDLExcies.SelectedValue + "','" + DDLVat.SelectedValue + "','" + SheduleDate + "','" + Convert.ToInt32(DrpBudgetCode.SelectedValue) + "'");

                            SqlCommand cmdsprPo = new SqlCommand(StrsprPo, con);
                            cmdsprPo.ExecuteNonQuery();

                            Response.Redirect("PO_PR_ItemGrid.aspx?Code=" + code + "&ModId=6&SubModId=35");
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
