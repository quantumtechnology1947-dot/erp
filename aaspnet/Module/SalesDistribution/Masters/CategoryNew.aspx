<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Masters_CategoryNew, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
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
    <table cellpadding="0" cellspacing="0" width="100%" align="center">
        
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Category 
                Of Work Order - New </b></td>
        </tr>
        <tr>
            <td align="left" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="CId" 
                FooterStyle-Wrap="True"
                
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" Width="50%" PageSize="17" 
                    onpageindexchanging="GridView1_PageIndexChanging1">
<FooterStyle Wrap="True"></FooterStyle>
                    <Columns >
                        <asp:TemplateField HeaderText="SN" SortExpression="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClientClick=" return confirmationAdd()" ValidationGroup="A"  CommandName="Add" CssClass="redbox"  />
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Id" SortExpression="CId" Visible="False">
                        <ItemTemplate>
                        <asp:Label ID="lblCId" runat="server" Text='<%#Eval("CId") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category" SortExpression="CName">
                        <ItemTemplate>
                        <asp:Label ID="lblCName" runat="server" Text='<%#Eval("CName") %>'>    </asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                        <asp:TextBox ID="txtCName" Width="90%" CssClass="box3" runat="server">
                        </asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqBissNat0" runat="server"  ValidationGroup="A" ControlToValidate="txtCName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Symbol" SortExpression="Symbol">
                        <ItemTemplate>
                        <asp:Label ID="lblAbbrivation" runat="server" Text='<%#Eval("Symbol") %>'>    </asp:Label>
                        </ItemTemplate>                       
                        <FooterTemplate>
                        <asp:TextBox  CssClass="box3" Width="90%" ID="txtAbb" runat="server" MaxLength="1">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqBissNat" runat="server" ValidationGroup="A" ControlToValidate="txtAbb"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="Has SubCategory" Visible ="false">
                        <ItemTemplate>
                        <asp:Label ID="lblsubcatNo" runat="server" Text='<%#Eval("HasSubCat") %>'>    </asp:Label>
                        </ItemTemplate>                       
                        <FooterTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />                        
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                        
                        
                    </Columns>
                    
                    <EmptyDataTemplate>
                    <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="Category"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="Symbol"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Has Sub Cate."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
            <asp:Button ID="btnInsert" runat="server" Text="Insert" CommandName="Add1" 
             OnClientClick=" return confirmationAdd()" ValidationGroup="C" CssClass="redbox"  /></td>
             <td>
            <asp:TextBox ID="txtCName" Width="85%" CssClass="fontcss" runat="server">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqEmptyCat" runat="server"  ValidationGroup="C" ControlToValidate="txtCName"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                        </td>
                        <td>
           <asp:TextBox  CssClass="fontcss" Width="85%" ID="txtAbb" runat="server" MaxLength="1">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqEmptySymb" runat="server" ValidationGroup="C" ControlToValidate="txtAbb"
                           ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                         <asp:CheckBox ID="CheckBox1" runat="server" /> 
                         </td>
                    </tr>
                          </table>

        </EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    
              </asp:GridView>
                
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                
               
               </td>
        </tr>
        </table>
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

