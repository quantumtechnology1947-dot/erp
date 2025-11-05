<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Budget_WONo_Details_Time.aspx.cs" Inherits="Module_Accounts_Transactions_Budget_WONo_Details_Time"  Theme ="Default" %>

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
        .style3
        {
            font-weight: bold;
        }
        .style4
        {
            height: 20px;
            width: 116px;
        }
        .style5
        {
            height: 20px;
            width: 337px;
        }
        .style6
        {
            height: 20px;
            width: 101px;
        }
        .style7
        {
            width: 337px;
        }
        .style8
        {
            height: 22px;
            width: 116px;
        }
        .style9
        {
            height: 22px;
            width: 337px;
        }
        .style10
        {
            height: 22px;
            width: 101px;
        }
        .style11
        {
            height: 22px;
        }
        .style12
        {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-style: normal;
            line-height: normal;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
            color: #000000;
            text-decoration: none;
            width: 62%;
        }
        .style14
        {
            color: #FF0000;
        }
    </style>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
    <form id="form1" runat="server">
   
    <table align="left" class="style12" cellpadding="0" 
        cellspacing="0" ><tr >
            <td align="left" valign="middle"  scope="col"   
                            style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
                            height="21" colspan="4">&#160;<b>Hrs Budget - Details</b></td></tr>
        <tr>
            <td align="left" class="style4">
                <span lang="en-us">&nbsp;</span><asp:Label ID="lblwn" runat="server" Text="WO No" CssClass="style3"></asp:Label>
               
            </td>
            <td align="left" class="style5">
                <asp:Label ID="lblWONo" runat="server" 
                    ></asp:Label>
            </td>
            <td align="left" class="style6">
                <span lang="en-us">&nbsp;</span><asp:Label ID="Label6" runat="server" CssClass="style3" Text="Category"></asp:Label>
            </td>
            <td align="left" class="style2">
                <asp:Label ID="lblCate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style8">
                <span lang="en-us">&nbsp;</span><asp:Label ID="Label4" runat="server" Text="Equipment No." 
                    CssClass="style3"></asp:Label>
            </td>
            <td align="left" class="style9">
                <asp:Label ID="lblEquipNo" runat="server"></asp:Label>
            </td>
            <td align="left" class="style10">
                <span lang="en-us">&nbsp;</span><asp:Label ID="Label7" runat="server" CssClass="style3" Text="Sub-Category"></asp:Label>
            </td>
            <td align="left" class="style11">
                <asp:Label ID="lblSubCate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style4" valign="top">
                <span lang="en-us">&nbsp;</span><asp:Label ID="Label5" runat="server" Text="Description" 
                    CssClass="style3"></asp:Label>
                </td>
            <td align="left" class="style7" rowspan="3" valign="top">
                <asp:Label ID="lblDesc" runat="server"></asp:Label>
            </td>
            <td align="left" class="style6">
                <span lang="en-us">&nbsp;</span><asp:Label ID="lblThr" runat="server" Text="Budget Hrs" CssClass="style3"></asp:Label>
            </td>
            <td align="left" class="style2">
            <asp:Label ID="lblTotalHr" runat="server" 
                    ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style4">
                &nbsp;</td>
            <td align="left" class="style6">
                <span lang="en-us">&nbsp;</span><asp:Label ID="lblUhr" runat="server" Text="Utilized Hrs" CssClass="style3"></asp:Label>
            </td>
            <td align="left" class="style2">
                <asp:Label ID="lblUsedHr" runat="server" 
                    ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style4">
                &nbsp;</td>
            <td align="left" class="style6">
                <span lang="en-us">&nbsp;</span><asp:Label ID="lblBhr" 
                    runat="server" Text="Bal Hrs" CssClass="style3"></asp:Label>
            </td>
            <td align="left" class="style2">
                <asp:Label 
                    ID="lblBalHr" runat="server" 
                    ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="style2" colspan="4" >
                <span lang="en-us">&nbsp;</span></td>
        </tr>
        <tr>
            <td align="left" class="fontcss" colspan="4">
               <asp:Panel ID="Panel1" runat="server"  Height="260px">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Id"  Width="90%" 
                    AllowPaging="True" CssClass="yui-datatable-theme" onrowupdating="GridView2_RowUpdating" 
                        PageSize="20" onpageindexchanging="GridView2_PageIndexChanging" 
                        onrowcommand="GridView2_RowCommand"  >
                        <PagerSettings PageButtonCount="40" />
                        <Columns>
                            <asp:TemplateField HeaderText="SN" SortExpression="Id">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CK">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                        OnCheckedChanged="CheckBox1_CheckedChanged" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" CommandName="del" Text ="Delete" runat="server"
                            OnClientClick=" return confirmationDelete()" ></asp:LinkButton>                    
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                            </asp:TemplateField>
            
                            <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("SysDate") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" SortExpression="Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" runat="server" Text='<%#Eval("SysTime") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hrs" SortExpression="Hrs">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Hour")%>' > </asp:Label>
                                    <asp:TextBox ID="TxtAmount" runat="server" Text='<%#Eval("Hour")%>' 
                                Visible="false" ValidationGroup="A" >
                                    </asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" ErrorMessage="*" ControlToValidate="TxtAmount" 
                                ValidationExpression="^[1-9]\d*(\.\d+)?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </asp:Panel>
            </td>
        </tr>
       
        <tr>
        <td align="center" colspan="4" height="25" valign="middle">
                   <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox"  Text="Update"  OnClientClick=" return confirmationUpdate()"
                       ValidationGroup="A" onclick="BtnUpdate_Click"  />
                    &nbsp;<asp:Button ID="BtnCancel" runat="server" Text="Cancel" 
                       CssClass="redbox" onclick="BtnCancel_Click"  />
        
                   <span lang="en-us">&nbsp; 
                <asp:Label ID="lblMessage" runat="server" CssClass="style14" ></asp:Label> </span>
        
        </td>
        </tr>
       
        </table>
    
    
    </form>
</body>
</html>
