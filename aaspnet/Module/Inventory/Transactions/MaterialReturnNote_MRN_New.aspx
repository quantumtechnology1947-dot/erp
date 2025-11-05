<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialReturnNote_MRN_New, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
     <style type="text/css">
        .style2
        {
            width: 100%;
        }
        
        </style>
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
    

    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Note [MRN] - New</b></td>
        </tr>
        <tr>
            <td >
                
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"  
                    Width="100%"  AutoPostBack="True" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Item Master" ID="TabPanel1">
                        <ContentTemplate>
            
            <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem Value="Category">Category</asp:ListItem>
                     <asp:ListItem Value="WOItems">WO Items</asp:ListItem>                    
                                    
                            </asp:DropDownList>
                <asp:DropDownList ID="DrpCategory1" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory1_SelectedIndexChanged" Height="21px" 
                    CssClass="box3">
                    
                
                    
                            </asp:DropDownList> 
                
                 <asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged">
                     <asp:ListItem Value="Select">Select</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>                    
                     <asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem>
                
                            </asp:DropDownList>
                
                <asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px" 
                    onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="box3">
                            </asp:DropDownList>

            
                <asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>
                
                &nbsp;<asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
            
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                   ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                   ProviderName="System.Data.SqlClient" 
                   SelectCommand="SELECT Id,Symbol as Dept FROM [BusinessGroup]">
                
                            </asp:SqlDataSource>
  <asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" Width="100%" PageSize="17" 
                                onrowcommand="GridView2_RowCommand">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle 
                            HorizontalAlign="Right" Width="3%"></ItemStyle>
                            </asp:TemplateField>                            
                            
                            
                            
                              <asp:TemplateField HeaderText="Id" Visible="False" >
                                                    <ItemTemplate>  
                                                    
                                                        <asp:Label ID="LblId" runat="server" Text='<%# Eval("Id") %>' ></asp:Label>          
                                     
                            </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                           </asp:TemplateField>
                           <asp:BoundField DataField="ItemCode" HeaderText="ItemCode">
                           
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           
                            <asp:BoundField DataField="ManfDesc" HeaderText="Description">
                           
                                <ItemStyle Width="35%" />
                            </asp:BoundField>
                           
                         
                            
                            <asp:BoundField DataField="UOMBasic" HeaderText="UOM ">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="StockQty" HeaderText="Stock Qty" >
                           
                                <ItemStyle Width="8%" HorizontalAlign="Right" />
                            </asp:BoundField>
                                                <asp:TemplateField HeaderText="BG Group/WoNo">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                                        CssClass="box3" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                                                        Width="100%">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="BG Group" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="WONo" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        
                                      
                                      <asp:DropDownList ID="drpdept" DataSourceID="SqlDataSource1" Width="90%" DataTextField="Dept" DataValueField="Id"  runat="server" CssClass="box3" Visible="false"></asp:DropDownList>
             
             <asp:TextBox ID="txtwono" runat="server" Width="75%" Height="15" CssClass="box3" Visible="false"></asp:TextBox>
                                         
                                          <asp:RequiredFieldValidator ID="Reqwono" ControlToValidate="txtwono" ValidationGroup="A" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ret Qty">
                                                   <ItemTemplate>
                                                        <asp:TextBox ID="txtqty" runat="server" Height="15" Width="80%" CssClass="box3"></asp:TextBox>
       <asp:RequiredFieldValidator ID="Reqty" ControlToValidate="txtqty" ValidationGroup="A" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtqty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="12%" />
                                                </asp:TemplateField>
                            <asp:BoundField DataField="Location" HeaderText="Location">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center"/>
                            </asp:BoundField>
                            
                            <asp:TemplateField HeaderText="Remarks">
                                                 <ItemTemplate>
                                                        <asp:TextBox ID="txtremarks" runat="server" Width="80" Height="15" CssClass="box3"></asp:TextBox>
                                                    </ItemTemplate>
                                                    
                                                 <ItemStyle Width="10%" />
                                                    
                                                </asp:TemplateField>
                            <asp:TemplateField>
                                                    <ItemTemplate>                                                        
                                                        <asp:Button ID="idbut" runat="server" CommandName="Add" CssClass="redbox" 
                                                            OnClientClick="return confirmationAdd()" Text="Add" ValidationGroup="A" />
    
                                                    </ItemTemplate>
                                                    <ItemStyle Width="4%" HorizontalAlign="Center" />
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
                
                        
                
                        
                    </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Selected Items">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" class="style2">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                            ShowFooter="True" DataKeyNames="Id"
                                             Width="100%" onpageindexchanging="GridView3_PageIndexChanging" 
                                            onrowcommand="GridView3_RowCommand" PageSize="15">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Id" Visible="False" >
                                                    <ItemTemplate>                                                      
                                       <asp:Label ID="LblId0" runat="server" Text='<%# Eval("Id") %>' ></asp:Label>          
                                     
                                                </ItemTemplate>
                           </asp:TemplateField>
                                                
                                                 <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="idbut0" runat="server" OnClientClick="return confirmationDelete()" CommandName="Del" Text="Delete" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ItemCode0" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="13%" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="ManfDesc0" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UOM">
                                                    <ItemTemplate>
                                                        <asp:Label ID="UOMBasic0" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Stk Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstkqty0" runat="server" Text='<%# Eval("StockQty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="9%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BG Group">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldept0" runat="server" Text='<%# Eval("Dept") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="WONo" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblWONO" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Ret Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblretqty" runat="server" Text='<%# Eval("RetQty") %>'></asp:Label>
                                                        
                                                    </ItemTemplate>
                                                    <ItemStyle Width="7%" HorizontalAlign="Right" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Remarks">
                                                    <ItemTemplate>
                                                       <asp:Label ID="lblremrk" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label> 
                                                    
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:Button ID="btnProceed" runat="server" CommandName="proceed" OnClientClick="return confirmationAdd()" CssClass="redbox" Text="Generate MRN" />
                                                    </FooterTemplate>
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
                        
                        
                    </ContentTemplate>
                    
</cc1:TabPanel>
                </cc1:TabContainer>         
                
                
                
                
                
                
                
                
                
                        </td>
        </tr>
        </table>
        
</asp:Content>

    
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

