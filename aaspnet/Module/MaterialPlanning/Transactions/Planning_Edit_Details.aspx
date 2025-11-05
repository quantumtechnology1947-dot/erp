<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialPlanning_Transactions_Planning_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr >                   
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >&nbsp;<strong>Material Planning 
                            - Edit</strong></td>
                    </tr>   
              </table>
               <table width="100%" align="left" cellpadding="0" cellspacing="0">
                   <tr>
                   <td>
                   
                       &nbsp;<b>Raw Material&nbsp;</b></td>
                   </tr>
                   
                   
                    <tr>
        <td  >
       
            <asp:GridView ID="GridView2"  runat="server"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="PLNo" RowStyle-HorizontalAlign ="Center"     
                     Width="90%" 
                    ShowFooter="True" onpageindexchanging="GridView2_PageIndexChanging" 
                onrowcommand="GridView2_RowCommand" 
                onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="15" 
                        >
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
              <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id">                           <ItemTemplate>
              <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
              </ItemTemplate>
                                    </asp:TemplateField>
                                     
                              <asp:TemplateField    HeaderText="Edit">              
                                               <ItemTemplate>
             <asp:CheckBox ID="CK" runat="server" AutoPostBack="true"  oncheckedchanged="CK_CheckedChanged"   />
       <asp:Label ID="lblDel" runat="server" Visible="false"  Text="PR"></asp:Label>
              </ItemTemplate>
                                    </asp:TemplateField> 
                        <asp:TemplateField HeaderText="PL No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPLNo" runat="server" Text='<%# Eval("PLNo") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:TemplateField>            
                        
                                    
                          <asp:TemplateField HeaderText="Item Code">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                       
                                       
                                   <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                                    </asp:TemplateField> 
                                                         
                             
                                       
                                                          
                          <asp:TemplateField HeaderText="Unit">
                                    <ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Symbol") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:TemplateField>                                                           
                       
                       <asp:TemplateField HeaderText="SupplierName">
                                    <ItemTemplate>
                                    <asp:Label ID="lblsupl" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label><asp:TextBox ID="txtSupName" Visible="false"  CssClass="box3"  Text='<%# Eval("SupplierName") %>'  runat="server" Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqSupNM" runat="server" ErrorMessage="*" ControlToValidate="txtSupName" ValidationGroup="edit1"></asp:RequiredFieldValidator>
                   <cc1:AutoCompleteExtender ID="txtSupName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="30%" HorizontalAlign="Left" />
                                    </asp:TemplateField>              
            <asp:TemplateField HeaderText="Comp Date"  >
                                    <ItemTemplate>
                                    <asp:Label ID="lblCompDate" runat="server" Text='<%# Eval("CompDate") %>'></asp:Label> 
           <asp:TextBox  ID="TxtCompDate" Visible ="false" Text='<%# Eval("CompDate") %>'  CssClass="box3"  Width="80%"  runat="server" ></asp:TextBox>
      
           <cc1:CalendarExtender ID="CalendarExtender1"  Format="dd-MM-yyyy" PopupPosition="BottomRight"  Animated="True"  TargetControlID="TxtCompDate" runat="server">          
           
           </cc1:CalendarExtender> 
              
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorTxtCompDate1" runat="server" ControlToValidate="TxtCompDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="edit1"  ErrorMessage="*">
                                      </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                   
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                   <FooterTemplate>
                                  <asp:Button runat="server" ID="btnEditRaw"  Text="Update" CssClass="redbox" OnClientClick="return confirmationUpdate();" ValidationGroup="edit1" CommandName="editRawMate" 
               />
                                   </FooterTemplate>
                                   <FooterStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>              
                <asp:TemplateField HeaderText="PId" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPid" runat="server" Text='<%# Eval("PId") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle  HorizontalAlign="Center" />
                                    </asp:TemplateField>   
                                     <asp:TemplateField HeaderText="CId" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblCid" runat="server" Text='<%# Eval("CId") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle  HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                    
             <asp:TemplateField HeaderText="ItemId"  Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                   
                                    </asp:TemplateField>  
 
            </Columns> 
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
       
       
       
       
      </td>
       </tr>  
       <tr>
       <td align="left">
       
       
       &nbsp;<b>Processing Material </b>
        <asp:GridView ID="GridView1"  runat="server"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="PLNo" RowStyle-HorizontalAlign ="Center"
     
                     Width="90%" 
                    ShowFooter="True" onpageindexchanging="GridView1_PageIndexChanging" 
               onrowcommand="GridView1_RowCommand" 
               onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="15"  >
                        
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
              <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" 
                    Visible="False">                           <ItemTemplate>
              <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
              </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                  <asp:TemplateField HeaderText="Edit">              
                                               <ItemTemplate>
             <asp:CheckBox ID="ck" runat="server"  AutoPostBack="true"  oncheckedchanged="ck_CheckedChanged"   />
             <asp:Label ID="lblDel" runat="server" Visible="false" Text="PR"></asp:Label>
             
              </ItemTemplate>
                                    </asp:TemplateField>      
                           
                        <asp:TemplateField HeaderText="PL No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPLNo" runat="server" Text='<%# Eval("PLNo") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:TemplateField>            
                        
                                    
                          <asp:TemplateField HeaderText="Item Code">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                       
                                       
                                   <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                                    </asp:TemplateField> 
                                                         
                             
                                       
                                                          
                          <asp:TemplateField HeaderText="Unit">
                                    <ItemTemplate>
                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Eval("Symbol") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                                          
                        
                        
                       
                       <asp:TemplateField HeaderText="SupplierName">
                                    <ItemTemplate>
                                    <asp:Label ID="lblsupl" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label> 
           <asp:TextBox ID="txtSupName" Visible="false"  Text='<%# Eval("SupplierName") %>' CssClass="box3"  runat="server" Width="300px"></asp:TextBox>
         <asp:RequiredFieldValidator ID="ReqRawSupNM" runat="server" ErrorMessage="*" ControlToValidate="txtSupName" ValidationGroup="edit"></asp:RequiredFieldValidator>
            
              <cc1:AutoCompleteExtender ID="txtSupName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
          
          
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="30%" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>   
                                    
                                    
                                <asp:TemplateField HeaderText="Comp Date"  >
                                    <ItemTemplate>
                                    <asp:Label ID="lblCompDate" runat="server" Text='<%# Eval("CompDate") %>'></asp:Label> 
           <asp:TextBox  ID="TxtCompDate" Visible ="false"  CssClass="box3"  Text='<%# Eval("CompDate") %>' Width="80%"  runat="server" ></asp:TextBox>
           
           <cc1:CalendarExtender ID="CalendarExtender1"  Format="dd-MM-yyyy" PopupPosition="BottomRight"  Animated="True"  TargetControlID="TxtCompDate" runat="server"></cc1:CalendarExtender> 
           
           
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorTxtCompDate" runat="server" ControlToValidate="TxtCompDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="edit"  ErrorMessage="*">
                                      </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                   
                                    <ItemStyle Width="10%" />
                                   <FooterTemplate>
                                   <asp:Button runat="server" ID="btnEdit" Text="Update" CssClass="redbox" OnClientClick="return confirmationUpdate();" ValidationGroup="edit" CommandName="editProMate"
               />
                                   
                                   </FooterTemplate>
                                   <FooterStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>              
                
                                    
                                    
                                    
                                               
            
             <asp:TemplateField HeaderText="ItemId"  Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItemId" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                   
                                    </asp:TemplateField>              
            <asp:TemplateField HeaderText="PId" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPid" runat="server" Text='<%# Eval("PId") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle  HorizontalAlign="Center" />
                                    </asp:TemplateField>   
                                     <asp:TemplateField HeaderText="CId" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblCid" runat="server" Text='<%# Eval("CId") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle  HorizontalAlign="Center" />
                                    </asp:TemplateField> 
            
            
            
 
            </Columns> 
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
      
       
       </td>
       </tr>
       
      <tr>
      <td align="center" height="30">      
       
          &nbsp;&nbsp;<asp:Button runat="server" ID="btnCancel1" Text="Cancel" CssClass="redbox" 
               onclick="btnCancel1_Click" />
       
       
      </td>
      </tr>
       </table>
       </td>
       </tr>
       </table>
       
              

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

