<%@ page language="C#" autoeventwireup="true" inherits="Module_Accounts_Transactions_CreditorsDebitors_InDetailView, newerp_deploy" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style4
        { 
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal; 
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
            height: 21px;
        }
        .style5
        {
            font-weight: bold;
        }
    </style>
    
    <title>ERP</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table align="center" style="width: 100%" cellpadding="0" cellspacing="0">       
            <tr>
            <td align="center">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"  HasCrystalLogo="False"   BorderStyle="Solid" BorderColor="Black" BorderWidth="1" AutoDataBind="True"  ReportSourceID="CrystalReportSource1" EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" ReuseParameterValuesOnRefresh="True" HyperlinkTarget="_Parent"
                Height="50px" Width="100%" oninit="CrystalReportViewer1_Init" onload="CrystalReportViewer1_Load"/> 
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" >
                <Report FileName="~/Module/Accounts/Reports/CreditorsDebitors_InDetailList.rpt"></Report>
                </CR:CrystalReportSource> 
            </td>
            </tr>
        <tr>
        <td  align="center" height="28px" valign="middle">       
          
            </td>        
        </tr>
      
    </table>
    </div>
    </form>
</body>
</html>



    
    

