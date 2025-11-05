<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillBooking_New_Details.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_New_Details" Title="ERP"  Theme="Default" %>
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
        </style>

    <script src="../../../Javascript/SelectionRadioButton.js" type="text/javascript"></script>
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
        <table align="center" cellpadding="0" cellspacing="0" width="100%" class="fontcss">
        <tr>
            <td align="left" valign="middle"  scope="col" class="style27" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Bill Booking - New&nbsp;</b></td>
        </tr>
        <tr >
<td valign="top" class="style20">


 <%--<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" AutoPostBack="True" Width="100%"  Height="430px">
 <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
<HeaderTemplate>Booking Details</HeaderTemplate>
<ContentTemplate></ContentTemplate>
</cc1:TabPanel>
<cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2"><HeaderTemplate>PO Term Details</HeaderTemplate>
<ContentTemplate></ContentTemplate>                    
</cc1:TabPanel>
<cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Selected Items">                    
     <HeaderTemplate>Selected Items</HeaderTemplate>
     <ContentTemplate></ContentTemplate>
    </cc1:TabPanel>
<cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Terms & Conditions">                    
     <HeaderTemplate>Terms &amp; Conditions
      </HeaderTemplate>
     <ContentTemplate>
                    </ContentTemplate>
      </cc1:TabPanel>

