
<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_ServiceTaxInvoice_New_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script type="text/javascript">
    
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
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
                class="fontcsswhite" colspan="4" >&nbsp;<b>Service Tax Invoice - New</b></td>
        </tr>
        <tr>
            <td width="20%" height="24">
                &nbsp; Ser. Tax Invoice No.&nbsp;<asp:TextBox ID="TxtInvNo" CssClass="box3" runat="server" ValidationGroup="A"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqInVNo" runat="server" 
                                ControlToValidate="TxtInvNo" ErrorMessage="*" ValidationGroup="A">
                                </asp:RequiredFieldValidator>
                       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorInv" runat="server" ValidationGroup="A"
                            ControlToValidate="TxtInvNo" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
            </td>
            <td width="12%">
                            Date :
                            <asp:Label ID="LblInvDate" runat="server" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td width="20%">
                            <asp:SqlDataSource ID="SqlCat" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblACC_Service_Category] order by [Id] desc"></asp:SqlDataSource>
                            
            </td>
            <td width="20%">
                            
                        <asp:SqlDataSource ID="SqlTaxableServices" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblACC_TaxableServices] order by [Id] desc">
                    </asp:SqlDataSource>                            
                            
            </td>
        </tr>
        <tr>
            <td width="20%" height="24">
                &nbsp; PO No. :&nbsp;<asp:Label ID="LblPONo" runat="server" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td>
                            Date :
                            <asp:Label ID="LblPODate" runat="server" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td width="20%">
                            WO No. :
                            <asp:Label ID="LblWONo" runat="server" Text="Label" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td width="20%">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" width="7%">
                <table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%">
                    <tr>
                        <td height="25" width="20%">
                            &nbsp;&nbsp;Category</td>
                        <td class="style9" width="18%">
                            <asp:DropDownList ID="DrpCategory" runat="server" DataSourceID="SqlCat" 
                                DataTextField="Description" DataValueField="Id">
                            
                            </asp:DropDownList>
                            
                        </td>
                        <td width="20%">
                            Rate of Duty</td>
                        <td>
                            <asp:TextBox ID="TxtDutyRate" 
                                runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Reqrateofduty" runat="server" 
                                ControlToValidate="TxtDutyRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="25">
                            &nbsp;&nbsp;Taxable Services</td>
                        <td class="style9">
                            <asp:DropDownList ID="DrpTaxableServices" runat="server" DataSourceID="SqlTaxableServices" 
                                DataTextField="Description" DataValueField="Id">                            
                            </asp:DropDownList>
                            
                     </td>
                        <td width="10%">                             
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td class="style8" height="25">
                            &nbsp;
                            Date Of Issue Of Invoice</td>
                        <td class="style9">
                            <asp:TextBox ID="TxtDateofIssueInvoice" runat="server" ValidationGroup="A" 
                                CssClass="box3"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDateofIssueInvoice_CalendarExtender" 
                                runat="server" Enabled="True" Format="dd-MM-yyyy" 
                                TargetControlID="TxtDateofIssueInvoice">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="ReqDateofinvoce" runat="server" 
                                ControlToValidate="TxtDateofIssueInvoice" ErrorMessage="*" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" 
                                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                ControlToValidate="TxtDateofIssueInvoice" ErrorMessage="*" ValidationGroup="A" 
                                ID="RegDateOfIssInvoice"></asp:RegularExpressionValidator>
                        </td>
                        <td width="12%">
                            Time of Issue of Invoice</td>
                        <td>
                           
                            <MKB:TimeSelector ID="TimeSelector1" runat="server" AmPm="AM" 
                                MinuteIncrement="1">
                            </MKB:TimeSelector>
                        </td>
                    </tr>
                   
                    </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <cc1:TabContainer ID="TabContainer1"  runat="server" ActiveTabIndex="0" 
                    Height="300px" Width="100%" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Buyer" ID="TabPanel1">
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%"><tr><td><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%"><tr>
                            <td class="style15" width="12%" height="25">Name</td><td><asp:TextBox 
                                ID="TxtBYName" runat="server" ValidationGroup="A" CssClass="box3" 
                                Width="42%"></asp:TextBox>
                           <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtBYName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                            <asp:RequiredFieldValidator ID="ReqByName" runat="server" 
                                ControlToValidate="TxtBYName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:Button
                                    ID="Button3" runat="server" Text="Search" CssClass="redbox" 
                                onclick="Button3_Click" /></td></tr><tr>
                                <td class="style15" valign="top">Adderss</td><td>
                                <asp:TextBox 
                                    ID="TxtByAddress" runat="server" ValidationGroup="A" CssClass="box3" 
                                    TextMode="MultiLine" Width="42%" Height="125px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByAddress" runat="server" 
                                    ControlToValidate="TxtByAddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr></table></td></tr><tr><td><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%"><tr>
                                <td 
                                    class="style13" width="15%" height="25">Country</td><td class="style13" 
                                    width="20%"><asp:DropDownList 
                                        ID="DrpByCountry" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="DrpByCountry_SelectedIndexChanged"></asp:DropDownList>
                                </td><td class="style13" width="10%">State</td><td class="style13" width="19%"><asp:DropDownList 
                                    ID="DrpByState" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DrpByState_SelectedIndexChanged"></asp:DropDownList></td>
                                <td class="style13" width="9%">City</td><td class="style13"><asp:DropDownList 
                                    ID="DrpByCity" runat="server" AutoPostBack="True"></asp:DropDownList></td></tr><tr>
                                    <td class="style21" height="25">Contact person</td><td class="style22">
                                    <asp:TextBox 
                                        ID="TxtByCName" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator  runat="server"  ID="ReqByCName" 
                                        ControlToValidate="TxtByCName" ErrorMessage="*" ValidationGroup="A" ></asp:RequiredFieldValidator></td><td class="style23">Phone No.</td><td class="style24">
                                    <asp:TextBox 
                                        ID="TxtByPhone" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByPhone" runat="server" 
                                        ControlToValidate="TxtByPhone" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style23">Mobile No.</td><td>
                                    <asp:TextBox 
                                        ID="TxtByMobile" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByMobile" runat="server" 
                                        ControlToValidate="TxtByMobile" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style21" height="25">E-mail</td><td class="style22">
                                    <asp:TextBox 
                                        ID="TxtByEmail" runat="server" ValidationGroup="A" CssClass="box3" 
                                        Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByEmail" runat="server" 
                                        ControlToValidate="TxtByEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegEmailvalBuyer" runat="server" 
                                        ControlToValidate="TxtByEmail" ErrorMessage="*" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td><td class="style23">Fax No.</td><td class="style24">
                                    <asp:TextBox 
                                        ID="TxtByFaxNo" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqFaxNo" runat="server" 
                                        ControlToValidate="TxtByFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style23">TIN / VAT No</td>
                                    <td height="25">
                                        <asp:TextBox ID="TxtByTINVATNo" runat="server" ValidationGroup="A" 
                                            CssClass="box3" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByTinVatNo" runat="server" 
                                            ControlToValidate="TxtByTINVATNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td height="24">Customer&#39;s ECC.No.</td><td class="style22">
                                    <asp:TextBox 
                                    ID="TxtByECCNo" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCustEccNo" runat="server" 
                                        ControlToValidate="TxtByECCNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style23">GST No.</td><td class="style24">
                                    <asp:TextBox 
                                    ID="TxtByTINCSTNo" runat="server" ValidationGroup="A" CssClass="box3" 
                                        Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByTInCStNo" runat="server" 
                                            ControlToValidate="TxtByTINCSTNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style23">
                                        &nbsp;</td><td>
                                        <asp:Button ID="BtnBuy" runat="server" CssClass="redbox" OnClick="BtnBuy_Click" 
                                            Text=" Next " />
                                        <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                            onclick="Button1_Click" Text="Cancel" />
                                    </td></tr></table></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Consignee">
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" width="100%" ><tr><td><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr>
                            <td class="style19" width="12%" height="25">Name</td><td><asp:TextBox 
                                ID="TxtCName" runat="server" ValidationGroup="A" CssClass="box3" 
                                Width="42%"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtCName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                            <asp:RequiredFieldValidator ID="ReqCName" runat="server" 
                                ControlToValidate="TxtCName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:Button
                                    ID="Button6" runat="server" Text="Search" CssClass="redbox" 
                                onclick="Button6_Click" />&nbsp;&nbsp;<asp:Button
                                        ID="Button5" runat="server" Text="Copy from Buyer" 
                                CssClass="redbox" onclick="Button5_Click" /></td></tr><tr>
                                <td class="style19" height="25" valign="top">Adderss</td><td>
                                <asp:TextBox 
                                    ID="TxtCAddress" runat="server" ValidationGroup="A" CssClass="box3" 
                                    TextMode="MultiLine" Width="42%" Height="125px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCaddress" runat="server" 
                                    ControlToValidate="TxtCAddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr></table></td></tr><tr><td><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr>
                                <td class="style20" width="15%" height="25">Country</td><td class="style15" 
                                    width="20%"><asp:DropDownList 
                                    ID="DrpCoCountry" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DrpCoCountry_SelectedIndexChanged"></asp:DropDownList></td><td class="style16" width="12%">State </td><td class="style17" width="19%"><asp:DropDownList 
                                    ID="DrpCoState" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DrpCoState_SelectedIndexChanged"></asp:DropDownList></td>
                                <td class="style18" width="12%">City</td><td><asp:DropDownList 
                                    ID="DrpCoCity" runat="server" AutoPostBack="True"></asp:DropDownList></td></tr><tr>
                                    <td class="style20" height="25">Contact person </td><td class="style15">
                                    <asp:TextBox 
                                        ID="TxtCoPersonName" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCoperson" runat="server" 
                                        ControlToValidate="TxtCoPersonName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style16">Phone No. </td><td class="style17">
                                    <asp:TextBox 
                                        ID="TxtCoPhoneNo" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCPhoneno" runat="server" 
                                        ControlToValidate="TxtCoPhoneNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style18">Mobile No. </td><td>
                                    <asp:TextBox 
                                        ID="TxtCoMobileNo" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCMobileno" runat="server" 
                                        ControlToValidate="TxtCoMobileNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style20" height="25">E-mail </td><td class="style15">
                                    <asp:TextBox 
                                        ID="TxtCoEmail" runat="server" ValidationGroup="A" CssClass="box3" 
                                        Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCEmail" runat="server" 
                                        ControlToValidate="TxtCoEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegEmailvalConsignee" runat="server" 
                                        ControlToValidate="TxtCoEmail" ErrorMessage="*" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td><td class="style16">Fax No. </td><td class="style17">
                                    <asp:TextBox 
                                        ID="TxtCoFaxNo" runat="server" ValidationGroup="A" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCFaxNo" runat="server" 
                                        ControlToValidate="TxtCoFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style18">
                                        TIN / VAT No.</td><td>
                                    <asp:TextBox ID="TxtCoTinVatNo" runat="server" ValidationGroup="A" 
                                        CssClass="box3" Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCTinVatno" runat="server" 
                                            ControlToValidate="TxtCoTinVatNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style20" height="25">Customer&#39;s ECC.No.</td><td class="style15">
                                    <asp:TextBox 
                                        ID="TxtECoCCNo" runat="server" ValidationGroup="A" CssClass="box3" 
                                        Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCECCNo" runat="server" 
                                        ControlToValidate="TxtECoCCNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style16">GST No.</td><td class="style17">
                                    <asp:TextBox 
                                        ID="TxtCoTinCSTNo" runat="server" ValidationGroup="A" CssClass="box3" 
                                        Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCTINcstno" runat="server" 
                                        ControlToValidate="TxtCoTinCSTNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style18">
                                        &nbsp;</td><td>
                                        <asp:Button ID="BtnCNext" runat="server" CssClass="redbox" 
                                            OnClick="BtnCNext_Click" Text=" Next " />
                                        <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                            onclick="Button2_Click" Text="Cancel" />
                                    </td></tr></table></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3"    runat="server" HeaderText="Goods">
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style2" 
                                width="100%"><tr><td width="100%">                                
                                <asp:Panel ID="Panel1" runat="server" Height="290px" ScrollBars="Auto">
                                    <asp:SqlDataSource ID="SqlUnitQty" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [Unit_Master] order by [Id] ASC">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlUnit" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [Unit_Master] order by [Id] ASC">
                                    </asp:SqlDataSource>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CssClass="yui-datatable-theme" 
                                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                                        OnRowCommand="GridView1_RowCommand" Width="98%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SN">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="3%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ItemDesc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("TotalQty") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remn Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemnQty" runat="server" Text='<%#Eval("RemainingQty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ck" runat="server" ValidationGroup="B" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Of Qty">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DrpUnitQty" runat="server" CssClass="box3" 
                                                        DataSourceID="SqlUnitQty" DataTextField="Symbol" DataValueField="Id" 
                                                        Width="100%">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle Width="6%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Req Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtReqQty" runat="server" CssClass="box3">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqQty" runat="server" 
                                                        ControlToValidate="TxtReqQty" ErrorMessage="*" ValidationGroup="B">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                                        runat="server" ControlToValidate="TxtReqQty" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B">
                                                    </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amt in (%)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtAmt" runat="Server" CssClass="box3" Text="100">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqAmt" runat="server" 
                                                        ControlToValidate="TxtAmt" ErrorMessage="*" ValidationGroup="B">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatoramt" 
                                                        runat="server" ControlToValidate="TxtAmt" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B">
                                                    </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
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
                    
                    
                    </td></tr><tr><td align="center"><asp:Button ID="Btngoods" runat="server"   
                                    onclick="Btngoods_Click"  Text=" Next " CssClass="redbox" />
                                <asp:Button ID="Button7" runat="server" CssClass="redbox" 
                                    OnClick="Button2_Click" Text="Cancel" />
                                </td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Taxation">
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%">
                            <tr>
                                <td height="25" width="10%">
                                    Add</td>
                                <td height="25" width="16%">
                                    <asp:TextBox ID="TxtAdd" runat="server" CssClass="box3" ValidationGroup="A"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAdd" runat="server" 
                                        ControlToValidate="TxtAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                        ControlToValidate="TxtAdd" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </td>
                                <td height="25">
                                    <asp:DropDownList ID="DrpAdd" runat="server" CssClass="box3">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25" width="10%">
                                    Deduction</td>
                                <td height="25" width="16%">
                                    <asp:TextBox ID="TxtDeduct" runat="server" CssClass="box3" ValidationGroup="A"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqDed" runat="server" 
                                        ControlToValidate="TxtDeduct" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ControlToValidate="TxtDeduct" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </td>
                                <td height="25">
                                    <asp:DropDownList ID="DrpDed" runat="server" CssClass="box3">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25" width="10%">
                                    Service Tax</td>
                                <td height="25" width="16%">
                                    <asp:DropDownList ID="DrpServiceTax" runat="server" CssClass="box3" 
                                        DataSourceID="SqlServiceTax" DataTextField="Terms" DataValueField="Id" 
                                        Width="133px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlServiceTax" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [tblExciseser_Master] order by [Id] desc">
                                    </asp:SqlDataSource>
                                </td>
                                <td height="25">
                                    <asp:Button ID="BtnSubmit" runat="server" CssClass="redbox" 
                                        OnClick="BtnSubmit_Click" OnClientClick=" return confirmationAdd()" 
                                        Text="Submit" ValidationGroup="A" />
                                    <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                                        OnClick="BtnCancel_Click" Text="Cancel" />
                                </td>
                            </tr>

                            
                            
                            
                            </td></tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

