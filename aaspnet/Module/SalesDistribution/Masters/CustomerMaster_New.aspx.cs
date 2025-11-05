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
using System.Text.RegularExpressions;

public partial class Module_SD_Cust_masters_CustomerMaster_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        sId = Session["username"].ToString();
        CompId = Convert.ToInt32(Session["compid"]);
        FinYearId = Convert.ToInt32(Session["finyear"]);

        

        if (!IsPostBack)
        {

            if (!String.IsNullOrEmpty(Request.QueryString["msg"]))
            {
                string mystring = string.Empty;
                mystring = Request.QueryString["msg"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring + "');", true);
            }
            fun.dropdownCountry(DDListNewRegdCountry, DDListNewRegdState);
            fun.dropdownCountry(DDListNewWorkCountry, DDListNewWorkState);
            fun.dropdownCountry(DDListNewMaterialDelCountry, DDListNewMaterialDelState);
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
            string charstr = fun.getCustChar(txtNewCustName.Text);
            string cmdStr = fun.select("CustomerId", "SD_Cust_master", "CustomerName like '" + charstr + "%' And CompId='" + CompId + "' order by CustomerId desc");
            SqlCommand cmd1 = new SqlCommand(cmdStr, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(DS, "SD_Cust_master");
            string custIdStr;

            if (DS.Tables[0].Rows.Count > 0)
            {
                string getcuststr = DS.Tables[0].Rows[0][0].ToString();
                string covstr = getcuststr.Substring(1);
                int incstr = Convert.ToInt32(covstr) + 1;
                custIdStr = charstr + incstr.ToString("D3");

            }
            else
            {
                custIdStr = charstr + "001";
            }

            string strRegex = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(txtNewEmail.Text) && txtNewEmail.Text != "" && CDate.ToString() != "" && CTime.ToString() != "" && sId.ToString() != "" && CompId != 0 && FinYearId != 0 && custIdStr.ToString() != "" && txtNewCustName.Text != "" && txtNewRegdAdd.Text != "" && DDListNewRegdCountry.SelectedValue != "Select" && DDListNewRegdState.SelectedValue != "Select" && DDListNewRegdCity.SelectedValue != "Select" && txtNewRegdPinNo.Text != "" && txtNewRegdContactNo.Text != "" && txtNewRegdFaxNo.Text != "" && txtNewWorkAdd.Text != "" && DDListNewWorkCountry.SelectedValue != "Select" && DDListNewWorkState.SelectedValue != "Select" && DDListNewWorkCity.SelectedValue != "Select" && txtNewWorkPinNo.Text != "" && txtNewWorkContactNo.Text != "" && txtNewWorkFaxNo.Text != "" && txtNewMaterialDelAdd.Text != "" && DDListNewMaterialDelCountry.SelectedValue != "Select" && DDListNewMaterialDelState.SelectedValue != "Select" && DDListNewMaterialDelCity.SelectedValue != "Select" && txtNewMaterialDelPinNo.Text != "" && txtNewMaterialDelContactNo.Text != "" && txtNewMaterialDelFaxNo.Text != "" && txtNewContactPerson.Text != "" && txtNewJuridictionCode.Text != "" && txtNewCommissionurate.Text != "" && txtNewTinVatNo.Text != "" && txtNewEccNo.Text != "" && txtNewDivn.Text != "" && txtNewTinCstNo.Text != "" && txtNewContactNo.Text != "" && txtNewRange.Text != "" && txtNewPanNo.Text != "" && txtNewTdsCode.Text!="")
            {
                string cmdstr = fun.insert("SD_Cust_master",
                    "SysDate,SysTime,SessionId,CompId,FinYearId,CustomerId,CustomerName,RegdAddress,RegdCountry,RegdState,RegdCity,RegdPinNo,RegdContactNo,RegdFaxNo,WorkAddress,WorkCountry,WorkState,WorkCity,WorkPinNo,WorkContactNo,WorkFaxNo,MaterialDelAddress,MaterialDelCountry,MaterialDelState,MaterialDelCity,MaterialDelPinNo,MaterialDelContactNo,MaterialDelFaxNo,ContactPerson,JuridictionCode,Commissionurate,TinVatNo,Email,EccNo,Divn,TinCstNo,ContactNo,Range,PanNo,TDSCode,Remark",
                    "'" + CDate.ToString() + "','" + CTime.ToString() + "','" + sId.ToString() + "','" + CompId + "','" + FinYearId + "','" + custIdStr.ToUpper() + "','" + txtNewCustName.Text.ToUpper() + "','" + txtNewRegdAdd.Text + "','" + DDListNewRegdCountry.SelectedValue + "','" + DDListNewRegdState.SelectedValue + "','" + DDListNewRegdCity.SelectedValue + "','" + txtNewRegdPinNo.Text + "','" + txtNewRegdContactNo.Text + "','" + txtNewRegdFaxNo.Text + "','" + txtNewWorkAdd.Text + "','" + DDListNewWorkCountry.SelectedValue + "','" + DDListNewWorkState.SelectedValue + "','" + DDListNewWorkCity.SelectedValue + "','" + txtNewWorkPinNo.Text + "','" + txtNewWorkContactNo.Text + "','" + txtNewWorkFaxNo.Text + "','" + txtNewMaterialDelAdd.Text + "','" + DDListNewMaterialDelCountry.SelectedValue + "','" + DDListNewMaterialDelState.SelectedValue + "','" + DDListNewMaterialDelCity.SelectedValue + "','" + txtNewMaterialDelPinNo.Text + "','" + txtNewMaterialDelContactNo.Text + "','" + txtNewMaterialDelFaxNo.Text + "','" + txtNewContactPerson.Text + "','" + txtNewJuridictionCode.Text + "','" + txtNewCommissionurate.Text + "','" + txtNewTinVatNo.Text + "','" + txtNewEmail.Text + "','" + txtNewEccNo.Text + "','" + txtNewDivn.Text + "','" + txtNewTinCstNo.Text + "','" + txtNewContactNo.Text + "','" + txtNewRange.Text + "','" + txtNewPanNo.Text + "','" + txtNewTdsCode.Text + "','" + txtNewRemark.Text + "'");
                
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.ExecuteNonQuery();
                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
                Page.Response.Redirect("CustomerMaster_New.aspx?msg=Customer is registered sucessfuly&ModId=2&SubModId=7");
                
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
}
