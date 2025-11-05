<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Masters_Payement_Receipt_Against, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
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

<table  width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Payment/Receipt Against</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">  
                        <ContentTemplate>
                        
                    <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" >
                   <asp:GridView ID="GridView1"  
                runat="server"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"                
                DataSourceID="SqlDataSource1"              
              OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" Width="60%" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onrowupdating="GridView1_RowUpdating">
                    
                   <Columns>
                      <asp:CommandField  ShowEditButton="True" 
                           ValidationGroup="Shree">
                          <ItemStyle HorizontalAlign="Center" />
                       </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True"  >
                         
                            <ItemStyle HorizontalAlign="Center" />
                       </asp:CommandField>
                         
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <FooterTemplate> 
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="abc" 
                        OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtTerms1" Width="97%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Description") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="Shree" ControlToValidate="txtTerms1" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtTerms2" CssClass="box3"   Width="97%" ValidationGroup="abc" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerm" runat="server" ValidationGroup="abc" ControlToValidate="txtTerms2" 
                         ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                        <ItemTemplate>
                        <asp:Label ID="lblTerms" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>                  
                    
                    </Columns> 
                    <EmptyDataTemplate>
                    <table border="1pt" style="border-color:GrayText" width="100%">
                    <tr>
                        <th>
                        </th>
                        <th>
                            Description
                        </th>
                         </tr>                      
                    <tr>
                        <td>
                            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="pqr" />
                        </td>
                        <td >
                            <asp:TextBox ID="txtTerms3" runat="server" Width="97%" CssClass="box3" 
                                ValidationGroup="pqr">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqTerm0" runat="server" 
                                ControlToValidate="txtTerms3" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                        
           </tr>
                        </table>
                   </EmptyDataTemplate> 
                    
<FooterStyle Wrap="True"></FooterStyle>
                   
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_PaymentAgainst] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblACC_PaymentAgainst] ([Description]) VALUES (@Description)" 
                    SelectCommand="SELECT * FROM [tblACC_PaymentAgainst]  order by [Id] desc" 
                    UpdateCommand="UPDATE [tblACC_PaymentAgainst] SET [Description] = @Description  WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Description" Type="String" />
                     
                    </InsertParameters>
                </asp:SqlDataSource>
                    </asp:Panel>
                       </ContentTemplate></cc1:TabPanel>
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Receipt">
                            
                        <ContentTemplate>
            
                <asp:Panel ID="Panel2" ScrollBars="Auto" runat="server">             
            
           <asp:GridView ID="GridView2"  
                runat="server"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"                
                DataSourceID="SqlDataSource2"              
              OnRowCommand="GridView2_RowCommand" CssClass="yui-datatable-theme" Width="60%" 
                    onrowdatabound="GridView2_RowDataBound" 
                    onrowupdating="GridView2_RowUpdating">
                    
                   <Columns>
                      <asp:CommandField  ShowEditButton="True" 
                           ValidationGroup="Shree">
                          <ItemStyle HorizontalAlign="Center" />
                       </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="True"  >
                         
                            <ItemStyle HorizontalAlign="Center" />
                       </asp:CommandField>
                         
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <FooterTemplate> 
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="abc" 
                        OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtTerms1" Width="97%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Description") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerms" ValidationGroup="Shree" ControlToValidate="txtTerms1" 
                            runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtTerms2" CssClass="box3"   Width="97%" ValidationGroup="abc" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqTerm" runat="server" ValidationGroup="abc" ControlToValidate="txtTerms2" 
                         ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                        <ItemTemplate>
                        <asp:Label ID="lblTerms" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>                  
                    
                    </Columns> 
                    <EmptyDataTemplate>
                    <table border="1pt" style="border-color:GrayText" width="100%">
                    <tr>
                        <th>
                        </th>
                        <th>
                            Description
                        </th>
                         </tr>                      
                    <tr>
                        <td>
                            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="pqr" />
                        </td>
                        <td >
                            <asp:TextBox ID="txtTerms3" runat="server" Width="97%" CssClass="box3" 
                                ValidationGroup="pqr">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqTerm0" runat="server" 
                                ControlToValidate="txtTerms3" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                        
           </tr>
                        </table>
                   </EmptyDataTemplate> 
                    
<FooterStyle Wrap="True"></FooterStyle>
                   
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_ReceiptAgainst] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblACC_ReceiptAgainst] ([Description]) VALUES (@Description)" 
                    SelectCommand="SELECT * FROM [tblACC_ReceiptAgainst]  order by [Id] desc" 
                    UpdateCommand="UPDATE [tblACC_ReceiptAgainst] SET [Description] = @Description  WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Description" Type="String" />
                     
                    </InsertParameters>
                </asp:SqlDataSource>
               </asp:Panel>
                           </ContentTemplate></cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

