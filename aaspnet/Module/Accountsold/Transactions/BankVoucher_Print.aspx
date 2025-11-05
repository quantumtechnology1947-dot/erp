<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BankVoucher_Print.aspx.cs" Inherits="Module_Accounts_Transactions_BankVoucher_Print" Title="ERP" Theme="Default" %>

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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Bank Voucher</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" onactivetabchanged="TabContainer1_ActiveTabChanged" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">  
                    
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" >
                    
                      
                    <table Width="100%" >
                    <tr>
                    <td height="29" valign="middle">
                        <asp:Label ID="lblPaidToSearch" runat="server" Text="Paid To "></asp:Label>
                 <asp:TextBox ID="txtPaidto" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />
                           
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtPaidto" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                    </td>
                    </tr>
                    
                    <tr>
                    <td>
                    
                     <asp:GridView ID="GridView3"  
                runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" CssClass="yui-datatable-theme" Width="100%" 
                    AllowPaging="True"                              
                            onpageindexchanging="GridView3_PageIndexChanging" 
                            onrowcommand="GridView3_RowCommand" PageSize="20">
                         <PagerSettings PageButtonCount="40" />
                         <Columns>
                                   
                                   <asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate> <%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="3%" /></asp:TemplateField> 
                                   
                                   <asp:TemplateField HeaderText="BVP No">
                                   <ItemTemplate>
                                   
                                 <%--  <asp:Label ID="lblBvbNo" runat="server" Text='<%#Eval("BVPNo") %>'> </asp:Label>--%>
                                       <asp:LinkButton ID="LinkButton1" CommandName="Sel" Text='<%#Eval("BVPNo") %>'  runat="server"></asp:LinkButton>
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
                      <ItemStyle HorizontalAlign="Left" Width="5%" />
                      </asp:TemplateField>
                      
                       <asp:TemplateField HeaderText="Date">
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
                      
                      
                       <asp:TemplateField HeaderText="Pay Amt">
                      <ItemTemplate>
                       <asp:Label ID="lblPayAmt" runat="server" Text='<%#Eval("PayAmt") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Right" Width="5%" />
                      </asp:TemplateField>
                      
                       <asp:TemplateField HeaderText=" Add Amt">
                      <ItemTemplate>
                       <asp:Label ID="lblAddAmt" runat="server" Text='<%#Eval("AddAmt") %>'> </asp:Label>
                             </ItemTemplate>
                      <ItemStyle HorizontalAlign="Right" Width="5%" />
                      </asp:TemplateField>
                      
                      
                      
                         </Columns>
                      <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                         </EmptyDataTemplate>
                        </asp:GridView>
                      
                       </td>
                    </tr>
                    </table>

                    </asp:Panel>
                    </ContentTemplate></cc1:TabPanel>
                    
                           
                  <cc1:TabPanel ID="View" runat="server" HeaderText="Receipt">
                            
                        <ContentTemplate><asp:Panel ID="Panel2" ScrollBars="Auto" runat="server" 
                                Height="425px">
                                
                  <table Width="100%" >
                    <tr>
                    <td height="29" valign="middle">
                        <asp:Label ID="Label3" runat="server" Text="Received From "></asp:Label>
                 <asp:TextBox ID="txtReceivedFrom" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearchReceivedFrom" runat="server" CssClass="redbox" 
                    Text="Search" OnClick="btnSearchReceivedFrom_Click"  />
                           
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="txtReceivedFrom" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender>
                    </td>
                    </tr>
                    
                    <tr>
                    <td>
                    
                                
                            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                               PageSize="15" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Size="10pt" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField  Visible="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Del" 
                                                OnClientClick="confirmationDelete()"> Delete</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdR" runat="server" Text='<%#Eval("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FinYear" HeaderText="Fin Year" 
                                        SortExpression="FinYearId" />
                                    <asp:BoundField DataField="BVRNo" HeaderText="BVRNo" SortExpression="BVRNo">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Types" HeaderText="Receipt Against" 
                                        SortExpression="Types" />
                                    <asp:BoundField DataField="ReceivedFrom" HeaderText="Received From" 
                                        SortExpression="ReceivedFrom" />
                                    <asp:TemplateField HeaderText="Invoice No" SortExpression="InvoiceNo">
                                       
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("InvoiceNo") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:TemplateField>
                                    
                                    
                                    
                                    <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No" 
                                        SortExpression="ChequeNo">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChequeDate" HeaderText="Cheque Date" 
                                        SortExpression="ChequeDate">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChequeReceivedBy" HeaderText="Cheque Recd By" 
                                        SortExpression="ChequeReceivedBy">
                                        <ItemStyle Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BankName" HeaderText="Bank Name" 
                                        SortExpression="BankName" />
                                    <asp:BoundField DataField="BankAccNo" HeaderText="Bank AccNo" 
                                        SortExpression="BankAccNo" />
                                    <asp:BoundField DataField="ChequeClearanceDate" HeaderText="Clearance Date" 
                                        SortExpression="ChequeClearanceDate">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Narration" HeaderText="Narration" 
                                        SortExpression="Narration" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="WONoBG" HeaderText="WONo/BG Group" SortExpression="WONoBG">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table class="fontcss" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label2" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                    Text="No data to display !"> </asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            
                            
                       </td>
                    </tr>
                    </table>
                            </asp:Panel>
                           
                    </ContentTemplate></cc1:TabPanel>
                 </cc1:TabContainer>  
            </td>
        </tr>
        
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

