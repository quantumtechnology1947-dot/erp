<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillBooking_Edit_Details.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_Edit_Details" Title="ERP"Theme="Default" %>
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
        .style20
        {
            height: 220px;
        }
        .style27
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
            height: 20px;
        }
        .style28
        {
            height: 28px;
        }
        .style29
        {
            font-weight: bold;
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
            <td align="left" valign="middle"  scope="col" class="style27" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Bill Booking - Edit&nbsp;</b></td>
        </tr>
        <tr >
            <td valign="top" class="style20">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" Height="410px">
<cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"><HeaderTemplate>PV/EV Booking Details
                    </HeaderTemplate>


<ContentTemplate><table width="900" class="fontcss"><tr ><td style="border: 1px solid #808080;" 
        class="style28" ><table width="100%"><tr><td class="style23"><b>PVEV No.</b> <asp:Label ID="lblPVEVNo" runat="server"></asp:Label></td><td class="style24"><b>PO No.</b> <asp:Label ID="lblPoNo" runat="server"></asp:Label></td><td class="style29">Bill No.</td><td><asp:TextBox ID="textBillno" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqBillno" runat="server" ControlToValidate="textBillno" 
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td class="style29">Supplier</td><td class="style24" rowspan="2" valign="top"><asp:Label ID="lblSupplierName" runat="server"></asp:Label></td><td class="style29">Bill Date</td><td><asp:TextBox ID="textBillDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="textBillDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd-MM-yyyy" TargetControlID="textBillDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="textBillDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegEditBillDate" runat="server" 
                ControlToValidate="textBillDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style23">&#160;</td><td class="style29">CenVat Entry No.</td><td><asp:TextBox ID="textCVEntryNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="textCVEntryNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td class="style29">Supplier Address</td><td class="style24" rowspan="3" valign="top"><asp:Label ID="lblSupplierAdd" runat="server"></asp:Label></td><td class="style29">CenVat Entry Date</td><td><asp:TextBox ID="textCVEntryDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="textCVEntryDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd-MM-yyyy" TargetControlID="textCVEntryDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="textCVEntryDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegEntryDtEd" runat="server" 
                ControlToValidate="textCVEntryDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style23">&#160;</td><td class="style29">WO No/ Dept. Code</td><td><asp:Label ID="lblWoDeptNo" runat="server"></asp:Label></td></tr><tr><td class="style23">&#160;</td><td class="style25">&#160;</td><td>&#160;</td></tr></table></td></tr><tr><td style="border: 1px solid #808080;" class="style28"><table width="100%"><tr><td>Supplier Details</td><td>ECC No.</td><td><asp:Label ID="lblECCno" runat="server"></asp:Label></td><td>Range</td><td><asp:Label ID="lblRange" runat="server"></asp:Label></td><td><span ID="ctl00_ContentPlaceHolder3_TabContainer1_TabPanel1_lblRange"></span>Service Tax No.</td><td><asp:Label ID="lblServiceTax" runat="server"></asp:Label></td></tr><tr><td>&#160;</td><td>Division</td><td><asp:Label ID="lblDivision" runat="server"></asp:Label></td><td>Commissionerate</td><td><asp:Label ID="lblComm" runat="server"></asp:Label></td><td><span ID="ctl00_ContentPlaceHolder3_TabContainer1_TabPanel1_lblComm"></span>TDS</td><td><asp:Label ID="lblTDS" runat="server"></asp:Label></td></tr><tr><td>&#160;</td><td>Vat No.</td><td><asp:Label ID="lblVatNo" runat="server"></asp:Label></td><td>CST No.</td><td><asp:Label ID="lblCSTNo" runat="server"></asp:Label></td><td>Pan No.</td><td><asp:Label ID="lblPanNo" runat="server"></asp:Label></td></tr><tr><td>&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr></table></td></tr><tr><td style="border: 1px solid #808080;" class="style28"><table cellpadding="0" cellspacing="0" width="100%"><tr><td align="left" class="style3"><b>&nbsp;Attachment : </b><asp:FileUpload ID="FileUpload1" runat="server" /><asp:RequiredFieldValidator ID="ReqFileUpload" runat="server" 
                                ControlToValidate="FileUpload1" ErrorMessage="*" ValidationGroup="C"></asp:RequiredFieldValidator><asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                OnClick="Button1_Click" OnClientClick="return confirmationUpload()" 
                                Text="Upload" ValidationGroup="C" /></td></tr><tr><td align="left"><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblACC_BillBooking_Attach_Master] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [tblACC_BillBooking_Attach_Master] ([FileName], [FileSize], [ContentType], [FileData]) VALUES (@FileName, @FileSize, @ContentType, @FileData)" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [FileName], [FileSize], [ContentType], [FileData], [Id] FROM [tblACC_BillBooking_Attach_Master] WHERE (([CompId] = @CompId) AND ([FinYearId] = @FinYearId) AND ([MId] = @Id))" 
                                UpdateCommand="UPDATE [tblACC_BillBooking_Attach_Master] SET [FileName] = @FileName, [FileSize] = @FileSize, [ContentType] = @ContentType, [FileData] = @FileData WHERE [Id] = @Id"><DeleteParameters><asp:Parameter Name="Id" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter Name="FileName" Type="String" /><asp:Parameter Name="FileSize" Type="Double" /><asp:Parameter Name="ContentType" Type="String" /><asp:Parameter Name="FileData" Type="Object" /></InsertParameters><SelectParameters><asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" /><asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" /><asp:SessionParameter Name="SessionId" SessionField="username" Type="String" /><asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int32" /></SelectParameters><UpdateParameters><asp:Parameter Name="FileName" Type="String" /><asp:Parameter Name="FileSize" Type="Double" /><asp:Parameter Name="ContentType" Type="String" /><asp:Parameter Name="FileData" Type="Object" /><asp:Parameter Name="Id" Type="Int32" /></UpdateParameters></asp:SqlDataSource><asp:Panel ID="Panel1" runat="server" Height="180px" 
            ScrollBars="Auto" CssClass="fontcss"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CssClass="yui-datatable-theme" DataKeyNames="Id" DataSourceID="SqlDataSource1" 
                                    EnableTheming="True" OnRowDataBound="GridView2_RowDataBound" Width="500px"><Columns><asp:CommandField HeaderText="Delete" ShowDeleteButton="True" /><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:BoundField DataField="FileName" HeaderText="FileName" 
                                            SortExpression="FileName"><ItemStyle Width="35%" /></asp:BoundField><asp:BoundField DataField="FileSize" HeaderText="FileSize(Byte)" 
                                            SortExpression="FileSize" /><asp:HyperLinkField DataNavigateUrlFields="Id" 
                                            DataNavigateUrlFormatString="~/Controls/DownloadFile.aspx?Id={0}&amp;tbl=tblACC_BillBooking_Attach_Master&amp;qfd=FileData&amp;qfn=FileName&amp;qct=ContentType" 
                                            Text="Download"><ItemStyle HorizontalAlign="Center" /></asp:HyperLinkField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                        Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></asp:Panel></td></tr></table></td></tr></table>

                    </ContentTemplate>


