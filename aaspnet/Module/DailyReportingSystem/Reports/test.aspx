<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Module_DailyReportingSystem_Reports_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Selected="True">t</asp:ListItem>
            <asp:ListItem>h</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
            <columns>  
         <asp:TemplateField HeaderText="ID">  
             <ItemTemplate>  
                 <asp:Label ID="LblCompanyId" runat="server" Text='<%#Bind("Id") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Name">  
             <ItemTemplate>  
                 <asp:Label ID="LblCompanyName" runat="server" Text='<%#Bind("Description") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Address">  
             <ItemTemplate>  
                 <asp:Label ID="LblCompanyAddress" runat="server" Text='<%#Bind("Symbol") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>           
     </columns>   
        </asp:GridView>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </form>
</body>
</html>
