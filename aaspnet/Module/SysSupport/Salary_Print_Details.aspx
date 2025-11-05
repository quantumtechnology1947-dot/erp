<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Salary_Print_Details.aspx.cs" Inherits="Module_HR_Transactions_Salary_Print_Details" Title="Untitled Page" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

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
 <table align="left" cellpadding="0" cellspacing="0"  Width="100%">
    <tr>
        <td align="center">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical"  Height="468" Width="100%">           
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
        AutoDataBind="True" Height="50px" ReportSourceID="CrystalReportSource2" 
        Width="350px" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" />
    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
        <Report FileName="~\Module\HR\Transactions\Reports\Salary.rpt"></Report>
    </CR:CrystalReportSource>
 </asp:Panel>
        </td>       
    </tr>
    <tr>
     <td  align="center" valign="middle" height="25">
            <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="redbox" onclick="Cancel_Click" /></td>
    </tr>
</table>


</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

