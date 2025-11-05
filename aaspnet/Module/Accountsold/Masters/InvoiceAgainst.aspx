<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InvoiceAgainst.aspx.cs" Inherits="Module_Accounts_Masters_InvoiceAgainst" Title="ERP" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <br />
    <table align="center" style="width: 49%">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Invoice Against</b></td>
        </tr>
        <tr>
            <td align="center">
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
              OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onrowupdating="GridView1_RowUpdating" PageSize="20">
                    
<FooterStyle Wrap="True"></FooterStyle>
                   
                   <Columns>
                      <asp:CommandField ButtonType="Link"  ShowEditButton="True" ValidationGroup="Shree"/>
                        <asp:CommandField   ButtonType="Link" ShowDeleteButton="True"  />
                         
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate> 
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="abc" 
                        OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Terms" SortExpression="Terms">
                        <ItemTemplate>
                        <asp:Label ID="lblTerms" runat="server" Text='<%#Eval("Against") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtTerms1" Width="300" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Against") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="Shree" ControlToValidate="txtTerms1" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtTerms2" CssClass="box3"   Width="300" ValidationGroup="abc" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerm" runat="server" ValidationGroup="abc" ControlToValidate="txtTerms2" 
                         ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>                  
                    
                    </Columns> 
                    <EmptyDataTemplate>
                    <table>
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Terms"></asp:Label></td>
           </tr>
                    <tr>
                    <td>
                   <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="pqr" 
                   OnClientClick=" return confirmationAdd()"  CommandName="Add1" CssClass="redbox" />
                   </td>
                   <td>
                   <asp:TextBox ID="txtTerms3" CssClass="box3"  runat="server" ValidationGroup="pqr" Width="300" >
                        </asp:TextBox> 
                       <asp:RequiredFieldValidator ID="ReqTerm0" runat="server" ValidationGroup="pqr" ControlToValidate="txtTerms3"
                        ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                         </tr>                      
                        </table>
                   </EmptyDataTemplate> 
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_InvoiceAgainst] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblACC_InvoiceAgainst] ([Against]) VALUES (@Terms)" 
                    SelectCommand="SELECT * FROM [tblACC_InvoiceAgainst]  order by [Id] desc" 
                    UpdateCommand="UPDATE [tblACC_InvoiceAgainst] SET [Against] = @Terms  WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                     
                    </InsertParameters>
                </asp:SqlDataSource>
                
            
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
<br />

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

