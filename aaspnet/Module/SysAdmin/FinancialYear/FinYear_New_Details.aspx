<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FinYear_New_Details.aspx.cs" Inherits="Module_SysAdmin_FinancialYear_FinYear_New_Details" Title="ERP" Theme ="Default"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

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
        <table align="center" cellpadding="0" cellspacing="0"  width="100%">
         <tr>
                    <td height="20" colspan="3" align="left" valign="center" class="fontcsswhite" style="background-image:url('../../../images/hdbg.jpg')">&nbsp;<b>Financial Year </b></td>
                   </tr>
                   <tr>
                   <td align="center">
                   <table width="70%">
                   <tr>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                        Text="New Financial Year" Font-Size="Large"></asp:Label>
                </td>
            </tr>  
                   <tr>
                <td align="center">
                    <b style="font-size: large">Name of Company: </b>
                    <asp:Label ID="lblcompNm" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="justify" style="text-align: center">
                    &nbsp;<asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                        Text="New Financial  Year :"></asp:Label>
                    <asp:Label ID="lblfyear" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblfrom" runat="server" style="font-weight: 700" 
                        Text="Date  From :"></asp:Label>
                    &nbsp;<asp:Label ID="lblFrmDt" runat="server"></asp:Label>
                    &nbsp;-
                    <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                        Text=" To :"></asp:Label>
                    &nbsp;<asp:Label ID="lblToDt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" >
                    <ul>
                        <li>Closing stock qty shifted to opening stock qty.</li>
                        <li>Users access shifted to next financial year.</li>
                        <li>Operations of all transactions of previous financial year will be closed.</li>
                        <li>Reseting the all transaction nos.</li>
                        <li>Partial transactions of previous financial year will be carry forwarded to next 
                            financial year.</li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="redbox" 
                        onclick="btnSubmit_Click"  OnClientClick="return confirmationAdd()" 
                        Text="Do you want to continue?" />
                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
                        onclick="btnCancel_Click" Text="Cancel" />
                </td>
            </tr>
                   
                   
            <tr>
                <td>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
                   
                   
                   </table>
                   </td>
                   
                   </tr>
            
        </table>
    </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

