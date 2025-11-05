<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_SundryCreditors_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style4
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal; 
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #FFFFFF;
            text-decoration: none;
            height: 21px;
        }
        .style6
        {
            text-align: right;
        }
        .style8
        {
            font-weight: bold;
        }
        </style>
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
    <table align="center" style="width: 100%" cellpadding="0" cellspacing="0"  >
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" 
                class="style4" colspan="2"><b>
                &nbsp;Sundry Creditors: 
                    <asp:Label ID="lblOf" runat="server"></asp:Label></b></td>
        </tr>

        
            <tr>
            <td>
         
            <table width="100%" align="center" ><tr><td align="left" ><b>Supplier Name</b> :<asp:TextBox ID="TextBox1" runat="server" CssClass="box3" 
                    Width="300px"></asp:TextBox><cc1:AutoCompleteExtender 
                    ID="Txt_AutoCompleteExtender" runat="server" 
                    CompletionInterval="100" CompletionListCssClass="almt" 
                    CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                    CompletionSetCount="2" ContextKey="key1" DelimiterCharacters="" Enabled="True" 
                    FirstRowSelected="True" MinimumPrefixLength="1" ServiceMethod="sql3" 
                    ServicePath="" ShowOnlyCurrentWordInCompletionListItem="True" 
                    TargetControlID="TextBox1" UseContextKey="True"></cc1:AutoCompleteExtender>&nbsp;<asp:Button ID="btn_Search" runat="server" CssClass="redbox" 
                    onclick="btn_Search_Click" Text="Search" />
                &nbsp;<asp:Button ID="Button2" runat="server" CssClass="redbox" 
                    onclick="Button2_Click" Text="Export" />
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    onclick="Button1_Click" Text="Cancel" />
                &nbsp;</td></tr><tr><td align="char" height="360" valign="top">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                            OnRowCommand="GridView1_RowCommand" PageSize="18" ShowFooter="False" 
                        Width="700px"><Columns><asp:TemplateField HeaderText="SN" SortExpression="Id"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" Width="2%" /></asp:TemplateField><asp:TemplateField HeaderText="Particulars"><ItemTemplate>                                            
                                            <asp:LinkButton ID="lblTerms" CommandName="LnkBtn" runat="server" Text='<%#Eval("SupplierName") %>'><%#Eval("SupplierName") %></asp:LinkButton>
                                            
                                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="40%" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Debit">
                            <ItemTemplate>
                            <asp:Label runat="server" ID="lblDebit" Text='<%#Eval("PaymentAmt") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Credit">
                            <ItemTemplate>
                                <asp:Label ID="lblBookBill" runat="server" Text='<%#Eval("BookBillAmt") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="12%" />
                            </asp:TemplateField>
                  
                  <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate></asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="SupplierId" Visible="False"><ItemTemplate><asp:Label ID="lblSupId" runat="server" Text='<%#Eval("SupplierId") %>'> </asp:Label></ItemTemplate></asp:TemplateField></Columns><FooterStyle Wrap="True" /><PagerSettings PageButtonCount="40" /></asp:GridView>
                    y</td></tr><tr><td align="center">
                <table align="left" cellpadding="0" cellspacing="0" width="56%">
                    <tr>
                        <td class="style6" width="70%">
                            <asp:Label ID="Label3" runat="server" CssClass="style8" Text="Credit Total:"></asp:Label>
                        </td>
                        <td class="style6" width="60%">
                            <asp:Label ID="lblTotal" runat="server" CssClass="style8" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
                </td></tr><tr><td align="center">
                <table align="left" cellpadding="0" cellspacing="0" width="56%">
                    <tr>
                        <td class="style6" width="70%">
                            <asp:Label ID="Label4" runat="server" CssClass="style8" Text="Debit Total:"></asp:Label>
                        </td>
                        <td class="style6" width="60%">
                            <asp:Label ID="lblTotal1" runat="server" CssClass="style8" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
                </td></tr><tr><td align="center">
                <table align="left" cellpadding="0" cellspacing="0" width="56%">
                    <tr>
                        <td class="style6" width="70%">
                            <asp:Label ID="Label5" runat="server" CssClass="style8" Text="Closing Bal:"></asp:Label>
                        </td>
                        <td class="style6" width="60%">
                            <asp:Label ID="lblTotal2" runat="server" CssClass="style8" Text="0"></asp:Label>
                        </td>
                    </tr>
                </table>
                </td></tr></table>   
             
            </td>
            </tr>    
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>