<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PR_Items, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    
        .style3
        {
            height: 37px;
        }
    
        .style4
        {
            width: 100%;
            float: left;
        }
        .style5
        {
            height: 31px;
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

    
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PR - New &nbsp;&nbsp;&nbsp;&nbsp; WO No:
            <asp:Label ID="lblwo" runat="server"></asp:Label>&nbsp;
           &nbsp;&nbsp;<asp:Label ID="lbltype" runat="server"></asp:Label></b></td>
        </tr>
        <tr>
            <td align="left" class="style3" valign="top">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="400px" 
                    AutoPostBack="true" onactivetabchanged="TabContainer1_ActiveTabChanged" 
                    ScrollBars="Auto" Width="100%">
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="List of Items">
                        <HeaderTemplate>
                            
                            List of Items 
                        </HeaderTemplate>
                        
                        <ContentTemplate>
                            <table align="left" cellpadding="0" cellspacing="0" class="style4">
                                <tr>
                                    <td class="style5" valign="middle">
                                        <b>Supplier</b>&nbsp; 
                                        <asp:TextBox ID="txtSupplierId" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                            CompletionInterval="100" CompletionSetCount="2" DelimiterCharacters="" 
                                            Enabled="True" FirstRowSelected="True" MinimumPrefixLength="1" 
                                            ServiceMethod="GetCompletionList" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="txtSupplierId" 
                                            UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                                        </cc1:AutoCompleteExtender>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                                            OnClick="btnSearch_Click" Text="Search" />
                                         
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <asp:Panel ID="Panel1" runat="server" Height="370px" ScrollBars="Auto">
                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                                OnPageIndexChanging="GridView2_PageIndexChanging" 
                                                OnRowCommand="GridView2_RowCommand" style="position:static" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SN">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Right" Width="3%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblit" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("PurchDesc") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="17%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="UOM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbluom" runat="server" Text='<%# Eval("UOMPurchase") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="4%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BOM Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltotqty" runat="server" Text='<%# Eval("TotQty") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PR Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblprqty" runat="server" Text='<%# Eval("PRQty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="WIS Qty">
                                                        <ItemTemplate>
                                                       <asp:Label ID="lblwisqty" runat="server" Text='<%#Eval("WISQty") %>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="MIN Qty">
                                                        <ItemTemplate>
                                                       <asp:Label ID="lblminqty" runat="server" Text='<%# Eval("MINQty") %>'></asp:Label>
                                                            
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Req. Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="ReqQty" runat="server" Text='<%# Eval("ReqQty") %>' CssClass="box3" Width="60">
                                                            </asp:TextBox>
                                                              <asp:Label ID="lblReqQty" runat="server" Visible="false" Text='<%# Eval("ReqQty") %>'></asp:Label>
                                                            <asp:RequiredFieldValidator ID="ReqReqQty" runat="server" 
                                                                ControlToValidate="ReqQty" ErrorMessage="*" ValidationGroup="A">
                                                            </asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularReqQty" runat="server" 
                                                                ControlToValidate="ReqQty" ErrorMessage="*" 
                                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                                                            </asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="7%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Supplier">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Supplier" runat="server" ControlStyle-CssClass="box3" 
                                                                EnableViewState="true" Text='<%# Eval("Supplier") %>' Width="89%">
                                                            </asp:TextBox>
                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                                                CompletionInterval="100" CompletionSetCount="2" EnableCaching="true" 
                                                                Enabled="True" FirstRowSelected="True" MinimumPrefixLength="1" 
                                                                ServiceMethod="GetCompletionList" ServicePath="" 
                                                                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="Supplier" 
                                                                UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                                                            </cc1:AutoCompleteExtender>
                                                            <asp:RequiredFieldValidator ID="ReqSupplier" runat="server" 
                                                                ControlToValidate="Supplier" ErrorMessage="*" ValidationGroup="A">
                                                            </asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="11%" />
                                                    </asp:TemplateField> 
                                                    
                                                    
                            <asp:TemplateField HeaderText="Rate">
                            <ItemTemplate>
                            <asp:TextBox ID="Rate" runat="server" Text='<%# Eval("Rate") %>'  CssClass="box3" Width="60"></asp:TextBox>
                                                        
                           <%--<a  runat="server" id="rt"><img  alt="" src="../../../images/Rupee.JPG" border="0"/></a>--%>
                           
                          <asp:ImageButton ID="ImageButton1"  runat="server" CommandName="rate" OnClientClick="aspnetForm.target='_blank';"
                                            ValidationGroup="B" ImageUrl="~/images/Rupee.JPG" />                                              
                                             
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="Rate" ErrorMessage="*" 
                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                            </asp:RegularExpressionValidator>                                
                             
                            </ItemTemplate>
                               
                            <ItemStyle VerticalAlign="Top" Width="9%" />
                            </asp:TemplateField>  
                            
                                                    <asp:TemplateField HeaderText="A/c Head">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="AccHead" runat="server" Width="100%" CssClass="box3" 
                                                                DataSourceID="SqlDataSource1" DataTextField="Symbol" DataValueField="Id">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Del. Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="DelDate" runat="server" CssClass="box3" 
                                                                Text='<%# Eval("DelDate") %>' Width="85%">
                                                            </asp:TextBox>
                                                            <cc1:CalendarExtender ID="DelDate_CalendarExtender" runat="server" 
                                                                Enabled="True" Format="dd-MM-yyyy" PopupPosition="Left" 
                                                                TargetControlID="DelDate">
                                                            </cc1:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="ReqDelDate" runat="server" 
                                                                ControlToValidate="DelDate" ErrorMessage="*" ValidationGroup="A">
                                                            </asp:RequiredFieldValidator>
                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                ControlToValidate="DelDate" ErrorMessage="*" 
                                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                                            
                                                        </ItemTemplate>
                                                        <ItemStyle VerticalAlign="Top" Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="Rmk" runat="server" CssClass="box3" Width="100">                                                            </asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="8%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="Add" runat="server" CommandName="AddMe" CssClass="redbox" 
                                                                Text="Add" ValidationGroup="A" OnClientClick="aspnetForm.target='_Self';"  />
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Size="10pt" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False">
                                                        <ItemStyle VerticalAlign="Top" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Item Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblitemid" runat="server" Text='<%# Eval("ItemId") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Type" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Type") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblpid" runat="server" Text='<%# Eval("PId") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcid" runat="server" Text='<%# Eval("CId") %>'> </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>                    
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                                                <FooterStyle Font-Bold="False" />
                                                <HeaderStyle Font-Size="9pt" />
                                            </asp:GridView>
                                        </asp:Panel>
                                         
                                    </td>
                                  
                                </tr>
                            </table>
                        </ContentTemplate>
                        
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Selected Items">
                        <HeaderTemplate>
                            Selected Items </HeaderTemplate>                        
                        <ContentTemplate>
                            <table align="left" cellpadding="0" cellspacing="0" class="style4">
                                <tr>
                                    <td>
                                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Auto">
                                            <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                                onpageindexchanging="GridView3_PageIndexChanging" 
                                                onrowcommand="GridView3_RowCommand" PageSize="15" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SN">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtn" runat="server" CommandName="AddToMaster" 
                                                                OnClientClick=" return confirmationDelete()" Text="Delete">
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblitemcode" runat="server" Text='<%# Eval("ItemCode") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate >
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc0" runat="server" Text='<%# Eval("PurchDesc") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="25%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="UOM">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblunit" runat="server" Text='<%# Eval("UOMPurchase") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Req. Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblqty" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Supplier">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsupl" runat="server" Text='<%# Eval("Supplier") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="A/c Head">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblachead" runat="server" Text='<%# Eval("AcHead") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Del. Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldeldate" runat="server" Text='<%# Eval("DelDate") %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrmk" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ItemId" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblitid" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" height="25" valign="middle">
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT [Symbol], [Id] FROM [AccHead]"></asp:SqlDataSource>
                
                <asp:Button ID="btnGenerate" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                    Text="Generate PR" onclick="btnGenerate_Click" ValidationGroup="A" />
            &nbsp;<asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="btnCancel" OnClick="btnCancel_Click"></asp:Button>

            &nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

