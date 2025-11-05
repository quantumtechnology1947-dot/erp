<%@ page language="C#" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_Edit_Details_PO_Select, newerp_deploy" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
    <style type="text/css">
       
        .style24
        {
            width: 100%;
            float: left;
            height: 209px;
        }
        .style32
        {
            width: 100%;
        }
        .style33
        {
            height: 102px;
        }
        .style37
        {
            width: 103px;
            height: 22px;
        }
        .style38
        {
            height: 22px;
        }
        .style39
        {
            width: 97px;
        }
        .style40
        {
        }
        .style41
        {
            width: 365px;
        }
        .style42
        {
            width: 308px;
        }
        .style43
        {
            width: 103px;
            height: 18px;
        }
        .style44
        {
            height: 18px;
        }
        .style45
        {
            height: 19px;
        }
        .style46
        {
            width: 85px;
        }
        #form1
        {
            height: 3px;
        }
        .style47
        {
            height: 23px;
        }
    </style>
</head>
<body topmargin=0 bottommargin=0 leftmargin=0 rightmargin=0>
    <form id="form1" runat="server">
    
        <table align="left" cellpadding="0" cellspacing="0" class="fontcss" 
            width="100%">
            <tr>
                <td class="style42" valign="top">
                    <table align="left" cellpadding="0" cellspacing="0" class="style24">
                        <tr>
                            <td class="style37">
                                PR No</td>
                            <td class="style38">
                                :<asp:Label ID="lblprno" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style37">
                                SPR No</td>
                            <td class="style38">
                                :<asp:Label ID="lblSprno" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                WO No</td>
                            <td class="style44" valign="middle">
                                :<asp:Label ID="lblwono" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                Dept</td>
                            <td class="style44" valign="middle">
                                :<asp:Label ID="lblDept" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style43">
                                Item Code</td>
                            <td class="style44" valign="middle">
                                :<asp:Label ID="lblItemCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style45" colspan="2" valign="middle">
                                Item Description</td>
                        </tr>
                        <tr>
                            <td class="style33" colspan="2" valign="top">
                                <asp:TextBox ID="lblItemDesc" runat="server" CssClass="box3" Height="79px" 
                                    TextMode="MultiLine" Width="298px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style41" valign="top">
                    <table align="left" cellpadding="0" cellspacing="0" class="style32">
                        <tr>
                            <td class="style39" height="25">
                                Ac Head</td>
                            <td>
                                :<asp:Label ID="lblAHId" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                Qty</td>
                            <td>
                                :<asp:Label ID="lblQty" runat="server"></asp:Label>
                                <asp:TextBox ID="txtQty" runat="server" CssClass="box3" Width="96px"></asp:TextBox>
                    
                    
                                <asp:RequiredFieldValidator ID="ReqtxtQty" runat="server" 
                                    ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegtxtQty" runat="server" 
                                    ControlToValidate="txtQty" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                                                UOM </td>
                            <td>
                                :<asp:Label ID="lblUnit" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                Rate
                            </td>
                            <td>
                                :<asp:TextBox ID="txtRate" runat="server" CssClass="box3" Width="96px"></asp:TextBox>
                                &nbsp;<a  runat="server" id="rt"><img  alt="" src="../../../images/Rupee.JPG" border="0"/></a>
                    
                    
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularReqQty0" runat="server" 
                                    ControlToValidate="txtRate" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                Discount
                            </td>
                            <td valign="middle">
                                :<asp:TextBox ID="txtDiscount" runat="server" CssClass="box3" Width="56px">0</asp:TextBox>
                                %<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularReqQty" runat="server" 
                                    ControlToValidate="txtDiscount" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" valign="top">
                                Budget Code</td>
                            <td valign="top">
                                <asp:Label ID="LblBudgetCode" runat="server"></asp:Label>
                                <asp:DropDownList ID="DrpBudgetCode" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" valign="top">
                                Additional Desc</td>
                            <td>
                                <asp:TextBox ID="txtAddDesc" runat="server" CssClass="box3" Height="56px" 
                                    TextMode="MultiLine" Width="227px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" valign="top">
                                &nbsp;</td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table cellpadding="0" cellspacing="0" class="style32">
                        <tr>
                            <td class="style38" colspan="2" height="25">
                                P &amp; F
                            </td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2">
                                <asp:DropDownList ID="DDLPF" runat="server" CssClass="box3">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2" height="25">
                                Excies / Service Tax/CGST/IGST</td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2">
                                <asp:DropDownList ID="DDLExcies" runat="server" CssClass="box3" 
                                    DataTextField="Terms" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style47" colspan="2">
                                VAT/SGST
                            </td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2" height="25">
                                <asp:DropDownList ID="DDLVat" runat="server" CssClass="box3" 
                                     DataTextField="Terms" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                Del. Date</td>
                            <td height="25">
                                :<asp:TextBox ID="txtDelDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" PopupPosition="TopLeft" 
                                    TargetControlID="txtDelDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtDelDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtDelDate" ErrorMessage="*" ValidationGroup="A" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style46" height="25">
                                &nbsp;</td>
                            <td>
                                &nbsp;<asp:Button ID="btnProcide" runat="server" CssClass="redbox"  OnClientClick=" return confirmationUpdate()" 
                                    onclick="btnProcide_Click" Text="  Add  " ValidationGroup="A" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                                    onclick="btnCancel_Click" Text="Cancel" />
                                <asp:Label ID="lblPODId" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
