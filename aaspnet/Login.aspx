<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="ERP" Theme ="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">  
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ERP</title>
    
         
    <script src="Javascript/JScript.js" type="text/javascript"></script>

    <script src="Javascript/PopUpMsg.js" type="text/javascript"></script>

    <link href="Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="Css/StyleSheet.css" rel="stylesheet" type="text/css" />
     
        
     <script type="text/javascript">
   window.history.forward();
function noBack(){ window.history.forward() };
</script>

    <script src="Javascript/loadingNotifier.js" type="text/javascript"></script>
     
    <style type="text/css">      
    </style>
     
    </head>
<body onload="goforit();noBack();"  background="images/1.jpg">
    <form id="form1" runat="server">
     <table bgcolor="#37474F" ><tr>                     
                                <td>
                                <span lang="en-us">&nbsp; </span><asp:LinkButton ID="LinkButton2" runat="server" 
                                    OnClientClick="window.open('Others/Security_GatePass.aspx','','target=_blank,scrollbars=1');"
                                    ><asp:Image ID="Image2" runat="server" ImageUrl="images/gate-pass.png" Width="25%" Height="40px" ToolTip="Daily Gate Pass" /></asp:LinkButton>
                                &nbsp;
&nbsp;
                                <asp:HyperLink ID="HyperLink2" runat="server" 
                                    NavigateUrl="http://192.168.1.4/servlet/LoginServlet?jsEnabled=true " 
                                    Target="_blank">
                                    <asp:Image ID="Image3" runat="server" ToolTip="Email" ImageUrl="images/email.ico" Height="40px" Width="25%" /></asp:HyperLink>
                              
&nbsp; </td><td> <table >
                        <tr>
                            <td>
                                &nbsp;<asp:Label Visible=false ID="Label1" runat="server" ></asp:Label>
                            </td>
                        </tr>
                     </table></td>
                        </tr>
       </table>
       <table align="center" width="100%">
            <tr style="height:0px">
               <td>
                <table>
                 <tr>
                 <td visible=false>
                 <asp:GridView visible=false ID="GridView1" runat="server" style="display:none" AutoGenerateColumns="False" ShowHeader="False" UseAccessibleHeader="False" 
            EnableTheming="false">
            <Columns>
            <asp:TemplateField>
            <ItemTemplate>
           <asp:Image  Visible=false ID="Image1"  runat="server" ImageUrl='<%# "Handler2.ashx?CompId=" + Eval("CompId") %>' BorderWidth="0"/>
           </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
                               </td>
                            </tr>
                        </table>                               
                   </td>                   
              
                <td> 
                    <table>
                        <tr>
                            <td><span style="display:none" id="clock"></span></td>
                        </tr>
                    </table>
                    </td>
            </tr>
            <tr style="height:0px"> 
            <td colspan="2"> 
                   
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td style="color:white; font:32px;"><span visible=false id="datacontainer"><script visible=false  language="javascript" type="text/javascript">TimeMsg();</script></span></td>                          
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height:410px;">
                    <table width="100%">           
                         <tr style="padding-top:0px">  
                            <td>
                              <center> 
                                  <asp:Login ID="Login1" runat="server" 
                                    FailureText="Invalid Login"  Width="60%" 
                                    onloggedin="Login1_LoggedIn" BorderColor="#333333" BorderStyle="Ridge" 
                                      BorderWidth="2px" BackColor="White">
                                    <TextBoxStyle/>
                                    <LoginButtonStyle />
                                    <LayoutTemplate>
                                        <table width="100%" border="0px" frame="box">                                            
                                            
                                            <tr>
                                                <td align="center" bgcolor="#C2185B"> Experience the Excellence.. 
                                                    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="87%" >
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="DropDownList1" ErrorMessage="*" InitialValue="Select" 
                                                        ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                         &nbsp;<asp:DropDownList ID="DptYear" runat="server" AutoPostBack="True" 
                                                       
                                                        onselectedindexchanged="DptYear_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                        ControlToValidate="DptYear" ErrorMessage="*" InitialValue="Select" 
                                                        ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td>
                                                    <h4 style="color:#C2185B">User Name:</h4>
                                                    <br>                                                   
                                                    <asp:TextBox ID="UserName" runat="server" ForeColor="#9E9E9E" 
                                                        style="border: 0; outline: 0; background: transparent; border-bottom: 2px solid #C2185B;" 
                                                        Width="80%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                        ControlToValidate="UserName" ErrorMessage="*" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                    <br></br>
                                                    </br>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><h4 style="color:#C2185B">Password:</h4>
                                                    <br>                                                    
                                                    <asp:TextBox ID="Password" runat="server" ForeColor="#9E9E9E" 
                                                        style="border: 0; outline: 0; background: transparent; border-bottom: 2px solid #C2185B;" 
                                                        TextMode="Password" Width="80%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="Password" ErrorMessage="*" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                                                    <br></br>
                                                    </br>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  style="height:22px" align="center">
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                                                        Text="Log In" ValidationGroup="Login1" 
                                                        onclick="LoginButton_Click" BackColor="#C2185B" BorderStyle="Outset" 
                                                        ForeColor="White" Width="50%" Height="31px" Font-Bold="True" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center"  style="height:22px">
                                                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" 
                                                        NavigateUrl="~/Module/ForgotPassword/ForgotPassword.aspx" Font-Size="8pt">Forgot 
                                                    Password?</asp:HyperLink>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center"  style="color:Red; height:22px">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False" ></asp:Literal>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                                        ForeColor="White" />
                                </asp:Login></center>
                                
                            </td>
                            <td bgcolor="#263238">                            
                                  <table width="100%">
                                    <tr>
                                        <td style="background:white">
                                            <span lang="en-us" style="color:#C2185B" >Happy Birthday:</span>
                               <marquee height="100px"  direction="up" scrollamount="2" onmouseover="stop()" onmouseout="start()"><asp:Label ID="lblBirthDay" runat="server" Text="test" ForeColor="#212121"></asp:Label></marquee>
                               </td>
                            
                                     </tr>
                                     <tr><td><asp:Label ID="Label2" runat="server" Text="News &amp; Notices" BackColor="#C2185B" Width="100%"></asp:Label>
                             <iframe src="Module/News_Scrolling_Data.aspx"  id="datamain" frameborder="0" marginwidth="0" marginheight="0" width="300px"  scrolling="no"></iframe>
                                </td></tr>
                              </table>
                    
                            </td>
                        </tr>
                      </table>
                      
                    </td>
                    </tr> 
                    </table>    
    </form>
</body>
</html>


