<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ASPR_New.aspx.cs" Inherits="Module_MaterialManagement_Transactions_ASPR_New" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style5
        {
            height: 31px;
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







<script type="text/javascript">
    function OnChanged(sender, args) {
        ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
    }
    </script>
<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>SPR - New</b></td>
        </tr>
        <tr>
            <td valign="top">
<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="410px"
Width="100%"  AutoPostBack="True">
<cc1:TabPanel runat="server" HeaderText="Item Master" ID="TabPanel1"><HeaderTemplate>Item Master</HeaderTemplate><ContentTemplate><table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px"><tr><td class="style5" height="30"><asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem><asp:ListItem Value="Category">Category</asp:ListItem><asp:ListItem Value="WOItems">WO Items</asp:ListItem></asp:DropDownList><asp:DropDownList ID="DrpCategory" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" Height="21px" 
                    CssClass="box3"></asp:DropDownList><asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem></asp:DropDownList><asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px" 
                    AutoPostBack="True" CssClass="box3"></asp:DropDownList><asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>&#160;<asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  /></td></tr><tr><td class="fontcss" valign="top"><asp:GridView ID="GridView2" runat="server" AllowPaging="False" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCommand="GridView2_RowCommand" PageSize="17" Width="85%" ><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField 
                                        HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:TemplateField><asp:TemplateField ><ItemTemplate><asp:LinkButton ID="LinkButton1" CommandName="Sel" Text="Select" runat="server"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" /></asp:TemplateField><asp:BoundField DataField="Id" HeaderText="Id" Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="SubCategory" HeaderText="SubCategory" 
                        Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="ItemCode" HeaderText="Item Code"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="ManfDesc" HeaderText="Description"><ItemStyle VerticalAlign="Top" Width="55%" /></asp:BoundField><asp:BoundField DataField="UOMBasic" HeaderText="UOM"><ItemStyle VerticalAlign="Top" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="StockQty" HeaderText="Stock Qty"><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="Location" HeaderText="Location"><ItemStyle VerticalAlign="Top" /></asp:BoundField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" /></asp:GridView></td></tr></table>

    </ContentTemplate>

</cc1:TabPanel>

<cc1:TabPanel ID="TabPanel2" HeaderText="No Code Item" runat="server"><HeaderTemplate>No Code Item</HeaderTemplate>
    <ContentTemplate><asp:Panel ID="Panel2" runat="server"><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td><table align="left" cellpadding="0" cellspacing="0" style="height: 254px" 
                        width="100%"><tr><td class="style6" height="25" valign="top">Description</td><td class="style11" valign="top"><asp:TextBox 
                ID="txtManfDesc" runat="server" CssClass="box3" Height="71px" 
                                    TextMode="MultiLine" Width="373px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtManfDesc" ErrorMessage="*" ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator></td><td class="style4" rowspan="5" valign="top"><table align="left" cellpadding="0" cellspacing="0" style="height: 230px" 
                                    width="100%"><tr><td class="style5" height="25">UOM&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DDLUnitBasic" runat="server" CssClass="box3" 
                                                ValidationGroup="NoCodeTabAdd"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                ControlToValidate="DDLUnitBasic" ErrorMessage="*" InitialValue="Select" 
                                                ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator></td></tr><tr><td height="25"><asp:RadioButton ID="rdwono" runat="server" Checked="True" GroupName="A" 
                                                Text="WO No" AutoPostBack="True" 
                        oncheckedchanged="rdwono_CheckedChanged" /><asp:TextBox ID="txtwono" runat="server" Width="64px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqWono" runat="server" 
                        ControlToValidate="txtwono" ErrorMessage="*" ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator><asp:RadioButton ID="rddept" runat="server" GroupName="A" Text="BG Group" 
                                                AutoPostBack="True" 
                        oncheckedchanged="rddept_CheckedChanged" /><asp:DropDownList ID="drpdept" runat="server" DataSourceID="SqlDataSource1" 
                                                DataTextField="Dept" DataValueField="Id"  CssClass="box3"></asp:DropDownList></td></tr><tr><td class="style7">Delivery Date <asp:TextBox ID="textDelDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="textDelDate_CalendarExtender" runat="server" 
                      Enabled="True" Format="dd-MM-yyyy" TargetControlID="textDelDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDelDate" runat="server" 
                      ControlToValidate="textDelDate" ErrorMessage="*" ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDelverylDate" runat="server" 
                      ControlToValidate="textDelDate" ErrorMessage="*" 
                      ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                      ValidationGroup="NoCodeTabAdd"></asp:RegularExpressionValidator></td></tr><tr><td class="style7">Remarks </td></tr><tr><td><asp:TextBox ID="txtRemark" runat="server" CssClass="box3" Height="52px" 
                                                TextMode="MultiLine" Width="367px"></asp:TextBox></td></tr><tr><td><asp:Button ID="btnAdd" runat="server" CssClass="redbox" OnClick="btnAdd_Click" 
                                                OnClientClick=" return confirmationAdd()"  Text="Add" ValidationGroup="NoCodeTabAdd" /></td></tr></table></td></tr><tr><td class="style10">Qty </td><td valign="middle" class="style11"><asp:TextBox ID="txtQty" runat="server" CssClass="box3" Width="96px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegQty" runat="server" 
                ControlToValidate="txtQty" ErrorMessage="*" 
                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="NoCodeTabAdd"></asp:RegularExpressionValidator>Rate: <asp:TextBox ID="txtRate" runat="server" CssClass="box3" Width="96px">0</asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegQty0" runat="server" 
                ControlToValidate="txtRate" ErrorMessage="*" 
                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="NoCodeTabAdd"></asp:RegularExpressionValidator>Discount <asp:TextBox ID="txtDiscount" runat="server" CssClass="box3" Width="96px">0</asp:TextBox><asp:RegularExpressionValidator ID="RegDiscount" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="NoCodeTabAdd"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator></td></tr><tr><td class="style10">Supplier </td><td class="style11" height="25" valign="middle"><asp:TextBox ID="txtAutoSupplierExt" runat="server" CssClass="box3" 
                                    OnTextChanged="txtAutoSupplierExt_TextChanged" Width="358px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtAutoSupplierExt_AutoCompleteExtender" 
                                    runat="server" CompletionInterval="100" CompletionSetCount="2" 
                                    DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                    MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                    ShowOnlyCurrentWordInCompletionListItem="True" 
                                    TargetControlID="txtAutoSupplierExt" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtAutoSupplierExt" ErrorMessage="*" 
                                    ValidationGroup="NoCodeTabAdd"></asp:RequiredFieldValidator></td></tr><tr><td 
                class="style15">A/c Head </td><td class="style16" valign="middle"><asp:RadioButton ID="RbtnLabour" runat="server" AutoPostBack="True" 
                                    Checked="True" GroupName="GroupACHead" 
                                    OnCheckedChanged="RbtnLabour_CheckedChanged" Text="Labour" /><asp:RadioButton ID="RbtnWithMaterial" runat="server" AutoPostBack="True" 
                                    GroupName="GroupACHead" OnCheckedChanged="RbtnWithMaterial_CheckedChanged" 
                                    Text="With Material" />&#160;&#160;<asp:RadioButton 
                    ID="RbtnExpenses" runat="server" AutoPostBack="True" GroupName="GroupACHead" 
                    OnCheckedChanged="RbtnExpenses_CheckedChanged" Text="Expenses" />
                <asp:RadioButton ID="RbtnSerProvider" runat="server" AutoPostBack="True" 
                    GroupName="GroupACHead" OnCheckedChanged="RbtnSerProvider_CheckedChanged" 
                    Text="Ser. Provider" />
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" 
                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td></tr><tr><td class="style6" height="25">&#160;</td><td align="right" class="style11"><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="Select Id, Symbol as Dept from BusinessGroup"></asp:SqlDataSource><asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label></td></tr></table></td></tr></table></asp:Panel>
    </ContentTemplate></cc1:TabPanel>

    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
        <HeaderTemplate>
        Selected Items</HeaderTemplate>
        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0"  width="100%"><tr><td><asp:Panel ID="Panel1" runat="server" Height="420px" ScrollBars="Auto" 
                            Width="100%"><asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                OnPageIndexChanging="GridView3_PageIndexChanging" 
                                OnRowCommand="GridView3_RowCommand" Width="100%" 
                                AutoGenerateColumns="False" PageSize="15"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBtn" runat="server" OnClientClick=" return confirmationDelete()" 
                Text="Delete" CommandName="del" ></asp:LinkButton></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label></ItemTemplate><ItemStyle Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="No Code"><ItemTemplate><asp:Label ID="lblnocode" runat="server" Text='<%#Eval("NoCode") %>'></asp:Label></ItemTemplate><ItemStyle Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblManfDecs" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lbluomBase" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Del.Date"><ItemTemplate><asp:Label ID="lblDelDate" runat="server" Text='<%#Eval("DelDate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="A/c Head"><ItemTemplate><asp:Label ID="lblac" runat="server" Text='<%#Eval("A/cHead") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="WONo"><ItemTemplate><asp:Label ID="lblwono" runat="server" Text='<%#Eval("WONo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Dept"><ItemTemplate><asp:Label ID="lblDept" runat="server" Text='<%#Eval("Dept") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Qty"><ItemTemplate><asp:Label ID="lblqty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Rate"><ItemTemplate><asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Dis"><ItemTemplate><asp:Label ID="lblDis" runat="server" Text='<%#Eval("Discount") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Remarks"><ItemTemplate><asp:Label ID="lblremark" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label></ItemTemplate><ItemStyle Width="18%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></asp:Panel></td></tr></table>
                    
        </ContentTemplate>
    </cc1:TabPanel>

</cc1:TabContainer>
</td>
</tr>
        <tr>
            <td valign="bottom" height="25" width="92%" align="right">
                <asp:Button ID="Button1" runat="server"  OnClientClick=" return confirmationAdd()"    CssClass="redbox" Text="Proceed" 
                    onclick="Button1_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="redbox" 
                    onclick="btnCancel_Click" />
            </td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

