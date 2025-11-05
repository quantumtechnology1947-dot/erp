<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Reports_InwardOutwardRegister, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        .style3
        {
            width: 100%;
            float: left;
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
 
    <table align="left" class="style3" cellpadding="0" cellspacing="0">
           <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Inward/Outward Register</b></td>
        </tr>
        </tr>
        <tr>
            <td height="27">
                &nbsp;
                <asp:Label runat="server" Text="Enter Date: From" ID="Label2"></asp:Label>
                &nbsp;<asp:TextBox runat="server" CssClass="box3" Width="100px" ID="TxtFromDt"></asp:TextBox>
                <cc1:CalendarExtender runat="server" CssClass="cal_Theme2" Format="dd-MM-yyyy" 
                    Enabled="True" TargetControlID="TxtFromDt" ID="TxtFromDt_CalendarExtender">
                </cc1:CalendarExtender>
                <asp:RegularExpressionValidator runat="server" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ControlToValidate="TxtFromDt" ErrorMessage="*" ValidationGroup="A" 
                    ID="ReqTDate"></asp:RegularExpressionValidator>
                &nbsp;<asp:Label runat="server" Text="- To " ID="Label4"></asp:Label>
                <asp:TextBox runat="server" CssClass="box3" Width="100px" ID="TxtToDt"></asp:TextBox>
                <cc1:CalendarExtender runat="server" CssClass="cal_Theme2" Format="dd-MM-yyyy" 
                    Enabled="True" TargetControlID="TxtToDt" ID="CalendarExtender1">
                </cc1:CalendarExtender>
                <asp:RegularExpressionValidator runat="server" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ControlToValidate="TxtToDt" ErrorMessage="*" ValidationGroup="A" 
                    ID="RegularExpressionValidator1"></asp:RegularExpressionValidator>
                &nbsp;
                <asp:Button runat="server" Text="Search" ValidationGroup="A" CssClass="redbox" 
                    ID="Button1" OnClick="Button1_Click"></asp:Button>
            </td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Height="400px" Width="100%">
                    <cc1:TabPanel runat="server" HeaderText="GIN/GRR/GSN" ID="TabPanel1">
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style3"><tr><td height="22" width="33%" style="text-align: left; background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<asp:Label ID="Label5" runat="server" style="font-weight: 700"  Text="GIN"></asp:Label></td><td height="22" width="33%" 
                                        style="text-align: left; background:url(../../../images/hdbg.JPG); width: 0%;" 
                                        class="fontcsswhite">&nbsp;<asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="GRR"></asp:Label></td><td class="fontcsswhite" height="22" 
                                        style="text-align: left; background: url(../../../images/hdbg.JPG); width: 25%;" 
                                        width="33%">&#160;<asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="GSN"></asp:Label></td></tr><tr><td valign="top" width="33%"><asp:Panel ID="Panel1" runat="server" Height="360px" Width="99%" 
                                    ScrollBars="Auto"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate>
                              
                                        </ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="Date" DataField="RDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="GIN No" DataField="GINNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="Amt" DataField="GINAmt"><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns></asp:GridView></asp:Panel></td><td valign="top" width="33%"><asp:Panel ID="Panel2" runat="server" Width="99%" Height="360px" 
                                    ScrollBars="Auto"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" Width="100%"><Columns><asp:TemplateField HeaderText="SN"></asp:TemplateField><asp:BoundField 
                                                HeaderText="Date" DataField="RDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField 
                                                HeaderText="GRR No" DataField="GRRNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField 
                                                HeaderText="Amt" DataField="GRRAmt"><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns></asp:GridView></asp:Panel></td><td valign="top" width="33%"><asp:Panel ID="Panel3" runat="server" Width="99%" Height="360px" 
                                    ScrollBars="Auto"><asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" Width="100%"><Columns><asp:TemplateField HeaderText="SN"></asp:TemplateField><asp:BoundField 
                                                HeaderText="Date" DataField="RDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField 
                                                HeaderText="GSN No" DataField="GSNNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField 
                                                HeaderText="Amt" DataField="GSNAmt"><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns></asp:GridView></asp:Panel></td></tr><tr><td align="right" height="25" valign="middle" width="33%"><asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Total: "></asp:Label><asp:Label ID="lblGINTot" runat="server" style="font-weight: 700" Text="0"></asp:Label></td><td align="right" valign="middle" width="33%">&#160;&nbsp;<asp:Label ID="Label8" runat="server" style="font-weight: 700" Text="Total: "></asp:Label><asp:Label ID="lblGRRTot" runat="server" style="font-weight: 700" Text="0"></asp:Label>&#160;</td><td align="right" valign="middle" width="33%"><asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Total: "></asp:Label><asp:Label ID="lblGSNTot" runat="server" style="font-weight: 700" Text="0"></asp:Label></td></tr></table>
                        
                        
                    </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="MRS/MIN">
                        <HeaderTemplate>MRS/MIN
                        </HeaderTemplate>
                        <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" class="style3"><tr><td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">&#160;<b>MRS</b></td><td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">&#160;<b>MIN</b></td></tr><tr><td valign="top" width="50%"><asp:Panel 
            ID="Panel4" runat="server" Height="360px" Width="99%" ScrollBars="Auto"><asp:GridView 
                                    ID="GridView4" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" Width="99%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:BoundField 
                    HeaderText="Date" DataField="RDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="MRS No" DataField="MRSNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="Amt" DataField="MRSAmt"><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns></asp:GridView></asp:Panel></td><td valign="top" width="50%"><asp:Panel 
                                        ID="Panel5" runat="server" Height="360px" Width="99%" 
                                    ScrollBars="Auto"><asp:GridView 
                                        ID="GridView5" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" Width="99%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:BoundField HeaderText="Date" DataField="RDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="MIN No" DataField="MINNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="Amt" DataField="MINAmt"><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns></asp:GridView></asp:Panel></td></tr><tr><td align="right" valign="top"><asp:Label ID="Label9" runat="server" style="font-weight: 700" Text="Total: "></asp:Label><asp:Label ID="lblMRSTot" runat="server" style="font-weight: 700" Text="0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td><td align="right" valign="top"><asp:Label ID="Label10" runat="server" style="font-weight: 700" Text="Total: "></asp:Label><asp:Label ID="lblMINTot" runat="server" style="font-weight: 700" Text="0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr></table>
                        
                    </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="WIS">
                        <HeaderTemplate>WIS</HeaderTemplate>
                        
<ContentTemplate><table align="left" cellpadding="0" cellspacing="1" width="40%"><tr><td><asp:Panel ID="Panel6" runat="server" Width="99%" Height="380px" 
        ScrollBars="Auto"><asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:BoundField HeaderText="Date" DataField="RDate"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="WIS No" DataField="WISNo"><ItemStyle HorizontalAlign="Center" /></asp:BoundField><asp:BoundField HeaderText="Amt" DataField="WISAmt"><ItemStyle HorizontalAlign="Right" /></asp:BoundField></Columns></asp:GridView></asp:Panel></td></tr><tr><td align="right"><asp:Label ID="Label11" runat="server" style="font-weight: 700" Text="Total: "></asp:Label><asp:Label ID="lblWISTot" runat="server" style="font-weight: 700" Text="0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr></table>
                        
                        
                    </ContentTemplate>
                    
</cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        </table>
 
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

