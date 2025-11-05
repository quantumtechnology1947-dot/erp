<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SalesInvoice_New.aspx.cs" Inherits="Module_Accounts_Transactions_SalesInvoice_New" Title="ERP" Theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    </style>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td style="background:url(../../../images/hdbg.JPG); height:21px" class="fontcsswhite" >&nbsp;<b>Sales Invoice - New</b></td>
        </tr>
        <tr>
        <td height="25">
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" 
                                onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                               <%--  <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                                <asp:ListItem Value="0">Customer Name</asp:ListItem>
                                 <asp:ListItem Value="1">PO No</asp:ListItem>
                            </asp:DropDownList>
&nbsp;
                <asp:TextBox ID="txtCustName" runat="server" CssClass="box3"  Width="350px"></asp:TextBox>
         
         <cc1:AutoCompleteExtender ID="txtCustName_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtCustName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
        
                            
                            <asp:TextBox ID="txtpoNo" runat="server" Visible="False" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox"  Text="Search" 
                                onclick="btnSearch_Click" />
                            
        </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server"  
                    AutoGenerateColumns="False" Width="100%" CssClass="yui-datatable-theme" 
                    onrowcommand="GridView1_RowCommand" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="15" 
                    AllowPaging="True">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Name of Customer">
                         <ItemTemplate>
                        <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="PO No">
                         <ItemTemplate>
                        <asp:Label ID="lblPONo" runat="server" Text='<%#Eval("PONo") %>'></asp:Label>
                        </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WO No">
                         <ItemTemplate>
                       
    <asp:Panel ID="Panel3" runat="server" Style="display:none; visibility:hidden;" 
        Width="320Px">
        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True"          
            Height="60px" onselectedindexchanged="ListBox1_SelectedIndexChanged" 
            Width="320px"></asp:ListBox>

    </asp:Panel>
    <asp:TextBox ID="TxtPF" runat="server"  CssClass="box3" Width="320px" 
        ReadOnly="True"></asp:TextBox>
    <cc1:DropDownExtender ID="TxtPF_DropDownExtender" runat="server" 
        DropDownControlID="Panel3" DynamicServicePath="" Enabled="True" 
        TargetControlID="TxtPF">
    </cc1:DropDownExtender>    
    <asp:Label ID="hfWOno" runat="server" Visible="false"></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="left" Width="5%" />
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="PO Id" Visible="False">
                         <ItemTemplate>
                        <asp:Label ID="lblPOId" runat="server" Text='<%#Eval("POId") %>'></asp:Label>
                        </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center"  />
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderText="Type">
                        <ItemTemplate>
                        <asp:DropDownList ID="drp1" Width="100%" runat="server" DataTextField="Description" DataValueField="Id" DataSourceID="Sqltype" >
                          </asp:DropDownList>
                                           
                        </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                      <asp:LinkButton ID="Btn1"   Text="Select" CommandName="Sel" runat="server"></asp:LinkButton>
                        
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                         <asp:TemplateField Visible="false" HeaderText="CustomerId">
                        <ItemTemplate>
                       <asp:Label ID="lblCustId" runat="server" Text='<%#Eval("CustomerId") %>'></asp:Label>
                        
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inv Count">
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
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
                <asp:SqlDataSource ID="Sqltype" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblACC_SalesInvoice_Master_Type] order by [Id] ASC"></asp:SqlDataSource>
              
              <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [WONo] FROM [SD_Cust_WorkOrder_Master] WHERE ([POId] = '13')">
                  
                </asp:SqlDataSource>  --%>                         
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

