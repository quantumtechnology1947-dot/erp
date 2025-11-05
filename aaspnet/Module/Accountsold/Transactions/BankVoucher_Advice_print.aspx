<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankVoucher_Advice_print.aspx.cs" Inherits="Module_Accounts_Transactions_BankVoucher_Advice_print" Title="ERP" Theme="Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
</asp:Content>
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
    <asp:Panel ID="Panel2" ScrollBars="Auto"  Width="100%" Height="450px" Visible="true" runat="server">
   
    <CR:CrystalReportViewer ID="CrystalReportViewer2"   AutoDataBind="True" 
        ReportSourceID="CrystalReportSource2" runat="server" 
        EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" 
        ReuseParameterValuesOnRefresh="True"  Width="100%"  />
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

