<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectSummary_Componant_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #000000;
            text-decoration: none;
            height: 28px;
        }
    </style>  
    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <table cellpadding="0" cellspacing="0" style="width: 550%" >                             
    <tr>
<td align="left" class="style1">&nbsp;<b>Summary Details For WoNo: </b>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    &nbsp;&nbsp; 
    <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
        onclick="btnCancel_Click" Text="Cancel" />
</td>
    </tr>
                      
    <tr>
<td>
           
    <asp:Panel ID="Panel1" runat="server" Width="100%">
    
        <telerik:RadTreeList runat="server" ID="RadTreeList1" AllowPaging="True"  HeaderStyle-HorizontalAlign="Center"
            PageSize="50" Width="100%"   
            DataKeyNames="CId" OnItemCommand="RadTreeList1_ItemCommand1"  
            OnPageSizeChanged="RadTreeList1_PageSizeChanged"  OnPageIndexChanged="RadTreeList1_PageIndexChanged"
            ParentDataKeyNames="PId"
            AutoGenerateColumns="False"  
           >       
            
         
            <Columns>            
                      
                            <telerik:TreeListBoundColumn DataField="PId" HeaderText="Parent Node" 
                            UniqueName="PId" Visible="false" />
                        <telerik:TreeListBoundColumn DataField="CId"   HeaderText="Assembly" 
                            UniqueName="CId" Visible="false"/> 
                       <telerik:TreeListBoundColumn DataField="WONo" HeaderText="WorkOrder" 
                            UniqueName="WONo"  Visible="false"/>
                            <telerik:TreeListBoundColumn DataField="ItemId" HeaderText="ItemId" 
                            UniqueName="ItemId"  Visible="False"/> 
                           <telerik:TreeListBoundColumn DataField="ItemCode" HeaderText="Item Code" 
                            UniqueName="ItemCode"  HeaderStyle-Width="4%" Visible="true"/> 
                            
                            
                            <telerik:TreeListBoundColumn DataField="ManfDesc" HeaderText="Manf. Desc" 
                            UniqueName="ManfDesc"  HeaderStyle-Width="8%"  Visible="true"/>                           
                            <telerik:TreeListBoundColumn DataField="UOM" HeaderText="UOM" 
                            UniqueName="UOM" ItemStyle-HorizontalAlign="Center"  Visible="true"/>
                                                       
                            <telerik:TreeListBoundColumn DataField="UnitQty" HeaderText="Quantity" 
                            UniqueName="UnitQty" ItemStyle-HorizontalAlign="Right"  Visible="true"/>
                            <telerik:TreeListBoundColumn DataField="BOMQty" HeaderText="BOMQty" 
                            UniqueName="BOMQty" ItemStyle-HorizontalAlign="Right"  Visible="true"/>
                         <telerik:TreeListBoundColumn DataField="Weld" HeaderText="Weldments" 
                            UniqueName="Weld" ItemStyle-HorizontalAlign="Right"  Visible="true"/>
                             <telerik:TreeListBoundColumn DataField="LH" HeaderText="LH" 
                            UniqueName="LH" ItemStyle-HorizontalAlign="Right" Visible="true"/>
                            <telerik:TreeListBoundColumn DataField="RH" HeaderText="RH" 
                            UniqueName="RH"  ItemStyle-HorizontalAlign="Right" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="PLNo"  HeaderText="PLNo" 
                            UniqueName="PLNo" ItemStyle-HorizontalAlign="Center" Visible="true"/>                             
                                           
                            <telerik:TreeListBoundColumn DataField="PLDate"  HeaderText="Planning Date" 
                            UniqueName="PLDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="PLGenBy"  HeaderText="Plan.By" 
                            UniqueName="PLGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="PLId"  HeaderText="Plan.Id" 
                            UniqueName="PLId" Visible="false"/>
                             <telerik:TreeListBoundColumn DataField="PRNo"  HeaderText="PRNO" 
                            UniqueName="PRNo" ItemStyle-HorizontalAlign="Center" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="PRDate"  HeaderText="PR Date" 
                            UniqueName="PRDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="PRGenBy"  HeaderText="PR.By" 
                            UniqueName="PRGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="PRSupplier"  HeaderText="Supplier" 
                            UniqueName="PRSupplier" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="PRQty"  HeaderText="PR.Qty" 
                            UniqueName="PRQty" ItemStyle-HorizontalAlign="Right" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="PRId"  HeaderText="PR.Id" 
                            UniqueName="PRId" Visible="false"/> 
                             <telerik:TreeListBoundColumn DataField="PONo"  HeaderText="PONO" 
                            UniqueName="PONo" ItemStyle-HorizontalAlign="Center" Visible="true"/>              
                            <telerik:TreeListBoundColumn DataField="PODate"  HeaderText="PO Date" 
                            UniqueName="PODate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="POGenBy"  HeaderText="PO.By" 
                            UniqueName="POGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="POSupplier"  HeaderText="Supplier" 
                            UniqueName="POSupplier" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="POQty"  HeaderText="PO.Qty" 
                            UniqueName="POQty" ItemStyle-HorizontalAlign="Right" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="POId"  HeaderText="PO.Id" 
                            UniqueName="POId" Visible="false"/>
                            <telerik:TreeListBoundColumn DataField="POCheckDt"  HeaderText="PO Check Dt" 
                            UniqueName="POCheckDt" ItemStyle-HorizontalAlign="Center" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="POApproveDt"  HeaderText="PO Approve Dt" 
                            UniqueName="POApproveDt" ItemStyle-HorizontalAlign="Center" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="POAuthDt"  HeaderText="PO Auth Dt" 
                            UniqueName="POAuthDt" ItemStyle-HorizontalAlign="Center" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="GINNo"  HeaderText="GINNo" 
                            UniqueName="GINNo" ItemStyle-HorizontalAlign="Center" Visible="true"/>               
                            <telerik:TreeListBoundColumn DataField="GINDate"  HeaderText="GIN Date" 
                            UniqueName="GINDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="GINGenBy"  HeaderText="GIN GenBy" 
                            UniqueName="GINGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="GINQty"  HeaderText="GIN Qty" 
                            UniqueName="GINQty" ItemStyle-HorizontalAlign="Right" Visible="true"/>                             
                            <telerik:TreeListBoundColumn DataField="GINId"  HeaderText="GIN.Id" 
                            UniqueName="GINId" Visible="false"/>                              
                            <telerik:TreeListBoundColumn DataField="GRRNo"  HeaderText="GRRNo" 
                            UniqueName="GRRNo" ItemStyle-HorizontalAlign="Center" Visible="true"/>            
                            <telerik:TreeListBoundColumn DataField="GRRDate"  HeaderText="GRR Date" 
                            UniqueName="GRRDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="GRRGenBy"  HeaderText="GRR GenBy" 
                            UniqueName="GRRGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="GRRQty"  HeaderText="GRR Qty" 
                            UniqueName="GRRQty" ItemStyle-HorizontalAlign="Right" Visible="true"/>                              
                            <telerik:TreeListBoundColumn DataField="GRRId"  HeaderText="GRR.Id" 
                            UniqueName="GRRId" Visible="false"/>                            
                            <telerik:TreeListBoundColumn DataField="GQNNo"   HeaderText="GQNNo" 
                            UniqueName="GQNNo" ItemStyle-HorizontalAlign="Center" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="GQNDate"  HeaderText="GQN Date" 
                            UniqueName="GQNDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="GQNGenBy"  HeaderText="GQN GenBy" 
                            UniqueName="GQNGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="GQNQty"  HeaderText="GQN Qty" 
                            UniqueName="GQNQty" ItemStyle-HorizontalAlign="Right" Visible="true"/>                              
                            <telerik:TreeListBoundColumn DataField="GQNId"  HeaderText="GQN.Id" 
                            UniqueName="GQNId" Visible="false"/>                             
                            <telerik:TreeListBoundColumn DataField="GSNNo"  HeaderText="GSNNo" 
                            UniqueName="GSNNo" ItemStyle-HorizontalAlign="Center" Visible="true"/>               
                            <telerik:TreeListBoundColumn DataField="GSNDate"  HeaderText="GSN Date" 
                            UniqueName="GSNDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="GSNGenBy"  HeaderText="GSN GenBy" 
                            UniqueName="GSNGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="GSNQty"  HeaderText="GSN Qty" 
                            UniqueName="GSNQty" ItemStyle-HorizontalAlign="Right" Visible="true"/>                              
                            <telerik:TreeListBoundColumn DataField="GSNId"  HeaderText="GSN.Id" 
                            UniqueName="GSNId" Visible="false"/>                             
                            <telerik:TreeListBoundColumn DataField="WISNo"  HeaderText="WISNo" 
                            UniqueName="WISNo" ItemStyle-HorizontalAlign="Center" Visible="true"/>               
                            <telerik:TreeListBoundColumn DataField="WISDate"  HeaderText="WIS Date" 
                            UniqueName="WISDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="WISGenBy"  HeaderText="WIS GenBy" 
                            UniqueName="WISGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="WISQty"  HeaderText="WIS Qty" 
                            UniqueName="WISQty" ItemStyle-HorizontalAlign="Right" Visible="true"/> 
                            
                            <telerik:TreeListBoundColumn DataField="MINNo"  HeaderText="MINNo" 
                            UniqueName="MINNo" ItemStyle-HorizontalAlign="Center" Visible="true"/>               
                            <telerik:TreeListBoundColumn DataField="MINDate"  HeaderText="MIN Date" 
                            UniqueName="MINDate" ItemStyle-HorizontalAlign="Center" Visible="true" />
                        <telerik:TreeListBoundColumn DataField="MINGenBy"  HeaderText="MIN GenBy" 
                            UniqueName="MINGenBy" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="MINQty"  HeaderText="MIN Qty" 
                            UniqueName="MINQty" ItemStyle-HorizontalAlign="Right" Visible="true"/>                               
                             
                             <telerik:TreeListBoundColumn DataField="ShortageQty"  HeaderText="Shortage Qty" 
                            UniqueName="ShortageQty" ItemStyle-HorizontalAlign="Right" Visible="true"/> 
                            <telerik:TreeListBoundColumn DataField="Progress"  HeaderText="Progress(%)" 
                            UniqueName="Progress" ItemStyle-HorizontalAlign="Center" Visible="true"/>   
            </Columns>
            

