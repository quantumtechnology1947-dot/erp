<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ManPowerPlanning_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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

<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Man Power Planning - Print</b></td>
        </tr>
        
       
        <tr>
        <td height="25px">
            &nbsp;  &nbsp;
              <asp:DropDownList ID="ddlSelectBG_WONo" runat="server" AutoPostBack="True" 
                CssClass="box3" onselectedindexchanged="ddlSelectBG_WONo_SelectedIndexChanged">
                <asp:ListItem Text="Select WONo" Value="0"></asp:ListItem>
                <asp:ListItem Text="BG Group" Value="1" Enabled="false"></asp:ListItem>
                <asp:ListItem Text="WONo" Value="2"></asp:ListItem>
            </asp:DropDownList>
             &nbsp;<asp:TextBox ID="TxtWONo" runat="server" CssClass="box3" Visible="False" 
                Width="95px"></asp:TextBox>
                <asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="False" 
                CssClass="box3" Height="21px" 
                
                    DataSourceID="SqlBGGroup" DataTextField="Symbol" DataValueField="Id" Visible="False"></asp:DropDownList>
     
        &nbsp;
            <asp:DropDownList ID="DrpMonths" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;
            <asp:DropDownList ID="Drptype" runat="server" AutoPostBack="False"  CssClass="box3">
                <asp:ListItem Value="0">NA</asp:ListItem>
                <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                <asp:ListItem Text="Absent" Value="2"></asp:ListItem>
                <asp:ListItem Text="Onsite" Value="3"></asp:ListItem>
                <asp:ListItem Text="PL" Value="4"></asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp; From Date
                <asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight" 
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
            &nbsp;To&nbsp;
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
                
            &nbsp;&nbsp;
                <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="TxtTodate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                Emp Name
            <asp:TextBox ID="TxtEmpName" runat="server" CssClass="box3" Width="250px"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                CompletionInterval="100" CompletionListCssClass="almt" 
                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                FirstRowSelected="True" MinimumPrefixLength="1" 
                ServiceMethod="GetCompletionList" ServicePath="" 
                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmpName" 
                UseContextKey="True">
            </cc1:AutoCompleteExtender>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnSearch" runat="server" CssClass="redbox" 
                onclick="BtnSearch_Click" Text="Search" ValidationGroup="view" />

        
        </td>
        </tr>
       
       
        <tr>
        <td height="25px">
        
        <iframe id="Iframe1" runat="server" width="100%" height="400Px" scrolling="auto" frameborder="0"></iframe>
   
        </td>
        </tr>
       
       
         <tr>
        <td>
        
                
            <asp:SqlDataSource ID="SqlBGGroup" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT [Id], [Symbol] As Symbol  FROM [BusinessGroup]">
            </asp:SqlDataSource>
                      
        
      </td>
        
        </tr>
        
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

