<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_SubCategoryEdit, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp3" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" align="center" style="width: 65%">
                    <tr>
                        <td align="center" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" style="background: url(../../../images/hdbg.JPG)"
                            height="21" class="fontcsswhite">
                            <b>&nbsp;Item SubCategory - Edit</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="SCId" DataSourceID="LocalSqlServer" CssClass="yui-datatable-theme"
                                OnRowCommand="GridView1_RowCommand" OnRowUpdated="GridView1_RowUpdated" 
                                Width="100%" OnRowDataBound="GridView1_RowDataBound" PageSize="20">
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" SortExpression="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Link"   ValidationGroup="c" ShowEditButton="True">
                                    
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCId" runat="server" Text='<%#Eval("catsy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddCategory1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Expr1"
                                                DataValueField="CId">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemStyle Width="35%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category" SortExpression="SCName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Width="95%" Text='<%# Bind("SCName") %>'></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="ReqCat" runat="server"  ValidationGroup="c" ControlToValidate="TextBox1"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SCName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="35%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Width="93%" Text='<%# Bind("Symbol") %>' MaxLength="2"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="ReqSym" runat="server"  ValidationGroup="c" ControlToValidate="TextBox2"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label>
                                        </ItemTemplate>
                                          <ItemStyle Width="25%" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle Wrap="True"></FooterStyle>
                                <HeaderStyle HorizontalAlign="Center" />
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
                            <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:SqlDataSource ID="LocalSqlServer" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [tblDG_SubCategory_Master].[SCId],[tblDG_SubCategory_Master].[CId],[tblDG_SubCategory_Master].SCName,[tblDG_SubCategory_Master].[Symbol],[tblDG_Category_Master].[Symbol] + ' - '+ [tblDG_Category_Master].[CName] as catsy FROM [tblDG_SubCategory_Master],[tblDG_Category_Master] Where [tblDG_SubCategory_Master].[CId]=[tblDG_Category_Master].[CId] And [tblDG_SubCategory_Master].[CompId] = @CompId AND [tblDG_SubCategory_Master].[FinYearId] &lt;= @FinYearId order by [tblDG_SubCategory_Master].[SCId] desc"
                                UpdateCommand="UPDATE [tblDG_SubCategory_Master] SET [CId] = @CId, [SCName] = @SCName, [Symbol] = @Symbol WHERE [SCId] = @SCId And [CompId] = @CompId">
                                <UpdateParameters>
                                    <asp:Parameter Name="CId" Type="Int32" />
                                    <asp:Parameter Name="SCName" Type="String" />
                                    <asp:Parameter Name="Symbol" Type="String" />
                                    <asp:Parameter Name="SCId" Type="Int32" />
                                    <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                                </UpdateParameters>
                                
                                <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                        <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                    </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="select CId,Symbol + ' - ' + CName AS Expr1 from tblDG_Category_Master WHERE [CompId] = @CompId AND [FinYearId] &lt;= @FinYearId And [HasSubCat]!='0'">
                       <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                        <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                    </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" runat="Server">
</asp:Content>
