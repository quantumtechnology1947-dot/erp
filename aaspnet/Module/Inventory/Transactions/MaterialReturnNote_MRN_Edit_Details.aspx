<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_MaterialReturnNote_MRN_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            height: 41px;
        }
        .style3
        {
            height: 24px;
            text-align: left;
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
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Material Return Note [MRN] - Edit</b></td>
        </tr>
        <tr>
            <td align="center" >
                <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                    onrowdatabound="GridView1_RowDataBound" PageSize="20" >
                    <PagerSettings PageButtonCount="40" />
                <Columns>
                  
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" OnClientClick="return confirmationUpdate()" runat="server" CausesValidation="False" 
                                CommandName="Edit" Text="Edit"></asp:LinkButton>
                            <asp:Label ID="lblmrqn" runat="server" Text="MRQN" Visible="false"></asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True"  ValidationGroup="A"
                                CommandName="Update" Text="Update"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                    
               <%-- <asp:TemplateField Visible="true">
                <ItemTemplate>
                <asp:Label ID="lblmrqn" runat="server" Text="MRQN"></asp:Label>
                
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>--%>
                
                <asp:TemplateField HeaderText="SN"> 
                <ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate>
                <ItemStyle HorizontalAlign="Right" Width="5%"  />
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Id" Visible="false">
                <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Item Code" >
                <ItemTemplate>
                <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"  Width="12%" />
                </asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Description" >
                  <ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%# Eval("Description") %>' ></asp:Label>
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Left"  Width="35%" />
                  </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="UOM" >
                   <ItemTemplate>
                   <asp:Label ID="lblUOMPurchase" runat="server" Text='<%# Eval("UOM") %>' ></asp:Label>
                   </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%"  />
                   </asp:TemplateField>                  
        
                    <asp:TemplateField HeaderText="BG Group/WoNo">
                    <ItemTemplate>               
                     <asp:Label ID="lblWODept" runat="server" Text='<%# Eval("WODept") %>' Visible="true" ></asp:Label>
                    <asp:Label ID="lblDwpt" runat="server" Text='<%# Eval("DeptId") %>' Visible="false" ></asp:Label> 
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="box3" Visible="false" 
                     onselectedindexchanged="DropDownList1_SelectedIndexChanged"  AutoPostBack ="true" >
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text="BG Group" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="WONo" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                      
                    </ItemTemplate>
                    
                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="10%"  />
                    </asp:TemplateField>
                                                           
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Label ID="lblDW" runat="server" Text='<%# Eval("DW") %>' ></asp:Label>
                <asp:DropDownList ID="drpdept" Width="70" SelectedValue='<%# Eval("DeptId") %>' DataSourceID="SqlDataSource1" DataTextField="Dept"  DataValueField="Id"
                  runat="server" CssClass="box3" Visible="false">
                  </asp:DropDownList>
                <asp:TextBox ID="txtwono" runat="server" Width="80%" CssClass="box3" Text='<%# Eval("WO") %>'  Visible="false">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="Req1" ControlToValidate="txtwono" ValidationGroup="A" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                
                
                </ItemTemplate>                
                <ItemStyle HorizontalAlign="Center" Width="10%"  />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Ret Qty">
                <ItemTemplate>
                <asp:Label ID="lblRetQty" runat="server" Text='<%# Eval("RetQty") %>' ></asp:Label>                
                </ItemTemplate>
                <EditItemTemplate>
                 <asp:TextBox ID="txtqty"  Text='<%# Eval("RetQty") %>' runat="server" Width="80%" CssClass="box3"  ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="Req2" ControlToValidate="txtqty" ValidationGroup="A" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="*" ControlToValidate="txtqty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                </asp:RegularExpressionValidator>
                </EditItemTemplate>
                <ItemStyle Width="10%" HorizontalAlign="Right"  />
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Remarks">
                <ItemTemplate>
                <asp:Label ID="lblRemarks" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                 <asp:TextBox ID="txtremarks" runat="server" Width="98%" Text='<%# Eval("Remarks") %>' CssClass="box3"   ></asp:TextBox>
                </EditItemTemplate>
                    <ItemStyle Width="20%" HorizontalAlign="Left"  />
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Item Id" Visible="false" >
                <ItemTemplate>
                <asp:Label ID="lblItemId" runat="server" Text='<%# Eval("ItemId") %>' ></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="right"  Width="4%" />
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
                                                   
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            
                    SelectCommand="SELECT Id,Symbol as Dept FROM [BusinessGroup]">
            </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" height="25" valign="bottom">
                &nbsp;<asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                    onclick="BtnCancel_Click" CssClass="redbox" />
            </td>
        </tr>
    </table>


</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

