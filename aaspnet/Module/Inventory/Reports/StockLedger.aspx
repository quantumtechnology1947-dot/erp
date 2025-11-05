<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Inventory_Transactions_StockLedger, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
  <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            width: 926px;
        }
       
        .style7
        {
            width: 100%;
            float: left;
        }
        .box3
        {
            width: 406px;
        }
               
        .style11
        {
            color: white;
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

    <table width="100%" cellpadding="0" cellspacing="0">
               
        
        <tr>
                    <td align="left" valign="middle" 
                 style="background:url(../../../images/hdbg.JPG)" height="21" class="style3"><b>&nbsp;<span 
                    class="style11">Stock Ledger</span></b>
                        </td>
                </tr>
        
        <tr>
        <td align="center" >
            <table align="left" cellpadding="0" cellspacing="0" class="style7">
                <tr>
                    <td align="left" height="26" width="120px">
                        &nbsp;<b>&nbsp; Financial Year</b></td>
                    <td align="left">
                        From Date:<asp:Label ID="lblFromDate" runat="server"></asp:Label>
                        &nbsp; To:<asp:Label ID="lblToDate" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <b>&nbsp;&nbsp; From Date</b></td>
                    <td align="left" height="26">
            <asp:TextBox ID="TxtFromDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtFromDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqFromDt" runat="server" ControlToValidate="TxtFromDate" 
                            ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TxtFromDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp;
                        <b>To</b>
            <asp:TextBox ID="TxtToDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:CalendarExtender ID="TxtToDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate">
            </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="ReqCate2" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TxtToDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#CC3300"></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" height="26">
                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" Height="21px" Width="100px" ID="DrpType" OnSelectedIndexChanged="DrpType_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem Value="Category">Category</asp:ListItem>
                            <asp:ListItem Value="WOItems">WO Items</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" CssClass="box3" Height="21px" AutoPostBack="true"  Width="200px" ID="DrpCategory1" 
                            OnSelectedIndexChanged="DrpCategory1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" 
                            Width="200px" ID="DrpSearchCode" 
                            OnSelectedIndexChanged="DrpSearchCode_SelectedIndexChanged">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem Value="tblDG_Item_Master.ItemCode">Item Code</asp:ListItem>
                            <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>
                            <asp:ListItem Value="tblDG_Item_Master.Location">Location</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" 
                            Width="155px" ID="DropDownList3" style="margin-bottom: 0px">
                        </asp:DropDownList>
                        <asp:TextBox runat="server" CssClass="box3" Width="207px" 
                            ID="txtSearchItemCode"></asp:TextBox>
            &nbsp;<asp:Button ID="Btnsearch" runat="server" CssClass="redbox" 
                onclick="Btnsearch_Click" Text="Search" />
                    </td>
                </tr>
            </table>
            </td>
        </tr> 
        <tr>
        <td>
            <table align="center" cellpadding="0" cellspacing="0" class="style7">
                <tr>
                    <td align="left">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="False"  
                OnPageIndexChanging="GridView1_PageIndexChanging" Width="95%"
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" 
                onrowcommand="GridView1_RowCommand" PageSize="20" >
      
                 <PagerSettings PageButtonCount="40" />
      
                 <Columns>
                  <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center"><ItemTemplate> <%# Container.DataItemIndex + 1%> </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                        </asp:TemplateField>
                  <asp:TemplateField >
                        <ItemTemplate>
                        <asp:LinkButton ID="btnselect" ValidationGroup="a" Text="Select" CommandName="Sel" runat="server" />
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                  <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                            
                            
                              <asp:TemplateField HeaderText="Image" >
                        <ItemTemplate>
                       
                            <asp:LinkButton ID="btnlnkImg" CommandName="downloadImg" Visible="true"  Text='<%# Bind("FileName") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Spec. Sheet" >
                        <ItemTemplate>
                         <asp:LinkButton ID="btnlnkSpec" CommandName="downloadSpec" Visible="true"  Text='<%# Bind("AttName") %>'  runat="server"></asp:LinkButton>
                         
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center"  Width="10%"/>
                        </asp:TemplateField>    
                            
                            
                                 
                  <asp:TemplateField HeaderText="Item Code">
                        <ItemTemplate>
                        <asp:Label ID="itemcode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                        <asp:Label ID="manfdesc" runat="server" Text='<%# Eval("ManfDesc") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="50%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                        <ItemTemplate>
                        <asp:Label ID="uomBasic" runat="server" Text='<%# Eval("UOMBasic") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Stock Qty">
                        <ItemTemplate>
                        <asp:Label ID="stockQty" runat="server" Text='<%# Eval("StockQty") %>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
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
                    </td>
                </tr>
            </table>
            </td>
        </tr>
      
        
                       
      
        
    </table>



</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

