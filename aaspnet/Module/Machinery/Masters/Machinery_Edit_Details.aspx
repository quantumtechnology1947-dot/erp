<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Masters_Machinery_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>        
    <style type="text/css">
        .style2
        {
            font-size: medium;
        }
        .style3
        {
            height: 22px;
        }
        .style4
        {
            font-size: medium;
            height: 22px;
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

<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    
    
<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Machinary - Edit</b></td>
        </tr>
        <tr>
            <td valign="top">
<cc1:TabContainer ID="TabContainer1" runat="server"  ActiveTabIndex="2"  
                    Width="100%"  AutoPostBack="false">


<cc1:TabPanel runat="server" HeaderText="Item Master"  ID="TabPanel1">
    

<HeaderTemplate>Machine
    </HeaderTemplate><ContentTemplate>
    
    <asp:UpdatePanel ID="Up" UpdateMode="Conditional" runat="server">    
    <ContentTemplate>
    <fieldset >
    
    <table class="style6"><tr><td width="30px">&nbsp;</td><td class="style9">
        Machine Code</td><td class="style2" width="350">: <asp:Label ID="lblItemCode" runat="server" 
        style="font-weight: 700; font-size: small;"></asp:Label></td><td class="style12" width="10">&#160;</td><td class="style3">&nbsp;UOM : <asp:Label ID="lblunit" runat="server" style="font-weight: 700"></asp:Label></td><td width="280"></td></tr><tr><td>&nbsp;</td><td class="style9">Name</td><td colspan="4">: <asp:Label ID="lblManfDesc" runat="server"></asp:Label></td></tr><tr><td>&nbsp;</td><td class="style9">Model</td><td class="style2">: <asp:TextBox ID="txtModel" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtModel" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style12">&#160;</td><td class="style3">Make</td><td>: <asp:TextBox ID="txtMake" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtMake" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td>&nbsp;</td><td class="style9">Purchase Date</td><td class="style2">: <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="txtPurchaseDate_CalendarExtender1" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtPurchaseDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPurchaseDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtPurchaseDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td class="style12">&#160;</td><td class="style3">Capacity </td><td>: <asp:TextBox ID="txtCapacity" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="txtCapacity" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td>&nbsp;</td><td class="style9">Cost</td><td class="style2">: <asp:TextBox ID="txtCost" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtCost" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                        ControlToValidate="txtCost" ErrorMessage="*" 
                        ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator></td><td class="style12">&#160;</td><td class="style3">Supplier Name</td><td>: <asp:TextBox ID="txtSupplierName" 
            runat="server" CssClass="box3" Width="250px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtSupplierName_AutoCompleteExtender" 
                        runat="server" DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" 
                        ServiceMethod="sql" ServicePath="" TargetControlID="txtSupplierName" 
                        UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ControlToValidate="txtSupplierName" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td>&nbsp; </td><td class="style9">Life Date </td><td class="style2">: <asp:TextBox ID="txtLifeDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="txtLifeDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtLifeDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtLifeDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegLifeDate" runat="server" 
                    ControlToValidate="txtLifeDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td class="style12">&#160;</td><td class="style3">Warranty Expires on</td><td>: <asp:TextBox ID="txtWarrantyExpireson" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="txtWarrantyExpireson_CalendarExtender1" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtWarrantyExpireson"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtWarrantyExpireson" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txtWarrantyExpireson" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td>&#160;</td><td class="style9">Insurance </td><td valign="middle"><asp:RadioButtonList ID="RadiobtnInsurance" runat="server" 
                        RepeatDirection="Horizontal" AutoPostBack="True" 
                onselectedindexchanged="RadiobtnInsurance_SelectedIndexChanged"><asp:ListItem Selected="True" Value="0">NO</asp:ListItem><asp:ListItem Value="1">YES</asp:ListItem></asp:RadioButtonList></td><td class="style12" valign="middle">&#160;</td><td class="style3"><asp:Label ID="lblInsuranceExpireson" runat="server" 
                Text="Insurance Expires on"></asp:Label></td><td><asp:Label ID="lblcolon" runat="server" Text=": "></asp:Label><asp:TextBox 
            ID="txtInsuranceExpiresOn" runat="server" CssClass="box3">
            
            
            </asp:TextBox>
            <cc1:CalendarExtender 
            ID="CalendarExtender1" runat="server" Enabled="True" Format="dd-MM-yyyy" 
            TargetControlID="txtInsuranceExpiresOn"></cc1:CalendarExtender>
            
            
            <asp:RequiredFieldValidator ID="ReqInsuranceExpire" runat="server" 
                ControlToValidate="txtInsuranceExpiresOn" ErrorMessage="*" ValidationGroup="A" 
                Visible="False">
                </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="txtInsuranceExpiresOn" ErrorMessage="*" 
            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
            ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td>&nbsp; </td><td class="style9">Put to use </td><td class="style2">: <asp:TextBox ID="txtPutToUse" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtPutToUse"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtPutToUse" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                    ControlToValidate="txtPutToUse" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td class="style12">&#160;</td><td class="style3">Received Date</td><td>: <asp:TextBox 
            ID="txtReceivedDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender 
            ID="txtReceivedDate_CalendarExtender1" runat="server" Enabled="True" 
            Format="dd-MM-yyyy" TargetControlID="txtReceivedDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtReceivedDate" ErrorMessage="*" ValidationGroup="A"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtReceivedDate" ErrorMessage="*" 
            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
            ValidationGroup="A"> </asp:RegularExpressionValidator></td></tr><tr><td>&nbsp;</td><td class="style9">Incharge</td><td class="style2">: <asp:TextBox ID="txtIncharge" runat="server" CssClass="box3" 
                Width="250px"></asp:TextBox><cc1:AutoCompleteExtender ID="txtIncharge_AutoCompleteExtender" runat="server" 
                        DelimiterCharacters="" Enabled="True" MinimumPrefixLength="1" 
                        ServiceMethod="GetCompletionList" ServicePath="" TargetControlID="txtIncharge" 
                        UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt"></cc1:AutoCompleteExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtIncharge" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td class="style12">&#160;</td><td class="style3">Location </td><td>: <asp:TextBox ID="txtLocation" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                        ControlToValidate="txtLocation" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td>&nbsp;</td><td class="style9" valign="bottom">Upload Image</td><td class="style2" valign="bottom">: <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="lbldownload" runat="server"></asp:Label><asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/images/cross.gif" 
            onclick="ImageButton1_Click" CausesValidation="true"  /></td><td class="style12">&#160;&nbsp; </td><td class="style3">Preventive Maintenance in days </td><td>: <asp:TextBox ID="txtPreMaintInDays" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                        ControlToValidate="txtPreMaintInDays" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                        ControlToValidate="txtPreMaintInDays" ErrorMessage="*" 
                        ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style3"></td><td class="style3"></td><td class="style4"></td><td class="style3"></td><td class="style3"></td><td class="style3"></td></tr><tr><td>&#160;</td><td class="style9">&#160;</td><td class="style2">&#160;</td><td class="style12">&#160;</td><td class="style3">&#160;&nbsp;</td><td>&#160;&nbsp;</td></tr></table>
     </fieldset>
     </ContentTemplate>
     </asp:UpdatePanel>  
    </ContentTemplate>
    
</cc1:TabPanel>

<cc1:TabPanel ID="TabPanel2" HeaderText=""  runat="server">
    <HeaderTemplate> 
        Functions
    </HeaderTemplate>
    
<ContentTemplate><asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional"><ContentTemplate><fieldset ><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td colspan="3"></td></tr><tr><td 
            align="left" valign="top" width="49%" rowspan="5"><asp:GridView ID="GridView1" runat="server"  CssClass="yui-datatable-theme"                
                      Width="100%" AutoGenerateColumns="False" 
                    DataKeyNames="Id" ><Columns><asp:TemplateField 
                        HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:CheckBox ID="chk" AutoPostBack="false" runat="server" Checked="false" /></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Process" SortExpression="Process"><ItemTemplate><asp:Label ID="lblprocess" runat="server" Text='<%# Bind("Pro") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Id"  SortExpression="Id" 
                            Visible="False"><ItemTemplate><asp:Label ID="lblProId" runat="server" Text='<%# Bind("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" /></asp:GridView></td><td 
                align="left" width="20" rowspan="5">&#160; </td><td align="left" valign="top" 
            width="49%" height="15">&nbsp;<b><span class="style2">Process Temp</span></b>&nbsp;</td></tr><tr><td align="left" valign="top" width="49%"><asp:GridView ID="GridView4" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                OnPageIndexChanging="GridView4_PageIndexChanging" 
                OnRowCommand="GridView4_RowCommand" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBtn" runat="server" CommandName="del" 
                                OnClientClick=" return confirmationDelete()" Text="Delete"> </asp:LinkButton></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Process"><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("Process") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                    Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></td></tr><tr><td align="left" height="5" valign="middle" width="49%">&#160;</td></tr><tr><td 
                align="left" valign="top" width="49%" class="style2" height="15"><b>Process Master</b></td></tr><tr><td align="left" valign="top" width="49%"><asp:GridView 
                ID="GridView6" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                OnPageIndexChanging="GridView6_PageIndexChanging" 
                Width="100%" OnRowCommand="GridView6_RowCommand"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBtn" runat="server" CommandName="del" 
                OnClientClick=" return confirmationDelete()" Text="Delete"> </asp:LinkButton></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Process"><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("Process") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label5" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></td></tr><tr align="center"><td align="center" class="style11" height="25"   valign="bottom"><asp:Button ID="btnProcessAdd"  OnClientClick="return confirmationAdd();" CssClass="redbox"  runat="server" Text="Add" 
                 onclick="btnProcessAdd_Click" /></td><td align="justify" class="style11" 
                height="25" valign="middle">&#160; </td><td align="center" class="style11" 
                height="25" valign="middle">&nbsp;&nbsp;<asp:Label ID="lblprocessmsg" runat="server" ForeColor="Red" 
                                            Text="*  Atleast one process is required for Machinery." Visible="False"></asp:Label></td></tr></table></fieldset></ContentTemplate></asp:UpdatePanel>
                
                
    </ContentTemplate>
                
</cc1:TabPanel>

<cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
        
        
    <HeaderTemplate> 
        Spare
    </HeaderTemplate><ContentTemplate>    
        
    
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional"><ContentTemplate><fieldset ><table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px"><tr><td class="style5" 
                    height="30" colspan="3"><asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="True" 
                CssClass="box3" Height="21px" 
                OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged"></asp:DropDownList>&nbsp;<asp:DropDownList 
                ID="DrpSubCategory" runat="server" AutoPostBack="True" 
                CssClass="box3" 
                OnSelectedIndexChanged="DrpSubCategory_SelectedIndexChanged"></asp:DropDownList>&#160;<asp:DropDownList 
                ID="DrpSearchCode" runat="server" AutoPostBack="True" 
                CssClass="box3" 
                ><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem></asp:DropDownList><asp:TextBox 
                ID="txtSearchItemCode" runat="server" CssClass="box3" Width="200px"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                OnClick="btnSearch_Click" Text="Search" />&nbsp; </td></tr><tr><td class="fontcss" valign="top" width="49%" rowspan="5">&#160;&#160; 
                
                
                
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        CssClass="yui-datatable-theme" 
                        OnPageIndexChanging="GridView2_PageIndexChanging" Width="100%"><Columns><asp:TemplateField 
                                HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" /></asp:TemplateField>
                                
                                
                                <asp:TemplateField>
                                <ItemTemplate>
                                <asp:CheckBox ID="chkSpare" 
                                    runat="server" AutoPostBack="false" Checked="false" />
                                    </ItemTemplate><HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                    </asp:TemplateField>
                                 
                                 
                                 <asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label 
                                    ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label 
                                    ID="lblId" runat="server" Text='<%# Bind("Id") %>'> </asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" /></asp:TemplateField><asp:BoundField DataField="SubCategory" 
                                HeaderText="SubCategory" Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField 
                                DataField="ManfDesc" HeaderText="Description"><ItemStyle 
                                VerticalAlign="Top" Width="45%" /></asp:BoundField><asp:BoundField 
                                DataField="UOMBasic" HeaderText="UOM"><ItemStyle HorizontalAlign="Center" 
                                VerticalAlign="Top" /></asp:BoundField>
                                
                                   <asp:TemplateField HeaderText=" Qty"><ItemTemplate><asp:TextBox 
                                    ID="txtQty" runat="server" CssClass="box3" Width="70%"> </asp:TextBox><asp:RequiredFieldValidator 
                                    ID="ReqQty" runat="server" ControlToValidate="txtQty" ErrorMessage="*" 
                                    ValidationGroup="spare" Visible="false"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                    ID="RegNumeric" runat="server" ControlToValidate="txtQty" ErrorMessage="*" 
                                    ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="spare"></asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:TemplateField>
                      
                      
                      
                      
                      </Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                            Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" />
                                            </asp:GridView>
                                            
                                            
                                            
                                            
                                            </td><td class="fontcss" rowspan="5" valign="top" width="20"></td> 
                <td align="left" class="fontcsswhite" class="fontcsswhite" height="15" 
                    scope="col" style="background: url(../../../images/hdbg.JPG)" valign="top" 
                    valign="top" width="49%">&#160;<b>Spare Temporary</b></td></tr><tr><td class="fontcss" valign="middle" 
                width="49%"><asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                    OnPageIndexChanging="GridView3_PageIndexChanging" 
                    OnRowCommand="GridView3_RowCommand" Width="100%"><Columns><asp:TemplateField 
                            HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBtn" 
                                runat="server" CommandName="del" OnClientClick=" return confirmationDelete()" 
                                Text="Delete"> </asp:LinkButton></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label 
                                ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label></ItemTemplate><ItemStyle Width="10%" /></asp:TemplateField>
                        <asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label 
                                ID="lblManfDesc" runat="server" Text='<%#Eval("ManfDesc") %>'> </asp:Label></ItemTemplate><ItemStyle Width="25%" /></asp:TemplateField><asp:TemplateField HeaderText="Unit"><ItemTemplate><asp:Label 
                                ID="lblUOM" runat="server" Text='<%#Eval("UOMBasic") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField>
                                
                                
                                
                                
                                <asp:TemplateField HeaderText="Id" SortExpression="Id" 
                            Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" 
                                Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label3" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                        Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></td></tr><tr><td 
                class="fontcss" valign="top" width="49%" height="15">&#160;</td></tr><tr><td class="fontcsswhite" 
                valign="middle" valign="middle" width="49%" align="left" class="fontcsswhite" 
                    height="15" scope="col" style="background: url(../../../images/hdbg.JPG)">&nbsp;<b>Spare Master</b></td></tr><tr><td class="fontcss" valign="top" width="49%"><asp:GridView ID="GridView5" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                        OnPageIndexChanging="GridView5_PageIndexChanging" 
                        OnRowCommand="GridView5_RowCommand" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="linkBtn" runat="server" CommandName="del" 
                                        OnClientClick=" return confirmationDelete()" Text="Delete"> </asp:LinkButton></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField>
                    <asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label></ItemTemplate><ItemStyle Width="10%" /></asp:TemplateField>
                    <asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblManfDesc" runat="server" Text='<%#Eval("ManfDesc") %>'> </asp:Label></ItemTemplate><ItemStyle Width="25%" /></asp:TemplateField><asp:TemplateField HeaderText="Unit"><ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label4" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                            Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></td></tr><tr><td align="center" class="style11" height="25" valign="middle"><asp:Button ID="btnSpareAdd" runat="server" CssClass="redbox" 
                    onclick="btnSpareAdd_Click" OnClientClick="return confirmationAdd();" 
                    Text="Add" ValidationGroup="spare" /></td><td align="center" class="style11" height="25" valign="middle">&nbsp;&nbsp; </td><td align="center" class="style11" height="25" valign="middle">&nbsp; <asp:Label ID="lblsparemsg" runat="server" ForeColor="Red" 
                    Text="*  Atleast one spare is required for Machinery." Visible="False"></asp:Label></td></tr></table></fieldset></ContentTemplate></asp:UpdatePanel>
            
            
    </ContentTemplate></cc1:TabPanel>
    


</cc1:TabContainer>
</td>
</tr>
        <tr>
            <td valign="middle" height="25" width="92%" align="right">
                <asp:Button ID="btnProceed" runat="server"  
                    OnClientClick=" return confirmationAdd()" CssClass="redbox" Text="Update" 
                    onclick="btnProceed_Click" ValidationGroup="A" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="redbox" 
                    onclick="btnCancel_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

