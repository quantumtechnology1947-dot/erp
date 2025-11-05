<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_ECNReasonTypes, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
<table width="100%" >
        <tr>
            <td align="center">
                <table cellpadding="0" cellspacing="0" width="500">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                            &nbsp;ECN Reasons</b>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                ShowFooter="True" DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView2_RowDeleted" 
                DataSourceID="SqlDataSource1"
              OnRowUpdated="GridView2_RowUpdated" 
              OnRowCommand="GridView2_RowCommand" CssClass="yui-datatable-theme" 
                                onrowdatabound="GridView2_RowDataBound" PageSize="20" Width="100%">
<FooterStyle Wrap="True"></FooterStyle>
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                     <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %> 
                                        </ItemTemplate>
                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                        <asp:Label ID="lblID0" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True" >
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Description">
                                     <ItemTemplate>
                                    <asp:Label ID="lblTypes" runat="server" Text='<%#Eval("Types") %>'></asp:Label>
                                </ItemTemplate>
                                     <EditItemTemplate>
                                    <asp:TextBox ID="txtTypes" runat="server" Width="98%" Text='<%#Bind("Types") %>'>
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req4" runat="server" Text="*" 
                                             ControlToValidate="txtTypes" ValidationGroup="C" ></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="80%" />
                                    <FooterTemplate>                        
                                    <asp:TextBox ID="txtTypes" runat="server" Width="50%" CssClass="box3">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="req5" runat="server"  ControlToValidate="txtTypes" 
                                            Text="*"  ValidationGroup="A" ></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:Button ID="btnInsert1" runat="server" CommandName="Add" OnClientClick="return confirmationAdd()" ValidationGroup="A" CssClass="redbox" Text="Insert" /> </FooterTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                           <table  width="100%" border="1" class="fontcss" style="border-color:Silver">                                   
                                    <tr>
                                        
                            <td>
                            <asp:TextBox ID="txtTypes0" runat="server" Width="50%" CssClass="box3">
                                        </asp:TextBox>&nbsp;<asp:Button ID="btnInsert0" runat="server" CommandName="Add1" ValidationGroup="B" 
                                                OnClientClick="return confirmationAdd()" CssClass="redbox" Text="Insert" />
                                        <asp:RequiredFieldValidator ID="req3" runat="server"  
                                    ControlToValidate="txtTypes0" Text="*"  ValidationGroup="B" ></asp:RequiredFieldValidator></td>
                                    </tr>
                                    </table>
        </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblDG_ECN_Reason] WHERE [Id] = @Id AND [CompId]= @CompId" 
                    InsertCommand="INSERT INTO [tblDG_ECN_Reason] ([CompId],[Types]) VALUES (@CompId,@Types)" 
                    SelectCommand="SELECT [Id], [Types] FROM [tblDG_ECN_Reason] Where CompId=@CompId ORDER BY [Id] ASC" 
                    ProviderName="System.Data.SqlClient"
                    UpdateCommand="UPDATE [tblDG_ECN_Reason] SET [Types] = @Types WHERE [Id] = @Id And [CompId]= @CompId ">
                    
                    <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                        <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32"/>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Types" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                       <asp:Parameter Name="CompId" Type="int32" />
                    </UpdateParameters>
                    <InsertParameters>
                       <asp:Parameter Name="Types" Type="String" />
                       <asp:Parameter Name="CompId" Type="int32" />
                    </InsertParameters>
                    </asp:SqlDataSource>
                &nbsp;<asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        
        <tr>
        <td>
            &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

