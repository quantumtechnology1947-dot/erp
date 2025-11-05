<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Masters_Excise, newerp_deploy" title="ERP" theme="Default" %>

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
   
    <table align="center" cellpadding="0" cellspacing="0" width="80%">
    
        <tr align="center">
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Excise/Service Tax</b></td>
        </tr>
    
        <tr align="center">
            <td align="center" valign="top">
               <asp:GridView ID="GridView1"  Width="100%"
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
                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" onrowupdating="GridView1_RowUpdating">
                    
                <FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Link"  ShowEditButton="True" 
                            ValidationGroup="Shree">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                        <asp:CommandField   ButtonType="Link" ShowDeleteButton="True"  >
                        
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:CommandField>
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id" >
                        <ItemTemplate>
                       <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert"  ValidationGroup="abc"
                         OnClientClick="return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Terms" SortExpression="Terms">
                        <ItemTemplate>
                        <asp:Label ID="txtTerms" runat="server" Text='<%#Eval("Terms") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" ID="txtTerms1" runat="server" Width="200" Text='<%#Bind("Terms") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="Shree" ControlToValidate="txtTerms1" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtTerms2" CssClass="box3" Width="200" runat="server">
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqTerms1" ValidationGroup="abc" ControlToValidate="txtTerms2" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Value" SortExpression="Value">
                        <ItemTemplate>
                        <asp:Label ID="txtValue" runat="server" Text='<%#Eval("Value") %>'>
                        </asp:Label>
                        </ItemTemplate>                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtValue1" runat="server" CssClass="box3" Width="80" Text='<%#Bind("Value") %>'>
                        </asp:TextBox>
                        
                         <asp:RequiredFieldValidator ID="ReqValue" ValidationGroup="Shree" ControlToValidate="txtValue1"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Shree"
                            ControlToValidate="txtValue1" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtValue2" runat="server" CssClass="box3" Width="80">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqValue1" ValidationGroup="abc" ControlToValidate="txtValue2"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>                                                    
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="abc" ControlToValidate="txtValue2" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>            				
                        </FooterTemplate>
                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Access. Value">
                        <ItemTemplate>
                        <asp:Label ID="txtAccessableValue" runat="server" Text='<%#Eval("AccessableValue") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox CssClass="box3" ID="TextBox1" runat="server" Width="80"/>
                        <asp:RequiredFieldValidator ID="ReqAccVal" ValidationGroup="abc" ControlToValidate="TextBox1"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator> 
                          <asp:RegularExpressionValidator ID="RegAccValFoot" runat="server" ValidationGroup="abc" ControlToValidate="TextBox1" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>  
                        </FooterTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" ID="txtAccessableValue0" Width="80" runat="server" Text='<%#Bind("AccessableValue") %>'>
                        </asp:TextBox>                         
                         <asp:RequiredFieldValidator ID="ReqAccEditValue" ValidationGroup="Shree" ControlToValidate="txtAccessableValue0"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator> 
                          <asp:RegularExpressionValidator ID="RegAccValFoot" runat="server" ValidationGroup="Shree" ControlToValidate="txtAccessableValue0" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>                      
                        </EditItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EDU Cess">
                        <ItemTemplate>
                        <asp:Label ID="txtEDUCess" runat="server" Text='<%#Eval("EDUCess") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox CssClass="box3" ID="TextBox2" runat="server" Width="80"/>
                      <asp:RequiredFieldValidator ID="ReqEducess" ValidationGroup="abc" ControlToValidate="TextBox2"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator> 
                          <asp:RegularExpressionValidator ID="RegEducessFoot" runat="server" ValidationGroup="abc" ControlToValidate="TextBox2" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>  
                        </FooterTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" ID="txtEDUCess0" Width="80" runat="server" Text='<%#Bind("EDUCess") %>'>                        </asp:TextBox>  
                         <asp:RequiredFieldValidator ID="ReqEduValue" ValidationGroup="Shree" ControlToValidate="txtEDUCess0"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator> 
                           <asp:RegularExpressionValidator ID="RegEducessEdit" runat="server" ValidationGroup="Shree" ControlToValidate="txtEDUCess0" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>                      
                        </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SHE Cess">
                        <ItemTemplate>
                        <asp:Label ID="txtSHECess" runat="server" Text='<%#Eval("SHECess") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox CssClass="box3" ID="TextBox3" runat="server" Width="80"/>
                        <asp:RequiredFieldValidator ID="ReqSheCess" ValidationGroup="abc" ControlToValidate="TextBox3"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegShecessFoot" runat="server" ValidationGroup="abc" ControlToValidate="TextBox3" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>  
                        </FooterTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" ID="txtSHECess0" Width="80" runat="server" Text='<%#Bind("SHECess") %>'>
                        </asp:TextBox> 
                         <asp:RequiredFieldValidator ID="ReqSHEValue" ValidationGroup="Shree" ControlToValidate="txtSHECess0"
                          runat="server" ErrorMessage="*">
                          </asp:RequiredFieldValidator>  
                          <asp:RegularExpressionValidator ID="RegShecessEdit" runat="server" ValidationGroup="Shree" ControlToValidate="txtSHECess0" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>                         
                        </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Default Excise">
                        <ItemTemplate>
                        <asp:Label ID="txtLive" runat="server" Text='<%#Eval("Live") %>'>
                        </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:CheckBox ID="CheckBox1"  runat="server" Width="80"/>
                        </FooterTemplate>
                        <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox01" runat="server">
                        </asp:CheckBox>                        
                        </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Default Ser. Tax">
                        <ItemTemplate>
                        <asp:Label ID="txtLiveSerTax" runat="server" Text='<%#Eval("LiveSerTax") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" Width="80"/>
                        </FooterTemplate>
                        <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox02" runat="server">
                        </asp:CheckBox>                        
                        </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                    <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Terms"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Value"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Access value"></asp:Label>
                        </td>
                        <td align="center">
                          <asp:Label ID="Label4" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="EDU Cess"></asp:Label>
                        </td>
                        <td align="center">
                          <asp:Label ID="Label5" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="SHE Cess"></asp:Label>
                        </td>
                        <td align="center">
                          <asp:Label ID="Label6" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Default Excise"></asp:Label>
                        </td>
                        <td align="center">
                          <asp:Label ID="Label7" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Default Service Tax"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                   <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="pqr" OnClientClick="return confirmationAdd()" CommandName="Add1" CssClass="redbox" /></td>
                <td>
                   <asp:TextBox CssClass="box3" ID="txtTerms3" runat="server"/>
                   <asp:RequiredFieldValidator ID="ReqTerm0" ValidationGroup="pqr" ControlToValidate="txtTerms3" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegTermEmpty" runat="server" ValidationGroup="pqr" ControlToValidate="txtTerms3" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator></td>
                   <td>
                   <asp:TextBox CssClass="box3" ID="txtValue3" runat="server" Width="150"/>
                   <asp:RequiredFieldValidator ID="Reqvalue0" ValidationGroup="pqr" ControlToValidate="txtValue3" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                               
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="pqr"
                            ControlToValidate="txtValue3" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
                    
                     </td>
                     <td>
                   <asp:TextBox CssClass="box3" ID="TextBox_1" runat="server" Width="80"/>
                   <asp:RequiredFieldValidator ID="ReqAccValEmpt" ValidationGroup="pqr" ControlToValidate="TextBox_1" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                               
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="pqr"
                            ControlToValidate="TextBox_1" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
                   
                   </td>
                   <td>
                   <asp:TextBox CssClass="box3" ID="TextBox_2" runat="server" Width="70"/>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="pqr" ControlToValidate="TextBox_2" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                               
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="pqr"
                            ControlToValidate="TextBox_2" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
                   </td>
                   <td>
                   <asp:TextBox CssClass="box3" ID="TextBox_3" runat="server" Width="70"/>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="pqr" ControlToValidate="TextBox_3" 
                     runat="server" ErrorMessage="*">
                     </asp:RequiredFieldValidator>                               
				            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="pqr"
                            ControlToValidate="TextBox_3" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
                   </td>
                   <td>
                   <asp:CheckBox ID="CheckBox_1" runat="server" /></td>
                   <td>
                   <asp:CheckBox ID="CheckBox_2" runat="server" />
                   </td>
                     
                     </tr>
                     </table>
                   </EmptyDataTemplate>
              </asp:GridView>
              
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblExciseser_Master] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblExciseser_Master] ([Terms], [Value],[AccessableValue],[EDUCess],[SHECess],[Live],[LiveSerTax]) VALUES (@Terms, @Value,@AccessableValue,@EDUCess,@SHECess,@Live,@LiveSerTax)" 
                    SelectCommand="SELECT * FROM [tblExciseser_Master] order by [Id] desc" 
                    UpdateCommand="UPDATE [tblExciseser_Master] SET [Terms] = @Terms, [Value] = @Value,[AccessableValue]=@AccessableValue,[EDUCess]=@EDUCess,[SHECess]=@SHECess,[Live]=@Live,[LiveSerTax]=@LiveSerTax WHERE [Id] = @Id" 
                    ProviderName="System.Data.SqlClient">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                        <asp:Parameter Name="Value" Type="String" />
                        <asp:Parameter Name="AccessableValue" Type="String" />
                        <asp:Parameter Name="EDUCess" Type="String" />
                        <asp:Parameter Name="SHECess" Type="String" />
                        <asp:Parameter Name="Live" Type="int32" />
                        <asp:Parameter Name="LiveSerTax" Type="int32" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Terms" Type="String" />
                        <asp:Parameter Name="Value" Type="String" />
                        <asp:Parameter Name="AccessableValue" Type="String" />
                        <asp:Parameter Name="EDUCess" Type="String" />
                        <asp:Parameter Name="SHECess" Type="String" />
                        <asp:Parameter Name="Live" Type="int32" />
                        <asp:Parameter Name="LiveSerTax" Type="int32" />
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

