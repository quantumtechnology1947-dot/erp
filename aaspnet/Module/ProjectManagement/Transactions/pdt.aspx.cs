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
using System.Text;

public partial class Module_MaterialPlanning_Transactions_pdt : System.Web.UI.Page
{
    string wono = "";
    string sId = "";
    int CompId = 0;
    int FinYearId = 0;
    string WomfDate = "";
    clsFunctions fun = new clsFunctions();
    string connStr = "";
    SqlConnection con;
    SqlCommand cmd1;
    string SupplierName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblreportdate.Text  = DateTime.Today.ToString("dd/MM/yyyy");
        

        Display();
        try
        {
            CompId = Convert.ToInt32(Session["compid"]);
            sId = Session["username"].ToString();
            connStr = fun.Connection();
            con = new SqlConnection(connStr);
            wono = Request.QueryString["WONo"].ToString();
            FinYearId = Convert.ToInt32(Session["finyear"]);
            lblWono.Text = wono;
          

            if (!Page.IsPostBack)
            {


                string sql2 = fun.select("*", "tblMP_Material_Detail_Temp", "SessionId='" + sId + "'");
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlDataAdapter DA2 = new SqlDataAdapter(cmd2);
                DataSet DS2 = new DataSet();
                DA2.Fill(DS2);
                for (int i = 0; i < DS2.Tables[0].Rows.Count; i++)
                {

                    string StrTemp2 = "delete from tblMP_Material_Process_Temp where DMid='" + DS2.Tables[0].Rows[i]["Id"].ToString() + "' ";
                    SqlCommand cmdTemp2 = new SqlCommand(StrTemp2, con);
                    con.Open();
                    cmdTemp2.ExecuteNonQuery();
                    con.Close();

                    string StrTemp3 = "delete from tblMP_Material_RawMaterial_Temp where DMid='" + DS2.Tables[0].Rows[i]["Id"].ToString() + "' ";
                    SqlCommand cmdTemp3 = new SqlCommand(StrTemp3, con);
                    con.Open();
                    cmdTemp3.ExecuteNonQuery();
                    con.Close();

                    string StrTemp4 = "delete from tblMP_Material_Finish_Temp where DMid='" + DS2.Tables[0].Rows[i]["Id"].ToString() + "' ";
                    SqlCommand cmdTemp4 = new SqlCommand(StrTemp4, con);
                    con.Open();
                    cmdTemp4.ExecuteNonQuery();
                    con.Close();

                }

                string StrTemp5 = "delete from tblMP_Material_Detail_Temp where SessionId='" + sId + "' ";
                SqlCommand cmdTemp5 = new SqlCommand(StrTemp5, con);
                con.Open();
                cmdTemp5.ExecuteNonQuery();
                con.Close();
                this.MP_GRID(wono, CompId, SearchGridView1, FinYearId, " And tblDG_Item_Master.CId is null");
               // this.GridColour();
            }

        

        }

