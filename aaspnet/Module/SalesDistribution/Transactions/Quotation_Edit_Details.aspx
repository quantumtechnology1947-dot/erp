<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_Quotation_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>


     <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../Css/StyleSheet.css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script type="text/javascript">


        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr height="21">
      <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<b>Customer  Quotation-Edit</b></td>
    </tr>
        <tr>
            <td>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
        Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
        <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
        <HeaderTemplate>
        
        
        
        Customer Details</HeaderTemplate>
        

<ContentTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
    <td 
                                colspan="1" align="left" valign="middle" 
        height="24" width="10%">Qutation No</td>
    <td align="left" height="24" valign="middle" width="90%">
        :<asp:Label ID="LblQuoteNo" runat="server" style="font-weight: 700"></asp:Label>
    </td>
    </tr>
    <tr>
        <td align="left" colspan="1" height="24" valign="middle" width="15%">
            Enquiry No</td>
        <td align="left" height="24" valign="middle" width="25%">
            :<asp:Label ID="LblEnquiry" runat="server" style="font-weight: 700"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="1" height="24" valign="middle" width="15%">
            Name of Customer&nbsp;&nbsp;&nbsp;</td>
        <td align="left" height="24" valign="middle" width="25%">
            :<asp:Label ID="LblName" runat="server"></asp:Label>
            <asp:Label ID="Lblpoid" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="LblCustId" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td 
            align="left" valign="top" height="20">Regd. Office Address&#160;</td>
        <td align="left" valign="top" height="25">:<asp:Label ID="LblAddress" runat="server"></asp:Label></td>
    </tr><tr>
        <td align="left" 
                                valign="middle" height="20" class="style1">&nbsp;</td>
    <td valign="middle" 
                    align="left">&nbsp;</td>
    </tr>
    <tr>
        <td align="left" class="style1" height="20" valign="middle">
            &nbsp;</td>
        <td align="left" valign="middle">
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
    <table border="0" cellspacing="0" cellpadding="0" style="width: 99%"><tr><td colspan="4" align="left" valign="middle" height="24">&#160;Description &amp; Specification of goods</td></tr><tr>
        <td align="left" valign="middle" width="5%" rowspan="4">
            <asp:TextBox ID="TxtDesc" runat="server" CssClass="box3" Height="70px" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqDesc1" runat="server" 
                ControlToValidate="TxtDesc" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
        <td align="left" height="24" valign="middle">
            Total Qty of goods</td>
        <td align="left" height="24" valign="middle">
            :
            <asp:TextBox ID="TxtQty" runat="server" CssClass="box3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqTotQty" runat="server" 
                ControlToValidate="TxtQty" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                ControlToValidate="TxtQty" ErrorMessage="*" 
                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
        </td>
        </tr>
        <tr>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" height="24" valign="middle">
                Rate per unit</td>
            <td align="left" height="24" valign="middle">
                :
                <asp:TextBox ID="TxtRate" runat="server" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                    ControlToValidate="TxtRate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                    ControlToValidate="TxtRate" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" height="24" valign="middle">
                Discount (in %)</td>
            <td align="left" height="24" valign="middle">
                :
                <asp:TextBox ID="TxtDiscount" runat="server" CssClass="box3"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqDiscount" runat="server" 
                    ControlToValidate="TxtDiscount" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                    ControlToValidate="TxtDiscount" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" height="24" valign="middle">
                Unit</td>
            <td align="left" height="24" valign="middle">
                :
                <asp:DropDownList ID="DrpUnit" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="ReqDesc4" runat="server" 
                    ControlToValidate="DrpUnit" ErrorMessage="*" InitialValue="Select" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="right" height="24" valign="middle">
                <asp:Button ID="BtnSubmit" runat="server" CssClass="redbox" 
                    OnClick="BtnSubmit_Click" OnClientClick="return confirmationAdd()" 
                    Text="Submit" ValidationGroup="A" />
                <asp:Button ID="BtnGoodsNext" runat="server" CssClass="redbox" 
                    OnClick="BtnGoodsNext_Click" Text="  Next  " />
                <asp:Button ID="BtnGoodsCancel" runat="server" CssClass="redbox" 
                    OnClick="BtnGoodsCancel_Click" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" valign="middle" class="style8" width="15%">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    DataKeyNames="Id" OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                    OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" 
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
                    Width="70%">
                    <Columns>
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
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
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" Text='<%#Eval("ItemDesc") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqDesc" runat="server" 
                                    ControlToValidate="txtDesc" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ItemDesc") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlunit" runat="server" DataSourceID="SqlDataSource12" 
                                    DataTextField="Symbol" DataValueField="Id">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ReqUnit" runat="server" 
                                    ControlToValidate="ddlunit" ErrorMessage="*" InitialValue="Select" 
                                    ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                 <asp:Label ID="lblUniit2" Visible="false" runat="server" Text='<%#Eval("UnitId") %>'> </asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUniit" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="7%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRate" runat="server" Width="70%" Text='<%#Eval("Rate") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                    ControlToValidate="TxtRate" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                                
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="15%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discount">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDiscount" runat="server" Width="78%" Text='<%#Eval("Discount") %>' />
                                <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"> </asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Qty">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTotalQty" runat="server" Width="70%" Text='<%#Eval("TotalQty") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqTotQty" runat="server" 
                                    ControlToValidate="txtTotalQty" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                    ControlToValidate="txtTotalQty" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("TotalQty") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="15%" />
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
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" valign="middle">
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
                                Width="70%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" ValidationGroup="edit1">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId1" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDesc1" runat="server" Text='<%#Eval("ItemDesc") %>'>
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqDesc1" runat="server" 
                                                ControlToValidate="txtDesc1" ErrorMessage="*" ValidationGroup="edit1">
                                            </asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesc1" runat="server" Text='<%#Eval("ItemDesc") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="40%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlunit1" runat="server" DataSourceID="SqlDataSource1" 
                                                DataTextField="Symbol" DataValueField="Id">
                                            </asp:DropDownList>
                                             <asp:Label ID="lblUniit2" runat="server" Visible="false" Text='<%#Eval("UnitId") %>'>
                                            </asp:Label>
                                            <asp:RequiredFieldValidator ID="ReqUnit1" runat="server" 
                                                ControlToValidate="ddlunit1" ErrorMessage="*" InitialValue="Select" 
                                                ValidationGroup="edit1">
                                            </asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUniit1" runat="server" Text='<%#Eval("Symbol") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtTotalQty1" runat="server"  Text='<%#Eval("TotalQty") %>'>
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqTotQty1" runat="server" 
                                                ControlToValidate="txtTotalQty1" ErrorMessage="*" ValidationGroup="edit1">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegQty1" runat="server" 
                    ControlToValidate="txtTotalQty1" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity1" runat="server" Text='<%#Eval("TotalQty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtRate1" runat="server" Text='<%#Eval("Rate") %>'>
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqRate1" runat="server" 
                                                ControlToValidate="txtRate1" ErrorMessage="*" ValidationGroup="edit1">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegRate1" runat="server" 
                    ControlToValidate="txtRate1" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit1"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate1" runat="server" Text='<%#Eval("Rate") %>'> </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDiscount1" runat="server" Text='<%#Eval("Discount") %>' />
                                            <asp:RegularExpressionValidator ID="RegDisc1" runat="server" 
                    ControlToValidate="txtDiscount1" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit1"> </asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDiscount1" runat="server" Text='<%#Eval("Discount") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
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
                        

