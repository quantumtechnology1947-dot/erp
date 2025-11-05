<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_Dashboard, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 35px;
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
   <%-- <table align="center" cellpadding="0" width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>
                &nbsp;Convert TPL Items into BOM</b></td>
        </tr>
        <tr>
            <td valign="top" align="center">
                <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    onrowdatabound="GridView2_RowDataBound" PageSize="13" Width="100%" 
                    AllowPaging="True" onpageindexchanging="GridView2_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server"  AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged"/>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelect" AutoPostBack="true"></asp:CheckBox>
                         </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                   
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td valign="middle" align="left" class="style2">
                &nbsp;
                <asp:Button ID="btncnv" runat="server" CssClass="redbox" Text="Add To BOM"  OnClientClick=" return confirmationAdd()" 
                    onclick="btncnv_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
    </table>--%>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

