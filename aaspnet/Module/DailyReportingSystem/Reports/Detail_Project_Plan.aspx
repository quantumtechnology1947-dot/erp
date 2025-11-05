<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Detail_Project_Plan.aspx.cs" Inherits="Module_Project_Planning_Reports_DETAIL_PROJECT_PLAN" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
  <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            width: 926px;
        }
       
        .style7
        {
            width: 100%;
            float: left;
        }
        .box3
        {
            width: 406px;
        }
               
        .style11
        {
            color: white;
        }
       
    </style>
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
   <table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
                      
                    <tr height="21">
                        <td style="background-color:gainsboro" class="fontcsswhite" ><strong style="background-color: #006699">&nbsp;Project Summary </strong>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    
                 <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="420px"
Width="100%"  AutoPostBack="True" >
<cc1:TabPanel runat="server" HeaderText="W/o Wise" ID="TabPanel1">
    <HeaderTemplate>Daily Reporting Tracker System</HeaderTemplate>
    <ContentTemplate>        
                    
                    
<table width="100%" cellpadding="0" cellspacing="0">
               
        
        <tr>
                    
                <td align="center">
                    <table align="left" cellpadding="0" cellspacing="0" class="style7">
                        <tr>
                            <td align="left" height="26" width="120px">&nbsp;<b>&nbsp; Financial Year</b></td>
                            <td align="left">From Date:<asp:Label ID="lblFromDate" runat="server"></asp:Label>
                                &nbsp; To:<asp:Label ID="lblToDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><b>&nbsp;&nbsp; From Date</b></td>
                            <td align="left" height="26">
                                <asp:TextBox ID="TxtFromDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" PopupPosition="BottomRight" TargetControlID="TxtFromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqFromDt" runat="server" ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="a"></asp:RegularExpressionValidator>
                                &nbsp;-&nbsp; <b>To</b>
                                <asp:TextBox ID="TxtToDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" PopupPosition="BottomRight" TargetControlID="TxtToDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqCate2" runat="server" ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtToDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="a"></asp:RegularExpressionValidator>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" height="26">
                                <asp:DropDownList ID="DrpType" runat="server" >
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem>Name</asp:ListItem>
                                    <asp:ListItem>WONo</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="Dropwo" runat="server"></asp:DropDownList>
                                <asp:DropDownList ID="DrpSearchCode" runat="server" AutoPostBack="True" CssClass="box3" OnSelectedIndexChanged="DrpSearchCode_SelectedIndexChanged" Width="200px">
                                    <asp:ListItem Value="Select">Select</asp:ListItem>
                                    <asp:ListItem Value="tblHR_Designation.Type">Designation</asp:ListItem>
                                    <asp:ListItem Value="tblHR_Departments.Description">Departments</asp:ListItem>
                                    <asp:ListItem Value="aspnet_Users.UserName">Employee Id</asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="Drpdesi" runat="server" DataSourceID="SqlDataSource1" DataTextField="Type"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [Type] FROM [tblHR_Designation]"></asp:SqlDataSource>
                                                    <asp:DropDownList ID="Drpdep" runat="server" AutoPostBack="True" CssClass="box3" style="margin-bottom: 0px" Width="155px">
                                </asp:DropDownList>
                                <asp:DropDownList ID="Drpempid" runat="server"></asp:DropDownList>
                                             <asp:TextBox ID="txtSearchItemCode" runat="server" CssClass="box3" Width="207px"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>
                                           &nbsp;<asp:Button ID="Btnsearch" runat="server" CssClass="redbox" OnClick="Btnsearch_Click" Text="Search" />
                            </td>
                        </tr>
                    </table>
                </td>
                    
                </tr>
        
        <tr>
        <td >
            <table align="center" cellpadding="0" cellspacing="0" class="style7">
                <tr>
                    <td align="left">
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" EnableModelValidation="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" PageSize="20" Width="95%">
                            <Columns>
                                <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnselect" runat="server" CommandName="Sel" Text="Select" ValidationGroup="a" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnlnkImg" runat="server" CommandName="downloadImg" Text='<%# Bind("FileName") %>' Visible="true"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spec. Sheet">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnlnkSpec" runat="server" CommandName="downloadSpec" Text='<%# Bind("AttName") %>' Visible="true"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Code">
                                    <ItemTemplate>
                                        <asp:Label ID="itemcode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="manfdesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="50%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UOM">
                                    <ItemTemplate>
                                        <asp:Label ID="uomBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Stock Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="stockQty" runat="server" Text='<%# Eval("StockQty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table class="fontcss" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" Text="No data to display !">
                    </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <PagerSettings PageButtonCount="40" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </td>
        </tr> 
      
        
                       
      
        
    </table>
