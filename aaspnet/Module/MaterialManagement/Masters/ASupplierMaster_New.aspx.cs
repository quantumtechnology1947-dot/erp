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

public partial class Module_MaterialManagement_Masters_ASupplierMaster_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                fun.dropdownCountry(DDListNewRegdCountry, DDListNewRegdState);
                fun.dropdownCountry(DDListNewWorkCountry, DDListNewWorkState);
                fun.dropdownCountry(DDListNewMaterialDelCountry, DDListNewMaterialDelState);

                if (!String.IsNullOrEmpty(Request.QueryString["msg"]))
                {
                    string mystring = string.Empty;
                    mystring = Request.QueryString["msg"].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
                }
            }
        }
        catch (Exception ett)
        {
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

        try
        {
            con.Open();

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();
            string sId = Session["username"].ToString();
            int CompId = Convert.ToInt32(Session["compid"]);
            int FinYearId = Convert.ToInt32(Session["finyear"]);

            string charstr = fun.getCustChar(txtNewSupplierName.Text);
            string cmdStr = fun.select("SupplierId", "tblMM_Supplier_masterA", "SupplierName like '" + charstr + "%' And CompId='" + CompId + "' order by SupplierId desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "tblMM_Supplier_masterA");
            string SupIdStr;

            if (DS.Tables[0].Rows.Count > 0)
            {
                string getcuststr = DS.Tables[0].Rows[0][0].ToString();
                string covstr = getcuststr.Substring(1);
                int incstr = Convert.ToInt32(covstr) + 1;
                SupIdStr = charstr + incstr.ToString("D3");

            }
            else
            {
                SupIdStr = charstr + "001";
            }

            int ModVatApplicable = 0;
            if (rbMVAYes.Checked == true)
            { ModVatApplicable = 1; }
            else { ModVatApplicable = 0; }

            int ModVatInvoice = 0;
            if (rbMVIYes.Checked == true)
            { ModVatInvoice = 1; }
            else { ModVatInvoice = 0; }

            if (txtNewSupplierName.Text != "" && txtScopeofSupply.Text != "" && txtNewRegdAdd.Text != "" && txtNewWorkAdd.Text != "" && txtNewWorkPinNo.Text != "" && txtNewWorkContactNo.Text != "" && txtNewWorkFaxNo.Text != "" && txtNewMaterialDelAdd.Text != "" && txtNewMaterialDelPinNo.Text != "" && txtNewMaterialDelContactNo.Text != "" && txtNewMaterialDelFaxNo.Text != "" && txtNewContactPerson.Text != "" && txtNewJuridictionCode.Text != "" && txtNewCommissionurate.Text != "" && txtNewTinVatNo.Text != "" && txtNewEmail.Text != "" && txtNewEccNo.Text != "" && txtNewDivn.Text != "" && txtNewTinCstNo.Text != "" && txtNewContactNo.Text != "" && txtNewRange.Text != "" && txtNewPanNo.Text != "" && txtNewTdsCode.Text != "" && txtNewRemark.Text != "" && txtBankAccNo.Text != "" && txtBankName.Text != "" && txtBankBranch.Text != "" && txtBankAddress.Text != "" && txtBankAccType.Text != "" && fun.EmailValidation(txtNewEmail.Text) == true)
            {

                string cmdstr = fun.insert("tblMM_Supplier_masterA",
                    "SysDate,SysTime,SessionId,CompId,FinYearId,SupplierId,SupplierName,ScopeOfSupply,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark,ModVatApplicable,ModVatInvoice,BankAccNo,BankName,BankBranch,BankAddress,BankAccType,BusinessType,BusinessNature,ServiceCoverage,PF,ExST,VAT",
                    "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + SupIdStr.ToUpper() + "','" + txtNewSupplierName.Text.ToUpper() + "','" + txtScopeofSupply.Text + "','" + txtNewRegdAdd.Text + "','" + DDListNewRegdCountry.SelectedValue + "','" + DDListNewRegdState.SelectedValue + "','" + DDListNewRegdCity.SelectedValue + "','" + txtNewRegdPinNo.Text + "','" + txtNewRegdContactNo.Text + "','" + txtNewRegdFaxNo.Text + "','" + txtNewWorkAdd.Text + "','" + DDListNewWorkCountry.SelectedValue + "','" + DDListNewWorkState.SelectedValue + "','" + DDListNewWorkCity.SelectedValue + "','" + txtNewWorkPinNo.Text + "','" + txtNewWorkContactNo.Text + "','" + txtNewWorkFaxNo.Text + "','" + txtNewMaterialDelAdd.Text + "','" + DDListNewMaterialDelCountry.SelectedValue + "','" + DDListNewMaterialDelState.SelectedValue + "','" + DDListNewMaterialDelCity.SelectedValue + "','" + txtNewMaterialDelPinNo.Text + "','" + txtNewMaterialDelContactNo.Text + "','" + txtNewMaterialDelFaxNo.Text + "','" + txtNewContactPerson.Text + "','" + txtNewJuridictionCode.Text + "','" + txtNewCommissionurate.Text + "','" + txtNewTinVatNo.Text + "','" + txtNewEmail.Text + "','" + txtNewEccNo.Text + "','" + txtNewDivn.Text + "','" + txtNewTinCstNo.Text + "','" + txtNewContactNo.Text + "','" + txtNewRange.Text + "','" + txtNewPanNo.Text + "','" + txtNewTdsCode.Text + "','" + txtNewRemark.Text + "','" + ModVatApplicable + "','" + ModVatInvoice + "','" + txtBankAccNo.Text + "','" + txtBankName.Text + "','" + txtBankBranch.Text + "','" + txtBankAddress.Text + "','" + txtBankAccType.Text + "','" + hfBusinessType.Text + "','" + hfBusinessNature.Text + "','" + DDLServiceCoverage.SelectedValue + "','" + Convert.ToInt32(DDLPF.SelectedValue) + "','" + Convert.ToInt32(DDLExcies.SelectedValue) + "','" + Convert.ToInt32(DDLVat.SelectedValue) + "'");

                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.ExecuteNonQuery();

                Page.Response.Redirect("ASupplierMaster_New.aspx?msg=Supplier is registered sucessfuly");

            }
        }
        catch (Exception ex) { }
        finally
        {
            con.Close();

        }

    }
    protected void DDListNewRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListNewRegdState, DDListNewRegdCity, DDListNewRegdCountry);
    }
    protected void DDListNewRegdCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DDListNewRegdState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListNewRegdCity, DDListNewRegdState);
    }
    protected void DDListNewWorkCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListNewWorkState, DDListNewWorkCity, DDListNewWorkCountry);
    }
    protected void DDListNewWorkState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListNewWorkCity, DDListNewWorkState);
    }
    protected void DDListNewMaterialDelCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListNewMaterialDelState, DDListNewMaterialDelCity, DDListNewMaterialDelCountry);
    }
    protected void DDListNewMaterialDelState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListNewMaterialDelCity, DDListNewMaterialDelState);
    }


    protected void CBLBusinessNature_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hfBusinessNature.Text = string.Empty;

            foreach (ListItem listitem in CBLBusinessNature.Items)
            {
                if (listitem.Selected)
                    hfBusinessNature.Text += listitem.Value + ",";
            }
        }
        catch (Exception ss)
        {
        }
    }
    protected void CBLBusinessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            hfBusinessType.Text = string.Empty;

            foreach (ListItem listitem in CBLBusinessType.Items)
            {
                if (listitem.Selected)
                    hfBusinessType.Text += listitem.Value + ",";
            }

        }
        catch (Exception ss)
        {
        }
    }
}
