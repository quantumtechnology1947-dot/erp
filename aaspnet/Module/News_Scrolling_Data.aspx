<%@ page language="C#" autoeventwireup="true" inherits="Module_News_Scrolling_Data" CodeFile = "News_Scrolling_Data.aspx.cs" title="ERP" %>

<html id="Html1" runat="server">
<head>
    <link href="../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../Javascript/JScript.js" type="text/javascript"></script>
        </head>
<body>

    <form id="form1" runat="server">

<div id="datacontainer" onMouseover="scrollspeed=0" onMouseout="scrollspeed=cache">

<!-- ADD YOUR SCROLLER CONTENT INSIDE HERE -->
<br /><br />
<!-- END SCROLLER CONTENT -->
    <asp:Table ID="Table1" runat="server" CssClass="fontcss" Width="100%">
        
    </asp:Table>
</div>
</form>

</body>
</html>
