<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysSupport_ECN_ViewAll, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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

<table class="fontcss" cellpadding="0" cellspacing="0" width="100%">
              <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../images/hdbg.JPG")" colspan="2">
        &nbsp;<b>ECN</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>WONo:&nbsp; </strong>
                <asp:Label ID="lblWono" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>
            <tr>
                <td colspan="4">
                    <asp:Panel ID="Panel1" ScrollBars="Auto" Height="430Px" runat="server">
                   
                     <asp:GridView ID="GridView1"  runat="server"
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" DataKeyNames="ItemId" 
                    CssClass="yui-datatable-theme"  >
                
                         <PagerSettings PageButtonCount="40" />
                
                <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="ItemId">
                       <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                                               
             
                                               
                        <asp:TemplateField HeaderText="ItemId" SortExpression="ItemId" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'>    </asp:Label>                                  </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                                               
                         <asp:TemplateField HeaderText="ItemCode" >
                        <ItemTemplate>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'>    </asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="center" Width="10%" />  
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Description" >
                        <ItemTemplate>
                        <asp:Label ID="lblManfDesc" runat="server" Text='<%#Eval("ManfDesc") %>'>    </asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="Left" Width="35px" />                                                               
                        </asp:TemplateField>
                        
                     <asp:TemplateField HeaderText="UOM" >
                        <ItemTemplate>
                        <asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="center" Width="5%" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="BOM Qty" >
                        <ItemTemplate>
                        <asp:Label ID="lblBOMQty" runat="server" Text='<%#Eval("BOMQty") %>'></asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Reason" >
                        <ItemTemplate>
                        <asp:Label ID="lblReason" runat="server" Text='<%#Eval("Reason") %>'></asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="Left" Width="20%" />                      
                        </asp:TemplateField>                     
                        
                        
                        
                        <asp:TemplateField HeaderText="Remarks" >                
                        
                        <ItemTemplate>
                        <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="Left" Width="25%" />                      
                        </asp:TemplateField>
                       
                        
                     
                                
                        
                        
                </Columns>
                
                <EmptyDataTemplate>
                                    <table width="100%" class="fontcss"><tr><td align="center" >
                                    <asp:Label ID="Label1" runat="server"  Text="No  data found to display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                                            <FooterStyle Wrap="True">
                                            </FooterStyle>
                    
                </asp:GridView>
                </asp:Panel>
                
                
                </td>
            </tr>
            <tr>
             <td style="height:25px" align="center" colspan="4" valign="bottom">
                 &nbsp;<asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                     onclick="BtnCancel_Click" Text="Cancel" />
                </td>
            </tr>
            </table>
   

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

