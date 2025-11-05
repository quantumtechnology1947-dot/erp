<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_WorkOrder_Dispatch, newerp_deploy" title="ERP" theme="Default" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>   
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
                   
                        <td height="21px" style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<strong>Work 
                            Order - Dispatch </strong>
                        </td>
                         </tr>  <tr>
            <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">WO  No</asp:ListItem>
                     <asp:ListItem Value="2">WR No</asp:ListItem>
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
                    
                    
                       
        &nbsp;<asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />
                        &nbsp;<asp:Label ID="Label2" runat="server" 
                    style="color: #FF0000; font-weight: 700"></asp:Label>
                        </td>
             </tr>
             <tr>
         <td>
                     
                  <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True"  CssClass="yui-datatable-theme"
                    AllowSorting="True" AutoGenerateColumns="False" 
                    DataKeyNames="WRNo" RowStyle-HorizontalAlign ="Center"
                    
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                      PageSize="20">

                      <PagerSettings PageButtonCount="40" />

<RowStyle HorizontalAlign="Center"></RowStyle>

            <Columns>
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                
                                <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                  <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" > 
                                      <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CustomerId" HeaderText="Code" >
                                    <ItemStyle HorizontalAlign="Center"  Width="8%"/>
                                </asp:BoundField>
                                  <asp:HyperLinkField DataNavigateUrlFields="WONo,WRNo" 
                    HeaderText="WR No" 
                    DataNavigateUrlFormatString="~/Module/SalesDistribution/Transactions/WorkOrder_Dispatch_Details.aspx?WONo={0}&amp;WRNo={1}&amp;ModId=2&amp;SubModId=54" 
                    NavigateUrl="~/Module/SalesDistribution/Transactions/WorkOrder_Dispatch_Details.aspx" 
                                    DataTextField="WRNo" >
                                      <ItemStyle HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                                  <asp:BoundField DataField="WONo" HeaderText="WO No" >
                                      <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" >
                                      <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" >
                            
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

