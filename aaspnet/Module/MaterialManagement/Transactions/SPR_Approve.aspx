<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SPR_Approve.aspx.cs" Inherits="Module_MaterialManagement_Transactions_SPR_Approve" Title="ERP"  Theme="Default"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            height: 335px;
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">&nbsp;<b>SPR Approve</b></td>
                    </tr>
                    <tr>
                        <td height="25">
                       
                            &nbsp;
                            <asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                onselectedindexchanged="drpfield_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="0">Employee Name</asp:ListItem>
                                <asp:ListItem Value="1">SPR No</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtEmpName" runat="server" CssClass="box3"  Width="350px"></asp:TextBox>
                             
                            <cc1:AutoCompleteExtender ID="txtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtEmpName" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                             
                            &nbsp;<asp:TextBox ID="txtSprNo"  Visible="False" runat="server" CssClass="box3"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Search" />
                        </td>
                        <td height="25" align="center">
                       
                            <asp:Button ID="App" runat="server" CommandName="App" CssClass="redbox" 
                                onclick="App_Click" OnClientClick=" return confirmation()" Text="Approved" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                       
                            <asp:Panel ID="Panel1" runat="server" Height="430px" ScrollBars="Auto">
                                <asp:GridView ID="GridView2" runat="server" 
                                Width="100%" ShowFooter="False" 
    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                                DataKeyNames="Id" onrowcommand="GridView2_RowCommand" 
                                
    onpageindexchanging="GridView2_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField 
                                        HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SPR No" 
                                        ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsprno" runat="server" 
                                                Text='<%# Bind("SPRNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" 
                                                runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fin Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfinyrs" runat="server" Text='<%# Eval("FinYear") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton Text="View" CommandName="view" ID="view" runat="server"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Time" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltime" runat="server"  Text='<%# Bind("Time") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gen. By" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgenby" runat="server"  Text='<%# Bind("GenBy") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Checked" ItemStyle-HorizontalAlign="center">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcheck" runat="server" Text='<%# Bind("CheckedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="For Approved" ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CK" runat="server"/>
                                                <asp:Label ID="lblApproved" runat="server" Text='<%# Bind("ApprovedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                          
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Authorized Date" Visible="false" ItemStyle-HorizontalAlign="center">
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblAutho" runat="server" Text='<%# Bind("AuthorizedDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table width="100%" class="fontcss">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
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

