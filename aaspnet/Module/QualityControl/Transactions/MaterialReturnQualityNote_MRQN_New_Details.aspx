<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_New_Details, newerp_deploy" title="ERP" theme="Default" %>

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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Quality Note [MRQN] - New</b></td>
        </tr>
        <tr>
            <td>
                                        <asp:GridView runat="server" AutoGenerateColumns="False" 
                                             CssClass="yui-datatable-theme" Width="100%" ID="GridView3" 
                                            OnPageIndexChanging="GridView3_PageIndexChanging" PageSize="20">
                                            <PagerSettings PageButtonCount="40" />
                                            <Columns>
<asp:TemplateField HeaderText="SN"><ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
                                                        <asp:CheckBox ID="ck" runat="server" />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate>
<asp:Label ID="lblitemid" runat="server" Text='<%# Eval("ItemId") %>'></asp:Label>
                                                    
</ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="ItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle Width="13%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Manf  Desc"><ItemTemplate>
                                                        <asp:Label ID="ManfDesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Left" Width="25%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
                                                        <asp:Label ID="UOMBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Dept"><ItemTemplate>
                                                        <asp:Label ID="lbldept" runat="server" Text='<%# Eval("Dept") %>'></asp:Label>
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="WO No"><ItemTemplate>
                                                        <asp:Label ID="lblWONO" runat="server" Text='<%# Eval("WONo") %>'></asp:Label>
                                                        
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Ret Qty"><ItemTemplate>
  <asp:Label ID="lblretqty" runat="server" Text='<%# Eval("RetQty") %>'></asp:Label>                                                   
</ItemTemplate>

<ItemStyle Width="7%" HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Accepted Qty"><ItemTemplate>
 <asp:Label ID="lblAccQty" runat="server" Text='<%# Eval("RecQty") %>'></asp:Label> 
</ItemTemplate>
    <ItemStyle Width="5%" HorizontalAlign="Right" />
</asp:TemplateField>

                                            <asp:TemplateField HeaderText="Accp Qty">
                                            <ItemTemplate>
                                                        <asp:TextBox ID="txtAccpQty" Width="70%" Text="0" runat="server" CssClass="box3"></asp:TextBox>
         <asp:RequiredFieldValidator ID="ReqAccQty" runat="server" ControlToValidate="txtAccpQty" ValidationGroup="New" ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegAccQty" runat="server" ValidationGroup="New"
            ControlToValidate="txtAccpQty" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator> <asp:Label ID="lblAccpQty" Visible="false" Text='<%# Eval("RecQty") %>' runat="server" CssClass="box3"></asp:Label>
                                                        
                                                    
</ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="8%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText ="Type">
                                            <ItemTemplate>
                                            <asp:DropDownList ID="Drptype" runat="server" >
                                            <asp:ListItem Text ="Hold" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Scrap" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                            
                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            
                              <asp:TemplateField HeaderText="ScrapQty" >
                                            <ItemTemplate>
                                            <asp:Label ID="lblScrap" runat="server" Text='<%# Eval("Qty") %>'></asp:Label> 
                                       
                                            
                                            
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                                          
                                            
                                            
<asp:TemplateField HeaderText="Remarks"><ItemTemplate>
 <asp:Label ID="lblremrk" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label> 
</ItemTemplate>
    <ItemStyle Width="20%" />
</asp:TemplateField>

<asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate>
                                                       <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label> 
                                                    
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

            </td>
        </tr>
        <tr>
            <td align="Right" height="25" valign="middle">
            <asp:Button ID="btnProceed" 
                    runat="server" CssClass="redbox" Text="Generate MRQN" ValidationGroup="New" OnClientClick=" return confirmationAdd()" 
                    onclick="btnProceed_Click" />&nbsp;
                    <asp:Button ID="btnCancel" 
                    runat="server" CssClass="redbox" Text="Cancel" onclick="btnCancel_Click" />&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

