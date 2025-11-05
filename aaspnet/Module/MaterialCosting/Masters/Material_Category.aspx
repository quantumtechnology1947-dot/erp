<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialCosting_Material_Category, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 14px;
            font-weight: bold;
        }
        .style3
        {
            height: 29px;
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

<table cellpadding="0" cellspacing="0" width="40%" align="center">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" align="center" style="width: 100%">
        
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Category</b>
                &nbsp;</td>
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
                CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound">
                    
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                        <asp:CommandField  ButtonType="Link" ShowEditButton="True" />
                        <asp:CommandField ButtonType="Link" ShowDeleteButton="True"  />
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btnInsert" runat="server"   OnClientClick=" return confirmationAdd()"  ValidationGroup="abc" CommandName="Add" CssClass="redbox" 
                                    Text="Insert" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">                            
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Material Name"  SortExpression="Name of Material">
                        <ItemTemplate>
                        <asp:Label ID="lblMaterial" runat="server" Text='<%#Eval("Material") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtMaterial1" runat="server" Text='<%#Bind("Material") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqMaterial1" ControlToValidate="txtMaterial1" 
                         runat="server" ErrorMessage="*">
                       </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtMaterial" runat="server" CssClass="box3" Width="93%">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqMaterial" ControlToValidate="txtMaterial" ValidationGroup="abc"
                         runat="server" ErrorMessage="*">
                       </asp:RequiredFieldValidator>                        
                        </FooterTemplate>
                         <ItemStyle HorizontalAlign="Left" Width="55%" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Unit" SortExpression="Unit">
                        <ItemTemplate>
                        <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("Unit") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:DropDownList ID ="ddUnit1" runat ="server" DataSourceID="SqlDataSource1" DataTextField="Symbol" DataValueField="Id" >
                                            
                        </asp:DropDownList>
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:DropDownList ID ="ddUnit" runat ="server" DataSourceID="SqlDataSource1" DataTextField="Symbol" DataValueField="Id" >
                                            
                        </asp:DropDownList>
                        </FooterTemplate>
                        </asp:TemplateField>
                   </Columns>
        <EmptyDataTemplate>
        <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Material Name"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Unit"></asp:Label></td>
                         
                    </tr>
                    <tr>
                        <td>
            <asp:Button ID="btnInsert" runat="server" CommandName="Add1" ValidationGroup="pqr" CssClass="redbox" Text="Insert" /></td>
         <td>
            <asp:TextBox ID="txtMaterial" runat="server" CssClass="box3" Width="96%"></asp:TextBox>
             <asp:RequiredFieldValidator ID="ReqMaterial" runat="server" ErrorMessage="*" ValidationGroup="pqr" ControlToValidate="txtMaterial" ></asp:RequiredFieldValidator>
          </td>
          <td>
           <asp:DropDownList ID ="ddUnit" runat ="server" DataSourceID="SqlDataSource1" DataTextField="Symbol" Width="96%" DataValueField="Id" >   </asp:DropDownList>
           </td>
           </tr>
           </table>
        </EmptyDataTemplate>
        
                    
              </asp:GridView>
                
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblDG_Material] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblDG_Material] ([SysDate],[SysTime],[CompId],[FinYearId],[SessionId],[Material], [Unit]) VALUES (@SysDate,@SysTime,@CompId,@FinYearId,@SessionId,@Material, @Unit)" 
                    SelectCommand="Select  tblDg_Material.Id, tblDg_Material.Material,Unit_Master.Symbol as Unit from Unit_Master,tblDg_Material where tblDg_Material.Unit=Unit_Master.Id order by Id Desc" 
                    
                    UpdateCommand="UPDATE [tblDG_Material] SET [SysDate]=@SysDate,[SysTime]=@SysTime,[CompId]=@CompId,[FinYearId]=@FinYearId,[SessionId]=@SessionId, [Material] = @Material, [Unit] = @Unit WHERE [Id] = @Id">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                      <asp:Parameter Name="SysDate" Type="String"/>
                          <asp:Parameter Name="SysTime" Type="String"/>
                             <asp:Parameter Name="CompId" Type="Int32"/>
                                <asp:Parameter Name="FinYearId" Type="Int32"/>
                                   <asp:Parameter Name="SessionId" Type="String"/>
                        <asp:Parameter Name="Material" Type="String" />
                        <asp:Parameter Name="Unit" Type="String" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                          <asp:Parameter Name="SysDate" Type="String"/>
                          <asp:Parameter Name="SysTime" Type="String"/>
                             <asp:Parameter Name="CompId" Type="Int32"/>
                                <asp:Parameter Name="FinYearId" Type="Int32"/>
                       
                       <asp:Parameter Name="SessionId" Type="String"/>
                        <asp:Parameter Name="Material" Type="String"/>
                        <asp:Parameter Name="Unit" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                
             
                
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    SelectCommand="SELECT [Id], [Symbol] FROM [vw_Unit_Master]">
                </asp:SqlDataSource>
                
             
                
               </td>
        </tr>
        <tr>
            <td align="center" valign="top" class="style3">
                <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label></td>
        </tr>
        </table>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

