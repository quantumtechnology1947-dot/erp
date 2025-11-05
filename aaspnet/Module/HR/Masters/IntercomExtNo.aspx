<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_IntercomExtNo, newerp_deploy" title="ERP" theme="Default" %>

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
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Intercom Ext. No</b></td>
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
                                        <asp:Button ID="btnInsert" runat="server" CommandName="Add" OnClientClick=" return confirmationAdd()"  CssClass="redbox"  Text="Insert"  ValidationGroup="abc"/>
                                    </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField  ButtonType="Link" ValidationGroup="A" ShowEditButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    </asp:CommandField>  
                                    <asp:CommandField ButtonType="Link" ShowDeleteButton="True" >
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                    </asp:CommandField> 
                                                                      
                                    <asp:TemplateField HeaderText="Ext.No">
                                       
                                        <ItemTemplate>
                                        <asp:Label ID="lblExtNo" runat="server" Text='<%#Eval("ExtNo") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:TextBox ID="lblExtNo0" runat="server" Width="150px" CssClass="box3" Text='<%#Bind("ExtNo") %>'>
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqExtNo0" ControlToValidate="lblExtNo0" runat="server" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:TextBox ID="txtExtNo" runat="server" Width="150px" CssClass="box3" >
                                        </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqExtNo" ControlToValidate="txtExtNo" runat="server" ErrorMessage="*" ValidationGroup="abc"></asp:RequiredFieldValidator>
                                            
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Left" />
                                         <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <asp:DropDownList ID="ddDepartment0" runat="server" CssClass="box3" DataSourceID="SqlDataSource2" DataTextField="Dept" Width="99%" DataValueField="Id"></asp:DropDownList>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                        <asp:DropDownList ID="ddDepartment" runat="server"  CssClass="box3" DataSourceID="SqlDataSource2" DataTextField="Dept" DataValueField="Id" Width="99%"></asp:DropDownList>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                 
                                </Columns>
                                
                                <EmptyDataTemplate>
                                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd()"  CssClass="redbox" ValidationGroup="pqr"  Text="Insert" />
                                <asp:TextBox ID="txtExtNo" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqExtNo0" ControlToValidate="txtExtNo" runat="server" ErrorMessage="*" ValidationGroup="pqr"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddDepartment" runat="server" DataSourceID="SqlDataSource2" DataTextField="Dept" DataValueField="Id"></asp:DropDownList>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                DeleteCommand="DELETE FROM [tblHR_IntercomExt] WHERE [Id] = @Id" 
                                InsertCommand="INSERT INTO [tblHR_IntercomExt] ([ExtNo], [Department]) VALUES (@ExtNo, @Department)" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [tblHR_IntercomExt].Id, [tblHR_IntercomExt].ExtNo,[tblHR_Departments].Symbol FROM [tblHR_IntercomExt],[tblHR_Departments] Where [tblHR_IntercomExt].Department=[tblHR_Departments].Id ORDER BY [tblHR_IntercomExt].Id DESC" 
                                UpdateCommand="UPDATE [tblHR_IntercomExt] SET [ExtNo] = @ExtNo, [Department] = @Department WHERE [Id] = @Id">
                                <DeleteParameters>
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </DeleteParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="ExtNo" Type="String" />
                                    <asp:Parameter Name="Department" Type="Int32" />
                                    <asp:Parameter Name="Id" Type="Int32" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="ExtNo" Type="String" />
                                    <asp:Parameter Name="Department" Type="Int32" />
                                </InsertParameters>
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [Id],[Symbol] as Dept FROM [tblHR_Departments]"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