<ContentTemplate>
<table width="100%">
<tr>
<td height="25">
    Payment Terms</td>
    <td height="25" valign="middle">
        :
        <asp:TextBox ID="TxtPayments" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqPayment" runat="server" 
            ControlToValidate="TxtPayments" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator>
    </td>
    <td height="25">
        &nbsp;</td>
    <td height="25">
    </td>
</tr>
    <tr>
        <td height="25">
            &nbsp;</td>
        <td height="25" valign="middle">
            <asp:TextBox ID="TxtPF" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
            <asp:DropDownList ID="DrpPFType" runat="server" Height="20px" Width="80px" 
                Visible="False">
                <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td height="25" valign="middle">
            CGST/IGST</td>
        <td height="25" valign="middle">
            :
            <asp:DropDownList ID="DrpExcise" runat="server" DataSourceID="SqlExcise" 
                DataTextField="Terms" DataValueField="Id" Height="20px" Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            SGST</td>
        <td height="25">
            :
            <asp:DropDownList ID="DrpVat" runat="server" DataSourceID="SqlVAT" 
                DataTextField="Terms" DataValueField="Id" Height="20px" Width="200px">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtOctroi" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
            <asp:DropDownList ID="DrpOctroiType" runat="server" Height="20px" Width="80px" 
                Visible="False">
                <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtWarrenty" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtInsurance" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtTransPort" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtNoteNo" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtRegdNo" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtFreight" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
            <asp:DropDownList ID="DrpFreightType" runat="server" Height="20px" 
                Width="80px" Visible="False">
                <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="TxtDueDate" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
            <cc1:CalendarExtender ID="TxtDueDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDueDate">
            </cc1:CalendarExtender>
        </td>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="Txtvalidity" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td height="25">
            <asp:TextBox ID="Txtocharges" runat="server" CssClass="box3" Width="200px" 
                Visible="False">0</asp:TextBox>
            <asp:DropDownList ID="DrpOChargeType" runat="server" Height="20px" 
                Width="80px" Visible="False">
                <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem>
                <asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            Delivery Terms :</td>
        <td height="25">
            <asp:TextBox ID="TxtDelTerms" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td valign="top">
            Remarks :</td>
        <td colspan="2" valign="top">
            <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Height="60px" 
                TextMode="MultiLine" Width="400px"></asp:TextBox>
        </td>
        <td align="right" valign="bottom">
            <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox" 
                OnClick="BtnUpdate_Click" OnClientClick="return confirmationUpdate()" 
                Text="Update" ValidationGroup="edit" />
            <asp:Button ID="BtnTermsCancel" runat="server" CssClass="redbox" 
                OnClick="BtnTermsCancel_Click" Text="Cancel" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:SqlDataSource ID="SqlVAT" runat="server" 
                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="SELECT *  FROM [tblVAT_Master] order by [Id] Asc">
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlCST" runat="server" 
                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="SELECT *  FROM [tblVAT_Master] order by [Id] Asc">
            </asp:SqlDataSource>
        </td>
        <td>
            <asp:SqlDataSource ID="SqlExcise" runat="server" 
                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="SELECT *  FROM [tblExciseser_Master] order by [Id] desc">
            </asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
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

                   
                        
                        
        