<%@ page language="C#" autoeventwireup="true" debug="true" masterpagefile="~/MasterPage.master" inherits="Module_Inventory_GoodsInwardNote_GIN_Delete_Details, newerp_deploy" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            height: 34px;
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
<table class="fontcss" width="100%" cellpadding="0" cellspacing="0">
                       <tr>
       <td   align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Inward Note [GIN] - Delete</b></td>
           </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%">
                    
     
                        <tr>
                            <td height="25px" colspan="6">
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="GIN No"></asp:Label>
                            &nbsp;:
                    <asp:Label ID="Lblgnno" runat="server" style="font-weight: 700"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Challan Date"></asp:Label>
                            &nbsp;:<asp:Label ID="LblChallanDate" runat="server" style="font-weight: 700"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:Label ID="Label3" runat="server" Text="Challan No "></asp:Label>
                    <asp:Label ID="lblChallanNo" runat="server" style="font-weight: 700"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="LblWODept" runat="server"></asp:Label>
&nbsp;:
                                <asp:Label ID="LblWONo" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3" height="25px">
&nbsp;&nbsp;
                    Gate Entry No:                     
&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="TxtGateentryNo" runat="server"></asp:Label>
                                </td>
                            <td class="style2" height="25px">
                    Date :<asp:Label ID="TxtGDate" runat="server"></asp:Label>
                            
&nbsp;&nbsp;&nbsp;&nbsp;Time&nbsp; :<asp:Label ID="lbltime" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td class="style2" height="25px">
                                &nbsp;</td>
                            <td class="style2" height="25px" align="right" width="12%">
                                Mode of Transport :</td>
                            <td class="style2" height="25px" align="left" width="20%">
                                <asp:Label ID="TxtModeoftransport" runat="server"></asp:Label>
                            </td>
                            <td class="style2" height="25px" width="20%">
                                &nbsp;&nbsp;Vehicle No :
                                <asp:Label ID="TxtVehicleNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
               
               
                <td class="fontcss"> 
                <asp:Panel ID="Panel1" ScrollBars="Auto" Height="410px" runat="server">
                     <asp:GridView ID="GridView1"  runat="server" 
                    AutoGenerateColumns="False"  Width="100%" DataKeyNames="Id" 
                    CssClass="yui-datatable-theme" onrowcommand="GridView1_RowCommand" 
                    AllowPaging="True" 
                         onpageindexchanging="GridView1_PageIndexChanging" >
                
                         <PagerSettings PageButtonCount="40" />
                
                <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                       <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                                               
                       <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkDel" CommandName="del" OnClientClick="return confirmationDelete();" Text="Delete" runat="server"></asp:LinkButton>
                            <asp:Label ID="lblgrr" runat="server" Text="GRR" Visible="false"></asp:Label>&nbsp;<asp:Label ID="lblgsn" runat="server" Text="GSN" Visible="false"></asp:Label>
                        </ItemTemplate>
                       
                            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
                                               
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Code" SortExpression="ItemCode">
                        <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                            <ItemStyle HorizontalAlign="center" />
                        
                        </asp:TemplateField>                      
                       
                                               
<asp:TemplateField HeaderText="Description" SortExpression="ManfDesc">
                        <ItemTemplate>
                        <asp:Label ID="lblPurChaseDesc" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>
                                            
                             <ItemStyle HorizontalAlign="Left" Width="30%" />
                             
                                            
                        </asp:TemplateField>
                        
                        
                       
                        
                        <asp:TemplateField HeaderText="UOM" SortExpression="UOMBasic">
                            
                        <ItemTemplate>
                        <asp:Label ID="lblUOMPurchase" runat="server" Text='<%#Eval("UOM") %>' >    </asp:Label>               
                        </ItemTemplate>
                                            
                            <ItemStyle HorizontalAlign="Center" />
                                           
                        </asp:TemplateField>                      
                       
                        
                        

              <%--          <asp:TemplateField HeaderText="Asset No" SortExpression="AssetNo" >
                        <ItemTemplate>
                        <asp:Label ID="lblAssetNo" runat="server" Text='<%#Eval("AssetNo") %>'>    </asp:Label> 
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="18%" />
                        </asp:TemplateField> --%>      
                        
                        
                        
                        
                                        
                                   <asp:TemplateField HeaderText="PO Qty" SortExpression ="Qty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblPOQty" runat="server" Text='<%#Eval("poqty") %>' > </asp:Label>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" />
                                     </asp:TemplateField>                                    
                                     
             <asp:TemplateField HeaderText="Challan Qty" SortExpression ="ChallanQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblChallanQty" runat="server" Text='<%#Eval("ChallanQty") %>'  > </asp:Label>
                                  
                                     
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" />
                                     </asp:TemplateField>  
                                     
                                       <asp:TemplateField HeaderText="Recd Qty" SortExpression ="ReceivedQty">
                                     <ItemTemplate>
                                     <asp:Label ID="lblReceivedQty" runat="server" Text='<%#Eval("RecedQty") %>' > </asp:Label>
                             </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Right" />
                                     </asp:TemplateField>  
                                     
                         <asp:TemplateField HeaderText="POId"  Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblPOId" runat="server" Text='<%#Eval("POId") %>'> </asp:Label>  
                        </ItemTemplate>
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
                </asp:GridView> </asp:Panel>
                </td> 
                
               
            </tr>
            
            <tr>
            <td align="center">
                <asp:Button ID="btnCancel" CssClass="redbox" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" />
            
            </td>
            
            </tr>
            </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
