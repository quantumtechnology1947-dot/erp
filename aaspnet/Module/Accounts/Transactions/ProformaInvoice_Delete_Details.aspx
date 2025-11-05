<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_ProformaInvoice_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
 <table align="left" cellpadding="0" cellspacing="0"  width="100%">
        <tr>
            <td style="background:url(../../../images/hdbg.JPG); height:21px" class="fontcsswhite" >&nbsp;<b>Proforma Invoice - Delete</b></td>
        </tr>
        <tr>
            <td>
              
                
                <table align="left" cellpadding="0" cellspacing="0"  width="100%">
                    <tr>
                        <td  height="21">
                          <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="445px">
                              <asp:Panel ID="Panel2" runat="server" Height="440px" ScrollBars="Auto">
                                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                      CssClass="yui-datatable-theme" 
                                      onpageindexchanging="GridView1_PageIndexChanging" 
                                      onrowcommand="GridView1_RowCommand" PageSize="17" Width="100%">
                                      <Columns>
                                          <asp:TemplateField HeaderText="SN">
                                              <ItemTemplate>
                                                  <%#Container.DataItemIndex+1  %>
                                              </ItemTemplate>
                                              <HeaderStyle Font-Size="10pt" />
                                              <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField>
                                              <ItemTemplate>
                                                  <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="false" />
                                              </ItemTemplate>
                                              <ItemStyle Width="2%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Id" Visible="false">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle Width="0%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Description">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblItemDesc" runat="server" Text='<%#Eval("ItemDesc") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle Width="25%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="UOM">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblSymbol" runat="server" Text='<%#Eval("Symbol") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Center" Width="5%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="UnitId" Visible="False">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblIdSymbol" runat="server" Text='<%#Eval("Unit") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle Width="0%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Qty">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Right" Width="5%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Rem Qty">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblRmnQty" runat="server" Text='<%#Eval("RmnQty") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="ItemId" Visible="false">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Req Qty">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblReqQty" runat="server" Text='<%#Eval("ReqQty") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Amt In Per">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblAmtInPer" runat="server" Text='<%#Eval("AmtInPer") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Right" Width="8%" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Rate">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Right" Width="6%" />
                                          </asp:TemplateField>
                                      </Columns>
                                      <FooterStyle Wrap="True" />
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
                                  </asp:Panel>
                        </td></tr>
                        
                        
                        
                        <tr><td align="center" height="25" valign="middle"><asp:Button ID="Btngoods" runat="server" OnClientClick=" return confirmationDelete()" CssClass="redbox"  onclick="Btngoods_Click"  Text="Delete" />&nbsp; <asp:Button ID="ButtonCancel"  runat="server" CssClass="redbox" OnClick=" ButtonCancel_Click" 
                                        Text="Cancel" />
                        </td></tr>
                        </table>
                        
                       
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

