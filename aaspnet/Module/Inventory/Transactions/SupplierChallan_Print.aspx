<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_SupplierChallan_Print, newerp_deploy" theme="Default" title="ERP" %>

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
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            colspan="2">&nbsp;<strong> 
                            Supplier Challan - Print</strong></td>
                    </tr>

                    <tr >
                       <td   height="26px" valign="middle" width="500Px" >
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Supplier Name "></asp:Label>
&nbsp;<asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="375px"></asp:TextBox>
                          
                            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                         
                            &nbsp;&nbsp;
                        </td>
                       
                       <td   height="26px" valign="middle" >
                          
                            <asp:Button ID="Search" runat="server" onclick="Search_Click" Text="Search" 
                                CssClass="redbox" />
                        </td>
                       
                    </tr>

             <tr>
            <td colspan="2" align="left">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="17"
                    DataKeyNames="SupplierId" 
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="65%"  
                    CssClass="yui-datatable-theme" onrowcommand="SearchGridView1_RowCommand">

                    <PagerSettings PageButtonCount="40" />

                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle  Width="3%" HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
              
                            <asp:TemplateField>
                        <ItemTemplate>
                      <asp:LinkButton ID="Btn1"   Text="Select" CommandName="sel" runat="server">
                      </asp:LinkButton>
                        
                        </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Print Type">
                        <ItemTemplate>
                        <asp:DropDownList  ID="DrpPrintType" runat="server" Width="100%" CssClass="box3" >
                        <asp:ListItem Text="ORIGINAL" Value="0"></asp:ListItem>
                        <asp:ListItem Text="DUPLICATE" Value="1"></asp:ListItem>
                        <asp:ListItem Text="TRIPLICATE" Value="2"></asp:ListItem>
                        <asp:ListItem Text="ACKNOWLEDGEMENT" Value="3"> </asp:ListItem>             
                        </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle  Width="20%"  HorizontalAlign="center" />
                         </asp:TemplateField>  
                         
                         <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs"  >
                           <ItemStyle HorizontalAlign="center" Width="12 %"/>
                         </asp:BoundField>
                        
                         
                          
                     <asp:TemplateField HeaderText="SCNo">
                    <ItemTemplate>
 <%--                   <asp:LinkButton ID ="lnkButton"  Text='<%# Eval("SCNo") %>' runat ="server" CommandName="sel">
                    </asp:LinkButton>--%>
                     <asp:Label ID="lblSCNo" runat="server" Text='<%#Eval("SCNo") %>'> </asp:Label>                    
                    </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                    </asp:TemplateField>
                        
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" /> 
                        <asp:BoundField DataField="SupplierId" HeaderText="Code" >  
                              <ItemStyle HorizontalAlign="center" Width="10%"/> 
                        </asp:BoundField> 
                         
                              <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="2%" />
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
