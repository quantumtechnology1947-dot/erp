<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_CategoryDelete, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="70%" align="center">
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Item Category - Delete</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                AutoGenerateColumns="False" 
                DataSourceID="SqlDataSource1"
               CssClass="yui-datatable-theme" Width="100%" DataKeyNames="CId" 
                    onrowdeleted="GridView1_RowDeleted" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="20" 
                   >
                  
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Link" ShowDeleteButton="True" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="CId" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<% #Eval("CId") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CName" HeaderText="Category" 
                            SortExpression="CName" >
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Symbol" HeaderText="Symbol" 
                            SortExpression="Symbol" >
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
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
                    
                    
                    <HeaderStyle HorizontalAlign="Center" />
                    
                    
              </asp:GridView>
                
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblDG_Category_Master] WHERE [CId] = @CId" 
                    
                    SelectCommand="SELECT * FROM [tblDG_Category_Master]WHERE (([CompId] = @CompId) AND ([FinYearId] &lt;= @FinYearId)) order by [CId] desc">
                    <DeleteParameters>
                        <asp:Parameter Name="CId" Type="Int32" />
                    </DeleteParameters>
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
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

