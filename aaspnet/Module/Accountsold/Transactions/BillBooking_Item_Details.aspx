<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillBooking_Item_Details.aspx.cs" Inherits="Module_Accounts_Transactions_BillBooking_Item_Details" Theme="Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
 <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style16
        {
            font-weight: bold;
        }
               
        .style21
        {
            text-align: right;
        }
        .style22
        {
            width: 100%;
            float: left;
        }
        .style29
        {
            background-color: #993300;
        }
        .style30
        {
            text-align: left;
            background-color: #993300;
        }
        .style31
        {
            color: #FFFFFF;
        }
        .style32
        {
            background-color: #CCFFFF;
        }
        .style33
        {
            text-align: left;
            background-color: #CCFFFF;
        }
        .style35
        {
            background-color: #FFFFCC;
        }
        .style36
        {
            text-align: left;
            background-color: #FFFFCC;
        }
        .style37
        {
            background-color: #993300;
            text-align: right;
        }
        .style38
        {
            background-color: #CCFFFF;
            text-align: right;
        }
        .style39
        {
            background-color: #FFFFCC;
            text-align: right;
        }
        .style40
        {
            background-color: #CCFFFF;
            text-align: right;
            font-weight: bold;
        }
        .style41
        {
            background-color: #FFFFCC;
            text-align: right;
            font-weight: bold;
        }
    </style>
</head>
<body style="margin-bottom:0px; margin-left:0px; margin-right:0px; margin-top:0px;">
    <form id="form1" runat="server">
    
    
        <table align="left" cellpadding="0" cellspacing="0" class="style22">
            <tr>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" width="100%" class="fontcss">
                        <tr>
                            <td width="200" height="22">
                    <asp:Label ID="lblGNo" runat="server" CssClass="style16"></asp:Label>
                                <span lang="en-us"><b>:</b> </span>
                    <asp:Label ID="lblGqnGsnNo" runat="server"></asp:Label>
                            </td>
                            <td>
                    <b>Item Code:<span lang="en-us"> </span></b>
                    <asp:Label ID="lblItemcode" runat="server"></asp:Label>
                            </td>
                            <td>
                    <b>Unit :</b><asp:Label ID="lblUnit" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="30" valign="top">
                    <b>Description</b></td>
                            <td colspan="2" valign="top">
                    <asp:Label ID="lblDiscription" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
    
    
        <table align="left" cellpadding="0" cellspacing="1" width="950px" 
            class="fontcss">
            <tr>
                <td width="20">
                    &nbsp;</td>
                <td width="170">
                    &nbsp;</td>
                <td width="200">
                    &nbsp;</td>
                <td class="style21">
                    <asp:Label ID="Label2" runat="server" CssClass="style16" 
                        Text="Tariff Class./Entry No."></asp:Label>
                    <span lang="en-us">&nbsp;&nbsp; </span></td>
                <td width="170">
                    <asp:TextBox ID="txtTCEntryNo" runat="server" CssClass="box3">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" 
                        ControlToValidate="txtTCEntryNo" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr bgcolor="#CCFFFF" class="style31">
                <td height="22" class="style37">
                    &nbsp;</td>
                <td height="22" class="style29">
                    &nbsp;</td>
                <td class="style29">
                    <asp:Label ID="Label9" runat="server" CssClass="style16" Text="As Per PO Terms"></asp:Label>
                </td>
                <td class="style30">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label10" runat="server" CssClass="style16" Text="New Terms"></asp:Label>
                    </td>
                <td class="style29">
                    <asp:Label ID="Label11" runat="server" CssClass="style16" Text="Cal. Amt."></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="22" class="style38">
                    &nbsp;</td>
                <td height="22" class="style32">
                    <span lang="en-us">
                    &nbsp;<asp:Label ID="lblRate" runat="server" CssClass="style16" Text="Rate"></asp:Label>
                    </span>
                </td>
                <td class="style32">
                    <asp:Label ID="lblRateAmt" runat="server"></asp:Label>
                </td>
                <td class="style33">
                    <span lang="en-us">
                    <asp:CheckBox ID="CkRate" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkRate_CheckedChanged" />
                    </span><asp:TextBox ID="txtRate" runat="server" CssClass="box3" Enabled="False" 
                        Width="100px">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" 
                        ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                        runat="server" ControlToValidate="txtRate" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                </td>
                <td class="style32">
                    &nbsp;</td>
            </tr>
            <tr>
                <td height="22" class="style39">
                    &nbsp;</td>
                <td height="22" class="style35">
                    <span lang="en-us">
                    &nbsp;<asp:Label ID="lblDisc" runat="server" CssClass="style16" Text="Discount"></asp:Label>
                    </span>
                </td>
                <td class="style35">
                    <asp:Label ID="lblDiscAmt" runat="server"></asp:Label>
                </td>
                <td class="style36">
                    <span lang="en-us">
                    <asp:CheckBox ID="CkDisc" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkDisc_CheckedChanged" />
                    </span><asp:TextBox ID="txtDisc" runat="server" CssClass="box3" Enabled="False" 
                        Width="50px">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" 
                        ControlToValidate="txtDisc" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" 
                        runat="server" ControlToValidate="txtDisc" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                </td>
                <td class="style35">
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td height="22" class="style38">
                    &nbsp;</td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="lblGQty" runat="server" CssClass="style16"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="lblGqnGsnQty" runat="server" Text="0"></asp:Label>
                </td>
                <td class="style33">
                    &nbsp;</td>
                <td class="style32">
                    &nbsp;</td>
            </tr>
            
            
            <tr>
                <td height="22" class="style41">
                    <span lang="en-us">A]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">
                    &nbsp;<asp:Label ID="lblGAmt" runat="server" style="font-weight: 700"></asp:Label>
                    </span>
                </td>
                <td class="style35">
                    <asp:Label ID="lblGqnGsnAmt" runat="server">0</asp:Label>
                </td>
                <td class="style36">
                    <asp:CheckBox ID="CKDebit" runat="server" AutoPostBack="True" 
                        CssClass="style16" oncheckedchanged="CKDebit_CheckedChanged" Text=" Debit" />
                    <span lang="en-us">&nbsp;<asp:TextBox ID="txtDebit" runat="server" 
                        CssClass="box3" Enabled="False" Width="120px">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" 
                        ControlToValidate="txtDebit" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" 
                        runat="server" ControlToValidate="txtDebit" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
