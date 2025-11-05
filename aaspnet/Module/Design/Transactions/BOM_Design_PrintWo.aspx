<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_BOM_Design_PrintWo, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <table width ="100%" cellpadding="0" cellspacing="0">
             <tr>
            <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21" ><b>&nbsp;BOM Design - Print</b></td>
             </tr>
             <tr>
            <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3"                     
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged2" 
                     >
                  <%--  <asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                     <asp:ListItem Value="2">PO No</asp:ListItem>
                         <asp:ListItem Value="3">WO No</asp:ListItem>
                </asp:DropDownList>
            
                 <asp:TextBox ID="txtSearchCustomer" runat="server"  Visible="False"
                    CssClass="box3"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchValue"  runat="server" 
                    CssClass="box3" Width="350px"></asp:TextBox>
                      <cc1:autocompleteextender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:autocompleteextender> 
                    <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList> 
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>

             <tr>
            <td class="fontcss">
              <asp:Panel ID="Panel1" Height="445px" ScrollBars="Auto"  runat="server">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="FALSE" Width="100%"
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo" RowStyle-HorizontalAlign ="Center"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" 
                    ShowFooter="false"  onrowcommand="SearchGridView1_RowCommand">
            
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                          <asp:TemplateField >
                <ItemTemplate>
                    <asp:LinkButton ID="BtnSel" CommandName="Sel" runat="server">Select</asp:LinkButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="center" ></ItemStyle>
                </asp:TemplateField>       
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle HorizontalAlign="Center" Width="9%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="WO No"  >
                <ItemTemplate>
                    <asp:Label ID="LblWONo" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="center"></ItemStyle>
                </asp:TemplateField>     
                                  <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="35%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                                  
                                   <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>                                    
                                    <asp:TextBox ID="TxtBOMDate" runat="server" Width="70"  Text='<%# Eval("BOMDate") %>'  CssClass="box3"></asp:TextBox>
    <cc1:CalendarExtender ID="TxtChallanDate_CalendarExtender" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtBOMDate" PopupPosition="BottomLeft">
    </cc1:CalendarExtender>                        
                                        
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorBOMDate" runat="server" ControlToValidate="TxtBOMDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>
                           </ItemTemplate>
                                   
                                     <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Upto Date">
                                    <ItemTemplate>                                    
                                    <asp:TextBox ID="TxtUptoDate" runat="server" Text='<%# Eval("UpToDate") %>'  Width="70"    CssClass="box3"></asp:TextBox>
    <cc1:CalendarExtender ID="TxtUptoDate_CalendarExtender" runat="server" 
        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtUptoDate" PopupPosition="BottomLeft">
    </cc1:CalendarExtender>                        
                                        
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidatorUPtoDate" runat="server" ControlToValidate="TxtUptoDate" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"  ValidationGroup="A"  ErrorMessage="*"></asp:RegularExpressionValidator>                           
                             
                          
                           </ItemTemplate>
                                   
                                     <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                        <asp:TemplateField HeaderText="Id" Visible="false" >
                <ItemTemplate>
                    <asp:Label ID="LblId" runat="server"  Text='<%# Eval("Id") %>'  ></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField> 
                
                <asp:BoundField DataField="WODate" HeaderText="Gen. Date" >
                                      <ItemStyle Width="10%" />
                </asp:BoundField>
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            
                                      <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                            
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

    <asp:HiddenField ID="hfSort" runat="server" Value=" " />
                     
            <asp:HiddenField ID="hfSearchText" runat="server" />
</asp:Panel>
            </td>
             </tr>
              </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

