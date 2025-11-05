<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_SupplierChallan_New_Details, newerp_deploy" title="ERP" theme="Default" %>

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
        }
    
        .style3
        {
            height: 37px;
        }
    
        .style4
        {
            width: 100%;
            float: left;
        }
            
        .style5
        {
            width: 30%;
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

    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
   
    <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            >&nbsp;<strong> 
                            Supplier Challan- New</strong></td>
                    </tr>
                    </table>
    
     <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" 
        onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Generate" ID="Add">                    
                        <HeaderTemplate>Generate
                        </HeaderTemplate><ContentTemplate><asp:Panel ID="Panel1" ScrollBars="Auto" runat="server"><table align="left" cellpadding="0" cellspacing="0" class="style2"><tr><td 
                            height="5px" colspan="4" >&#160;</td></tr><tr><td colspan="4" height="5px"><asp:Panel 
                                ID="Panel3" runat="server" Height="329px" ScrollBars="Auto"><asp:GridView 
                                ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                CssClass="yui-datatable-theme" style="position:static" Width="100%"><Columns><asp:TemplateField 
                                        HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                                oncheckedchanged="CheckBox1_CheckedChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle Font-Size="10pt" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PR NO">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprNo" runat="server" Text='<%# Eval("PRNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprDId" runat="server" Text='<%# Eval("PRId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprDt" runat="server" Text='<%# Eval("PRDate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="WONo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWono" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblit" runat="server" Text='<%# Eval("ItemCode") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldesc" runat="server" Text='<%# Eval("Descr") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="UOM">
                                        <ItemTemplate>
                                            <asp:Label ID="lbluom" runat="server" Text='<%# Eval("Symbol") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PR Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprqty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remain Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqty" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="6%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqty" runat="server" CssClass="box3" Enabled="false" 
                                                Width="78%">
                                             </asp:TextBox><asp:RequiredFieldValidator ID="ReqChNo" runat="server" 
                                                ControlToValidate="txtqty" ErrorMessage="*" ValidationGroup="A" Visible="false"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                                                ID="Reg2" runat="server" ControlToValidate="txtqty" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A" 
                                                Visible="false"> </asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="8%" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <table class="fontcss" width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                    Text="No data to display !"> </asp:Label></td></tr></table>
                                </EmptyDataTemplate>
                                <FooterStyle Font-Bold="False" />
                                <HeaderStyle Font-Size="9pt" />
                                <PagerSettings PageButtonCount="40" />
                            </asp:GridView>
                            </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="4" height="5px" 
                                style="border-bottom-style: solid; border-width: thin; border-color: #808080">
                            &#160;</td>
                         </tr>
                         <tr>
                         <td height="23px" 
                                style="border-right-style: none; border-width: medium; border-color: #808080; border-left-style: solid; border-top-style: none;" 
                                width="1%">&#160;</td><td class="style5" height="5px" valign="middle">Vehicle No. : <asp:TextBox 
                                    ID="txtVehicleNo" runat="server" CssClass="box3" Width="200px"></asp:TextBox></td><td 
                                align="right" height="5px" valign="middle" width="5%">Remarks :</td><td 
                                height="5px" rowspan="2" 
                                style="border-width: thin; border-color: #808080; height: 10px; border-right-style: solid;" 
                                valign="middle"><asp:TextBox ID="txtRemarks" runat="server" CssClass="box3" 
                                    Height="36px" TextMode="MultiLine" Width="98%"></asp:TextBox></td></tr>
                          <tr>
                          <td 
                                height="23px" 
                                style="border-left-style: solid; border-width: medium; border-color: #808080; border-right-style: none;" 
                                width="1%">&#160;</td><td height="5px" valign="middle">Transpoter : <asp:TextBox 
                                    ID="txtTranspoter" runat="server" CssClass="box3" Width="200px"></asp:TextBox></td><td 
                                height="5px" width="10%">&#160;</td></tr>
                           <tr>
                           <td align="left" valign="top" 
                                colspan="4" height="5px"><table align="left" cellpadding="0" cellspacing="0" class="style4"><tr><td 
                                    valign="bottom" align="center" height="23px" 
                                    style="border-top-style: solid; border-width: thin; border-color: #808080"  ><asp:Button 
                                    ID="BtnAdd" runat="server" CssClass="redbox" OnClick="BtnAdd_Click" 
                                    Text="Submit" ValidationGroup="A" />
                                &#160; <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                                    OnClick="btnCancel_Click" Text="Cancel" />
                                </td></tr></table></td></tr>
                                
                                </table></asp:Panel></ContentTemplate></cc1:TabPanel>
                        
                        
                        
                        
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Clear">
                    <ContentTemplate><asp:Panel ID="Panel2"  ScrollBars="Auto" runat="server"><table width="100%" align="center" cellpadding="0" cellspacing="0" 
                             style="height: 454px"><tr><td><table width="100%" align="center" cellpadding="0" cellspacing="0"><tr><td colspan="2"><iframe src="" id="myframe"  runat="server"  width="100%" height="430Px" frameborder="0" ></iframe></td></tr></table></td></tr></table></asp:Panel>
                    </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

