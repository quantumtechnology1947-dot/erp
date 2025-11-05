<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="APO_New.aspx.cs" Inherits="Module_MaterialManagement_Transactions_APO_New" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style5
        {
            height: 32px;
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
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" class="fontcsswhite" height="20" scope="col" style="background: url(../../../images/hdbg.JPG)" valign="middle">&nbsp;<b>PO - New</b></td>
        </tr>
        <tr>
            <td align="left">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged1" >
                    <cc1:TabPanel runat="server" HeaderText="PR" ID="PR" Visible="false">
                        <HeaderTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                        
                        
                    </HeaderTemplate>
                        
<ContentTemplate><table align="center" cellpadding="0" cellspacing="0" 
                                style="width: 77%"><tr>
                            <td align="left" class="style5">&nbsp;&nbsp;<b>Supplier</b>&nbsp; 
                                <asp:TextBox ID="txtSupplierPR" runat="server" Width="336px" CssClass="box3"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSupplierPR" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
                                &nbsp;<asp:Button 
                                    ID="Button1" runat="server" CssClass="redbox" Text="Search" 
                                    onclick="Button1_Click" /></td></tr><tr><td>
                                
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                            CssClass="yui-datatable-theme" Width="100%" 
                                            AllowPaging="True" onrowcommand="GridView2_RowCommand" onpageindexchanging="GridView2_PageIndexChanging" 
                                    PageSize="17" >
                                            <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                   <asp:TemplateField>
                                   <ItemTemplate>
                                   <asp:LinkButton CommandName="selme" runat="server" ID="lnkButton" Text="Select"></asp:LinkButton> 
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="7%" />
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier">
                                    <ItemTemplate>
                                    <asp:Label ID="lblsupl" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="60%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                    <asp:Label ID="lblcode" runat="server" Text='<%# Eval("Code") %>'></asp:Label>
                                                </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of Items">
                                    <ItemTemplate>
                                    <asp:Label ID="lblnoites" runat="server" Text='<%# Eval("Items") %>'></asp:Label>
                                                </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
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
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                            </asp:GridView>
                            
                            </td></tr></table>
                        </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="SPR" runat="server" HeaderText="SPR">
                        <HeaderTemplate>
                            &nbsp;&nbsp;SPR&nbsp;&nbsp;
                        
                        
                    </HeaderTemplate>
                        
<ContentTemplate><table align="center" cellpadding="0" cellspacing="0" border="0" 
                                style="width: 77%"><tr><td align="left" height="30"><b>&nbsp; 
        Supplier&nbsp;&nbsp; 
                                <asp:TextBox ID="txtSearchSupplier" runat="server" Width="336px" 
                                    CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="txtSearchSupplier_AutoCompleteExtender" 
                                            runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtSearchSupplier" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>
        &nbsp;</b><asp:Button 
                                ID="btnSearch" runat="server" CssClass="redbox" Text="Search" 
                                onclick="btnSearch_Click" />&nbsp;</td></tr><tr><td align="left">
                                <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
                                    CssClass="yui-datatable-theme" 
                                    OnPageIndexChanging="GridView5_PageIndexChanging" 
                                    OnRowCommand="GridView5_RowCommand" 
                                    Width="100%" AutoGenerateColumns="False" PageSize="17">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1  %>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Size="10pt" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField>
                                   <ItemTemplate>
                                   <asp:LinkButton CommandName="sel" runat="server" ID="lnkButton" Text="Select"></asp:LinkButton> 
                                   </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" />
                                   </asp:TemplateField>                                  
                                    
                                        <asp:TemplateField HeaderText="Supplier">
                                            <ItemTemplate>
                                            <asp:Label ID="lblsprsup" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code">
                                            <ItemTemplate>
                                            <asp:Label ID="lblsprcode" runat="server" Text='<%# Eval("Code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. Of Items">
                                            <ItemTemplate>
                                            <asp:Label ID="lblspritems" runat="server" Text='<%# Eval("Items") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
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
                                    <FooterStyle Wrap="True" />
                                </asp:GridView>
                                </td></tr></table>
                        </ContentTemplate>
                    
</cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
    </table>



</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

