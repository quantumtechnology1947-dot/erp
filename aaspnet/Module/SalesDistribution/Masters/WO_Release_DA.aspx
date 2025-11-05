<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Masters_WO_Release_DA, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    </style>
    <link type="text/css" href="../../../Css/yui-datatable.css" rel="stylesheet" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="21" style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<strong>Work Order Release & Dispatch Authority</strong></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="440px" ScrollBars="Auto">
                    <asp:GridView ID="GridView2" runat="server"  ShowFooter="False"
                    AutoGenerateColumns="False" PageSize="1" CssClass="yui-datatable-theme" 
                    onpageindexchanging="GridView2_PageIndexChanging" 
    Width="55%" >
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle 
                                HorizontalAlign="Right" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name of Employee">
                                <ItemTemplate>
                                    <asp:Label ID="empname" Text='<%#Eval("EmpName") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="45%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Emp. No">
                                <ItemTemplate>
                                    <asp:Label ID="empno" runat="server" Text='<%#Eval("EmpNo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department">
                                <ItemTemplate>
                                    <asp:Label ID="dept" Text='<%#Eval("Dept") %>' runat="server"> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Release">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkrelease" runat="server"/>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                               
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dispatch">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkdispatch"   runat="server"  />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table width="100%" class="fontcss">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" height="27">
               <asp:Button Text="Submit" runat="server" ID="btnsubmit" 
                                        CssClass="redbox" onclick="btnsubmit_Click" /></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

