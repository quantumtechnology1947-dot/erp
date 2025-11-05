<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_BusinessGroup, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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

<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="60%" align="left">
     
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Business Group</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                DataSourceID="LocalSqlServer"
              OnRowUpdated="GridView1_RowUpdated" 
              OnRowCommand="GridView1_RowCommand" CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="20">
                    
<FooterStyle Wrap="True"></FooterStyle>
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" 
                         OnClientClick=" return confirmationAdd()" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                         <asp:CommandField  ButtonType="Link" ShowEditButton="True" ValidationGroup ="SG" >
                            <ItemStyle Width="3%" />
                        </asp:CommandField>
                         <asp:CommandField ShowDeleteButton="True" ButtonType="Link" >
                             <ItemStyle Width="3%" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'>    
                        </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblName0" runat="server" Text='<%#Bind("Name") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqName0" runat="server" ControlToValidate="lblName0" ValidationGroup="SG"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtName" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqName" runat="server" ControlToValidate="txtName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        </FooterTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblsymbol" runat="server" Text='<%#Eval("Symbol") %>'>    
                        </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblsymbol0" runat="server" Text='<%#Bind("Symbol") %>'>
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="Reqsymbol0" runat="server" ControlToValidate="lblsymbol0" ValidationGroup="SG"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtsymbol" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Reqtxtsymbol" runat="server" ControlToValidate="txtsymbol"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Incharge" SortExpression="Incharge">
                            <ItemStyle Width="45%" />
                             <ItemTemplate>
                        <asp:Label ID="lblincharge" runat="server" Text='<%#Eval("Incharge") %>'>    
                        </asp:Label></ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblincharge0" runat="server" Text='<%#Bind("Incharge") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Reqincharge0" runat="server" ControlToValidate="lblincharge0" ValidationGroup="SG"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtincharge" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="Reqincharge" runat="server" ControlToValidate="txtincharge"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [BusinessGroup] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [BusinessGroup] ([Name], [Symbol],[Incharge]) VALUES (@Name, @Symbol,@Incharge)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [BusinessGroup]" 
                    UpdateCommand="UPDATE [BusinessGroup] SET [Name] = @Name, [Symbol] = @Symbol, [Incharge] = @Incharge WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Name" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="Incharge" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Name" Type="String"/>
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="Incharge" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                
             
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
    </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

