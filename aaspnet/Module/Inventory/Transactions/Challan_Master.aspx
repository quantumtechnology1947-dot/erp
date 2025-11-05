<%@ Page Title="ERP" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Challan_Master.aspx.cs" Inherits="Challan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 247px;
        }
    </style>
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
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Delivery Challan</b></td>
    </tr></table>
   
                <h3/>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                    <b><u style="font-size: large; text-decoration: underline; text-align: center;">Delivery Challan</u></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <table >
                    <tr align="center">
                        <td valign="middle">
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                <asp:Label ID="Label2" runat="server" Width="101px" Text="DC No." Font-Bold="False" 
                                  Font-Size="Larger" BorderStyle="None" ></asp:Label>
                <asp:Label ID="TextDCNO" runat="server" Width="99px" Font-Bold="True" Font-Size="Larger" 
                                  BorderStyle="None" Height="34px" ToolTip="DC No." Font-Underline="False" ></asp:Label>  
             <br />
                        </td>      
<td class="style2"></td>
    <td>
            
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label10" runat="server"  
                        Text="D.C Date " Font-Bold="False" ></asp:Label> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextDCDate" runat="server" Width="251px"></asp:TextBox>

               <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextDCDate" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
    </td>
                    </tr>
                </table><br />
                <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Challan Type"></asp:Label>
                &nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlType" runat="server" Height="26px" Width="251px">
              <asp:ListItem Text ="Select" Value =""></asp:ListItem>
              <asp:ListItem Text ="RETURNABLE" Value ="RETURNABLE"></asp:ListItem>
              <asp:ListItem Text ="NON-RETURNABLE" Value ="NON-RETURNABLE"></asp:ListItem>
       </asp:DropDownList>
                
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label13" runat="server"  Text="To" Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextTO" runat="server" 
                    ontextchanged="TextTO_TextChanged" AutoPostBack="true" Height="23px" 
                    Width="251px"></asp:TextBox>  

                    <asp:AutoCompleteExtender ServiceMethod="GetSearch" MinimumPrefixLength="1" CompletionInterval="10"  
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TextTO" ID="AutoCompleteExtender1"  
            runat="server" FirstRowSelected="false">  
        </asp:AutoCompleteExtender>  
 <br />
  <br />
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server"  Text="Address" Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="Textaddress" runat="server" TextMode ="MultiLine" 
                    Width="251px" Height="18px" ></asp:TextBox><br />
             <br />
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Label ID="Label12" runat="server"  Text="GST No." Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:TextBox ID="TextGST" runat="server" MaxLength = "15" Width="251px"></asp:TextBox>
             
          
          
             
                            
                <br />
                 <br />
           
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label9" runat="server"  Text="KIND ATTN  " Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextAttention" runat="server" Width="251px"></asp:TextBox><br />
             <br />
             
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label14" runat="server"  Text="Contact No." Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextContact" runat="server" Width="251px"></asp:TextBox>  
 
 <br />
             <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label15" runat="server"  Text="Responsible By" Font-Bold="False" ></asp:Label>
                    :&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextRes" runat="server" Width="251px"></asp:TextBox>
                    
                    
                     <asp:AutoCompleteExtender ServiceMethod="Search" MinimumPrefixLength="1" CompletionInterval="10"  
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TextRes" ID="Name_AutoCompleteExtender3"  
            runat="server" FirstRowSelected="false">  
        </asp:AutoCompleteExtender>  
                    
                    
                       <br />
