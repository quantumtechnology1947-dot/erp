<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsReceivedReceipt_GRR_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            width: 73px;
            height: 20px;
        }
        .style4
        {
            height: 20px;
        }
        .style5
        {
            height: 20px;
            width: 135px;
        }
        .style6
        {
            width: 77px;
            height: 20px;
        }
        .style7
        {
            height: 20px;
            width: 86px;
        }
        .style8
        {
            height: 20px;
            width: 136px;
        }
        .style9
        {
            width: 40px;
            height: 20px;
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
    <table align="center" cellpadding="0" cellspacing="0" width="100%" >
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Received Receipt [GRR] - Edit</b></td>
        </tr>
        <tr>
            <td >
                <table align="center"  width ="100%" cellpadding="0" cellspacing="0"
                    ><tr><td 
                            ><table cellpadding="0" cellspacing="0" 
                            ><tr >
                                <td class="style3"  >&nbsp; GRR No</td>
                                <td class="style5"  >
                                    <asp:Label ID="lblGrr" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td align="justify" class="style6"  >&nbsp;&nbsp;&nbsp;&nbsp; GIN No</td>
                                <td class="style5"  > <asp:Label runat="server" Font-Bold="True" ID="lblGIn"></asp:Label>
</td><td class="style7"  >&nbsp; Challan No</td><td align="left" class="style8"  >&nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblChNo"></asp:Label>
</td><td align="center" class="style9"  >Date</td><td class="style4"  ><asp:Label runat="server" Font-Bold="True" ID="lblDate"></asp:Label>
</td></tr></table></td></tr><tr ><td align="left" height="25"  >&nbsp; Supplier&nbsp;&nbsp; &nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblSupplier"></asp:Label>
</td></tr><tr><td class="style10" >
                        <asp:GridView runat="server" AllowPaging="True"  DataKeyNames="Id"
                            AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" Width="100%" ID="GridView2" 
                            OnPageIndexChanging="GridView2_PageIndexChanging" onrowcancelingedit="GridView2_RowCancelingEdit" 
                            onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" 
                            onrowdatabound="GridView2_RowDataBound" PageSize="17" 
                            onrowcommand="GridView2_RowCommand">
                            <PagerSettings PageButtonCount="40" />
                            <Columns>
                            
                            <asp:TemplateField HeaderText="SN"><ItemTemplate>
<%#Container.DataItemIndex+1  %>
                                                    
</ItemTemplate>

<HeaderStyle Font-Size="10pt"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="4%"></ItemStyle>
</asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirmationUpdate()" CausesValidation="False"  ValidationGroup="A"
                                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                                            <asp:Label ID="lblgqn" runat="server" Text="GQN" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" ValidationGroup="A" runat="server" CausesValidation="True" 
                                            CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                </asp:TemplateField>

<asp:TemplateField HeaderText="Id" Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>


<asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="12%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Image" >
                        <ItemTemplate>
                       
                            <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Spec. Sheet" >
                        <ItemTemplate>
                         <asp:LinkButton ID="btnlnkSpec" CommandName="downloadSpec" Visible="true"  Text='<%# Bind("AttName") %>'  runat="server"></asp:LinkButton>
                         
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center"  Width="5%"/>
                        </asp:TemplateField>






<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description "><ItemTemplate>
                                                        <asp:Label ID="lblpurchDesc" runat="server" Text='<%#Eval("Description") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="30%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
 <asp:Label ID="lbluompurch" runat="server" Text='<%#Eval("UOM") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="PO Qty">
<ItemTemplate>
<asp:Label ID="lblpoqty" runat="server" Text='<%#Eval("POQty") %>' />
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inward Qty">
<ItemTemplate>
  <asp:Label ID="lblInwrdqty" runat="server" Text='<%#Eval("InvQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tot Reced Qty">
<ItemTemplate>
  <asp:Label ID="lblTotRecedQty" runat="server" Text='<%#Eval("TotRecedQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Reced Qty">
<ItemTemplate>
  <asp:Label ID="lblRecedqty" runat="server" Text='<%#Eval("RecedQty") %>' />
</ItemTemplate>
<EditItemTemplate>
<asp:Label ID="lblRecedqty1" runat="server" Text='<%#Eval("RecedQty") %>' Visible="false"/>
<asp:TextBox ID="TxtRecedqty" CssClass="box3" runat="server" Width="80%" Text='<%#Eval("RecedQty") %>' />
    <asp:RequiredFieldValidator ID="ReqRecQty" runat="server" ControlToValidate="TxtRecedqty" ValidationGroup="A" ErrorMessage="*"></asp:RequiredFieldValidator>
   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ValidationGroup="A" ControlToValidate="TxtRecedqty" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$"></asp:RegularExpressionValidator> 
</EditItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Item Id" Visible="false">
<ItemTemplate>
  <asp:Label ID="lblPOId" runat="server" Text='<%#Eval("POId") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right"></ItemStyle>
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
                            </table>
            </td>
        </tr>
        <tr>
            <td align="center" height="21" valign="middle">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                            ProviderName="System.Data.SqlClient" 
                            SelectCommand="SELECT * FROM [tblQc_Rejection_Reason]"></asp:SqlDataSource>
                <asp:Button ID="btnCancel"  runat="server" CssClass="redbox" 
                    onclick="btnCancel_Click" Text="Cancel" />
&nbsp;</td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

