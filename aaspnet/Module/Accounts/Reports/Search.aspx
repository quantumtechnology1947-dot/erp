<%@ page language="C#" masterpagefile="~/MasterPage.master" culture="en-GB" autoeventwireup="true" inherits="Module_Accounts_Reports_Search, newerp_deploy" title="ERP" enableviewstate="true" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
    {
        height: 23px;
    }
        
        </style>
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
   
   
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
       
      
       
        <tr>
            <td align="left" valign="middle"  scope="col" height="21" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
        &nbsp;<b> Search </b></td>
        </tr></table>
          <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True">
                    <cc1:TabPanel runat="server" HeaderText="PVEV Search" ID="PVEVId">
                       
                        
<ContentTemplate><table  width="100%" align="center"><tr><td 
        colspan="2" style="width: 80%" width="40%">&#160;Enter No.&#160;&#160;&#160;<asp:DropDownList ID="Drpoption" runat="server" 
                    AutoPostBack="True" ><asp:ListItem Value="0">All</asp:ListItem><asp:ListItem Value="1">GQN No</asp:ListItem><asp:ListItem Value="2">GSN No</asp:ListItem><asp:ListItem Value="3">PO No</asp:ListItem><asp:ListItem 
            Value="4">PVEV No</asp:ListItem></asp:DropDownList>&#160;<asp:TextBox ID="txtNo" runat="server" CssClass="box3"></asp:TextBox>&#160;&#160; &#160; &#160;&#160; &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; Report For :<asp:RadioButton 
        ID="radGqn" runat="server" Checked="True" GroupName="ck" Text="GQN" 
        AutoPostBack="True" oncheckedchanged="radGqn_CheckedChanged" />
    <asp:RadioButton ID="radgsn" runat="server" GroupName="ck" Text="GSN" 
        AutoPostBack="True" oncheckedchanged="radgsn_CheckedChanged" />
    </td></tr><tr><td width="14%"><asp:CheckBox ID="CkItem" runat="server" Text="ItemCode" AutoPostBack="True" 
                oncheckedchanged="CkItem_CheckedChanged" />&#160;&#160; </td><td><asp:TextBox ID="txtItemcode" runat="server" CssClass="box3" Enabled="False"></asp:TextBox></td></tr><tr><td><asp:CheckBox ID="CKwono" runat="server" Text="WorkOrder No" 
            AutoPostBack="True" oncheckedchanged="CKwono_CheckedChanged" />&nbsp; </td><td><asp:TextBox ID="txtwono" runat="server" CssClass="box3" Enabled="False"></asp:TextBox></td></tr><tr><td><asp:CheckBox ID="CkSupplier" runat="server" Text="Supplier Name" 
            AutoPostBack="True" oncheckedchanged="CkSupplier_CheckedChanged" />&nbsp; </td><td><asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Enabled="False" 
                Width="375px"></asp:TextBox><cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                CompletionSetCount="1" DelimiterCharacters="" Enabled="True" 
                FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql" 
                ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                TargetControlID="TxtSearchValue" UseContextKey="True"></cc1:AutoCompleteExtender></td></tr><tr><td colspan="2"><asp:CheckBox ID="CkACCHead" runat="server" Text="Account Head" />&#160;&#160;&#160;&#160;&#160;&#160; <asp:RadioButton ID="RbtnLabour" runat="server" Text="Labour" 
                    GroupName="GroupACHead" AutoPostBack="True" Checked="True" 
                    oncheckedchanged="RbtnLabour_CheckedChanged" />&#160;&#160;&#160; <asp:RadioButton ID="RbtnWithMaterial" runat="server" Text="With Material"  GroupName="GroupACHead" AutoPostBack="True" 
                    oncheckedchanged="RbtnWithMaterial_CheckedChanged" />&#160;&#160;&#160;&#160;<asp:RadioButton ID="RbtnExpenses" runat="server" Text="Expenses"  GroupName="GroupACHead" AutoPostBack="True" 
                    oncheckedchanged="RbtnExpenses_CheckedChanged" />&#160;&#160;&#160;&#160;<asp:RadioButton ID="RbtnServiceProvider" runat="server" Text="Service Provider"  GroupName="GroupACHead" AutoPostBack="True" 
                    oncheckedchanged="RbtnServiceProvider_CheckedChanged" />&#160;&#160;&#160;&#160; <asp:DropDownList runat="server" CssClass="box3" ID="DropDownList1" ></asp:DropDownList></td></tr><tr><td colspan="2">Select Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From: <asp:TextBox ID="textFromDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="textFromDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="textFromDate"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="ReqTDate" runat="server" 
                    ControlToValidate="textFromDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="vdr"></asp:RegularExpressionValidator>To: <asp:TextBox ID="TextToDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="cd1" runat="server" Enabled="True" 
                    Format="dd-MM-yyyy" TargetControlID="TextToDate"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextToDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="vdr"></asp:RegularExpressionValidator><asp:CompareValidator 
            ID="CompareValidator1" runat="server" ControlToCompare="textFromDate" 
            ControlToValidate="TextToDate" 
            ErrorMessage="From date must greater than or equal to To date" 
            Operator="GreaterThanEqual" Type="Date" ValidationGroup="vdr"></asp:CompareValidator></td></tr><tr>
            
            <td colspan="2">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="RadGin" runat="server" Checked="True" 
            GroupName="APR" Text="Completed" />
        <asp:RadioButton ID="RadPO" runat="server" GroupName="APR" Text="Pending" />
        </td></tr>
    <tr>
        <td align="center" class="style4" colspan="2">
            <asp:Button ID="BtnSearch" runat="server" CssClass="redbox" 
                OnClick="BtnSearch_Click" Text="Search" ValidationGroup="vdr" />
        </td>
    </tr>
    </table>
                    </ContentTemplate>
    </cc1:TabPanel>
    
    </cc1:TabContainer>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

