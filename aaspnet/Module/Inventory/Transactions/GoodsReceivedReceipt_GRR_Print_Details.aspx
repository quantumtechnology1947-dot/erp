<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style8
        {  
        	text-align: left;
        }
        .style10
        {
            text-align: center;
            height: 31px;
        }
        .style17
        {
            text-align: center;
            height: 22px;
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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Received Receipt [GRR] - Print</b></td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
            
 <table align="center" cellpadding="0" cellspacing="0" class="style2">
                <tr >
<td align="center">
    <asp:Panel ID="Panel1" runat="server" Height="445" ScrollBars="Auto">
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" EnableDatabaseLogonPrompt="False"  HasCrystalLogo="False"
        EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1"  DisplayGroupTree="False"/>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Module\Inventory\Transactions\Reports\GRR_Print.rpt">
            </Report>
        </CR:CrystalReportSource>
    </asp:Panel>
</td>
</tr>
<tr >
<td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        onclick="btnCancel_Click" CssClass="redbox" />
</td>
</tr>
</table>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

