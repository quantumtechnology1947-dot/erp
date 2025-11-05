<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_WIS_View_TransWise, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
   
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td  align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Transaction wise WIS Issue Of WONo: <asp:Label ID="LblWONo" runat="server" Text="Label"></asp:Label></b></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" ScrollBars="Auto" Height="445px" runat="server">
                
                <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                    onrowcommand="GridView2_RowCommand" 
                    onpageindexchanging="GridView2_PageIndexChanging" PageSize="20">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>                        
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton ID="lnkbtn" runat="server"  CommandName="Sel" Text="Select"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField> 
                           <asp:TemplateField HeaderText="WIS No">
                           <ItemTemplate>
                          <asp:Label ID="LblWISNo" runat="server"  Text='<%#Eval("WISNo") %>'></asp:Label>
                          
                           </ItemTemplate>
                               <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                          <asp:Label ID="LblDate" runat="server"  Text='<%#Eval("SysDate") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time">
                         <ItemTemplate>
                          <asp:Label ID="LblTime" runat="server"  Text='<%#Eval("SysTime") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        
                        
                        
                        
                        
                         <asp:TemplateField HeaderText="Try Out From Date">
                        <ItemTemplate>
                          <asp:Label ID="LbltryoutFDate" runat="server"  Text='<%#Eval("TaskTargetTryOut_FDate") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                         <asp:TemplateField HeaderText="Try Out To Date">
                        <ItemTemplate>
                          <asp:Label ID="LbltryoutTDate" runat="server"  Text='<%#Eval("TaskTargetTryOut_TDate") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Dispatch From Date">
                        <ItemTemplate>
                          <asp:Label ID="LblDFDate" runat="server"  Text='<%#Eval("TaskTargetDespach_FDate") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        
                        
                         <asp:TemplateField HeaderText="Dispatch To Date">
                        <ItemTemplate>
                          <asp:Label ID="LblDTDate" runat="server"  Text='<%#Eval("TaskTargetDespach_TDate") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Gen. By">
                        
                         <ItemTemplate>
                          <asp:Label ID="LblGenBy" runat="server"  Text='<%#Eval("GenBy") %>'></asp:Label>
                          
                           </ItemTemplate>
                            <ItemStyle Width="25%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="false">                        
                         <ItemTemplate>
                          <asp:Label ID="LblId" runat="server"  Text='<%#Eval("Id") %>'></asp:Label>
                          
                           </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                                    <table width="100%" class="fontcss"><tr><td align="center" >
                                    <asp:Label ID="Label1" runat="server"  Text="No  data found to display" Font-Bold="true"
    Font-Names="Calibri" ForeColor="red"></asp:Label></td></tr>
    </table>
                                    </EmptyDataTemplate>
                    
                </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
        <td align="center" class="style4" colspan="2" height="25">
               
                               <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="redbox" 
                    valign="top" onclick="Cancel_Click"/>
                    
                    </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

