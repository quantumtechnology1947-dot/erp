<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sales_Register.aspx.cs" Inherits="Module_Accounts_Reports_Sales_Register" Title="ERP" Theme="Default" Culture="en-GB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <style type="text/css">
        .style4
        {
            font-weight: bold;
        }
        .style5
        {
            color: #FF0000;
            font-weight: bold;
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
    <table  width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Sales Register</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">                      
                    <HeaderTemplate>Sales</HeaderTemplate>                    

<ContentTemplate>

    
    <table class="fontcss" width="100%">
        <tr>
            <td>
                <asp:Label ID="lblFrmDt" runat="server" Font-Bold="True" Text="From Date :"></asp:Label>
                <asp:TextBox ID="TxtChequeDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtChequeDate_CalendarExtender" runat="server" 
                    CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" 
                    TargetControlID="TxtChequeDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqChequeDate" runat="server" 
                    ControlToValidate="TxtChequeDate" ErrorMessage="*" ValidationGroup="M"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegBillDate0" runat="server" 
                    ControlToValidate="TxtChequeDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="M"></asp:RegularExpressionValidator>
                <asp:Label ID="lblToDt" runat="server" Font-Bold="True" Text="TO :"></asp:Label>
                <asp:TextBox ID="TxtClearanceDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtClearanceDate_CalendarExtender" runat="server" 
                    CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" 
                    TargetControlID="TxtClearanceDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqClearanceDate" runat="server" 
                    ControlToValidate="TxtClearanceDate" ErrorMessage="*" ValidationGroup="M"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegBillDate" runat="server" 
                    ControlToValidate="TxtClearanceDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="M"></asp:RegularExpressionValidator>
                <asp:Button ID="BtnView" runat="server" CssClass="redbox" 
                    OnClick="BtnView_Click" Text="View" ValidationGroup="M" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TxtClearanceDate" ControlToValidate="TxtChequeDate" 
                    CssClass="style4" ErrorMessage="Invalid selected date range." 
                    Operator="LessThanEqual" Type="Date" ValidationGroup="M"></asp:CompareValidator>
                <asp:Label ID="lblsalemsg" runat="server" CssClass="style5" ForeColor="Red" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    
    
     <asp:Panel ID="Panel1"  Height="400px" ScrollBars="Auto" runat="server" Width="100%" >
<CR:CrystalReportViewer ID="CrystalReportViewer1"   HasCrystalLogo="False"
        AutoDataBind="True" 
        ReportSourceID="CrystalReportSource1" runat="server"  
             EnableParameterPrompt="False" Visible="False"
        EnableDatabaseLogonPrompt="False" DisplayGroupTree="False" 
        ReuseParameterValuesOnRefresh="True"  Width="100%" 
              />
    <CR:CrystalReportSource  ID="CrystalReportSource1"  runat="server">
        <Report FileName="~/Module/Accounts/Reports/SalesExise_Print.rpt">
        </Report>
    </CR:CrystalReportSource> 
</asp:Panel>
    

</ContentTemplate>
</cc1:TabPanel>

<cc1:TabPanel runat="server" HeaderText="" ID="TabPanel1">                      
 <HeaderTemplate>Excise</HeaderTemplate>                    

<ContentTemplate>

<table width="100%" class="fontcss">
                             <tr>
                    <td align="left" width="100">
                        <b>&nbsp;&nbsp; From Date: </b></td>
                    <td align="left" height="26">
            <asp:TextBox ID="TxtExFrDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender1"  CssClass="cal_Theme2" runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtExFrDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtExFrDate" 
                            ErrorMessage="*" ValidationGroup="b"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="TxtExFrDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="b"></asp:RegularExpressionValidator>                        
                        <b>To</b>
            <b>:</b>
            <asp:TextBox ID="txtExToDt" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme2"  runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtExToDt">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtExToDt" ErrorMessage="*" ValidationGroup="b"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtExToDt" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="b"></asp:RegularExpressionValidator>
                        <b>
                        <asp:Button ID="btnExcise" runat="server" CssClass="redbox" 
                            onclick="btnExcise_Click" Text="View" ValidationGroup="b" />
                        <b>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" 
                            ControlToCompare="txtExToDt" ControlToValidate="TxtExFrDate" 
                            ErrorMessage="Invalid selected date range." 
                            Operator="LessThanEqual" Type="Date" ValidationGroup="b"></asp:CompareValidator>
                        <asp:Label ID="lblexcisemsg" runat="server" CssClass="style5" ForeColor="Red" 
                            Visible="False"></asp:Label>
                        </b>
                        </b>
                        </td>
                </tr>                            
                </table>
                
                <asp:Panel ID="Panel3" runat="server" Height="400px" ScrollBars="Auto" 
                    Width="100%">
                    <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/SalesEx_Print.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer3" HasCrystalLogo="False"
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource3"  Visible="False"
                    DisplayGroupTree="False" 
                    EnableParameterPrompt="False" />
                </asp:Panel>
</ContentTemplate>
</cc1:TabPanel>


<cc1:TabPanel runat="server" HeaderText="Payment" ID="TabPanel2">                      
 <HeaderTemplate>VAT/CST</HeaderTemplate>                    

<ContentTemplate>
 <table width="100%" class="fontcss">
                             <tr>
                    <td align="left" width="100">
                        <b>&nbsp;&nbsp; From Date: </b></td>
                    <td align="left" height="26">
            <asp:TextBox ID="TxtFromDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender"  CssClass="cal_Theme2" runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqFromDt" runat="server" ControlToValidate="TxtFromDate" 
                            ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TxtFromDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                                                <b>To</b>
            <b>:</b>
            <asp:TextBox ID="TxtToDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" CssClass="cal_Theme2"  runat="server" 
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqCate2" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        <b>
                        <asp:Button ID="Btnsearch" runat="server" CssClass="redbox" 
                            onclick="Btnsearch_Click" Text="View" ValidationGroup="a" />
                        <b>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToCompare="TxtToDate" ControlToValidate="TxtFromDate" 
                            ErrorMessage="Invalid selected date range." 
                            Operator="LessThanEqual" Type="Date" ValidationGroup="a"></asp:CompareValidator>
                        <b>
                        <asp:Label ID="lblvatcstmsg" runat="server" CssClass="style5" ForeColor="Red" 
                            Visible="False"></asp:Label>
                        </b>
                        </b>
                        </b>
                        </td>
                </tr>                            
                </table>
                
                <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Auto" 
                    Width="100%">
                    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/Sales_Vat.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer2" HasCrystalLogo="False"
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource2"  Visible="False"
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                </asp:Panel>
                    
</ContentTemplate>
</cc1:TabPanel>

</cc1:TabContainer>
</td>
</tr>

</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

