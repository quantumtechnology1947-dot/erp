<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_OwnerLogin, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 26%;
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    
        <table align="center" cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <table align="center" cellpadding="0" cellspacing="0" class="box3" width="270">
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
&nbsp;
        <asp:Label ID="Label2" runat="server" Text="User Name:"></asp:Label>
                            </td>
                            <td height="23">
        <asp:TextBox ID="txtUserName" runat="server" CssClass="box3"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtUserName" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                            </td>
                            <td height="21">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="box3"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="log"
            ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td height="30">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Login" CssClass="redbox" ValidationGroup="log" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        
        <p>
        <br />
&nbsp;&nbsp;&nbsp;
        </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p style="margin-left: 80px">
        &nbsp;</p>
    <p>
    </p>
    </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

