<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Budget_Labour_Details.aspx.cs" Inherits="Module_Accounts_Transactions_BudgetDetails" Title="ERP" Theme ="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            height: 24px;
            }
        .style4
        {
            height: 40px;
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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
    <table align="center" cellpadding="0" cellspacing="0" width="50%" class="box3">
 
        <tr>
            <td align="left" valign="middle"  scope="col"  
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">
                            &nbsp;<b>Labour Budget</b></td>
        </tr>
    
        <tr>
            <td align="left" class="style3" >
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Budget Code"></asp:Label>
            &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCode" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
                &nbsp;
                </td>
        </tr>
        <tr>
            <td align="left" class="style3">
                &nbsp;
                <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id"  Width="100%" ShowFooter="True"
                    AllowPaging="True" CssClass="yui-datatable-theme" 
                    onrowcommand="GridView2_RowCommand" 
                    onrowupdating="GridView2_RowUpdating" PageSize="20"  >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                    
                     <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                       
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                       
                       <asp:TemplateField HeaderText="CK">
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"  runat="server"/>
        </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Date" SortExpression="Date">
                        <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                             <ItemStyle HorizontalAlign="Center" />
                        
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Time" SortExpression="Time">
                        <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%#Eval("SysTime") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                             <ItemStyle HorizontalAlign="Center" />
                        
                        </asp:TemplateField>
                        
                        
                          <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                        <ItemTemplate>
              <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>' >    </asp:Label> 
                        
                           <asp:TextBox ID="TxtAmount" runat="server" Text='<%#Eval("Amount")%>' Visible="false"  ValidationGroup="A">
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtAmount" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                       
                        
                          <FooterTemplate> 
                  <asp:Button ID="BtnUpdate" runat="server"  ValidationGroup="A" Text="Update" CommandName="Update" CssClass="redbox" />
                   <asp:Button ID="BtnDelete" runat="server" Text="Delete" CommandName="Deletes" CssClass="redbox" />
                  </FooterTemplate>
                        
                              <FooterStyle HorizontalAlign="Right" />
                        
                              <ItemStyle HorizontalAlign="Right" />
                        
                        </asp:TemplateField>
                    
                       
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        
       
        <tr>
            <td align="center" class="style4">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
                    &nbsp;<asp:Button ID="BtnExport" runat="server" onclick="BtnExport_Click" 
                    Text="Export" CssClass="redbox" />
            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                    onclick="btnCancel_Click" Text="Cancel" />
            </td>
        </tr>
        
       
        </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

