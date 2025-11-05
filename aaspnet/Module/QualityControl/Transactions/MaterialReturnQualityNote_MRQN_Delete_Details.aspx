<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_QualityControl_Transactions_MaterialReturnQualityNote_MRQN_Delete_Details, newerp_deploy" title="ERP 
" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 21px;
        }
        .style3
        {
            height: 25px;
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
    <table class="style2" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Quality Note [MRQN] - Delete</b></td>
        </tr>
        <tr>
            <td align="left" >
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    onrowcommand="GridView1_RowCommand" 
                    onpageindexchanging="GridView1_PageIndexChanging" PageSize="20" >
                    <PagerSettings PageButtonCount="40" />
                <Columns>
                <asp:TemplateField HeaderText="SN"> <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 <asp:TemplateField >
                      <ItemTemplate>
                          <asp:LinkButton ID="LinkButton1" CommandName="Del"  
                           OnClientClick=" return confirmationDelete()" Text="Delete" runat="server"></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>                
                
                    
                <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Item Code" ><ItemTemplate><asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Description" ><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Description") %>' ></asp:Label></ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" Width="30%" /></asp:TemplateField>
                   <asp:TemplateField HeaderText="UOM" ><ItemTemplate><asp:Label ID="lblUOMPurchase" runat="server" Text='<%# Eval("UOM") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                 
                 
                <asp:TemplateField HeaderText="Dept" ><ItemTemplate><asp:Label ID="lblDept" runat="server" Text='<%# Eval("Symbol") %>' ></asp:Label></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                 <asp:TemplateField HeaderText="WO No" ><ItemTemplate><asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>' ></asp:Label></ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" /></asp:TemplateField>
                  <asp:TemplateField HeaderText="Ret Qty" ><ItemTemplate><asp:Label ID="lblRetQty" runat="server" Text='<%# Eval("RetQty") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 <asp:TemplateField HeaderText="Accpt Qty" ><ItemTemplate><asp:Label ID="lblAccptQty" runat="server" Text='<%# Eval("AcceptedQty") %>' ></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                 <asp:TemplateField HeaderText="Remarks" ><ItemTemplate><asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label></ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" Width="25%" />                 
                 </asp:TemplateField>
                 
<asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="12%"></ItemStyle>
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
            <td align="center" class="style3" height="25" valign="bottom">&nbsp;
                &nbsp;<asp:Label ID="lblmsg" runat="server" 
                    style="font-weight: 700; color: #FF0000"></asp:Label>
&nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="redbox" Text="Cancel" 
                    onclick="BtnCancel_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

