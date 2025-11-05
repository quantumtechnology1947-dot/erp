<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_TPL_Design_Assembly_New, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
        function limitcounter(n)
        {
           document.getElementById('TxtCounter').value=parseInt(n)-parseInt(document.getElementById('txtPartNo').value.length);
        }
        
    </script>    
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <style type="text/css">
        .style12
        {
        }
        .style13
        {
            width: 445px;
        }
        .style14
        {
            width: 535px;
        }
        .style16
        {
        }
        .style17
        {
            height: 25px;
        }
        .style18
        {
            height: 25px;
        }
        .style19
        {
            text-align: left;
        }
        .style20
        {
            text-align: left;
            width: 86px;
        }
        .style21
        {
            width: 100%;
        }
        .style22
        {
            height: 18px;
        }
        .fontcss
        {
            width: 293px;
            margin-left: 12px;
        }
        .style23
        {
            width: 100%;
            float: left;
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
    <table align="left" cellpadding="0" cellspacing="0" class="style23">
        <tr>
            <td colspan="3" align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>&nbsp;TPL Assembly - New</b></td>
        </tr>
        <tr>
            <td>
                <%--<cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" onactivetabchanged="TabContainer1_ActiveTabChanged" 
                    BorderWidth="0px">
                    <cc1:TabPanel runat="server" HeaderText="Add" ID="TabPanel1">
                        <HeaderTemplate>
                            Add
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table align="center" cellpadding="0" cellspacing="0" width="980">
                                <tr>
                                    <td align="left" class="style13" height="21" valign="top">
                                        <table align="left" cellpadding="0" cellspacing="0" class="fontcss">
                                            <tr>
                                                <td>
                                                    Category</td>
                                                <td>
                                                    <asp:DropDownList ID="DDLCategory" runat="server" CssClass="box3" 
                                                        onselectedindexchanged="DDLCategory_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                        ControlToValidate="DDLCategory" ErrorMessage="*" ValidationGroup="assub" 
                                                        InitialValue="Select Category"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="30">
                                                    Part No</td>
                                                <td>
                                                    <asp:Label ID="lblWo" runat="server"></asp:Label>
                                                    <asp:TextBox ID="txtPartNo" runat="server" CssClass="box3" 
                                                        onblur="javascript:if(isNaN(this.value)==true){ this.value ='';}" 
                                                        onfocus="javascript:if(isNaN(this.value)==true){ this.value ='';}" 
                                                        onkeyup="javascript:if(isNaN(this.value)==true){ this.value ='';}" 
                                                        Width="160px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtPartNo" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator>
                                                    <asp:TextBox ID="TxtCounter" runat="server" BorderWidth="0px" ReadOnly="True" 
                                                        Width="20px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Revision</td>
                                                <td>
                                                    <asp:CheckBox ID="CKRevision" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="CKRevision_CheckedChanged" />
                                                    <asp:Label ID="hfRevisionTaskId" runat="server" Text="-" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Panel ID="Panel1" runat="server" CssClass="box3" Height="80px" 
                                                        ScrollBars="Auto">
                                                        <table align="left" cellpadding="0" cellspacing="0" class="style21">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" 
                                                                        DataSourceID="SqlDataSource1" DataTextField="Types" DataValueField="Id" 
                                                                        onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" RepeatColumns="1" 
                                                                        RepeatLayout="Flow" Visible="False">
                                                                    </asp:CheckBoxList>
                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                                                                        SelectCommand="SELECT [Id], [Types] FROM [tblDG_Revision_Type_Master]">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <asp:Label ID="lblRemark" runat="server" Text="Remarks" Visible="False"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" Height="31px" TextMode="MultiLine" 
                                                                        Visible="False" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" class="style14" height="21" valign="top">
                                        <table align="left" cellpadding="0" cellspacing="0" class="fontcss">
                                            <tr>
                                                <td align="left" class="style22" colspan="2" valign="middle">
                                                    &nbsp;Manf&nbsp; Description&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="style17" valign="top">
                                                    &nbsp;</td>
                                                <td class="style18">
                                                    <asp:TextBox ID="txtManfDescription" runat="server" CssClass="box3" 
                                                        Height="57px" TextMode="MultiLine" Width="270px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtManfDescription" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style12" colspan="2" valign="middle">
                                                    &nbsp;Purchase Description&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="style12" valign="top">
                                                    &nbsp;</td>
                                                <td>
                                                    <asp:TextBox ID="txtPurchDescription" runat="server" CssClass="box3" 
                                                        Height="57px" TextMode="MultiLine" Width="270px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                        ControlToValidate="txtPurchDescription" ErrorMessage="*" 
                                                        ValidationGroup="assub"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td align="left" class="fontcsswhite" height="21" valign="top">
                                        <table align="left" cellpadding="0" cellspacing="0" class="fontcss" 
                                            style="width: 344px">
                                            <tr>
                                                <td class="style20" height="25">
                                                    Unit Basic</td>
                                                <td>
                                                    <asp:DropDownList ID="DDLUnitBasic" runat="server" CssClass="box3" 
                                                        onselectedindexchanged="DDLUnitBasic_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                                        ControlToValidate="DDLUnitBasic" ErrorMessage="*" ValidationGroup="assub" 
                                                        InitialValue="Select"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style20" height="25">
                                                    Unit Purchase</td>
                                                <td>
                                                    <asp:DropDownList ID="DDLUnitPurchase" runat="server" CssClass="box3" 
                                                        onselectedindexchanged="DDLUnitPurchase_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="DDLUnitPurchase" ErrorMessage="*" 
                                                        ValidationGroup="assub" InitialValue="Select"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="style19" colspan="2" height="30">
                                                    Qty
                                                    <asp:TextBox ID="txtQuntity" runat="server" CssClass="box3" Width="62px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtQuntity" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                        ControlToValidate="txtQuntity" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="assub"></asp:RegularExpressionValidator>
                                                    &nbsp;<asp:CheckBox ID="CKWeldments" runat="server" />
                                                    Weldment&nbsp;
                                                    <asp:CheckBox ID="CKLH" runat="server" />
                                                    LH&nbsp;
                                                    <asp:CheckBox ID="CKRH" runat="server" />
                                                    RH</td>
                                            </tr>
                                            <tr>
                                                <td class="style16" colspan="2" height="25">
                                                    Drw/Image:
                                                    <asp:FileUpload ID="DrwUpload" runat="server" CssClass="box5" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style16" colspan="2" height="30">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                                      onclick="btnSubmit_Click" Text="Add To TPL" ValidationGroup="assub" />
                                      <asp:Button ID="Button1" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                                      onclick="Button1_Click" Text="Add To TPL &amp; BOM" ValidationGroup="assub" />
                                       <asp:Button ID="btncancel" runat="server" CssClass="redbox" 
                                                        onclick="btncancel_Click" Text="Cancel" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style16" colspan="2" height="20">
                                                    <asp:Label ID="lblMsg1" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
                                                    <asp:Label ID="lblMsg" runat="server" CssClass="fontcss" ForeColor="Red" 
                                                        style="font-weight: 700"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="View">
                        <HeaderTemplate>
                            View
                        </HeaderTemplate>
                        <ContentTemplate>
                        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
 <tr><td></td></tr>
  <tr>
  <td style="border: 1px solid #808080;">
                            <table align="left" cellpadding="0" cellspacing="0" class="style23">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                            OnPageIndexChanging="GridView2_PageIndexChanging" 
                                            OnRowCommand="GridView2_RowCommand" OnRowDeleting="GridView2_RowDeleting" 
                                            OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" 
                                            PageSize="7" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText="Id" Visible="False">
                                                    <ItemStyle Width="8%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ItemCode" HeaderText="Assembly No">
                                                    <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ManfDesc" HeaderText="Manf Desc">
                                                    <ItemStyle Width="25%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UOMBasic" HeaderText="UOM">
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PurchDesc" HeaderText="Purch Desc">
                                                    <ItemStyle Width="25%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="UOMPurchase" HeaderText="UOM">
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Qty" HeaderText="Qty">
                                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Weldments" HeaderText="Weld.">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LH" HeaderText="LH">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RH" HeaderText="RH">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:HyperLinkField DataNavigateUrlFields="ItemId" 
                                                    DataNavigateUrlFormatString="~/Controls/DownloadFile.aspx?Id={0}&amp;tbl=tblDG_Item_Master&amp;qfd=FileData&amp;qfn=FileName&amp;qct=ContentType" 
                                                    DataTextField="FileName" HeaderText="Drw File" />
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
                                    </td>
                                </tr>
                            </table>
                            </td>
  </tr>
 </table>

                            
                            
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>--%>
                
                <table align="left" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="middle" width="35%" colspan="2" height="22">
                                        &nbsp;<asp:Label ID="Label9" runat="server" Text="WO No: " 
                                            style="font-weight: 700"></asp:Label>
                                                    <asp:Label ID="lblWo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" width="35%" colspan="2" height="420">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                                OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="17" 
                                                Width="100%" ShowFooter="True" AllowPaging="True" 
                                            onrowcommand="GridView2_RowCommand"><Columns>
                                                <asp:TemplateField 
                                                        HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                                        </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="5%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                      
                                                        <ItemStyle Width="8%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Equipment No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEquipNo" runat="server" Text='<%# Bind("EquipmentNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                   
                                                    <FooterTemplate>
                                                    <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                                        OnClick="Button1_Click" OnClientClick=" return confirmationAdd()" 
                                                        Text="Insert" ValidationGroup="assub" CommandName="Insert" />
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" HorizontalAlign="Center" />
                                                    
                                                    <ItemStyle HorizontalAlign="Center" Width="9%" />
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit No &nbsp; (Ex: xx)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitNo" runat="server" Text='<%# Bind("UnitNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtUnitNo" runat="server" CssClass="box3" MaxLength="2" 
                                                        Width="50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="txtUnitNo" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>                             </FooterTemplate>
                                                        <FooterStyle VerticalAlign="Top" />
                                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Part No/SN (Ex: xx)">
                                                     <ItemTemplate>
                                                        <asp:Label ID="lblPartNo" runat="server" Text='<%# Bind("PartNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                        <FooterStyle VerticalAlign="Top" />
                                                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                                                        <FooterTemplate>
                                                        <asp:TextBox ID="txtPartNo" runat="server" CssClass="box3" MaxLength="2" 
                                                        Width="50px"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtPartNo" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ManfDesc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                      
                                                        <FooterTemplate>
                                                        <asp:TextBox ID="txtManfDescription" runat="server" CssClass="box3" 
                                                        TextMode="MultiLine" Width="350px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtManfDescription" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>
                                                        </FooterTemplate>
                                                        <FooterStyle VerticalAlign="Top" />
                                                        <ItemStyle Width="37%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UOM">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UOMBasic") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  
                                                    <FooterTemplate>
                                                    <asp:DropDownList ID="DDLUnitBasic" runat="server" CssClass="box3" 
                                                       DataSourceId="SqlDataSource1" DataValueField="Id" DataTextField="Symbol"  >
                                                    </asp:DropDownList>                                                   
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <ItemStyle HorizontalAlign="Center" Width="7%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  
                                                    <FooterTemplate>
                                                     <asp:TextBox ID="txtQuntity" runat="server" CssClass="box3" Width="50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtQuntity" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                        ControlToValidate="txtQuntity" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="assub"> </asp:RegularExpressionValidator>
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <ItemStyle HorizontalAlign="Right" Width="7%" />
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Drw/Image">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                                                NavigateUrl='<%# Eval("ItemId", "~/Controls/DownloadFile.aspx?Id={0}&tbl=tblDG_Item_Master&qfd=FileData&qfn=FileName&qct=ContentType") %>' 
                                                                Text='<%# Eval("FileName") %>'> </asp:HyperLink>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                    <asp:FileUpload ID="DrwUpload" runat="server" CssClass="box5"/>
                                                    </FooterTemplate>
                                                        <FooterStyle VerticalAlign="Top" />
                                                        <ItemStyle HorizontalAlign="Left" Width="13%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Spec. Sheet">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("ItemId", "~/Controls/DownloadFile.aspx?Id={0}&tbl=tblDG_Item_Master&qfd=AttData&qfn=AttName&qct=AttContentType") %>' 
                                                                Text='<%# Eval("AttName") %>'> </asp:HyperLink>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                    <asp:FileUpload ID="OtherUpload" runat="server" CssClass="box5" />
                                                    </FooterTemplate>
                                                    <FooterStyle VerticalAlign="Top" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table id="tbl" align="left" cellpadding="2" cellspacing="2" class="fontcss" width="1150">
                                                     <tr class="graybg">
                                                            <td align="center" valign="middle">&nbsp;</td>
                                                                <td width="0" align="center" valign="middle">
                                                                <b> Equipment No</b></td>
                                                                <td width="70" align="center" valign="middle">
                                                                <b>Unit No (Ex:xx)</b></td>
                                                                <td width="0" align="center" valign="middle">
                                                                <b>Part No/SN (Ex:xx)</b></td>
                                                                <td width="240" align="center" valign="middle">
                                                                <b>Description</b></td>
                                                                <td width="0" align="center" valign="middle">
                                                                <b>UOM</b></td>
                                                                <td width="80" align="center" valign="middle">
                                                                <b>Qty</b></td>
                                                                <td width="0" align="center" valign="middle">
                                                                <b>Drw/Image</b></td>
                                                                <td width="0" align="center" valign="middle">
                                                                <b>Spec. Sheet</b></td>
                                                                <td width="0" align="center" valign="middle">
                                                                &nbsp;</td>
                                                    </tr>
                                                        <tr>
                                                            <td align="center" valign="middle">
                                                                &nbsp;</td>
                                                            <td align="center" valign="middle">
                                                                <asp:Label ID="lblEquipNo1" runat="server"></asp:Label>
                                                            </td>
                                                            <td align="center" valign="middle">
                                                                <asp:TextBox ID="txtUnitNo1" runat="server" CssClass="box3" MaxLength="2" 
                                                        Width="50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                        ControlToValidate="txtUnitNo1" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator></td>
                                                            <td align="center" valign="middle">
                                                                <asp:TextBox ID="txtPartNo1" runat="server" CssClass="box3" MaxLength="2" 
                                                        Width="50px"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtPartNo1" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator></td>
                                                            <td align="left" valign="middle"><asp:TextBox ID="txtManfDescription1" runat="server" CssClass="box3" 
                                                        TextMode="MultiLine" Width="220px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtManfDescription1" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator></td>
                                                            <td align="center" valign="middle"><asp:DropDownList ID="DDLUnitBasic1" runat="server" CssClass="box3" 
                                                       DataSourceId="SqlDataSource1" DataValueField="Id" DataTextField="Symbol"  ></asp:DropDownList></td>
                                                            <td align="left" valign="middle"><asp:TextBox ID="txtQuntity1" runat="server" CssClass="box3" Width="50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="txtQuntity1" ErrorMessage="*" ValidationGroup="assub"> </asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegQty1" runat="server" 
                                                        ControlToValidate="txtQuntity1" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="assub"> </asp:RegularExpressionValidator></td>
                                                            <td align="center" valign="middle">
                                                                <asp:FileUpload ID="DrwUpload1" runat="server" CssClass="box5"/></td>
                                                            <td align="center" valign="middle">
                                                                <asp:FileUpload ID="OtherUpload1" runat="server" CssClass="box5" /></td>
                                                                <td width="0" align="center" valign="middle">
                                                                <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                                        OnClick="Button1_Click" OnClientClick=" return confirmationAdd()" 
                                                        Text="Insert" ValidationGroup="assub" CommandName="Insert1" /></td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" align="center" height="22">
                                                    
                                                    &nbsp;<asp:Button ID="btncancel" runat="server" CssClass="redbox" 
                                                        OnClick="btncancel_Click" Text="Cancel" />
                                                &nbsp;
                                                    <asp:Label ID="lblMsg1" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>
                                                    &nbsp;<asp:Label ID="lblMsg" runat="server" style="color: #FF0000; font-weight: 700"></asp:Label>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                        ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                                                        ProviderName="System.Data.SqlClient" 
                                                        SelectCommand="SELECT [Id], [Symbol] FROM [vw_Unit_Master]">
                                                    </asp:SqlDataSource>
                                                    
                                    </td>
                                    <td valign="top">
                                        &nbsp;</td>
                                </tr>
                            </table>
            </td>
        </tr>
    </table>
    </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

