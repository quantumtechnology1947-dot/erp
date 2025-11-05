<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BOM_Design_Item_Edit.aspx.cs" Inherits="Module_Design_Transactions_BOM_Design_Item_Edit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
        <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            height: 22px;
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
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

<table cellpadding="0" width="100%" cellspacing="0">
    <tr>
    <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
            height="21">&nbsp;<b>BOM 
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
                        <td align="left" valign="top">
                            Description&nbsp; </td>
                        <td align="left" valign="top" height="25PX">
                            <asp:Label ID="lblMfDesc" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style2">
                            </td>
                        <td align="left" class="style2">
                            UOM</td>
                        <td align="left" class="style2">
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
                        <td align="left" class="style34" height="22">
                            Revision</td>
                        <td align="left">
                <asp:TextBox ID="txtRevision" runat="server" Width="99px" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqtxtRevision" runat="server" 
                    ControlToValidate="txtRevision" ValidationGroup="val" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        
                        
                        <td align="left" class="style34" height="22">
                            Material</td>
                        <td align="left">
                <asp:TextBox ID="txtmat" runat="server" Width="99px" CssClass="box3"></asp:TextBox>
               
                        </td>
                        
                        
                    </tr>
                    <tr>
                    <td align="left" class="style34">
                            &nbsp;</td>
                        <td align="left" class="style34" height="22">
                             </td>
                        <td align="left">
                  
                <asp:TextBox ID="txtremark" runat="server" Width="99px" Visible="false" CssClass="box3"></asp:TextBox>
               
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
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

