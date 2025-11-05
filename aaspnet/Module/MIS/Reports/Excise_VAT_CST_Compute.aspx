<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MIS_Reports_Excise_VAT_CST_Compute, newerp_deploy" culture="en-GB" title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        
        <tr >
            <td valign="top">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True" ScrollBars="Auto" >
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>Excise/VAT/CST Computation
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
                    Operator="LessThanEqual" Type="Date" ValidationGroup="a1"></asp:CompareValidator>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" 
                    Visible="False" ></asp:Label>
                        
                        </td>
                </tr>
                             <tr>
                                 <td align="left">                                    
                                     
                                 <asp:Panel ID="Panel2" Width="100%" Height="410px" runat="server" ScrollBars="Auto">
                                     <asp:GridView ID="GridView1" runat="server">
                                     </asp:GridView>
                  
                  
                  
                                  <CR:CrystalReportSource ID="CrystalReportSource3"   runat="server">
                        <Report FileName="~/Module/MIS/Reports/Ex_Vat_CST_Computation.rpt">
                        </Report>
                    </CR:CrystalReportSource>
                    <CR:CrystalReportViewer ID="CrystalReportViewer3" EnableDrillDown="False"  Visible="False" 
                    runat="server" AutoDataBind="True" ReportSourceID="CrystalReportSource3" HasCrystalLogo="False"
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

