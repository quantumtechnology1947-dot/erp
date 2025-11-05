<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manufacturing_Design_Vendor_New_Details.aspx.cs" Inherits="Module_MaterialManagement_Transactions_PR_New_Detail" Title="ERP" Theme ="Default"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite" >
                        <strong>Design Report No.:</strong>
                       <asp:Label runat="server" ID="lblreport"></asp:Label>
                       <strong>Vendor Plan: </strong>
                       <asp:Label runat="server" ID="lblreport1"></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;<strong>Design Report Date:</strong>
                       <asp:Label runat="server" ID="lblreportdate"></asp:Label>
                        <strong>Vendor Date</strong>
                        <asp:Label runat="server" ID="lblreportdate1"></asp:Label>
                        &nbsp;&nbsp;&nbsp;<strong>WONo:</strong>
                        <asp:Label ID="lblWono" runat="server" Text=""></asp:Label>
                       
                        </td>
                    </tr>   
              </table>             
  <telerik:RadSkinManager ID="QsfSkinManager" runat="server" Skin="Office2007" ShowChooser="false" />

                
        <telerik:RadGrid ID="RadGrid1" runat="server"   
        AutoGenerateColumns="false" 
            AllowSorting="false" AllowPaging="false"   ShowFooter="false" 
        Width="100%"    Skin="Office2007">
            
            
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
   
   
   <telerik:GridTemplateColumn HeaderText="Select">
    <ItemTemplate>
         <asp:CheckBox ID="chkitems"  runat="server"
        AutoPostBack="true" OnCheckedChanged="Selected_chk_Changed"  />
    </ItemTemplate>
   <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="20px" ></ItemStyle>       
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
        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="120px" VerticalAlign="Top"   />
             <HeaderStyle HorizontalAlign="center" Width="120px"  />
        </telerik:GridTemplateColumn>
        <telerik:GridTemplateColumn HeaderText="UOM" >
        <ItemTemplate>
        <asp:Label ID="lbluombasic" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="30px"  />
            <HeaderStyle HorizontalAlign="center" Width="30px"   />
        </telerik:GridTemplateColumn>
        
        <telerik:GridTemplateColumn HeaderText="BOM Qty">
        <ItemTemplate>
        <asp:Label ID="lblbomqty" runat="server" Text='<%#Eval("BOMQ") %>'></asp:Label>
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Left"  VerticalAlign="Top" Width="10px"   />
            <HeaderStyle HorizontalAlign="center" Width="15px"   />
        </telerik:GridTemplateColumn>
        
         <telerik:GridTemplateColumn HeaderText="Design">
        <ItemTemplate>
        
        <asp:Label ID="txtdesign" runat="server"  Text='<%#Eval("Design") %>' ></asp:Label>
      
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        
        
        <telerik:GridTemplateColumn HeaderText="Plan Date" Visible="True">
        <ItemTemplate>
        <asp:TextBox ID="txtven1" runat="server" Enabled="false" ></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtenderFin"  Format="dd-MM-yyyy"
          PopupPosition="BottomRight" CssClass="cal_Theme1"
           Animated="True"  TargetControlID="txtven1" runat="server"></cc1:CalendarExtender> 

       
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        
         <telerik:GridTemplateColumn HeaderText="Actual Date" Visible="True">
        <ItemTemplate>
        <asp:TextBox ID="txtven2" runat="server" Enabled="false" ></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtenderFin1"  Format="dd-MM-yyyy"
          PopupPosition="BottomRight" CssClass="cal_Theme1"
           Animated="True"  TargetControlID="txtven2" runat="server"></cc1:CalendarExtender> 

        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        
         <telerik:GridTemplateColumn HeaderText="Remark" Visible="False">
        <ItemTemplate>
        <asp:TextBox ID="txtremark" runat="server" ></asp:TextBox>
        </ItemTemplate>
           <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="40px"   />
            <HeaderStyle HorizontalAlign="center" Width="40px"   />
        </telerik:GridTemplateColumn>
        
       
   </Columns>
            </MasterTableView>
            
            <HeaderStyle  HorizontalAlign="Center" Wrap="true"></HeaderStyle>
            <PagerStyle   Mode="NextPrevAndNumeric"></PagerStyle>          
         
        </telerik:RadGrid>         
 </div>
                        
     <table align="left" cellpadding="0" cellspacing="0" width="100%">
    
    <tr>
    
    <td align="center" style="height:25px" valign="middle">
     
                     <asp:Button ID="Button1" CssClass="redbox"   Text="Add"  runat="server" 
                    onclick="RadButton2_Click_Cancel" Skin="Default"/>
    
    
    </td>
    </tr>
    
    <tr>
            <td align="center" style="height:25px" valign="middle" >
            
                <asp:Button ID="RadButton1" Text="Generate Report"  runat="server" 
                    onclick="RadButton1_Click" CssClass="redbox" Skin="Default"/> &nbsp;&nbsp;
                 <asp:Button ID="RadButton2" CssClass="redbox"   Text="Cancel"  runat="server" 
                    onclick="RadButton2_Click" Skin="Default"/>
                    
                   
            </td>
            
          
        </tr> 
        </table>  
 
     
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