&nbsp;<asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" CssClass="box3" 
                        onselectedindexchanged="DrpType_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="1">Amt</asp:ListItem>
                        <asp:ListItem Value="2">%</asp:ListItem>
                    </asp:DropDownList>
                    </span>
                    </td>
                <td class="style35">
                    <asp:TextBox ID="txtDebitAmt" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" 
                        ControlToValidate="txtDebitAmt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                        runat="server" ControlToValidate="txtDebitAmt" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            
            <tr>
                <td height="22" class="style40">
                    <span lang="en-us">B]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label1" runat="server" CssClass="style16" Text="P&amp;F"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="lblPF" runat="server"></asp:Label>
                </td>
                <td class="style33">
                    <asp:CheckBox ID="CkPf" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkPf_CheckedChanged" />
                    <asp:DropDownList ID="DDLPF" runat="server" DataSourceID="SqlDataSource1" 
                            DataTextField="Terms" DataValueField="Id" CssClass="box3" 
                        Enabled="False" AutoPostBack="True" 
                        onselectedindexchanged="DDLPF_SelectedIndexChanged">
                    </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblPacking_Master]">
                    </asp:SqlDataSource>
                    </td>
                <td class="style32">
                    <asp:TextBox ID="txtPF" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                        ControlToValidate="txtPF" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtPF" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator5"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style41" height="22">
                    <span lang="en-us">C]</span></td>
                <td class="style35" height="22">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label12" runat="server" CssClass="style16" Text="BCD"></asp:Label>
                </td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    <asp:CheckBox ID="CkBCD" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkBCD_CheckedChanged" />
                    <asp:TextBox ID="txtBCD" runat="server" CssClass="box3" Width="75px" 
                        Enabled="False">0</asp:TextBox>
                    <span lang="en-us">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" 
                        ControlToValidate="txtBCD" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" 
                        runat="server" ControlToValidate="txtBCD" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                &nbsp;</span><asp:DropDownList ID="drpBCD" runat="server" AutoPostBack="True" 
                        Enabled="False" onselectedindexchanged="drpBCD_SelectedIndexChanged">
                        <asp:ListItem Value="1">Amt</asp:ListItem>
                        <asp:ListItem Value="2">%</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                <td class="style35">
                    <asp:TextBox ID="txtCalBCD" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style40" height="22">
                    &nbsp;</td>
                <td class="style32" height="22">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label13" runat="server" CssClass="style16" Text="Value for CVD"></asp:Label>
                </td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    <asp:TextBox ID="txtValCVD" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style41">
                    &nbsp;</td>
                <td class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label3" runat="server" CssClass="style16" 
                        Text="Excise/Service Tax"></asp:Label>
                </td>
                <td class="style35">
                    <asp:Label ID="lblExServiceTax" runat="server"></asp:Label>
                </td>
                <td class="style35">
                    <asp:CheckBox ID="CkExcise" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkExcise_CheckedChanged" />
                    <asp:DropDownList ID="DDLExcies" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="Terms" DataValueField="Id" CssClass="box3" Enabled="False" 
                        AutoPostBack="True" onselectedindexchanged="DDLExcies_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblExciseser_Master]">
                    </asp:SqlDataSource>
                    </td>
                <td class="style35">
                    <asp:Label ID="lblExciseServiceTax" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="22" class="style40">
                    D<span lang="en-us">]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label4" runat="server" Text="Basic Excise(%)" CssClass="style16"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="lblBasicExcise" runat="server"></asp:Label>
                    </td>
                <td class="style32">
                    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                    <asp:TextBox ID="txtBasicExcise" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="txtBasicExcise" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtBasicExcise" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator2"></asp:RegularExpressionValidator>                  
                    
                    </td>
                <td class="style32">
                    <asp:TextBox ID="txtBasicExciseAmt" runat="server" CssClass="box3" 
                        Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                        ControlToValidate="txtBasicExciseAmt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtBasicExciseAmt" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator7"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td height="22" class="style41">
                    E<span lang="en-us">]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label5" runat="server" CssClass="style16" Text="EDU Cess(%)"></asp:Label>
                </td>
                <td class="style35">
                    <asp:Label ID="lblEDUCess" runat="server"></asp:Label>
                    </td>
                <td class="style35">
                    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                    <asp:TextBox ID="txtEDUCess" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                        ControlToValidate="txtEDUCess" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtSHECess" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator3"></asp:RegularExpressionValidator></td>
                <td class="style35">
                    <asp:TextBox ID="txtEDUCessAmt" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                        ControlToValidate="txtEDUCessAmt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtEDUCessAmt" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator8"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td height="22" class="style40">
                    <span lang="en-us">F]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label6" runat="server" CssClass="style16" Text="SHE Cess(%)"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="lblSHECess" runat="server"></asp:Label>
                    </td>
                <td class="style32">
                    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                    <asp:TextBox ID="txtSHECess" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                        ControlToValidate="txtSHECess" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtBasicExcise" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator4"></asp:RegularExpressionValidator></td>
                <td class="style32">
                    <asp:TextBox ID="txtSHECessAmt" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                        ControlToValidate="txtSHECessAmt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtSHECessAmt" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator9"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td height="22" class="style41">
                    <span lang="en-us">G]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label14" runat="server" CssClass="style16" 
                        Text="Value for Ed Cess CD"></asp:Label>
                </td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    <asp:TextBox ID="txtValEdCessCD" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style40">
                    <span lang="en-us">H]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label15" runat="server" CssClass="style16" Text="Ed. Cess on CD"></asp:Label>
                </td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    <asp:CheckBox ID="CkEdCessCD" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkEdCessCD_CheckedChanged" />
                    <span lang="en-us">&nbsp;</span><asp:TextBox ID="txtEdCessCD" runat="server" 
                        CssClass="box3" Width="75px" Enabled="False">0</asp:TextBox>
                    <span lang="en-us">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" 
                        ControlToValidate="txtEdCessCD" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator18" 
                        runat="server" ControlToValidate="txtEdCessCD" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                &nbsp;<asp:DropDownList ID="drpEdCessCD" runat="server" AutoPostBack="True" 
                        Enabled="False" onselectedindexchanged="drpEdCessCD_SelectedIndexChanged">
                        <asp:ListItem Value="1">Amt</asp:ListItem>
                        <asp:ListItem Value="2">%</asp:ListItem>
                    </asp:DropDownList>
                    </span></td>
                <td class="style32">
                    <asp:TextBox ID="txtEdCessOnCD" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style41">
                    <span lang="en-us">I]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label16" runat="server" CssClass="style16" 
                        Text="S &amp; H Ed Cess"></asp:Label>
                </td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    <asp:CheckBox ID="CkSHEdCess" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkSHEdCess_CheckedChanged" />
                    <span lang="en-us">&nbsp;</span><asp:TextBox ID="txtSHEdCess" runat="server" 
                        CssClass="box3" Width="75px" Enabled="False">0</asp:TextBox>
                    <span lang="en-us">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" 
                        ControlToValidate="txtSHEdCess" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator19" 
                        runat="server" ControlToValidate="txtSHEdCess" ErrorMessage="*" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                &nbsp;<asp:DropDownList ID="drpSHEdCess" runat="server" AutoPostBack="True" 
                        Enabled="False" onselectedindexchanged="drpSHEdCess_SelectedIndexChanged">
                        <asp:ListItem Value="1">Amt</asp:ListItem>
                        <asp:ListItem Value="2">%</asp:ListItem>
                    </asp:DropDownList>
                    </span></td>
                <td class="style35">
                    <asp:TextBox ID="txtSHEdCessAmt" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style40">
                    <span lang="en-us">J]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label17" runat="server" CssClass="style16" Text="Total Duty"></asp:Label>
                </td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    <asp:TextBox ID="txtTotDuty" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style41">
                    <span lang="en-us">K]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label18" runat="server" CssClass="style16" 
                        Text="Total Duty ED &amp; S.H. ED"></asp:Label>
                </td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    <asp:TextBox ID="txtEDSHED" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style40">
                    <span lang="en-us">P]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label7" runat="server" Text="Freight" CssClass="style16"></asp:Label>
                </td>
                <td class="style32">
                    <asp:Label ID="lblFreight" runat="server"></asp:Label>
                </td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    <asp:Label ID="txtFreight" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="22" class="style41">
                    <span lang="en-us">Q]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label19" runat="server" CssClass="style16" Text="Insurance"></asp:Label>
                </td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                    &nbsp;</td>
                <td class="style35">
                     <asp:TextBox ID="txtInsurance" runat="server" CssClass="box3">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" 
                        ControlToValidate="txtInsurance" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtInsurance" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator20"></asp:RegularExpressionValidator>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style40">
                    <span lang="en-us">L]</span></td>
                <td height="22" class="style32">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="Label20" runat="server" CssClass="style16" 
                        Text="Value with Duty"></asp:Label>
                </td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                    &nbsp;</td>
                <td class="style32">
                     <asp:TextBox ID="txtValDuty" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                                </td>
            </tr>
            <tr>
                <td height="22" class="style41">
                    <span lang="en-us">N]</span></td>
                <td height="22" class="style35">
                    <span lang="en-us">&nbsp;</span><asp:Label ID="lblVatCst" runat="server" CssClass="style16"></asp:Label>
                </td>
                <td class="style35">
                    <asp:Label ID="lblVat" runat="server"></asp:Label>
                </td>
                <td class="style35">
                    <asp:CheckBox ID="CkVat" runat="server" AutoPostBack="True" 
                        oncheckedchanged="CkVat_CheckedChanged" />
                    <asp:DropDownList ID="DDLVat" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="Terms" DataValueField="Id" CssClass="box3" Enabled="False" 
                        AutoPostBack="True" onselectedindexchanged="DDLVat_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblVAT_Master]">
                    </asp:SqlDataSource>
                    </td>
                <td class="style35">
                     <asp:TextBox ID="txtVatCstAmt" runat="server" CssClass="box3" Enabled="False">0</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" 
                        ControlToValidate="txtVatCstAmt" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ControlToValidate="txtVatCstAmt" 
                        ErrorMessage="*" ValidationGroup="B" ID="RegularExpressionValidator12"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Calculate" 
                        onclick="Button1_Click" />
                    <span lang="en-us">&nbsp;</span><asp:Button ID="btnAdd" runat="server" 
                        CssClass="redbox" onclick="btnAdd_Click" Text="Add" 
                        Width="57px" ValidationGroup="B" />
                    <span lang="en-us">&nbsp;</span><asp:Button ID="BtnCancel" runat="server" 
                        CssClass="redbox" onclick="BtnCancel_Click" Text="Cancel" /></td>
                <td height="30">
                    <span lang="en-us">&nbsp;</span></td>
            </tr>
        </table>
    
    
                    </td>
                </tr>
            </table>
    
    
    </form>
</body>
</html>
