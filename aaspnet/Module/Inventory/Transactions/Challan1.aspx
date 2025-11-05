<%@ Page Title="ERP" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Challan1.aspx.cs" Inherits="Challan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Delivery Challan</b></td>
    </tr></table>
    <br />
                <h3>
                    <p style="text-align: center">
                        <b><u>Delivery Challan</u></b></p>
                </h3>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Challan Type"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlType" runat="server" Height="26px" Width="251px">
              <asp:ListItem Text ="Select" Value =""></asp:ListItem>
              <asp:ListItem Text ="Returnable" Value ="Returnable"></asp:ListItem>
              <asp:ListItem Text ="Non-Returnable" Value ="Non-Returnable"></asp:ListItem>
             <%-- <asp:ListItem Text ="TRIPLICATE" Value ="TRIPLICATE"></asp:ListItem>
              <asp:ListItem Text ="TRANSPORTER" Value ="TRANSPORTER"></asp:ListItem>--%>
                </asp:DropDownList>
                
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                :&nbsp;<%--<asp:TextBox ID="TextTO" runat="server"></asp:TextBox>--%>
                        <asp:TextBox ID="TextTO" runat="server" 
                    ontextchanged="TextTO_TextChanged" AutoPostBack="true" Height="23px" 
                    Width="251px"></asp:TextBox>  

                    <asp:AutoCompleteExtender ServiceMethod="GetSearch" MinimumPrefixLength="1" CompletionInterval="10"  
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TextTO" ID="AutoCompleteExtender1"  
            runat="server" FirstRowSelected="false">  
        </asp:AutoCompleteExtender>  
 <br />
  <br />
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp : 
                <asp:TextBox ID="Textaddress" runat="server" TextMode ="MultiLine" 
                    Width="251px" ></asp:TextBox><br />
             <br />
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                GST No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextGST" runat="server" MaxLength = "15" Width="251px"></asp:TextBox><br />
             <br />
             
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                D.C No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextDCNO" runat="server" Width="251px" ><%--Text = "2018-2019/"--%></asp:TextBox>  
             <br />
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; D.C Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextDCDate" runat="server" Width="251px"></asp:TextBox>
               <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextDCDate" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                <br />
                 <br />
            <hr />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; KIND ATTN&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextAttention" runat="server" Width="251px"></asp:TextBox><br />
             <br />
             
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Contact No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextContact" runat="server" Width="251px"></asp:TextBox>  
  <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="fill proper contact no" ControlToValidate="TextContact" 
                    ValidationExpression="^([0-9]{10})$" ValidationGroup="vg"></asp:RegularExpressionValidator>--%>
 <br />
             <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Responsible By&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextRes" runat="server" Width="251px"></asp:TextBox>
                       <br />
&nbsp;<br /><br />
<hr />
 <div style="text-align:center">
        <asp:Label ID="Label5" runat="server" Text="Enter Details " ForeColor="#0066FF" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </div>
   
   <asp:Table runat="server"  ID="Gantt" GridLines="Both"  Width="100%">
    <asp:TableRow>
      <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD">
        <asp:Label ID="Labelitem" runat="server"  Font-Bold="true" ForeColor="Black"  Text=" Item Code No"></asp:Label>
    </asp:TableCell>
   
     <asp:TableCell HorizontalAlign="Center"  BackColor="#BDBDBD">
        <asp:Label ID="Labeldescription" runat="server"  Font-Bold="true" ForeColor="Black"  Text=" Description"></asp:Label>
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
    
     <asp:TableCell HorizontalAlign="Center" >
      <asp:TextBox ID="TxtHsn" runat="server" Width="100px" ></asp:TextBox>
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
 
 <%--<asp:TemplateField HeaderText="SrNo" >
   <ItemTemplate>
       <%# Container.DataItemIndex + 1%>
   </ItemTemplate>
 </asp:TemplateField>--%>
 
<%--   <asp:BoundField DataField="No" HeaderText="Sr.No" HeaderStyle-BackColor="#f7f0f7" SortExpression="No" />
--%>   
<asp:CommandField  ButtonType="Link"   ShowDeleteButton="True"  /> <asp:BoundField DataField="DCNo" HeaderText="Code"  HeaderStyle-BackColor="#f7f0f7" SortExpression="DCNo" Visible =false  />

   <asp:BoundField DataField="ItemCode" HeaderText="Item Code"  HeaderStyle-BackColor="#f7f0f7" SortExpression="ItemCode" />
   <asp:BoundField DataField="Description" HeaderText="Description"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Description" />
     <asp:BoundField DataField="HSN" HeaderText="HSN No"  HeaderStyle-BackColor="#f7f0f7" SortExpression="HSN" />
   <asp:BoundField DataField="Quantity" HeaderText="Quantity"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Quantity" />
   <asp:BoundField DataField="Rate" HeaderText="Rate"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Rate" />
   <asp:BoundField DataField="Amount" HeaderText="Amount"  HeaderStyle-BackColor="#f7f0f7" SortExpression="Amount" />

  </Columns>
</asp:GridView>
<hr />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Amt : <asp:TextBox ID="total" runat="server"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Qty : <asp:TextBox ID="qty" runat="server"></asp:TextBox>
<%--          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="cal" runat="server" Text="Calculate" CssClass ="redbox" onclick="cal_Click"/>
--%>
      <br /><br />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GST % : <asp:TextBox ID="Gst" runat="server"></asp:TextBox>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Grand Total : <asp:TextBox ID="Gt" runat="server"></asp:TextBox> 

<%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer%>"
        SelectCommand="SELECT [id],[LastType],[LastSerialNo] FROM [tbl_LastType]" >
         </asp:SqlDataSource>--%>
     <hr />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Remark&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TxtRemark" runat="server" Width="251px"></asp:TextBox><br />
      <br />
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Transport Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TxtTrans" runat="server" Width="251px"></asp:TextBox>

                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Vehicle No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TxtVehicle" runat="server" Width="251px"></asp:TextBox>
                       <br />
<br />
                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; L.R.NO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TxtLRNo" runat="server" Width="251px"></asp:TextBox>

      
      <br/>
      <br/>
      
     
      <hr />
                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Acknowledgement&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : 
                <asp:TextBox ID="TextACK" runat="server" Width="251px" Text = "Received material in good condition" ReadOnly = "true" ></asp:TextBox>
    
<%--                                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Labeltext" runat="server" Text="(Received Material In Good Condition Sign And Stamp.) " Font-Bold =true></asp:Label>
--%>     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
 <asp:Button ID="Btnsubmit" runat="server" Text="Submit" CssClass ="redbox" 
                    style=" float:right; margin-right:63px; width: 58px;" 
                    onclick="Btnsubmit_Click" /><br />
                    <br />
                    




</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

