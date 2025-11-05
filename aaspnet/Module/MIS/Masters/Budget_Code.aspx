<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MIS_Masters_Budget_Code, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <br />
    <table align="center" style="width: 53%" cellpadding="0" cellspacing="0" >
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Budget Code</b></td>
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
                   
                   <PagerSettings PageButtonCount="40" />
                   
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
                        
                        
                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                        <ItemTemplate>
                        <asp:Label ID="lblTerms" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtTerms1" Width="90%" runat="server" Text='<%#Bind("Description") %>' CssClass="box3">
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
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblvalue" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        
                        
                            <asp:Label ID="txtValue1" runat="server" Text='<%#Bind("Symbol") %>'></asp:Label>
                       <%-- <asp:TextBox ID="txtValue1" Width="75%" runat="server"  MaxLength="2" Text='<%#Bind("Symbol") %>' CssClass="box3">
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqValue" ValidationGroup="Shree" ControlToValidate="txtValue1"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>   --%>                    
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtValue2" runat="server" Width="80%" CssClass="box3"  MaxLength="2" >
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqValue" ValidationGroup="abc" ControlToValidate="txtValue2"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                                                    
				          
                        </FooterTemplate>
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                 
                        
                        
                    </Columns>  
                    
                    <EmptyDataTemplate>
                    <table>
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Description"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Symbol"></asp:Label></td>
               
               </tr>
               <tr>
                    <td>
                   <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="pqr" OnClientClick="return confirmationAdd()" CommandName="Add1" CssClass="redbox" /></td>
                <td>
                   <asp:TextBox ID="txtTerms3" runat="server" Width="400px" CssClass="box3" />
                   <asp:RequiredFieldValidator ID="ReqTerm0" ValidationGroup="pqr" ControlToValidate="txtTerms3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
                   <td>
                   <asp:TextBox ID="txtValue3" runat="server" Width="100px" CssClass="box3" MaxLength="2" />
                     <asp:RequiredFieldValidator ID="Reqvalue0" ValidationGroup="pqr" ControlToValidate="txtValue3" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>
                               
				          
                    
                     </td>
                     
                     </tr>
                     </table>
                   </EmptyDataTemplate> 
              </asp:GridView>
                
                </td>
        </tr>
        <tr>
            <td align="center" height="25px">
                <asp:Label ID="lblMessage" runat="server" Text="Label" ForeColor="#FF3300" 
                    style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" height="25px">
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblMIS_BudgetCode] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblMIS_BudgetCode] ([Description], [Symbol]) VALUES (@Description, @Symbol)" 
                    SelectCommand="SELECT * FROM [tblMIS_BudgetCode] order by [Id] desc" 
                    UpdateCommand="UPDATE [tblMIS_BudgetCode] SET [Description] = @Description, [Symbol] = @Symbol  WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                     
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                       
                    </InsertParameters>
                </asp:SqlDataSource>
                
                    <asp:Button runat="server" Text="Cancel" CssClass="redbox" Width="60px" ID="btnCancel" OnClick="btnCancel_Click"></asp:Button>

            </td>
        </tr>
    </table>
<br />

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

