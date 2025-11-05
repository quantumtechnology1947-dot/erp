<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_WONo_Details_TimeCopy.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_WONo_Details_TimeCopy"  Theme ="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">


        .style1
        {
        }
        .style2
        {
            height: 20px;
        }
    </style>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

</head>
<body>
     <form id="form1" runat="server">
   
    <table align="center" width="60%" class="fontcss" cellpadding="0" 
        cellspacing="0" ><tr ><td align="left" valign="middle"  scope="col"   
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21">&#160;<b>Budget-Hrs</b></td></tr>
        <tr>
            <td align="left" class="style2">
                <asp:Label ID="Label5" runat="server" Text="WO No"></asp:Label>
               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
                <asp:Label ID="lblWONo" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style2" >
                <asp:Label ID="Label2" runat="server" Text="Budget Code"></asp:Label>
                &nbsp;<asp:Label ID="lblCode" runat="server" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Description"></asp:Label>
            &nbsp;
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="fontcss">
                <asp:Panel ID="Panel1" runat="server"  Height="330px" ScrollBars="Vertical">
               
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id"  Width="100%" 
                    AllowPaging="True" CssClass="yui-datatable-theme" 
                    onrowcommand="GridView2_RowCommand" onrowupdating="GridView2_RowUpdating" 
                        PageSize="20" onpageindexchanging="GridView2_PageIndexChanging"  >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                   
                     <asp:TemplateField HeaderText="SN" SortExpression="Id">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                       
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                       
                       <asp:TemplateField HeaderText="CK">
        <ItemTemplate>
        <asp:CheckBox ID="CheckBox1" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"  runat="server"/>
        </ItemTemplate>
        </asp:TemplateField>
                           
                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'>    </asp:Label>    
                          </ItemTemplate>
                      </asp:TemplateField>
                        
                        
                        
                         <asp:TemplateField HeaderText="Date" SortExpression="Date">
                        <ItemTemplate>
                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Time" SortExpression="Time">
                        <ItemTemplate>
                        <asp:Label ID="lblTime" runat="server" Text='<%#Eval("SysTime") %>'>    </asp:Label>                                  </ItemTemplate>
                        
                        </asp:TemplateField>
                        
                        
                          <asp:TemplateField HeaderText="Budget Hrs" SortExpression="Amount">
                        <ItemTemplate>
              <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("BudgetAmtHrs")%>' >    </asp:Label> 
                        
                           <asp:TextBox ID="TxtAmount" runat="server" Text='<%#Eval("BudgetAmtHrs")%>' Visible="false" ValidationGroup="A" >
                                </asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" ControlToValidate="TxtAmount" ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </ItemTemplate><ItemStyle HorizontalAlign="Right" />
                                              
                          <FooterTemplate> 
                  
                  </FooterTemplate>
                        
                        </asp:TemplateField>
                    
                       
                    </Columns>
                </asp:GridView>
                 </asp:Panel>
            </td>
        </tr>
        <tr>
        <td align="center" height="25px" valign="bottom">
                   <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox"  Text="Update"  OnClientClick=" return confirmationUpdate()"
                       ValidationGroup="A" onclick="BtnUpdate_Click"  />
                   &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="redbox"  OnClientClick=" return confirmationDelete()" 
                       Text="Delete" onclick="BtnDelete_Click"  />    
                    &nbsp;<asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                       CssClass="redbox" onclick="BtnCancel_Click"  />
        
                   <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="True" 
                    ForeColor="#3333FF"></asp:Label>
                    
        </td>
        </tr>
       
        </table>
        </form>
</body>
</html>
