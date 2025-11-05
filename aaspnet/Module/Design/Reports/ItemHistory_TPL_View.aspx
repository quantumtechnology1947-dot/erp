<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Reports_ItemHistory_TPL_View, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 322px;
        }
        .style4
        {
        }
        .style5
        {
            width: 114px;
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
<table width="100%" cellspacing="0" cellpadding="0">
    <tr>
            <td  valign="middle" colspan="3" align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>Item History - TPL</b></td>
             </tr>
  
  
    <tr>
            <td  height="25" valign="middle" class="style5" >
            
                &nbsp;
            
                <asp:Label ID="Label2" runat="server" Text="ItemCode " style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
            <td  height="25" valign="middle" class="style3" >
            
                <asp:Label ID="LblCode" runat="server"></asp:Label>
                        </td>
            <td  height="25" valign="middle" >
            
                <asp:Label ID="Label3" runat="server" Text="Manf Desc" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="lblManfdesc" runat="server"></asp:Label>
                        </td>
             </tr>
  
  
    <tr>
            <td  height="25" valign="middle" class="style5" >
            
                &nbsp;
            
                <asp:Label ID="Label4" runat="server" Text="Purchase Desc" 
                    style="font-weight: 700"></asp:Label>
&nbsp;
                        </td>
            <td  height="25" valign="middle" class="style3" >
            
                <asp:Label ID="lblPDesc" runat="server"></asp:Label>
                        </td>
            <td height="25" valign="middle" style="margin-left: 120px" >
            
                <asp:Label ID="Label5" runat="server" Text="UOM Basic" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="LblUOMBasic" runat="server"></asp:Label>
                        </td>
             </tr>
  
  
    <tr>
            <td  height="25" valign="top" class="style5" >
            
                &nbsp;
            
                <asp:Label ID="Label10" runat="server" style="font-weight: 700">UOM Purchase</asp:Label>
&nbsp;
                        </td>
            <td  height="25" valign="top" class="style3" >
            
                <asp:Label ID="LblUOMPurchase" runat="server"></asp:Label>
                        </td>
            <td  height="25" valign="middle" >
            
                <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    onclick="Button1_Click" Text="Cancel" />
            </td>
             </tr>
  
  
 <tr>
 
 
 <td colspan="3">
  
     &nbsp;</td>   
             </tr>
  
  
 <tr>
 
 
 <td colspan="3" >
  
     
  <asp:GridView ID="GridView2" runat="server" AllowPaging="True"  OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
         Width="100%" PageSize="15">
                 <Columns>
                        
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                       <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                      
                          <asp:TemplateField HeaderText="WO No">
                          <ItemTemplate>
                          <asp:Label ID="lblwono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Center"  Width="5%"/>
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Date">
                          <ItemTemplate>
                          <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="8%" />
                          </asp:TemplateField>
                           <asp:TemplateField HeaderText="Time">
                          <ItemTemplate>
                          <asp:Label ID="lblTime" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="8%" />
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Assembly No">
                          <ItemTemplate>
                          <asp:Label ID="lblasslyno" runat="server" Text='<%# Eval("AssemblyNo") %>'></asp:Label>
                          </ItemTemplate>
                          <ItemStyle HorizontalAlign="center" Width="9%" />
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Item Code">
                          <ItemTemplate>
                          <asp:Label ID="lblItemcode" runat="server" Text='<%# Eval("Itemcode") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="center" Width="12%" />
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText=" Manf Desc">
                          <ItemTemplate>
                          <asp:Label ID="lblManfDesc0" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left"  />
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Purchase Desc" Visible="False">
                          <ItemTemplate>
                          <asp:Label ID="lblPurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Left"  />
                          </asp:TemplateField>
                          
                           <asp:TemplateField HeaderText="UOM Basic">
                          <ItemTemplate>
                          <asp:Label ID="lblUOMBasic0" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Center"  Width="10%"/>
                          </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="UOM Purch" Visible="False">
                          <ItemTemplate>
                          <asp:Label ID="lblUOMPurchase0" runat="server" Text='<%# Eval("UOMPurchase") %>'></asp:Label>
                          </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="7%"/>
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Unit Qty">
                          <ItemTemplate>
                          <asp:Label ID="lblUnitQty" runat="server" Text='<%# Eval("UnitQty") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Right" Width="8%"/>
                          </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="TPL Qty">
                          <ItemTemplate>
                          <asp:Label ID="lblTPLQty" runat="server" Text='<%# Eval("TPLQty") %>'></asp:Label>
                          </ItemTemplate>
                              <ItemStyle HorizontalAlign="Right" Width="8%"/>
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
                <table align="left" cellpadding="0" cellspacing="0" class="style2">
         <tr>
             <td>
            
                 &nbsp;</td>
         </tr>
     </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

