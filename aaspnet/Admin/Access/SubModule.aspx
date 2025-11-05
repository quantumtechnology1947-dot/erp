<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Admin_Access_SubModule, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    
    .style2
    {
        width: 147px;
    }
    
</style>
<link type="text/css" href="../../Css/yui-datatable.css" rel="stylesheet" />
<script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr>
    <td>&nbsp;</td>
    </tr>
        <tr>
            <td >
                <table align="center" cellpadding="0" cellspacing="0" class="box3" width="400">
                    <tr>
                        <td colspan="2" style="background:url('../../images/hdbg.JPG')" height="21" class="fontcsswhite">&nbsp;<strong>Sub Module</strong> </td>
                    </tr>
                    <tr>
                        <td height="25" class="style2">
    &nbsp;
    <asp:Label ID="Label2" runat="server" Text="Module Name"></asp:Label>
                        </td>
                        <td>
    <asp:DropDownList ID="DrpModName" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="ModName" DataValueField="ModId" CssClass="box3">
    </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [ModId], [ModName] FROM [tblModule_Master] ORDER BY [ModId] Desc">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" class="style2">
    &nbsp;
    <asp:Label ID="Label3" runat="server" Text="Type"></asp:Label>
                        </td>
                        <td>
    <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" CssClass="box3">
        <asp:ListItem Value="1">Masters</asp:ListItem>
        <asp:ListItem Value="2">Transactions</asp:ListItem>
        <asp:ListItem Value="3">Reports</asp:ListItem>
    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" class="style2">
    &nbsp;
    <asp:Label ID="Label4" runat="server" Text="Sub Module Name"></asp:Label>
                        </td>
                        <td>
    <asp:TextBox ID="TxtSubModuleName" runat="server" CssClass="box3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" class="style2">
    &nbsp;
    <asp:Label ID="Label5" runat="server" Text="LinK Page"></asp:Label>
                        </td>
                        <td>
    <asp:TextBox ID="TxtLinkPage" runat="server" CssClass="box3"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2" height="35">
                            &nbsp;</td>
                        <td height="25">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" CssClass="redbox" />
                            <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                onclick="Button2_Click" Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
             <asp:Panel ID="Panel1" runat ="server" ScrollBars="Auto" Width="70%" Height="305px" >
    <asp:GridView ID="GridView2" runat="server" 
        AutoGenerateColumns="False" 
        DataKeyNames="SubModId" DataSourceID="LocalSqlServer" CssClass="yui-datatable-theme" 
                    Width="100%">
        <Columns>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" >
                <ItemStyle Width="4%" HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:BoundField DataField="SubModId" HeaderText="SubModId" 
                InsertVisible="False" ReadOnly="True" SortExpression="SubModId" >
                <ItemStyle Width="7%" HorizontalAlign="Center"  />
            </asp:BoundField>
             <asp:BoundField DataField="ModId" HeaderText="ModId" SortExpression="ModId" Visible ="false" >                          
                 <ItemStyle Width="4%" />
            </asp:BoundField>
                          
                <asp:TemplateField HeaderText="Module Id - Module Name" 
                SortExpression="ModuleName">
                <ItemTemplate>
                <asp:Label ID="lblModuleName" runat="server" Text='<%#Eval("ModuleName") %>'> </asp:Label>
                </ItemTemplate>                      
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                
            <asp:BoundField DataField="MTR" HeaderText="MTR" SortExpression="MTR" >
                <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="SubModName" HeaderText="SubModName" 
                SortExpression="SubModName" >
                <ItemStyle Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="DashBoardPage" HeaderText="DashBoardPage" 
                SortExpression="DashBoardPage" >
                <ItemStyle Width="20%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    
                    
                    SelectCommand="SELECT [tblSubModule_Master].[SubModId],[tblSubModule_Master].[ModId],Convert(Varchar,[tblSubModule_Master].[ModId])+'  - '+[tblModule_Master].[ModName] AS ModuleName,CASE WHEN [tblSubModule_Master].[MTR]=1 THEN '1 - Masters' WHEN [tblSubModule_Master].[MTR]=2 THEN '2 - Transactions' ELSE'3 - Reports'END AS MTR,[tblSubModule_Master].[SubModName],[tblSubModule_Master].[DashBoardPage] FROM [tblSubModule_Master],[tblModule_Master]WHERE [tblModule_Master].[ModId]=[tblSubModule_Master].[ModId] Order by [tblSubModule_Master].[SubModId] Desc"
                    
                    
                    
                    DeleteCommand="DELETE FROM [tblSubModule_Master] WHERE [SubModId] = @SubModId" 
                    InsertCommand="INSERT INTO [tblSubModule_Master] ([ModId], [MTR], [SubModName], [DashBoardPage]) VALUES (@ModId, @MTR, @SubModName, @DashBoardPage)" 
                    UpdateCommand="UPDATE [tblSubModule_Master] SET [MTR] = @MTR, [SubModName] = @SubModName, [DashBoardPage] = @DashBoardPage WHERE [SubModId] = @SubModId">
                    <DeleteParameters>
                        <asp:Parameter Name="SubModId" Type="Int32" />
                    </DeleteParameters>                 
                    <UpdateParameters>
                        <asp:Parameter Name="ModId" Type="Int32" />
                        <asp:Parameter Name="MTR" Type="Int32" />
                        <asp:Parameter Name="SubModName" Type="String" />
                        <asp:Parameter Name="DashBoardPage" Type="String" />
                        <asp:Parameter Name="SubModId" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ModId" Type="Int32" />
                        <asp:Parameter Name="MTR" Type="Int32" />
                        <asp:Parameter Name="SubModName" Type="String" />
                        <asp:Parameter Name="DashBoardPage" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>                
                
             </asp:Panel>    
                
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

