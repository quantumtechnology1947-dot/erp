<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_ProjectSummary_Shortage, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">



<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" defer="defer" type="text/javascript"></script> 
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
    
<style type="text/css">
    
    
.container 
{
    overflow:auto;
    margin-left:0px;   
    height:422px; 
    width:100%;  
    margin-top:15px;   
  
 }

.grdview_headers
{
    color:#330000; 
    position:absolute ;
    display:block;
    width:98.5%;
    margin-top:-18px;   
  
}


</style>
<script type="text/javascript">
    $(document).ready(function ()
     {
        $('.container tr>td:nth-child(2)').css("background-color", "#EAEAEA").css("position", "absolute");
    });
</script>
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

    <table >
<tr>
<td width="100%">
<b>  WONo : <asp:Label ID="lblWo" runat="server" Text=""></asp:Label></b>

</td>
</tr>
</table>


 <div class="container" >   

     <asp:UpdatePanel ID="UpdatePanel1" EnableViewState="true" UpdateMode="Always" runat="server">
   <ContentTemplate >
 
                     <asp:DataList ID="GridView3" CssClass="yui-datatable-theme" GridLines="Both" 
                runat="server"  ShowHeader="true"  Width="100%"  
                    >
                      <HeaderStyle  CssClass="grdview_headers" />
                    <HeaderTemplate >
                  <table cellpadding="0" cellspacing="0"   width="100%">
        <tr>
