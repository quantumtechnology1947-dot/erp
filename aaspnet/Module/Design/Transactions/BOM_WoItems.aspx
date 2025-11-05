<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BOM_WoItems.aspx.cs" Inherits="Module_Design_Transactions_BOM_WoItems" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="center" valign="top">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;BOM Items&nbsp;&nbsp;WoNo:&nbsp;<asp:Label ID="lblwono" Font-Bold="true"  runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;Assly No:&nbsp;<asp:Label ID="lblasslyno" runat="server"></asp:Label></b>
                    </td>
                    </tr>
                    <tr>
                        <td valign="top">
                                                    
                            <cc1:TabContainer ID="TabContainer1" runat="server"  
                                AutoPostBack="True" 
                                onactivetabchanged="TabContainer1_ActiveTabChanged" ActiveTabIndex="0" 
                                Width="100%">
                                   
                                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Item Master">                               
                                    <HeaderTemplate>
Item Master
                                </HeaderTemplate>
                                    
<ContentTemplate>
<asp:Panel ID="Panel2" ScrollBars="Auto" Height="405px" runat="server"><table width ="100%" cellpadding="0" cellspacing="0"><tr><td class="fontcsswhite" height="25" valign="middle" >&#160;&nbsp;<asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="Category">Category</asp:ListItem><asp:ListItem Value="WOItems">WO Items</asp:ListItem>
    </asp:DropDownList><asp:RequiredFieldValidator ID="ReqSelect" runat="server" ValidationGroup="sel"  ControlToValidate="DrpType" InitialValue="Select" ErrorMessage="*"></asp:RequiredFieldValidator><asp:DropDownList ID="DrpCategory1" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory1_SelectedIndexChanged" Height="21px" 
                    CssClass="box3"></asp:DropDownList><asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem><asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem>
    </asp:DropDownList><asp:DropDownList ID="DropDownList3" runat="server" 
                                style="margin-bottom: 0px" Width="155px" 
                    onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                    AutoPostBack="True" CssClass="box3"></asp:DropDownList><asp:TextBox ID="txtSearchItemCode" runat="server"  Visible="False" Width="207px" 
                    CssClass="box3"></asp:TextBox>&#160;<asp:Button ID="btnSearch" runat="server" ValidationGroup="sel" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  /></td></tr><tr><td class="style2" 
                                                valign="top"><asp:GridView ID="GridView2" runat="server" PageSize="14" AllowPaging="True" 
                                                        AutoGenerateColumns="False" DataKeyNames="Id" CssClass="yui-datatable-theme" 
                                                        OnPageIndexChanging="GridView2_PageIndexChanging" 
                                                        OnRowCommand="GridView2_RowCommand" Width="100%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                                    
                </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle>
</asp:TemplateField><asp:TemplateField HeaderText="Req Qty"><ItemTemplate><asp:TextBox ID="txtQty" runat="server" CssClass="box3" 
                                                                        onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                                        onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                                        onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                                        Width="90%" /><asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                                        ControlToValidate="txtQty" ErrorMessage="*" 
                                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="as">  </asp:RegularExpressionValidator>
                </ItemTemplate><ItemStyle VerticalAlign="Top" Width="8%" />
</asp:TemplateField><asp:TemplateField><ItemTemplate><asp:Button ID="btnadd" CommandName="Add" CssClass="redbox" ValidationGroup="as" runat="server" 
                                                Text="Add">
                                                        </asp:Button>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" 
                                                            VerticalAlign="Top" Width="5%" />
</asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                </ItemTemplate><ItemStyle VerticalAlign="Top" />
</asp:TemplateField><asp:BoundField DataField="Category" HeaderText="Category" Visible="False"><ItemStyle VerticalAlign="Top" />
</asp:BoundField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblitemcode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:Label>
                </ItemTemplate><ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="10%" />
</asp:TemplateField><asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblManfDesc" runat="server" Text='<%#Eval("ManfDesc") %>'> </asp:Label>
                </ItemTemplate><ItemStyle VerticalAlign="Top" Width="28%" />
</asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMBasic" runat="server" Text='<%#Eval("UOMBasic") %>'> </asp:Label>
                </ItemTemplate><ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="5%" />
</asp:TemplateField><asp:TemplateField HeaderText="Location"><ItemTemplate><asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'> </asp:Label>
                </ItemTemplate><ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="8%" />
</asp:TemplateField>
            </Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                                                
            </EmptyDataTemplate><FooterStyle Font-Bold="False" /><HeaderStyle Font-Size="9pt" /><PagerSettings PageButtonCount="40" />
        </asp:GridView></td></tr></table></asp:Panel>   
                                
                                </ContentTemplate>
                                
                                
</cc1:TabPanel>                                
               
                                <cc1:TabPanel  runat="server" ID="TabPanel2" HeaderText="New Items" >
    <HeaderTemplate> 
 New Items
                                </HeaderTemplate>
    
<ContentTemplate>
<asp:Panel ID="Panel3" ScrollBars="Auto" Height="405px" runat="server">
   
    
    
        <table cellpadding="0" cellspacing="0" width="80%" >
        <tr ><td align="right"  style="text-align: left" valign="middle" >
        Equipment No :&nbsp;</td>
        <td align="left" height="25"><asp:Label ID="lblEquipNo" runat="server"></asp:Label></td>
        
        </tr><tr><td align="right"  style="text-align: left;" valign="middle">Unit No</td><td align="left" height="25"><asp:TextBox ID="txtUnitNo" runat="server" CssClass="box3" MaxLength="2" 
                    onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" Width="50px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqUnitNo" runat="server" 
                    ControlToValidate="txtUnitNo" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator></td></tr><tr><td align="right" class="style12" style="text-align: left" valign="middle">Part No </td><td align="left" height="25"><asp:TextBox ID="txtPartNo" runat="server" CssClass="box3" 
                    onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    Width="50px" MaxLength="2"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtPartNo" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator></td></tr><tr><td align="right" class="style13" style="text-align: left" valign="top">Description </td><td align="left">
            <asp:TextBox ID="txtManfDescription" runat="server" CssClass="box3" 
                    Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtManfDescription" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator></td>
                    
                    <td>
                
                
                
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                            CssClass="yui-datatable-theme" DataKeyNames="Id" 
                            onrowcommand="GridView1_RowCommand" PageSize="15" ShowFooter="True" 
                            Width="100%">
                            <PagerSettings PageButtonCount="40" />
                            <Columns>
                                <asp:TemplateField HeaderText="SN" SortExpression="Id">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                            OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId55" runat="server" Text='<%#Eval("Id") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Types") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Left" Width="65%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Width="95%">
                                        </asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="28%" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table class="fontcss" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Names="Calibri" 
                                                ForeColor="red" Text="No  data found to display"> </asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <FooterStyle Wrap="True" />
                        </asp:GridView>
                
                
                
                </td>
                
                
                </tr><tr><td align="right" class="style23" style="text-align: left" valign="middle">UOM</td><td align="left" height="25"><asp:DropDownList ID="DDLUnitBasic" runat="server" CssClass="box3"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="DDLUnitBasic" ErrorMessage="*" 
                ValidationGroup="assub" InitialValue="Select"></asp:RequiredFieldValidator></td>
                <td>
                Material : 
                <asp:TextBox runat="server" ID="txtmat"></asp:TextBox>
                
                </td>
                
                
                </tr><tr><td align="right" class="style12" style="text-align: left" valign="middle">Required Qty </td><td align="left" class="25" height="25" valign="bottom"><asp:TextBox ID="txtQuntity" runat="server" CssClass="box3" 
                    onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                    onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }" Width="50px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtQuntity" ErrorMessage="*" ValidationGroup="assub"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegQty0" runat="server" 
                    ControlToValidate="txtQuntity" ErrorMessage="*" 
                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="assub"></asp:RegularExpressionValidator></td></tr><tr><td align="right" class="style12" style="text-align: left" valign="middle">Image</td><td align="left" class="25" height="25" valign="bottom"><asp:FileUpload ID="FileUpload1" runat="server" /></td></tr><tr><td align="right" class="style12" style="text-align: left" valign="middle">Spec. Sheet </td><td align="left" class="25" height="25" valign="bottom"><asp:FileUpload ID="FileUpload2" runat="server" /></td></tr><tr><td align="right" class="style4" style="text-align: left" valign="top">&#160;</td><td align="left" height="25" valign="bottom">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="redbox"  OnClientClick=" return confirmationAdd()" 
                    OnClick="btnSubmit_Click" Text="Add" ValidationGroup="assub" />&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
                    OnClick="Button1_Click1" Text="Cancel" /></td></tr><tr><td align="right" class="style4" style="text-align: left" valign="top">&#160;</td><td align="left" class="style3"><asp:Label ID="lblMsg1" runat="server"></asp:Label><asp:Label ID="lblMsg" runat="server"></asp:Label></td></tr></table>
         
      
         
         </asp:Panel>
   
                                
   
                                
                                </ContentTemplate> 
                             

