<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass_Insert.aspx.cs" Inherits="GatePass_Insert" Title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
     <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.4/angular.min.js"></script>
      <script type="text/javascript" src="../fusioncharts/fusioncharts.js"></script>
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

  <asp:Table runat="server" ID="Gantt" GridLines="Both" Width="100%" BackColor="#EEEEEE" >
  
   <asp:TableRow>

      <asp:TableCell HorizontalAlign="center" Width="17%">
   <asp:Label runat="server" Text="DATE" Font-Bold="true"  ></asp:Label>
   </asp:TableCell>
    <asp:TableCell HorizontalAlign="center" Width="17%">
    <asp:TextBox ID="Textbox1" runat="server" Width="55%" Text='<%# System.DateTime.Now %>'></asp:TextBox>
         
         <%-- <asp:TextBox ID="Textbox1" runat="server" Width="55%"></asp:TextBox>
         
     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
           Enabled="True" Format="dd-MM-yyyy" TargetControlID="Textbox1">
       </cc1:CalendarExtender> --%>
               
  </asp:TableCell>
   <asp:TableCell HorizontalAlign="center" Width="17%">
    <asp:Label ID="Label5" runat="server" Text="WONO" Font-Bold="true"  ></asp:Label>
   </asp:TableCell>
   <asp:TableCell HorizontalAlign="center">
       <asp:DropDownList ID="Textbox2" runat="server" AutoPostBack="true" DataSourceID="SqlDataSource2"
    DataTextField="WONo" DataValueField="WONo" AppendDataBoundItems="true" Width="60%" >
    <asp:ListItem Text="All WONo" Value="" />

</asp:DropDownList>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [WONo] FROM [SD_Cust_WorkOrder_Master]"></asp:SqlDataSource>
  
   <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"  ControlToValidate="TextBox2" ErrorMessage="*">
       </asp:RequiredFieldValidator> --%>
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center" Width="17%">
          <asp:Label ID="Label6" runat="server" Text="SELECT" Font-Bold="true"> </asp:Label>
   </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
        <asp:DropDownList ID="TextBox3" runat="server" Width="60%" >
                           <asp:ListItem Text="Select" Value="" />
                         <asp:ListItem Text="Supplier" Value="Supplier"  ></asp:ListItem>
                           <asp:ListItem Text="customer" Value="customer" ></asp:ListItem>
                             
                       </asp:DropDownList>  
 </asp:TableCell>
</asp:TableRow>

 <asp:TableRow>
  <asp:TableCell HorizontalAlign="center">
        <asp:Label ID="Label7" runat="server" Text="CODE NO" Font-Bold="true" ></asp:Label>
  </asp:TableCell>
   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox4" runat="server" Width="55%"></asp:TextBox>
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ControlToValidate="TextBox4" ErrorMessage="*">
                                </asp:RequiredFieldValidator>  --%>
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
       <asp:Label ID="Label8" runat="server" Text="DECRIPTION" Font-Bold="true" ></asp:Label>
   </asp:TableCell>
   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox5" runat="server" TextMode="MultiLine" Width="60%" Height="18px"></asp:TextBox>
    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="TextBox5" ErrorMessage="*">
                                </asp:RequiredFieldValidator>  --%>
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
        <asp:Label ID="Label9" runat="server" Text="UNIT" Font-Bold="true" ></asp:Label>
   </asp:TableCell>
   <asp:TableCell HorizontalAlign="center">
     
     
     <%-- <asp:DropDownList ID="Textbox6" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource11"
    DataTextField="Symbol" DataValueField="Symbol" AppendDataBoundItems="true" Width="60%">
    <asp:ListItem Text="All UNIT" Value="" />
    </asp:DropDownList>
        <asp:SqlDataSource ID="DropDownDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
    SelectCommand="SELECT [Symbol] FROM [Unit_Master]"></asp:SqlDataSource>--%>
 
       <asp:DropDownList ID="Textbox6" runat="server" Width="60%" >
                           <asp:ListItem Text="Select" Value="" />
                         <asp:ListItem Text="NOS" Value="NOS"  ></asp:ListItem>
                           <asp:ListItem Text="KG" Value="KG" ></asp:ListItem>
                            <asp:ListItem Text="LIT" Value="LIT"  ></asp:ListItem>
                           <asp:ListItem Text="LOOSE" Value="LOOSE" ></asp:ListItem>
                            <asp:ListItem Text="MTR" Value="MTR"  ></asp:ListItem>
              </asp:DropDownList>  
  </asp:TableCell>
   </asp:TableRow>
  
   <asp:TableRow>

   <asp:TableCell HorizontalAlign="center">
     <asp:Label ID="Label10" runat="server" Text="RETURNABLE_GATEPASS" Font-Bold="true"  ></asp:Label>
   </asp:TableCell>
   
   <asp:TableCell HorizontalAlign="center">
      <%-- <asp:TextBox ID="Textbox7" runat="server" Width="55%"></asp:TextBox>--%>
       <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"  ControlToValidate="TextBox7" ErrorMessage="*">
                                </asp:RequiredFieldValidator>  --%>
   
                 <asp:DropDownList ID="Textbox7" runat="server" Width="55%" >
                           <asp:ListItem Text="Select" Value="" />
                         <asp:ListItem Text="Returnable" Value="Returnable"  ></asp:ListItem>
                           <asp:ListItem Text="Non Returnable " Value="Non Returnable" ></asp:ListItem>
                            <asp:ListItem Text="Rejection" Value="Rejection"  ></asp:ListItem>
                             
                       </asp:DropDownList> 
                      
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
      <asp:Label ID="Label11" runat="server" Text=" TOTAL QTY" Font-Bold="true"  ></asp:Label>
  </asp:TableCell>
   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox8" runat="server" Width="60%"></asp:TextBox>
     <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ControlToValidate="TextBox8" ErrorMessage="*">
                                </asp:RequiredFieldValidator>  --%>
  </asp:TableCell>

    <asp:TableCell HorizontalAlign="center">
       <asp:Label ID="Label12" runat="server" Text="CHECKBY"  Font-Bold="true" ></asp:Label>
   </asp:TableCell>
  
   <asp:TableCell HorizontalAlign="center">
      <asp:TextBox ID="Textbox9" runat="server" Width="60%"></asp:TextBox>
     <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox9" ErrorMessage="*">
                                </asp:RequiredFieldValidator>  --%>
                                
         <%-- <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="Textbox9">
                        </cc1:CalendarExtender>  --%>
  </asp:TableCell>

