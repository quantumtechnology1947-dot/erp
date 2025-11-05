<%@ page language="C#" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ManPowerPlanning_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:auto;">  
 
            
 <table align="Left" cellpadding="0" cellspacing="0">
                <tr >
<td align="Left">
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
        AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1"  DisplayGroupTree="False"/>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="Module\ProjectManagement\Transactions\Reports\ManPowerPlanning.rpt">
            </Report>
        </CR:CrystalReportSource>
    
</td>
</tr>

</table>            
    </div>
    </form>
</body>