</ContentTemplate>
 </cc1:TabPanel>
 
 <cc1:TabPanel runat="server" HeaderText="Quantity Wise" ID="TabPanel2">
     <HeaderTemplate>Design Plan</HeaderTemplate>
 <ContentTemplate>  
   
 
       <table align="center" cellpadding="0" cellspacing="0" width="100%"><tr><td height="25">&nbsp;<asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                AutoPostBack="True" ><asp:ListItem Value="0">WoNo</asp:ListItem><asp:ListItem Value="1">Name</asp:ListItem><asp:ListItem Value="2">Date</asp:ListItem></asp:DropDownList>&nbsp;<asp:TextBox ID="txtSupplier" runat="server" CssClass="box3"  Width="250px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender>&nbsp;<asp:TextBox ID="txtPONo" runat="server" Visible="False" CssClass="box3" 
                                Width="250px"></asp:TextBox>&nbsp;<asp:CheckBox ID="SelectAll" runat="server" Text="Select All Work Order"  AutoPostBack="True" 
                               />&nbsp; &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search"  />&nbsp;&nbsp;</td></tr><tr><td><asp:Panel ID="Panel1" runat="server" Height="375px" ScrollBars="Auto"><asp:GridView ID="GridView1" runat="server"  
                                    AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="WOId"  Width="100%" EnableModelValidation="True"><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField HeaderText="SN" ><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:CheckBox ID="CheckBox1" runat="server" /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="WO No"  ><ItemTemplate><asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'>
                                </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Project Title" ><ItemTemplate><asp:Label ID="lblProjectTitle" runat="server" Text='<%#Eval("ProjectTitle") %>'>
                                </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="40%" /></asp:TemplateField><asp:TemplateField HeaderText="Employee Name" ><ItemTemplate><asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'>
                                </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30%" /></asp:TemplateField><asp:TemplateField HeaderText="Designation" ><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'>
                                </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Department Name"></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Names="Calibri" 
                                        ForeColor="red" Text="No  data found to display"></asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True" /></asp:GridView></asp:Panel></td></tr><tr><td align="center" height="25px" valign="middle"><asp:Button ID="btnPrint" runat="server" CssClass="redbox" Text="Proceed" 
                   /></td></tr></table></ContentTemplate>
 </cc1:TabPanel>
 
 
 
 <cc1:TabPanel runat="server" HeaderText="Shortage Wise" ID="TabPanel3">
     <HeaderTemplate>Manufacturing Plan</HeaderTemplate>
     <ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0"><tr><td class="fontcsswhite" height="25" ><asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" ID="DropDownList4"  Width="180px"><asp:ListItem Value="3">WO No</asp:ListItem><asp:ListItem Value="0">Customer Name</asp:ListItem><asp:ListItem Value="1">Enquiry No</asp:ListItem><asp:ListItem Value="2">PO No</asp:ListItem></asp:DropDownList><asp:TextBox ID="txtEnqSH" runat="server" CssClass="box3" 
                    Width="150px"></asp:TextBox><asp:TextBox ID="TxtSearchSH" runat="server" CssClass="box3"  
                    Visible="False" Width="350px"></asp:TextBox><asp:Button ID="btnSearchSH" runat="server" 
            Text="Search" CssClass="redbox"   />&nbsp;&nbsp;&nbsp; </td></tr><tr><td><asp:GridView ID="SearchGridView2" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                               
                    Width="100%" 
                    PageSize="15"  EnableModelValidation="True" ><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:TemplateField><asp:BoundField DataField="FinYear" HeaderText="Fin Yrs"><ItemStyle HorizontalAlign="Center" Width="8%" /></asp:BoundField><asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName"><ItemStyle HorizontalAlign="Left" Width="25%" /></asp:BoundField><asp:TemplateField HeaderText="WO No"><ItemTemplate><asp:LinkButton ID="BtnWONoSH" runat="server" CommandName="NavigateToSH" Text='<%# Eval("WONo") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField><asp:BoundField DataField="SysDate" HeaderText="Gen. Date" /><asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" Visible="False" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label3" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label></td></tr></table></EmptyDataTemplate><RowStyle HorizontalAlign="Center" /></asp:GridView></td></tr></table></ContentTemplate>
 </cc1:TabPanel>
 
 
 
 
 <cc1:TabPanel runat="server" HeaderText="Supplier Wise" ID="TabPanel4">
     <HeaderTemplate>Vendor Plan</HeaderTemplate>
     <ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0"><tr><td class="fontcsswhite" height="25" ><asp:TextBox ID="TextSupWONo" runat="server" CssClass="box3" 
                    Width="150px"></asp:TextBox><asp:TextBox ID="TextSupCust" runat="server" CssClass="box3"  
                    Visible="False" Width="350px"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender12" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TextSupCust" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:Button ID="BtnSup" runat="server" 
            Text="Search" CssClass="redbox"   />&nbsp;&nbsp;&nbsp; </td></tr><tr><td><asp:GridView ID="GridViewSup" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo"                  
                   Width="100%" PageSize="15" EnableModelValidation="True" ><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:TemplateField><asp:BoundField DataField="FinYear" HeaderText="Fin Yrs"><ItemStyle HorizontalAlign="Center" Width="8%" /></asp:BoundField><asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName"><ItemStyle HorizontalAlign="Left" Width="25%" /></asp:BoundField><asp:TemplateField HeaderText="WO No"><ItemTemplate><asp:LinkButton ID="BtnWONoSup" runat="server" CommandName="Sup" Text='<%# Eval("WONo") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField><asp:BoundField DataField="SysDate" HeaderText="Gen. Date" /><asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" Visible="False" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label4" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label></td></tr></table></EmptyDataTemplate><RowStyle HorizontalAlign="Center" /></asp:GridView></td></tr></table></ContentTemplate>
 </cc1:TabPanel>
 
  
 </cc1:TabContainer>
            </td>
        </tr>
        
        </table>
 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

