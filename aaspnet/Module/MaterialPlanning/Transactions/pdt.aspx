<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"   AutoEventWireup="true" CodeFile="pdt.aspx.cs" Inherits="Module_MaterialPlanning_Transactions_pdt" Title="ERP"    Theme="Default" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            height: 19px;
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

 <%--<script type="text/javascript">
var prm = Sys.WebForms.PageRequestManager.getInstance();
//Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
prm.add_beginRequest(BeginRequestHandler);
// Raised after an asynchronous postback is finished and control has been returned to the browser.
prm.add_endRequest(EndRequestHandler);
function BeginRequestHandler(sender, args) {
//Shows the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.show();
}
}

function EndRequestHandler(sender, args) {
//Hide the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.hide();
}
}
</script>
    
<script type="text/javascript">
      window.onload = function(){
        var strCook = document.cookie;
        if(strCook.indexOf("!~")!=0)
        {
          var intS = strCook.indexOf("!~");
          var intE = strCook.indexOf("~!");
          var strPos = strCook.substring(intS+2,intE);
          document.getElementById("grdWithScroll").scrollTop = strPos;
        }
      }
      function SetDivPosition(){
        var intY = document.getElementById("grdWithScroll").scrollTop;
       // document.title = intY;
        document.cookie = "yPos=!~" + intY + "~!";
      }
    </script>
    <script type="text/javascript" language="javascript">
       window.scrollBy(100,100);
       
      function foo(){
       alert("ddd");
       if(grdWithScroll != null) alert(grdWithScroll.scrollTop);
      }
    </script>
