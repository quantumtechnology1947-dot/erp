<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_MobileBills_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
  
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" /> 

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

    <table width="100%" >
              
         <tr>
           
            <td align="left" valign="middle" colspan="3"  style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Mobile Bill - Print</b></td>
           
        </tr>
        <tr>
            <td align="left" colspan="3">
                <b>Month Of Bill&nbsp; </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    CssClass="box3" Width="100px">
                  
                </asp:DropDownList>  
            </td>
           
        </tr>
         
         <tr>
         <td  align="center">
         
         <iframe   src="" id="myframe"  runat="server"  width="100%" height="415" frameborder="0" >        
        </iframe> 
         </td>
         </tr>
 <%--   <tr>
        <td align="center">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="430" Width="100%">           
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" Height="50px" ReportSourceID="CrystalReportSource2" 
        Width="350px" DisplayGroupTree="False" EnableDatabaseLogonPrompt="False" 
        EnableParameterPrompt="False" />
    <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
        <Report FileName="~\Module\HR\Transactions\Reports\MobileBill.rpt"></Report>
    </CR:CrystalReportSource>
 </asp:Panel>
        </td>       
    </tr>--%>
    <tr>
     <td  align="center" valign="middle" height="25">
          </td>
    </tr>

       
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

