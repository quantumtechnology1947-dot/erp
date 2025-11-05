<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Masters_PF_Slab, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
    <table cellpadding="0" cellspacing="0" width="40%" align="center">
        <tr>
            <td align="center" valign="top" height="10px">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;PF Slab</b></td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <asp:GridView ID="GridView1" 
                runat="server" 
                AllowPaging="True"
                ShowFooter="True" 
                AutoGenerateColumns="False" 
                DataKeyNames="Id" 
                FooterStyle-Wrap="True"
                OnRowDeleted="GridView1_RowDeleted" 
               
                OnRowUpdated="GridView1_RowUpdated" 
                OnRowCommand="GridView1_RowCommand"
                CssClass="yui-datatable-theme" onrowdatabound="GridView1_RowDataBound" 
                    Width="100%" PageSize="17" onrowupdating="GridView1_RowUpdating" 
                    onrowediting="GridView1_RowEditing1" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowdeleting="GridView1_RowDeleting">

                    <Columns>

                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %> 
                        </ItemTemplate>
                        <FooterTemplate>
                                <asp:Button ID="btnInsert" runat="server" CommandName="Add" ValidationGroup="Ins" OnClientClick=" return confirmationAdd() " CssClass="redbox" 
                                    Text="Insert" />
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        
                        
                      <asp:CommandField    ButtonType ="Link" ShowEditButton="True" 
                            ValidationGroup="up" >
                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:CommandField>
                       <asp:CommandField    ButtonType ="Link" ShowDeleteButton="True"   >

                           <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:CommandField>

                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </ItemTemplate>                            
                            <EditItemTemplate>
                                <asp:Label ID="lblIDE" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                            </EditItemTemplate>
                            
                            
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="PF Employee" SortExpression="PFEmployee">
                        <ItemTemplate>
                        <asp:Label ID="lblPFEmployee" runat="server" Text='<%#Eval("PFEmployee") %>'>    </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox CssClass="box3" Width="80%" ID="txtPFEmployee0" runat="server" Text='<%#Bind("PFEmployee") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqPFEmployee0" runat="server" ControlToValidate="txtPFEmployee0" 
                        ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                        <asp:RegularExpressionValidator ID="RegularPFEmployee0" runat="server" 
                        ControlToValidate="txtPFEmployee0" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="up">
                        </asp:RegularExpressionValidator>

                        
                        
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtPFEmployee" Width="80%" runat="server"  CssClass="box3"> 
                        </asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqPFEmployee" runat="server" ControlToValidate="txtPFEmployee"
                             ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                             
                       <asp:RegularExpressionValidator ID="RegularPFEmployee" runat="server" 
                        ControlToValidate="txtPFEmployee" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Ins">
                        </asp:RegularExpressionValidator>

                             
                        </FooterTemplate>
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="PF Company" SortExpression="PFCompany">
                        <ItemTemplate>
                        <asp:Label ID="lblPFCompany" runat="server" Text='<%#Eval("PFCompany") %>'>    </asp:Label>
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:TextBox ID="txtPFCompany0" Width="80%" CssClass="box3" runat="server" Text='<%#Bind("PFCompany") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqtxtPFCompany0" runat="server" ControlToValidate="txtPFCompany0"
                          ValidationGroup="up" ErrorMessage="*"></asp:RequiredFieldValidator>
                          
                        <asp:RegularExpressionValidator ID="RegulartxtPFCompany0" runat="server" 
                        ControlToValidate="txtPFCompany0" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="up">
                        </asp:RegularExpressionValidator>

                          
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                        <asp:TextBox ID="txtPFCompany" Width="80%" runat="server" CssClass="box3">
                        </asp:TextBox> 
                         <asp:RequiredFieldValidator ID="ReqtxtPFCompany" runat="server" ControlToValidate="txtPFCompany"
                          ValidationGroup="Ins" ErrorMessage="*"></asp:RequiredFieldValidator>
                          
                     <asp:RegularExpressionValidator ID="RegulartxtPFCompany" runat="server" 
                        ControlToValidate="txtPFCompany" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="Ins">
                        </asp:RegularExpressionValidator>
                      
                        </FooterTemplate>                        
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Active">
                            <ItemStyle HorizontalAlign="Center" Width="18%" />
                            <ItemTemplate>
                            <asp:Label ID="lblActive" runat="server" Text='<%#Eval("Active") %>'>    </asp:Label>
                            </ItemTemplate>                            
                        <EditItemTemplate>
                       <%-- <asp:Label ID="lblActive2" Visible="false" runat="server" Text='<%#Eval("Active") %>'>    </asp:Label>--%>
                        <asp:CheckBox ID="ChkActive0" runat="server"></asp:CheckBox>
                       <%-- <asp:CheckBox ID="CheckBox2"  runat="server" />--%>
                        </EditItemTemplate>
                        
                            <FooterTemplate>
                            <asp:CheckBox ID="ChkActive" runat="server"></asp:CheckBox>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>

<FooterStyle Wrap="True"></FooterStyle>
             <EmptyDataTemplate>
             
             <table  width="100%" border="1" style="border-color:Gray">
                    <tr>
                    <td></td>
                    <td align="center">
                        <asp:Label ID="Label1" Font-Bold="true" Font-Size="Medium" Font-Names="Times New Roman" runat="server" Text="PFEmployee"></asp:Label></td>
                        
                        <td align="center">
                         <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Names="Times New Roman"  Font-Bold="true" Text="PFCompany"></asp:Label></td>
                         <td align="center">
                          <asp:Label ID="Label3" runat="server" Font-Size="Medium"  Font-Names="Times New Roman" Font-Bold="true" Text="Active"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Button ID="btnInsert" runat="server" CommandName="Add1" OnClientClick=" return confirmationAdd() " CssClass="redbox" Text="Insert" />
                </td>
                
                <td>
                <asp:TextBox ID="txtPFEmployee1" runat="server" Width="200"></asp:TextBox>
                
                </td>
                <td>
                <asp:TextBox ID="txtPFCompany1" runat="server" Width="127"></asp:TextBox>
                </td>
                <td>
                <asp:CheckBox ID="ChkActive1" runat="server"></asp:CheckBox>
                </td>
                </tr>
                </table>
                
            </EmptyDataTemplate>                    
            </asp:GridView>               
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>               
               </td>
        </tr>
        </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

