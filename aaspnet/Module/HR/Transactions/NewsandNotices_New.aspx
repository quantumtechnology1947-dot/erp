<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_NewsandNotices, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: right;
        }
        .style3
        {
            width: 120px;
        }
        .style4
        {
            width: 120px;
            height: 27px;
        }
        .style5
        {
            height: 27px;
        }
        .style6
        {
            width: 120px;
            height: 31px;
        }
        .style7
        {
            height: 31px;
        }
        .style8
        {
            width: 120px;
            height: 28px;
        }
        .style9
        {
            height: 28px;
        }
    </style>
    

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

    <table align="center" cellpadding="0" cellspacing="0" class="style2">
        
        <tr>
            <td>

    <table align="center" cellpadding="0" cellspacing="0" class="box3" style="width: 80%">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="2"><b>&nbsp;News & Notices - New</b></td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;
                Title</td>
            <td class="style5">
                <asp:TextBox ID="TxtNewsTitle" runat="server" CssClass="box3" Width="519px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTitle" runat="server" 
                    ControlToValidate="TxtNewsTitle" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3" valign="top">
                &nbsp;
                Description</td>
            <td>
                <asp:TextBox ID="txtNews" runat="server" Height="110px" TextMode="MultiLine" 
                    Width="521px" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTitle0" runat="server" 
                    ControlToValidate="txtNews" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;
                Date on Display</td>
            <td class="style7">
                From
                <asp:TextBox ID="TxtFromDate" runat="server" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="ReqTitle1" runat="server" 
                    ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="RegFromDateVal" runat="server" 
                    ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="A"></asp:RegularExpressionValidator>
                &nbsp;&nbsp;&nbsp;&nbsp; To
                <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="TxtFromDate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                &nbsp;<asp:TextBox ID="TxtToDate" runat="server" CssClass="box3"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate" >
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqTitle2" runat="server" 
                    ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegToDateVal" runat="server" 
                    ControlToValidate="TxtToDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="A"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style8">
                &nbsp;
                Upload File</td>
            <td class="style9">
                <asp:FileUpload ID="FileUpload1" runat="server" size="50"/>
            </td>
        </tr>
        <tr>
            <td class="style6">
                </td>
            <td class="style7">
               <%-- <asp:Button ID="BtnUpload" runat="server" Text="Proceed"  OnClientClick="return confirmationAdd()"
                    onclick="BtnUpload_Click" CssClass="redbox" ValidationGroup="A" />--%>
                     <asp:Button ID="BtnUpload" runat="server" Text="Proceed" 
                    onclick="BtnUpload_Click" CssClass="redbox" ValidationGroup="A" />
            </td>
        </tr>
        </table>
   
            </td>
        </tr>
    </table>
   
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