</cc1:TabContainer>--%>

    <cc1:TabContainer ID="TabContainer1" runat="server" Width="100%"  
        Height="430px" ActiveTabIndex="2" AutoPostBack="True" 
        onactivetabchanged="TabContainer1_ActiveTabChanged">
    <cc1:TabPanel runat="server" ID="TabPanel1">
            <HeaderTemplate>Booking Details</HeaderTemplate>
            <ContentTemplate><table width="950" class="fontcss"><tr ><td style="border: 1px solid #808080;" ><table width="100%"><tr><td width="60%" rowspan="4" valign="top"><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td height="26" width="90">Supplier </td><td><asp:Label ID="lblSupplierName" runat="server"></asp:Label></td></tr><tr><td valign="top">Address </td><td><asp:Label ID="lblSupplierAdd" runat="server"></asp:Label></td></tr></table></td><td width="15%">Bill No.</td><td><asp:TextBox ID="textBillno" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBillno" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td class="style34">Bill Date</td><td><asp:TextBox ID="textBillDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender 
                    ID="textBillDate_CalendarExtender" runat="server" Enabled="True" 
                    Format="dd-MM-yyyy" TargetControlID="textBillDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBillDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBillDate" runat="server" 
                ControlToValidate="textBillDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style34">HSN Code </td><td><asp:TextBox ID="textCVEntryNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="textCVEntryNo" ErrorMessage="*" alidationGroup="A" 
        ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td class="style34">CenVat Entry Date </td><td><asp:TextBox ID="textCVEntryDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender 
                        ID="textCVEntryDate_CalendarExtender" runat="server" Enabled="True" 
                        Format="dd-MM-yyyy" TargetControlID="textCVEntryDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="textCVEntryDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegCenVatEntryDt" runat="server" ControlToValidate="textCVEntryDate" ErrorMessage="*" ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" ValidationGroup="A"></asp:RegularExpressionValidator></td></tr></table></td></tr><tr><td style="border: 1px solid #808080;" class="style28"><table width="100%"><tr><td width="120">Supplier Details </td><td width="60">ECC No. </td><td width="160">: <asp:Label ID="lblECCno" runat="server"></asp:Label></td><td width="120">Range </td><td width="170">: <asp:Label ID="lblRange" runat="server"></asp:Label></td><td width="120"><span ID="ctl00_ContentPlaceHolder3_TabContainer1_TabPanel1_lblRange"></span>Service Tax No. </td><td>: <asp:Label ID="lblServiceTax" runat="server"></asp:Label></td></tr><tr><td>&#160; </td><td>Division </td><td>: <asp:Label ID="lblDivision" runat="server"></asp:Label></td><td>Commissionerate </td><td>: <asp:Label ID="lblComm" runat="server"></asp:Label></td><td><span ID="ctl00_ContentPlaceHolder3_TabContainer1_TabPanel1_lblComm"></span>TDS </td><td>: <asp:Label ID="lblTDS" runat="server"></asp:Label></td></tr><tr><td>&#160; </td><td>VAT No. </td><td>: <asp:Label ID="lblVatNo" runat="server"></asp:Label></td><td>CST No. </td><td>: <asp:Label ID="lblCSTNo" runat="server"></asp:Label></td><td>PAN No. </td><td>: <asp:Label ID="lblPanNo" runat="server"></asp:Label></td></tr></table></td></tr><tr><td style="border: 1px solid #808080;" class="style28"><table cellpadding="0" cellspacing="0" width="600"><tr><td align="left" class="style3" width="17"><b>&nbsp;Attachment:</b> </td><td align="left" class="style33"><asp:FileUpload ID="FileUpload1" runat="server" /><asp:RequiredFieldValidator ID="ReqFileUpload" runat="server" 
                                ControlToValidate="FileUpload1" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                OnClick="Button1_Click" OnClientClick="return confirmationUpload()" 
                                Text="Upload" ValidationGroup="B" />&#160; <asp:Button ID="BtnNext1" runat="server" CssClass="redbox" 
                                onclick="BtnNext1_Click" Text="Next" />&nbsp; <asp:Button ID="btnCancel1" runat="server" CssClass="redbox" 
                                OnClick="btnCancel_Click" Text="Cancel" /></td></tr><tr><td colspan="2" align="left"><asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblACC_BillBooking_Attach_Temp] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [tblACC_BillBooking_Attach_Temp] ([FileName], [FileSize], [ContentType], [FileData]) VALUES (@FileName, @FileSize, @ContentType, @FileData)" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [FileName], [FileSize], [ContentType], [FileData], [Id] FROM [tblACC_BillBooking_Attach_Temp] WHERE (([CompId] = @CompId) AND ([FinYearId] = @FinYearId) AND ([SessionId] = @SessionId))" 
                                UpdateCommand="UPDATE [tblACC_BillBooking_Attach_Temp] SET [FileName] = @FileName, [FileSize] = @FileSize, [ContentType] = @ContentType, [FileData] = @FileData WHERE [Id] = @Id"><DeleteParameters><asp:Parameter Name="Id" Type="Int32" /></DeleteParameters><InsertParameters><asp:Parameter Name="FileName" Type="String" /><asp:Parameter Name="FileSize" Type="Double" /><asp:Parameter Name="ContentType" Type="String" /><asp:Parameter Name="FileData" Type="Object" /></InsertParameters><SelectParameters><asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" /><asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" /><asp:SessionParameter Name="SessionId" SessionField="username" Type="String" /></SelectParameters><UpdateParameters><asp:Parameter Name="FileName" Type="String" /><asp:Parameter Name="FileSize" Type="Double" /><asp:Parameter Name="ContentType" Type="String" /><asp:Parameter Name="FileData" Type="Object" /><asp:Parameter Name="Id" Type="Int32" /></UpdateParameters></asp:SqlDataSource><asp:Panel ID="Panel3" runat="server" Height="250px" ScrollBars="Auto" 
                        Width="600px"><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                    DataSourceID="SqlDataSource1" EnableTheming="True" 
                                    OnRowDataBound="GridView1_RowDataBound" Width="550px"><Columns><asp:CommandField HeaderText="Delete" ShowDeleteButton="True" /><asp:TemplateField HeaderText="SN"><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:BoundField DataField="FileName" HeaderText="FileName" 
                                            SortExpression="FileName"><ItemStyle Width="35%" /></asp:BoundField><asp:BoundField DataField="FileSize" HeaderText="FileSize(Byte)" 
                                            SortExpression="FileSize" /><asp:HyperLinkField DataNavigateUrlFields="Id" 
                                            DataNavigateUrlFormatString="~/Controls/DownloadFile.aspx?Id={0}&amp;tbl=tblACC_BillBooking_Attach_Temp&amp;qfd=FileData&amp;qfn=FileName&amp;qct=ContentType" 
                                            Text="Download"><ItemStyle HorizontalAlign="Center" /></asp:HyperLinkField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                        Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></asp:Panel></td></tr></table></td></tr></table>
            </ContentTemplate>
     </cc1:TabPanel>
     <cc1:TabPanel runat="server" ID="TabPanel2">
        <HeaderTemplate>PO Items</HeaderTemplate>
        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td><iframe id="Iframe1"  runat ="server" width="100%" height="410px" frameborder="0" ></iframe></td></tr><tr ><td align="right"><asp:Button ID="BtnNext2" runat="server" CssClass="redbox" 
