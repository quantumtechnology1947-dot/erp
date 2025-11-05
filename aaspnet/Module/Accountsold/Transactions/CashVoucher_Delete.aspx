<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CashVoucher_Delete.aspx.cs" Inherits="Module_Accounts_Transactions_CashVoucher_Delete" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

 <table align="left" cellpadding="0" cellspacing="0"  width="100%">
        <tr>
            <td style="background:url(../../../images/hdbg.JPG); height:21px" 
                class="fontcsswhite" >&nbsp;<b>Cash Voucher- Delete</b></td>
        </tr>
        <tr>
        <td>
        
             <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Height="431px" Width="100%" >
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Payment" >
                    <HeaderTemplate>Payment
                    </HeaderTemplate>

                    <ContentTemplate>
                    
                    <table Width="100%" >
                    <tr>
                    <td height="29" valign="middle">
                        <asp:Label ID="lblCVP_NO" runat="server" Text="CVP No "></asp:Label>
                 <asp:TextBox ID="txtcvp_No" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />                           
               
                    </td>
                    </tr>
                    
                    <tr>
                    <td>                    
                    <asp:GridView 
                                ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CssClass="yui-datatable-theme" DataKeyNames="Id"   
                AllowPaging="True" PageSize="20"   
                OnPageIndexChanging="GridView1_PageIndexChanging"       OnRowCommand="GridView1_RowCommand"                               
                                        Width="100%" ><PagerSettings PageButtonCount="40" />
                                        
                                        
                                        <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate><%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <HeaderStyle Font-Size="10pt" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:LinkButton  ID ="lnkButton" Text="Select" runat ="server" CommandName="Sel">
                                         </asp:LinkButton>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" />
                                         </asp:TemplateField>
                                        
                                        <asp:TemplateField    HeaderText="Id" Visible="False"><ItemTemplate>
                                        <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                                        </ItemTemplate><ItemStyle Width="3%" /></asp:TemplateField>
                                        
                                        <asp:BoundField DataField="CVPNo" HeaderText="CVP No" >
                                        <ItemStyle HorizontalAlign="Center" Width="7%" /></asp:BoundField>
                     
                     <asp:BoundField DataField="FinYear" HeaderText="Fin. Year">
                     <ItemStyle HorizontalAlign="Center" Width="7%" /></asp:BoundField>
           
           <asp:BoundField DataField="Date" HeaderText="Date" ><ItemStyle HorizontalAlign="Center" />
           </asp:BoundField>
           
           <asp:BoundField DataField="PaidTo" HeaderText="Paid To"  />
           <asp:BoundField DataField="CodeType" HeaderText="Receiver Type"  >           
           <ItemStyle HorizontalAlign="Center"  Width="11%"/>
           </asp:BoundField>
           
           <asp:BoundField DataField="Receivedby" HeaderText="Received by"  />
           <asp:BoundField DataField="CompId" HeaderText="CompId" SortExpression="CompId" 
                                                Visible="False" />
                                                
                                                  <asp:BoundField DataField="Amount" HeaderText="Amount"  >
                                                    <ItemStyle HorizontalAlign="Right"  Width="7%"/>
                                               </asp:BoundField>
                                                
                                                </Columns>
                                                
                                                <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>                    
                     
                     </td>
                    </tr>
                    </table>

                        </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Receipt">
                        <HeaderTemplate>Receipt
                        </HeaderTemplate>

                        <ContentTemplate>
                        
                         <table Width="100%" >
                    <tr>
                    <td height="29" valign="middle">
                        <asp:Label ID="lblCVRNo" runat="server" Text="CVR No "></asp:Label>
                 <asp:TextBox ID="txtCVR_No" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
                &nbsp;<asp:Button ID="btnSearch1" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch1_Click" />                           
               
                    </td>
                    </tr>
                    
                    <tr>
                    <td>  


    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" DataKeyNames="Id" 
                            Width="100%" PageSize="20" onpageindexchanging="GridView2_PageIndexChanging" 
                                onrowcommand="GridView2_RowCommand" AllowPaging="True">

                            <Columns>
                            <asp:TemplateField HeaderText="SN">
                            <ItemTemplate><%#Container.DataItemIndex+1%>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="10pt" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                            
                              <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:LinkButton  ID ="lnkButton_R" Text="Delete" runat ="server" CommandName="Sel_R">
                                         </asp:LinkButton>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="3%" />
                                         </asp:TemplateField>
                                         
                                    <asp:TemplateField    HeaderText="Id" Visible="False">
                                    <ItemTemplate><asp:Label ID="lblId_R" Text='<%# Eval("Id") %>' runat="server">
                                    </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="2%" />
                                    </asp:TemplateField>                
                            
                            <asp:BoundField DataField="CVRNo" HeaderText="CVR No" SortExpression="CVRNo" >
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:BoundField>
                            
                              <asp:BoundField DataField="FinYear" HeaderText="Fin. Year"> 
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="SysDate" HeaderText="Date" 
                            SortExpression="SysDate" >
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:BoundField>
                            
                             <asp:BoundField DataField="CashReceivedAgainstType" HeaderText="Rec. Against Type" 
                            SortExpression="CashReceivedAgainstType" >
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField> 
                                                         
                            <asp:BoundField DataField="CashReceivedAgainst" 
                            HeaderText="Cash Rec. Against" SortExpression="CashReceivedAgainst" >
                            <ItemStyle HorizontalAlign="Left" Width="16%" />
                            </asp:BoundField>

                            
                            <asp:BoundField DataField="CashReceivedByType" HeaderText="Rec.By Type" 
                            SortExpression="CashReceivedByType" >
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="CashReceivedBy" HeaderText="Cash Rec. By" 
                            SortExpression="CashReceivedBy" >
                            <ItemStyle HorizontalAlign="Left" Width="16%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="CompId" HeaderText="CompId" Visible="False"
                            SortExpression="CompId" >
                            
                                <ItemStyle Width="1%" />
                                </asp:BoundField>
                            
                           <asp:BoundField DataField="Amount" HeaderText="Amount"  >
                            <ItemStyle HorizontalAlign="Right"  Width="4%"/>
                       </asp:BoundField>                          


                            </Columns>
    
    <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                                        
    </EmptyDataTemplate>

                                <PagerSettings PageButtonCount="40" />

    </asp:GridView>

</td>
                    </tr>
                    </table>
                     </ContentTemplate>

                    </cc1:TabPanel>
                    </cc1:TabContainer>     
        
        
        
        
        
        
        
        
         
                                                
        </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

