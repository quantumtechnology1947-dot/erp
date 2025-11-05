<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SundryCreditors.aspx.cs" Inherits="Module_Accounts_Transactions_SundryCreditors" Title="ERP" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 100%;
            float: left;
        }
    </style>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
<table width="100%" >
<tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite" colspan="3"><b>&nbsp;Balance Sheet: Current Liabilities: 
                Sundry Creditors</b></td>
        </tr>
<tr>
<td height="420" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server"
                ShowFooter="True" 
                AutoGenerateColumns="False"                
                FooterStyle-Wrap="True"               
                DataSourceID="SqlDataSource1"                          
                OnRowCommand="GridView1_RowCommand" 
                CssClass="yui-datatable-theme" 
                Width="600px"              
                    PageSize="20">
<FooterStyle Wrap="True">
</FooterStyle>
                    <Columns>           
                        <asp:TemplateField HeaderText="Perticulars" >
                        <ItemTemplate>
                        &nbsp;<asp:LinkButton ID="lblCategory" CommandName="gotoPage" runat="server" Text='<%#Eval("Category") %>'></asp:LinkButton>
                        </ItemTemplate>   
                        <FooterTemplate>
                          <table cellpadding="0" cellspacing="0" class="style5">
                            <tr>
                                <td align="right" height="22px"><asp:Label runat="server" ID="lblOpBal" Text="Opening Bal." Font-Bold="true"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" height="22px"><asp:Label runat="server" ID="Total" Text="Grand Total" Font-Bold="true"></asp:Label></td>                              
                            </tr>
                            <tr><td align="right" height="22px"> <asp:Label runat="server" ID="lblClbal" Text="Closing Bal." Font-Bold="true"></asp:Label></td></tr>
                        </table>
                        </FooterTemplate>                        
                            <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Debit" >
                        <ItemTemplate>
                        <asp:Label ID="lblDebit" runat="server" Text="0"></asp:Label>
                        </ItemTemplate>                     
                            <FooterStyle HorizontalAlign="Right" />
                        <ItemStyle Width="25%" HorizontalAlign="Right" />
                        <FooterTemplate>
                         <table cellpadding="0" cellspacing="0" class="style5">
                            <tr>
                                <td height="22px">
                                    &nbsp;</td>
                                
                            </tr>
                            <tr>
                                <td align="right" height="22px"> <asp:Label runat="server" ID="DrTotal" Text="0" Font-Bold="true"></asp:Label></td>                              
                            </tr>
                            <tr><td align="right" height="22px"> &nbsp;</td></tr>
                        </table>                        
                        </FooterTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Credit" >
                        <ItemTemplate>
                        <asp:Label ID="lblCredit" runat="server" Text="0"></asp:Label>
                        </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle Width="25%" HorizontalAlign="Right" />
                        <FooterTemplate>                        
                        <table cellpadding="0" cellspacing="0" class="style5">
                            <tr>
                                <td align="right" height="22px"><asp:Label runat="server" ID="OpTotal" Text="0" Font-Bold="true"></asp:Label></td></tr><tr><td align="right" height="22px"> <asp:Label runat="server" ID="CrTotal" Text="0" Font-Bold="true"></asp:Label></td></tr><tr><td align="right" height="22px"> <asp:Label runat="server" ID="Clbal" Text="0" Font-Bold="true"></asp:Label></td></tr>
                        </table> 
                        </FooterTemplate>
                        </asp:TemplateField>                       
                    </Columns>                    
              </asp:GridView>     
              
              <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT Category FROM AccHead WHERE Id!=0 Group By Category Order by Category DESC"></asp:SqlDataSource>          
   
</td>
</tr>
<tr>
<td align="center" height="22">

    <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
        onclick="btnCancel_Click" Text="Cancel" />

   

</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

