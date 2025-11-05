<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VAT.aspx.cs" Inherits="Module_Accounts_Masters_VAT" Title="ERP" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            width: 60%;
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <br />
    <table align="center" cellpadding="0" cellspacing="0" class="style2" >
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;VAT</b></td>
        </tr>
        <tr>
            <td align="center">
            <asp:GridView ID="GridView1" Width="100%" 
                runat="server"
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                DataSourceID="SqlDataSource1"
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" 
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
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Terms" SortExpression="Terms">
                        <ItemTemplate>
                        <asp:Label ID="lblTerms" runat="server" Text='<%#Eval("Terms") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtTerms1" Width="90%" runat="server" Text='<%#Bind("Terms") %>' CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="Shree" ControlToValidate="txtTerms1" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtTerms2" runat="server" Width="90%" CssClass="box3">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="abc" ControlToValidate="txtTerms2" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="value" SortExpression="value">
                        <ItemTemplate>
                        <asp:Label ID="lblvalue" runat="server" Text='<%#Eval("value") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtValue1" Width="75%" runat="server" Text='<%#Bind("Value") %>' CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqValue" ValidationGroup="Shree" ControlToValidate="txtValue1"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>                         

				            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Shree" ControlToValidate="txtValue1" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>

                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtValue2" runat="server" Width="80%" CssClass="box3">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqValue" ValidationGroup="abc" ControlToValidate="txtValue2"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                                                    
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="abc"
                            ControlToValidate="txtValue2" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$"></asp:RegularExpressionValidator>
            				
                        </FooterTemplate>
                            <ItemStyle Width="20%" HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="Default">
                        <ItemTemplate>
                        <asp:Label ID="txtLive" runat="server" Text='<%#Eval("Live") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                        </FooterTemplate>
                        <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox02" runat="server">
                        </asp:CheckBox>                        
                        </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="IsVAT">
                       <ItemTemplate>
                       <asp:Label ID="RdBtnIsVAT" runat="server" Text='<%#Eval("IsVAT") %>'></asp:Label>
                       </ItemTemplate>
                       <FooterTemplate>
                       <asp:CheckBox runat="server" ID="CKIsVAT"/>
                       </FooterTemplate>
                           <FooterStyle HorizontalAlign="Center" />
                           <ItemStyle Width="10%" HorizontalAlign="Center" />
                       </asp:TemplateField>
                       
                       <asp:TemplateField HeaderText="IsCST">
                       <ItemTemplate>
                       <asp:Label ID="lblIsVATCST" runat="server" Text='<%#Eval("IsCST") %>'></asp:Label>
                       </ItemTemplate>   
                       <FooterTemplate>
                       <asp:CheckBox runat="server" ID="CKIsCST"/>
                       </FooterTemplate>  
                           <FooterStyle HorizontalAlign="Center" />
                       <ItemStyle Width="10%" HorizontalAlign="Center" />                               
                       </asp:TemplateField>
                    </Columns>  
                    
                    <EmptyDataTemplate>
                    <table>
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Terms"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Value"></asp:Label></td>
               <td align="center">
                         <asp:Label ID="Label3" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Default"></asp:Label></td>
               </tr>
               <tr>
                    <td>
                   <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="pqr" OnClientClick="return confirmationAdd()" CommandName="Add1" CssClass="redbox" /></td>
                <td>
                   <asp:TextBox ID="txtTerms3" runat="server" Width="230" CssClass="box3" />
                   <asp:RequiredFieldValidator ID="ReqTerm0" ValidationGroup="pqr" ControlToValidate="txtTerms3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                   <td>
                   <asp:TextBox ID="txtValue3" runat="server" Width="50%" CssClass="box3" />
                     <asp:RequiredFieldValidator ID="Reqvalue0" ValidationGroup="pqr" ControlToValidate="txtValue3" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>
				     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="pqr" ControlToValidate="txtValue3" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$"> </asp:RegularExpressionValidator>
                    
                     </td>
                     <td>
                     <asp:CheckBox ID="CheckBox_2" runat="server" />
                     </td>
                     <td>
                     <asp:CheckBox ID="CKIsVAT" runat="server" />
                     </td>
                     <td>
                     <asp:CheckBox ID="CKIsCST" runat="server" />
                     </td>
                     </tr>
                     </table>
                   </EmptyDataTemplate> 
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblVAT_Master] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblVAT_Master] ([Terms], [Value],[Live],[IsVAT],[IsCST]) VALUES (@Terms, @Value,@Live,@IsVAT,@IsCST)"
                    SelectCommand="SELECT * FROM [tblVAT_Master] order by [Id] desc" 
                    UpdateCommand="UPDATE [tblVAT_Master] SET [Terms] = @Terms, [Value] = @Value , [Live]=@Live WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                        <asp:Parameter Name="Value" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                      <asp:Parameter Name="Live" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                        <asp:Parameter Name="Value" Type="String" />
                        <asp:Parameter Name="Live" Type="Int32" />
                        <asp:Parameter Name="IsVAT" Type="Int32" />
                        <asp:Parameter Name="IsCST" Type="Int32" />
                    </InsertParameters>
                </asp:SqlDataSource>
                
                </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
<br />

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

