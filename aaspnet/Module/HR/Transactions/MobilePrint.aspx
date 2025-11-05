<%@ page language="C#" autoeventwireup="true" inherits="Module_HR_Transactions_MobilePrint, newerp_deploy" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
</head>
<body>
    <form id="form1" runat="server" >
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
                    AutoDataBind="true" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False" 
            ReuseParameterValuesOnRefresh="True" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
           <Report FileName="~\Module\HR\Transactions\Reports\MobileBill.rpt"></Report>
        </CR:CrystalReportSource>
   
    </form>
</body>
</html>
