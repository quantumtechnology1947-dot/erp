<%@ page language="C#" autoeventwireup="true" inherits="Module_PopUpNews, newerp_deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

        #form1
        {
            height: 320px;
            width: 683px;
        }
        .style2
        {            height: 19px;
        }
        
        .style3
        {
            font-weight: bold;
        }
        
        .style4
        {
            width: 76px;
        }
        .style5
        {
            width: 76px;
            font-weight: bold;
        }
        
        .style6
        {
            color: #FFFFFF;
        }
        
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    
        <table align="left" cellpadding="2" class="fontcss" class="fontcss" 
            frame="border">
            <tr>
                <td class="style2" colspan="2" align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="2"><b>&nbsp;<span class="style6">News & Notices</span></b>
                    
                </td>
            </tr>
            <tr>
                <td style="background-color:Green; color:White;" class="style4">
                    <b>Title</b></td>
                <td>
                    <asp:Label ID="lblTitle" runat="server" style="font-weight: 700"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td align="right">
                    <b>Date:</b>
                    <asp:Label ID="lbldate" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp; 
                    <b>Time:</b>
                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5" style="background-color:Green; color:White;" valign="top">
                    In Details</td>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Height="226px" ScrollBars="Auto" 
                        Width="589px">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style3" align="center" colspan="2">
                    <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Close" 
                        onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>
