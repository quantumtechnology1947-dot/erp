<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_Search, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            height: 22px;
        }
        
        .style4
        {
            height: 30px;
        }
        
    </style>
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
        </tr>
        </table>
        <table  width="100%" align="center">
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Enter No.&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Drpoption" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="Drpoption_SelectedIndexChanged">
                    <asp:ListItem Value="1">PO No</asp:ListItem>
                    <asp:ListItem Value="2">PR No</asp:ListItem>
                    <asp:ListItem Value="3">SPR No</asp:ListItem>
                    <asp:ListItem Value="4">WO No</asp:ListItem>
                    <asp:ListItem Value="5">Item Code</asp:ListItem>
                    <asp:ListItem Value="6">Supplier Code</asp:ListItem>
                   <asp:ListItem Value="7">All</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtNo" runat="server" CssClass="box3"></asp:TextBox>
            &nbsp;&nbsp; 
                
                <asp:TextBox ID="TxtSuplier" runat="server" CssClass="box3" Width="255px" 
                    Visible="False"></asp:TextBox>
                          
                            <cc1:AutoCompleteExtender ID="TxtSuplier_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSuplier" UseContextKey="True" 
                    CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" 
                    CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                &nbsp;
                Report For&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RadPO" runat="server" Checked="true" Text="PO" GroupName="APR" />
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:RadioButton ID="RadPR" runat="server" Text="PR" GroupName="APR" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RadSPR" runat="server" Text="SPR" GroupName="APR" />
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:CheckBox ID="CkItem" runat="server" Text="ItemCode" AutoPostBack="True" />
            &nbsp;&nbsp;
                <asp:TextBox ID="txtItemcode" runat="server" CssClass="box3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CKwono" runat="server" Text="WorkOrder No" 
                    AutoPostBack="True" />
            &nbsp;&nbsp;
                <asp:TextBox ID="txtwono" runat="server" CssClass="box3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CkSupplier" runat="server" Text="Supllier Code" 
                    AutoPostBack="True" />
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="375px"></asp:TextBox>
                          
                            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CkACCHead" runat="server" Text="Account Head" 
                    AutoPostBack="True" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RbtnLabour" runat="server" Text="Labour" 
                    GroupName="GroupACHead" AutoPostBack="True" Checked="True" 
                    oncheckedchanged="RbtnLabour_CheckedChanged" />
&nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RbtnWithMaterial" runat="server" Text="With Material" 
                    GroupName="GroupACHead" AutoPostBack="True" 
                    oncheckedchanged="RbtnWithMaterial_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList runat="server" CssClass="box3" ID="DropDownList1" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CkExcise" runat="server" Text="Excise" AutoPostBack="True" />
            &nbsp;&nbsp;
                                <asp:DropDownList ID="DDLExcies" runat="server" CssClass="box3" 
                                    DataSourceID="SqlDataSource2" DataTextField="Terms" DataValueField="Id">
                                </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT [Id], [Terms] FROM [tblExciseser_Master]">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox8" runat="server" Text="Pending" AutoPostBack="True" 
                    oncheckedchanged="CheckBox8_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="CheckBox9" runat="server" Text="Completed" 
                    AutoPostBack="True" oncheckedchanged="CheckBox9_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Select Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                From:    <asp:TextBox runat="server" 
                        CssClass="box3" ID="textFromDate"></asp:TextBox>
<cc1:CalendarExtender runat="server" Format="dd-MM-yyyy" Enabled="True" 
                        TargetControlID="textFromDate" ID="textFromDate_CalendarExtender"></cc1:CalendarExtender>
<asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                        ControlToValidate="textFromDate" ErrorMessage="*" ValidationGroup="QtyAdd" 
                        ID="ReqTDate"></asp:RegularExpressionValidator> To:    
                        
                        
                        
                        <asp:TextBox runat="server" 
                        CssClass="box3" ID="TextToDate"></asp:TextBox>
                        
<cc1:CalendarExtender runat="server" Format="dd-MM-yyyy" Enabled="True" 
                        TargetControlID="TextToDate"  ID="cd1"></cc1:CalendarExtender>
                        
<asp:RegularExpressionValidator runat="server"  ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                        ControlToValidate="TextToDate" ErrorMessage="*" ValidationGroup="QtyAdd" 
                        ID="RegularExpressionValidator1"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="BtnSearch" runat="server" CssClass="redbox" Text="Search" onclick="BtnSearch_Click" 
                     />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

