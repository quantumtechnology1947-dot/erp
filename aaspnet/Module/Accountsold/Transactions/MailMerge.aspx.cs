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
using System.Web.Mail;

public partial class Module_Accounts_Transactions_MailMerge : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    SqlConnection con;
    int CompId = 0;
    int FyId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
       // try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            FyId = Convert.ToInt32(Session["finyear"]);
           
            if (!Page.IsPostBack)
            {
                //this.BindData();
            }
        }
       // catch (Exception ex)
        {
        }
    }

    public void BindData()
    {
      //  try
        {
            string connStr = fun.Connection();
            con = new SqlConnection(connStr);
            con.Open();

            string sqlsup = "Select tblMM_Supplier_master.Email,tblMM_Supplier_master.SupplierName,tblMM_Supplier_master.SupplierId,REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING(tblMM_Supplier_master.SysDate, CHARINDEX('-', tblMM_Supplier_master.SysDate) + 1, 2) + '-' + LEFT(tblMM_Supplier_master.SysDate,CHARINDEX('-', tblMM_Supplier_master.SysDate) - 1) + '-' + RIGHT(tblMM_Supplier_master.SysDate, CHARINDEX('-', REVERSE(tblMM_Supplier_master.SysDate)) - 1)), 103), '/', '-')AS SysDate,FinYear,EmployeeName from tblMM_Supplier_master inner join tblFinancial_master on tblMM_Supplier_master.FinYearId=tblFinancial_master.FinYearId inner join tblHR_OfficeStaff on tblMM_Supplier_master.SessionId=tblHR_OfficeStaff.EmpId And tblMM_Supplier_master.CompId='" + CompId + "' And tblMM_Supplier_master.FinYearId<='" + FyId + "' Order by tblMM_Supplier_master.SupplierName Asc";

            SqlCommand Cmd = new SqlCommand(sqlsup, con);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            SearchGridView1.DataSource = ds;
            SearchGridView1.DataBind();
        }
      //  catch (Exception ex)
        {
        }
      //  finally 
        {
            con.Close();
        }

    }

    protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchGridView1.PageIndex = e.NewPageIndex;
        this.BindData();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        {
            MailMessage mail = new MailMessage();
            SmtpMail.SmtpServer = "smtp.synergytechs.com";
            
            mail.From = txtFrom.Text;
            mail.Subject = txtSub.Text;
            mail.Body = txtMsg.Text;
            mail.BodyFormat = MailFormat.Html;

            Response.Write(mail.From);

            //foreach (GridViewRow row in SearchGridView1.Rows)
            {
                //mail.To = ((Label)row.FindControl("Email")).Text;
                mail.To = "ashish.mahindre@synergytechs.com";
                SmtpMail.Send(mail);                
            }
        }
        //catch (Exception st)
        {
            //lblerror.Text = st.Message;
        }
       
    }

}
