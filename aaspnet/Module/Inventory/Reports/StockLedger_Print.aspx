<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_StockLedger_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style>
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
        <table align="center" cellpadding="0" cellspacing="0" class="style2">
            <tr>
                <td align="center">
          <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="460px">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" Width="100%" 
        AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" 
        ReuseParameterValuesOnRefresh="True" DisplayGroupTree="False" />
         <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="Module\Inventory\Reports\Stock_Ledger.rpt">
        </Report>
    </CR:CrystalReportSource> 
     </asp:Panel>
        </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="redbox" 
                        onclick="btnCancel_Click"/>
                    </td>
            </tr>
           
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

