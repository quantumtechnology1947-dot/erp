<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_OverallRating, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .style2
    {
        width: 100%;
        float: left;
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr> 
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Overall Supplier Rating</b></td>
        </tr>
        <tr>
            <td>
   
    
    <CR:CrystalReportViewer ID="CrystalReportViewer1"  
        ReportSourceID="VendorRating"  EnableDatabaseLogonPrompt="False" HasCrystalLogo="False"
        ReuseParameterValuesOnRefresh="True" runat="server" 
    AutoDataBind="True" DisplayGroupTree="False" />
    <CR:CrystalReportSource ID="VendorRating"  runat="server">
        <Report FileName="Module\MaterialManagement\Reports\OverallRating.rpt">
        </Report>
    </CR:CrystalReportSource> 
    </td>
    </tr>
              
        <tr>
            <td align="center" height="25">
            <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Cancel" onclick="Button1_Click"/>
                            
             </td>
             </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

