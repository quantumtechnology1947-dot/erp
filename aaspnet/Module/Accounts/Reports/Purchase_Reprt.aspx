<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Reports_Purchase_Reprt, newerp_deploy" title="ERP" theme="Default" culture="en-GB" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>    
    <style type="text/css">
        .style2
        {
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

<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>

    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Purchase Report</b></td>
        </tr>
        <tr >
            <td valign="top">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True" ScrollBars="Auto" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>Excise
                    </HeaderTemplate>
<ContentTemplate>

 <table class="fontcss" width="100%" cellpadding="0" cellspacing="0">
                             <tr>
                    <td align="left">
                        <b>&nbsp;&nbsp;Date From: </b>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme2" ID="CalendarExtender3" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox3">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="*" ValidationGroup="a2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a2"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp; <b>To:</b>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme2" ID="CalendarExtender4" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox4">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="*" ValidationGroup="a2"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a2"></asp:RegularExpressionValidator>
                       
                       
                        <b>
                        <asp:Button ID="Btnsearch1" runat="server" ValidationGroup="a2" CssClass="redbox" 
                            OnClick="Btnsearch1_Click" Text="Search" />
                        </b>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToCompare="TextBox4" ControlToValidate="TextBox3" 
                    ErrorMessage="Invalid selected date range." 
                    Operator="LessThanEqual" Type="Date" ValidationGroup="a1" CssClass="style2"></asp:CompareValidator>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" 
                    Visible="False" CssClass="style2"></asp:Label>
                        
                        </td>
                </tr>
                             <tr>
                                 <td align="left">
                                 <asp:Panel ID="Panel2" Width="100%" Height="410px" runat="server" ScrollBars="Auto">
                                  <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/Purchase_Excise.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer3" Visible="False" 
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource3" HasCrystalLogo="False"
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                                 </asp:Panel>
                                 </td>
                             </tr>
                </table>

</ContentTemplate>
</cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="TabPanel2" Height="410px" ID="TabPanel2">
                        <HeaderTemplate>
VAT/CST                    
                    
                    </HeaderTemplate>
                        

<ContentTemplate>
                        <table class="fontcss" width="100%" cellpadding="0" cellspacing="0">
                             <tr>
                    <td align="left">
                        <b>&nbsp;&nbsp;Date From: </b>
                        <asp:TextBox ID="TxtFromDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme2" ID="TxtFromDate_CalendarExtender" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqFromDt" runat="server" 
                            ControlToValidate="TxtFromDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TxtFromDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp; <b>To:</b>
                        <asp:TextBox ID="TxtToDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme2" ID="TxtToDate_CalendarExtender" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqCate2" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                       
                        <b>
                        <asp:Button ID="Btnsearch" runat="server" ValidationGroup="a" CssClass="redbox" 
                            OnClick="Btnsearch_Click" Text="Search" />
                        </b>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TxtToDate" ControlToValidate="TxtFromDate" 
                    ErrorMessage="Invalid selected date range." 
                    Operator="LessThanEqual" Type="Date" ValidationGroup="a" CssClass="style2"></asp:CompareValidator>
                <asp:Label ID="lblsalemsg" runat="server" ForeColor="Red" 
                    Visible="False" CssClass="style2"></asp:Label>
                        
                        </td>
                </tr>
                             <tr>
                                 <td align="left">
                                 <asp:Panel Width="100%" Height="410px" runat="server" ScrollBars="Auto">
                                  <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/Purchase.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" Visible="False" 
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource1" HasCrystalLogo="False"
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                                 </asp:Panel>
                                 </td>
                             </tr>
                </table>
                        </ContentTemplate>
                    

</cc1:TabPanel>



 <cc1:TabPanel runat="server" HeaderText="TabPanel3" Height="410px" ID="TabPanel3">
                        <HeaderTemplate>
VAT/CST (Labour)                    
                    
                    </HeaderTemplate>
                        

<ContentTemplate>
                        <table class="fontcss" width="100%" cellpadding="0" cellspacing="0">
                             <tr>
                    <td align="left">
                        <b>&nbsp;&nbsp;Date From: </b>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme2" ID="CalendarExtender1" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox1">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="*" ValidationGroup="a1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a1"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp; <b>To:</b>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                        <cc1:CalendarExtender CssClass="cal_Theme2" ID="CalendarExtender2" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TextBox2">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="*" ValidationGroup="a1"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a1"></asp:RegularExpressionValidator>
                       
                        <b>
                        <asp:Button ID="Btnsearch2" runat="server" ValidationGroup="a1" CssClass="redbox" 
                            OnClick="Btnsearch2_Click" Text="Search" />
                        </b>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToCompare="TextBox2" ControlToValidate="TextBox1" 
                    ErrorMessage="Invalid selected date range." 
                    Operator="LessThanEqual" Type="Date" ValidationGroup="a1" CssClass="style2"></asp:CompareValidator>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                    Visible="False" CssClass="style2"></asp:Label>
                        
                        </td>
                </tr>
                             <tr>
                                 <td align="left">
                                 <asp:Panel ID="Panel1" Width="100%" Height="410px" runat="server" ScrollBars="Auto">
                                  <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
                        <Report FileName="~/Module/Accounts/Reports/Purchase.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer2" Visible="False" 
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource2" HasCrystalLogo="False"
                    DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" />
                                 </asp:Panel>
                                 </td>
                             </tr>
                </table>
                        </ContentTemplate>
                    

</cc1:TabPanel>



            
                </cc1:TabContainer>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

