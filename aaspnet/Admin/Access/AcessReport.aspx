<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_Access_AcessReport, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>

  <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />   
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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


  <table align="left" cellpadding="0" cellspacing="0" width="100%" class="style2">
    <tr>
        <td align="left" valign="middle" style="background:url(../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;
        Access Report- Print </b></td>
    </tr>
    <tr>
        <td align="center">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%" Height="445">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                AutoDataBind="true" HasCrystalLogo="False"
    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" ReuseParameterValuesOnRefresh="true"  HasPageNavigationButtons="True" 
    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" />
            </asp:Panel>
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="~\Admin\Access\AccessReports.rpt">
                </Report>
            </CR:CrystalReportSource>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" 
                onclick="btnCancel_Click"   />
        </td>
    </tr>
</table>
   
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

