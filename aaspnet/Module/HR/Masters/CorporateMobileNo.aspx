<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_CorporateMobileNo, newerp_deploy" title="ERP" theme="Default" %>

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
                <table cellpadding="0" cellspacing="0" style="width: 500px">
                    <tr>
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Corporate Mobile</b></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"       
                                AutoGenerateColumns="False" DataKeyNames="Id" 
                                DataSourceID="SqlDataSource1" Width="100%" 
                                onrowcommand="GridView1_RowCommand" onrowdeleted="GridView1_RowDeleted" 
                                onrowupdated="GridView1_RowUpdated" ShowFooter="True" 
                                CssClass="yui-datatable-theme" PageSize="20" 
                                onrowdatabound="GridView1_RowDataBound">
                                <PagerSettings PageButtonCount="40" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="4%" />
                                        <FooterTemplate>
                                        <asp:Button ID="btnInsert" runat="server" OnClientClick=" return confirmationAdd()" CommandName="Add" ValidationGroup="abc" CssClass="redbox"  Text="Insert" />
                                    </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField  ButtonType="Link"  ValidationGroup="c" 
                                        ShowEditButton="True" >
                                         <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:CommandField>
                                         <asp:CommandField ShowDeleteButton="True" ButtonType="Link">
                                             <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Mobile No">
                                        <ItemStyle Width="40%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="lblMobileNo0" runat="server" Width="150px" CssClass="box3" Text='<%#Bind("MobileNo") %>'>
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Req1" runat="server" ControlToValidate="lblMobileNo0" ValidationGroup="c" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtMobileNo" runat="server" Width="150px" CssClass="box3"> 
                                        </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqMobNo" runat="server" ControlToValidate="txtMobileNo" ValidationGroup="abc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amt. Limit">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLimitAmt" runat="server" Text='<%#Eval("LimitAmt") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="lblLimitAmt0" runat="server"  Width="150px" CssClass="box3" Text='<%#Bind("LimitAmt") %>'>
                                        </asp:TextBox>
                                         <asp:RequiredFieldValidator ID="Req2" runat="server" ControlToValidate="lblLimitAmt0" ValidationGroup="c" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtLimitAmt" runat="server"  Width="150px" CssClass="box3">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqLimitAmt" runat="server" ControlToValidate="txtLimitAmt" ValidationGroup="abc" ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                <asp:Button ID="btnInsert" runat="server" ValidationGroup="pqr" OnClientClick=" return confirmationAdd()" CommandName="Add1" CssClass="redbox"  Text="Insert" />
                                <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqMobNo0" runat="server" ControlToValidate="txtMobileNo" ValidationGroup="pqr" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtLimitAmt" runat="server" Width="200px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ReqLimitAmt0" runat="server" ControlToValidate="txtLimitAmt" ValidationGroup="pqr" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblHR_CoporateMobileNo] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [tblHR_CoporateMobileNo] ([MobileNo], [LimitAmt]) VALUES (@MobileNo, @LimitAmt)" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [Id], [MobileNo], [LimitAmt] FROM [tblHR_CoporateMobileNo] Order by Id Desc" 
                                UpdateCommand="UPDATE [tblHR_CoporateMobileNo] SET [MobileNo] = @MobileNo, [LimitAmt] = @LimitAmt WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="MobileNo" Type="String" />
                                    <asp:Parameter Name="LimitAmt" Type="Double" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="MobileNo" Type="String" />
                                    <asp:Parameter Name="LimitAmt" Type="Double" />
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

