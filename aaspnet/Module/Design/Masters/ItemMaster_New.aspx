<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Masters_ItemMasterNew, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
        function limitcounter(n)
        {
           document.getElementById('TxtCounter').value=parseInt(n)-parseInt(document.getElementById('TxtPartNo').value.length);
        }
        
    </script>     
    
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
       
    <table cellpadding="2" cellpadding="0" cellspacing="0" width="120%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Item Master - New</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Add Items" ID="Add">
                        
                        
                    
<HeaderTemplate>Add Items
                        </HeaderTemplate><ContentTemplate>
                        
                    <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server">
                        <table align="left" 
                            cellpadding="0" cellspacing="0" width="100%"><tr><td height="27" 
                                valign="middle" width="17%"><asp:Label ID="Label2" runat="server" 
                                Text="Category"></asp:Label></td><td valign="middle" width="25%">
                                    <asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="True" 
                                            CssClass="box3" 
                                        OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged" Width="150px"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqCat" runat="server" 
                                            ControlToValidate="DrpCategory" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator></td><td>&#160;</td>
                                <td>&nbsp;</td></tr><tr><td valign="middle" 
                            height="27" width="17%"><asp:Label ID="Label4" runat="server" 
                            Text="Part No"></asp:Label></td><td valign="middle" colspan="3"><asp:TextBox ID="TxtPartNo" 
                                runat="server" CssClass="box3" MaxLength="3" Width="60px"></asp:TextBox><asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPartNo" 
                                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:CompareValidator 
                                ID="CompareValidator3" runat="server" ControlToValidate="TxtPartNo" 
                                ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ValidationGroup="A"></asp:CompareValidator>-
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="box3" MaxLength="3" 
                                    Width="60px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="TextBox1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                    ControlToValidate="TextBox1" ErrorMessage="*" Operator="DataTypeCheck" 
                                    Type="Integer" ValidationGroup="A"></asp:CompareValidator>
                                -
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="box3" MaxLength="3" 
                                    Width="60px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="TextBox2" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                    ControlToValidate="TextBox2" ErrorMessage="*" Operator="DataTypeCheck" 
                                    Type="Integer" ValidationGroup="A"></asp:CompareValidator>
                                &nbsp; Ex.:xxxx-xxx-xxx&nbsp;</td></tr><tr><td valign="top"><asp:Label 
                                ID="Label7" runat="server">Description</asp:Label></td><td colspan="3">
                                    <asp:TextBox 
                                    ID="TxtManfDesc" runat="server" CssClass="box3" Rows="6" TextMode="MultiLine" 
                                    Width="500px"></asp:TextBox><asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtManfDesc" 
                                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td valign="middle"><asp:Label 
                                ID="Label9" runat="server" Text="UOM"></asp:Label></td><td valign="middle" 
                                    height="25px"><asp:DropDownList ID="DrpUOMBasic" runat="server" 
                                    CssClass="box3">
                                </asp:DropDownList><asp:RequiredFieldValidator ID="ReqUOM" runat="server" 
                                    ControlToValidate="DrpUOMBasic" ErrorMessage="*" InitialValue="Select" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator></td><td 
                                valign="middle"><asp:Label ID="Label19" runat="server" Text="UOM Conv."></asp:Label></td><td 
                                valign="middle" height="25px"><asp:RadioButtonList ID="RadioButtonList1" 
                                    runat="server" RepeatDirection="Horizontal"><asp:ListItem Value="1">Yes</asp:ListItem><asp:ListItem 
                                        Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td></tr><tr><td valign="middle" height="25px"><asp:Label 
                                ID="Label13" runat="server" Text="Stock Qty"></asp:Label></td>
                                <td 
                                valign="middle">
                                    <asp:TextBox ID="TxtStockQty" runat="server" 
                                    CssClass="box3" onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onkeyup="if(isNaN(this.value)==true) { this.value=''; }" Enabled="False">0</asp:TextBox><asp:RegularExpressionValidator 
                                    ID="RegStkQty" runat="server" ControlToValidate="TxtStockQty" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator></td><td 
                                valign="middle" height="25px"><asp:Label ID="Label20" runat="server">Class</asp:Label></td><td 
                                valign="middle"><asp:DropDownList ID="drpclass" runat="server" CssClass="box3" 
                                    DataSourceID="SqlDataSource2" DataTextField="Class" DataValueField="Id">
                                </asp:DropDownList></td></tr><tr><td valign="middle"><asp:Label 
                                ID="Label11" runat="server" Text="Min Order Qty"></asp:Label></td>
                                <td 
                                valign="middle" height="25px"><asp:TextBox ID="TxtMinorderQty" 
                                    runat="server" CssClass="box3" 
                                    onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onkeyup="if(isNaN(this.value)==true) { this.value=''; }">1</asp:TextBox><asp:RegularExpressionValidator 
                                    ID="RegStkQty2" runat="server" ControlToValidate="TxtMinorderQty" 
                                    ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td 
                                valign="middle"><asp:Label ID="Label22" runat="server">Inspection Days</asp:Label></td><td valign="top"><asp:TextBox 
                                    ID="txtInspdays" runat="server" CssClass="box3">0</asp:TextBox><asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtInspdays" 
                                    ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td 
                                valign="middle"><asp:Label ID="Label12" runat="server" Text="Min Stock Qty"></asp:Label></td>
                                <td 
                                valign="middle" height="25px"><asp:TextBox ID="TxtMinStockQty" 
                                    runat="server" CssClass="box3" 
                                    onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onkeyup="if(isNaN(this.value)==true) { this.value=''; }">1</asp:TextBox><asp:RegularExpressionValidator 
                                    ID="RegStkQty1" runat="server" ControlToValidate="TxtMinStockQty" 
                                    ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td 
                                valign="middle"><asp:Label ID="Label14" runat="server" Text="Store Location"></asp:Label></td><td 
                                valign="middle" height="25px"><asp:DropDownList ID="DrpLocation" runat="server" 
                                    CssClass="box3">
                                </asp:DropDownList><asp:RequiredFieldValidator ID="ReqLoc" runat="server" 
                                    ControlToValidate="DrpLocation" ErrorMessage="*" InitialValue="Select" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td 
                                valign="middle"><asp:Label ID="Label18" runat="server" 
                                Text="Opening Bal Qty"></asp:Label></td><td valign="middle">
                                    <asp:TextBox 
                                    ID="TxtOpeningBalQty" runat="server" CssClass="box3" 
                                    onblue="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onfocus="if(isNaN(this.value)==true) { this.value=''; }" 
                                    onkeyup="if(isNaN(this.value)==true) { this.value=''; }" Enabled="False">0</asp:TextBox><asp:RegularExpressionValidator 
                                    ID="RegStkQty0" runat="server" ControlToValidate="TxtOpeningBalQty" 
                                    ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td valign="middle"><asp:Label 
                                    ID="Label17" runat="server" Text="Opening Bal Date"></asp:Label></td><td valign="middle">
                                    <asp:TextBox 
                                    ID="TxtOpeningBalDate" runat="server" CssClass="box3" Enabled="False" ></asp:TextBox>
                                    
                                    <cc1:CalendarExtender 
                                    ID="TxtOpeningBalDate_CalendarExtender" runat="server" Enabled="True" CssClass="cal_Theme2" PopupPosition="TopRight"
                                    Format="dd-MM-yyyy" TargetControlID="TxtOpeningBalDate"></cc1:CalendarExtender>
                                    
                                    </td></tr><tr><td 
                                valign="middle"><asp:Label ID="Label21" runat="server">Lead Days</asp:Label></td>
                                <td 
                                valign="middle"><asp:TextBox ID="txtleaddays" runat="server" 
                                    CssClass="box3">0</asp:TextBox><asp:RegularExpressionValidator 
                                    ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtleaddays" 
                                    ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td><td valign="middle"><asp:Label 
                                    ID="Label23" runat="server" Text="Import/Local"></asp:Label></td><td valign="middle"><asp:RadioButtonList 
                                    ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"><asp:ListItem 
                                    Value="1">Yes</asp:ListItem><asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td></tr><tr><td valign="middle"><asp:Label 
                                ID="Label24" runat="server" Text="Excise Applicable"></asp:Label></td>
                                <td 
                                valign="middle"><asp:RadioButtonList ID="RadioButtonList3" 
                                    runat="server" RepeatDirection="Horizontal"><asp:ListItem Value="1"> Yes</asp:ListItem><asp:ListItem 
                                        Selected="True" Value="0">No</asp:ListItem>
                                </asp:RadioButtonList></td><td valign="middle"><asp:Label ID="Label16" 
                                    runat="server" Text="Absolute"></asp:Label></td><td valign="middle"><asp:CheckBox 
                                    ID="CheckAbsolute" runat="server" /></td></tr><tr><td valign="middle">Drw/<asp:Label 
                                ID="Label15" runat="server" Text="Image"></asp:Label></td>
                                <td 
                                valign="middle"><asp:FileUpload ID="FileUpload1" runat="server" /></td><td valign="top">Buyer</td><td valign="top"><asp:DropDownList 
                                ID="DrpBuyer" runat="server" DataSourceID="SqlDataSource3" 
                                DataTextField="EmpName" DataValueField="Id">
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [tblMM_Buyer_Master].[Id], [tblMM_Buyer_Master].[Category]+Convert(varchar,[tblMM_Buyer_Master].[Nos])+'-'+[tblHR_OfficeStaff].[EmployeeName]+'['+[tblMM_Buyer_Master].[EmpId]+']' As EmpName FROM [tblMM_Buyer_Master],[tblHR_OfficeStaff] where [tblHR_OfficeStaff].[EmpId]=[tblMM_Buyer_Master].[EmpId] And [tblMM_Buyer_Master].Id!='0' ">
                            </asp:SqlDataSource></td></tr><tr><td valign="middle">Spec. Sheet</td>
                                <td 
                                valign="middle"><asp:FileUpload ID="FileUpload2" 
                                runat="server" /></td><td valign="top">A/C Head </td><td valign="top"><table 
                                align="left" cellpadding="0" cellspacing="0" class="style2"><tr><td>
                                    <asp:RadioButton 
                                    ID="RbtnLabour" runat="server" AutoPostBack="True" 
                                    GroupName="GroupACHead" OnCheckedChanged="RbtnLabour_CheckedChanged" 
                                    Text="Labour" /><asp:RadioButton ID="RbtnWithMaterial" runat="server" 
                                    AutoPostBack="True" GroupName="GroupACHead" 
                                    OnCheckedChanged="RbtnWithMaterial_CheckedChanged" Text="With Material" 
                                        Checked="True" />                                        
                                        <asp:RadioButton ID="RbtnExpenses" runat="server" 
                                    AutoPostBack="True" GroupName="GroupACHead" 
                                    OnCheckedChanged="RbtnExpenses_CheckedChanged" Text="Expenses" 
                                        Checked="False" />                                        
                                        <asp:RadioButton ID="RbtnServiceProvider" runat="server" 
                                    AutoPostBack="True" GroupName="GroupACHead" 
                                    OnCheckedChanged="RbtnServiceProvider_CheckedChanged" Text="Service Provider" 
                                        Checked="False" />                                        
                                        </td><td>
                                        <asp:DropDownList ID="DrpACHead" runat="server" CssClass="box3" 
                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td></tr></table></td></tr><tr><td valign="middle">&#160;&#160; </td>
                                <td 
                            valign="middle"><asp:SqlDataSource ID="SqlDataSource2" 
                            runat="server" ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                            ProviderName="System.Data.SqlClient" 
                            SelectCommand="SELECT * FROM [tblDG_Item_Class] where [Id]!=0"></asp:SqlDataSource></td><td 
                            valign="top">&#160; </td><td valign="bottom" height="25px"><asp:Button 
                                ID="BtnSubmit" runat="server" CssClass="redbox" OnClick="BtnSubmit_Click" 
                                OnClientClick="return confirmationAdd()" Text="Submit" ValidationGroup="A" />
                        </td></tr></table></asp:Panel></ContentTemplate></cc1:TabPanel>
                    <cc1:TabPanel ID="View" runat="server" HeaderText="View Items">
                        
                        

                    
