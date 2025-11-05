<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CPO_PR_Print_Page.aspx.cs" Inherits="Module_MaterialManagement_Transactions_PO_PR_Print_Page" Theme="Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body style="margin-bottom:0; margin-left:0; margin-right:0; margin-top:0;">
    <form id="form1" runat="server">
   <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="~/Module/MaterialManagement/Transactions/Reports/OLDPO.rpt"></Report>
    </CR:CrystalReportSource>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" HasCrystalLogo="False"
    runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
    EnableParameterPrompt="False"/>       
    </form>
</body>
</html>
