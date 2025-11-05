<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_New_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style8
        {  
        	text-align: left;
        }
        .style10
        {
            text-align: left;
            height: 31px;
        }
        .style12
        {
            width: 82px;
            height: 23px;
        }
        .style13
        {
            width: 35px;
            height: 23px;
        }
        .style14
        {
            width: 63px;
            height: 23px;
        }
        .style15
        {
            width: 141px;
            height: 23px;
        }
        .style16
        {
            height: 23px;
        }
        .style17
        {
            text-align: left;
            height: 22px;
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
    <table align="center" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Received Receipt [GRR] - New</b></td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                <table align="center" cellpadding="0" cellspacing="0" class="style2" 
                    __designer:mapid="729"><tr __designer:mapid="72a"><td class="style8" 
                            __designer:mapid="72b"><table cellpadding="0" cellspacing="0" 
                            class="style2" __designer:mapid="72c"><tr __designer:mapid="72d">
                                <td class="style14" __designer:mapid="72e">&nbsp; GIN No</td>
                                <td __designer:mapid="72f" class="style15"><asp:Label runat="server" Font-Bold="True" ID="lblGIn"></asp:Label>
</td><td class="style12" __designer:mapid="731">Challan No</td><td __designer:mapid="732" class="style16"><asp:Label runat="server" Font-Bold="True" ID="lblChNo"></asp:Label>
</td><td class="style13" __designer:mapid="734">Date</td><td __designer:mapid="735" class="style16"><asp:Label runat="server" Font-Bold="True" ID="lblDate"></asp:Label>
</td></tr></table></td></tr><tr __designer:mapid="737"><td class="style17" __designer:mapid="738">&nbsp; Supplier&nbsp;&nbsp; &nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblSupplier"></asp:Label>
</td></tr><tr __designer:mapid="73a"><td class="style10" __designer:mapid="73b">&nbsp; Tax Invoice No.: 
                        <asp:TextBox runat="server" CssClass="box3" ID="txtTaxInvoice" 
                            ValidationGroup="A"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="txtTaxInvoice" ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator1"></asp:RequiredFieldValidator>
&nbsp;&nbsp; Date: <asp:TextBox runat="server" CssClass="box3" ID="txtDate" Width="80px" 
                            ValidationGroup="A"></asp:TextBox>
<cc1:CalendarExtender runat="server" Enabled="True" TargetControlID="txtDate" CssClass="cal_Theme2" PopupPosition="BottomRight"
                            ID="txtDate_CalendarExtender" Format="dd-MM-yyyy"></cc1:CalendarExtender>
&nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator2"></asp:RequiredFieldValidator>
&nbsp;&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="A"></asp:RegularExpressionValidator>
&nbsp;MODVAT Applicable: <asp:DropDownList runat="server" CssClass="box3" ID="drpModVat">
<asp:ListItem Value="Select">Select</asp:ListItem>
<asp:ListItem Value="0">No</asp:ListItem>
<asp:ListItem Value="1">Yes</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator runat="server" ControlToValidate="drpModVat" InitialValue="Select" ErrorMessage="*" ValidationGroup="A" ID="ReqModVat"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp; MODVAT Invoice: <asp:DropDownList runat="server" CssClass="box3" ID="drpModVatInvoice">
<asp:ListItem Value="Select">Select</asp:ListItem>
<asp:ListItem Value="0">No</asp:ListItem>
<asp:ListItem Value="1">Yes</asp:ListItem>
</asp:DropDownList>
<asp:RequiredFieldValidator runat="server" ControlToValidate="drpModVatInvoice" InitialValue="Select" ErrorMessage="*" ValidationGroup="A" ID="ReqModVatInvoice"></asp:RequiredFieldValidator>
&nbsp;
</td></tr><tr __designer:mapid="743"><td class="style10" __designer:mapid="744">

    <asp:Panel ID="Panel1" ScrollBars="Auto" Height="375px" runat="server">
                        <asp:GridView runat="server" AutoGenerateColumns="False"  
                            DataKeyNames="Id" ShowFooter="false" CssClass="yui-datatable-theme" Width="100%" 
                            ID="GridView2" OnRowCommand="GridView2_RowCommand" 
                             
                            >
                            <PagerSettings PageButtonCount="40" />
                            <Columns>
<asp:TemplateField HeaderText="SN"><ItemTemplate>
<%#Container.DataItemIndex+1  %>
                                                    
</ItemTemplate>

<HeaderStyle Font-Size="10pt"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                                        <asp:CheckBox ID="ck" runat="server" AutoPostBack="true" 
                                                            oncheckedchanged="ck_CheckedChanged" />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="12%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Image" >
                        <ItemTemplate>
                       
                            <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Spec. Sheet" >
                        <ItemTemplate>
                         <asp:LinkButton ID="btnlnkSpec" CommandName="downloadSpec" Visible="true"  Text='<%# Bind("AttName") %>'  runat="server"></asp:LinkButton>
                         
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center"  Width="8%"/>
                        </asp:TemplateField>




<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description "><ItemTemplate>
                                                        <asp:Label ID="lblpurchDesc" runat="server" Text='<%#Eval("Description") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="28%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
                                                        <asp:Label ID="lbluompurch" runat="server" Text='<%#Eval("UOM") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="PO Qty"><ItemTemplate>
                                                        <asp:Label ID="lblpoqty" runat="server" Text='<%#Eval("Qty") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Inward Qty"><ItemTemplate>
                                                        <asp:Label ID="lblInwrdqty" runat="server" Text='<%#Eval("InvQty") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tot Reced Qty"><ItemTemplate>
                                                        <asp:Label ID="lbltotrecevdqty" runat="server" Text='<%#Eval("TotRecQty") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reced Qty"><ItemTemplate>
                                                        <asp:Label ID="lblrecevdqty" runat="server" />
                                                        <asp:TextBox ID="txtrecQty" runat="server" CssClass="box3" Text='<%#Eval("TotRemainQty") %>' Visible="false" Width="90%" ValidationGroup="A" onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }"  onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" /> <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ValidationGroup="A" ControlToValidate="txtrecQty" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
                                                         </asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="ReqRecQty" runat="server" ControlToValidate="txtrecQty"  ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                         
                                                    
</ItemTemplate>


<ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
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
                        <td align="center">
<asp:Button ID="btnInsert" runat="server"  CssClass="redbox" OnClientClick="return confirmationAdd()"  Text=" Add " ValidationGroup="A" OnClick="btnInsert_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" onclick="btnCancel_Click"/>

                        </td>

                    </tr>
                            </table>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

