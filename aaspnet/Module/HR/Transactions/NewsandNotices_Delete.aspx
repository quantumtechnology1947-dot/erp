<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_NewsandNotices_Delete, newerp_deploy" title="ERP" theme="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 75%;
            float: left;
        }
    </style>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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

    <table cellpadding="0" cellspacing="0" width="100%" >
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" align="center" width="80%">
                    <tr>
                        <td  align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="2"><b>&nbsp;News & Notices - Delete</b></td>
                    </tr>
                    <tr>
                        <td align="left">
                <asp:GridView ID="GridView2" runat="server"
                    DataSourceID="SqlDataSource1" CssClass="yui-datatable-theme" 
                    AllowPaging="True" Width="100%" onrowdatabound="GridView2_RowDataBound" 
                                AutoGenerateColumns="False" onrowcommand="GridView2_RowCommand" 
                                PageSize="20" >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                     <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                     
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                     
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" Text="Delete" CommandName="Del" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                     
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                     
                        </asp:TemplateField>
                       
                   
                       
                        <asp:BoundField DataField="FinYear" HeaderText="FinYear" 
                            SortExpression="FinYear">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                        <asp:BoundField DataField="FromDate" HeaderText="FromDate" 
                            SortExpression="FromDate">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ToDate" HeaderText="ToDate" SortExpression="ToDate">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" 
                            Visible="False">
                            
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
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
                     <FooterStyle Wrap="True"></FooterStyle>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
          SelectCommand="SELECT [tblHR_News_Notices].[Id], [tblHR_News_Notices].[Title],[tblFinancial_master].[FinYear], REPLACE(CONVERT (varchar, CONVERT 
(datetime, SUBSTRING([tblHR_News_Notices].[FromDate], CHARINDEX('-', [tblHR_News_Notices].[FromDate]) + 1, 2) + '-' + LEFT ([tblHR_News_Notices].[FromDate],
CHARINDEX('-', [tblHR_News_Notices].[FromDate]) - 1) + '-' + RIGHT ([tblHR_News_Notices].[FromDate],CHARINDEX('-', REVERSE([tblHR_News_Notices].[FromDate])) - 1)), 103), '/', '-') AS FromDate, REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING([tblHR_News_Notices].[ToDate], CHARINDEX('-', [tblHR_News_Notices].[ToDate]) + 1, 2) + '-' + LEFT ([tblHR_News_Notices].[ToDate], CHARINDEX('-', [tblHR_News_Notices].[ToDate]) - 1) + '-' + RIGHT ([tblHR_News_Notices].[ToDate], CHARINDEX('-', REVERSE([tblHR_News_Notices].[ToDate])) - 1)), 103), '/', '-') AS ToDate FROM [tblFinancial_master],[tblHR_News_Notices] where  [tblHR_News_Notices].[FinYearId]=[tblFinancial_master].[FinYearId] And ([tblHR_News_Notices].[CompId] = @CompId) ORDER BY [tblHR_News_Notices].[Id] DESC"
ProviderName="System.Data.SqlClient"                                
                                >
                    <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                    </SelectParameters>                   
                                      
                </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

<%--
SelectCommand="SELECT Id, Title, REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(FromDate, CHARINDEX('-', FromDate) + 1, 2) + '-' + LEFT (FromDate, CHARINDEX('-', FromDate) - 1) + '-' + RIGHT (FromDate, CHARINDEX('-', REVERSE(FromDate)) - 1)), 103), '/', '-') AS FromDate, REPLACE(CONVERT (varchar, CONVERT (datetime, SUBSTRING(ToDate, CHARINDEX('-', ToDate) + 1, 2) + '-' + LEFT (ToDate, CHARINDEX('-', ToDate) - 1) + '-' + RIGHT (ToDate, CHARINDEX('-', REVERSE(ToDate)) - 1)), 103), '/', '-') AS ToDate, FileName FROM tblHR_News_Notices order by Id Desc" --%>