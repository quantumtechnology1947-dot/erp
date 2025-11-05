<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_BalanceSheet, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2 {
            width: 100%;
            float: left;
        }
        .style5
        {
            font-weight: bold;
            text-decoration: underline;
        }
        .style7
        {
            font-weight: bold;
        }
        .style8
        {
            width: 100%;
            float: left;
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
    <table cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="2"><b>&nbsp;Balance Sheet</b></td>
        </tr>
        <tr>
            <td height="25" width="50%" valign="top">
                <table align="left" cellpadding="0" cellspacing="0" width="90%">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                <asp:Label ID="Label2" runat="server" CssClass="style5" Text="Liabilities"></asp:Label>
                        </td>
                        <td width="40%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCFFFF">
                            &nbsp;</td>
                        <td bgcolor="#CCFFFF" height="25">
                            <asp:LinkButton ID="LinkButton2" runat="server" 
                                PostBackUrl="~/Module/Accounts/Transactions/Acc_Capital_Particulars.aspx">Input Cst-Interstate Capital 
                            Goods</asp:LinkButton>
                        </td>
                        <td align="right" bgcolor="#CCFFFF">
                            <asp:Label ID="Amt_CapitalGood" runat="server" Font-Bold="True" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            <asp:LinkButton ID="LinkButton3" runat="server" 
                                PostBackUrl="~/Module/Accounts/Transactions/Acc_Loan_Particulars.aspx">Loan (Liability)</asp:LinkButton>
                        </td>
                        <td align="right">
                            <asp:Label ID="Amt_LoanLiability" runat="server" Font-Bold="True" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCFFFF">
                            &nbsp;</td>
                        <td bgcolor="#CCFFFF" height="25">
                <asp:LinkButton ID="LinkButton1" runat="server" 
                    PostBackUrl="CurrentLiabilities.aspx">Current Liabilities</asp:LinkButton>
                        </td>
                        <td align="right" bgcolor="#CCFFFF">
                <asp:Label ID="Amt_CurrentLiab" runat="server" Text="0" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            <asp:LinkButton ID="LinkButton4" runat="server">Branch/Division</asp:LinkButton>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCFFFF">
                            &nbsp;</td>
                        <td bgcolor="#CCFFFF" height="25">
                            <asp:LinkButton ID="LinkButton5" runat="server">Suspence A/c</asp:LinkButton>
                        </td>
                        <td align="right" bgcolor="#CCFFFF">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            <asp:LinkButton ID="LinkButton6" runat="server">Profit &amp; Loss A/c</asp:LinkButton>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                <asp:Label ID="Label4" runat="server" CssClass="style7" Text="Total"></asp:Label>
                        </td>
                        <td align="right">
                <asp:Label ID="Amt_CurrentLiab0" runat="server" Text="0" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="50%">
                <table align="left" cellpadding="0" cellspacing="0" class="style8">
                    <tr>
                        <td colspan="3" height="25" width="1%">
                <asp:Label ID="Label3" runat="server" CssClass="style5" Text="Assets"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCFFFF" height="25">
                            &nbsp;</td>
                        <td bgcolor="#CCFFFF" height="25">
                            <asp:LinkButton ID="LinkButton7" runat="server">Fixed Asset</asp:LinkButton>
                        </td>
                        <td align="right" bgcolor="#CCFFFF" width="40%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;</td>
                        <td height="25">
                            <asp:LinkButton ID="LinkButton8" runat="server">Investments</asp:LinkButton>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td bgcolor="#CCFFFF" height="25">
                            &nbsp;</td>
                        <td bgcolor="#CCFFFF" height="25">
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="Acc_Bal_CurrAssets.aspx">Current Assets</asp:LinkButton>
                        </td>
                        <td align="right" bgcolor="#CCFFFF">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;</td>
                        <td height="25">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

