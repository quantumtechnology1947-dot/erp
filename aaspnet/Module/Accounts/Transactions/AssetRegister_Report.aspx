<%@ page language="C#" autoeventwireup="true" inherits="Module_Accounts_Transactions_AssetRegister_Report, newerp_deploy" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
     <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table align="left" cellpadding="0" cellspacing="0" width="100%">
 
        <tr>
            <td align="center" >
                <asp:Panel ID="Panel1" runat="server" width="100%" class="fontcss">
                <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"></asp:Label>
                </asp:Panel>
               
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/AssetRegister.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1"  HasCrystalLogo="False"
                    runat="server" AutoDataBind="true" ReportSourceID="CrystalReportSource1" 
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />                    
                    </td>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>

    </table>
                   
    </div>
    </form>
</body>
</html>
