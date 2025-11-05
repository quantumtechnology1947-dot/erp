<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_WIS_Dry_Actual_Run, newerp_deploy" title="ERP" theme="Default" %>

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

   <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate> 
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;WIS Dry/Actual Run</b></td>
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
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="17">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>                        
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:Button  ID="btnRun" CommandName="add" runat="server"  Text="Dry Run" CssClass="redbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />                        
                        </asp:TemplateField> 
                           <asp:TemplateField>
                        <ItemTemplate>
                        <asp:DropDownList ID="drpIssueShortage" runat="server">
                        <asp:ListItem Text="Transaction wise Issue" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Issue List" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Shortage List" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                       
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:Button  ID="btnView" CommandName="view" runat="server"  Text="View" CssClass="redbox" />
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
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
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("SysDate") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Title">
                            <ItemTemplate>
                            <asp:Label ID="lblprjtitle" runat="server" Text='<%#Eval("PrjTitle") %>'  />
                            </ItemTemplate>
                            <ItemStyle Width="70%" HorizontalAlign="Left" />
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
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

