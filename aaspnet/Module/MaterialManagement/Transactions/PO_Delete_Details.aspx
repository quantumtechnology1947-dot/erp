<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>

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

<table align="center" cellpadding="0" cellspacing="0" width="100%" class="fontcss">
        <tr>
            <td height="21" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>PO - Delete</b></td>
            <td height="21" align="right" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">                
               
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
               
                <asp:Panel ID="Panel1" runat="server" Height="440px" ScrollBars="Auto">
                    <asp:GridView ID="GridView2" CssClass="yui-datatable-theme" runat="server" 
                    Width="140%" AllowPaging="True" DataKeyNames="PONo"
                    onpageindexchanging="GridView2_PageIndexChanging"  onrowcommand="GridView2_RowCommand" 
    AutoGenerateColumns="False" PageSize="20" >
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
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton  ID ="lnkButton" Text="Delete" runat ="server"  OnClientClick=" return confirmationDelete()" CommandName="Del">
                                    </asp:LinkButton>
                                    <asp:Label ID="lblDel" runat="server" Text="GIN"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FinId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFinId" runat="server" Text='<%# Eval("FinId") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Top" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="PO No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPONo" runat="server" Text='<%# Eval("PONo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Code">
                                <ItemStyle HorizontalAlign="center" Width="8%" VerticalAlign="Top" />
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
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="4%" />
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
                            <asp:TemplateField HeaderText="Discount">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisc" Text='<%# Eval("Discount") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="5%" VerticalAlign="Top" />
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
                                <ItemStyle HorizontalAlign="Left" Width="12%" VerticalAlign="Top" />
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
                                <ItemStyle HorizontalAlign="Center" Width="4%" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="A/c Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblAHId" Text='<%# Eval("AHId") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="4%" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                                </ItemTemplate>
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
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td valign="middle" colspan="2" align="center" height="30">
               
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                    onclick="btnCancel_Click" Text="Cancel" />
            </td>
        </tr>
        
        </table>




</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

