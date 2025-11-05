<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_Dist_Dept.aspx.cs" EnableEventValidation="false" Inherits="Module_Accounts_Transactions_Budget_Dist_Dept" Theme ="Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        </style>
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
       
     
        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            onactivetabchanged="TabContainer1_ActiveTabChanged">
            <cc1:TabPanel runat="server" HeaderText="Labour" ID="TabPanel1">
            <ContentTemplate><table class="style1" cellpadding="0" cellspacing="1"><tr><td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">&#160;<b>Labour</b></td></tr><tr><td align="left" class="fontcss"><asp:UpdatePanel  runat="server" ID="up" UpdateMode="Conditional"><ContentTemplate>
                    <asp:GridView ID="GridView1"  runat="server" 
                    AutoGenerateColumns="False"  Width="100%" 
                    CssClass="yui-datatable-theme" onrowcommand="GridView1_RowCommand" 
                    AllowPaging="True" ShowFooter="True" DataSourceID="LocalSqlServer" 
                        PageSize="20">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Text="Select" /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                        <asp:TemplateField HeaderText="CK"><ItemTemplate><asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                OnCheckedChanged="CheckBox1_CheckedChanged" /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" SortExpression="Description"><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField>
                                <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol"><ItemTemplate><asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /><FooterTemplate><asp:Button ID="BtnExport" runat="server" CssClass="redbox" CommandName="export" 
                        Text="Export" /></FooterTemplate></asp:TemplateField>
                        <asp:TemplateField HeaderText="Budget Amount" SortExpression="Amount"><FooterTemplate><asp:Button ID="BtnInsert" runat="server" ValidationGroup="A" CommandName="Insert" CssClass="redbox" 
                                     Text="Insert"  /></FooterTemplate><ItemTemplate><asp:Label ID="lblAmount" runat="server" > </asp:Label><asp:TextBox ID="TxtAmount" runat="server" Visible="false" ValidationGroup="A"> </asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*" ControlToValidate="TxtAmount" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator></ItemTemplate><FooterStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                                     <asp:TemplateField HeaderText="PO" SortExpression ="PO"><ItemTemplate><asp:Label ID="lblPO" runat="server" > </asp:Label><asp:TextBox ID="TxtPO" runat="server" Visible="false"></asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                                     <asp:TemplateField HeaderText="Cash" SortExpression ="Cash"><ItemTemplate><asp:Label ID="lblCash" runat="server" > </asp:Label><asp:TextBox ID="TxtCash" runat="server" Visible="false"></asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Tax" SortExpression ="Tax"><ItemTemplate><asp:Label ID="lblTax" runat="server" > </asp:Label><asp:TextBox ID="TxtTax" runat="server" Visible="false"></asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Bal Budget" SortExpression ="Budget"><ItemTemplate><asp:Label ID="lblBudget" runat="server" > </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                        
                        
                    </Columns>
                    </asp:GridView><asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                     ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                     SelectCommand="SELECT Id, Category, Description, Symbol, Abbrivation FROM AccHead WHERE (Category = 'Labour')"></asp:SqlDataSource><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                 
                    </ContentTemplate></asp:UpdatePanel></td></table>
            </ContentTemplate>
            </cc1:TabPanel>
            
            <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="With Material">
            <ContentTemplate><table class="style1" cellpadding="0" cellspacing="1"><tr><td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">&#160;<b>With Material</b></td></tr><tr><td align="right" class="fontcss" valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                   AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                   DataSourceID="LocalSqlServer0" onrowcommand="GridView2_RowCommand" 
                                   ShowFooter="True" Width="100%" PageSize="20">
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                                   <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                        </asp:TemplateField>
                                   <asp:TemplateField><ItemTemplate><asp:HyperLink ID="HyperLink2" runat="server" Text="Select" /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="CK"><ItemTemplate><asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" 
                                                   OnCheckedChanged="CheckBox2_CheckedChanged" /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false"><ItemTemplate><asp:Label ID="lblId0" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Description" SortExpression="Description"><ItemTemplate><asp:Label ID="lblDesc0" runat="server" Text='<%#Eval("Description") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:TemplateField HeaderText="Symbol" SortExpression="Symbol"><ItemTemplate><asp:Label ID="lblSymbol0" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label></ItemTemplate><FooterTemplate><asp:Button ID="BtnExport0" runat="server" CommandName="export" 
                                                   CssClass="redbox" Text="Export" /></FooterTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Budget Amount" SortExpression="Amount"><FooterTemplate><asp:Button ID="BtnInsert0" runat="server" CommandName="Insert" 
                                                   CssClass="redbox" Text="Insert" ValidationGroup="B" /></FooterTemplate><ItemTemplate><asp:Label ID="lblAmount0" runat="server"> </asp:Label><asp:TextBox ID="TxtAmount0" runat="server" ValidationGroup="B" Visible="false"> </asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                   ControlToValidate="TxtAmount0" ErrorMessage="*" 
                                                   ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="B"></asp:RegularExpressionValidator></ItemTemplate><FooterStyle HorizontalAlign="Center" /><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="PO" SortExpression ="PO"><ItemTemplate><asp:Label ID="lblPO0" runat="server" > </asp:Label><asp:TextBox ID="TxtPO0" runat="server" Visible="false"></asp:TextBox>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Cash" SortExpression ="Cash"><ItemTemplate><asp:Label ID="lblCash0" runat="server" > </asp:Label><asp:TextBox ID="TxtCash0" runat="server" Visible="false"></asp:TextBox>
                                     </ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Tax" SortExpression ="Tax"><ItemTemplate><asp:Label ID="lblTax0" runat="server" > </asp:Label><asp:TextBox ID="TxtTax0" runat="server" Visible="false"></asp:TextBox>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Bal Budget" SortExpression ="Budget"><ItemTemplate><asp:Label ID="lblBudget0" runat="server" > </asp:Label><asp:TextBox ID="TxtBudget0" runat="server" Visible="false"></asp:TextBox>
                                     </ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField></Columns></asp:GridView><asp:SqlDataSource ID="LocalSqlServer0" runat="server" 
                                   ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                   SelectCommand="SELECT Id, Category, Description, Symbol, Abbrivation FROM AccHead WHERE (Category = 'With Material')"></asp:SqlDataSource></ContentTemplate></asp:UpdatePanel></td></tr></table>
     
                
                
            
            
            
            </ContentTemplate>
            
            
            </cc1:TabPanel>
        
    </cc1:TabContainer>
        
        
        
        
            
    </div>
    
    </form>
</body>
</html>
