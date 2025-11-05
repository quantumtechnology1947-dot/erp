<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_ReleaseWIS_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Release WO for WIS</b></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="70%" 
             
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>                        
                       
                           
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Fin Year">
                            <ItemTemplate>
                            <asp:Label ID="lblyear" runat="server" Text='<%#Eval("FinYear") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WO No">
                            <ItemTemplate>
                            <asp:Label ID="lblwono" runat="server" Text='<%#Eval("WONo") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Rel Date">
                            <ItemTemplate>
                            <asp:Label ID="lblreldate" runat="server" Text='<%#Eval("ReleaseSysDate") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rel Time">
                         <ItemTemplate>
                            <asp:Label ID="lblreltime" runat="server" Text='<%#Eval("ReleaseSysTime") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Release By">
                         <ItemTemplate>
                            <asp:Label ID="lblrelby" runat="server" Text='<%#Eval("GenBy") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="50%"/>
                        </asp:TemplateField>
                      
                    </Columns>
                    <EmptyDataTemplate>
                                    <table width="100%" class="fontcss"><tr><td align="center" >
                                    <asp:Label ID="Label1" runat="server"  Text="No  data found to display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                    
                    
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="25">
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    onclick="Button1_Click" Text="Cancel" />
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

