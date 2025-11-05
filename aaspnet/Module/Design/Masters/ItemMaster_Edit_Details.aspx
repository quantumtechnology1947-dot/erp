<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_ItemMaster_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style18
        {
        }
        .style19
        {
            color: #CC0000;
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
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG); " height="21" class="fontcsswhite"><b>&nbsp;Item Master - Edit</b></td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td class="style18">
                             <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server">
                          
                            <table align="left" cellpadding="0" cellspacing="0" width="1024">
                                <tr>
                                    <td height="27" valign="middle">
                                        &nbsp;</td>
                                    <td height="27" valign="middle" width="12%">
                                        <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
                                    </td>
                                    <td valign="middle" width="35%" colspan="2">
                                        <asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="True" 
                                            CssClass="box3" OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged" 
                                            Enabled="False" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="27" valign="middle">
                                        &nbsp;</td>
                                    <td height="27" valign="middle" width="12%">
                                        <asp:Label ID="Label4" runat="server" Text="Part No"></asp:Label>
                                    </td>
                                    <td valign="middle" colspan="2" height="25px">
                                        <asp:TextBox ID="TxtPartNo" runat="server" CssClass="box3" Enabled="False"></asp:TextBox>
                                        <span>Ex.: xxxx-xxx-xxx</span><span class="style19">&nbsp;</span></td>
                                    <td style="width: 70%" valign="middle">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;</td>
                                    <td valign="top">
                                        <asp:Label ID="Label7" runat="server">Description</asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="TxtManfDesc" runat="server" CssClass="box3" Rows="3" 
                                            TextMode="MultiLine" Width="500px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                            ControlToValidate="TxtManfDesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" height="25px">
                                        &nbsp;</td>
                                    <td height="25px" valign="middle">
                                        <asp:Label ID="Label9" runat="server" Text="UOM"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:DropDownList ID="DrpUOMBasic" runat="server" CssClass="box3">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqUOM" runat="server" 
                                            ControlToValidate="DrpUOMBasic" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:Label ID="Label19" runat="server" Text="UOM Conv."></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" height="25px" style="margin-left: 80px">
                                        &nbsp;</td>
                                    <td height="25px" style="margin-left: 80px" valign="middle">
                                        <asp:Label ID="Label13" runat="server" Text="Stock Qty"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:TextBox ID="TxtStockQty" runat="server" CssClass="box3" 
                                            onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onkeyup="if(isNaN(this.value)==true) { this.value=''; }" Enabled="False"> 0</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegStkQty" runat="server" 
                                            ControlToValidate="TxtStockQty" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:Label ID="Label20" runat="server">Class</asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:DropDownList ID="drpclass" runat="server" CssClass="box3" 
                                            DataSourceID="SqlDataSource2" DataTextField="Class" DataValueField="Id">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" height="25px">
                                        &nbsp;</td>
                                    <td height="25px" valign="middle">
                                        <asp:Label ID="Label11" runat="server" Text="Min Order Qty"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:TextBox ID="TxtMinorderQty" runat="server" CssClass="box3" 
                                            onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onkeyup="if(isNaN(this.value)==true) { this.value=''; }">1</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegStkQty2" runat="server" 
                                            ControlToValidate="TxtMinorderQty" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:Label ID="Label22" runat="server">Inspection Days</asp:Label>
                                    </td>
                                    <td valign="top" height="25px">
                                        <asp:TextBox ID="txtInspdays" runat="server" CssClass="box3">0</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                            ControlToValidate="txtInspdays" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;</td>
                                    <td valign="middle">
                                        <asp:Label ID="Label12" runat="server" Text="Min Stock Qty"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:TextBox ID="TxtMinStockQty" runat="server" CssClass="box3" 
                                            onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onkeyup="if(isNaN(this.value)==true) { this.value=''; }">1</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegStkQty1" runat="server" 
                                            ControlToValidate="TxtMinStockQty" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                    <td valign="middle">
                                        <asp:Label ID="Label14" runat="server" Text="Store Location"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:DropDownList ID="DrpLocation" runat="server" CssClass="box3">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqLoc" runat="server" 
                                            ControlToValidate="DrpLocation" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;</td>
                                    <td valign="middle">
                                        <asp:Label ID="Label18" runat="server" Text="Opening Bal Qty"></asp:Label>
                                    </td>
                                    <td valign="middle">
                                        <asp:TextBox ID="TxtOpeningBalQty" runat="server" CssClass="box3" 
                                            onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                            onkeyup="if(isNaN(this.value)==true) { this.value=''; }" Enabled="False">0</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegStkQty0" runat="server" 
                                            ControlToValidate="TxtOpeningBalQty" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                    <td valign="middle">
                                        <asp:Label ID="Label17" runat="server" Text="Opening Bal Date"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:TextBox ID="TxtOpeningBalDate" runat="server" CssClass="box3" 
                                            Enabled="False"></asp:TextBox>
                                        <cc1:CalendarExtender ID="TxtOpeningBalDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="TopRight"
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtOpeningBalDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;</td>
                                    <td valign="middle">
                                        <asp:Label ID="Label21" runat="server">Lead Days</asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:TextBox ID="txtleaddays" runat="server" CssClass="box3">0</asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="txtleaddays" ErrorMessage="*" 
                                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                    <td valign="middle">
                                        <asp:Label ID="Label23" runat="server" Text="Import/Local"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" height="25px">
                                        &nbsp;</td>
                                    <td height="25px" valign="middle">
                                        <asp:Label ID="Label24" runat="server" Text="Excise Applicable"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1"> Yes</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:Label ID="Label16" runat="server" Text="Absolute"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:CheckBox ID="CheckAbsolute" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" height="25px">
                                        &nbsp;</td>
                                    <td height="25px" valign="middle">
                                        <asp:Label ID="Label25" runat="server" Text="Attachment"></asp:Label>
                                    </td>
                                    <td valign="middle" height="25px">
                                        <asp:FileUpload ID="FileUpload3" runat="server" />
                                        <asp:Label ID="lbldownload" runat="server" Text=""></asp:Label>
                                       
                                        <asp:ImageButton ID="imgUpload0" runat="server" ImageUrl="~/images/cross.gif" 
                                            onclick="imgUpload0_Click" style="width: 13px" Visible="False" 
                                            Width="16px" />
                                    </td>
                                    <td height="25px" valign="middle">
                                        Buyer
                                    </td>
                                    <td valign="top" height="25px">
                                        <asp:DropDownList ID="DrpBuyer" runat="server" AutoPostBack="True" 
                                            DataSourceID="SqlDataSource3" DataTextField="EmpName" DataValueField="Id" 
                                            >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle">
                                        &nbsp;</td>
                                    <td valign="middle">
                                        <asp:Label ID="Label15" runat="server" Text="Image"></asp:Label>
                                    </td>
                                    <td valign="bottom" height="25px">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:Label ID="lbluploadImg" runat="server"></asp:Label>
                                        <asp:ImageButton ID="imgUpload" runat="server" ImageUrl="~/images/cross.gif" 
                                            onclick="imgUpload_Click" Visible="False" Width="16px" />
                                    </td>
                                    <td height="25px" valign="middle">
                                        <asp:Label ID="lblAHId" runat="server" Text="A/C Head"> </asp:Label>
                                    </td>
                                    <td valign="top">
                                       
                                        <table align="left" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="42%">
                                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="RadioButtonList4_SelectedIndexChanged" 
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Labour</asp:ListItem>
                                                        <asp:ListItem Value="2">With Material</asp:ListItem>
                                                        <asp:ListItem Value="3">Expenses</asp:ListItem>
                                                        <asp:ListItem Value="4">Service Provider</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DrpAChead" runat="server" AutoPostBack="True" 
                                                        CssClass="box3">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                       
                                    </td>
                                </tr>
                            </table>
                          </asp:Panel> </td>
                    </tr>
                    <tr>
                        <td class="style18" align="center">
