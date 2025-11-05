<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Challanreport.aspx.cs" Inherits="Challanreport" %>

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
            width: 283px;
        }
        .style6
        {
            width: 84px;
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
       <table style="width: 934px">
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
    &nbsp;<small>GST No - 27AAHCS9857M1ZD</small>&nbsp;
            </td>
            <td class="style6"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</td>
                <td > 
                    &nbsp;</td>
            <td align="right">
           <table >
            <tr align="right">
            <td >
                <asp:Label runat="server" ID="C" Text="CHALLAN COPY:- " Font-Bold="True"></asp:Label>
            &nbsp; </td>
                <td align="lEFT">
                
            <br />
              ORIGINAL<br />
              
               ACKNOLEDGMENT
               <br />
                                        STORE COPY
                <br />
                    EXTRA COPY
                 <br />
                GATE COPY
                </td>
               
            </tr>
           </table>
            </td>
        </tr>
       </table>
    <center> <asp:Label runat="server" ID="dclabel" Text="DELIVERY CHALLAN" 
            Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label> </center> 
   <br />

        
    </div>
            &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="False" 
        Text="Challan Type"></asp:Label>
    &nbsp;:&nbsp;
    <asp:Label ID="LabelType" runat="server" Text="Label"  Font-Bold="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="DC No." Font-Bold="True" 
        Font-Size="Large"></asp:Label>
&nbsp;:&nbsp;<asp:Label ID="Labeldc" runat="server" Text="Label" Font-Bold="True" 
        Font-Size="Large"></asp:Label> &nbsp;&nbsp;&nbsp;<asp:Label 
        ID="Label4" runat="server" Text="DC Date" Font-Bold="True" 
        Font-Size="Large"  ></asp:Label>
&nbsp;: <asp:Label ID="Labeldate" runat="server" Text="Label" Font-Bold="True" 
        Font-Size="Large"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;
            <hr />
<%--            <div class = "vertical">
--%>&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="To"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; :&nbsp; <asp:Label ID="Labelto" runat="server" ></asp:Label>
              <br />
          &nbsp;  <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; :&nbsp; <asp:Label ID="Labelad" runat="server" ></asp:Label>
              <br />
             
           &nbsp; <asp:Label ID="Label7" runat="server" Text="GST No"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; <asp:Label ID="Labelgst" runat="server" ></asp:Label>
            
           
             &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="Kind Attention"></asp:Label>
    &nbsp; : &nbsp;<asp:Label ID="Labelkn" runat="server" ></asp:Label>
                        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Contact No"></asp:Label>
&nbsp;&nbsp; &nbsp;&nbsp; :&nbsp;<asp:Label ID="Labelcn" runat="server" ></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
 &nbsp;
    <br />
<hr />

 
    <asp:GridView ID="GridView2" runat="server" Width = "100%" AutoGenerateColumns="False" 
    DataSourceID="SqlDataSource1" style="margin-top: 0px" >
    <RowStyle HorizontalAlign="Center" />
        <Columns>
        <asp:TemplateField HeaderText="Sr No">
        <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
        </ItemTemplate>
    </asp:TemplateField>
    
    
            <%-- <asp:BoundField DataField="Bno" HeaderText="BOM No" SortExpression="Bno"/>
             <asp:BoundField DataField="CName" HeaderText="Customer Name" SortExpression="CName" />
             <asp:BoundField DataField="bomdate" HeaderText="BOM Date" SortExpression="bomdate" />
             <asp:BoundField DataField="MainCode" HeaderText="Product Code" SortExpression="MainCode" />
             <asp:BoundField DataField="Name" HeaderText="Product Name" SortExpression="Name" />
             <asp:BoundField DataField="Cdn" HeaderText="DRG No" SortExpression="Cdn" />--%>
<%--             <asp:BoundField DataField="No" HeaderText="Sr.No" HeaderStyle-BackColor="#f7f0f7" SortExpression="No" />
--%>          <asp:BoundField DataField="ItemCode" HeaderText="Item code" SortExpression="ItemCode" />
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
</asp:SqlDataSource>

<hr />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
        ID="Label10" runat="server" Text="Total Qty"></asp:Label>
&nbsp;:- &nbsp;<asp:Label ID="TQ" runat="server" ></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;Total Amount :- &nbsp;<asp:Label ID="Tot" runat="server"></asp:Label>
    <hr />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GST&nbsp; &nbsp;:&nbsp;<asp:Label ID="GST" runat="server" Visible="false" ></asp:Label> 
    &nbsp;<asp:Label ID="GST0" runat="server" ></asp:Label> 
    &nbsp;&nbsp;&nbsp; &nbsp;GST Amount&nbsp; :&nbsp;<asp:Label ID="LabelGT" runat="server"></asp:Label>
    
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
   <asp:Label runat="server" ID="GRAND" Text=" Grand Total :" Font-Bold="True"></asp:Label>
    <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="True"></asp:Label>
    <br />
    
<hr />
            
            &nbsp;&nbsp; Remark &nbsp; :&nbsp;<asp:Label ID="Labelrm" runat="server" Text="Label"></asp:Label>
           <hr />
          
            &nbsp;&nbsp;&nbsp;Transport Name  &nbsp;:&nbsp;<asp:Label ID="Labeltn" runat="server" ></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vehicle No  :- <asp:Label ID="Labelvn" runat="server" Text="Label"></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;L.R. No  :- <asp:Label ID="Labelln" runat="server" Text="Label"></asp:Label>

            <hr />
            
         
             
    &nbsp;&nbsp;&nbsp;&nbsp;Responsible by&nbsp;:&nbsp;<asp:Label ID="Labelres" runat="server" ></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; For Synergytech Automation Pvt. Ltd. 
            <br />
            &nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;&nbsp;
            <br />
           
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Requested by  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Checked by &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Authorised by         <asp:Label ID="Label1" runat="server" Text="Label" Visible=false></asp:Label>
        <br />
   
    <br /><br />
    <br />&nbsp;&nbsp;&nbsp;Acknowledgement &nbsp;  :&nbsp; 
    <asp:Label ID="Labelack" runat="server" 
        Text="Received material in good condition" Font-Bold="True"></asp:Label>
           
           <br />
           <br />
           <br />
           
           
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    </form>
</body>
</html>
