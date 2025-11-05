<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_Error, newerp_deploy" theme="Default" title="ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
      <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
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
<div>

    <table class="style2">
     <tr>
            <td align="left" class="fontcsswhite" height="20" scope="col" style="background: url(../../../images/hdbg.JPG)" valign="middle">&nbsp;<b>Insufficient Budget</b></td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="true" PageSize="15" CssClass="yui-datatable-theme" 
                    Width="70%" onpageindexchanging="GridView2_PageIndexChanging">
                    <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top"  Width="6%" />
                                    </asp:TemplateField>
                                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">

 <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
        Text="Cancel" CssClass="redbox" />
            </td>
        </tr>
    </table>
    <br />
    <br />
</div>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
   
</asp:Content>

