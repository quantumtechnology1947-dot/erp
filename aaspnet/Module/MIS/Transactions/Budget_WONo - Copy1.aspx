<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_WONo - Copy1.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_WONo" Theme ="Default"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
        <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css"/>

<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>

</head>
<body>

    <form id="form1" runat="server">
    <div> 
    
  <table   width="100%" cellpadding="0" cellspacing="1" class="fontcss"><tr ><td align="left" valign="middle"  scope="col"   
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">&#160;<b>Budget-Hrs</b></td></tr>
                       <tr>
                       <td>
                           <asp:Panel ID="Panel1" runat="server"  Height="345px">  
                            <asp:GridView ID="GridView1"  runat="server" 
                    AutoGenerateColumns="False"  Width="100%"  ShowFooter="true"
                    CssClass="yui-datatable-theme" onrowcommand="GridView1_RowCommand" 
                    AllowPaging="True"  DataSourceID="LocalSqlServer" PageSize="20">
                                <PagerSettings PageButtonCount="40" />
                                <Columns>
                    
                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                    
                    
                    <asp:TemplateField><ItemTemplate><asp:HyperLink ID="Link1" runat="server" Text="Select"/>
                        </ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="CK"><ItemTemplate><asp:CheckBox ID="CheckBox1"  OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" runat="server"/>
                        </ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField 
                            HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Description" SortExpression="Description"><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:TemplateField HeaderText="Symbol" SortExpression="Symbol"><ItemTemplate><asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label></ItemTemplate>
                            
                           
                           <ItemStyle HorizontalAlign="Center" />
                            
                           </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Budget Code" >
                                       <ItemTemplate>
                                       <asp:Label ID="LblBudgetCode" runat="server"  > </asp:Label>  
                                       </ItemTemplate>
                                      </asp:TemplateField>                                     
                                     <asp:TemplateField HeaderText="Budget Hrs" SortExpression="Amount"><ItemTemplate><asp:Label ID="lblAmount" runat="server" > </asp:Label><asp:TextBox ID="TxtAmount" runat="server" Visible="false" ValidationGroup="A"> </asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtAmount" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator></ItemTemplate><ItemStyle HorizontalAlign="Right" />
                          <FooterTemplate><asp:Label ID="lblTotalBudAmt" runat="server" > </asp:Label>
                                                                                           
                                                                        </FooterTemplate><FooterStyle Font-Bold  HorizontalAlign="Right" />
                          </asp:TemplateField>
                                       
                                     <asp:TemplateField HeaderText="PO" SortExpression ="PO" Visible="false">
                                     <ItemTemplate>
                                     <asp:Label ID="lblPO" runat="server" > </asp:Label>
</ItemTemplate><ItemStyle HorizontalAlign="Right" /> <FooterTemplate>
                                                                        
                                                                                           <asp:Label ID="lblPO1" runat="server" > </asp:Label>
                                                                                           
                                                                        </FooterTemplate><FooterStyle Font-Bold  HorizontalAlign="Right" />
                                     </asp:TemplateField>
                                     
                                     
               <asp:TemplateField HeaderText="Cash Pay" SortExpression="Cash" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCashPay" runat="server"> </asp:Label>
                                        <asp:TextBox ID="TxtCashPay" runat="server" Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    
                                    <FooterTemplate>                                    
                                     <asp:Label ID="lblCashPay1" runat="server" > </asp:Label>
                                                                                           
                                                                        </FooterTemplate><FooterStyle Font-Bold  HorizontalAlign="Right" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Cash Rec" SortExpression="Cash" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCashRec" runat="server"> </asp:Label>
                                        <asp:TextBox ID="TxtCashRec" runat="server" Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                    
                                    
                                         <FooterTemplate>                                    
                                     <asp:Label ID="lblCashRec1" runat="server" > </asp:Label>
                                                                                           
                                                                        </FooterTemplate><FooterStyle Font-Bold  HorizontalAlign="Right" />
                                </asp:TemplateField> 
                                     
                                       <asp:TemplateField HeaderText="Tax" SortExpression ="Tax" Visible="false">
                                     <ItemTemplate>
                                     <asp:Label ID="lblTax" runat="server" > </asp:Label>
                                        </ItemTemplate><ItemStyle HorizontalAlign="Right" />
                                        
                                        <FooterTemplate>
                                                                        
                                                                  <asp:Label ID="lblTax1" runat="server" > </asp:Label>                          
                                                                        </FooterTemplate><FooterStyle Font-Bold  HorizontalAlign="Right" />
                                     </asp:TemplateField>                        
                                     
                                     <asp:TemplateField HeaderText="Bal Budget-Hrs" SortExpression ="Budget">
                                     <ItemTemplate>
                                     <asp:Label ID="lblBudget" runat="server" > </asp:Label>
                                         </ItemTemplate><ItemStyle HorizontalAlign="Right" />
                                         
                                         
                                         <FooterTemplate>
                                                                        
                              <asp:Label ID="lblBudget1" runat="server" > </asp:Label>
                                                        
                                </FooterTemplate>
                                         <FooterStyle Font-Bold  HorizontalAlign="Right" />
                                         
                                     </asp:TemplateField>
                                     
                                     </Columns>
                    </asp:GridView> </asp:Panel></td></tr>
                
                    <tr>
                        <td align="center" class="style3">
                        <asp:Button ID="BtnInsert" runat="server" CssClass="redbox"  
                                     Text="Insert" onclick="BtnInsert_Click" />
                                     &nbsp;<asp:Button ID="BtnExport" runat="server" CssClass="redbox" 
                                     Text="Export" onclick="BtnExport_Click" />
                            &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                        onclick="btnCancel_Click" Text="Cancel" />
                              <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                            ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT Id, Description,  Symbol FROM tblMIS_BudgetCode_Time">
                        </asp:SqlDataSource>
                           
                        </td>
                </tr>
                    
                    </table>
           
     
        </div>
    </form>
</body>
</html>
