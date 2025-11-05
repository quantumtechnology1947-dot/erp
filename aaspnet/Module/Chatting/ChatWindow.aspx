<%@ page language="C#" autoeventwireup="true" inherits="LinqChat.ChatWindow, newerp_deploy" theme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Private Chat</title>
    
    <link href="../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">    
        function SetScrollPosition()
        {
            var div = document.getElementById('divMessages');
            div.scrollTop = 100000000000;
        }
        
       function SetCursorToTextEnd(textControlID) 
{
        var text = document.getElementById(textControlID);
        if (text != null && text.value.length > 0)
        {
                if (text.createTextRange) 
                {
                        var range = text.createTextRange();
                        range.moveStart('character', text.value.length);
                                range.collapse();
                                range.select();
                }
                else if (text.setSelectionRange) 
                {
                        var textLength = text.value.length;
                        text.setSelectionRange(textLength, textLength);
                }
        }


}    
               
        function ReplaceChars() 
        {
            var txt = document.getElementById('txtMessage').value;
            var out = "<"; // replace this
            var add = ""; // with this
            var temp = "" + txt; // temporary holder

            while (temp.indexOf(out)>-1) 
            {
                pos= temp.indexOf(out);
                temp = "" + (temp.substring(0, pos) + add + temp.substring((pos + out.length), temp.length));
            }
            
            document.getElementById('txtMessage').value = temp;        
                       
            
        }
        
        function FocusThisWindow(result, context)
        {
            // don't do anything here
        }
        
        function FocusMe()
        {
            FocusThisWindowCallBack('FocusThisWindow');   
        }
    </script>
</head>
<body style="background-color:#DCDCDC; margin: 0 0 0 0;" onload="SetScrollPosition()">
    <form id="form1" runat="server" >
    <div>
        <asp:Label Id="lblFromUserId" Visible="false" runat="server" />
        <asp:Label Id="lblToUserId" Visible="false" runat="server" />
        <asp:Label Id="lblFromUsername" Visible="false" runat="server" />
        <asp:Label Id="lblMessageSent" Visible="false" runat="server" />
        <asp:ScriptManager Id="ScriptManager1" runat="server" />
        
        <asp:UpdatePanel Id="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlId="Timer1" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer Id="Timer1" Interval="7000" OnTick="Timer1_OnTick" runat="server" />
                <div id="divMessages" style="background-color: White; border-color:Black;border-width:1px;border-style:solid;height:160px;width:388px;overflow-y:scroll; font-size: 11px; padding: 4px 4px 4px 4px;" onresize="SetScrollPosition()">
                    <asp:Literal Id="litMessages" runat="server" />
                </div>  
                <asp:TextBox Id="txtMessage" onkeyup="ReplaceChars();" onclick="FocusMe()" onfocus="SetCursorToTextEnd(this.id)" runat="server" Width="320px" />
                <asp:Button Id="btnSend" runat="server" CssClass="redbox" Text="Send" OnClientClick="SetScrollPosition()" OnClick="BtnSend_Click" />           
            </ContentTemplate>
        </asp:UpdatePanel>  
    </div>
    </form>
</body>
</html>