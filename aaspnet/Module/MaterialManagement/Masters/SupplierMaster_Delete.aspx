<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Masters_SupplierMaster_Delete, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            colspan="2"> <strong> &nbsp;Supplier - Delete</strong></td>
                    </tr>

                    <tr >
                        <td   height="26px" valign="middle" width="500px">
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" Text="Supplier Name "></asp:Label>
&nbsp;<asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="368px"></asp:TextBox>
                          
                            <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                            
                            
                            
                            
                            &nbsp;&nbsp;
                        </td>
                        <td  height="25">
                            
                            
                            
                            
                            <asp:Button ID="Search" runat="server" onclick="Search_Click" Text="Search" 
                                CssClass="redbox" />
                        </td>
                    </tr>

             <tr>
            <td colspan="2">
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="17"
                    DataKeyNames="SupplierId" RowStyle-HorizontalAlign ="Center"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    CssClass="yui-datatable-theme">
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs" />
                        <asp:HyperLinkField DataNavigateUrlFields="SupplierId" 
                            DataNavigateUrlFormatString="~/Module/MaterialManagement/Masters/SupplierMaster_Delete_Details.aspx?SupplierId={0}&ModId=6&SubModId=22" 
                            DataTextField="SupplierName" HeaderText="Supplier Name">
                            <ItemStyle HorizontalAlign="Left" Width="35%" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="SupplierId" HeaderText="Code" />
                        <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                        <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
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
                     
            <asp:HiddenField ID="hfSearchText" runat="server" />

    <asp:HiddenField ID="hfSort" runat="server" Value=" " />
   
            </td>
             </tr>
              </table>
            </td>
        </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

