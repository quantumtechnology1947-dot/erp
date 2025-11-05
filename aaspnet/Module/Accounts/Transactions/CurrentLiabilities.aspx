<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_CurrentLiabilities, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 70%;
            float: left;
        }
        .style3
        {
            font-weight: bold;            
        }
    </style>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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
<table width="100%" >
<tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="3"><b>&nbsp;Balance Sheet: Current Liabilities</b></td>
        </tr>
<tr>
<td height="420" valign="top">
    <table cellpadding="0" cellspacing="0" class="style2">
        
        <tr>
            <td rowspan="2" width="60%" class="bottomrightedge" >
                &nbsp;
                <asp:Label ID="Label5" runat="server" CssClass="style3" Text="Perticulars"></asp:Label>
            </td>
            <td align="center" colspan="2" class="bottomrightedge" height="22">
                <asp:Label ID="Label2" runat="server" CssClass="style3" Text="Closing Balance"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td height="22" class="bottomrightedge">
                <asp:Label ID="Label3" runat="server" CssClass="style3" Text="Debit"></asp:Label>
            </td>
            <td class="bottomrightedge">
                <asp:Label ID="Label4" runat="server" CssClass="style3" Text="Credit"></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td align="left" height="22" class="bottomrightedge">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" 
                    PostBackUrl="~/Module/Accounts/Transactions/SundryCreditors.aspx?ModId=&SubModId=">Sundry Creditors</asp:LinkButton>
                &nbsp;</td>
            <td class="bottomrightedge">
                <asp:Label ID="lblDeb_SuCr" runat="server" Text="0" CssClass="style3"></asp:Label>
            </td>
            <td class="bottomrightedge">
                <asp:Label ID="lblCrd_SuCr" runat="server" Text="0" CssClass="style3"></asp:Label>
            </td>
        </tr>
        <tr align="right">
            <td align="left" height="22" class="bottomrightedge">
                &nbsp;
                <asp:Label ID="Label6" runat="server" CssClass="style3" Text="Grand Total"></asp:Label>
            </td>
            <td class="bottomrightedge">
                <asp:Label ID="lblDeb_SuCr0" runat="server" Text="0" CssClass="style3"></asp:Label>
            </td>
            <td class="bottomrightedge">
                <asp:Label ID="lblCrd_SuCr0" runat="server" Text="0" CssClass="style3"></asp:Label>
            </td>
        </tr>
    </table>
</td>
</tr>
<tr>
<td align="center" height="22">

    <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
        onclick="btnCancel_Click" Text="Cancel" />

</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

