<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_BOM_Design_Assembly_New, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    
    <style type="text/css">
        .style2
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
    <table align="left" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>&nbsp;BOM Assembly - New</b></td>
        </tr>
        <tr>
            <td>
            
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
                                                        onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                    onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                    onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }"
                                                        Width="50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" 
                                                    runat="server" 
                                                        ControlToValidate="txtUnitNo" ErrorMessage="*" ValidationGroup="assub">
                                                        </asp:RequiredFieldValidator>                             </FooterTemplate>
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
                                                        onblur="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                        onfocus="javascript:if(isNaN(this.value)==true){ this.value=''; }" 
                                                        onkeyup="javascript:if(isNaN(this.value)==true){ this.value=''; }"
                                                        Width="50px">
                                                         </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                                                        
                                                        runat="server" 
                                                        ControlToValidate="txtPartNo" ErrorMessage="*" ValidationGroup="assub"> 
                                                        </asp:RequiredFieldValidator>
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

