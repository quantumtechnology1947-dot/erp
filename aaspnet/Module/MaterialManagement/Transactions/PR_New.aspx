<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PR_New, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
     <table cellpadding="0" cellspacing="0" width="100%" align="center">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PR - New</b></td>
        </tr>
         <tr>
            <td height="25">&nbsp;<asp:Label ID="Label2" runat="server" Text="WO No"></asp:Label>
                :&nbsp;<asp:TextBox ID="TxtWONo" runat="server" CssClass="box3"></asp:TextBox>
&nbsp; 
                    
                   <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" 
                    Text="Search" />
            
            </td>
            </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" Width="800px" 
                    CssClass="yui-datatable-theme" onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                                                </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1"  CommandName="Select" runat="server">Select</asp:LinkButton>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WO No">
                        <ItemTemplate>
                        <asp:Label ID="lblwono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Title">
                            <ItemStyle HorizontalAlign="Left" Width="60%" />
                            <ItemTemplate>
                        <asp:Label ID="lblpt" runat="server" Text='<%# Eval("ProjectTitle") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                     <%--   <asp:TemplateField HeaderText="Total Finish" Visible="False">
                        <ItemTemplate>
                        
                        <asp:LinkButton ID="lblfin" runat="server" Text='<%# Eval("TotFinish") %>' CommandName="fin"></asp:LinkButton>
                        <asp:Label ID="lbltotfin" runat="server" Text='<%# Eval("TotFinish") %>'></asp:Label>
                        
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Component" Visible="False">
                        <ItemTemplate>
                        <asp:LinkButton ID="lblco" runat="server" Text='<%# Eval("TotComp") %>' CommandName="comp"></asp:LinkButton>
                         <asp:Label ID="lblcomp" runat="server" Text='<%# Eval("TotComp") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Process" Visible="False">
                        <ItemTemplate>
                        <asp:LinkButton ID="lblpro" runat="server" Text='<%# Eval("TotProc") %>' CommandName="pro"></asp:LinkButton>
                        <asp:Label ID="lblproc" runat="server" Text='<%# Eval("TotProc") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                        
                        <asp:TemplateField HeaderText="WIS">
                        <ItemTemplate>                        
                        <asp:Label ID="lblrel" runat="server" Text='<%# Eval("Release") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WIS Run">
                        <ItemTemplate>                        
                        <asp:Label ID="lblrun" runat="server" Text='<%# Eval("Run") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
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
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

