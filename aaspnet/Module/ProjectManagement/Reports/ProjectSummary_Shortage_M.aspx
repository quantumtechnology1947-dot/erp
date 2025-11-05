<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectSummary_Shortage_M.aspx.cs" Inherits="Module_ProjectManagement_Reports_ProjectSummary_Shortage_M" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" defer="defer" type="text/javascript"></script>  

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
  
    <style type="text/css">
 .container 
 {
    overflow:auto;
    margin-left:0px;   
    height:420px; 
    width:100%;  
    margin-top:18px;
  
 }

.grdview_headers
{
    color:#330000; 
    position:absolute ;
    display:block;
    width:98.4%;
    margin-top:-22px;
  
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">


<table width="100%">
<tr>
<td>
<b>  WONo : <asp:Label ID="lblWo" runat="server" Text=""></asp:Label>&nbsp;[Manufacturing 
    Items]</b></td>
</tr>
</table>
<div class="container" >
    
   
                     <asp:DataList ID="GridView3" CssClass="yui-datatable-theme" GridLines="Both" 
                runat="server"  Width="100%" 
                    >
                    
                    <HeaderTemplate >
                  <table cellpadding="0" cellspacing="0"   width="100%">
        <tr>
<th  style="text-align:center" width="5%" >SN</th>
<th  style="text-align:center" width="10%" >Item Code</th>
<th  style="text-align:center" width="40%" >Description</th>
<th style="text-align:center" width="5%" >UOM</th>
<th style="text-align:center" width="10%" >Bom Qty</th> 
<th style="text-align:center" width="10%">WIS Qty</th>
<th style="text-align:center" width="10%">Stock Qty</th>               
<th style="text-align:center" width="10%">Short Qty</th>
            
        </tr>
      </table>
                    </HeaderTemplate>
                    <HeaderStyle  CssClass="grdview_headers" />
                            <ItemTemplate>
                     <table cellpadding="0"  cellspacing="0"  width="100%">
       
      
        <tr>
        
        <td    align="right" width="5%">
             <asp:Label ID="lblsn" runat="server" Text='<%#Eval("Sn") %>'> </asp:Label>
                </td>
            <td class="leftedge" align="center" width="10%">
             <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label>
                </td>
            <td  class="leftedge" width="40%">
               &nbsp;<asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'> </asp:Label></td>
             <td class="leftedge" align="center" width="5%" >
                 <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOM") %>'> </asp:Label></td>
              <td class="leftedge" align="right" width="10%">
                 <asp:Label ID="lblBomQty" runat="server" Text='<%#Eval("BOMQty") %>'> </asp:Label></td>
                 
                 <td class="leftedge" align="right" width="10%">
               <asp:Label ID="lblWISQty" runat="server" Text='<%#Eval("WISQty") %>'> </asp:Label></td>
                       <td class="leftedge" align="right" width="10%">
               <asp:Label ID="lblStockQty" runat="server" Text='<%#Eval("StockQty") %>'> </asp:Label></td> 
           <td class="leftedge" align="right" width="10%">
               <asp:Label ID="lblShortQty" runat="server" Text='<%#Eval("ShortQty") %>'> </asp:Label></td> 
            
        </tr>       
      
    </table>
                      </ItemTemplate> 
                      <ItemStyle Wrap="true" />

                           <FooterTemplate>

                            
               <b><asp:Label ID="lblShortQty1" runat="server" Text='<%#Eval("TotShortQty") %>'> </asp:Label></b>

                         </FooterTemplate>
                         <FooterStyle  HorizontalAlign="Right"    />
                 </asp:DataList>
             
     
     
    </div>
<table width="100%">     
     <tr>
     <td align="center">
     <asp:Button ID="btnExport" runat="server" CssClass="redbox" Text="Export" 
                    onclick="btnExpor_Click" />
                    
         &nbsp;<asp:Button ID="btnCancel" CssClass="redbox" runat="server" Text="Cancel" 
             onclick="btnCancel_Click" /></td>
     </tr></table>   

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

