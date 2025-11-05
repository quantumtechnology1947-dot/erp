<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysAdmin_BusinessNature, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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

<table cellpadding="0" cellspacing="0" width="40%" align="center" >
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
       
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Business Nature</b></td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                DataSourceID="SqlDataSource1"
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="17">
                    
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:CommandField  ButtonType="Link" ValidationGroup="edit" 
                            ShowEditButton="True" >
                            <ItemStyle Width="3%" />
                        </asp:CommandField>
                         <asp:CommandField ShowDeleteButton="True" ButtonType="Link" 
                            ValidationGroup="edit"   >
                             <ItemStyle Width="3%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btnInsert" runat="server" ValidationGroup="abc" 
                                OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" Text="Insert" />
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nature" SortExpression="Nature">
                        <ItemTemplate>
                        <asp:Label ID="lblBusinessNature" runat="server" Text='<%#Eval("Nature") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblBusinessNature0" Width="95%" CssClass="box3" runat="server" Text='<%#Bind("Nature") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqBissNat0" runat="server" ControlToValidate="lblBusinessNature0" ValidationGroup="edit" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtBusinessNature" CssClass="box3" Width="95%" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqBissNat" runat="server" ControlToValidate="txtBusinessNature" ValidationGroup="abc" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                        </FooterTemplate>
                            <ItemStyle Width="55%" />
                        </asp:TemplateField>
                        
                    </Columns>
                    
                    
                    
                     <EmptyDataTemplate>
                <table  width="100%" border="1" style=" border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Nature"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                         <td>
                <asp:Button ID="btnInsert" runat="server" ValidationGroup="pqr" CommandName="Add1"
                OnClientClick=" return confirmationAdd()"  CssClass="redbox" Text="Insert" /></td>
         <td>
                &nbsp
                <asp:TextBox ID="txtBusinessNature" CssClass="box3" runat="server" Width="95%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqBissNat0" runat="server" ControlToValidate="txtBusinessNature" ValidationGroup="pqr" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                </td>
         
           </tr>
           </table>
        </EmptyDataTemplate>
                    
                    
                    
           
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblMM_Supplier_BusinessNature] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblMM_Supplier_BusinessNature] ([Nature]) VALUES (@Nature)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [tblMM_Supplier_BusinessNature] ORDER BY [Id] DESC" 
                    UpdateCommand="UPDATE [tblMM_Supplier_BusinessNature] SET [Nature] = @Nature WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Nature" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Nature" Type="String"/>
                    </InsertParameters>
                </asp:SqlDataSource>
                
             
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

