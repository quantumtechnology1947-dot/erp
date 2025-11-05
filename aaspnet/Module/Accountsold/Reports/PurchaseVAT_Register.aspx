<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PurchaseVAT_Register.aspx.cs" Inherits="Module_Accounts_Reports_PurchaseVAT_Register"    Title="ERP" Theme="Default"  %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
        }
        .style4
        {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="hfFreight" ContentPlaceHolderID="cp3" Runat="Server">
    
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

     <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>Purchase Register - Print</b>
            </td>
        </tr>
        <tr>
            <td align="center" class="style3">
               <asp:Panel ID="Panel1" runat="server" Height="425px" ScrollBars="Auto" 
                    Width="100%">
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/Purchase.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" 
                    runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                </asp:Panel>
                    
                    </td>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
         <tr>
            <td align="center" class="style3">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CssClass="redbox" onclick="btnCancel_Click" /> </td>
            
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

