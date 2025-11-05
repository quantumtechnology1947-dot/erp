<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_Dist_Dept_Details_old.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_Dist_Dept_Details" Theme ="Default"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
   <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
        .style2
        {
            height: 18px;
        }
    </style>
</head>
 
<body>
    <form id="form1" runat="server">
    <table align="center" border="0" cellspacing="0" width="50%" class="fontcss" >
        <tr>
            <td align="left" class="style2">
                &nbsp;<asp:Label ID="Label5" runat="server" Text="Department"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbldept" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style1" >
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Budget Code"></asp:Label>
                &nbsp;&nbsp;<asp:Label ID="lblCode" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
            &nbsp;<asp:Label ID="lblDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id"  Width="100%" ShowFooter="True"
                    AllowPaging="True" CssClass="yui-datatable-theme" 
                    onrowcommand="GridView2_RowCommand" onrowupdating="GridView2_RowUpdating" 
                    PageSize="20">
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
        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Date" SortExpression="Date">
                        <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Time" SortExpression="Time">
                        <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%#Eval("SysTime") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        
                        
                          <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                        <ItemTemplate>
              <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>' >    </asp:Label> 
                        
                           <asp:TextBox ID="TxtAmount" runat="server" Text='<%#Eval("Amount")%>' Visible="false"  ValidationGroup="A" >
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtAmount" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                       
                        
                          <FooterTemplate> 
                  <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox" ValidationGroup="A" Text="Update" CommandName="Update" />
                   <asp:Button ID="BtnDelete" runat="server" CssClass="redbox"  Text="Delete" CommandName="Deletes" />
   <asp:Button ID="btnCancel"  CssClass="redbox" runat="server" Text="Cancel"  CommandName="cancel"
                           />
                  </FooterTemplate>                        
                              <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>                   
                       
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        
       
        <tr>
            <td align="center" class="style3">
                <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
                   
            </td>
        </tr>
        
       
        </table>
    
    
    </form>
</body>
</html>
