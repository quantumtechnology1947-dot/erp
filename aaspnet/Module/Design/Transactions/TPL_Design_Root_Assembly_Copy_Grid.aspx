<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Design_Transactions_TPL_Design_Assembly_Edit_Assbly, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
 <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" height="21" ><strong>&nbsp;TPL Root Assembly Copy&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WO No From: <asp:Label ID="lblWONoFrm" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;To: <asp:Label runat="server" ID="lblWONo"></asp:Label> </strong></td></tr>
             <tr>
            <td class="fontcsswhite" height="25" >
            
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" 
                    CssClass="box3">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="tblDG_Item_Master.ItemCode">Assembly No</asp:ListItem>
                    <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>
                   <%-- <asp:ListItem Value="tblDG_Item_Master.PurchDesc">Purchase Description</asp:ListItem>--%>
                </asp:DropDownList>
            
                <asp:TextBox ID="txtSearchCustomer" runat="server" Width="350px" 
                    CssClass="box3"></asp:TextBox>
                
        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="redbox" onclick="btnSearch_Click"/>&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" onclick="btnCancel_Click" Text="Cancel" />&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" style="color: #FF0000"></asp:Label>
             </td>
             </tr>

             <tr>
            <td>
            
             <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"            
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="700px" 
                    ShowFooter="True" PageSize="12" onrowcommand="SearchGridView1_RowCommand">
            <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="2%"  />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelect" AutoPostBack="False"></asp:CheckBox>
                         </ItemTemplate>
                        <FooterTemplate>
                         <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="Add"  OnClientClick=" return confirmationAdd()" 
                         CssClass="redbox"/>
                         </FooterTemplate>
                        <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server"  AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                        </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Assembly No">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("ItemCode") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="13%" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ManfDesc" HeaderText="Description" >
                            <ItemStyle Width="40%" />
                        </asp:BoundField>
                        
                        
                        <asp:BoundField DataField="UOMBasic" HeaderText="UOM" >
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="Qty" HeaderText="Qty" >
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:BoundField>
                        
                        
                        <asp:TemplateField HeaderText="Id" Visible="False">

                        <ItemTemplate>

                            <asp:Label ID="Id" runat="server" Text='<%# Bind("Id") %>' />

                        </ItemTemplate>

                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="CId" Visible="False">

                        <ItemTemplate>

                            <asp:Label ID="CId" runat="server" Text='<%# Bind("CId") %>' />

                        </ItemTemplate>

                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="ItemId" Visible="False">

                        <ItemTemplate>

            <asp:Label ID="ItemId" runat="server" Text='<%# Bind("ItemId") %>' />

        </ItemTemplate>

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
              <%-- <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"            
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    ShowFooter="True" PageSize="12" onrowcommand="SearchGridView1_RowCommand">
            <RowStyle />
            <Columns>
                        <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                        <HeaderTemplate>
                        <asp:CheckBox ID="chkSelectAll" runat="server"  AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelect" AutoPostBack="true"></asp:CheckBox>
                         </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        <FooterTemplate>
                         <asp:Button ID="btnAdd" runat="server" Text="Add" CommandName="Add"  OnClientClick=" return confirmationAdd()" 
                         CssClass="redbox"/>
                         </FooterTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ItemCode" HeaderText="Assembly No" >
                            <ItemStyle Width="14%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ManfDesc" HeaderText="Manf. Desc." >
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PurchDesc" HeaderText="Purch . Desc." >
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UOMBasic" HeaderText="UOM Basic" >
                            <ItemStyle HorizontalAlign="Center" Width="9%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UOMPurchase" HeaderText="UOM Purch." >
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Qty" HeaderText="Qty" >
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Weldments" HeaderText="Weld." >
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LH" HeaderText="LH" >
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RH" HeaderText="RH" >
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="Id" Visible="False">

                        <ItemTemplate>

                            <asp:Label ID="Id" runat="server" Text='<%# Bind("Id") %>' />

                        </ItemTemplate>

                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="CId" Visible="False">

                        <ItemTemplate>

                            <asp:Label ID="CId" runat="server" Text='<%# Bind("CId") %>' />

                        </ItemTemplate>

                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="ItemId" Visible="False">

                        <ItemTemplate>

            <asp:Label ID="ItemId" runat="server" Text='<%# Bind("ItemId") %>' />

        </ItemTemplate>

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
                    
        </asp:GridView>--%>

    <asp:HiddenField ID="hfSort" runat="server" Value=" " />
        <asp:HiddenField ID="hfSearchText" runat="server" />
        </td>
         </tr>
          </table>
        </td>
        </tr>
     </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