</cc1:TabPanel>                     
                               
                                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Copy From">
                                    <HeaderTemplate>
                                    Copy From
                                </HeaderTemplate>
                                
<ContentTemplate>
<table width="100%"><tr><td><iframe ID="frm2" frameborder="0" runat="server" height="405px" scrolling="auto" 
                                        width="100%"></iframe></td></tr></table>
                                
                                
                                </ContentTemplate>   
                                
</cc1:TabPanel>
                                
                                <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Selected Items">
                                    <HeaderTemplate>
                                    Selected Items
                                </HeaderTemplate>
                                    
<ContentTemplate>
<asp:Panel ID="Panel1" ScrollBars="Auto"  height="405px" runat="server"><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td height="300" valign="top"><asp:GridView ID="GridView3" runat="server" AllowPaging="True"
                                                            AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                                                            DataKeyNames="Id" OnRowCommand="GridView3_RowCommand" 
                                                           PageSize="30" Width="100%" 
                                                        
                                                        onpageindexchanging="GridView3_PageIndexChanging"                                                    ><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %>
                                                        
                                            </ItemTemplate><ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle></asp:TemplateField><asp:TemplateField><ItemTemplate><asp:LinkButton ID="btndelete" runat="server" CommandName="del" Text="Delete"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblid" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblic" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblmanfdesc0" runat="server" Text='<%#Eval("ManfDesc") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="30%" /></asp:TemplateField><asp:TemplateField HeaderText="UOM"><ItemTemplate><asp:Label ID="lblUOMB" runat="server" Text='<%#Eval("UOMBasic") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField HeaderText="Assly Qty"><ItemTemplate><asp:Label ID="lblasslyqty" runat="server" Text='<%#Eval("AsslyQty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="Req Qty"><ItemTemplate><asp:Label ID="lblreqqty" runat="server" Text='<%#Eval("Qty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField><asp:TemplateField HeaderText="BOM Qty"><ItemTemplate><asp:Label ID="lblBOMQty" runat="server" Text='<%#Eval("BOMQty") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="7%" /></asp:TemplateField>
                                            
                               <asp:TemplateField HeaderText="Item Id" Visible="false"><ItemTemplate><asp:Label ID="lblItemId" runat="server" Text='<%#Eval("ItemId") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%" /></asp:TemplateField>             
                                            
                                            
                                            
                                            </Columns><EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                                        </EmptyDataTemplate></asp:GridView></td></tr></table></asp:Panel>
                                    
                                    
                                </ContentTemplate>
                                
</cc1:TabPanel>
                                
                            </cc1:TabContainer>
                             
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" height="25" align="center">
                            <asp:Button runat="server" OnClientClick=" return confirmationAdd()" Text="Add to BOM" CssClass="redbox" ID="btnaddtobom" OnClick="btnaddtobom_Click">
                            </asp:Button>&nbsp;
                            <asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="Button2" OnClick="btnCancel_Click">
                            </asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

