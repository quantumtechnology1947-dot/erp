<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_QualityControl_Transactions_GoodsQualityNote_GQN_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style2
        {
            width: 109px;
        }
        .style3
        {
            width: 111px;
        }
        .style4
        {
            width: 75px;
        }
        .style5
        {
            height: 13px;
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
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Goods Quality Note [GQN] -Edit </b></td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                <table align="center" cellpadding="0" cellspacing="0" width="100%"
                    ><tr><td 
                            ><table cellpadding="0" cellspacing="0" 
                            ><tr >
                                <td  >&nbsp;GQN No&nbsp;&nbsp;&nbsp; </td>
                                <td  class="style3" >
                                    :
                                    <asp:Label ID="lblGQn" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td  >GRR No&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                <td class="style2"  >
                                    :
                                    <asp:Label ID="lblGrr" runat="server" style="font-weight: 700"></asp:Label>
                                </td>
                                <td  >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GIN No&nbsp; &nbsp; </td>
                                <td class="style3"  >: <asp:Label runat="server" Font-Bold="True" ID="lblGIn"></asp:Label>
</td><td  >Challan No</td><td class="style3"  >&nbsp;&nbsp;&nbsp; : <asp:Label runat="server" Font-Bold="True" ID="lblChNo"></asp:Label>
</td><td align="center" class="style4"  >Date</td><td class="style3"  >: <asp:Label runat="server" Font-Bold="True" ID="lblDate"></asp:Label>
</td></tr></table></td></tr><tr><td align="left"  >
&nbsp;Supplier&nbsp;:&nbsp;<asp:Label runat="server" Font-Bold="True" ID="lblSupplier"></asp:Label> 

                                    </td>
                                </tr>
                        <tr>
                            <td align="left" class="style5"  >
                                <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; A : Total Received Quantity,&nbsp;&nbsp; 
                                B : Normal Accepted Quantity,&nbsp;&nbsp; C : Deviated Quantity,&nbsp;&nbsp; D : 
                                Segregated Quantity,&nbsp;&nbsp; E : Rejected Quantity.</b> 

                                    </td>
                                </tr>
                        <tr><td  >
                        <asp:GridView runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" ShowFooter="True" 
                        CssClass="yui-datatable-theme" Width="100%" ID="GridView2" 
                        OnPageIndexChanging="GridView2_PageIndexChanging"  DataKeyNames="Id" 
                        
                        onrowcancelingedit="GridView2_RowCancelingEdit" 
                        onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" 
                                onrowdatabound="GridView2_RowDataBound" PageSize="20">
                                    <PagerSettings PageButtonCount="40" />
                                    <Columns>
                        <asp:CommandField  ButtonType="Link" ValidationGroup="edit" 
                        ShowEditButton="True" >
                        <ItemStyle Width="3%" />
                        </asp:CommandField>
<asp:TemplateField HeaderText="SN">
<ItemTemplate><%#Container.DataItemIndex+1  %>
</ItemTemplate>
                                                    


<HeaderStyle Font-Size="10pt"></HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="3%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField Visible="False"><ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' />
                                                    
</ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
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

<ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Description "><ItemTemplate>
 <asp:Label ID="lblpurchDesc" runat="server" Text='<%#Eval("Description") %>' />                                                    
</ItemTemplate>
<ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
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
<asp:TemplateField HeaderText="Reced Qty">
<ItemTemplate>
  <asp:Label ID="lblRecedqty" runat="server" Text='<%#Eval("RecedQty") %>' />
</ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="8%"></ItemStyle>
</asp:TemplateField>
<asp:TemplateField HeaderText="Accp Qty">
    <ItemTemplate>
        <asp:Label ID="lblaccpQty" runat="server" Visible="true" Text='<%#Eval("AcceptedQty")%>'></asp:Label>        
        
    </ItemTemplate>    
    <ItemStyle HorizontalAlign="right" Width="8%" />
    <EditItemTemplate>
    <asp:TextBox ID="TxtaccpQty" CssClass="box3" Width="75%"  runat="server" Visible="true" Text='<%#Eval("AcceptedQty")%>'></asp:TextBox>    
    <asp:RequiredFieldValidator ID="ReqAccQty" runat="server" ControlToValidate="TxtaccpQty" ValidationGroup="edit" ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegAccQty" runat="server" ValidationGroup="edit"
            ControlToValidate="TxtaccpQty" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
        </asp:RegularExpressionValidator>
    </EditItemTemplate>
</asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason">
                        <ItemTemplate>  
                        <asp:Label ID="lblrejreason" Text='<%#Eval("RejReason")%>' runat="server"></asp:Label>                         
                        </ItemTemplate>                        
                        <EditItemTemplate>                                                   
                            <asp:DropDownList ID="drprejreason" runat="server" CssClass="box3" DataSourceID="SqlDataSource1" DataTextField="Symbol" DataValueField="Id">                            
                          </asp:DropDownList>
 </EditItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="8%"></ItemStyle>                        
   
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="S/N">
                        <ItemTemplate>                                               
                        <asp:Label ID="lblsn" runat="server" Text='<%#Eval("sn") %>'></asp:Label>    
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="txtSN" runat="server" CssClass="box3" Width="75%" ValidationGroup="A" Visible="true" Text='<%#Eval("sn") %>'></asp:TextBox>
                  
                  <asp:RequiredFieldValidator ID="ReqSn" runat="server" ControlToValidate="txtSN" ValidationGroup="edit" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                             <ItemStyle HorizontalAlign="Left" Width="8%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="P/N">
                        <ItemTemplate>                       
                        <asp:Label ID="lblpn" runat="server" Text='<%#Eval("pn") %>'></asp:Label>          
                        </ItemTemplate>
                        <EditItemTemplate>
 <asp:TextBox ID="txtPN" runat="server" CssClass="box3" Width="75%" ValidationGroup="A" Visible="true" Text='<%#Eval("pn") %>'></asp:TextBox>
                   <asp:RequiredFieldValidator ID="ReqPn" runat="server" ControlToValidate="txtPN" ValidationGroup="edit" ErrorMessage="*"></asp:RequiredFieldValidator>    
                        </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="8%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                         <asp:Label ID="lblremarks" Text='<%#Eval("Remarks")%>' runat="server"></asp:Label>
                        </ItemTemplate>
                        
                        <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                        <EditItemTemplate>
    <asp:TextBox ID="Txtremarks" CssClass="box3"  runat="server" Visible="true" Text='<%#Eval("Remarks")%>'></asp:TextBox>
    </EditItemTemplate>
    
                        </asp:TemplateField >
                        
                  
                         <asp:TemplateField HeaderText="RejectionReason" Visible="false">
                       <ItemTemplate>
                       <asp:Label ID="lblRejectionReason" Text='<%#Eval("RejectionReason")%>' runat="server"></asp:Label>
                       </ItemTemplate>
                              </asp:TemplateField> 
                               <asp:TemplateField HeaderText="AHId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblahid" runat="server" Text='<%#Eval("AHId") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="true" HeaderText="Total Accepted Qty"><ItemTemplate>
                        <asp:Label ID="lblaccpQty1" runat="server" Visible="true" Text='<%#Eval("AcceptedQty")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                      
                        <asp:TemplateField Visible="false" HeaderText="ItemId"><ItemTemplate>
                                                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>' />
                                                    
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
                            <tr><td style="text-align: right" height="22">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                            ProviderName="System.Data.SqlClient" 
                            SelectCommand="SELECT [Symbol],[Id] FROM [tblQc_Rejection_Reason]"></asp:SqlDataSource>

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

