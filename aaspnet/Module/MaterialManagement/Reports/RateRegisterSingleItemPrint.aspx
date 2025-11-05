<%@ page language="C#" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_RateRegisterSingleItemPrint, newerp_deploy" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <title>ERP</title>
    </head>
<body style="margin-right:0; margin-left:0; margin-top:0; margin-bottom:0;">
<form id="Form1" runat="server">
<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">&nbsp;<b>Rate Register</b>
         </td>
        </tr>
       <td align="center">
         <asp:Panel ID="Panel1" runat="server" Height="430" ScrollBars="Auto" Width="100%" >
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                        AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
                        EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" 
                        DisplayGroupTree="False" Width="350px" 
                ReuseParameterValuesOnRefresh="True" />
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="~\Module\MaterialManagement\Reports\RateRegSingleItem.rpt">
                </Report>
                
            </CR:CrystalReportSource>
        </asp:Panel>
      </td>
       </table>
</form>    
</body>
</html>
