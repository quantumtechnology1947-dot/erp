    <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GatePass_New.aspx.cs" Inherits="Module_Scheduler_GatePass_New" Title="ERP" Theme="Default"  %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />   
    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <script src="../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <style type="text/css">
         .style2
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

<table  width="100%" cellpadding="0" cellspacing="0">
                
        <tr>
            <td align="left" height="21" style="background:url(../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite">
                <b>&nbsp;CUSTOMER VISIT</b></td>
               
        </tr>
        
        <tr>
            <td align="left">
                <b>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT * FROM [tblCV_Reason]"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT [Symbol], [Description], [Id] FROM [tblHR_Departments]">
                </asp:SqlDataSource>
               
                </b>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Height="420px" Width="100%">
                    
                    
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>New
                        </HeaderTemplate>
                        <ContentTemplate><table class="style2"><tr><td align="center"><asp:GridView 
                                ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                OnRowCommand="GridView3_RowCommand" 
                                OnSelectedIndexChanged="GridView3_SelectedIndexChanged" PageSize="15" 
                                ShowFooter="True" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
                                </asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton 
                                        ID="LinkButton1" runat="server" CommandName="Del1">Delete</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
                                </asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label 
                                        ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
                                </asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label 
                                        ID="lblDate1" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TxtDate1" runat="server" CssClass="box3" Width="70px"> </asp:TextBox>
                                    <cc1:CalendarExtender ID="TxtDate1_CalendarExtender" runat="server" 
                                        Enabled="True" Format="dd-MM-yyyy" PopupPosition="BottomLeft" CssClass="cal_Theme2" 
                                        TargetControlID="TxtDate1"></cc1:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="TxtDate1" ErrorMessage="*" ValidationGroup="A"> </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegTxtDate1" runat="server" 
                                        ControlToValidate="TxtDate1" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                </FooterTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Purpose Type"><ItemTemplate><asp:Label 
                                        ID="lblType1" runat="server" Text='<%#Eval("Type") %>'> </asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                        DataSourceID="SqlDataSource1" DataTextField="Reason" DataValueField="Id" 
                                        onselectedindexchanged="DropDownList1_SelectedIndexChanged " 
                                        style="margin-bottom: 0px">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Purpose Type Of"><ItemTemplate><asp:Label 
                                        ID="lblTypeOf1" runat="server" Text='<%#Eval("TypeOf") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                        style="margin-bottom: 0px">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField><ItemTemplate><asp:Label ID="lblTypeFor1" 
                                        runat="server" Text='<%#Eval("TypeFor") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TxtDetails1" runat="server" CssClass="box3" Width="70px"></asp:TextBox>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="F Time"><ItemTemplate><asp:Label 
                                        ID="lblFTime1" runat="server" Text='<%#Eval("FromTime") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <MKB:TimeSelector ID="TimeSelector1" runat="server" AmPm="AM" 
                                        MinuteIncrement="1"></MKB:TimeSelector>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="T Time"><ItemTemplate><asp:Label 
                                        ID="lblTTime1" runat="server" Text='<%#Eval("ToTime") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <MKB:TimeSelector ID="TimeSelector2" runat="server" AmPm="AM" 
                                        MinuteIncrement="1"></MKB:TimeSelector>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Visitor Name"><ItemTemplate><asp:Label 
                                        ID="lblPlace1" runat="server" Text='<%#Eval("Place") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TxtPlace1" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="TxtPlace1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Contact Person"><ItemTemplate><asp:Label 
                                        ID="lblContPerson1" runat="server" Text='<%#Eval("ContactPerson") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TxtContPerson1" runat="server" CssClass="box3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="TxtContPerson1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Contact No"><ItemTemplate><asp:Label 
                                        ID="lblContNo1" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TxtContNo1" runat="server" CssClass="box3" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                        ControlToValidate="TxtContNo1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField HeaderText="Reason"><ItemTemplate><asp:Label 
                                        ID="lblReason1" runat="server" Text='<%#Eval("Reason") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="TxtReason1" runat="server" CssClass="box3" ValidationGroup="A" 
                                        Width="80px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                        ControlToValidate="TxtReason1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </FooterTemplate>
                                </asp:TemplateField><asp:TemplateField><FooterTemplate><asp:Button ID="BtnAdd" 
                                        runat="server" CommandName="add" CssClass="redbox" Text="Add" 
                                        ValidationGroup="A" />
                                </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellpadding="0" cellspacing="0" class="fontcss" width="100%">
                                    <tr height="24" valign="middle">
                                        <td align="center">
                                            <b>Date</b> </td><td align="center"><b>Purpose Type</b> </td><td align="center"><b>Purpose Type Of</b> </td><td 
                                            align="center"><b></b></td><td align="center"><b>F Time</b> </td><td 
                                            align="center"><b>T Time</b> </td><td align="center"><b>Visitor Name</b> </td><td 
                                            align="center"><b>Contact Person</b> </td><td align="center"><b>Contact No</b> <td 
                                                align="center"><b>Reason</b></td><td align="center">&#160;</td></td></tr><tr><td 
                                        align="center"><asp:TextBox ID="TxtDate2" runat="server" CssClass="box3" 
                                        Width="70px"> </asp:TextBox><cc1:CalendarExtender 
                                        ID="TxtDate2_CalendarExtender" runat="server" Enabled="True" 
                                        Format="dd-MM-yyyy" PopupPosition="BottomLeft" CssClass="cal_Theme2"  TargetControlID="TxtDate2">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator 
                                        ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtDate2" 
                                        ErrorMessage="*" ValidationGroup="A1"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                        ID="RegTxtDate2" runat="server" ControlToValidate="TxtDate2" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A1"></asp:RegularExpressionValidator></td><td 
                                        align="center"><asp:DropDownList ID="DropDownList3" runat="server" 
                                            AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Reason" 
                                            DataValueField="Id" onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                                            style="margin-bottom: 0px" Width="115px">
                                        </asp:DropDownList></td><td align="center"><asp:DropDownList ID="DropDownList4" 
                                            runat="server" AutoPostBack="True" Width="70px">
                                        </asp:DropDownList></td><td align="center" valign="top" width="100px"><asp:TextBox 
                                            ID="TxtDetails2" runat="server" CssClass="box3" Width="70px"> </asp:TextBox></td><td 
                                        align="center" valign="top" width="130px"><MKB:TimeSelector ID="TimeSelector3" 
                                            runat="server" AmPm="AM" MinuteIncrement="1"></MKB:TimeSelector></td><td 
                                        align="center" valign="top" width="130px"><MKB:TimeSelector ID="TimeSelector4" 
                                            runat="server" AmPm="AM" MinuteIncrement="1"></MKB:TimeSelector></td><td 
                                        align="center"><asp:TextBox ID="TxtPlace2" runat="server" CssClass="box3" 
                                            Width="100px"></asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtPlace2" 
                                            ErrorMessage="*" ValidationGroup="A1"> </asp:RequiredFieldValidator></td><td 
                                        align="center"><asp:TextBox ID="TxtContPerson2" runat="server" CssClass="box3" 
                                            Width="100px"> </asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtContPerson2" 
                                            ErrorMessage="*" ValidationGroup="A1"> </asp:RequiredFieldValidator></td><td 
                                        align="center"><asp:TextBox ID="TxtContNo2" runat="server" CssClass="box3" 
                                            Width="100px"></asp:TextBox><asp:RequiredFieldValidator 
                                            ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtContNo2" 
                                            ErrorMessage="*" ValidationGroup="A1"> </asp:RequiredFieldValidator><td 
                                            align="center"><asp:TextBox ID="TxtReason2" runat="server" CssClass="box3" 
                                                ValidationGroup="A1" Width="100px"> </asp:TextBox><asp:RequiredFieldValidator 
                                                ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtReason2" 
                                                ErrorMessage="*" ValidationGroup="A1"> </asp:RequiredFieldValidator></td><td 
                                            align="center"><asp:Button ID="Button2" runat="server" CommandName="add1" 
                                                CssClass="redbox" Text="Add" ValidationGroup="A1" /></td></td></tr></table>
                            </EmptyDataTemplate>
                            <PagerSettings PageButtonCount="40">
                            </PagerSettings>
                            </asp:GridView></td></tr><tr><td align="center" valign="middle"><asp:Button 
                                    ID="BtnSubmit" runat="server" CssClass="redbox" OnClick="BtnSubmit_Click" 
                                    Text="Submit"></asp:Button></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                    
                    <cc1:TabPanel ID="TabPanel2" Visible="false" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ContentTemplate><table class="style2"><tr><td><asp:GridView ID="GridView1" runat="server" AllowPaging="True"  DataKeyNames="Id"
                                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                            OnRowCommand="GridView1_RowCommand" PageSize="15" ShowFooter="True" 
                                            Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle Width="2%"  HorizontalAlign="Right"/></asp:TemplateField><asp:TemplateField ><ItemTemplate><asp:LinkButton ID="LinkButton2" runat="server"  CommandName="Del2">Delete</asp:LinkButton></ItemTemplate><ItemStyle Width="2%"  HorizontalAlign="Right"/></asp:TemplateField><asp:TemplateField HeaderText="Id"  Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate><ItemStyle Width="2%"  HorizontalAlign="Right"/></asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label ID="lblDate2" runat="server" Text='<%#Eval("FromDate") %>'> </asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtDate3" runat="server" CssClass="box3" Width="68px"> </asp:TextBox>
                                            
                                            <cc1:CalendarExtender ID="TxtDate3_CalendarExtender" runat="server" 
                                                Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="BottomLeft"
                                                            TargetControlID="TxtDate3"></cc1:CalendarExtender>
                                                            
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                            ControlToValidate="TxtDate3" ErrorMessage="*" ValidationGroup="D"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTxtDate3" runat="server" 
                                    ControlToValidate="TxtDate3" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="D"></asp:RegularExpressionValidator></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Type"><ItemTemplate><asp:Label ID="lblType2" runat="server" Text='<%#Eval("Type") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" 
                                                            DataSourceID="SqlDataSource1" DataTextField="Reason" DataValueField="Id" 
                                                            onselectedindexchanged="DropDownList5_SelectedIndexChanged"  Width="115px"
                                                            style="margin-bottom: 0px"></asp:DropDownList></FooterTemplate><ItemStyle Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Type Of"><ItemTemplate><asp:Label ID="lblTypeOf2" runat="server" Text='<%#Eval("TypeOf") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" 
                                                          Width="70px"   style="margin-bottom: 0px"></asp:DropDownList></FooterTemplate><ItemStyle Width="5%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:Label ID="lblTypeFor2" runat="server" Text='<%#Eval("TypeFor") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtDetails3" runat="server" CssClass="box3" Width="70px"> </asp:TextBox></FooterTemplate><ItemStyle Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="F Time"><ItemTemplate><asp:Label ID="lblFTime2" runat="server" Text='<%#Eval("FromTime") %>'> </asp:Label></ItemTemplate><FooterTemplate><MKB:TimeSelector ID="TimeSelector5" runat="server" AmPm="AM" 
                                                            MinuteIncrement="1"></MKB:TimeSelector></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="T Time"><ItemTemplate><asp:Label ID="lblTTime2" runat="server" Text='<%#Eval("ToTime") %>'> </asp:Label></ItemTemplate><FooterTemplate><MKB:TimeSelector ID="TimeSelector6" runat="server" AmPm="AM" 
                                                            MinuteIncrement="1"></MKB:TimeSelector></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Emp Name"><ItemTemplate><asp:Label ID="lblEmpName" runat="server" Text='<%#Eval("EmpId") %>'> </asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtEmp1" runat="server" CssClass="box3" ValidationGroup="D" 
                                                            Width="90px"> </asp:TextBox><cc1:AutoCompleteExtender ID="TxtEmp1_AutoCompleteExtender" runat="server" 
                                                            CompletionInterval="100" CompletionListCssClass="almt" 
                                                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                                            EnableViewState="true" FirstRowSelected="True" MinimumPrefixLength="1" 
                                                            ServiceMethod="GetCompletionList" ServicePath="" 
                                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmp1" 
                                                            UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="Req15" runat="server" 
                                                            ControlToValidate="TxtEmp1" ErrorMessage="*" ValidationGroup="D"> </asp:RequiredFieldValidator></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Visitor Name"><ItemTemplate><asp:Label ID="lblPlace" runat="server" Text='<%#Eval("Place") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtPlace3" runat="server"   Width="90px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                            ControlToValidate="TxtPlace3" ErrorMessage="*" ValidationGroup="D"></asp:RequiredFieldValidator></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Contact Person"><ItemTemplate><asp:Label ID="lblContPerson2" runat="server" 
                                                            Text='<%#Eval("ContactPerson") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtContPerson3" runat="server" Width="90px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                            ControlToValidate="TxtContPerson3" ErrorMessage="*" ValidationGroup="D"></asp:RequiredFieldValidator></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Contact No"><ItemTemplate><asp:Label ID="lblContNo2" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtContNo3" runat="server" Width="90px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                            ControlToValidate="TxtContNo3" ErrorMessage="*" ValidationGroup="D"></asp:RequiredFieldValidator></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Reason"><ItemTemplate><asp:Label ID="lblReason2" runat="server" Text='<%#Eval("Reason") %>'></asp:Label></ItemTemplate><FooterTemplate><asp:TextBox ID="TxtReason3" runat="server" CssClass="box3" Width="90px" ValidationGroup="D"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                            ControlToValidate="TxtReason3" ErrorMessage="*" ValidationGroup="D"> </asp:RequiredFieldValidator></FooterTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField><FooterTemplate><asp:Button ID="BtnAdd2" runat="server" CommandName="add2" CssClass="redbox" 
                                                            Text="Add" ValidationGroup="D" /></FooterTemplate><ItemStyle Width="1%" /></asp:TemplateField></Columns><EmptyDataTemplate><table cellpadding="0" cellspacing="0" class="fontcss" width="100%"><tr height="24" valign="middle"><td align="center"><b>Date</b> </td><td align="center"><b>Purpose Type</b> </td><td align="center"><b>For Purposr Type Of</b> </td><td align="center"><b></b></td><td align="center"><b>F Time</b> </td><td align="center"><b>T Time</b> </td><td align="center"><b>Emp Name</b></td><td align="center"><b>Visit Place</b> </td><td align="center"><b>Contact Person</b> </td><td align="center"><b>Contact No</b> <td align="center"><b>Reason</b></td><td align="center">&#160;</td></td></tr><tr><td align="center"><asp:TextBox ID="TxtDate4" runat="server" CssClass="box3" Width="70px"></asp:TextBox><cc1:CalendarExtender ID="TxtDate4_CalendarExtender" runat="server" 
                                 Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="BottomLeft"
                                                                TargetControlID="TxtDate4"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                                                                ControlToValidate="TxtDate4" ErrorMessage="*" ValidationGroup="C"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTxtDate4" runat="server" 
                                    ControlToValidate="TxtDate4" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="C"></asp:RegularExpressionValidator></td><td align="center"><asp:DropDownList ID="DropDownList7" runat="server" AutoPostBack="True" 
                                                                DataSourceID="SqlDataSource1" DataTextField="Reason" DataValueField="Id" 
                                                                onselectedindexchanged="DropDownList7_SelectedIndexChanged" 
                                                                style="margin-bottom: 0px" Width="115px"></asp:DropDownList></td><td align="center" valign="top" width="80px"><asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True" 
                                                                Width="70px"></asp:DropDownList></td><td align="center" valign="top" width="80px"><asp:TextBox ID="TxtDetails4" runat="server" CssClass="box3" Width="70px"></asp:TextBox></td><td align="center" valign="top" width="130px"><MKB:TimeSelector ID="TimeSelector7" runat="server" AmPm="AM" 
                                                                MinuteIncrement="1"></MKB:TimeSelector></td><td align="center" valign="top" width="130px"><MKB:TimeSelector ID="TimeSelector8" runat="server" AmPm="AM" 
                                                                MinuteIncrement="1"></MKB:TimeSelector></td><td align="center"><asp:TextBox ID="TxtEmp2" runat="server" CssClass="box3" ValidationGroup="C" 
                                                                Width="100px"></asp:TextBox><cc1:AutoCompleteExtender ID="TxtEmp2_AutoCompleteExtender" runat="server" 
                                                                CompletionInterval="100" CompletionListCssClass="almt" 
                                                                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                                                                CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                                                                FirstRowSelected="True" MinimumPrefixLength="1" 
                                                                ServiceMethod="GetCompletionList" ServicePath="" 
                                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmp2" 
                                                                UseContextKey="True"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" 
                                                                ControlToValidate="TxtEmp2" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td align="center"><asp:TextBox ID="TxtPlace4" runat="server" CssClass="box3" Width="95px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                                                ControlToValidate="TxtPlace4" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td align="center"><asp:TextBox ID="TxtContPerson4" runat="server" Width="100px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                                                                ControlToValidate="TxtContPerson4" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td align="center"><asp:TextBox ID="TxtContNo4" runat="server" CssClass="box3" Width="95px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                                                                ControlToValidate="TxtContNo4" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator><td align="center"><asp:TextBox ID="TxtReason4" runat="server" CssClass="box3" ValidationGroup="C" 
                                                                    Width="95px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                                                                    ControlToValidate="TxtReason4" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator></td><td align="center"><asp:Button ID="Button22" runat="server" CommandName="add3" CssClass="redbox" 
                                                                    Text="Add" ValidationGroup="C" /></td></td></tr></table></EmptyDataTemplate><PagerSettings PageButtonCount="40" /></asp:GridView></td></tr><tr><td align="center" valign="middle"><asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                            OnClick="Button2_Click" Text="Submit" /></td></tr></table>
                        </ContentTemplate></cc1:TabPanel>
                    
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>View
                        </HeaderTemplate>
                        <ContentTemplate>                       
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="GridView2" runat="server" 
                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                DataKeyNames="Id"  ShowFooter="True"
                                OnPageIndexChanged="GridView2_PageIndexChanged" 
                                OnPageIndexChanging="GridView2_PageIndexChanging" Width="100%" 
                                onrowcommand="GridView2_RowCommand" PageSize="15"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField ><ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server"  CommandName="Del3">Delete</asp:LinkButton></ItemTemplate><ItemStyle Width="2%"  HorizontalAlign="Right"/></asp:TemplateField><asp:TemplateField ><ItemTemplate><asp:LinkButton ID="LinkButton4" runat="server"  CommandName="Print">Print</asp:LinkButton></ItemTemplate><ItemStyle Width="2%"  HorizontalAlign="Right"/></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId1" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate><ItemStyle Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Fin Year"><ItemTemplate><asp:Label ID="lblFinYear" runat="server" Text='<%#Eval("FinYear") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="GP No"><ItemTemplate><asp:Label ID="lblGPNo" runat="server" Text='<%#Eval("GPNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Gen.Date"><ItemTemplate><asp:Label ID="lblSysDate" runat="server" Text='<%#Eval("SysDate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText=" For Date"><ItemTemplate><asp:Label ID="lblInVoiceNo" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="From Time"><ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%#Eval("FromTime") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="To Time"><ItemTemplate><asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("ToTime") %>'></asp:Label>
                                </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Employee Name"><ItemTemplate><asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("SelfEId") %>'></asp:Label>
                                </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="13%" /></asp:TemplateField><asp:TemplateField HeaderText="Purpose Type"><ItemTemplate><asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="For Purpose Type For"><ItemTemplate><asp:Label ID="lblWONo" runat="server" Text='<%#Eval("TypeFor") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Reason"><ItemTemplate><asp:Label ID="lblReason" runat="server" Text='<%#Eval("Reason") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="12%" /></asp:TemplateField><asp:TemplateField HeaderText="Authorized by"><ItemTemplate><asp:Label ID="lblAuthorizedBy" runat="server" Text='<%# Bind("AuthorizedBy") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="12%" /></asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label ID="lblAuthorizeDate" runat="server" Text='<%# Bind("AuthorizeDate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Time"><ItemTemplate><asp:Label ID="lblAuthorizeTime" runat="server" Text='<%# Bind("AuthorizeTime") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="DId" Visible="False" ><ItemTemplate><asp:Label ID="lblDId" runat="server" Text='<%# Bind("DId") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Authorize" Visible="False" ><ItemTemplate><asp:Label ID="lblAuthorize" runat="server" Text='<%# Bind("Authorize") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Feedback" ><ItemTemplate><asp:Label ID="LblFeedback" runat="server" Text='<%# Bind("Feedback") %>'  ></asp:Label><asp:TextBox ID="TxtFeedback" runat="server" Visible="false"  CssClass="box3"  Width ="80%" > </asp:TextBox>
                                </ItemTemplate><FooterTemplate><asp:Button ID="BtnFeedback"  runat="server" Text="Submit" ValidationGroup="Shree"
                                 CommandName="Submit" CssClass="redbox" />
                                </FooterTemplate><FooterStyle HorizontalAlign="Right" /><ItemStyle HorizontalAlign="Left" Width="20%" /></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon"  Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>
                            
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                </cc1:TabContainer>
            </td>
        </tr>
        
        </table>
        
       
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

