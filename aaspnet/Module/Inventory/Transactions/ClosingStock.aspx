<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_ClosingStock, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Closing Stock</b></td>
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
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                Width="100%" PageSize="22">

                    <Columns>

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
                        
                        
                       <asp:CommandField ButtonType ="Link" ShowDeleteButton="True"   >

                           <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:CommandField>

                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="From">
                        <ItemTemplate>
                        <asp:Label ID="lblFrom" runat="server" Text='<%#Eval("FromDt") %>'>    </asp:Label>
                        </ItemTemplate>                       
                        <FooterTemplate>
                        <asp:TextBox ID="txtFrom" Width="100" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqFrom" runat="server" ControlToValidate="txtFrom" ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <cc1:CalendarExtender ID="txtFrom_CalendarExtender4" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFrom">
                </cc1:CalendarExtender>       
                        </FooterTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="To">
                        <ItemTemplate>
                        <asp:Label ID="lblTo" runat="server" Text='<%#Eval("ToDt") %>'>    </asp:Label>
                        </ItemTemplate>                       
                        <FooterTemplate>
                        <asp:TextBox ID="txtTo" Width="100" runat="server" CssClass="box3">
                        </asp:TextBox> 
                        <cc1:CalendarExtender ID="txtFrom_CalendarExtender3" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtTo">
                </cc1:CalendarExtender>        
                         <asp:RequiredFieldValidator ID="ReqTo" runat="server" ControlToValidate="txtTo" ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>                       
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="Closing Stock">
                            <ItemStyle HorizontalAlign="Right" />
                            <ItemTemplate>
                            <asp:Label ID="lblClStk" runat="server" Text='<%#Eval("ClStock") %>'></asp:Label></ItemTemplate>                      
                            <FooterTemplate>
                            <asp:TextBox ID="txtClStk" Width="100" runat="server" CssClass="box3">
                        </asp:TextBox> 
                         <asp:RequiredFieldValidator ID="ReqClStk" runat="server" ControlToValidate="txtClStk" ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>     
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                    </Columns>

<FooterStyle Wrap="True"></FooterStyle>
             <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray"  CssClass="yui-datatable-theme" >
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="From"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="To"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Closing Stock"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                </td>
                
                <td>
                <asp:TextBox ID="txtFrom" runat="server" ></asp:TextBox>
                 <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFrom">
                </cc1:CalendarExtender>                
                </td>
                <td>
                <asp:TextBox ID="txtTo" runat="server" ></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtTo">
                </cc1:CalendarExtender>
                </td>
                <td>
                <asp:TextBox ID="txtClStk" runat="server" ></asp:TextBox>
             
                </td>
                </tr>
                </table>
                
            </EmptyDataTemplate>                    
            </asp:GridView>               
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    DeleteCommand="DELETE FROM [tblInv_ClosingStck] WHERE [Id] = @Id" 
                    InsertCommand="INSERT INTO [tblInv_ClosingStck] ([FromDt], [ToDt],[ClStock]) VALUES (@FromDt, @ToDt,@Stock)" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [tblInv_ClosingStck] order by [Id] desc">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                    </DeleteParameters>                    
                    <InsertParameters>
                        <asp:Parameter Name="FromDt" Type="String"/>
                        <asp:Parameter Name="ToDt" Type="String" />
                        <asp:Parameter Name="Stock" Type="Double" />
                    </InsertParameters>
                </asp:SqlDataSource>
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>                       </td>
        </tr>
        </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

