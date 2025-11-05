<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccHead.aspx.cs" Inherits="Module_Accounts_Masters_AccHead" Title="ERP" Theme="Default" %>

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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="70%" align="center">
        <tr>
            <td align="left" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Account Heads</b></td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
                DataSourceID="SqlDataSource1"
                OnRowUpdated="GridView1_RowUpdated"                
                OnRowCommand="GridView1_RowCommand" 
                CssClass="yui-datatable-theme" 
                Width="100%" onrowdatabound="GridView1_RowDataBound" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" PageSize="20">
<FooterStyle Wrap="True">
</FooterStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Link"  ShowEditButton="True" ValidationGroup="Shree"/>
                        <asp:CommandField  ButtonType="Link" ShowDeleteButton="True"  />
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClientClick=" return confirmationAdd()" 
                        ValidationGroup="abc" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'>
                        </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate> 
                                                                   
                        <asp:DropDownList ID="ddCategory1" runat="server" Text='<%#Eval("Category") %>'                  AutoPostBack="true"  CssClass="box3" ValidationGroup="Shree">
                          <asp:ListItem Text="Labour" Value="Labour" ></asp:ListItem>
                          <asp:ListItem Text="With Material" Value="With Material"></asp:ListItem>
                          <asp:ListItem Text="Expenses" Value="Expenses"></asp:ListItem>
                          <asp:ListItem Text="Service Provider" Value="Service Provider"></asp:ListItem>
                        </asp:DropDownList>
                        
                        </EditItemTemplate>
                                            
                        <FooterTemplate>
                        <asp:DropDownList ID="ddCategory2" runat="server" CssClass="box3">
                        <asp:ListItem Text="Labour" Value="Labour"></asp:ListItem>
                        <asp:ListItem Text="With Material" Value="With Material"></asp:ListItem>
                        <asp:ListItem Text="Expenses" Value="Expenses"></asp:ListItem>
                          <asp:ListItem Text="Service Provider" Value="Service Provider"></asp:ListItem>
                        </asp:DropDownList>
                        </FooterTemplate> 
                                               
                        <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                        <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtDescription1" runat="server" Text='<%#Bind("Description") %>'
                        ValidationGroup="Shree" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqDescription0" runat="server" ControlToValidate="txtDescription1" 
                        ErrorMessage="*" ValidationGroup="Shree">
                        </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtDescription2" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqDesc" runat="server" ControlToValidate="txtDescription2" 
                        ErrorMessage="*" ValidationGroup="abc">
                        </asp:RequiredFieldValidator>                        
                        </FooterTemplate>
                        <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'></asp:Label>
                        </ItemTemplate>                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtSymbol1" runat="server" Text='<%#Bind("Symbol") %>' CssClass="box3">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqSymbol0" runat="server" ControlToValidate="txtSymbol1" 
                        ErrorMessage="*" ValidationGroup="Shree">
                        </asp:RequiredFieldValidator>
                        </EditItemTemplate>                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtSymbo2" runat="server" CssClass="box3">
                        </asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="ReqSymb" runat="server" ControlToValidate="txtSymbo2" ErrorMessage="*"
                        ValidationGroup="abc">
                        </asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Abbrivation" SortExpression="Abbrivation">
                        <ItemTemplate>
                        <asp:Label ID="lblAbbrivation" runat="server" Text='<%#Eval("Abbrivation") %>'>    </asp:Label>
                        </ItemTemplate>                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtAbbrivation1" runat="server" Text='<%#Bind("Abbrivation") %>' CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqAbbrivation0" runat="server" ControlToValidate="txtAbbrivation1" 
                        ErrorMessage="*" ValidationGroup="Shree">
                        </asp:RequiredFieldValidator>                        
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtAbbrivation2" runat="server" CssClass="box3">
                        </asp:TextBox>                        
                         <asp:RequiredFieldValidator ID="ReqAbbrv" runat="server" ControlToValidate="txtAbbrivation2" 
                         ErrorMessage="*" ValidationGroup="abc">
                         </asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id">
                        <ItemTemplate>
                   <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                   </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    
                     <EmptyDataTemplate>
                     
                      <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Category"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Description"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Symbol"></asp:Label>
                        </td>
                        <td align="center">
                          <asp:Label ID="Label4" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Abbrivation"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd()" 
            CssClass="redbox" ValidationGroup="pqr" Text="Insert" />
            </td>
            <td>
            <asp:DropDownList ID="ddCategory3" runat="server" >
                        <asp:ListItem Text="Labour" Value="Labour"></asp:ListItem>
                        <asp:ListItem Text="With Material" Value="With Material"></asp:ListItem>
                        <asp:ListItem Text="Expenses" Value="Expenses"></asp:ListItem>
                        <asp:ListItem Text="Service Provider" Value="Service Provider"></asp:ListItem>
                        </asp:DropDownList></td>
                        <td>
                        <asp:TextBox ID="txtDescription3" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqDesc0" runat="server" ControlToValidate="txtDescription3" 
                        ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        <asp:TextBox ID="txtSymbol3" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqSymb0" runat="server" ControlToValidate="txtSymbol3" ErrorMessage="*" 
                        ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        <asp:TextBox ID="txtAbbrivation3" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqAbbrv0" runat="server" ControlToValidate="txtAbbrivation3" 
                        ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        </table>
        </EmptyDataTemplate>                    
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [AccHead] WHERE [Id] = @Id "  
                    InsertCommand="INSERT INTO [AccHead] ([Category], [Description], [Symbol], [Abbrivation]) VALUES (@Category, @Description, @Symbol, @Abbrivation)" 
                    SelectCommand="SELECT Id, Category, Description, Symbol, Abbrivation FROM AccHead WHERE Id!=0 ORDER BY Id DESC"            UpdateCommand="UPDATE [AccHead] SET  [Description] = @Description, [Symbol] = @Symbol, [Abbrivation] = @Abbrivation WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="Abbrivation" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Category" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="Abbrivation" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top" height="25">
                <asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        </tr>
        </table>
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

