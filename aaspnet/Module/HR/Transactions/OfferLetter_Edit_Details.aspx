<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OfferLetter_Edit_Details.aspx.cs" Inherits="Module_HR_Transactions_OfferLetter_Edit_Details" Title="ERP" Theme ="Default"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" /> 
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script> 
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style4
        {
            text-align: left;
            font-weight: bold;
        }
      
        .style5
        {
            
            float: left;
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
    <table  width="100%" cellpadding="0" cellspacing="0">
        <%--  <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                            CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                
                                                    
                                                </asp:TemplateField>--%>
        
        <tr>
        <td colspan="2" height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b> 
            <asp:Label ID="lblOfferIncrement" runat="server" Text=""></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;Offer Id: <asp:Label ID="lblOfferId" runat="server" Text=""></asp:Label></b></td>
        
        
        </tr>
        
        <tr>
        <td>
            &nbsp;</td>
        
        <td>
        
        
            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                <tr __designer:mapid="83">
                    <td 
         width="12%">
                        Designation</td>
                    <td 
         width="20%">
                        <asp:DropDownList runat="server" DataTextField="Designation" 
                            DataValueField="Id" DataSourceID="SqlDataSource3" CssClass="box3" 
                            ID="DrpDesignation">
                        </asp:DropDownList>
                    </td>
                    <td 
         width="10%">
                        Name</td>
                    <td width="21%" >
                        <asp:DropDownList ID="DrpTitle" runat="server">
                            <asp:ListItem Value="Mr.">Mr.</asp:ListItem>
                            <asp:ListItem Value="Mrs."></asp:ListItem>
                            <asp:ListItem Value="Miss."></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" CssClass="box3" Width="200px" ID="TxtName"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtName" 
                            ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator2"></asp:RequiredFieldValidator>
                    </td>
                    <td rowspan="7" valign="top" width="20%" >
                        <table align="left" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtHeader" runat="server" CssClass="box3" Height="59px" 
                                        TextMode="MultiLine" Width="250px" Visible="False">You will be on a probation for the period of Six Months.You should join on or before dt. / / .You should submit Xerox copies of certificates and two passport size Photographs at the time of joining.</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                        ControlToValidate="txtHeader" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="lblEffectFromForTheYeartext" runat="server" 
                                        style="font-weight: 700" Text="Effect From For The Year" Visible="False"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtIncrementForTheYear" runat="server" CssClass="box3" 
                                        Visible="False" Width="90px"></asp:TextBox>
                                &nbsp;<asp:Label ID="lblIncrementForTheYear" runat="server" Text="Ex- 2014 - 2015" 
                                        style="font-weight: 700" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtFooter" runat="server" CssClass="box3" Height="59px" 
                                        TextMode="MultiLine" Width="250px" Visible="False">If you are agreed to above terms and conditions then please sign the second copy . We have pleasure in welcoming you to our Organization.</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                        ControlToValidate="txtFooter" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="lblEffectFromtext" runat="server" style="font-weight: 700" 
                                        Text="Effect From" Visible="False"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtEffectFrom" runat="server" CssClass="box3" Visible="False" 
                                        Width="90px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtEffectFrom_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtEffectFrom">
                                    </cc1:CalendarExtender>                                    
                                    <asp:RegularExpressionValidator ID="RegtxtEffectFrom" runat="server" 
                                    ControlToValidate="txtEffectFrom" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr 
        >
                    <td __designer:mapid="8b">
                        Duty Hours</td>
                    <td 
            >
                        <asp:DropDownList runat="server" DataTextField="Hours" DataValueField="Id" 
                            DataSourceID="SqlDataSource1" CssClass="box3" ID="DrpDutyHrs">
                        </asp:DropDownList>
                    </td>
                    <td 
            >
                        Contact Nos.</td>
                    <td >
                        <asp:TextBox runat="server" CssClass="box3" Width="150px" ID="TxtContactNo"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtContactNo" 
                            ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator4"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr >
                    <td >
                        OT Hours</td>
                    <td 
            >
                        <asp:DropDownList runat="server" DataTextField="Hours" DataValueField="Id" 
                            DataSourceID="SqlDataSource2" CssClass="box3" ID="DrpOTHrs">
                        </asp:DropDownList>
                    </td>
                    <td 
             rowspan="2" valign="top">
                        Address</td>
                    <td 
             rowspan="2">
                        <asp:TextBox runat="server" TextMode="MultiLine" ValidationGroup="A" 
                            CssClass="box3" Height="45px" Width="250px" ID="TxtAddress"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtAddress" 
                            ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator3"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr 
        >
                    <td >
                        OT Applicable</td>
                    <td 
            >
                        <asp:DropDownList runat="server" 
                            DataTextField="Description" DataValueField="Id" DataSourceID="SqlDataSource5" 
                            CssClass="box3" ID="DrpOvertime">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr 
        >
                    <td >
                        Type of Employee</td>
                    <td 
           >
                        <asp:DropDownList ID="DrpEmpTypeOf" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DrpEmpTypeOf_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">SAPL</asp:ListItem>
                            <asp:ListItem Value="2">NEHA</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                            ControlToValidate="DrpEmpTypeOf" ErrorMessage="*" InitialValue="0" 
                            ValidationGroup="B"></asp:RequiredFieldValidator>
                        <asp:DropDownList runat="server" 
                            DataTextField="Description" DataValueField="Id" DataSourceID="SqlDataSource4" 
                            CssClass="box3" ID="DrpEmpType" AutoPostBack="True" 
                            onselectedindexchanged="DrpEmpType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td 
            >
                        Email Id</td>
                    <td >
                        <asp:TextBox runat="server" CssClass="box3" Width="250px" ID="TxtEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtEmail" 
                            ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator5"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ControlToValidate="TxtEmail" ErrorMessage="*" ValidationGroup="A" 
                            ID="RegularExpressionValidator1"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr 
        >
                    <td >
                        Interviewed By</td>
                    <td 
            >
                        <asp:TextBox runat="server" CssClass="box3" Width="300px" ID="Txtinterviewedby"></asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" MinimumPrefixLength="1" 
                            CompletionInterval="100" CompletionSetCount="1" 
                            ServiceMethod="GetCompletionList" ServicePath="" UseContextKey="True" 
                            CompletionListCssClass="almt2" CompletionListItemCssClass="bg" 
                            CompletionListHighlightedItemCssClass="bgtext" DelimiterCharacters="" 
                            FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True" 
                            Enabled="True" TargetControlID="Txtinterviewedby" 
                            ID="TxtEmpName_AutoCompleteExtender">
                        </cc1:AutoCompleteExtender>
                  
                        
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Txtinterviewedby" 
                            ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator6"></asp:RequiredFieldValidator>
                    </td>
                    <td 
            >
                        Authorized By</td>
                    <td >
                        <asp:TextBox runat="server" CssClass="box3" Width="250px" ID="TxtAuthorizedby"></asp:TextBox>
                        <cc1:AutoCompleteExtender runat="server" MinimumPrefixLength="1" 
                            CompletionInterval="100" CompletionSetCount="2" 
                            ServiceMethod="GetCompletionList" ServicePath="" UseContextKey="True" 
                            CompletionListCssClass="almt2" CompletionListItemCssClass="bg" 
                            CompletionListHighlightedItemCssClass="bgtext" DelimiterCharacters="" 
                            FirstRowSelected="True" ShowOnlyCurrentWordInCompletionListItem="True" 
                            Enabled="True" TargetControlID="TxtAuthorizedby" ID="AutoCompleteExtender1">
                        </cc1:AutoCompleteExtender>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtAuthorizedby" 
                            ErrorMessage="*" ValidationGroup="A" ID="RequiredFieldValidator7"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr 
        >
                    <td >
                        Reference By</td>
                    <td 
            >
                        <asp:TextBox runat="server" CssClass="box3" Width="300px" ID="TxtReferencedby"></asp:TextBox>
                    </td>
                    <td 
            >
                        Gross Salary</td>
                    <td >
                        <asp:TextBox runat="server" CssClass="box3" ID="TxtGrossSalry" 
                            ValidationGroup="B"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtGrossSalry" 
                            ErrorMessage="*" ValidationGroup="B" ID="RequiredFieldValidator1"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B" ControlToValidate="TxtGrossSalry"
                                ID="RegularExpressionValidator2" runat="server" ErrorMessage="*"></asp:RegularExpressionValidator>
&nbsp;</td>
                </tr>
                <tr 
        >
                    <td colspan="5">
                        <table width="100%" 
                class="box3" align="center" border="0" cellpadding="1" cellspacing="1">
                            <tr __designer:mapid="cc">
                                <td __designer:mapid="cd" 
                    class="style4" width="100">
                                    Description<asp:SqlDataSource runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT * FROM [tblHR_OverTime]" ID="SqlDataSource5">
                        </asp:SqlDataSource>
                                </td>
                                <td width="70"  __designer:mapid="ce">
                                    <b>%<asp:SqlDataSource runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT * FROM [tblHR_OTHour]" ID="SqlDataSource2">
                        </asp:SqlDataSource>
        
        
        
                                    </b></td>
                                <td __designer:mapid="cf" align="left">
                                    <b>Per Month<asp:SqlDataSource runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT * FROM [tblHR_DutyHour]" ID="SqlDataSource1">
                        </asp:SqlDataSource>
                                    </b></td>
                                <td width="60" __designer:mapid="cf" align="left" colspan="2">
                                    <b>Annual<asp:SqlDataSource runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT Symbol + ' - ' +Type  AS Designation, [Id] FROM [tblHR_Designation]" 
                            ID="SqlDataSource3"></asp:SqlDataSource>
                                    </b></td>
                                <td __designer:mapid="d0" colspan="2">
                                      <%--  <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                            CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                
                                                    
                                                </asp:TemplateField>--%>
        
                                </td>
                                <td width="100"  __designer:mapid="177" align="justify">
                                    &nbsp;</td>
                                <td width="200"
                    __designer:mapid="192" align="justify">
                                    &nbsp;</td>
                                <td width="100" __designer:mapid="1ba" 
                    align="justify">
                                    <b>Per Month</b></td>
                                <td __designer:mapid="1ba" 
                    align="justify">
                                    <b>Annual</b></td>
                            </tr>
                            <tr __designer:mapid="d2">
                                <td 
                    __designer:mapid="d3" class="style5">
                                    Gross Salary</td>
                                <td 
                    __designer:mapid="d4">
                                    100</td>
                                <td __designer:mapid="d5">
                                    <asp:label runat="server" Enabled="False" ID="TxtGSal"></asp:label>
                                </td>
                                <td __designer:mapid="d5" colspan="2">
                                    <asp:label runat="server"  Enabled="False" ID="TxtANNualSal"></asp:label>
                                </td>
                                <td 
                    __designer:mapid="d7" colspan="2">
                                    LTA</td>
                                <td __designer:mapid="178">
                                    <asp:TextBox runat="server" CssClass="box3" ID="TxtGLTA" Width="80px">0</asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                                        ControlToValidate="TxtGLTA" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                        ControlToValidate="TxtGLTA" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td 
                    __designer:mapid="193">
        
        
                                    Take Home</td>
                                <td __designer:mapid="1bb">
        
        
                                    <asp:Label ID="lblTH" runat="server"></asp:Label>
                                </td>
                                <td __designer:mapid="1bb">
        
        
                                    <asp:Label ID="lblTHAnn" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="d9">
                                <td __designer:mapid="da" class="style5">
                                    Basic</td>
                                <td 
                    __designer:mapid="db">
                                    30</td>
                                <td __designer:mapid="dc">
                                    <asp:label runat="server"  Enabled="False" ID="TxtGBasic"></asp:label>
                                </td>
                                <td __designer:mapid="dc" colspan="2">
                                    <asp:label runat="server"  Enabled="False" ID="TxtAnBasic"></asp:label>
                                </td>
                                <td 
                    __designer:mapid="de" colspan="2">
                                    Ex Gratia</td>
                                <td __designer:mapid="179">
                                    <asp:TextBox runat="server" CssClass="box3" ID="TxtGGratia" Width="80px">0</asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                        ControlToValidate="TxtGGratia" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                        ControlToValidate="TxtGGratia" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td 
                    __designer:mapid="194">
        
        
                                    Take Home&nbsp; (With Attd. Bonus - 1)*</td>
                                <td __designer:mapid="1bc">
        
        
                                    <asp:Label ID="lblTH1" runat="server"></asp:Label>
                                </td>
                                <td __designer:mapid="1bc">
        
        
                                    <asp:Label ID="lblTHAnn1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="e0">
                                <td __designer:mapid="e1" class="style5">
                                    DA</td>
                                <td 
                    __designer:mapid="e2">
                                    20</td>
                                <td __designer:mapid="e3">
                                    <asp:label runat="server" Enabled="False" ID="TxtGDA"></asp:label>
                                </td>
                                <td __designer:mapid="e3" colspan="2">
                                    <asp:label runat="server" Enabled="False" ID="TxtAnDA"></asp:label>
                                </td>
                                <td 
                    __designer:mapid="e5" colspan="2" >
                                    Loyalty Benefits</td>
                                <td __designer:mapid="17a" >
                                    <asp:TextBox runat="server" CssClass="box3" ID="TxtAnnLOYAlty" Width="80px">0</asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                                        runat="server" ControlToValidate="TxtAnnLOYAlty" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                        ControlToValidate="TxtAnnLOYAlty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td 
                    __designer:mapid="195" >
        
        
                                    Take Home&nbsp; (With Attd. Bonus - 2)*</td>
                                <td __designer:mapid="1bd" >
        
        
                                    <asp:Label ID="lblTH2" runat="server"></asp:Label>
                                </td>
                                <td __designer:mapid="1bd" >
        
        
                                    <asp:Label ID="lblTHAnn2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="e7">
                                <td __designer:mapid="e8" class="style5">
                                    HRA</td>
                                <td 
                    __designer:mapid="e9">
                                    20</td>
                                <td __designer:mapid="ea">
                                    <asp:label runat="server" Enabled="False" ID="TxtGHRA"></asp:label>
                                </td>
                                <td __designer:mapid="ea" colspan="2">
                                    <asp:label runat="server" Enabled="False" ID="TxtANHRA"></asp:label>
                                </td>
                                <td 
                    __designer:mapid="ec" colspan="2">
                                    Vehicle Allowance</td>
                                <td __designer:mapid="17b">
                                    <asp:TextBox runat="server" CssClass="box3" ID="TxtGVehAll" Width="80px">0</asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                        ControlToValidate="TxtGVehAll" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                        ControlToValidate="TxtGVehAll" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td 
                    __designer:mapid="196">
        
        
                                    CTC</td>
                                <td __designer:mapid="1be">
        
        
                                    <asp:Label ID="lblCTC" runat="server"></asp:Label>
                                </td>
                                <td __designer:mapid="1be">
        
        
                                    <asp:Label ID="lblCTCAnn" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="ee">
                                <td __designer:mapid="ef" class="style5">
                                    Convenience</td>
                                <td 
                    __designer:mapid="f0">
                                    20</td>
                                <td __designer:mapid="f1">
                                    <asp:label runat="server" Enabled="False" 
                                        ID="TxtGConvenience"></asp:label>
                                </td>
                                <td __designer:mapid="f1" colspan="2">
                                    <asp:label runat="server" Enabled="False" 
                                        ID="TxtANConvenience"></asp:label>
                                </td>
                                <td 
                    __designer:mapid="f3" colspan="2">
                                    Paid Leaves</td>
                                <td __designer:mapid="17c">
                                    <asp:TextBox runat="server" CssClass="box3" ID="TxtAnnpaidleaves" Width="80px">0</asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                                        runat="server" ControlToValidate="TxtAnnpaidleaves" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                        ControlToValidate="TxtAnnpaidleaves" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td 
                    __designer:mapid="197">
        
        
                                    CTC&nbsp; (With Attd. Bonus - 1)*</td>
                                <td __designer:mapid="1bf">
                                    <asp:Label ID="lblCTC1" runat="server"></asp:Label>
                                </td>
                                <td __designer:mapid="1bf">
                                    <asp:Label ID="lblCTCAnn1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="f5">
                                <td __designer:mapid="f6" class="style5">
                                    Education</td>
                                <td 
                __designer:mapid="f7">
                                    5</td>
                                <td __designer:mapid="f8">
                                    <asp:label runat="server" Enabled="False" ID="TxtGEdu"></asp:label>
                                </td>
                                <td __designer:mapid="f8" colspan="2">
                                    <asp:label runat="server"  Enabled="False" ID="TxtANEDU"></asp:label>
                                </td>
                                <td 
                __designer:mapid="fa" colspan="2">
                                    PF-Employee <asp:TextBox ID="txtPFEmployee" runat="server" CssClass="box3" Width="35px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtPFEmployee" runat="server" 
                                        ControlToValidate="txtPFEmployee" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegutxtPFEmployee" 
                                        runat="server" ControlToValidate="txtPFEmployee" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                </td>
                                <td __designer:mapid="17d">
                                    <asp:label runat="server" Enabled="False" ID="TxtGEmpPF"></asp:label>
                                </td>
                                <td 
                __designer:mapid="198" valign="top">
        
        
                                    CTC&nbsp; (With Attd. Bonus - 2)*</td>
                                <td 
                __designer:mapid="198" valign="top">
        
        
                                    <asp:Label ID="lblCTC2" runat="server"></asp:Label>
                                </td>
                                <td 
                __designer:mapid="198" valign="top">
        
        
                                    <asp:Label ID="lblCTCAnn2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="fc">
                                <td __designer:mapid="fd" class="style5" height="20">
                                    Medical</td>
                                <td 
                __designer:mapid="fe">
                                    5</td>
                                <td __designer:mapid="ff">
                                    <asp:label runat="server" Enabled="False" ID="TxtGWash"></asp:label>
                                </td>
                                <td __designer:mapid="ff" colspan="2">
                                    <asp:label runat="server" Enabled="False" ID="TxtANWash"></asp:label>
                                </td>
                                <td 
                __designer:mapid="101" colspan="2">
                                    PF-Company&nbsp; <asp:TextBox ID="txtPFCompany" runat="server" CssClass="box3" Width="35px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtPFCompany" runat="server" 
                                        ControlToValidate="txtPFCompany" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegutxtPFCompany" 
                                        runat="server" ControlToValidate="txtPFCompany" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                </td>
                                <td __designer:mapid="17e">
                                    <asp:label runat="server" Enabled="False" ID="TxtGCompPF"></asp:label>
                                </td>
                                <td 
                __designer:mapid="198" valign="top" colspan="3" rowspan="5" width="590px">
        
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            DataKeyNames="Id" 
                                            CssClass="yui-datatable-theme" Width ="99%" AllowPaging="True" 
                                            PageSize="2" ShowFooter="True" onrowcommand="GridView1_RowCommand" 
                                        onrowupdating="GridView1_RowUpdating" 
                                        onpageindexchanging="GridView1_PageIndexChanging" 
                                        onrowcancelingedit="GridView1_RowCancelingEdit" 
                                        onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing">
                                            <PagerSettings PageButtonCount="20" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                                            CommandName="Update" Text="Update"></asp:LinkButton>
                                                        &nbsp; <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                        &nbsp; <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                                                            CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    
                                                     
                                                      <ItemStyle Width="15%" />
                                                </asp:TemplateField>
                                              <%--  <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                                            CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                
                                                    
                                                </asp:TemplateField>--%>
                                                
                                                 <asp:TemplateField HeaderText="SN">
                                                <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="4%" />                                      
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Include In">
                                                  <ItemTemplate>
                                                  <asp:Label ID="lblIncludesInId" runat="server" Text='<%#Eval("IncludesIn")%>' Visible="false"></asp:Label>
                                                  <asp:Label ID="lblIncludesIn" runat="server"></asp:Label></ItemTemplate>
                                                  <FooterTemplate>
                                                    <asp:DropDownList ID="IncludeIn" runat="server" CssClass="box3" DataSourceID="SqlDataSource6" DataTextField="IncludesIn" DataValueField="Id"> </asp:DropDownList> </FooterTemplate>
                                                  </asp:TemplateField>
                                                  
                                                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                                                    ReadOnly="True" SortExpression="Id" Visible="False">
                                                    <ItemStyle Width="2%" />
                                                </asp:BoundField>
                                            <%--    <asp:BoundField DataField="SessionId" HeaderText="SessionId" 
                                                    SortExpression="SessionId" Visible="False" >
                                                    <ItemStyle Width="2%" />
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="MId" HeaderText="MId" SortExpression="MId" 
                                                    Visible="False">
                                                    <ItemStyle Width="2%" />
                                                </asp:BoundField>
                                                
                                                  <asp:TemplateField HeaderText="Perticulars" SortExpression="Perticulars">
                                                      <EditItemTemplate>
                                                       <asp:TextBox ID="txtPerticularsE" Text='<%# Bind("Perticulars") %>'
                                                        Width="90%" runat="server"  CssClass="box3"> 
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqtxtPerticularsE" runat="server"
                                                     ControlToValidate="txtPerticularsE" ValidationGroup="InsE" ErrorMessage="*">
                                                    </asp:RequiredFieldValidator>
                                                      </EditItemTemplate>
                                                      <ItemTemplate>
                                                          <asp:Label ID="Label3" runat="server" Text='<%# Bind("Perticulars") %>'></asp:Label>
                                                      </ItemTemplate>
                                                      
                                                                                                          <FooterTemplate>
                                                    <asp:TextBox ID="txtPerticulars" Width="95%" Text='<%# Bind("Perticulars") %>'
                                                    runat="server"  CssClass="box3"> 
                                                    </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ReqPerticulars" runat="server"
                                                     ControlToValidate="txtPerticulars" ValidationGroup="Ins" ErrorMessage="*">
                                                    </asp:RequiredFieldValidator>
                                                    </FooterTemplate>
                                                      <ItemStyle Width="30%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                                                    <EditItemTemplate>
                                                 <asp:TextBox ID="txtAccQtyE" runat="server" CssClass="box3" Width="70%" Text='<%# Bind("Qty") %>'> 
                                                      </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredtxtAccQtyE" runat="server" 
                                        ControlToValidate="txtAccQtyE" ErrorMessage="*" ValidationGroup="InsE"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegulartxtAccQtyE" 
                                        runat="server" ControlToValidate="txtAccQtyE" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="InsE"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <FooterTemplate>
                                                     <asp:TextBox ID="txtAccQty" runat="server" CssClass="box3" Width="75%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredtxtAccQty" runat="server" 
                                        ControlToValidate="txtAccQty" ErrorMessage="*" ValidationGroup="Ins"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegulartxtAccQty" 
                                        runat="server" ControlToValidate="txtAccQty" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Ins"></asp:RegularExpressionValidator>
                                                     </FooterTemplate>
                                                    
                                                    <ItemStyle Width="13%" HorizontalAlign="Right" />
                                                    
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                                    <EditItemTemplate>
                                              <asp:TextBox ID="txtAccAmountE" runat="server" CssClass="box3"  Text='<%# Bind("Amount") %>'
                                               Width="70%">
                                                       </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredtxtAccAmountE" runat="server" 
                                        ControlToValidate="txtAccAmountE" ErrorMessage="*" ValidationGroup="InsE"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegulartxtAccAmountE" 
                                        runat="server" ControlToValidate="txtAccAmountE" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="InsE"></asp:RegularExpressionValidator>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    
                                                      <FooterTemplate>
                                                     <asp:TextBox ID="txtAccAmount" runat="server" CssClass="box3" Width="75%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredtxtAccAmount" runat="server" 
                                        ControlToValidate="txtAccAmount" ErrorMessage="*" ValidationGroup="Ins"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegulartxtAccAmount" 
                                        runat="server" ControlToValidate="txtAccAmount" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Ins"></asp:RegularExpressionValidator>
                                                     </FooterTemplate>
                                                    
                                                    <ItemStyle Width="12%" HorizontalAlign="Right" />
                                                    
                                                </asp:TemplateField>
                                                
                                                  <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                                      <EditItemTemplate>
                                          <asp:Label ID="LabTot" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                         <%-- <asp:TextBox ID="txtAccTotalE" runat="server" Text='<%# Bind("Total") %>' CssClass="box3"> 
                                         </asp:TextBox> --%>
                                                           
                                                      </EditItemTemplate>
                                                      <ItemTemplate>
                                                          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                                      </ItemTemplate>
                                                      <FooterTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" CommandName="Add" ValidationGroup="Ins" 
                                                    OnClientClick=" return confirmationAdd() " CssClass="redbox"  Width="40px"
                                                    Text="Insert" />
                                                    </FooterTemplate>
                                                      <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                </asp:TemplateField>
                                            </Columns>


                                            <EmptyDataTemplate>
                                            <table  width="100%" border="1" style="border-color:Gray">
                                            <tr>
                                             <td align="center">
                                              <asp:Label ID="SN" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                                            runat="server" Text="SN"></asp:Label></td>
                                            <td align="center">
                                            IncludeIn
                                            </td>
                                            <td align="center">
                                            <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                                            runat="server" Text="Perticulars"></asp:Label></td>

                                            <td align="center">
                                            <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman" 
                                             Font-Bold="true" Text="Qty"></asp:Label>
                                             </td>
                                             <td align="center">
                                            <asp:Label ID="Label4" runat="server" Font-Size="Medium" Font-Names="Times New Roman" 
                                             Font-Bold="true" Text="Amount"></asp:Label>
                                             </td>
                                             

                                            </tr>
                                            <tr>
                                            
                                            <td style="width:60px">
                                            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" ValidationGroup="Ins1"
                                             OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                                            </td>
<td>
<asp:DropDownList ID="IncludeIn0" runat="server" CssClass="box3" DataSourceID="SqlDataSource6" DataTextField="IncludesIn" DataValueField="Id"> </asp:DropDownList>
</td>
                                            <td style="width:300px">
                                            <asp:TextBox ID="txtPerticulars1"  Width="90%" runat="server" CssClass="box3"></asp:TextBox>
                                              
                                                    <asp:RequiredFieldValidator ID="ReqPerticulars1" runat="server"
                                                     ControlToValidate="txtPerticulars1" ValidationGroup="Ins1" ErrorMessage="*">
                                                    </asp:RequiredFieldValidator>
                                            </td>
                                            <td style="width:100px">
                                            <asp:TextBox ID="txtAccQty1" runat="server" CssClass="box3" Width="70%"></asp:TextBox>                
                                    <asp:RequiredFieldValidator ID="RequiredtxtAccQty1" runat="server" 
                                        ControlToValidate="txtAccQty1" ErrorMessage="*" ValidationGroup="Ins1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegulartxtAccQty1" 
                                        runat="server" ControlToValidate="txtAccQty1" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Ins1"></asp:RegularExpressionValidator>
                                            
                                            </td>
                                            <td style="width:100px">
                                            <asp:TextBox ID="txtAccAmount1" runat="server" CssClass="box3" Width="70%"></asp:TextBox>
                                       
                                    <asp:RequiredFieldValidator ID="RequiredtxtAccAmount1" runat="server" 
                                        ControlToValidate="txtAccAmount1" ErrorMessage="*" ValidationGroup="Ins1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegulartxtAccAmount1" 
                                        runat="server" ControlToValidate="txtAccAmount1" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Ins1"></asp:RegularExpressionValidator>
                                            </td>
                                            </tr>
                                            </table>

                                            </EmptyDataTemplate>        
                                            
                                            
                                            
                                        </asp:GridView>
        
        </td>
                            </tr>
                            <tr 
                __designer:mapid="103">
                                <td __designer:mapid="104" class="style5" height="20">
                                    Attend Bonus - 1</td>
                                <td 
                __designer:mapid="105" >
                                    <asp:TextBox ID="txtAttB1" runat="server" CssClass="box3" Width="35px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                                        ControlToValidate="txtAttB1" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                                        runat="server" ControlToValidate="txtAttB1" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                </td>
                                <td __designer:mapid="106">
                                    <asp:label runat="server" Enabled="False" ID="TxtGATTBN1"></asp:label>
                                </td>
                                <td __designer:mapid="106" colspan="2">
                                    &nbsp;</td>
                                <td __designer:mapid="108" colspan="2">
                                    P. Tax</td>
                                <td 
                __designer:mapid="17f">
                                    <asp:label runat="server" Enabled="False" ID="TxtGPTax"></asp:label>
                                </td>
                            </tr>
                            <tr 
                __designer:mapid="10f">
                                <td class="style5" __designer:mapid="110" height="20">
                                    Attend Bonus - 2</td>
                                <td 
                __designer:mapid="111">
                                    <asp:TextBox ID="txtAttB2" runat="server" CssClass="box3" Width="35px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                                        ControlToValidate="txtAttB2" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                                        runat="server" ControlToValidate="txtAttB2" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                </td>
                                <td __designer:mapid="112" >
                                    <asp:label runat="server" Enabled="False" ID="TxtGATTBN2"></asp:label>
                                </td>
                                <td __designer:mapid="112" colspan="2" >
                                    &nbsp;</td>
                                <td __designer:mapid="114" colspan="2">
                                    &nbsp;</td>
                                <td 
                __designer:mapid="181">
                                    &nbsp;</td>
                            </tr>
                            <tr 
                __designer:mapid="115">
                                <td class="style5" __designer:mapid="116">
                                    Bonus</td>
                                <td 
                align="left" __designer:mapid="117">
                                    &nbsp;</td>
                                <td 
                align="left" __designer:mapid="117" colspan="2">
                                    <asp:TextBox ID="txtBonus" runat="server" CssClass="box3" Width="50px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                                        ControlToValidate="txtBonus" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                                        runat="server" ControlToValidate="txtBonus" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                </td>
                                <td 
                align="left" __designer:mapid="117">
                                    <asp:label runat="server" Enabled="False" ID="TxtAnnBonus"></asp:label>
                                </td>
                                <td 
                align="left" __designer:mapid="117">ESI-E
                                    &nbsp;</td>
                                  <td>
                                    <asp:TextBox runat="server"  Enabled="True" ID="lblesie" Text="0.75"></asp:TextBox>
                               
                               </td>
                                
                                <td 
                align="left" __designer:mapid="117" colspan="2">
                                    &nbsp;
                                    
                                     <asp:label runat="server" Enabled="TRUE" ID="lblesi"></asp:label>
                                    </td>
                            </tr>
                            <tr 
                __designer:mapid="115">
                                <td class="style5" __designer:mapid="116">
                                    Gratuity</td>
                                <td 
                align="left" __designer:mapid="117">
                                    &nbsp;</td>
                                <td 
                align="left" __designer:mapid="117" colspan="2">
                                    <asp:Label ID="lblGratuaty" runat="server"></asp:Label>
                                </td>
                                <td 
                align="left" __designer:mapid="117">
                                    <asp:label runat="server" Enabled="False" ID="TxtAnnGratuaty"></asp:label>
                                </td>
                                <td 
                align="left" __designer:mapid="117">
                                    &nbsp;</td>
                                <td 
                align="left" __designer:mapid="117" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            </table>
                    </td>
                </tr>
                <tr 
        >
                    <td colspan="5" height="30" valign="middle">
        
        
            Remarks <asp:TextBox runat="server" CssClass="box3" ID="TxtRemarks" Width="400px"></asp:TextBox>
                                &nbsp;
                                    <asp:Button runat="server" Text="Calculate" ValidationGroup="B" CssClass="redbox" 
                            ID="ButtonSubmit" OnClick="ButtonSubmit_Click"></asp:Button>
                                    &nbsp;
                                    <asp:Button runat="server" Text="Update" ValidationGroup="A" CssClass="redbox" 
                ID="BtnSubmit" OnClick="BtnSubmit_Click"></asp:Button>
                                    &nbsp;   
                                    <asp:Button runat="server" Text="Increment" ValidationGroup="A" CssClass="redbox" 
                ID="BtnIncrement" OnClick="BtnIncrement_Click"></asp:Button>
                                  &nbsp;
                                    <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                        onclick="Button1_Click" Text="Cancel" />
                                &nbsp; <asp:Label runat="server" Font-Bold="True" ForeColor="#FF3300" ID="Label2"></asp:Label>
        
        
        
                        <asp:SqlDataSource runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT * FROM [tblHR_EmpType]" ID="SqlDataSource4">
                        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT * FROM [tblHR_IncludesIn]"></asp:SqlDataSource>
        
        
                    </td>
                </tr>
            </table>
        
        
        
          </td>
        
        </tr>
        
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>


