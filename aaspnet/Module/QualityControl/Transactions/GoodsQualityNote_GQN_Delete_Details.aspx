<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_GoodsQualityNote_GQN_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>

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
        .style8
        {  
        	text-align: left;
        }
        .style10
        {
            text-align: left;
            height: 31px;
        }
        .style24
        {
            height: 23px;
        }
        .redbox
        {
            text-align: right;
        }
        .style26
        {
            text-align: left;
            height: 25px;
        }
        .style27
        {
            height: 23px;
        }
        .style28
        {
            height: 23px;
        }
        .style32
        {
            height: 23px;
        }
    .style33
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
    <table align="center" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Quality Note [GQN] -Delete </b></td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                <table align="center" cellpadding="0" cellspacing="0" class="style2" 
                    ><tr><td class="style8" 
                            ><table cellpadding="0" cellspacing="0" 
                            class="style2" ><tr >
                                <td class="style33" >&nbsp; GQN No. :
                                    <asp:Label ID="lblGQn" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style27" >GRR No. :
                                    <asp:Label ID="lblGrr" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td class="style28" >&nbsp; GIN No.: <asp:Label runat="server" Font-Bold="True" ID="lblGIn"></asp:Label>
                                </td>
                                <td class="style32" >Challan No. : <asp:Label runat="server" Font-Bold="True" ID="lblChNo"></asp:Label>
                                </td><td class="style24" >Date : <asp:Label runat="server" Font-Bold="True" ID="lblDate"></asp:Label>
                                </td></tr></table></td></tr><tr><td class="style26" >
&nbsp;&nbsp;Supplier :&nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblSupplier"></asp:Label>

                                    </td>
                            </tr>
                            <tr><td class="style26" >
                                <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A : Total Received Quantity,&nbsp;&nbsp; 
                                B : Normal Accepted Quantity,&nbsp;&nbsp; C : Deviated Quantity,&nbsp;&nbsp; D : 
                                Segregated Quantity,&nbsp;&nbsp; E : Rejected Quantity.</b>

                                    </td>
                            </tr>
                            <tr><td class="style10" >
                            <asp:GridView runat="server" 
                            AllowPaging="True" 
                            AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" Width="100%" ID="GridView2" 
                            OnPageIndexChanging="GridView2_PageIndexChanging" 
                            OnRowCommand="GridView2_RowCommand" DataKeyNames="Id" PageSize="20">
                                <PagerSettings PageButtonCount="40" />
                            <Columns>
                            <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>    <%#Container.DataItemIndex+1  %>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="10pt"></HeaderStyle>

                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false"><ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                        
                            </ItemTemplate>

                            <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                            <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandName="del" Text ="Delete" runat="server"
                             OnClientClick=" return confirmationDelete()" ></asp:LinkButton>                    
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                            </asp:TemplateField>

<asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="12%"></ItemStyle>
</asp:TemplateField>

<asp:TemplateField HeaderText="Item Code"><ItemTemplate>
                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText=" Description "><ItemTemplate>
                                                        <asp:Label ID="lblpurchDesc" runat="server" Text='<%#Eval("Description") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Justify" Width="20%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="UOM"><ItemTemplate>
                                                        <asp:Label ID="lbluompurch" runat="server" Text='<%#Eval("UOM") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="PO Qty">
<ItemTemplate>
<asp:Label ID="lblpoqty" runat="server" Text='<%#Eval("POQty") %>' />
</ItemTemplate>

<ItemStyle HorizontalAlign="Right" Width="7%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Inward Qty">
<ItemTemplate>
  <asp:Label ID="lblInwrdqty" runat="server" Text='<%#Eval("InvQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="A">
<ItemTemplate>
  <asp:Label ID="lblRecedqty" runat="server" Text='<%#Eval("RecedQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="B">
    <ItemTemplate>
        <asp:Label ID="lblaccpQty" runat="server" Visible="true" Text='<%#Eval("NormalAccQty")%>'></asp:Label>        
    </ItemTemplate>
    
    <ItemStyle HorizontalAlign="right" Width="7%" />
</asp:TemplateField>


<asp:TemplateField HeaderText="C">
    <ItemTemplate>
        <asp:Label ID="lblDeviatedQty" runat="server" Visible="true" Text='<%#Eval("DeviatedQty") %>'></asp:Label>       
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="8%" />
</asp:TemplateField>


<asp:TemplateField HeaderText="D">
    <ItemTemplate>
        <asp:Label ID="lblSegregatedQty" runat="server" Visible="true" Text='<%#Eval("SegregatedQty") %>'></asp:Label>
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="8%" />
</asp:TemplateField>


 <asp:TemplateField HeaderText="E" SortExpression="RejectedQty">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("RejectedQty") %>'></asp:Label>
                                    </ItemTemplate>                                    
                                    <ItemStyle HorizontalAlign="Right" Width="7%" />
                                </asp:TemplateField>












                        <asp:TemplateField HeaderText="Rej Reason">
                        <ItemTemplate>
                          
                          <asp:Label ID="lblrejreason" Text='<%#Eval("RejReason")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="14%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                         <asp:Label ID="lblremarks" Text='<%#Eval("Remarks")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
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
                            <tr><td style="text-align: center" height="22">
                                &nbsp;<asp:Label ID="lblmsg" runat="server" 
                                    style="font-weight: 700; color: #FF0000"></asp:Label>
&nbsp;
                                <asp:Button ID="btnCancel" CssClass="redbox" runat="server" 
                                    CommandName="cancel" Text="Cancel" onclick="btnCancel_Click" />&nbsp;</td>
                                </tr>
                            </table>
            </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

