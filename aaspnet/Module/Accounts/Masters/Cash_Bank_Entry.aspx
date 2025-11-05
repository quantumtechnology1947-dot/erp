<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Masters_Cash_Bank_Entry, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        </style>
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
 <table align="center" cellpadding="0" cellspacing="0"
        width="100%">
         <tr>
                        <td align="left" valign="middle"  scope="col" 
                style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21">
        &nbsp;<b>Cash / Bank Entry </b></td>
                    </tr>
                    <tr>
                    <td>

    <table class="style3">
        <tr>
            <td width="50%" align="center" headers="20px">
                <b>Cash Entry</b></td>
            <td height="20px" width="50%" align="center">
                <b>Bank Entry</b></td>
        </tr>
        <tr>
            <td>
                <table class="style3">
                    <tr>
                        <td valign="middle" width="5%" align="right">
                            <b>Amount:</b>
                            <asp:TextBox ID="txtCashAmt" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValtxtCashAmt" runat="server" 
                                    ControlToValidate="txtCashAmt" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularReqAmt" runat="server" 
                                    ControlToValidate="txtCashAmt" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                            &nbsp;<asp:Button ID="btnAdd" runat="server" CssClass="redbox" onclick="btnAdd_Click" OnClientClick=" return confirmationAdd()"
                                Text="Add" ValidationGroup="A" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                 <table class="style3">
                    <tr>
                        <td valign="bottom" width="50%" align="left">
                            <asp:Label ID="lblBank" runat="server" style="font-weight: 700" 
                                Text="Bank Name :"></asp:Label>
                            
                            <asp:DropDownList ID="DrpBankName" runat="server" DataSourceID="SqlDataSource3" 
                                DataTextField="Name" DataValueField="Id">
                            </asp:DropDownList>
                            
                        </td>
                        <td valign="bottom" align="left">
                            <b style="text-align: left">
                            Amount:</b>
                            <asp:TextBox ID="txtBankAmt" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldtxtBankAmt" runat="server" 
                                    ControlToValidate="txtBankAmt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressiontxtBankAmt" runat="server" 
                                    ControlToValidate="txtBankAmt" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                            &nbsp;<asp:Button ID="btnBankAdd" runat="server" CssClass="redbox" 
                                 OnClientClick=" return confirmationAdd()"
                                Text="Add" ValidationGroup="B" onclick="btnBankAdd_Click" />
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="Panel1" runat="server" Height="405px" 
                    ScrollBars="Auto">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Id" DataSourceID="SqlDataSource1" 
                        CssClass="yui-datatable-theme" Width="100%" 
                        onrowupdating="GridView2_RowUpdating">
                        <Columns>
                                                       
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" >
                            
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Id" Visible="False" />
                            <asp:TemplateField HeaderText="Date" SortExpression="SysDate">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("SysDate") %>'></asp:Label>
                                </ItemTemplate>                               
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" SortExpression="SysTime">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SysTime") %>'></asp:Label>
                                </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SessionId" HeaderText="SessionId" 
                                SortExpression="SessionId" Visible="False" />
                            <asp:BoundField DataField="CompId" HeaderText="CompId" 
                                SortExpression="CompId" Visible="False" />
                            <asp:BoundField DataField="FinYearId" HeaderText="FinYearId" 
                                SortExpression="FinYearId" Visible="False" />
                            <asp:TemplateField HeaderText="Amount" SortExpression="Amt">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Amt") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Amt") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:TemplateField>
                        </Columns>
                         <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                    <FooterStyle Wrap="True">
                    </FooterStyle>
                    </asp:GridView>
                </asp:Panel>
            </td>
             <td align="center">            
            
                <asp:Panel ID="Panel2" runat="server" Height="405px" 
                    ScrollBars="Auto">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Id" 
                        CssClass="yui-datatable-theme" Width="100%" 
                        onrowupdating="GridView1_RowUpdating" onrowediting="GridView1_RowEditing" 
                        onrowdeleting="GridView1_RowDeleting" 
                        onrowcancelingedit="GridView1_RowCancelingEdit">
                        <Columns>
                                                       
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" >                           
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:CommandField>
                            
                            
                            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Id" Visible="False" />
                            <asp:TemplateField HeaderText="Date" SortExpression="SysDate">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("SysDate") %>'></asp:Label>
                                </ItemTemplate>                               
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" SortExpression="SysTime">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("SysTime") %>'></asp:Label>
                                </ItemTemplate>
                              
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BankName" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblBank" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate> 
                                <asp:Label ID="lblBankId" runat="server" Visible="false" Text='<%# Bind("BankId") %>'></asp:Label>                               
                                <asp:DropDownList ID="DrpBankNameE"  runat="server" DataSourceID="SqlDataSource3" 
                                DataTextField="Name"  DataValueField="Id">
                                </asp:DropDownList>                                
                                </EditItemTemplate>                              
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="SessionId" HeaderText="SessionId" 
                                SortExpression="SessionId" Visible="False" />
                            <asp:BoundField DataField="CompId" HeaderText="CompId" 
                                SortExpression="CompId" Visible="False" />
                            <asp:BoundField DataField="FinYearId" HeaderText="FinYearId" 
                                SortExpression="FinYearId" Visible="False" />
                            <asp:TemplateField HeaderText="Amount" SortExpression="Amt">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Amt") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Amt") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="6%" />
                            </asp:TemplateField>
                        </Columns>
                         <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                    <FooterStyle Wrap="True">
                    </FooterStyle>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"    
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                    SelectCommand="SELECT [Id],REPLACE(CONVERT(varchar, CONVERT(datetime, SUBSTRING( [tblACC_CashAmt_Master].SysDate , CHARINDEX('-',[tblACC_CashAmt_Master].SysDate ) + 1, 2) + '-' + LEFT([tblACC_CashAmt_Master].SysDate,CHARINDEX('-',[tblACC_CashAmt_Master].SysDate) - 1) + '-' + RIGHT([tblACC_CashAmt_Master].SysDate, CHARINDEX('-', REVERSE([tblACC_CashAmt_Master].SysDate)) - 1)), 103), '/', '-') AS  SysDate ,[SysTime],[SessionId],[CompId],[FinYearId],[Amt] FROM [tblACC_CashAmt_Master] Order by Id Desc" 
                    ConflictDetection="OverwriteChanges"
                    DeleteCommand="DELETE FROM [tblACC_CashAmt_Master] WHERE [Id] = @Id " 
                   
                    UpdateCommand="UPDATE [tblACC_CashAmt_Master] SET [SessionId] = @SessionId, [CompId] = @CompId, [FinYearId] = @FinYearId, [Amt] = @Amt WHERE [Id] = @Id ">
                    <DeleteParameters>
                        <asp:Parameter Name="Id" Type="Int32" />
                        
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="SysDate"  Type="String" />
                        <asp:Parameter Name="SysTime" Type="String" />
                       <asp:SessionParameter Name="SessionId" SessionField="username" Type="String"/>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32"/>
                        <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32"/>
                        <asp:Parameter Name="Amt" Type="Double" />
                        <asp:Parameter Name="Id" Type="Int32" />
                    </UpdateParameters>
                   
                </asp:SqlDataSource>
            </td>
            <td>                
                 <b>
                 <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                   ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
                     ProviderName="System.Data.SqlClient" 
                     SelectCommand="SELECT [Id], [Name] FROM [tblACC_Bank] where [Id]!=4"></asp:SqlDataSource>
                 </b>
                </td>
        </tr>
    </table>
    </td></tr>
     </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

