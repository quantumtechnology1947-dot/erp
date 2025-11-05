<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Masters_PaymentTerms, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <table align="center" style="width: 47%" >
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Payment Terms</b></td>
        </tr>
        <tr>
            <td align="lefts">
            <asp:GridView ID="GridView1" width="100%"
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                PageSize="10"
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                DataSourceID="SqlDataSource1"
              OnRowUpdated="GridView1_RowUpdated" 
              OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onrowupdating="GridView1_RowUpdating">
                    
<FooterStyle Wrap="True"></FooterStyle>
                   
                   <Columns>                    
                    
                      <asp:CommandField ButtonType="Link"  ShowEditButton="True" ValidationGroup="Shree"/>
                         <asp:CommandField  ButtonType="Link"   ShowDeleteButton="True"  /> 
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
                        <asp:Label ID="lblTerms" runat="server" Text='<%#Eval("Terms") %>'>    </asp:Label>
                        </ItemTemplate>
                       <EditItemTemplate>
                        <asp:TextBox ID="txtTerms1" Width="300" runat="server" ValidationGroup="Shree" Text='<%#Bind("Terms") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="Shree" ControlToValidate="txtTerms1" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                       <FooterTemplate>
                        <asp:TextBox ID="txtTerms2"  Width="300" ValidationGroup="abc" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerm" runat="server" ValidationGroup="abc" ControlToValidate="txtTerms2" 
                         ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                            <FooterStyle HorizontalAlign="Left" Width="45%" />
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
                   <asp:TextBox ID="txtTerms3" runat="server" ValidationGroup="pqr" Width="300" >
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
                    DeleteCommand="DELETE FROM [tblPayment_Master] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblPayment_Master] ([Terms]) VALUES (@Terms)" 
                    SelectCommand="SELECT * FROM [tblPayment_Master] order by [Id] desc" 
                    UpdateCommand="UPDATE [tblPayment_Master] SET [Terms] = @Terms  WHERE [Id] = @Id">
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
                
             
            
            
            
                </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
                
            </td>
        </tr>
    </table>
<br />



</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

