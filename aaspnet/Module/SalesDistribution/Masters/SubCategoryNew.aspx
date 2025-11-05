<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Masters_SubCategoryNew, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    <table cellpadding="0" cellspacing="0" align="center" style="width: 100%">
        
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;WO SubCategory - New</b></td>
        </tr>
        <tr>
            <td align="Left" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                PageSize="17"
                AutoGenerateColumns="False" 
                DataKeyNames="CId" 
                DataSourceID="LocalSqlServer"
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="65%">
              
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns>
                    
                         <asp:TemplateField HeaderText="SN" SortExpression="SN">
                        <ItemTemplate>  <%# Container.DataItemIndex+1 %> </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add" OnClientClick="return confirmationAdd()" CssClass="redbox" />
                        </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Category" SortExpression="Category">
                        <ItemTemplate>
                        <asp:Label ID="lblCId" runat="server" Text='<%#Eval("catsy") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:DropDownList ID="ddCategory"  Width="98%" runat="server" CssClass="box3" DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="CId">
                        </asp:DropDownList>
                        </FooterTemplate>                        
                            <ItemStyle Width="35%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubCategory" SortExpression="SCName">
                        <ItemTemplate>
                        <asp:Label ID="lblSCName" runat="server" Text='<%#Eval("SCName") %>'>    </asp:Label>
                       </ItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtSCName" Width="96%" CssClass="box3" runat="server">
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
                       
                        <FooterTemplate>
                        <asp:TextBox ID="txtSymbol" Width="85%" CssClass="box3" runat="server" MaxLength="1">
                        </asp:TextBox>
                          <asp:RequiredFieldValidator ID="ReqBissNat0" runat="server" ControlToValidate="txtSymbol"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                     <EmptyDataTemplate>
                     <table  width="100%" border="1" style="border-color:Silver">
                    <tr>
                    <td></td>
                    <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Category"></asp:Label>
                        </td>
                         <td align="center">
                          <asp:Label ID="Label1" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="SubCategory"></asp:Label>
                        </td>
                         <td align="center">
                          <asp:Label ID="Label2" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Symbol"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="C" CommandName="Add1" OnClientClick="return confirmationAdd()"   CssClass="redbox"  />
            </td>
            <td>
            <asp:DropDownList ID="ddCategory" runat="server" DataSourceID="SqlDataSource1" DataTextField="Expr1" DataValueField="CId">
                        </asp:DropDownList></td>
                        
                        <td>
                       
           <asp:TextBox ID="txtSCName" Width="200" CssClass="fontcss" runat="server">
                        </asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="ReqNm1" runat="server" ValidationGroup="C" ControlToValidate="txtSCName" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                         <asp:TextBox ID="txtSymbol"  Width="190" CssClass="fontcss" MaxLength="1" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="C" ControlToValidate="txtSymbol" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        </tr>                        
                        </table>
        </EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    
              </asp:GridView>
              
              <asp:SqlDataSource ID="LocalSqlServer" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    InsertCommand="INSERT INTO [tblSD_WO_SubCategory] ([CId],[SCName], [Symbol],[CompId],[SysDate],[SysTime],[FinYearId],[SessionId]) VALUES (@CId,@SCName, @Symbol,@CompId,@SysDate,@SysTime,@FinYearId,@SessionId)" 
                    ProviderName="System.Data.SqlClient"
                    SelectCommand="SELECT [tblSD_WO_SubCategory].[CId],[tblSD_WO_SubCategory].SCName,[tblSD_WO_SubCategory].[Symbol],[tblSD_WO_Category].[Symbol] + ' - '+ [tblSD_WO_Category].[CName] as catsy FROM [tblSD_WO_SubCategory],[tblSD_WO_Category] Where [tblSD_WO_SubCategory].[CId]=[tblSD_WO_Category].[CId] And [tblSD_WO_SubCategory].[CompId] = @CompId AND [tblSD_WO_SubCategory].[FinYearId] &lt;= @FinYearId order by [tblSD_WO_SubCategory].[SCId] desc">
                    <InsertParameters>
                    <asp:Parameter Name="CId" Type="Int32"/>
                        <asp:Parameter Name="SCName" Type="String"/>
                        <asp:Parameter Name="Symbol" Type="String" />
                        <asp:Parameter Name="CompId" Type="Int32"/>
                        <asp:Parameter Name="SysDate" Type="String"/>
                        <asp:Parameter Name="SysTime" Type="String" />
                        <asp:Parameter Name="FinYearId" Type="Int32"/>
                        <asp:Parameter Name="SessionId" Type="String"/>
                        
                    </InsertParameters>
                     <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                        <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="select CId,Symbol + ' - ' + CName AS Expr1 from tblSD_WO_Category WHERE (([CompId] = @CompId) AND ([FinYearId] &lt;= @FinYearId) And [HasSubCat]!='0')">
                    <SelectParameters>
                        <asp:SessionParameter Name="CompId" SessionField="compid" Type="Int32" />
                        <asp:SessionParameter Name="FinYearId" SessionField="finyear" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
               </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:Label ID="lblMessage" ForeColor="Red" Font-Bold="true" runat="server" Text=""></asp:Label></td>
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
