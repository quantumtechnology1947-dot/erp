<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectSummary_Details_Bought.aspx.cs" Inherits="Module_ProjectManagement_Reports_ProjectSummary_Details_Bought" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


  <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" defer="defer" type="text/javascript"></script> 
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
     <style type="text/css">
.container 
{
    overflow:auto;
    margin-left:0px;   
    height:420px; 
    width:183%;  
    margin-top:18px;
  
 }

.grdview_headers
{
    color:#330000; 
    position:absolute ;
    display:block;
    width:181.2%;
    margin-top:-22px;
  
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

<table width="100%" >
<tr>
<td width="12%">
<b>  WONo : <asp:Label ID="lblWo" runat="server" Text=""></asp:Label></b>
</td>
<td>
    <b>Check All :</b><asp:CheckBox ID="CheckAll" runat="server" 
        AutoPostBack="True" oncheckedchanged="CheckAll_CheckedChanged" />
</td>
</tr>
</table>    
    <div>
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Bold="True" 
         RepeatColumns="16" RepeatDirection="Horizontal">
        <asp:ListItem Selected="True">Sr.No</asp:ListItem>
        <asp:ListItem Selected="True" Value="0">Item Code</asp:ListItem>
        <asp:ListItem Value="1" Selected="True">Description</asp:ListItem>
        <asp:ListItem Value="2" Selected="True">UOM</asp:ListItem>
        <asp:ListItem Value="3" Selected="True">BOM Qty</asp:ListItem>
        <asp:ListItem Value="4" Selected="True">WIS Qty</asp:ListItem>
        <asp:ListItem Value="5" Selected="True">Stock Qty</asp:ListItem>        
        <asp:ListItem Value="10">PR No</asp:ListItem>
        <asp:ListItem Value="11">PR Date</asp:ListItem>
        <asp:ListItem Value="12">PR Qty</asp:ListItem>
        <asp:ListItem Value="13">PO No</asp:ListItem>
        <asp:ListItem Value="14">PO Date</asp:ListItem>
        <asp:ListItem Value="15">Supplier Name</asp:ListItem>
        <asp:ListItem Value="16">Authorized</asp:ListItem>
        <asp:ListItem Value="17">PO Qty</asp:ListItem>
        <asp:ListItem Value="18">GIN No</asp:ListItem>
        <asp:ListItem Value="19">GIN Date</asp:ListItem>
        <asp:ListItem Value="20">GIN Qty</asp:ListItem>
        <asp:ListItem Value="21">GRR No</asp:ListItem>
        <asp:ListItem Value="22">GRR Date</asp:ListItem>
        <asp:ListItem Value="23">GRR Qty</asp:ListItem>
        <asp:ListItem Value="24">GQN No</asp:ListItem>
        <asp:ListItem Value="25">GQN Date</asp:ListItem>
        <asp:ListItem Value="26">GQN Qty</asp:ListItem>
    </asp:CheckBoxList>     
        
    </div>
<table width="100%"> 

<tr>

<td>&nbsp;</td>
</tr>    
     <tr>
     <td align="center">     
         &nbsp;<asp:Button ID="btnExport" runat="server" 
             CssClass="redbox" onclick="btnExport_Click" Text="Export" />
         &nbsp;<asp:Button ID="btnCancel" CssClass="redbox" runat="server" Text="Cancel" 
             onclick="btnCancel_Click" />
         </td>
     </tr></table>

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

