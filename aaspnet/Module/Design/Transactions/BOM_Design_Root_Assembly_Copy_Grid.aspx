<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_BOM_Design_Root_Assembly_Copy_Grid, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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


    <table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21" ><strong>&nbsp;BOM Root Assembly Copy&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WO No From: <asp:Label ID="lblWONoFrm" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;To: <asp:Label runat="server" ID="lblWONo"></asp:Label> </strong></td></tr>
            
            
            <tr>
            <td>
            <cc1:TabContainer ID="TabContainer1" runat="server"  Height="434px" 
                                AutoPostBack="True" 
                                 ActiveTabIndex="0" 
                                 Width="100%" >
                                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="BOM Master" >
                                   
                                    <ContentTemplate>
                                    <table width ="100%" cellpadding="0" cellspacing="0">
             <tr> 
            <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server"   Width="200px" 
                    CssClass="box3"  >
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="tblDG_Item_Master.ItemCode">Assembly No</asp:ListItem>
                    <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>                   
                </asp:DropDownList>
            
                <asp:TextBox ID="txtSearchCustomer" runat="server" Width="350px" 
                    CssClass="box3"></asp:TextBox>
                
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="redbox" onclick="btnSearch_Click"/>&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" onclick="btnCancel_Click" Text="Cancel" />&nbsp;&nbsp;<asp:Label 
                    ID="lblMsg" runat="server" style="color: #FF0000; font-weight: 700;"></asp:Label>
             </td>
             </tr>

             <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Auto" 
                    Width="100%">
                    <asp:GridView ID="SearchGridView1" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                        OnPageIndexChanging="SearchGridView1_PageIndexChanging" 
                        OnRowCommand="SearchGridView1_RowCommand" PageSize="12" ShowFooter="True" 
                        Width="700px">
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="False" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnAdd" runat="server" CommandName="Add" CssClass="redbox" 
                                        OnClientClick=" return confirmationAdd()" Text="Add" />
                                </FooterTemplate>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" 
                                        OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                </HeaderTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Assembly No">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemCode") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="13%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ManfDesc" HeaderText="Description">
                                <ItemStyle Width="40%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UOMBasic" HeaderText="UOM">
                                <ItemStyle HorizontalAlign="Center" Width="9%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qty" HeaderText="Qty">
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Id" runat="server" Text='<%# Bind("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="CId" runat="server" Text='<%# Bind("CId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ItemId" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="ItemId" runat="server" Text='<%# Bind("ItemId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="fontcss" width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                            Text="No data to display !"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:Panel>

    <asp:HiddenField ID="hfSort" runat="server" Value=" " />
        <asp:HiddenField ID="hfSearchText" runat="server" />
        </td>
         </tr>
         </table>
         </ContentTemplate>
         
         </cc1:TabPanel>
         
        
         
         </cc1:TabContainer>
         </td>
         </tr>
         
          </table>
        </td>
        </tr>
     </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

