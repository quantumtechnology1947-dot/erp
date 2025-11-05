<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Reports_ProjectSummary_Sup_B, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
<td width="12%">
<b>  WONo : <asp:Label ID="lblWo" runat="server" Text=""></asp:Label></b>
</td>
<td>
    <b>Check All :</b><asp:CheckBox ID="CheckAll" runat="server" 
        AutoPostBack="True" oncheckedchanged="CheckAll_CheckedChanged" />
</td><%--<td height="25 px">
    <b>Supplier</b>&nbsp; 
                                <asp:TextBox ID="txtSupplierPR" runat="server" Width="336px" CssClass="box3"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplierPR" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                &nbsp;&nbsp;&nbsp;&nbsp;</td>--%>



     <td height="21" align="left">
                &nbsp;<b> Date&nbsp;From</b></td>
            <td align="left">
                <asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
             
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
                &nbsp; -&nbsp; To
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtTodate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
             
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
               <%--  <asp:Button 
                                    ID="Button1" runat="server" CssClass="redbox" Text="Search" 
                                    onclick="Button1_Click" />--%>
            </td>
</tr>
       <tr>

          

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
        <asp:ListItem Enabled="false" Selected="True"  Value="15">Supplier Name</asp:ListItem>
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
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

