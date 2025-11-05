<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_New, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width:100%;
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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Quality Note [MRQN] - New</b></td>
        </tr>
          <tr>
                    <td height="25">

                    &nbsp;
                    <asp:DropDownList ID="DrpField" runat="server" CssClass="box3" 
                    onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True">
                  <%--<asp:ListItem Value="Select">Select</asp:ListItem>--%>
                    <asp:ListItem Value="0">MRN No</asp:ListItem>
                    <asp:ListItem Value="1">Employee Name</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:TextBox ID="TxtMrn" runat="server" CssClass="box3"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="TxtEmpName" runat="server" CssClass="box3" Visible="False" Width="250px"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                    ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                    CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" 
                    MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True"  CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                    </cc1:AutoCompleteExtender>
                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" onclick="Button1_Click" Text="Search" />
                    </td>
                    </tr>
        <tr>
            <td align="Left">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" Width="60%" 
                    onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="7%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="btnSel" runat="server" Text="Select" CommandName="Sel"></asp:LinkButton>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' ></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="FinYrsId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblfinyrsid" runat="server" Text='<%#Eval("FinYrsId") %>' ></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Fin Year">
                        <ItemTemplate>
                        <asp:Label ID="lblfinyrs" runat="server" Text='<%#Eval("FinYrs") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="12%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="MRN No">
                        <ItemTemplate>
                        <asp:Label ID="lblmrnno" runat="server" Text='<%#Eval("MRNNo") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="12%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="12%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Gen. By">
                        <ItemTemplate>
                        <asp:Label ID="lblgenby" runat="server" Text='<%#Eval("GenBy") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="60%" HorizontalAlign="Left" />
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
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