</cc1:TabPanel>

 <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
 <HeaderTemplate>  
  PO Term Details
                    </HeaderTemplate>                        

<ContentTemplate><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" AllowPaging="True" 
                    Width="100%" onpageindexchanging="GridView1_PageIndexChanging" 
                     onrowediting="GridView1_RowEditing" 
                    onrowupdating="GridView1_RowUpdating" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" PageSize="15" ><Columns>
        <asp:TemplateField Visible="False"><ItemTemplate><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"  
                    CommandName="Edit" Text="Edit"></asp:LinkButton></ItemTemplate><EditItemTemplate><asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                    CommandName="Update" ValidationGroup="B" Text="Update" OnClientClick="confirmationUpdate()"> </asp:LinkButton>&#160;&nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" Text="Cancel"> </asp:LinkButton></EditItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="SN"><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>'/></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="GQN No"><ItemTemplate><asp:Label ID="lblGQNNo" runat="Server" Text='<%#Eval("GQNNo")%>'/></ItemTemplate><ItemStyle HorizontalAlign="Center"  Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="GSN No"><ItemTemplate><asp:Label ID="lblGSNNo" runat="Server" Text='<%#Eval("GSNNo")%>'/></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblItemCode" runat="Server" Text='<%#Eval("ItemCode")%>'/></ItemTemplate><ItemStyle HorizontalAlign="Center"  Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Descrption"><ItemTemplate><asp:Label ID="lblDesc" runat="Server" Text='<%#Eval("Descr")%>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="17%"  /></asp:TemplateField><asp:TemplateField HeaderText="UOM" ><ItemTemplate><asp:Label ID="lblUOM" runat="Server" Text='<%#Eval("UOM")%>'/></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Amt" ><ItemTemplate><asp:Label ID="lblAmt" runat="Server" Text='<%#Eval("Amt")%>'/></ItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="PF Amt" ><ItemTemplate><asp:Label ID="lblPFAmt" runat="Server" Text='<%#Eval("PFAmt")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxpf" runat="server"  Text='<%#Eval("PFAmt")%>' Width="90%" > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBoxpf" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxpf"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoxpf" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxpf" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Basic SerTax(%)" ><ItemTemplate><asp:Label ID="lblBasicInPer" runat="Server"   Text='<%#Eval("ExStBasicInPer")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxExStBasicInPer" runat="server"  Width="90%"  Text='<%#Eval("ExStBasicInPer")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBoxExStBasicInPer" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxExStBasicInPer"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoxExStBasicInPer" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxExStBasicInPer" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Edu Cess(%)" ><ItemTemplate><asp:Label ID="lblEducessInPer" runat="Server" 
                                    Text='<%#Eval("ExStEducessInPer")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxExStEducessInPer" runat="server"  Width="90%" Text='<%#Eval("ExStEducessInPer")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBoxExStEducessInPer" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxExStEducessInPer"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoxExStEducessInPer" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxExStEducessInPer" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="She Cess(%)" ><ItemTemplate><asp:Label ID="lblShecessInPer" runat="Server" 
                                    Text='<%#Eval("ExStShecessInPer")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxExStShecessInPer" runat="server"  Width="90%" Text='<%#Eval("ExStShecessInPer")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBoxExStShecessInPer" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxExStShecessInPer"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoxExStShecessInPer" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxExStShecessInPer" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Ex/Ser tax" ><ItemTemplate><asp:Label ID="lblExStBasic" runat="Server" Text='<%#Eval("ExStBasic")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxExStBasic" runat="server"  Width="90%" Text='<%#Eval("ExStBasic")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBoxExStBasic" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxExStBasic"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoxExStBasic" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxExStBasic" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Edu Cess" ><ItemTemplate><asp:Label ID="lblExStEducess" runat="Server" Text='<%#Eval("ExStEducess")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxExStEducess" runat="server"  Width="90%" Text='<%#Eval("ExStEducess")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqExStEducess" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxExStEducess"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExStEducess" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxExStEducess" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="She Cess" ><ItemTemplate><asp:Label ID="lblExStShecess" runat="Server" Text='<%#Eval("ExStShecess")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxExStShecess" runat="server"  Width="90%" Text='<%#Eval("ExStShecess")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqExStShecess" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxExStShecess"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegExStShecess" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxExStShecess" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Custom Duty" ><ItemTemplate><asp:Label ID="lblCustomDuty" runat="Server" Text='<%#Eval("CustomDuty")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxCustomDuty" runat="server"  Width="90%" Text='<%#Eval("CustomDuty")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqCustomDuty" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxCustomDuty"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegCustomDuty" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxCustomDuty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="VAT" ><ItemTemplate><asp:Label ID="lblVAT" runat="Server" Text='<%#Eval("VAT")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxVAT" runat="server"  Width="90%" Text='<%#Eval("VAT")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqVAT" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxVAT"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegVAT" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxVAT" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="CST" ><ItemTemplate><asp:Label ID="lblCST" runat="Server" Text='<%#Eval("CST")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxCST" runat="server"  Width="90%" Text='<%#Eval("CST")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqCST" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxCST"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegCST" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxCST" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Freight" ><ItemTemplate><asp:Label ID="lblFreight" runat="Server"  Text='<%#Eval("Freight")%>'/></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxFreight" runat="server"  Width="90%"  Text='<%#Eval("Freight")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqBoxFreight" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxFreight"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoxFreight" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxFreight" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Tarrif No"><ItemTemplate><asp:Label ID="lblTarrifNo" runat="Server" Text='<%#Eval("TarrifNo")%>' /></ItemTemplate><EditItemTemplate><asp:TextBox ID="TextBoxTarrifNo" runat="server"  Width="90%" Text='<%#Eval("TarrifNo")%>' > </asp:TextBox><asp:RequiredFieldValidator ID="ReqTarrifNo" runat="server" ErrorMessage="*" 
                                ValidationGroup="B" ControlToValidate="TextBoxTarrifNo"> </asp:RequiredFieldValidator><%--<asp:RegularExpressionValidator ID="RegTarrifNo" runat="server" ErrorMessage="*" 
                                ControlToValidate="TextBoxTarrifNo" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"> </asp:RegularExpressionValidator>--%></EditItemTemplate><ItemStyle HorizontalAlign="Right"  Width="6%" /></asp:TemplateField></Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><FooterStyle Wrap="True"></FooterStyle></asp:GridView>

                    

                    
                    </ContentTemplate>  

                  

