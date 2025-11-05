<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustPO_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
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
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr height="21">
      <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<b>Customer  PO-Edit</b></td>
    </tr>
        <tr>
            <td>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
        Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
        <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
        <HeaderTemplate>
        
            Customer Details</HeaderTemplate>
        

<ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
    <td align="left" valign="middle" class="style1">&nbsp;Name of Customer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
    <td align="left" class="style1" valign="middle">
        :
        <asp:Label ID="LblName" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Lblpoid" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="LblCustId" runat="server" Visible="False"></asp:Label>
    </td>
    <td align="left" class="style1" valign="middle">
    </td>
    <td align="left" class="style1" valign="middle">
    </td>
    <td align="left" class="style1" valign="middle">
    </td>
    </tr><tr><td 
            align="left" valign="top" class="style1">Regd. Office Address&nbsp;</td>
        <td align="left" valign="top" colspan="4" class="style1">: <asp:Label ID="LblAddress" runat="server"></asp:Label></td></tr><tr>
    <td align="left" 
                                valign="middle" class="style5">&nbsp;Enquiry No </td>
    <td valign="middle" 
                    align="left" class="style5">: <asp:Label ID="LblEnquiry" runat="server" Text="Label"></asp:Label></td>
    <td valign="top" align="left" class="style5">&nbsp;&nbsp;</td>
    <td align="left" 
        colspan="2" valign="top" class="style5">: 
        <asp:DropDownList ID="drpQuotNO" runat="server" Visible="true" Width="135px">
        </asp:DropDownList>
    </td></tr><tr><td align="left" 
            valign="middle" height="24" class="style4">&nbsp;PO Received Date </td><td valign="middle" class="style3">
            : <asp:TextBox ID="TxtPORecDate" runat="server" CssClass="box3" 
                                        Width="80px"></asp:TextBox><cc1:CalendarExtender 
                    ID="TxtPORecDate_CalendarExtender" runat="server" 
CssClass="cal_Theme2" PopupPosition="BottomRight"
                                        Enabled="True" TargetControlID="TxtPORecDate" 
                    Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqPoRecDate" runat="server" 
            ControlToValidate="TxtPORecDate" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegPORecDate" runat="server" 
                ControlToValidate="TxtPORecDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="edit"></asp:RegularExpressionValidator>
        </td><td height="20" valign="middle">&nbsp;PO Date</td><td valign="middle" colspan="2">
        : <asp:TextBox ID="TxtPODate" 
                        runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="TxtPODate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtPODate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqPODate" runat="server" 
            ControlToValidate="TxtPODate" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegPODateVal" runat="server" 
            ControlToValidate="TxtPODate" ErrorMessage="*" 
            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
            ValidationGroup="edit"></asp:RegularExpressionValidator>
        </td></tr><tr><td 
            align="left" height="20" valign="top" class="style4">&nbsp;PO No&nbsp;</td><td class="style3">
            : <asp:TextBox ID="TxtPONo" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqPONO" runat="server" 
                ControlToValidate="TxtPONo" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td><td height="20">
            &nbsp;Our Vendor Code&nbsp;</td><td align="justify">
            : <asp:TextBox ID="TxtVendorCode" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVendorCode" runat="server" 
            ControlToValidate="TxtVendorCode" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td><td align="justify">
            &nbsp; </td></tr>
    <tr>
        <td align="left" class="style4" height="20" valign="top">
            &nbsp;</td>
        <td class="style3" colspan="2">
            &nbsp;</td>
        <td align="justify">
            &nbsp;</td>
        <td align="justify">
            <asp:Button ID="BtnCustomerNext" runat="server" CssClass="redbox" 
                OnClick="BtnCustomerNext_Click" Text="  Next  " />
            <asp:Button ID="BtnCustomerCancel" runat="server" CssClass="redbox" 
                OnClick="BtnCustomerCancel_Click" Text="Cancel" />
        </td>
    </tr>
    </table>
                       
        </ContentTemplate></cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>          
            
        
                Goods Details</HeaderTemplate>
             

