<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsServiceNote_SN_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style8
        {  
        	text-align: left;
        }
        .style10
        {
            text-align: center;
            height: 31px;
        }
        .style12
        {
            width: 71px;
            height: 23px;
        }
        .style13
        {
            width: 31px;
            height: 23px;
        }
        .style15
        {
            width: 141px;
            height: 23px;
        }
        .style16
        {
            height: 23px;
        }
        .style17
        {
            text-align: left;
            height: 22px;
        }
        .style18
        {
            width: 61px;
            height: 23px;
        }
        .style19
        {
            width: 109px;
            height: 23px;
        }
        .style20
        {
            width: 66px;
            height: 23px;
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
    <table align="center" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Service Note [GSN] -Edit</b></td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                <table align="center" cellpadding="0" cellspacing="0" class="style2" 
                    ><tr><td class="style8" 
                            ><table cellpadding="0" cellspacing="0" 
                            class="style2" ><tr >
                                <td class="style20" >&nbsp; GSN No</td>
                                <td class="style19" >
                                    <asp:Label ID="lblGsn" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style18" >&nbsp; GIN No</td>
                                <td  class="style15"><asp:Label runat="server" Font-Bold="True" ID="lblGIn"></asp:Label>
</td><td class="style12" >Challan No</td><td  class="style16"><asp:Label runat="server" Font-Bold="True" ID="lblChNo"></asp:Label>
</td><td class="style13" >Date</td><td  class="style16"><asp:Label runat="server" Font-Bold="True" ID="lblDate"></asp:Label>
</td></tr></table></td></tr><tr ><td class="style17" >&nbsp; Supplier&nbsp;&nbsp; &nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblSupplier"></asp:Label>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                            ProviderName="System.Data.SqlClient" 
                            SelectCommand="SELECT * FROM [tblQc_Rejection_Reason]"></asp:SqlDataSource>
</td></tr><tr><td class="style10" >
                        <asp:GridView runat="server" AllowPaging="True" 
                            AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" Width="100%" ID="GridView2" 
                            OnPageIndexChanging="GridView2_PageIndexChanging" 
                            onrowcancelingedit="GridView2_RowCancelingEdit" 
                            onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" 
                            onrowdatabound="GridView2_RowDataBound" PageSize="15">
                            <PagerSettings PageButtonCount="40" />
                            <Columns>
                                <asp:CommandField ShowEditButton="True" ButtonType="Link" ValidationGroup="A">
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:CommandField>
<asp:TemplateField HeaderText="SN"><ItemTemplate>
<%#Container.DataItemIndex+1  %>
                                                    
</ItemTemplate>

<HeaderStyle Font-Size="10pt"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField Visible="False"><ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description "><ItemTemplate>
                                                        <asp:Label ID="lblpurchDesc" runat="server" Text='<%#Eval("Description") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="35%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
                                                        <asp:Label ID="lbluompurch" runat="server" Text='<%#Eval("UOM") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="PO Qty">
<ItemTemplate>
<asp:Label ID="lblpoqty" runat="server" Text='<%#Eval("POQty") %>' />
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inward Qty">
<ItemTemplate>
  <asp:Label ID="lblInwrdqty" runat="server" Text='<%#Eval("InvQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tot Reced Qty">
<ItemTemplate>
  <asp:Label ID="lblTotRecedQty" runat="server" Text='<%#Eval("TotRecedQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reced Qty">
<ItemTemplate>
  <asp:Label ID="lblRecedqty" runat="server" Text='<%#Eval("RecedQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
<EditItemTemplate>
<asp:Label ID="lblRecedqty1" runat="server" Text='<%#Eval("RecedQty") %>' Visible="false"/>
<asp:TextBox ID="TxtRecedqty" runat="server" CssClass="box3" Width="60" Text='<%#Eval("RecedQty") %>' />
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ValidationGroup="A" ControlToValidate="TxtRecedqty" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
                                                         </asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="ReqRecQty" runat="server" ControlToValidate="TxtRecedqty" ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>
</EditItemTemplate>
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
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left" height="21" valign="middle">
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                    onclick="btnCancel_Click" Text="Cancel" />
&nbsp;</td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

