<%@ page language="C#" autoeventwireup="true" inherits="Module_Inventory_Transactions_WISWONO_Print_, newerp_deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:auto;">  
    <table width="100%">
    <tr>
    <td align="Left">
     <CR:CrystalReportViewer ID="CrystalReportViewer1"  EnableDatabaseLogonPrompt="false" DisplayGroupTree="False"
      ReportSourceID="CrystalReportSource1"  runat="server" AutoDataBind="true" HasCrystalLogo="False" />
 <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
<Report FileName="~\Module\Inventory\Transactions\Reports\WONOWISe.rpt"></Report> 

</CR:CrystalReportSource>
    
    </td>
    </tr>
    </table>

          
    </div>
    </form>
</body>
</html>
