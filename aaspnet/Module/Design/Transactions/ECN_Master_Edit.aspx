<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ECN_Master_Edit.aspx.cs" Inherits="Module_Design_Transactions_ECN_Master_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />    
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">



<table class="fontcss" cellpadding="0" cellspacing="0" width="60%">
              <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>ECN</b></td>
        </tr>
            <tr>
                <td colspan="4">
                     <asp:GridView ID="GridView1"  runat="server"
                    AutoGenerateColumns="False"  PageSize="15" Width="100%" DataKeyNames="Id" 
                    CssClass="yui-datatable-theme" onrowcommand="GridView1_RowCommand" ShowFooter="True"  >
                
                         <PagerSettings PageButtonCount="40" />
                
                <Columns>
                        <asp:TemplateField HeaderText="SN" SortExpression="Id">
                       <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                                               
             
                                               
                       <asp:TemplateField >
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                       
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
        </asp:TemplateField>
                                               
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>                                  </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                     
                                               
                         <asp:TemplateField HeaderText="Description" >
                        <ItemTemplate>
                        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Types") %>'>    </asp:Label>
                        </ItemTemplate>                                            
                             <ItemStyle HorizontalAlign="Left" Width="65%" />   
                             
                               <FooterTemplate>
                                
                              
                                     
                                     
                            </FooterTemplate> <FooterStyle HorizontalAlign="Right" />
                                                                      
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Remarks" >
                        
                        
                        <ItemTemplate>
                          <asp:TextBox ID="TxtRemarks" CssClass="box3"  Width="95%"  runat="server"></asp:TextBox>  
                       
                     
                         </ItemTemplate>   <ItemStyle Width="28%" />
                        <FooterTemplate>                                                       
                                     
                                       <asp:Button ID="BtnInsert" runat="server" Width="45px" ValidationGroup="A" OnClientClick="return confirmationAdd()" CommandName="Ins" CssClass="redbox" 
                                     Text="Insert"  />
                            </FooterTemplate> <FooterStyle HorizontalAlign="Right" />
                      
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
                    
                </asp:GridView></td>
               
            </tr>
            <tr>
             <td style="height:22px" align="center" colspan="4">
                <asp:Button ID="BtnCancel" runat="server" Width="50px" Text="Cancel" onclick="BtnCancel_Click" CssClass="redbox" /></td>
            </tr>
            </table>
   


</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

