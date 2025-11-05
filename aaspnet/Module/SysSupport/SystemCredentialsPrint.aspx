<%@ page language="C#" autoeventwireup="true" inherits="Module_SysSupport_SystemCredentialsPrint, newerp_deploy" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
    <tr>
    <td align="center"> <asp:Panel ID="Panel4" ScrollBars="Auto" Height="390px" runat="server">
     <CR:CrystalReportViewer ID="CrystalReportViewer1"  
            EnableDatabaseLogonPrompt="False" DisplayGroupTree="False"
      ReportSourceID="CrystalReportSource1"  runat="server" AutoDataBind="True" 
            HasCrystalLogo="False" />
 <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
<Report FileName="~\Module\SysSupport\AuthorityAuthorizationForm.rpt"></Report> 

</CR:CrystalReportSource>
    </asp:Panel> 
    </td>
    </tr>
     
    </table>    
    </div>
    </form>
</body>
</html>
