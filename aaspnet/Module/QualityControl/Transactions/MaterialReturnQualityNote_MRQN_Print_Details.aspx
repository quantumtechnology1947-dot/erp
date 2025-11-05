<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Print_Details, newerp_deploy" title="ERP
" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css"> 
        .style2
        {
            height: 25px;
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


<table class="style2" width="100%" cellpadding="0" cellspacing="0">
         <tr>
                <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Quality Note [MRQN] - Print</b></td>
           </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Panel1" runat="server" Width="100%" Height="445" ScrollBars="Auto">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False" 
                    AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" 
                        DisplayGroupTree="False" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="Module\QualityControl\Transactions\Reports\MRQN_Print.rpt">
                    </Report>
                </CR:CrystalReportSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" class="style2" height="25">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                         CssClass="redbox" onclick="btnCancel_Click"  /> 
                </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

