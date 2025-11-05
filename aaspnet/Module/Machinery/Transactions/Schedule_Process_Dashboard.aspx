<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Machinery_Transactions_Schedule_Process_Dashboard, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    
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
            cellspacing="0" width="100%" ><tr>
        <td 
            valign="middle" align="center" height="25">&nbsp;&nbsp;<b>Machine Name :</b> <asp:Label ID="lblMachine" runat="server" 
            style="font-weight: 700"></asp:Label>
        </td></tr><tr><td  
            valign="top" align="center">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" CssClass="yui-datatable-theme" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                    OnRowCommand="GridView2_RowCommand" PageSize="15" Width="40%"><FooterStyle Font-Bold="False" /><Columns>
                    
                    <asp:TemplateField HeaderText="SN">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Right" Width="1%" />
                                                </asp:TemplateField>
                                                
                    <asp:TemplateField HeaderText="Id" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField>
               
               <asp:TemplateField HeaderText="Machine Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblMachineId" runat="server" Text='<%# Bind("MachineId") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" />
                    </asp:TemplateField> 
                    
                    
                                                <asp:TemplateField HeaderText="Process" >
                        <ItemTemplate>
                        
                                                       <asp:LinkButton ID="LinkButton1" CommandName="Sel" Text='<%# Bind("Process") %>' runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left" Width="7%" />
                    </asp:TemplateField>
                                                
                    <%--<asp:TemplateField HeaderText="Shift" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblShift" runat="server" Text='<%# Bind("Shift") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                        <ItemStyle VerticalAlign="Top" Width="4%" HorizontalAlign="Center" />
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Batch No" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblBatchNo" runat="server" Text='<%# Bind("BatchNo") %>'></asp:Label>
                        </ItemTemplate>                                                                       
                         <ItemStyle VerticalAlign="Top" Width="5%" HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    
                    
                </Columns><EmptyDataTemplate>
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
                    </td></tr><tr>
        <td class="fontcss" 
            valign="bottom" align="center" height="25">
            
            
            <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                onclick="btnCancel_Click" Text="Cancel" />
        </td>
                    </tr>                    
                    </table>
    </td>    
    </tr>    
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