<ClientSettings>
<Selecting AllowItemSelection="True"></Selecting>

</ClientSettings>

            <PagerStyle CssClass="fontcss" />
            
            <HeaderStyle Font-Bold="True" CssClass="fontcss" />
            
            <SelectedItemStyle CssClass="fontcss" />
            
            <PagerTemplate>
                <table width="15%">
                    <tr>
                        <td align="center" width="7%">
<asp:Button ID="btnPageFirst" runat="server" Text=" " CssClass="rtlPageFirst" CommandName="Page"
CommandArgument="First" />
<asp:Button ID="btnPagePrev" runat="server" Text=" " CssClass="rtlPagePrev" CommandName="Page"
CommandArgument="Prev" /> 
                        </td>
                        <td align="center" width="4%">
                        <%# (int)DataBinder.Eval(Container, "Paging.CurrentPageIndex") + 1 %>
                        </td>
                        <td align="center" width="8%">
                        <asp:Panel runat="server" ID="TreeListPagerPlaceHolder" />
<asp:Button ID="btnPageNext" runat="server" Text=" " CssClass="rtlPageNext" CommandName="Page"
CommandArgument="Next" />
<asp:Button ID="btnPageLast" runat="server" Text=" " CssClass="rtlPageLast" CommandName="Page"
CommandArgument="Last" />


        </td>
        <td align="left">
                Displaying page
                <%# (int)DataBinder.Eval(Container, "Paging.CurrentPageIndex") + 1 %>
                of
                <%# (int)DataBinder.Eval(Container, "Paging.PageCount") %>
                / Items
                <%# (int)DataBinder.Eval(Container, "Paging.FirstIndexInPage") + 1 %>
                to
                <%# (int)DataBinder.Eval(Container, "Paging.LastIndexInPage") + 1 %>
                of
                <%# DataBinder.Eval(Container, "Paging.DataSourceCount")%>
        </td>
        <td>
        
                    </tr>
                </table>
            </PagerTemplate>
            
        </telerik:RadTreeList>  
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
   </asp:Panel>
    </td>
</tr>  
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

