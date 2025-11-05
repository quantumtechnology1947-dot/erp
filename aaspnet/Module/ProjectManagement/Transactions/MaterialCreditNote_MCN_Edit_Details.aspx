<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaterialCreditNote_MCN_Edit_Details.aspx.cs" Inherits="Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Edit_Details" Title="ERP" Theme ="Default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
<style type="text/css">
        .style2
        {
            width: 100%;
            height: 335px;
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
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="3">&nbsp;<b>Material Credit Note [MCN] - Edit</b></td>
                    </tr>
                  
                    
                    <tr>
                        <td width="15%" height="25">                       
                         
                &nbsp; <b>WONo : </b>
                            <asp:Label ID="lblWono" runat="server"></asp:Label>
                
             
                        </td>
                        <td width="40%">                       
                         
                            <b>Project Name : </b>
                            <asp:Label ID="lblProjectTitle" runat="server"></asp:Label>
                
             
                        </td>
                        <td width="40%">                       
                         
                            <b>Customer Name : </b>
                            <asp:Label ID="lblCustName" runat="server"></asp:Label>
                
             
                        </td>
                    </tr>
                  
                   
                    
                    <tr>
                        <td colspan="3">                       
                        <asp:Panel ID="Panel1" runat="server" Height="403px" ScrollBars="Auto">   
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme"   Width="100%" DataKeyNames="Id"
                                    onpageindexchanging="GridView1_PageIndexChanging"  
                                onrowcommand="GridView1_RowCommand" onrowediting="GridView1_RowEditing" 
                                onrowupdating="GridView1_RowUpdating" 
                                onrowcancelingedit="GridView1_RowCancelingEdit">
                    <PagerSettings PageButtonCount="40" />
                    
                    <Columns>
                        <asp:TemplateField HeaderText="SN" >
                            <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="ItemId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblPId" runat="server" Text='<%#Eval("PId") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                        
                           <asp:TemplateField HeaderText="CId"  Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblCId" runat="server" Text='<%#Eval("CId") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>     
                        <asp:TemplateField HeaderText="MCN No">
                        <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("MCNNo") %>' ID="lblMCNNo"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                         <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("MCNDate") %>' ID="lblDate"></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Draw/Img" >
                            <ItemTemplate>                                                        
                                <asp:LinkButton ID="lbtnDownload" runat="server" CommandName="Download" Text='<%#Eval("Download") %>'>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         
                        <asp:TemplateField HeaderText="Spec.sheet" >
                            <ItemTemplate>
                            <asp:LinkButton ID="lbtnDownloadSpec" runat="server" CommandName="DownloadSpec"  Text='<%#Eval("DownloadSpec") %>'> 
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                                           
                       
                         <asp:TemplateField HeaderText="Item Code"  >
                            <ItemTemplate>
                                <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                  
                        <asp:TemplateField HeaderText="Description" >
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="UOM" >
                            <ItemTemplate>
                                <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOM") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="BOM Qty" Visible="False" >
                            <ItemTemplate>
                                <asp:Label ID="lblBOMQty0" runat="server" Text='<%#Eval("BOMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:TemplateField>
            
                        
                        <asp:CommandField ShowEditButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:CommandField>
            
                        
                 <asp:TemplateField HeaderText="MCN Qty">
                <ItemTemplate>
                <asp:Label Text='<%#Eval("MCNQty") %>' runat="server" ID="lblMCNQty"></asp:Label>
                    
                </ItemTemplate>
                <ItemStyle Width="17%" HorizontalAlign="left"  />
                <EditItemTemplate>
                <asp:Label ID="lblBOMQty" runat="server" Text='<%#Eval("BOMQty") %>' Visible="false">
                                </asp:Label>
                                <asp:Label ID="lblTotMCNQty" runat="server" Text='<%#Eval("TotMCNQty") %>' Visible="false">
                                </asp:Label>
                                <asp:Label Text='<%#Eval("MCNQty") %>' runat="server" ID="lblMCNQty0" Visible="false"></asp:Label>
                <asp:TextBox ID="txtqty" Text='<%#Eval("MCNQty") %>' runat="server" Width="100" CssClass="box3"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtqty" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A">
                    </asp:RegularExpressionValidator>
                </EditItemTemplate>
                </asp:TemplateField>
                       <asp:TemplateField HeaderText="Tot MCN Qty" Visible="False" >
                            <ItemTemplate>
                                <asp:Label ID="lblTotMCNQty0" runat="server" Text='<%#Eval("TotMCNQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="fontcss" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Names="Calibri" 
                                        ForeColor="red" Text="No  data found to display"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <FooterStyle Wrap="True" />
                </asp:GridView>               
                
             </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
         <tr>
            <td align="center" height="25px" valign="middle">
                <asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" 
                    onclick="btnCancel_Click" />
              </td>
        </tr>
          </table> 
          
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

