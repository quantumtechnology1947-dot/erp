<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HrsBudgetSummary.aspx.cs" Inherits="Module_MIS_Transactions_HrsBudgetSummary" Title="ERP"  Theme ="Default"  %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
           <td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">
                            &nbsp;<b>Hrs Budget Summary</b></td>
           <td align="right" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">
                            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                onclick="Button1_Click" Text="Cancel" />
&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
            AutoDataBind="True" Height="50px" 
            Width="350px" DisplayGroupTree="False" 
                        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"  />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="~\Module\Accounts\Transactions\Reports\HrsBudgetSummary.rpt">            
            </Report>
       </CR:CrystalReportSource>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

