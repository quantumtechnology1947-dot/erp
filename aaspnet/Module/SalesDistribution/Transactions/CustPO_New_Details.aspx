<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustPO_New_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            height: 25px;
        }
        .style3
        {
            height: 25px;
            width: 104px;
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

<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr height="21">
      <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<b>Customer  PO-New</b></td>
    </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
                    Width="100%" onactivetabchanged="TabContainer1_ActiveTabChanged">
               
                
               
                    
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>
                            
                            Customer Details
                    
                    </HeaderTemplate>                       

                 <ContentTemplate>
                 
                 
                 
               
                 <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
                                        <td align="left" valign="middle" height="24">Name of Customer&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                        <td align="left" colspan="3" height="24" valign="middle">
                                            :
                                            <asp:Label ID="LblName" runat="server"></asp:Label>
                                            <asp:Label ID="HfCustId" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="HfEnqId" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        </tr><tr><td align="left" valign="top">Regd. Office Address</td><td align="left" 
                                                valign="top" colspan="3">: <asp:Label ID="LblAddress" runat="server"></asp:Label></td></tr><tr>
                                            <td align="left" 
                                            valign="middle">Enquiry No </td><td valign="top" align="left">: <asp:Label ID="LblEnqNo" runat="server"></asp:Label></td>
                                            <td height="20" valign="top" align="left">Quotation :
                                             </td><td height="20" valign="top" align="left">
                                                
                                                <asp:DropDownList ID="drpQuotNO" runat="server" Width="135px" Visible="True">
                                                </asp:DropDownList>
                                            </td></tr><tr><td 
                                                align="left" valign="middle" height="24" width="14%">PO No</td>
                                            <td valign="middle" width="27%">: <asp:TextBox ID="TxtPONo" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqPoNo" runat="server" 
                                                ControlToValidate="TxtPONo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td><td height="20" valign="middle" width="13%">PO Date</td><td valign="middle" height="20" width="46%">
                                            : <asp:TextBox    ID="TxtPODate" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                            
                                            <cc1:CalendarExtender ID="TxtPODate_CalendarExtender" runat="server" 
CssClass="cal_Theme2" PopupPosition="BottomRight"
                                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtPODate">
                                                    
                                                    </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqPoDate" runat="server" 
                                            ControlToValidate="TxtPODate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegPODate" runat="server" 
                                                ControlToValidate="TxtPODate" ErrorMessage="*" 
                                                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                        </td></tr><tr><td align="left" valign="middle" height="24">PO Received Date</td>
                                            <td valign="middle">: <asp:TextBox ID="TxtPORecDate" runat="server" CssClass="box3" 
                                                    Width="200px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="TxtPORecDate_CalendarExtender" runat="server" 
CssClass="cal_Theme2" PopupPosition="BottomRight"
                                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtPORecDate">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="ReqRecDate" runat="server" 
                                                ControlToValidate="TxtPORecDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegPORecDate" runat="server" 
                                                    ControlToValidate="TxtPORecDate" ErrorMessage="*" 
                                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                    </td>
                                            <td valign="middle" height="20">Our Vendor Code</td><td valign="middle">
                                            :
                                            <asp:TextBox 
                                            ID="TxtVendorCode" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqVendorCode" runat="server" 
                                            ControlToValidate="TxtVendorCode" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr>
                <tr>
                    <td align="left" height="20" valign="top">
                        &nbsp;&nbsp;</td>
                    <td>
                    </td>
                    <td height="20">
                        &nbsp;&nbsp;</td>
                    <td align="right">
                        &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                            OnClick="Button1_Click" Text="  Next  " />
                        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="redbox" 
                            OnClick="Button2_Click" Text="Cancel" />
                    </td>
                </tr>
                </table>
                
  
                
                </ContentTemplate>    
                </cc1:TabPanel>
    
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>
                            Goods Details
                    </HeaderTemplate>
              <ContentTemplate>
              
              
                    <table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss"><tr><td><table width="98%" align="center" cellpadding="0" cellspacing="0"><tr><td height="19" align="left" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0"><tr>
                            <td colspan="2" align="left" valign="middle" height="24">&#160;Description &amp; Specification of goods</td></tr><tr>
                            <td align="left" valign="top">
                                <table align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TxtItemDesc" runat="server" CssClass="box3" Height="70px" 
                                                TextMode="MultiLine" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:RequiredFieldValidator ID="ReqDesc" runat="server" 
                                    ControlToValidate="TxtItemDesc" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                            </td><td align="left" valign="top">
                                <table align="left" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            Total Qty of goods</td>
                                        <td height="25" valign="middle">
                                            :
                                            <asp:TextBox ID="TxtQty" runat="server" CssClass="box3" 
                                                OnTextChanged="TxtQty_TextChanged"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqTotQty" runat="server" 
                                                ControlToValidate="TxtQty" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                ControlToValidate="TxtQty" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Rate per unit</td>
                                        <td height="25">
                                            :
                                            <asp:TextBox ID="TxtRate" runat="server" CssClass="box3" ValidationGroup="B"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                                                ControlToValidate="TxtRate" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="Regrate" runat="server" 
                                                ControlToValidate="TxtRate" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Discount</td>
                                        <td height="25" valign="middle">
                                            :
                                            <asp:TextBox ID="TxtDiscount" runat="server" CssClass="box3" 
                                                ValidationGroup="B"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="Reqdiscount" runat="server" 
                                        ControlToValidate="TxtDiscount" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                                                ControlToValidate="TxtDiscount" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Unit</td>
                                        <td height="21">
                                            :
                                            <asp:DropDownList ID="DrpUnit" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ReqDesc0" runat="server" 
                                                ControlToValidate="DrpUnit" ErrorMessage="*" InitialValue="Select" 
                                                ValidationGroup="B"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td height="21">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td></tr><tr><td align="right" valign="middle"><br />
                                </td>
                                <td align="right" valign="middle">
                                    <asp:Button ID="Button5" runat="server" CssClass="redbox" 
                                        OnClick="Button5_Click" Text="Submit" 
                                        onclientclick="return confirmationAdd()" ValidationGroup="B" />
                                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="redbox" 
                                        OnClick="Button3_Click" Text="  Next  " />
                                    &nbsp;<asp:Button ID="Button4" runat="server" CssClass="redbox" 
                                        OnClick="Button4_Click" Text="Cancel" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="middle">
                                    &nbsp;</td>
                                <td align="right" valign="middle">
                                    &nbsp;</td>
                            </tr>
                            <tr><td align="center" valign="middle" colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                    OnPageIndexChanging="GridView1_PageIndexChanging"  PageSize="15"
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
                                    Width="100%" 
                                    onrowdatabound="GridView1_RowDataBound" 
                                    onrowupdating="GridView1_RowUpdating1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle Width="3%" HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        
                                        <asp:CommandField ShowEditButton="True"  ValidationGroup="A1" >
                                       <ItemStyle Width="3%" HorizontalAlign="Center" />
                                         </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True">
                                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                            </ItemTemplate>                                            
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ItemDesc") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDesc"  Width="95%" runat="server" Text='<%#Eval("ItemDesc") %>' />
                                                <asp:RequiredFieldValidator ID="ReqDesc" runat="server" 
                                                ControlToValidate="txtDesc" ValidationGroup="A1" ErrorMessage="*">
                                       </asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUniit" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlunit"  runat="server" AutoPostBack="true"   
                                                    DataSourceID="SqlDataSource12" DataTextField="Symbol" DataValueField="Id">
                                                </asp:DropDownList>  <asp:Label ID="lblUniit2" runat="server" Text='<%#Eval("UnitId") %>' Visible="false"> </asp:Label>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("TotalQty") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtQty" Width="85%" runat="server" Text='<%#Eval("TotalQty") %>' />
                                                 <asp:RegularExpressionValidator ID="Regqtyedit" runat="server" 
                                                ControlToValidate="txtQty" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A1"> </asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRate" runat="server" Width="85%" Text='<%#Eval("Rate") %>' />
                                                <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                                                ControlToValidate="txtRate" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A1"> 
                                                </asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount(%)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDiscount" runat="server" Width="85%" Text='<%#Eval("Discount") %>' />
                                                <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                                                ControlToValidate="txtDiscount" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A1"> </asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        
                                         
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                               <asp:Label ID="lblAmount1" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
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
                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                    SelectCommand="SELECT [Id],[Symbol] FROM [Unit_Master]"></asp:SqlDataSource>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                </td></tr></table></td></tr></table></td></tr></table>  
                       
                                             
                        
                    </ContentTemplate> 
                </cc1:TabPanel>  
                
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate> Terms &amp; Conditions 
                    </HeaderTemplate> 
                    <ContentTemplate>
                    
                    
                      <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
                            <td width="20%" align="left" valign="middle">&nbsp;Payment Terms</td>
                            <td colspan="3" align="left" valign="middle" height="25">: <asp:Panel ID="Panel2" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="lstTitles" runat="server" Width="200px"   DataSourceID="SqlDataSource2"  
                DataTextField="PaymentTerms" DataValueField="PaymentTerms"  AutoPostBack="True" 
                                    onselectedindexchanged="lstTitles_SelectedIndexChanged" Height="60px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT Distinct [PaymentTerms] FROM [SD_Cust_PO_Master]">
                                </asp:SqlDataSource></asp:Panel><asp:TextBox ID="TxtPayments"  
                            runat="server" Width="200px" CssClass="box3"></asp:TextBox>
                            <cc1:DropDownExtender ID="TxtPayments_DropDownExtender" runat="server" DropDownControlID="Panel2" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtPayments" 
                                DynamicServiceMethod="GetDynamicContent2"></cc1:DropDownExtender>
                            <asp:RequiredFieldValidator ID="ReqPayTerm" runat="server" 
                                ControlToValidate="TxtPayments" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td></tr><tr><td align="left" valign="middle">&nbsp;</td>
                                <td width="25%" align="left" valign="middle" 
            height="25">&nbsp;<asp:Panel ID="Panel3" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True"  DataSourceID="SqlDataSource3" 
                DataTextField="PF" DataValueField="PF"  
                             onselectedindexchanged="ListBox1_SelectedIndexChanged" Height="60px" 
                             Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [PF] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
                                    <asp:TextBox ID="TxtPF" Width="200px" 
                            runat="server" CssClass="box3" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtPF_DropDownExtender" runat="server"
                         DropDownControlID="Panel3" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtPF"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqPF" runat="server" ControlToValidate="TxtPF" 
                                    ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
            <td width="10%" align="left" valign="middle">
                GST </td>
                                
                                <td width="60%" align="left" valign="middle">:<asp:Panel ID="Panel5" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="ListBox3" runat="server" DataSourceID="SqlDataSource5" 
                DataTextField="Excise" DataValueField="Excise"  AutoPostBack="True"
                             onselectedindexchanged="ListBox3_SelectedIndexChanged" Height="60px" 
                             Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Excise] FROM [SD_Cust_PO_Master]">
                                    </asp:SqlDataSource></asp:Panel><asp:TextBox ID="TxtExcise" runat="server" CssClass="box3" Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtExcise_DropDownExtender" runat="server"
                         DropDownControlID="Panel5"  
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtExcise"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqExcise" runat="server" 
                                    ControlToValidate="TxtExcise" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                </tr><tr><td align="left" valign="middle">&nbsp;</td>
                                <td align="left" valign="middle" height="25">&nbsp;<asp:Panel ID="Panel4" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="ListBox2" runat="server" DataSourceID="SqlDataSource4"  AutoPostBack="True"
                DataTextField="VAT" DataValueField="VAT" 
                             onselectedindexchanged="ListBox2_SelectedIndexChanged" Height="60px" 
                             Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [VAT] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
                                    <asp:TextBox ID="txtVAT" runat="server" 
                            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="txtVAT_DropDownExtender" runat="server" 
                            DropDownControlID="Panel4" 
                            DynamicServicePath="" Enabled="True" TargetControlID="txtVAT"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqVat" runat="server" 
                                    ControlToValidate="txtVAT" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                
                                
                                <td align="left" valign="middle">&nbsp;</td>
                                <td align="left" valign="middle" height="25"><asp:TextBox ID="TxtOctroi" 
                                        runat="server" CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtOctroi_DropDownExtender" runat="server" 
                           DropDownControlID="Panel6"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtOctroi"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqOctri" runat="server" 
                                    ControlToValidate="TxtOctroi" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr><tr><td align="left" valign="middle" class="style2">&nbsp;</td>
                                <td align="left" valign="middle" class="style2">&nbsp;<asp:Panel ID="Panel7" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="ListBox5" runat="server" DataSourceID="SqlDataSource7"  AutoPostBack="True"
                DataTextField="Warrenty" DataValueField="Warrenty" 
                             onselectedindexchanged="ListBox5_SelectedIndexChanged" Height="60px" 
                             Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource7" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Warrenty] FROM [SD_Cust_PO_Master]">
                                    </asp:SqlDataSource></asp:Panel>
                                    <asp:TextBox ID="TxtWarrenty" runat="server" 
                            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtWarrenty_DropDownExtender" runat="server" 
                         DropDownControlID="Panel7"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtWarrenty"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqWarranty" runat="server" 
                                    ControlToValidate="TxtWarrenty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td><td align="left" valign="middle" class="style3">
                              </td>
                                <td align="left" valign="middle" class="style2"><asp:TextBox ID="TxtInsurance" 
                                        runat="server" CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtInsurance_DropDownExtender" runat="server" 
                         DropDownControlID="Panel8"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtInsurance"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqInsurance" runat="server" 
                                    ControlToValidate="TxtInsurance" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr><tr><td align="left" valign="middle">&nbsp;</td>
                                <td align="left" valign="middle" class="style2" 
            height="25">&nbsp;<asp:Panel ID="Panel9" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="ListBox7" runat="server" DataSourceID="SqlDataSource9"  AutoPostBack="True"
                DataTextField="Transport" DataValueField="Transport" 
                         onselectedindexchanged="ListBox7_SelectedIndexChanged" Height="60px" 
                         Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource9" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Transport] FROM [SD_Cust_PO_Master]">
                                    
                                        </asp:SqlDataSource></asp:Panel>
                                    <asp:TextBox ID="TxtTransPort" runat="server" 
                            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtTransPort_DropDownExtender" runat="server" 
                          DropDownControlID="Panel9"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtTransPort"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqModTrans" runat="server" 
                                    ControlToValidate="TxtTransPort" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td><td align="left" valign="middle" class="style2">
                                  &nbsp;</td>
                                <td align="left" valign="middle"><asp:TextBox ID="TxtNoteNo" runat="server" 
                                        CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtNoteNo_DropDownExtender" runat="server" 
                          DropDownControlID="Panel10"
                      
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtNoteNo"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="ReqGcNote" runat="server" 
                                    ControlToValidate="TxtNoteNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr><tr><td align="left" valign="middle" height="22">&nbsp;</td>
                                <td align="left" height="25" valign="middle">
                                    &nbsp;<asp:TextBox ID="TxtRegdNo" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">-</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqRegNo" runat="server" 
                                        ControlToValidate="TxtRegdNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left" valign="middle">&nbsp;</td><td align="left" valign="middle"><asp:Panel ID="Panel12" runat="server" Style="display:none; visibility:hidden;" Width="200px"><asp:ListBox ID="ListBox11" runat="server" DataSourceID="SqlDataSource11"  AutoPostBack="True"
                DataTextField="Freight" DataValueField="Freight" 
                                 onselectedindexchanged="ListBox11_SelectedIndexChanged" Height="60px" 
                                 Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource11" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Freight] FROM [SD_Cust_PO_Master]">
                                </asp:SqlDataSource></asp:Panel><asp:TextBox ID="TxtFreight" runat="server" 
                                  CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtFreight_DropDownExtender" runat="server"
                         DropDownControlID="Panel12" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtFreight"></cc1:DropDownExtender>
                                <asp:RequiredFieldValidator ID="Reqfreight" runat="server" 
                                    ControlToValidate="TxtFreight" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr><tr><td align="left" valign="top">&nbsp;</td>
                                <td align="left" 
                                    valign="middle" height="25">
                                    &nbsp;<asp:TextBox ID="Txtcst" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">-</asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqCST" runat="server" 
                                    ControlToValidate="Txtcst" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left" valign="middle" class="style1">
                                    &nbsp;</td>
                                <td align="right" valign="top" style="text-align: left">
                                    <asp:TextBox ID="Txtvalidity" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">-</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqValidity" runat="server" 
                                        ControlToValidate="Txtvalidity" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr>
                            <tr>
                                <td align="left" valign="top">
                                    &nbsp;</td>
                                <td align="left" valign="middle" height="25">
                                    &nbsp;<asp:TextBox ID="Txtocharges" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">-</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqoCharges" runat="server" 
                                        ControlToValidate="Txtocharges" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td align="left" valign="middle" class="style1">
                                    </td>
                                <td align="right" valign="top">
                                    </td>
                            </tr>
                            <tr><td align="left" valign="top">Attachment</td><td align="left" colspan="2" valign="top">
                                :
                                <asp:FileUpload ID="FileUpload1" runat="server" size="50" />
                                </td><td align="right" valign="bottom">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Remarks</td>
                                <td align="left" colspan="2" valign="top">
                                    :
                                    <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Height="100px" 
                                        TextMode="MultiLine" Width="481px"></asp:TextBox>
                                </td>
                                <td align="right" valign="bottom">
                                    <asp:Button ID="Button6" runat="server" CssClass="redbox" 
                                        OnClick="Button6_Click" OnClientClick="return confirmationAdd()" Text="Submit" 
                                        ValidationGroup="A" />
                                    &nbsp;<asp:Button ID="BtnTermCancel" runat="server" CssClass="redbox" 
                                        OnClick="Button7_Click" Text="Cancel" />
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

