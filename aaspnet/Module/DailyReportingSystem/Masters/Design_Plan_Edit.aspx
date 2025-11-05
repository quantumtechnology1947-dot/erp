<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Design_Plan_Edit.aspx.cs" Inherits="Module_DailyReportingSystem_Masters_Design_Plan_Edit" %>

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
    <div>
       <p align=center> 
           <asp:Label ID="Label1" runat="server" Text="DESIGN PLAN" BackColor="#006699" 
            BorderStyle="Ridge" ForeColor="White" Width="100%" Font-Bold="True" Font-Size="Large"></asp:Label></p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="W/O NO.:"></asp:Label>
        <asp:TextBox ID="idwono" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" Width="100%" BorderStyle="Double"  Height="103px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" BackColor="#999999">SR.NO.</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">FIXTURE NO.</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">CONCEPT DESIGN</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">INTERNAL REVIEW</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">DAP SEND</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">DAP RECD.</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">CORRECTION</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#999999">FINAL DAP</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idsr" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idfxn" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idconcpd" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idintrnrw" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="iddaps" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="iddapr" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idcrr" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idfdap" runat="server"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
    </div>
    
        <center>
            <br />
            <asp:Table ID="Table3" runat="server" Width="100%">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BackColor="#999999" RowSpan="2">BOUGHT LIST</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999" ColumnSpan="3" RowSpan="1">DRAWING RELEASE</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999" RowSpan="2">CNC DATA</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999" RowSpan="2">CMM DATA</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999" RowSpan="2">FIT LIST</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999" RowSpan="2">MANUAL</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" BackColor="#999999">DETAILING</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999">TPL ENTRY</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#999999">FLAME CUT</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server"><asp:TextBox ID="idboulst" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="iddrwrls" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="idcncd" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="idcmmdt" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="idftlst" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="idmnl" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="iddtal" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell runat="server"><asp:TextBox ID="idtpletr" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Button ID="submit" runat="server"  Text="Update" BackColor="#FF3300" OnClick="submit_Click" />
            <br />
    </center>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

