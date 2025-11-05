<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ForgotPassword, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <style type="text/css">
        
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
    &nbsp;<br />
    <br />
    <br />
    <br />
    <table width="100%">
        <tr>
            <td align="center">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" BackColor="#FFFBD6" 
        BorderColor="#FFDFAD" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="10pt" 
        AnswerRequiredErrorMessage="Answer is  required." Height="180px" 
        
                    SuccessText="Your password has been sent on your Email., Login with your new password." 
                    Width="321px" onsendingmail="PasswordRecovery1_SendingMail">
        <%--<MailDefinition From="erpsystem@sapl.com" IsBodyHtml="True" Priority="High" 
            Subject="Your New,Temporary password.">
        </MailDefinition>--%>
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <SuccessTextStyle Font-Bold="True" ForeColor="#990000" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
        <SubmitButtonStyle BackColor="White" BorderColor="#CC9966" 
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#990000" />
    </asp:PasswordRecovery>
    <br />
    <br />
            </td>
        </tr>
    </table>
    <br />



</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

