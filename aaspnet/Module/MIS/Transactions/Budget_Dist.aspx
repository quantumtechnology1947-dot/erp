<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Budget_Dist.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_Dist" Title="ERP" Theme ="Default"  %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    
.redbox 
{
	font-family: Verdana, Arial, Helvetica, sans-serif; 
    color: #FFFFFF;
	font-size: 11px; background-color:#FF0000;
	border: 1px solid #FD80FA;
	height: 19px;
}

        </style>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">
                            &nbsp;<b>Assign Budget</b></td>
        </tr>
        <tr>
            <td>
                <%--<asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>--%>
            
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="434px"
        AutoPostBack="True" onactivetabchanged="TabContainer1_ActiveTabChanged" Width="100%" >
        <cc1:TabPanel runat="server" HeaderText="Bussiness Group" ID="TabPanel1">
            <HeaderTemplate>Bussiness Group
            </HeaderTemplate>
        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style2"><tr><td><asp:Panel ID="Panel1" runat="server" Height="420px" ScrollBars="Auto">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" DataSourceID="LocalSqlServer" 
                            OnRowCommand="GridView1_RowCommand" PageSize="20" Width="100%" 
                ShowFooter="True"><PagerSettings PageButtonCount="40" /><Columns><asp:TemplateField HeaderText="SN"><ItemStyle HorizontalAlign="Right" Width="3%" /></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:HyperLink ID="HyperLink1" runat="server" Text="Select" /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="CK"><ItemTemplate><asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                            OnCheckedChanged="CheckBox1_CheckedChanged" /></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Description" SortExpression="Description"><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Name") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField><asp:TemplateField HeaderText="Symbol" SortExpression="Symbol"><ItemTemplate><asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Budget Amount" SortExpression="Amount"><ItemTemplate><asp:Label ID="lblAmount" runat="server"> </asp:Label><asp:TextBox ID="TxtAmount" runat="server" ValidationGroup="A" Visible="false"> </asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="TxtAmount" ErrorMessage="*" 
                                            ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator></ItemTemplate><FooterTemplate>
                                            <asp:Label ID="TotBudgetAmt" runat="server"></asp:Label>
                                            </FooterTemplate><FooterStyle Font-Bold HorizontalAlign="Right" /><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="PO" SortExpression="PO"><ItemTemplate><asp:Label ID="lblPO" runat="server"> </asp:Label><asp:TextBox ID="TxtPO" runat="server" Visible="false"></asp:TextBox></ItemTemplate>
    <FooterTemplate>
                                            <asp:Label ID="TotPOAmt" runat="server"></asp:Label>
                                            </FooterTemplate><FooterStyle Font-Bold HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
    </asp:TemplateField><asp:TemplateField HeaderText="Cash Pay" SortExpression="Cash"><ItemTemplate><asp:Label ID="lblCashPay" runat="server"> </asp:Label><asp:TextBox ID="TxtCashPay" runat="server" Visible="false"></asp:TextBox></ItemTemplate>
    <FooterTemplate>
                                            <asp:Label ID="TotCashPay" runat="server"></asp:Label>
                                            </FooterTemplate><FooterStyle Font-Bold HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
    </asp:TemplateField><asp:TemplateField HeaderText="Cash Rec" SortExpression="Cash"><ItemTemplate><asp:Label ID="lblCashRec" runat="server"> </asp:Label><asp:TextBox ID="TxtCashRec" runat="server" Visible="false"></asp:TextBox></ItemTemplate>
    <FooterTemplate>
                                            <asp:Label ID="TotCashRec" runat="server"></asp:Label>
                                            </FooterTemplate><FooterStyle Font-Bold HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
    </asp:TemplateField><asp:TemplateField HeaderText="Tax" SortExpression="Tax"><ItemTemplate><asp:Label ID="lblTax" runat="server"> </asp:Label><asp:TextBox ID="TxtTax" runat="server" Visible="false"></asp:TextBox></ItemTemplate>
    <FooterTemplate>
                                            <asp:Label ID="TotTaxAmt" runat="server"></asp:Label>
                                            </FooterTemplate><FooterStyle Font-Bold HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
    </asp:TemplateField><asp:TemplateField HeaderText="Bal Budget" SortExpression="Budget"><ItemTemplate><asp:Label ID="lblBudget" runat="server"> </asp:Label></ItemTemplate>
    <FooterTemplate><asp:Label ID="TotBalBudgetAmt" runat="server"></asp:Label>
                                            </FooterTemplate><FooterStyle Font-Bold HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
    </asp:TemplateField></Columns></asp:GridView></asp:Panel></td></tr><tr><td style="text-align: center"><asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT Id, Name,  Symbol FROM BusinessGroup Where Id not in ('1') "></asp:SqlDataSource><asp:Button ID="BtnInsert" runat="server" CssClass="redbox" 
                        OnClick="BtnInsert_Click" Text="Insert" ValidationGroup="A" /><asp:Button ID="BtnExport" runat="server" CssClass="redbox" 
                        OnClick="BtnExport_Click" Text="Export" /><asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                        OnClick="btnCancel_Click" Text="Cancel" Width="60px" /></td></tr></table>
        </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Work Order ">
        <ContentTemplate> 
             
        <iframe src="Budget_Dist_WONo.aspx"  width="100%" height="435Px" frameborder="0" ></iframe>
            
        </ContentTemplate>
        
        </cc1:TabPanel>
    </cc1:TabContainer>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

