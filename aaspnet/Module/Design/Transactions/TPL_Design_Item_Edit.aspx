<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_TPL_Design_Item_Edit, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
 
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    
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

 <table cellpadding="0" width="100%" cellspacing="0">
    <tr>
    <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
            height="21">&nbsp;<b>TPL 
        Item - Edit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WO No:&nbsp;<asp:Label runat="server" ID="lblWONo"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
        </td>
    </tr>
        <tr>
            <td align="center" class="style25" valign="top">
                <table align="left" cellpadding="0" cellspacing="0" class="fontcss" width="500">
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left" height="22">
                            Item Code</td>
                        <td align="left">
                <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left" height="150" valign="top">
                            Description&nbsp; </td>
                        <td align="left" valign="top">
                            <asp:Label ID="lblMfDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left" height="22">
                            UOM</td>
                        <td align="left">
                            <asp:Label ID="lblUOMB" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style34">
                            &nbsp;</td>
                        <td align="left" class="style34" height="22">
                            Unit
                            Qty</td>
                        <td align="left">
                <asp:TextBox ID="txtQuntity" runat="server" Width="99px" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtQuntity" ValidationGroup="val" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtQuntity" 
                                ErrorMessage="*" ValidationGroup="val" ID="RegQty"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style34">
                            &nbsp;</td>
                        <td align="left" class="style34" height="35">
                            &nbsp;</td>
                        <td align="left">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="val"  OnClientClick=" return confirmationUpdate()" 
                    onclick="btnUpdate_Click" CssClass="redbox" />
                            &nbsp;<asp:Button ID="btncancel" runat="server" 
                    onclick="btncancel_Click" Text="Cancel" CssClass="redbox" />
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        </table>
        
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

