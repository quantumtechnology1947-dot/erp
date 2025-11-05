<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustEnquiry_Edit, newerp_deploy" title="ERP" theme="Default" %>
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
<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp; <strong> Customer Enquiry - Edit</strong></td>
                    </tr>

             <tr>
           <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                </asp:DropDownList>
            
               <asp:TextBox ID="txtEnqId" runat="server"      CssClass="box3"
                    Width="150px"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                      <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                       
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        </td>
             </tr>

             <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" 
                    DataKeyNames="EnqId" RowStyle-HorizontalAlign ="Center" PageSize="20"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" ShowFooter="False"                                  
                    CssClass="yui-datatable-theme">
            
            <RowStyle />
            <Columns>
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                    <ItemStyle Width="8%" />
                </asp:BoundField>
                <asp:HyperLinkField DataTextField="CustomerName" HeaderText="Customer" 
                       
                    
                    DataNavigateUrlFields="CustomerName,CustomerId,EnqId" 
                    DataNavigateUrlFormatString="~/Module/SalesDistribution/Transactions/CustEnquiry_Edit_Details.aspx?CustomerId={1}&amp;EnqId={2}&amp;ModId=2&amp;SubModId=10" >
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="CustomerId" HeaderText="Code" >
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EnqId" HeaderText="Enquiry No.">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="SysDate" HeaderText="Gen. Date">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By">
                    <ItemStyle HorizontalAlign="Left" Width="32%" />
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

