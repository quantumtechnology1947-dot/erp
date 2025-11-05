<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Apprisal_View.aspx.cs" Inherits="Module_ProjectManagement_Transactions_Plan_Proj" Title="ERP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
               style="background-color:Black ">
               
        &nbsp;<b>Appraisal View</b></td>
        </tr>
        </table>
        <br />
        <br />
         
    <asp:Panel ID="Panel1" runat="server" Visible="True">
     <asp:GridView ID="GridView1"  HeaderStyle-BackColor="red" HeaderStyle-ForeColor="Black"
                runat="server" AutoGenerateColumns="False" 
                  ShowFooter="true"  CssClass="yui-datatable-theme"
        DataSourceID="SqlDataSource1" Width="100%" Height="63%"    FooterStyle-Wrap="True"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
        CellSpacing="2" ForeColor="Black"  >
        
                <FooterStyle BackColor="#CCCCCC" />
              
                <Columns>
                
        <asp:TemplateField HeaderText="Sr No."  HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
      </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Name" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDate1" Text='<%#Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Department"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblwono1" runat="server" Text='<%# Bind("Dept") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
         
          
                </asp:TemplateField>
                
                   <asp:TemplateField HeaderText="Designation"  HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0" >
                <ItemTemplate>
                <asp:Label ID="lblprojtitle1" runat="server" Text='<%# Bind("Designation") %>' Font-Size="Larger"></asp:Label> 
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />

         
                </asp:TemplateField>
                
               
                 <asp:TemplateField HeaderText="Appraisal period from Date"   HeaderStyle-Font-Bold="True" HeaderStyle-BackColor="#f0eef0">
                <ItemTemplate>
                <asp:Label ID="lblpono1" runat="server" Text='<%# Bind("Aperiod") %>' Font-Size="Larger"></asp:Label> 
                
                </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />

            
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="Grade" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lblpress1"  Text='<%# Bind("Grade") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="JoiningDate" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblsft1"  Text='<%# Bind("JoiningDate") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Job Responsibilities" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lbl2D1"  Text='<%# Bind("JobR") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Specific Achievement" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lbl3D1"  Text='<%# Bind("SpeciAchv") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Specific loss to the company from your side" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblbend1"  Text='<%# Bind("losscomp") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Participation in other dept.other than your own dept in relation of work" >
                    <ItemTemplate>
                        <asp:Label Id="lblfab1"  Text='<%# Bind("Part") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    
                    
                    
                      <asp:TemplateField HeaderText="Denied for onsite with Reason" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblmchn1"  Text='<%# Bind("Deniedonsite") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Leave Without Permission" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblshr1"  Text='<%# Bind("LeaveWP") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Strength" >
                    <ItemTemplate>
                        <asp:Label Id="lblcDate"  Text='<%# Bind("Strength") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                
                <asp:TemplateField HeaderText="Weekness" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblremark"  Text='<%# Bind("Weekness") %>' runat="server"  ></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                
                   <asp:TemplateField HeaderText="Training Required" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblbend12"  Text='<%# Bind("TrainR") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Curr CTC" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblfab12"  Text='<%# Bind("CurrCTC") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="ExpectedCTC" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblmchn12"  Text='<%# Bind("ExpectedCTC") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Leave Without Permission"  HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblshr12"  Text='<%# Bind("TotalHrs") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Strength" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblcDate2"  Text='<%# Bind("TotalHrsPref") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                
                <asp:TemplateField HeaderText="Weekness" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblremark2"  Text='<%# Bind("LastIncDate") %>' runat="server"  ></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                
                
                <asp:TemplateField HeaderText="Total Yrs of Exp." HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lblmchn13"  Text='<%# Bind("TotalYrsExp") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Total Yrs of Exp.In SAPL" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblshr13"  Text='<%# Bind("TotalYrsExpSAPL") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Take Home Salary"  HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblcDate3"  Text='<%# Bind("HomeSalMon") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                
                <asp:TemplateField HeaderText="High Qualification" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblremark3"  Text='<%# Bind("HighQua") %>' runat="server"  ></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                
                   <asp:TemplateField HeaderText="Employee Comments" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                      <asp:Label Id="lblbend123"  Text='<%# Bind("EmpCom") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Notice Period on Offer Letter" HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblfab123"  Text='<%# Bind("NoticePerOffletr") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Pending PL"  HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                      <asp:Label Id="lblmchn123"  Text='<%# Bind("PLpend") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="Pending C-OFF"  HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblshr123"  Text='<%# Bind("COffPend") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="On Roll or Casual " HeaderStyle-BackColor="#f0eef0" >
                    <ItemTemplate>
                        <asp:Label Id="lblcDate23"  Text='<%# Bind("RollOCas") %>' runat="server"  ></asp:Label>
                    </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                
                <asp:TemplateField HeaderText="Appraisal Time on offer letter" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblremark23"  Text='<%# Bind("AppTimeLetter") %>' runat="server"  ></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                  <asp:TemplateField HeaderText="Eligible for facilities" HeaderStyle-BackColor="#f0eef0">
                    <ItemTemplate>
                        <asp:Label Id="lblremark233"  Text='<%# Bind("EligibleFasi") %>' runat="server"  ></asp:Label>
                    </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                </Columns>

             

           <HeaderStyle BackColor="#CCCCCC" ForeColor="Black"></HeaderStyle>
            </asp:GridView>
    <br />
    
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
            SelectCommand="SELECT Name, Dept,Designation,Aperiod,Grade,JoiningDate,JobR,SpeciAchv,losscomp,Part,Deniedonsite,LeaveWP,Strength,Weekness,TrainR,CurrCTC,ExpectedCTC,TotalHrs,TotalHrsPref,LastIncDate,TotalYrsExp,TotalYrsExpSAPL,HomeSalMon,HighQua,EmpCom,NoticePerOffletr,PLpend,COffPend,RollOCas,AppTimeLetter,EligibleFasi FROM tbl_ApprisalForm1" >
               
         </asp:SqlDataSource>
    
    </asp:Panel>
      

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

