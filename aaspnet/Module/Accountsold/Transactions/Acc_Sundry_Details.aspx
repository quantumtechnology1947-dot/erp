<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Acc_Sundry_Details.aspx.cs" Inherits="Module_Accounts_Transactions_Acc_Sundry_Details" Title="ERP" Theme="Default" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    
    <table width="100%">
   
   <tr>
   <td align="center">
    <asp:Panel ID="Panel1" ScrollBars="Auto"  Width="100%" Height="460px"  runat="server">
   
     <CR:CrystalReportViewer ID="CrystalReportViewer1"    HasCrystalLogo="False"
             AutoDataBind="True" 
        ReportSourceID="CrystalReportSource1" runat="server" 
        EnableDatabaseLogonPrompt="true" DisplayGroupTree="False" 
        ReuseParameterValuesOnRefresh="True"  Width="100%" 
             />
    <CR:CrystalReportSource  ID="CrystalReportSource1"   runat="server">
        <Report FileName="Acc_Sundry_Dr_Details.rpt">
        </Report>
    </CR:CrystalReportSource>  
    </asp:Panel>
   </td>
   </tr>
   
   <tr>
   <td  align="center" style="height:25px; ">   
       <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Cancel" 
           onclick="btnCancel_Click" /></td>
   </tr>
   
   </table>   

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