OnClick="BtnNext2_Click1" Text="Next" />&nbsp;<asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="btnCancel0" 
 OnClick="btnCancel_Click"></asp:Button></td></tr></table>
        </ContentTemplate>                    
     </cc1:TabPanel>
     <cc1:TabPanel ID="TabPanel3" runat="server">
     <HeaderTemplate>Selected Items</HeaderTemplate>
        <ContentTemplate><table width="100%"><tr><td>
                                        
                                        
                                        <asp:GridView ID="GridView3" 
                runat="server" AutoGenerateColumns="False"  ShowFooter="True"
             CssClass="yui-datatable-theme" DataKeyNames="Id" 
             OnPageIndexChanging="GridView3_PageIndexChanging" 
             OnRowCommand="GridView3_RowCommand" PageSize="15" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="lnkButton" runat="server" CommandName="del" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="PO No"><ItemTemplate><asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label ID="lblDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="GQN No"><ItemTemplate><asp:Label ID="lblgqnno" runat="server" Text='<%# Eval("GQNNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="GSN No"><ItemTemplate><asp:Label ID="lblgsnno" runat="server" Text='<%# Eval("GSNNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="DC No"><ItemTemplate><asp:Label ID="lbldcno" runat="server" Text='<%# Eval("DCNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblPurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMPurch" runat="server" Text='<%# Eval("UOMPurch") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="Qty"><ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="GQN Amt" Visible="False"><ItemTemplate><asp:Label ID="lblgqnamt" runat="server" Text='<%# Eval("GQNAmt") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="GSN Amt" Visible="False"><ItemTemplate><asp:Label ID="lblgsnamt" runat="server" Text='<%# Eval("GSNAmt") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Debit Type" Visible="False"><ItemTemplate><asp:Label ID="lbldebittype" runat="server" Text='<%# Eval("DebitType") %>'></asp:Label></ItemTemplate><ItemStyle Width="4%" HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Debit Value" Visible="False"><ItemTemplate><asp:Label ID="lbldebitvalue" runat="server" Text='<%# Eval("DebitValue") %>'></asp:Label></ItemTemplate><ItemStyle Width="5%" HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Basic Amt"><ItemTemplate><asp:Label ID="lbldebitamt" runat="server" Text='<%# Eval("DebitAmt") %>'></asp:Label></ItemTemplate><ItemStyle Width="7%" HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="P&amp;F"><ItemTemplate><asp:Label ID="lblpfAmt" runat="server" Text='<%# Eval("PFAmt") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField  HeaderText="GST"><ItemTemplate ><asp:Label ID="lblExStbasic" runat="server" Text='<%# Eval("ExStBasic") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="6%" /></asp:TemplateField><asp:TemplateField HeaderText="EDU" visible="false"><ItemTemplate><asp:Label ID="lblExSteducess" runat="server" Text='<%# Eval("ExStEducess") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="SHE" visible="false"><ItemTemplate><asp:Label ID="lblExstshecess" runat="server" Text='<%# Eval("ExStShecess") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="VAT" visible="false"><ItemTemplate><asp:Label ID="lblvat" runat="server" Text='<%# Eval("VAT") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="CST" visible="false"><ItemTemplate><asp:Label ID="lblcst" runat="server" Text='<%# Eval("CST") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Freight" visible="false"><ItemTemplate><asp:Label ID="lblfrieght" runat="server" Text='<%# Eval("Freight") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" /></asp:TemplateField><asp:TemplateField 
                        HeaderText="Tariff No"  Visible="False"><ItemTemplate><asp:Label ID="lbltariffNo" runat="server" Text='<%# Eval("TarrifNo") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Total Amt"><FooterTemplate><asp:Label ID="lblrtotal" runat="server" ></asp:Label></FooterTemplate><ItemTemplate><asp:Label ID="lbltotamt" runat="server" Text='<%# Eval("TotalAmt") %>'></asp:Label></ItemTemplate><FooterStyle 
                        HorizontalAlign="Right"  Font-Bold="True"/><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                 Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>
                                 
      
      </td></tr><tr><td align="right"><asp:Button ID="BtnNext3" runat="server" CssClass="redbox" 
             OnClick="BtnNext3_Click" Text="Next" />&nbsp;<asp:Button ID="btnCancel2" 
                 runat="server" CssClass="redbox" OnClick="btnCancel_Click" Text="Cancel" /></td></tr></table>
        </ContentTemplate>
     </cc1:TabPanel>   
     <cc1:TabPanel ID="TabPanel4" runat="server">
        <HeaderTemplate>Terms &amp; Conditions</HeaderTemplate>
        <ContentTemplate><table width="900" class="fontcss"><tr><td class="style32" 
                colspan="2"><asp:Panel ID="Panel4" runat="server" Height="200px" ScrollBars="Auto"
                Width="100%"><asp:GridView CssClass="yui-datatable-theme" ID="GridView4" 
                    runat="server" AutoGenerateColumns="False" 
                    Width="100%" onrowcommand="GridView4_RowCommand"><Columns>
                    <asp:TemplateField HeaderText="SN"><ItemTemplate>
                    <%#Container.DataItemIndex+1  %>
                    </ItemTemplate><ItemStyle 
                            HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField>
                            <ItemTemplate><asp:RadioButton ID="RadioButton1" oncheckedchanged="RadioButton1_CheckedChanged" runat="server" AutoPostBack="False" OnClick="javascript:SelectSingleRadiobutton(this.id)"/></ItemTemplate>
                            <HeaderTemplate>
                            <asp:RadioButton ID="RadioButton2" Checked="true" runat="server" AutoPostBack="False" OnClick="javascript:SelectSingleRadiobutton(this.id)"/>
                            </HeaderTemplate>
                            <ItemStyle 
                            HorizontalAlign="Center" Width="1%" /></asp:TemplateField><asp:TemplateField HeaderText="Section No"><ItemTemplate><asp:Label runat="server" ID="SectionNo" Text='<%# Eval("SectionNo") %>'> </asp:Label></ItemTemplate><ItemStyle 
                            HorizontalAlign="Center" Width="9%" /></asp:TemplateField><asp:TemplateField HeaderText="Nature Of Payment"><ItemTemplate><asp:Label runat="server" ID="NatureOfPayment" Text='<%# Eval("NatureOfPayment") %>'> </asp:Label></ItemTemplate><ItemStyle 
                            HorizontalAlign="Left" Width="40%" /></asp:TemplateField><asp:TemplateField HeaderText="Payment Range"><ItemTemplate><asp:Label runat="server" ID="PaymentRange" Text='<%# Eval("PaymentRange") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Individual /HUF(%)"><ItemTemplate><asp:Label runat="server" ID="IndividualHUF" Text='<%# Eval("IndividualHUF") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Others (%)"><ItemTemplate><asp:Label runat="server" ID="Others" Text='<%# Eval("Others") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                        <asp:TemplateField HeaderText="Without PAN (%)">
                        <ItemTemplate><asp:Label runat="server" ID="WithoutPAN" Text='<%# Eval("WithOutPAN") %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TDS Amt" Visible="False"><ItemTemplate><asp:Label runat="server" ID="TDSAmt" Text='<%# Eval("TDSAmt") %>'></asp:Label></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="15%" /></asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label runat="server" ID="Id" Text='<%# Eval("Id") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField> </Columns></asp:GridView></asp:Panel></td></tr><tr><td class="style32">Other Charges</td><td class="style31"><asp:TextBox ID="txtOtherCharges" runat="server" CssClass="box3"> 0 </asp:TextBox><asp:RequiredFieldValidator ID="ReqOtherCharges" runat="server" 