&nbsp;<br /><br />
<hr />
 <div style="text-align:center">
        <asp:Label ID="Label5" runat="server" Text="Enter Details " ForeColor="#0066FF" Font-Bold="False" Font-Size="Larger"></asp:Label>
    </div>
   
   <asp:Table runat="server"  ID="Gantt" GridLines="Both"  Width="100%">
    <asp:TableRow>
      <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD">
        <asp:Label ID="Labelitem" runat="server"  Font-Bold="true" ForeColor="Black"  Text=" Item Code No"></asp:Label>
    </asp:TableCell>
   
     <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD">
        <asp:Label ID="Labeldescription" runat="server"  Font-Bold="true" ForeColor="Black"  Text=" Description"></asp:Label>
    </asp:TableCell>
    
    
 <asp:TableCell HorizontalAlign="Center" BackColor="#BDBDBD">
    <asp:Label runat="server" ID="lblUOM" Font-Bold="true" ForeColor="Black" Text="UOM"></asp:Label>
    </asp:TableCell>
    
    
    <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD" >
        <asp:Label ID="LabelHSN" runat="server"  Font-Bold="true" ForeColor="Black"  Text="HSN Code"></asp:Label>
    </asp:TableCell>
    
    <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD" >
        <asp:Label ID="LabelQuantity" runat="server"  Font-Bold="true" ForeColor="Black"  Text="Quantity"></asp:Label>
    </asp:TableCell>
    
     <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD" >
        <asp:Label ID="LabelRate" runat="server"  Font-Bold="true" ForeColor="Black"  Text="Rate"></asp:Label>
    </asp:TableCell>
    
    <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD" >
        <asp:Label ID="LabelAmount" runat="server"  Font-Bold="true" ForeColor="Black"  Text="Amount"></asp:Label>
    </asp:TableCell>
    
    </asp:TableRow>
    
    <asp:TableRow>
    <asp:TableCell HorizontalAlign="Center" >
    <asp:AutoCompleteExtender ServiceMethod="Get" MinimumPrefixLength="1" CompletionInterval="10"  
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TxtItemCode" ID="AutoCompleteExtender2"  
            runat="server" FirstRowSelected="false">  
        </asp:AutoCompleteExtender>  
      <asp:TextBox ID="TxtItemCode" runat="server" Width="100px"  ontextchanged="TxtItemCode_TextChanged" AutoPostBack="true"></asp:TextBox>
    </asp:TableCell>
    
     <asp:TableCell HorizontalAlign="Center" >
      <asp:TextBox ID="TxtDesc" runat="server" Width="300px" ></asp:TextBox>
    </asp:TableCell>
    
    
  <asp:TableCell Visible="True">
       <asp:DropDownList ID="drpuom" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource2"
    DataTextField="Symbol" DataValueField="Symbol" AppendDataBoundItems="true" Width="100%" >
    
</asp:DropDownList>

<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [Symbol] FROM [Unit_Master]" ></asp:SqlDataSource>
    </asp:TableCell>
    
    
     <asp:TableCell HorizontalAlign="Center" >
      <asp:TextBox ID="TxtHsn" runat="server" Width="100px" Text="0" ></asp:TextBox>
    </asp:TableCell>
    
    <asp:TableCell HorizontalAlign="Center" >
      <asp:TextBox ID="TxtQty" runat="server" Width="100px" ></asp:TextBox>
    </asp:TableCell>
    
     <asp:TableCell HorizontalAlign="Center" >
      <asp:TextBox ID="TxtRate" runat="server" Width="100px"  AutoPostBack =true ></asp:TextBox>
    </asp:TableCell>
    
     <asp:TableCell HorizontalAlign="Center" >
      <asp:TextBox ID="TxtAmt" runat="server" Width="100px" ></asp:TextBox>
    </asp:TableCell>
     </asp:TableRow>
      </asp:Table>
     <br />
    <asp:Button ID="Button1" runat="server" Text="Add" CssClass ="redbox" 
                    style=" float:right; margin-right:63px;" onclick="Button1_Click"/>
    <br />
    
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" Height="10%" 
        BorderStyle="Double" BorderColor ="Red"  BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames = "DCNo,ItemCode" OnRowDeleting="GridView1_RowDeleting" >
       
 <Columns>
 

 
