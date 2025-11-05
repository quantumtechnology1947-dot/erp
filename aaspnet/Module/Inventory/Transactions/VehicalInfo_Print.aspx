<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VehicalInfo_Print.aspx.cs" Inherits="ChallanInfo" Title="ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
 <table align="center" cellpadding="0" cellspacing="0" width="100%" >
    <tr height="21">
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Delivery Challan Info</b></td>
    </tr></table>
    <br /> <br />
   
    <br />
                                
<asp:GridView ID="GridView1" runat="server" DataKeyNames="VehNo" AllowPaging="True" PageSize="10000" 
         AutoGenerateColumns="False"  Width = "100%" DataSourceID="SqlDataSource1" onrowcommand="GridView1_RowCommand1">
            <Columns>
            
            
            
         <asp:BoundField DataField="VehNo" HeaderText="Registration No." SortExpression="DCNo" HeaderStyle-BackColor = "#BDBDBD"/>
         <asp:TemplateField HeaderText="Link" HeaderStyle-Font-Bold="true"   HeaderStyle-BackColor="red"  HeaderStyle-ForeColor="black" HeaderStyle-HorizontalAlign="Center">
  <EditItemTemplate>
  <asp:Label runat="server" ID="lbl14" Text='<%# Eval("VehNo") %>'></asp:Label>
  </EditItemTemplate>
   <ItemTemplate>
       <asp:LinkButton ID="View" runat="server" CommandName="View" CommandArgument='<%# Bind("VehNo") %>'>View</asp:LinkButton>
   </ItemTemplate>
            <HeaderStyle BackColor="#BDBDBD" Font-Bold="True" ForeColor="black" />
   <ItemStyle HorizontalAlign="Center"  ForeColor="Black" />
  </asp:TemplateField>
           <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" HeaderStyle-BackColor = "#BDBDBD"/>
         <asp:BoundField DataField="Date" HeaderText="Id" SortExpression="Id" HeaderStyle-BackColor = "#BDBDBD" Visible="false"/>
          <asp:BoundField DataField="Destination" HeaderText="Supplier Name" SortExpression="Destination" HeaderStyle-BackColor = "#BDBDBD"/>
         <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" HeaderStyle-BackColor = "#BDBDBD"/>
           </Columns>
             </asp:GridView>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>"
        SelectCommand="SELECT  Destination,Address,VehNo,Date,Id FROM tblVeh_Master_Details ORDER BY Id DESC  " >
         </asp:SqlDataSource>
         
   
   
   
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

