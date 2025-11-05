<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CashVoucher_New.aspx.cs" Inherits="Module_Accounts_Transactions_CashVoucher_New" Title="ERP" Theme ="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
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

  <table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%">
        <tr>
            <td style="background:url(../../../images/hdbg.JPG); height:21px" 
                class="fontcsswhite" >&nbsp;<b>Cash Voucher- New</b></td>
        </tr>
        <tr>
        
        <td>
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Height="431px" Width="100%" >
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Payment" >
                    <HeaderTemplate>
                    Payment
                    </HeaderTemplate>

                    <ContentTemplate>
                        
                        <table align="left" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                        <td colspan="2">
                        </td>
                        </tr>
                        <tr>
                        <td height="25px" width="10%" class="style4">&#160; Paid To &#160;</td><td>:<asp:TextBox 
                                ID="txtPaidTo" runat="server" CssClass="box3" Width="350px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldtxtPaidTo" runat="server" ControlToValidate="txtPaidTo" 
                                ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td></tr><tr>
                                <td height="25px" width="10%" class="style5">&#160; Received By&#160;</td><td>:<asp:DropDownList 
                                    ID="ddlCodeType" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="ddlCodeType_SelectedIndexChanged">
                               <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Employee</asp:ListItem>
                                <asp:ListItem Value="2">Customer</asp:ListItem>
                                <asp:ListItem Value="3">Supplier</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox 
                                    ID="txtNewCustomerName" runat="server" CssClass="box3" Width="350px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtNewCustomerName_AutoCompleteExtender" 
                                    runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                    CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                    FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql" 
                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                    TargetControlID="txtNewCustomerName" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                    ControlToValidate="txtNewCustomerName" ErrorMessage="*" 
                                    ValidationGroup="B"></asp:RequiredFieldValidator></td></tr><tr><td colspan="2" style="border: 2px solid #808080;"  ><table class="style3"><tr><td height="25px" width="25%">Bill No. : <asp:TextBox 
                                ID="txtBillNo" runat="server" CssClass="box3" ValidationGroup="A"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldBillNo" runat="server" ControlToValidate="txtBillNo" 
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td width="25%">Bill Date :<asp:TextBox 
                                    ID="textBillDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender 
                                    ID="textBillDate_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="textBillDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqtextBillDate" runat="server" 
                                    ControlToValidate="textBillDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegtextBillDate" runat="server" 
                                    ControlToValidate="textBillDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td width="25%">PO No. :<asp:TextBox ID="txtPONo" runat="server" 
                                    CssClass="box3"></asp:TextBox></td><td width="25%">PO Date :<asp:TextBox 
                                    ID="textPODate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender 
                                    ID="textPODate_CalendarExtender" runat="server" Enabled="True" 
                                    Format="dd-MM-yyyy" TargetControlID="textPODate"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegtextPODate" runat="server" 
                                    ControlToValidate="textPODate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td height="25px" width="25%">Amount :&#160;<asp:TextBox ID="txtAmount" 
                                    runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                                    ID="RequiredFieldtxtAmount" runat="server" ControlToValidate="txtAmount" 
                                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                    ID="RegtxtAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator></td><td width="25%">
                                        <asp:RadioButtonList ID="RadioButtonWONoGroup" runat="server" 
                                            AutoPostBack="True" 
                                            OnSelectedIndexChanged="RadioButtonWONoGroup_SelectedIndexChanged" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">WO No</asp:ListItem>
                                            <asp:ListItem Value="1"> BG Group</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td><td width="25%">
                                        <asp:TextBox ID="txtWONo" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldtxtWONo" runat="server" 
                                            ControlToValidate="txtWONo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        <asp:DropDownList ID="drpGroup" runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="LBlBudget" runat="server" Text="Budget Code :"></asp:Label>
                                         </td><td width="25%">
                                        <asp:DropDownList ID="drpBudgetcode" runat="server">
                                        </asp:DropDownList>
                                    </td></tr><tr><td height="25px" colspan="2">Particulars :<asp:TextBox 
                                        ID="txtParticulars" runat="server" CssClass="box3" Height="50px" 
                                        TextMode="MultiLine" Width="280px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldtxtParticulars" runat="server" 
                                        ControlToValidate="txtParticulars" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                    <td colspan="2" height="25px">
                                        <asp:RadioButtonList ID="RadioButtonAcHead" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="RadioButtonAcHead_SelectedIndexChanged" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Labour</asp:ListItem>
                                            <asp:ListItem Value="1">With Material</asp:ListItem>
                                            <asp:ListItem Value="2">Expenses</asp:ListItem>
                                            <asp:ListItem Value="3">Ser. Provider</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:DropDownList ID="drpAcHead" runat="server" CssClass="box3">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFielddrpAcHead" runat="server" 
                                            ControlToValidate="drpAcHead" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                 
                                 
                                 </tr><tr><td height="25px">PVEV No :
                                    <asp:TextBox ID="txtPVEVNO" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                                    </td><td>&nbsp;</td><td>&nbsp;</td><td><asp:Button ID="btnPaymentAdd" runat="server" CssClass="redbox" Text="Add" 
                                                    onclick="btnPaymentAdd_Click" ValidationGroup="A" /></td></tr><tr><td height="25px">&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr></table></td></tr><tr><td colspan="2" >&#160;</td></tr><tr><td colspan="2" align="center">
                            <asp:Panel ID="Panel1" runat="server" Height="180px" ScrollBars="Auto">
                                                    
                                                    <asp:GridView 
                                ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CssClass="yui-datatable-theme" DataKeyNames="Id"  
                                        Width="100%" onrowcommand="GridView1_RowCommand1">
                                        
                                        <Columns>
                                       
                                        
                                        <asp:TemplateField><ItemTemplate><asp:LinkButton  ID ="lnkButton" Text="Delete" runat ="server" CommandName="Del"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                
                                            </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                                        
                                        
                                        
                                        
                                        <asp:TemplateField    HeaderText="Id" Visible="False">
                                    <ItemTemplate><asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:BoundField DataField="CompId" HeaderText="CompId" SortExpression="CompId" 
                                                Visible="False" />
                                                
                                                <asp:BoundField DataField="SessionId" HeaderText="SessionId" 
                                                SortExpression="SessionId" Visible="False" /><asp:BoundField DataField="BillNo" HeaderText="Bill No" SortExpression="BillNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="BillDate" HeaderText="Bill Date" 
                                                SortExpression="BillDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="PONo" HeaderText="PO No" SortExpression="PONo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="PODate" HeaderText="PO Date" SortExpression="PODate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="Particulars" HeaderText="Particulars" 
                                                SortExpression="Particulars"><ItemStyle HorizontalAlign="Left" /></asp:BoundField><asp:BoundField DataField="WONo" HeaderText="WO No" SortExpression="WONo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="BGGroup" HeaderText="Group" SortExpression="BGGroup"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="AcHead" HeaderText="Ac Head" SortExpression="AcHead">
                                            <ItemStyle HorizontalAlign="Left" Width="10%" /></asp:BoundField><asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"><ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                                                
                                             
                                                
                                                <asp:TemplateField HeaderText="BudgetCode">
                                                
                                                  <ItemTemplate><asp:Label ID="lblBudgetCode" Text='<%# Eval("BudgetCode") %>' runat="server"></asp:Label></ItemTemplate>
                                                 <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                </asp:TemplateField>
                                                
                                             <asp:BoundField DataField="PVEVNo" HeaderText="PVEV No" 
                                                SortExpression="PVEVNo" ><ItemStyle HorizontalAlign="Center" Width="7%" />
