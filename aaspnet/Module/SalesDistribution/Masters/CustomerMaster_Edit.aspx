<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Masters_CustomerMaster_Edit, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link type="text/css" href="../../../css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
                            
                            <asp:Label ID="Label2" runat="server" Text="CustomerName"></asp:Label>
                            <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="411px"></asp:TextBox>
                      
                            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                            
                            <asp:Button ID="Search" runat="server" onclick="Search_Click" Text="Search" 
                                CssClass="redbox" />
                        </td>
                    </tr>

             <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="20"
                    DataKeyNames="CustomerId" RowStyle-HorizontalAlign ="Center"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%"  
                    ShowFooter="false" CssClass="yui-datatable-theme">
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs" />
                        <asp:HyperLinkField DataNavigateUrlFields="CustomerId" 
                            DataNavigateUrlFormatString="~/Module/SalesDistribution/Masters/CustomerMaster_Edit_Details.aspx?CustomerId={0}&amp;ModId=2&amp;SubModId=7" 
                            DataTextField="CustomerName" HeaderText="Customer Name">
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                            <asp:BoundField DataField="Address" HeaderText="Address" >
                             <ItemStyle HorizontalAlign="Left"  Width="40%"/>
                            </asp:BoundField>
                        <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
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
                     
            </td>
             </tr>
              </table>
            </td>
        </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

