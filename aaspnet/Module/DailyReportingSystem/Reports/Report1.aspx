<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report1.aspx.cs" Inherits="Module_DailyReportingSystem_Reports_Report1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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
            <cc1:calendarextender ID="TxtFromDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtFromDate">
            </cc1:calendarextender>
                        <asp:RequiredFieldValidator ID="ReqFromDt" runat="server" ControlToValidate="TxtFromDate" 
                            ErrorMessage="*" ValidationGroup="a"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TxtFromDate" ErrorMessage="*" 
                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                            ValidationGroup="a"></asp:RegularExpressionValidator>
                        &nbsp;-&nbsp;
                        <b>To</b>
            <asp:TextBox ID="TxtToDate" runat="server" CssClass="box3" Width="100px"></asp:TextBox>
            <cc1:calendarextender ID="TxtToDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtToDate">
            </cc1:calendarextender>
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
                       
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmployeeName" >
                        </asp:DropDownList> 
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [EmployeeName] FROM [tblHR_OfficeStaff]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" DataTextField="Type">
                        </asp:DropDownList> 
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [Type] FROM [tblHR_Designation]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource4" DataTextField="Description">
                        </asp:DropDownList> 
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:D:\INETPUB\WWWROOT\NEWERP\APP_DATA\ERP_DB.MDFConnectionString %>" SelectCommand="SELECT [Description] FROM [tblHR_Departments]"></asp:SqlDataSource>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:Button ID="search" runat="server" Text="SEARCH" BackColor="#62C0FF" ForeColor="White" OnClick="search_Click"/>          
                        <br />
                        
                        <br />
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EnableModelValidation="True">
                        </asp:GridView>
   
    </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

