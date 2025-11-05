<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_Dept_Print.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_Dept_Print" Theme ="Default"  %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
            AutoDataBind="True" Height="50px" 
            Width="350px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="~\Module\Accounts\Transactions\Reports\Budget_Dept.rpt">            
            </Report>
       </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
