<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_OnSiteAttendance_Print, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
           
            <td align="left"  
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" width="100%" colspan="7"><b>&nbsp;Onsite Attendance</b></td>
           
        </tr>
        <tr valign="bottom">           
           
           <td align="left" height="25px" valign="bottom">
                &nbsp;Year:&nbsp;<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                    CssClass="box3" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                    Width="100px">
                </asp:DropDownList>
            </td>
            <td align="left" valign="bottom">
                &nbsp;Month:&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"                     
                    CssClass="box3" Width="100px">
                  
                </asp:DropDownList>  
            </td> 
            <td align="left" valign="bottom">
                From Date: <asp:TextBox ID="txtFromDate" CssClass="box3" runat="server" 
                    Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomRight"
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFromDate">
                        </cc1:CalendarExtender>
            </td>
           
            <td align="left" valign="bottom">
                To Date: <asp:TextBox ID="txtToDate" CssClass="box3" runat="server" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomRight" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtToDate">
                </cc1:CalendarExtender>
            </td>
           
            <td align="left" valign="bottom">
                Employee&nbsp; Name: <asp:TextBox ID="txtEmpCode" CssClass="box3" runat="server"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="Txt_AutoCompleteExtender" runat="server" 
                        CompletionInterval="100"
                         CompletionListCssClass="almt2" 
                        CompletionListHighlightedItemCssClass="bgtext"
                         CompletionListItemCssClass="bg" 
                        CompletionSetCount="2"
                         DelimiterCharacters="" Enabled="True" 
                        FirstRowSelected="True" 
                        MinimumPrefixLength="1" ServiceMethod="sql3" 
                        ServicePath=""
                         ShowOnlyCurrentWordInCompletionListItem="True" 
                        TargetControlID="txtEmpCode" UseContextKey="True">
                    </cc1:AutoCompleteExtender>
            </td>
           
            <td align="left" valign="bottom">
                BG Group: <asp:DropDownList ID="DrpBGGroup" runat="server">
                </asp:DropDownList>
            </td>
           
            <td align="left" valign="bottom">
                <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="redbox" 
                    onclick="BtnSearch_Click" />
            </td>
            
           
        </tr>       
        <tr valign="bottom">           
           
           <td align="left" colspan="7">
                &nbsp;</td>
            
           
        </tr>       
        
        <tr valign="bottom">  
           <td align="center" colspan="7">
             <iframe id="Iframe1"  runat ="server" width="100%" height="400px" frameborder="0" scrolling="auto" ></iframe>
           </td> 
        </tr>         
        </table>
        
    
       

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

