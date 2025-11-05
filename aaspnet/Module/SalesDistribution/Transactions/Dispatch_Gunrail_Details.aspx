<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_Dispatch_Gunrail_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

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
<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <asp:Panel ID="Panel1" Height="440px" ScrollBars="Auto" runat="server">
               
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            colspan="2" ><strong>&nbsp;Slido Gunrail Dispatch - For WONo: 
                            <asp:Label ID="lblWono" runat="server" Text=""></asp:Label>
                          </strong>
                        </td>
                    </tr>  
                    <tr>
                     <td align="center" ><strong>Cross Rail</strong></td>
                     <td align="center" ><strong>Long Rail</strong></td>
                    </tr>          

             <tr>
            
            <td align="center" width="50%">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True"  ShowFooter="True"
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="Id" RowStyle-HorizontalAlign ="Center"  PageSize="20"                 
                    Width="95%" 
                    DataSourceID="SqlDataSource1" onrowcommand="SearchGridView1_RowCommand" 
                    onrowdatabound="SearchGridView1_RowDataBound" >            
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                <asp:CommandField ShowDeleteButton="True" />
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                           
                
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>              

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Length in Meter">
                  <ItemTemplate>
                      <asp:Label ID="lbllenMtr" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                  </ItemTemplate>                   
                  <FooterTemplate>
                    <asp:TextBox ID="txtLenMTR"  CssClass="box3" Width="83%"  runat="server" Text=""></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ReqLenMTRF" ControlToValidate="txtLenMTR" ValidationGroup="CRF" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegLenMTR" runat="server" 
                                    ControlToValidate="txtLenMTR" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="CRF"></asp:RegularExpressionValidator>
                  </FooterTemplate>
                  <ItemStyle HorizontalAlign="right"  />
                </asp:TemplateField>
                                  
                <asp:TemplateField HeaderText="Numbers" Visible="true">
                  <ItemTemplate>
                      <asp:Label ID="lblNo" runat="server" Text='<%# Bind("No") %>'></asp:Label>
                  </ItemTemplate>                  
                   <FooterTemplate>
                      <asp:TextBox ID="txtNoRows" Width="83%"  CssClass="box3" runat="server" Text=""></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ReqNOF" ControlToValidate="txtNoRows" ValidationGroup="CRF" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegNoRows" runat="server" 
                                    ControlToValidate="txtNoRows" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="CRF"></asp:RegularExpressionValidator>                      
                      
                  </FooterTemplate>
                   <ItemStyle HorizontalAlign="right"  />
                  
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Total" Visible="true">
                  <ItemTemplate>
                      <asp:Label ID="lblTot" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                  </ItemTemplate>                              
                  <FooterTemplate>                  
                <asp:Button ID="btnAddCRF"  ValidationGroup="CRF" runat="server" OnClientClick="return confirmationAdd();" CssClass="redbox" CommandName="AddCRF" Text="Submit" />
                </FooterTemplate> 
                <FooterStyle Width="20%"  HorizontalAlign="center" />
                <ItemStyle Width="20%"  HorizontalAlign="Right" />                
                </asp:TemplateField>
                                 
                            
            </Columns>
               <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <th> SN</th>                  
                    <th>Length in Meter</th>
                    <th>No of Rows</th>
                     <th></th>                  
                    </tr>
                    <tr>
                    <td align="center"> 1                 
                    </td>
                    
                    <td> 
                         <asp:TextBox ID="txtLenMtrECR" Width="90%"  CssClass="box3" runat="server"></asp:TextBox>   
                         <asp:RequiredFieldValidator ID="ReqLenMTRE" ControlToValidate="txtLenMtrECR" ValidationGroup="CRE" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>  
                         <asp:RegularExpressionValidator ID="RegLenMtrECR" runat="server" 
                                    ControlToValidate="txtLenMtrECR" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="CRE"></asp:RegularExpressionValidator>           
                    </td>
                    <td > 
                         <asp:TextBox ID="txtNRowECR" Width="90%" CssClass="box3" runat="server"></asp:TextBox> 
                         <asp:RequiredFieldValidator ID="ReqNOE" ControlToValidate="txtNRowECR" ValidationGroup="CRE" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>   
                          <asp:RegularExpressionValidator ID="RegNRowECR" runat="server" 
                                    ControlToValidate="txtNRowECR" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="CRE"></asp:RegularExpressionValidator>  
                                    
                    </td>
                     <td align="center"> 
                    <asp:Button ID="btnAddECR" ValidationGroup="CRE" runat="server" OnClientClick="return confirmationAdd();" CssClass="redbox" CommandName="AddECR" Text="Submit" />                 
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
            
        </asp:GridView>

   

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblDG_Gunrail_CrossRail_Dispatch_Temp] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblDG_Gunrail_CrossRail_Dispatch_Temp] ([Length], [No], [SessionId], [CompId]) VALUES (@Length, @No, @SessionId, @CompId)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT Id,Length,No,SessionId,CompId,Round((Length*No),3) As Total  FROM [tblDG_Gunrail_CrossRail_Dispatch_Temp] where [SessionId] = @SessionId and  [CompId] = @CompId " 
                    UpdateCommand="UPDATE [tblDG_Gunrail_CrossRail_Dispatch_Temp] SET [Length] = @Length,[Total] = @Total , [No] = @No, [SessionId] = @SessionId, [CompId] = @CompId WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Length" Type="Double" />
                        <asp:Parameter Name="No" Type="Double" />
                        <asp:Parameter Name="Total" Type="Double" />
                        <asp:Parameter Name="SessionId" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Length" Type="Double" />
                        <asp:Parameter Name="No" Type="Double" />
                         <asp:Parameter Name="Total" Type="Double" />
                        <asp:Parameter Name="SessionId" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32" />
                    </InsertParameters>
                    <SelectParameters>
                    
                    <asp:SessionParameter Name="SessionId" SessionField="username" Type="String" />
                     <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>


            </td>
            
            
             <td align="center" width="50%">
                     
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True"   ShowFooter="True"
                     AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="Id" RowStyle-HorizontalAlign ="Center"  PageSize="20"                 
                    Width="95%" 
                     DataSourceID="SqlDataSource2" onrowcommand="GridView1_RowCommand" 
                     onrowdatabound="GridView1_RowDataBound" >            
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
             <Columns>
                
                 <asp:CommandField ShowDeleteButton="True" />
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                           
                
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>
                

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Length in Meter">
                  <ItemTemplate>
                      <asp:Label ID="lbllenMtr" runat="server" Text='<%# Bind("Length") %>'></asp:Label>
                  </ItemTemplate>  
                  <FooterTemplate>
                      <asp:TextBox ID="txtLenMTR"  CssClass="box3" Width="83%" runat="server" Text=""></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ReqLenMTLRF" ControlToValidate="txtLenMTR" ValidationGroup="LRF" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegLenMTLRF" runat="server" 
                                    ControlToValidate="txtLenMTR" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="LRF"></asp:RegularExpressionValidator>
                  </FooterTemplate>
                 <ItemStyle HorizontalAlign="right"  />
                </asp:TemplateField>
                                  
                <asp:TemplateField HeaderText="No of Rows" Visible="true">
                  <ItemTemplate>
                      <asp:Label ID="lblNo" runat="server" Text='<%# Bind("No") %>'></asp:Label>
                  </ItemTemplate>                
                   <FooterTemplate>
                      <asp:TextBox ID="txtNoRows"  CssClass="box3" Width="83%" runat="server" Text=""></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ReqNOLRF" ControlToValidate="txtNoRows" ValidationGroup="LRF" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegNoRowsLRF" runat="server" 
                                    ControlToValidate="txtNoRows" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="LRF"></asp:RegularExpressionValidator>
                  </FooterTemplate>
                  
                <ItemStyle   HorizontalAlign="Right" />   
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Total" Visible="true">
                  <ItemTemplate>
                      <asp:Label ID="lblTot" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                  </ItemTemplate> 
                  <FooterTemplate>                  
                <asp:Button ID="btnAddLRF" runat="server" OnClientClick="return confirmationAdd();" ValidationGroup="LRF" CssClass="redbox" CommandName="AddLRF" Text="Submit" />
                </FooterTemplate> 
                <FooterStyle Width="20%"  HorizontalAlign="center" />
                <ItemStyle Width="20%"  HorizontalAlign="Right" />                
                </asp:TemplateField>
                                 
                            
            </Columns>
                <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <th> SN</th>                    
                    <th>Length in Meter</th>
                    <th>No of Rows</th>
                    <th></th>                    
                    </tr>
                    <tr>
                    <td align="center"> 1                 
                    </td>
                    
                    <td> 
                         <asp:TextBox ID="txtLenMtrELR"  Width="90%" CssClass="box3" runat="server"></asp:TextBox> 
                         <asp:RequiredFieldValidator ID="ReqLENLRE" ControlToValidate="txtLenMtrELR" ValidationGroup="LRE" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> 
                          <asp:RegularExpressionValidator ID="RegLenMtrELR" runat="server" 
                                    ControlToValidate="txtLenMtrELR" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="LRE"></asp:RegularExpressionValidator>              
                    </td>
                    <td > 
                         <asp:TextBox ID="txtNRowELR"  Width="90%" CssClass="box3" runat="server"></asp:TextBox>  
                          <asp:RequiredFieldValidator ID="ReqNRowELR" ControlToValidate="txtNRowELR" ValidationGroup="LRE" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>   
                           <asp:RegularExpressionValidator ID="RegNRowELR" runat="server" 
                                    ControlToValidate="txtNRowELR" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="LRE"></asp:RegularExpressionValidator>                   
                    </td>
                   <td align="center"> 
                    <asp:Button ID="btnAddELR" runat="server" OnClientClick="return confirmationAdd();" ValidationGroup="LRE" CssClass="redbox" CommandName="AddELR" Text="Submit" />                 
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
            
        </asp:GridView>

      <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblDG_Gunrail_LongRail_Dispatch_Temp] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblDG_Gunrail_LongRail_Dispatch_Temp] ([Length], [No], [SessionId], [CompId]) VALUES (@Length, @No, @SessionId, @CompId)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT Id,Length,No,SessionId,CompId,Round((Length*No),3) As Total  FROM [tblDG_Gunrail_LongRail_Dispatch_Temp] where [SessionId] = @SessionId and  [CompId] = @CompId " 
                    UpdateCommand="UPDATE [tblDG_Gunrail_LongRail_Dispatch_Temp] SET [Length] = @Length,[Total] = @Total ,[No] = @No, [SessionId] = @SessionId, [CompId] = @CompId WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Length" Type="Double" />
                        <asp:Parameter Name="No" Type="Double" />
                        <asp:Parameter Name="Total" Type="Double" />
                        <asp:Parameter Name="SessionId" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Length" Type="Double" />
                        <asp:Parameter Name="No" Type="Double" />
                        <asp:Parameter Name="Total" Type="Double" />
                        <asp:Parameter Name="SessionId" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32" />
                    </InsertParameters>
                    
                    <SelectParameters>
                    
                    <asp:SessionParameter Name="SessionId" SessionField="username" Type="String" />
                     <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>


            </td>            
            
             </tr>
            
              </table> 
              </asp:Panel>
            </td>
        </tr>
        
        <tr>
        <td align="center">
           <table cellpadding="0" cellspacing="0" width="600">
                    <tr>
                        <td>
                            <asp:Label ID="lblType" runat="server" Font-Bold="True" Text="Type :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">Swivel</asp:ListItem>
                                <asp:ListItem Value="1">Fixed</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblSupportPitch" runat="server" Font-Bold="True" 
                                Text="Support Pitch :"></asp:Label>
                        </td>
                        <td align="left">
&nbsp;
                            <asp:TextBox ID="txtPitch" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqPitch" ControlToValidate="txtPitch" ValidationGroup="PIT" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegPitch" runat="server" 
                                    ControlToValidate="txtPitch" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="PIT"></asp:RegularExpressionValidator>
&nbsp;<asp:Button ID="btnProceed"  ValidationGroup="PIT" runat="server" CssClass="redbox" 
                                onclientclick="return confirmationAdd();" Text="Proceed" 
                                onclick="btnProceed_Click" />
&nbsp;<asp:Button ID="btncancel" runat="server" CssClass="redbox" Text="Cancel" onclick="btncancel_Click" />
                        </td>
                    </tr>
                </table>
        </td>
        </tr>
        
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

