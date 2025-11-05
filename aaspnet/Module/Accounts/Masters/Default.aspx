<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Masters_Default, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

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
    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
    AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" 
    DataSourceID="SqlDataSource1">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
            ReadOnly="True" SortExpression="Id" />
        <asp:BoundField DataField="Terms" HeaderText="Terms" SortExpression="Terms" />
        <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" 
    DeleteCommand="DELETE FROM [tblOctroi_Master] WHERE [Id] = @Id" 
    InsertCommand="INSERT INTO tblOctroi_Master(Terms, Value) VALUES (@Terms, @Value)" 
    SelectCommand="SELECT * FROM [tblOctroi_Master] order by [Id] desc" 
    UpdateCommand="UPDATE [tblOctroi_Master] SET [Terms] = @Terms, [Value] = @Value WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="Terms" />
        <asp:Parameter Name="Value" />
        <asp:Parameter Name="Id" />
    </UpdateParameters>
    <InsertParameters>
        <asp:Parameter Name="Terms" />
        <asp:Parameter Name="Value" />
    </InsertParameters>
</asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

