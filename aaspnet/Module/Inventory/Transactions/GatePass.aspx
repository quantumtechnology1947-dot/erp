<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass.aspx.cs" Inherits="GatePass" Title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
     <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular.min.js"></script>
      <script type="text/javascript" src="/fusioncharts/fusioncharts.js"></script>
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

<asp:Table runat="server" ID="jj" Width="100%" Height="25">
<asp:TableRow  runat="server" ID="tr" Width="100%" BackColor="gray">
<asp:TableCell>
<asp:Label runat="server" ID="lls" Text="RETURNABLE GATE PASS" Width="100%" ForeColor="white" Font-Bold="true" Font-Size="Larger"></asp:Label>
</asp:TableCell>
</asp:TableRow>
</asp:Table>


<br />

<asp:Table runat="server" ID="fff" Width="20%">

<asp:TableRow>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/View.png" ID="uij"  Width="18" Height="18" OnClick="Image2" />
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/new.png.png" ID="ImageButton2" Width="15" Height="15" OnClick="Image1" />
</asp:TableCell>


<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/edit.png" ID="ImageButton1" Width="20" Height="20" OnClick="Image3" />
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server" img src="../../../images/delete.jpg" ID="ImageButton3" Width="13" Height="13" OnClick="Image4" />
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:ImageButton runat="server"   img src="../../../images/Print_PNG.jpg" ID="ImageButton4" Width="23px" Height="20" OnClick="Image5" />
</asp:TableCell>

</asp:TableRow>

<asp:TableRow>

<asp:TableCell HorizontalAlign="center">

<asp:Label ID="Label4" runat="server" Text="View"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">

<asp:Label ID="Label1" runat="server" Text="New"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:Label ID="Label3" runat="server" Text="Edit"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:Label ID="Label2" runat="server" Text="Delete"></asp:Label>
</asp:TableCell>

<asp:TableCell HorizontalAlign="center">
<asp:Label ID="Label19" runat="server" Text="Print"></asp:Label>
</asp:TableCell>

</asp:TableRow>
</asp:Table>


<br />
  <asp:Table runat="server" ID="kkkk" Width="100%">
  <asp:TableRow runat="server">
  <asp:TableCell>

 <asp:GridView ID="GridView1" CssClass = "Grid" runat="server" Width="100%"  AutoGenerateColumns="false" OnRowDataBound = "OnRowDataBound">
   
  <Columns>
  
    <asp:TemplateField HeaderText="CHALLAN NO." HeaderStyle-Height="10px" HeaderStyle-BackColor="#E0E0E0">
          <ItemTemplate>
               <%# Container.DataItemIndex+1 %>
          </ItemTemplate>
         <ItemStyle HorizontalAlign="Right" />
     </asp:TemplateField>
     
         <asp:BoundField DataField="Date" HeaderText="DATE" HeaderStyle-BackColor="#E0E0E0"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Height="30"/>
         <asp:BoundField DataField="WoNo" HeaderText="WONO" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Des_Name" HeaderText="SUPPLIER/CUSTOMER" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="AthoriseBy" HeaderText="SUPPLIER/CUSTOMER NAME" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="CodeNo" HeaderText="CODE NO." HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Description" HeaderText="DECRIPTION" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Unit" HeaderText="UNIT" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Gatepass" HeaderText="RETURNABLE_GATEPASS" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Total_qty" HeaderText="TOTAL QTY" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="IssueTo" HeaderText="CHECKBY" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Rec_Date" HeaderText="DATE OF sRECEIPT" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Qty_Recd" HeaderText="QTY RECD." HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Qty_pend" HeaderText="QTY. PENDING." HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="RecdBy" HeaderText="RECD.BY." HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
         <asp:BoundField DataField="Remark" HeaderText="REMARK" HeaderStyle-BackColor="#E0E0E0" ItemStyle-HorizontalAlign="Center"/>
      
        <asp:TemplateField HeaderText="STATUS" HeaderStyle-BackColor="#E0E0E0">
        <ItemTemplate >
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
         
  </Columns>
    
      <EmptyDataTemplate>
               <table class="fontcss" width="100%">
                     <tr>
                        <td align="center">
                            <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                    Text="No data to display !"> </asp:Label>
                         </td>
                     </tr>
             </table>
    </EmptyDataTemplate>
    
</asp:GridView>
     
 </asp:TableCell>
 </asp:TableRow>
</asp:Table>

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

