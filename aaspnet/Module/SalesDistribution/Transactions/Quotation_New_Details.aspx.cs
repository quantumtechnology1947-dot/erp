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

public partial class Module_SalesDistribution_Transactions_Quotation_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string CustCode = "";
    int enqId = 0;
    string SId = "";
    int CompId = 0;
    int FinYearId = 0;
    SqlConnection con;
    string constr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        constr = fun.Connection();
        con = new SqlConnection(constr);
       try
        {

            SId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            LblEnqNo.Text = Request.QueryString["EnqId"].ToString();
            HfCustId.Text = Request.QueryString["CustomerId"].ToString();
            CustCode = HfCustId.Text;
            HfEnqId.Text = Request.QueryString["EnqId"].ToString();
            enqId = Convert.ToInt32(HfEnqId.Text);
            lblMessage.Text = "";
            TxtDueDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                fun.dropdownUnit(DrpUnit);
                this.FillGrid();
                DataSet ds = new DataSet();
                con.Open();
                string cn = fun.select("CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "'");
                SqlCommand cmd4 = new SqlCommand(cn, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd4);
                da.Fill(ds, "SD_Cust_master");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LblName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                    string strcmd1 = fun.select("CountryName", "tblcountry", "CId='" + ds.Tables[0].Rows[0]["RegdCountry"] + "'");
                    string strcmd2 = fun.select("StateName", "tblState", "SId='" + ds.Tables[0].Rows[0]["RegdState"] + "'");
                    string strcmd3 = fun.select("CityName", "tblCity", "CityId='" + ds.Tables[0].Rows[0]["RegdCity"] + "'");
                    SqlCommand Cmd1 = new SqlCommand(strcmd1, con);
                    SqlCommand Cmd2 = new SqlCommand(strcmd2, con);
                    SqlCommand Cmd3 = new SqlCommand(strcmd3, con);
                    SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
                    SqlDataAdapter DA2 = new SqlDataAdapter(Cmd2);
                    SqlDataAdapter DA3 = new SqlDataAdapter(Cmd3);
                    DataSet ds1 = new DataSet();
                    DataSet ds2 = new DataSet();
                    DataSet ds3 = new DataSet();
                    DA1.Fill(ds1, "tblCountry");
                    DA2.Fill(ds2, "tblState");
                    DA3.Fill(ds3, "tblcity");
                    if (ds1.Tables[0].Rows.Count > 0 && ds2.Tables[0].Rows.Count > 0 && ds3.Tables[0].Rows.Count > 0)
                    {
                        LblAddress.Text = ds.Tables[0].Rows[0]["RegdAddress"].ToString() + ",<br>&nbsp&nbsp" + ds3.Tables[0].Rows[0]["CityName"].ToString() + "," + ds2.Tables[0].Rows[0]["StateName"].ToString() + ",<br>&nbsp&nbsp" + ds1.Tables[0].Rows[0]["CountryName"].ToString() + ".<br>&nbsp&nbsp" + ds.Tables[0].Rows[0]["RegdPinNo"].ToString() + "<br>";
                    }


                    TabContainer1.OnClientActiveTabChanged = "OnChanged";
                    TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
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


    protected void Button6_Click(object sender, EventArgs e)
    {
      try
        {
            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            con.Open();

            string sql = fun.select("QuotationNo", "SD_Cust_Quotation_Master", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by QuotationNo desc");
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            da.Fill(DS, "SD_Cust_Quotation_Master");
            string QuoteNo = "";
            if (DS.Tables[0].Rows.Count > 0)
            {
                int Quotetemp = Convert.ToInt32(DS.Tables[0].Rows[0][0].ToString()) + 1;
                QuoteNo = Quotetemp.ToString("D4");
            }
            else
            {
                QuoteNo = "0001";
            }

            if (TxtPayments.Text != "" && TxtPF.Text != "" && TxtOctroi.Text != "" && TxtWarrenty.Text != "" && TxtInsurance.Text != "" && TxtTransPort.Text != "" && TxtNoteNo.Text != "" && TxtFreight.Text != "" && Txtvalidity.Text != "" && Txtocharges.Text != "" && TxtDelTerms.Text != "" && fun.DateValidation(TxtDueDate.Text) == true && fun.NumberValidationQty(TxtPF.Text) == true && fun.NumberValidationQty(Txtocharges.Text) == true && fun.NumberValidationQty(TxtOctroi.Text) == true && fun.NumberValidationQty(TxtFreight.Text) == true && fun.NumberValidationQty(TxtInsurance.Text) == true)
            {
                string cmdStr = fun.insert("SD_Cust_Quotation_Master", "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,EnqId,QuotationNo,PaymentTerms,PF,VATCST,Excise,Octroi,Warrenty,Insurance,Transport,NoteNo,RegistrationNo,Freight,Remarks,Validity,OtherCharges,DeliveryTerms,PFType,OctroiType,OtherChargesType,FreightType,DueDate", "'" + CDate + "','" + CTime + "','" + SId + "','" + CompId + "','" + FinYearId + "','" + CustCode + "','" + enqId + "','" + QuoteNo + "','" + TxtPayments.Text + "','" + TxtPF.Text + "','" + DrpVat.SelectedValue + "','" + DrpExcise.SelectedValue + "','" + TxtOctroi.Text + "','" + TxtWarrenty.Text + "','" + TxtInsurance.Text + "','" + TxtTransPort.Text + "','" + TxtNoteNo.Text + "','" + TxtRegdNo.Text + "','" + TxtFreight.Text + "','" + TxtRemarks.Text + "','" + Txtvalidity.Text + "','" + Txtocharges.Text + "','" + TxtDelTerms.Text + "','" + DrpPFType.SelectedValue + "','" + DrpOctroiType.SelectedValue + "','" + DrpOChargeType.SelectedValue + "','" + DrpFreightType.SelectedValue + "','"+fun.FromDate(TxtDueDate.Text)+"'");

                SqlCommand cmdQ = new SqlCommand(cmdStr, con);
                cmdQ.ExecuteNonQuery();
                string strp = fun.select("Id", "SD_Cust_Quotation_Master", "CompId='" + CompId + "' order by Id DESC");
                SqlCommand cmdp = new SqlCommand(strp, con);
                SqlDataAdapter dap = new SqlDataAdapter(cmdp);
                DataSet dsp = new DataSet();
                dap.Fill(dsp, "SD_Cust_Quotation_Master");
                if (dsp.Tables[0].Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    string strselect = fun.select("*", "SD_Cust_Quotation_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
                    SqlCommand cmd1 = new SqlCommand(strselect, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    da1.Fill(ds, "SD_Cust_Quotation_Details_Temp");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                        {
                            string strInsert = fun.insert("SD_Cust_Quotation_Details", "SessionId,CompId,FinYearId,MId,ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId.ToString() + "','" + CompId + "','" + FinYearId + "','" + dsp.Tables[0].Rows[0]["Id"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["ItemDesc"].ToString() + "','" + ds.Tables[0].Rows[k]["TotalQty"].ToString() + "','" + ds.Tables[0].Rows[k]["Unit"].ToString() + "','" + Convert.ToDouble(decimal.Parse(ds.Tables[0].Rows[k]["Rate"].ToString()).ToString("N2")) + "','" + Convert.ToDouble(decimal.Parse(ds.Tables[0].Rows[k]["Discount"].ToString()).ToString("N2")) + "'");
                            SqlCommand cmd2 = new SqlCommand(strInsert, con);
                            cmd2.ExecuteNonQuery();
                        }

                    }

                }
                string strDelete = fun.delete("SD_Cust_Quotation_Details_Temp", "SessionId='" + SId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
                SqlCommand cmddelete = new SqlCommand(strDelete, con);
                cmddelete.ExecuteNonQuery();
                string strUpdate = fun.update("SD_Cust_Enquiry_Master", "POStatus=1", "EnqId='" + enqId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
                SqlCommand cmdUpdate = new SqlCommand(strUpdate, con);
                cmdUpdate.ExecuteNonQuery();
                Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63&msg=Quotation is generated.");
            }
        }
        catch (Exception EX)
        {

        }

      finally
        {
            con.Close();


        }

    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        try
        {
            
            if (TxtItemDesc.Text != "" && TxtQty.Text != "" && DrpUnit.SelectedValue != "Select" && TxtRate.Text != "" && TxtDiscount.Text != "" && fun.NumberValidationQty(TxtQty.Text) == true && fun.NumberValidationQty(TxtRate.Text) == true && fun.NumberValidationQty(TxtDiscount.Text) == true)
            {
                double TDiscount = 0;
                TDiscount = Convert.ToDouble(decimal.Parse((TxtDiscount.Text).ToString()).ToString("N2"));

                string cmdStr = fun.insert("SD_Cust_Quotation_Details_Temp", "SessionId,CompId,FinYearId, ItemDesc,TotalQty,Unit,Rate,Discount", "'" + SId + "','" + CompId + "' ,'" + FinYearId + "' ,'" + TxtItemDesc.Text + "','" + Convert.ToDouble(decimal.Parse((TxtQty.Text).ToString()).ToString("N3")) + "','" + DrpUnit.SelectedValue + "','" + Convert.ToDouble(decimal.Parse((TxtRate.Text).ToString()).ToString("N2")) + "','" + TDiscount + "'");
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                con.Open();
                cmd.ExecuteNonQuery();               
                con.Close();
                 this.FillGrid();
                 TxtItemDesc.Text = "";
                 TxtQty.Text = "";
                 DrpUnit.SelectedValue = "Select";
                 TxtRate.Text = "";
                 TxtDiscount.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[1];
        }
    }
    protected void TxtQty_TextChanged(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string GetDynamicContent(string contextKey)
    {
        return default(string);
    }
  
    protected void Button3_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[2];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Quotation_New.aspx?ModId=2&SubModId=63");

    }
   

    public void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
    }
   
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        FillGrid();
        int index = GridView1.EditIndex;
        GridViewRow grv = GridView1.Rows[index];
        string labelLoc = ((Label)grv.FindControl("lblUniit2")).Text;
        ((DropDownList)grv.FindControl("ddlunit")).SelectedValue = labelLoc;

    }

    private void FillGrid()
    {

        DataSet ds = new DataSet();
        try
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT SD_Cust_Quotation_Details_Temp.Id,SD_Cust_Quotation_Details_Temp.Discount,Unit_Master.Symbol,Unit_Master.Id As UnitId,SD_Cust_Quotation_Details_Temp.ItemDesc, SD_Cust_Quotation_Details_Temp.TotalQty,SD_Cust_Quotation_Details_Temp.Rate From SD_Cust_Quotation_Details_Temp INNER JOIN Unit_Master ON SD_Cust_Quotation_Details_Temp.Unit=Unit_Master.Id And SD_Cust_Quotation_Details_Temp.CompId ='" + CompId + "'AND SD_Cust_Quotation_Details_Temp.FinYearId ='" + FinYearId + "' AND SD_Cust_Quotation_Details_Temp.SessionId ='" + SId + "'Order by Id Desc ", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, " SD_Cust_Quotation_Details_Temp");
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
        }
        finally
        {
            con.Close();
        }
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            int index = GridView1.EditIndex;
            GridViewRow row = GridView1.Rows[index];
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string DescItem = ((TextBox)row.FindControl("txtDesc")).Text.ToString().Trim();
            double QtyTot = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtQty")).Text).ToString("N3"));
            double rate = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtRate")).Text).ToString("N3"));
            double Disc = Convert.ToDouble(decimal.Parse(((TextBox)row.FindControl("txtDiscount")).Text).ToString("N3"));
            DropDownList ddl = (DropDownList)row.FindControl("ddlunit");
            string value = ddl.SelectedValue;
            int Symbl = Convert.ToInt32(value);

            if (DescItem.ToString() != "" && QtyTot.ToString() != "" && rate.ToString() != "" && Disc.ToString() != "" && fun.NumberValidationQty(QtyTot.ToString()) == true && fun.NumberValidationQty(rate.ToString()) == true && fun.NumberValidationQty(Disc.ToString()) == true)
            {
                string sql = "UPDATE SD_Cust_Quotation_Details_Temp SET ItemDesc='" + DescItem + "',TotalQty=" + QtyTot + ",Unit=" + Symbl + ",Rate=" + rate+ ",Discount=" + Disc + " WHERE Id=" + id + " And CompId='" + CompId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int temp = cmd.ExecuteNonQuery();
                con.Close();
                if (temp == 1)
                {
                    lblMessage.Text = "Record updated successfully";
                }
                
            }
            GridView1.EditIndex = -1;
            this.FillGrid();
        }

        catch (Exception ch) { }
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int Eid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM SD_Cust_Quotation_Details_Temp WHERE Id=" + Eid + " And CompId='" + CompId + "'", con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record deleted successfully";
            }
            con.Close();
           this.FillGrid();
        }

        catch (Exception ex) { }


    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.EditIndex = -1;
        this.FillGrid();

    }


    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.FillGrid();
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[1].Controls[0];
                del.Attributes.Add("onclick", "return confirmationUpdate();");

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del1 = (LinkButton)e.Row.Cells[2].Controls[0];
                del1.Attributes.Add("onclick", "return confirmationDelete();");
            }
        }
        catch (Exception ex) { }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        Session.Remove("TabIndex");
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string GetDynamicContent2(string contextKey)
    {
        return default(string);
    }
}
