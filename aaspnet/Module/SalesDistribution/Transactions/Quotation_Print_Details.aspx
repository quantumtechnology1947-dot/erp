<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_Quotation_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .style2
    {
        width: 100%;
        float: left;
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

     <table align="Center" cellpadding="0" cellspacing="0" class="style2">
    <tr Height="21" >
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<b>Quotation- Print</b></td>
    </tr>
    <tr>
        <td align=Center >
            <asp:Panel ID="Panel1" runat="server" Width="100%" Height="450" ScrollBars="Auto">            
     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
         ReuseParameterValuesOnRefresh="true" DisplayGroupTree="False"  AutoDataBind="true" />
    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
    </CR:CrystalReportSource>
           </asp:Panel>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Cancel" />
        </td>
    </tr>
</table>

     </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

