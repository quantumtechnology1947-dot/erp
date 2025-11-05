<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialPlanning_Transactions_Planning_Edit, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

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
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >&nbsp;<strong>Material Planning- Edit</strong></td>
                    </tr>   
              </table>
                
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr>
        <td align="left" height="25" >
        
          
            <asp:DropDownList ID="DrpField" runat="server" 
                 AutoPostBack="True" 
                CssClass="box3" onselectedindexchanged="DrpField_SelectedIndexChanged">
                <asp:ListItem Value="0">Select</asp:ListItem>
                <asp:ListItem Value="1">Supplier Name</asp:ListItem>
               <asp:ListItem Value="2">PL No</asp:ListItem>
             
            </asp:DropDownList>
         
            <asp:TextBox ID="Txtsearch" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
           
           
        
              <asp:TextBox ID="txtCustName" runat="server" Width="300px"></asp:TextBox>
         
            
              <cc1:AutoCompleteExtender ID="txtCustName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtCustName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
           
           
        
              &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
            
        
        
              </td>
        </tr>

             <tr>
            <td width="100%">                     
  
                     <asp:GridView ID="GridView1"  runat="server" 
                    AllowPaging="True"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="PLNo" RowStyle-HorizontalAlign ="Center"
     
                     Width="100%" 
                         onrowcommand="GridView1_RowCommand" 
                         onpageindexchanging="GridView1_PageIndexChanging" 
                         onrowdatabound="GridView1_RowDataBound" 
                         onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="15" >
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
              <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">                           <ItemTemplate>
              <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
              </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField >
                         <ItemTemplate>
                     <asp:LinkButton  runat="server"   CommandName="Sel" Text="Select" ID="btnSel"  />
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        
                          <asp:TemplateField >
                         <ItemTemplate>
                     <asp:LinkButton  runat="server" Visible="false"  CommandName="edt" OnClientClick="return confirmationUpdate();" Text="Edit" ID="btnEdit"  />  
         <asp:LinkButton  runat="server"    Visible="false"  CommandName="save" Text="Save" ValidationGroup="abc"  ID="btnSave"  />
         <asp:LinkButton  runat="server"    Visible="false"  CommandName="Cancel" Text="cancel" ID="btnCancel"  />
                             <asp:Label ID="lblPR" runat="server" Text="PR" Visible="false"></asp:Label>
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                                              
                                    
                                    
                                    
                                    
              <asp:TemplateField HeaderText="FinYear">
                         <ItemTemplate>
                        <asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label>
                        </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PL No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPLNo" runat="server" Text='<%# Eval("PLNo") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>            
                        
                        
                        <asp:TemplateField HeaderText="WO No">
                                    <ItemTemplate>
                                    <asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    </asp:TemplateField>            
                        
                        
                        
                       
                       <asp:TemplateField HeaderText="SupplierName">
                                    <ItemTemplate>
                                    <asp:Label ID="lblsupl" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
          <asp:TextBox ID="txtSupName" Visible="false"  Text='<%# Eval("SupplierName") %>'  runat="server" Width="75%"></asp:TextBox>
          <asp:RequiredFieldValidator ID="ReqSupNm" ValidationGroup="abc" runat="server"  ControlToValidate="txtSupName" ErrorMessage="*"></asp:RequiredFieldValidator>
            
              <cc1:AutoCompleteExtender ID="txtSupName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
           
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                                  
                                    
                                    </asp:TemplateField>              
            <asp:TemplateField HeaderText="Comp Date"  >
                                    <ItemTemplate>
                                    <asp:Label ID="lblCompDate"   runat="server" Text='<%# Eval("CompDate") %>'></asp:Label>
          <asp:TextBox  ID="TxtCompDate" Visible ="false" Text='<%# Eval("CompDate") %>' Width="90%"  runat="server" ></asp:TextBox>
          <asp:RequiredFieldValidator ID="ReqCompDt" ValidationGroup="abc" runat="server"  ControlToValidate="TxtCompDate" ErrorMessage="*"></asp:RequiredFieldValidator>
           <cc1:CalendarExtender ID="CalendarExtender1"  Format="dd-MM-yyyy" PopupPosition="BottomRight"  Animated="True"  TargetControlID="TxtCompDate" runat="server"></cc1:CalendarExtender>
           
           <asp:RegularExpressionValidator ID="RegularExpressionValidatorTxtCompDate1" runat="server" ControlToValidate="TxtCompDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="abc"  ErrorMessage="*">
                                      </asp:RegularExpressionValidator> 
                                                </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    
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
                                    
                                    <asp:TemplateField HeaderText="ItemId" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblItem" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
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
              </table>
            </td>
        </tr>
        
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

