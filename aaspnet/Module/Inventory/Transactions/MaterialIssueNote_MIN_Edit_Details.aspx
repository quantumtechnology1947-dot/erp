<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialIssueNote_MIN_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 63px;
        }
        .style3
        {
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
    <table class="style2" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite" ><b>&nbsp;Material Issue Note [MIN] - Edit</b></td>
        </tr>
        <tr>
            <td align="Left" >
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    DataKeyNames="Id" onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="15" >
                    <PagerSettings PageButtonCount="40" />
                <Columns>
                    <asp:CommandField ShowEditButton="True" ButtonType="Link" ValidationGroup="A">
                        <ItemStyle HorizontalAlign="Center" Width="4%" />
                    </asp:CommandField>
                <asp:TemplateField HeaderText="SN">
                 <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                 <ItemStyle HorizontalAlign="Right" />
                 </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Id" Visible="False">
                <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Item Code" >
                <ItemTemplate>
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' ></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Description" >
                  <ItemTemplate>
                  <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("PurchDesc") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left" Width="25%" />
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="UOM" >
                   <ItemTemplate>
                   <asp:Label ID="lblUOMPurchase" runat="server" Text='<%# Eval("UOM") %>' ></asp:Label>
                   </ItemTemplate><ItemStyle HorizontalAlign="Center" />
                   </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="BG Group" >
                <ItemTemplate>
                <asp:Label ID="lblDept" runat="server" Text='<%# Eval("Symbol") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="WO No" >
                 <ItemTemplate>
                 <asp:Label ID="lblWONo" runat="server" Text='<%# Eval("WONo") %>' ></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Req Qty" >
                 <ItemTemplate>
                 <asp:Label ID="lblReqQty" runat="server" Text='<%# Eval("ReqQty") %>' ></asp:Label>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Right" />
                 </asp:TemplateField>
                 
                 
                  <asp:TemplateField HeaderText="Issue Qty" >
                  <ItemTemplate>
                  <asp:Label ID="lblIssueQty" runat="server" Text='<%# Eval("IssueQty") %>' ></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                 <asp:TextBox ID="txtAccQty" Text='<%# Eval("IssueQty") %>' CssClass="box3" Width="50" runat="server"></asp:TextBox>  
                 <asp:RequiredFieldValidator ID="Req1" runat="server" ValidationGroup="A" ControlToValidate="txtAccQty" ErrorMessage="*"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="A" runat="server" ErrorMessage="*" ControlToValidate="txtAccQty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ></asp:RegularExpressionValidator>                
                 </EditItemTemplate>
                  <ItemStyle HorizontalAlign="Right" />
                  </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Remarks" >
                 <ItemTemplate>
                 <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label>
                 </ItemTemplate>
                     <ItemStyle HorizontalAlign="Left" Width="20%" />
                 </asp:TemplateField>
                <asp:TemplateField HeaderText="IssueQty" Visible="false" >
                  <ItemTemplate>
                  <asp:Label ID="lblIssueQty1" runat="server" Text='<%# Eval("IssueQty") %>' ></asp:Label>
                  </ItemTemplate>                  
                  <ItemStyle HorizontalAlign="Right" />
                  </asp:TemplateField>
             <asp:TemplateField HeaderText="Item Id" Visible="false" >
                  <ItemTemplate>
                  <asp:Label ID="lblItemId" runat="server" Text='<%# Eval("ItemId") %>' ></asp:Label>
                  </ItemTemplate>                  
                  <ItemStyle HorizontalAlign="Right" />
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
            <td align="center" class="style3">
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                    onclick="BtnCancel_Click" CssClass="redbox" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

