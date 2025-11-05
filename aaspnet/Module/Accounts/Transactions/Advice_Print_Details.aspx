<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Advice_Print_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cp3" Runat="Server">         
          
          
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" Runat="Server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
   
   <table width="100%">
   <tr>
   <td align="center">
  <asp:Panel ID="Panel1" ScrollBars="Auto" Width="100%" Height="200px" runat="server">
    
       <%--<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
       <Triggers>           
            <asp:PostBackTrigger ControlID="CrystalReportViewer1"  />
        </Triggers>
       <ContentTemplate>--%>
   
    <CR:CrystalReportViewer ID="CrystalReportViewer1"   BorderStyle="Solid"  HasCrystalLogo="False"
            BorderColor="Black" BorderWidth="1"  AutoDataBind="True" 
        ReportSourceID="CrystalReportSource1" runat="server" 
        EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" 
        ReuseParameterValuesOnRefresh="True" Height="50px" Width="100%" 
             />
    <CR:CrystalReportSource  ID="CrystalReportSource1"  runat="server">
        <Report FileName="~/Module/Accounts/Reports/Advice_Print.rpt">
        </Report>
    </CR:CrystalReportSource> 
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </asp:Panel>
   </td>
   </tr>
   
   <tr>
   <td style="height:25px;"></td>
   </tr>
   
   <tr>
   <td align="center">
    <asp:Panel ID="Panel2" ScrollBars="Auto"  Width="100%" Height="200px" Visible="false" runat="server">
   
    <CR:CrystalReportViewer ID="CrystalReportViewer2"   AutoDataBind="True" 
        ReportSourceID="CrystalReportSource2" runat="server" 
        EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" 
        ReuseParameterValuesOnRefresh="True" Height="50px" Width="100%"  />
    <CR:CrystalReportSource ID="CrystalReportSource2"  runat="server">
        <Report FileName="~/Module/Accounts/Reports/BankVoucher_Payment_Advice.rpt">
        </Report>
    </CR:CrystalReportSource> 
    </asp:Panel>
   </td>
   </tr>
   
   <tr>
   <td  align="center" style="height:25px; ">   
       <asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" 
           onclick="btnCancel_Click" /></td>
   </tr>
   
   </table>     
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

