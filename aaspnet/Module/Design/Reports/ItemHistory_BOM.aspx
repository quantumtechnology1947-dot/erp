<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_ItemHistory_BOM, newerp_deploy" title="ERP" theme="Default" %>

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
  
  <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Item History</b></td>
             </tr>
    <tr>
            <td class="fontcsswhite" height="25" valign="middle" >
            
             &nbsp;
            
            <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem Value="Category">Category</asp:ListItem>
                     <asp:ListItem Value="WOItems">WO Items</asp:ListItem>                    
                </asp:DropDownList>
                <asp:DropDownList ID="DrpCategory" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" Height="21px" 
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
                    AutoPostBack="True" CssClass="box3">
                            </asp:DropDownList>

            
                <asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>
                
                &nbsp;<asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        
                        
                        
                        </td>
             </tr>
  
  
 <tr>
 
 
 <td>
  
  <asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" Width="100%" PageSize="20">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle 
                            HorizontalAlign="Right" Width="2%"></ItemStyle>
                            </asp:TemplateField>
                            
                            <asp:HyperLinkField DataNavigateUrlFields="Id" 
                            DataNavigateUrlFormatString="~/Module/Design/Reports/ItemHistory_BOM_View.aspx?Id={0}&amp;ModId=3&amp;SubModId=21" 
                            Text="Select" >
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:HyperLinkField>
                            <asp:BoundField DataField="Id" HeaderText="Id" 
                            Visible="False" />
                            <asp:BoundField DataField="Category" HeaderText="Category">
                           
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="PartNo" HeaderText="PartNo" Visible="False">
                           
                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           <asp:BoundField DataField="ItemCode" HeaderText="ItemCode">
                           
                                <ItemStyle Width="6%" HorizontalAlign="Center" />
                            </asp:BoundField>
                           
                           
                            <asp:BoundField DataField="ManfDesc" HeaderText="Manf Desc">
                           
                                <ItemStyle Width="25%" />
                            </asp:BoundField>
                           
                         
                            
                            <asp:BoundField DataField="UOMBasic" HeaderText="UOM ">
                            
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:BoundField>                            
                  
                           
                            <asp:BoundField DataField="Location" HeaderText="Location">
                            
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
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
     
                
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