<ContentTemplate><table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss"><tr><td><table width="98%" align="center" cellpadding="0" cellspacing="0"><tr><td height="19" align="left" valign="top">
    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%"><tr>
        <td colspan="5" align="left" valign="middle" height="24">&nbsp;Description &amp; 
            Specification of goods</td></tr><tr>
        <td align="left" 
                                    valign="top" rowspan="4"><asp:TextBox ID="TxtDesc" runat="server" CssClass="box3" Height="70px" 
                         TextMode="MultiLine" Width="400px"></asp:TextBox></td>
        <td align="left" rowspan="4" valign="top">
            <asp:RequiredFieldValidator ID="ReqDesc1" runat="server" 
                ControlToValidate="TxtDesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
        </td>
        <td align="left" 
        valign="top" class="style9">&nbsp;</td>
        <td align="left" class="style18" valign="top">
            Total Qty of goods</td>
        <td align="left" valign="middle" height="25">
            :
            <asp:TextBox ID="TxtQty" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTotQty" runat="server" 
                ControlToValidate="TxtQty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                ControlToValidate="TxtQty" ErrorMessage="*" 
                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
        </td>
        </tr><tr><td align="left" 
        valign="top" class="style9">&nbsp;</td>
            <td align="left" class="style18" valign="top">
                Rate per unit</td>
            <td align="left" valign="middle" height="25">
                :
                <asp:TextBox ID="TxtRate" runat="server" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                    ControlToValidate="TxtRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                    ControlToValidate="TxtRate" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
            </td>
        </tr><tr><td align="left" 
            valign="top" class="style9">
                &nbsp;</td>
            <td align="left" class="style18" valign="top">
                Discount</td>
            <td align="left" valign="middle" height="25">
                :
                <asp:TextBox ID="TxtDiscount" runat="server" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqDiscount" runat="server" 
                    ControlToValidate="TxtDiscount" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                    ControlToValidate="TxtDiscount" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
            </td>
        </tr><tr>
            <td 
                                    valign="top" align="left" class="style13">
                &nbsp;</td>
            <td align="left" class="style19" valign="top">
                Unit</td>
            <td align="left" valign="middle" height="25">
                :
                <asp:DropDownList ID="DrpUnit" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ReqDesc4" runat="server" 
                    ControlToValidate="DrpUnit" ErrorMessage="*" InitialValue="Select" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr><tr><td align="left" valign="middle" width="15%">
            </td>
            <td class="style3" valign="middle">
            </td>
            <td valign="middle" class="style7">
                &nbsp;</td>
            <td class="style19" valign="middle">
            </td>
            <td align="right" valign="middle" height="25">
                <asp:Button ID="BtnSubmit" runat="server" CssClass="redbox" 
                    OnClick="BtnSubmit_Click" OnClientClick="return confirmationAdd()" 
                    Text="Submit" ValidationGroup="A" />
                &nbsp;<asp:Button ID="BtnGoodsNext" runat="server" CssClass="redbox" 
                    OnClick="BtnGoodsNext_Click" Text="  Next  " />
                &nbsp;<asp:Button ID="BtnGoodsCancel" runat="server" CssClass="redbox" 
                    OnClick="BtnGoodsCancel_Click" Text="Cancel" />
            </td>
        </tr><tr><td align="left" colspan="5" valign="middle" class="style8" width="15%">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
                Width="70%" onrowdeleted="GridView1_RowDeleted" 
                onrowupdated="GridView1_RowUpdated">
                <Columns>
                    <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="3%" />
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ValidationGroup="editgrid">
                        <ItemStyle HorizontalAlign="Center" Width="4%" />
                    </asp:CommandField>
                    <asp:CommandField ShowDeleteButton="True">
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:CommandField>
                    <asp:TemplateField HeaderText="Id" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ItemDesc") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDesc" runat="server" Text='<%#Eval("ItemDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqDesc" runat="server" 
                                ControlToValidate="txtDesc" ErrorMessage="*" ValidationGroup="editgrid"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                    </asp:TemplateField>
                    
                 
                    <asp:TemplateField HeaderText="Unit">
                        <ItemTemplate>
                            <asp:Label ID="lblUniit" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlunit" runat="server" DataSourceID="SqlDataSource12" 
                                DataTextField="Symbol" DataValueField="Id">
                            </asp:DropDownList>  <asp:Label ID="lblUniit1" runat="server" Text='<%#Eval("UnitId") %>' Visible="false"> </asp:Label>
                            <asp:RequiredFieldValidator ID="ReqUnit" runat="server" 
                                ControlToValidate="ddlunit" ErrorMessage="*" InitialValue="Select" 
                                ValidationGroup="editgrid"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Qty">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("TotalQty") %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTotalQty" runat="server" Text='<%#Eval("TotalQty") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqTotQty" runat="server" 
                                ControlToValidate="txtTotalQty" ErrorMessage="*" ValidationGroup="editgrid"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                ControlToValidate="txtTotalQty" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                    </asp:TemplateField>
                    
                       <asp:TemplateField HeaderText="Rate">
                        <ItemTemplate>
                            <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'> </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("Rate") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                                ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="editgrid"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                                                ControlToValidate="txtRate" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Discount(%)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDiscount" runat="server" Text='<%#Eval("Discount") %>' />
                                                <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                                                ControlToValidate="txtDiscount" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"> </asp:RegularExpressionValidator>
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
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
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
            <asp:SqlDataSource ID="SqlDataSource12" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT [Id],[Symbol] FROM [Unit_Master]"></asp:SqlDataSource>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td align="left" colspan="5" valign="middle">
                <table align="center" width="100%">
                    <tr>
                        <td align="left">
                            <br />
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                OnPageIndexChanging="GridView2_PageIndexChanging" 
                                OnRowCancelingEdit="GridView2_RowCancelingEdit" 
                                OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting" 
                                OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" 
                                Width="70%" AllowSorting="True" onrowdeleted="GridView2_RowDeleted" 
                                onrowupdated="GridView2_RowUpdated">
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" ValidationGroup="edit">
                                         <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True">
                                          <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId1" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesc1" runat="server" Text='<%#Eval("ItemDesc") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDesc1" runat="server" Text='<%#Eval("ItemDesc") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqDesc1" runat="server" 
                                                ControlToValidate="txtDesc1" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUniit3" runat="server" Text='<%#Eval("Symbol") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlunit3" runat="server" DataSourceID="SqlDataSource1" 
                                                DataTextField="Symbol" DataValueField="Id">
                                            </asp:DropDownList>  <asp:Label ID="lblUniit4" runat="server" Text='<%#Eval("UnitId") %>' Visible="false"> </asp:Label>
                                            <asp:RequiredFieldValidator ID="ReqUnit3414" runat="server" 
                                                ControlToValidate="ddlunit3" ErrorMessage="*" InitialValue="Select" 
                                                ValidationGroup="edit"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity1" runat="server" Text='<%#Eval("TotalQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTotalQty1" runat="server" Text='<%#Eval("TotalQty") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqTotQty1" runat="server" 
                                                ControlToValidate="txtTotalQty1" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegQty1" runat="server" 
                                                ControlToValidate="txtTotalQty1" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit"></asp:RegularExpressionValidator>
                       
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate1" runat="server" Text='<%#Eval("Rate") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRate1" runat="server" Text='<%#Eval("Rate") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqRate1" runat="server" 
                                                ControlToValidate="txtRate1" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegRate1" runat="server" 
                                                ControlToValidate="txtRate1" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="8%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Discount(%)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiscount1" runat="server" Text='<%#Eval("Discount") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDiscount1" runat="server" Text='<%#Eval("Discount") %>' />
                                                <asp:RegularExpressionValidator ID="RegDisc1" runat="server" 
                                                ControlToValidate="txtDiscount1" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit"> </asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount2" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                               <asp:Label ID="lblAmount3" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="20%" />
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                ProviderName="System.Data.SqlClient" 
                                SelectCommand="SELECT [Id], [Symbol] FROM [Unit_Master]">
                            </asp:SqlDataSource>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table></td></tr></table></td></tr></table>
                        
                        
        
        </ContentTemplate>
        

