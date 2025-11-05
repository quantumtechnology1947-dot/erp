<%@ page language="C#" autoeventwireup="true" inherits="Module_Design_Transactions_TPL_Design_CopyWo, newerp_deploy" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <table width ="100%" cellpadding="0" cellspacing="0">
                    
             <tr>
            <td height="25" class="fontcss" >
            
                <b>Search Work Order:</b>&nbsp;
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="SD_Cust_Master.CustomerId">Customer Name</asp:ListItem>
                    <asp:ListItem Value="SD_Cust_WorkOrder_Master.EnqId">Enquiry No</asp:ListItem>
                    <asp:ListItem Value="SD_Cust_WorkOrder_Master.WONo">WO No</asp:ListItem>
                    <asp:ListItem Value="SD_Cust_WorkOrder_Master.PONo">PO No</asp:ListItem>
                </asp:DropDownList>
            
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            
                <asp:TextBox ID="txtSearchCustomer" runat="server" width="200px"
                    CssClass="box3"></asp:TextBox>
                
                <asp:TextBox ID="TxtSearchValue" Visible="False" runat="server" 
                    CssClass="box3" Width="350px"></asp:TextBox>
                      <cc1:autocompleteextender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:autocompleteextender> 
        <asp:Button ID="Button1" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearchWo_Click"  />
                        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="redbox" 
                    onclick="Button2_Click" Text="Cancel" />
                        &nbsp;
                        <asp:Label ID="lblasslymsg" runat="server" ForeColor="Red" 
                    style="font-weight: 700"></asp:Label>
                        </td>
             </tr>

             <tr>
            <td class="fontcss">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" Width="100%"
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo" RowStyle-HorizontalAlign ="Center"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging">
            
            <RowStyle />
            <Columns>
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                               
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle HorizontalAlign="Center" Width="9%" />
                </asp:BoundField>
                                  <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="35%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" >
                                  <ItemStyle Width ="8%" HorizontalAlign="Center" />
                               </asp:BoundField>
                                  
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" >
                                      <ItemStyle Width="10%" />
                </asp:BoundField>
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" >
                                 <ItemStyle HorizontalAlign="center" Width="12%" />
                               </asp:BoundField>
                                <asp:BoundField DataField="WONo" HeaderText="WONo" />
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" >
                                      <ItemStyle Width="10%" />
                </asp:BoundField>
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            
                                      <ItemStyle HorizontalAlign="Left" Width="42%" />
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

            </td>
             </tr>
              </table>
    </form>
</body>
</html>
