<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SSStock_Statement.aspx.cs" Inherits="Module_Inventory_Reports_STOCK_S" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" /> 
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    


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



 <table align="center" cellspacing="1">
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" align="center"  class="box3">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" 
                height="21" class="fontcsswhite" colspan="3"><b>&nbsp;Stock Statement</b>
                &nbsp;</td>
        </tr>
        <tr>
            <td height="21" align="left">
                &nbsp;
                <b>Financial Year</b></td>
            <td align="left" height="28" colspan="2">
                From Date :
                <asp:Label ID="lblFromDate" runat="server" style="font-weight: 700"></asp:Label>
                &nbsp;<b>To :</b>
                <asp:Label ID="lblToDate" runat="server" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="21" align="left">
                &nbsp;<b> Date&nbsp;From</b></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqFrDate" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
                &nbsp; -&nbsp; <b>To</b>&nbsp;
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="90px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="TxtTodate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqTODate" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td height="30" align="left">
                &nbsp;&nbsp;<b>PO Rate</b></td>
            <td align="left" valign="middle">
                <asp:RadioButtonList ID="RadRate" runat="server" 
                    RepeatDirection="Horizontal" style="margin-top: 0px">
                    <asp:ListItem Selected="True" Value="0">Max</asp:ListItem>
                    <asp:ListItem Value="1">Min</asp:ListItem>
                    <asp:ListItem Value="2">Average</asp:ListItem>
                    <asp:ListItem Value="3">Latest</asp:ListItem>
                    <asp:ListItem Value="4">Actual</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td align="left" valign="middle">
                &nbsp; <b>Over heads :</b>&nbsp;
                <asp:TextBox ID="txtOverheads" runat="server" CssClass="box3" Width="30px">20</asp:TextBox>
                &nbsp;%
                <asp:RegularExpressionValidator ID="RegtxtOverheads" runat="server" 
                    ControlToValidate="txtOverheads" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="ReqtxtOverheads" runat="server" 
                    ControlToValidate="txtOverheads" ErrorMessage="*" ValidationGroup="A">
                </asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td height="30" align="left">
                &nbsp;</td>
            <td align="left" valign="middle" colspan="2">
                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" Height="21px" Width="100px" ID="DrpType" OnSelectedIndexChanged="DrpType_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Value="Category">Category</asp:ListItem>
                            <asp:ListItem Value="WOItems">WO Items</asp:ListItem>
                        </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ReqCategory" runat="server" 
                    ControlToValidate="DrpType" ErrorMessage="*" InitialValue="Select" 
                    ValidationGroup="view"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="28">
                </td>
            <td align="left" colspan="2">
                <asp:DropDownList runat="server" CssClass="box3" Height="21px" Width="200px" ID="DrpCategory1" 
                            OnSelectedIndexChanged="DrpCategory1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" 
                            Width="200px" ID="DrpSearchCode" 
                            OnSelectedIndexChanged="DrpSearchCode_SelectedIndexChanged">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem>
                            <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>
                            <asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" 
                            Width="155px" ID="DropDownList3" style="margin-bottom: 0px">
                        </asp:DropDownList>
                        <asp:TextBox runat="server" CssClass="box3" Width="207px" 
                            ID="txtSearchItemCode"></asp:TextBox>
                    <asp:Button ID="BtnView" runat="server" onclick="BtnView_Click" Text="Proceed" 
                    CssClass="redbox" ValidationGroup="view" />
            &nbsp;</td>
        </tr>
        <tr>
            <td>
                </td>
            <td align="left" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

