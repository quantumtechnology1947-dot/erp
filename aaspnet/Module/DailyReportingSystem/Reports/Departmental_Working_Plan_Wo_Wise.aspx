<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Departmental_Working_Plan_Wo_Wise.aspx.cs" Inherits="Module_DailyReportingSystem_Reports_Departmental_Working_Plan_Wo_Wise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <center> <asp:label runat="server" text="DEPARTMENTAL WORKING PLAN " BackColor="#006699" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" Width="100%"></asp:label></center>
    <br />
    <br />
    <asp:dropdownlist runat="server" DataSourceID="SqlDataSource1" DataTextField="Description" ID="department" OnSelectedIndexChanged="department_SelectedIndexChanged" style="height: 22px"></asp:dropdownlist>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [Description] FROM [tblHR_Departments]"></asp:SqlDataSource>
    <asp:dropdownlist runat="server" ID="D_cat">
        <asp:ListItem>WoNo</asp:ListItem>
        <asp:ListItem>Name</asp:ListItem>
        <asp:ListItem Value="Date"></asp:ListItem>
    </asp:dropdownlist>
    <asp:textbox runat="server"></asp:textbox>
    <asp:Button ID="TxtSearchValue" runat="server" BackColor="#3EB1FF" OnClick="Search_Click" Text="Search" />
    <br />
    <br />
    <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False"
                    DataKeyNames="IdWo,E_name,IdDate" RowStyle-HorizontalAlign ="Center"
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    CssClass="yui-datatable-theme" PageSize="16" DataSourceID="SqlDataSource2" EnableModelValidation="True">
                    <HeaderStyle BackColor="#999999" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerSettings PageButtonCount="40" />
<RowStyle HorizontalAlign="Center"></RowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="SrNo"><ItemTemplate> <%# Container.DataItemIndex+1 %> </ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle></asp:TemplateField>
                        <asp:BoundField DataField="Department" HeaderText="Department" ApplyFormatInEditMode="True" SortExpression="Department" >
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdWo" HeaderText="IdWo" SortExpression="IdWo" />
                         <asp:BoundField DataField="IDperc" HeaderText="IDperc" SortExpression="IDperc" >
                            </asp:BoundField>
                        
                        
                        <asp:BoundField DataField="IdStatus" HeaderText="IdStatus" SortExpression="IdStatus" />
                        <asp:BoundField DataField="IdActivity" HeaderText="IdActivity" SortExpression="IdActivity" >
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="Idrmk" HeaderText="Idrmk" SortExpression="Idrmk" />
                        <asp:BoundField DataField="IdDate" HeaderText="IdDate" SortExpression="IdDate" />
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [Department], [IdWo], [IDperc], [IdStatus], [IdActivity], [E_name], [IdDate], [Idrmk] FROM [DRT_Sys_New]"></asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

