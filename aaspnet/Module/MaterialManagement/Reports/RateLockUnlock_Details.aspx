<%@ page language="C#" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_RateLockUnlock_Details, newerp_deploy" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        #form1
        {
            width: 1104px;
            height: 279px;
        }
      
    </style>
   
</head>
<body style="margin-bottom:0; margin-left:0; margin-right:0; margin-top:0;">
    <form id="form1" runat="server">
    
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"  Width="100%"
                    AutoDataBind="true" ReportSourceID="CrystalReportSource1" HasCrystalLogo="False"
                    EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" 
                    DisplayGroupTree="False" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                    <Report FileName="Module\MaterialManagement\Reports\RateLockUnlock.rpt">
                        
                    </Report>
                </CR:CrystalReportSource>
                
            </td>
        </tr>
        </table>
    
    </form>
</body>
</html>
