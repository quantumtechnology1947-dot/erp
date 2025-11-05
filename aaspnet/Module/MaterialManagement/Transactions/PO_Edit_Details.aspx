<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    
    <style type="text/css">
        #Iframe1
        {
            width: 99%;
            height: 257px;
        }
        .style7
        {
            width: 100%;
        }
        .style8
        {
            width: 4px;
            height: 26px;
        }
        .style9
        {
            width: 95px;
            height: 26px;
        }
        .style10
        {
            width: 527px;
            height: 26px;
        }
        .style18
        {
            width: 74px;
            height: 26px;
        }
        .style17
        {
            height: 26px;
        }
        .style12
        {
            width: 4px;
            height: 36px;
        }
        .style13
        {
            width: 95px;
            height: 36px;
        }
        .style14
        {
            width: 527px;
            height: 36px;
        }
        .style19
        {
            width: 74px;
            height: 36px;
        }
        .style16
        {
            height: 36px;
        }
        .style22
        {
            width: 389px;
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

    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PO - Edit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PO No :
                <asp:Label ID="lblpono" runat="server"></asp:Label>
&nbsp;&nbsp;</b></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="style7">
                    <tr>
                        <td class="style8">
                        </td>
                        <td class="style9">
                            Supplier Name</td>
                        <td class="style10">

                <asp:TextBox ID="txtNewCustomerName" runat="server" Width="350px" 
                CssClass="box3"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtNewCustomerName_AutoCompleteExtender" 
                runat="server" CompletionInterval="100" CompletionSetCount="2" 
                DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                ShowOnlyCurrentWordInCompletionListItem="True" 
                TargetControlID="txtNewCustomerName" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>


                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtNewCustomerName" ErrorMessage="*" 
                        ValidationGroup="B"></asp:RequiredFieldValidator>


                        </td>
                        <td class="style18">
                            Reference
                        </td>
                        <td class="style17">
                            <asp:DropDownList ID="DDLReference" 
                    runat="server" CssClass="box3">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style12">
                        </td>
                        <td class="style13" valign="top">
                            Address</td>
                        <td class="style14" valign="top">
                            &nbsp;<asp:Label runat="server" ID="LblAddress"></asp:Label>
                        </td>
                        <td class="style19" valign="top">
                            Ref. Date</td>
                        <td class="style16" valign="top">
                            <asp:TextBox ID="txtRefDate" 
                    runat="server" Width="86px" CssClass="box3"></asp:TextBox>
                            <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtRefDate" Format="dd-MM-yyyy">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtRefDate" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" ControlToValidate="txtRefDate" ErrorMessage="*" 
                                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                ValidationGroup="B"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtReferenceDesc" runat="server" CssClass="box3" 
                                Width="105px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr >
            <td valign="top">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
                    Width="100%" AutoPostBack="True" ScrollBars="Auto">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>PO Items</HeaderTemplate>
                        <ContentTemplate><iframe id="Iframe1"  runat ="server" width="100%" height="340px" 
                                frameborder="0" ></iframe>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
                        <HeaderTemplate>Selected Items</HeaderTemplate>
                        <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="348px" ScrollBars="Auto" 
                                        Width="100%">
                                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                    OnPageIndexChanging="GridView3_PageIndexChanging" 
                                    OnRowCommand="GridView3_RowCommand" Width="120%" PageSize="20"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="lnkButton" runat="server" CommandName="del" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label></ItemTemplate><ItemStyle Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="PO No"><ItemTemplate><asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="7%" /></asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblPurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label></ItemTemplate><ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMPurch" runat="server" Text='<%# Eval("UOMPurch") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="Qty"><ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="Rate"><ItemTemplate><asp:Label ID="lblrate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="A/c Head"><ItemTemplate><asp:Label ID="lblAcHead" runat="server" Text='<%# Eval("AcHead") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Dis %"><ItemTemplate><asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="Add Desc."><ItemTemplate><asp:Label ID="lblAddDesc" runat="server" Text='<%# Eval("AddDesc") %>'></asp:Label></ItemTemplate><ItemStyle Width="7%" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="PF"><ItemTemplate><asp:Label ID="lblPF" runat="server" Text='<%# Eval("PF") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Ex/Ser Tax"><ItemTemplate><asp:Label ID="lblExST" runat="server" Text='<%# Eval("ExST") %>'></asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="VAT"><ItemTemplate><asp:Label ID="lblVAT" runat="server" Text='<%# Eval("VAT") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Deli Date"><ItemTemplate><asp:Label ID="lblSheduleDate" runat="server" Text='<%# Eval("DelDate") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" /></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle></asp:GridView></asp:Panel></ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Terms & Conditions">
                        <HeaderTemplate>Terms &amp; Conditions
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:Panel ID="Panel2" ScrollBars="Auto" Height="348px" runat="server">
                           
                        <table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td class="style22" valign="top"><table align="left" cellpadding="0" 
                                    cellspacing="0" style="width: 382px"><tr><td>Payment Terms </td>
                                <td>
                                    <asp:DropDownList ID="DDLPaymentTerms" runat="server" CssClass="box3" 
                                        DataTextField="Terms" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr><tr><td>Frieght </td>
                                <td height="25">
                                    <asp:DropDownList ID="DDLFreight" runat="server" CssClass="box3" 
                                        DataTextField="Terms" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr><tr><td>Octri </td>
                                <td height="25">
                                    <asp:DropDownList ID="DDLOctroi" runat="server" CssClass="box3" 
                                        DataTextField="Terms" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr><tr><td>Warranty </td>
                                <td height="25">
                                    <asp:DropDownList ID="DDLWarrenty" runat="server" CssClass="box3" 
                                        DataSourceID="SqlDataSource1" DataTextField="Terms" DataValueField="Id">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr><tr><td>
                                    Insurance
                                </td>
                                <td height="25">
                                    <asp:TextBox ID="txtInsurance" runat="server" CssClass="box3" Width="250px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            
                            <tr>
                                <td class="style23" height="25">
                                    Remarks:</td>
                                <td class="style23" height="25">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="box3" Height="50px" 
                                        TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </td>
                                <td class="style23" height="25">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style23" colspan="4" height="25">
                                    <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="box3" 
                                        Height="120px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                </td>
                            </tr>
                            </table></td><td valign="top"><table align="left" cellpadding="0" cellspacing="0"><tr><td class="style25" height="25">Ship To </td><td>&#160;&nbsp;</td></tr><tr><td class="style25" colspan="2" height="25">
                                <asp:TextBox 
                                    ID="txtShipTo" runat="server" CssClass="box3" Height="100px" 
                                            TextMode="MultiLine" Width="100%"></asp:TextBox></td></tr><tr><td class="style25" height="25">Mode of Dispatch </td><td><asp:TextBox ID="txtModeOfDispatch" runat="server" CssClass="box3" 
                                            Width="295px"></asp:TextBox></td></tr><tr><td class="style25" height="25">Inspection </td><td><asp:TextBox ID="txtInspection" runat="server" CssClass="box3" Width="294px"></asp:TextBox></td></tr><tr><td class="style25" height="25">Annexture </td><td>
                                &nbsp;</td></tr><tr>
                                    <td 
                                    class="style25" height="100" colspan="2" valign="top">
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="box3" />
                                <asp:Label ID="lbldownload" 
                                    runat="server"></asp:Label>&nbsp;
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cross.gif" 
                                            onclick="ImageButton1_Click" style="width: 14px; height: 16px" Width="28px" />
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                            ProviderName="System.Data.SqlClient" 
                                            SelectCommand="SELECT * FROM [tblWarrenty_Master]"></asp:SqlDataSource>
                                    </td></tr>
                                <tr>
                                    <td colspan="2" height="25">
                                        <asp:Button ID="btnProceed" runat="server" CssClass="redbox" 
                                            OnClick="btnProceed_Click" OnClientClick=" return confirmationUpdate()" 
                                            Text="Update PO" ValidationGroup="B"></asp:Button>
                                        
                                    </td>
                                </tr>
                                </table></td></tr></table>
                                 </asp:Panel>
                                
                                        
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
                                    <td  align="right" colspan="2" valign="bottom" height="25">
                                        
                                        <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                            OnClick="btnCancel_Click" Text=" Cancel"></asp:Button>
                                    </td>
                                </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

