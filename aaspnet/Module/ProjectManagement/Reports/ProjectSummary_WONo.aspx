<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectSummary_WONo.aspx.cs" Inherits="Module_ProjectManagement_Reports_ProjectSummary_WONo" Title="ERP" Theme="Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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

<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
       
                
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" ><strong>&nbsp;Project Summary </strong>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    
                            <asp:Panel ID="Panel1" runat="server" Height="440px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server"  
                                    AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="WONo"  Width="100%" AllowPaging="True" 
                                    PageSize="15" onpageindexchanging="GridView1_PageIndexChanging"  
                                   >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN" >
                            <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="WO No"  >
                            <ItemTemplate>
                                <asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>

                    
                    
                        <asp:TemplateField HeaderText="Project Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblProjectTitle" runat="server" Text='<%#Eval("TaskProjectTitle") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="7%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Customer Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="9%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Code" >
                            <ItemTemplate>
                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("CustomerId") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UOM">
                            <ItemTemplate>
                                <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="B" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblBOMQty" runat="server" Text='<%#Eval("BOMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="BOM(M)" >
                            <ItemTemplate>
                                <asp:Label ID="lblBOM_Mfg_Qty" runat="server" Text='<%#Eval("BOM_MFG_Qty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2.5%" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="B" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblWIS" runat="server" Text='<%#Eval("WISQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField> 
                        
                        
                        <asp:TemplateField HeaderText="M" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblWIS_M" runat="server" Text='<%#Eval("WISMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="B"  Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblBShort" runat="server" Text='<%#Eval("ShortBQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="M" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblMShort" runat="server" Text='<%#Eval("ShortMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField> 
                        
                        
                        
                         <asp:TemplateField HeaderText="B" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblPOBQty" runat="server" Text='<%#Eval("POBQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="O" Visible ="false">
                            <ItemTemplate>
                                <asp:Label ID="lblPOMQtyF" runat="server" Text='<%#Eval("POMQtyF") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2.5%" />
                        </asp:TemplateField>  
                        
                         <asp:TemplateField HeaderText="A" Visible ="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblPOMQtyA" runat="server" Text='<%#Eval("POMQtyA") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2.5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="F+O" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblPOMQtyO" runat="server" Text='<%#Eval("POMQtyO") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2.5%" />
                        </asp:TemplateField> 
                                                
                         <asp:TemplateField HeaderText="Tot M" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblPOMQty" runat="server" Text='<%#Eval("POMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>  
                        
                         <asp:TemplateField HeaderText="B" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblGRRB" runat="server" Text='<%#Eval("GRRBQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="F" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblGRRMQtyF" runat="server" Text='<%#Eval("GRRMQtyF") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="A" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblGRRMQtyA" runat="server" Text='<%#Eval("GRRMQtyA") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="O" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblGRRMQtyO" runat="server" Text='<%#Eval("GRRMQtyO") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField> 
                        
                           <asp:TemplateField HeaderText="RECVD(M)" >
                            <ItemTemplate>
                                <asp:Label ID="lblGRR" runat="server" Text='<%#Eval("GRRQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                           
                           <asp:TemplateField HeaderText="B" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblGQN" runat="server" Text='<%#Eval("GQNQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                          <asp:TemplateField HeaderText="F" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblGQNMQtyF" runat="server" Text='<%#Eval("GQNMQtyF") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="A" Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="lblGQNMQtyA" runat="server" Text='<%#Eval("GQNMQtyA") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="O"  Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblGQNMQtyO" runat="server" Text='<%#Eval("GQNMQtyO") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                                             
                        
                         <asp:TemplateField HeaderText="Tot M" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblMGQN" runat="server" Text='<%#Eval("GQNMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                            <asp:TemplateField HeaderText="B" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblBREJ" runat="server" Text='<%#Eval("RejBQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="F" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblFREJ" runat="server" Text='<%#Eval("RejQtyF") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="A"  Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblAREJ" runat="server" Text='<%#Eval("RejQtyA") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>   
                        
                        <asp:TemplateField HeaderText="O" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblOREJ" runat="server" Text='<%#Eval("RejQtyO") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>   
                        
                        
                         <asp:TemplateField HeaderText="Tot M" Visible=false>
                            <ItemTemplate>
                                <asp:Label ID="lblMREJ" runat="server" Text='<%#Eval("RejMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>                      
                        
                        
                     
                        
                        <asp:TemplateField HeaderText="B" Visible=false >
                            <ItemTemplate>
                                <asp:Label ID="lblBQA" runat="server" Text='<%#Eval("QABQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Balance"  >
                            <ItemTemplate>
                                <asp:Label ID="lblMQA" runat="server" Text='<%#Eval("QAMQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance"  visible="false">
                            <ItemTemplate>
                                <asp:Label ID="Idbal" runat="server" Text=''>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
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
                    <tr>
        <td align="center" height="25px" valign="middle">
        
                
                <asp:Button ID="btnExport" runat="server" CssClass="redbox" Text="Export" 
                    onclick="btnExpor_Click" />
                    
                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" Text="Cancel" 
                    onclick="btnCance_Click" />
                    
        </td>
        </tr>
                    
                    
                    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

