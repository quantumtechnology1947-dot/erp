<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Customers_Dashboard, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            color: red;
            font-weight: bold;
            font-size: large;
        }
        .style4
        {
            text-align: center;
        }
        .style5
        {
            font-weight: bold;
        }
.box3 {
border: 1px solid #C5C5C5;

}

.redbox 
{
	font-family: Verdana, Arial, Helvetica, sans-serif; 
    color: #FFFFFF;
	font-size: 11px; background-color:#FF0000;
	border: 1px solid #FD80FA;
	height: 19px;
}

        .style6
        {
            font-weight: bold;
            font-size: small;
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
    <table cellpadding="0" cellspacing="0" class="fontcss" width="100%">
        <tr>
            <td class="style4" height="30">
                &nbsp;<asp:Label ID="Label3" runat="server" CssClass="style5" Text="Welcome"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" CssClass="style3"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4" height="25">
                <asp:Label ID="lblTitle" runat="server" CssClass="style6"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="style2">
                    <tr>
                        <td valign="top" align="center">
                            <asp:Panel ID="Panel2" runat="server" Height="420px" ScrollBars="Auto" 
                                Direction="LeftToRight" HorizontalAlign="Left" Width="100%">
                                <asp:GridView ID="GridView3" runat="server" 
                        AutoGenerateColumns="False" 
    CssClass="yui-datatable-theme" DataKeyNames="Id" PageSize="23" 
    Width="100%" onrowcommand="GridView3_RowCommand">
                                    <Columns>
                                        <asp:TemplateField 
                                HeaderText="SN">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1  %>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Size="10pt" />
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId0" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                            </ItemTemplate>
                                           
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Date" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblPLNDate" runat="server" Text='<%# Bind("PLNDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Time">
                                <ItemTemplate>
                                <asp:Label runat="server" ID="lbltime" Text='<%#Eval("Time") %>'></asp:Label>
                                </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="9%" VerticalAlign="Top" />
                            </asp:TemplateField>
                                       <asp:TemplateField HeaderText="File" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                                        </ItemTemplate>           
                                        <ItemStyle HorizontalAlign="left" Width="25%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Mail To">
                                <ItemTemplate>                                
                                <asp:Label runat="server" ID="lblmailTo" Text='<%#Eval("MailTo") %>'></asp:Label>
                                </ItemTemplate>
                               
                                    <ItemStyle HorizontalAlign="Left" Width="12%" VerticalAlign="Top" />
                            </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Message">
                                <ItemTemplate>                                
                                <asp:Label runat="server" ID="lblmsg" Text='<%#Eval("msg") %>'></asp:Label>
                                </ItemTemplate>                                
                                    <ItemStyle HorizontalAlign="Left" Width="20%" VerticalAlign="Top" />
                              </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>                                
                                <asp:Label runat="server" ID="lblrks" Text='<%#Eval("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:TextBox runat="server" ID="txtRemarks" CssClass="box3" Width="99%"></asp:TextBox>
                                </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="25%" VerticalAlign="Top" />
                            </asp:TemplateField>
                                        
                                    </Columns>
                                   
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

