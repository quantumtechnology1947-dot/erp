<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_NewsandNotices_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style4
        {
            width: 379px;
        }
        .style5
        {
            width: 141px;
        }
        .style8
        {
            width: 141px;
            height: 33px;
        }
        .style9
        {
            width: 379px;
            height: 33px;
        }
        .style12
        {
            width: 141px;
            height: 29px;
        }
        .style13
        {
            height: 29px;
        }
        .style19
        {
            width: 100%;
        }
        .style20
        {
            width: 141px;
            height: 34px;
        }
        .style21
        {
            width: 379px;
            height: 34px;
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

    <table align="center" cellpadding="0" cellspacing="0" class="style19">
        
        <tr>
            <td>

<table id="box3" align="center" cellpadding="0" cellspacing="0" width="100%" class="box3">
    <tr>
            <td  align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="2"><b>&nbsp;News & Notices - Edit</b></td>
        </tr>
    <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    <tr>
            <td class="style5">
                &nbsp; Title</td>
            <td>
                <asp:TextBox ID="TxtNewsTitle" runat="server" CssClass="box3" Height="18px" 
                    Width="519px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqTitle" runat="server" 
                    ControlToValidate="TxtNewsTitle" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
            <td class="style5" valign="top">
                &nbsp; Description</td>
            <td>
                <asp:TextBox ID="txtNews" runat="server" Height="110px" TextMode="MultiLine" 
                    Width="521px" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqDesc0" runat="server" 
                    ControlToValidate="txtNews" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
            </td>
        </tr>
    <tr>
            <td class="style8">
                &nbsp; Date on Display</td>
            <td class="style9">
                From
                <asp:TextBox ID="TxtFromDate" runat="server" Width="116px" 
                    CssClass="box3"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate" >
                </cc1:CalendarExtender>
&nbsp;<b><asp:RequiredFieldValidator ID="ReqFdate" runat="server" 
                    ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegFromDateVal" runat="server" 
                    ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="edit"></asp:RegularExpressionValidator>
                &nbsp;&nbsp; </b>
                To
                <asp:TextBox ID="TxtToDate" runat="server" Width="114px" 
                    CssClass="box3"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate" >
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqToDate" runat="server" 
                    ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ReqToDateVal" runat="server" 
                    ControlToValidate="TxtToDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="edit"></asp:RegularExpressionValidator>
            </td>
        </tr>
    <tr>
            <td class="style12">
                &nbsp; Upload File</td>
            <td class="style13">
                <asp:HyperLink ID="HyperLink1" runat="server">[HyperLink1]</asp:HyperLink>
                <asp:ImageButton ID="ImageCross" runat="server" ImageUrl="~/images/cross.gif" 
                    onclick="ImageCross_Click" Width="16px" />
                <asp:FileUpload ID="FileUpload1" runat="server" size="25"/>
            </td>
        </tr>
    <tr>
            <td class="style20">
                </td>
            <td class="style21" valign="middle">
                <asp:Button ID="BtnUpload" runat="server" Text="Update" OnClientClick="return confirmationUpdate()"
                    onclick="BtnUpload_Click" CssClass="redbox" ValidationGroup="edit" />
            &nbsp;<asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="redbox" 
                    onclick="BtnCancel_Click" />
            </td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