<HeaderTemplate>View Items
                        
                        
                    </HeaderTemplate><ContentTemplate>
                            
                        <table width="100%"><tr><td class="fontcsswhite" height="25" valign="middle" >&#160; <asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="70px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged"><asp:ListItem>Select</asp:ListItem><asp:ListItem Value="Category">Category</asp:ListItem><asp:ListItem Value="WOItems">WO Items</asp:ListItem></asp:DropDownList><asp:DropDownList ID="DrpCategory1" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory1_SelectedIndexChanged" Height="21px" 
                    CssClass="box3"></asp:DropDownList>
                    
                    <asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem></asp:DropDownList>
             
             <asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px"
                    AutoPostBack="True" CssClass="box3"></asp:DropDownList><asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>&nbsp;<asp:Button ID="BtnSearch" runat="server" 
                                CssClass="redbox" onclick="BtnSearch_Click" Text="Search" />
                            </td></tr><tr>
            
            
            <td>
            
                <asp:Panel ID="Panel2" ScrollBars="Auto" runat="server">
              
            
            <asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" AllowPaging="True" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" Width="100%" 
                        PageSize="20">
                              <PagerSettings PageButtonCount="40" />
                              <Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate><ItemStyle 
                            HorizontalAlign="Right"></ItemStyle></asp:TemplateField><asp:BoundField DataField="Id" HeaderText="Id" 
                            Visible="False" /><asp:BoundField DataField="Category" HeaderText="Category"><ItemStyle Width="7%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="PartNo" HeaderText="PartNo"><ItemStyle Width="8%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="ItemCode" HeaderText="Item Code"><ItemStyle Width="10%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="ManfDesc" HeaderText="Description"><ItemStyle Width="15%" /></asp:BoundField><asp:BoundField DataField="UOMBasic" HeaderText="UOM "><ItemStyle Width="5%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="MinOrderQty" HeaderText="Min Order Qty" ><ItemStyle Width="6%" HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="MinStockQty" HeaderText="Min Stock Qty"><ItemStyle Width="6%" HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="StockQty" HeaderText="Stock Qty" ><ItemStyle Width="6%" HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="Location" HeaderText="Location"><ItemStyle Width="5%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="Absolute" HeaderText="Absolute" ><ItemStyle Width="5%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="Excise" HeaderText="Excise"><ItemStyle Width="5%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="ImportLocal" HeaderText="Import/ Local" ><ItemStyle Width="4%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="OpeningBalDate" HeaderText="Open Bal Date" ><ItemStyle Width="6%" HorizontalAlign="Center" /></asp:BoundField><asp:BoundField DataField="OpeningBalQty" HeaderText="Opening Bal Qty"><ItemStyle Width="6%" HorizontalAlign="Right" /></asp:BoundField><asp:BoundField DataField="UOMConFact" HeaderText="UOM Conv. Fact." 
                                Visible="False"><ItemStyle Width="8%" /></asp:BoundField>
                        
                        <asp:BoundField DataField="AHId" HeaderText="A/C Head."><ItemStyle Width="8%" /></asp:BoundField>
                                </Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView>  </asp:Panel></td></tr></table></ContentTemplate></cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        </table>
    
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

