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
using MKB.TimePicker;
using System.Web.Mail;
using System.Net;

public partial class Module_Scheduler_GatePass_New : System.Web.UI.Page
{
    clsFunctions fun = new clsFunctions();
    string sId = string.Empty;
    int FinYearId = 0;
    int CompId = 0;
    string connStr =string.Empty;
    SqlConnection con;
    string CDate = string.Empty;
    string CTime = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {         
        try
        {
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            FinYearId = Convert.ToInt32(Session["finyear"]);
            CompId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString().Trim();
            CDate = fun.getCurrDate();
            CTime = fun.getCurrTime();            
            if (!IsPostBack)
            {
                this.loaddata();
                this.loadGrid();
                this.FillGrid();
            }

            foreach (GridViewRow grv in GridView2.Rows)
            {

                string id = ((Label)grv.FindControl("lblId1")).Text;
                string sqlInv = fun.select("Authorize", "tblCV_Pass", "  Id='" + id + "' And Authorize='1'  And CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'");
                SqlCommand cmdInv = new SqlCommand(sqlInv, con);
                SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
                DataSet DSInv = new DataSet();
                DAInv.Fill(DSInv);
                if (DSInv.Tables[0].Rows.Count > 0)
                {

                    ((TextBox)grv.FindControl("TxtFeedback")).Visible = true;
                    ((LinkButton)grv.FindControl("LinkButton3")).Visible = false;
                }
                else
                {
                    ((TextBox)grv.FindControl("TxtFeedback")).Visible = false;
                    ((LinkButton)grv.FindControl("LinkButton3")).Visible = true;
                }
                string Did = ((Label)grv.FindControl("lblDId")).Text;
                string sql = fun.select("Feedback", "tblCV_Details", "  MId='" + id + "' And Id='" + Did + "'  ");
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0)
                {
                    if (DS.Tables[0].Rows[0]["Feedback"] != DBNull.Value && DS.Tables[0].Rows[0]["Feedback"].ToString() != "")
                    {
                        ((Label)grv.FindControl("LblFeedback")).Visible = true;
                        ((TextBox)grv.FindControl("TxtFeedback")).Visible = false;
                    }
                    else
                    {
                        ((Label)grv.FindControl("LblFeedback")).Visible = false;
                       
                    }
                }

            }

        }
       catch (Exception ex)
        {
        }

    }
    public void loaddata()
    {
        try
        {
           
            string sqlInv = fun.select("*", "tblCV_Temp", "  EmpId is  null  And SessionId='" + sId + "' And CompId='" + CompId + "'   Order By Id Desc");
            SqlCommand cmdInv = new SqlCommand(sqlInv, con);
            SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
            DataSet DSInv = new DataSet();
            DAInv.Fill(DSInv);
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FromDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FromTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ToTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Place", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ContactPerson", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ContactNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Reason", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeOf", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeFor", typeof(string)));
            if (DSInv.Tables[0].Rows.Count > 0)
            {
                DataRow dr;

                for (int i = 0; i < DSInv.Tables[0].Rows.Count; i++)
                {

                    dr = dt.NewRow();

                    dr[0] = DSInv.Tables[0].Rows[i]["Id"].ToString();
                    dr[1] = fun.FromDate(DSInv.Tables[0].Rows[i]["FromDate"].ToString());
                    dr[2] = DSInv.Tables[0].Rows[i]["FromTime"].ToString();
                    dr[3] = DSInv.Tables[0].Rows[i]["ToTime"].ToString();
                    dr[4] = DSInv.Tables[0].Rows[i]["Place"].ToString();
                    dr[5] = (DSInv.Tables[0].Rows[i]["ContactPerson"].ToString());
                    dr[6] = (DSInv.Tables[0].Rows[i]["ContactNo"].ToString());
                    dr[7] = (DSInv.Tables[0].Rows[i]["Reason"].ToString());

                    string sql = fun.select("*", "tblCV_Reason", "Id='" + DSInv.Tables[0].Rows[i]["Type"].ToString() + "'");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    dr[8] = (DS.Tables[0].Rows[0]["Reason"].ToString());
                    string typof = "";
                    if (DSInv.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
                    {
                        typof = "WONo";
                    }


                    if (DSInv.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
                    {
                        typof = "Enquiry";
                    }
                    if (DSInv.Tables[0].Rows[i]["TypeOf"].ToString() == "3")
                    {
                        typof = "Others";
                    }
                    dr[9] = typof;
                    dr[10] = DSInv.Tables[0].Rows[i]["TypeFor"].ToString();

                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            }
            GridView3.DataSource = dt;
            GridView3.DataBind();

            if (GridView3.Rows.Count == 0)
            {
                ((TextBox)GridView3.Controls[0].Controls[0].FindControl("TxtDate2")).Attributes.Add("readonly", "readonly");
            }
            else
            {
                ((TextBox)GridView3.FooterRow.FindControl("TxtDate1")).Attributes.Add("readonly", "readonly");
            }

        }
        catch (Exception ex)
        {
        }

    }
    public void loadGrid()
    {
      try
        {
            
            string sqlInv = fun.select("*", "tblCV_Temp", " EmpId is  not null And  SessionId='" + sId + "' And CompId='" + CompId + "'   Order By Id Desc");
            SqlCommand cmdInv = new SqlCommand(sqlInv, con); 
            SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
            DataSet DSInv = new DataSet();
            DAInv.Fill(DSInv);
            DataTable dt = new DataTable();            
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FromDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FromTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ToTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Place", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ContactPerson", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ContactNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Reason", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeOf", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeFor", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("EmpId", typeof(string)));
            
            DataRow dr;

                for (int i = 0; i < DSInv.Tables[0].Rows.Count; i++)
                {

                    dr = dt.NewRow();

                    dr[0] = DSInv.Tables[0].Rows[i]["Id"].ToString();
                    dr[1] = fun.FromDate(DSInv.Tables[0].Rows[i]["FromDate"].ToString());
                    dr[2] = DSInv.Tables[0].Rows[i]["FromTime"].ToString();
                    dr[3] = DSInv.Tables[0].Rows[i]["ToTime"].ToString();
                    dr[4] = DSInv.Tables[0].Rows[i]["Place"].ToString();
                    dr[5] = (DSInv.Tables[0].Rows[i]["ContactPerson"].ToString());
                    dr[6] = (DSInv.Tables[0].Rows[i]["ContactNo"].ToString());
                    dr[7] = (DSInv.Tables[0].Rows[i]["Reason"].ToString());

                    string sql = fun.select("*", "tblCV_Reason", "Id='" + DSInv.Tables[0].Rows[i]["Type"].ToString() + "'");
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    dr[8] = (DS.Tables[0].Rows[0]["Reason"].ToString());
                    string typof = "";
                    if (DSInv.Tables[0].Rows[i]["TypeOf"].ToString() == "1")
                    {
                        typof = "WONo";
                    }


                    if (DSInv.Tables[0].Rows[i]["TypeOf"].ToString() == "2")
                    {
                        typof = "Enquiry";
                    }
                    if (DSInv.Tables[0].Rows[i]["TypeOf"].ToString() == "3")
                    {
                        typof = "Others";
                    }
                    dr[9] = typof;
                    dr[10] = DSInv.Tables[0].Rows[i]["TypeFor"].ToString();
                    if (DSInv.Tables[0].Rows[i]["EmpId"] != DBNull.Value)
                    {
                        string StrEmp = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["EmpId"].ToString() + "'And CompId='" + CompId + "'");
                        SqlCommand CmdEmp = new SqlCommand(StrEmp, con);
                        SqlDataAdapter DAEmp = new SqlDataAdapter(CmdEmp);
                        DataSet DSEmp = new DataSet();
                        DAEmp.Fill(DSEmp);

                        dr[11] = DSEmp.Tables[0].Rows[0]["Title"].ToString() + ". " + DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();
                    }

                    else
                    {
                        dr[11] = "";
                    }
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();

                }
            
            GridView1.DataSource = dt;
            GridView1.DataBind();


            if (GridView1.Rows.Count == 0)
            {
                ((TextBox)GridView1.Controls[0].Controls[0].FindControl("TxtDate4")).Attributes.Add("readonly", "readonly");
            }
            else
            {
                ((TextBox)GridView1.FooterRow.FindControl("TxtDate3")).Attributes.Add("readonly", "readonly");
            }
        }
        catch (Exception ex)
        {
        }

    }
    public void FillGrid()
    {
      try
        {
           
            string sqlInv = fun.select("tblCV_pass.Authorize,tblCV_pass.SysDate,tblCV_pass.EmpId As SelfEId,tblCV_pass.Id,tblCV_pass.FinYearId,tblCV_pass.GPNo,tblCV_pass.Authorize,tblCV_pass.AuthorizedBy,tblCV_pass.AuthorizeDate,tblCV_pass.AuthorizeTime,tblCV_Details.FromDate,tblCV_Details.FromTime,tblCV_Details.ToTime,tblCV_Details.Type,tblCV_Details.TypeFor,tblCV_Details.Reason,tblCV_Details.Feedback,tblCV_Details.Id As DId,tblCV_Details.EmpId As OtherEId", "tblCV_pass,tblCV_Details", "tblCV_pass.Id=tblCV_Details.MId And tblCV_pass.SessionId='" + sId + "' And tblCV_Details.Feedback is null AND  tblCV_pass.CompId='" + CompId + "'   Order By tblCV_pass.Id Desc");
            SqlCommand cmdInv = new SqlCommand(sqlInv, con);
            SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
            DataSet DSInv = new DataSet();
            DAInv.Fill(DSInv);
            DataTable dt = new DataTable();

            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("FinYear", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("GPNo", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FromDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("FromTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("ToTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("TypeFor", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Reason", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizedBy", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizeDate", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AuthorizeTime", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Feedback", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("DId", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("SelfEId", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Authorize", typeof(int)));
            dt.Columns.Add(new System.Data.DataColumn("SysDate", typeof(string)));
            if (DSInv.Tables[0].Rows.Count > 0)
            {
                DataRow dr;

                for (int i = 0; i < DSInv.Tables[0].Rows.Count; i++)
                {

                    dr = dt.NewRow();
                    string AuthBy = "";
                    string AuthDate = "";
                    string AuthTime = "";

                    {

                        string sqlFin = fun.select("FinYear", "tblFinancial_master", "CompId='" + CompId + "' AND FinYearId='" + DSInv.Tables[0].Rows[i]["FinYearId"].ToString() + "'");
                        SqlCommand cmdFinYr = new SqlCommand(sqlFin, con);
                        SqlDataAdapter daFin = new SqlDataAdapter(cmdFinYr);
                        DataSet DSFin = new DataSet();
                        daFin.Fill(DSFin);


                        dr[0] = DSInv.Tables[0].Rows[i]["Id"].ToString();
                        dr[1] = DSFin.Tables[0].Rows[0]["FinYear"].ToString();
                        dr[2] = DSInv.Tables[0].Rows[i]["GPNo"].ToString();
                        dr[3] = fun.FromDate(DSInv.Tables[0].Rows[i]["FromDate"].ToString());
                        dr[4] = DSInv.Tables[0].Rows[i]["FromTime"].ToString();
                        dr[5] = DSInv.Tables[0].Rows[i]["ToTime"].ToString();
                        dr[7] = DSInv.Tables[0].Rows[i]["TypeFor"].ToString();

                        dr[8] = (DSInv.Tables[0].Rows[i]["Reason"].ToString());

                        string sql1 = fun.select("*", "tblCV_Reason", "Id='" + DSInv.Tables[0].Rows[i]["Type"].ToString() + "'");
                        SqlCommand cmd1 = new SqlCommand(sql1, con);
                        SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
                        DataSet DS1 = new DataSet();
                        DA1.Fill(DS1);

                        dr[6] = (DS1.Tables[0].Rows[0]["Reason"].ToString());

                        if (Convert.ToInt32(DSInv.Tables[0].Rows[i]["Authorize"]) == 1)
                        {
                            string StrEmp = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["AuthorizedBy"].ToString() + "'And CompId='" + CompId + "'");
                            SqlCommand CmdEmp = new SqlCommand(StrEmp, con);
                            SqlDataAdapter DAEmp = new SqlDataAdapter(CmdEmp);
                            DataSet DSEmp = new DataSet();
                            DAEmp.Fill(DSEmp);


                            AuthBy = DSEmp.Tables[0].Rows[0]["Title"].ToString() + ". " + DSEmp.Tables[0].Rows[0]["EmployeeName"].ToString();
                            AuthDate = fun.FromDateDMY(DSInv.Tables[0].Rows[i]["AuthorizeDate"].ToString());
                            AuthTime = DSInv.Tables[0].Rows[i]["AuthorizeTime"].ToString();

                        }

                        dr[9] = AuthBy;
                        dr[10] = AuthDate;
                        dr[11] = AuthTime;

                        string feed = "";
                        if (DSInv.Tables[0].Rows[i]["Feedback"] != DBNull.Value)
                        {
                            feed = DSInv.Tables[0].Rows[i]["Feedback"].ToString();
                        }
                        dr[12] = DSInv.Tables[0].Rows[i]["Feedback"].ToString();
                        dr[13] = DSInv.Tables[0].Rows[i]["DId"].ToString();

                        string EmpName = "";
                        if (DSInv.Tables[0].Rows[i]["SelfEId"] != DBNull.Value)
                        {
                            string StrEmpSelf = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["SelfEId"].ToString() + "'And CompId='" + CompId + "'");
                            SqlCommand CmdEmpSelf = new SqlCommand(StrEmpSelf, con);
                            SqlDataAdapter DAEmpSelf = new SqlDataAdapter(CmdEmpSelf);
                            DataSet DSEmpSelf = new DataSet();
                            DAEmpSelf.Fill(DSEmpSelf);
                            if (DSEmpSelf.Tables[0].Rows.Count > 0)
                            {
                                EmpName = DSEmpSelf.Tables[0].Rows[0]["Title"].ToString() + ". " + DSEmpSelf.Tables[0].Rows[0]["EmployeeName"].ToString();
                            }
                        }
                        else
                        {
                            string StrOtherEId = fun.select("Title,EmployeeName", "tblHR_OfficeStaff", "EmpId='" + DSInv.Tables[0].Rows[i]["OtherEId"].ToString() + "'And CompId='" + CompId + "'");
                            SqlCommand CmdOtherEId = new SqlCommand(StrOtherEId, con);
                            SqlDataAdapter DAOtherEId = new SqlDataAdapter(CmdOtherEId);
                            DataSet DSOtherEId = new DataSet();
                            DAOtherEId.Fill(DSOtherEId);
                            if (DSOtherEId.Tables[0].Rows.Count > 0)
                            {
                                EmpName = DSOtherEId.Tables[0].Rows[0]["Title"].ToString() + ". " + DSOtherEId.Tables[0].Rows[0]["EmployeeName"].ToString();
                            }

                        }
                        dr[14] = EmpName;
                        dr[16] =fun.FromDateDMY(DSInv.Tables[0].Rows[i]["SysDate"].ToString());
                        dt.Rows.Add(dr);
                        dt.AcceptChanges();
                    }
                }
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
      catch (Exception ex)
        {
        }

    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
       con.Open();
       try
       {

           int i = 0;
           if (e.CommandName == "Submit")
           {

               foreach (GridViewRow grv in GridView2.Rows)
               {
                   string Did = ((Label)grv.FindControl("lblDId")).Text;
                   string id = ((Label)grv.FindControl("lblId1")).Text;

                   string feed = ((TextBox)grv.FindControl("TxtFeedback")).Text;
                   if (feed != "")
                   {
                       string sql3 = fun.update("tblCV_Details", "Feedback='" + feed + "'", " Id ='" + Did + "' AND MId='" + id + "'");

                       SqlCommand cmd3 = new SqlCommand(sql3, con);
                       cmd3.ExecuteNonQuery();

                       i++;
                   }

               }
               if (i > 0)
               {

                   //this.loaddata();
                   //this.loadGrid();
                   //this.FillGrid(); 
                   Page.Response.Redirect(Page.Request.Url.ToString(), true);
                   TabContainer1.ActiveTab = TabContainer1.Tabs[2];
               }


               else
               {
                   string myStringVariable = string.Empty;
                   myStringVariable = "Please fill Feedback.";
                   ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
               }
           }



           if (e.CommandName == "Del3")
           {

               GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

               string Did = ((Label)grv.FindControl("lblDId")).Text;
               string id = ((Label)grv.FindControl("lblId1")).Text;

               SqlCommand cmd = new SqlCommand(fun.delete("tblCV_Details", " Id=" + Did + "    "), con);

               cmd.ExecuteNonQuery();


               string sqlInv = fun.select("*", "tblCV_Details", "MId='" + id + "'");
               SqlCommand cmdInv = new SqlCommand(sqlInv, con);
               SqlDataAdapter DAInv = new SqlDataAdapter(cmdInv);
               DataSet DSInv = new DataSet();
               DAInv.Fill(DSInv);
               if (DSInv.Tables[0].Rows.Count == 0)
               {
                   SqlCommand cmd2 = new SqlCommand(fun.delete("tblCV_pass", " Id=" + id + "    "), con);
                   cmd2.ExecuteNonQuery();

               }

               Page.Response.Redirect(Page.Request.Url.ToString(), true);
               //TabContainer1.ActiveTab = TabContainer1.Tabs[2];

               // this.FillGrid();



           }


           if (e.CommandName == "Print")
           {

               GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

               string Did = ((Label)grv.FindControl("lblDId")).Text;
               string id = ((Label)grv.FindControl("lblId1")).Text;

               string getRandomKey = fun.GetRandomAlphaNumeric();

               Response.Redirect("GatePass_Print.aspx?Id=" + id + "&DId=" + Did + "&Key=" + getRandomKey + "");
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
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        try
        {
            //EmptyDataTemplate
            if (e.CommandName == "add1")
            {
                con.Open();
                GridViewRow grv = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                
                string FromTime = ((TimeSelector)grv.FindControl("TimeSelector3")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector3")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector3")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector3")).AmPm.ToString();
                string ToTime = ((TimeSelector)grv.FindControl("TimeSelector4")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector4")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector4")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector4")).AmPm.ToString();
                string Date = fun.FromDate(((TextBox)grv.FindControl("TxtDate2")).Text);
                string Place = ((TextBox)grv.FindControl("TxtPlace2")).Text;
                string Person = ((TextBox)grv.FindControl("TxtContPerson2")).Text;
                string ContactNo = ((TextBox)grv.FindControl("TxtContNo2")).Text;
                string Reason = ((TextBox)grv.FindControl("TxtReason2")).Text;
                string typ = ((DropDownList)grv.FindControl("DropDownList3")).SelectedValue;
                string tof = ((DropDownList)grv.FindControl("DropDownList4")).SelectedValue;
                string typefor = ((TextBox)grv.FindControl("TxtDetails2")).Text;

                int T = 0;             
                if (tof == "WONo")
                {
                    T = 1;                  
                }
                else if (tof == "Enquiry")
                {
                    T = 2;                    
                }
                else if (tof == "Others")
                {
                    T = 3;                    
                }
                if (((TextBox)grv.FindControl("TxtDate2")).Text!="" && fun.DateValidation(((TextBox)grv.FindControl("TxtDate2")).Text)==true)
                {
                    if (T == 1)
                    {
                        if (typefor != "" && fun.CheckValidWONo(((TextBox)grv.FindControl("TxtDetails2")).Text, CompId, FinYearId)==true)
                        {
                        SqlCommand exeme2 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "'"), con);
                        exeme2.ExecuteNonQuery();
                        con.Close();
                        this.loaddata();
                        TabContainer1.ActiveTab = TabContainer1.Tabs[0];
                        }
                        else
                        {
                            string myStringVariable = string.Empty;
                            myStringVariable = "Invalid WONo.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                        }
                    }
                    else
                    {
                        SqlCommand exeme2 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "'"), con);
                        exeme2.ExecuteNonQuery();
                        con.Close();
                        this.loaddata();
                        TabContainer1.ActiveTab = TabContainer1.Tabs[0];

                    }

                }
            }

            if (e.CommandName == "add")
            {
                con.Open();
                GridViewRow grv = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                string FromTime = ((TimeSelector)grv.FindControl("TimeSelector1")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector1")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector1")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector1")).AmPm.ToString();
                string ToTime = ((TimeSelector)grv.FindControl("TimeSelector2")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector2")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector2")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector2")).AmPm.ToString();
                string Date = fun.FromDate(((TextBox)grv.FindControl("TxtDate1")).Text);
                string Place = ((TextBox)grv.FindControl("TxtPlace1")).Text;
                string Person = ((TextBox)grv.FindControl("TxtContPerson1")).Text;
                string ContactNo = ((TextBox)grv.FindControl("TxtContNo1")).Text;
                string Reason = ((TextBox)grv.FindControl("TxtReason1")).Text;
                string typ = ((DropDownList)grv.FindControl("DropDownList1")).SelectedValue;
                string tof = ((DropDownList)grv.FindControl("DropDownList2")).SelectedValue;
                string typefor = ((TextBox)grv.FindControl("TxtDetails1")).Text;

                int T = 0;              
                if (tof == "WONo")
                {
                    T = 1;                   
                }
                else if (tof == "Enquiry")
                {
                    T = 2;                    
                }
                else if (tof == "Others")
                {
                    T = 3;                   
                }
                if (((TextBox)grv.FindControl("TxtDate1")).Text != "" && fun.DateValidation(((TextBox)grv.FindControl("TxtDate1")).Text) == true)
                {
                    if (T == 1)
                    {
                        if (typefor != "" && fun.CheckValidWONo(((TextBox)grv.FindControl("TxtDetails1")).Text, CompId, FinYearId) == true)
                        {

                            SqlCommand exeme1 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "'"), con);
                            exeme1.ExecuteNonQuery();
                            con.Close();
                            this.loaddata();
                            TabContainer1.ActiveTab = TabContainer1.Tabs[0];
                        }
                        else
                        {
                            string myStringVariable = string.Empty;
                            myStringVariable = "Invalid WONo.";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                        }
                    }
                    else
                    {
                        SqlCommand exeme1 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "'"), con);
                        exeme1.ExecuteNonQuery();
                        con.Close();
                        this.loaddata();
                        TabContainer1.ActiveTab = TabContainer1.Tabs[0];

                    }
                }

            }


            if (e.CommandName == "Del1")
            {
               
                GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                string id = ((Label)grv.FindControl("lblId")).Text;
                SqlCommand cmd = new SqlCommand(fun.delete("tblCV_Temp"," Id=" + id + " And CompId='" + CompId + "'"), con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                this.loaddata();
            }
        }
        catch (Exception ex)
        { }
        
    }    
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {          
               
                string strCategory = ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList3")).SelectedValue;
                string SqlType = fun.select("*", "tblCV_Reason", "Id='" + strCategory + "'");
                SqlCommand CmdType = new SqlCommand(SqlType, con);
                SqlDataAdapter DaType = new SqlDataAdapter(CmdType);
                DataSet DSType = new DataSet();
                DaType.Fill(DSType);
                if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
                {

                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();
                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("WONo");
                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Enquiry");
                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Others");
                }


                if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
                {

                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();

                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("WONo");
                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Others");
                }
                if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
                {

                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();

                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Enquiry");
                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Add("Others");
                }
                if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "0")
                {

                    ((DropDownList)GridView3.Controls[0].Controls[0].FindControl("DropDownList4")).Items.Clear();
                 
                }

                TabContainer1.ActiveTab = TabContainer1.Tabs[0];
        }

        catch (Exception ex)
        {
        }
    }    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {
            

            string strCategory = ((DropDownList)GridView3.FooterRow.FindControl("DropDownList1")).SelectedValue;

            string SqlType = fun.select("*", "tblCV_Reason", "Id='" + strCategory + "'");
            SqlCommand CmdType = new SqlCommand(SqlType, con);
            SqlDataAdapter DaType = new SqlDataAdapter(CmdType);
            DataSet DSType = new DataSet();
            DaType.Fill(DSType);
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();
                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("WONo");
                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Enquiry");
                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Others");
            }


            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();

                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("WONo");
                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Others");
            }
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();

                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Enquiry");
                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Add("Others");
            }
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "0")
            {

                ((DropDownList)GridView3.FooterRow.FindControl("DropDownList2")).Items.Clear();

               
            }
            TabContainer1.ActiveTab = TabContainer1.Tabs[0];
            
        }

        catch (Exception ex)
        {
        }
        
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {

            string strCategory = ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList7")).SelectedValue;
            string SqlType = fun.select("*", "tblCV_Reason", "Id='" + strCategory + "'");
            SqlCommand CmdType = new SqlCommand(SqlType, con);
            SqlDataAdapter DaType = new SqlDataAdapter(CmdType);
            DataSet DSType = new DataSet();
            DaType.Fill(DSType);
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();
                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("WONo");
                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Enquiry");
                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Others");
            }


            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();

                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("WONo");
                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Others");
            }
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();

                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Enquiry");
                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Add("Others");
            }
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "0")
            {

                ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList8")).Items.Clear();

            }
            TabContainer1.ActiveTab = TabContainer1.Tabs[1];
        }

        catch (Exception ex)
        {
        }

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        try
        {
            string strCategory = ((DropDownList)GridView1.FooterRow.FindControl("DropDownList5")).SelectedValue;

            string SqlType = fun.select("*", "tblCV_Reason", "Id='" + strCategory + "'");
            SqlCommand CmdType = new SqlCommand(SqlType, con);
            SqlDataAdapter DaType = new SqlDataAdapter(CmdType);
            DataSet DSType = new DataSet();
            DaType.Fill(DSType);
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();
                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("WONo");
                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Enquiry");
                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Others");
            }


            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "1" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();

                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("WONo");
                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Others");
            }
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "1" && DSType.Tables[0].Rows[0]["Other"].ToString() == "1")
            {

                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();

                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Enquiry");
                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Add("Others");
            }
            if (DSType.Tables[0].Rows[0]["WONo"].ToString() == "0" && DSType.Tables[0].Rows[0]["Enquiry"].ToString() == "0" && DSType.Tables[0].Rows[0]["Other"].ToString() == "0")
            {

                ((DropDownList)GridView1.FooterRow.FindControl("DropDownList6")).Items.Clear();
            }
            TabContainer1.ActiveTab = TabContainer1.Tabs[1];
        }

        catch (Exception ex)
        {
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
        clsFunctions fun = new clsFunctions();
        string connStr = fun.Connection();
        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        int CompId = Convert.ToInt32(HttpContext.Current.Session["compid"]);
        string cmdStr = fun.select("EmpId,EmployeeName", "tblHR_OfficeStaff", "CompId='" + CompId + "'");
        SqlDataAdapter da = new SqlDataAdapter(cmdStr, con);
        da.Fill(ds, "tblHR_OfficeStaff");
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
    protected void BtnFeedback_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        try
        {
            if (e.CommandName == "add3")
            {
                con.Open();
                GridViewRow grv = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string FromTime = ((TimeSelector)grv.FindControl("TimeSelector7")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector7")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector7")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector7")).AmPm.ToString();
                string ToTime = ((TimeSelector)grv.FindControl("TimeSelector8")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector8")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector8")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector8")).AmPm.ToString();
                string Date = fun.FromDate(((TextBox)grv.FindControl("TxtDate4")).Text);
                string Place = ((TextBox)grv.FindControl("TxtPlace4")).Text;
                string Person = ((TextBox)grv.FindControl("TxtContPerson4")).Text;
                string ContactNo = ((TextBox)grv.FindControl("TxtContNo4")).Text;
                string Reason = ((TextBox)grv.FindControl("TxtReason4")).Text;
                string typ = ((DropDownList)grv.FindControl("DropDownList7")).SelectedValue;
                string tof = ((DropDownList)grv.FindControl("DropDownList8")).SelectedValue;
                string typefor = ((TextBox)grv.FindControl("TxtDetails4")).Text;
                string empid = fun.getCode(((TextBox)grv.FindControl("TxtEmp2")).Text);

                int T = 0;
                if (tof == "WONo")
                {
                    T = 1;
                }
                else if (tof == "Enquiry")
                {
                    T = 2;
                }
                else if (tof == "Others")
                {
                    T = 3;
                }

                string StrEmp = fun.select("EmpId", "tblHR_OfficeStaff", "EmpId='" + empid + "'And CompId='" + CompId + "'");
                SqlCommand CmdEmp = new SqlCommand(StrEmp, con);
                SqlDataAdapter DAEmp = new SqlDataAdapter(CmdEmp);
                DataSet DSEmp = new DataSet();
                DAEmp.Fill(DSEmp);
                if (((TextBox)grv.FindControl("TxtDate4")).Text != "" && fun.DateValidation(((TextBox)grv.FindControl("TxtDate4")).Text) == true)
                {
                    if (empid != "" && DSEmp.Tables[0].Rows.Count > 0)
                    {
                        if (T == 1)
                        {
                            if (typefor != "" && fun.CheckValidWONo(((TextBox)grv.FindControl("TxtDetails4")).Text, CompId, FinYearId) == true)
                            {
                                SqlCommand exeme2 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "','" + empid + "'"), con);
                                exeme2.ExecuteNonQuery();
                                con.Close();
                                this.loadGrid();
                                TabContainer1.ActiveTab = TabContainer1.Tabs[1];
                            }
                            else
                            {
                                string myStringVariable = string.Empty;
                                myStringVariable = "Invalid WONo.";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                            }
                        }
                        else
                        {
                            SqlCommand exeme2 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "','" + empid + "'"), con);
                            exeme2.ExecuteNonQuery();
                            con.Close();
                            this.loadGrid();
                            TabContainer1.ActiveTab = TabContainer1.Tabs[1];

                        }
                    }
                    else
                    {
                        string myStringVariable = string.Empty;
                        myStringVariable = "Employee Name is Invalid.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                    }
                }
            }

            if (e.CommandName == "add2")
            {
                con.Open();
                GridViewRow grv = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                string FromTime = ((TimeSelector)grv.FindControl("TimeSelector5")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector5")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector5")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector5")).AmPm.ToString();
                string ToTime = ((TimeSelector)grv.FindControl("TimeSelector6")).Hour.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector6")).Minute.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector6")).Second.ToString("D2") + ":" + ((TimeSelector)grv.FindControl("TimeSelector6")).AmPm.ToString();
                string Date = fun.FromDate(((TextBox)grv.FindControl("TxtDate3")).Text);
                string Place = ((TextBox)grv.FindControl("TxtPlace3")).Text;
                string Person = ((TextBox)grv.FindControl("TxtContPerson3")).Text;
                string ContactNo = ((TextBox)grv.FindControl("TxtContNo3")).Text;
                string Reason = ((TextBox)grv.FindControl("TxtReason3")).Text;
                string typ = ((DropDownList)grv.FindControl("DropDownList5")).SelectedValue;
                string tof = ((DropDownList)grv.FindControl("DropDownList6")).SelectedValue;
                string typefor = ((TextBox)grv.FindControl("TxtDetails3")).Text;
                string empid = fun.getCode(((TextBox)grv.FindControl("TxtEmp1")).Text);

                int T = 0;              
                if (tof == "WONo")
                {
                    T = 1;
                }
                else if (tof == "Enquiry")
                {
                    T = 2;
                }
                else if (tof == "Others")
                {
                    T = 3;
                }

                string StrEmp = fun.select("EmpId", "tblHR_OfficeStaff", "EmpId='" + empid + "'And CompId='" + CompId + "'");
                SqlCommand CmdEmp = new SqlCommand(StrEmp, con);
                SqlDataAdapter DAEmp = new SqlDataAdapter(CmdEmp);
                DataSet DSEmp = new DataSet();
                DAEmp.Fill(DSEmp);
                if (((TextBox)grv.FindControl("TxtDate3")).Text != "" && fun.DateValidation(((TextBox)grv.FindControl("TxtDate3")).Text) == true)
                {
                    if (empid != "" && DSEmp.Tables[0].Rows.Count > 0)
                    {
                        if (T == 1)
                        {
                            if (typefor != "" && fun.CheckValidWONo(((TextBox)grv.FindControl("TxtDetails3")).Text, CompId, FinYearId) == true)
                            {
                                SqlCommand exeme1 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "','" + empid + "'"), con);
                                exeme1.ExecuteNonQuery();
                                con.Close();
                                this.loadGrid();
                                TabContainer1.ActiveTab = TabContainer1.Tabs[1];
                            }
                            else
                            {
                                string myStringVariable = string.Empty;
                                myStringVariable = "Invalid WONo.";
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                            }
                        }
                        else
                        {
                            SqlCommand exeme1 = new SqlCommand(fun.insert("tblCV_Temp", "SessionId,CompId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + sId + "','" + CompId + "','" + Date + "','" + FromTime + "','" + ToTime + "','" + Place + "','" + Person + "','" + ContactNo + "','" + Reason + "','" + typ + "','" + T + "','" + typefor + "','" + empid + "'"), con);
                            exeme1.ExecuteNonQuery();
                            con.Close();
                            this.loadGrid();
                            TabContainer1.ActiveTab = TabContainer1.Tabs[1];
                        }
                    }
                    else
                    {
                        string myStringVariable = string.Empty;
                        myStringVariable = "Employee Name is Invalid.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                    }
                }

            }


            if (e.CommandName == "Del2")
            {
               
                GridViewRow grv = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

                string id = ((Label)grv.FindControl("lblId")).Text;
                SqlCommand cmd = new SqlCommand(fun.delete("tblCV_Temp", " Id=" + id + " And CompId='" + CompId + "'"), con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                this.loadGrid();


            }

        }
      catch (Exception ex)
        { }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        //new        
        try
        {
            string MId = "";
            string sqlGqn = fun.select("GPNo", "tblCV_pass", "CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GPNo desc");
            SqlCommand cmdGqn = new SqlCommand(sqlGqn, con);
            SqlDataAdapter daGqn = new SqlDataAdapter(cmdGqn);
            DataSet DSGqn = new DataSet();

            daGqn.Fill(DSGqn, "tblCV_pass");

            string Gpno = "";
            string EmpSessionName = string.Empty;
            if (DSGqn.Tables[0].Rows.Count > 0)
            {
                int GPtemp = Convert.ToInt32(DSGqn.Tables[0].Rows[0][0].ToString()) + 1;
                Gpno = GPtemp.ToString("D4");
            }
            else
            {
                Gpno = "0001";
            }
            string sql5 = fun.select("*", "tblCV_Temp", " EmpId is null And  CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {
                con.Open();

                string StrAdd = fun.insert("tblCV_pass", "SysDate,SysTime,CompId,FinYearId,SessionId,EmpId,GPNo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + sId + "','" + Gpno + "'");
                SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
                cmdAdd.ExecuteNonQuery();

                string sqlmid = fun.select("Id", "tblCV_pass", "CompId='" + CompId + "' Order by Id desc");
                SqlCommand cmdmid = new SqlCommand(sqlmid, con);
                SqlDataAdapter damid = new SqlDataAdapter(cmdmid);
                DataSet DSmid = new DataSet();
                damid.Fill(DSmid, "tblCV_pass");

                MId = DSmid.Tables[0].Rows[0]["Id"].ToString();
                int srNo = 0;
                string SR = string.Empty;
                string EmailGp = string.Empty;
                string EmailGpDate = string.Empty;
                string EmailGpFT = string.Empty;
                string EmailGpTT = string.Empty;
                string EmailGpPlace = string.Empty;
                string EmailGpContPerson = string.Empty;
                string EmailGpContNo = string.Empty;
                string EmailGpReason = string.Empty;
                for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                {

                    string sql2 = "";
                    sql2 = fun.select("Title+'.'+EmployeeName As EmpName,Symbol", "tblHR_OfficeStaff,BusinessGroup", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   EmpId='" + sId + "' And BusinessGroup.Id=tblHR_OfficeStaff.BGGroup");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                    DataSet DS2 = new DataSet();
                    DA2.Fill(DS2);
                    if (DS2.Tables[0].Rows.Count > 0)
                    {
                        EmpSessionName = DS2.Tables[0].Rows[0][0].ToString() + '[' + DS2.Tables[0].Rows[0][1].ToString() + ']' + "<br>" + EmpSessionName;
                        srNo++;
                        SR = srNo.ToString() + "<br>" + SR;
                        EmailGp = Gpno + "<br>" + Gpno;

                    }
                    EmailGpDate = fun.FromDateDMY(DS5.Tables[0].Rows[p]["FromDate"].ToString()) + "<br>" + EmailGpDate;
                    EmailGpFT = DS5.Tables[0].Rows[p]["FromTime"].ToString() + "<br>" + EmailGpFT;
                    EmailGpTT = DS5.Tables[0].Rows[p]["ToTime"].ToString() + "<br>" + EmailGpTT;
                    EmailGpPlace = DS5.Tables[0].Rows[p]["Place"].ToString() + "<br>" + EmailGpPlace;
                    EmailGpContPerson = DS5.Tables[0].Rows[p]["ContactPerson"].ToString() + "<br>" + EmailGpContPerson;
                    EmailGpContNo = DS5.Tables[0].Rows[p]["ContactNo"].ToString() + "<br>" + EmailGpContNo;
                    EmailGpReason = DS5.Tables[0].Rows[p]["Reason"].ToString() + "<br>" + EmailGpReason;
                    SqlCommand exeme2 = new SqlCommand(fun.insert("tblCV_Details", "MId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor", "'" + MId + "','" + DS5.Tables[0].Rows[p]["FromDate"].ToString() + "','" + DS5.Tables[0].Rows[p]["FromTime"].ToString() + "','" + DS5.Tables[0].Rows[p]["ToTime"].ToString() + "','" + DS5.Tables[0].Rows[p]["Place"].ToString() + "','" + DS5.Tables[0].Rows[p]["ContactPerson"].ToString() + "','" + DS5.Tables[0].Rows[p]["ContactNo"].ToString() + "','" + DS5.Tables[0].Rows[p]["Reason"].ToString() + "','" + DS5.Tables[0].Rows[p]["Type"].ToString() + "','" + DS5.Tables[0].Rows[p]["TypeOf"].ToString() + "','" + DS5.Tables[0].Rows[p]["TypeFor"].ToString() + "'"), con);
                    exeme2.ExecuteNonQuery();

                }

                string delsql = fun.delete("tblCV_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And EmpId is  null");
                SqlCommand cmd12 = new SqlCommand(delsql, con);
                cmd12.ExecuteNonQuery();

                //// Send Mail
                //MailMessage msg = new MailMessage();
                //string ErpMail = "";
                //string EmailId = string.Empty;
                //string sql = "";
                //sql = fun.select("EmailId1", "tblHR_OfficeStaff", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   UserId=(select DeptHead From tblHR_OfficeStaff where EmpId ='" + sId + "' ) ");
                //SqlCommand cmd = new SqlCommand(sql, con);
                //SqlDataAdapter DA = new SqlDataAdapter(cmd);
                //DataSet DS = new DataSet();
                //DA.Fill(DS);
                //if (DS.Tables[0].Rows.Count > 0)
                //{
                //    EmailId = DS.Tables[0].Rows[0]["EmailId1"].ToString();
                //}

                //string sqlmailserverip = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
                //SqlCommand cmd4 = new SqlCommand(sqlmailserverip, con);
                //SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                //DataSet ds4 = new DataSet();
                //da4.Fill(ds4);
                //if (ds4.Tables[0].Rows.Count > 0)
                //{
                //    SmtpMail.SmtpServer = ds4.Tables[0].Rows[0]["MailServerIp"].ToString();
                //    ErpMail = ds4.Tables[0].Rows[0]["ErpSysmail"].ToString();
                //}
                //msg.From = ErpMail;
                //msg.To = EmailId;
                //msg.Subject = "Gate Pass";
                //msg.Body = "<table width='100%' border='1'><tr align='center'><td align='center'> Sr.No</td> <td align='center'> Gate Pass No</td> <td align='center'>Employee Name</td><td align='center'>Date</td><td align='center'>From Time</td><td align='center'>To Time</td><td align='center'>Place</td><td align='center'>Contact Person</td><td align='center'>Contact No</td><td align='center'>Reason</td></tr><tr><td>" + SR + "</td><td>" + EmailGp + "</td><td>" + EmpSessionName + "</td><td>" + EmailGpDate + "</td><td>" + EmailGpFT + "</td><td>" + EmailGpTT + "</td><td>" + EmailGpPlace + "</td><td>" + EmailGpContPerson + "</td><td>" + EmailGpContNo + "</td><td>" + EmailGpReason + "</td></tr></table><br><br><br>Please Authorize it.<br><br>This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
                //msg.BodyFormat = MailFormat.Html;
                //SmtpMail.Send(msg);               

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                //this.loaddata();
                //this.FillGrid();              
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "Please click on Add button.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
        }
        catch (Exception ec)
        {
        }
        finally
        {
            con.Close();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //other        
        try
        {
            string MId = "";
            string sqlGqn = fun.select("GPNo", "tblCV_pass", "  CompId='" + CompId + "' AND FinYearId='" + FinYearId + "' Order by GPNo desc");
            SqlCommand cmdGqn = new SqlCommand(sqlGqn, con);
            SqlDataAdapter daGqn = new SqlDataAdapter(cmdGqn);
            DataSet DSGqn = new DataSet();
            daGqn.Fill(DSGqn, "tblCV_pass");
            string Gpno = "";
            if (DSGqn.Tables[0].Rows.Count > 0)
            {
                int GPtemp = Convert.ToInt32(DSGqn.Tables[0].Rows[0][0].ToString()) + 1;
                Gpno = GPtemp.ToString("D4");
            }
            else
            {
                Gpno = "0001";
            }
            string sql5 = fun.select("*", "tblCV_Temp", " EmpId is not  null And   CompId='" + CompId + "' AND SessionId='" + sId + "'");
            SqlCommand cmd5 = new SqlCommand(sql5, con);
            SqlDataAdapter da5 = new SqlDataAdapter(cmd5);
            DataSet DS5 = new DataSet();
            da5.Fill(DS5);

            if (DS5.Tables[0].Rows.Count > 0)
            {

                con.Open();
                string StrAdd = fun.insert("tblCV_pass", "SysDate,SysTime,CompId,FinYearId,SessionId,GPNo", "'" + CDate + "','" + CTime + "','" + CompId + "','" + FinYearId + "','" + sId + "','" + Gpno + "'");
                SqlCommand cmdAdd = new SqlCommand(StrAdd, con);
                cmdAdd.ExecuteNonQuery();
                string sqlmid = fun.select("Id", "tblCV_pass", "CompId='" + CompId + "' Order by Id desc");
                SqlCommand cmdmid = new SqlCommand(sqlmid, con);
                SqlDataAdapter damid = new SqlDataAdapter(cmdmid);
                DataSet DSmid = new DataSet();
                damid.Fill(DSmid, "tblCV_pass");
                MId = DSmid.Tables[0].Rows[0]["Id"].ToString();
                string EmpSessionName = string.Empty;
                int srNo = 0;
                string SR = string.Empty;
                string EmailGp = string.Empty;
                string EmailGpDate = string.Empty;
                string EmailGpFT = string.Empty;
                string EmailGpTT = string.Empty;
                string EmailGpPlace = string.Empty;
                string EmailGpContPerson = string.Empty;
                string EmailGpContNo = string.Empty;
                string EmailGpReason = string.Empty;
                for (int p = 0; p < DS5.Tables[0].Rows.Count; p++)
                {

                    SqlCommand exeme2 = new SqlCommand(fun.insert("tblCV_Details", "MId,FromDate,FromTime,ToTime,Place,ContactPerson,ContactNo,Reason,Type,TypeOf,TypeFor,EmpId", "'" + MId + "','" + DS5.Tables[0].Rows[p]["FromDate"].ToString() + "','" + DS5.Tables[0].Rows[p]["FromTime"].ToString() + "','" + DS5.Tables[0].Rows[p]["ToTime"].ToString() + "','" + DS5.Tables[0].Rows[p]["Place"].ToString() + "','" + DS5.Tables[0].Rows[p]["ContactPerson"].ToString() + "','" + DS5.Tables[0].Rows[p]["ContactNo"].ToString() + "','" + DS5.Tables[0].Rows[p]["Reason"].ToString() + "','" + DS5.Tables[0].Rows[p]["Type"].ToString() + "','" + DS5.Tables[0].Rows[p]["TypeOf"].ToString() + "','" + DS5.Tables[0].Rows[p]["TypeFor"].ToString() + "','" + DS5.Tables[0].Rows[p]["EmpId"].ToString() + "'"), con);
                    exeme2.ExecuteNonQuery();                 
                   
                    string sql2 = "";
                    sql2 = fun.select("Title+'.'+EmployeeName As EmpName,Symbol", "tblHR_OfficeStaff,BusinessGroup", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   EmpId='" + DS5.Tables[0].Rows[p]["EmpId"].ToString() + "' And BusinessGroup.Id=tblHR_OfficeStaff.BGGroup");
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                    DataSet DS2 = new DataSet();
                    DA2.Fill(DS2);
                    if (DS2.Tables[0].Rows.Count > 0)
                    {                       
                        EmpSessionName = DS2.Tables[0].Rows[0][0].ToString() + '[' + DS2.Tables[0].Rows[0][1].ToString() + ']' + "<br>" + EmpSessionName;
                        srNo++;
                        SR = srNo.ToString() + "<br>" + SR;
                        EmailGp = Gpno + "<br>" + Gpno; 
                    }

                    EmailGpDate = fun.FromDateDMY(DS5.Tables[0].Rows[p]["FromDate"].ToString()) + "<br>" + EmailGpDate;
                    EmailGpFT = DS5.Tables[0].Rows[p]["FromTime"].ToString() + "<br>" + EmailGpFT;
                    EmailGpTT = DS5.Tables[0].Rows[p]["ToTime"].ToString() + "<br>" + EmailGpTT;
                    EmailGpPlace = DS5.Tables[0].Rows[p]["Place"].ToString() + "<br>" + EmailGpPlace;
                    EmailGpContPerson = DS5.Tables[0].Rows[p]["ContactPerson"].ToString() + "<br>" + EmailGpContPerson;
                    EmailGpContNo = DS5.Tables[0].Rows[p]["ContactNo"].ToString() + "<br>" + EmailGpContNo;
                    EmailGpReason = DS5.Tables[0].Rows[p]["Reason"].ToString() + "<br>" + EmailGpReason;
                }
                string delsql = fun.delete("tblCV_Temp", "CompId='" + CompId + "' AND SessionId='" + sId + "' And EmpId is not null ");
                SqlCommand cmd12 = new SqlCommand(delsql, con);
                cmd12.ExecuteNonQuery();

                // Send Mail
                //MailMessage msg = new MailMessage();
                //string ErpMail = "";
                //string EmailId = string.Empty;
                //string BgGroupName = string.Empty;
                //string sql21 = "";
                //sql21 = fun.select("Title+'.'+EmployeeName As EmpName,Symbol", "tblHR_OfficeStaff,BusinessGroup", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   EmpId='" + sId + "' And BusinessGroup.Id=tblHR_OfficeStaff.BGGroup");
                //SqlCommand cmd21 = new SqlCommand(sql21, con);
                //SqlDataAdapter DA21 = new SqlDataAdapter(cmd21);
                //DataSet DS21 = new DataSet();
                //DA21.Fill(DS21);
                //if (DS21.Tables[0].Rows.Count > 0)
                //{                     
                //    BgGroupName =DS21.Tables[0].Rows[0][0].ToString()+'['+DS21.Tables[0].Rows[0][1].ToString()+']';
                //}
                //string sql = "";
                //sql = fun.select("EmailId1", "tblHR_OfficeStaff", " CompId='" + CompId + "' And FinYearId<='" + FinYearId + "'   And   UserId=(select DeptHead From tblHR_OfficeStaff where EmpId ='" + sId + "')");
                //SqlCommand cmd = new SqlCommand(sql, con);
                //SqlDataAdapter DA = new SqlDataAdapter(cmd);
                //DataSet DS = new DataSet();
                //DA.Fill(DS);
                //if (DS.Tables[0].Rows.Count > 0)
                //{
                //    EmailId = DS.Tables[0].Rows[0]["EmailId1"].ToString();
                //    string sqlmailserverip = fun.select("MailServerIp,ErpSysmail", "tblCompany_master", "CompId = '" + CompId + "'");
                //    SqlCommand cmd4 = new SqlCommand(sqlmailserverip, con);
                //    SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                //    DataSet ds4 = new DataSet();
                //    da4.Fill(ds4);
                //    if (ds4.Tables[0].Rows.Count > 0)
                //    {
                //        SmtpMail.SmtpServer = ds4.Tables[0].Rows[0]["MailServerIp"].ToString();
                //        ErpMail = ds4.Tables[0].Rows[0]["ErpSysmail"].ToString();
                //    }
                //    msg.From = ErpMail;
                //    msg.To = EmailId;                    
                //    msg.Subject = "Gate Pass";
                //    msg.Body = " Gate Pass No." + Gpno + " is generated by " + BgGroupName + " for:<br><br><table width='100%' border='1'><tr align='center'><td align='center'> Sr.No</td> <td align='center'> Gate Pass No</td> <td align='center'>Employee Name</td><td align='center'>Date</td><td align='center'>From Time</td><td align='center'>To Time</td><td align='center'>Place</td><td align='center'>Contact Person</td><td align='center'>Contact No</td><td align='center'>Reason</td></tr><tr><td>" + SR + "</td><td>" + EmailGp + "</td><td>" + EmpSessionName + "</td><td>" + EmailGpDate + "</td><td>" + EmailGpFT + "</td><td>" + EmailGpTT + "</td><td>" + EmailGpPlace + "</td><td>" + EmailGpContPerson + "</td><td>" + EmailGpContNo + "</td><td>" + EmailGpReason + "</td></tr></table><br><br>Please Authorize it.<br><br>This is Auto generated mail by ERP system, please do not reply.<br><br> Thank you.";
                //    msg.BodyFormat = MailFormat.Html;
                //    SmtpMail.Send(msg);

                //}
                Page.Response.Redirect(Page.Request.Url.ToString(), true);                
            }
            else
            {
                string myStringVariable = string.Empty;
                myStringVariable = "please click Add button.";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }

        }
        catch (Exception ec)
        {
        } 
        finally
        {
            con.Close();
        }

    }
}
