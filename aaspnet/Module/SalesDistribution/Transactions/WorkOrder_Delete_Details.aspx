<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_WorkOrder_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

 <table align="center" cellpadding="0" cellspacing="0" width="100%" >
    <tr height="21">
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Work 
            Order -Delete</b></td>
    </tr>
        <tr>
            <td align="left">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
                    Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>Task Execution</HeaderTemplate>
                        <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td colspan="2" align="left" valign="middle" height="24">&nbsp;Customer Name: <asp:Label ID="lblCustomerName" runat="server"></asp:Label><asp:Label ID="hfCustId" runat="server" Visible="False"></asp:Label><asp:Label ID="hfPoNo" runat="server" Visible="False"></asp:Label></td><td align="left" colspan="2" height="24" valign="middle">Work Order No:<asp:Label ID="lblWONo" runat="server"></asp:Label></td></tr><tr><td width="30%" align="left" valign="middle" height="24">&nbsp;Enquiry No: <asp:Label ID="hfEnqId" runat="server"></asp:Label></td><td width="25%" align="left" valign="middle" colspan="2">Type of WO : <asp:DropDownList DataSourceID="SqlDataSource2" DataTextField="Category" DataValueField="Id" 
                                ID="DDLTaskWOType" runat="server" AutoPostBack="True" CssClass="box3"><asp:ListItem 
                                Value="1"></asp:ListItem></asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                        SelectCommand="SELECT * FROM [tblSD_WO_Category]"></asp:SqlDataSource></td><td width="34%" align="left" valign="middle">Date of WO: 
                                <asp:TextBox ID="txtWorkOrderDate" runat="server" Width="90px" CssClass="box3" 
                                    ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtWorkOrderDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtWorkOrderDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td colspan="4" align="left" valign="middle" height="24">&nbsp;Project Title :<asp:TextBox 
                                    ID="txtProjectTitle" runat="server" CssClass="box3" Width="400px" 
                                    ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" valign="middle" height="22" colspan="4">&nbsp;Project Leader :<asp:TextBox 
            ID="txtProjectLeader" runat="server" CssClass="box3" Width="300px" ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" valign="middle" height="22">&nbsp;Category: <asp:DropDownList 
                                    ID="DDLCategory" runat="server" CssClass="box3" AutoPostBack="True"></asp:DropDownList></td><td align="left" colspan="3" valign="middle">Business Group: <asp:DropDownList 
                                        ID="DDLBusinessGroup" runat="server" CssClass="box3" AutoPostBack="True"></asp:DropDownList></td></tr><tr><td colspan="4" align="center" valign="middle"><table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td align="left" height="22" valign="middle" width="20%">&#160;Target DAP Date </td><td align="left" valign="middle" width="80%">&#160;From 
                                <asp:TextBox ID="txtTaskTargetDAP_FDate" runat="server" CssClass="box3" 
                                Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDAP_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetDAP_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                <asp:TextBox ID="txtTaskTargetDAP_TDate" runat="server" CssClass="box3" 
                                Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDAP_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetDAP_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Design Finalization Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskDesignFinalization_FDate" runat="server" 
                                    CssClass="box3" Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskDesignFinalization_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskDesignFinalization_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskDesignFinalization_TDate" runat="server" 
                                    CssClass="box3" Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskDesignFinalization_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskDesignFinalization_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Manufg. Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskTargetManufg_FDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetManufg_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetManufg_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskTargetManufg_TDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetManufg_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetManufg_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Try-out Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskTargetTryOut_FDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetTryOut_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetTryOut_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskTargetTryOut_TDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetTryOut_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetTryOut_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Despatch Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskTargetDespach_FDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDespach_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetDespach_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskTargetDespach_TDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDespach_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetDespach_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Assembly Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskTargetAssembly_FDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetAssembly_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetAssembly_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskTargetAssembly_TDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetAssembly_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetAssembly_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Installation Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskTargetInstalation_FDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetInstalation_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetInstalation_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskTargetInstalation_TDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetInstalation_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskTargetInstalation_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr><tr><td align="left" height="22" valign="middle">&#160;Cust. Inspection Date </td><td align="left" valign="middle">&#160;From 
                                    <asp:TextBox ID="txtTaskCustInspection_FDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskCustInspection_FDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskCustInspection_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>&#160; To&#160; 
                                    <asp:TextBox ID="txtTaskCustInspection_TDate" runat="server" CssClass="box3" 
                                    Width="90px" ReadOnly="True"></asp:TextBox><cc1:CalendarExtender ID="txtTaskCustInspection_TDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtTaskCustInspection_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender></td></tr></table>&#160;</td></tr><tr><td align="right" colspan="4" valign="middle"><asp:Button 
                                    ID="btnTaskNext" runat="server" CssClass="redbox" Text="Next  " 
                                    onclick="btnTaskNext_Click" />&nbsp;<asp:Button ID="btnTaskCancel" runat="server" 
                                    CssClass="redbox" Text="Cancel" onclick="btnTaskCancel_Click" /></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>Shipping</HeaderTemplate>
                        <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="6%" rowspan="3" align="left" valign="top">Address</td><td width="44%" rowspan="3" align="left" valign="top">
                            <asp:TextBox ID="txtShippingAdd" runat="server" CssClass="box3" Height="60px" 
            TextMode="MultiLine" Width="80%" ReadOnly="True"></asp:TextBox></td><td width="11%" align="left" valign="middle">Country</td><td width="39%" align="left" valign="middle">:<asp:DropDownList ID="DDLShippingCountry" 
            runat="server" CssClass="box3" AutoPostBack="True" 
                                    onselectedindexchanged="DDLShippingCountry_SelectedIndexChanged"></asp:DropDownList></td></tr><tr><td align="left" valign="middle">State</td><td align="left" valign="middle">:<asp:DropDownList 
                                    ID="DDLShippingState" runat="server" CssClass="box3" AutoPostBack="True" 
                                    onselectedindexchanged="DDLShippingState_SelectedIndexChanged"></asp:DropDownList></td></tr><tr><td align="left" valign="middle">City</td><td align="left" valign="middle">:<asp:DropDownList ID="DDLShippingCity" 
                                        runat="server" CssClass="box3" 
                                    onselectedindexchanged="DDLShippingCity_SelectedIndexChanged"></asp:DropDownList></td></tr><tr><td colspan="4" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td width="14%" align="left" valign="middle" height="24">Contact Person 1 </td><td width="36%" align="left" valign="middle">:<asp:TextBox ID="txtShippingContactPerson1" 
                runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox></td><td width="11%" align="left" valign="middle">Contact No </td><td width="39%" align="left" valign="middle">:<asp:TextBox ID="txtShippingContactNo1" 
                runat="server" CssClass="box3" ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" valign="middle" height="24">Email</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingEmail1" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td><td align="left" valign="middle">&nbsp;</td><td align="left" valign="middle">&nbsp;</td></tr><tr><td align="left" valign="middle" height="24">Contact Person 2 </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingContactPerson2" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td><td align="left" valign="middle">Contact No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingContactNo2" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" valign="middle" height="24">Email</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingEmail2" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td><td align="left" valign="middle">&nbsp;</td><td align="left" valign="middle">&nbsp;</td></tr><tr><td align="left" valign="middle" height="24">Fax No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingFaxNo" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td><td align="left" valign="middle">ECC No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingEccNo" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" valign="middle" height="24">TIN/CST No.</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingTinCstNo" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td><td align="left" valign="middle">TIN/VAT No.</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingTinVatNo" runat="server" 
                CssClass="box3" ReadOnly="True"></asp:TextBox></td></tr><tr><td valign="middle">&nbsp;</td><td valign="middle">&nbsp;</td><td valign="middle">&nbsp;</td><td align="right" valign="middle"><asp:Button 
                                        ID="btnShippingNext" runat="server" CssClass="redbox" Text="Next  " 
                                        onclick="btnShippingNext_Click" />&nbsp;<asp:Button ID="btnShippingCancel" 
                                        runat="server" CssClass="redbox" Text="Cancel" 
                                        onclick="btnShippingCancel_Click" /></td></tr></table></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    
                    
                    <HeaderTemplate>Products</HeaderTemplate><ContentTemplate>                                                                     
                                
                        
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td 
                            align="left" valign="middle"><asp:GridView ID="GridView1" runat="server" 
                            AllowPaging="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                            DataKeyNames="Id" DataSourceID="SqlDataSource1" HorizontalAlign="Left" 
                            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" 
                            OnRowDeleted="GridView1_RowDeleted" OnRowEditing="GridView1_RowEditing" 
                            OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating" 
                            Width="60%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Item Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemCode1" runat="server" Text='<%#Eval("ItemCode") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemCode1" runat="server" Text='<%#Eval("ItemCode") %>'>
                                         </asp:TextBox><asp:RequiredFieldValidator ID="ReqItemCode1" runat="server" 
                                            ControlToValidate="txtItemCode1" ErrorMessage="*" ValidationGroup="edit1"> </asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId1" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription1" runat="server" Text='<%#Eval("Description") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescription1" runat="server" 
                                            Text='<%#Eval("Description") %>'>
                                         </asp:TextBox><asp:RequiredFieldValidator ID="ReqDescription1" runat="server" 
                                            ControlToValidate="txtDescription1" ErrorMessage="*" ValidationGroup="edit1"> </asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="50%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty1" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtQty1" runat="server" Text='<%#Eval("Qty") %>'>
                                         </asp:TextBox><asp:RequiredFieldValidator ID="ReqQty1" runat="server" 
                                            ControlToValidate="txtQty1" ErrorMessage="*" ValidationGroup="edit"> </asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table class="fontcss" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                Text="No data to display !"> </asp:Label></td></tr></table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        </td></tr>
                        <tr>
                            <td align="left" height="25" valign="middle">
                                <asp:Button ID="btnProductNext" runat="server" CssClass="redbox" 
                                    OnClick="btnProductNext_Click" Text="Next  " />
                                <asp:Button ID="btnProductCancel" runat="server" CssClass="redbox" 
                                    OnClick="btnProductCancel_Click" Text="Cancel" />
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        DeleteCommand="DELETE FROM [SD_Cust_WorkOrder_Products_Details] WHERE [Id] = @Id" 
                                        InsertCommand="INSERT INTO [SD_Cust_WorkOrder_Products_Details] ([ItemCode], [Description], [Qty]) VALUES (@ItemCode, @Description, @Qty)" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT [ItemCode], [Description], [Qty], [Id] FROM [SD_Cust_WorkOrder_Products_Details] WHERE ([WONo] = @WONo)" 
                                        UpdateCommand="UPDATE [SD_Cust_WorkOrder_Products_Details] SET [ItemCode] = @ItemCode, [Description] = @Description, [Qty] = @Qty WHERE [Id] = @Id"><SelectParameters><asp:QueryStringParameter Name="WONo" QueryStringField="WONo" Type="String" /></SelectParameters><DeleteParameters><asp:Parameter Name="Id" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter Name="ItemCode" Type="String" /><asp:Parameter Name="Description" Type="String" /><asp:Parameter Name="Qty" Type="String" /></InsertParameters><UpdateParameters><asp:Parameter Name="ItemCode" Type="String" /><asp:Parameter Name="Description" Type="String" /><asp:Parameter Name="Qty" Type="String" /><asp:Parameter Name="Id" Type="Int32" /></UpdateParameters></asp:SqlDataSource></ContentTemplate></cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>Instructions</HeaderTemplate>
                          <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="29%" align="left" valign="middle" height="24">Primer Painting to be done.</td><td width="71%" align="left" valign="middle"><asp:CheckBox ID="CKInstractionPrimerPainting" runat="server" /></td></tr><tr><td align="left" valign="middle" height="24">Painting to be done.</td><td align="left" valign="middle"><asp:CheckBox ID="CKInstractionPainting" runat="server" /></td></tr><tr><td align="left" valign="middle" height="24">Self Certification Report to be submitted.</td><td align="left" valign="middle"><asp:CheckBox ID="CKInstractionSelfCertRept" runat="server" /></td></tr><tr><td align="left" valign="top" height="24">others</td><td align="left" valign="middle">
                              <asp:TextBox 
                                  ID="txtInstractionOther" runat="server" ReadOnly="True" CssClass="box3"></asp:TextBox></td></tr><tr><td align="left" valign="middle" height="24">Export Case Mark</td><td align="left" valign="middle">
                                  <asp:TextBox ID="txtInstractionExportCaseMark" runat="server" CssClass="box3" 
                                      ReadOnly="True"></asp:TextBox></td></tr><tr><td colspan="2" align="left" valign="middle" height="24">Attach Annexure</td></tr><tr><td colspan="2" align="left" valign="top" height="110">&nbsp;</td></tr><tr><td colspan="2" align="left" valign="middle">*Packing Instructions&#160;: Export Seaworthy / Wooden / Corrugated 7 day before desp.</td></tr><tr><td align="right" colspan="2" valign="middle"><asp:Button ID="btnDelete" runat="server" OnClientClick="return confirmationDelete()" CssClass="redbox" Text="Delete" onclick="btnDelete_Click"
                                   /><asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                                  OnClick="btnCancel_Click" Text="Cancel" /></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

