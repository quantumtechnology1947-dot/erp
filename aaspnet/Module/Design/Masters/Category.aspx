<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_Category, newerp_deploy" title="ERP" theme="Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 422px;
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
            <td align="center">
                <table cellpadding="0" cellspacing="0" class="style2" >
                    <tr>
                        <td >&nbsp;
                    </tr>
                    <tr>
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Item  Category</b></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" DataKeyNames="CId" 
                                DataSourceID="SqlDataSource1" Width="100%" 
                                onrowcommand="GridView1_RowCommand" onrowdeleted="GridView1_RowDeleted" 
                                onrowupdated="GridView1_RowUpdated" ShowFooter="True" 
                                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                                PageSize="20">
                                <Columns>
                                    <asp:CommandField  ButtonType="Link" ShowEditButton="True" ValidationGroup="A"  />
                                     <asp:CommandField ShowDeleteButton="True" ButtonType="Link" />
                                    
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                        <asp:Button ID="btnInsert" runat="server" OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox"  Text="Insert" ValidationGroup="reqdesc" />
                                    </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("CName") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="lblDescription0" Width="150" CssClass="box3" runat="server" Text='<%#Bind("CName") %>'>
                                        </asp:TextBox>
                                           <asp:RequiredFieldValidator ID="Req1" runat="server" ErrorMessage="*" ControlToValidate="lblDescription0" ValidationGroup="A"></asp:RequiredFieldValidator>                                      
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtDescription" runat="server" Width="150" CssClass="box3">
                                        </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqDesc" runat="server" ErrorMessage="*" ControlToValidate="txtDescription" ValidationGroup="reqdesc"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Symbol">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="lblSymbol0" runat="server" Width="70" CssClass="box3"  Text='<%#Bind("Symbol") %>'>
                                        </asp:TextBox>
                                        
                                       <asp:RequiredFieldValidator ID="Req2" runat="server" ErrorMessage="*" ControlToValidate="lblSymbol0" ValidationGroup="A"></asp:RequiredFieldValidator>   
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtSymbol" Width="70" CssClass="box3"  runat="server" >
                                        </asp:TextBox>                                        
                                         <asp:RequiredFieldValidator ID="ReqSymb" runat="server" ErrorMessage="*" ControlToValidate="txtSymbol" ValidationGroup="reqdesc"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CId" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("CId") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                 
                                </Columns>
                                
                                <EmptyDataTemplate>
                                <asp:Button ID="btnInsert" runat="server" OnClientClick=" return confirmationAdd()" CommandName="Add1" CssClass="redbox"  Text="Insert" />
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtSymbol" runat="server"></asp:TextBox>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            
                                                    
                            
                            
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblDG_Category_Master] WHERE [CId] = @CId" 
                                InsertCommand="INSERT INTO [tblDG_Category_Master] ([CName], [Symbol]) VALUES (@CName, @Symbol)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [tblDG_Category_Master] Order by [CId] desc"
                                UpdateCommand="UPDATE [tblDG_Category_Master] SET [CName] = @CName, [Symbol] = @Symbol WHERE [CId] = @CId">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="CName" Type="String" />
                                    <asp:Parameter Name="Symbol" Type="String" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="CName" Type="String" />
                                    <asp:Parameter Name="Symbol" Type="String" />
                                </InsertParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
         <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="True" 
                    ForeColor="Red"></asp:Label></td>
        </tr>
    </table>



</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

