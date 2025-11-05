<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManPowerPlanning.aspx.cs" Inherits="Module_ProjectManagement_Transactions_ManPowerPlanning" Title="ERP"  Theme ="Default" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style6
        {
            font-weight: bold;
        }
        .style9
        {
            height: 11px;
        }
        .style11
        {
            width: 100%;
            float: left;
        }
        .style12
        {
            width: 60px;
        }
        .style14
        {
            width: 168px;
        }
        .style15
        {
            width: 145px;
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
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Man Power Planning - New</b></td>
        </tr>        
       
        <tr>
        <td height="25px">
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                Width="100%" Height="420px">
                <cc1:TabPanel runat="server" HeaderText="Planning" ID="Planning">
                
                
                    <ContentTemplate>
                        <table align="left" cellpadding="0" cellspacing="0" width="800px">
                            <tr>
                                <td align="left" height="30" valign="middle">
                                    &nbsp;<asp:Label ID="Label2" runat="server" CssClass="style4" 
                                        style="font-weight: bold" Text="Select BG Group:"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="True" 
                                        CssClass="box3" DataSourceID="SqlBGGroup" DataTextField="Symbol" 
                                        DataValueField="Id" Height="21px" 
                                        onselectedindexchanged="DrpCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqBGgroup" runat="server" 
                                        ControlToValidate="DrpCategory" ErrorMessage="*" InitialValue="Select" 
                                        ValidationGroup="acbd"></asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" Height="390px" ScrollBars="Auto" 
                                        Width="100%">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            CssClass="yui-datatable-theme" 
                                            OnPageIndexChanging="GridView1_PageIndexChanging" 
                                            OnRowCommand="GridView1_RowCommand" PageSize="20" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="2%" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmployeeName" runat="server" 
                                                            Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Id" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TxtDate" runat="server" CssClass="box3" Width="70px"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="TxtDate_CalendarExtender" runat="server" 
                                                            CssClass="cal_Theme2" Enabled="True" Format="dd-MM-yyyy" 
                                                            PopupPosition="BottomRight" TargetControlID="TxtDate">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="Drpwodept" runat="server" AutoPostBack="true" 
                                                            CssClass="box3" onselectedindexchanged="Drpwodept_SelectedIndexChanged">
                                                            <asp:ListItem Text="WONo" Value="1">
                                                            </asp:ListItem>
                                                            <asp:ListItem Text="BG" Enabled="false" Value="2">
                                                            </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="3%" />
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="WONo">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TxtWONo" runat="server" CssClass="box3" Width="90%"></asp:TextBox>
                                                        <asp:DropDownList ID="DrpDepartment" runat="server" CssClass="box3" 
                                                            DataSourceID="SqlDept" DataTextField="DeptName" DataValueField="Id" 
                                                            Visible="false">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDept" runat="server" 
                                                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                                            SelectCommand="SELECT Id, Symbol AS DeptName FROM BusinessGroup">
                                                        </asp:SqlDataSource>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="6%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="Drptype" runat="server" CssClass="box3">
                                                            <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Absent" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Onsite" Value="3"></asp:ListItem>
                                                            <asp:ListItem Text="PL" Value="4"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle VerticalAlign="Top" Width="3%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="BtnAdd" runat="server" CommandName="add" CssClass="redbox" Text="Select" ValidationGroup="A" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
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
                                            <FooterStyle Font-Bold="False" />
                                            <HeaderStyle Font-Size="9pt" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlBGGroup" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                            SelectCommand="SELECT [Id], [Symbol] As Symbol  FROM [BusinessGroup]">
                                        </asp:SqlDataSource>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                
                
                </cc1:TabPanel>
               
                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Details">
                    <HeaderTemplate>
                        Details
                    </HeaderTemplate>
                    <ContentTemplate>
                      <table align="left" cellpadding="0" cellspacing="0" class="fontcss" width="100%">
                                        <tr>
                                            <td class="style9">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style9">
                                                <table cellpadding="0" cellspacing="0" class="style11">
                                                    <tr>
                                                        <td class="style15" height="21">
                                                            <asp:Label ID="Label3" runat="server" CssClass="style6" Text="Name of Employee"></asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                            : <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                                                            <asp:Label ID="lblEmpId" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" height="21">
                                                            <asp:Label ID="Label4" runat="server" CssClass="style6" Text="Designation"></asp:Label>
                                                        </td>
                                                        <td class="style14">
                                                            :
                                                            <asp:Label ID="lblDesig" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="style12">
                                                            <asp:Label ID="lbldrp" runat="server" CssClass="style6"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                            <asp:Label ID="lblWODept" runat="server"></asp:Label>
                                                            <asp:Label ID="lblWODeptId" runat="server" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblBGId" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style15" height="21">
                                                            <asp:Label ID="Label5" runat="server" CssClass="style6" Text="Date"></asp:Label>
                                                        </td>
                                                        <td class="style14">
                                                            :
                                                            <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="style12">
                                                            <asp:Label ID="Label7" runat="server" CssClass="style6" Text="Status"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                            <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                            <asp:Label ID="lblStatusId" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="Panel3" runat="server" Height="320px" ScrollBars="Auto" 
                                                    Width="100%">
                                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                                                        CssClass="yui-datatable-theme" Width="80%">
                                                        <Columns>
                                                           <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkSelect" runat="server"  oncheckedchanged="ChkSelect_CheckedChanged" AutoPostBack="true" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Top" />
                                                </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Equip No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEquipNo" runat="server" Text='<%# Bind("ItemCode") %>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Desc">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldesc" runat="server" Text='<%# Bind("ManfDesc") %>'> </asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="drpCat" runat="server" AutoPostBack="True"  DataSourceID="SqlCategory" DataTextField="Category" DataValueField="Id"   onselectedindexchanged="drpCat_SelectedIndexChanged" Enabled="false">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="drpSubCat" runat="server" Enable="False" Enabled="false">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Planned">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPlanned" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Actual">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActual" runat="server" TextMode="MultiLine">
                                                                    </asp:TextBox>
                                                                    
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Hrs">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtHrs" runat="server" Width="40px" > </asp:TextBox>
  <asp:RegularExpressionValidator ID="ExptxtHrs" runat="server" ControlToValidate="txtHrs" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                                                    
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField  Visible="False">
                                                            <ItemTemplate >
                                                                    <asp:label ID="lblEquipId" runat="server" Text='<%# Bind("ItemId") %>'>
                                                                    </asp:label>
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView> 
                                                </asp:Panel>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" height="25">
                                                <asp:Button ID="btnSelect" runat="server" CssClass="redbox" Text=" Add "  
                                                    ValidationGroup="B" onclick="btnSelect_Click"/>
                                                <asp:SqlDataSource ID="SqlCategory" runat="server" 
                                                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                                    SelectCommand="SELECT Id,Category FROM tblMIS_BudgetHrs_Field_Category Order by Id ASC">
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                    </ContentTemplate>
                </cc1:TabPanel>
            
            </cc1:TabContainer>
        </td>
        </tr>
        
       
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

