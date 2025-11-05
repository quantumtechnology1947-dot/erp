<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_MaterialCreditNote_MCN_Print_Details, newerp_deploy" title="ERP" theme="Default" %>

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
                style="background:url(../../../images/hdbg.JPG)" colspan="3">&nbsp;<b>Material Credit Note [MCN] - Print</b></td>
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
                    CssClass="yui-datatable-theme"   Width="40%" DataKeyNames="Id"
                                    onpageindexchanging="GridView1_PageIndexChanging"  
                                onrowcommand="GridView1_RowCommand" 
                               >
                    <PagerSettings PageButtonCount="40" />
                    
                    <Columns>
                        <asp:TemplateField HeaderText="SN" >
                            <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        
                             <asp:TemplateField  >
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1"  CommandName="Print" runat="server">Print</asp:LinkButton>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        
                        
                        
                        
                        
                        
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                        
                            
                        
                        <asp:TemplateField HeaderText="MCN No">
                            <ItemTemplate>
                                <asp:Label ID="lblMCNNo" runat="server" Text='<%#Eval("MCNNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("MCNDate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
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