<%--   <asp:BoundField DataField="No" HeaderText="Sr.No" HeaderStyle-BackColor="#f7f0f7" SortExpression="No" />
--%>   
<asp:CommandField  ButtonType="Link"   ShowDeleteButton="True"  /> <asp:BoundField DataField="DCNo" HeaderText="Code"  HeaderStyle-BackColor="#f7f0f7" SortExpression="DCNo" Visible =false  />

   <asp:BoundField DataField="ItemCode" HeaderText="Item Code"  HeaderStyle-BackColor="#f7f0f7" SortExpression="ItemCode" />
   <asp:BoundField DataField="Description" HeaderText="Description"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Description" />
     
<%--       <asp:BoundField DataField="UOM" HeaderText="UOM"   HeaderStyle-BackColor="#f7f0f7" SortExpression="UOM" />
--%>
     <asp:BoundField DataField="HSN" HeaderText="HSN No"  HeaderStyle-BackColor="#f7f0f7" SortExpression="HSN" />
   <asp:BoundField DataField="Quantity" HeaderText="Quantity"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Quantity" />
   <asp:BoundField DataField="Rate" HeaderText="Rate"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Rate" />
   <asp:BoundField DataField="Amount" HeaderText="Amount"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Amount" />

  </Columns>
</asp:GridView>
<hr />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Amt : <asp:Label ID="total" runat="server" ></asp:Label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Qty : <asp:Label ID="qty" runat="server"></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

      <br /><br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Label ID="Label8" runat="server"  Text="GST :" ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
     
    <asp:DropDownList runat="server" ID="drpGST" autopostback="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Text="0%" Value="0"></asp:ListItem>
        <asp:ListItem Text="IGST 18%" Value="18"></asp:ListItem>
        <asp:ListItem Text="CGST 9%" Value="9"></asp:ListItem>
         <asp:ListItem Text="CGST 18%" Value="18"></asp:ListItem>
        <asp:ListItem Text="GST 9%" Value="9"></asp:ListItem>
         <asp:ListItem Text="SGST 12%" Value="12"></asp:ListItem>
        <asp:ListItem Text="CGST 6%" Value="6"></asp:ListItem>
    </asp:DropDownList> 
     
     
     
     <asp:Label ID="Gst" runat="server" Text="0"  Visible="false" AutoPostBack="true" ></asp:Label>
     
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       GST Amount: 
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAmount" Text="0"  Visible="True" runat="server" ></asp:TextBox> 


    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      <asp:TextBox ID="txtgrandtot" Text="0" Visible="false" runat="server" ></asp:TextBox> 


     &nbsp;<br />
    <br />


     <hr />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      <br />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label7" runat="server"  Text="Transport Name" Font-Bold="False" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TxtTrans" runat="server" Width="128px"></asp:TextBox>

                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server"  Text="Vehicle No." Font-Bold="False" ></asp:Label>&nbsp;&nbsp; 
    :&nbsp;&nbsp; <asp:TextBox ID="TxtVehicle" runat="server" ></asp:TextBox>
               
                       <br />
<br />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="lblLRNO" Text="L.R.No." Font-Bold="False"></asp:Label> 
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: 
              <asp:TextBox ID="TxtLRNo" runat="server" ></asp:TextBox>
      
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    <asp:Label ID="Label6" runat="server"  Text="Remark" Font-Bold="False" ></asp:Label>
    &nbsp;&nbsp;:&nbsp;&nbsp; 
                <asp:TextBox ID="TxtRemark" runat="server" Width="140px"></asp:TextBox><br />
      
      <br />
                                              
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <asp:Label ID="Label3" runat="server"  Text="Acknowledgement" Font-Bold="False" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:Label ID="TextACK" runat="server" Width="400px" Text = "RECEIVED MATERIAL IN GOOD CONDITION SIGNATURE & STAMP" ></asp:Label>
    
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
 <asp:Button ID="Btnsubmit" runat="server" Text="Submit" CssClass ="redbox" 
                    style=" float:right; margin-right:63px; width: 58px;" 
                    onclick="Btnsubmit_Click" Height="31px" Width="75px" /><br />
                    <br />
                    




</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

