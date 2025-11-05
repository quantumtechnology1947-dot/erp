<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Asset_Register, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite">
                <b>&nbsp;Asset Register</b></td>
        </tr>
      <tr>
            <td height="25" valign="middle" width="100%">
                &nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="0">Search All</asp:ListItem>
                <asp:ListItem Value="1">Categoy</asp:ListItem>
               </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="ddlCategory" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="Abbrivation" 
                    DataValueField="Id" 
                    onselectedindexchanged="ddlCategory_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
    
      
                &nbsp;<asp:DropDownList ID="ddlSubCategory" runat="server" > 
                </asp:DropDownList>
                      
                &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                    Text="Search" onclick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" height="430" width="100%"> 
               <iframe runat="server" id="ifrm" width="100%" height="430" frameborder="0"></iframe>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"                   
                    SelectCommand="SELECT Id,Abbrivation FROM tblACC_Asset_Category" >  
                </asp:SqlDataSource>   
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

