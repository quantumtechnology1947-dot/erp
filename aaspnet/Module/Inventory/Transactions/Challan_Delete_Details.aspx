<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Challan_Delete_Details.aspx.cs" Inherits="Challanreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delivery Challan</title>
    <style> 
        form
        {
        	border: 1px solid black;
            height: 1020px;
        }
        .style4
        {
            height: 177px;
        }
        </style> 
<%-- <style type="text/css" media="print">
@page {
      
    margin: 0;  /* this affects the margin in the printer settings */
}
</style>--%>
</head>
<body>
    <form id="form1" runat="server" style="font-weight: normal">
    <%--<div>--%>
    <%--<div id="img1" style="width: 178px; height: 94px;" >--%>
       <table>
        <tr>
            <td>
                 <asp:Image ID="Image1"  Height="77px" Width="123px" 
        ImageUrl="~/images/logo.jpg" runat="server" style="margin-top:1%"/>
            </td>
            <td></td>
             <td class="style4">
            &nbsp;<small><b style="font-family:Times New Roman; font-style:normal">SYNERGYTECH AUTOMATION PVT.LTD.</b></small><br />
    &nbsp;<small>Gat No.205,Kasurdi (Khed Shivapur),</small> &nbsp;&nbsp;<br />
                <small>&nbsp;Off Pune Satara Road , Tal.Bhor , Dist. Pune -412205</small>&nbsp;<br />
&nbsp;<small>Tel No. - 9881147037</small><br />
&nbsp;<small>Email -&quot;sales@synergytechs.com&quot;</small><br />
    &nbsp;<small>GST No - 27AAHCS9857M1ZD</small>
            </td>
            
        </tr>
       </table>
    <center> <u> <b>DELIVERY CHALLAN</b></u></center> 
   <br />

        
    </div>
            &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="False" 
        Text="Challan Type"></asp:Label>
    &nbsp;:&nbsp;
    <asp:Label ID="LabelType" runat="server" Text="Label" Font-Bold="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="DC No."></asp:Label>
&nbsp;:&nbsp;<asp:Label ID="Labeldc" runat="server" Text="Label"></asp:Label> &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Text="DC Date"></asp:Label>
&nbsp;: <asp:Label ID="Labeldate" runat="server" Text="Label"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;
            <hr />
<%--            <div class = "vertical">
--%>&nbsp;<asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; :&nbsp; <asp:Label ID="Labelto" runat="server" ></asp:Label>
              <br />
            <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; :&nbsp; <asp:Label ID="Labelad" runat="server" ></asp:Label>
              <br />
             
            <asp:Label ID="Label7" runat="server" Text="GST No"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; <asp:Label ID="Labelgst" runat="server" ></asp:Label>
            
           
             &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<br />
    &nbsp;<asp:Label ID="Label8" runat="server" Text="Kind Attention"></asp:Label>
    &nbsp; : &nbsp;<asp:Label ID="Labelkn" runat="server" ></asp:Label>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;<asp:Label ID="Label9" runat="server" Text="Contact No"></asp:Label>
&nbsp;&nbsp; &nbsp;&nbsp; :&nbsp;<asp:Label ID="Labelcn" runat="server" ></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
 &nbsp;
    <br />
<hr />

 
    <%--<asp:GridView ID="GridView2" runat="server" Width = "100%" AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1" style="margin-top: 0px" >
    <RowStyle HorizontalAlign="Center" />
        <Columns>
        <asp:TemplateField HeaderText="Sr No">
        <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
        </ItemTemplate>
    </asp:TemplateField>
    --%>
    
            <%-- <asp:BoundField DataField="Bno" HeaderText="BOM No" SortExpression="Bno"/>
             <asp:BoundField DataField="CName" HeaderText="Customer Name" SortExpression="CName" />
             <asp:BoundField DataField="bomdate" HeaderText="BOM Date" SortExpression="bomdate" />
             <asp:BoundField DataField="MainCode" HeaderText="Product Code" SortExpression="MainCode" />
             <asp:BoundField DataField="Name" HeaderText="Product Name" SortExpression="Name" />
             <asp:BoundField DataField="Cdn" HeaderText="DRG No" SortExpression="Cdn" />--%>
