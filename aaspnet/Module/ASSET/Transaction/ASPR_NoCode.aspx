<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ASPR_NoCode.aspx.cs" Inherits="Module_MaterialManagement_Transactions_ASPR_NoCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
        .style6
        {
            height: 42px;
            width: 101px;
        }
        .style7
        {
            height: 4px;
        }
        .style8
        {
            height: 27px;
        }
        .style10
        {
            height: 20px;
        }
        .style11
        {
            height: 20px;
            width: 101px;
        }
        .style13
        {
            width: 101px;
        }
        .style14
        {
            height: 4px;
            width: 101px;
        }
        .style15
        {
            height: 27px;
            width: 101px;
        }
        .style16
        {
            width: 206px;
        }
        .style17
        {
            height: 23px;
            width: 101px;
        }
        .style18
        {
            height: 23px;
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

 <table align="left" cellpadding="0" cellspacing="0" class="style2">
                <tr>
                <td>
              <table align="center" cellpadding="0" cellspacing="0" class="box3" width="70%">
                <tr>
                <td  height="20" align="left" valign="middle"  scope="col" 
                class="fontcsswhite" style="background:url(../../../images/hdbg.JPG)">&nbsp;<b>SPR- Item 
                Master</b></td>
                </tr>
                <tr>
                <td>
                <table align="left" cellpadding="0" cellspacing="0" width="100%" 
                style="height: 191px" >
                <tr >
                <td class="style11" valign="top" width="20%">
                    &nbsp;</td>
                <td 
                class="style10" valign="top" >
                    &nbsp;</td>
                </tr>
                <tr >
                <td class="style10" valign="top">
                &nbsp; Item Code</td>
                <td 
                class="style10" valign="top" >
                <asp:Label ID="lbltIemCode" runat="server"></asp:Label>
                </td>
                </tr>
                <tr >
                <td class="style17" valign="top" >
                    &nbsp; Description</td>
                <td 
                class="style18" valign="top">
                <asp:Label ID="lblManfDescription" runat="server"></asp:Label>
                </td>
                </tr>
                <tr >
                <td class="style13" >
                &nbsp; UOM</td>
                <td height="22" class="style16">
                <asp:Label ID="lblUOMBasic" runat="server"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <tr>
                <td class="style13" >
                &nbsp; Qty</td>
                <td class="style16" >
                <asp:TextBox runat="server" CssClass="box3" ID="txtQty" Width="89px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="QtyAdd">
                    </asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegQty" runat="server" ValidationGroup="QtyAdd"
            ControlToValidate="txtQty" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>
                                       
                </td>
                </tr>
                <tr >
                <td>&nbsp;&nbsp;Rate</td>

                <td height="25">

                    <asp:TextBox ID="txtRate" runat="server" CssClass="box3" Width="98px"></asp:TextBox>
                    
                   <a  runat="server" id="rt"><img  alt="" src="../../../images/Rupee.JPG" border="0"/></a><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="QtyAdd"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegRate" runat="server" ValidationGroup="QtyAdd"
            ControlToValidate="txtRate" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>
                                       

                </td>
                </tr>
                <tr >
                <td>&nbsp; Discount&nbsp;</td>

                <td height="25">

                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="box3" Width="98px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="QtyAdd"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegDisc" runat="server" ValidationGroup="QtyAdd"
            ControlToValidate="txtDiscount" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$"></asp:RegularExpressionValidator>
                                       

                </td>
                </tr>
                <tr >
                <td  class="style13">&nbsp; Supplier</td>

                <td height="25">

                <asp:TextBox ID="txtNewCustomerName" runat="server" Width="350px" 
                CssClass="box3"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtNewCustomerName_AutoCompleteExtender" 
                runat="server" CompletionInterval="100" CompletionSetCount="2" 
                DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                ShowOnlyCurrentWordInCompletionListItem="True" 
                TargetControlID="txtNewCustomerName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtNewCustomerName" ErrorMessage="*" 
                        ValidationGroup="QtyAdd"></asp:RequiredFieldValidator>


                </td>
                </tr>
                <tr >
                <td class="style14">
                &nbsp; A/c Head</td>
                <td 
                class="style7" valign="middle" >
                <asp:RadioButton runat="server" Text="Labour" ID="RbtnLabour" 
                AutoPostBack="True" Checked="True" GroupName="GroupACHead" 
                oncheckedchanged="RbtnLabour_CheckedChanged">
                </asp:RadioButton>
                <asp:RadioButton runat="server" Text="With Material" ID="RbtnWithMaterial" 
                AutoPostBack="True" GroupName="GroupACHead" 
                oncheckedchanged="RbtnWithMaterial_CheckedChanged">
                </asp:RadioButton>
                &nbsp;&nbsp;
                <asp:DropDownList runat="server" CssClass="box3" ID="DropDownList1" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                    <asp:Label ID="lblAHId" runat="server"></asp:Label>
&nbsp;</td>
                </tr>
                <tr >
                <td class="style15"  valign="top">
                    &nbsp; </td>
                <td 
                class="style8" >
                    <asp:RadioButton ID="rdwono" runat="server" Checked="True" GroupName="A" 
                        Text="WO No" AutoPostBack="True" />
&nbsp;<asp:TextBox ID="txtwono" runat="server" Width="84px" CssClass="box3"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rddept" runat="server" GroupName="A" Text="BG Group" 
                        AutoPostBack="True" />
&nbsp;
                    <asp:DropDownList ID="drpdept" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="Dept" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                </td>
                </tr>
                <tr >
                <td height="22"  valign="top">
                &nbsp;&nbsp;Delivery Date</td>
                <td 
                class="style8" valign="top" >
                    <asp:TextBox runat="server" 
                        CssClass="box3" ID="textDelDate"></asp:TextBox>
<cc1:CalendarExtender runat="server" Format="dd-MM-yyyy" Enabled="True" 
                        TargetControlID="textDelDate" ID="textDelDate_CalendarExtender"></cc1:CalendarExtender>
<asp:RequiredFieldValidator runat="server" ControlToValidate="textDelDate" ErrorMessage="*" 
                        ValidationGroup="QtyAdd" ID="ReqDelDate"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                        ControlToValidate="textDelDate" ErrorMessage="*" ValidationGroup="QtyAdd" 
                        ID="RegDelverylDate"></asp:RegularExpressionValidator>
                </td>
                </tr>
                <tr >
                <td class="style6" height="25"  valign="top">
                &nbsp; Remarks</td>
                <td 
                class="style8" >
                <asp:TextBox runat="server" TextMode="MultiLine" CssClass="box3" Height="52px" 
                Width="309px" ID="txtRemark"></asp:TextBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, Symbol as Dept from BusinessGroup"></asp:SqlDataSource>
                </td>
                </tr>
                <tr >
                <td class="style6" height="25" >
                    &nbsp;</td>
                <td 
                class="style8" >
                <asp:Button runat="server" Text="Add" OnClientClick=" return confirmationAdd()"  CssClass="redbox" ID="btnAdd" 
                OnClick="btnAdd_Click" ValidationGroup="QtyAdd"></asp:Button>
                &nbsp;<asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="btnCancel2" OnClick="btnCancel2_Click">
                </asp:Button>
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
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

