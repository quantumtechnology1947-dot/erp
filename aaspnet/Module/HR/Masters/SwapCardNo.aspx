<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_SwapCard_No, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
            <td align="left">
                <table cellpadding="0" cellspacing="0" style="width: 400px" >
                    <tr>
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;SwapCard No</b></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" DataKeyNames="Id" 
                                DataSourceID="SqlDataSource1" Width="100%" 
                                onrowcommand="GridView1_RowCommand" onrowdeleted="GridView1_RowDeleted" 
                                onrowupdated="GridView1_RowUpdated" ShowFooter="True" PageSize="20" 
                                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound">
                                <PagerSettings PageButtonCount="40" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="4%" />
                                        <FooterTemplate>
                                        <asp:Button ID="btnInsert" ValidationGroup="abc" runat="server" CommandName="Add" OnClientClick=" return confirmationAdd()"  CssClass="redbox"  Text="Insert" />
                                    </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField  ButtonType="Link" ValidationGroup="A" ShowEditButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    </asp:CommandField>
                                      <asp:CommandField ButtonType="Link" ShowDeleteButton="True" >
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="SwapCard No">
                                        <ItemStyle Width="30%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                        <asp:Label ID="lblSwapCardNo" runat="server" Text='<%#Eval("SwapCardNo") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="lblSwapCardNo0" runat="server" Width="200" CssClass="box3" Text='<%#Bind("SwapCardNo") %>'>
                                        </asp:TextBox>
                                          <asp:RequiredFieldValidator ID="ReqSwapCard0" ValidationGroup="A" runat="server" ErrorMessage="*" ControlToValidate="lblSwapCardNo0"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtSwapCardNo" runat="server"  Width="200" CssClass="box3">
                                        </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqSwapCard" ValidationGroup="abc" runat="server" ErrorMessage="*" ControlToValidate="txtSwapCardNo"></asp:RequiredFieldValidator>
                                        
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                 
                                </Columns>
                                
                                <EmptyDataTemplate>
                                <asp:Button ID="btnInsert" runat="server" ValidationGroup="pqr" OnClientClick=" return confirmationAdd()"  CommandName="Add1"  CssClass="redbox"  Text="Insert" />
                                <asp:TextBox ID="txtSwapCardNo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqSwapCard0" ValidationGroup="pqr" runat="server" ErrorMessage="*" ControlToValidate="txtSwapCardNo"></asp:RequiredFieldValidator>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblHR_SwapCard] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [tblHR_SwapCard] ([SwapCardNo]) VALUES (@SwapCardNo)" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [Id], [SwapCardNo] FROM [tblHR_SwapCard] ORDER BY [Id] DESC" 
                                
                                UpdateCommand="UPDATE [tblHR_SwapCard] SET [SwapCardNo] = @SwapCardNo WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="SwapCardNo" Type="String" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="SwapCardNo" Type="String" />
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

