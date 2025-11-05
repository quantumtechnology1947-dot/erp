<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_CategoryEdit, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 24px;
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

<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="70%" align="center">
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp; 
                Item Category - Edit</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                AutoGenerateColumns="False" 
                DataKeyNames="CId" 
                DataSourceID="LocalSqlServer"
                CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onrowupdated="GridView1_RowUpdated" onrowcommand="GridView1_RowCommand" 
                    PageSize="20">
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>                        
                        <asp:CommandField  ButtonType="Link" ShowEditButton="True" ValidationGroup="c" >                        
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="CId" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<% #Eval("CId") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Category" SortExpression="CName">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCate" CssClass="box3" runat="server" Width="95%" Text='<%# Bind("CName") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqCat" runat="server"  ValidationGroup="c" ControlToValidate="txtCate"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                            <EditItemTemplate>                                                        
                            <asp:Label ID="lblSy" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Has SubCategory" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblsubcatNo" runat="server" Text='<%#Eval("HasSubCat") %>'>    </asp:Label>
                        </ItemTemplate>  
                        
                         <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" /> 
                         </EditItemTemplate>                     
                        
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
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
                
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [CId], [CName], [Symbol],[HasSubCat] FROM [tblDG_Category_Master]WHERE (([CompId] = @CompId) AND ([FinYearId] &lt;= @FinYearId)) order by [CId] desc"           
                    UpdateCommand="UPDATE [tblDG_Category_Master] SET [CName] = @CName2 WHERE [CId] = @CId2"  >
                    <UpdateParameters>
                        <asp:Parameter Name="CName2" Type="String" />                        
                        <asp:Parameter Name="CId2" Type="Int32" />                      
                        
                    </UpdateParameters>
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

