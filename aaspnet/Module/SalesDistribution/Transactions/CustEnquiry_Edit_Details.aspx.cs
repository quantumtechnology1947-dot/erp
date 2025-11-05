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

public partial class Module_SalesDistribution_Transactions_CustEnquiry_Edit_Details : System.Web.UI.Page
{

    clsFunctions fun = new clsFunctions();
    DataSet DS = new DataSet();
    string CustCode ="";
    int EnqId = 0;
    int CId = 0;
    string sId = "";   
    int FinYearId = 0;
    string CDate = "";
    string CTime = "";
    string connStr = "";
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            CId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            hfCustId.Text = Request.QueryString["CustomerId"].ToString();
            CustCode = hfCustId.Text;
            hfEnqId.Text = Request.QueryString["EnqId"].ToString();
            EnqId = Convert.ToInt32(hfEnqId.Text);
            DataSet DSEnq = new DataSet();
            string cmdStrEnq = fun.select("CustomerName", "SD_Cust_Enquiry_Master", "CompId='" + CId + "'AND EnqId='" + EnqId + "'");
            SqlCommand cmdEnq = new SqlCommand(cmdStrEnq, con);
            SqlDataAdapter DAEnq = new SqlDataAdapter(cmdEnq);
            DAEnq.Fill(DSEnq, "SD_Cust_Enquiry_Master");
            // Regd Country 
            if (DSEnq.Tables[0].Rows.Count > 0)
            {
                lblCustName.Text = DSEnq.Tables[0].Rows[0]["CustomerName"].ToString();

            }

