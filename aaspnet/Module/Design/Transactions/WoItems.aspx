<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" enableeventvalidation="false" inherits="Module_Design_Transactions_WoItems, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    <style type="text/css">
        .style22
        {
            height: 28px;
        }
        .style23
        {
            height: 30px;
        }
        .style24
        {
            height: 19px;
        }
        .style25
        {
            font-weight: bold;
        }
        .style26
        {
            height: 28px;
            font-weight: bold;
        }
        .style27
        {
            height: 19px;
            font-weight: bold;
        }
        .style28
        {
            height: 30px;
            font-weight: bold;
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
            <td align="left" valign="top">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;TPL Items&nbsp;&nbsp;WoNo:&nbsp;<asp:Label ID="lblwono" Font-Bold="true"  runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;Assly No:&nbsp;<asp:Label ID="lblasslyno" runat="server"></asp:Label></b>
                    </td>
                    </tr>
                    <tr>
                        <td>
                            <cc1:TabContainer ID="TabContainer1" runat="server"  Height="434px" 
                                AutoPostBack="True" 
                                onactivetabchanged="TabContainer1_ActiveTabChanged" ActiveTabIndex="0" 
                                 Width="100%" >
                                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Item Master" >
                                    <HeaderTemplate>
                                    Item Master</HeaderTemplate>
                                    <ContentTemplate><table width ="100%" cellpadding="0" cellspacing="0">
                                    <tr><td class="style12" valign="middle" height="25" ><asp:DropDownList ID="DrpCategory" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory_SelectedIndexChanged" 
                    CssClass="box3"></asp:DropDownList>&nbsp; <asp:DropDownList ID="DrpSubCategory" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpSubCategory_SelectedIndexChanged" 
                    CssClass="box3"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DrpSearchCode" 
                                            runat="server" AutoPostBack="True" CssClass="box3" 
                                            onselectedindexchanged="DrpSearchCode_SelectedIndexChanged"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ManfDesc">Manuf. Description</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.PurchDesc">Purchase Description</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem></asp:DropDownList>&nbsp;<asp:TextBox ID="txtSearchItemCode" runat="server" Width="200px" 
                    CssClass="box3"></asp:TextBox>&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px" AutoPostBack="True" CssClass="box3" 
                                            onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;
                                        
                                        
                                         <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />&nbsp;
            <asp:Button ID="btnCancel" runat="server" CssClass="redbox" onclick="btnCancel_Click" Text="Cancel" /></td></tr>
            <tr><td class="fontcss" height="207" 
                                                valign="top" align="right" colspan="3" style="text-align: left">
                <asp:GridView ID="GridView2" 
                                                runat="server" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" OnRowCommand="GridView2_RowCommand" 
         Width="100%" PageSize="12"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate><HeaderStyle Font-Size="10pt" /><ItemStyle HorizontalAlign="Right" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="Req Qty"><ItemTemplate><asp:TextBox ID="txtQty" runat="server" CssClass="box3" 
                                                                        onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                                        onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                                        onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                                        Width="60px" />
                                                                        
                                                                         <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                        ControlToValidate="txtQty" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="as"></asp:RegularExpressionValidator>
                                                                        </ItemTemplate>
                            <ItemStyle VerticalAlign="Top" Width="7%" /></asp:TemplateField>
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:Button ID="btnadd" CommandName="Add"  CssClass="redbox"  ValidationGroup="as" runat="server"  OnClientClick=" return confirmationAdd()" 
                    Text="Add">
                    </asp:Button>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="2%" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'> </asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" /></asp:TemplateField><asp:BoundField DataField="Category" HeaderText="Category" Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:BoundField DataField="SubCategory" HeaderText="SubCategory" 
                                                                Visible="False"><ItemStyle VerticalAlign="Top" /></asp:BoundField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblitemcode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label></ItemTemplate>
                            <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Manf Desc"><ItemTemplate><asp:Label ID="lblManfDesc" runat="server" Text='<%#Eval("ManfDesc") %>'> </asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" Width="28%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMBasic" runat="server" Text='<%#Eval("UOMBasic") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="Purch Desc"><ItemTemplate><asp:Label ID="lblPurchDesc" runat="server" Text='<%#Eval("PurchDesc") %>'> </asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" Width="28%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMPurchase" runat="server" Text='<%#Eval("UOMPurchase") %>'> </asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" /></asp:TemplateField><asp:TemplateField HeaderText="Location"><ItemTemplate><asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'> </asp:Label></ItemTemplate><ItemStyle VerticalAlign="Top" /></asp:TemplateField></Columns>
                    <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" />
                            </asp:GridView></td></tr><tr><td align="right" class="fontcss" valign="top"></td></tr></table>      
                                </ContentTemplate>
                                </cc1:TabPanel>
               
               
<cc1:TabPanel  runat="server" ID="TabPanel2" HeaderText="New Items" >
    <HeaderTemplate>
                                New Items</HeaderTemplate>
    <ContentTemplate><table cellpadding="0" cellspacing="0" 
            style="height: 67px; width: 47%;" ><tr>
            <td align="right" class="style25" 
                style="text-align: left" valign="middle">Category</td><td align="right" class="style34" style="text-align: left" valign="middle" 
                height="30"><asp:DropDownList ID="DDLCategory" runat="server" CssClass="box3"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="DDLCategory" ErrorMessage="*" ValidationGroup="assub" 
                    InitialValue="Select Category"></asp:RequiredFieldValidator></td></tr><tr valign="middle">
            <td 
            align="right" class="style25" style="text-align: left" 
            valign="middle"  >Part No</td><td class="style42" align="right" 
                style="text-align: left" valign="middle" height="30"><asp:Label ID="lblWo" runat="server"></asp:Label><asp:TextBox ID="txtPartNo" runat="server" CssClass="box3" 
                    onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    Width="160px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPartNo" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator>
                <asp:TextBox ID="TxtCounter" runat="server" BorderWidth="0px" ReadOnly="True" 
                    Width="20px"></asp:TextBox>
            </td></tr><tr>
            <td align="right" class="style26" style="text-align: left" valign="middle">Revision </td><td align="right" class="fontcss" style="text-align: left" valign="middle" 
                height="30"><asp:CheckBox ID="CKRevision" runat="server" AutoPostBack="True" /></td></tr><tr>
            <td align="right" class="style26" style="text-align: left" valign="top">Manf Desc</td><td align="right" class="fontcss" style="text-align: left" valign="middle"><asp:TextBox ID="txtManfDescription" runat="server" CssClass="box3" 
                    Height="58px" TextMode="MultiLine" Width="320px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtManfDescription" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator></td></tr><tr>
            <td align="right" class="style26" style="text-align: left" valign="top">Purchase Desc</td><td align="right" class="fontcss" style="text-align: left" valign="middle">
            <asp:TextBox ID="txtPurchDescription" runat="server" CssClass="box3" 
                    Height="58px" TextMode="MultiLine" Width="320px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtPurchDescription" ErrorMessage="*" 
                    ValidationGroup="assub"></asp:RequiredFieldValidator></td></tr><tr>
            <td align="right" class="style26" style="text-align: left" valign="middle">Unit Purchase</td><td align="right" class="style22" style="text-align: left" valign="middle"><asp:DropDownList ID="DDLUnitBasic" runat="server" CssClass="box3"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="DDLUnitBasic" ErrorMessage="*" 
                ValidationGroup="assub" InitialValue="Select"></asp:RequiredFieldValidator></td></tr><tr>
            <td align="right" class="style27" style="text-align: left" valign="middle">Unit Basic</td><td align="right" class="style24" style="text-align: left" valign="bottom"><asp:DropDownList ID="DDLUnitPurchase" runat="server" CssClass="box3"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="DDLUnitPurchase" ErrorMessage="*" 
                ValidationGroup="assub" InitialValue="Select"></asp:RequiredFieldValidator></td></tr><tr>
            <td align="right" class="style28" style="text-align: left" valign="middle">Required Qty</td><td align="right" class="style23" style="text-align: left" valign="middle"><asp:TextBox ID="txtQuntity" runat="server" CssClass="box3" 
                    onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" Width="50px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtQuntity" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegQty" runat="server" 
                ControlToValidate="txtQuntity" ErrorMessage="*" 
                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="assub"></asp:RegularExpressionValidator>
            </td></tr><tr><td align="right" class="style35" style="text-align: left" valign="top"></td><td align="right" class="style36" style="text-align: left" valign="middle" 
                height="30">
                
                
                <asp:Button ID="btnSubmit" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                    OnClick="btnSubmit_Click" Text="Add" ValidationGroup="assub" />
                    <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    OnClick="Button1_Click1" Text="Cancel" /><asp:Label ID="lblMsg1" 
                    runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" style="font-weight: 700"></asp:Label></td></tr></table>

                                </ContentTemplate>
                             
</cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Copy From">
                                    <HeaderTemplate>
                                    Copy From</HeaderTemplate>
                                <ContentTemplate><table width="100%"><tr><td><iframe ID="frm2" frameborder="0" runat="server" height="415px" scrolling="auto" width="100%"></iframe></td></tr>
                                
                                <tr>
                                <td align="right">
                                <b>
<asp:Button ID="Button3" runat="server" CssClass="redbox" 
    onclick="btnCancel_Click" Text="Cancel" />
                        </b>
                                </td>
                                </tr>
                                
                                </table>
                                </ContentTemplate>   
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Selected Items">
                                    <ContentTemplate><table align="left" cellpadding="0" cellspacing="0"
                                            width="100%" class="fontcss"><tr><td  valign="top"><asp:GridView ID="GridView4" 
                                                runat="server" AllowPaging="True"  PageSize="12"
                                                        AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                                        OnRowCommand="GridView4_RowCommand" OnRowDeleting="GridView4_RowDeleting" 
                                                        Width="100%" onpageindexchanging="GridView4_PageIndexChanging"><Columns><asp:TemplateField HeaderText="SN">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex+1 %>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="btndelete" OnClientClick=" return confirmationDelete()" runat="server" CommandName="del" Text="Delete"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblic" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" /></asp:TemplateField><asp:TemplateField HeaderText="Manf Desc"><ItemTemplate><asp:Label ID="lblmanfdesc0" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="24%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMB" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Purch Desc"><ItemTemplate><asp:Label ID="lblpurchdesc0" runat="server" Text='<%#Eval("PurchDesc") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="24%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMP" runat="server" Text='<%#Eval("UOMPurchase") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Assly Qty"><ItemTemplate><asp:Label ID="lblasslyqty" runat="server" Text='<%#Eval("AsslyQty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="Req Qty"><ItemTemplate><asp:Label ID="lblreqqty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField><asp:TemplateField HeaderText="BOM Qty"><ItemTemplate><asp:Label ID="lblBOMQty" runat="server" Text='<%#Eval("BOMQty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField></Columns> 
                    <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate></asp:GridView></td></tr><tr><td align="right" height="25">
                          <asp:Button ID="btnproceed" runat="server" CssClass="redbox" OnClientClick=" return confirmationAdd()"  onclick="btnproceed_Click" Text="Add To TPL" />&nbsp;
                <asp:Button ID="btnCovBom" runat="server" CssClass="redbox" onclick="Button1_Click" OnClientClick=" return confirmationAdd()" Text="Add To TPL &amp; BOM" />&nbsp;<asp:Button ID="Button4" runat="server" CssClass="redbox" onclick="btnCancel_Click" Text="Cancel" />&nbsp;</td></tr></table>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                            </cc1:TabContainer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

