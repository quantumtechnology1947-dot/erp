<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankVoucher.aspx.cs" Inherits="Module_Accounts_Transactions_BankVoucher" Title="ERP"  Theme="Default" Culture="en-GB"%>
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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Bank Voucher</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add"><HeaderTemplate>Payment</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" ><cc1:TabContainer 
        ID="TabContainer2" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="True"
                    Width="100%" Height="390px" ScrollBars="Auto" ><cc1:TabPanel runat="server" HeaderText="Advance" ID="TabPanel11"><HeaderTemplate>Advance</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel3" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr><td>Payment Against : </td><td >Advance</td><td 
                        height="25" style="text-align: center" valign="middle">&#160;</td><td height="25" valign="middle">Cheque Date :</td><td height="25" valign="middle"  ><asp:TextBox 
                        ID="textChequeDate" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender 
                        ID="textDelDate_CalendarExtender" runat="server" Enabled="True" 
                        Format="dd-MM-yyyy" TargetControlID="textChequeDate"></cc1:CalendarExtender><asp:RequiredFieldValidator 
                        ID="ReqDelDate" runat="server" ControlToValidate="textChequeDate" 
                        ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                        ID="RegDelverylDate" runat="server" ControlToValidate="textChequeDate" 
                        ErrorMessage="*" 
                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                        ValidationGroup="B"></asp:RegularExpressionValidator></td><td colspan="2">&#160;</td></tr><tr><td >Drawn On : </td><td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" 
                            DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id" 
                            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td><td height="25" 
            valign="middle" align="center"><asp:DropDownList ID="drptype" 
        runat="server" AutoPostBack="True" 
        onselectedindexchanged="drptype_SelectedIndexChanged1"><asp:ListItem Value="0"> Select </asp:ListItem><asp:ListItem 
            Value="1"> Employee </asp:ListItem><asp:ListItem Value="2"> Customer </asp:ListItem><asp:ListItem 
            Value="3"> Supplier </asp:ListItem></asp:DropDownList></td><td height="25" valign="middle">Pay To : </td><td ><asp:TextBox ID="TextBox1" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="Txt_AutoCompleteExtender" runat="server" 
                CompletionInterval="100" CompletionListCssClass="almt" 
                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                CompletionSetCount="2" ContextKey="key2" DelimiterCharacters="" Enabled="True" 
                FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql3" 
                ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                TargetControlID="TextBox1" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqEmpEdit" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td height="25" valign="middle" 
        width="1%" colspan="2"><asp:Button ID="BtnSearch_Adv" runat="server" CssClass="redbox" 
                    onclick="BtnSearch_Adv_Click" Text="Search" Visible="False" /></td></tr><tr><td >Cheque No./ D.D.No.: </td><td ><asp:TextBox ID="txtDDNo" runat="server" CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList1" 
                                ServicePath="" TargetControlID="txtDDNo" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqDDNo" runat="server" 
                        ControlToValidate="txtDDNo" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td align="center">&#160;</td><td>Payable At :</td><td 
        colspan="2"><asp:DropDownList 
        ID="DDListNewRegdCountry_Adv" runat="server" AutoPostBack="True" CssClass="box3" 
        OnSelectedIndexChanged="DDListNewRegdCountry_Adv_SelectedIndexChanged"><asp:ListItem 
        Value="1">India</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqCountry_Adv" 
        runat="server" ControlToValidate="DDListNewRegdCountry_Adv" ErrorMessage="*" 
        InitialValue="Select" ValidationGroup="B"></asp:RequiredFieldValidator><asp:DropDownList 
        ID="DDListNewRegdState_Adv" runat="server" AutoPostBack="True" CssClass="box3" 
        OnSelectedIndexChanged="DDListNewRegdState_Adv_SelectedIndexChanged"><asp:ListItem 
            Value="21"> Maharashtra</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqStat_Adv" runat="server" 
        ControlToValidate="DDListNewRegdState_Adv" ErrorMessage="*" InitialValue="Select" 
        ValidationGroup="B"></asp:RequiredFieldValidator><asp:DropDownList 
        ID="DDListNewRegdCity_Adv" runat="server" CssClass="box3"><asp:ListItem Value="405"> Pune</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqCity_Adv" runat="server" 
        ControlToValidate="DDListNewRegdCity_Adv" ErrorMessage="*" InitialValue="Select" 
        ValidationGroup="B"></asp:RequiredFieldValidator></td><td>&#160;</td><td align="center">&#160;</td></tr><tr><td>Add. Charges :</td><td valign="middle"><asp:TextBox ID="Txtaddcharg_Adv" runat="server" CssClass="box3" 
                        Width="92px">0</asp:TextBox><asp:RegularExpressionValidator ID="RegularReqAdd_Adv" runat="server" 
                        ControlToValidate="Txtaddcharg_Adv" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator></td><td align="center"></td><td>Transaction Type : </td><td colspan="2"><asp:RadioButtonList ID="Rdbtncrtrtype_Adv" runat="server" 
                        RepeatDirection="Horizontal"><asp:ListItem Value="1">RTGS</asp:ListItem><asp:ListItem Value="2">NEFT</asp:ListItem><asp:ListItem Value="3">DD</asp:ListItem><asp:ListItem Selected="True" Value="4">CHEQUE</asp:ListItem></asp:RadioButtonList></td><td>&#160;&#160;</td><td align="center">&#160;&#160;</td></tr><tr><td><asp:Label 
                        ID="Label9" runat="server" Text="Name on Cheque : "></asp:Label></td><td 
                        align="right"><asp:RadioButton ID="Rdbtncheck_Adv" runat="server" 
                            AutoPostBack="True" GroupName="cheque" 
                            oncheckedchanged="Rdbtncheck_Adv_CheckedChanged" /></td><td><asp:TextBox 
                            ID="txtNameOnchq_Adv" runat="server" CssClass="box3" Enabled="False" 
                            Width="200px"> </asp:TextBox></td><td align="justify"><asp:RadioButton 
                            ID="Rdbtncheck1_Adv" runat="server" AutoPostBack="True" Checked="True" 
                            GroupName="cheque" oncheckedchanged="Rdbtncheck1_Adv_CheckedChanged" /><asp:DropDownList 
                            ID="DrpPaid_Adv" runat="server" CssClass="box3">
                        </asp:DropDownList></td><td><asp:Button ID="btnProceed" runat="server" 
                            CssClass="redbox" OnClick="btnProceed_Click" 
                            OnClientClick="return confirmationAdd();" Text="Proceed" ValidationGroup="B" /><asp:Label 
                            ID="Lblsupid_Adv" runat="server" Visible="False"></asp:Label></td><td align="center" style="text-align: right">&#160;&#160; </td><td>&#160;&#160; </td></tr></table></asp:Panel><table width="100%"><tr><td><asp:Panel 
                        ID="Panel8" runat="server" Height="250px" ScrollBars="Auto"><asp:GridView 
                        ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                        CssClass="yui-datatable-theme" DataKeyNames="Id" 
                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                        OnRowCommand="GridView1_RowCommand" onrowdatabound="GridView1_RowDataBound" 
                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
                        onrowupdating="GridView1_RowUpdating" PageSize="14" ShowFooter="True" 
                        Width="100%"><Columns><asp:TemplateField HeaderText="Sr.No.">
                                    <ItemStyle Width="3%" />
                                    </asp:TemplateField><asp:TemplateField 
                                ShowHeader="False"><ItemTemplate>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                CommandName="Edit" OnClientClick="return confirmationUpdate();" Text="Edit">
                                            </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="Update"> </asp:LinkButton>
                                &#160;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="btnInsert" runat="server" CommandName="Add" CssClass="redbox" 
                                    OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="abc" />
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                            </asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton 
                                    ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" 
                                    OnClientClick="return confirmationDelete();" Text="Delete"> </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                            </asp:TemplateField><asp:TemplateField HeaderText="Proforma Inv No  "><ItemTemplate><asp:Label 
                                    ID="lblProFormaInvNo" runat="server" Text='<%#Eval("ProformaInvNo") %>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' Visible="false"> </asp:Label>
                                <asp:TextBox ID="txtProforInvNo" runat="server" CssClass="box3" 
                                    Text='<%#Bind("ProformaInvNo") %>' ValidationGroup="Shree" Width="97%"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqProE" runat="server" 
                                    ControlToValidate="txtProforInvNo" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtProforInvNoFoot" runat="server" CssClass="box3" 
                                    ValidationGroup="abc" Width="90%"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqProF" runat="server" 
                                    ControlToValidate="txtProforInvNoFoot" ErrorMessage="*" ValidationGroup="abc"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label 
                                    ID="lblDate" runat="server" Text='<%#Eval("InvDate") %>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="textDate" runat="server" CssClass="box3" 
                                    Text='<%#Eval("InvDate") %>'> </asp:TextBox>
                                <cc1:CalendarExtender ID="textDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="textDate"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqDate" runat="server" 
                                    ControlToValidate="textDate" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegDate" runat="server" 
                                    ControlToValidate="textDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="Shree"> </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="textDateF" runat="server" CssClass="box3" Width="80%"> </asp:TextBox>
                                <cc1:CalendarExtender ID="textDateF_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="textDateF"></cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqDateF" runat="server" 
                                    ControlToValidate="textDateF" ErrorMessage="*" ValidationGroup="abc"> </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegDateF" runat="server" 
                                    ControlToValidate="textDateF" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="abc"> </asp:RegularExpressionValidator>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField><asp:TemplateField HeaderText="PO No"><ItemTemplate><asp:Label 
                                    ID="lblPoNo" runat="server" Text='<%#Eval("PONo") %>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPoNo" runat="server" CssClass="box3" 
                                    Text='<%#Bind("PONo") %>' ValidationGroup="Shree" Width="97%"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqPoE" runat="server" 
                                    ControlToValidate="txtPoNo" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Panel ID="Panel21" runat="server" CssClass="box3" Height="90px" 
                                    ScrollBars="Auto"><asp:CheckBoxList ID="CBLPOList2" runat="server" 
                                        AutoPostBack="false" CssClass="fontcss" DataSourceID="SqlDataSourcePOList" 
                                        DataTextField="PONo" DataValueField="Id">
                                    </asp:CheckBoxList></asp:Panel>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                            </asp:TemplateField><asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label 
                                    ID="lblParticulars" runat="server" Text='<%#Eval("Particular") %>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtParticulars" runat="server" CssClass="box3" 
                                    Text='<%#Bind("Particular") %>' ValidationGroup="Shree" Width="99%"> </asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtParticularsFoot" runat="server" CssClass="box3" 
                                    ValidationGroup="abc" Width="99%"> </asp:TextBox>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                            </asp:TemplateField><asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:Label 
                                    ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="box3" 
                                    Text='<%#Bind("Amount") %>' ValidationGroup="Shree" Width="97%"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqAmountE" runat="server" 
                                    ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtAmountFoot" runat="server" CssClass="box3" 
                                    ValidationGroup="abc" Width="85%"> </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqAmountF" runat="server" 
                                    ControlToValidate="txtAmountFoot" ErrorMessage="*" ValidationGroup="abc"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Right" Width="6%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table border="1pt" style="border-color:GrayText" width="100%">
                                <tr>
                                    <th>
                                        Proforma Invoice No </th><th>Date </th><th>PONo </th><th>Amount </th><th>Particulars </th><th></th></tr><tr><td><asp:TextBox 
                                    ID="txtProInv" runat="server" CssClass="box3" ValidationGroup="pqr" Width="92%"> </asp:TextBox><%--<asp:RequiredFieldValidator ID="ReqProInv" runat="server" 
                                    ControlToValidate="txtProInv" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>--%> </td><td><asp:TextBox 
                                        ID="txtDate1" runat="server" CssClass="box3" ValidationGroup="pqr" Width="88%"> </asp:TextBox><cc1:CalendarExtender 
                                        ID="text_CalendarExtender" runat="server" Enabled="True" Format="dd-MM-yyyy" 
                                        TargetControlID="txtDate1"></cc1:CalendarExtender><%-- <asp:RequiredFieldValidator ID="ReqDate1" runat="server" 
                                    ControlToValidate="txtDate1" ErrorMessage="*" ValidationGroup="pqr">
                                </asp:RequiredFieldValidator>--%> <asp:RegularExpressionValidator ID="RegDate1" 
                                        runat="server" ControlToValidate="txtDate1" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="pqr"> </asp:RegularExpressionValidator></td><td><asp:Panel 
                                        ID="Panel2" runat="server" CssClass="box3" Height="90px" ScrollBars="Auto"><asp:CheckBoxList 
                                        ID="CBLPOList" runat="server" AutoPostBack="false" CssClass="fontcss" 
                                        DataSourceID="SqlDataSourcePOList" DataTextField="PONo" DataValueField="Id">
                                    </asp:CheckBoxList></asp:Panel></td><td><asp:TextBox ID="txtAmt" runat="server" 
                                        CssClass="box3" ValidationGroup="pqr" Width="92%"> </asp:TextBox><asp:RequiredFieldValidator 
                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmt" 
                                        ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator></td><td><asp:TextBox 
                                        ID="txtparticul" runat="server" CssClass="box3" ValidationGroup="pqr" 
                                        Width="99%"> </asp:TextBox></td><td><asp:Button ID="btnInsert" 
                                        runat="server" CommandName="Add1" CssClass="redbox" 
                                        OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="pqr" /></td></tr></table>
                        </EmptyDataTemplate>
                        <FooterStyle Wrap="True"></FooterStyle>
                        <PagerSettings PageButtonCount="40" />
                    </asp:GridView></asp:Panel></td></tr><tr><td align="center">&#160; </td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel21" runat="server" HeaderText="Creditors"><HeaderTemplate>Creditors</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel4" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr><td>&#160; Payment Against : &#160; </td><td>Creditors </td><td>Pay To : </td><td 
        colspan="3"><asp:TextBox ID="txtPayTo_Credit" runat="server" 
        CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender 
        ID="AutoCompleteExtender3" runat="server" CompletionInterval="100" 
        CompletionListCssClass="almt" CompletionListHighlightedItemCssClass="bgtext" 
        CompletionListItemCssClass="bg" CompletionSetCount="2" DelimiterCharacters="" 
        Enabled="True" FirstRowSelected="True" MinimumPrefixLength="1" 
        ServiceMethod="Sql" ServicePath="" 
        ShowOnlyCurrentWordInCompletionListItem="True" 
        TargetControlID="txtPayTo_Credit" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator 
        ID="RequiredFieldValidator12" runat="server" 
        ControlToValidate="txtPayTo_Credit" ErrorMessage="*" ValidationGroup="z1"></asp:RequiredFieldValidator></td><td><asp:Button 
            ID="btnSearch" runat="server" CssClass="redbox" OnClick="btnSearch_Click" 
            Text="Search" /><asp:Button ID="btnRefresh" runat="server" 
            CssClass="redbox" OnClick="btnRefresh_Click" Text="Refresh" Visible="False" /></td></tr><tr><td >Drawn On : </td><td ><asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" 
                                            CssClass="box3" DataSourceID="SqlDataSource6" DataTextField="Name" 
                                            DataValueField="Id" onselectedindexchanged="DropDownList4_SelectedIndexChanged"></asp:DropDownList></td><td height="25" valign="middle">Cheque Date : </td><td 
            height="25" valign="middle" colspan="3"><asp:TextBox 
            ID="txtChequeDate_Credit" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender 
            ID="CalendarExtender3" runat="server" Enabled="True" Format="dd-MM-yyyy" 
            TargetControlID="txtChequeDate_Credit"></cc1:CalendarExtender><asp:RequiredFieldValidator 
            ID="RequiredFieldValidator14" runat="server" 
            ControlToValidate="txtChequeDate_Credit" ErrorMessage="*" ValidationGroup="z1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
            ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtChequeDate_Credit" ErrorMessage="*" 
            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
            ValidationGroup="z1"></asp:RegularExpressionValidator></td><td >&#160;&#160;</td></tr><tr><td >Cheque No./ D.D.No.:</td><td ><asp:TextBox ID="txtChequeNo_Credit" runat="server" CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList1" 
                                ServicePath="" TargetControlID="txtChequeNo_Credit" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                        ControlToValidate="txtChequeNo_Credit" ErrorMessage="*" ValidationGroup="z1"></asp:RequiredFieldValidator></td><td>Payable At : </td><td 
        colspan="3"><asp:DropDownList 
        ID="DDListNewRegdCountry" runat="server" AutoPostBack="True" CssClass="box3" 
        OnSelectedIndexChanged="DDListNewRegdCountry_SelectedIndexChanged"><asp:ListItem 
        Value="1">India</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqRegdCountry" 
        runat="server" ControlToValidate="DDListNewRegdCountry" ErrorMessage="*" 
        InitialValue="Select" ValidationGroup="z1"></asp:RequiredFieldValidator><asp:DropDownList 
        ID="DDListNewRegdState" runat="server" AutoPostBack="True" CssClass="box3" 
        OnSelectedIndexChanged="DDListNewRegdState_SelectedIndexChanged"><asp:ListItem 
            Value="21"> Maharashtra</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqRegdState" runat="server" 
        ControlToValidate="DDListNewRegdState" ErrorMessage="*" InitialValue="Select" 
        ValidationGroup="z1"></asp:RequiredFieldValidator><asp:DropDownList 
        ID="DDListNewRegdCity" runat="server" CssClass="box3"><asp:ListItem Value="405"> Pune</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqRegdCity" runat="server" 
        ControlToValidate="DDListNewRegdCity" ErrorMessage="*" InitialValue="Select" 
        ValidationGroup="z1"></asp:RequiredFieldValidator></td><td ><asp:Label ID="Lblsupid" runat="server" Text="Label" Visible="False"></asp:Label></td></tr><tr><td ><asp:Label 
                        ID="lblOpeningBal" runat="server" Font-Bold="True" Text="Opening Bal Amt. :"></asp:Label></td><td ><asp:Label 
                            ID="lblgetbal" runat="server" style="font-weight: 700"></asp:Label></td><td><asp:Label 
                            ID="Label3" runat="server" style="font-weight: 700" Text="Total Paid:"></asp:Label><asp:Label 
                            ID="lblPaid" runat="server" style="font-weight: 700">0</asp:Label></td><td><asp:Label 
                            ID="Label6" runat="server" style="font-weight: 700" Text="Closing Bal Amt:"></asp:Label></td><td 
        style="text-align: right"><asp:Label ID="lblClosingAmt" runat="server" style="font-weight: 700">0</asp:Label></td><td align="center" 
        style="text-align: right"><asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                            Text="Payment:"></asp:Label></td><td><asp:TextBox ID="txtPayment" 
                            runat="server" CssClass="box3" Width="100px">0</asp:TextBox><asp:RegularExpressionValidator 
                            ID="RegularReqAmt" runat="server" ControlToValidate="txtPayment" 
                            ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                            ValidationGroup="z1"></asp:RegularExpressionValidator></td></tr><tr><td>Add. Charges :</td><td><asp:TextBox 
                            ID="Txtaddcharges" runat="server" CssClass="box3" Height="20px" Width="92px">0</asp:TextBox><asp:RegularExpressionValidator 
                            ID="RegularReqAmt1" runat="server" ControlToValidate="Txtaddcharges" 
                            ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                            ValidationGroup="z1"></asp:RegularExpressionValidator></td><td>Transaction Type : </td><td><asp:RadioButtonList 
                            ID="Rdbtncrtrtype" runat="server" RepeatDirection="Horizontal"><asp:ListItem 
                            Value="1">RTGS</asp:ListItem><asp:ListItem Value="2">NEFT</asp:ListItem><asp:ListItem 
                            Value="3">DD</asp:ListItem><asp:ListItem Selected="True" Value="4">CHEQUE</asp:ListItem>
                        </asp:RadioButtonList></td><td style="text-align: right">&#160;</td><td align="center" style="text-align: right">&#160;</td><td>&#160;</td></tr><tr><td><asp:Label ID="Label8" runat="server" Text="Name on Cheque : "></asp:Label></td><td align="right"><asp:RadioButton ID="Rdbtncheck" runat="server" AutoPostBack="True" 
                    GroupName="cheque" oncheckedchanged="Rdbtncheck_CheckedChanged" /></td><td><asp:TextBox ID="Txtnameoncheque" runat="server" CssClass="box3" Width="200px" 
                    Enabled="False"> </asp:TextBox></td><td><asp:RadioButton ID="Rdbtncheck1" runat="server" AutoPostBack="True" 
                    Checked="True" GroupName="cheque" 
                    oncheckedchanged="Rdbtncheck1_CheckedChanged" /><asp:DropDownList ID="DrpPaid" runat="server" CssClass="box3"></asp:DropDownList></td><td style="text-align: right">&#160;&#160; </td><td align="center" style="text-align: right">&#160;&#160; </td><td>&#160;&#160; </td></tr></table></asp:Panel><table width="100%"><tr><td><cc1:TabContainer 
            ID="TabContainer3" runat="server" ActiveTabIndex="0" Height="205px" 
            Width="100%"><cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="PVEV"><HeaderTemplate>PVEV</HeaderTemplate><ContentTemplate><asp:Panel 
                ID="Panel5" runat="server" Height="190px" ScrollBars="Auto"><asp:GridView 
                ID="GridView4" runat="server" AutoGenerateColumns="False" 
                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                 ShowFooter="True" Width="100%"><Columns><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:CheckBox ID="ck"  AutoPostBack="true" OnCheckedChanged="ck_CheckedChanged"
                            runat="server" /></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label 
                            ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="PVEV No"><ItemTemplate><asp:Label 
                            ID="lblPVEVNO0" runat="server" Text='<%#Eval("PVEVNo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="PONo"><ItemTemplate><asp:Label 
                            ID="lblPONo0" runat="server" Text='<%#Eval("PONo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Bill No"><ItemTemplate><asp:Label 
                            ID="lblBillNo" runat="server" Text='<%#Bind("BillNo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Bill Date"><ItemTemplate><asp:Label 
                            ID="lblBillDate" runat="server" Text='<%#Eval("BillDate") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Against Bill"><ItemTemplate><asp:TextBox 
                            ID="txtBill_Against" Text='<%#Bind("BillNo") %>' runat="server" CssClass="box3" Width="88%"> </asp:TextBox><asp:RequiredFieldValidator 
                            ID="ReqBillAgainst" runat="server" ControlToValidate="txtBill_Against" 
                            ErrorMessage="*" ValidationGroup="temp"> </asp:RequiredFieldValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Actual Amt"><ItemTemplate><asp:Label 
                            ID="lblActAmt" runat="server" Text='<%#Eval("ActAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Paid Amt"><ItemTemplate><asp:Label 
                            ID="lblpaidAmt" runat="server" Text='<%#Eval("PaidAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Bal Amt"><ItemTemplate><asp:Label 
                            ID="lblBalAmt" runat="server" Text='<%#Eval("BalAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:TextBox 
                            ID="txtAmount" runat="server" CssClass="box3" Width="79%"> </asp:TextBox><asp:RequiredFieldValidator 
                            ID="Req16" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" 
                            ValidationGroup="temp"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                            ID="RegularReqAmt0" runat="server" ControlToValidate="txtAmount" 
                            ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                            ValidationGroup="temp"></asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Narration"><ItemTemplate><asp:TextBox 
                            ID="txtNarration0" Text="-" runat="server" CssClass="box3" Width="99%"> </asp:TextBox></ItemTemplate><FooterStyle HorizontalAlign="Right" /><ItemStyle HorizontalAlign="Center" Width="10%" /></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                    Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></asp:Panel><table width="100%"><tr><td align="center"><asp:Button ID="btnCalculate" runat="server" CssClass="redbox" 
                        onclick="btnCalculate_Click" Text="Calculate" /><asp:Label ID="lbltotActAmt" runat="server" Font-Bold="True" 
                        Text="Total Actual Amt :    "></asp:Label><asp:Label ID="totActAmt" runat="server" Text="0"> </asp:Label><asp:Label ID="lbltotBalAmt" runat="server" Font-Bold="True" 
                        Text="Total Balance Amt :    "></asp:Label><asp:Label ID="totbalAmt" runat="server" Text="0    "> </asp:Label><asp:Label ID="Label7"  Font-Bold="True" runat="server" 
                                Text="Pay Amt :"></asp:Label><asp:Label ID="lblPayamt" Font-Bold="True" runat="server" Text="0"></asp:Label><asp:Button ID="btnAddTemp" runat="server" CssClass="redbox" 
                        OnClick="btnAddTemp_Click" Text="Add" ValidationGroup="temp" /></td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel1" runat="server" 
            HeaderText="Selected PVEV"><ContentTemplate><asp:Panel ID="Panel10" 
                runat="server" Height="250px" ScrollBars="Auto"><asp:GridView 
                ID="GridView5" runat="server" AutoGenerateColumns="False" 
                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                OnPageIndexChanging="GridView5_PageIndexChanging" 
                OnRowCancelingEdit="GridView5_RowCancelingEdit" 
                OnRowDeleting="GridView5_RowDeleting" OnRowEditing="GridView5_RowEditing" 
                PageSize="5" Width="100%"><Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton 
                        ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Delete" 
                        OnClientClick="return confirmationDelete();" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField Visible="False"><ItemTemplate><asp:Label 
                            ID="lblId1" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="PVEV No"><EditItemTemplate><asp:TextBox 
                            ID="txtPvEvE" runat="server" Text='<%#Eval("PVEVNo") %>'> </asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblPvevNo" runat="server" Text='<%#Eval("PVEVNo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Bill Against"><EditItemTemplate><asp:TextBox 
                            ID="txtBillAgstE" runat="server" Text='<%#Eval("BillAgainst") %>'> </asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblBillAgainst" runat="server" Text='<%#Eval("BillAgainst") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="25%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><EditItemTemplate><asp:TextBox 
                            ID="txtAmountE" runat="server" Text='<%#Eval("Amount") %>'> </asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblamt" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label5" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                    Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView><br /></asp:Panel></ContentTemplate></cc1:TabPanel></cc1:TabContainer></td></tr><tr><td align="center"><asp:Button ID="btnProceed_Creditor" runat="server" CssClass="redbox" 
                            OnClick="btnProceed_Creditor_Click" OnClientClick="return confirmationAdd();" 
                            Text="Proceed" ValidationGroup="z1" /></td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel_Sal" runat="server" HeaderText="Salary"><HeaderTemplate>Salary</HeaderTemplate><ContentTemplate><asp:Panel ID="plnSalary" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr><td >Payment Against : </td><td >Salary</td><td height="25" valign="middle">Pay To :</td><td height="25" valign="middle"><asp:TextBox ID="txtPayTo_Sal" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" 
                                            ServiceMethod="Sql2" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtPayTo_Sal" 
                                            UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtPayTo_Sal" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td  >&#160;</td></tr><tr><td >Drawn On :</td><td ><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                        CssClass="box3" DataSourceID="SqlDataSource3" DataTextField="Name" 
                        DataValueField="Id" onselectedindexchanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList></td><td height="25" valign="middle">Cheque Date : </td><td height="25" valign="middle"><asp:TextBox 
                                ID="TxtChequeDate_Sal" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtChequeDate_Sal"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="B"  runat="server" 
                                            ControlToValidate="TxtChequeDate_Sal" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="TxtChequeDate_Sal" ErrorMessage="*"  ValidationGroup="B" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator></td><td >&#160;</td></tr><tr><td >Cheque No./ D.D.No.:</td><td ><asp:TextBox ID="TxtChequeNo_Sal" runat="server" CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList1" 
                                ServicePath="" TargetControlID="TxtChequeNo_Sal" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtChequeNo_Sal" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td>Payable At :</td><td><asp:TextBox 
                                ID="txtPayAt_Sal" runat="server" CssClass="box3" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                            ControlToValidate="txtPayAt_Sal" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td ></td></tr><tr><td >&#160;&#160;</td></tr></table></asp:Panel><table width="100%"><tr><td align="center" style="height:25px;"><asp:Button 
                        ID="btnProceed_Sal" runat="server" CssClass="redbox" 
                        onclick="btnProceed_Sal_Click" onclientclick="return confirmationAdd();" 
                        Text="Proceed" ValidationGroup="B" /></td></tr><tr><td><asp:Panel ID="Panel9" 
                            runat="server" Height="280px" ScrollBars="Auto"><asp:GridView 
                            ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" DataKeyNames="Id" 
                            onpageindexchanging="GridView2_PageIndexChanging" 
                            onrowcancelingedit="GridView2_RowCancelingEdit" 
                            OnRowCommand="GridView2_RowCommand" onrowdatabound="GridView2_RowDataBound" 
                            onrowdeleting="GridView2_RowDeleting" onrowediting="GridView2_RowEditing" 
                            onrowupdating="GridView2_RowUpdating" PageSize="13" ShowFooter="True" 
                            Width="100%"><FooterStyle Wrap="True"></FooterStyle>
                            <Columns>
                                <asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton 
                                        ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Edit" 
                                        OnClientClick="return confirmationUpdate();" Text="Edit"> </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="Update" ValidationGroup="Shree"> </asp:LinkButton>
                                    &#160;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton 
                                        ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" 
                                        OnClientClick="return confirmationDelete();" Text="Delete"> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" runat="server" CommandName="Add" CssClass="redbox" 
                                        OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="abc" />
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label 
                                        ID="lblParticulars" runat="server" Text='<%#Eval("Particular") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtParticulars" runat="server" CssClass="box3" 
                                        Text='<%#Bind("Particular") %>' ValidationGroup="Shree" Width="99%"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtParticularsFoot" runat="server" CssClass="box3" 
                                        ValidationGroup="abc" Width="99%"> </asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:Label ID="lblAmount" 
                                        runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="box3" 
                                        Text='<%#Bind("Amount") %>' ValidationGroup="Shree" Width="92%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAmountE" runat="server" 
                                        ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtAmountFoot" runat="server" CssClass="box3" 
                                        ValidationGroup="abc" Width="92%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAmountF" runat="server" 
                                        ControlToValidate="txtAmountFoot" ErrorMessage="*" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Right" Width="6%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table border="1pt" style="border-color:GrayText" width="100%">
                                    <tr>
                                        <th>
                                            Particulars </th><th>Amount </th><th></th></tr><tr><td><asp:TextBox 
                                        ID="txtparticul" runat="server" CssClass="box3" ValidationGroup="pqr" 
                                        Width="99%"> </asp:TextBox></td><td><asp:TextBox ID="txtAmt" runat="server" 
                                            CssClass="box3" ValidationGroup="pqr" Width="92%"> </asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmt" 
                                            ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator></td><td><asp:Button 
                                            ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                            OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="pqr" /></td></tr></table>
                            </EmptyDataTemplate>
                            <PagerSettings PageButtonCount="20" />
                        </asp:GridView></asp:Panel></td></tr></table></ContentTemplate></cc1:TabPanel><cc1:TabPanel ID="TabPanel_Others" runat="server" HeaderText="Others"><HeaderTemplate>Others</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel6" ScrollBars="Auto" runat="server" ><table cellpadding="0" cellspacing="0" width="100%"><tr 
            ><td >Payment Against : </td><td >Others</td><td height="25" valign="middle">Pay To :</td><td height="25" valign="middle" align="right"><asp:DropDownList 
            ID="drptypeOther" runat="server" AutoPostBack="True" 
            OnSelectedIndexChanged="drptypeOther_SelectedIndexChanged"><asp:ListItem 
            Value="0">Select</asp:ListItem><asp:ListItem Value="1">Employee</asp:ListItem><asp:ListItem 
            Value="2">Customer</asp:ListItem><asp:ListItem Value="3">Supplier</asp:ListItem></asp:DropDownList></td><td height="25" valign="middle" width="1%"  >&#160;</td><td height="25" valign="middle"><asp:TextBox ID="txtPayTo_Others" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                        CompletionInterval="100" CompletionListCssClass="almt" 
                        CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                        CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                        FirstRowSelected="True" MinimumPrefixLength="1" 
                        ServiceMethod="GetCompletionList" ServicePath="" 
                        ShowOnlyCurrentWordInCompletionListItem="True" 
                        TargetControlID="txtPayTo_Others" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtPayTo_Others" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator></td><td>&#160;</td></tr><tr><td >Drawn On : </td><td ><asp:DropDownList ID="DropDownList3" runat="server" CssClass="box3" 
                        DataSourceID="SqlDataSource5" DataTextField="Name" DataValueField="Id" 
                            AutoPostBack="True" onselectedindexchanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList></td><td 
            height="25" valign="middle" colspan="2">Cheque Date : </td><td height="25" valign="middle">&#160; </td><td height="25" valign="middle" ><asp:TextBox ID="txtChq_Date" runat="server" CssClass="box3" Width="70%"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" 
                            Format="dd-MM-yyyy" TargetControlID="txtChq_Date"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtChq_Date" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtChq_Date" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="z"></asp:RegularExpressionValidator></td><td>&#160;</td></tr><tr><td >Cheque No./ D.D.No.:</td><td ><asp:TextBox ID="txtChqNo" runat="server" CssClass="box3"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender6" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList1" 
                                ServicePath="" TargetControlID="txtChqNo" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="txtChqNo" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator></td><td 
            colspan="2">Payable At :</td><td>&#160; </td><td ><asp:TextBox ID="txtpayAt_oth" runat="server" CssClass="box3" Width="70%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtpayAt_oth" ErrorMessage="*" ValidationGroup="z"></asp:RequiredFieldValidator></td><td></td></tr><tr><td >&#160;&#160;</td></tr></table></asp:Panel><table width="100%"><tr><td align="center" style="height:25px"><asp:Button 
                        ID="btnProceed_Oth" runat="server" CssClass="redbox" 
                        onclick="btnProceed_Oth_Click" onclientclick="return confirmationAdd();" 
                        Text="Proceed" ValidationGroup="z" /></td></tr><tr><td><asp:Panel ID="Panel7" 
                            runat="server" ScrollBars="Auto"><asp:GridView ID="GridView3" 
                            runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" DataKeyNames="Id" 
                            onpageindexchanging="GridView3_PageIndexChanging" 
                            onrowcancelingedit="GridView3_RowCancelingEdit" 
                            OnRowCommand="GridView3_RowCommand" onrowdeleting="GridView3_RowDeleting" 
                            onrowediting="GridView3_RowEditing" onrowupdating="GridView3_RowUpdating" 
                            PageSize="17" ShowFooter="True" Width="100%"><FooterStyle Wrap="True">
                            </FooterStyle>
                            <Columns>
                                <asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton 
                                        ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Edit" 
                                        OnClientClick="return confirmationUpdate();" Text="Edit"> </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="Update" ValidationGroup="Shree"> </asp:LinkButton>
                                    &#160;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton 
                                        ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" 
                                        OnClientClick="return confirmationDelete();" Text="Delete"> </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" runat="server" CommandName="Add" CssClass="redbox" 
                                        OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="abc" />
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Within Group"><ItemTemplate><asp:Label 
                                        ID="lblWithinGroup" runat="server" Text='<%#Eval("WithinGroup") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtwithGr" runat="server" CssClass="box3" 
                                        Text='<%#Bind("WithinGroup") %>' Width="99%"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtwithingrFt" runat="server" CssClass="box3" 
                                        ValidationGroup="abc" Width="85%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqWithinF" runat="server" 
                                        ControlToValidate="txtwithingrFt" ErrorMessage="*" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label 
                                        ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Label ID="lblIdE" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </EditItemTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="6%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WO No/BG Group"><ItemTemplate><asp:RadioButtonList 
                                        ID="RadioButtonWONoGroup1" runat="server" AutoPostBack="True" 
                                        RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0"> WO No </asp:ListItem><asp:ListItem 
                                        Value="1"> Group </asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonWONoGroupE" runat="server" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="RadioButtonWONoGroupE_SelectedIndexChanged" 
                                        RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0"> WO No </asp:ListItem><asp:ListItem 
                                            Value="1"> Group </asp:ListItem>
                                    </asp:RadioButtonList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:RadioButtonList ID="RadioButtonWONoGroupF" runat="server" 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="RadioButtonWONoGroupF_SelectedIndexChanged" 
                                        RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0"> WO No </asp:ListItem><asp:ListItem 
                                            Value="1"> Group </asp:ListItem>
                                    </asp:RadioButtonList>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WONo"><ItemTemplate><asp:Label ID="lblWONo" 
                                        runat="server" Text='<%#Eval("WONo") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtWONoE" runat="server" CssClass="box3"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtWONoF" runat="server" CssClass="box3" Width="83%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldtxtWONoF" runat="server" 
                                        ControlToValidate="txtWONoF" ErrorMessage="*" ValidationGroup="abc"> </asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="BG"><ItemTemplate><asp:Label ID="lblBG" 
                                        runat="server" Text='<%#Eval("BG") %>' Visible="true"> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="drpGroupE" runat="server" DataSourceID="SqlDataBG" 
                                        DataTextField="Symbol" DataValueField="Id" Visible="false">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="drpGroupF" runat="server" DataSourceID="SqlDataBG" 
                                        DataTextField="Symbol" DataValueField="Id" Visible="false">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Particulars"><ItemTemplate><asp:Label 
                                        ID="lblParticulars" runat="server" Text='<%#Eval("Particular") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtParticulars" runat="server" CssClass="box3" 
                                        Text='<%#Bind("Particular") %>' ValidationGroup="Shree" Width="99%"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtParticularsFoot" runat="server" CssClass="box3" 
                                        ValidationGroup="abc" Width="99%"> </asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount"><ItemTemplate><asp:Label ID="lblAmount" 
                                        runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="box3" 
                                        Text='<%#Bind("Amount") %>' Width="90%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAmountE" runat="server" 
                                        ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="Shree"> </asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtAmountFoot" runat="server" CssClass="box3" 
                                        ValidationGroup="abc" Width="85%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAmountF" runat="server" 
                                        ControlToValidate="txtAmountFoot" ErrorMessage="*" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Right" Width="6%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table border="1pt" style="border-color:GrayText" width="100%">
                                    <tr>
                                        <th>
                                            Within Group </th><th>WONo/BG Group </th><th></th><th>Particulars </th><th>Amount </th><th></th></tr><tr><td><asp:TextBox 
                                        ID="txtwithinGr" runat="server" CssClass="box3" Width="92%"> </asp:TextBox><asp:RequiredFieldValidator 
                                        ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtwithinGr" 
                                        ErrorMessage="*" ValidationGroup="pqr2"></asp:RequiredFieldValidator></td><td><asp:RadioButtonList 
                                            ID="RadioButtonWONoGroup" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="RadioButtonWONoGroup_SelectedIndexChanged" 
                                            RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="0">WO No</asp:ListItem><asp:ListItem 
                                            Value="1">Group</asp:ListItem>
                                        </asp:RadioButtonList></td><td><asp:TextBox ID="txtWONo" runat="server" 
                                            CssClass="box3"> </asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldtxtWONo" runat="server" ControlToValidate="txtWONo" 
                                            ErrorMessage="*" ValidationGroup="pqr2"> </asp:RequiredFieldValidator><asp:DropDownList 
                                            ID="drpGroup" runat="server" DataSourceID="SqlDataBG" DataTextField="Symbol" 
                                            DataValueField="Id" Visible="false">
                                        </asp:DropDownList></td><td><asp:TextBox ID="txtparticul" runat="server" 
                                            CssClass="box3" Width="99%"> </asp:TextBox></td><td><asp:TextBox 
                                            ID="txtAmt" runat="server" CssClass="box3" ValidationGroup="pqr2" Width="92%"> </asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmt" 
                                            ErrorMessage="*" ValidationGroup="pqr2"></asp:RequiredFieldValidator></td><td><asp:Button 
                                            ID="btnInsert" runat="server" CommandName="Add1" CssClass="redbox" 
                                            OnClientClick=" return confirmationAdd()" Text="Insert" 
                                            ValidationGroup="pqr2" /></td></tr></table>
                            </EmptyDataTemplate>
                        </asp:GridView></asp:Panel></td></tr></table></ContentTemplate></cc1:TabPanel></cc1:TabContainer></asp:Panel></ContentTemplate></cc1:TabPanel>
                    
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Receipt"><HeaderTemplate>Receipt</HeaderTemplate><ContentTemplate><asp:Panel ID="Panel2" ScrollBars="Auto" runat="server"><table width="100%"><tr><td colspan="5">&#160;</td></tr><tr><td>Receipt Against</td><td><asp:DropDownList ID="DrpTypes" runat="server" AutoPostBack="True"  
                                  CssClass="box3" OnSelectedIndexChanged="DrpTypes_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqDrpType" runat="server" ValidationGroup="M"
                                    ControlToValidate="DrpTypes" InitialValue="Select" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>Received From: <asp:DropDownList ID="drptypeReceipt" runat="server" AutoPostBack="True" 
                                    OnSelectedIndexChanged="drptypeReceipt_SelectedIndexChanged"><asp:ListItem Value="0">Select</asp:ListItem><asp:ListItem Value="1">Employee</asp:ListItem><asp:ListItem Value="2">Customer</asp:ListItem><asp:ListItem Value="3">Supplier</asp:ListItem><asp:ListItem Value="4">Others</asp:ListItem></asp:DropDownList></td><td 
                        colspan="2"><asp:TextBox ID="TxtFrom" 
                                        runat="server" CssClass="box3" 
                                    Width="250px"></asp:TextBox><cc1:AutoCompleteExtender ID="TxtFrom_AutoCompleteExtender" runat="server" 
                                    CompletionInterval="100" CompletionListCssClass="almt" 
                                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                    CompletionSetCount="2" ContextKey="key1" DelimiterCharacters="" Enabled="True" 
                                    FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="Sql3" 
                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                    TargetControlID="TxtFrom" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqFrom" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtReceived" ErrorMessage="*"></asp:RequiredFieldValidator>&#160;&#160;</td></tr><tr><td>Invoice No </td><td><asp:TextBox ID="TxtInvoiceNo" runat="server" CssClass="box3" 
                                        TextMode="MultiLine">0 </asp:TextBox></td><td>Bank Name</td><td 
                            colspan="2"><asp:TextBox ID="TxtBank" runat="server" CssClass="box3" Width="250px"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender7" runat="server" 
                                    CompletionInterval="100" CompletionListCssClass="almt" 
                                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                    CompletionSetCount="2" ContextKey="key1" DelimiterCharacters="" Enabled="True" 
                                    FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="Getbank" 
                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                    TargetControlID="TxtBank" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqReceived" runat="server" 
                                        ControlToValidate="TxtBank" ErrorMessage="*" ValidationGroup="M"></asp:RequiredFieldValidator></td></tr><tr><td>Cheque No</td><td><asp:TextBox ID="TxtChequeNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqChequeNo" runat="server" ValidationGroup="M"
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
                                    ControlToValidate="TxtReceived" ErrorMessage="*"></asp:RequiredFieldValidator></td><td 
                            width="200px">Amount</td><td><asp:TextBox ID="TxtAmount" runat="server" CssClass="box3"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                        ControlToValidate="TxtAmount" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="M"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="ReqAmount" runat="server" 
                                        ControlToValidate="TxtAmount" ErrorMessage="*" ValidationGroup="M"></asp:RequiredFieldValidator></td><td></td></tr><tr><td>Bank Account No</td><td><asp:TextBox ID="TxtBankAccNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqBankAccNo" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtBankAccNo" ErrorMessage="*"></asp:RequiredFieldValidator></td><td>Cheque Clearance Date</td><td><asp:TextBox ID="TxtClearanceDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtClearanceDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtClearanceDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqClearanceDate" runat="server" ValidationGroup="M"
                                    ControlToValidate="TxtClearanceDate" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBillDate" runat="server" 
                                    ControlToValidate="TxtClearanceDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="M"></asp:RegularExpressionValidator></td><td>&#160;</td></tr><tr><td>Transaction Type</td><td><asp:RadioButtonList ID="Rdbtncrtrtype_Rec" runat="server" 
                                    RepeatDirection="Horizontal"><asp:ListItem Value="1">RTGS</asp:ListItem><asp:ListItem Value="2">NEFT</asp:ListItem><asp:ListItem Value="3">DD</asp:ListItem><asp:ListItem Selected="True" Value="4">CHEQUE</asp:ListItem></asp:RadioButtonList></td><td 
                        align="right"><asp:RadioButton ID="rdwono" runat="server" AutoPostBack="True" 
                            Checked="True" GroupName="A" oncheckedchanged="rdwono_CheckedChanged" 
                            Text="WO No" />
                        <asp:TextBox ID="txtwono" runat="server" CssClass="box3" Width="84px">
                         </asp:TextBox></td><td colspan="2"><asp:RadioButton ID="rddept" runat="server" 
                            AutoPostBack="True" GroupName="A" oncheckedchanged="rddept_CheckedChanged" 
                            Text="BG Group" />
                        <asp:DropDownList ID="drpdept" runat="server" CssClass="box3" 
                            DataSourceID="SqlDataSource15" DataTextField="Dept" DataValueField="Id">
                        </asp:DropDownList>
                    </td></tr><tr><td>Narration</td><td><asp:TextBox ID="TxtNarration" runat="server" CssClass="box3" 
                                        TextMode="MultiLine"></asp:TextBox></td><td>Dropped In Bank</td><td><asp:DropDownList ID="DrpBankName" runat="server" DataSourceID="SqlDataSource7" 
                                        DataTextField="Name" DataValueField="Id"></asp:DropDownList></td><td valign="middle"><asp:Button ID="TxtSubmit" runat="server" CssClass="redbox" 
                                        OnClick="TxtSubmit_Click" Text="Submit" ValidationGroup="M" /></td></tr></table></asp:Panel></ContentTemplate></cc1:TabPanel>
                    
                </cc1:TabContainer>
                                            
                 <asp:SqlDataSource 
        runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource1"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource3">
        </asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource5">
    </asp:SqlDataSource>
    <asp:SqlDataSource 
        runat="server" ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT DISTINCT * FROM [tblACC_Bank]" ID="SqlDataSource6">
    </asp:SqlDataSource>                       
             
               <asp:SqlDataSource ID="SqlDataBG" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [BusinessGroup]"></asp:SqlDataSource>               
                
                
                 <b>
                 <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                     ProviderName="System.Data.SqlClient" 
                     SelectCommand="SELECT [Id], [Name] FROM [tblACC_Bank] where [Id]!=4"></asp:SqlDataSource>
            
                
                  <asp:SqlDataSource ID="SqlDataSource14" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                     ProviderName="System.Data.SqlClient" 
                     SelectCommand="SELECT [Id], [Particulars] FROM [tblACC_PaidType] "></asp:SqlDataSource>     </b>
                     
                     
                     <asp:SqlDataSource ID="SqlDataSourcePOList" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                    ProviderName="System.Data.SqlClient" 
                    
                    SelectCommand="SELECT PONo,Id FROM [tblMM_PO_Master] WHERE (([SupplierId] = @SupplierId) AND ([CompId] = @CompId))" 
                    ConflictDetection="OverwriteChanges" >
                    <SelectParameters>
                                                
                        <asp:Parameter Name="SupplierId" Type="String" />
                         <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                    </SelectParameters>
                    
                </asp:SqlDataSource> 
                
                    <asp:SqlDataSource ID="SqlDataSource15" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        ProviderName="System.Data.SqlClient" 
                        SelectCommand="Select Id, Symbol as Dept from BusinessGroup"></asp:SqlDataSource>
                
            </td>
        </tr>
        
        </table>
 
 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