</asp:BoundField>
                                                
                                                
                                                
                                             
                                                
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
                                                
                                                
                                                </td></tr><tr><td align="center" colspan="2" height="30px" valign="middle">
                                   <asp:Button ID="btnPayProceed" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                                        onclick="btnPayProceed_Click" Text="Proceed" ValidationGroup="B" />
  
  </td></tr></table>
  
                    
  
                    
                        </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Receipt">
                        <HeaderTemplate>
                        Receipt
                        </HeaderTemplate>

                        <ContentTemplate>
<table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td><table class="style3"><tr><td width="1%">&#160;</td><td width="14%">Amount</td><td width="1%">:</td><td colspan="3" width="60%"><asp:TextBox ID="txtAmountRec" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldtxtAmountRec" runat="server" 
                                            ControlToValidate="txtAmountRec" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegtxtAmountRec" runat="server" 
                                            ControlToValidate="txtAmountRec" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="C"></asp:RegularExpressionValidator></td><td width="10%">&#160;</td></tr><tr><td>&#160;</td><td>Cash Received Against</td><td>:</td><td colspan="3"><asp:DropDownList ID="ddlCodeTypeRA" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlCodeTypeRA_SelectedIndexChanged"><asp:ListItem Value="0">Select</asp:ListItem><asp:ListItem Value="1">Employee</asp:ListItem><asp:ListItem Value="2">Customer</asp:ListItem><asp:ListItem Value="3">Supplier</asp:ListItem>
    </asp:DropDownList><asp:TextBox ID="txtNewCustomerNameRA" runat="server" CssClass="box3" 
                                            Width="350px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtNewCustomerNameRA_AutoCompleteExtender" 
                                            runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql1" 
                                            ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtNewCustomerNameRA" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                            ControlToValidate="txtNewCustomerNameRA" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td>&#160;</td><td>Cash Received By</td><td>:</td><td colspan="3"><asp:DropDownList ID="ddlCodeTypeRB" runat="server" AutoPostBack="True" 
                                            OnSelectedIndexChanged="ddlCodeTypeRB_SelectedIndexChanged"><asp:ListItem Value="0">Select</asp:ListItem><asp:ListItem Value="1">Employee</asp:ListItem><asp:ListItem Value="2">Customer</asp:ListItem><asp:ListItem Value="3">Supplier</asp:ListItem>
    </asp:DropDownList><asp:TextBox ID="txtNewCustomerNameRB" runat="server" CssClass="box3" 
                                            Width="350px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtNewCustomerNameRB_AutoCompleteExtender" 
                                            runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql2" 
                                            ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtNewCustomerNameRB" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                            ControlToValidate="txtNewCustomerNameRB" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td>&#160;</td><td>WONo / Group</td><td>:</td><td width="19%"><asp:RadioButtonList ID="RadioButtonWONoGroupRec" runat="server" 
                                            AutoPostBack="True" 
                                            OnSelectedIndexChanged="RadioButtonWONoGroupRec_SelectedIndexChanged" 
                                            RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">WO No</asp:ListItem><asp:ListItem Value="1">Group</asp:ListItem>
    </asp:RadioButtonList></td><td><asp:TextBox ID="txtWONoRec" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldtxtWONoRec" runat="server" 
                                            ControlToValidate="txtWONoRec" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator><asp:DropDownList ID="drpGroupRec" runat="server"></asp:DropDownList></td><td><asp:Label ID="LblBudget1" runat="server" Text="Budget Code :"></asp:Label></td><td><asp:DropDownList ID="drpBudgetcode1" runat="server"></asp:DropDownList></td></tr><tr><td>&#160;&nbsp;</td><td>Ac Head </td><td>: </td><td><asp:RadioButtonList ID="RadioButtonAcHeadRec" runat="server" 
                                            AutoPostBack="True" 
                                            OnSelectedIndexChanged="RadioButtonAcHeadRec_SelectedIndexChanged" 
                                            RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0"> Labour </asp:ListItem><asp:ListItem Value="1"> With Material </asp:ListItem>  <asp:ListItem Value="2">Expenses</asp:ListItem>
                                            <asp:ListItem Value="3">Ser. Provider</asp:ListItem>
    </asp:RadioButtonList></td><td colspan="2"><asp:DropDownList ID="drpAcHeadRec" runat="server" CssClass="box3"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFielddrpAcHeadRec" runat="server" 
                                            ControlToValidate="drpAcHeadRec" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td>&#160;&nbsp;</td></tr><tr><td>&#160;&nbsp;</td><td>Others </td><td>: </td><td colspan="3"><asp:TextBox ID="txtOthers" runat="server" CssClass="box3" Height="50px" 
                                            TextMode="MultiLine" Width="280px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldtxtOthers" runat="server" 
                                            ControlToValidate="txtOthers" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td>&#160;&nbsp;</td></tr><tr><td>&#160;&nbsp;</td><td>&#160;&nbsp;</td><td>&#160;&nbsp;</td><td align="center" colspan="3" height="25px" valign="middle"><asp:Button ID="btnReceiptProceed" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                                            onclick="btnReceiptProceed_Click" Text="Proceed" ValidationGroup="C" /></td><td>&#160;&nbsp;</td></tr></table></td></tr><tr><td align="center">&#160;</td></tr><tr><td>
                                            
                                            
                                            
                                            <asp:Panel ID="Panel2" runat="server" Height="230px" ScrollBars="Auto">
                                            
                                            
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                        CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                        Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1%>
                                </ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
