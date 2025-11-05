<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PO_Dashboard.aspx.cs" Inherits="Module_MaterialManagement_Transactions_PO_Dashboard" Title="ERP" Theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
<style type="text/css">
        .style2
        {
            width: 100%;
            height: 335px;
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
<table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">&nbsp;<b>PO</b></td>
                    </tr>
                    
                    <tr>
                        <td height="25">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                 AutoPostBack="True" 
                                onselectedindexchanged="drpfield_SelectedIndexChanged">
                                <asp:ListItem Value="0">Supplier</asp:ListItem>
                                <asp:ListItem Value="1">PO No</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" CssClass="box3" Width="350px"></asp:TextBox>

                            <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList2" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                           
                            <asp:TextBox ID="txtPONo" runat="server" Visible="False" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" onclick="Button1_Click" />

                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                       
                            <asp:GridView ID="GridView2" runat="server" 
                                Width="100%" CssClass="yui-datatable-theme" 
                                AllowPaging="True" AutoGenerateColumns="False" 
                                DataKeyNames="Id" onrowcommand="GridView2_RowCommand" 
                                onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="20" 
                                onpageindexchanging="GridView2_PageIndexChanging1">
                                <PagerSettings PageButtonCount="40" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                      <asp:TemplateField HeaderText="AmendmentNo" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblAmendmentNo" runat="server" Text='<%# Eval("AmendmentNo") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Fin Year">
                                    <ItemTemplate>
                                    <asp:Label ID="lblfin" runat="server" Text='<%# Eval("FinYearId") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="PO No" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblsprno" runat="server" Text='<%# Bind("PONo") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField>
                                    <ItemTemplate>
                                    <asp:LinkButton ID="lnkview" CommandName="view" runat="server" Text="View"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Time" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lbltime" runat="server"  Text='<%# Bind("Time") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Gen By" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblgenby" runat="server"  Text='<%# Bind("GenBy") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="22%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Supplier">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsup" runat="server" Text='<%# Bind("Sup") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="22%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                        <ItemTemplate>
                                        <asp:Label ID="lblsupcode" runat="server" Text='<%# Bind("Code") %>'></asp:Label></ItemTemplate>
                                        <ItemStyle Width="7%" HorizontalAlign="Center"/>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Checked" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                   
                                    <asp:Label ID="lblcheck" runat="server" Text='<%# Bind("CheckedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                   
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Approved" ItemStyle-HorizontalAlign="center">
<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    <ItemTemplate>
                                    
                                    <asp:Label ID="lblApproved" runat="server" Text='<%# Bind("ApprovedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                     
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Authorized" ItemStyle-HorizontalAlign="center">         
<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
<ItemTemplate>

                                    <asp:Label ID="lblAutho" runat="server" Text='<%# Bind("AuthorizedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                            </asp:GridView>
                            <br />
                        </td>
                    </tr>
                    
                  <%--  <tr>
                        <td>
                            <table align="left" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">&nbsp;<b>Status of Stock ReOrder Level</b></td>
                                </tr>
                                <tr>
                                    <td>
                                       <asp:GridView ID="GridView1" runat="server" 
                                Width="100%" CssClass="yui-datatable-theme" 
                                AllowPaging="True" AutoGenerateColumns="False" 
                                DataKeyNames="Id" onpageindexchanging="GridView1_PageIndexChanging" >
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Sub Category" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblSubCategory" runat="server" Text='<%# Bind("SubCategory") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                    </asp:TemplateField>
                                    
                                  
                                    
                                    <asp:TemplateField HeaderText="Item Code" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" ></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="center">

<ItemStyle HorizontalAlign="Left" ></ItemStyle>
                                    <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server"  Text='<%# Bind("ManfDesc") %>'></asp:Label>
                                    
                                    </ItemTemplate>
                                    <ItemStyle  Width="30%" />

                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="UOM" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblUOM" runat="server"  Text='<%# Bind("UOMBasic") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" ></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Min. Stock Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMinStockQty" runat="server" Text='<%# Bind("MinStockQty") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                        <ItemStyle HorizontalAlign="Right" />
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="StockQty">
                                        <ItemTemplate>
                                        <asp:Label ID="lblStockQty" runat="server" Text='<%# Bind("StockQty") %>'></asp:Label></ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Right"/>
                                    </asp:TemplateField>
                                    
                                 
                                </Columns>
                                <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                            </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>--%>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

