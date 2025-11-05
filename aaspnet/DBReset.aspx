<%@ page language="C#" autoeventwireup="true" inherits="DBReset, newerp_deploy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    <link href="Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="Javascript/PopUpMsg.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:Button ID="Button1" runat="server" Text="Reset DB" OnClientClick="return confirmation();" onclick="Button1_Click" 
            CssClass="redbox" />
    </div>
    </form>
</body>
</html>