</asp:TemplateField><asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" Visible="False"
                                                ReadOnly="True" SortExpression="Id" /><asp:BoundField DataField="SysDate" HeaderText="Date" 
                                                SortExpression="SysDate" ><ItemStyle HorizontalAlign="Center" Width="5%" />
</asp:BoundField><asp:BoundField DataField="SysTime" HeaderText="SysTime" Visible="False"
                                                SortExpression="SysTime" /><asp:BoundField DataField="CompId" HeaderText="CompId" Visible="False"
                                                SortExpression="CompId" /><asp:BoundField DataField="FinYearId" 
                                                        HeaderText="FinYearId" Visible="False"
                                                SortExpression="FinYearId" >
                                                        <ItemStyle Width="2%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SessionId" HeaderText="SessionId" Visible="False"
                                                SortExpression="SessionId" /><asp:BoundField DataField="CVRNo" HeaderText="CVR No" SortExpression="CVRNo" ><ItemStyle HorizontalAlign="Center" Width="5%" />
</asp:BoundField><asp:BoundField DataField="CashReceivedAgainst" 
                                                HeaderText="Cash Rec. Against" SortExpression="CashReceivedAgainst" ><ItemStyle HorizontalAlign="Left" Width="15%" />
</asp:BoundField><asp:BoundField DataField="CashReceivedBy" HeaderText="Cash Rec. By" 
                                                SortExpression="CashReceivedBy" ><ItemStyle HorizontalAlign="Left" Width="15%" />
