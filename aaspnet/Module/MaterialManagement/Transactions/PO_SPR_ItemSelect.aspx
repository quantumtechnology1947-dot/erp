<%@ page language="C#" autoeventwireup="true" inherits="Module_MaterialManagement_Transactions_PO_SPR_ItemSelect, newerp_deploy" culture="en-GB" theme="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
    <style type="text/css">
       
        .style24
        {
            width: 100%;
            float: left;
            height: 193px;
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
<body>
    <form id="form1" runat="server">
    
        <table align="left" cellpadding="0" cellspacing="0" class="fontcss" 
            width="100%">
            <tr>
                <td class="style42" valign="top">
                    <table align="left" cellpadding="0" cellspacing="0" class="style24">
                        <tr>
                            <td class="style37">
                                SPR No</td>
                            <td class="style38">
                                :<asp:Label ID="lblSprno" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style37">
                                SPR Qty</td>
                            <td class="style38">
                                :<asp:Label ID="lblQty" runat="server"></asp:Label>
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
                                BG Group</td>
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
                                <asp:TextBox ID="lblItemDesc" runat="server" CssClass="box3" Height="113px" 
                                    TextMode="MultiLine" Width="298px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblExciseser_Master] Where Id='1' OR Id='30' OR Id='31'OR Id='32' OR Id='33' OR Id='34'OR Id='35' OR Id='36' OR Id='37' OR Id='38' ">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT [Id], [Terms] FROM [tblVAT_Master]  Where Id='1' OR Id='2' OR Id='93' OR Id='94' OR Id='95' OR Id='124' OR Id='129' OR Id='130'">
                    </asp:SqlDataSource>
                </td>
                <td class="style41" valign="top">
                    <table align="left" cellpadding="0" cellspacing="0" class="style32">
                        <tr>
                            <td class="style39" height="25">
                                Ac Head</td>
                            <td>
                                :<asp:Label ID="lblAcHead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                PO
                                Qty</td>
                            <td>
                                :<asp:TextBox ID="txtQty" runat="server" CssClass="box3" Width="96px"></asp:TextBox>
                    
                    
                                <asp:RequiredFieldValidator ID="ReqtxtQty" runat="server" 
                                    ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegtxtQty" runat="server" 
                                    ControlToValidate="txtQty" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                                                UOM</td>
                            <td>
                                :<asp:Label ID="lblUnit" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style39" height="25">
                                Rate
                            </td>
                            <td>
                                :<asp:TextBox ID="txtRate" runat="server"   CssClass="box3" Width="96px" 
                                    Enabled="False"></asp:TextBox>
                                &nbsp;<a id="rt" runat="server"><img alt="" border="0" 
                                    src="../../../images/Rupee.JPG" /></a>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularReqQty" runat="server" 
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
                                <asp:RegularExpressionValidator ID="RegularReqQty0" runat="server" 
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                    SelectCommand="SELECT [Id], [Terms] FROM [tblPacking_Master]">
                                </asp:SqlDataSource>
                            </td>
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
                                <asp:DropDownList ID="DDLPF" runat="server" CssClass="box3" 
                                    DataSourceID="SqlDataSource1" DataTextField="Terms" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2" height="25">
                                Excies / Service Tax</td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2">
                                <asp:DropDownList ID="DDLExcies" runat="server" CssClass="box3" 
                                    DataSourceID="SqlDataSource2" DataTextField="Terms" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style47" colspan="2">
                                VAT
                            </td>
                        </tr>
                        <tr>
                            <td class="style40" colspan="2" height="25">
                                <asp:DropDownList ID="DDLVat" runat="server" CssClass="box3" 
                                    DataSourceID="SqlDataSource3" DataTextField="Terms" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style46">
                                Del. Date</td>
                            <td height="25">
                                :<asp:TextBox ID="txtDelDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDelDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtDelDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtDelDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtDelDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style46" height="25">
                                <asp:TextBox ID="LblDate" runat="server" Visible="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;<asp:Button ID="btnProcide" runat="server" CssClass="redbox" 
                                    onclick="btnProcide_Click" Text="  Add  " ValidationGroup="A"  OnClientClick=" return confirmationAdd()"  />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                                    onclick="btnCancel_Click" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
