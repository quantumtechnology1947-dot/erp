<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PO_SPR_View_Print_Details.aspx.cs" Inherits="Module_MaterialManagement_Transactions_PO_SPR_View_Print_Details" Title="ERP" Theme="Default" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style6
        {
            width: 908px;
        }
       
    </style>
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
    <table align="left" cellpadding="0" cellspacing="0" width="100%" height="340">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" width="908px">&nbsp;<b>PO - Print</b> 
            </td>
            <td height="20" align="center" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
                <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="redbox" 
             valign="top" onclick="Cancel_Click" /></td>
        </tr>
        <tr>
            <td align="Left" colspan="2">                               
                <iframe id="myifram" width="100%" scrolling="auto" height="470" frameborder="0" runat="server"></iframe>
             </td>
        </tr>
        
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

