<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_CustomerChallan_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

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

    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    
      <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" 
       >
                    <cc1:TabPanel runat="server" HeaderText="Customer Challan" ID="Add">                    
<ContentTemplate><asp:Panel ID="Panel2" ScrollBars="Auto" runat="server"><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td height="5px" ></td></tr><tr><td align="left"  valign="top"><table align="left" cellpadding="0" cellspacing="0" width="100%" ><tr><td valign="top" align="center"  ><asp:Panel ID="Panel1" ScrollBars="Auto" Height="430px" runat="server"><CR:CrystalReportViewer 
        ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="True" EnableDatabaseLogonPrompt="False" 
                    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource1" HasCrystalLogo="False"
                    DisplayGroupTree="False" /><CR:CrystalReportSource ID="CrystalReportSource1" runat="server"><Report FileName="Module\Inventory\Transactions\Reports\CustomerChallan.rpt"></Report></CR:CrystalReportSource></asp:Panel></td></tr><tr><td valign="top" align="center"  ><asp:Button ID="Btncancel"  runat="server"  CssClass="redbox" 
                                            Text="Cancel" onclick="Btncancel_Click"  /></td></tr></table></td></tr></table></asp:Panel></ContentTemplate></cc1:TabPanel>
    
       <cc1:TabPanel ID="View" runat="server" HeaderText="Clear Challan">
                    <ContentTemplate><asp:Panel ID="Panel3" ScrollBars="Auto" runat="server"><table align="left" width="100%" cellpadding="0" cellspacing="0" ><tr><td height="5px" ></td></tr><tr><td align="left"  valign="top"><table align="left" cellpadding="0" width="100%" cellspacing="0" ><tr><td valign="top" align="center"  ><asp:Panel ID="Panel4" ScrollBars="Auto" Height="430px" runat="server"><CR:CrystalReportViewer ID="CrystalReportViewer2" runat="server" 
                    AutoDataBind="True" EnableDatabaseLogonPrompt="False" HasCrystalLogo="False"
                    EnableParameterPrompt="False" ReportSourceID="CrystalReportSource2" 
                    DisplayGroupTree="False"  /><CR:CrystalReportSource ID="CrystalReportSource2" runat="server"><Report FileName="Module\Inventory\Transactions\Reports\CustomerChallan_Clear.rpt"></Report></CR:CrystalReportSource></asp:Panel></td></tr><tr><td valign="top" align="center"  >&#160;<asp:Button ID="BtnCancel1"  runat="server"  CssClass="redbox" 
                                            Text="Cancel" onclick="BtnCancel1_Click"  /></td></tr></table></td></tr></table></asp:Panel>
                    </ContentTemplate>
                    </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>


