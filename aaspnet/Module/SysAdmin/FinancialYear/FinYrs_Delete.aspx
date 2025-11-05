<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FinYrs_Delete.aspx.cs" Inherits="Module_SysAdmin_FinancialYear_Delete" Title="ERP" EnableEventValidation="false" Theme ="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="320" align="center" valign="center" >
                <table cellpadding="0" cellspacing="0" class="fontcss" width="100%">
                    <tr>
                        <td>
                            <table border="0" align="center" cellpadding="0" width="400" cellspacing="0" class="box3">
                                <tr>
                                    <td height="20" colspan="3" align="left" valign="center" class="fontcsswhite" style="background-image:url('../../../images/hdbg.jpg')">
                                        &nbsp;<b>Financial Year - Delete</b></td>
                                </tr>
                                <tr>
                                    <td width="7" height="25" align="left" valign="top">
                                        &nbsp;</td>
                                    <td width="70" align="left" valign="middle">
                                        Company</td>
                                    <td width="250" align="left" valign="middle">
                                        : 
                                        <asp:DropDownList ID="DropDownDelFYCName" 
                            runat="server" CssClass="box3" AutoPostBack="True" 
                                            onselectedindexchanged="DropDownDelFYCName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqCompName" runat="server" 
                                            ControlToValidate="DropDownDelFYCName" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left" valign="top">
                                        &nbsp;</td>
                                    <td align="left" valign="top">
                                        Financial Year</td>
                                    <td align="left" valign="middle">
                                        &nbsp; 
                                        <asp:ListBox ID="ListBoxDelFinYear" runat="server" Width="170px" Height="152px" 
                                            CssClass="box3" 
                                            onselectedindexchanged="ListBoxDelFinYear_SelectedIndexChanged">
                                        </asp:ListBox>
                                        <asp:RequiredFieldValidator ID="ReqFinYr" runat="server" 
                                            ControlToValidate="ListBoxDelFinYear" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="3" align="center" valign="middle">
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" colspan="3" align="center" valign="middle">
                                        <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="redbox" 
                                         OnClientClick=" return confirmationDelete()"  onclick="Delete_Click" 
                                            ValidationGroup="A"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

