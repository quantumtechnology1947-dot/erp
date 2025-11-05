<%@ Page Language="C#" AutoEventWireup="true" CodeFile="APO_SPR_ItemGrid.aspx.cs" Inherits="Module_MaterialManagement_Transactions_APO_SPR_ItemGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

</head>
<body topmargin=0 bottommargin=0 leftmargin=0 rightmargin=0>
    <form id="form1" runat="server">
    <div>
  
    
 <table align="center" cellpadding="0" cellspacing="0" width="100%" class="fontcss">
        <tr>
            <td valign="top">
               
                <asp:GridView ID="GridView2" CssClass="yui-datatable-theme" runat="server" 
                    Width="100%" AllowPaging="False" PageSize="17"
                    onpageindexchanging="GridView2_PageIndexChanging"  onrowcommand="GridView2_RowCommand" 
                    onrowdatabound="GridView2_RowDataBound" AutoGenerateColumns="False" >
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
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
</asp:TemplateField>
                           <asp:TemplateField HeaderText="Fin Year">
                           <ItemTemplate>
                                <asp:Label ID="lblfinyear" runat="server" Text='<%# Eval("FinYearId") %>'></asp:Label>
                            </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                           <asp:TemplateField>
                           <ItemTemplate>
                           <asp:LinkButton ID="lnkButton" Text="Select" runat ="server" CommandName="sel">
                           </asp:LinkButton>
                           </ItemTemplate>
                               <ItemStyle HorizontalAlign="Center" />
                           </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="SPR No">
                            <ItemTemplate>
                                <asp:Label ID="lblsprno" runat="server" Text='<%# Eval("SPRNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="WO No">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:Label ID="lblwono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="BG Group">
                        <ItemTemplate>
                            <asp:Label ID="lbldept" runat="server" Text='<%# Eval("DeptId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                        <asp:Label ID="lblDate" Text='<%# Eval("Date") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                        <asp:Label ID="lblItemCode" Text='<%# Eval("ItemCode") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                        <asp:Label ID="lblPurchDesc" Text='<%# Eval("PurchDesc") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                        <ItemTemplate>
                        <asp:Label ID="lblUOMPurch" Text='<%# Eval("UOMPurch") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" SPR Qty">
                        <ItemTemplate>
                        <asp:Label ID="lblQty" Text='<%# Eval("Qty") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PO Qty">
                        <ItemTemplate>
                        <asp:Label ID="lblPOQty" Text='<%# Eval("POQty") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Remain Qty">
                        <ItemTemplate>
                        <asp:Label ID="lblRemQty" Text='<%# Eval("RemainQty") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A/c Head">
                        <ItemTemplate>
                        <asp:Label ID="lblAcHead" Text='<%# Eval("AcHead") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Del. Date">
                        <ItemTemplate>
                        <asp:Label ID="lblDeliDate" Text='<%# Eval("DeliDate") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gen. By">
                        <ItemTemplate>
                        <asp:Label ID="lblGenBy" Text='<%# Eval("GenBy") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
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