<%--             <asp:BoundField DataField="No" HeaderText="Sr.No" HeaderStyle-BackColor="#f7f0f7" SortExpression="No" />
--%>        <%--  <asp:BoundField DataField="ItemCode" HeaderText="Item code" SortExpression="ItemCode" />
             <asp:BoundField DataField="Description" HeaderText=" Description" SortExpression="Description" />
          <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM" />   
             <asp:BoundField DataField="HSN" HeaderText="HSN" SortExpression="HSN" />
             <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
             <asp:BoundField DataField="Rate" HeaderText="RATE" SortExpression="Rate" />
             <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"  />
        

        </Columns>
    </asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
    SelectCommand="SELECT [ItemCode],[Description],[HSN],[Quantity] ,[Rate],[Amount],[UOM] FROM [Challan] WHERE ([DCNo] = @DCNo)">
    <SelectParameters>
        <asp:QueryStringParameter Name="DCNo" QueryStringField="DCNo" 
            Type="String" />
    </SelectParameters>
</asp:SqlDataSource>--%>

         <asp:GridView ID="GridView12" runat="server" AutoGenerateColumns="False" Width="100%" Height="10%"  
        BorderStyle="Double" BorderColor ="Red"  BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames = "DCNo,ItemCode"   >
       
 <Columns>
 
<asp:CommandField  ButtonType="Link"   ShowDeleteButton="True"  />
 <asp:BoundField DataField="DCNo" HeaderText="Code"  HeaderStyle-BackColor="#f7f0f7" SortExpression="DCNo" Visible =false  />

   <asp:BoundField DataField="ItemCode" HeaderText="Item Code"  HeaderStyle-BackColor="#f7f0f7" SortExpression="ItemCode" />
   <asp:BoundField DataField="Description" HeaderText="Description"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Description" />
     <asp:BoundField DataField="HSN" HeaderText="HSN No"  HeaderStyle-BackColor="#f7f0f7" SortExpression="HSN" />
   <asp:BoundField DataField="Quantity" HeaderText="Quantity"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Quantity" />
   <asp:BoundField DataField="Rate" HeaderText="Rate"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Rate" />
   <asp:BoundField DataField="Amount" HeaderText="Amount"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Amount" />

  </Columns>
</asp:GridView>



<hr />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
        ID="Label10" runat="server" Text="Total Qty"></asp:Label>
&nbsp;:- &nbsp;<asp:Label ID="TQ" runat="server" ></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Total :- &nbsp;<asp:Label ID="Tot" runat="server"></asp:Label>
    <hr />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GST&nbsp; &nbsp;:&nbsp;<asp:Label ID="GST" runat="server" ></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grand Total&nbsp; :&nbsp;<asp:Label ID="LabelGT" runat="server"></asp:Label>
    
<hr />
            
            &nbsp;&nbsp; Remark &nbsp; :&nbsp;<asp:Label ID="Labelrm" runat="server" Text="Label"></asp:Label>
           <hr />
          
            &nbsp;&nbsp;&nbsp;Transport Name  &nbsp;:&nbsp;<asp:Label ID="Labeltn" runat="server" ></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vehicle No  :- <asp:Label ID="Labelvn" runat="server" Text="Label"></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L.R. No  :- <asp:Label ID="Labelln" runat="server" Text="Label"></asp:Label>

            <hr />
            
         
             
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For Synergytech Automation Pvt. Ltd. 
            <br />
            &nbsp;&nbsp;&nbsp;Responsible by&nbsp;:&nbsp;<asp:Label ID="Labelres" runat="server" ></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;
    <br />
&nbsp;&nbsp; Requested by  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Checked by &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Authorised by         <asp:Label ID="Label1" runat="server" Text="Label" Visible=false></asp:Label>
        <br /><br />&nbsp;&nbsp;&nbsp;Acknowledgement &nbsp;  :&nbsp; 
    <asp:Label ID="Labelack" runat="server" 
        Text="Received material in good condition" Font-Bold="True"></asp:Label>
           
<%--    </div>
--%>    
    <br />
    <br />
    <br />
    <br />
    <div style="margin-Center: 320px; margin-left: 320px;">
        <asp:Button ID="Button1" runat="server" BackColor="Red" ForeColor="White" 
            onclick="Cancel_Click" Text="Cancel" ToolTip="Cancel" Width="95px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BackColor="Red" ForeColor="White" 
            onclick="DELETE_Click" Text="DELETE ALL" ToolTip="Cancel" Width="95px" />
        <br />
    </div>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    </form>
</body>
</html>
