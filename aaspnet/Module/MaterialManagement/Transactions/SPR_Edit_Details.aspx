<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_SPR_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

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

<table style="width:100%" cellpadding="0" cellspacing="0" >
<tr>
                <td  height="20" align="Left" valign="middle"  scope="col" width="82%"
                class="fontcsswhite" style="background:url(../../../images/hdbg.JPG)">&nbsp;<b 
                       >SPR - Edit</b></td>
                </tr>
 <tr>
            <td valign="top" align="center" height="150" width="92%">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="452px">
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
        CssClass="yui-datatable-theme"  onpageindexchanging="GridView3_PageIndexChanging" 
        onrowcommand="GridView3_RowCommand" PageSize="17" Width="100%" 
                    AutoGenerateColumns="False" >
                        <FooterStyle 
                    Wrap="True"></FooterStyle>
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
                            <asp:TemplateField 
                        HeaderText="SN" ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1  %>
                                </ItemTemplate>
                                <HeaderStyle 
                        Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                            </asp:TemplateField>
                            <%--<asp:ButtonField Text="Edit" CommandName="edt" />--%>
                            <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton 
                                 ID="linkBtn" runat="server" Text="Edit"  OnClientClick=" return confirmationUpdate()"  CommandName="edt" ></asp:LinkButton>
           <asp:Label ID="lblDel" runat="server" Text="PO" Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Font-Size="10pt" />
                                <ItemStyle HorizontalAlign="Center"  Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SPR No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblsprno" runat="server" Text='<%#Eval("SPRNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="6%" HorizontalAlign="Center" />
                            </asp:TemplateField>                             
                            <asp:TemplateField HeaderText="ItemCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="8%" HorizontalAlign="left"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="15%" HorizontalAlign="left"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM">                            
                            <ItemTemplate>
                                    <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="4%" HorizontalAlign="Center"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supplier">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("Supplier") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="A/c Head">
                                <ItemTemplate>
                                    <asp:Label ID="lblAc" runat="server" Text='<%#Eval("AcHead") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="WONo">
                                <ItemTemplate>
                                    <asp:Label ID="lblwono" runat="server" Text='<%#Eval("WONo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                            </asp:TemplateField>                          
                            <asp:TemplateField HeaderText="BG Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblDept" runat="server" Text='<%#Eval("Dept") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="4%"  HorizontalAlign="Center"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qty">
                                <ItemTemplate>
                                    <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblrate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Dis">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisc" runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="6%" HorizontalAlign="Right" />
                            </asp:TemplateField>
                            
                            
                            
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:Label ID="lblremark" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <ItemStyle Width="15%" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <asp:Button ID="btncancel" CssClass="redbox"  runat="server" 
                Text="Cancel" onclick="btncancel_Click" />
                
</td>
</tr>
</table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

