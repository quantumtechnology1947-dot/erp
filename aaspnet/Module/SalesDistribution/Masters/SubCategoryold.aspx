<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Masters_SubCategory, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

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
    <table cellpadding="0" cellspacing="0" align="center" style="width: 65%">
        <tr>
            <td align="center" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp; SubCategory</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="SCId" 
                DataSourceID="LocalSqlServer"
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView1_RowDataBound" onrowdeleted="GridView1_RowDeleted" 
                    onrowupdated="GridView1_RowUpdated" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowupdating="GridView1_RowUpdating" PageSize="15"   >
              
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                    <asp:CommandField  Visible="false"  ButtonType="Link" ShowEditButton="True" ValidationGroup="A"  />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Link" />
                                     
                         <asp:TemplateField HeaderText="SN" SortExpression="SN">
                        <ItemTemplate>  <%# Container.DataItemIndex+1 %> </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" OnClientClick="return confirmationAdd()" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCId"   runat="server" Text='<%#Eval("catsy") %>'>    </asp:Label><asp:Label ID="lblCId2"  runat="server" Visible="false" Text='<%#Eval("CId") %>'></asp:Label>
                        </ItemTemplate>
                         <EditItemTemplate>
                         
                                            <asp:DropDownList ID="ddCategory1" Width="85%" AutoPostBack="true" runat="server" DataSourceID="SqlDataSource1" DataTextField="Expr1"  ValidationGroup="A"
                                                DataValueField="CId">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:DropDownList ID="ddCategory"  Width="85%" runat="server" DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="CId">
                        </asp:DropDownList>
                        </FooterTemplate>                        
                            <ItemStyle Width="35%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubCategory" SortExpression="SCName">
                        <ItemTemplate>
                        <asp:Label ID="lblSCName" runat="server" Text='<%#Eval("SCName") %>'>    </asp:Label> <asp:Label ID="lblSCId0" Visible="false" runat="server" Text='<%#Eval("SCId") %>'></asp:Label>
                       </ItemTemplate>
                       <EditItemTemplate>
                      
                       <asp:TextBox ID="txtSCName1" runat="server" ValidationGroup="A" Width="85%" Text='<%#Eval("SCName") %>'></asp:TextBox>
                       <asp:RequiredFieldValidator ID="Req1" runat="server" ValidationGroup="A" ControlToValidate="txtSCName1"       ErrorMessage="*" ></asp:RequiredFieldValidator>
                        </EditItemTemplate>                       
                       
                        <FooterTemplate>
                        <asp:TextBox ID="txtSCName" Width="85%" CssClass="fontcss" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqBissNat" runat="server" ControlToValidate="txtSCName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle Width="45%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                        </ItemTemplate>
                       <EditItemTemplate>
                        <asp:Label ID="lblSymbol1" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                       
                      <%-- <asp:TextBox ID="txtSymbol1" runat="server"  Width="85%" Text='<%#Eval("Symbol") %>' MaxLength="2"></asp:TextBox>--%>
                        <%--<asp:RequiredFieldValidator ID="Req2" runat="server" ValidationGroup="A" ControlToValidate="txtSymbol1"       ErrorMessage="*" ></asp:RequiredFieldValidator>--%>
                       </EditItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtSymbol" Width="85%" CssClass="fontcss" runat="server" MaxLength="1">
                        </asp:TextBox>
                          <asp:RequiredFieldValidator ID="ReqBissNat0" runat="server" ControlToValidate="txtSymbol"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                          <ItemStyle Width="15%" />
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="ScId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblSCId" runat="server" Text='<%#Eval("SCId") %>'>    </asp:Label>
                        </ItemTemplate>                       
                        </asp:TemplateField>
                    </Columns>
                     <EmptyDataTemplate>

            <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add1" OnClientClick="return confirmationAdd()"   CssClass="redbox"  />
            <asp:DropDownList ID="ddCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="CId">
                        </asp:DropDownList>
           <asp:TextBox ID="txtSCName" Width="200" CssClass="fontcss" runat="server">
                        </asp:TextBox>
                         <asp:TextBox ID="txtSymbol"  Width="190" CssClass="fontcss" runat="server">
                        </asp:TextBox>
        </EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    
              </asp:GridView>
              
                <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                      DeleteCommand="DELETE FROM [tblSD_WO_SubCategory] WHERE [SCId] = @SCId" 
                    InsertCommand="INSERT INTO [tblSD_WO_SubCategory] ([CId],[SCName], [Symbol]) VALUES (@CId,@SCName, @Symbol)" 
                    ProviderName="System.Data.SqlClient"
                    SelectCommand="SELECT   [tblSD_WO_SubCategory].[SCId],[tblSD_WO_SubCategory].[CId],[tblSD_WO_SubCategory].SCName,[tblSD_WO_SubCategory].[Symbol],[tblSD_WO_Category].[Symbol] + ' - '+ [tblSD_WO_Category].[CName] as catsy FROM [tblSD_WO_Category],[tblSD_WO_SubCategory] Where [tblSD_WO_Category].[CId]=[tblSD_WO_SubCategory].[CId] order by [tblSD_WO_SubCategory].[SCId] desc"
                     UpdateCommand="UPDATE [tblSD_WO_SubCategory] SET [CId] = @CId, [SCName] = @SCName WHERE [SCId] = @SCId">
      <%-- UpdateCommand="UPDATE [tblSD_WO_SubCategory] SET [CId] = @CId, [SCName] = @SCName, [Symbol] = @Symbol WHERE [SCId] = @SCId"--%>             
                    
                    <DeleteParameters>
                        <asp:Parameter Name="SCId" Type="Int32" />
                    </DeleteParameters>
                     <UpdateParameters>
                                    <asp:Parameter Name="CId" Type="Int32" />
                                    <asp:Parameter Name="SCName" Type="String" />
                                   <%-- <asp:Parameter Name="Symbol" Type="String" />--%>
                                    <asp:Parameter Name="SCId" Type="Int32" />
                                </UpdateParameters>
                    <InsertParameters>
                    <asp:Parameter Name="CId" Type="Int32"/>
                        <asp:Parameter Name="SCName" Type="String"/>
                        <asp:Parameter Name="Symbol" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="select CId,Symbol + ' - ' + CName AS Expr1 from tblSD_WO_Category">
                </asp:SqlDataSource>
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
    </table>
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

