<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PR_New_Details1.aspx.cs" Inherits="Module_MaterialManagement_Transactions_PR_New_Detail" Title="ERP" Theme ="Default"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ OutputCache Duration="1000" VaryByParam="*" VaryByHeader="*" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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
   

                 
<div style="width:99.9%; height:auto; position:relative; margin:0px 0px 0px 0px; top: 0px; left: 0px;" >
                         
             <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr >                   
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >&nbsp;<strong>PR - New</strong>&nbsp;&nbsp;&nbsp;<strong>WONo:</strong><asp:Label ID="lblWono" runat="server" Text=""></asp:Label>
                       
                        </td>
                    </tr>   
              </table>             
  <telerik:RadSkinManager ID="QsfSkinManager" runat="server" Skin="Office2007" ShowChooser="false" />

                
        <telerik:RadGrid ID="RadGrid1" runat="server"   
        OnItemCommand="RadGrid1_ItemCommand"  AutoGenerateColumns="false" 
            AllowSorting="false" AllowPaging="false"   ShowFooter="false" 
        Width="100%"   OnColumnCreated="RadGrid1_ColumnCreated" Skin="Office2007">
            
            
            <ClientSettings>
                <Scrolling AllowScroll="True"  ScrollHeight="380px"    UseStaticHeaders="true"   SaveScrollPosition="true" FrozenColumnsCount="9">
                </Scrolling>                
              
            </ClientSettings> 
        


            <MasterTableView  TableLayout="Auto"   GridLines="Both" >            
            
