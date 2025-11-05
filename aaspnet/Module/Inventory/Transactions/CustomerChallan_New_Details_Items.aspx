<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_CustomerChallan_New_Details_Items, newerp_deploy" title="ERP" theme="Default" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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

 <table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0" >
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" ><strong>&nbsp;Customer Challan</strong>
                        </td>
                    </tr>
<tr><td class="style5" height="30"><asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
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
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  /></td></tr><tr><td class="fontcss" valign="top">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCommand="GridView2_RowCommand" PageSize="17" Width="85%" >
            <PagerSettings PageButtonCount="40" />
            <Columns>                                        
                <asp:TemplateField 
                                        HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ><ItemTemplate><asp:LinkButton ID="LinkButton1" CommandName="Sel" Text="Select" runat="server"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" /></asp:TemplateField><asp:BoundField DataField="Id" HeaderText="Id" Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="SubCategory" HeaderText="SubCategory" 
                        Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="ItemCode" HeaderText="Item Code"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="ManfDesc" HeaderText="Description"><ItemStyle VerticalAlign="Top" Width="55%" /></asp:BoundField><asp:BoundField DataField="UOMBasic" HeaderText="UOM"><ItemStyle VerticalAlign="Top" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="StockQty" HeaderText="Stock Qty"><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="Location" HeaderText="Location"><ItemStyle VerticalAlign="Top" /></asp:BoundField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" /></asp:GridView></td></tr></table>
                        </td></tr></table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

