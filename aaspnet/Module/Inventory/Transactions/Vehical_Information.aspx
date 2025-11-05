<%@ Page Title="ERP" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Vehical_Information.aspx.cs" Inherits="Challan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>  
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 177px;
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
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Vehical Information</b></td>
    </tr></table>
   
                <h3/>
                    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <table >
                    <tr align="center">
                        <td valign="middle">
                              &nbsp; &nbsp;  
                <asp:Label ID="Label2" runat="server" Width="189px" Text="Vehical Registration No." Font-Bold="False" 
                                  Font-Size="Larger" BorderStyle="None" ></asp:Label>
                <asp:Label ID="TextDCNO" runat="server" Width="99px" Font-Bold="True" Font-Size="Larger" 
                                  BorderStyle="None" Height="34px" ToolTip="DC No." Font-Underline="False" ></asp:Label>  
             <br />
                        </td>      
<td class="style2"></td>
    <td>
            
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label10" runat="server"  
                        Text="Date " Font-Bold="False" ></asp:Label> 
                    &nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
            ID="TextDCDate" runat="server" Width="130px" Height="21px"></asp:TextBox>

               <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TextDCDate" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
    </td>
                    </tr>
                </table><br />
                <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Vehical Type"></asp:Label>
                &nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlType" runat="server" Height="26px" Width="163px"
              DataSourceID="SqlDataSource1"
    DataTextField="Vehical" DataValueField="Vehical" AppendDataBoundItems="true">
    <asp:ListItem Text=" select" Value="" />
       </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT (VehicalName + ' ' + VehicalNo) AS Vehical FROM tblVeh_Process_Master WHERE Id!='0' ">
</asp:SqlDataSource>
                <h3/>
                    
                    &nbsp;<asp:Label ID="Label13" runat="server"  Text="Supplier Name" Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextTO" runat="server" 
                    ontextchanged="TextTO_TextChanged" AutoPostBack="true" Height="34px" 
                    Width="182px"></asp:TextBox>  

                    <asp:AutoCompleteExtender ServiceMethod="GetSearch" MinimumPrefixLength="1" CompletionInterval="10"  
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TextTO" ID="AutoCompleteExtender1"  
            runat="server" FirstRowSelected="false">  
        </asp:AutoCompleteExtender>  
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label11" runat="server"  Text="Address" Font-Bold="False" ></asp:Label>
                    &nbsp;: 
                <asp:TextBox ID="Textaddress" runat="server" TextMode ="MultiLine" 
                    Width="245px" Height="35px" ></asp:TextBox>
  <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <br />
           
               
             
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label14" runat="server"  Text="Contact No." Font-Bold="False" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextContact" runat="server" Width="150px" Height="19px"></asp:TextBox>  
 
 <br />
             <br />
            &nbsp;<asp:Label ID="Label15" runat="server"  Text="Employee Name" Font-Bold="False" ></asp:Label>
                    &nbsp;:&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextRes" runat="server" Width="193px" Height="28px"></asp:TextBox>
                    
                    
                     <asp:AutoCompleteExtender ServiceMethod="Search" MinimumPrefixLength="1" CompletionInterval="10"  
            EnableCaching="false" CompletionSetCount="10" TargetControlID="TextRes" ID="Name_AutoCompleteExtender3"  
            runat="server" FirstRowSelected="false">  
        </asp:AutoCompleteExtender>  
                    
                    
                       <br />
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Label ID="Label7" runat="server"  Text="From KM" Font-Bold="False" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TxtTrans" runat="server" Width="128px"></asp:TextBox>

                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server"  Text="To KM" Font-Bold="False" ></asp:Label>&nbsp;&nbsp; 
    :&nbsp;&nbsp; <asp:TextBox ID="TxtVehicle" runat="server" Height="24px" Width="83px" ></asp:TextBox>
               
                       <br />
<br />
                             &nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="lblLRNO" Text="Avrage KM" Font-Bold="False" Visible="false"></asp:Label> 
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
              <asp:TextBox ID="TxtLRNo" runat="server" Visible="false" Text="0" ></asp:TextBox>
      <br />
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    <asp:Label ID="Label6" runat="server"  Text="Fuel Date" Font-Bold="False" ></asp:Label>
    &nbsp;
    &nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextACK" runat="server" Width="125px" Height="23px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
              <cc1:CalendarExtender ID="CalendarExtender12" runat="server" 
                    Enabled="True" TargetControlID="TextACK" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
            
            
            
             <asp:Label ID="Label3" runat="server"  Text="Fuel Rs." Font-Bold="False" ></asp:Label>
    &nbsp;:&nbsp; 
                <asp:TextBox ID="TxtRemarkM" runat="server" Width="86px" Height="27px"></asp:TextBox><br />
      
                    &nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp; <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          
           
           
              <asp:Label ID="Label5" runat="server"  Text="Material" Font-Bold="False" ></asp:Label>
    &nbsp;&nbsp;:&nbsp;&nbsp; 
                <asp:TextBox ID="TxtTransE" runat="server" Width="140px"></asp:TextBox><br />
                <br />
 <asp:Button ID="Btnsubmit0" runat="server" Text="Submit" CssClass ="redbox" 
                    style=" float:left; margin-right:63px; width: 58px;" 
                    onclick="Btnsubmit_Click" Height="31px" Width="75px" />
           <br />
     <br />   
<br />
                    




</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

