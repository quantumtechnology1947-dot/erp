<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vehical_Info_Print_Details.aspx.cs" Inherits="Challanreport" %>

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
        .style7
        {
            width: 150px;
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
            <td class="style7">
                 <asp:Image ID="Image1"  Height="93px" Width="141px" 
        ImageUrl="~/images/logo.jpg" runat="server" style="margin-top:1%"/>
            &nbsp;</td>
             <td class="style4">
            &nbsp;<small><b style="font-family:Times New Roman; font-style:normal">SYNERGYTECH AUTOMATION PVT.LTD.</b></small><br />
    &nbsp;<small>Gat No.205,Kasurdi (Khed Shivapur),</small> &nbsp;&nbsp;<br />
                <small>&nbsp;Off Pune Satara Road , Tal-Bhor ,&nbsp;
                 <br />
&nbsp;Dist- Pune -412205</small>&nbsp;<br />
&nbsp;<small>Tel No. - 9881147037</small><br />
&nbsp;<small>Email -&quot;sales@synergytechs.com&quot;</small><br />
    &nbsp;<small>GST No - 27AAHCS9857M1ZD</small>&nbsp;
            </td>
            <td class="style6"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                &nbsp;</td>
                <td > 
                    &nbsp;</td>
            <td align="right">
          
            </td>
        </tr>
       </table>
    <center> 
        <asp:Label runat="server" ID="dclabel" Text="VEHICLE INFORMATION" 
            Font-Bold="True" Font-Size="XX-Large" Font-Underline="True"></asp:Label> </center> 
   <br />

        
    </div>
            
    &nbsp;<asp:Label ID="Label10" runat="server" Text="VEHICLE " Font-Bold="True" 
        Font-Size="Large"></asp:Label>
    &nbsp;:&nbsp;
    <asp:Label ID="LabelType" runat="server" Text="Label"  Font-Bold="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Reg  No." Font-Bold="True" 
        Font-Size="Large"></asp:Label>
    &nbsp;<asp:Label ID="Labeldc" runat="server" Text="Label" Font-Bold="True" 
        Font-Size="Large"></asp:Label> &nbsp; &nbsp;&nbsp;<asp:Label 
        ID="Label4" runat="server" Text="Date" Font-Bold="True" 
        Font-Size="Large"  ></asp:Label>
&nbsp;:<asp:Label ID="Labeldate" runat="server" Text="Label" Font-Bold="True" 
        Font-Size="Large"></asp:Label> 
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
&nbsp;<%--            <div class = "vertical">
--%>&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="SUPPLIER NAME"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; :&nbsp; <asp:Label ID="Labelto" runat="server" ></asp:Label>
              <br />
              <br />
          &nbsp;  <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; :&nbsp; <asp:Label ID="Labelad" runat="server" ></asp:Label>
              <br />
             
           &nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            
           
             &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Contact No"></asp:Label>
&nbsp;:&nbsp; <asp:Label ID="Labelcn" runat="server" ></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
 &nbsp;
        
<hr style="height: -12px; margin-top: 0px" />
            
            &nbsp;&nbsp; MATERIAL&nbsp; :&nbsp;<asp:Label ID="Labelrm" runat="server" Text="Label"></asp:Label>
           <hr />
          
            &nbsp;&nbsp;&nbsp;FROM KM  &nbsp;:&nbsp;<asp:Label ID="Labeltn" runat="server" ></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TO 
    KM  :- <asp:Label ID="Labelvn" runat="server" Text="Label"></asp:Label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;TOTAL KM  :- <asp:Label ID="Labelln" runat="server" Text="Label"></asp:Label>

            <br />
    <br />
&nbsp;&nbsp; FUEL DATE :&nbsp; <asp:Label ID="labelfuelDate" runat="server" ></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FUEL RS. :
    <asp:Label ID="lblfrs" runat="server" ></asp:Label>
            &nbsp;

            <hr />
            
            <asp:Label ID="Label1" runat="server" Text="Label" Visible=false></asp:Label>
             
    &nbsp;&nbsp;&nbsp;&nbsp;EMPLOYEE&nbsp; NAME&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
        ID="labelemp" runat="server" Text="Label"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;</form>
</body>
</html>
