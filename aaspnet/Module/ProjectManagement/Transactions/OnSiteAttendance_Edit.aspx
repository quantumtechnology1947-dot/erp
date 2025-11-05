<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_OnSiteAttendance_Edit, newerp_deploy" theme="Default" title="ERP" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script> 
<style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 25px;
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
 <table cellpadding="0" cellspacing="0" class="style3">
        
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="25" class="fontcsswhite"><b>&nbsp;Attendance Onsite Details for  Date:<asp:Label ID="Label3" runat="server"
                    Text="Label"></asp:Label>  </b></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Panel ID="Panel1" runat="server">
                    <table class="style3">
                        <tr>
                            <td width="18% ">
                                </td>
                            <td align="right" width="10%">
                                &nbsp;<b>Select Date :&nbsp;</b></td>
                            <td width="15%">
                                <asp:TextBox ID="textChequeDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                                <cc1:CalendarExtender ID="textDelDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="textChequeDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqDelDate" runat="server" 
                                    ControlToValidate="textChequeDate" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegDelverylDate" runat="server" 
                                    ControlToValidate="textChequeDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="B"></asp:RegularExpressionValidator>
                            </td>
                            <td align="right" width="15%">
                                <b>Select BG Group :</b></td>
                            <td width="10%">
                                <asp:DropDownList ID="drpGroupF" runat="server" DataSourceID="SqlDataBG" 
                                    DataTextField="Symbol" DataValueField="Id">
                                </asp:DropDownList>
                            </td>
                            <td width="10%">
                                <asp:Button ID="btnProceed" runat="server" CssClass="redbox" Text="Search" 
                                    ValidationGroup="B" onclick="btnProceed_Click" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td height="10px">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td >
                <asp:Panel ID="Panel5" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
                        CssClass="yui-datatable-theme" DataKeyNames="Id" PageSize="17" Width="100%" 
                        AllowPaging="True" onpageindexchanging="GridView4_PageIndexChanging" 
                        onrowcancelingedit="GridView4_RowCancelingEdit" 
                        onrowediting="GridView4_RowEditing" onrowupdating="GridView4_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="SN" SortExpression="Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1  %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" Width="2%" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="Edit">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                                        CommandName="Update" Text="Update">
                                    </asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                <asp:Label ID="lblIdE" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name Of Employee">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmp" runat="server" Text='<%#Eval("EmpName") %>'>
                                    </asp:Label>
                                </ItemTemplate> 
                                <ItemStyle HorizontalAlign="Left" Width="14%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BG Group">
                                <ItemTemplate>
                                    <asp:Label ID="lblBG" runat="server" Text='<%#Eval("BG") %>'> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shift">
                                <ItemTemplate>
                                    <asp:Label ID="lblShift" runat="server" Text='<%#Bind("Shift") %>'>
                                    </asp:Label>
                                 </ItemTemplate>
                                 <EditItemTemplate>
                                 <asp:Label ID="lblShiftE" Visible="false" runat="server" Text='<%#Bind("Shift") %>'>
                                    </asp:Label>
                                    <asp:RadioButtonList 
                                ID="RadioButtonShift" runat="server" AutoPostBack="false" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Selected="True"> Day </asp:ListItem><asp:ListItem Value="1"> 
                                Night </asp:ListItem></asp:RadioButtonList>
                                </EditItemTemplate>
                               
                                <ItemStyle HorizontalAlign="Center" Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate> 
                                 <asp:Label ID="lblStatus" runat="server" Text='<%#Bind("Status") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                
                                <EditItemTemplate>
                                <asp:Label ID="lblStatusE" runat="server" Visible="false" Text='<%#Bind("Status") %>'>
                                    </asp:Label>
                                    <asp:RadioButtonList 
                                ID="RadioButtonStatus" runat="server" AutoPostBack="false" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Selected="True"> Present </asp:ListItem><asp:ListItem Value="1"> 
                                Absent </asp:ListItem></asp:RadioButtonList>
                                </EditItemTemplate>
                               
                                <ItemStyle HorizontalAlign="center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="If On Site">                           
                            
                                <ItemTemplate>
                                 <asp:Label ID="lblOnSite" runat="server" Text='<%#Bind("Onsite") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtOnsite" TextMode="MultiLine" Text='<%#Bind("Onsite") %>'  runat="server" CssClass="box3" Width="95%">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtOnsite" ValidationGroup="A" runat="server" 
                                        ControlToValidate="txtOnsite" ErrorMessage="*" >
                                    </asp:RequiredFieldValidator></EditItemTemplate>
                                 
                                <ItemStyle HorizontalAlign="Left" Width="13%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shift Hrs">
                                <ItemTemplate>
                                    <asp:Label ID="lblHours" runat="server" Text='<%#Eval("Hours") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From Time">
                                <ItemTemplate>
                                <asp:Label ID="lblFrmTime" runat="server" Text='<%#Eval("FromTime") %>'>
                                    </asp:Label>
                                </ItemTemplate>                                
                                <EditItemTemplate>
                                
                                <asp:Label ID="lblFrmTimeE"   runat="server" Text='<%#Eval("FromTime") %>'>
                                    </asp:Label>
                                   <MKB:TimeSelector ID="FTime" Visible="false" runat="server" AmPm="AM" Width="100%" MinuteIncrement="1"></MKB:TimeSelector>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="6%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="To Time">
                                <ItemTemplate>
                                <asp:Label ID="lblToTime" runat="server" Text='<%#Eval("ToTime") %>'>
                                    </asp:Label>
                                </ItemTemplate>                                
                                <EditItemTemplate>
                                
                                 <asp:Label ID="lblToTimeE"  Visible="false" runat="server" Text='<%#Eval("ToTime") %>'>
                                    </asp:Label>
                                   <MKB:TimeSelector ID="TTime" runat="server" AmPm="AM" Width="100%" MinuteIncrement="1"></MKB:TimeSelector>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="center" Width="6%" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="fontcss" width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                            Text="No data to display !"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <br />
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td align="center" height="25px" valign="bottom">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataBG" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                    ProviderName="System.Data.SqlClient" 
                    SelectCommand="SELECT * FROM [BusinessGroup]"></asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

