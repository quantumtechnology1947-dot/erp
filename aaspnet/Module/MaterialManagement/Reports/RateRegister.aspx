<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_RateRegister, newerp_deploy" title="ERP" theme="Default" %>

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
    
  <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>&nbsp;Rate Register </b></td>
             </tr>
    <tr>
            <td valign="bottom" align="left" >
            <table>
            <tr>
            <td>
                &nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                    Text="Search Option :"></asp:Label></td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" Font-Bold="True">
                    <asp:ListItem Value="0" >Item Wise</asp:ListItem>
                    <asp:ListItem Value="1">All</asp:ListItem>
                </asp:RadioButtonList></td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblmsg" runat="server" style="font-weight: 700; color: #FF3300"></asp:Label>
                </td>
                </tr>
                </table>
                        </td>
             </tr>
             <tr>
             <td>
             
            
      <asp:Panel ID="Panel1" runat="server"   Visible="false">
            
  <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td  height="25" valign="middle" >
            
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
            
            </td>
            </tr>
            <tr>
            <td  valign="middle" >
                   
                <asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" Width="100%" 
                    PageSize="20" onrowcommand="GridView2_RowCommand">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                      
                                
                    <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                    <asp:LinkButton ID ="lnkButton"  Text="Select" runat ="server" CommandName="sel">
                    </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle 
                            HorizontalAlign="Right" Width="4%"></ItemStyle>
                            </asp:TemplateField>                           
                      
                            
                              <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Category" HeaderText="Category">
                           
                                <ItemStyle  HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="PartNo" HeaderText="PartNo" Visible="False">
                           
                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           <asp:BoundField DataField="ItemCode" HeaderText="ItemCode">
                           
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           
                            <asp:BoundField DataField="ManfDesc" HeaderText="Manf Desc">
                           
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                           
                         
                            
                            <asp:BoundField DataField="UOMBasic" HeaderText="UOM ">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            
                           
                            <asp:BoundField DataField="MinOrderQty" HeaderText="Min Order Qty" 
                                Visible="False" >
                           
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="MinStockQty" HeaderText="Min Stock Qty" 
                                Visible="False">
                           
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="StockQty" HeaderText="Stock Qty" >
                           
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="Location" HeaderText="Location">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center"/>
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="Absolute" HeaderText="Absolute" Visible="False" >
                           
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="Excise" HeaderText="Excise">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="ImportLocal" HeaderText="Import/Local" >
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                            </asp:BoundField>
                          
                            <asp:BoundField DataField="OpeningBalDate" HeaderText="Open Bal Date" >
                           
                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="OpeningBalQty" HeaderText="Opening Bal Qty">
                           
                                <ItemStyle Width="8%" HorizontalAlign="Right" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="UOMconv" HeaderText="UOM Conv. Fact." 
                                Visible="False">
                            
                                <ItemStyle Width="8%" />
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
            
                        </td>
             </tr>
  
  
</table>
            </asp:Panel> 
             </td>
             </tr>
             
         </table>        
                
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