ControlToValidate="txtOtherCharges" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegOtherCharges" runat="server" 
                    ControlToValidate="txtOtherCharges" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style32">Other Cha. Desc.</td><td class="style31"><asp:TextBox ID="txtOtherChaDesc" runat="server" CssClass="box3" Height="20px" 
                    Width="200px"> - </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtOtherChaDesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td class="style32">Debit Amt</td><td class="style31"><asp:TextBox ID="txtDebitAmt" runat="server" 
                        CssClass="box3"> 0 </asp:TextBox><asp:RequiredFieldValidator ID="ReqDebitAmt" runat="server" 
                                ControlToValidate="txtDebitAmt" ErrorMessage="*" 
                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDebitAmt" runat="server" 
                                ControlToValidate="txtDebitAmt" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td class="style32">Discount </td><td class="style31"><asp:TextBox ID="txtDiscount" runat="server" CssClass="box3" Height="19px" 
                    Width="71px"> 0 </asp:TextBox><asp:RequiredFieldValidator ID="ReqDiscount" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegDiscount" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator><asp:DropDownList ID="DrpAdd" runat="server" AutoPostBack="True" 
                    CssClass="box3"><asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem><asp:ListItem Text="Per(%)" Value="1"></asp:ListItem></asp:DropDownList>
               
                </td></tr><tr><td valign="top">Narration </td><td class="style31"><asp:TextBox ID="txtNarration" runat="server" CssClass="box3" Height="100px" 
                        TextMode="MultiLine" Width="97%"> - </asp:TextBox></td></tr><tr><td align="center" class="style32" colspan="2">&nbsp; </td></tr><tr><td align="center" class="style32" colspan="2"><asp:Button ID="btnProceed" runat="server" CssClass="redbox" 
                        OnClick="btnProceed_Click" OnClientClick=" return confirmationAdd()" 
                        Text="Submit" ValidationGroup="A" />&#160;&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
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