<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Scheduler_GatePass_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
      
    
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>GatePass - Print</b>
            </td>
        </tr>
        <tr>
            <td align="Left">
                <asp:Panel ID="Panel1" runat="server" Height="420px" ScrollBars="Auto" 
                    Width="100%">
                    <CR:CrystalReportSource ID="CrystalReportSource1"   runat="server">
        <Report FileName="Module\Scheduler\CrystalReport.rpt">
        </Report>
    </CR:CrystalReportSource>
<CR:CrystalReportViewer ID="CrystalReportViewer1" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false" 
 HasCrystalLogo="False" EnableParameterPrompt="false"  ReportSourceID="CrystalReportSource1" runat="server" 
    AutoDataBind="true" />
                </asp:Panel>
                    
                    </td>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style4" colspan="2">
                <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="redbox" 
                    valign="top" onclick="Cancel_Click"/>
                    
                    </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

