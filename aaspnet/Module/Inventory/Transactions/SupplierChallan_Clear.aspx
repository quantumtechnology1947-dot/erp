<%@ page language="C#" autoeventwireup="true" inherits="Module_Inventory_Transactions_SupplierChallan_Clear, newerp_deploy" theme="Default" %>

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
    <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server">                    
                        
                         <table align="left" width="100%" cellpadding="0" cellspacing="0" >
        <tr>
            <td height="5px" ></td>
        </tr>
        <tr>
            <td align="left"  valign="top">
               
                            <table align="left" cellpadding="0" width="100%" cellspacing="0" >
                               
                                <tr>
                                    <td valign="top" align="center"  >
                                        <asp:Panel ID="Panel3" ScrollBars="Auto" Height="395px" runat="server">
                                       
                                      
                                            <asp:GridView ID="GridView2" runat="server"
                                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                                OnPageIndexChanging="GridView2_PageIndexChanging" style="position:static" 
                                                Width="100%" onrowcommand="GridView2_RowCommand" 
                                              >
                                                
                                                <PagerSettings PageButtonCount="40" />
                                                
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SN">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                 <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox1_CheckedChanged"
                                                 />
                                                
                                                        </ItemTemplate>                                                         
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField  Visible="true" HeaderText="SC No">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprDId" runat="server" Text='<%# Eval("SCNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                    <asp:TemplateField  Visible="false" HeaderText="Id">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                    <asp:TemplateField HeaderText="PR NO">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprNo" runat="server" Text='<%# Eval("PRNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField>                                                    
                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprDt" runat="server" Text='<%# Eval("PRDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                   
                                                   <asp:TemplateField HeaderText="WONo">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblWono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                     <asp:TemplateField HeaderText="Item Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblit" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("Descr") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="20%" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="UOM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbluom" runat="server" Text='<%# Eval("Symbol") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Challan Qty">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprqty" runat="server" Text='<%# Eval("ChallanQty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Right" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                    <asp:TemplateField HeaderText="Cleared Qty">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblqty" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Right" Width="6%" />
                                                    </asp:TemplateField> 
                                                   
                                                   
                                                     <asp:TemplateField HeaderText=" Clear Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtqty" Width="80%"  CssClass="box3" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtqty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator
                                        ID="ReqChNo" runat="server" ErrorMessage="*"  ValidationGroup="A" ControlToValidate="txtqty"></asp:RequiredFieldValidator>
                                                          
                                                    </ItemTemplate>
                                                    
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" Width="10%" />
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
                                                <FooterStyle Font-Bold="False" />
                                                <HeaderStyle Font-Size="9pt" />
                                            </asp:GridView>
                                        </asp:Panel>
                                        
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td valign="top" align="center"  >
                                        <asp:Button ID="BtnAdd" ValidationGroup="A"  runat="server"  CssClass="redbox" 
                                            Text="Submit" onclick="BtnAdd_Click" />                                            
                                        
                                        &nbsp;<asp:Button ID="BtnCancel"  runat="server"  CssClass="redbox" 
                                            Text="Cancel" onclick="BtnCancel_Click"  /> 
                                        
                                    </td>
                                </tr>
                                
                            </table>
                      
                   </td>
        </tr>
        
    </table>
                        </asp:Panel>
    </div>
    </form>
</body>
</html>
