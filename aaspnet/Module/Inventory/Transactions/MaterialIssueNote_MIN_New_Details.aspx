<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialIssueNote_MIN_New_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style2
        {
            width: 100%;
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
var prm = Sys.WebForms.PageRequestManager.getInstance();
//Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
prm.add_beginRequest(BeginRequestHandler);
// Raised after an asynchronous postback is finished and control has been returned to the browser.
prm.add_endRequest(EndRequestHandler);
function BeginRequestHandler(sender, args) {
//Shows the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.show();
}
}

function EndRequestHandler(sender, args) {
//Hide the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.hide();
}
}
</script>
    
<div>   
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
<asp:Image ID="Image1" ImageUrl="~/images/spinner-big.gif" AlternateText="Processing" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>
<cc1:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
<asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
   <ContentTemplate>  
   
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Issue Note [MIN] - New</b></td>
        </tr>
        <tr>
            <td> 
                <asp:Panel ID="Panel1" Height="445px" ScrollBars="Auto" runat="server">
              
            <asp:GridView runat="server" AutoGenerateColumns="False" 
                                            ShowFooter="false" CssClass="yui-datatable-theme" Width="100%" ID="GridView3" 
                                            OnPageIndexChanging="GridView3_PageIndexChanging" PageSize="15">
                                            <PagerSettings PageButtonCount="40" />
                                            <Columns>
<asp:TemplateField HeaderText="SN"><ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                                        <asp:CheckBox ID="ck" runat="server" />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate>
<asp:Label ID="lblitemid" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                                                    
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="ItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle Width="13%" HorizontalAlign="Center"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description"><ItemTemplate>
                                                        <asp:Label ID="ManfDesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
                                                        <asp:Label ID="UOMBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="BG Group"><ItemTemplate>
                                                        <asp:Label ID="lbldept" runat="server" Text='<%# Eval("Dept") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="WO No"><ItemTemplate>
                                                        <asp:Label ID="lblWONO" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                        
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Stk Qty"><ItemTemplate>
                                                        <asp:Label ID="lblstkqty" runat="server" Text='<%# Eval("StockQty") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Req. Qty"><ItemTemplate>
                                                        <asp:Label ID="lblreqty" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>
                                                        
                                                    
</ItemTemplate>

<ItemStyle Width="7%" HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
                                            <asp:TemplateField HeaderText="Issued Qty">
                                            <ItemTemplate>
                                                        <asp:Label ID="lblissty" runat="server" Text='<%# Eval("IssQty") %>'></asp:Label>
                                                        
                                                    
</ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="8%" />
                                            </asp:TemplateField>
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
                                                       <asp:Label ID="lblremrk" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label> 
                                                    
                                                    
</ItemTemplate>
<FooterTemplate>
                                                    
                                                    
</FooterTemplate>
    <ItemStyle Width="20%" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate>
                                                       <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label> 
                                                    
</ItemTemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
</asp:GridView>  
                </asp:Panel>

            </td>
        </tr>
        <tr>
            <td align="center" height="25" valign="middle">&nbsp; <asp:Button ID="btnProceed" 
                    runat="server" CssClass="redbox" Text="Generate MIN" OnClientClick="return confirmationAdd()
" 
                    onclick="btnProceed_Click" />&nbsp;<asp:Button ID="btnCancel" 
                    runat="server" CssClass="redbox" Text="Cancel" onclick="btnCancel_Click" />&nbsp;</td>
        </tr>
    </table>
    
    </ContentTemplate>
    </asp:UpdatePanel>
</div>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

