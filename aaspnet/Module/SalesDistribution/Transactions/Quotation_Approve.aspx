<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_Quotation_Approve, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" /> 
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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
                style="background:url(../../../images/hdbg.JPG)">&nbsp;<b>Quotation Approve</b></td>
                    </tr>
                    
                    <tr>
                        <td height="25">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                AutoPostBack="True" onselectedindexchanged="drpfield_SelectedIndexChanged">
                                <asp:ListItem Value="0">Quotation No</asp:ListItem>
                                <asp:ListItem Value="1">Customer</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" CssClass="box3" Visible="False" Width="250px"></asp:TextBox>

                            <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>

                            &nbsp;<asp:TextBox ID="txtPONo" runat="server" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" onclick="Button1_Click" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td>                       
                            <asp:GridView ID="GridView2" runat="server" 
                                Width="100%" ShowFooter="true"  CssClass="yui-datatable-theme" 
                                PageSize="20" AutoGenerateColumns="False" 
                                DataKeyNames="Id" onrowcommand="GridView2_RowCommand" 
                                onpageindexchanging="GridView2_PageIndexChanging">
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
                                    
                                    
                                    <asp:TemplateField HeaderText="Fin Year">
                                    <ItemTemplate>
                                    <asp:Label ID="lblfinyrs" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Quotation No" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblQuotationNo" runat="server" Text='<%# Bind("QuotationNo") %>'></asp:Label>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtn" runat="server" Text="View" CommandName="view"></asp:LinkButton>
                                    </ItemTemplate> 
<ItemStyle HorizontalAlign="Center"></ItemStyle>                                  
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lbldate" runat="server" Text='<%# Bind("SysDate") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <%--<asp:TemplateField HeaderText="AmdNo" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lbltime" runat="server"  Text='<%# Bind("AmdNo") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    </asp:TemplateField>--%>
                                    
                                    <asp:TemplateField HeaderText="Gen. By" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblgenby" runat="server"  Text='<%# Bind("EmpLoyeeName") %>'></asp:Label>
                                    </ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="23%"></ItemStyle>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Customer" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" runat="server" Text='<%# Bind("CustomerName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="23%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustcode" runat="server" Text='<%# Bind("CustomerId") %>'></asp:Label></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Checked" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                   
                                    <asp:Label ID="lblcheck" runat="server" Text='<%# Bind("CheckedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                                   
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="For Approve" ItemStyle-HorizontalAlign="center">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                    <asp:CheckBox ID="CK" runat="server"/>
                                    <asp:Label ID="lblApproved" runat="server" Text='<%# Bind("ApprovedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                                     <FooterTemplate>
                                    <asp:Button ID="App" Text="Approved" CssClass="redbox" runat="server" 
                                    OnClientClick=" return confirmation()" CommandName="App"/>
                                    </FooterTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Authorized" ItemStyle-HorizontalAlign="center">         
<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

