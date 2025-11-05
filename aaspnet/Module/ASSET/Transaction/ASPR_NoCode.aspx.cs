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

public partial class Module_MaterialManagement_Transactions_ASPR_NoCode : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    int itemId = 0;
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string id = Request.QueryString["Id"];
            itemId = Convert.ToInt32(id);
            string connStr = fun.Connection();
            SqlConnection con = new SqlConnection(connStr);
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            con.Open();
            textDelDate.Attributes.Add("readonly", "readonly");
            if (!IsPostBack)
            {
                this.AcHead();
                string sqlfg = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + itemId + "' And CompId='" + CompId + "'");
                SqlCommand cmdfg = new SqlCommand(sqlfg, con);
                SqlDataAdapter dafg = new SqlDataAdapter(cmdfg);
                DataSet DSfg = new DataSet();
                dafg.Fill(DSfg);
                double Rate = 0;
                if (DSfg.Tables[0].Rows.Count > 0 && DSfg.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                {
                    Rate = Convert.ToDouble(decimal.Parse(DSfg.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
                    txtRate.Text = DSfg.Tables[0].Rows[0]["Rate"].ToString();
                    txtDiscount.Text = DSfg.Tables[0].Rows[0]["Discount"].ToString();
                }

                else
                {
                    string sqlrt = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "'  order by DisRate Asc ");
                    SqlCommand cmdrt = new SqlCommand(sqlrt, con);
                    SqlDataAdapter dart = new SqlDataAdapter(cmdrt);
                    DataSet DSrt = new DataSet();
                    dart.Fill(DSrt);

                    if (DSrt.Tables[0].Rows.Count > 0 && DSrt.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                    {
                        Rate = Convert.ToDouble(decimal.Parse(DSrt.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
                        txtRate.Text = DSrt.Tables[0].Rows[0]["Rate"].ToString();
                        txtDiscount.Text = DSrt.Tables[0].Rows[0]["Discount"].ToString();
                    }
                }

            }

            rt.HRef = "~/Module/MaterialManagement/Reports/RateRegisterSingleItemPrint.aspx?ItemId=" + itemId + "&CompId=" + CompId + "";
            rt.Target = "_blank";

            if (rddept.Checked == true)
            {
                txtwono.Text = "";
            }

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            string cmdId = fun.select("tblDG_Item_Master.Id,tblDG_Item_Master.AHId,tblDG_Item_Master.CId,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic, tblDG_Item_Master.ItemCode ", "tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic AND tblDG_Item_Master.Id='" + itemId + "' AND tblDG_Item_Master.CompId='" + CompId + "'");

            SqlCommand cmdItemId = new SqlCommand(cmdId, con);
            SqlDataAdapter DAItemId = new SqlDataAdapter(cmdItemId);
            DataSet DSItemId = new DataSet();
            DAItemId.Fill(DSItemId);
            if (DSItemId.Tables[0].Rows.Count > 0)
            {
                lbltIemCode.Text = DSItemId.Tables[0].Rows[0]["ItemCode"].ToString();
                lblUOMBasic.Text = DSItemId.Tables[0].Rows[0]["UOMBasic"].ToString();
                lblManfDescription.Text = DSItemId.Tables[0].Rows[0]["ManfDesc"].ToString();
                if (DSItemId.Tables[0].Rows[0]["CId"] != DBNull.Value)
                {
                    lblAHId.Visible = true;
                    RbtnLabour.Visible = false;
                    RbtnWithMaterial.Visible = false;
                    DropDownList1.Visible = false;

                    string cmdStrAH = fun.select("Category,'['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Id='" + Convert.ToInt32(DSItemId.Tables[0].Rows[0]["AHId"]) + "'");
                    SqlCommand cmdAH = new SqlCommand(cmdStrAH, con);
                    SqlDataAdapter DAAH = new SqlDataAdapter(cmdAH);
                    DataSet DSAH = new DataSet();
                    DAAH.Fill(DSAH, "AccHead");
                    if (DSAH.Tables[0].Rows.Count > 0)
                    {
                        lblAHId.Text = DSAH.Tables[0].Rows[0]["Category"].ToString() + " - " + DSAH.Tables[0].Rows[0]["Head"].ToString();

                    }
                }
                else
                {
                    lblAHId.Visible = false;
                    RbtnLabour.Visible = true;
                    RbtnWithMaterial.Visible = true;
                    DropDownList1.Visible = true;
                }
            }

        }
        catch (Exception ex) { }

    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ASPR_New.aspx?ModId=6&SubModId=31");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            string sId = Session["username"].ToString();
            int CompId = Convert.ToInt32(Session["compid"]);
            int FinYearId = Convert.ToInt32(Session["finyear"]);
            string CustCode = fun.getCode(txtNewCustomerName.Text);
            con.Open();

            int AHId = 0;
            string cmdCId = fun.select("AHId,CId", "tblDG_Item_Master", "tblDG_Item_Master.Id='" + itemId + "' AND CompId='" + CompId + "'");
            SqlCommand cmdCId1 = new SqlCommand(cmdCId, con);
            SqlDataAdapter DACId1 = new SqlDataAdapter(cmdCId1);
            DataSet DSCId1 = new DataSet();
            DACId1.Fill(DSCId1);
            if (DSCId1.Tables[0].Rows.Count > 0)
            {
                if (DSCId1.Tables[0].Rows[0]["CId"] != DBNull.Value)
                {
                    AHId = Convert.ToInt32(DSCId1.Tables[0].Rows[0]["AHId"]);
                }
                else
                {
                    AHId = Convert.ToInt32(DropDownList1.SelectedValue);
                }
            }

            string OnWoNo = "";
            string OnDept = "";
            int u = 0;

            if (rdwono.Checked == true && txtwono.Text != "")
            {
                if (fun.CheckValidWONo(txtwono.Text, CompId, FinYearId) == true)
                {
                    OnWoNo = txtwono.Text;
                    u = 1;
                }
            }

            if (rddept.Checked == true)
            {
                OnDept = drpdept.SelectedValue.ToString();
                u = 1;
            }


            int CheckItemId = fun.chkItemId(itemId);
            double Rate = 0;
            double DiscRate = 0;
            double Discount = 0;
            Rate = Convert.ToDouble(decimal.Parse(txtRate.Text).ToString("N2"));
            Discount = Convert.ToDouble(decimal.Parse(txtDiscount.Text).ToString("N2"));
            DiscRate = Convert.ToDouble(decimal.Parse((Rate - (Rate * Discount / 100)).ToString()).ToString("N2"));

            double rate = 0;

            string sqlfg = fun.select("Rate,Discount,(Rate-(Rate*Discount/100)) as DisRate,Id,Flag", "tblMM_Rate_Register", "Flag=1  And ItemId='" + itemId + "' And CompId='" + CompId + "'   ");
            SqlCommand cmdfg = new SqlCommand(sqlfg, con);
            SqlDataAdapter dafg = new SqlDataAdapter(cmdfg);
            DataSet DSfg = new DataSet();
            dafg.Fill(DSfg);
            if (DSfg.Tables[0].Rows.Count > 0 && DSfg.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
            {
                rate = Convert.ToDouble(decimal.Parse(DSfg.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
            }
            else
            {
                string sqlrt2 = fun.select("min(Rate-(Rate*Discount/100)) as DisRate", "tblMM_Rate_Register", "ItemId='" + itemId + "' And CompId='" + CompId + "' ");
                SqlCommand cmdrt2 = new SqlCommand(sqlrt2, con);
                SqlDataAdapter dart2 = new SqlDataAdapter(cmdrt2);
                DataSet DSrt2 = new DataSet();
                dart2.Fill(DSrt2);

                if (DSrt2.Tables[0].Rows.Count > 0 && DSrt2.Tables[0].Rows[0]["DisRate"] != DBNull.Value)
                {
                    rate = Convert.ToDouble(decimal.Parse(DSrt2.Tables[0].Rows[0]["DisRate"].ToString()).ToString("N2"));
                }
            }
            if (u == 1)
            {
                if (DiscRate > 0)
                {
                    if (rate > 0)
                    {
                        double x = 0;
                        x = Convert.ToDouble(decimal.Parse((rate - DiscRate).ToString()).ToString("N2"));
                        if (x >= 0)
                        {

                            int CheckSqupId = fun.chkSupplierCode(CustCode);

                            if (CheckSqupId == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) == true && fun.NumberValidationQty(txtQty.Text) == true && fun.NumberValidationQty(txtDiscount.Text) == true && fun.NumberValidationQty(Rate.ToString()) == true)
                            {
                                string StrAdd = fun.insert("tblMM_SPR_TempA", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,SupplierId,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + itemId + "','" + CustCode + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Rate + "','" + AHId + "','" + OnWoNo + "','" + OnDept + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + Discount + "'");
                                SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
                                cmdAdd.ExecuteNonQuery();
                                Response.Redirect("ASPR_New.aspx?ModId=6&SubModId=31");

                            }

                        }
                        else
                        {
                            string sqlrate = fun.select("LockUnlock,Type,ItemId", "tblMM_RateLockUnLock_Master", "ItemId='" + itemId + "' And CompId='" + CompId + "' And LockUnlock='1'  And Type='1'");

                            SqlCommand cmdrate = new SqlCommand(sqlrate, con);
                            SqlDataAdapter darate = new SqlDataAdapter(cmdrate);
                            DataSet dsrate = new DataSet();
                            darate.Fill(dsrate);

                            if (dsrate.Tables[0].Rows.Count > 0)
                            {
                                //if (CheckItemId == 0)
                                {
                                    int CheckSqupId = fun.chkSupplierCode(CustCode);

                                    if (CheckSqupId == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) == true && fun.NumberValidationQty(txtQty.Text) == true && fun.NumberValidationQty(Rate.ToString()) == true)
                                    {

                                        string StrAdd = fun.insert("tblMM_SPR_TempA", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,SupplierId,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + itemId + "','" + CustCode + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Rate + "','" + AHId + "','" + OnWoNo + "','" + OnDept + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + Discount + "'");
                                        SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
                                        cmdAdd.ExecuteNonQuery();
                                        Response.Redirect("ASPR_New.aspx?ModId=6&SubModId=31");

                                    }
                                }

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
                        // if (CheckItemId == 0)
                        {
                            int CheckSqupId = fun.chkSupplierCode(CustCode);

                            if (CheckSqupId == 1 && textDelDate.Text != "" && fun.DateValidation(textDelDate.Text) == true && fun.NumberValidationQty(txtQty.Text) == true && fun.NumberValidationQty(Rate.ToString()) == true)
                            {

                                string StrAdd = fun.insert("tblMM_SPR_TempA", "SysDate,SysTime,CompId,FinYearId,SessionId,ItemId,SupplierId,Qty,Rate,AHId,WONo,DeptId,Remarks,DelDate,Discount", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + itemId + "','" + CustCode + "','" + Convert.ToDouble(decimal.Parse(txtQty.Text).ToString("N3")) + "','" + Rate + "','" + AHId + "','" + OnWoNo + "','" + OnDept + "','" + txtRemark.Text + "','" + fun.FromDate(textDelDate.Text) + "','" + Discount + "'");


                                SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
                                cmdAdd.ExecuteNonQuery();
                                Response.Redirect("ASPR_New.aspx?ModId=6&SubModId=31");

                            }
                        }

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
                mystring = "WONo or Dept is not found!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }

            con.Close();
        }
        catch (Exception ex) { }


    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] sql(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        int CompId1 = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        con.Open();
        string cmdStr = fun.select("SupplierId,SupplierName", "tblMM_Supplier_masterA", "CompId='" + CompId1 + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblMM_Supplier_masterA");
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

    protected void txtEditCustomerName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void RbtnLabour_CheckedChanged(object sender, EventArgs e)
    {
        this.AcHead();

    }
    protected void RbtnWithMaterial_CheckedChanged(object sender, EventArgs e)
    {
        this.AcHead();
    }

    public void AcHead()
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {
            string x = "";
            if (RbtnLabour.Checked == true)
            {
                x = "Labour";
            }

            if (RbtnWithMaterial.Checked == true)
            {
                x = "With Material";
            }

            string cmdStrLabour = fun.select(" '['+Symbol+'] '+Description AS Head,Id ", " AccHead ", "Category='" + x + "'");
            SqlCommand cmdLabour = new SqlCommand(cmdStrLabour, con);
            SqlDataAdapter DALabour = new SqlDataAdapter(cmdLabour);
            DataSet DSLabour = new DataSet();
            DALabour.Fill(DSLabour, "AccHead");

            DropDownList1.DataSource = DSLabour;
            DropDownList1.DataTextField = "Head";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();
        }
        catch (Exception ex) { }
    }
}
