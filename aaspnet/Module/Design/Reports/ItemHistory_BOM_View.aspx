<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Reports_ItemHistory_BOM_View, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 27px;
        }
        .style3
        {
            height: 25px;
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
 <table width="100%" cellpadding="0" cellspacing="0">
    <tr>
    <td  valign="middle" colspan="4" align="left" valign="middle" 
        style="background:url(../../../images/hdbg.JPG)" height="21" 
        class="fontcsswhite"><b>Item History</b>           
        &nbsp;</td>
     </tr>  
 <tr> 
 <td>  
     &nbsp;</td>   
 <td>  
     &nbsp;</td>   
 <td width="25%">  
     &nbsp;</td> 
 <td width="25%">  
     &nbsp;</td>   
 </tr>  
 <tr>
 
 <td class="style2">  
     &nbsp;&nbsp;&nbsp;            
                <asp:Label ID="Label2" runat="server" Text="ItemCode : " 
                    style="font-weight: 700; text-align: justify"></asp:Label>            
                <asp:Label ID="LblCode" runat="server"></asp:Label>
     </td>
 <td class="style2">  
     <asp:Label ID="Label5" runat="server" Text="UOM :" 
                    style="font-weight: 700"></asp:Label>
                <asp:Label ID="LblUOMBasic" runat="server"></asp:Label>
     </td> 
 <td class="style2" width="15%">  
     </td> 
 <td class="style2" width="15%">  
     </td>   
     </tr>
 <tr>
 
 <td colspan="3" class="style3">  
     &nbsp;&nbsp;&nbsp;            
                <asp:Label ID="Label3" runat="server" Text=" Description :" style="font-weight: 700"></asp:Label>            
                <asp:Label ID="lblManfdesc" runat="server"></asp:Label>
     </td>   
 
 <td class="style3">  
     </td>   
     </tr>  
 <tr>
 
 <td colspan="4" align="center">  
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox" onclick="btnCancel_Click" Text="Cancel" />
     </td>   
     </tr> 
 <tr> 
 <td colspan="4" align="center">  
     &nbsp;</td>  
     </tr>  
 <tr> 
 <td colspan="4">  
     <table align="left" cellpadding="0" cellspacing="0" width="100%">
         <tr>
             <td>
  
                 <asp:Panel ID="Panel1" runat="server" Height="340px" ScrollBars="Auto">
                     <asp:GridView ID="GridView2" runat="server" AllowPaging="False"  OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" DataKeyNames="Id" 
         Width="80%" PageSize="15">
                         <Columns>
                             <asp:HyperLinkField DataNavigateUrlFields="Id" 
                            Text="Select" 
                            NavigateUrl="~/Module/Design/Reports/ItemHistory_BOM_View.aspx" 
                            Visible="False" />
                             <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                     <%# Container.DataItemIndex + 1%>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                             </asp:TemplateField>
                             <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                             <asp:TemplateField HeaderText="WO No">
                                 <ItemTemplate>
                                     <asp:Label ID="lblwono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="5%" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Date">
                                 <ItemTemplate>
                                     <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="5%" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Time">
                                 <ItemTemplate>
                                     <asp:Label ID="lblTime" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="6%" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Assembly No">
                                 <ItemTemplate>
                                     <asp:Label ID="lblasslyno" runat="server" Text='<%# Eval("AssemblyNo") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="9%" />
                             </asp:TemplateField>
                             <%-- <asp:TemplateField HeaderText="Item Code">
                          <ItemTemplate>
                          <asp:Label ID="lblItemcode" runat="server" Text='<%# Eval("Itemcode") %>'></asp:Label>
                          </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" Width="12%" />
                          </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="Description">
                                 <ItemTemplate>
                                     <asp:Label ID="lblManfDesc0" runat="server" 
                                   Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Left" Width="30%" />
                             </asp:TemplateField>
                             <%--  <asp:TemplateField HeaderText="Purchase Desc" Visible="False">
                          <ItemTemplate>
                          <asp:Label ID="lblPurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left" />
                          </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="UOM ">
                                 <ItemTemplate>
                                     <asp:Label ID="lblUOMBasic0" runat="server" 
                                    Text='<%# Eval("UOMBasic") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Center" Width="10%" />
                             </asp:TemplateField>
                             <%-- <asp:TemplateField HeaderText="UOM Purch" Visible="False">
                          <ItemTemplate>
                          <asp:Label ID="lblUOMPurchase0" runat="server" Text='<%# Eval("UOMPurchase") %>'></asp:Label>
                          </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="6%" />
                          </asp:TemplateField>
                          
                           <asp:TemplateField HeaderText="Unit Qty">
                          <ItemTemplate>
                          <asp:Label ID="lblUnitQty" runat="server" Text='<%# Eval("UnitQty") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                          </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="BOM Qty">
                                 <ItemTemplate>
                                     <asp:Label ID="lblBOMQty" runat="server" 
                                   Text='<%# Eval("BOMQty") %>'></asp:Label>
                                 </ItemTemplate>
                                 <ItemStyle HorizontalAlign="Right" Width="8%" />
                             </asp:TemplateField>
                         </Columns>
                         <EmptyDataTemplate>
                             <table width="100%" class="fontcss">
                                 <tr>
                                     <td align="center">
                                         <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                                     </td>
                                 </tr>
                             </table>
                         </EmptyDataTemplate>
                     </asp:GridView>
                 </asp:Panel>
             </td>
         </tr>
         <tr>
             <td align="center" height="22">
  
                 <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Total:"></asp:Label>
&nbsp;<asp:Label ID="lblTot" runat="server"></asp:Label>
             </td>
         </tr>
     </table>
     </td>   
   </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>