&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnUpdate" runat="server" onclick="BtnUpdate_Click"   OnClientClick=" return confirmationUpdate()" 
                    Text="Update" CssClass="redbox" ValidationGroup="A" />
            &nbsp;<asp:Button ID="BtnCancel" runat="server" onclick="BtnCancel_Click" 
                    Text="Cancel" CssClass="redbox" />
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                            ProviderName="System.Data.SqlClient" 
                                            
                                            SelectCommand="SELECT [tblMM_Buyer_Master].[Id], [tblMM_Buyer_Master].[Category]+Convert(varchar,[tblMM_Buyer_Master].[Nos])+'-'+[tblHR_OfficeStaff].[EmployeeName]+'['+[tblMM_Buyer_Master].[EmpId]+']' As EmpName FROM [tblMM_Buyer_Master],[tblHR_OfficeStaff] where [tblHR_OfficeStaff].[EmpId]=[tblMM_Buyer_Master].[EmpId]">
                                        </asp:SqlDataSource>
                                       
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                            ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                            ProviderName="System.Data.SqlClient" 
                                            SelectCommand="SELECT * FROM [tblDG_Item_Class] where [Id]!=0"></asp:SqlDataSource>
                                       
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
           
                <asp:Panel ID="Panel2" ScrollBars="Auto"  Height="81px"  runat="server">
                <br />                              
                <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
                    AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView2_PageIndexChanging" 
                    Width="120%">
                    <Columns>                    
                    <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Right"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="id" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                        <ItemTemplate>
                        <asp:Label ID="category" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="7%" />
                        </asp:TemplateField>                        
                         
                        <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                        <asp:Label ID="itemcode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Description">
                        <ItemTemplate>
                        <asp:Label ID="manfdesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle Width="13%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="UOM ">
                        <ItemTemplate>
                        <asp:Label ID="uomBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>                         
                         <asp:TemplateField HeaderText="Min Order Qty">
                        <ItemTemplate>
                        <asp:Label ID="minOrderQty" runat="server" Text='<%# Eval("MinOrderQty") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Min Stock Qty">
                        <ItemTemplate>
                        <asp:Label ID="minStockQty" runat="server" Text='<%# Eval("MinStockQty") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Stock Qty">
                        <ItemTemplate>
                        <asp:Label ID="stockQty" runat="server" Text='<%# Eval("StockQty") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Location">
                        <ItemTemplate>
                        <asp:Label ID="location" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Open Bal Date">
                        <ItemTemplate>                       
                        <asp:Label ID="openBalDate" runat="server" Text='<%# Eval("OpenBalDate") %>'></asp:Label>
                        </ItemTemplate>                            
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Opening Bal Qty">
                        <ItemTemplate>
                        <asp:Label ID="openingBalQty" runat="server" Text='<%# Eval("OpeningBalQty") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Absolute">
                        <ItemTemplate>                        
                         <asp:Label ID="absolute" runat="server" Text='<%# Eval("Absolute") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="Excise">
                        <ItemTemplate>
                        <asp:Label ID="lblExcise" runat="server" Text='<%# Eval("Excise") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Import & Local">
                        <ItemTemplate>
                        <asp:Label ID="lblImportLocal" runat="server" Text='<%# Eval("ImportLocal") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM Conv.">
                        <ItemTemplate>
                        <asp:Label ID="uomConFact" runat="server" Text='<%# Eval("UOMConFact") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="A/C Head">
                        <ItemTemplate>
                        <asp:Label ID="lblACHead" runat="server" Text='<%# Eval("AHId") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                                    
                    </Columns>
                   <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
                </asp:GridView>
                
                </asp:Panel>
                </td>
        </tr>
        
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

