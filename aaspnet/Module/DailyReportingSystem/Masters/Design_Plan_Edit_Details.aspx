<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Design_Plan_Edit_Details.aspx.cs" Inherits="Module_DailyReportingSystem_Masters_Design_Plan_Edit_Details" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <table width="100%" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<strong> Customer Master - Edit</strong></td>
                    </tr>

                    <tr height="21">
                        <td  height="25">
                            &nbsp;
                            
                            <asp:Label ID="Label2" runat="server" Text="WoNo"></asp:Label>
                            <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="411px"></asp:TextBox>
                      
                            <cc1:autocompleteextender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:autocompleteextender>
                            
                            <asp:Button ID="Search" runat="server" onclick="Search_Click" Text="Search" 
                                CssClass="redbox" />
                        </td>
                    </tr>

             <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="20" RowStyle-HorizontalAlign ="Center"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" CssClass="yui-datatable-theme" EnableModelValidation="True" DataSourceID="SqlDataSource1">
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="idwono" HeaderText="WoNo" SortExpression="idwono" />
                        <asp:BoundField DataField="idsr" HeaderText="Sr.No." SortExpression="idsr" />
                        <asp:BoundField DataField="idfxn" HeaderText="FIXTURE NO." SortExpression="idfxn" />
                        <asp:BoundField DataField="idconcpd" HeaderText="CONCEPT DESIGN" SortExpression="idconcpd" />
                        <asp:BoundField DataField="idintrnrw" HeaderText="INTERNAL REVIEW" SortExpression="idintrnrw" />
                        <asp:BoundField DataField="iddaps" HeaderText="DAP SEND" SortExpression="iddaps" />
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
                     
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [idwono], [idsr], [idfxn], [idconcpd], [idintrnrw], [iddaps] FROM [DRTS_Desing_Plan_New]"></asp:SqlDataSource>
                     
                <br />
               <center> <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="#FF3300" /></center>
                <br />
                     
            </td>
             </tr>
              </table>
            </td>
        </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

