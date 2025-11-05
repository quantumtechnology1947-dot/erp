<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_Delete_Supplier, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <table align="center" cellpadding="0" cellspacing="0" border="0" 
                                style="width: 100%"><tr><td height="21" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PO - Delete</b></td></tr><tr><td align="left" height="30"><b>&nbsp; Supplier&nbsp;&nbsp; 
                                <asp:TextBox runat="server" CssClass="box3" Width="336px" ID="txtSearchSupplier"></asp:TextBox>
         <cc1:AutoCompleteExtender runat="server" MinimumPrefixLength="1" CompletionInterval="100" CompletionSetCount="1" ServiceMethod="sql" ServicePath="" UseContextKey="True" DelimiterCharacters="" FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True" Enabled="True" TargetControlID="txtSearchSupplier" ID="txtSearchSupplier_AutoCompleteExtender" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
         </cc1:AutoCompleteExtender>
         &#160;<asp:Button runat="server" Text="Search" CssClass="redbox" ID="btnSearch" OnClick="btnSearch_Click">
         </asp:Button>
         </b>&#160;</td></tr><tr><td align="left">
                                <asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
                                    CssClass="yui-datatable-theme" 
                                    OnPageIndexChanging="GridView5_PageIndexChanging" 
                                    OnRowCommand="GridView5_RowCommand" PageSize="20" 
                                    Width="600px" AutoGenerateColumns="False">
                                    <PagerSettings PageButtonCount="40" />
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
                                        <asp:LinkButton id="lnkbutton" runat="server" Text="Select" CommandName="sel"></asp:LinkButton>
                                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" Width="7%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Supplier">
                                            <ItemTemplate>
                                            <asp:Label ID="lblposup" runat="server" Text='<%# Eval("POSupplier") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code">
                                            <ItemTemplate>
                                            <asp:Label ID="lblpocode" runat="server" Text='<%# Eval("POCode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No. Of PO">
                                            <ItemTemplate>
                                            <asp:Label ID="lblpoitems" runat="server" Text='<%# Eval("POItems") %>'></asp:Label>
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
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

