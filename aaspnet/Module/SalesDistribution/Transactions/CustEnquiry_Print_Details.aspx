<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustEnquiry_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 976px;
        }
        .style2
        {
            width: 100%;
            float: left;
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
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr height="21">
                        <th style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp; <strong> Customer Enquiry - Print</strong></th>
                    </tr>
                    <tr>
                        <td Height="320" align="center">
                   <asp:Panel ID="Panel1" runat="server" Width="100%" Height="450" ScrollBars="Auto">
                          
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
HasCrystalLogo="False" EnableParameterPrompt="False" />
                <CR:CrystalReportSource ID="CrystalReportSource1" runat="server" >
                </CR:CrystalReportSource>
                  </asp:Panel>
                        </td>
                    </tr>
                    
                     <tr>
                        <td align="center">
                            <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="redbox" 
                                onclick="Button1_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

