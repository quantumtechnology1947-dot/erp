<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true"   CodeFile="SalesInvoice_New_Details.aspx.cs" Inherits="Module_Accounts_Transactions_SalesInvoice_New_Details" Title="ERP"Theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>

    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%" 
        id="7">
        <tr>
            <td style="background:url(../../../images/hdbg.JPG); height:21px" 
                class="fontcsswhite" colspan="5" >&nbsp;<b>Sales Invoice - New</b></td>
        </tr>
        <tr>
            <td width="25%" height="22">
                &nbsp; Invoice No. :
                       
                            <asp:TextBox ID="TxtInvNo" CssClass="box3" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqInVNo" runat="server" 
                                ControlToValidate="TxtInvNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                       
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorInv" runat="server" ValidationGroup="A"
                            ControlToValidate="TxtInvNo" ErrorMessage="*"  ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            				</asp:RegularExpressionValidator>
            </td>
            <td>
                            Date :
                            <asp:Label ID="LblInvDate" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                            Mode of Invoice :
                            <asp:Label ID="LblMode" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td width="35%" style="width: 0%">
                            
                             <asp:SqlDataSource ID="SqlCommodity" runat="server"  ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblExciseCommodity_Master] order by [Id] asc"></asp:SqlDataSource>
            </td>
            <td width="35%" style="width: 17%">
                            <asp:SqlDataSource ID="SqlCat" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblACC_Service_Category] order by [Id] desc"></asp:SqlDataSource>
                            
            </td>
        </tr>
        <tr>
            <td height="22">
                &nbsp; PO No. :
                            <asp:Label ID="LblPONo" runat="server" 
                    style="font-weight: 700"></asp:Label>
            </td>
            <td>
                            Date :
                            <asp:Label ID="LblPODate" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                            WO No. :
                            <asp:Label ID="LblWONo" runat="server" style="font-weight: 700"></asp:Label>
            </td>
            <td>
                            
                             <asp:SqlDataSource ID="Sqltransport" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblACC_TransportMode] order by [Id] desc"></asp:SqlDataSource>
                            
            </td>
            <td>
                               <asp:SqlDataSource ID="Sqlnature" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT *  FROM [tblACC_Removable_Nature] order by [Id] desc"></asp:SqlDataSource>
                            
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%">
                    <tr>
                        <td  height="25" width="24%">
                            &nbsp;Category</td>
                        <td width="19%">
                            <asp:DropDownList ID="DrpCategory" runat="server" DataSourceID="SqlCat" 
                                DataTextField="Description" DataValueField="Id">
                            
                            </asp:DropDownList>
                            
                        </td>
                        <td class="style10" width="15%">
                            Excisable Commodity
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="DrpCommodity" runat="server" DataSourceID="SqlCommodity" 
                                DataTextField="Terms" DataValueField="Id" AutoPostBack="True" 
                                onselectedindexchanged="DrpCommodity_SelectedIndexChanged"  >
                            </asp:DropDownList>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="DrpCommodity" ErrorMessage="*" InitialValue="0" 
                                ValidationGroup="A"></asp:RequiredFieldValidator>
                            
                        </td>
                    </tr>
                    <tr>
                        <td  height="25">
                            &nbsp;Tariff Head No/ Exemption Notif. No.</td>
                        <td class="style9">
                            <asp:Label ID="TxttrafficNo" runat="server" BackColor="White"></asp:Label></td>
                        <td class="style10">
                            Rate of Duty</td>
                        <td colspan="2">
                            <asp:TextBox ID="TxtDutyRate" 
                                runat="server" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Reqrateofduty" runat="server" 
                                ControlToValidate="TxtDutyRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        &nbsp;[Tariff Rate/Notifi No. &amp; Date]</td>
                    </tr>
                    <tr>
                        <td class="style2" height="25">
                            &nbsp;Mode of Transport</td>
                        <td class="style2">
                            <asp:DropDownList ID="DrpTransport"  runat="server" DataSourceID="Sqltransport" 
                                DataTextField="Description" DataValueField="Id" >
                            </asp:DropDownList>
                            
                        </td>
                        <td class="style2">
                            R.R.G.C. No
                        </td>
                        <td class="style2" colspan="2">
                            <asp:TextBox ID="TxtRRGCNo" runat="server" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqRgcno" runat="server" 
                                ControlToValidate="TxtRRGCNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" height="25">
                            &nbsp;If by motor vehicle , it&#39;s regist. number</td>
                        <td class="style9">
                            <asp:TextBox ID="TxtRegistrationNo" runat="server" CssClass="box3"></asp:TextBox>
                        </td>
                        <td class="style10">
                            Nature Of Removal</td>
                        <td colspan="2">
                            <asp:DropDownList ID="DrpNatureremovable" runat="server" 
                                DataSourceID="Sqlnature" DataTextField="Description" DataValueField="Id"  >
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style8" height="25">
                            &nbsp;Date Of Issue Of Invoice</td>
                        <td class="style9">
                            <asp:TextBox ID="TxtDateofIssueInvoice" runat="server" CssClass="box3"></asp:TextBox>
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
                        <td class="style10">
                            Time Of Issue Of Invoice</td>
                        <td>
                            <MKB:TimeSelector ID="TimeOfIssue" runat="server" AmPm="AM" MinuteIncrement="1">
                            </MKB:TimeSelector>
                        </td>
                        <td>
                            
                             &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style8" height="25">
                            &nbsp;Date Of Removal</td>
                        <td class="style9">
                            <asp:TextBox ID="TxtDateRemoval" runat="server" CssClass="box3"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtDateRemoval_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDateRemoval">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="ReqDateofremoval" runat="server" 
                                ControlToValidate="TxtDateRemoval" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" 
                                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                ControlToValidate="TxtDateRemoval" ErrorMessage="*" ValidationGroup="A" 
                                ID="RegDateOfRemoval"></asp:RegularExpressionValidator>
                        </td>
                        <td class="style10">
                            Time Of Removal</td>
                        <td>
                            <MKB:TimeSelector ID="TimeOfRemove" runat="server" AmPm="AM" 
                                MinuteIncrement="1">
                            </MKB:TimeSelector>
                        </td>
                        <td>
                               &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="5"> 
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Height="238px" Width="100%" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Buyer" ID="TabPanel1">
                        <HeaderTemplate>Buyer
                        </HeaderTemplate>
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%"><tr><td><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%"><tr>
                            <td class="style15" width="12%">Name</td><td>
                            <asp:TextBox 
                                ID="TxtBYName" runat="server" CssClass="box3" Width="42%"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtBYName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                            <asp:RequiredFieldValidator ID="ReqByName" runat="server" 
                                ControlToValidate="TxtBYName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>&nbsp;<asp:Button ID="Button5" runat="server" CssClass="redbox" 
                                onclick="Button5_Click" Text="Search" />
                            </td></tr><tr>
                                <td class="style15" valign="top">Adderss </td><td>
                                <asp:TextBox 
                                    ID="TxtByAddress" runat="server" CssClass="box3" TextMode="MultiLine" 
                                    Width="42%" Height="115px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByAddress" runat="server" 
                                    ControlToValidate="TxtByAddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr></table></td></tr><tr><td><table align="left" cellpadding="0" cellspacing="0" class="style2" width="100%"><tr>
                                <td 
                                    class="style3" width="15%">Country </td><td class="style3" width="20%"><asp:DropDownList 
                                        ID="DrpByCountry" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="DrpByCountry_SelectedIndexChanged"></asp:DropDownList></td>
                                <td class="style3" width="12%">State </td><td class="style3" width="20%"><asp:DropDownList 
                                    ID="DrpByState" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DrpByState_SelectedIndexChanged"></asp:DropDownList></td>
                                <td class="style3" width="11%">City </td><td class="style3"><asp:DropDownList 
                                    ID="DrpByCity" runat="server" AutoPostBack="True"></asp:DropDownList></td></tr><tr>
                                    <td class="style3">Contact person </td><td class="style3">
                                    <asp:TextBox 
                                        ID="TxtByCName" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator  runat="server"  ID="ReqByCName" 
                                        ControlToValidate="TxtByCName" ErrorMessage="*" ValidationGroup="A" ></asp:RequiredFieldValidator></td>
                                    <td class="style3">Phone No. </td><td class="style3">
                                    <asp:TextBox 
                                        ID="TxtByPhone" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByPhone" runat="server" 
                                        ControlToValidate="TxtByPhone" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td>
                                    <td class="style3">Mobile No. </td><td>
                                    <asp:TextBox 
                                        ID="TxtByMobile" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByMobile" runat="server" 
                                        ControlToValidate="TxtByMobile" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style3">E-mail </td><td class="style3">
                                    <asp:TextBox 
                                        ID="TxtByEmail" runat="server" CssClass="box3" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByEmail" runat="server" 
                                        ControlToValidate="TxtByEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegEmailvalBuyer" runat="server" 
                                        ControlToValidate="TxtByEmail" ErrorMessage="*" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td><td class="style3">Fax No. </td><td class="style3">
                                    <asp:TextBox 
                                        ID="TxtByFaxNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqFaxNo" runat="server" 
                                        ControlToValidate="TxtByFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td>
                                    <td class="style3">
                                        TIN/VAT No </td><td>
                                    <asp:TextBox ID="TxtByTINVATNo" runat="server" CssClass="box3" Width="180px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByTinVatNo" runat="server" 
                                            ControlToValidate="TxtByTINVATNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style3">Customer&apos;s ECC.No. </td><td class="style3">
                                    <asp:TextBox 
                                    ID="TxtByECCNo" runat="server" CssClass="box3" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqCustEccNo" runat="server" 
                                        ControlToValidate="TxtByECCNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td><td class="style3">TIN / CST No. </td><td class="style3">
                                    <asp:TextBox 
                                    ID="TxtByTINCSTNo" runat="server" CssClass="box3" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqByTInCStNo" runat="server" 
                                            ControlToValidate="TxtByTINCSTNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style23">
                                    </td><td valign="bottom">
                                        <asp:Button ID="BtnBuy" runat="server" CssClass="redbox" OnClick="BtnBuy_Click" 
                                            Text=" Next " />
                                        <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                            onclick="Button1_Click" Text="Cancel" />
                                    </td></tr></table></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Consignee">
                        <HeaderTemplate>Consignee
                        </HeaderTemplate>
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" width="100%" ><tr><td><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr>
                            <td class="style19" width="12%">Name</td><td>
                            <asp:TextBox 
                                ID="TxtCName" runat="server" CssClass="box3" Width="42%"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtCName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                            <asp:RequiredFieldValidator ID="ReqCName" runat="server" 
                                ControlToValidate="TxtCName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;<asp:Button ID="Button4" runat="server" CssClass="redbox" 
                                Text="Search" OnClick="Button4_Click" />&nbsp;&nbsp;<asp:Button 
                                ID="Button6" runat="server"
                                    Text="Copy from buyer" CssClass="redbox" onclick="Button6_Click" />
                            </td></tr><tr>
                                <td class="style19" valign="top">Adderss </td><td>
                                <asp:TextBox 
                                    ID="TxtCAddress" runat="server" CssClass="box3" TextMode="MultiLine" 
                                    Width="42%" Height="115px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCaddress" runat="server" 
                                    ControlToValidate="TxtCAddress" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr></table></td></tr><tr><td><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr>
                                <td class="style20" width="15%" height="25">Country </td><td class="style15" 
                                    width="20%"><asp:DropDownList 
                                    ID="DrpCoCountry" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DrpCoCountry_SelectedIndexChanged"></asp:DropDownList></td>
                                <td class="style16" width="10%">State </td><td class="style17" width="22%"><asp:DropDownList 
                                    ID="DrpCoState" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DrpCoState_SelectedIndexChanged"></asp:DropDownList></td>
                                <td class="style18" width="9%">City</td><td>
                                <asp:DropDownList 
                                    ID="DrpCoCity" runat="server"></asp:DropDownList></td></tr><tr>
                                    <td class="style20" height="25">Contact person </td><td class="style15">
                                    <asp:TextBox 
                                        ID="TxtCoPersonName" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCoperson" runat="server" 
                                        ControlToValidate="TxtCoPersonName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style16">Phone No. </td><td class="style17">
                                    <asp:TextBox 
                                        ID="TxtCoPhoneNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCPhoneno" runat="server" 
                                        ControlToValidate="TxtCoPhoneNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style18">Mobile No. </td><td>
                                    <asp:TextBox 
                                        ID="TxtCoMobileNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCMobileno" runat="server" 
                                        ControlToValidate="TxtCoMobileNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style20" height="25">E-mail </td><td class="style15">
                                    <asp:TextBox 
                                        ID="TxtCoEmail" runat="server" CssClass="box3" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCEmail" runat="server" 
                                        ControlToValidate="TxtCoEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegEmailvalConsignee" runat="server" 
                                        ControlToValidate="TxtCoEmail" ErrorMessage="*" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td><td class="style16">Fax No. </td><td class="style17" 
                                        style="margin-left: 80px">
                                    <asp:TextBox 
                                        ID="TxtCoFaxNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCFaxNo" runat="server" 
                                        ControlToValidate="TxtCoFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style18">TIN/VAT No.</td><td>
                                    <asp:TextBox ID="TxtCoTinVatNo" runat="server" CssClass="box3" Width="180px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCTinVatno" runat="server" 
                                            ControlToValidate="TxtCoTinVatNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr>
                                    <td class="style20" height="25">Customer&apos;s ECC.No.</td><td class="style15">
                                    <asp:TextBox 
                                        ID="TxtECoCCNo" runat="server" CssClass="box3" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCECCNo" runat="server" 
                                        ControlToValidate="TxtECoCCNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style16">
                                        TIN/CST No.</td><td class="style17">
                                    <asp:TextBox 
                                        ID="TxtCoTinCSTNo" runat="server" CssClass="box3" Width="170px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqCTINcstno" runat="server" 
                                        ControlToValidate="TxtCoTinCSTNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style18">
                                        &nbsp;</td><td>
                                        <asp:Button ID="BtnCNext" runat="server" CssClass="redbox" 
                                            OnClick="BtnCNext_Click" Text=" Next " />
                                        <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                            onclick="Button1_Click" Text="Cancel" />
                                    </td></tr></table></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Goods">
                        <HeaderTemplate>Goods</HeaderTemplate>
                        <ContentTemplate>
                        <table align="left" cellpadding="0" cellspacing="0" class="style2" 
                                width="100%"><tr><td width="100%">
                                <asp:Panel ID="Panel1" runat="server" Height="220px" ScrollBars="Both">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CssClass="yui-datatable-theme" OnRowCommand="GridView1_RowCommand" PageSize="1" 
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SN">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="4%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ck" runat="server" ValidationGroup="B" />
                                                </ItemTemplate>
                                                <ItemStyle Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ItemDesc") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Symbol") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("TotalQty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="6%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remn Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRemnQty" runat="server" Text='<%#Eval("RemainingQty") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Of Qty">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DrpUnitQty" runat="server" CssClass="box3" 
                                                        DataSourceID="SqlUnitQty" DataTextField="Symbol" DataValueField="Id">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Req Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtReqQty" runat="server" CssClass="box3" Width="85%">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqQty" runat="server" 
                                                        ControlToValidate="TxtReqQty" ErrorMessage="*" ValidationGroup="A">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                                        runat="server" ControlToValidate="TxtReqQty" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                                                    </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="POId" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPOId" runat="server" Text='<%#Eval("POId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amt in (%)">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtAmt" runat="Server" CssClass="box3" 
                                                        Text='<%#Eval("Amt") %>' Width="85%">
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqAmt" runat="server" 
                                                        ControlToValidate="TxtAmt" ErrorMessage="*" ValidationGroup="A">
                                                    </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatoramt" 
                                                        runat="server" ControlToValidate="TxtAmt" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                                                    </asp:RegularExpressionValidator>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="12%" />
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
    
    
    
    </td></tr><tr><td align="center" height="25">
                                <asp:SqlDataSource ID="SqlUnitQty" runat="server" 
                                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                    ProviderName="System.Data.SqlClient" 
                                    SelectCommand="SELECT *  FROM [Unit_Master] order by [Id] ASC">
                                </asp:SqlDataSource>
                                <asp:Button ID="Btngoods" runat="server"  CssClass="redbox"  
                                    onclick="Btngoods_Click"  Text=" Next " />
                                <asp:Button ID="Button3" runat="server" CssClass="redbox" 
                                    onclick="Button3_Click" Text="Cancel" />
                                </td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Taxation">
                        <HeaderTemplate>Taxation
                        </HeaderTemplate>
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0"  width="750"><tr>
                            <td height="25" width="12%" >
                            Add </td>
                            <td height="25">
                                :<asp:TextBox ID="TxtAdd" runat="server" CssClass="box3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqAdd" runat="server" 
                                    ControlToValidate="TxtAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="TxtAdd" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                <asp:DropDownList ID="DrpAdd" runat="server">
                                    <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td height="25">&nbsp;&nbsp; 
                                Other Amount :
                                <asp:TextBox ID="TxtOtherAmt" runat="server" CssClass="box3">0</asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqTxtOtherAmt" runat="server" 
                                    ControlToValidate="TxtOtherAmt" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegTxtOtherAmt" runat="server" 
                                    ControlToValidate="TxtOtherAmt" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    Deduction</td>
                                <td height="25" width="40%" colspan="2">
                                    :<asp:TextBox ID="TxtDeduct" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqDed" runat="server" 
                                        ControlToValidate="TxtDeduct" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                        ControlToValidate="TxtDeduct" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:DropDownList ID="DrpDed" runat="server">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    P&amp;F</td>
                                <td height="25" colspan="2">
                                    :<asp:TextBox ID="TxtPf" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqPf" runat="server" ControlToValidate="TxtPf" 
                                        ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                        runat="server" ControlToValidate="TxtPf" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:DropDownList ID="DrpPAF" runat="server">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    CENVAT/Excise</td>
                                <td height="25" colspan="2">
                                    :<asp:DropDownList ID="DrpServiceTax" runat="server" CssClass="box3" 
                                        DataSourceID="SqlServiceTax" DataTextField="Terms" DataValueField="Id">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlVAT" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [tblVAT_Master] order by [Id] Asc">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlServiceTax" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [tblExciseser_Master] order by [Id] desc">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    SED</td>
                                <td height="25" width="20%" colspan="2">
                                    :<asp:TextBox ID="TxtSed" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqSed" runat="server" 
                                        ControlToValidate="TxtSed" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                        ControlToValidate="TxtSed" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:DropDownList ID="DrpSED" runat="server">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    AED</td>
                                <td height="25" width="20%" colspan="2">
                                    :<asp:TextBox ID="TxtAed" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqAed" runat="server" 
                                        ControlToValidate="TxtAed" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                                        ControlToValidate="TxtAed" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:DropDownList ID="DrpAED" runat="server">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    Freight</td>
                                <td height="25" width="20%" colspan="2">
                                    :<asp:TextBox ID="Txtfreight" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Reqfrieght" runat="server" 
                                        ControlToValidate="Txtfreight" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                                        ControlToValidate="Txtfreight" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:DropDownList ID="DrpFreight" runat="server">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    <asp:Label ID="lblVAT" runat="server"></asp:Label>
                                </td>
                                <td height="25" align="left" colspan="2">:<asp:DropDownList ID="DrpCst" runat="server" AutoPostBack="True"><asp:ListItem Text="C.S.T.(With C Form)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="C.S.T.(Without C Form)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DrpVAT" runat="server" DataSourceID="SqlVAT" 
                                        DataTextField="Terms" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="25">
                                    Insurance&nbsp;</td>
                                <td height="25" width="20%" colspan="2">
                                    :<asp:TextBox ID="TxtInsurance" runat="server" CssClass="box3" 
                                        OnTextChanged="TxtInsurance_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqInsurance" runat="server" 
                                        ControlToValidate="TxtInsurance" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                        runat="server" ControlToValidate="TxtInsurance" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:DropDownList ID="DrpInsurance" runat="server">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList> &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="BtnSubmit" runat="server" CssClass="redbox" 
                                        OnClick="BtnSubmit_Click" OnClientClick=" return confirmationAdd()" 
                                        Text="Submit" ValidationGroup="A" />&nbsp;
                                    <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                                        OnClick="BtnCancel_Click" Text="Cancel" />
                                </td>
                            </tr>
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

