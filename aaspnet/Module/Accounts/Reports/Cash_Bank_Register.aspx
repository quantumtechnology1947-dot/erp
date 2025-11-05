<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Reports_Cash_Bank_Register, newerp_deploy" title="ERP" theme="Default" culture="en-GB" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style2
        {
            font-weight: bold;
        }
        .style3
        {
            text-align: center;
        }
    .box3 {
border: 1px solid #C5C5C5;

}
    </style>
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
    <table cellpadding="0" cellspacing="0" class="fontcss" width="100%">
        <tr>
             <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Cash/Bank Register</b></td>
        </tr>
        <tr>
            <td class="style3" height="25">
                &nbsp;<asp:Label ID="Label2" runat="server" CssClass="style2" Text="Date From:"></asp:Label>
                &nbsp;<asp:TextBox ID="txtFD" runat="server" CssClass="box3" Width="80px" 
                    ValidationGroup="A"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFD" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtFD" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="A"></asp:RegularExpressionValidator>
                <cc1:CalendarExtender CssClass="cal_Theme2" ID="txtFD_CalendarExtender" runat="server" Enabled="True" 
                    Format="dd-MM-yyyy" TargetControlID="txtFD">
                </cc1:CalendarExtender>
&nbsp;-&nbsp;
                <asp:Label ID="Label3" runat="server" CssClass="style2" Text="To:"></asp:Label>
                <asp:TextBox ID="txtTo" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtTo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtTo" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="A"></asp:RegularExpressionValidator>
                <cc1:CalendarExtender CssClass="cal_Theme2" ID="txtTo_CalendarExtender" runat="server" Enabled="True" 
                    Format="dd-MM-yyyy" TargetControlID="txtTo">
                </cc1:CalendarExtender>
&nbsp; <asp:DropDownList 
        runat="server" AutoPostBack="true" CssClass="box3" ID="DropDownList3">
    </asp:DropDownList>&nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    onclick="Button1_Click" Text="Search" ValidationGroup="A" />               
            </td>
        </tr>
        <tr>
            <td align="center">
            <asp:Panel Height="420px" runat="server" Width="100%" ScrollBars="Auto">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" Visible="False"   
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource1" HasCrystalLogo="False"
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/Cash_Bank_Register.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    </asp:Panel>
                    </td>
        </tr>
    </table>
    <%--<asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank] order by OrdNo Asc" ID="SqlDataSource5">
    </asp:SqlDataSource>--%>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">    
</asp:Content>
