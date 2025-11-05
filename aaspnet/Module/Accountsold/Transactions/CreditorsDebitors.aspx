<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreditorsDebitors.aspx.cs" Inherits="Module_Accounts_Transactions_CreditorsDebitors" Title="ERP"  Theme="Default"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style4
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal; 
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
            height: 21px;
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
    <table align="center" style="width: 100%" cellpadding="0" cellspacing="0"  >
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" 
                class="style4" colspan="2"><b>
                &nbsp;Creditors / Debitors</b></td>
        </tr>

        
            <tr>
            <td>
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  
                    AutoPostBack="True" Width="100%" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged" >
            <cc1:TabPanel runat="server" HeaderText="Creditors" ID="Creditors"> 
                <HeaderTemplate>
                Creditors</HeaderTemplate>
            <ContentTemplate><table width="100%" align="center" ><tr><td align="left" ><b>Supplier Name</b> :<asp:TextBox ID="TextBox1" runat="server" CssClass="box3" 
                    Width="300px"></asp:TextBox><cc1:AutoCompleteExtender 
                    ID="Txt_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" CompletionListCssClass="almt" 
                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                    CompletionSetCount="2" ContextKey="key1" DelimiterCharacters="" Enabled="True" 
                    FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql3" 
                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                    TargetControlID="TextBox1" UseContextKey="True"></cc1:AutoCompleteExtender><asp:Button ID="btn_Search" runat="server" CssClass="redbox" 
                    onclick="btn_Search_Click" Text="Search" />&#160;</td></tr><tr><td align="center"><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                            OnRowCommand="GridView1_RowCommand" PageSize="18" ShowFooter="True" Width="98%"><Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkBtnDel" runat="server" CausesValidation="False" 
                                            CommandName="Del" OnClientClick=" return confirmationDelete()" Text="Delete"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><FooterTemplate><asp:Button ID="btnInsert" runat="server" CommandName="Add" CssClass="redbox" 
                                            OnClientClick=" return confirmationAdd()" Text="Insert" ValidationGroup="abc" /></FooterTemplate><ItemStyle HorizontalAlign="Center" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Creditors"><ItemTemplate><asp:Label ID="lblTerms2" runat="server" Text='<%#Eval("SupplierName") %>' Visible="false"> </asp:Label><asp:LinkButton
                                                ID="lblTerms" CommandName="LnkBtn" runat="server" Text='<%#Eval("SupplierName") %>'><%#Eval("SupplierName") %></asp:LinkButton></ItemTemplate><FooterTemplate><asp:TextBox ID="txtTerms2" runat="server" CssClass="box3" Width="90%"> </asp:TextBox><cc1:AutoCompleteExtender ID="txtTerms2_AutoCompleteExtender" runat="server" 
                                            CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="1" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" ContextKey="key1" ServiceMethod="sql3" 
                                            ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtTerms2" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqTerms" runat="server" 
                                            ControlToValidate="txtTerms2" ErrorMessage="*" ValidationGroup="abc"> </asp:RequiredFieldValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" /></asp:TemplateField><asp:TemplateField HeaderText="Opening Amt" SortExpression="OpeningAmt"><ItemTemplate><asp:Label ID="lblOpeningAmt" runat="server" Text='<%#Eval("OpeningAmt") %>'> </asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtOpeningAmt2" runat="server" CssClass="box3" Width="70%"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqOpeningAmt2" runat="server" 
                                            ControlToValidate="txtOpeningAmt2" ErrorMessage="*" ValidationGroup="abc"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegulartxtOpeningAmt2" runat="server" 
                                            ControlToValidate="txtOpeningAmt2" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="abc"> </asp:RegularExpressionValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Booked Bill"><ItemTemplate><asp:Label ID="lblBookBill" runat="server" Text='<%#Eval("BookBillAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS Amount">
                                            <ItemTemplate><asp:Label ID="lblTDSAmt" runat="server" Text='<%#Eval("TDSAmt") %>'> </asp:Label></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Payment"><ItemTemplate><asp:Label ID="lblPayment" runat="server" Text='<%#Eval("PaymentAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Closing Amt"><ItemTemplate><asp:Label ID="lblClosingAmt" runat="server" Text='<%#Eval("ClosingAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="SupplierId" Visible="False"><ItemTemplate><asp:Label ID="lblSupId" runat="server" Text='<%#Eval("SupplierId") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table><tr><td></td><td align="center"><asp:Label ID="Label1" runat="server" Font-Bold="true" 
                                Font-Names="Times New Roman" Font-Size="Medium" Text="Creditors"></asp:Label></td><td align="center"><asp:Label ID="Label2" runat="server" Font-Bold="true" 
                                                Font-Names="Times New Roman" Font-Size="Medium" Text="Opening Amt"></asp:Label></td></tr><tr><td><asp:Button ID="btnInsert0" runat="server" CommandName="Add1" CssClass="redbox" 
                                OnClientClick="return confirmationAdd()" Text="Insert" ValidationGroup="pqr" /></td><td><asp:TextBox ID="txtTerms3" runat="server" CssClass="box3" Width="400px" /><cc1:AutoCompleteExtender ID="txtTerms3_AutoCompleteExtender" runat="server" 
                                    CompletionInterval="100" CompletionListCssClass="almt" 
                                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                    CompletionSetCount="1" ContextKey="key1" DelimiterCharacters="" Enabled="True" 
                                    FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql3" 
                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                    TargetControlID="txtTerms3" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqTerm0" runat="server" 
                                    ControlToValidate="txtTerms3" ErrorMessage="*" ValidationGroup="pqr"> </asp:RequiredFieldValidator></td><td><asp:TextBox ID="txtValue3" runat="server" CssClass="box3" Width="100px" /><asp:RequiredFieldValidator ID="Reqvalue0" runat="server" 
                                                ControlToValidate="txtValue3" ErrorMessage="*" ValidationGroup="pqr"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpValAmount0" runat="server" 
                                                ControlToValidate="txtValue3" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="pqr"> </asp:RegularExpressionValidator></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True" /><PagerSettings PageButtonCount="40" /></asp:GridView></td></tr><tr><td align="center"><asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300" 
                            style="font-weight: 700"></asp:Label></td></tr></table>   
                        
                </ContentTemplate>            
            </cc1:TabPanel>
                
            <cc1:TabPanel  runat="server" HeaderText="Debitors" ID="Debitors">                           
            <ContentTemplate><table width="100%" align="center" ><tr><td><b>Debitors Name : </b><asp:TextBox 
                    ID="TextBox2" runat="server" CssClass="box3" Width="300px"></asp:TextBox><cc1:AutoCompleteExtender 
                    ID="TextBox2_AutoCompleteExtender" runat="server" CompletionInterval="100" 
                    CompletionListCssClass="almt" CompletionListHighlightedItemCssClass="bgtext" 
                    CompletionListItemCssClass="bg" CompletionSetCount="2" ContextKey="key2" 
                    DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                    MinimumPrefixLength="1" ServiceMethod="sql3" ServicePath="" 
                    ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TextBox2" 
                    UseContextKey="True"></cc1:AutoCompleteExtender><asp:Button ID="btn_deb_search" runat="server" CssClass="redbox" 
                    onclick="btn_deb_search_Click" Text="Search" /></td></tr><tr><td align="center" ><asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCommand="GridView2_RowCommand" PageSize="18" ShowFooter="True" 
                        Width="98%"><Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkBtnDelD" runat="server" CausesValidation="False" 
                                    CommandName="DelD" OnClientClick=" return confirmationDelete()" Text="Delete"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><FooterTemplate><asp:Button ID="btnInsertD" runat="server" CommandName="AddD" CssClass="redbox" 
                                    OnClientClick=" return confirmationAdd()" Text="Insert" 
                                    ValidationGroup="abcD" /></FooterTemplate><ItemStyle HorizontalAlign="Center" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Debitors"><ItemTemplate><asp:Label ID="lblCustomerId" runat="server" Text='<%#Eval("CustomerName") %>'> </asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtCustomerId2" runat="server" CssClass="box3" Width="90%"> </asp:TextBox><cc1:AutoCompleteExtender ID="TxtCustomerId2_AutoCompleteExtender" 
                                    runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                    CompletionSetCount="1" DelimiterCharacters="" Enabled="True" 
                                    FirstRowSelected="True" MinimumPrefixLength="1" ContextKey="key2" ServiceMethod="sql3" 
                                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                    TargetControlID="txtCustomerId2" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqTermsD" runat="server" 
                                    ControlToValidate="txtCustomerId2" ErrorMessage="*" ValidationGroup="abcD"> </asp:RequiredFieldValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Left" Width="35%" /></asp:TemplateField><asp:TemplateField HeaderText="Opening Amt" SortExpression="OpeningAmt"><ItemTemplate><asp:Label ID="lblOpeningAmtD" runat="server" Text='<%#Eval("OpeningAmt") %>'> </asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="txtOpeningAmtD2" runat="server" CssClass="box3" Width="70%"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqOpeningAmtD2" runat="server" 
                                    ControlToValidate="txtOpeningAmtD2" ErrorMessage="*" ValidationGroup="abcD"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegulartxtOpeningAmtD2" runat="server" 
                                    ControlToValidate="txtOpeningAmtD2" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="abcD"> </asp:RegularExpressionValidator></FooterTemplate><FooterStyle HorizontalAlign="Left" /><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Sales Invoice"><ItemTemplate><asp:Label ID="lblSalesInv" runat="server" Text='<%#Eval("SalesInvAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Service Invoice"><ItemTemplate><asp:Label ID="lblServiceInv" runat="server" Text='<%#Eval("ServiceInvAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Performa Invoice"><ItemTemplate><asp:Label ID="lblperformaInv" runat="server" Text='<%#Eval("PerformaInvAmt") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblIdD" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table><tr><td></td><td align="center"><asp:Label ID="Label3" runat="server" Font-Bold="true" 
                        Font-Names="Times New Roman" Font-Size="Medium" Text="Debitors"></asp:Label></td><td align="center"><asp:Label ID="Label4" runat="server" Font-Bold="true" 
                                        Font-Names="Times New Roman" Font-Size="Medium" Text="Opening Amt"></asp:Label></td></tr><tr><td><asp:Button ID="btnInsertD0" runat="server" CommandName="AddD1" 
                            CssClass="redbox" OnClientClick="return confirmationAdd()" Text="Insert" 
                            ValidationGroup="pqrD" /></td><td><asp:TextBox ID="txtTermsD3" runat="server" CssClass="box3" Width="400px" /><cc1:AutoCompleteExtender ID="TxtTermsD3_AutoCompleteExtender" runat="server" 
                                CompletionInterval="100" CompletionListCssClass="almt" 
                                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                CompletionSetCount="1" DelimiterCharacters="" Enabled="True" 
                                FirstRowSelected="True" MinimumPrefixLength="1" ContextKey="key2" ServiceMethod="sql3" 
                                ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                TargetControlID="txtTermsD3" UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="ReqTermD0" runat="server" 
                                ControlToValidate="txtTermsD3" ErrorMessage="*" ValidationGroup="pqr"> </asp:RequiredFieldValidator></td><td><asp:TextBox ID="txtValueD3" runat="server" CssClass="box3" Width="100px" /><asp:RequiredFieldValidator ID="ReqvalueD0" runat="server" 
                                        ControlToValidate="txtValueD3" ErrorMessage="*" ValidationGroup="pqrD"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpValAmountD0" runat="server" 
                                        ControlToValidate="txtValueD3" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="pqr"> </asp:RegularExpressionValidator></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True" /><PagerSettings PageButtonCount="40" /></asp:GridView></td></tr><tr><td align="center"><asp:Label ID="lblMessage2" runat="server" ForeColor="#FF3300" 
                            style="font-weight: 700" Text="Label"></asp:Label></td></tr><tr><td><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_Debitors_Master] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblACC_Debitors_Master] ([SysDate],[SysTime],[SessionId],[CompId],[FinYearId],[CustomerId],[OpeningAmt]) VALUES (@SysDate,@SysTime,@SessionId,@CompId,@FinYearId, @CustomerId, @OpeningAmt)" 
                    SelectCommand="SELECT tblACC_Debitors_Master.Id,SD_Cust_master.CustomerName+' ['+SD_Cust_master.CustomerId+']' AS CustomerId,tblACC_Debitors_Master.OpeningAmt FROM tblACC_Debitors_Master INNER JOIN SD_Cust_master ON tblACC_Debitors_Master.CustomerId = SD_Cust_master.CustomerId order by [Id] desc"  ><DeleteParameters><asp:Parameter Name="Id" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter Name="SysDate" Type="String" /><asp:Parameter Name="SysTime" Type="String" /><asp:Parameter Name="SessionId" Type="String" /><asp:Parameter Name="CompId" Type="Int32" /><asp:Parameter Name="FinYearId" Type="Int32" /><asp:Parameter Name="CustomerId" Type="String" /><asp:Parameter Name="OpeningAmt" Type="Double" /></InsertParameters></asp:SqlDataSource></td></tr></table>
                  
                        
                </ContentTemplate>
            </cc1:TabPanel>
            </cc1:TabContainer> 
            </td>
            </tr>    
        
       
         
      
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

