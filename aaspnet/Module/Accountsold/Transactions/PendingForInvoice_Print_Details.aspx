<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendingForInvoice_Print_Details.aspx.cs" Inherits="Module_Accounts_Transactions_PendingForInvoice_Print_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:auto;">  
    <table width="100%">
    <tr>
    <td align="center">
     <CR:CrystalReportViewer HasCrystalLogo="False" ID="CrystalReportViewer1"  EnableDatabaseLogonPrompt="false" DisplayGroupTree="False" ReportSourceID="CrystalReportSource1"  runat="server" AutoDataBind="true" EnableDrillDown="false" />
 <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
 <Report FileName="~/Module/Accounts/Reports/PendingForInvoice.rpt" > 
 </Report>
</CR:CrystalReportSource>
    
    </td>
    </tr>
    </table>

          
    </div>
    </form>
</body>
</html>
