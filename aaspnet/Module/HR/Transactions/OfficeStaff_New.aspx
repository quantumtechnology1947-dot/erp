<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_OfficeStaff_New, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3"  Runat="Server" >
    <table align="left" cellpadding="0" cellspacing="0" class="style1" 
        style="width: 525px">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Offers</b></td>
        </tr>
        <tr>
            <td align="center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="OfferId"  AllowPaging="True" 
                    CssClass="yui-datatable-theme" PageSize="24" Width="100%" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged"> 
        <PagerSettings PageButtonCount="40" />
        <Columns>
            <asp:HyperLinkField NavigateUrl="~/Module/HR/Transactions/OfficeStaff_New_Details.aspx" 
                Text="Select" DataNavigateUrlFields="OfferId" 
                
                DataNavigateUrlFormatString="~/Module/HR/Transactions/OfficeStaff_New_Details.aspx?OfferId={0}&ModId=12&SubModId=24" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
            <asp:TemplateField HeaderText="OfferId" InsertVisible="False" 
                SortExpression="OfferId">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("OfferId") %>'></asp:Label>
                </ItemTemplate>                
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EmployeeName" SortExpression="EmployeeName">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                </ItemTemplate>
                
                <ItemStyle Width="50%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StaffType" SortExpression="StaffType">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("StaffType") %>'></asp:Label>
                </ItemTemplate>
                
                <ItemStyle HorizontalAlign="Center" />
                
            </asp:TemplateField>            
        </Columns>
         <FooterStyle Wrap="True"></FooterStyle>
                
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
                <br />
                <asp:Label ID="lblmsg" runat="server" style="color: #CC0000"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