            if (!IsPostBack)
            {
                fun.dropdownCountry(DDListEditRegdCountry, DDListEditRegdState);
                fun.dropdownCountry(DDListEditWorkCountry, DDListEditWorkState);
                fun.dropdownCountry(DDListEditMaterialDelCountry, DDListEditMaterialDelState);

                {
                    DataSet DS = new DataSet();
                    string cmdStr = fun.select("*","SD_Cust_Enquiry_Master","CompId='" + CId + "' AND EnqId='" + EnqId + "'");
                    SqlCommand cmd = new SqlCommand(cmdStr, con);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DA.Fill(DS, "SD_Cust_Enquiry_Master");
                    if (DS.Tables[0].Rows.Count > 0)
                    {
                        // Regd Country 
                        txtEditRegdAdd.Text = DS.Tables[0].Rows[0]["RegdAddress"].ToString();
                        fun.dropdownCountrybyId(DDListEditRegdCountry, DDListEditRegdState, "CId='" + DS.Tables[0].Rows[0]["RegdCountry"].ToString() + "'");
                        DDListEditRegdCountry.SelectedIndex = 0;
                        fun.dropdownCountry(DDListEditRegdCountry, DDListEditRegdState);
                        DDListEditRegdCountry.SelectedValue = DS.Tables[0].Rows[0]["RegdCountry"].ToString();
                        // Regd State
                        fun.dropdownState(DDListEditRegdState, DDListEditRegdCity, DDListEditRegdCountry);
                        fun.dropdownStatebyId(DDListEditRegdState, "CId='" + DS.Tables[0].Rows[0]["RegdCountry"].ToString() + "' AND SId='" + DS.Tables[0].Rows[0]["RegdState"].ToString() + "'");
                        
                        DDListEditRegdState.SelectedValue = DS.Tables[0].Rows[0]["RegdState"].ToString();

                        // Regd City
                        fun.dropdownCity(DDListEditRegdCity, DDListEditRegdState);
                        fun.dropdownCitybyId(DDListEditRegdCity, "SId='" + DS.Tables[0].Rows[0]["RegdState"].ToString() + "' AND CityId='" + DS.Tables[0].Rows[0]["RegdCity"].ToString() + "'");
                        

                        DDListEditRegdCity.SelectedValue = DS.Tables[0].Rows[0]["RegdCity"].ToString();

                        txtEditRegdPinNo.Text = DS.Tables[0].Rows[0]["RegdPinNo"].ToString();
                        txtEditRegdContactNo.Text = DS.Tables[0].Rows[0]["RegdContactNo"].ToString();
                        txtEditRegdFaxNo.Text = DS.Tables[0].Rows[0]["RegdFaxNo"].ToString();

                        // Work Country 
                        txtEditWorkAdd.Text = DS.Tables[0].Rows[0]["WorkAddress"].ToString();
                        fun.dropdownCountrybyId(DDListEditWorkCountry, DDListEditWorkState, "CId='" + DS.Tables[0].Rows[0]["WorkCountry"].ToString() + "'");
                        DDListEditWorkCountry.SelectedIndex = 0;
                        fun.dropdownCountry(DDListEditWorkCountry, DDListEditWorkState);
                        DDListEditWorkCountry.SelectedValue = DS.Tables[0].Rows[0]["WorkCountry"].ToString();
                        // Work State
                        fun.dropdownState(DDListEditWorkState, DDListEditWorkCity, DDListEditWorkCountry);
                        fun.dropdownStatebyId(DDListEditWorkState, "CId='" + DS.Tables[0].Rows[0]["WorkCountry"].ToString() + "' AND SId='" + DS.Tables[0].Rows[0]["WorkState"].ToString() + "'");
                        

                        DDListEditWorkState.SelectedValue = DS.Tables[0].Rows[0]["WorkState"].ToString();

                        // Work City
                        fun.dropdownCity(DDListEditWorkCity, DDListEditWorkState);
                        fun.dropdownCitybyId(DDListEditWorkCity, "SId='" + DS.Tables[0].Rows[0]["WorkState"].ToString() + "' AND CityId='" + DS.Tables[0].Rows[0]["WorkCity"].ToString() + "'");
                       

                        DDListEditWorkCity.SelectedValue = DS.Tables[0].Rows[0]["WorkCity"].ToString();

                        txtEditWorkPinNo.Text = DS.Tables[0].Rows[0]["WorkPinNo"].ToString();
                        txtEditWorkContactNo.Text = DS.Tables[0].Rows[0]["WorkContactNo"].ToString();
                        txtEditWorkFaxNo.Text = DS.Tables[0].Rows[0]["WorkFaxNo"].ToString();

                        // Material Country
                        txtEditMaterialDelAdd.Text = DS.Tables[0].Rows[0]["MaterialDelAddress"].ToString();
                        fun.dropdownCountrybyId(DDListEditMaterialDelCountry, DDListEditMaterialDelState, "CId='" + DS.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "'");
                        DDListEditMaterialDelCountry.SelectedIndex = 0;
                        fun.dropdownCountry(DDListEditMaterialDelCountry, DDListEditMaterialDelState);
                        DDListEditMaterialDelCountry.SelectedValue = DS.Tables[0].Rows[0]["MaterialDelCountry"].ToString();
                        // Material State
                        fun.dropdownState(DDListEditMaterialDelState, DDListEditMaterialDelCity, DDListEditMaterialDelCountry);
                        fun.dropdownStatebyId(DDListEditMaterialDelState, "CId='" + DS.Tables[0].Rows[0]["MaterialDelCountry"].ToString() + "' AND SId='" + DS.Tables[0].Rows[0]["MaterialDelState"].ToString() + "'");
                        
                        DDListEditMaterialDelState.SelectedValue = DS.Tables[0].Rows[0]["MaterialDelState"].ToString();

                        // Material City
                        fun.dropdownCity(DDListEditMaterialDelCity, DDListEditMaterialDelState);
                        fun.dropdownCitybyId(DDListEditMaterialDelCity, "SId='" + DS.Tables[0].Rows[0]["MaterialDelState"].ToString() + "' AND CityId='" + DS.Tables[0].Rows[0]["MaterialDelCity"].ToString() + "'");
                        

                        DDListEditMaterialDelCity.SelectedValue = DS.Tables[0].Rows[0]["MaterialDelCity"].ToString();

                        txtEditMaterialDelPinNo.Text = DS.Tables[0].Rows[0]["MaterialDelPinNo"].ToString();
                        txtEditMaterialDelContactNo.Text = DS.Tables[0].Rows[0]["MaterialDelContactNo"].ToString();
                        txtEditMaterialDelFaxNo.Text = DS.Tables[0].Rows[0]["MaterialDelFaxNo"].ToString();

                        txtEditContactPerson.Text = DS.Tables[0].Rows[0]["ContactPerson"].ToString();
                        txtEditJuridictionCode.Text = DS.Tables[0].Rows[0]["JuridictionCode"].ToString();
                        txtEditCommissionurate.Text = DS.Tables[0].Rows[0]["Commissionurate"].ToString();
                        txtEditTinVatNo.Text = DS.Tables[0].Rows[0]["TinVatNo"].ToString();
                        txtEditEmail.Text = DS.Tables[0].Rows[0]["Email"].ToString();
                        txtEditEccNo.Text = DS.Tables[0].Rows[0]["EccNo"].ToString();
                        txtEditDivn.Text = DS.Tables[0].Rows[0]["Divn"].ToString();
                        txtEditTinCstNo.Text = DS.Tables[0].Rows[0]["TinCstNo"].ToString();
                        txtEditContactNo.Text = DS.Tables[0].Rows[0]["ContactNo"].ToString();
                        txtEditRange.Text = DS.Tables[0].Rows[0]["Range"].ToString();
                        txtEditPanNo.Text = DS.Tables[0].Rows[0]["PanNo"].ToString();
                        txtEditTdsCode.Text = DS.Tables[0].Rows[0]["TDSCode"].ToString();
                        txtEditRemark.Text = DS.Tables[0].Rows[0]["Remark"].ToString();
                        txtEditEnquiryFor.Text = DS.Tables[0].Rows[0]["EnquiryFor"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void Update_Click(object sender, EventArgs e)
    {        
        try
        {
            con.Open();
            if (txtEditRegdAdd.Text != "" && DDListEditRegdCountry.SelectedValue != "Select" && DDListEditRegdState.SelectedValue != "Select" && DDListEditRegdCity.SelectedValue != "Select" && txtEditRegdPinNo.Text != "" && txtEditRegdContactNo.Text != "" && txtEditRegdFaxNo.Text != "" && txtEditWorkAdd.Text != "" && DDListEditWorkCountry.SelectedValue != "Select" && DDListEditWorkState.SelectedValue != "" && DDListEditWorkCity.SelectedValue != "Select" && txtEditWorkPinNo.Text != "" && txtEditWorkContactNo.Text != "" && txtEditWorkFaxNo.Text != "" && txtEditMaterialDelAdd.Text != "" && DDListEditMaterialDelCountry.SelectedValue != "Select" && DDListEditMaterialDelState.SelectedValue != "Select" && DDListEditMaterialDelCity.SelectedValue != "Select" && txtEditMaterialDelPinNo.Text != "" && txtEditMaterialDelContactNo.Text != "" && txtEditMaterialDelFaxNo.Text != "" && txtEditContactPerson.Text != "" && txtEditJuridictionCode.Text != "" && txtEditCommissionurate.Text != "" && txtEditTinVatNo.Text != "" && fun.EmailValidation(txtEditEmail.Text) == true && txtEditEmail.Text != "" && txtEditEccNo.Text != "" && txtEditDivn.Text != "" && txtEditTinCstNo.Text != "" && txtEditContactNo.Text != "" && txtEditRange.Text != "" && txtEditPanNo.Text != "" && txtEditTdsCode.Text != "" && txtEditEnquiryFor.Text != "")
            {
                string cmdstr = fun.update("SD_Cust_Enquiry_Master",
                         "SysDate='" + CDate.ToString() + "',SysTime='" + CTime.ToString() + "',SessionId='" + sId.ToString() + "',RegdAddress='" + txtEditRegdAdd.Text + "',RegdCountry='" + DDListEditRegdCountry.SelectedValue + "',RegdState='" + DDListEditRegdState.SelectedValue + "',RegdCity='" + DDListEditRegdCity.SelectedValue + "',RegdPinNo='" + txtEditRegdPinNo.Text + "',RegdContactNo='" + txtEditRegdContactNo.Text + "',RegdFaxNo='" + txtEditRegdFaxNo.Text + "',WorkAddress='" + txtEditWorkAdd.Text + "',WorkCountry='" + DDListEditWorkCountry.SelectedValue + "',WorkState='" + DDListEditWorkState.SelectedValue + "',WorkCity='" + DDListEditWorkCity.SelectedValue + "',WorkPinNo='" + txtEditWorkPinNo.Text + "',WorkContactNo='" + txtEditWorkContactNo.Text + "',WorkFaxNo='" + txtEditWorkFaxNo.Text + "',MaterialDelAddress='" + txtEditMaterialDelAdd.Text + "' ,MaterialDelCountry='" + DDListEditMaterialDelCountry.SelectedValue + "',MaterialDelState='" + DDListEditMaterialDelState.SelectedValue + "',MaterialDelCity='" + DDListEditMaterialDelCity.SelectedValue + "',MaterialDelPinNo='" + txtEditMaterialDelPinNo.Text + "',MaterialDelContactNo='" + txtEditMaterialDelContactNo.Text + "',MaterialDelFaxNo='" + txtEditMaterialDelFaxNo.Text + "',ContactPerson='" + txtEditContactPerson.Text + "',JuridictionCode='" + txtEditJuridictionCode.Text + "',Commissionurate='" + txtEditCommissionurate.Text + "',TinVatNo='" + txtEditTinVatNo.Text + "',Email='" + txtEditEmail.Text + "',EccNo='" + txtEditEccNo.Text + "',Divn='" + txtEditDivn.Text + "',TinCstNo='" + txtEditTinCstNo.Text + "',ContactNo='" + txtEditContactNo.Text + "',Range='" + txtEditRange.Text + "',PanNo='" + txtEditPanNo.Text + "',TDSCode='" + txtEditTdsCode.Text + "',Remark='" + txtEditRemark.Text + "',EnquiryFor='" + txtEditEnquiryFor.Text + "'", "CustomerId='" + CustCode + "' and EnqId=" + EnqId + " and CompId=" + CId + "");

                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("CustEnquiry_Edit.aspx?ModId=2&SubModId=10");
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

    protected void DDListEditRegdCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListEditRegdState, DDListEditRegdCity, DDListEditRegdCountry);
    }
    protected void DDListEditWorkCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListEditWorkState, DDListEditWorkCity, DDListEditWorkCountry);
    }
    protected void DDListEditWorkState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListEditWorkCity, DDListEditWorkState);
    }
    protected void DDListEditRegdState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListEditRegdCity, DDListEditRegdState);
    }
    protected void DDListEditMaterialDelCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownState(DDListEditMaterialDelState, DDListEditMaterialDelCity, DDListEditMaterialDelCountry);
    }
    protected void DDListEditMaterialDelState_SelectedIndexChanged(object sender, EventArgs e)
    {
        fun.dropdownCity(DDListEditMaterialDelCity, DDListEditMaterialDelState);
    }
   
    protected void DDListEditRegdCity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)//Upload Image/File
    {
        try
        {
            string strfilename = "";
            HttpPostedFile myfile = FileUpload1.PostedFile;
            Byte[] mydata = null;

            if (FileUpload1.PostedFile != null)
            {
                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                mydata = br.ReadBytes((Int32)fs.Length);
                strfilename = Path.GetFileName(myfile.FileName);

                if (strfilename != "")
                {
                    string strinsert = fun.insert("SD_Cust_Enquiry_Attach_Master", "EnqId,CompId,SessionId,FinYearId,FileName,FileSize,ContentType,FileData", "" + EnqId + ",'" + CId + "','" + sId + "','" + FinYearId + "','" + strfilename + "','" + mydata.Length + "','" + myfile.ContentType + "',@TransStr");

                    using (SqlCommand cmdinsert = new SqlCommand(strinsert, con))
                    {
                        cmdinsert.Parameters.Add("@TransStr", SqlDbType.VarBinary).Value = mydata;
                        con.Open();
                        cmdinsert.ExecuteNonQuery();
                        con.Close();
                    }

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
            }
        }
        catch (Exception exx)
        {

        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustEnquiry_Edit.aspx?ModId=2&SubModId=10");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = (LinkButton)e.Row.Cells[0].Controls[0];
                del.Attributes.Add("onclick", "return confirmationDelete();");

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink del1 = (HyperLink)e.Row.Cells[5].Controls[0];
                del1.Attributes.Add("onclick", "return confirmation();");
            }
        }
        catch (Exception ex) { }
    }
}
