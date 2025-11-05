<%@ page language="C#" autoeventwireup="true" inherits="Module_Inventory_Transactions_SupplierChallan_Clear_Details, newerp_deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
</head>
<body  style="margin:0px 0px 0px 0px" class="fontcss" >
    <form id="form1" runat="server">
    <div>
     <asp:Panel ID="Panel2"  ScrollBars="Auto" runat="server">                    
                        
                         <table width="100%" align="center" cellpadding="0" cellspacing="0" 
                             style="height: 420px">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">

                    <tr >
                       <td   height="26px" valign="middle" width="500Px" >
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Supplier Name "></asp:Label>
&nbsp;<asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="370px"></asp:TextBox>
                          
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
            <td  align="left" colspan="2">
                    <asp:Panel ID="Panel4" ScrollBars="Auto" Height="395px" runat="server">  
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="17"
                    DataKeyNames="Id"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="65%"  
                    CssClass="yui-datatable-theme" onrowcommand="SearchGridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SN"><ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle  Width="5%" HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs"  >
                           <ItemStyle HorizontalAlign="Center" Width="12%"/>
                         </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="SC No">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnScNo" CommandName="GoToPage" Text='<%#Eval("SCNo") %>' runat="server"></asp:LinkButton>
                         </ItemTemplate>

                    <ItemStyle  Width="10%" HorizontalAlign="Center">
                    </ItemStyle>
                        </asp:TemplateField>
                        
                        <asp:TemplateField Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblId"  Text='<%#Eval("Id") %>'  runat="server"/>
                         </ItemTemplate>

                    <ItemStyle  Width="8%" HorizontalAlign="Center">
                    </ItemStyle>
                        </asp:TemplateField>
                                               
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name">
                        
                       <ItemStyle HorizontalAlign="Left"  Width="65%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SupplierId" HeaderText="Code" />  
                            
                                             
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
                    <PagerSettings PageButtonCount="40" />
<RowStyle HorizontalAlign="Center"></RowStyle>
                </asp:GridView>
                </asp:Panel>
                     
            </td>            
           
             </tr>
              </table>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
              
            </td>
        </tr>
</table>
                     </asp:Panel>
    </div>
    </form>
</body>
</html>
