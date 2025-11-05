<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Advice_Print_Advice, newerp_deploy" title="ERP" theme="Default" %>

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
    <asp:Panel ID="Panel1" ScrollBars="Auto"  Width="100%" Height="430px"  runat="server">
   
    <CR:CrystalReportViewer ID="CrystalReportViewer2"   AutoDataBind="True"  HasCrystalLogo="False"
        ReportSourceID="CrystalReportSource2" runat="server" EnableParameterPrompt="false" 
        EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" 
        ReuseParameterValuesOnRefresh="True" Height="50px" Width="100%"  />
    <CR:CrystalReportSource ID="CrystalReportSource2"  runat="server">
        <Report FileName="~/Module/Accounts/Reports/Advice_Print_Advice.rpt">
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