</asp:TableRow>

 <asp:TableRow>
<asp:TableCell HorizontalAlign="center">
     <asp:Label ID="Label13" runat="server"  Text="SUPPLIER/CUSTOMER NAME" Font-Bold="true"></asp:Label>
 </asp:TableCell>

  <asp:TableCell HorizontalAlign="center">
       <%--<asp:DropDownList ID="Textbox10" runat="server" AutoPostBack="true" DataSourceID="DropDownDataSource112"
           DataTextField="EmployeeName" DataValueField="EmployeeName" AppendDataBoundItems="true" Width="55%">
          <asp:ListItem Text="EmployeeName" Value="" />
       </asp:DropDownList>
         <asp:SqlDataSource ID="DropDownDataSource112" runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
              SelectCommand="SELECT [EmployeeName] FROM [tblHR_OfficeStaff]"></asp:SqlDataSource>--%>
             
       <asp:TextBox ID="Textbox10" runat="server" Width="55%"></asp:TextBox>        
             
  </asp:TableCell>

 <asp:TableCell HorizontalAlign="center">
    <asp:Label ID="Label14" runat="server" Text=" DATE OF RECEIPT" Font-Bold="true"></asp:Label>
</asp:TableCell>
  
  <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox11" runat="server" Width="60%"></asp:TextBox>

                   <cc1:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="Textbox11">
                        </cc1:CalendarExtender>  
  </asp:TableCell>

  <asp:TableCell HorizontalAlign="center">
      <asp:Label ID="Label15" runat="server" Text=" QTY RECD." Font-Bold="true" ></asp:Label>
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox12" runat="server" Width="60%"></asp:TextBox>
      <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBox12" ErrorMessage="*">
          </asp:RequiredFieldValidator>  --%>
  </asp:TableCell>

  </asp:TableRow>

<asp:TableRow>

  <asp:TableCell HorizontalAlign="center">
       <asp:Label ID="Label16" runat="server" Text=" QTY PENDING" Font-Bold="true"></asp:Label>
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox13" runat="server" Width="55%" ></asp:TextBox>
    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"  ControlToValidate="TextBox13" ErrorMessage="*">
                            </asp:RequiredFieldValidator>  --%>
  </asp:TableCell>

 <asp:TableCell HorizontalAlign="center">
   <asp:Label ID="Label17" runat="server" Text="RECD.BY" Font-Bold="true" ></asp:Label>
 </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox14" runat="server" Width="60%"></asp:TextBox>
      <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"  ControlToValidate="TextBox14" ErrorMessage="*">
       </asp:RequiredFieldValidator>  --%>
       
          
  </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
       <asp:Label ID="Label18" runat="server" Text="REMARK" Font-Bold="true" ></asp:Label>
   </asp:TableCell>

   <asp:TableCell HorizontalAlign="center">
       <asp:TextBox ID="Textbox15" runat="server" Width="60%"></asp:TextBox>
     <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox15" ErrorMessage="*">
    </asp:RequiredFieldValidator>  --%>
  </asp:TableCell>

 </asp:TableRow>
</asp:Table>

   <br />

   <div style="text-align:center">
    <asp:Button runat="server" ID="btn" Text="Submit" OnClick="Add" BackColor="red" ForeColor="white"  Width="10%"/>
   </div>

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

