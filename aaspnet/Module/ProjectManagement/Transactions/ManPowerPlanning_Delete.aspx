<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ManPowerPlanning_Delete, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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

<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Man Power Planning - Delete</b></td>
        </tr>
        
       
        <tr>
        <td height="35px">
              <asp:DropDownList ID="ddlSelectBG_WONo" runat="server" AutoPostBack="True" 
                CssClass="box3" onselectedindexchanged="ddlSelectBG_WONo_SelectedIndexChanged">
                <asp:ListItem Text="Select WONo or BG Group" Value="0"></asp:ListItem>
                <asp:ListItem Text="BG Group" Value="1"></asp:ListItem>
                <asp:ListItem Text="WONo" Value="2"></asp:ListItem>
            </asp:DropDownList>
             &nbsp;<asp:TextBox ID="TxtWONo" runat="server" CssClass="box3" Visible="False" 
                Width="95px"></asp:TextBox>
                <asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="False" 
                CssClass="box3" Height="21px" 
                
                    DataSourceID="SqlBGGroup" DataTextField="Symbol" DataValueField="Id" Visible="False"></asp:DropDownList>
     
        &nbsp;
            <asp:DropDownList ID="DrpMonths" runat="server">
            </asp:DropDownList>
&nbsp;&nbsp;
            <asp:DropDownList ID="Drptype" runat="server" AutoPostBack="False"  CssClass="box3">
                <asp:ListItem Value="0">NA</asp:ListItem>
                <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                <asp:ListItem Text="Absent" Value="2"></asp:ListItem>
                <asp:ListItem Text="Onsite" Value="3"></asp:ListItem>
                <asp:ListItem Text="PL" Value="4"></asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp; From Date
                <asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight" 
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
            &nbsp;To&nbsp;
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" TargetControlID="TxtTodate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="view"></asp:RegularExpressionValidator>
                
            &nbsp;&nbsp;
                Emp Name
            <asp:TextBox ID="TxtEmpName" runat="server" CssClass="box3" Width="250px"></asp:TextBox>
            <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                CompletionInterval="100" CompletionListCssClass="almt" 
                CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                FirstRowSelected="True" MinimumPrefixLength="1" 
                ServiceMethod="GetCompletionList" ServicePath="" 
                ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmpName" 
                UseContextKey="True">
            </cc1:AutoCompleteExtender>
              &nbsp;&nbsp;
            <asp:Button ID="BtnSearch" runat="server" CssClass="redbox" 
                onclick="BtnSearch_Click" Text="Search" ValidationGroup="view" />

        
        
        
        
            <asp:SqlDataSource ID="SqlBGGroup" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT [Id], [Symbol] As Symbol  FROM [BusinessGroup]">
            </asp:SqlDataSource>
                      
        
        
        
        
        </td>
        </tr>
       
       
        <tr>
        <td height="25px" valign="top">
        
        
   
        
            <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both" 
                Width="100%">
                <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                     PageSize="17" Width="800px" onrowcommand="GridView2_RowCommand" 
    onpageindexchanging="GridView2_PageIndexChanging">
                    <FooterStyle 
        Font-Bold="False" />
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="BtnSel" runat="server" Text="Select" CommandName="Sel" />
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeName" runat="server" 
                                    Text='<%# Bind("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="25%"  />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="2%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="EmpId" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("EmpId") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="4%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Designation" >
                            <ItemTemplate>
                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" Width="8%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" >
                            <ItemTemplate>
                                <asp:Label ID="LblDate" runat="server" Text='<%# Bind("Date") %>' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center" Width="7%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WONo" >
                            <ItemTemplate>
                                <asp:Label ID="Lblwono" runat="server" Text='<%# Bind("WONo") %>' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center"   Width="7%"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="BG" >
                            <ItemTemplate>
                                <asp:Label ID="LblDept" runat="server" Text='<%# Bind("Dept") %>' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle  HorizontalAlign="Center"  Width="6%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" >
                            <ItemTemplate>
                                <asp:Label ID="LblType" runat="server" Text='<%# Bind("Types") %>' ></asp:Label>
                            </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table width="100%" class="fontcss">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <HeaderStyle Font-Size="9pt" />
                </asp:GridView>
            </asp:Panel>
        
        
        </td>
        </tr>
       
       
         <tr>
        <td>
        
        
   
        
            <asp:Panel ID="Panel2" runat="server" Height="230px" ScrollBars="Both" Width="100%">
           
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                CssClass="yui-datatable-theme" 
    Width="98%" onrowcommand="GridView3_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle 
                        HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="BtnDel" runat="server" Text="Delete" CommandName="Del" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Equip No">
                            <ItemTemplate>
                                <asp:Label ID="lblEquipNo" runat="server" Text='<%# Bind("EquipNo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cate.">
                            <ItemTemplate>
                                <asp:Label ID="lblCate" runat="server" Text='<%# Bind("Cate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubCate">
                            <ItemTemplate>
                                <asp:Label ID="lblSubCate" runat="server" Text='<%# Bind("SubCate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Planned">
                            <ItemTemplate>
                                <asp:Label ID="lblPlanned" runat="server" Text='<%# Bind("Planned") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actual">
                            <ItemTemplate>
                                <asp:Label ID="lblActual" runat="server" Text='<%# Bind("Actual") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="20%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hours">
                            <ItemTemplate>
                                <asp:Label ID="lblHrs" runat="server" Text='<%# Bind("Hrs") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblMId" runat="server" Text='<%# Bind("MId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
                      
        
      </td>
        
        </tr>
        
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

