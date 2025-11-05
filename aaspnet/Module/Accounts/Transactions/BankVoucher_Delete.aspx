<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_BankVoucher_Delete, newerp_deploy" theme="Default" title="ERP" %>
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
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">  
                    
                    <ContentTemplate>
                    <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server" >
                    
                    <table Width="100%" >
                    <tr>
                    <td height="29" valign="middle">
                        <asp:Label ID="lblBVP_NO" runat="server" Text="BVP No "></asp:Label>
                 <asp:TextBox ID="txtbvp_No" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />                           
               
                    </td>
                    </tr>
                    
                    <tr>
                    <td>      
                    
                     <asp:GridView ID="GridView3"  
                runat="server" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" CssClass="yui-datatable-theme" Width="100%" 
                    AllowPaging="True"  PageSize="20"
                             onrowdeleting="GridView3_RowDeleting" 
                            onpageindexchanging="GridView3_PageIndexChanging">
                         <PagerSettings PageButtonCount="40" />
                         <Columns><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirmationDelete();" CausesValidation="False" 
                                   CommandName="Delete" Text="Delete"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" /></asp:TemplateField>
                                   
                                   <asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate> <%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField> 
                                   
                                   <asp:TemplateField HeaderText="BVP No">
                                   <ItemTemplate><asp:Label ID="lblBvbNo" runat="server" Text='<%#Eval("BVPNo") %>'> </asp:Label></ItemTemplate>
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
                      <ItemStyle HorizontalAlign="Left" Width="12%" />
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
                  
                  </td>
                  </tr>                  
                  </table>
                    </asp:Panel>
                    </ContentTemplate></cc1:TabPanel>
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Receipt">
                            
                        <ContentTemplate><asp:Panel ID="Panel2" ScrollBars="Auto" runat="server" 
                                Width="100%">
                                
                                <table Width="100%" >
                    <tr>
                    <td height="29" valign="middle">
                        <asp:Label ID="lblbvrNo" runat="server" Text="BVR No "></asp:Label>
                 <asp:TextBox ID="txtbvr_No" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearch1" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch1_Click" />                           
               
                    </td>
                    </tr>
                    
                    <tr>
                    <td> 
                     <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                onrowcommand="GridView6_RowCommand" PageSize="15" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Size="10pt" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Del" 
                                                OnClientClick="confirmationDelete()"> Delete</asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdR" runat="server" Text='<%#Eval("Id")%>'> </asp:Label>
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
                                    <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" 
                                        SortExpression="InvoiceNo">
                                        <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No" 
                                        SortExpression="ChequeNo">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
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