<th  style="text-align:center" width="2%" >SN</th>
<th  style="text-align:center" width="4%" >WONO</th>
<th  style="text-align:center" width="6%" >ITEM CODE</th>
<th  style="text-align:center" width="8%" >DESCRIPTION</th>
<th style="text-align:center" width="3%" >UOM</th>
<th style="text-align:center" width="5%" >BOM QTY</th>
<th style="text-align:center" width="6%" >BOM DT.</th>
<th style="text-align:center" width="5%">SHORT.QTY</th>
<th style="text-align:center" width="5%" >WIS QTY </th>
<th style="text-align:center" width="5%" >PR NO</th>
<th style="text-align:center" width="5%">PR QTY</th>
<th style="text-align:center"  width="4%">PO NO</th>
<th style="text-align:center" width="5%" >PO QTY</th>
<th style="text-align:center"  width="6%">PO DT.</th>
<th style="text-align:center"  width="6%">SCH.DT.</th>
<th style="text-align:center" width="5%">PO RATE</th>
<th style="text-align:center" width="4%">AMOUNT</th>
<th style="text-align:center" width="6%">SUPPLIER</th>
<th style="text-align:center"  width="5%" >GIN NO</th> 
<th style="text-align:center" width="5%" >GIN QTY</th>         
        </tr>
      </table>
     </HeaderTemplate >
                            <ItemTemplate>
 
                     <table cellpadding="0"  cellspacing="0"  width="100%">
                     <tr>
        
        <td    align="right" width="2%">
             <asp:Label ID="lblsn" runat="server" Text='<%#Eval("Sn") %>'> </asp:Label>
                </td>
                <td  class="leftedge" width="4%">
               &nbsp;<asp:Label ID="lblWono" runat="server" Text='<%#Eval("WONo") %>'> </asp:Label></td>
            <td class="leftedge" align="center" width="6%">
             <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label>
                </td>
            <td  class="leftedge" width="8%">
               <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'> </asp:Label></td>
             <td class="leftedge" align="center" width="3%" >
                 <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOM") %>'> </asp:Label></td>
              <td class="leftedge" align="right" width="5%">
                 <asp:Label ID="lblBomQty" runat="server" Text='<%#Eval("BOMQty") %>'> </asp:Label></td>
                  
                 <td class="leftedge" align="center" width="6%">
                 <asp:Label ID="lblbomdt" runat="server" Text='<%#Eval("BOMDate") %>'> </asp:Label></td>
                  <td class="leftedge" align="right" width="5%">
                 <asp:Label ID="lblshortqty" runat="server" Text='<%#Eval("ShortQty") %>'> </asp:Label></td>
                 <td class="leftedge" align="right" width="5%">
                 <asp:Label ID="Label1" runat="server" Text='<%#Eval("WISQty") %>'> </asp:Label></td>
         <td class="leftedge" width="56%">                    
                <asp:DataList ID="DataList2" runat="server" Width="100%">
                <ItemTemplate>
                <table cellpadding="0"   cellspacing="0" width="100%"> 
                <tr> 
                 <td  align="center"  width="9%">
                 <asp:Label ID="lblPRNo" runat="server" Text='<%#Eval("PRNo") %>'> </asp:Label>
                 </td>
                  <td  align="right" class="leftedge"  width="9%">
               <asp:Label ID="lblPRQty" runat="server" Text='<%#Eval("PRQty") %>'> </asp:Label>
               </td>
               
               <td class="leftedge" width="82%">
               <asp:DataList ID="DataList3" runat="server" width="100%" 
             onitemcommand="DataList3_ItemCommand" > 
                
                <ItemTemplate>
            <table cellpadding="0" cellspacing="0"  width="100%"> 
            <tr>
            <td visible ="false">
            <asp:Label ID="lblPOId" runat="server" Visible="false" Text='<%#Eval("POId") %>'> </asp:Label>
            </td> 
            <td  align="center"  width="9%">
            <asp:LinkButton ID="lblPONo" CommandName="NavTo" Text='<%#Eval("PONo") %>' runat="server"></asp:LinkButton>
            </td>  
              
            <td  align="right" class="leftedge"  width="11%">
            <asp:Label ID="lblPOQty" runat="server" Text='<%#Eval("POQty") %>'> </asp:Label>
            </td> 
           
            <td  align="center" class="leftedge" width="13%" >
            <asp:Label ID="lblPODate" runat="server" ForeColor ="Green" Font-Bold="true" Text='<%#Eval("PODate") %>'> </asp:Label>
            </td> 
            <td  align="center" class="leftedge" width="13%" >
            <asp:Label ID="lblPODelDate" runat="server" Font-Bold="true" ForeColor ="Red" Text='<%#Eval("PODelDate") %>'> </asp:Label>
            </td> 
            <td class="leftedge" align="right" width="11%">
            <asp:Label ID="lblPoRate" runat="server" Text='<%#Eval("PORate") %>'> </asp:Label>
            </td>
            <td class="leftedge" align="right" width="8%" >
            <asp:Label ID="lblAmnt" runat="server" Text='<%#Eval("POAmount") %>'> </asp:Label></td>
            <td class="leftedge" width="13%"  >&nbsp;
            <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("Supplier") %>'> </asp:Label>
            </td>
            
            <td class="leftedge"  width="22%">
            <asp:DataList ID="DataList4" runat="server" width="100%">
            <ItemTemplate>
            <table cellpadding="0" cellspacing="0"  width="100%"> 
            <tr>
            <td   align="center" width="50%">
            <asp:Label ID="lblGInNo" runat="server" Text='<%#Eval("GINNo") %>'> </asp:Label></td> 
            <td  align="right" class="leftedge" width="50%">
            <asp:Label ID="lblGINQty" runat="server" Text='<%#Eval("GINQty") %>'> </asp:Label></td>            
            </tr>
            </table> 
            </ItemTemplate>    
            </asp:DataList>  
            </td>
            </tr>
            </table>
                
               
                
                </ItemTemplate>    
                </asp:DataList>  
                
               </td>
            
        </tr>       
                 </table>                 
                </ItemTemplate>    
                </asp:DataList> 
                  
            </td>
            
        </tr>      
                    </table>
    
   

                      </ItemTemplate> 
                      <ItemStyle Wrap="true" />
                 </asp:DataList>
             
     </ContentTemplate>  </asp:UpdatePanel>
    
    </div> 
   
   
   
    <table width="100%">     
     <tr>
     <td align="center">         
             <asp:Button ID="btnExport" runat="server" CssClass="redbox" 
         onclick="btnExport_Click" Text="Export To Excel" />&nbsp;<asp:Button ID="btnCancel" CssClass="redbox" runat="server" Text="Cancel" 
             onclick="btnCancel_Click" />
             </td>
             
             
     </tr></table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

