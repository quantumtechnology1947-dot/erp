<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_WorkOrder_ReleaseRPT, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

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

    <table width="100%">
<tr>
<td height="21px" style="background:url(../../../images/hdbg.JPG)"  class="fontcsswhite">
    &nbsp;<strong>Work Order No. 
        <asp:Label ID="Label2" runat="server"></asp:Label> - Release </strong></td>
</tr>

<tr>
 
<td align ="left">
<asp:Panel ID="Panel1" ScrollBars="Auto" Height="205px" runat="server">
      

<asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
        Width="100%" PageSize="10" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="SN">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="4%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CK">
        <ItemTemplate>
       <asp:CheckBox ID="CheckBox1"  runat="server" 
        oncheckedchanged="CheckBox1_CheckedChanged"/>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="3%" />
        </asp:TemplateField>        
        <asp:TemplateField HeaderText="To Release Qty">
        <ItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server" Width="60%" CssClass="box3" OnTextChanged="TextBox1_OnTextChanged"/>
        
        <asp:RequiredFieldValidator ID="Req" runat="server" ControlToValidate="TextBox1"  ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegQty" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="8%" />
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Id" Visible="false" >
        <ItemTemplate>
        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
        </ItemTemplate>
        <ItemStyle Width="3%" />           
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Item Code">
        <ItemTemplate>
        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
        </ItemTemplate>           
             <ItemStyle Width="15%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description">
        <ItemTemplate>
        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
        </ItemTemplate>           
            <ItemStyle Width="35%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Qty">
        <ItemTemplate>
        <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
        </ItemTemplate>           
            <ItemStyle HorizontalAlign="Right" Width="8%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Released Qty">
        <ItemTemplate>
        <asp:Label ID="lblReleasedQty" runat="server" Text='<%#Eval("ReleasedQty") %>'></asp:Label>
        </ItemTemplate>           
            <ItemStyle HorizontalAlign="Right" Width="8%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remain Qty">
        <ItemTemplate>
        <asp:Label ID="lblRemainQty" runat="server" Text='<%#Eval("RemainQty") %>'></asp:Label>
        </ItemTemplate>           
            <ItemStyle HorizontalAlign="Right" Width="8%" />
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
  <br />
</td>

</tr>
<tr>
 
<td align="left">
<asp:Panel ID="Panel2" ScrollBars="Auto" Height="205px" runat="server">
    <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
        DataSourceID="SqlDataSource1" Width="70%" AutoGenerateColumns="False">
        <Columns>
        <asp:TemplateField HeaderText="SN">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="3%" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CK">
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox2" runat="server"/>
        </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
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
        SelectCommand="SELECT [EmpId], [EmployeeName], [EmailId1] FROM [tblHR_OfficeStaff] WHERE (([WR] = @WR) AND ([ResignationDate]='')AND ([CompId]=@CompId) AND(UserID !='1'))">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="WR" Type="Int32" />
            <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
            
        </SelectParameters>
    </asp:SqlDataSource>
     </asp:Panel>
    </td>

</tr>
<tr>
<td align="center" class="style2">
&nbsp;
<asp:Button ID="Submit" runat="server" ValidationGroup="A" CssClass="redbox" OnClientClick="return confDyna('Do you really want to released Work Order?')" onclick="Submit_Click" 
        Text="Submit" Height="20px" />
        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="redbox"  
        Text="Cancel" Height="20px" onclick="Button2_Click" />        
        
    </td>
</tr>         
</table>  

</ContentTemplate>
</asp:UpdatePanel>
</div>
 </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

