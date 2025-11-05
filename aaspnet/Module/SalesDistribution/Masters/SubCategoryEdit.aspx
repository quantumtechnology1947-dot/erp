<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Masters_SubCategoryEdit, newerp_deploy" title="ERP" theme="Default" %>

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
                <table cellpadding="0" cellspacing="0" align="center" style="width: 100%">
                  
                    <tr>
                        <td align="left" valign="middle" style="background: url(../../../images/hdbg.JPG)"
                            height="21" class="fontcsswhite">
                            <b>&nbsp;WO SubCategory - Edit</b>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="SCId"  CssClass="yui-datatable-theme"                               
                                Width="65%" onrowcommand="GridView1_RowCommand" 
                                onpageindexchanging="GridView1_PageIndexChanging" PageSize="20" 
                                onrowcancelingedit="GridView1_RowCancelingEdit" 
                                onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                                onrowupdated="GridView1_RowUpdated" >
                                <Columns>
                                    <asp:TemplateField HeaderText="SN" SortExpression="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    
                                    <asp:CommandField ShowEditButton="True" ValidationGroup="abc"  ButtonType="Link" >
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:CommandField>
                                                                   
                                    
                                    <asp:TemplateField HeaderText="SCId" Visible="false" >
                                        <ItemTemplate>
                                           <asp:Label ID="lblSCId" runat="server" Text='<%#Eval("SCId") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                        <EditItemTemplate>
                                        
                                        <asp:Label ID="lblSCId0" runat="server" Text='<%#Eval("SCId") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>                                 
                                    
                                    
                                    
                                   
                                    <asp:TemplateField HeaderText="Category" SortExpression="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCId" runat="server" Text='<%#Eval("CatName") %>'></asp:Label>
                    
                                                                                       
                                        </ItemTemplate> 
                                        
                                        <EditItemTemplate>
                                         <asp:Label ID="lblCId2" Visible="false" runat="server" Text='<%#Eval("CId") %>'></asp:Label>
                                        <asp:DropDownList ID="DrpCategory" runat="server" CssClass="box3"  Visible="true" DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="CId"  >
                                            </asp:DropDownList> 
                                        
                                        </EditItemTemplate>                                      
                                        <ItemStyle Width="35%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category" SortExpression="SCName">                                                                  <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SCName") %>'></asp:Label>
                                           
                                        </ItemTemplate>
                                        <ItemStyle Width="35%" />
                                        
                                        <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" Visible="true" CssClass="box3"   runat="server" Width="95%" Text='<%# Bind("SCName") %>'></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="ReqCat" runat="server"  ValidationGroup="c" ControlToValidate="TextBox1"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                                        
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                                       
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Symbol") %>'></asp:Label> 
                                            <%--<asp:TextBox ID="TextBox2" Visible="false"   runat="server" Width="93%" Text='<%# Bind("Symbol") %>' MaxLength="2"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="ReqSym" runat="server"  ValidationGroup="c" ControlToValidate="TextBox2"
                           ErrorMessage="*"></asp:RequiredFieldValidator>--%>
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
                            
                       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="select CId,Symbol + ' - ' + CName AS Expr1 from tblSD_WO_Category WHERE [CompId] = @CompId AND [FinYearId] &lt;= @FinYearId And [HasSubCat]!='0'">
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
