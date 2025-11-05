<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Salary_Summery.aspx.cs" Inherits="Module_HR_Transactions_Salary_Print" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style2
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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" 
                    style="background:url(../../../images/hdbg.JPG)" height="21" 
                    class="fontcsswhite" colspan="4"><b>&nbsp;Salary Summery</b></td>
        </tr>
        <tr> 
        <td width="20%">
        
        </td>
         
        <td width="10%">
            &nbsp;</td>
        <td width="80%">
        
            &nbsp;</td>
        <td width="5%">
        
        </td>
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
         &nbsp;<b><asp:Label ID="Label4" runat="server" Text="Select Month"></asp:Label></b>
            </td>
        <td>
        
           <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box3" 
                                AutoPostBack="True" 
                onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                            </asp:DropDownList>
                            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblBGGroup" runat="server" Font-Bold="True" Text="Select Department"></asp:Label>
&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlBGGroup" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="Dept" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
            </td>
            
       
        <td>
        
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="Select Id, Symbol as Dept from BusinessGroup">
            </asp:SqlDataSource>
        
        
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT [Id], [Name] FROM [tblACC_Bank] WHERE [Id]!='4'">
            </asp:SqlDataSource>
                                     
            
            </td>
       
        </tr>
       
        <tr>
     
        <td align="center" colspan="4" height="25px" valign="middle">
            <br />
            <br />
         <asp:Button ID="btnProceed" runat="server" CssClass="redbox" Text="Proceed" 
                                            onclick="Button1_Click" />
        </td>
        
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

