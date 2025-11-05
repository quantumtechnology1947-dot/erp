<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OldCSBillBooking_Print_Details.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_Print_Details" Title="ERP" Theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css"> 
        .style2
        {
            width: 100%; 
        } 
        .style3        
        {
        	height : 21px;
        }
        .style4
        {
            height: 34px;
        }
        .style5
        {
            width: 500px;
            border-collapse: collapse;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="hfFreight" ContentPlaceHolderID="cp3" Runat="Server">    
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
     <table align="center" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>Bill Booking - Print</b>
            </td>
        </tr>
      <tr>
            <td align="left" align="left" height="420" valign="top">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%">
                <cc1:TabPanel ID="View" runat="server" HeaderText="Preview">
                <ContentTemplate>
                 <asp:Panel ID="Panel1" runat="server" Height="410px" ScrollBars="Auto" 
                    Width="100%">
                    
                    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server"><Report FileName="~/Module/Accounts/Reports/OldCSBillBooking.rpt"></Report></CR:CrystalReportSource>
                    
                    
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" 
                    runat="server" AutoDataBind="True" HasCrystalLogo="False"  
                         ReportSourceID="CrystalReportSource1" DisplayGroupTree="False" 
                         EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" /></asp:Panel>
                </ContentTemplate>
                </cc1:TabPanel>
                    <cc1:TabPanel ID="Annexures" runat="server" HeaderText="Annexures">
                     
                        <HeaderTemplate>
                            Annexures
                        </HeaderTemplate>
                     
                        <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                CssClass="yui-datatable-theme" DataKeyNames="Id" DataSourceID="SqlDataSource1" EnableTheming="True" Width="700px">
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FileName" HeaderText="FileName" 
                                        SortExpression="FileName">
                                        <ItemStyle Width="55%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FileSize" HeaderText="FileSize(Byte)" 
                                        SortExpression="FileSize" />
                                    <asp:HyperLinkField DataNavigateUrlFields="Id" 
                                        DataNavigateUrlFormatString="~/Controls/DownloadFile.aspx?Id={0}&amp;tbl=tblACC_BillBooking_Attach_Master&amp;qfd=FileData&amp;qfn=FileName&amp;qct=ContentType" 
                                        Text="Download">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:HyperLinkField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table class="fontcss" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                    Text="No data to display !"> </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblACC_BillBooking_Attach_Master] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [tblACC_BillBooking_Attach_Master] ([FileName], [FileSize], [ContentType], [FileData]) VALUES (@FileName, @FileSize, @ContentType, @FileData)" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [FileName], [FileSize], [ContentType], [FileData], [Id] FROM [tblACC_BillBooking_Attach_Master] WHERE (([CompId] = @CompId) AND ([FinYearId] = @FinYearId) AND ([MId] = @Id))" 
                                UpdateCommand="UPDATE [tblACC_BillBooking_Attach_Master] SET [FileName] = @FileName, [FileSize] = @FileSize, [ContentType] = @ContentType, [FileData] = @FileData WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="FileName" Type="String" />
                                    <asp:Parameter Name="FileSize" Type="Double" />
                                    <asp:Parameter Name="ContentType" Type="String" />
                                    <asp:Parameter Name="FileData" Type="Object" />
                                </InsertParameters>
                                <SelectParameters>
                                    <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                                    <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                                    <asp:SessionParameter Name="SessionId" SessionField="username" Type="String" />
                                    <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="FileName" Type="String" />
                                    <asp:Parameter Name="FileSize" Type="Double" />
                                    <asp:Parameter Name="ContentType" Type="String" />
                                    <asp:Parameter Name="FileData" Type="Object" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                        </ContentTemplate>
                     
                    </cc1:TabPanel>
                </cc1:TabContainer>
                    </td>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
         <tr>
            <td align="center">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="redbox" onclick="btnCancel_Click" />
                 
               <%-- <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" />--%>                 
            </td>
            
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>