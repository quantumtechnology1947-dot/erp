<%@ page language="C#" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_Edit_Details_PO_Grid, newerp_deploy" theme="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
</head>
<body style="margin-bottom:0px;margin-left:0px; margin-right:0px; margin-top:0px;">
    <form id="form1" runat="server">
    <div>
 <table align="center" cellpadding="0" cellspacing="0" width="140%" class="fontcss">
        <tr>
            <td valign="top">
               
                <asp:GridView ID="GridView2" CssClass="yui-datatable-theme" runat="server" 
                    Width="100%" AllowPaging="True"
                    onpageindexchanging="GridView2_PageIndexChanging"  onrowcommand="GridView2_RowCommand" 
                    onrowdatabound="GridView2_RowDataBound" AutoGenerateColumns="False">
                    <FooterStyle Wrap="True"></FooterStyle>
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
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate><%#Container.DataItemIndex+1%></ItemTemplate>             
                <HeaderStyle Font-Size="10pt" />
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%" />
</asp:TemplateField>
                           <asp:TemplateField>
                           <ItemTemplate>
                           <asp:LinkButton ID ="lnkButton" Text="Select" runat ="server" CommandName="sel">
                           </asp:LinkButton>
                           </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                           </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="PO No">
                            <ItemTemplate>
                                <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Item Code">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                            <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblPurchDesc" runat="server" Text='<%# Eval("PurchDesc") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="20%" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                        <ItemTemplate>
                        <asp:Label ID="lblUOMPurch" Text='<%# Eval("UOMPurch") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                        <asp:Label ID="lblQty" Text='<%# Eval("Qty") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" VerticalAlign="Top" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Rate">
                        <ItemTemplate>
                        <asp:Label ID="lblRate" Text='<%# Eval("Rate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Disc %">
                        <ItemTemplate>
                        <asp:Label ID="lblDisc" Text='<%# Eval("Disc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PF">
                        <ItemTemplate>
                        <asp:Label ID="lblPF" Text='<%# Eval("PF") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excise">
                        <ItemTemplate>
                        <asp:Label ID="lblExST" Text='<%# Eval("ExST") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VAT">
                        <ItemTemplate>
                        <asp:Label ID="lblVAT" Text='<%# Eval("VAT") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WONo">
                        <ItemTemplate>
                        <asp:Label ID="lblWONo" Text='<%# Eval("WONo") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="BG Group">
                        <ItemTemplate>
                        <asp:Label ID="lblDeptId" Text='<%# Eval("DeptId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="A/c Head">
                        <ItemTemplate>
                        <asp:Label ID="lblAHId" Text='<%# Eval("AHId") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" />
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        </table>
      
      
    </div>
    </form>
</body>
</html>