<div>   
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
<asp:Image ID="Image1" ImageUrl="~/images/spinner-big.gif" AlternateText="Processing" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>
<cc1:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
<asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
                 <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            colspan="2" ><strong>&nbsp;Material Planning - New
                          </strong>&nbsp;&nbsp;&nbsp;<strong>WONo:</strong><asp:Label ID="lblWono" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                    <td rowspan="7" valign="top" width="65%">
                    
                        
                      <%-- <asp:Panel ID="pnlTree" Height="442px" HorizontalAlign="Center"  Width="98%"  ScrollBars="Auto" runat="server">    
                       --%>
                      <%-- <blockquote style="TEXT-ALIGN: center" >--%>
   <div id="grdWithScroll" style="OVERFLOW: auto; WIDTH:auto; HEIGHT: 440px" onscroll="SetDivPosition()">

                          <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="false" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="" RowStyle-HorizontalAlign ="Center"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    PageSize="20" OnRowCommand="SearchGridView1_RowCommand" 
                                >
                    <PagerSettings PageButtonCount="40" />
            
            <RowStyle />
            <Columns>
                
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                  
                  
                  
                  
                    <asp:TemplateField HeaderText="Item Code" >
                <ItemTemplate>
                <asp:LinkButton ID="btnCode"   CommandName="Show"  Text='<%#Eval("ItemCode") %>'   
                        runat="server"></asp:LinkButton>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                </asp:TemplateField>            
                                  
                      
                    <asp:TemplateField HeaderText="Description" >
                <ItemTemplate>
                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>         
                       
                      <asp:TemplateField HeaderText="UOM" >
                <ItemTemplate>
             <asp:Label ID="lbluombasic" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>               
                        
                        
                   <asp:TemplateField HeaderText="BOM Qty" >
                <ItemTemplate>
                <asp:Label ID="lblbomqty" runat="server" Text='<%#Eval("BOMQty") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>       
                        
                        
                        
                         <asp:TemplateField HeaderText="PR Qty" >
                <ItemTemplate>
            <asp:Label ID="lblprqty" runat="server" Text='<%#Eval("PRQty") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>       
                         
                        
                        
                        <asp:TemplateField HeaderText="WIS Qty" >
                <ItemTemplate>
             <asp:Label ID="lblwisqty" runat="server" Text='<%#Eval("WISQty") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>       
                          
                        
                       <asp:TemplateField HeaderText="GQN Qty" >
                <ItemTemplate>
                    <asp:Label ID="lblgqnqty" runat="server" Text='<%#Eval("GQNQty") %>'></asp:Label>
    
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>       
                           
                       <asp:TemplateField HeaderText="Draw/ img" >
                <ItemTemplate>
                <asp:LinkButton ID="lnkbtnImg" Text='<%#Eval("FileName") %>' CommandName="viewImg" 
                        runat="server"></asp:LinkButton>
    
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>      
                        
                       <asp:TemplateField HeaderText="Spec." >
                <ItemTemplate>
        <asp:LinkButton ID="lnkbtnSpec" Text='<%#Eval("AttName") %>' CommandName="viewSpec" 
                        runat="server"></asp:LinkButton>
    
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>                
                         
                       <asp:TemplateField HeaderText="Item Id" Visible="false" >
                <ItemTemplate>
                     <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'></asp:Label> 
                </ItemTemplate>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>       
                         
                            
            </Columns>
               <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon">
                         </asp:Label></td></tr></table>
                    </EmptyDataTemplate>
            
        </asp:GridView>
       
           </div>   
  <%-- </blockquote>--%>
            
            
      <%--  </asp:Panel> --%>
                        
                        
                       
                    
                    </td>
                    <td width="35%">
                    
                        <asp:Label ID="lblItemCode" runat="server" Font-Bold="True" Text="Item Code :" 
                            Visible="False"></asp:Label>
                        <b>
                        <asp:Label ID="lblItemCode0" runat="server" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="lblBomQty" runat="server" Font-Bold="True" Text="Bom Qty :" Visible="False"></asp:Label>
                        <asp:Label ID="lblBomQty0" runat="server" Font-Bold="True"></asp:Label>
                        <br />
                        </b>
                        <asp:Label ID="lblRawMaterial" runat="server" Font-Bold="True" 
                            Text="Raw Material [A]" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    
                
                    <tr>
                    <td width="35%" align="center" valign="top">
                       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                         <asp:Panel ID="Panel2" Height="100px" HorizontalAlign="Center"  Width="98%"  ScrollBars="Auto"  runat="server">                    
                           <asp:GridView  ID="GridView3" runat="server"  OnRowCommand="GridView3_RowCommand"   Width="100%"  AllowPaging="false" PageSize="17" 
                    CssClass="yui-datatable-theme"    
             AutoGenerateColumns="False">          
            
   <Columns>
   <asp:TemplateField>
    
    <HeaderTemplate>
    <asp:CheckBox ID="CheckBox1"  AutoPostBack="true"   runat="server" 
                oncheckedchanged="CheckBox1_CheckedChanged" /> 
    </HeaderTemplate>
       
           <ItemTemplate>
               <asp:ImageButton ID="ImageButton1" CommandName="RMDelete" ImageUrl="~/images/cross.gif"  runat="server" />              
              
           </ItemTemplate>           
           <ItemStyle HorizontalAlign="left"  />
           <HeaderStyle HorizontalAlign="left"  />
    </asp:TemplateField>    
       <asp:TemplateField HeaderText="Supplier">
       <ItemTemplate>
   
       <asp:TextBox ID="txtSupplierRM" Width="110px" Text='<%#Eval("Column1") %>'  runat="server" EnableViewState="true" 
                                                    CssClass="box3" />  
                                                                                            
      <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" TargetControlID="txtSupplierRM" runat="server" ServicePath=""    ServiceMethod="GetCompletionList" 
                                 CompletionInterval="100"
                                 EnableCaching="true" 
                                 CompletionSetCount="2" 
                                 MinimumPrefixLength="1"
                                 UseContextKey="True"
                                 Enabled="True"                                                           
                                 FirstRowSelected="True"                                     
                                 ShowOnlyCurrentWordInCompletionListItem="True"  CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt2" >
                                                    </cc1:AutoCompleteExtender>
                                                   
                                                    
                                                <asp:RequiredFieldValidator ID="ReqSupNmFinish" runat="server" 
                                                    ControlToValidate="txtSupplierRM" ErrorMessage="*"  ValidationGroup="azx"></asp:RequiredFieldValidator>
                      
                       </ItemTemplate>
       
           <ItemStyle HorizontalAlign="Left"/>
      </asp:TemplateField>
       <asp:TemplateField HeaderText="Qty">       
       <ItemTemplate>
        <asp:TextBox ID="txtRMQty" Width="50px"  Text='<%#Eval("Column2") %>' runat="server" EnableViewState="true" CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="ReqRMQty" runat="server" ControlToValidate="txtRMQty" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
           <ItemStyle  HorizontalAlign="left" />
       </asp:TemplateField>
       <asp:TemplateField HeaderText="Rate">
       
       <ItemTemplate>
        <asp:TextBox ID="txtRMRate" Width="50px" Text='<%#Eval("Column3") %>' runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="ReqRMRate" runat="server" ControlToValidate="txtRMRate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>
        
    <asp:TemplateField HeaderText="Discount">
       
       <ItemTemplate>
        <asp:TextBox ID="TxtDiscount" Width="40px" Text='<%#Eval("Column5") %>' runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="Reqrmdiscount" runat="server" ControlToValidate="TxtDiscount" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>    
   
   
   
   
       <asp:TemplateField HeaderText="Deliv.Date">
       
       <ItemTemplate>
       
       <asp:TextBox ID="txtRMDeliDate" Width="70px" Text='<%#Eval("Column4") %>' runat="server" 
                                                    EnableViewState="true" CssClass="box3"></asp:TextBox>
                                                    
                <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1"   Format="dd-MM-yyyy"  PopupPosition="BottomRight" Animated="True"  TargetControlID="txtRMDeliDate" runat="server"></cc1:CalendarExtender> 
                                                <asp:RequiredFieldValidator ID="ReqRMDeliDate" runat="server" 
                                                    ControlToValidate="txtRMDeliDate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegRMDeliDate" runat="server" 
                    ControlToValidate="txtRMDeliDate" ErrorMessage="*" 
                                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                    ValidationGroup="azx"></asp:RegularExpressionValidator>
       </ItemTemplate>
            <ItemStyle HorizontalAlign="left"  />
       </asp:TemplateField>      
         
       
        <asp:TemplateField HeaderText="Id"  Visible="false">
       
       <ItemTemplate>
           <asp:Label ID="lblRMId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>  
           <asp:Label ID="lblRMDMid" runat="server" Text='<%#Eval("Did") %>'></asp:Label> 
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>
      
               </Columns>              
        </asp:GridView>
            </asp:Panel>
                        
                         <%-- </ContentTemplate>
                      </asp:UpdatePanel>--%>
                    
                 
                    
                        </td>
                    </tr>
                    
                    
                    

                    <tr>
                    <td width="35%" valign="top">
                    
                        <asp:Label ID="lblProcess" runat="server" style="font-weight: 700" 
                            Text="Process [O]" Visible="False"></asp:Label>
                        </td>
                    </tr>
                                    
                    

                    <tr>
                    <td width="35%" align="center" valign="top"> 
                  <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                     <asp:Panel ID="Panel3" Height="100px" HorizontalAlign="Center"  Width="98%"  ScrollBars="Auto"  runat="server"> 
                      
                       
                        
                         <asp:GridView ID="GridView4" runat="server" OnRowCommand="GridView4_RowCommand" 
                     Width="100%"  AllowPaging="false" PageSize="17" 
                    CssClass="yui-datatable-theme"   
             AutoGenerateColumns="False" HorizontalAlign="Center">          
            
            
   <Columns>
           
           
       
   <asp:TemplateField>
    
    <HeaderTemplate>
    <asp:CheckBox ID="CheckBox2"  AutoPostBack="true"   runat="server" 
                oncheckedchanged="CheckBox2_CheckedChanged" /> 
    </HeaderTemplate>
       
           <ItemTemplate>
               <asp:ImageButton ID="ImageButton2" CommandName="ProDelete" ImageUrl="~/images/cross.gif"  runat="server" />              
              
           </ItemTemplate>           
           <ItemStyle HorizontalAlign="left"  />
           <HeaderStyle HorizontalAlign="left"  />
    </asp:TemplateField> 
       <asp:TemplateField HeaderText="Supplier">
       <ItemTemplate>
     
       <asp:TextBox ID="txtSupplierPro" Width="110px" Text='<%#Eval("Column11") %>'  runat="server" EnableViewState="true" 
                                                    CssClass="box3" />    
                                                                                           
      <cc1:AutoCompleteExtender ID="AutoCompleteExtenderPro" TargetControlID="txtSupplierPro" runat="server" ServicePath=""    ServiceMethod="GetCompletionList" 
                                 CompletionInterval="100"
                                 EnableCaching="true"
                                 CompletionSetCount="2" 
                                 MinimumPrefixLength="1"
                                 UseContextKey="True"
                                 Enabled="True"                                
                                 FirstRowSelected="false"   
                                 ShowOnlyCurrentWordInCompletionListItem="false" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt2">
                                                    </cc1:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator ID="ReqSupplierPro" runat="server" 
                                                    ControlToValidate="txtSupplierPro" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator> 
                       </ItemTemplate>
       
           <ItemStyle HorizontalAlign="Left" />
       </asp:TemplateField>
        
   
      
       <asp:TemplateField HeaderText="Qty">
       
       <ItemTemplate>
        <asp:TextBox ID="txtProQty" Width="50px"  Text='<%#Eval("Column21") %>' runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="ReqProQty" runat="server" ControlToValidate="txtProQty" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
          <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>
        
   <asp:TemplateField HeaderText="Rate">
       <ItemTemplate>
               <asp:TextBox ID="txtProRate" Width="50px" Text='<%#Eval("Column31") %>' runat="server" CssClass="box3" 
                   EnableViewState="true"  />
               <asp:RequiredFieldValidator ID="ReqProRate" runat="server" 
                   ControlToValidate="txtProRate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>
           </ItemTemplate>
            <ItemStyle  HorizontalAlign="left" />
       </asp:TemplateField> 
       
       
        <asp:TemplateField HeaderText="Discount">
       
       <ItemTemplate>
        <asp:TextBox ID="TxtProDiscount" Width="40px" Text='<%#Eval("Column51") %>' runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="ReqProdiscount" runat="server" ControlToValidate="TxtProDiscount" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>       
          
       <asp:TemplateField HeaderText="Deliv.Date" >
       <ItemTemplate>
        <asp:TextBox ID="txtProDeliDate" Width="70px" Text='<%#Eval("Column41") %>' runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
           <cc1:CalendarExtender ID="CalendarExtenderPro" runat="server" CssClass="cal_Theme1" Animated="True" 
               Format="dd-MM-yyyy" PopupPosition="BottomRight" 
               TargetControlID="txtProDeliDate">
           </cc1:CalendarExtender>
         <asp:RequiredFieldValidator ID="ReqDeliDate" runat="server" ControlToValidate="txtProDeliDate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
           <asp:RegularExpressionValidator ID="RegProDeliDate" runat="server" 
               ControlToValidate="txtProDeliDate" ErrorMessage="*" 
               ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
               ValidationGroup="azx"></asp:RegularExpressionValidator>
              
       </ItemTemplate>
            <ItemStyle HorizontalAlign="left" />
           
       </asp:TemplateField> 
       
       <asp:TemplateField HeaderText="Id"  Visible="false">
       
       <ItemTemplate>
           <asp:Label ID="lblProId" runat="server" Text='<%#Eval("Id1") %>'></asp:Label>  
           <asp:Label ID="lblProDMid" runat="server" Text='<%#Eval("Did1") %>'></asp:Label> 
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>        
       </Columns>
       
      </asp:GridView>  </asp:Panel>
                       <%-- </ContentTemplate>
                        </asp:UpdatePanel>   
                       --%>
    
      
      </td>
                    </tr>
                    
                    
                    

                    <tr>
                    <td width="35%" valign="top">
                    
                        <asp:Label ID="lblFinish" runat="server" style="font-weight: 700" 
                            Text="Finish [F]" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    
                    
                    

                    <tr>
                    <td width="35%" align="center" valign="top"> <%--<asp:UpdatePanel ID="UpdatePanel3"  runat="server">
                        <ContentTemplate>--%>
                       <asp:Panel ID="Panel4" Height="100px" HorizontalAlign="Center"  Width="98%"  ScrollBars="Auto"  runat="server">    
                                                
                       <asp:GridView ID="GridView5" runat="server" OnRowCommand="GridView5_RowCommand"  AllowPaging="false" 
                    CssClass="yui-datatable-theme" Width="100%"  
             AutoGenerateColumns="False">           
            
   <Columns>
         <asp:TemplateField>
    
    <HeaderTemplate>
    <asp:CheckBox ID="CheckBox3"  AutoPostBack="true"   runat="server" 
                oncheckedchanged="CheckBox3_CheckedChanged" /> 
    </HeaderTemplate>
       
           <ItemTemplate>
               <asp:ImageButton ID="ImageButton3" CommandName="FinDelete" ImageUrl="~/images/cross.gif"  runat="server" />              
              
           </ItemTemplate>           
           <ItemStyle HorizontalAlign="left"  />
           <HeaderStyle HorizontalAlign="left"  />
    </asp:TemplateField> 
        
   
       <asp:TemplateField HeaderText="Supplier">
       <ItemTemplate>     
       <asp:TextBox ID="txtSupplierFin" Width="110px" Text='<%#Eval("Column111") %>'  runat="server" EnableViewState="true" 
                                                    CssClass="box3" />                                                     
                                                                                            
      <cc1:AutoCompleteExtender ID="AutoCompleteExtenderFin" TargetControlID="txtSupplierFin" runat="server" ServicePath=""    ServiceMethod="GetCompletionList" 
                                 CompletionInterval="100"
                                 EnableCaching="true"
                                 CompletionSetCount="2"                                  
                                 MinimumPrefixLength="1"
                                 UseContextKey="True"
                                 Enabled="True"                                
                                 FirstRowSelected="True"                                 
                                 ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt2">
                                                    </cc1:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator ID="ReqSupplierFin" runat="server" 
                                                    ControlToValidate="txtSupplierFin" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>  
                       </ItemTemplate>
       
            <ItemStyle HorizontalAlign="Left" />
       </asp:TemplateField>
        
       <asp:TemplateField HeaderText="Qty">       
       <ItemTemplate>
           <asp:TextBox ID="txtQtyFin" CssClass="box3" Width="50px"  Text='<%#Eval("Column211") %>' runat="server"></asp:TextBox>       
         <asp:RequiredFieldValidator ID="ReqFinQty" runat="server" ControlToValidate="txtQtyFin" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
            <ItemStyle HorizontalAlign="left"  />
       </asp:TemplateField> 
       
       <asp:TemplateField HeaderText="Rate">
       
       <ItemTemplate>
        <asp:TextBox ID="txtFinRate" Width="50px" Text='<%#Eval("Column311") %>'  runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="ReqFinRate" runat="server" ControlToValidate="txtFinRate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
          <ItemStyle HorizontalAlign="left"  />
       </asp:TemplateField> 
      
       <asp:TemplateField HeaderText="Discount">
       
       <ItemTemplate>
        <asp:TextBox ID="TxtFinDiscount" Width="40px" Text='<%#Eval("Column511") %>' runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="Reqfindiscount" runat="server" ControlToValidate="TxtFinDiscount" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>  
      
       <asp:TemplateField HeaderText="Deliv.Date">       
       <ItemTemplate>   
       
       <asp:TextBox ID="txtFinDeliDate" Width="70px"  Text='<%#Eval("Column411") %>' runat="server" 
                                                    CssClass="box3"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtenderFin"  Format="dd-MM-yyyy"   PopupPosition="BottomRight" CssClass="cal_Theme1" Animated="True"  TargetControlID="txtFinDeliDate" runat="server"></cc1:CalendarExtender> 
                                                <asp:RequiredFieldValidator ID="ReqFinDeliDate" runat="server" 
                                                    ControlToValidate="txtFinDeliDate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegFinDeliDate" runat="server" 
                    ControlToValidate="txtFinDeliDate" ErrorMessage="*" 
                                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                    ValidationGroup="azx"></asp:RegularExpressionValidator>
                                                
       </ItemTemplate>
            <ItemStyle HorizontalAlign="left"   />
       </asp:TemplateField> 
       
       <asp:TemplateField HeaderText="Id"  Visible="false">
       
       <ItemTemplate>
           <asp:Label ID="lblFinId" runat="server" Text='<%#Eval("Id11") %>'></asp:Label>  
           <asp:Label ID="lblFinDMid" runat="server" Text='<%#Eval("Did11") %>'></asp:Label> 
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>        
       </Columns>
      
       </asp:GridView>  
       </asp:Panel>
       <%-- </ContentTemplate>
                        </asp:UpdatePanel>
       --%>
      
       </td>
                    </tr>
                    
                    
                    

                    <tr>
                    <td width="35%" align="center" class="style2">
                    
                    
                    
                        
                           &nbsp;</td>
                    </tr>

                    
                    

<tr>
<td align="center" height="30px" valign="middle">            
                <asp:Button ID="RadButton1" Text="Generate PLN"  runat="server" 
                    onclick="RadButton1_Click" CssClass="redbox" Skin="Default"/> 
&nbsp;
                 <asp:Button ID="RadButton2" CssClass="redbox"   Text="Cancel"  runat="server" 
                    onclick="RadButton2_Click" Skin="Default"/>
</td>
<td align="center" height="30px" valign="middle">            
                    
                    
                    
                        
                           &nbsp;&nbsp;            
                    
                    
                    
                        
                           <asp:Button ID="BtnAddTemp" runat="server" Text="Add" CssClass="redbox" 
 onclick="BtnAddTemp_Click" Visible="False" />
       
</td>
</tr>
            
 </table>
<%--</ContentTemplate>
</asp:UpdatePanel>
</div>--%>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

