<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FinYrs_Update.aspx.cs" Inherits="Module_SysAdmin_FinancialYear_Update" Title="ERP"EnableEventValidation="false" Theme ="Default"  %>

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
                                        &nbsp;<b>Financial Year - Edit</b></td>
                                </tr>
                                <tr>
                                    <td width="7" height="25" align="left" valign="top">
                                        &nbsp;</td>
                                    <td width="70" align="left" valign="middle">
                                        Company</td>
                                    <td width="250" align="left" valign="middle">
                                        : 
                                        <asp:DropDownList ID="DropDownUpFYCName" 
                            runat="server" CssClass="box3" AutoPostBack="True" 
                                            onselectedindexchanged="DropDownUpFYCName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqCompName" runat="server" 
                                            ControlToValidate="DropDownUpFYCName" ErrorMessage="*" InitialValue="Select" 
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
                                        <asp:ListBox ID="ListBoxUpFinYear" runat="server" Width="170" 
                                            CssClass="box3" AutoPostBack="True" onselectedindexchanged="ListBoxUpFinYear_SelectedIndexChanged"  
                                            >
                                        </asp:ListBox>
                                        <asp:RequiredFieldValidator ID="ReqFinYr" runat="server" 
                                            ControlToValidate="ListBoxUpFinYear" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left" valign="top">
                                        &nbsp;</td>
                                    <td align="right" valign="middle">
                                        Date From</td>
                                    <td align="left" valign="middle">
                                        : 
                                  <asp:TextBox ID="txtFDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                           
                                        <cc1:CalendarExtender ID="txtFDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                                            Enabled="True" TargetControlID="txtFDate" Format="dd-MM-yyyy">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                       ValidationGroup="A"    ControlToValidate="txtFDate"  ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="txtFDate" ErrorMessage="*" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                           
                                </td>
                                </tr>
                                <tr>
                                    <td height="25" align="left" valign="top">
                                        &nbsp;</td>
                                    <td align="right" valign="middle">
                                        Date To</td>
                                    <td align="left" valign="middle">
                                        : 
                              <asp:TextBox ID="txtTDate" runat="server" CssClass="box3" Width="80px">
                            </asp:TextBox>
                           
                                        <cc1:CalendarExtender ID="txtTDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                                            Enabled="True" TargetControlID="txtTDate" Format="dd-MM-yyyy">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                     ControlToValidate="txtTDate" ValidationGroup="A"         ErrorMessage="*"></asp:RequiredFieldValidator>
                           
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="txtTDate" ErrorMessage="*" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                           
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="3" align="center" valign="middle">
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" colspan="3" align="center" valign="middle">
                                        <asp:Button ID="Update" runat="server" Text="Update" CssClass="redbox" 
                                         ValidationGroup="A"   OnClientClick=" return confirmationUpdate()"   onclick="Update_Click"/>
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