</asp:BoundField><asp:BoundField DataField="WONo" HeaderText="WO No" SortExpression="WONo" ><ItemStyle HorizontalAlign="Center" Width="5%" />
</asp:BoundField><asp:BoundField DataField="BGGroup" HeaderText="BG Group" 
                                                SortExpression="BGGroup" ><ItemStyle HorizontalAlign="Center" Width="6%" />
</asp:BoundField><asp:BoundField DataField="AcHead" HeaderText="Ac Head" 
                                                SortExpression="AcHead" ><ItemStyle HorizontalAlign="Left" Width="7%" />
</asp:BoundField><asp:BoundField DataField="Amount" HeaderText="Amount" 
                                                SortExpression="Amount" ><ItemStyle HorizontalAlign="Right" Width="5%" />
</asp:BoundField><asp:BoundField DataField="BudgetCode" HeaderText="Budget Code" 
                                                SortExpression="BudgetCode" ><ItemStyle HorizontalAlign="Center" Width="7%" />
</asp:BoundField>



    </Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                                        
    </EmptyDataTemplate>
    </asp:GridView>

                                
                                    </asp:Panel></td></tr></table>
                         
                    </ContentTemplate>

                    </cc1:TabPanel>
                    </cc1:TabContainer>
        </td>
        
        </tr> 
          </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

