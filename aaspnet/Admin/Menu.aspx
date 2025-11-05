<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_Default, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .box3
        {
            width: 287px;
        }
        .style3
        {
            height: 25px;
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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" class="box3">
                    <tr>
                        <td colspan="2" style="background:url('../images/hdbg.JPG')" height="21" class="fontcsswhite">&nbsp;<strong> ERP Owner </strong></td>
                    </tr>
                    <tr>
                        <td class="style3" >
                            </td>
                        <td class="style3">
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl="~/Module/SysSupport/SysConfig/config.aspx">System configuration</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            <asp:HyperLink ID="HyperLink2" runat="server" 
                                NavigateUrl="~/Admin/Access/Module.aspx">Module</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            <asp:HyperLink ID="HyperLink3" runat="server" 
                                NavigateUrl="~/Admin/Access/SubModule.aspx">Sub Module</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td height="25">
                            <asp:HyperLink ID="HyperLink4" runat="server" 
                                NavigateUrl="~/Admin/Access/SubModuleLink.aspx">Sub Module Link</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

