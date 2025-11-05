<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_Access_AccessModule, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            height: 21px;
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
    <!-- #include file="_nav.aspx -->
<!-- #include file="_nav3.aspx -->
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="100%" align="center" class="box3">
        <tr>
            <td colspan="2" class="fontcsswhite" 
                style="background:url('../../images/hdbg.JPG')" height="21" >&nbsp;<strong>Access Module</strong>
                </td>
        </tr>
        <tr>
            <td class="style2" height="25" width="10%">

    &nbsp;

                Company</td>
            <td>
    <asp:DropDownList ID="DrpCompany" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DrpCompany_SelectedIndexChanged" CssClass="box3">
    </asp:DropDownList>
            &nbsp;&nbsp; Financial Year
    <asp:DropDownList ID="DrpFinYear" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DrpFinYear_SelectedIndexChanged" CssClass="box3">
    </asp:DropDownList>
            &nbsp;<asp:DropDownList ID="DrpField" runat="server" 
                onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True" 
                CssClass="box3">
                <asp:ListItem>Select</asp:ListItem>
               <asp:ListItem Value="0">Employee Name</asp:ListItem>
               <asp:ListItem Value="1">Dept Name</asp:ListItem>
               <asp:ListItem Value="2">BG Group </asp:ListItem>
                               
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="TxtMrs" runat="server" Width="150px" CssClass="box3" 
                     Visible="False"></asp:TextBox>
            &nbsp;<asp:TextBox ID="TxtEmpName" runat="server" Width="250px" CssClass="box3" 
                     Visible="False"></asp:TextBox>
                  
        &nbsp;<cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
        
                    
            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
            
        
            &nbsp;<asp:Button ID="BtnView" runat="server" CssClass="redbox" 
                    onclick="BtnView_Click" Text="Access Chart" />
            
        
            </td>
        </tr>
      <%--  <tr>
            <td class="style2" height="25">
                &nbsp;
   
    <asp:Label ID="Label4" runat="server" Text="Employee "></asp:Label>
   
            </td>
            <td>
    <asp:DropDownList ID="DrpEmployeeName" runat="server" AutoPostBack="True" 
         
        style="height: 22px" 
        onselectedindexchanged="DrpEmployeeName_SelectedIndexChanged" CssClass="box3">
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2" height="25">
                &nbsp;
   
    <asp:Label ID="Label5" runat="server" Text="Module"></asp:Label>
            </td>
            <td>
    <asp:DropDownList ID="DrpModule" runat="server" AutoPostBack="True" 
   onselectedindexchanged="DrpModule_SelectedIndexChanged" CssClass="box3">
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2" height="25">
                &nbsp;
   
    <asp:Label ID="Label6" runat="server">Type </asp:Label>
            </td>
            <td>
    <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DrpType_SelectedIndexChanged" CssClass="box3">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem Value="1">Masters</asp:ListItem>
        <asp:ListItem Value="2">Transactions</asp:ListItem>
        <asp:ListItem Value="3">Reports</asp:ListItem>
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2" height="25">
&nbsp; <asp:Label ID="Label7" runat="server" Text="Sub Module Name "></asp:Label>
   
            </td>
            <td>
   
    <asp:DropDownList ID="DrpSubModule" runat="server" 
        DataTextField="SubModName" DataValueField="MTR" AutoPostBack="True" 
        onselectedindexchanged="DrpSubModule_SelectedIndexChanged" CssClass="box3">
    </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2" height="25">
                &nbsp;</td>
            <td>
                <asp:CheckBox ID="cNew" runat="server" Text="New" />
    <asp:CheckBox ID="cEdit" runat="server" Text="Edit" />
    <asp:CheckBox ID="cDelete" runat="server" Text="Delete" />
    <asp:CheckBox ID="cPrint" runat="server" Text="Print" />
   
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td height="30">
    <asp:Button ID="Btnsave" runat="server" onclick="Btnsave_Click" Text=" Save " 
                    CssClass="redbox" />
                &nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    onclick="Button1_Click" Text="Cancel" />
                &nbsp;&nbsp;<asp:Button ID="BtnView" runat="server" CssClass="redbox" 
                    onclick="BtnView_Click" Text="Access Chart" />
            </td>
        </tr>
        <tr>
            <td class="style3" align="center" colspan="2">
                <asp:Label ID="Label8" runat="server" style="color: #FF0000"></asp:Label>
            </td>
        </tr>--%>
        <tr>
<td class="style2" height="25" colspan="2">
<table  width="100%">
   
        <tr>
             <td align="left">
        
            &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            
        
            </td>
        </tr>
        <tr>
            <td>


    <asp:GridView ID="GridView2" runat="server" 
        CssClass="yui-datatable-theme" AutoGenerateColumns="False" DataKeyNames="UserId" 
        AllowPaging="True" Width="98%" onrowcommand="GridView2_RowCommand" 
                    onpageindexchanged="GridView2_PageIndexChanged" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="14">
        <PagerSettings PageButtonCount="40" />
      <Columns>
      
                <asp:TemplateField HeaderText="Fin Year">
                <ItemTemplate>
                <asp:Label ID="lblFinYear" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
          <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" 
              ReadOnly="True" SortExpression="UserId" Visible="False" />
                <asp:TemplateField HeaderText="Emp Id" SortExpression="EmpId">
                    <ItemTemplate>
                        <asp:Label ID="lblempid" runat="server" Text='<%# Bind("EmpId") %>'></asp:Label>
                    </ItemTemplate>                    
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
          <asp:BoundField DataField="EmployeeName" HeaderText="Emp Name" 
              SortExpression="EmployeeName">
              <ItemStyle HorizontalAlign="Left" Width="25%" />
          </asp:BoundField>
          <asp:BoundField DataField="DeptName" HeaderText="Dept Name" 
              SortExpression="DeptName" >
              <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="BGgroup" HeaderText="BG Group" 
              SortExpression="BGgroup" >
              <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="Designation" HeaderText="Designation" 
              SortExpression="Designation" />
          <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" 
              SortExpression="MobileNo" >
              <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" 
              SortExpression="JoiningDate" >
              <ItemStyle HorizontalAlign="Center" />
          </asp:BoundField>
          
          
                <asp:TemplateField HeaderText="Module">
                <ItemTemplate>                        
    <asp:DropDownList ID="DrpModule" runat="server"  DataSourceID="SqlDataSource1" DataTextField="ModName" 
    AutoPostBack="false" DataValueField="ModId" Width="100%"     
    CssClass="box3">
    </asp:DropDownList>
                    
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>
                
                
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkBtnSel"  runat="server" CausesValidation="False" 
                            CommandName="Select" Text="Select"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
      </Columns>
       <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
      
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                     ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT * FROM [tblModule_Master] Where ModId not in('5','8')"></asp:SqlDataSource>
            </td>
        </tr>
        </table>           
</td>
</tr>
        </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

