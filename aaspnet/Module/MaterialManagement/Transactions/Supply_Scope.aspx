<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Supply_Scope.aspx.cs" Inherits="Module_MaterialManagement_Masters_Supply_Scope" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<br />
<br />

Scope Of Supply :
<asp:TextBox ID="txtSearch" runat="server" ></asp:TextBox>
<asp:Button ID="Button1" Text="Search" runat="server" OnClick="Search" CssClass="redbox"/>
<br />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" AllowPaging="False"
    OnPageIndexChanging="OnPaging">
    <Columns>
     <asp:TemplateField HeaderText="Sr No">
        <ItemTemplate>
            <%# Container.DataItemIndex + 1 %>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" ItemStyle-Width="150" />
        <asp:BoundField DataField="SupplierId" HeaderText="SupplierId" ItemStyle-Width="70" />
        <asp:BoundField DataField="ScopeOfSupply" HeaderText="Scope Of Supply " ItemStyle-Width="150" />
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
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

