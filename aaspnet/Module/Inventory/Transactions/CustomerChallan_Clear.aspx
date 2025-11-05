<%@ page language="C#" autoeventwireup="true" inherits="Module_Inventory_Transactions_CustomerChallan_Clear, newerp_deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
</head>
<body  style="margin:0px 0px 0px 0px" class="fontcss" >
    <form id="form1" runat="server">
    <div>
     
                         <table width="100%" align="center" cellpadding="0" cellspacing="0"   >
        <tr>
            <td>
                <table width="100%"  cellpadding="0" cellspacing="0">

                    <tr >
                       <td valign="top"  align="Left"width="35%"  >
                       
                       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                    DataKeyNames="Id" onpageindexchanging="GridView1_PageIndexChanging" 
                                    onrowcommand="GridView1_RowCommand" PageSize="17" Width="95%">
                                    <Columns>   
                                       
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="CC No">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnScNo" runat="server" CommandName="Sel" 
                                                    Text='<%#Eval("CCNo") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="30%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="WONo" HeaderText="WO No" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table class="fontcss" width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                        Text="No data to display !"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <PagerSettings PageButtonCount="40" />
                                    <RowStyle HorizontalAlign="Center" />
                                </asp:GridView>
                        </td>
                       
                        <td align="center">
                        <asp:Panel ID="Panel2"  ScrollBars="Auto"  Height="390px" runat="server">                    
                        
                              <asp:GridView ID="GridView2" runat="server" 
                                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                    DataKeyNames="Id" onpageindexchanging="GridView2_PageIndexChanging" 
                                    onrowcommand="GridView2_RowCommand" PageSize="17" Width="100%">
                                    <Columns>
                                    
                                     <asp:TemplateField ><ItemTemplate>  <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox1_CheckedChanged"
                                                 />
                                                </ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="6%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ItemCode" HeaderText="Item Code">
                                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                              <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ManfDesc") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45%" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="UOM">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("Symbol") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="Challan Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblChallanQty" runat="server" Text='<%#Eval("ChallanQty") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                          
                                         <asp:TemplateField HeaderText="Cleared Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClearedQty" runat="server"  />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        
                                        
                                        
                                       <asp:TemplateField  HeaderText=" Clear Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtQty" runat="server" Width="80%"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="TxtQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator
                                        ID="ReqChNo" runat="server" ErrorMessage="*"  ValidationGroup="A" ControlToValidate="TxtQty"></asp:RequiredFieldValidator>
                            
                            
           </ItemTemplate>
             <ItemStyle HorizontalAlign="Left" Width="13%" />
           <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                                        <asp:TemplateField Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table class="fontcss" width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                        Text="No data to display !"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <PagerSettings PageButtonCount="40" />
                                    <RowStyle HorizontalAlign="Center" />
                                </asp:GridView> </asp:Panel></td>
                       
                    </tr>

                     <tr>
                                    <td  >
                                        
                                        
                                    </td>
                                    <td valign="top" align="center" >
                                    <asp:Button ID="BtnAdd" ValidationGroup="A"  runat="server"  CssClass="redbox" 
                                            Text="Submit" onclick="BtnAdd_Click"  Visible="false" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                             </td>
                                </tr>
              </table>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
              
            </td>
        </tr>
</table>
                    
    </div>
    </form>
</body>
</html>
