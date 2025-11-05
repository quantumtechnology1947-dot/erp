<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_PMBM_New_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style6
        {
            width: 100%;
        }
        .style8
        {
            width: 994px;
        }
        .style9
        {
            width: 994px;
            font-weight: bold;
            height: 2px;
        }
        .style10
        {
            height: 23px;
        }
        .style11
        {
            height: 23px;
            width: 121px;
        }
        .style12
        {
            width: 121px;
        }
        .style14
        {
            height: 23px;
            width: 127px;
            font-size: larger;
            font-weight: bold;
        }
        .style15
        {
            width: 127px;
        }
        .style20
        {
            height: 23px;
            }
        .style21
        {
            width: 52px;
        }
        .style22
        {
            font-size: larger;
        }
        .style23
        {
            width: 136px;
        }
        .style24
        {
            height: 23px;
            width: 22%;
        }
        .style25
        {
        }
        .style29
        {
            height: 23px;
            width: 23%;
        }
        .style30
        {
            width: 23%;
        }
        .style31
        {
            font-weight: bold;
            font-size: larger;
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
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>Preventive /Breckdown Maintenance- New </b></td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
               
                <table class="style6">
                    <tr>
                        <td class="style31" bgcolor="Silver" colspan="6">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            Machine</td>
                    </tr>
                    <tr>
                        <td class="style20">
                            </td>
                        <td class="style14">
                            &nbsp;</td>
                        <td class="style24">
                            </td>
                        <td class="style11">
                            </td>
                        <td class="style29">
                            </td>
                        <td class="style10">
                            </td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Machine&nbsp; Code</td>
                        <td class="style25">
                            :
                            <asp:Label ID="lblItemCode" runat="server"></asp:Label>
                        </td>
                        <td class="style12">
                            UOM</td>
                        <td class="style30">
                            :
                            <asp:Label ID="lblUOM" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Name</td>
                        <td class="style25" colspan="3">
                            :
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Model</td>
                        <td class="style25">
                            :
                            <asp:Label ID="lblModel" runat="server"></asp:Label>
                        </td>
                        <td class="style12">
                            Make</td>
                        <td class="style30">
                            :
                            <asp:Label ID="lblMake" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Capacity</td>
                        <td class="style25">
                            :
                            <asp:Label ID="lblCapacity" runat="server"></asp:Label>
                        </td>
                        <td class="style12">
                            Location</td>
                        <td class="style30">
                            :
                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Maintenance</td>
                        <td class="style25">
                            :
                            <asp:DropDownList ID="DDLMaintenance" runat="server" Width="150px" 
                                CssClass="box3">
                                <asp:ListItem Selected="True" Value="0">Preventive</asp:ListItem>
                                <asp:ListItem Value="1">Breckdown</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                        <td class="style30">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            From Date</td>
                        <td class="style25">
                            :
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="box3"></asp:TextBox>
                            <cc1:CalendarExtender 
            ID="CalendarFromDate" runat="server" Enabled="True" Format="dd-MM-yyyy" 
            TargetControlID="txtFromDate"></cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="ReqFromDate" runat="server" 
                    ControlToValidate="txtFromDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator 
                        ID="RegularFromDate" runat="server" 
                    ControlToValidate="txtFromDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator>
                        </td>
                        <td class="style12">
                            To Date</td>
                        <td class="style30">
                            :
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="box3"></asp:TextBox>
                            <cc1:CalendarExtender 
            ID="CalendarExtender1" runat="server" Enabled="True" Format="dd-MM-yyyy" 
            TargetControlID="txtToDate"></cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtToDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtToDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            From Time
                        </td>
                        <td class="style25" align="left">
                            
                            &nbsp;
                            
                            <MKB:TimeSelector ID="TSFromTime" runat="server" AmPm="AM" MinuteIncrement="1">
                            </MKB:TimeSelector>
                        </td>
                        <td class="style12">
                            To Time</td>
                        <td class="style30">
                            <MKB:TimeSelector ID="TSToTime" runat="server" AmPm="AM" 
                                MinuteIncrement="1">
                            </MKB:TimeSelector>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Name of Agency</td>
                        <td class="style25">
                            :
                            <asp:TextBox ID="txtNameOfAgency" runat="server" Width="200px" CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqFromDate0" runat="server" 
                    ControlToValidate="txtNameOfAgency" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style12">
                            Name of Engineer</td>
                        <td class="style30">
                            :
                            <asp:TextBox ID="txtNameOfEngineer" runat="server" Width="200px" 
                                CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqFromDate1" runat="server" 
                    ControlToValidate="txtNameOfEngineer" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15">
                            Next PM Due on</td>
                        <td class="style25">
                            :
                            <asp:TextBox ID="txtNextPMDueOn" runat="server" CssClass="box3"></asp:TextBox>
                            <cc1:CalendarExtender 
            ID="CalendarExtender2" runat="server" Enabled="True" Format="dd-MM-yyyy" 
            TargetControlID="txtNextPMDueOn"></cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtNextPMDueOn" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator 
                        ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtNextPMDueOn" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="A"></asp:RegularExpressionValidator>
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                        <td class="style30">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style21">
                            &nbsp;</td>
                        <td class="style15" valign="top">
                            Remarks</td>
                        <td class="style25" colspan="2" valign="top">
                            :
                            <asp:TextBox ID="txtRemarks" runat="server" Width="300px" TextMode="MultiLine" 
                                CssClass="box3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqFromDate2" runat="server" 
                    ControlToValidate="txtRemarks" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style30" valign="top">
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" 
                                Text="* PM excluding holiday"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
                
                <table>
                <tr>
                <td class="style9" colspan="3" bgcolor="Silver">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <span class="style22">Spare</span></td>
                </tr>
                <tr>
                <td class="style23">&nbsp;</td>
                <td width="60%">
               <asp:GridView ID="GridView5" runat="server" 
                        AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                        DataKeyNames="Id" Width="100%">
                        
                        
                        
                        <Columns>
                        
                        <asp:TemplateField HeaderText="SN"><ItemTemplate><%#Container.DataItemIndex+1  %></ItemTemplate><HeaderStyle Font-Size="10pt" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="2%" /></asp:TemplateField>
                        
                        
                                  <asp:TemplateField>
                                <ItemTemplate>
                                <asp:CheckBox ID="chkSpare" 
                                    runat="server" AutoPostBack="false" Checked="false" />
                                    </ItemTemplate><HeaderStyle Font-Size="10pt" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="3%" />
                                    </asp:TemplateField>
                                        
                                        
                                        <asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label></ItemTemplate>
                                            <ItemStyle Width="9%" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblManfDesc" runat="server" Text='<%#Eval("ManfDesc") %>'> </asp:Label></ItemTemplate><ItemStyle Width="25%" /></asp:TemplateField><asp:TemplateField HeaderText="Unit"><ItemTemplate><asp:Label ID="lblUOM" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Stock Qty">
                                        <ItemTemplate><asp:Label ID="lblStockQty" runat="server" Text='<%#Eval("StockQty") %>'></asp:Label>
                                        </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="8%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Required Qty">
                                        <ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                        </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="8%" />
                                        </asp:TemplateField>
                                 
                                        <asp:TemplateField HeaderText=" Availed Qty">
                                        <ItemTemplate>
                                        <asp:TextBox   ID="txtQty" runat="server" CssClass="box3" Width="85%"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ReqQty" runat="server" ControlToValidate="txtQty" ErrorMessage="*" 
                                    ValidationGroup="A" Visible="false">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator   ID="RegNumeric" runat="server" ControlToValidate="txtQty" ErrorMessage="*" 
                                    ValidationExpression="^[0-9]\d*(\.\d+)?$" ValidationGroup="A">
                                    </asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:TemplateField>
                                        
                                        
                                        <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                                        <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                       </Columns>
                                        
                                        <EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label4" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                            Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>
                
                </td>
                <td class="style8">&nbsp;</td>
                </tr>
                <tr>
                <td class="style8" colspan="3" align="center">
                    &nbsp;</td>
                </tr>
                <tr>
                <td class="style8" colspan="3" align="center">
                    <asp:Button ID="btnProceed" runat="server" Text="Proceed" CssClass="redbox" OnClientClick="return confirmationAdd();" 
                        onclick="btnProceed_Click" ValidationGroup="A"  />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                        onclick="BtnCancel_Click" Text="Cancel" />
                    </td>
                </tr>
                <tr>
                <td class="style8" colspan="3">&nbsp;</td>
                </tr>
                </table>
    </td>    
    </tr>    
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

