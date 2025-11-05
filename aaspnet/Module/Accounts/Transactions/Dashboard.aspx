<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_Dashboard, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
   
    
    <style type="text/css">
        .style2
        {
            height: 24px;
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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="60%" class="box3">
                    <tr>
                        <td colspan="4" style="background:url(../../../images/hdbg.JPG); height:21px" 
                            class="fontcsswhite" >&nbsp;<b>Status</b></td>
                    </tr>  
                     <tr>
    <td align="left">
     <asp:Panel ID="Panel1" runat="server" Height="470px" 
                    ScrollBars="Auto">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="Id" 
                        CssClass="yui-datatable-theme" Width="100%" 
                        >
                        <Columns>
                                                       
                           
                            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
                                ReadOnly="True" SortExpression="Id" Visible="False" />
                            <asp:TemplateField HeaderText=" " >
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Trans") %>'></asp:Label>
                                </ItemTemplate>                               
                                <ItemStyle HorizontalAlign="left" Width="15%" Font-Bold="true" />
                            </asp:TemplateField>                                                       
                            <asp:TemplateField HeaderText="Opening Amount" SortExpression="OpAmt">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("OpAmt") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Closing Amount" SortExpression="ClAmt">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ClAmt") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle HorizontalAlign="Right" Width="5%" />
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
                    </table>
            </td>
        </tr>
        
       

    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