</cc1:TabPanel>

 <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Terms & Conditions">                    
     <HeaderTemplate>Terms &amp; Conditions
                    </HeaderTemplate>
     
<ContentTemplate><table width="600" class="fontcss"><tr><td class="style23">Other Charges</td><td 
        class="style25"><asp:TextBox ID="txtOtherCharges" runat="server" 
        CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
        ID="ReqOtherCharges" runat="server" ControlToValidate="txtOtherCharges" 
        ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
        ID="RegOtherCharges" runat="server" ControlToValidate="txtOtherCharges" 
        ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td 
            class="style28">Other Cha. Desc.</td><td class="style28"><asp:TextBox 
                ID="txtOtherChaDesc" runat="server" CssClass="box3" Height="20px" Width="200px"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator6" runat="server" 
                 ControlToValidate="txtOtherChaDesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td 
            class="style23">Debit Amt</td><td class="style25"><asp:TextBox ID="txtDebitAmt" 
                runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="ReqDebitAmt" runat="server" 
                ControlToValidate="txtDebitAmt" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                ID="RegDebitAmt" runat="server" ControlToValidate="txtDebitAmt" 
                ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style23">Discount</td><td class="style25"><asp:TextBox 
            ID="txtDiscount" runat="server" CssClass="box3" Height="19px" Width="71px"></asp:TextBox><asp:RequiredFieldValidator 
            ID="ReqDiscount" runat="server" 
                 ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator 
            ID="RegDiscount" runat="server" 
                 ControlToValidate="txtDiscount" ErrorMessage="*" 
                 ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator><asp:DropDownList 
            ID="DrpAdd" runat="server" AutoPostBack="True" CssClass="box3"><asp:ListItem 
                Text="Amt(Rs)" Value="0"></asp:ListItem><asp:ListItem Text="Per(%)" 
                Value="1"></asp:ListItem>
        </asp:DropDownList></td></tr><tr><td class="style23" valign="top">Narration</td><td class="style25"><asp:TextBox 
            ID="txtNarration" runat="server" CssClass="box3" Height="100px" 
                     Width="97%" TextMode="MultiLine"></asp:TextBox></td></tr></table>
         
                    
         
                    
                    </ContentTemplate></cc1:TabPanel>


 </cc1:TabContainer>
            </td>
        </tr>
       
        <tr >
            <td valign="middle" align="center" height="24">
                <asp:Button runat="server" OnClientClick="confirmationUpdate()" Text="Update" ValidationGroup="A" CssClass="redbox" ID="btnProceed" OnClick="btnProceed_Click">
                </asp:Button>
                <asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="btnCancel" OnClick="btnCancel_Click">
                </asp:Button>
            </td>
        </tr>
       
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

