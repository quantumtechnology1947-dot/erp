<%@ page language="C#" masterpagefile="~/MasterPage.master" culture="en-GB" autoeventwireup="true" inherits="Module_Inventory_Reports_Search, newerp_deploy" title="ERP" enableviewstate="true" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
   
   
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
       
      
       
        <tr>
            <td align="left" valign="middle"  scope="col" height="21" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
        &nbsp;<b> Search </b></td>
        </tr></table>
          <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True">
                    <cc1:TabPanel runat="server" HeaderText="GIN Search" ID="GIN">
                       
                        
                        <HeaderTemplate>
                            GIN Search
                        </HeaderTemplate>
                       
                        
<ContentTemplate><table  width="100%" align="center"><tr><td class="style3" 
        colspan="2" height="25">&nbsp;Enter Nos.&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Drpoption" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="Drpoption_SelectedIndexChanged"><asp:ListItem Value="0">All</asp:ListItem><asp:ListItem Value="1">GIN No</asp:ListItem><asp:ListItem Value="2">GRR No</asp:ListItem><asp:ListItem Value="3">GQN No</asp:ListItem><asp:ListItem Value="4">GSN No</asp:ListItem><asp:ListItem 
        Value="5">PO No</asp:ListItem></asp:DropDownList>&#160;<asp:TextBox ID="txtNo" runat="server" CssClass="box3"></asp:TextBox>&#160;&#160; &#160; &#160;&#160;&#160; &#160;&#160;Report For: <asp:RadioButton 
        ID="RadPO" runat="server" Checked="True" GroupName="APR" Text="PO" />&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="RadGin" runat="server" GroupName="APR" 
                    Text="GIN" />&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="RadGRR" runat="server" 
        GroupName="APR" Text="GRR" />&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="RadGQN" 
        runat="server" GroupName="APR" Text="GQN" />&#160;&#160; <asp:RadioButton ID="RadGSn" runat="server" GroupName="APR" Text="GSN" />&#160; &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </td></tr><tr>
        <td class="style4">
            <asp:CheckBox ID="CkItem" runat="server" AutoPostBack="True" 
                OnCheckedChanged="CkItem_CheckedChanged" Text="Item Code" />
            &nbsp;&nbsp; </td><td height="25">
            <asp:TextBox ID="txtItemcode" runat="server" CssClass="box3" Enabled="False"></asp:TextBox>
        </td></tr><tr><td class="style4">
        <asp:CheckBox ID="CKwono" runat="server" AutoPostBack="True" 
            OnCheckedChanged="CKwono_CheckedChanged" Text="WO No" />
        &nbsp; </td><td height="25">
            <asp:TextBox ID="txtwono" runat="server" CssClass="box3" Enabled="False"></asp:TextBox>
        </td></tr><tr><td class="style4">
        <asp:CheckBox ID="CkSupplier" runat="server" AutoPostBack="True" 
            OnCheckedChanged="CkSupplier_CheckedChanged" Text="Supplier Name" />
        &nbsp; </td><td height="25">
            <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Enabled="False" 
                Width="375px"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                runat="server" CompletionInterval="100" CompletionListCssClass="almt" 
                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                CompletionSetCount="1" DelimiterCharacters="" Enabled="True" 
                FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql" 
                ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                TargetControlID="TxtSearchValue" UseContextKey="True">
            </cc1:AutoCompleteExtender>
        </td></tr><tr><td class="style4">
        <asp:CheckBox ID="CkACCHead" runat="server" Text="Account Head" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td><td height="25">
            <asp:RadioButton ID="RbtnLabour" runat="server" AutoPostBack="True" 
                Checked="True" GroupName="GroupACHead" 
                OnCheckedChanged="RbtnLabour_CheckedChanged" Text="Labour" />
            &nbsp;<asp:RadioButton ID="RbtnWithMaterial" runat="server" AutoPostBack="True" 
                GroupName="GroupACHead" OnCheckedChanged="RbtnWithMaterial_CheckedChanged" 
                Text="With Material" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" 
                OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td></tr><tr><td class="style4">&nbsp;<asp:Label ID="Label2" runat="server" 
            Text="Enter Date"></asp:Label>
        </td><td height="25">From:
            <asp:TextBox ID="textFromDate" runat="server" CssClass="box3"></asp:TextBox>
            <cc1:CalendarExtender ID="textFromDate_CalendarExtender" runat="server" 
                CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" 
                PopupPosition="BottomRight" TargetControlID="textFromDate">
            </cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="ReqTDate" runat="server" 
                ControlToValidate="textFromDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="vdr"></asp:RegularExpressionValidator>
            - To:
            <asp:TextBox ID="TextToDate" runat="server" CssClass="box3"></asp:TextBox>
            <cc1:CalendarExtender ID="cd1" runat="server" CssClass="cal_Theme2" 
                Enabled="True" Format="dd-MM-yyyy" PopupPosition="BottomRight" 
                TargetControlID="TextToDate">
            </cc1:CalendarExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextToDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="vdr"></asp:RegularExpressionValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="textFromDate" ControlToValidate="TextToDate" 
                ErrorMessage="From date must greater than or equal to To date" 
                Operator="GreaterThanEqual" Type="Date" ValidationGroup="vdr"></asp:CompareValidator>
        </td></tr><tr><td height="30px" width="13%"><asp:Button ID="BtnSearch" runat="server" CssClass="redbox" 
                    OnClick="BtnSearch_Click" Text="Search" ValidationGroup="vdr" /></td></tr></table>
                    </ContentTemplate>
    </cc1:TabPanel>
    
    
    
    
    
    
    <cc1:TabPanel runat="server" HeaderText="MRS Search" ID="MRS">
          <HeaderTemplate>MRS Search
                    </HeaderTemplate>
          <ContentTemplate> 
             <table  width="100%" align="center"><tr><td colspan="3">&#160;</td></tr><tr><td height="30px" width="13%">Enter No.</td><td height="30px" colspan="2">: <asp:DropDownList ID="ddlEnterNoMRS" runat="server" AutoPostBack="True" 
                    CssClass="box3" 
                    OnSelectedIndexChanged="ddlEnterNoMRS_SelectedIndexChanged"><asp:ListItem Value="3">All</asp:ListItem><asp:ListItem Value="1">MRS No</asp:ListItem><asp:ListItem Value="2">MIN No</asp:ListItem></asp:DropDownList><asp:TextBox ID="txtEnterNoMRS" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td height="30px" width="13%">
                     <asp:CheckBox ID="CheBoxItemCatMRS" runat="server" AutoPostBack="True" 
                         OnCheckedChanged="CheBoxItemCatMRS_CheckedChanged" Text="Item Category" />
                     </td><td height="30px" colspan="2">
                         <asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="True" 
                             CssClass="box3" Width="150px">
                         </asp:DropDownList>
                     </td></tr><tr><td height="30px" width="13%">
                     <asp:CheckBox ID="CheBoxItemCodeMRS" runat="server" 
                             Text="Item Code" AutoPostBack="True" 
                             oncheckedchanged="CheBoxItemCodeMRS_CheckedChanged" /></td><td height="30px" colspan="2">: 
                         <asp:TextBox ID="txtItemCodeMRS" runat="server" CssClass="box3" Enabled="False"></asp:TextBox></td></tr><tr><td height="30px" width="13%">
                     <asp:CheckBox ID="CheBoxEmployeeNameMRS" runat="server" 
                             Text="Employee Name" AutoPostBack="True" 
                             oncheckedchanged="CheBoxEmployeeNameMRS_CheckedChanged" /></td><td height="30px" colspan="2">: 
                         <asp:TextBox ID="TxtEmpName" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                         <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                             CompletionInterval="100" CompletionListCssClass="almt" 
                             CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                             CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                             FirstRowSelected="True" MinimumPrefixLength="1" 
                             ServiceMethod="GetCompletionList" ServicePath="" 
                             ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmpName" 
                             UseContextKey="True">
                         </cc1:AutoCompleteExtender>
                     </td></tr><tr><td height="30px" width="13%">
                     <asp:CheckBox ID="CheBoxBGGroupMRS" runat="server" 
                             Text="BG Group" AutoPostBack="True" 
                             oncheckedchanged="CheBoxBGGroupMRS_CheckedChanged" /></td><td height="30px" colspan="2">: 
                         <asp:DropDownList ID="ddlDeptMRS" runat="server" CssClass="box3" 
                             DataSourceID="SqlDataSourceMRS" DataTextField="Dept" DataValueField="Id">
                         </asp:DropDownList>
                     </td></tr><tr><td height="30px" width="13%">
                     <asp:CheckBox ID="CheBoxWONoMRS" runat="server" AutoPostBack="True" 
                         OnCheckedChanged="CheBoxWONoMRS_CheckedChanged" Text="Work Order No" />
                     </td><td height="30px" colspan="2">:
                         <asp:TextBox ID="txtWONoMRS" runat="server" CssClass="box3" Width="84px"></asp:TextBox>
                     </td></tr><tr><td height="30px" width="13%">Select Date</td>
                     <td height="30px" width="10%">
                         <asp:RadioButtonList ID="RadMRSMIN" runat="server" RepeatDirection="Horizontal">
                             <asp:ListItem Selected="True" Value="1">MRS</asp:ListItem>
                             <asp:ListItem Value="2">MIN</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                     <td height="30px">
                         From :
                         <asp:TextBox ID="txtFromDateMRS" runat="server" CssClass="box3"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                             CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" 
                             PopupPosition="BottomRight" TargetControlID="txtFromDateMRS">
                         </cc1:CalendarExtender>
                         <asp:RegularExpressionValidator ID="RegtxtFromDateMRS" runat="server" 
                             ControlToValidate="txtFromDateMRS" ErrorMessage="*" 
                             ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
                         To :
                         <asp:TextBox ID="txtToDateMRS" runat="server" CssClass="box3"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                             CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" 
                             PopupPosition="BottomRight" TargetControlID="txtToDateMRS">
                         </cc1:CalendarExtender>
                         <asp:RegularExpressionValidator ID="RegtxtToDateMRS" runat="server" 
                             ControlToValidate="txtToDateMRS" ErrorMessage="*" 
                             ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
                     </td>
                 </tr><tr><td align="center" colspan="3" height="30px">
                     <asp:Button ID="btnSearchMRS" runat="server" CssClass="redbox" 
                         OnClick="btnSearchMRS_Click" Text="Search" />
                     </td></tr>
                 <tr>
                     <td align="center" colspan="3">
                         <asp:SqlDataSource ID="SqlDataSourceMRS" runat="server" 
                             ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                             ProviderName="System.Data.SqlClient" 
                             SelectCommand="Select Id, Symbol as Dept from BusinessGroup">
                         </asp:SqlDataSource>
                     </td>
                 </tr>
              </table>   
                    </ContentTemplate>           
        </cc1:TabPanel>                
 <cc1:TabPanel runat="server" HeaderText="MRN Search" ID="MRN">
          <HeaderTemplate>MRN Search
                    </HeaderTemplate>
          <ContentTemplate> 
            <table  width="100%" align="center"><tr><td colspan="3">&#160;</td></tr><tr><td height="30px" width="13%">Enter Nos.</td><td height="30px" colspan="2">: <asp:DropDownList ID="ddlEnterNoMRN" runat="server" AutoPostBack="True" 
                    CssClass="box3" 
                    OnSelectedIndexChanged="ddlEnterNoMRN_SelectedIndexChanged"><asp:ListItem Value="3">All</asp:ListItem><asp:ListItem Value="1">MRN No</asp:ListItem><asp:ListItem Value="2">MRQN No</asp:ListItem></asp:DropDownList><asp:TextBox ID="txtEnterNoMRN" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td height="30px" width="13%"><asp:CheckBox ID="CheBoxItemCodeMRN" runat="server" AutoPostBack="True" 
                             oncheckedchanged="CheBoxItemCodeMRN_CheckedChanged" Text="Item Code" /></td><td height="30px" colspan="2">: <asp:TextBox ID="txtItemCodeMRN" runat="server" CssClass="box3" Enabled="False"></asp:TextBox></td></tr><tr><td height="30px" width="13%"><asp:CheckBox ID="CheBoxEmployeeNameMRN" runat="server" 
                             Text="Employee Name" AutoPostBack="True" 
                             oncheckedchanged="CheBoxEmployeeNameMRN_CheckedChanged" /></td><td height="30px" colspan="2">: <asp:TextBox ID="TxtEmpName1" runat="server" CssClass="box3" Width="350px"></asp:TextBox><cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                             CompletionInterval="100" CompletionListCssClass="almt" 
                             CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                             CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                             FirstRowSelected="True" MinimumPrefixLength="1" 
                             ServiceMethod="GetCompletionList" ServicePath="" 
                             ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmpName1" 
                             UseContextKey="True"></cc1:AutoCompleteExtender></td></tr><tr><td height="30px" width="13%"><asp:CheckBox ID="CheBoxBGGroupMRN" runat="server" 
                             Text="BG Group" AutoPostBack="True" 
                             oncheckedchanged="CheBoxBGGroupMRN_CheckedChanged" /></td><td height="30px" colspan="2">: <asp:DropDownList ID="ddlDeptMRN" runat="server" CssClass="box3" 
                             DataSourceID="SqlDataSourceMRN" DataTextField="Dept" DataValueField="Id"></asp:DropDownList></td></tr><tr><td height="30px" width="13%"><asp:CheckBox ID="CheBoxWONoMRN" runat="server" 
                             Text="Work Order No" AutoPostBack="True" 
                             oncheckedchanged="CheBoxWONoMRN_CheckedChanged" /></td><td height="30px" colspan="2">: <asp:TextBox ID="txtWONoMRN" runat="server" CssClass="box3" Width="84px"></asp:TextBox></td></tr><tr><td height="30px" width="13%">Enter Date</td><td height="30px" width="10%"><asp:RadioButtonList ID="RadMRNMRQN" runat="server" RepeatDirection="Horizontal"><asp:ListItem Selected="True" Value="1">MRN</asp:ListItem><asp:ListItem Value="2">MRQN</asp:ListItem></asp:RadioButtonList></td><td height="30px">From : <asp:TextBox ID="txtFromDateMRN" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender3" runat="server" 
                             CssClass="cal_Theme2" PopupPosition="BottomRight" Enabled="True" Format="dd-MM-yyyy" 
                             TargetControlID="txtFromDateMRN"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegtxtFromDateMRN" runat="server" 
                             ControlToValidate="txtFromDateMRN" ErrorMessage="*" 
                             
                             ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>To : <asp:TextBox ID="txtToDateMRN" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                             CssClass="cal_Theme2" PopupPosition="BottomRight" Enabled="True" Format="dd-MM-yyyy" 
                             TargetControlID="txtToDateMRN"></cc1:CalendarExtender><asp:RegularExpressionValidator ID="RegtxtToDateMRN" runat="server" 
                             ControlToValidate="txtToDateMRN" ErrorMessage="*" 
                             
                             ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator></td></tr><tr><td height="30px" width="13%"><asp:Label ID="Label3" runat="server" Text="PO Rate"></asp:Label></td><td colspan="2" height="30px" width="10%"><asp:RadioButtonList ID="PORate" runat="server" RepeatDirection="Horizontal"><asp:ListItem Value="1" Selected="True">Max</asp:ListItem><asp:ListItem Value="2">Min</asp:ListItem><asp:ListItem Value="3">Average</asp:ListItem><asp:ListItem Value="4">Latest</asp:ListItem></asp:RadioButtonList></td></tr><tr><td align="center" colspan="3" height="30px"><asp:Button ID="btnSearchMRN" runat="server" CssClass="redbox" 
                             OnClick="btnSearchMRN_Click" Text="Search" /></td></tr><tr><td align="center" colspan="3"><asp:SqlDataSource ID="SqlDataSourceMRN" runat="server" 
                             ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                             ProviderName="System.Data.SqlClient" 
                             SelectCommand="Select Id, Symbol as Dept from BusinessGroup"></asp:SqlDataSource></td></tr></table>
                    </ContentTemplate>           
        </cc1:TabPanel> 
    
    
    
    
    
    
    
    </cc1:TabContainer>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

