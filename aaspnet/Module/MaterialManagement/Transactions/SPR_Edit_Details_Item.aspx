<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_SPR_Edit_Details_Item, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <table align="center" cellpadding="0" cellspacing="0"  width="70%">
                <tr>
                <td>
              <table align="center" cellpadding="0" cellspacing="0" class="box3" width="100%">
                <tr>
                <td  height="20" align="left" valign="middle"  scope="col" 
                class="fontcsswhite" style="background:url(../../../images/hdbg.JPG)">&nbsp;<b>SPR - 
                    Edit</b></td>
                </tr>
                <tr>
                <td>
                <table align="left" cellpadding="0" cellspacing="0" width="100%" 
                style="height: 191px" >
                <tr >
                <td class="style11" valign="middle">
                &nbsp; <b>Item Code</b></td>
                <td 
                class="style10" valign="middle" colspan="2" >
                    <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                </td>
                </tr>
                <tr >
                <td class="style12" valign="top" >
                    &nbsp; <b>Description</b></td>
                <td 
                class="style9" valign="top" colspan="2">
                    <asp:TextBox ID="txtManfDesc" runat="server" TextMode="MultiLine" Width="388px" 
                        Height="71px"></asp:TextBox>
                </td>
                </tr>
                <tr >
                <td class="style13" >
                    &nbsp; <b>UOM</b></td>
                <td height="22" colspan="2">
                &nbsp;<asp:DropDownList ID="DDLUomBasic" runat="server">
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="DDLUomBasic" ErrorMessage="*" InitialValue="Select" 
                                        ValidationGroup="EditIcode" CssClass="box3"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                </tr>
                <tr>
                <td class="style13" >
                &nbsp;&nbsp;<b>Qty</b></td>
                <td height="25" colspan="2" >
                <asp:TextBox runat="server" CssClass="box3" ID="txtQty"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="QtyAdd">
                    </asp:RequiredFieldValidator>
                                       
              <asp:CompareValidator ID="CompareValidator2" runat="server" Operator="DataTypeCheck" Type="Integer"
 	ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="QtyAdd" />
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
                                runat="server" ControlToValidate="txtQty" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                        ValidationGroup="QtyAdd"></asp:RegularExpressionValidator>
                    
                </td>
                </tr>
                <tr>
                <td class="style13" >
                    &nbsp;&nbsp;<b>Rate</b></td>
                <td height="25" colspan="2" >
                <asp:TextBox runat="server" CssClass="box3" ID="txtRate"></asp:TextBox>
                    &nbsp;<a  runat="server" id="rt"><img  alt="" src="../../../images/Rupee.JPG" border="0"/></a>
                    
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="QtyAdd"></asp:RequiredFieldValidator>
                                       
              <asp:CompareValidator ID="CompareValidator3" runat="server" Operator="DataTypeCheck" Type="Double"
 	ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="QtyAdd" />
                    
                </td>
                </tr>
                <tr>
                <td class="style13" >
                    &nbsp;<b>Discount</b></td>
                <td height="25" colspan="2" >
                <asp:TextBox runat="server" CssClass="box3" ID="txtDiscount"></asp:TextBox>
                                       
              <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck" Type="Double"
 	ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="QtyAdd" />
                    
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="QtyAdd"></asp:RequiredFieldValidator>
                                       
                </td>
                </tr>
                <tr >
                <td  class="style18">&nbsp; <b>Supplier</b></td>

                <td class="style19" colspan="2">

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
                &nbsp; <b>A/c Head</b></td>
                <td width="45%" >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                        RepeatDirection="Horizontal" Enabled="False">
                        <asp:ListItem Value="1">Labour</asp:ListItem>
                        <asp:ListItem Value="2">With Material</asp:ListItem>
                        <asp:ListItem Value="3">Expenses</asp:ListItem>
                        <asp:ListItem Value="4">Ser. provider</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td >
                <asp:DropDownList runat="server" CssClass="box3" ID="DropDownList1" 
                        AutoPostBack="True" Enabled="False">
                </asp:DropDownList>
                </td>
                </tr>
                <tr >
                <td class="style15"  valign="top">
                    &nbsp; </td>
                <td 
                class="style8" colspan="2" >
                    <asp:RadioButton ID="rddept" runat="server" GroupName="A" Text="BG Group" 
                        AutoPostBack="True" Checked="True" />
&nbsp;
                    <asp:DropDownList ID="drpdept" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="Dept" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="rdwono" runat="server" GroupName="A" 
                        Text="WO No" AutoPostBack="True" />
                    <asp:TextBox ID="txtwono" runat="server" Width="84px" CssClass="box3"></asp:TextBox>
                </td>
                </tr>
                <tr >
                <td class="style16"  valign="top">
                &nbsp;&nbsp;<b>Delivery Date</b></td>
                <td 
                class="style17" colspan="2" >
                    <asp:TextBox runat="server" CssClass="box3" ID="textDelDate" Width="100px"></asp:TextBox>
                    <cc1:CalendarExtender runat="server" Format="dd-MM-yyyy" Enabled="True" 
                        TargetControlID="textDelDate" ID="textDelDate_CalendarExtender">
                    </cc1:CalendarExtender>
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
                &nbsp; <b>Remarks</b></td>
                <td 
                class="style8" colspan="2" >
                <asp:TextBox runat="server" TextMode="MultiLine" CssClass="box3" Height="155px" 
                Width="409px" ID="txtRemark"></asp:TextBox>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, '['+Symbol+'] '+Name as Dept from BusinessGroup"></asp:SqlDataSource>
                </td>
                </tr>
                <tr >
                <td class="style15" >
                    </td>
                <td 
                class="style8" colspan="2" >
                <asp:Button runat="server" Text="Update" CssClass="redbox" ID="btnUpdate"  OnClientClick=" return confirmationUpdate()" 
                ValidationGroup="QtyAdd" onclick="btnUpdate_Click"></asp:Button>
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
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

