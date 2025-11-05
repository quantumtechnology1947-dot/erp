<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_TPL_Design_Print_Cry, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <table align="center" cellpadding="0" cellspacing="0" width="100%">   
    <tr>
        <td align="left" valign="middle"  scope="col" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21">
        &nbsp;<b>TPL - Print</b></td>            
    </tr>
        
    <tr>
        <td align="center"> 
        <asp:Panel ID="Panel1" runat="server" Height="450px" ScrollBars="Auto">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
                DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True"  />
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="~\Module\Design\Transactions\Reports\TPL_Print_ALL.rpt">
                </Report>
            </CR:CrystalReportSource>
            </asp:Panel>
        </td>            
    </tr>
    <tr>
     <td align="center" valign="top">
            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Cancel" />
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>