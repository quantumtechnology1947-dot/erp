<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_WorkOrder_Dispatch_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
   
    <style  type="text/css">
        .style2
        {
            text-align: left;
            width: 137px;
        }
        .style3
        {
            width: 137px;
        }
        .style4
        {
            width: 677px;
        }
        .fontcss
        {
            width: 291px;
        }
        .style5
        {
            text-align: left;
            width: 137px;
            height: 33px;
        }
        .style6
        {
            height: 33px;
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
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td align="left" colspan="2" height="21px" style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >
    &nbsp;<strong>Work Order - Dispatch</strong></td>

</tr>

<tr>
<td align="left" colspan="2">
<asp:Panel ID="Panel1" ScrollBars="Auto" Height="215px" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CssClass="yui-datatable-theme" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="SN">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CK">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" 
                        oncheckedchanged="CheckBox1_CheckedChanged" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="To DA Qty">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="box3" Width="60" />
                    <asp:RequiredFieldValidator ID="Req" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="*" ValidationGroup="A">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                    </asp:RegularExpressionValidator>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Item Code">
                <ItemTemplate>
                    <asp:Label ID="lblic" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="14%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty">
                <ItemTemplate>
                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Released Qty">
                <ItemTemplate>
                    <asp:Label ID="lblrelqty" runat="server" Text='<%#Eval("ReleasedQty") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DA Total Qty">
                <ItemTemplate>
                    <asp:Label ID="lbldaqty" runat="server" Text='<%#Eval("DATotalQty") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DA Remain Qty">
                <ItemTemplate>
                    <asp:Label ID="lbldaremqty" runat="server" Text='<%#Eval("DARemainQty") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ItemId" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblitemid" runat="server" Text='<%#Eval("ItemId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <table class="fontcss" width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                            Text="No data to display !"> </asp:Label>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Panel>
<br />
    
</td>

</tr>

<tr>

<td align="center" class="style4" valign="top">
<asp:Panel ID="Panel2" ScrollBars="Auto" Height="205px" runat="server">
    <asp:GridView ID="GridView2" runat="server"  
        CssClass="yui-datatable-theme" Width="100%"
        DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
        <Columns>    
           <asp:TemplateField HeaderText="SN">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
               <ItemStyle HorizontalAlign="Right" Width="4%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CK">
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox2" runat="server"/>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="3%" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Name of Employee">
        <ItemTemplate>
          <asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("EmployeeName") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="20%" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Emp Id">
        <ItemTemplate>
          <asp:Label ID="lblEmpId" runat="server" Text='<%#Eval("EmpId") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Email Id">
        <ItemTemplate>
          <asp:Label ID="lblEmailId" runat="server" Text='<%#Eval("EmailId1") %>'></asp:Label>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="15%" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
        SelectCommand="SELECT [EmpId], [EmployeeName], [EmailId1] FROM [tblHR_OfficeStaff] WHERE (([DA] = @DA) AND ([ResignationDate]='') AND ([CompId]=@CompId) AND(UserID !='1'))">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="DA" Type="Int32" />
           <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </asp:Panel>
    </td>

<td align="left" valign="top">
    <table cellpadding="2" cellspacing="0" class="fontcss"  align="center">
        <tr>
            <td class="style2">
                <label>
                <strong>Freight Charges by</strong></label>
            </td>
            <td>
                <asp:RadioButton ID="FCustomer" runat="server" Checked="True" 
                    GroupName="FCust" Text="Customer" />
            </td>
            <td>
                <asp:RadioButton ID="FSelf" runat="server" GroupName="FCust" 
                    Text="Self" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <strong>Vehicle by</strong></td>
            <td>
                <asp:RadioButton ID="VCustomer" runat="server" Checked="True" 
                    GroupName="VCust" Text="Customer" />
            </td>
            <td>
                <asp:RadioButton ID="VSelf" runat="server" GroupName="VCust" 
                    Text="Self" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                <strong>Octroi Charges by</strong></td>
            <td>
                <asp:RadioButton ID="OCustomer" runat="server" Checked="True" 
                    GroupName="OCust" Text="Customer" />
            </td>
            <td>
                <asp:RadioButton ID="OSelf" runat="server" GroupName="OCust" 
                    Text="Self" />
            </td>
        </tr>
       
    </table>
    </td>
</tr>

 <tr>
    <td  align="center" colspan="2" height="30" valign="middle">
    <asp:Button ID="Submit" runat="server" CssClass="redbox" ValidationGroup="A" OnClientClick="return confDyna('Do you really want to Dispatch this Work Order?')" onclick="Submit_Click" Text="Submit" Height="21px"/>
    <asp:Button ID="Cancel" runat="server" CssClass="redbox"  Text="Cancel"  
    Height="21px" onclick="Cancel_Click"/>   
    </td>
 </tr>

</table>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