<CommandItemSettings   ExportToPdfText="Export to Pdf"></CommandItemSettings>
            
             <Columns >
   <telerik:GridTemplateColumn HeaderText="SN"><ItemTemplate><%# Container.ItemIndex+1 %></ItemTemplate><HeaderStyle Font-Size="9pt" />
       <ItemStyle HorizontalAlign="right" VerticalAlign="Top" Width="25px" ></ItemStyle>       
       <HeaderStyle HorizontalAlign="center" Width="25px"  />
       </telerik:GridTemplateColumn> 
   
       <telerik:GridTemplateColumn HeaderText="Item Code">
        <ItemTemplate>
        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
        </ItemTemplate>
          <ItemStyle HorizontalAlign="center" VerticalAlign="Top"  Width="85px"   ></ItemStyle>       
       <HeaderStyle HorizontalAlign="center" Width="60px"  />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Description">
        <ItemTemplate>
        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="120px" VerticalAlign="Top"   />
             <HeaderStyle HorizontalAlign="center" Width="120px"  />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="UOM" >
        <ItemTemplate>
        <asp:Label ID="lbluombasic" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px"  />
            <HeaderStyle HorizontalAlign="center" Width="30px"   />
        </telerik:GridTemplateColumn>
        
        <telerik:GridTemplateColumn HeaderText="BOM Qty">
        <ItemTemplate>
        <asp:Label ID="lblbomqty" runat="server" Text='<%#Eval("BOMQty") %>'></asp:Label>
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="PR Qty">
        <ItemTemplate>
        <asp:Label ID="lblprqty" runat="server" Text='<%#Eval("PRQty") %>'></asp:Label>
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="WIS Qty">
        <ItemTemplate>
        <asp:Label ID="lblwisqty" runat="server" Text='<%#Eval("WISQty") %>'></asp:Label>
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="GQN Qty">
        <ItemTemplate>
        <asp:Label ID="lblgqnqty" runat="server" Text='<%#Eval("GQNQty") %>'></asp:Label>
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="45px"   />
            <HeaderStyle HorizontalAlign="center" Width="45px"   />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Draw/ img">
        <ItemTemplate>
         <asp:LinkButton ID="lnkbtnImg" Text='<%#Eval("FileName") %>' CommandName="viewImg" runat="server"></asp:LinkButton>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="center" VerticalAlign="Top" Width="35px"    />
            <HeaderStyle HorizontalAlign="center"  Width="35px" />
        </telerik:GridTemplateColumn>
       <telerik:GridTemplateColumn HeaderText="Spec.">
       <ItemTemplate>
         <asp:LinkButton ID="lnkbtnSpec" Text='<%#Eval("AttName") %>' CommandName="viewSpec" runat="server"></asp:LinkButton>
        </ItemTemplate>
          <ItemStyle HorizontalAlign="center"  VerticalAlign="Top" Width="35px"   />
            <HeaderStyle HorizontalAlign="center"  Width="35px" />
       </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="Item Id" Visible="false">
        <ItemTemplate>
        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'></asp:Label>
        </ItemTemplate>
        </telerik:GridTemplateColumn>
       <telerik:GridTemplateColumn HeaderText="" Visible="true">
        <ItemTemplate>
            <%--<asp:Button ID="AddTemp"  CommandName="TempAdd" Text="Add" Width="30px" CssClass="redbox"  runat="server" >
            </asp:Button>   --%> 
            
            <asp:LinkButton  ID="AddTemp"  CommandName="TempAdd" Text="Add" Width="30px"   runat="server"></asp:LinkButton>       
        </ItemTemplate>
        <ItemStyle HorizontalAlign="center" VerticalAlign="Top"  Width="35px"   />
            <HeaderStyle HorizontalAlign="center"  Width="30px" />
        </telerik:GridTemplateColumn>      
   
       
       <telerik:GridTemplateColumn HeaderText=" ">
           <ItemTemplate> 
                      
       <asp:GridView ID="GridView5" runat="server" OnRowCommand="GridView5_RowCommand"  AllowPaging="True" PageSize="17" 
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
           <asp:TextBox ID="txtQtyFin" CssClass="box3" Width="45px"  Text='<%#Eval("Column211") %>' runat="server"></asp:TextBox>       
         <asp:RequiredFieldValidator ID="ReqFinQty" runat="server" ControlToValidate="txtQtyFin" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
            <ItemStyle HorizontalAlign="left"  />
       </asp:TemplateField> 
   <asp:TemplateField HeaderText="Rate">
       
       <ItemTemplate>
        <asp:TextBox ID="txtFinRate" Width="45px" Text='<%#Eval("Column311") %>'  runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="ReqFinRate" runat="server" ControlToValidate="txtFinRate" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
          <ItemStyle HorizontalAlign="left"  />
       </asp:TemplateField>
      
      
      
      <asp:TemplateField HeaderText="Discount">
       
       <ItemTemplate>
        <asp:TextBox ID="txtDiscount" Width="45px" Text='<%#Eval("Column511") %>'  runat="server" EnableViewState="true" 
                                                    CssClass="box3" /> 
         <asp:RequiredFieldValidator ID="Reqdisc" runat="server" ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="azx"></asp:RequiredFieldValidator>       
       </ItemTemplate>
          <ItemStyle HorizontalAlign="left"  />
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
           <asp:Label ID="lblFinDMid" runat="server" Text='<%#Eval("SessionId") %>'></asp:Label> 
       </ItemTemplate>
           <ItemStyle HorizontalAlign="left" />
       </asp:TemplateField>        
       </Columns>
      
       </asp:GridView>   
       
       </ItemTemplate>
        <ItemStyle HorizontalAlign="left" VerticalAlign="Top" width="275px"  /> 
        <HeaderStyle  HorizontalAlign="center" width="275px"  ></HeaderStyle>       
       </telerik:GridTemplateColumn>
       
        
       
   </Columns>
            </MasterTableView>
            
            <HeaderStyle  HorizontalAlign="Center" Wrap="true"></HeaderStyle>
            <PagerStyle   Mode="NextPrevAndNumeric"></PagerStyle>          
         
        </telerik:RadGrid>         
 </div>
                        
     <table align="left" cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td align="center" style="height:25px" valign="middle" >
            
                <asp:Button ID="RadButton1" Text="Generate PR"  runat="server" 
                    onclick="RadButton1_Click" CssClass="redbox" Skin="Default"/> &nbsp;&nbsp;
                 <asp:Button ID="RadButton2" CssClass="redbox"   Text="Cancel"  runat="server" 
                    onclick="RadButton2_Click" Skin="Default"/>
            </td>
            
          
        </tr> 
        </table>  
 
     
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

