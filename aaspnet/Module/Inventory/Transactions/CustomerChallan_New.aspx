<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_CustomerChallan_New, newerp_deploy" title="ERP" theme="Default" %>

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
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>Customer Challan - New</b></td>
        </tr>
           

                    <tr >
                        <td  >
                     <table  width="100%">
                     
                     <tr><td>
                     
                     
                            
                            <asp:Label ID="Label2" runat="server" Text="CustomerName"></asp:Label>
                            <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3" Width="350px"></asp:TextBox>
                      
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

             <tr >
            <td  width="45%" align="left" valign="top" >
                   
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" PageSize="20"
                    DataKeyNames="CustomerId" RowStyle-HorizontalAlign ="Center" Width="100%"
                    onpageindexchanging="SearchGridView1_PageIndexChanging"   
                    ShowFooter="false" CssClass="yui-datatable-theme" 
                    onrowcommand="SearchGridView1_RowCommand">
                    <PagerSettings PageButtonCount="40" />
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle HorizontalAlign="Right"  Width="6%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs" >
                         <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                        
                        <asp:TemplateField  HeaderText="Customer Name">
                        <ItemTemplate>
                             <asp:LinkButton ID="BtnSel" runat="server"  CommandName="Sel"  Text='<%#Eval("CustomerName")%>' ></asp:LinkButton>
                         </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>
                  
                        <asp:TemplateField  HeaderText="Code">
                        <ItemTemplate>
                          
           <asp:Label ID="lblCustomerId"  runat="server" Text='<%#Eval("CustomerId")%>'></asp:Label>
           
                         </ItemTemplate>
              <ItemStyle HorizontalAlign="Center"  />
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
                </asp:GridView>
                     
            </td>
            
             <td align="Center" valign="top">

         <div id="Up" runat="server"  >
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="Id" RowStyle-HorizontalAlign ="Center"       Width="95%"             
                    onpageindexchanging="GridView1_PageIndexChanging"  
                    PageSize="20" >            
           
                  <PagerSettings PageButtonCount="40" />
           
<RowStyle HorizontalAlign="Center"></RowStyle>
           
            <Columns>
                <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                                
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle Width="10%" />
                </asp:BoundField>
                                  <asp:BoundField HeaderText="Project Name" 
                    DataField="TaskProjectTitle" >
                                      <ItemStyle HorizontalAlign="Left" Width="45%" />
                                </asp:BoundField>
                                  
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" >                                    
                                   <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:BoundField>
                                  
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" >
                                      <ItemStyle HorizontalAlign="Left" Width="10%" />
                </asp:BoundField>
                                   <asp:BoundField DataField="POId" HeaderText="POId" Visible="false" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                                  <asp:HyperLinkField DataNavigateUrlFields="EnqId,PONo,POId,WONo" 
                    HeaderText="WO No" 
                    DataNavigateUrlFormatString="~/Module/Inventory/Transactions/CustomerChallan_New_Details.aspx?EnqId={0}&amp;PONo={1}&amp;POId={2}&amp;WONo={3}&ModId=9&SubModId=121"  
                    DataTextField="WONo" 
                    />
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date"  Visible="false"/>
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" Visible="false">
                            
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
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
         
         </div>
         </td>
            
            
             </tr>
            
                     </table>
              </td></tr>
            
            
             
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