</cc1:TabPanel>
     
        
        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                        <HeaderTemplate>
                        
                        
        
                        
                        
        
                            Terms &amp; Conditions</HeaderTemplate>
                        

<ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="14%" align="left" valign="middle">
    &nbsp;Payment Terms</td><td colspan="3" align="left" valign="middle" height="22">: <asp:Panel          ID="Panel2" runat="server"  Style="display:none; visibility:hidden;"  Width="200px"><asp:ListBox ID="lstTitles" 
        runat="server" Width="200px"    DataSourceID="SqlDataSource21"  
                DataTextField="PaymentTerms" DataValueField="PaymentTerms" AutoPostBack="True" 
                                    
        onselectedindexchanged="lstTitles_SelectedIndexChanged" Height="60px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource21" runat="server"  
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT Distinct [PaymentTerms] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel><asp:TextBox ID="TxtPayments"  
                            runat="server" Width="200px" CssClass="box3"></asp:TextBox><cc1:DropDownExtender ID="TxtPayments_DropDownExtender" runat="server" DropDownControlID="Panel2" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtPayments"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqPayment" runat="server" 
        ControlToValidate="TxtPayments" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">
        &nbsp; </td><td align="left" valign="middle" height="22" class="style9">
            <asp:TextBox ID="TxtPF" Width="200px" 
                            runat="server" CssClass="box3" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtPF_DropDownExtender" runat="server"
                         DropDownControlID="Panel3" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtPF"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqPf" runat="server" ControlToValidate="TxtPF" 
                ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td><td width="14%" align="left" valign="middle">
            &nbsp;GST </td><td width="36%" align="left" valign="middle">: <asp:Panel        ID="Panel5" runat="server" Style="display:none; visibility:hidden;"  Height="60px" Width="200px"><asp:ListBox ID="ListBox3" 
            runat="server" DataSourceID="SqlDataSource5"  AutoPostBack="True"
                DataTextField="Excise" DataValueField="Excise" 
                             onselectedindexchanged="ListBox3_SelectedIndexChanged" 
            Height="60px" Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Excise] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel><asp:TextBox ID="TxtExcise" runat="server" CssClass="box3" 
            Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtExcise_DropDownExtender" runat="server"
                         DropDownControlID="Panel5"  
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtExcise"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqExcise" runat="server" 
            ControlToValidate="TxtExcise" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">
        </td><td align="left" valign="middle" height="22" class="style9">&nbsp;<asp:Panel         ID="Panel4" runat="server" Style="display:none; visibility:hidden;"  Height="60px"  Width="200px"><asp:ListBox ID="ListBox2" 
            runat="server" DataSourceID="SqlDataSource4"  AutoPostBack="True"
                DataTextField="VAT" DataValueField="VAT" 
                             onselectedindexchanged="ListBox2_SelectedIndexChanged" 
            Height="60px" Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource4" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [VAT] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
            <asp:TextBox ID="TxtVAT" runat="server" 
                            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="txtVAT_DropDownExtender" runat="server" 
                            DropDownControlID="Panel4" 
                            DynamicServicePath="" Enabled="True" TargetControlID="txtVAT"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqVat" runat="server" 
                ControlToValidate="TxtVAT" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td><td align="left" valign="middle">
            &nbsp;</td><td align="left" valign="middle">&nbsp;<asp:Panel ID="Panel6" runat="server" Style="display:none; visibility:hidden;" Height="60px"  Width="200px"><asp:ListBox ID="ListBox4" 
            runat="server" DataSourceID="SqlDataSource6" 
                DataTextField="Octroi" DataValueField="Octroi"  AutoPostBack="True"
                               onselectedindexchanged="ListBox4_SelectedIndexChanged" 
            Height="60px" Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource6" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Octroi] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
            <asp:TextBox ID="TxtOctroi" runat="server" 
            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtOctroi_DropDownExtender" runat="server" 
                           DropDownControlID="Panel6"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtOctroi"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqOctri" runat="server" 
            ControlToValidate="TxtOctroi" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">
        &nbsp;</td><td align="left" valign="middle" height="22" class="style9">
            <asp:TextBox ID="TxtWarrenty" runat="server" 
                            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtWarrenty_DropDownExtender" runat="server" 
                         DropDownControlID="Panel7"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtWarrenty"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="Reqwarranty" runat="server" 
                ControlToValidate="TxtWarrenty" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td><td align="left" valign="middle">
            </td><td align="left" valign="middle">&nbsp;<asp:Panel 
            ID="Panel8" runat="server" Style="display:none; visibility:hidden;"  Height="60px"
            Width="200px"  ><asp:ListBox 
            ID="ListBox6" runat="server" DataSourceID="SqlDataSource8"  AutoPostBack="True"
                DataTextField="Insurance" DataValueField="Insurance" 
                               onselectedindexchanged="ListBox6_SelectedIndexChanged" 
            Height="60px" Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource8" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Insurance] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
            <asp:TextBox ID="TxtInsurance" runat="server" 
            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtInsurance_DropDownExtender" runat="server" 
                         DropDownControlID="Panel8"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtInsurance"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqInsurance" runat="server" 
            ControlToValidate="TxtInsurance" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">
        </td><td align="left" valign="middle" height="22" class="style9">
            &nbsp;<asp:Panel       ID="Panel9" runat="server" Style="display:none; visibility:hidden;"  Height="60px" Width="200px"><asp:ListBox ID="ListBox7" 
            runat="server" DataSourceID="SqlDataSource9"  AutoPostBack="True"
                DataTextField="Transport" DataValueField="Transport" 
                         onselectedindexchanged="ListBox7_SelectedIndexChanged" 
            Height="60px" Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource9" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Transport] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
            <asp:TextBox ID="TxtTransPort" runat="server" 
                            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtTransPort_DropDownExtender" runat="server" 
                          DropDownControlID="Panel9"
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtTransPort"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqTransport" runat="server" 
                ControlToValidate="TxtTransPort" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td><td align="left" valign="middle">
            &nbsp;</td><td align="left" valign="middle">&nbsp;<asp:TextBox ID="TxtNoteNo" 
                runat="server" CssClass="box3" 
            Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtNoteNo_DropDownExtender" runat="server" 
                          DropDownControlID="Panel10"
                      
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtNoteNo"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="ReqGCNo" runat="server" 
            ControlToValidate="TxtNoteNo" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td></tr><tr>
        <td align="left" valign="middle" class="style16">&nbsp;</td>
        <td align="left" valign="middle" class="style17">
            <asp:TextBox ID="TxtRegdNo" runat="server" CssClass="box3" Width="200px" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqRegnNo" runat="server" 
                ControlToValidate="TxtRegdNo" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
        </td>
        <td align="left" valign="middle" class="style16"></td>
        <td align="left" valign="middle" class="style16">&nbsp;<asp:Panel   ID="Panel12" runat="server" Style="display:none; visibility:hidden;"  Height="60px" Width="200px"><asp:ListBox ID="ListBox11" 
            runat="server" DataSourceID="SqlDataSource11" 
                DataTextField="Freight" DataValueField="Freight"  AutoPostBack="True"
                                 
            onselectedindexchanged="ListBox11_SelectedIndexChanged" Height="60px" 
            Width="200px"></asp:ListBox><asp:SqlDataSource ID="SqlDataSource11" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            SelectCommand="SELECT Distinct [Freight] FROM [SD_Cust_PO_Master]"></asp:SqlDataSource></asp:Panel>
            <asp:TextBox ID="TxtFreight" runat="server" 
            CssClass="box3" Width="200px" Visible="False">-</asp:TextBox><cc1:DropDownExtender ID="TxtFreight_DropDownExtender" runat="server"
                         DropDownControlID="Panel12" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtFreight"></cc1:DropDownExtender><asp:RequiredFieldValidator ID="Reqfrieght" runat="server" 
            ControlToValidate="TxtFreight" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></td></tr>
    <tr>
        <td align="left" valign="middle" class="style11">
            </td>
        <td align="left" valign="middle" class="style14">
            &nbsp;<asp:TextBox ID="Txtcst" runat="server" Width="200px" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqCST" runat="server" 
                ControlToValidate="Txtcst" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
        </td>
        <td align="left" valign="middle" class="style11">
            &nbsp;</td>
        <td align="right" style="text-align: left" valign="middle" class="style11">
            &nbsp;<asp:TextBox ID="Txtvalidity" runat="server" Width="200px" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqValidity" runat="server" 
                ControlToValidate="Txtvalidity" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="left" valign="middle" class="style15">
            &nbsp;</td>
        <td align="left" valign="middle" class="style15">
            <asp:TextBox ID="Txtocharges" runat="server" Width="200px" CssClass="box3" 
                Visible="False">-</asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqoCharges" runat="server" 
                ControlToValidate="Txtocharges" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
        </td>
        <td align="left" valign="middle" class="style15">
            </td>
        <td align="right" valign="top" class="style15">
            </td>
    </tr>
    <tr>
        <td align="left" valign="top">
            Attachment</td>
        <td align="left" colspan="2" valign="top">
            :
            <asp:HyperLink ID="HyperLink1" runat="server">[HyperLink1]</asp:HyperLink>
            <asp:ImageButton ID="ImageCross" runat="server" ImageUrl="~/images/cross.gif" 
                OnClick="ImageCross_Click" Width="16px" />
            <asp:FileUpload ID="FileUpload1" runat="server" size="25" />
        </td>
        <td align="right" valign="top">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left" valign="top">
            &nbsp;Remarks</td>
        <td align="left" colspan="2" valign="top">
            :
            <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Height="60px" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
        <td align="right" valign="top">
            <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox" 
                OnClick="BtnUpdate_Click" OnClientClick="return confirmationUpdate()" 
                Text="Update" ValidationGroup="edit" />
            &nbsp;<asp:Button ID="BtnTermsCancel" runat="server" CssClass="redbox" 
                OnClick="BtnTermsCancel_Click" Text="Cancel" />
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

