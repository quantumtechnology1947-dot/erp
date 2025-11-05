<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PR_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PR - Print</b>
            </td>
        </tr>
        <tr>
            <td align="center" class="style3">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%" Height="452">
                
                <CR:CrystalReportViewer ID="CrystalReportViewer1" HasCrystalLogo="False"
                    runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="~/Module/MaterialManagement/Transactions/Reports/PR.rpt">
                    </Report>
                </CR:CrystalReportSource>
                 <CR:CrystalReportViewer ID="CrystalReportViewer2" HasCrystalLogo="False"
                    runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                    <Report FileName="~/Module/MaterialManagement/Transactions/Reports/NewPR.rpt">
                    </Report>
                </CR:CrystalReportSource>
                    </asp:Panel>
                    </td>
        </tr>
        <tr>
            <td align="center" class="style3">
                <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="redbox" 
                    valign="top" onclick="Cancel_Click" />
                    
                    </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

