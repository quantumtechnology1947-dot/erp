<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Quotation_New_Details.aspx.cs" Inherits="Module_SalesDistribution_Transactions_Quotation_New_Details" Title="ERP"  Theme ="Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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

<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr>
      <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" 
            height="20">&nbsp;<b>Customer Quotation-New</b></td>
    </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" 
                    Width="100%" onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>Customer Details</HeaderTemplate>                        
                        <ContentTemplate>
                        
                         <table width="100%" class="fontcss">
                        <tr>
                        <td width="15%" >
                            Name of Customer&nbsp;</td>
                            <td>
                                :
                                <asp:Label ID="LblName" runat="server"></asp:Label>
                                <asp:Label ID="HfCustId" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="HfEnqId" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td class="style2" width="8%">
                                Enquiry No</td>
                            <td>
                                :
                                <asp:Label ID="LblEnqNo" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                            <tr>
                                <td class="style3" valign="top">
                                    Regd. Office Address</td>
                                <td rowspan="2" valign="top">
                                    :
                                    <asp:Label ID="LblAddress" runat="server"></asp:Label>
                                </td>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td class="style2">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                        OnClick="Button1_Click" Text="  Next  " />
                                    <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                        OnClick="Button2_Click" Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                        
                        
                        
                        </ContentTemplate>
                        
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" >
                        <HeaderTemplate>
                            Goods Details
                        </HeaderTemplate>
                        
                        <ContentTemplate><table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss"><tr><td><table width="98%" align="center" cellpadding="0" cellspacing="0"><tr><td height="19" align="left" valign="top">
                            <table border="0" cellspacing="0" cellpadding="0" style="width: 100%"><tr>
                            <td colspan="2" align="left" valign="middle" >&#160;Description &amp; Specification of goods</td></tr><tr>
                            <td align="left" valign="top" class="style161">
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
                                        <td height="25px" >
                                            :
                                            <asp:TextBox ID="TxtQty" runat="server" CssClass="box3"></asp:TextBox>
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
                                        <td height="25px" >
                                            :
                                            <asp:TextBox ID="TxtRate" runat="server" CssClass="box3" ValidationGroup="B"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                                                ControlToValidate="TxtRate" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                                                ControlToValidate="TxtRate" ErrorMessage="*" 
                                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Discount(in%)</td>
                                        <td  valign="middle" height="25px">
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
                                        <td height="25px">
                                            :
                                            <asp:DropDownList ID="DrpUnit" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="ReqDesc0" runat="server" 
                                                ControlToValidate="DrpUnit" ErrorMessage="*" InitialValue="Select" 
                                                ValidationGroup="B"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td></tr><tr><td align="right" valign="middle" class="style161"><br />
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
                                <td align="right" valign="middle" class="style161">
                                    &nbsp;</td>
                                <td align="right" valign="middle">
                                    &nbsp;</td>
                            </tr>
                            <tr><td align="center" valign="middle" colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
                                    OnRowUpdating="GridView1_RowUpdating" Width="100%" 
                                    onrowdatabound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowEditButton="True" ValidationGroup="editgrid" >
                                            <ItemStyle Width="3%" />
                                        </asp:CommandField>
                                        <asp:CommandField ShowDeleteButton="True" >
                                            <ItemStyle Width="3%" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("ItemDesc") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDesc" runat="server" CssClass="box3" Text='<%#Eval("ItemDesc") %>' />
                                                <asp:RequiredFieldValidator ID="ReqDesc" runat="server" 
                                    ControlToValidate="txtDesc" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Unit">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="lblUniit" runat="server" Text='<%#Eval("Symbol") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="ddlunit"   runat="server" AutoPostBack="true"   
                                                    DataSourceID="SqlDataSource12" DataTextField="Symbol" DataValueField="Id">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblUniit2" runat="server" Text='<%#Eval("UnitId") %>' Visible="false"> </asp:Label>
                                                
                                            </EditItemTemplate>
                                            
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("TotalQty") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="box3" Text='<%#Eval("TotalQty") %>' />
                                     <asp:RequiredFieldValidator ID="ReqQty" runat="server" 
                                    ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                    ControlToValidate="txtQty" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtRate" CssClass="box3" runat="server" Text='<%#Eval("Rate") %>' />
                                                <asp:RequiredFieldValidator ID="ReqRate" runat="server" 
                                    ControlToValidate="txtRate" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegRate" runat="server" 
                    ControlToValidate="txtRate" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Discount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'> </asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDiscount" runat="server" CssClass="box3" Text='<%#Eval("Discount") %>' />
                                                <asp:RequiredFieldValidator ID="ReqDisc" runat="server" 
                                    ControlToValidate="txtDiscount" ErrorMessage="*" ValidationGroup="editgrid">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegDisc" runat="server" 
                    ControlToValidate="txtDiscount" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="editgrid"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
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
                        <HeaderTemplate>Terms &amp; Conditions
                        </HeaderTemplate>
                        
                        <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="14%" align="left" valign="middle">&nbsp;Payment Terms</td>
                            <td colspan="3" align="left" valign="middle" height="25">: 
                            <asp:TextBox ID="TxtPayments" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqPayTerm" runat="server" 
                                ControlToValidate="TxtPayments" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td></tr><tr><td align="left" valign="middle" class="style8">&nbsp;</td>
                                <td align="left" valign="middle" height="25"> 
                                    <asp:TextBox ID="TxtPF" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                    <asp:DropDownList ID="DrpPFType" runat="server" Height="20px" Width="100px" 
                                        Visible="False">
                                    <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem><asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left" valign="middle" class="style8">
                                    CGST/IGST</td>
                                <td width="36%" align="left" valign="middle" height="25">:
                                    <asp:DropDownList ID="DrpExcise" runat="server" DataSourceID="SqlExcise" 
                                        DataTextField="Terms" DataValueField="Id" Height="20px" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                </tr><tr><td align="left" valign="middle" class="style6">SGST</td>
                                <td align="left" 
                                    valign="middle" height="25">: 
                                <asp:DropDownList ID="DrpVat" DataSourceID="SqlVAT"  DataTextField="Terms" 
                                        DataValueField="Id" runat="server" Height="20px" Width="200px">
                                </asp:DropDownList>
                              
                                </td><td align="left" valign="middle" height="25">&nbsp;</td>
                                <td align="left" valign="middle" height="25"> 
                                <asp:TextBox ID="TxtOctroi" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqOctri" runat="server" 
                                    ControlToValidate="TxtOctroi" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegRate2" runat="server" 
                                        ControlToValidate="TxtOctroi" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                <asp:DropDownList ID="DrpOctroiType" runat="server" Height="20px" Width="100px" 
                                        Visible="False">
                                <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem><asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr><tr><td align="left" valign="middle" class="style7">&nbsp;</td>
                                <td align="left" 
                                    valign="middle" height="25"> 
                                <asp:TextBox ID="TxtWarrenty" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">00</asp:TextBox>
                                </td><td align="left" valign="middle" class="style7">&nbsp;</td>
                                <td align="left" 
                                    valign="middle" height="25"> 
                                <asp:TextBox ID="TxtInsurance" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqInsurance" runat="server" 
                                    ControlToValidate="TxtInsurance" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegRate3" runat="server" 
                                        ControlToValidate="TxtInsurance" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator>
                                </td></tr><tr><td align="left" valign="middle" class="style184">&nbsp;</td>
                                <td align="left" valign="middle" height="25"> 
                                <asp:TextBox ID="TxtTransPort" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">00</asp:TextBox>
                                </td><td align="left" valign="middle" class="style187">&nbsp;</td>
                                <td align="left" valign="middle" height="25"> 
                                <asp:TextBox ID="TxtNoteNo" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqGcNote" runat="server" 
                                    ControlToValidate="TxtNoteNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr><tr><td align="left" valign="middle" height="22">&nbsp;</td>
                                <td align="left" height="25" valign="middle">
                                    <asp:TextBox ID="TxtRegdNo" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                </td>
                                <td align="left" valign="middle" class="style186">&nbsp;</td>
                                <td align="left" valign="middle" height="25"> 
                                <asp:TextBox ID="TxtFreight" runat="server" CssClass="box3" Width="200px" 
                                    ValidationGroup="A" Visible="False">0</asp:TextBox>
                                <asp:RequiredFieldValidator ID="Reqfreight" runat="server" 
                                    ControlToValidate="TxtFreight" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegRate4" runat="server" 
                                    ControlToValidate="TxtFreight" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                <asp:DropDownList ID="DrpFreightType" runat="server" Height="20px" 
                                    Width="100px" Visible="False">
                                    <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem><asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                            </tr><tr><td align="left" valign="middle" class="style9" width="200">Due Date :&nbsp;&nbsp;</td>
                                <td align="left" 
                                    valign="top" height="25">
                                    
                                    <asp:TextBox ID="TxtDueDate" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                   
                                    <cc1:CalendarExtender ID="TxtDueDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDueDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td align="left" valign="middle" class="style9">
                                    &nbsp;</td>
                                <td align="right" valign="top" style="text-align: left" height="25">
                                    <asp:TextBox ID="Txtvalidity" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqValidity" runat="server" 
                                        ControlToValidate="Txtvalidity" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td></tr>
                            <tr>
                                <td align="left" valign="top" class="style6">
                                    &nbsp;</td>
                                <td align="left" valign="middle" height="25">
                                    <asp:TextBox ID="Txtocharges" runat="server" CssClass="box3" Width="200px" 
                                        Visible="False">0</asp:TextBox>
                                    <asp:DropDownList ID="DrpOChargeType" runat="server" Height="20px" 
                                        Width="100px" Visible="false">
                                        <asp:ListItem Text="Amt(Rs)" Value="0"></asp:ListItem><asp:ListItem Text="Per(%)" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="left" valign="middle" class="style6">
                                    Delivery Terms</td>
                                <td align="left" valign="top" height="25">
                                    :
                                    <asp:TextBox ID="TxtDelTerms" runat="server" CssClass="box3" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqDelTerms" runat="server" 
                                        ControlToValidate="TxtDelTerms" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    &nbsp;Remarks</td>
                                <td align="left" colspan="2" valign="middle">
                                    :
                                    <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Height="60px" 
                                        TextMode="MultiLine" Width="400px"></asp:TextBox>
                                    <asp:SqlDataSource ID="SqlCST" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [tblVAT_Master] order by [Id] Asc">
                                    </asp:SqlDataSource>
                                </td>
                                <td align="right" valign="bottom">
                                    <asp:Button ID="Button6" runat="server" CssClass="redbox" 
                                        OnClick="Button6_Click" OnClientClick="return confirmationAdd()" Text="Submit" 
                                        ValidationGroup="A" />
                                    &nbsp;<asp:Button ID="BtnTermCancel" runat="server" CssClass="redbox" 
                                        OnClick="Button7_Click" Text="Cancel" />
                                    <asp:SqlDataSource ID="SqlExcise" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [tblExciseser_Master] order by [Id] desc">
                                    </asp:SqlDataSource>
                                    <asp:SqlDataSource ID="SqlVAT" runat="server" 
                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                        ProviderName="System.Data.SqlClient" 
                                        SelectCommand="SELECT *  FROM [tblVAT_Master] order by [Id] Asc">
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

