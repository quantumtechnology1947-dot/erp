<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Manufacturing_Plan.aspx.cs" Inherits="Module_Daily_Reporting_System_Masters_Manufacturing_Plan" %>

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
        <center><asp:Label ID="Label1" runat="server" Text="MANUFACTURING PLAN" BackColor="#006699" BorderStyle="Ridge" Font-Bold="True" ForeColor="White" Width="100%" Font-Size="Large"></asp:Label></center>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="W/O NO." BackColor="#CCCCCC" Height="25px"></asp:Label>
        <asp:TextBox ID="idwono" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" Width="100%">
            <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#CCCCCC">
                <asp:TableCell runat="server" RowSpan="2">FIXTURE NO.</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2">ITEM NO</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2">DESCRIPTION</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2">QTY</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="3" RowSpan="1" BackColor="#999999" HorizontalAlign="Center" VerticalAlign="Middle">DRAWING RELEASE</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BackColor="#999999" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server" BackColor="#CCCCCC">DETAILING</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#CCCCCC">TPL ENTRY</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#CCCCCC">FLAME CUT</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                <asp:TableCell runat="server"><asp:TextBox ID="idfxn" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="iditn" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="iddes" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idqty" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="iddet" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idtple" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server"><asp:TextBox ID="idflc" runat="server"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
        </asp:Table><br/>
        <center>
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" Width="100%" HorizontalAlign="Center">
                <asp:TableRow runat="server"  HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#CCCCCC">
                    <asp:TableCell runat="server" ColumnSpan="2" RowSpan="1" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#999999">CUTTING</asp:TableCell>
                    <asp:TableCell runat="server" ColumnSpan="2" RowSpan="1" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#999999">RAW MATERIAL</asp:TableCell>
                    <asp:TableCell runat="server" RowSpan="2">FABRICATION</asp:TableCell>
                    <asp:TableCell runat="server" RowSpan="2">SR</asp:TableCell>
                    <asp:TableCell runat="server" RowSpan="2">M/C ING</asp:TableCell>
                    <asp:TableCell runat="server" RowSpan="2">TAPPING</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" BackColor="#999999" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TableCell runat="server" BackColor="#CCCCCC">FLAME CUT</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#CCCCCC">CHANNLEL</asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#CCCCCC">LIST </asp:TableCell>
                    <asp:TableCell runat="server" BackColor="#CCCCCC">RECEIVE</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idfab" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="ids" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idmcing" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idtap" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idfc" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idchn" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idlist" runat="server"></asp:TextBox>
</asp:TableCell>
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idrec" runat="server"></asp:TextBox>
</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="Table3" runat="server" HorizontalAlign="Left" Height="55px">
                <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#CCCCCC">
                    <asp:TableCell runat="server">PAINTING</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TableCell runat="server">
                        <asp:TextBox ID="idpai" runat="server"></asp:TextBox>
</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <br />
            <br />
            <asp:Button ID="submit" runat="server" Text="Submit" BackColor="Red" OnClick="submit_Click" /></center>
    </div>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

