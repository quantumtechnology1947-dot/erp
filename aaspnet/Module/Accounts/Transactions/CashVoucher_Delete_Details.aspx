<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CashVoucher_Delete_Details.aspx.cs" Inherits="Module_Accounts_Transactions_CashVoucher_Delete_Details" Title="ERP" Theme="Default" %>

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
         <asp:GridView 
                                ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        CssClass="yui-datatable-theme" DataKeyNames="Id"   AllowPaging="true" PageSize="20"   OnPageIndexChanging="GridView1_PageIndexChanging"          OnRowCommand="GridView1_RowCommand"   ShowFooter="true"                             
                                        Width="100%" >
                                        
                                        <Columns>
                                       <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>                                
                                            </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" />
                            </asp:TemplateField>
                                        
                                        <asp:TemplateField><ItemTemplate><asp:LinkButton  ID ="lnkButton"   OnClientClick=" return confirmationDelete()" Text="Delete" runat ="server" CommandName="Del"> </asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" /></asp:TemplateField>
                                        
                                        
                                        <asp:TemplateField    HeaderText="Id" Visible="False">
                                    <ItemTemplate><asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label></ItemTemplate>
                                    </asp:TemplateField>
                                    
                                  
                                                
                                                <asp:BoundField DataField="BillNo" HeaderText="Bill No" >
                                                <ItemStyle HorizontalAlign="Center"  Width="7%"/>
                                               </asp:BoundField>
                                              
                           <asp:BoundField DataField="BillDate" HeaderText="Bill Date"> <ItemStyle HorizontalAlign="Center"  Width="8%" />
                                               </asp:BoundField>
                                                  <asp:BoundField DataField="PONo" HeaderText="PO No" ><ItemStyle HorizontalAlign="Center"  Width="6%"/>
                                               </asp:BoundField>
                                              <asp:BoundField DataField="PODate" HeaderText="PO Date"  ><ItemStyle HorizontalAlign="Center"  Width="6%"/>
                                               </asp:BoundField>
                                              
                                                <asp:BoundField DataField="Particulars" HeaderText="Particulars"  ><ItemStyle HorizontalAlign="Left"  />
                                               </asp:BoundField>
                                                 <asp:BoundField DataField="WONo" HeaderText="WONo" ItemStyle-Width="6%" /> 
                                                  <asp:BoundField DataField="BGGroup" HeaderText="BG Group" SortExpression="BGGroup"  ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="8%" />
                                                 <asp:BoundField DataField="AcHead" HeaderText="Acc Head" SortExpression="AcHead"        ><ItemStyle HorizontalAlign="Center"  Width="7%"/>
                                               </asp:BoundField>
                                               
                                               <asp:TemplateField HeaderText="Amount">
                                               <ItemTemplate>
                                                   <asp:Label ID="LblAmt" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                               </ItemTemplate>
                                               <ItemStyle HorizontalAlign="Right"  Width="8%" />
                                               
                                               <FooterTemplate>
                                                <asp:Label ID="LblTotalAmt" runat="server" ></asp:Label>
                                               </FooterTemplate>
                                               <FooterStyle HorizontalAlign="Right" Font-Bold />
                                               </asp:TemplateField>
                                               
                                                 
                                          <asp:BoundField DataField="BudgetCode" HeaderText="Budget Code" SortExpression="BudgetCode"    ItemStyle-Width="8%"    />  
                            
                            
                            <asp:BoundField DataField="PVEVNo" HeaderText="PVEV No" 
                                                SortExpression="PVEVNo" ><ItemStyle HorizontalAlign="Center" Width="5%" />
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
        </tr><tr>
<td align="center"> <asp:Button ID="btncancel" CssClass="redbox"  runat="server" Text="Cancel" 
                    onclick="btncancel_Click" />
        </td>
</tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

