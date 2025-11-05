<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass_Report.aspx.cs" Inherits="Module_ProjectManagement_Transactions_GatePass_Report" Title="ERP" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

<table align="left" cellpadding="0" cellspacing="0" width="100%">
   <tr>
            <td align="center" >
                <asp:Panel ID="Panel1" runat="server" width="100%" class="fontcss">
                </asp:Panel>
               
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="~/Module/Inventory/Transactions/Reports/ReturnablePass.rpt">
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

<div style="text-align:center">
    <asp:Button ID="Button1" runat="server" Text="Cancel" BackColor="red" OnClick="cancel" ForeColor="white" Width="10%" />
</div>
<asp:TextBox runat="server" ID="text1" Text="test" Visible="false"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

