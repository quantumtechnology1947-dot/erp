<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_Schedule_Machine_Dashboard, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style5
        {
            height: 28px;
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
<table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)" colspan="2">
        &nbsp;<b>Machinary - Dashboard</b></td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
<table align="left" cellpadding="0" 
            cellspacing="0" width="100%" style="height: 162px"><tr><td class="style5" 
            height="25" valign="middle">&nbsp; <asp:DropDownList ID="DrpCategory" runat="server" AutoPostBack="True" 
                CssClass="box3" Height="21px" 
                OnSelectedIndexChanged="DrpCategory_SelectedIndexChanged"></asp:DropDownList>&nbsp;<asp:DropDownList 
                ID="DrpSubCategory" runat="server" AutoPostBack="True" 
                CssClass="box3" 
                OnSelectedIndexChanged="DrpSubCategory_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;<asp:DropDownList 
                ID="DrpSearchCode" runat="server" AutoPostBack="True" 
                CssClass="box3" 
                >
                <asp:ListItem Value="Select">Select</asp:ListItem>
                <asp:ListItem Value="tblDG_Item_Master.ItemCode">Machine Code</asp:ListItem>
                <asp:ListItem Value="tblDG_Item_Master.ManfDesc">Description</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:TextBox 
                ID="txtSearchItemCode" runat="server" CssClass="box3" Width="200px"></asp:TextBox>&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="redbox" 
                OnClick="btnSearch_Click" Text="Search" />
            </td></tr><tr><td class="style5" height="30" valign="middle">&nbsp;&nbsp;&nbsp;
            &nbsp;<asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCommand="GridView2_RowCommand" PageSize="20" Width="100%"><FooterStyle Font-Bold="False" /><Columns>
                    
                    <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="2%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Machine Code" >
                        <ItemTemplate>
                        
                                                       <asp:LinkButton ID="LinkButton1" CommandName="Sel" Text='<%# Bind("ItemCode") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                    </asp:TemplateField>
                                                
                    <asp:TemplateField HeaderText="Id" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
               
               <asp:TemplateField HeaderText="MachineId" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblMachineId" runat="server" Text='<%# Bind("MachineId") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Date" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblRegDate" runat="server" Text='<%# Bind("SysDate") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                        <ItemStyle VerticalAlign="Top" Width="4%" HorizontalAlign="Center" />
                    </asp:TemplateField>                  
                    <asp:BoundField DataField="ManfDesc" HeaderText="Description">
                <ItemStyle VerticalAlign="Top" Width="30%" /></asp:BoundField>
                    <asp:BoundField DataField="Make" HeaderText="Make" 
                            ><ItemStyle VerticalAlign="Top" Width="7%" /></asp:BoundField>                  
                    <asp:BoundField DataField="Model" HeaderText="Model" Visible="true">
                    <ItemStyle VerticalAlign="Top" HorizontalAlign="Center" Width="7%" /></asp:BoundField>
                <asp:BoundField DataField="Capacity" HeaderText="Capacity">
                    <ItemStyle HorizontalAlign="Right" Width="5%" />
                </asp:BoundField>
                    <asp:BoundField DataField="Location" HeaderText="Location">
                    <ItemStyle VerticalAlign="Top" Width="8%" /></asp:BoundField>
                    <asp:TemplateField HeaderText="Last PM Date" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblPMDate" runat="server" Text='<%# Bind("PMDate") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Remain Days" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblRemainDate" runat="server" Text='<%# Bind("RemainDay") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" HorizontalAlign="Right" Width="4%" />
                    </asp:TemplateField>
                </Columns><EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate><HeaderStyle Font-Size="9pt" />
                    </asp:GridView>
                    &nbsp;&nbsp;&nbsp; &nbsp;</td></tr><tr><td class="fontcss" valign="top">
            &nbsp;</td>
                    </tr>                    
                    </table>
    </td>    
    </tr>    
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