        catch (Exception ex) { }
    }
    protected void SearchGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SearchGridView1.PageIndex = e.NewPageIndex;
        try
        {
            this.MP_GRID(wono, CompId, SearchGridView1, FinYearId, " And tblDG_Item_Master.CId is null");
        }
        catch (Exception ex) { }

    }
    public void GridColour()
    {

        try
        {
            foreach (GridViewRow grv in SearchGridView1.Rows)
            {
                CheckBox chkitems = (grv.Cells[0].FindControl("chkitems") as CheckBox);
               if (chkitems.Checked)
            
                {
                    grv.BackColor = System.Drawing.Color.Pink;
                }
                else
                {
                    grv.BackColor = System.Drawing.Color.Transparent;
                }

            }
        }
        catch (Exception ex)
        {
        }
    }    

    ///// For New Report No./////
    public void Display()
    {
        string conStr = ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString;
        using (SqlConnection cnz = new SqlConnection(conStr))
        {

           
            SqlCommand cmdzs = new SqlCommand("SELECT MAX((PRJCTNO) + 1) as PRJCTNO FROM tblPM_Project_Site_MasterD ", cnz);
            cmdzs.CommandType = CommandType.Text;
            cnz.Open();
            lblreport.Text = cmdzs.ExecuteScalar().ToString();
        }

    }

    ///// Adding selected checkboxes in Temp//////


    protected void Selected_chk_Changed(object sender, EventArgs e)
    {
        foreach (GridViewRow grv in SearchGridView1.Rows)
        {
            CheckBox chkitems = (grv.Cells[0].FindControl("chkitems") as CheckBox);

            TextBox txtdesign1 = (grv.Cells[5].FindControl("txtdesign") as TextBox);
            TextBox txtmanf1 = (grv.Cells[6].FindControl("txtmanf") as TextBox);
            TextBox txtbop1 = (grv.Cells[7].FindControl("txtbop") as TextBox);
            DropDownList drpassemly = (grv.Cells[8].FindControl("drpassemly") as DropDownList);
            TextBox txthrs = (grv.Cells[9].FindControl("txthrs") as TextBox);

            if (chkitems.Checked)
            {


                grv.BackColor = System.Drawing.Color.Pink;

                txtdesign1.Visible = true;
                txtmanf1.Visible = true;
                txtbop1.Visible = true;
                drpassemly.Visible = true;
                txthrs.Visible = true;

            }

            else
            {
                txtdesign1.Visible = false;
                txtmanf1.Visible = false;
                txtbop1.Visible = false;
                drpassemly.Visible = false;
                txthrs.Visible = false;

            }
        }

    }




    protected void Button1_Click(object sender, EventArgs e)
    {

        con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);
        con.Open();

        int i;
        foreach (GridViewRow grv in SearchGridView1.Rows)
        {
            string lblitemcode = (grv.FindControl("lblitemcode") as Label).Text;
            string lblDesc = (grv.FindControl("lblDesc") as Label).Text;
            string lbluombasic = (grv.FindControl("lbluombasic") as Label).Text;
            string lblbomqty = (grv.FindControl("lblbomqty") as Label).Text;
            string txtdesign = (grv.FindControl("txtdesign") as TextBox).Text;
            string txtmanf = (grv.FindControl("txtmanf") as TextBox).Text;
            string txtbop = (grv.FindControl("txtbop") as TextBox).Text;
            string txthrs = (grv.FindControl("txthrs") as TextBox).Text;
            DropDownList drpassemly =(grv.FindControl("drpassemly") as DropDownList);

            CheckBox chkitems = (grv.Cells[0].FindControl("chkitems") as CheckBox);
           
            //TextBox txtdesign1 = (grv.Cells[5].FindControl("txtdesign") as TextBox);
            //TextBox txtmanf1 = (grv.Cells[6].FindControl("txtmanf") as TextBox);
            //TextBox txtbop1 = (grv.Cells[7].FindControl("txtbop") as TextBox);
           // TextBox drpassemly = (grv.Cells[5].FindControl("drpassemly") as TextBox);
           // TextBox txtdesign1 = (grv.Cells[5].FindControl("txtdesign") as TextBox);

            if (chkitems.Checked)
            {


                grv.BackColor = System.Drawing.Color.Pink;

                //txtdesign1.Visible = true;
                //txtmanf1.Visible = true;
                //txtbop1.Visible = true;
                //drpassemly.Visible = true;


                cmd1 = new SqlCommand("INSERT INTO tblPM_Project_Site_Master_Detail(PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Design,Manf,BOP ,Assemly,Hrs) values(@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Design,@Manf,@BOP ,@Assemly,@Hrs)", con);
                cmd1.Parameters.AddWithValue("@ItemCode", lblitemcode);
                cmd1.Parameters.AddWithValue("@Description", lblDesc);
                cmd1.Parameters.AddWithValue("@UOM", lbluombasic);
                cmd1.Parameters.AddWithValue("@BOMQ", lblbomqty);
                cmd1.Parameters.AddWithValue("@Design", txtdesign);
                cmd1.Parameters.AddWithValue("@Manf", txtmanf);
                cmd1.Parameters.AddWithValue("@BOP", txtbop);
                cmd1.Parameters.AddWithValue("@Assemly", drpassemly.SelectedItem.Text);
                cmd1.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
                cmd1.Parameters.AddWithValue("@WONo", lblWono.Text);
                cmd1.Parameters.AddWithValue("@Hrs", txthrs);
                //  cmd1.CommandType = CommandType.Text;
                cmd1.ExecuteNonQuery();

            }
            //else
            //{
            //    txtdesign1.Visible = false;
            //    txtmanf1.Visible = false;
            //    txtbop1.Visible = false;
            //    drpassemly.Visible = false;


            //}
        }
        con.Close();
    }

   

    protected void Button_Submit_Click(object sender, EventArgs e)
    {

        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

            string CDate = fun.getCurrDate();
            string CTime = fun.getCurrTime();

            string sqlStatment = "INSERT INTO tblPM_Project_Site_MasterD(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,GenDate) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@GenDate)";
           // string sqlStatment = "INSERT INTO tblPM_Project_Site_Master(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Design,Manf,BOP,Assemly) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Design,@Manf,@BOP,@Assemly)";
            {
                using (SqlCommand cmds = new SqlCommand(sqlStatment, con))
                {
                    cmds.Parameters.AddWithValue("@SysDate", CDate.ToString());
                    cmds.Parameters.AddWithValue("@SysTime", CTime.ToString());
                    cmds.Parameters.AddWithValue("@CompId", CompId);
                    cmds.Parameters.AddWithValue("@SessionId", sId.ToString());
                    cmds.Parameters.AddWithValue("@FinYearId", FinYearId);
                    cmds.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
                    cmds.Parameters.AddWithValue("@WONo", lblWono.Text);
                    cmds.Parameters.AddWithValue("@GenDate", lblreportdate.Text);
                    con.Open();
                    cmds.ExecuteNonQuery();
                  
                    con.Close();
                    Response.Redirect("~/Module/ProjectManagement/Transactions/Planning_New.aspx?ModId=7&SubModId=152", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    //protected void Button_Submit_Click(object sender, EventArgs e)
    //{
    //    string Item = string.Empty;
    //    string Desc = string.Empty;
    //    string Qty = string.Empty;
    //    string hsn = string.Empty;
    //    string r = string.Empty;
    //    string amt = string.Empty;
    //    string uom = string.Empty;
    //    string assmly = string.Empty;

    //    foreach (GridViewRow row in this.SearchGridView1.Rows)
    //    {
    //        Item = row.Cells[3].Text.ToString();
    //        Desc = row.Cells[4].Text.ToString();
    //        hsn = row.Cells[5].Text.ToString();
    //        Qty = row.Cells[6].Text.ToString();
    //        r = row.Cells[7].Text.ToString();
    //        amt = row.Cells[8].Text.ToString();
    //        uom = row.Cells[9].Text.ToString();
    //        assmly = row.Cells[10].Text.ToString();

    //        this.Save(Item, Desc, hsn, Qty, r, amt, uom, assmly);
    //    }
    //    //MessageBox.Show("Data Added");
    //    //clear();
    //    Response.Redirect("Planning_New.aspx", true);

    //}

    //protected void Save(string Item, string Desc, string hsn, string Qty, string r, string amt, string uom, string assemly)
    //{


    //    try
    //    {

    //        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlserver"].ConnectionString);

    //        string CDate = fun.getCurrDate();
    //        string CTime = fun.getCurrTime();

    //        //string sqlStatment = "INSERT INTO tblPM_Project_Site_MasterD(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo)";
    //         string sqlStatment = "INSERT INTO tblPM_Project_Site_Master(SysDate,SysTime,CompId,SessionId,FinYearId,PRJCTNO,WONo,ItemCode,Description,UOM,BOMQ,Design,Manf,BOP,Assemly) VALUES(@SysDate,@SysTime,@CompId,@SessionId,@FinYearId,@PRJCTNO,@WONo,@ItemCode,@Description,@UOM,@BOMQ,@Design,@Manf,@BOP,@Assemly)";
    //        {
    //            using (SqlCommand cmds = new SqlCommand(sqlStatment, con))
    //            {
    //                foreach (GridViewRow grv1 in SearchGridView1.Rows)
    //                {

    //                    // GridView grv = new GridView();

                        

    //                    string lblitemcode = (grv.FindControl("lblitemcode") as Label).Text;
    //                    string lblDesc = (grv.FindControl("lblDesc") as Label).Text;
    //                    string lbluombasic = (grv.FindControl("lbluombasic") as Label).Text;
    //                    string lblbomqty = (grv.FindControl("lblbomqty") as Label).Text;
    //                    string txtdesign = (grv.FindControl("txtdesign") as TextBox).Text;
    //                    string txtmanf = (grv.FindControl("txtmanf") as TextBox).Text;
    //                    string txtbop = (grv.FindControl("txtbop") as TextBox).Text;
    //                    string txtassemly = (grv.FindControl("txtassemly") as TextBox).Text;

    //                    cmds.Parameters.AddWithValue("@SysDate", CDate.ToString());
    //                    cmds.Parameters.AddWithValue("@SysTime", CTime.ToString());
    //                    cmds.Parameters.AddWithValue("@CompId", CompId);
    //                    cmds.Parameters.AddWithValue("@SessionId", sId.ToString());
    //                    cmds.Parameters.AddWithValue("@FinYearId", FinYearId);
    //                    cmds.Parameters.AddWithValue("@PRJCTNO", lblreport.Text);
    //                    cmds.Parameters.AddWithValue("@WONo", lblWono.Text);
    //                    cmds.Parameters.AddWithValue("@ItemCode", lblitemcode);
    //                    cmds.Parameters.AddWithValue("@Description", lblDesc);
    //                    cmds.Parameters.AddWithValue("@UOM", lbluombasic);
    //                    cmds.Parameters.AddWithValue("@BOMQ", lblbomqty);
    //                    cmds.Parameters.AddWithValue("@Design", txtdesign);
    //                    cmds.Parameters.AddWithValue("@Manf", txtmanf);
    //                    cmds.Parameters.AddWithValue("@BOP", txtbop);
    //                    cmds.Parameters.AddWithValue("@Assemly", txtassemly);

    //                    con.Open();
    //                    cmds.ExecuteNonQuery();
    //                     GSTAMount();
    //                    con.Close();


    //                }

    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //}


    



    protected void SearchGridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int itemId = 0;
            double BomQty = 0;
            string ItemCode = ((LinkButton)row.FindControl("btnCode")).Text;
            BomQty = Convert.ToDouble(((Label)row.FindControl("lblbomqty")).Text);
            itemId = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
            if (e.CommandName == "Show")
            {


                string Sql = "SELECT ItemId FROM tblMP_Material_Detail_Temp  where  tblMP_Material_Detail_Temp.ItemId='" + itemId + "'  And SessionId!='" + sId + "' ";
                SqlCommand Cmd = new SqlCommand(Sql, con);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                if (DS.Tables[0].Rows.Count > 0 && DS.Tables[0].Rows[0][0] != DBNull.Value)
                {
                    string mystring1 = string.Empty;
                    mystring1 = "This item is in use.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + mystring1 + "');", true);

                }
                else
                {

                    ViewState["ItemId"] = itemId;
                    ViewState["BOMQty"] = BomQty;
                   
                  
                }

            }
            if (e.CommandName == "viewImg")
            {
                Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemId + "&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType");
            }

            if (e.CommandName == "viewSpec")
            {
                Response.Redirect("~/Controls/DownloadFile.aspx?Id=" + itemId + "&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType");
            }
        }
        catch (Exception ex)
        {
        }

    }
    
    public void MP_GRID(string wono, int CompId, GridView GridView2, int finid, string param)
    {

        string connStr = fun.Connection();
        SqlConnection con = new SqlConnection(connStr);

       
          try
        {
            con.Open();
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemCode", typeof(string));
            dt.Columns.Add("ManfDesc", typeof(string));
            dt.Columns.Add("UOMBasic", typeof(string));
            dt.Columns.Add("UnitQty", typeof(string));
            dt.Columns.Add("BOMQty", typeof(string));
            dt.Columns.Add(new System.Data.DataColumn("FileName", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("AttName", typeof(string)));
            dt.Columns.Add("ItemId", typeof(int));
            dt.Columns.Add("PRQty", typeof(string));
            dt.Columns.Add("WISQty", typeof(string));
            dt.Columns.Add("GQNQty", typeof(string));
            DataRow dr;

            string sql = fun.select("Distinct ItemId,PartNo", "tblDG_BOM_Master", "WONo='" + wono + "'and PartNo LIKE '%-00%' And FinYearId<='" + finid + "'  ");




           // string sql = fun.select("Distinct ItemId", "tblDG_BOM_Master", "WONo='" + wono + "'and  CompId='" + CompId + "'And FinYearId<='" + finid + "' And ECNFlag=0    ");          
            SqlCommand cmd = new SqlCommand(sql, con);           
            SqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())          
            {

                
                dr = dt.NewRow();
                string sql1 = fun.select("tblDG_Item_Master.ItemCode,tblDG_Item_Master.PartNo,tblDG_Item_Master.CId,tblDG_Item_Master.Id,tblDG_Item_Master.ManfDesc,Unit_Master.Symbol As UOMBasic,tblDG_Item_Master.AttName,tblDG_Item_Master.FileName", " tblDG_Item_Master,Unit_Master", " Unit_Master.Id=tblDG_Item_Master.UOMBasic And  tblDG_Item_Master.Id='" + rdr["ItemId"].ToString() + "'" + param + "");
                DataSet DS_S = new DataSet();
                SqlCommand cmd_S = new SqlCommand(sql1, con);
                SqlDataAdapter DA_S = new SqlDataAdapter(cmd_S);
                DA_S.Fill(DS_S);
                if (DS_S.Tables[0].Rows.Count > 0)
                {

                    string sqlGetProItem = fun.select("tblDG_Item_Master.Process,tblDG_Item_Master.ItemCode", " tblDG_Item_Master", " tblDG_Item_Master.PartNo='" + DS_S.Tables[0].Rows[0]["PartNo"].ToString() + "' And CompId='" + CompId + "' " + param + " And tblDG_Item_Master.Process is not  null");                   
                    SqlCommand cmd_GetProItem = new SqlCommand(sqlGetProItem, con);                  
                    string RMA = "";
                    SqlDataReader rdr3 = cmd_GetProItem.ExecuteReader();

                    //int p = 0;
                    while (rdr3.Read())                 
                    {
                        //RMA += "/" + rdr3["Process"].ToString();
                    }

                    if (DS_S.Tables[0].Rows[0]["CId"] == DBNull.Value)
                    {
                        dr[0] = DS_S.Tables[0].Rows[0]["PartNo"].ToString() + RMA;
                    }
                    else
                    {
                        dr[0] = DS_S.Tables[0].Rows[0]["ItemCode"].ToString();
                    }

                    dr[1] = DS_S.Tables[0].Rows[0]["ManfDesc"].ToString();
                    dr[2] = DS_S.Tables[0].Rows[0]["UOMBasic"].ToString();
                    double tqty = 0;
                    dr[3] = tqty;
                    
                    double liQty = 0;
                    liQty = fun.AllComponentBOMQty(CompId, wono, rdr["ItemId"].ToString(), finid);
                    dr[4] = liQty;
                    dr[7] = rdr["ItemId"].ToString();
                    ////PR Qty
                    //double PRQty = 0;
                    //PRQty = fun.CalPRQty(CompId, wono, Convert.ToInt32(rdr["ItemId"]));
                    //dr[8] = PRQty.ToString();
                    ////WIS Qty
                    //double WISQty = 0;
                    //WISQty = fun.CalWISQty(CompId.ToString(), wono, rdr["ItemId"].ToString());
                    //dr[9] = WISQty.ToString();

                    ////GQN Qty
                    //double GQNQty = 0;
                    //GQNQty = fun.GQNQTY(CompId, wono,rdr["ItemId"].ToString());                    
                    //dr[10] = GQNQty.ToString();

                    
                    //    if (DS_S.Tables[0].Rows[0]["FileName"].ToString() != "" && DS_S.Tables[0].Rows[0]["FileName"] != DBNull.Value)
                    //    { 
                    //        dr[5] = "View";
                    //    }
                    //    else
                    //    {
                    //        dr[5] = "";
                    //    }

                    //    if (DS_S.Tables[0].Rows[0]["AttName"].ToString() != "" && DS_S.Tables[0].Rows[0]["AttName"] != DBNull.Value)
                    //    {
                    //        dr[6] = "View";
                    //    }
                    //    else
                    //    {
                    //        dr[6] = "";
                    //    }


                    //    double TempRawQty = 0;
                    //    string SqlTempRaw = "SELECT SUM(tblMP_Material_RawMaterial_Temp.Qty) AS RawQty FROM tblMP_Material_Detail_Temp INNER JOIN               tblMP_Material_RawMaterial_Temp ON tblMP_Material_Detail_Temp.Id = tblMP_Material_RawMaterial_Temp.DMid And  tblMP_Material_Detail_Temp.ItemId='" + rdr["ItemId"] + "'  And SessionId!='" + sId + "' ";
                    //    SqlCommand CmdTempRaw = new SqlCommand(SqlTempRaw, con);
                    //    SqlDataAdapter DATempRaw = new SqlDataAdapter(CmdTempRaw);
                    //    DataSet DSTempRaw = new DataSet();
                    //    DATempRaw.Fill(DSTempRaw);
                    //    if (DSTempRaw.Tables[0].Rows.Count > 0 && DSTempRaw.Tables[0].Rows[0][0] != DBNull.Value)
                    //    {
                    //        TempRawQty = Convert.ToDouble(DSTempRaw.Tables[0].Rows[0][0]);
                    //    }
                    //    double TempProQty = 0;
                    //    string SqlTempPro = "SELECT SUM(tblMP_Material_Process_Temp.Qty) AS ProQty FROM tblMP_Material_Detail_Temp INNER JOIN               tblMP_Material_Process_Temp ON tblMP_Material_Detail_Temp.Id = tblMP_Material_Process_Temp.DMid And  tblMP_Material_Detail_Temp.ItemId='" + rdr["ItemId"] + "'  And SessionId!='"+sId+"' ";
                    //    SqlCommand CmdTempPro = new SqlCommand(SqlTempPro, con);
                    //    SqlDataAdapter DATempPro = new SqlDataAdapter(CmdTempPro);
                    //    DataSet DSTempPro = new DataSet();
                    //    DATempPro.Fill(DSTempPro);
                    //    if (DSTempPro.Tables[0].Rows.Count > 0 && DSTempPro.Tables[0].Rows[0][0] != DBNull.Value)
                    //    {
                    //        TempProQty = Convert.ToDouble(DSTempPro.Tables[0].Rows[0][0]);
                    //    }
                    //    double TempFinQty = 0;
                    //    string SqlTempFin = "SELECT SUM(tblMP_Material_Finish_Temp.Qty) AS FinQty FROM tblMP_Material_Detail_Temp INNER JOIN               tblMP_Material_Finish_Temp ON tblMP_Material_Detail_Temp.Id = tblMP_Material_Finish_Temp.DMid And  tblMP_Material_Detail_Temp.ItemId='" + rdr["ItemId"] + "'  And SessionId!='" + sId + "' ";
                    //    SqlCommand CmdTempFin = new SqlCommand(SqlTempFin, con);
                    //    SqlDataAdapter DATempFin = new SqlDataAdapter(CmdTempFin);
                    //    DataSet DSTempFin = new DataSet();
                    //    DATempFin.Fill(DSTempFin);
                    //    if (DSTempFin.Tables[0].Rows.Count > 0 && DSTempFin.Tables[0].Rows[0][0] != DBNull.Value)
                    //    {
                    //        TempFinQty = Convert.ToDouble(DSTempFin.Tables[0].Rows[0][0]);
                    //    }
                    //    double ProQty = 0;
                    //    string SqlPro = "SELECT SUM(tblMP_Material_Process.Qty) AS ProQty FROM tblMP_Material_Detail INNER JOIN               tblMP_Material_Master ON tblMP_Material_Detail.Mid = tblMP_Material_Master.Id INNER JOIN tblMP_Material_Process ON tblMP_Material_Detail.Id = tblMP_Material_Process.DMid And tblMP_Material_Detail.ItemId='" + rdr["ItemId"] + "'  And WONo='"+wono+"'";
                    //    SqlCommand CmdPro = new SqlCommand(SqlPro, con);
                    //    SqlDataAdapter DAPro = new SqlDataAdapter(CmdPro);
                    //    DataSet DSPro = new DataSet();
                    //    DAPro.Fill(DSPro);
                    //    if (DSPro.Tables[0].Rows.Count > 0 && DSPro.Tables[0].Rows[0][0]!=DBNull.Value)
                    //    {                            
                    //        ProQty = Convert.ToDouble(DSPro.Tables[0].Rows[0][0]);
                    //    }


                       
                                    dt.Rows.Add(dr);
                                    dt.AcceptChanges();
                               
                }
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();


        }
         catch (Exception ch)
        {
        }
         finally
        {
            con.Close();
        }

    }    protected void RadButton2_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Planning_New.aspx?ModId=4&SubModId=33");
    }


    protected void Button_Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Module/ProjectManagement/Transactions/Planning_New.aspx?ModId=7&SubModId=152", true);
    }

}

