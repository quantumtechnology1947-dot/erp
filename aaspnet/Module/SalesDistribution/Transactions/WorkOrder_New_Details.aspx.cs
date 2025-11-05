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

public partial class Module_SalesDistribution_Transactions_WorkOrder_New_Details : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string CustCode = "";
    string pono = "";
    int enqId = 0;
    int CompId = 0;
    string sId = "";
    string PoId = "";
    int FinYearId = 0;
    SqlConnection con;
    string connStr = "";
    public void Page_Load(object sender, EventArgs e)
    {
        try
        {
            hfCustId.Text = Request.QueryString["CustomerId"].ToString();
            CustCode = hfCustId.Text;
            hfPoNo.Text = Request.QueryString["PONo"].ToString();
            lblPONo.Text = Request.QueryString["PONo"].ToString();
            PoId = Request.QueryString["PoId"].ToString();
            pono = hfPoNo.Text;
            hfEnqId.Text = Request.QueryString["EnqId"].ToString();
            enqId = Convert.ToInt32(hfEnqId.Text);
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            sId = Session["username"].ToString();
            CompId = Convert.ToInt32(Session["compid"]);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            lblMessage.Text = "";

            // For Date 

            txtWorkOrderDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetDAP_FDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetDAP_TDate.Attributes.Add("readonly", "readonly");
            txtTaskDesignFinalization_FDate.Attributes.Add("readonly", "readonly");
            txtTaskDesignFinalization_TDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetManufg_FDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetManufg_TDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetTryOut_FDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetTryOut_TDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetDespach_FDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetDespach_TDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetAssembly_FDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetAssembly_TDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetInstalation_FDate.Attributes.Add("readonly", "readonly");
            txtTaskTargetInstalation_TDate.Attributes.Add("readonly", "readonly");
            txtTaskCustInspection_FDate.Attributes.Add("readonly", "readonly");
            txtTaskCustInspection_TDate.Attributes.Add("readonly", "readonly");
            txtManufMaterialDate.Attributes.Add("readonly", "readonly");
            txtBoughtoutMaterialDate.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                fun.dropdownBuyer(DDLBuyer);

                fun.dropdownBG(DDLBusinessGroup);
                fun.dropdownCountry(DDLShippingCountry, DDLShippingState);

                con.Open();
                string StrCat = fun.select("CId,Symbol+' - '+CName as Category", "tblSD_WO_Category", "CompId='" + CompId + "'");
                SqlCommand Cmd = new SqlCommand(StrCat, con);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DA.Fill(DS, "tblSD_WO_Category");
                DDLTaskWOType.DataSource = DS.Tables["tblSD_WO_Category"];
                DDLTaskWOType.DataTextField = "Category";
                DDLTaskWOType.DataValueField = "CId";
                DDLTaskWOType.DataBind();
                DDLTaskWOType.Items.Insert(0, "Select");
                DDLSubcategory.Items.Insert(0, "Select");

                DataSet ds = new DataSet();
                string cn = fun.select("CustomerName", "SD_Cust_master", "CustomerId='" + CustCode + "' And CompId='" + CompId + "' ");
                SqlCommand cmd4 = new SqlCommand(cn, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd4);
                da.Fill(ds, "SD_Cust_master");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCustomerName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                }

                con.Close();

            }



            TabContainer1.OnClientActiveTabChanged = "OnChanged";
            TabContainer1.ActiveTabIndex = Convert.ToInt32(Session["TabIndex"] ?? "0");
        }

        catch (Exception ex) { }
    }



    public void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //TabContainer1.ActiveTabIndex = 2;
    }


    protected void DDLShippingCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDLShippingState, DDLShippingCity, DDLShippingCountry);
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void DDLShippingState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDLShippingCity, DDLShippingState);
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void DDLShippingCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        TabContainer1.ActiveTabIndex = 1;
    }
    protected void btnProductSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            if (txtDescOfItem.Text != "" && txtItemCode.Text != "" && txtQty.Text != "" && fun.NumberValidationQty(txtQty.Text) == true)
            {
                string cmdstr = fun.insert("SD_Cust_WorkOrder_Products_Temp", "SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + txtItemCode.Text + "','" + txtDescOfItem.Text + "','" + Convert.ToDouble(decimal.Parse((txtQty.Text).ToString()).ToString("N3")) + "'");
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            FillGrid();

            txtDescOfItem.Text = "";
            txtItemCode.Text = "";
            txtQty.Text = "";

        }

        catch (Exception ex) { }
        finally
        {
            TabContainer1.ActiveTab = TabContainer1.Tabs[2];
        }

    }
    protected void btnTaskNext_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[1];
    }
    protected void btnShippingNext_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[2];
    }
    protected void btnProductNext_Click(object sender, EventArgs e)
    {
        TabContainer1.ActiveTab = TabContainer1.Tabs[3];
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("WorkOrder_New.aspx?ModId=2&SubModId=13");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        con.Open();
        string CDate = fun.getCurrDate();
        string CTime = fun.getCurrTime();
        int k1 = 0;
        int k2 = 0;
        try
        {
            string StrCat = fun.select("HasSubCat", "tblSD_WO_Category", "CId='" + DDLTaskWOType.SelectedValue + "'");
            SqlCommand Cmd = new SqlCommand(StrCat, con);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS1 = new DataSet();
            DA.Fill(DS1, "tblSD_WO_Category");
            string scid = "0";
            if (Convert.ToInt32(DS1.Tables[0].Rows[0]["HasSubCat"]) == 1)
            {
                if (DDLSubcategory.SelectedValue != "Select")
                {
                    scid = DDLSubcategory.SelectedValue;
                }
                else
                {
                    scid = "Select";
                }
            }



            string WorkOrderNo = "";
            string subcat = "0";
            string WOId = "";
            if (scid != "Select")
            {
                string cat = fun.getWOChar(DDLTaskWOType.SelectedItem.Text);

                if (DDLSubcategory.SelectedValue != "Select")
                {
                    subcat = fun.getWOChar(DDLSubcategory.SelectedItem.Text);
                }

                string cmdStr = fun.select("WONo", "SD_Cust_WorkOrder_Master", "CId='" + DDLTaskWOType.SelectedValue + "' AND SCId='" + scid + "' order by Id desc");
                SqlCommand cmd11 = new SqlCommand(cmdStr, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd11);
                da.Fill(DS, "SD_Cust_WorkOrder_Master");

                if (DS.Tables[0].Rows.Count > 0)
                {
                    int won = Convert.ToInt32(fun.getWO(DS.Tables[0].Rows[0]["WONo"].ToString())) + 1;
                    //WorkOrderNo = cat + subcat + won.ToString("D4");
                    WorkOrderNo = cat + won.ToString("D4");
                }
                else
                {
                    //WorkOrderNo = cat + subcat + "0001";
                    WorkOrderNo = cat + "0001";
                }
            }
            string strselect = fun.select("*", "SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "' ");
            SqlCommand cmd1 = new SqlCommand(strselect, con);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1); DataSet ds = new DataSet();
            da1.Fill(ds, "SD_Cust_WorkOrder_Products_Temp");

            if (ds.Tables[0].Rows.Count > 0 && scid != "Select")
            {

                if (DDLBuyer.SelectedValue != "Select" && DDLTaskWOType.SelectedValue != "Select" && scid != "Select" && WorkOrderNo != "" && txtWorkOrderDate.Text != "" && txtTaskTargetDAP_FDate.Text != "" && txtTaskTargetDAP_TDate.Text != "" && txtTaskDesignFinalization_FDate.Text != "" && txtTaskDesignFinalization_TDate.Text != "" && txtTaskTargetManufg_FDate.Text != "" && txtTaskTargetManufg_TDate.Text != "" && txtTaskTargetTryOut_FDate.Text != "" && txtTaskTargetTryOut_TDate.Text != "" && txtTaskTargetDespach_FDate.Text != "" && txtTaskTargetDespach_TDate.Text != "" && txtTaskTargetAssembly_FDate.Text != "" && txtTaskTargetAssembly_TDate.Text != "" && txtTaskTargetInstalation_FDate.Text != "" && txtTaskTargetInstalation_TDate.Text != "" && txtTaskCustInspection_FDate.Text != "" && txtTaskCustInspection_TDate.Text != "" && CustCode.ToString() != "" && enqId != 0 && pono.ToString() != "" && DDLTaskWOType.SelectedValue != "Select" && txtProjectTitle.Text != "" && txtProjectLeader.Text != "" && DDLBusinessGroup.SelectedValue != "Select" && txtShippingAdd.Text != "" && DDLShippingCountry.SelectedValue != "Select" && DDLShippingState.SelectedValue != "Select" && DDLShippingCity.SelectedValue != "Select" && txtShippingContactPerson1.Text != "" && txtShippingContactNo1.Text != "" && txtShippingEmail1.Text != "" && txtShippingContactPerson2.Text != "" && txtShippingContactNo2.Text != "" && txtShippingEmail2.Text != "" && txtShippingFaxNo.Text != "" && txtShippingEccNo.Text != "" && txtShippingTinCstNo.Text != "" && txtShippingTinVatNo.Text != "" && txtInstractionOther.Text != "" && txtInstractionExportCaseMark.Text != "" && fun.EmailValidation(txtShippingEmail1.Text) == true && fun.EmailValidation(txtShippingEmail2.Text) == true && fun.DateValidation(txtWorkOrderDate.Text) == true && fun.DateValidation(txtTaskTargetDAP_FDate.Text) == true && fun.DateValidation(txtTaskTargetDAP_TDate.Text) == true && fun.DateValidation(txtTaskDesignFinalization_FDate.Text) == true && fun.DateValidation(txtTaskDesignFinalization_TDate.Text) == true && fun.DateValidation(txtTaskTargetManufg_FDate.Text) == true && fun.DateValidation(txtTaskTargetManufg_TDate.Text) == true && fun.DateValidation(txtTaskTargetTryOut_FDate.Text) == true && fun.DateValidation(txtTaskTargetTryOut_TDate.Text) == true && fun.DateValidation(txtTaskTargetDespach_FDate.Text) == true && fun.DateValidation(txtTaskTargetDespach_TDate.Text) == true && fun.DateValidation(txtTaskTargetAssembly_FDate.Text) == true && fun.DateValidation(txtTaskTargetAssembly_TDate.Text) == true && fun.DateValidation(txtTaskTargetInstalation_FDate.Text) == true && fun.DateValidation(txtTaskTargetInstalation_TDate.Text) == true && fun.DateValidation(txtTaskCustInspection_FDate.Text) == true && fun.DateValidation(txtTaskCustInspection_TDate.Text) == true && fun.DateValidation(txtManufMaterialDate.Text) == true && fun.DateValidation(txtBoughtoutMaterialDate.Text) == true)
                {

                    string InstractionAttachAnnexure = "";// browse button to be add
                    string WorkOrderDate = fun.FromDate(txtWorkOrderDate.Text);

                    string TaskTargetDAP_FDate = fun.FromDate(txtTaskTargetDAP_FDate.Text);
                    string TaskTargetDAP_TDate = fun.ToDate(txtTaskTargetDAP_TDate.Text);

                    string TaskDesignFinalization_FDate = fun.FromDate(txtTaskDesignFinalization_FDate.Text);
                    string TaskDesignFinalization_TDate = fun.ToDate(txtTaskDesignFinalization_TDate.Text);

                    string TaskTargetManufg_FDate = fun.FromDate(txtTaskTargetManufg_FDate.Text);
                    string TaskTargetManufg_TDate = fun.ToDate(txtTaskTargetManufg_TDate.Text);

                    string TaskTargetTryOut_FDate = fun.FromDate(txtTaskTargetTryOut_FDate.Text);
                    string TaskTargetTryOut_TDate = fun.ToDate(txtTaskTargetTryOut_TDate.Text);

                    string TaskTargetDespach_FDate = fun.FromDate(txtTaskTargetDespach_FDate.Text);
                    string TaskTargetDespach_TDate = fun.ToDate(txtTaskTargetDespach_TDate.Text);

                    string TaskTargetAssembly_FDate = fun.FromDate(txtTaskTargetAssembly_FDate.Text);
                    string TaskTargetAssembly_TDate = fun.ToDate(txtTaskTargetAssembly_TDate.Text);

                    string TaskTargetInstalation_FDate = fun.FromDate(txtTaskTargetInstalation_FDate.Text);
                    string TaskTargetInstalation_TDate = fun.ToDate(txtTaskTargetInstalation_TDate.Text);

                    string TaskCustInspection_FDate = fun.FromDate(txtTaskCustInspection_FDate.Text);
                    string TaskCustInspection_TDate = fun.ToDate(txtTaskCustInspection_TDate.Text);

                    string ManufMaterialDate = fun.FromDate(txtManufMaterialDate.Text);
                    string BoughtoutMaterialDate = fun.FromDate(txtBoughtoutMaterialDate.Text);

                    int a;
                    if (CKInstractionPrimerPainting.Checked == true)
                    { a = 1; }
                    else { a = 0; }

                    int b;
                    if (CKInstractionPainting.Checked == true)
                    { b = 1; }
                    else { b = 0; }

                    int c;
                    if (CKInstractionSelfCertRept.Checked == true)
                    { c = 1; }
                    else { c = 0; }

                    string cmdstr = fun.insert("SD_Cust_WorkOrder_Master",
                        "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,EnqId,PONo,WONo,TaskWorkOrderDate,TaskProjectTitle,TaskProjectLeader,CId,SCId,TaskBusinessGroup,TaskTargetDAP_FDate,TaskTargetDAP_TDate,TaskDesignFinalization_FDate,TaskDesignFinalization_TDate,TaskTargetManufg_FDate,TaskTargetManufg_TDate,TaskTargetTryOut_FDate,TaskTargetTryOut_TDate,TaskTargetDespach_FDate,TaskTargetDespach_TDate,TaskTargetAssembly_FDate,TaskTargetAssembly_TDate,TaskTargetInstalation_FDate,TaskTargetInstalation_TDate,TaskCustInspection_FDate,TaskCustInspection_TDate,ShippingAdd,ShippingCountry,ShippingState,ShippingCity,ShippingContactPerson1,ShippingContactNo1,ShippingEmail1,ShippingContactPerson2,ShippingContactNo2,ShippingEmail2,ShippingFaxNo,ShippingEccNo,ShippingTinCstNo,ShippingTinVatNo,InstractionPrimerPainting,InstractionPainting,InstractionSelfCertRept,InstractionOther,InstractionExportCaseMark,InstractionAttachAnnexure,POId,ManufMaterialDate,BoughtoutMaterialDate,Buyer,Critics", "'" + CDate.ToString() + "','" + CTime + "','" + sId + "','" + CompId + "','" + FinYearId + "','" + CustCode + "','" + enqId + "','" + pono + "','" + WorkOrderNo + "','" + WorkOrderDate + "','" + txtProjectTitle.Text + "','" + txtProjectLeader.Text + "','" + DDLTaskWOType.SelectedValue + "','" + scid + "','" + DDLBusinessGroup.SelectedValue + "','" + TaskTargetDAP_FDate + "','" + TaskTargetDAP_TDate + "','" + TaskDesignFinalization_FDate + "','" + TaskDesignFinalization_TDate + "','" + TaskTargetManufg_FDate + "','" + TaskTargetManufg_TDate + "','" + TaskTargetTryOut_FDate + "','" + TaskTargetTryOut_TDate + "','" + TaskTargetDespach_FDate + "','" + TaskTargetDespach_TDate + "','" + TaskTargetAssembly_FDate + "','" + TaskTargetAssembly_TDate + "','" + TaskTargetInstalation_FDate + "','" + TaskTargetInstalation_TDate + "','" + TaskCustInspection_FDate + "','" + TaskCustInspection_TDate + "','" +
                        txtShippingAdd.Text + "','" + DDLShippingCountry.SelectedValue + "','" + DDLShippingState.SelectedValue + "','" + DDLShippingCity.SelectedValue + "','" + txtShippingContactPerson1.Text + "','" + txtShippingContactNo1.Text + "','" + txtShippingEmail1.Text + "','" + txtShippingContactPerson2.Text + "','" + txtShippingContactNo2.Text + "','" + txtShippingEmail2.Text + "','" + txtShippingFaxNo.Text + "','" + txtShippingEccNo.Text + "','" + txtShippingTinCstNo.Text + "','" + txtShippingTinVatNo.Text + "','" + a.ToString() + "','" + b.ToString() + "','" + c.ToString() + "','" + txtInstractionOther.Text + "','" + txtInstractionExportCaseMark.Text + "','" + InstractionAttachAnnexure.ToString() + "','" + PoId + "','" + ManufMaterialDate.ToString() + "','" + BoughtoutMaterialDate.ToString() + "','" + DDLBuyer.SelectedValue + "','" + txtcri.Text + "'");

                    SqlCommand cmd = new SqlCommand(cmdstr, con);
                    cmd.ExecuteNonQuery();

                    string sqlId = fun.select("Id", "SD_Cust_WorkOrder_Master", "CompId='" + CompId + "'Order by Id desc");
                    SqlCommand cmdId = new SqlCommand(sqlId, con);
                    SqlDataAdapter daId = new SqlDataAdapter(cmdId);
                    DataSet DSId = new DataSet();
                    daId.Fill(DSId, "tblinv_MaterialReceived_Master");
                    WOId = DSId.Tables[0].Rows[0]["Id"].ToString();
                    k1++;
                }


                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    string strInsert = fun.insert("SD_Cust_WorkOrder_Products_Details", "MId,SessionId,CompId,FinYearId,ItemCode,Description,Qty", "'" + WOId + "','" + ds.Tables[0].Rows[k]["SessionId"].ToString() + "','" + Convert.ToInt32(ds.Tables[0].Rows[k]["CompId"]) + "','" + Convert.ToInt32(ds.Tables[0].Rows[k]["FinYearId"]) + "','" + ds.Tables[0].Rows[k]["ItemCode"].ToString() + "','" + ds.Tables[0].Rows[k]["Description"].ToString() + "','" + Convert.ToDouble(decimal.Parse(ds.Tables[0].Rows[k]["Qty"].ToString()).ToString("N3")) + "'");

                    SqlCommand cmd2 = new SqlCommand(strInsert, con);
                    cmd2.ExecuteNonQuery();
                }

                if (k1 > 0)
                {
                    //Code for deleting Details in SD_Cust_WorkOrder_Products_Temp table.
                    string strDelete = fun.delete("SD_Cust_WorkOrder_Products_Temp", "SessionId='" + sId + "' and CompId='" + CompId + "' and FinYearId ='" + FinYearId + "'");
                    SqlCommand cmddelete = new SqlCommand(strDelete, con);
                    cmddelete.ExecuteNonQuery();
                    k2++;
                }
            }
            else
            {
                string myStringVariable = string.Empty;
                string myStringVariable2 = "Invalid Data.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable2 + "');", true);

            }


            if (k1 > 0 && (k1 > 0 || k2 > 0))
            {
                Response.Redirect("WorkOrder_New.aspx?ModId=2&SubModId=13&msg=Work order is generated.");
            }
        }
        catch (Exception exs)
        {
        }
        finally
        {
            con.Close();
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        FillGrid();

    }

    private void FillGrid()
    {

        try
        {

            con.Open();
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(fun.select("Id,ItemCode,Description,Qty", "SD_Cust_WorkOrder_Products_Temp", "CompId ='" + CompId + "'AND FinYearId ='" + FinYearId + "' AND SessionId ='" + sId + "' Order by Id desc"), con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, " SD_Cust_WorkOrder_Products_Temp");
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
            string DescItem = ((TextBox)row.FindControl("txtItemCode")).Text.ToString().Trim();
            string DESC1 = ((TextBox)row.FindControl("txtDesc")).Text.ToString().Trim();
            double rate = Convert.ToDouble(((TextBox)row.FindControl("txtQty")).Text.ToString().Trim());
            if (DescItem != "" && DESC1 != "" && rate != 0 && fun.NumberValidationQty(rate.ToString()) == true)
            {
                string sql = fun.update("SD_Cust_WorkOrder_Products_Temp", "ItemCode='" + DescItem + "',Description='" + DESC1 + "',Qty='" + decimal.Parse(rate.ToString()).ToString("N3") + "' ", "Id=" + id + " And CompId='" + CompId + "'");
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                int temp = cmd.ExecuteNonQuery();
                con.Close();
                if (temp == 1)
                {

                    lblMessage.Text = "Record updated successfully";
                }
                GridView1.EditIndex = -1;
                FillGrid();
            }
        }
        catch (Exception ex) { }


    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            int Eid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM SD_Cust_WorkOrder_Products_Temp  WHERE Id=" + Eid + " And CompId='" + CompId + "'", con);
            con.Open();
            int temp = cmd.ExecuteNonQuery();
            if (temp == 1)
            {
                lblMessage.Text = "Record deleted successfully";
            }
            con.Close();
            FillGrid();

        }
        catch (Exception ex)
        {
        }

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
        FillGrid();
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
    protected void DDLTaskWOType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);
        try
        {

            if (DDLTaskWOType.SelectedValue != "Select")
            {
                string StrCat1 = fun.select("HasSubCat", "tblSD_WO_Category", "CId='" + DDLTaskWOType.SelectedValue + "'");
                SqlCommand Cmdcat = new SqlCommand(StrCat1, con);
                SqlDataAdapter DAcat = new SqlDataAdapter(Cmdcat);
                DataSet DScat = new DataSet();
                DAcat.Fill(DScat, "tblSD_WO_Category");
                if (Convert.ToInt32(DScat.Tables[0].Rows[0]["HasSubCat"]) == 0)
                {
                    ReqWoType0.Visible = false;
                }
                else
                {
                    ReqWoType0.Visible = true;
                }

                string StrSub = fun.select("CId,SCId,Symbol+' - '+SCName as SubCategory", " tblSD_WO_SubCategory", "CId=" + DDLTaskWOType.SelectedValue + "And CompId='" + CompId + "'");
                SqlCommand Cmd1 = new SqlCommand(StrSub, con);

                SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
                DataSet DS2 = new DataSet();
                DA1.Fill(DS2, "tblSD_WO_SubCategory");

                DDLSubcategory.DataSource = DS2.Tables["tblSD_WO_SubCategory"];
                DDLSubcategory.DataTextField = "SubCategory";
                DDLSubcategory.DataValueField = "SCId";
                DDLSubcategory.DataBind();
                DDLSubcategory.Items.Insert(0, "Select");
            }
            else
            {
                DDLSubcategory.Items.Clear();
                DDLSubcategory.Items.Insert(0, "Select");

            }
        }
        catch (Exception ch)
        {
        }
        finally
        {
            con.Close();
        }

    }
}

