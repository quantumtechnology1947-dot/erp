<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Advice_Print.aspx.cs" Inherits="Module_Accounts_Transactions_Advice_Print" Title="ERP" Theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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

<table  width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Advice </b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">  
                    
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" >
                     <asp:GridView ID="GridView3"  
                runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" CssClass="yui-datatable-theme" Width="100%" 
                    AllowPaging="True"                              
                            onpageindexchanging="GridView3_PageIndexChanging" 
                            onrowcommand="GridView3_RowCommand"><Columns>
                                   
                                   <asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate> <%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="3%" /></asp:TemplateField> 
                                   
                                   <asp:TemplateField HeaderText="AD No">
                                   <ItemTemplate>
                                   
                                 <%--  <asp:Label ID="lblBvbNo" runat="server" Text='<%#Eval("BVPNo") %>'> </asp:Label>--%>
                                       <asp:LinkButton ID="LinkButton1" CommandName="Sel" Text='<%#Eval("ADNo") %>'  runat="server"></asp:LinkButton>
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="4%" />
                                   </asp:TemplateField>
                                   
                                   <asp:TemplateField HeaderText="Advice">
                                   <ItemTemplate>
                                   
                                 <%--  <asp:Label ID="lblBvbNo" runat="server" Text='<%#Eval("BVPNo") %>'> </asp:Label>--%>
                                  <asp:LinkButton ID="LinkButton2" CommandName="Adv" Text="Advice" runat="server"></asp:LinkButton>
                                      
                                   </ItemTemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="4%" />
                                   </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Id" Visible="False"  >
                         <ItemTemplate>
                         <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                             </ItemTemplate>
                         <ItemStyle HorizontalAlign="Left" Width="3%" />
                         </asp:TemplateField>
                      
                      <asp:TemplateField HeaderText="Type">
                      <ItemTemplate>
                       <asp:Label ID="lblType" runat="server" Text='<%#Eval("TypeOfVoucher") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="4%" />
                      </asp:TemplateField>
                      
                      <asp:TemplateField HeaderText="Paid To">
                      <ItemTemplate>
                       <asp:Label ID="lblPaidTo" runat="server" Text='<%#Eval("PaidTo") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" Width="15%" />
                      </asp:TemplateField>
                      
                      <asp:TemplateField HeaderText="Cheque No">
                      <ItemTemplate>
                       <asp:Label ID="lblchqNo" runat="server" Text='<%#Eval("ChequeNo") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="5%" />
                      </asp:TemplateField>
                      
                       <asp:TemplateField HeaderText="Cheque Date">
                      <ItemTemplate>
                       <asp:Label ID="lblChqDt" runat="server" Text='<%#Eval("ChequeDate") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" Width="5%" />
                      </asp:TemplateField>
                      
                       <asp:TemplateField HeaderText="Bank Name">
                      <ItemTemplate>
                       <asp:Label ID="lblBank" runat="server" Text='<%#Eval("Bank") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" Width="15%" />
                      </asp:TemplateField>
                      
                      <asp:TemplateField HeaderText="Amount">
                      <ItemTemplate>
                       <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Right" Width="5%" />
                      </asp:TemplateField>
                      
                         </Columns>
                      <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                         </EmptyDataTemplate>
                        </asp:GridView>
                    </asp:Panel>
                    </ContentTemplate></cc1:TabPanel>
                    
                </cc1:TabContainer>              
                
                
            </td>
        </tr>
        
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

