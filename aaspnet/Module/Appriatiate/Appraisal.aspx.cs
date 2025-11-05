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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using Image = System.Drawing.Image;

public partial class Appraisal : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);

    SqlDataAdapter adapt;
    DataTable dt;

    SqlDataAdapter adapt1;
    DataTable dt1;

    //  SqlDataAdapter da;
    DataSet ds;
    SqlCommand cmd;
    

    private SqlConnection con1;
    private SqlCommand com1;
    private string constr1, query1;


    private void connection()
    {
        constr1 = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ToString();
        con1 = new SqlConnection(constr1);
        con1.Open();


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
           // con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);


             cmd = new SqlCommand("insert into tbl_ApprisalForm1 (Name,Dept,Designation,Aperiod,Grade,JoiningDate,JobR,SpeciAchv,losscomp,Part,Deniedonsite,LeaveWP,Strength,Weekness,TrainR,CurrCTC,ExpectedCTC,TotalHrs,TotalHrsPref,LastIncDate,TotalYrsExp,TotalYrsExpSAPL,HomeSalMon,HighQua,EmpCom,NoticePerOffletr,PLpend,COffPend,RollOCas,AppTimeLetter,EligibleFasi) values(@Name,@Dept,@Designation,@Aperiod,@Grade,@JoiningDate,@JobR,@SpeciAchv,@losscomp,@Part,@Deniedonsite,@LeaveWP,@Strength,@Weekness,@TrainR,@CurrCTC,@ExpectedCTC,@TotalHrs,@TotalHrsPref,@LastIncDate,@TotalYrsExp,@TotalYrsExpSAPL,@HomeSalMon,@HighQua,@EmpCom,@NoticePerOffletr,@PLpend,@COffPend,@RollOCas,@AppTimeLetter,@EligibleFasi)", con);

            using (SqlConnection con1 = new SqlConnection(con.ConnectionString))
            {
              //  using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    String str = "";

                    for (int i = 0; i <= CheckBox1.Items.Count - 1; i++)
                    {

                        if (CheckBox1.Items[i].Selected)
                        {

                            if (str == "")
                            {
                                str = CheckBox1.Items[i].Text;
                            }
                            else
                            {
                                str += "," + CheckBox1.Items[i].Text;

                            }

                        }
                    }



                    cmd.CommandText ="Insert into tbl_ApprisalForm1 (Name,Dept,Designation,Aperiod,Grade,JoiningDate,JobR,SpeciAchv,losscomp,Part,Deniedonsite,LeaveWP,Strength,Weekness,TrainR,CurrCTC,ExpectedCTC,TotalHrs,TotalHrsPref,LastIncDate,TotalYrsExp,TotalYrsExpSAPL,HomeSalMon,HighQua,EmpCom,NoticePerOffletr,PLpend,COffPend,RollOCas,AppTimeLetter,EligibleFasi) values(@Name,@Dept,@Designation,@Aperiod,@Grade,@JoiningDate,@JobR,@SpeciAchv,@losscomp,@Part,@Deniedonsite,@LeaveWP,@Strength,@Weekness,@TrainR,@CurrCTC,@ExpectedCTC,@TotalHrs,@TotalHrsPref,@LastIncDate,@TotalYrsExp,@TotalYrsExpSAPL,@HomeSalMon,@HighQua,@EmpCom,@NoticePerOffletr,@PLpend,@COffPend,@RollOCas,@AppTimeLetter,@EligibleFasi)";


                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Dept", txtdept.Text);

                    cmd.Parameters.AddWithValue("@Designation", txtdesg.Text);
                    cmd.Parameters.AddWithValue("@Aperiod", txtapp.Text);
                    cmd.Parameters.AddWithValue("@Grade", txtgrade.Text);
                    cmd.Parameters.AddWithValue("@JoiningDate", txtJDate.Text);
                    cmd.Parameters.AddWithValue("@JobR", txtjobRes.Text);
                    cmd.Parameters.AddWithValue("@SpeciAchv", txtspecific.Text);
                    cmd.Parameters.AddWithValue("@losscomp", txtloss.Text);
                    cmd.Parameters.AddWithValue("@Part", txtpart.Text);
                    cmd.Parameters.AddWithValue("@Deniedonsite", txtonsite.Text);
                    cmd.Parameters.AddWithValue("@LeaveWP", txtlevper.Text);
                    cmd.Parameters.AddWithValue("@Strength", txtstr.Text);
                    cmd.Parameters.AddWithValue("@Weekness", txtweek.Text);
                    cmd.Parameters.AddWithValue("@TrainR", txttrnreq.Text);
                    cmd.Parameters.AddWithValue("@CurrCTC", txtcrntCTC.Text);
                    cmd.Parameters.AddWithValue("@ExpectedCTC", tctexpCTC.Text);
                    cmd.Parameters.AddWithValue("@TotalHrs", txtHrs.Text);
                    cmd.Parameters.AddWithValue("@TotalHrsPref", txtdutyHrs.Text);
                    cmd.Parameters.AddWithValue("@LastIncDate", txtIncL.Text);
                    cmd.Parameters.AddWithValue("@TotalYrsExp", txtExpyr.Text);
                    cmd.Parameters.AddWithValue("@TotalYrsExpSAPL", txtYrSAPL.Text);
                    cmd.Parameters.AddWithValue("@HomeSalMon", txtHSal.Text);
                    cmd.Parameters.AddWithValue("@HighQua", txthighQ.Text);
                    cmd.Parameters.AddWithValue("@EmpCom", txtEmpC.Text);
                    cmd.Parameters.AddWithValue("@NoticePerOffletr", txtNPer.Text);
                    cmd.Parameters.AddWithValue("@PLpend", txtPL.Text);
                    cmd.Parameters.AddWithValue("@COffPend", txtCOFF.Text);
                    cmd.Parameters.AddWithValue("@RollOCas", txtroll.Text);
                    cmd.Parameters.AddWithValue("@AppTimeLetter", txtapp.Text);
                    cmd.Parameters.AddWithValue("@EligibleFasi", str);
                    
               
                 
                    cmd.ExecuteNonQuery();
                    
                    con.Close();

                }
            }
        }

        catch (Exception ex)
        {


        }
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }

}
