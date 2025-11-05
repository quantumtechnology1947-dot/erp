<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_ItemHistory_TPL, newerp_deploy" title="ERP" theme="Default" %>

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
  
  
  <table width="100%">
    <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>Item History - TPL</b></td>
             </tr>
  
  
    <tr>
            <td class="fontcsswhite" height="25" valign="middle" >
            
                <asp:DropDownList ID="DrpCategory" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" Height="21px" 
                    CssClass="box3">
                    
                </asp:DropDownList> 
                
                 &nbsp;<asp:DropDownList ID="DrpSubCategory" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpSubCategory_SelectedIndexChanged" Height="21px" 
                    CssClass="box3">
                    
                </asp:DropDownList>
            
                &nbsp;&nbsp;
                <asp:DropDownList ID="DrpSearchCode" runat="server" 
                    Height="21px" Width="200px" CssClass="box3">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Manuf. Description</asp:ListItem>
                     <asp:ListItem Value="tblDG_Item_Master.PurchDesc">Purchase Description</asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;
            
                <asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>
                
        &nbsp;&nbsp;
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>
  
  
 <tr>
 
 
 <td>
  
  <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="15"  OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
         Width="75%">
                 <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="4%"  ></ItemStyle>
                        </asp:TemplateField>
                        <asp:HyperLinkField DataNavigateUrlFields="Id"
                            Text="Select" 
                            NavigateUrl="~/Module/Design/Reports/ItemHistory_TPL_View.aspx" 
                            DataNavigateUrlFormatString="~/Module/Design/Reports/ItemHistory_TPL_View.aspx?Id={0}" >
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:HyperLinkField>                       
                        <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="Id"  runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                        <asp:Label ID="ItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="13%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Manf  Desc">
                        <ItemTemplate>
                        <asp:Label ID="ManfDesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Purch Desc" Visible="False">
                        <ItemTemplate>
                        <asp:Label ID="PurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UOM Basic">
                        <ItemTemplate>
                        <asp:Label ID="UOMBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Location">
                        <ItemTemplate>
                        <asp:Label ID="Location" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
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
                
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

