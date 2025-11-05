<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABCAnalysis_Details.aspx.cs" Inherits="Module_Inventory_Reports_ABCAnalysis_DetailsO" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    

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
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b> Stock Statement</b></td>
        </tr>
        <tr>
            <td align="center">
                       <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="445">                       
                       <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" HasCrystalLogo="False"
        AutoDataBind="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" Height="50px" 
                           Width="350px" ReuseParameterValuesOnRefresh="True" />
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="Stock_Statement.rpt"></Report>  
                    </CR:CrystalReportSource>
                    </asp:Panel>
                    </td>
                </tr> 
        <tr>
            <td align="center">
                       <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Cancel" 
                           onclick="Button1_Click" />
                    </td>
                </tr>
    </table>

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

