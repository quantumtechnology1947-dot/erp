<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_Moving_NonMoving_Items, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
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
    <table align="center" cellspacing="1" class="style12" width="100%">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
    <table class="box3" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" 
                height="21" class="fontcsswhite" colspan="2"><b>&nbsp;Moving Non-Moving Items</b>
                &nbsp;</td>
        </tr>
        <tr>
            <td height="22" align="left" width="100">
                &nbsp;
                Financial Year</td>
            <td class="style13">
                From Date :
                <asp:Label ID="lblFromDate" runat="server" style="font-weight: 700"></asp:Label>
                &nbsp;To :
                <asp:Label ID="lblToDate" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="22" align="left">
                &nbsp;
                From Date&nbsp;</td>
            <td style="text-align: left" class="style21">
                <asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqFrDate" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
                -&nbsp; To
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
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
            <td height="22" align="left">
                &nbsp;
                Category</td>
            <td align="left">
                <asp:DropDownList ID="DrpCategory" runat="server" 
                    CssClass="box3" Height="21px" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" height="22">
                &nbsp;
                PO Rate</td>
            <td class="style13" align="left">
                <asp:RadioButtonList ID="RadRate" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal" style="margin-top: 0px" Height="28px" 
                    Width="291px">
                    <asp:ListItem Selected="True" Value="0">Max</asp:ListItem>
                    <asp:ListItem Value="1">Min</asp:ListItem>
                    <asp:ListItem Value="2">Average</asp:ListItem>
                    <asp:ListItem Value="3">Latest</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style24" height="22">
                </td>
            <td class="style25" align="left">
                <asp:RadioButtonList ID="RadMovingItem" runat="server" AutoPostBack="True" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="0" Selected="True">Moving Items</asp:ListItem>
                    <asp:ListItem Value="1">Non-Moving Items</asp:ListItem>
                </asp:RadioButtonList>
                </td>
        </tr>
        <tr>
            <td class="style22" height="24">
                </td>
            <td class="style23" align="left" valign="middle">
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

