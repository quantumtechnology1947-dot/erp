<%@ page language="C#" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ManPowerPlanning_Print_Details1, newerp_deploy" title="ERP" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:auto;">  
 
            
 <table align="center" cellpadding="0" cellspacing="0">
                <tr >
<td align="center">
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
        AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1"  DisplayGroupTree="False"/>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Module\ProjectManagement\Transactions\Reports\ManPowerPlanning1.rpt">
            </Report>
        </CR:CrystalReportSource>
    
</td>
</tr>
<tr>
            <td align="center" height="25px" valign="middle">
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" 
                    onclick="btnCancel_Click" />
              </td>
        </tr>
</table>            
    </div>
    </form>
</body>


