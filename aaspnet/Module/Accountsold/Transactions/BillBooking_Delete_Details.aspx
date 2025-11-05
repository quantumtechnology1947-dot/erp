<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillBooking_Delete_Details.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_Delete_Details" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
  
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            height: 25px;
        }
    </style>

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

<table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite">
                <b>&nbsp;Bill Booking -Delete</b></td>
        </tr>
        
     <tr>       
            <td align="center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="Id" AllowPaging="True" 
                    Width="100%" onpageindexchanging="GridView1_PageIndexChanging" 
                    onrowcommand="GridView1_RowCommand" PageSize="20" >
                    <Columns>
                 <asp:TemplateField >
                            <ItemTemplate>
                            <asp:LinkButton ID="btndelete" runat="server" Text="Delete" OnClientClick="confirmationDelete()" CommandName="Del" ></asp:LinkButton>                 
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                   
                    
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1  %>
                            </ItemTemplate>
                            <HeaderStyle Font-Size="10pt" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" />
                        </asp:TemplateField>
                
                        <asp:TemplateField HeaderText="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="Server" Text='<%#Eval("Id")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GQN No">
                            <ItemTemplate>
                                <asp:Label ID="lblGQNNo" runat="Server" Text='<%#Eval("GQNNo")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="4%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="GSN No">
                            <ItemTemplate>
                                <asp:Label ID="lblGSNNo" runat="Server" Text='<%#Eval("GSNNo")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"  Width="4%" />
                        </asp:TemplateField>
                         
                           
                          <asp:TemplateField HeaderText="Item Code">
                            <ItemTemplate>
                                <asp:Label ID="lblItemCode" runat="Server" Text='<%#Eval("ItemCode")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Descrption">
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="Server" Text='<%#Eval("Descr")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left"  Width="20%" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="UOM">
                            <ItemTemplate>
                                <asp:Label ID="lblUOM" runat="Server" Text='<%#Eval("UOM")%>'/>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Left"  />
                           
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amt" >
                            <ItemTemplate>
                                <asp:Label ID="lblAmt" runat="Server" Text='<%#Eval("Amt")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right"  />
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="PF Amt" >
                            <ItemTemplate>
                                <asp:Label ID="lblPFAmt" runat="Server" Text='<%#Eval("PFAmt")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right"  />
                        </asp:TemplateField>
                        
                                              
                          
                             <asp:TemplateField HeaderText="Ex/Ser tax" >
                            <ItemTemplate>
                                <asp:Label ID="lblExStBasic" runat="Server" Text='<%#Eval("ExStBasic")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                        
                        
                         <asp:TemplateField HeaderText="Edu Cess" >
                            <ItemTemplate>
                                <asp:Label ID="lblExStEducess" runat="Server" Text='<%#Eval("ExStEducess")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                        
                        
                         <asp:TemplateField HeaderText="She Cess" >
                            <ItemTemplate>
                                <asp:Label ID="lblExStShecess" runat="Server" Text='<%#Eval("ExStShecess")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                        
                         <asp:TemplateField HeaderText="Custom Duty" >
                            <ItemTemplate>
                                <asp:Label ID="lblCustomDuty" runat="Server" Text='<%#Eval("CustomDuty")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="CST" >
                            <ItemTemplate>
                                <asp:Label ID="lblCST" runat="Server" Text='<%#Eval("CST")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                        
                            <asp:TemplateField HeaderText="VAT" >
                            <ItemTemplate>
                                <asp:Label ID="lblVAT" runat="Server" Text='<%#Eval("VAT")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Freight" >
                            <ItemTemplate>
                                <asp:Label ID="lblFreight" runat="Server" Text='<%#Eval(" Freight")%>'/>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField> 
                        
                          <asp:TemplateField HeaderText="Tarrif No" >
                            <ItemTemplate>
                                <asp:Label ID="lblTarrifNo" runat="Server" Text='<%#Eval("TarrifNo")%>'/>
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
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                    
                </asp:GridView>
            </td>
        </tr>
        
        <tr>
        <td align="center" height="24">
        
            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Cancel" />
        
        </td>
        </tr>
    </table>






</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

