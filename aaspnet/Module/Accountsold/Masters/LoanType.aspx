<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoanType.aspx.cs" Inherits="Module_Accounts_Masters_LoanType" Title="ERP" Theme="Default"  %>

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
    <table cellpadding="0" cellspacing="0" width="50%" align="center">
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite">
            <b>&nbsp;Loan Type</b></td>
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
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                    Width="100%" PageSize="22" onrowupdating="GridView1_RowUpdating">

                    <Columns>

                      <%--  <asp:CommandField   ButtonType="Link" ShowDeleteButton="True" ShowEditButton="True" />--%>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btnInsert" runat="server" CommandName="Add" ValidationGroup="Ins" OnClientClick=" return confirmationAdd() " CssClass="redbox" 
                                    Text="Insert" />
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                      <asp:CommandField    ButtonType ="Link" ShowEditButton="True" 
                            ValidationGroup="up" >
                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                       <asp:CommandField    ButtonType ="Link" ShowDeleteButton="True"   >

                           <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:CommandField>

                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Loan Type" SortExpression="Description">
                        <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="95%" ID="txtDescription0" runat="server" Text='<%#Bind("Description") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqtxtDescription0" runat="server" ControlToValidate="txtDescription0" 
                        ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtDescription1" Width="95%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqtxtDescription1" runat="server" ControlToValidate="txtDescription1" 
                            ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        
                            <ItemStyle Width="60%" />
                        </asp:TemplateField>
                        
                    </Columns>

<FooterStyle Wrap="True"></FooterStyle>





             <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center" >
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" 
                        runat="server" Text="Loan Type"></asp:Label></td>
    
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" ValidationGroup="Ins1"
                 OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                </td>
                
                <td>
                <asp:TextBox ID="txtDescription" runat="server" Width="85%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqtxtDescription" runat="server" ControlToValidate="txtDescription" 
                            ValidationGroup="Ins1" ErrorMessage="*">
                            
                            </asp:RequiredFieldValidator>
                </td>
 
                </tr>
                </table>
                
            </EmptyDataTemplate>                    
            </asp:GridView>               
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>               
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblACC_LoanType] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblACC_LoanType] ([Description]) VALUES (@Description)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [tblACC_LoanType] order by [Id] desc" 
                    UpdateCommand="UPDATE [tblACC_LoanType] SET [Description] = @Description WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Description" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="Description" Type="String"/>                      
                    </InsertParameters>
                </asp:SqlDataSource>
               </td>
        </tr>
        </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

