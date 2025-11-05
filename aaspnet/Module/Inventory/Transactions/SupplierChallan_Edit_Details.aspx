<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_SupplierChallan_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    
      <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" 
        onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Supplier Challan" ID="Add">                    
<ContentTemplate>
                        
                    <asp:Panel ID="Panel2" ScrollBars="Auto" runat="server">                    
                        
                         <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="5px" colspan="4" ></td>
        </tr>
                             <tr>
                                 <td colspan="4" height="5px">
                                     <asp:Panel ID="Panel1" runat="server" Height="360px" ScrollBars="Auto">
                                         <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                             CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                             OnPageIndexChanging="GridView2_PageIndexChanging" 
                                             OnRowCommand="GridView2_RowCommand" style="position:static" Width="100%">
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
                                                         <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                                             oncheckedchanged="CheckBox1_CheckedChanged" />
                                                     </ItemTemplate>
                                                     <HeaderStyle Font-Size="10pt" />
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Id" Visible="False">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PR NO">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblprNo" runat="server" Text='<%# Eval("PRNo") %>'></asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="WONo">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblWono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="SC No">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblSCno" runat="server" Text='<%# Eval("SCNo") %>'></asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Date">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblprDt" runat="server" Text='<%# Eval("SCDate") %>'></asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Item Code">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblit" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Description">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("ManfDesc") %>'>
                                                         </asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="UOM">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lbluom" runat="server" Text='<%# Eval("UOM") %>'> </asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PR Qty">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblprqty" runat="server" Text='<%# Eval("PRQty") %>'></asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Remain Qty">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblrmnqty" runat="server" Text=""> </asp:Label>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText=" Challan Qty">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblCHQty" runat="server" Text='<%# Eval("ChallanQty") %>' 
                                                             Visible="false"></asp:Label>
                                                         <asp:TextBox ID="txtqty" runat="server" CssClass="box3" 
                                                             Text='<%# Eval("ChallanQty") %>' Width="80%">
                                                         </asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="ReqChNo" runat="server" 
                                                             ControlToValidate="txtqty" ErrorMessage="*" ValidationGroup="A">
                                                         </asp:RequiredFieldValidator>
                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                             ControlToValidate="txtqty" ErrorMessage="*" 
                                                             ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                                                         </asp:RegularExpressionValidator>
                                                     </ItemTemplate>
                                                     <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="8%" />
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
                                             <FooterStyle Font-Bold="False" />
                                             <HeaderStyle Font-Size="9pt" />
                                             <PagerSettings PageButtonCount="40" />
                                         </asp:GridView>
                                     </asp:Panel>
                                 </td>
                             </tr>
                             <tr>
                                 <td colspan="4" height="5px" 
                                     style="border-bottom-style: solid; border-width: thin; border-color: #808080">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td height="24px" 
                                     style="border-left-style: solid; border-width: medium; border-color: #808080" 
                                     width="1%">
                                     &nbsp;</td>
                                 <td height="5px" valign="middle" width="30%">
                                     Vehicle No. :
                                     <asp:TextBox ID="txtVehicleNo" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                 </td>
                                 <td align="right" height="5px" valign="middle" width="10%">
                                     Remarks :</td>
                                 <td height="5px" rowspan="2" 
                                     style="border-width: thin; border-color: #808080; height: 10px; border-right-style: solid;" 
                                     valign="middle" width="56%">
                                     <asp:TextBox ID="txtRemarks" runat="server" Height="38px" TextMode="MultiLine" 
                                         Width="98%"></asp:TextBox>
                                 </td>
                             </tr>
                             <tr>
                                 <td height="24px" 
                                     style="border-left-style: solid; border-width: medium; border-color: #808080" 
                                     width="1%">
                                     &nbsp;</td>
                                 <td height="5px" valign="middle" width="30%">
                                     Transpoter :
                                     <asp:TextBox ID="txtTranspoter" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                 </td>
                                 <td height="5px" width="10%">
                                     &nbsp;</td>
                             </tr>
        <tr>
            <td align="left"  valign="top" colspan="4">
               
                            <table align="left" cellpadding="0" cellspacing="0" width="100%" >
                                <tr>
                                    <td valign="middle" align="center" height="24px" 
                                        style="border-top-style: solid; border-width: thin; border-color: #808080"  >
                                        <asp:Button ID="BtnAdd" runat="server" CssClass="redbox" OnClick="BtnAdd_Click" 
                                            OnClientClick=" confirmationUpdate()" Text="Update" ValidationGroup="A" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Btncancel" runat="server" CssClass="redbox" 
                                            OnClick="Btncancel_Click" Text="Cancel" />
                                    </td>
                                </tr>
                                
                            </table>
                      
                   </td>
        </tr>
        
    </table> </asp:Panel></ContentTemplate></cc1:TabPanel>
    
       <cc1:TabPanel ID="View" runat="server" HeaderText="Clear Challan">
                    <ContentTemplate>
                     <asp:Panel ID="Panel3" ScrollBars="Auto" runat="server">                    
                        
                         <table align="left" width="100%" cellpadding="0" cellspacing="0" >
        <tr>
            <td height="5px" ></td>
        </tr>
        <tr>
            <td align="left"  valign="top">
               
                            <table align="left" cellpadding="0" width="100%" cellspacing="0" >
                               
                                <tr>
                                    <td valign="top" align="center"  >
                                        <asp:Panel ID="Panel4" ScrollBars="Auto" Height="395px" runat="server">
                                       
                                      
                                            <asp:GridView ID="GridView1" runat="server"
                                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id"
                                                 style="position:static" 
                                                Width="100%" >
                                                
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
                                                 <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox2_CheckedChanged"
                                                 />
                                                
                                                        </ItemTemplate>                                                         
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                                    </asp:TemplateField>
                                                    
                                                     <asp:TemplateField HeaderText="PR NO">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprNo1" runat="server" Text='<%# Eval("PRNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="WONo">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblWono1" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                    <asp:TemplateField HeaderText="SC No">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblSCNo1" runat="server" Text='<%# Eval("SCNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                     <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblprDt1" runat="server" Text='<%# Eval("PRDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                    
                                                    <asp:TemplateField  Visible="false" HeaderText="Id">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblId1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField> 
                                                    
                                                     <asp:TemplateField  Visible="false">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lblDId1" runat="server" Text='<%# Eval("DId") %>'></asp:Label>
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
                                                            <asp:TextBox ID="txtqty" Width="80%" Text='<%# Eval("ClearedQty") %>'  CssClass="box3" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtqty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator
                                        ID="ReqChNo" runat="server" ErrorMessage="*"  ValidationGroup="B" ControlToValidate="txtqty"></asp:RequiredFieldValidator>
                                                          
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
                                        <asp:Button ID="BtnAdd1" ValidationGroup="B"  runat="server"  CssClass="redbox" 
                                            Text="Update" onclick="BtnAdd1_Click" />                                            
                                        
                                        &nbsp;<asp:Button ID="BtnCancel1"  runat="server"  CssClass="redbox" 
                                            Text="Cancel" onclick="BtnCancel1_Click"  /> 
                                        
                                    </td>
                                </tr>
                                
                            </table>
                      
                   </td>
        </tr>
        
    </table>
                        </asp:Panel>
                    </ContentTemplate>
                    </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>


