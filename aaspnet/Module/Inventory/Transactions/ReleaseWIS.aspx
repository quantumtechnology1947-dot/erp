<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_ReleaseWIS, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    

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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Release WO for WIS</b></td>
        </tr>
        
        <tr>
            <td height="28px">
            
            
                &nbsp;&nbsp;
                <asp:DropDownList ID="DrpWOType" runat="server" AutoPostBack="True" 
                    CssClass="box3" onselectedindexchanged="DrpWOType_SelectedIndexChanged">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WONo &nbsp;<asp:TextBox ID="TxtWONo" 
                    runat="server" CssClass="box3"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    onclick="Button1_Click" Text="Search" />
            
            
            </td>
            
            </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>                        
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:Button  ID="btnRelease" CommandName="add" runat="server"  Text="Release" CssClass="redbox" />
                             <asp:Button ID="btnstop" CommandName="stp" runat="server" Text="Stop" CssClass="redbox" Visible="false" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />                        
                        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WO No">
                            <ItemTemplate>
                            <asp:Label ID="lblwono" runat="server" Text='<%#Eval("WONo") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("SysDate") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Title">
                            <ItemTemplate>
                            <asp:Label ID="lblprjtitle" runat="server" Text='<%#Eval("PrjTitle") %>'  />
                            </ItemTemplate>
                            <ItemStyle Width="40%" HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rel Count">
                        <ItemTemplate>
                        <asp:LinkButton ID="btncnt" runat="server" CommandName="Sel"  Text='<%#Eval("counts") %>'></asp:LinkButton>     </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rel Date">
                            <ItemTemplate>
                            <asp:Label ID="lblreldate" runat="server" Text='<%#Eval("ReleaseDate") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rel Time">
                         <ItemTemplate>
                            <asp:Label ID="lblreltime" runat="server" Text='<%#Eval("ReleaseTime") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Release By">
                         <ItemTemplate>
                            <asp:Label ID="lblrelby" runat="server" Text='<%#Eval("ReleaseBy") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ReleaseWIS" Visible="false">
                         <ItemTemplate>
                            <asp:Label ID="lblrelwis" runat="server" Text='<%#Eval("ReleaseWIS") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25%"/>
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
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

