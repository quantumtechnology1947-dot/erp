<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Advice, newerp_deploy" title="ERP" culture="en-GB" theme="Default" %>


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



<table  width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Advice</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">  
                    
                    <HeaderTemplate>Payment
                    
                    
                    </HeaderTemplate>
                    

<ContentTemplate><asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" ><cc1:TabContainer 
        ID="TabContainer2" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="True"
                    Width="100%" Height="390px" ScrollBars="Auto" ><cc1:TabPanel runat="server" HeaderText="Advance" ID="TabPanel11"><HeaderTemplate>Advance</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel3" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr><td >Payment Against : </td><td >Advance</td><td height="25" valign="middle">Pay To : </td><td 
            align="right" height="25" valign="middle"><asp:DropDownList ID="drptype" 
            runat="server" AutoPostBack="True" 
            onselectedindexchanged="drptype_SelectedIndexChanged1"><asp:ListItem Value="0">Select</asp:ListItem><asp:ListItem 
                Value="1">Employee</asp:ListItem><asp:ListItem Value="2">Customer</asp:ListItem><asp:ListItem 
                Value="3">Supplier</asp:ListItem></asp:DropDownList></td><td height="25" 
                    valign="middle" width="1%">&nbsp;</td><td height="25" valign="middle"  ><asp:TextBox ID="TextBox1" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="Txt_AutoCompleteExtender" runat="server" 
                        CompletionInterval="100"
                         CompletionListCssClass="almt" 
                        CompletionListHighlightedItemCssClass="bgtext"
                         CompletionListItemCssClass="bg" 
                        CompletionSetCount="2"
                         DelimiterCharacters="" Enabled="True" 
                        FirstRowSelected="True" 
                        MinimumPrefixLength="1" ServiceMethod="sql3" 
                        ServicePath=""
                         ShowOnlyCurrentWordInCompletionListItem="True" 
                        TargetControlID="TextBox1" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqEmpEdit" runat="server" 
                        ControlToValidate="TextBox1" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td >Cheque No./ D.D.No.:</td><td ><asp:TextBox 
            ID="txtDDNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
            ID="ReqDDNo" runat="server" ControlToValidate="txtDDNo" ErrorMessage="*" 
            ValidationGroup="B"></asp:RequiredFieldValidator></td><td height="25" 
            valign="middle" colspan="2">Cheque Date :</td><td height="25" valign="middle">&nbsp;</td><td height="25" valign="middle" ><asp:TextBox ID="textChequeDate" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender ID="textDelDate_CalendarExtender" runat="server" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="textChequeDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDelDate" runat="server" 
                            ControlToValidate="textChequeDate" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDelverylDate" runat="server" 
                            ControlToValidate="textChequeDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="B"></asp:RegularExpressionValidator></td><td>&#160;</td></tr><tr><td >Drawn On</td><td ><asp:DropDownList 
            ID="DropDownList1" runat="server" CssClass="box3" DataSourceID="SqlDataSource1" 
            DataTextField="Name" DataValueField="Id"></asp:DropDownList></td><td 
            colspan="2">Payable At :</td><td>&nbsp;</td><td ><asp:TextBox ID="txtPayAt" runat="server" CssClass="box3" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="ReqPayableAt" runat="server" 
                        ControlToValidate="txtPayAt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td></td></tr><tr><td >&#160;&nbsp;</td></tr></table></asp:Panel><table width="100%"><tr><td><asp:Panel ID="Panel8" runat="server" 
                Height="283px" ScrollBars="Auto"><asp:GridView ID="GridView1"  
                runat="server"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"
              OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" 
                    onrowupdating="GridView1_RowUpdating" AllowPaging="True" 
                    DataSourceID="SqlDataSource2" PageSize="14"><Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationUpdate();" runat="server" CausesValidation="False" 
                                   CommandName="Edit" Text="Edit"> </asp:LinkButton></ItemTemplate><EditItemTemplate><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                   CommandName="Update" Text="Update"> </asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                   CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirmationDelete();" CausesValidation="False" 
                                   CommandName="Delete" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><FooterTemplate><asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="abc" 
                        OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" />
                </FooterTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Proforma Inv No  "><ItemTemplate><asp:Label ID="lblProFormaInvNo" runat="server" Text='<%#Eval("ProformaInvNo") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtProforInvNo" Width="97%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("ProformaInvNo") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="ReqProE" ValidationGroup="Shree" ControlToValidate="txtProforInvNo" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="txtProforInvNoFoot" Width="90%" CssClass="box3" ValidationGroup="abc" runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqProF" runat="server" ValidationGroup="abc" ControlToValidate="txtProforInvNoFoot" 
                         ErrorMessage="*"></asp:RequiredFieldValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%#Eval("InvDate") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="textDate" runat="server" Text='<%#Eval("InvDate") %>' CssClass="box3"> </asp:TextBox><cc1:CalendarExtender ID="textDate_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="textDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDate" runat="server" 
                                            ControlToValidate="textDate" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDate" ValidationGroup="Shree" runat="server" 
                                            ControlToValidate="textDate" ErrorMessage="*" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"> </asp:RegularExpressionValidator>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="textDateF" runat="server" Width="80%" CssClass="box3"> </asp:TextBox><cc1:CalendarExtender ID="textDateF_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="textDateF"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDateF" runat="server" 
                                            ControlToValidate="textDateF" ErrorMessage="*" ValidationGroup="abc"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDateF" ValidationGroup="abc" runat="server" 
                                            ControlToValidate="textDateF" ErrorMessage="*" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"> </asp:RegularExpressionValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="PO No"><ItemTemplate><asp:Label ID="lblPoNo" runat="server" Text='<%#Eval("PONo") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtPoNo" Width="97%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("PONo") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="ReqPoE" ValidationGroup="Shree" ControlToValidate="txtPoNo" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="txtPoNoFoot" CssClass="box3" Width="86%"   ValidationGroup="abc" runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqPoF" runat="server" ValidationGroup="abc" ControlToValidate="txtPoNoFoot" 
                         ErrorMessage="*"></asp:RequiredFieldValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particular") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtParticulars" Width="99%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Particular") %>'> </asp:TextBox>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="txtParticularsFoot" CssClass="box3"   Width="99%" ValidationGroup="abc" runat="server"> </asp:TextBox></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="25%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtAmount" Width="97%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Amount") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmountE" ValidationGroup="Shree" ControlToValidate="txtAmount" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="txtAmountFoot" Width="85%" CssClass="box3"  ValidationGroup="abc" runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmountF" runat="server" ValidationGroup="abc" ControlToValidate="txtAmountFoot" 
                         ErrorMessage="*"></asp:RequiredFieldValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Right" Width="6%" /></asp:TemplateField></Columns><EmptyDataTemplate><table border="1pt" style="border-color:GrayText" width="100%"><tr><th>Proforma Invoice No </th><th>Date </th><th>PONo </th><th>Amount </th><th>Particulars </th><th></th></tr><tr><td><asp:TextBox ID="txtProInv" runat="server" CssClass="box3" 
                                         ValidationGroup="pqr" Width="92%"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqProInv" runat="server" 
                                         ControlToValidate="txtProInv" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator></td><td><asp:TextBox ID="txtDate1" runat="server" CssClass="box3" ValidationGroup="pqr" 
                                         Width="88%"> </asp:TextBox><cc1:CalendarExtender ID="text_CalendarExtender" runat="server" Enabled="True" 
                                         Format="dd-MM-yyyy" TargetControlID="txtDate1"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDate1" runat="server" 
                                         ControlToValidate="txtDate1" ErrorMessage="*" ValidationGroup="pqr"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDate1" runat="server" 
                                         ControlToValidate="txtDate1" ErrorMessage="*" 
                                         ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                         ValidationGroup="pqr"> </asp:RegularExpressionValidator></td><td><asp:TextBox ID="txtPo" runat="server" CssClass="box3" ValidationGroup="pqr" 
                                         Width="92%"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                         ControlToValidate="txtPo" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator></td><td><asp:TextBox ID="txtAmt" runat="server" CssClass="box3" ValidationGroup="pqr" 
                                         Width="92%"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                         ControlToValidate="txtAmt" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator></td><td><asp:TextBox ID="txtparticul" runat="server" CssClass="box3" 
                                         ValidationGroup="pqr" Width="99%"> </asp:TextBox></td><td><asp:Button ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                         OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="pqr" /></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle><PagerSettings PageButtonCount="40" /></asp:GridView></asp:Panel></td></tr><tr><td align="center" style="height:25px"><asp:Button 
                                    ID="btnProceed" runat="server" CssClass="redbox" OnClick="btnProceed_Click" 
                                    onclientclick="return confirmationAdd();" Text="Proceed" ValidationGroup="B" /></td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel21" runat="server" HeaderText="Creditors"><HeaderTemplate>Creditors</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel4" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr><td >Payment Against : </td><td >Creditors</td><td height="25" valign="middle">Pay To :</td><td height="25" valign="middle"><asp:TextBox ID="txtPayTo_Credit" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                                            CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" 
                                            ServiceMethod="Sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtPayTo_Credit" 
                                            UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                            ControlToValidate="txtPayTo_Credit" ErrorMessage="*" ValidationGroup="z1"></asp:RequiredFieldValidator></td><td  ><asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                                 onclick="btnSearch_Click" Text="Search" /><asp:Button ID="btnRefresh" runat="server" Visible="False" CssClass="redbox" Text="Refresh" 
                                 onclick="btnRefresh_Click" /></td></tr><tr><td >Cheque No./ D.D.No.: </td><td ><asp:TextBox ID="txtChequeNo_Credit" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                            ControlToValidate="txtChequeNo_Credit" ErrorMessage="*" ValidationGroup="z1"></asp:RequiredFieldValidator></td><td height="25" valign="middle">Cheque Date : </td><td height="25" valign="middle"><asp:TextBox 
                                ID="txtChequeDate_Credit" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtChequeDate_Credit"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="z1"  runat="server" 
                                            ControlToValidate="txtChequeDate_Credit" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                            ControlToValidate="txtChequeDate_Credit" ErrorMessage="*"  ValidationGroup="z1" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator></td><td >&#160;&nbsp;</td></tr><tr><td >Drawn On : </td><td ><asp:DropDownList ID="DropDownList4" runat="server" CssClass="box3" 
                                            DataSourceID="SqlDataSource6" DataTextField="Name" DataValueField="Id"></asp:DropDownList></td><td>Payable At : </td><td><asp:TextBox 
                                ID="txtPayAt_Credit" runat="server" CssClass="box3" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                            ControlToValidate="txtPayAt_Credit" ErrorMessage="*" ValidationGroup="z1"></asp:RequiredFieldValidator></td><td ></td></tr><tr><td >&#160;&nbsp;</td></tr></table></asp:Panel><table width="100%"><tr><td><asp:Panel ID="Panel5" runat="server" 
                    Height="145px" ScrollBars="Auto"><asp:GridView ID="GridView4"  
                runat="server"  ShowFooter="True"
                AutoGenerateColumns="False" 
                DataKeyNames="Id"
               CssClass="yui-datatable-theme" Width="100%" onrowcommand="GridView4_RowCommand"><Columns><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:CheckBox ID="ck" runat="server" /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"  ><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="PVEV No"><ItemTemplate><asp:Label ID="lblPVEVNO" runat="server" Text='<%#Eval("PVEVNo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="PONo"><ItemTemplate><asp:Label ID="lblPONo" runat="server" Text='<%#Eval("PONo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Bill No"><ItemTemplate><asp:Label ID="lblBillNo" runat="server" Text='<%#Bind("BillNo") %>'> </asp:Label></ItemTemplate><ItemStyle 
            HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Bill Date"><ItemTemplate><asp:Label ID="lblBillDate" runat="server" Text='<%#Eval("BillDate") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Against Bill"><ItemTemplate><asp:TextBox ID="txtBill_Against" Width="88%" runat="server" CssClass="box3"  > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBillAgainst" ValidationGroup="temp"  ControlToValidate="txtBill_Against" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Actual Amt"><ItemTemplate><asp:Label ID="lblActAmt" runat="server" Text='<%#Eval("ActAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Paid Amt"><ItemTemplate><asp:Label ID="lblpaidAmt" runat="server" Text='<%#Eval("PaidAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="20%" /></asp:TemplateField><asp:TemplateField HeaderText="Bal Amt"><ItemTemplate><asp:Label ID="lblBalAmt" runat="server" Text='<%#Eval("BalAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:TextBox ID="txtAmount" Width="79%" runat="server" CssClass="box3" > </asp:TextBox><asp:RequiredFieldValidator ID="Req16" ValidationGroup="temp"  ControlToValidate="txtAmount" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularReqAmt" runat="server" 
                                    ControlToValidate="txtAmount" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="temp"></asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Narration"><ItemTemplate><asp:TextBox ID="txtNarration" Width="99%" runat="server" CssClass="box3"> </asp:TextBox></ItemTemplate><FooterTemplate><asp:Button ID="btnAddTemp" ValidationGroup="temp"  CssClass="redbox" 
                            runat="server" Text="Add" CommandName="AddToTemp"/></FooterTemplate><FooterStyle HorizontalAlign="Right" /><ItemStyle HorizontalAlign="Center" Width="10%" /></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView><br /></asp:Panel></td></tr><tr><td style="height:10px;"></td></tr><tr><td><asp:Panel ID="Panel10" runat="server" Height="125px" ScrollBars="Auto"><asp:GridView ID="GridView5"  
                runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"
                CssClass="yui-datatable-theme" Width="100%"                     
                AllowPaging="True" 
                onpageindexchanging="GridView5_PageIndexChanging" 
                onrowcancelingedit="GridView5_RowCancelingEdit" 
                onrowdeleting="GridView5_RowDeleting" onrowediting="GridView5_RowEditing" 
                        PageSize="5"><Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirmationDelete();" CausesValidation="False" 
                                   CommandName="Delete" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField Visible="False" ><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="PVEV No"  ><ItemTemplate><asp:Label ID="lblPvevNo" Text='<%#Eval("PVEVNo") %>' runat="server" > </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtPvEvE" Text='<%#Eval("PVEVNo") %>' runat="server"> </asp:TextBox></EditItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Bill Against"  ><ItemTemplate><asp:Label ID="lblBillAgainst" runat="server" Text='<%#Eval("BillAgainst") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtBillAgstE" Text='<%#Eval("BillAgainst") %>' runat="server"> </asp:TextBox></EditItemTemplate><ItemStyle HorizontalAlign="Left" Width="25%" /></asp:TemplateField><asp:TemplateField HeaderText="Bal Amt"  ><ItemTemplate><asp:Label ID="lblBalamt" runat="server" Text='<%#Eval("BalAmt") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:Label ID="lblBalamtE" runat="server" Text='<%#Eval("BalAmt") %>'> </asp:Label><asp:Label ID="lblActAmt" runat="server" Text='<%#Eval("ActAmt") %>'> </asp:Label></EditItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"  ><ItemTemplate><asp:Label ID="lblamt" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtAmountE" Text='<%#Eval("Amount") %>' runat="server"> </asp:TextBox></EditItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView><br /></asp:Panel></td></tr><tr><td align="center"><asp:Button 
                                    ID="btnProceed_Creditor" runat="server" CssClass="redbox" 
                                    onclientclick="return confirmationAdd();" Text="Proceed" 
                                    ValidationGroup="z1" OnClick="btnProceed_Creditor_Click"   /></td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel_Sal" runat="server" HeaderText="Salary"><HeaderTemplate>Salary</HeaderTemplate><ContentTemplate><asp:Panel ID="plnSalary" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr><td >Payment Against : </td><td >Salary</td><td height="25" valign="middle">Pay To :</td><td height="25" valign="middle"><asp:TextBox ID="txtPayTo_Sal" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" 
                                            ServiceMethod="Sql2" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtPayTo_Sal" 
                                            UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtPayTo_Sal" ErrorMessage="*" ValidationGroup="B"> </asp:RequiredFieldValidator></td><td  >&#160;</td></tr><tr><td >Cheque No./ D.D.No.:</td><td ><asp:TextBox ID="TxtChequeNo_Sal" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="TxtChequeNo_Sal" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td height="25" valign="middle">Cheque Date :</td><td height="25" valign="middle"><asp:TextBox 
                                ID="TxtChequeDate_Sal" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtChequeDate_Sal"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="B"  runat="server" 
                                            ControlToValidate="TxtChequeDate_Sal" ErrorMessage="*"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="TxtChequeDate_Sal" ErrorMessage="*"  ValidationGroup="B" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"> </asp:RegularExpressionValidator></td><td >&#160;</td></tr><tr><td >Drawn On :</td><td ><asp:DropDownList ID="DropDownList2" runat="server" CssClass="box3" 
                                            DataSourceID="SqlDataSource3" DataTextField="Name" DataValueField="Id"></asp:DropDownList></td><td>Payable At :</td><td><asp:TextBox 
                                ID="txtPayAt_Sal" runat="server" CssClass="box3" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="txtPayAt_Sal" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td ></td></tr><tr><td >&#160;&nbsp;</td></tr></table></asp:Panel><table width="100%"><tr><td><asp:Panel ID="Panel9" runat="server" 
                Height="280px" ScrollBars="Auto"><asp:GridView ID="GridView2"  
                runat="server"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"
              OnRowCommand="GridView2_RowCommand" CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView2_RowDataBound" 
                    onrowupdating="GridView2_RowUpdating" AllowPaging="True" 
                                            onrowcancelingedit="GridView2_RowCancelingEdit" 
                                            onrowdeleting="GridView2_RowDeleting" 
                                        onrowediting="GridView2_RowEditing" 
                                        onpageindexchanging="GridView2_PageIndexChanging" PageSize="13"><Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationUpdate();" runat="server" CausesValidation="False" 
                                   CommandName="Edit" Text="Edit"> </asp:LinkButton></ItemTemplate><EditItemTemplate><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" ValidationGroup="Shree"
                                   CommandName="Update" Text="Update"> </asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                   CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirmationDelete();" CausesValidation="False" 
                                   CommandName="Delete" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><FooterTemplate><asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="abc" 
                        OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" /></FooterTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particular") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtParticulars" Width="99%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Particular") %>'> </asp:TextBox>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="txtParticularsFoot" CssClass="box3"   Width="99%" ValidationGroup="abc" runat="server"> </asp:TextBox></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="30%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtAmount" Width="92%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Amount") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmountE" ValidationGroup="Shree" ControlToValidate="txtAmount" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator>
                </EditItemTemplate><FooterTemplate><asp:TextBox ID="txtAmountFoot" Width="92%" CssClass="box3"  ValidationGroup="abc" runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmountF" runat="server" ValidationGroup="abc" ControlToValidate="txtAmountFoot" 
                         ErrorMessage="*"></asp:RequiredFieldValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Right" Width="6%" /></asp:TemplateField></Columns><EmptyDataTemplate><table border="1pt" style="border-color:GrayText" width="100%"><tr><th>Particulars </th><th>Amount </th><th></th></tr><tr><td><asp:TextBox ID="txtparticul" runat="server" CssClass="box3" 
                                                        ValidationGroup="pqr" Width="99%"> </asp:TextBox></td><td><asp:TextBox ID="txtAmt" runat="server" CssClass="box3" ValidationGroup="pqr" 
                                                        Width="92%"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="txtAmt" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator></td><td><asp:Button ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                                        OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="pqr" /></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle><PagerSettings PageButtonCount="20" /></asp:GridView></asp:Panel></td></tr><tr><td align="center" style="height:25px;"><asp:Button 
                                    ID="btnProceed_Sal" runat="server" CssClass="redbox" 
                                    onclientclick="return confirmationAdd();" Text="Proceed" 
                                    ValidationGroup="B" onclick="btnProceed_Sal_Click" /></td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel_Others" runat="server" HeaderText="Others"><HeaderTemplate>Others</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel6" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr 
            ><td >Payment Against : </td><td >Others</td><td height="25" valign="middle">Pay To :</td><td height="25" valign="middle" align="right"><asp:DropDownList 
            ID="drptypeOther" runat="server" AutoPostBack="True" 
            OnSelectedIndexChanged="drptypeOther_SelectedIndexChanged"><asp:ListItem 
            Value="0">Select</asp:ListItem><asp:ListItem Value="1">Employee</asp:ListItem><asp:ListItem 
            Value="2">Customer</asp:ListItem><asp:ListItem Value="3">Supplier</asp:ListItem>
        </asp:DropDownList></td><td height="25" valign="middle" width="1%"  >&nbsp;</td><td height="25" valign="middle"><asp:TextBox ID="txtPayTo_Others" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                        CompletionInterval="100" CompletionListCssClass="almt" 
                        CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                        CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                        FirstRowSelected="True" MinimumPrefixLength="1" 
                        ServiceMethod="GetCompletionList" ServicePath="" 
                        ShowOnlyCurrentWordInCompletionListItem="True" 
                        TargetControlID="txtPayTo_Others" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtPayTo_Others" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td >Cheque No./ D.D.No.:</td><td ><asp:TextBox ID="txtChqNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                            ControlToValidate="txtChqNo" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator></td><td 
            height="25" valign="middle" colspan="2">Cheque Date :</td><td height="25" valign="middle">&nbsp;</td><td height="25" valign="middle" ><asp:TextBox ID="txtChq_Date" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                            Format="dd-MM-yyyy" TargetControlID="txtChq_Date"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtChq_Date" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtChq_Date" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="z"></asp:RegularExpressionValidator></td><td>&#160;</td></tr><tr><td >Drawn On :</td><td ><asp:DropDownList ID="DropDownList3" runat="server" CssClass="box3" 
                                            DataSourceID="SqlDataSource5" DataTextField="Name" DataValueField="Id"></asp:DropDownList></td><td 
            colspan="2">Payable At :</td><td>&nbsp;</td><td ><asp:TextBox ID="txtpayAt_oth" runat="server" CssClass="box3" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtpayAt_oth" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator></td><td></td></tr><tr><td >&#160;&nbsp;</td></tr></table></asp:Panel><table width="100%"><tr><td><asp:Panel ID="Panel7" runat="server" 
                ScrollBars="Auto"><asp:GridView ID="GridView3"  
                runat="server"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id"
              OnRowCommand="GridView3_RowCommand" CssClass="yui-datatable-theme" Width="100%" 
                    onrowupdating="GridView3_RowUpdating" AllowPaging="True" 
                              onrowediting="GridView3_RowEditing" 
                             onrowcancelingedit="GridView3_RowCancelingEdit" 
                             onrowdeleting="GridView3_RowDeleting" 
                onpageindexchanging="GridView3_PageIndexChanging" PageSize="17"><Columns><asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:LinkButton ID="LinkButton1" ValidationGroup="Shree" runat="server" CausesValidation="True" 
                                   CommandName="Update" Text="Update"> </asp:LinkButton>&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                   CommandName="Cancel" Text="Cancel"></asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationUpdate();" runat="server" CausesValidation="False" 
                                   CommandName="Edit" Text="Edit"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirmationDelete();" CausesValidation="False" 
                                   CommandName="Delete" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><FooterTemplate><asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="abc" 
                        OnClientClick=" return confirmationAdd()" CommandName="Add" CssClass="redbox" /></FooterTemplate><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Within Group"><EditItemTemplate><asp:TextBox ID="txtwithGr" Width="99%" runat="server" CssClass="box3" Text='<%#Bind("WithinGroup") %>'> </asp:TextBox></EditItemTemplate><FooterTemplate><asp:TextBox ID="txtwithingrFt" CssClass="box3"   Width="85%" ValidationGroup="abc" runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqWithinF" runat="server" ValidationGroup="abc" ControlToValidate="txtwithingrFt" 
                         ErrorMessage="*"></asp:RequiredFieldValidator></FooterTemplate><ItemTemplate><asp:Label ID="lblWithinGroup" runat="server" Text='<%#Eval("WithinGroup") %>'> </asp:Label></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"  ><EditItemTemplate><asp:Label ID="lblIdE" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="WO No/BG Group"><EditItemTemplate><asp:RadioButtonList 
                                ID="RadioButtonWONoGroupE" runat="server" AutoPostBack="True" 
                                                    RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonWONoGroupE_SelectedIndexChanged" 
                                    ><asp:ListItem Value="0" Selected="True"> WO No </asp:ListItem><asp:ListItem Value="1"> Group </asp:ListItem></asp:RadioButtonList></EditItemTemplate><FooterTemplate><asp:RadioButtonList 
                                ID="RadioButtonWONoGroupF" runat="server" AutoPostBack="True" 
                                                    RepeatDirection="Horizontal" onselectedindexchanged="RadioButtonWONoGroupF_SelectedIndexChanged" 
                                    ><asp:ListItem Value="0" Selected="True"> WO No </asp:ListItem><asp:ListItem Value="1"> Group </asp:ListItem></asp:RadioButtonList></FooterTemplate><ItemTemplate><asp:RadioButtonList 
                                ID="RadioButtonWONoGroup1" runat="server" AutoPostBack="True" 
                                                    RepeatDirection="Horizontal" 
                                    ><asp:ListItem Value="0" Selected="True"> WO No </asp:ListItem><asp:ListItem Value="1"> Group </asp:ListItem></asp:RadioButtonList></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="12%" /></asp:TemplateField><asp:TemplateField HeaderText="WONo"><EditItemTemplate><asp:TextBox 
                                    ID="txtWONoE" runat="server" CssClass="box3"> </asp:TextBox></EditItemTemplate><FooterTemplate><asp:TextBox 
                                    ID="txtWONoF" runat="server" Width="83%" CssClass="box3"> </asp:TextBox><asp:RequiredFieldValidator 
                                    ID="RequiredFieldtxtWONoF" runat="server" ValidationGroup="abc" ControlToValidate="txtWONoF" 
                                    ErrorMessage="*" > </asp:RequiredFieldValidator></FooterTemplate><ItemTemplate><asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'> </asp:Label></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="BG"><EditItemTemplate><asp:DropDownList ID="drpGroupE" DataSourceID="SqlDataBG" 
                    DataTextField="Symbol"  Visible="false" DataValueField="Id" runat="server"></asp:DropDownList></EditItemTemplate><FooterTemplate><asp:DropDownList ID="drpGroupF" runat="server" DataSourceID="SqlDataBG" 
                    DataTextField="Symbol"   Visible="false" DataValueField="Id"></asp:DropDownList></FooterTemplate><ItemTemplate><asp:Label ID="lblBG" runat="server" Visible="true" Text='<%#Eval("BG") %>'> </asp:Label></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Particulars"><EditItemTemplate><asp:TextBox ID="txtParticulars" Width="99%" runat="server" CssClass="box3"  ValidationGroup="Shree" Text='<%#Bind("Particular") %>'> </asp:TextBox></EditItemTemplate><FooterTemplate><asp:TextBox ID="txtParticularsFoot" CssClass="box3"   Width="99%" ValidationGroup="abc" runat="server"> </asp:TextBox></FooterTemplate><ItemTemplate><asp:Label ID="lblParticulars" runat="server" Text='<%#Eval("Particular") %>'> </asp:Label></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="30%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><EditItemTemplate><asp:TextBox ID="txtAmount" Width="90%" runat="server" CssClass="box3"  Text='<%#Bind("Amount") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmountE" ValidationGroup="Shree" ControlToValidate="txtAmount" 
                            runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator></EditItemTemplate><FooterTemplate><asp:TextBox ID="txtAmountFoot" Width="85%" CssClass="box3"  ValidationGroup="abc" runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmountF" runat="server" ValidationGroup="abc" ControlToValidate="txtAmountFoot" 
                         ErrorMessage="*"></asp:RequiredFieldValidator></FooterTemplate><ItemTemplate><asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label></ItemTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Right" Width="6%" /></asp:TemplateField></Columns><EmptyDataTemplate><table border="1pt" style="border-color:GrayText" width="100%"><tr><th>Within Group </th><th>WONo/BG Group </th><th></th><th>Particulars </th><th>Amount </th><th></th></tr><tr><td><asp:TextBox ID="txtwithinGr" runat="server" CssClass="box3" Width="92%"> </asp:TextBox><asp:RequiredFieldValidator 
                                        ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtwithinGr" 
                                        ErrorMessage="*" ValidationGroup="pqr2"></asp:RequiredFieldValidator></td><td><asp:RadioButtonList ID="RadioButtonWONoGroup" runat="server" AutoPostBack="True" 
                                   onselectedindexchanged="RadioButtonWONoGroup_SelectedIndexChanged" 
                                   RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">WO No</asp:ListItem><asp:ListItem 
                                   Value="1">Group</asp:ListItem></asp:RadioButtonList></td><td><asp:TextBox ID="txtWONo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                                        ID="RequiredFieldtxtWONo" runat="server" ControlToValidate="txtWONo" 
                                        ErrorMessage="*" ValidationGroup="pqr2"></asp:RequiredFieldValidator><asp:DropDownList ID="drpGroup" runat="server" DataSourceID="SqlDataBG" 
                                        DataTextField="Symbol" DataValueField="Id" Visible="false"></asp:DropDownList></td><td><asp:TextBox ID="txtparticul" runat="server" CssClass="box3" Width="99%"> </asp:TextBox></td><td><asp:TextBox ID="txtAmt" runat="server" CssClass="box3" ValidationGroup="pqr2" 
                                    Width="92%"> </asp:TextBox><asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmt" 
                                    ErrorMessage="*" ValidationGroup="pqr2"></asp:RequiredFieldValidator></td><td><asp:Button 
                                        ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                        OnClientClick=" return confirmationAdd()" Text="Insert" 
                                        ValidationGroup="pqr2" /></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle></asp:GridView></asp:Panel></td></tr><tr><td align="center" style="height:25px"><asp:Button 
                                    ID="btnProceed_Oth" runat="server" CssClass="redbox" 
                                    onclientclick="return confirmationAdd();" Text="Proceed" 
                                    ValidationGroup="z" onclick="btnProceed_Oth_Click"  /></td></tr></table></ContentTemplate></cc1:TabPanel></cc1:TabContainer></asp:Panel>
                    
                    </ContentTemplate></cc1:TabPanel>
                    
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Receipt">
                            
                        <ContentTemplate><asp:Panel ID="Panel2" ScrollBars="Auto" runat="server"><table width="100%"><tr><td>&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr><tr><td>Receipt Against</td><td><asp:DropDownList ID="DrpTypes" runat="server" AutoPostBack="True"  
                                  CssClass="box3" OnSelectedIndexChanged="DrpTypes_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqDrpType" runat="server" ValidationGroup="M"
                                    ControlToValidate="DrpTypes" InitialValue="Select" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>Received From</td><td><asp:TextBox ID="TxtFrom" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqFrom" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtReceived" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td>Invoice No</td><td><asp:TextBox ID="TxtInvoiceNo" runat="server" CssClass="box3">0</asp:TextBox></td><td>Amount </td><td><asp:TextBox ID="TxtAmount" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqAmount" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtAmount" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                    ControlToValidate="TxtAmount" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="M"></asp:RegularExpressionValidator></td><td>&#160;</td></tr><tr><td>Cheque No</td><td><asp:TextBox ID="TxtChequeNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqChequeNo" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtChequeNo" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>Cheque Date</td><td><asp:TextBox ID="TxtChequeDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtChequeDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtChequeDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqChequeDate" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtChequeDate" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBillDate0" runat="server" 
                                    ControlToValidate="TxtChequeDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="M"></asp:RegularExpressionValidator></td><td><asp:CompareValidator ID="CompareValidator1" ValidationGroup="M" runat="server" 
                                    ControlToValidate = "TxtChequeDate" ControlToCompare = "TxtClearanceDate" 
                                    Operator ="LessThanEqual" Type = "Date" 
                                    ErrorMessage="Cheque date must be less than or equal to Clearance date."></asp:CompareValidator></td></tr><tr><td>Cheque Received By</td><td><asp:TextBox ID="TxtReceived" runat="server" CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtenderR" runat="server" 
                        CompletionInterval="100"
                         CompletionListCssClass="almt" 
                        CompletionListHighlightedItemCssClass="bgtext"
                         CompletionListItemCssClass="bg" 
                        CompletionSetCount="2"
                         DelimiterCharacters="" Enabled="True" 
                        FirstRowSelected="True" 
                        MinimumPrefixLength="1" ServiceMethod="sql2" 
                        ServicePath=""
                         ShowOnlyCurrentWordInCompletionListItem="True" 
                        TargetControlID="TxtReceived" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="M" 
                                    ControlToValidate="TxtReceived" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>Bank Name</td><td><asp:TextBox ID="TxtBank" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqReceived" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtBank" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td>Bank Account No</td><td><asp:TextBox ID="TxtBankAccNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqBankAccNo" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtBankAccNo" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>Cheque Clearance Date</td><td><asp:TextBox ID="TxtClearanceDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtClearanceDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtClearanceDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqClearanceDate" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtClearanceDate" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBillDate" runat="server" 
                                    ControlToValidate="TxtClearanceDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="M"></asp:RegularExpressionValidator></td><td>&#160;</td></tr><tr><td>Narration</td><td><asp:TextBox ID="TxtNarration" runat="server" CssClass="box3" 
                                    TextMode="MultiLine"></asp:TextBox></td><td>&#160;</td><td><asp:Button ID="TxtSubmit" runat="server" CssClass="redbox"  ValidationGroup="M"
                                    onclick="TxtSubmit_Click" Text="Submit" /></td><td>&#160;</td></tr><tr><td colspan="5"><asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                                    CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                    PageSize="15"  Width="100%"
                                    onrowcommand="GridView6_RowCommand"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="LinkButton1" OnClientClick="confirmationDelete()"  CommandName="Del" runat="server">Delete</asp:LinkButton>
                                    </ItemTemplate></asp:TemplateField><asp:TemplateField Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                    </ItemTemplate></asp:TemplateField><asp:BoundField DataField="FinYear" HeaderText="Fin Year" 
                                            SortExpression="FinYearId"  /><asp:BoundField DataField="ADRNo" 
                                    HeaderText="ADRNo" SortExpression="BVRNo" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="Types" HeaderText="Receipt Against" 
                                            SortExpression="Types" /><asp:BoundField DataField="ReceivedFrom" HeaderText="Received From" 
                                            SortExpression="ReceivedFrom" /><asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" 
                                            SortExpression="InvoiceNo" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="ChequeNo" HeaderText="Cheque No" 
                                            SortExpression="ChequeNo" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="ChequeDate" HeaderText="Cheque Date" 
                                            SortExpression="ChequeDate" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="ChequeReceivedBy" HeaderText="Cheque Recd By" 
                                            SortExpression="ChequeReceivedBy" ><ItemStyle Width="15%" /></asp:BoundField><asp:BoundField DataField="BankName" HeaderText="Bank Name" 
                                            SortExpression="BankName" /><asp:BoundField DataField="BankAccNo" HeaderText="Bank AccNo" 
                                            SortExpression="BankAccNo" /><asp:BoundField DataField="ChequeClearanceDate" HeaderText="Clearance Date" 
                                            SortExpression="ChequeClearanceDate" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="Narration" HeaderText="Narration" 
                                            SortExpression="Narration" /><asp:BoundField DataField="Amount" HeaderText="Amount" 
                                            SortExpression="Amount" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></td></tr></table></asp:Panel>
                    
                           
                    
                    </ContentTemplate></cc1:TabPanel>
                    
                </cc1:TabContainer>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                    ProviderName="System.Data.SqlClient" 
                    
                    SelectCommand="SELECT * FROM [tblACC_Advice_Payment_Temp] WHERE (([SessionId] = @SessionId) AND ([CompId] = @CompId) And ([Types]=1))" 
                    ConflictDetection="OverwriteChanges" 
                    DeleteCommand="DELETE FROM [tblACC_Advice_Payment_Temp] WHERE [Id] = @original_Id" 
                    InsertCommand="INSERT INTO [tblACC_Advice_Payment_Temp] ([ProformaInvNo], [InvDate], [PONo], [Amount], [Particular], [CompId], [SessionId],[Types]) VALUES (@ProformaInvNo, @InvDate, @PONo, @Amount, @Particular, @CompId, @SessionId,@Types)" 
                    OldValuesParameterFormatString="original_{0}" 
                    UpdateCommand="UPDATE [tblACC_Advice_Payment_Temp] SET [ProformaInvNo] = @ProformaInvNo, [InvDate] = @InvDate, [PONo] = @PONo, [Amount] = @Amount, [Particular] = @Particular, [CompId] = @CompId, [SessionId] = @SessionId WHERE [Id] = @original_Id">
                    <SelectParameters>
                        <asp:SessionParameter Name="SessionId" SessionField="username" Type="String" />
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                       
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="original_Id" Type="Int32" />
                        
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProformaInvNo" Type="String" />
                        <asp:Parameter Name="InvDate" Type="String" />
                        <asp:Parameter Name="PONo" Type="String" />
                        <asp:Parameter Name="Amount" Type="Double" />
                        <asp:Parameter Name="Particular" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32" />
                        <asp:Parameter Name="SessionId" Type="String" />
                        <asp:Parameter Name="original_Id" Type="Int32" />                        
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProformaInvNo" Type="String" />
                        <asp:Parameter Name="InvDate" Type="String" />
                        <asp:Parameter Name="PONo" Type="String" />
                        <asp:Parameter Name="Amount" Type="Double" />
                        <asp:Parameter Name="Particular" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32" />
                        <asp:Parameter Name="SessionId" Type="String" />
                         <asp:Parameter Name="Types" Type="Int32" />
                    </InsertParameters>
                </asp:SqlDataSource>                
                 <asp:SqlDataSource 
        runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource1"></asp:SqlDataSource><asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource3">
        </asp:SqlDataSource><asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource5">
    </asp:SqlDataSource><asp:SqlDataSource 
        runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource6">
    </asp:SqlDataSource>
                        
             
               <asp:SqlDataSource ID="SqlDataBG" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [BusinessGroup]"></asp:SqlDataSource>
                
                
                
            </td>
        </tr>
        
        </table>
 
 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

