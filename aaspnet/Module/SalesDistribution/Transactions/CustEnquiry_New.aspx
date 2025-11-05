<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustEnquiry_New, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../Javascript/PopUpMsg.js"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        #I1
        {
            height: 132px;
        }
        </style>
    
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    
    <table cellpadding="0" cellspacing="0" class="box3" width="100%" align="center" >
        <tr valign="top">
        <th align="left" class="fontcsswhite" height="20" scope="col" 
            style="background: url(../../../images/hdbg.JPG)" valign="middle">
            &nbsp;<strong>Customer Enquiry - New </strong>
        </th>
    </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%">
                    <cc1:TabPanel runat="server" HeaderText="Details" ID="TabPanel1">
                        <ContentTemplate>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" 
                                Class="fontcss" width="100%">
                               
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="25" scope="col" valign="middle" 
                                        width="10%">
                                        &nbsp;Customer&#39;s Name</th>
                                    <th align="left" colspan="4" scope="col" valign="middle">
                                        <asp:RadioButton ID="RadioBtnNew" runat="server" AutoPostBack="True" 
                                            Checked="True" GroupName="CustEnquiryNew" 
                                            oncheckedchanged="RadioBtnNew_CheckedChanged" Text="New" />
                                        &nbsp;
                                        <asp:TextBox ID="txtNewnewCustName" runat="server" CssClass="box3" 
                                            Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqCustNM" runat="server" 
                                            ControlToValidate="txtNewnewCustName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RadioButton ID="RadioBtnExisting" runat="server" AutoPostBack="True" 
                                            GroupName="CustEnquiryNew" OnCheckedChanged="RadioBtnExisting_CheckedChanged" 
                                            Text="Existing" />
                                        <asp:TextBox ID="txtNewCustomerName" runat="server" CssClass="box3" 
                                            Enabled="False" Width="300px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="txtNewCustomerName_AutoCompleteExtender" 
                                            runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                            FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql" 
                                            ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtNewCustomerName" UseContextKey="True">
                                        </cc1:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="ReqExistCust" runat="server" 
                                            ControlToValidate="txtNewCustomerName" ErrorMessage="*" 
                                            ValidationGroup="Existing"></asp:RequiredFieldValidator>
                                        <asp:Button ID="btnView" runat="server" CssClass="redbox" Enabled="False" 
                                            OnClick="btnView_Click" Text="Search" ValidationGroup="Existing" />
                                    </th>
                                </tr>
                                <tr class="graybg" valign="top">
                                    <th align="center" class="graybg" height="23" scope="col" valign="middle" 
                                        width="10%">
                                        Address/Details</th>
                                    <th align="center" class="graybg" scope="col" valign="middle" width="27%">
                                        REGD. OFFICE</th>
                                    <th align="center" class="graybg" scope="col" valign="middle" width="28%" 
                                        colspan="2">
                                        WORKS/FACTORY</th>
                                    <th align="center" class="graybg" scope="col" valign="middle" width="28%">
                                        MATERIAL DELIVERY</th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="28" scope="col" valign="top">
                                        &nbsp;Address
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewRegdAdd" runat="server" CssClass="box3" 
                                            TextMode="MultiLine" Width="230px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqRegdAdd" runat="server" 
                                            ControlToValidate="txtNewRegdAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" width="28%" colspan="2">
                                        <asp:TextBox ID="txtNewWorkAdd" runat="server" CssClass="box3" 
                                            TextMode="MultiLine" Width="230px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqWorkAdd" runat="server" 
                                            ControlToValidate="txtNewWorkAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" width="28%">
                                        <asp:TextBox ID="txtNewMaterialDelAdd" runat="server" CssClass="box3" 
                                            TextMode="MultiLine" Width="230px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqMateAdd" runat="server" 
                                            ControlToValidate="txtNewMaterialDelAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="middle">
                                        &nbsp;Country</th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:DropDownList ID="DDListNewRegdCountry" runat="server" AutoPostBack="True" 
                                            CssClass="box3" 
                                            onselectedindexchanged="DDListNewRegdCountry_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqRegdCountry" runat="server" 
                                            ControlToValidate="DDListNewRegdCountry" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" colspan="2">
                                        <asp:DropDownList ID="DDListNewWorkCountry" runat="server" AutoPostBack="True" 
                                            CssClass="box3" 
                                            onselectedindexchanged="DDListNewWorkCountry_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqWorkCountry" runat="server" 
                                            ControlToValidate="DDListNewWorkCountry" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:DropDownList ID="DDListNewMaterialDelCountry" runat="server" 
                                            AutoPostBack="True" CssClass="box3" 
                                            onselectedindexchanged="DDListNewMaterialDelCountry_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqMateCountry" runat="server" 
                                            ControlToValidate="DDListNewMaterialDelCountry" ErrorMessage="*" 
                                            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="middle">
                                        &nbsp;State</th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:DropDownList ID="DDListNewRegdState" runat="server" AutoPostBack="True" 
                                            CssClass="box3" 
                                            onselectedindexchanged="DDListNewRegdState_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqRegdState" runat="server" 
                                            ControlToValidate="DDListNewRegdState" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" colspan="2">
                                        <asp:DropDownList ID="DDListNewWorkState" runat="server" AutoPostBack="True" 
                                            CssClass="box3" 
                                            onselectedindexchanged="DDListNewWorkState_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqWorkState" runat="server" 
                                            ControlToValidate="DDListNewWorkState" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:DropDownList ID="DDListNewMaterialDelState" runat="server" 
                                            AutoPostBack="True" CssClass="box3" 
                                            onselectedindexchanged="DDListNewMaterialDelState_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqMateState" runat="server" 
                                            ControlToValidate="DDListNewMaterialDelState" ErrorMessage="*" 
                                            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="middle">
                                        &nbsp;City</th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:DropDownList ID="DDListNewRegdCity" runat="server" CssClass="box3">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqRegdCity" runat="server" 
                                            ControlToValidate="DDListNewRegdCity" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" colspan="2">
                                        <asp:DropDownList ID="DDListNewWorkCity" runat="server" CssClass="box3">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqWorkCity" runat="server" 
                                            ControlToValidate="DDListNewWorkCity" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:DropDownList ID="DDListNewMaterialDelCity" runat="server" CssClass="box3">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqMateCity" runat="server" 
                                            ControlToValidate="DDListNewMaterialDelCity" ErrorMessage="*" 
                                            InitialValue="Select" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" scope="col" valign="middle">
                                        &nbsp;PIN No.</th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewRegdPinNo" runat="server" CssClass="box3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqRegdPin" runat="server" 
                                            ControlToValidate="txtNewRegdPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" colspan="2">
                                        <asp:TextBox ID="txtNewWorkPinNo" runat="server" CssClass="box3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqWorkPin" runat="server" 
                                            ControlToValidate="txtNewWorkPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewMaterialDelPinNo" runat="server" CssClass="box3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqMatePin" runat="server" 
                                            ControlToValidate="txtNewMaterialDelPinNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="middle">
                                        &nbsp;Contact No.</th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewRegdContactNo" runat="server" CssClass="box3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqRegdContNo" runat="server" 
                                            ControlToValidate="txtNewRegdContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" colspan="2">
                                        <asp:TextBox ID="txtNewWorkContactNo" runat="server" CssClass="box3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqWorkContNo" runat="server" 
                                            ControlToValidate="txtNewWorkContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewMaterialDelContactNo" runat="server" CssClass="box3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqMateContNo" runat="server" 
                                            ControlToValidate="txtNewMaterialDelContactNo" ErrorMessage="*" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="middle">
                                        &nbsp;</th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewRegdFaxNo" runat="server" CssClass="box3" 
                                            Visible="False">-</asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqRegdFax" runat="server" 
                                            ControlToValidate="txtNewRegdFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle" colspan="2">
                                        <asp:TextBox ID="txtNewWorkFaxNo" runat="server" CssClass="box3" 
                                            Visible="False">-</asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqWorkFax" runat="server" 
                                            ControlToValidate="txtNewWorkFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewMaterialDelFaxNo" runat="server" CssClass="box3" 
                                            Visible="False">-</asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqMateFaxNo" runat="server" 
                                            ControlToValidate="txtNewMaterialDelFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" colspan="5" height="23" scope="col" valign="top">
                                        <table border="0" cellpadding="1" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="left" class="fontcss" height="23" valign="middle">
                                                    &nbsp;Contact person</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewContactPerson" runat="server" CssClass="box3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqContPerson" runat="server" 
                                                        ControlToValidate="txtNewContactPerson" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle">
                                                    E-mail</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewEmail" runat="server" CssClass="box3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqEmail" runat="server" 
                                                        ControlToValidate="txtNewEmail" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegEmail" runat="server" 
                                                        ControlToValidate="txtNewEmail" ErrorMessage="*" 
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle">
                                                    Contact No.</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewContactNo" runat="server" CssClass="box3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqContNo" runat="server" 
                                                        ControlToValidate="txtNewContactNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="fontcss" height="23" valign="middle" width="10%">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle" width="21%">
                                                    <asp:TextBox ID="txtNewJuridictionCode" runat="server" CssClass="box3" 
                                                        Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqJuridCode" runat="server" 
                                                        ControlToValidate="txtNewJuridictionCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle" width="10%">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle" width="20%">
                                                    <asp:TextBox ID="txtNewEccNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqECCNO" runat="server" 
                                                        ControlToValidate="txtNewEccNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle" width="10%">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle" width="22%">
                                                    <asp:TextBox ID="txtNewRange" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqRange" runat="server" 
                                                        ControlToValidate="txtNewRange" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="fontcss">
                                                <td align="left" class="fontcss" height="23" valign="middle">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewCommissionurate" runat="server" CssClass="box3" 
                                                        Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqCommisunurate" runat="server" 
                                                        ControlToValidate="txtNewCommissionurate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewDivn" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqDivn" runat="server" 
                                                        ControlToValidate="txtNewDivn" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewPanNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqPanNo" runat="server" 
                                                        ControlToValidate="txtNewPanNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="fontcss" height="23" valign="middle">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewTinVatNo" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqTinVat" runat="server" 
                                                        ControlToValidate="txtNewTinVatNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle">
                                                    GST No- </td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewTinCstNo" runat="server" CssClass="box3"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqTinCSt" runat="server" 
                                                        ControlToValidate="txtNewTinCstNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="fontcss" valign="middle">
                                                    &nbsp;</td>
                                                <td align="left" valign="middle">
                                                    <asp:TextBox ID="txtNewTdsCode" runat="server" CssClass="box3" Visible="False">-</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqTDS" runat="server" 
                                                        ControlToValidate="txtNewTdsCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="middle">
                                        &nbsp;Enquiry For
                                    </th>
                                    <th align="left" colspan="2" scope="col" valign="middle">
                                        &nbsp;</th>
                                    <th align="left" colspan="2" scope="col" valign="middle">
                                        <span class="style2">Remarks</span></th>
                                </tr>
                                <tr valign="top">
                                    <th align="left" class="fontcss" height="23" scope="col" valign="top">
                                        &nbsp;&nbsp;</th>
                                    <th align="left" colspan="2" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewEnquiryFor" runat="server" CssClass="box3" Height="40px" 
                                            TextMode="MultiLine" Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqEnqFor" runat="server" 
                                            ControlToValidate="txtNewEnquiryFor" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </th>
                                    <th align="left" colspan="2" scope="col" valign="middle">
                                        <asp:TextBox ID="txtNewRemark" runat="server" CssClass="box3" Height="40px" 
                                            TextMode="MultiLine" Width="300px"></asp:TextBox>
                                    </th>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" Visible="tRUE" runat="server" HeaderText="">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" width="600" visible="false">
                                <tr>
                                    <td align="left">
                                        <b>&nbsp;</b></td>
                                    <td align="left" width="83%">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:RequiredFieldValidator ID="ReqFileUpload" runat="server" 
                                            ControlToValidate="FileUpload1" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                        <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                            onclick="Button1_Click" onclientclick="return confirmationUpload()" 
                                            Text="Upload" ValidationGroup="B" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                            DeleteCommand="DELETE FROM [tblFile_Attachment] WHERE [Id] = @Id" 
                                            InsertCommand="INSERT INTO [tblFile_Attachment] ([FileName], [FileSize], [ContentType], [FileData]) VALUES (@FileName, @FileSize, @ContentType, @FileData)" 
                                            ProviderName="System.Data.SqlClient" 
                                            SelectCommand="SELECT [FileName], [FileSize], [ContentType], [FileData], [Id] FROM [tblFile_Attachment] WHERE (([CompId] = @CompId) AND ([FinYearId] = @FinYearId) AND ([SessionId] = @SessionId))" 
                                            UpdateCommand="UPDATE [tblFile_Attachment] SET [FileName] = @FileName, [FileSize] = @FileSize, [ContentType] = @ContentType, [FileData] = @FileData WHERE [Id] = @Id">
                                            <DeleteParameters>
                                                <asp:Parameter Name="Id" Type="Int32" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="FileName" Type="String" />
                                                <asp:Parameter Name="FileSize" Type="Double" />
                                                <asp:Parameter Name="ContentType" Type="String" />
                                                <asp:Parameter Name="FileData" Type="Object" />
                                            </InsertParameters>
                                            <SelectParameters>
                                                <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                                                <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                                                <asp:SessionParameter Name="SessionId" SessionField="username" Type="String" />
                                            </SelectParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="FileName" Type="String" />
                                                <asp:Parameter Name="FileSize" Type="Double" />
                                                <asp:Parameter Name="ContentType" Type="String" />
                                                <asp:Parameter Name="FileData" Type="Object" />
                                                <asp:Parameter Name="Id" Type="Int32" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                            DataSourceID="SqlDataSource1" EnableTheming="True" 
                                            onrowdatabound="GridView1_RowDataBound" Width="100%" PageSize="17">
                                            <Columns>
                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="FileName" HeaderText="FileName" 
                                                    SortExpression="FileName">
                                                    <ItemStyle Width="35%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FileSize" HeaderText="FileSize(Byte)" 
                                                    SortExpression="FileSize" />
                                                <asp:HyperLinkField DataNavigateUrlFields="Id" 
                                                    DataNavigateUrlFormatString="~/Controls/DownloadFile.aspx?Id={0}&amp;tbl=tblFile_Attachment&amp;qfd=FileData&amp;qfn=FileName&amp;qct=ContentType" 
                                                    Text="Download">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:HyperLinkField>
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
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td align="center" height="29" valign="middle">
                <asp:Button runat="server" OnClientClick="return confirmationAdd()" 
                    Text="Submit" ValidationGroup="A" CssClass="redbox" ID="Submit" 
                    OnClick="Submit_Click"></asp:Button>
&nbsp;<asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="btncancel" 
                    OnClick="btncancel_Click"></asp:Button>
            &nbsp;
                <asp:Label ID="lblmsg" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

