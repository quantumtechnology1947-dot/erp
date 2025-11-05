<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_CustomerChallan_New_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
                    <cc1:TabPanel runat="server" HeaderText="Customer Challan" ID="Add">                    
                        <HeaderTemplate>
                            Customer Challan
                        </HeaderTemplate>
<ContentTemplate>
                        
                    <asp:Panel ID="Panel1" ScrollBars="Auto" Height="450px" runat="server">                    
                        
                         <table align="left" width="100%" cellpadding="0" cellspacing="0" >
        <tr>
            <td    valign="top">
               
                            <table align="left" cellpadding="0" cellspacing="0" >
                               <tr><td  height="30"><asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem><asp:ListItem Value="Category">Category</asp:ListItem><asp:ListItem Value="WOItems">WO Items</asp:ListItem></asp:DropDownList><asp:DropDownList ID="DrpCategory" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" Height="21px" 
                    CssClass="box3"></asp:DropDownList><asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem></asp:DropDownList><asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px" 
                    AutoPostBack="True" CssClass="box3"></asp:DropDownList><asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>&#160;<asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  /></td></tr>
                                <tr>
                                    <td valign="top" align="Left"  >
                                        <asp:Panel ID="Panel2" ScrollBars="Auto" Height="400px" Width="100%" runat="server">
                                       
                                            <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCommand="GridView2_RowCommand" PageSize="15" Width="95%" >
            <Columns>                                        
                <asp:TemplateField 
                                        HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ><ItemTemplate>  <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox1_CheckedChanged"
                                                 />
                                                </ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" /></asp:TemplateField><asp:BoundField DataField="Id" HeaderText="Id" Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="SubCategory" HeaderText="SubCategory" 
                        Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="ItemCode" HeaderText="Item Code"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="ManfDesc" HeaderText="Description"><ItemStyle VerticalAlign="Top" Width="55%" /></asp:BoundField><asp:BoundField DataField="UOMBasic" HeaderText="UOM"><ItemStyle VerticalAlign="Top" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="StockQty" HeaderText="Stock Qty"><ItemStyle HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="Location" HeaderText="Location"><ItemStyle VerticalAlign="Top" /></asp:BoundField>
                        
                        <asp:TemplateField  HeaderText=" Challan Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtQty" runat="server"></asp:TextBox>
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="TxtQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator
                                        ID="ReqChNo" runat="server" ErrorMessage="*"  ValidationGroup="A" ControlToValidate="TxtQty"></asp:RequiredFieldValidator>
                            
                            
           </ItemTemplate>
           <ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                        
                        </Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" />
            <PagerSettings PageButtonCount="40" />
                                            </asp:GridView>
                                       
                                        </asp:Panel>
                                        
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td valign="top" align="center"  >
                                        <asp:Button ID="BtnAdd" ValidationGroup="A"  runat="server"  CssClass="redbox" 
                                            Text="Submit" onclick="BtnAdd_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                             <asp:Button ID="Btncancel"  runat="server"  CssClass="redbox" 
                                            Text="Cancel" onclick="Btncancel_Click"  />
                                        
                                    </td>
                                </tr>
                                
                            </table>
                      
                   </td>
        </tr>
        
    </table>
                        </asp:Panel></ContentTemplate></cc1:TabPanel>
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Clear Challan">
                    <ContentTemplate>
                    <asp:Panel ID="Panel3"  ScrollBars="Auto" runat="server">                    
                        
                         <table width="100%" align="center" cellpadding="0" cellspacing="0" 
                             style="height: 454px">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">

                   

             <tr>
            <td colspan="2">
             <iframe src="" id="myframe"  runat="server"  width="100%" height="410Px" frameborder="0" >        
        </iframe> 
            </td>
             </tr>
             
             <tr>
             <td align="center">
             
             
                 <asp:Button ID="Btncancel1" runat="server" CssClass="redbox" 
                     onclick="Btncancel1_Click" Text="Cancel" />
             
             
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

