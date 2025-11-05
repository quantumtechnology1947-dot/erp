<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" inherits="Module_Inventory_Transactions_GoodsInwardNote_GIN_Print_Details, newerp_deploy" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style2
        {
            height: 34px;
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
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server" >
<table width ="100%" cellpadding="0" cellspacing="0" >
        <tr>
       <td   align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Inward Note [GIN] - Print</b></td>
           </tr>
        <tr>
        <td>
     <asp:Panel ID="Panel1"  runat="server" Height="445px"  ScrollBars="Auto" Width="100%" HorizontalAlign="Center" >
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" EnableDatabaseLogonPrompt="False" HasCrystalLogo="False"
                    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False"  BestFitPage="True" 
            ReuseParameterValuesOnRefresh="True" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="~\Module\Inventory\Transactions\Reports\GIN_Print.rpt">
            </Report>
        </CR:CrystalReportSource>
    </asp:Panel>
    </td>
      </tr>
    </table>
    <asp:Panel ID="Panel2" HorizontalAlign="Center" runat="server">
        <asp:Button ID="btncancel" runat="server" CssClass="redbox" Text="Cancel" 
            onclick="btncancel_Click" />
    </asp:Panel>
    </asp:Content>

    
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

