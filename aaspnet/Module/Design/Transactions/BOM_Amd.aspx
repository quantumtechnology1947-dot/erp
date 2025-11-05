<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_BOM_Amd, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
        .style5
        {
            width: 100%;
        }
        .fontcss
        {
            width: 294px;
            margin-left: 12px;
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
   <table cellpadding="2" class="style5" width="98%">
    <tr>
    <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
            height="21">&nbsp;<b>BOM 
        Item - Amendment&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WO No:&nbsp;<asp:Label runat="server" ID="lblWONo"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
        </td>
    </tr>
        <tr>
            <td align="center" valign="top">
            
            
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                                OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="17" 
                                                Width="100%"  AllowPaging="True" 
                                           ><Columns>
                                          <asp:TemplateField             HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    </asp:TemplateField>
                                                    
                                            
                                            
                                            
                                             <asp:TemplateField  HeaderText="Date"  >
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SysDate") %>' ></asp:Label>  
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="6%"  HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            
                                           <asp:TemplateField  HeaderText="Date"  >
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("SysTime") %>' ></asp:Label>  
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="6%"  HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                             
                                            
            
                                                    <asp:TemplateField HeaderText="WONo" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblWONo" runat="server" Text='<%# Bind("WONo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="8%"  HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                        </ItemTemplate>                                                     
                                                       
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amendment No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmdNo" runat="server" Text='<%# Bind("AmdNo") %>'></asp:Label>                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                
                                                
                                                <asp:TemplateField HeaderText="Item Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                              
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ManfDesc") %>'></asp:Label> 
                                                        </ItemTemplate>
                                                      
                                                        
                                                        <ItemStyle Width="35%"  VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UOM">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UOM") %>'></asp:Label>
          
                                                    </ItemTemplate>
                                                  
                                                   
                                                    <ItemStyle HorizontalAlign="Center"  VerticalAlign="Top" Width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
     
      
                                                    </ItemTemplate>
                                                  
                                                    
                                                    <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="8%" />
                                                </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="Amd by">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("AmdBy") %>'></asp:Label>
     
      
                                                    </ItemTemplate>
                                                  
                                                    
                                                    <ItemStyle HorizontalAlign="Right"  VerticalAlign="Top" Width="20%" />
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
        
        <td align="center">
        
        
            <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                onclick="Button2_Click" Text="Cancel" />
        
        
        </td>
        </tr>
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

