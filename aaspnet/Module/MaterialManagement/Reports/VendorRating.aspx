<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_VendorRating, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    <table width="100%" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="99%" align="center" cellpadding="0" cellspacing="0">
                    <tr >
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            colspan="2">&nbsp;<strong> 
                            Vendor Rating</strong></td>
                    </tr>
              
   <tr >
                        <td> 
                        
                  <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True">
                    <cc1:TabPanel runat="server" HeaderText="Overall rating" ID="Overallrating">
                        <HeaderTemplate>
&nbsp;&nbsp;Overall rating&nbsp;&nbsp;           
                    </HeaderTemplate>
<ContentTemplate>       
                      <table  width="100%">
                      <tr>
                      <td >
                      
                      
                         From Date</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtFromDate1" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender1" runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate1">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqFromDt1" runat="server" ControlToValidate="TxtFromDate1" 
                            ErrorMessage="*" ValidationGroup="a1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TxtFromDate1" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a1"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp;
                        <b>To</b>
            <asp:TextBox ID="TxtToDate1" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtToDate_CalendarExtender1" runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate1">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqCate2" runat="server" 
                            ControlToValidate="TxtToDate1" ErrorMessage="*" ValidationGroup="a1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TxtToDate1" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                          &nbsp;&nbsp;&nbsp;<asp:Button ID="BtnSearch" runat="server" CssClass="redbox" 
                              OnClick="BtnSearch_Click" Text="Submit" />
                          &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    
                      </table>  
      </ContentTemplate>
                    
</cc1:TabPanel>
<cc1:TabPanel ID="SupplierWise" runat="server" HeaderText="Supplier Wise">
                        <HeaderTemplate>
&nbsp;&nbsp;Supplier Wise&nbsp;&nbsp;
                    </HeaderTemplate>
                        
<ContentTemplate>

<table width="100%">
<tr>
<td >
  From Date</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TxtFromDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFromDate" 
                            ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="TxtFromDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp;
                        <b>To</b>
            <asp:TextBox ID="TxtToDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item Category&nbsp;
                            <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True"
                                CssClass="box3" Height="21px" 
                                
        OnSelectedIndexChanged="DrpType_SelectedIndexChanged" Width="100px">
                                <asp:ListItem  Value="Select">Select</asp:ListItem>
                                <asp:ListItem Value="BoughtOut"> BoughtOut</asp:ListItem>
                                <asp:ListItem Value="WOItems">WO Items</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    
   <tr >
                        <td   height="26px" valign="middle" class="style2">
                            &nbsp;<asp:Label ID="Label3" runat="server" Text="Supplier Name"></asp:Label>
                            <strong>&nbsp;</strong><asp:TextBox ID="TxtSearchValue" runat="server" 
                                CssClass="box3" Width="350px"></asp:TextBox>
                          
                            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                            
                            
                            
                            
                            &nbsp;&nbsp;
                                                    
                            
                            
                            
                            <asp:Button ID="Button1" runat="server" onclick="Search_Click" Text="Search" 
                                CssClass="redbox" />
                        </td>
                    </tr>

             <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="17"
                    DataKeyNames="SupplierId"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%"  
                     CssClass="yui-datatable-theme" onrowcommand="SearchGridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SN"><ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1"  CommandName="Sel" runat="server">Select</asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs" /> 
                         <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" >
                        <ItemStyle HorizontalAlign="Left" Width="35%" />
                         </asp:BoundField>
                      
                          <asp:TemplateField  HeaderText="Code">
                        <ItemTemplate>
                            <asp:Label ID="LblCode" runat="server" Text='<%# Eval("SupplierId") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
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
<RowStyle HorizontalAlign="Center"></RowStyle>
                </asp:GridView>
                     
            <asp:HiddenField ID="hfSearchText" runat="server" />

    <asp:HiddenField ID="hfSort" runat="server" Value=" " />
   







 </td>
                      
                      </tr>
                      
                      </table>  
</ContentTemplate>
                    
</cc1:TabPanel>
                </cc1:TabContainer>


            </td>
             </tr>
              </table>
            </td>
        </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

