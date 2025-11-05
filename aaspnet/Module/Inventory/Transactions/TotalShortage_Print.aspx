<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TotalShortage_Print.aspx.cs" Inherits="Module_Inventory_Transactions_TotalShortage_Print" Title="Untitled Page" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 914px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
  <table align="center" cellpadding="0" cellspacing="0" width="100%">
    
    <tr>
        <td align="left" valign="middle"  scope="col" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21">
        &nbsp;<b>Total Shortage - Print</b></td>            
    </tr>
    
    <tr>
        <td align="center">
        <asp:Panel ID="Panel1" runat="server" Height="450px" ScrollBars="Auto">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                AutoDataBind="true" ReportSourceID="CrystalReportSource1" HasCrystalLogo="False"
                DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                EnableParameterPrompt="False" ReuseParameterValuesOnRefresh="True" Visible="false" />
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="~\Module\Inventotry\Transactions\Reports\TotalShortage.rpt">
                </Report>
            </CR:CrystalReportSource>
            </asp:Panel>
        </td>
    </tr>
     <tr>
     <td align="center" valign="top">
            <asp:Button ID="Button2" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Cancel" />
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

