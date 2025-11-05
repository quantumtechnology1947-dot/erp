<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CashVoucher_Receipt_Print_Details.aspx.cs" Inherits="Module_Accounts_Transactions_CashVoucher_Receipt_Print_Details" Title="ERP" Theme="Default" %>

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
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="454" Width="100%">
        
<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
        AutoDataBind="True" Width="400px" ReportSourceID="CrystalReportSource1" 
                DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                EnableParameterPrompt="False" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" >
            <Report FileName="Module\Accounts\Reports\CashVoucher_Receipt.rpt">
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

