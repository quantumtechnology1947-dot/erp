<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VENDOR_PLAN.aspx.cs" Inherits="Module_Daily_Reporting_System_Masters_VENDOR_PLAN" %>

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
    
    </div>
       <center> <asp:Label ID="Label1" runat="server" BackColor="#006699" Font-Bold="True" ForeColor="White"  Width="100%" BorderStyle="Ridge" Font-Size="Large" Height="26px">VENDOR PLAN</asp:Label></center>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="W/o No." Font-Size="Medium" 
        Height="25px"></asp:Label>
        <asp:TextBox ID="idwono" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
    <center>
        <asp:Table ID="Table1" runat="server" Width="100%" Font-Size="Medium" Height="25px" HorizontalAlign="Center" ForeColor="White" BackColor="White">
            <asp:TableRow runat="server" BackColor="White" ForeColor="Black">
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">Sr.No.</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">Fixture No.</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">No of Parts for Manufacturing</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">Planning</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">FlameCut Loading</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">Premach-Ineing</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">Weldment Fabrication</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                    <asp:TextBox ID="idsr" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"> <asp:TextBox ID="idfxn" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"> <asp:TextBox ID="idnpm" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"> <asp:TextBox ID="idpln" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"> <asp:TextBox ID="idfcl" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"> <asp:TextBox ID="idpri" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"> <asp:TextBox ID="idwef" runat="server"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <br />
        <asp:Table ID="Table2" runat="server" Width="100%" HorizontalAlign="Center" Font-Size="Medium" Height="25px" ForeColor="White">
            <asp:TableRow runat="server" BackColor="White" ForeColor="Black">
                <asp:TableCell runat="server">Weldment Loading</asp:TableCell>
                <asp:TableCell runat="server">No of Parts Receved</asp:TableCell>
                <asp:TableCell runat="server">No of Accepted Parts</asp:TableCell>
                <asp:TableCell runat="server">Pending MFG Parts</asp:TableCell>
                <asp:TableCell runat="server">Broghout Parts</asp:TableCell>
                <asp:TableCell runat="server">Pending BO Parts</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idwl" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idnpr" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idnap" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idpmp" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idbpt" runat="server"></asp:TextBox>
</asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="idpbp" runat="server"></asp:TextBox>
</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
       <center> 
           <br />
           <br />
           <asp:Table ID="Table3" runat="server" HorizontalAlign="Left" Font-Size="Medium" ForeColor="White" Height="25px" Width="528px">
               <asp:TableRow runat="server" ForeColor="Black" HorizontalAlign="Center" 
                   VerticalAlign="Middle">
                   <asp:TableCell runat="server" BackColor="White" ForeColor="Black">No of Pending Challan</asp:TableCell>
                   <asp:TableCell runat="server">No of Parts Receved after Processing</asp:TableCell>
               </asp:TableRow>
               <asp:TableRow runat="server" BackColor="White" ForeColor="Black" 
                   HorizontalAlign="Center" VerticalAlign="Middle">
                   <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox ID="idnpc" runat="server"></asp:TextBox>
</asp:TableCell>
                   <asp:TableCell runat="server" HorizontalAlign="Center" VerticalAlign="Middle"><asp:TextBox ID="idnprap" runat="server"></asp:TextBox>
</asp:TableCell>
               </asp:TableRow>
           </asp:Table>
           <br />
           <br />
           <br />
           <br />
           <br />
           <asp:Button ID="submit" runat="server" BackColor="#FF3300" Height="28px" 
               Text="SUBMIT" Width="80px" OnClick="submit_Click" BorderStyle="Ridge" 
               ForeColor="White"/></center>
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

