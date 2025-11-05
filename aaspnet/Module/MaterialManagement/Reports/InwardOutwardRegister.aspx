<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_InwardOutwardRegister, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
        .style3
        {
            width: 100%;
        }
        </style>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Inward/Outward Register</b></td>
        </tr>
        <tr>
            <td height="27" valign="middle">
                &nbsp;
                <asp:Label ID="Label2" runat="server" Text="Enter Date: From"></asp:Label>
&nbsp;<asp:TextBox ID="TxtFromDt" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
<cc1:CalendarExtender runat="server" Format="dd-MM-yyyy" Enabled="True" 
                        TargetControlID="TxtFromDt" ID="TxtFromDt_CalendarExtender" CssClass="cal_Theme2"></cc1:CalendarExtender>
<asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                        ControlToValidate="TxtFromDt" ErrorMessage="*" ValidationGroup="A" 
                        ID="ReqTDate"></asp:RegularExpressionValidator>
                        
&nbsp;<asp:Label ID="Label4" runat="server" Text="- To "></asp:Label>
                <asp:TextBox ID="TxtToDt" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
               <cc1:CalendarExtender runat="server" Format="dd-MM-yyyy" Enabled="True" 
                        TargetControlID="TxtToDt" ID="CalendarExtender1" CssClass="cal_Theme2" ></cc1:CalendarExtender>
<asp:RegularExpressionValidator runat="server" 
                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                        ControlToValidate="TxtToDt" ErrorMessage="*" ValidationGroup="A" 
                        ID="RegularExpressionValidator1"></asp:RegularExpressionValidator>
&nbsp; <asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" 
                    ValidationGroup="A" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>            
                <table cellpadding="0" cellspacing="0" class="style3">
                    <tr>
<td height="22" width="33%" style="text-align: left; background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
&nbsp;<asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="PR "></asp:Label>
                        </td>
<td width="33%" style="text-align: left; background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
&nbsp;<asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="SPR"></asp:Label>
                        </td>
<td width="34%" style="text-align: left; background:url(../../../images/hdbg.JPG)" class="fontcsswhite">
&nbsp;<asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="PO"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel1" runat="server" Height="390px" ScrollBars="Auto" 
                                Width="99%">
                                <asp:GridView ID="GridView2" runat="server" 
    AutoGenerateColumns="False" CssClass="yui-datatable-theme" Width="99%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                 <%#Container.DataItemIndex+1  %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RDate" HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PRNo" HeaderText="PR No">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PRAmt" HeaderText="Amt">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td valign="top">
                            <asp:Panel ID="Panel2" runat="server" Height="390px" ScrollBars="Auto" 
                                Width="99%">
                                <asp:GridView ID="GridView3" runat="server" 
    AutoGenerateColumns="False" Width="99%" CssClass="yui-datatable-theme">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RDate" HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SPRNo" HeaderText="SPR No">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SPRAmt" HeaderText="Amt">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server" Height="390px" ScrollBars="Auto" 
                                Width="99%">
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                    CssClass="yui-datatable-theme" Width="99%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                         <ItemTemplate>
                                         <%#Container.DataItemIndex+1 %>
                                         </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="RDate" HeaderText="Date">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField  DataField="PONo" HeaderText="PO No">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField  DataField="POAmt" HeaderText="Amt">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" height="27" style="text-align: right">
                            <asp:Label ID="Label8" runat="server" Text="Total : " style="font-weight: 700"></asp:Label>
                            <asp:Label ID="lblPRTot" runat="server" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td valign="middle" style="text-align: right">
                            <asp:Label ID="Label9" runat="server" Text="Total : " style="font-weight: 700"></asp:Label>
                            <asp:Label ID="lblSPRTot" runat="server" style="font-weight: 700"></asp:Label>
&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td valign="middle" style="text-align: right">
                            <asp:Label ID="Label10" runat="server" Text="Total : " style="font-weight: 700"></asp:Label>
                            <asp:Label ID="lblPOTot" runat="server" style="font-weight: 700"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>