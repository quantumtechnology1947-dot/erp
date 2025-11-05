<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABCAnalysisABC.aspx.cs" Inherits="Module_Inventory_Reports_ABCAnalysis" Theme="Default" Title="ERP" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <table align="center" cellspacing="1" width="100%">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
    <table class="box3" cellpadding="0" cellspacing="0" align="center" width="50%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" 
                height="21" class="fontcsswhite" colspan="2"><b>&nbsp;ABC Analysis</b>
                &nbsp;</td>
        </tr>
        <tr>
            <td height="26" align="left">
                &nbsp;
                Financial Year</td>
            <td class="style13" align="left">
                From Date :
                <asp:Label ID="lblFromDate" runat="server" style="font-weight: 700"></asp:Label>
                &nbsp;To :
                <asp:Label ID="lblToDate" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="26" align="left">
                &nbsp;
                From Date</td>
            <td style="text-align: left" class="style21">
                <asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqFrDate" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
            &nbsp; -&nbsp;
                To&nbsp;
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="TxtTodate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqTODate" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td height="26" align="left">
                &nbsp;
                Category</td>
            <td align="left">
                <asp:DropDownList ID="DrpCategory" runat="server" 
                    CssClass="box3" Height="21px" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" Width="200px">
                </asp:DropDownList>
              <%--  <asp:RequiredFieldValidator ID="ReqCategory" runat="server" 
                    ControlToValidate="DrpCategory" ErrorMessage="*" InitialValue="Select" 
                    ValidationGroup="view"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="style10" height="24" align="left">
                &nbsp;
                PO Rate</td>
            <td class="style11" align="left">
                <asp:RadioButtonList ID="RadRate" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal" style="margin-top: 0px">
                    <asp:ListItem Selected="True" Value="0">Max</asp:ListItem>
                    <asp:ListItem Value="1">Min</asp:ListItem>
                    <asp:ListItem Value="2">Average</asp:ListItem>
                    <asp:ListItem Value="3">Latest</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style22" height="24" align="left">
                &nbsp; Class</td>
            <td class="style11" valign="bottom" align="left">
                &nbsp; A :&nbsp;
            <asp:TextBox ID="TxtboxA" runat="server" Width="51px">70</asp:TextBox>
        
                %&nbsp;<asp:RequiredFieldValidator ID="ReqA" runat="server" 
                    ControlToValidate="TxtboxA" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegA" runat="server" 
                    ControlToValidate="TxtboxA" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="view"></asp:RegularExpressionValidator>
&nbsp;B:
            <asp:TextBox ID="TxtboxB" runat="server" Width="51px">20</asp:TextBox>
        
        &nbsp;%<asp:RequiredFieldValidator ID="ReqB" runat="server" 
                    ControlToValidate="TxtboxB" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegB" runat="server" 
                    ControlToValidate="TxtboxB" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="view"></asp:RegularExpressionValidator>
                C:<asp:TextBox ID="TxtboxC" runat="server" Width="51px">10</asp:TextBox>
        
                %<asp:RequiredFieldValidator ID="ReqC" runat="server" 
                    ControlToValidate="TxtboxC" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegC" runat="server" 
                    ControlToValidate="TxtboxC" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="view"></asp:RegularExpressionValidator>
        
            </td>
        </tr>
        
        
        
        <tr>
            <td height="26">
                </td>
            <td class="style7" valign="middle">
&nbsp;<asp:Button ID="BtnView" runat="server" onclick="BtnView_Click" Text="Proceed" 
                    CssClass="redbox" ValidationGroup="view" />
                &nbsp;&nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

