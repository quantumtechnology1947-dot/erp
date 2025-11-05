<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Currency.aspx.cs" Inherits="Module_Accounts_Masters_Currency" Title="ERP"   Theme="Default" %>

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
    <table cellpadding="0" cellspacing="0" width="300" align="center">
        <tr>
            <td align="left" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp; Currency</b></td>
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
               
                OnRowUpdated="GridView1_RowUpdated"                
                OnRowCommand="GridView1_RowCommand" 
                CssClass="yui-datatable-theme" 
                Width="100%" onrowdatabound="GridView1_RowDataBound" 
                onrowcancelingedit="GridView1_RowCancelingEdit" 
                onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" PageSize="20" 
                    >                  
                    
<FooterStyle Wrap="True">
</FooterStyle>
                    <Columns>
                        <asp:CommandField ButtonType="Link"  ShowEditButton="True" 
                            ValidationGroup="Shree">
                            <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </asp:CommandField>
                <%--        <asp:CommandField  ButtonType="Link" ShowDeleteButton="True"  />--%>
                        
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClientClick=" return confirmationAdd()" 
                        ValidationGroup="abc" CommandName="Add" CssClass="redbox" />
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="Country " SortExpression="CountryName">
                        <ItemTemplate>
                        <asp:DropDownList ID="DrpCountry"  runat="server" DataSourceID="SqlDataSource2" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList>                   
                        </ItemTemplate>
                        <ItemStyle  Width="25%"/>
                        <EditItemTemplate>
                           <asp:DropDownList ID="DrpCountry1" runat="server"  DataSourceID="SqlDataSource2" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList>                     
                        </EditItemTemplate  >
                        
                         <FooterTemplate>
                         <asp:DropDownList ID="DrpCountry2"  runat="server" DataSourceID="SqlDataSource2" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList> 
                        </EditItemTemplate>
                        </FooterTemplate>
                           <FooterStyle Width="25%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Currency" SortExpression="Name">
                        <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtName1" runat="server" Text='<%#Bind("Name") %>'
                        ValidationGroup="Shree" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqDescription0" runat="server" ControlToValidate="txtName1" 
                        ErrorMessage="*" ValidationGroup="Shree">
                        </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtName2" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqDesc" runat="server" ControlToValidate="txtName2" 
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
                        <asp:TextBox ID="txtSymbol2" runat="server" CssClass="box3">
                        </asp:TextBox>                        
                        <asp:RequiredFieldValidator ID="ReqSymb" runat="server" ControlToValidate="txtSymbol2" ErrorMessage="*"
                        ValidationGroup="abc">
                        </asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        
                        <%--<asp:TemplateField HeaderText="Abbrivation" SortExpression="Abbrivation">
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
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Id" Visible="false" SortExpression="Id">
                        <ItemTemplate>
                   <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>
                   </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    
                     <EmptyDataTemplate>
                     
                      <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Country"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text=" Currency Name"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Symbol"></asp:Label>
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd()" 
            CssClass="redbox" ValidationGroup="pqr" Text="Insert" />
            </td>
            <td>
             <asp:DropDownList ID="DrpCountry3" Width="100%" runat="server" DataSourceID="SqlDataSource2" DataValueField="CId" DataTextField="CountryName" ></asp:DropDownList>          </td>
                        <td>
                        <asp:TextBox ID="txtName3" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqDesc0" runat="server" ControlToValidate="txtName3" 
                        ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        <asp:TextBox ID="txtSymbol3" runat="server" CssClass="box3">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqSymb0" runat="server" ControlToValidate="txtSymbol3" ErrorMessage="*" 
                        ValidationGroup="pqr"></asp:RequiredFieldValidator>
                        </td>
                       
                        </tr>
                        </table>
        </EmptyDataTemplate>                    
                    
              </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"  
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT * FROM [tblCountry]"   ></asp:SqlDataSource>
                    
                    
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_Currency_Master] WHERE [Id] = @Id "  
                    InsertCommand="INSERT INTO [tblACC_Currency_Master] ([Country], [Name], [Symbol], ) VALUES (@Country, @Name, @Symbol)" 
                    SelectCommand="SELECT Id, Country, Name, Symbol FROM tblACC_Currency_Master ORDER BY Id DESC"
                 
                    UpdateCommand="UPDATE [tblACC_Currency_Master] SET  [Co] = @Description, [Symbol] = @Symbol, [Abbrivation] = @Abbrivation WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Country" Type="String" />
                        
                        <asp:Parameter Name="Symbol" Type="String" />
                   
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Category" Type="String" />
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                        
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

