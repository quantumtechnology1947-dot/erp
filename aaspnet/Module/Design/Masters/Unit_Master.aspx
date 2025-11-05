<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysAdmin_Unit_Master, newerp_deploy" title="ERP" theme="Default" %>

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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Unit Master</b></td>
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
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Name" SortExpression="Unit Name">
                        <ItemTemplate>
                        <asp:Label ID="lblUnitName" runat="server" Text='<%#Eval("UnitName") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="90%" ID="lblUnitName0" runat="server" Text='<%#Bind("UnitName") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqUNEdit" runat="server" ControlToValidate="lblUnitName0" ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtUnitName" Width="90%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqUnitNm" runat="server" ControlToValidate="txtUnitName" ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblAbbrivation" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="lblAbbrivation0" Width="92%" CssClass="box3" runat="server" Text='<%#Bind("Symbol") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqabbrvEdit" runat="server" ControlToValidate="lblAbbrivation0" ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtAbb" Width="95%" runat="server" CssClass="box3">
                        </asp:TextBox> 
                         <asp:RequiredFieldValidator ID="ReqAbb" runat="server" ControlToValidate="txtAbb" ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>                       
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Effect On Invoice">
                            <ItemStyle HorizontalAlign="Center" Width="18%" />
                            <ItemTemplate>
                            <asp:Label ID="lblEffInv" runat="server" Text='<%#Eval("EffectOnInvoice") %>'>    </asp:Label></ItemTemplate>
                        <EditItemTemplate>
                        <asp:CheckBox ID="txtEffInv00" runat="server"></asp:CheckBox>
                        </EditItemTemplate>
                        
                            <FooterTemplate>
                            <asp:CheckBox ID="txtEffInv" runat="server"></asp:CheckBox>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>

<FooterStyle Wrap="True"></FooterStyle>
             <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Unit Name"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Symbol"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Effect On Invoice"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                </td>
                
                <td>
                <asp:TextBox ID="txtUnitName" runat="server" Width="200"></asp:TextBox>
                
                </td>
                <td>
                <asp:TextBox ID="txtAbb" runat="server" Width="127"></asp:TextBox>
                </td>
                <td>
                <asp:CheckBox ID="txtEffInv0" runat="server"></asp:CheckBox>
                </td>
                </tr>
                </table>
                
            </EmptyDataTemplate>                    
            </asp:GridView>               
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>               
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [Unit_Master] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [Unit_Master] ([UnitName], [Symbol],[EffectOnInvoice]) VALUES (@UnitName, @Symbol,@EffInv)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [Unit_Master] order by [Id] desc" 
                    UpdateCommand="UPDATE [Unit_Master] SET [UnitName] = @UnitName, [Symbol] = @Symbol,[EffectOnInvoice]=@EffInv WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="UnitName" Type="String" />
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="EffInv" Type="Int32" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="UnitName" Type="String"/>
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="EffInv" Type="Int32" />
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

