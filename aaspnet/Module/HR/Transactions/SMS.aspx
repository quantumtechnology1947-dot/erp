<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_SMS, newerp_deploy" title="ERP" theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>    
    <script src="../../../Javascript/jquery.min.js" type="text/javascript"></script>
    <script src="../../../Javascript/MaxLength.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () 
        {
            //Normal Configuration
            $("[id*=TextBox2]").MaxLength({ MaxLength: 140 });
 
//            //Specifying the Character Count control explicitly
//            $("[id*=TextBox2]").MaxLength(
//            {
//                MaxLength: 15,
//                CharacterCountControl: $('#counter')
//            });

//            //Disable Character Count
//            $("[id*=TextBox2]").MaxLength(
//            {
//                MaxLength: 20,
//                DisplayCharacterCount: false
//            });
    });
    </script>
    
    <style type="text/css">
        .style1
        {
            width: 100%;
            float: left;
        }
        .style2
        {
            width: 504px;
        }
        .style3
        {
            width: 88px;
        }
        .style4
        {
            width: 504px;
            color: red;
        }
        .style5
        {
            text-align: left;
        }
        #counter
        {
            text-align: left;
        }
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
    <table align="left" cellpadding="0" cellspacing="0" width="100%">
        <tr>
        <td colspan="2" align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;SMS</b></td>
            
        </tr>
        <tr>
            <td class="style4" height="25">
                &nbsp; * Internet connection is required to send SMS</td>
            <td>
                <b>&nbsp;&nbsp; Select receipients</b></td>
        </tr>
        <tr>
            <td class="style2" valign="top">
                <table align="left" cellpadding="0" cellspacing="0" width="97%">
                    <tr>
                        <td class="style3">
&nbsp; <b>Mobile No.</b></td>
                        <td>
    <asp:TextBox ID="TextBox1" runat="server" Width="395px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3" valign="top">
                            &nbsp;</td>
                        <td>
                            Use (,) as seperator for multiple mobile nos.</td>
                    </tr>
                    <tr>
                        <td class="style3" valign="top">
&nbsp; <b>Message</b><br />
                        </td>
                        <td>
    <asp:TextBox ID="TextBox2" runat="server" Height="135px" TextMode="MultiLine" Width="397px"></asp:TextBox>
                            
                            </td>
                    </tr>
                    <tr>
                        <td class="style3" valign="top">
                            &nbsp;</td>
                        <td height="25">
                            
                            <div id="counter">
                            </div>
                           
                            </td>
                    </tr>
                    </table>
            </td>
            <td valign="top">
                <asp:Panel ID="Panel1" runat="server" Height="363px" ScrollBars="Auto">
                    <table align="right" cellpadding="0" cellspacing="0" width="99%">
                        <tr>
                            <td class="style5">
                                 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                    CssClass="yui-datatable-theme" Width="80%" 
                                     onrowcommand="GridView2_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SN">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack=true oncheckedchanged="CheckBox1_CheckedChanged"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack=true oncheckedchanged="CheckBox2_CheckedChanged"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Emp No">
                                         <ItemTemplate>
                                             <asp:Label ID="EmpNo" runat="server" Text='<%#Eval("EmpNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name of Employee">
                                        <ItemTemplate>
                                             <asp:Label ID="EmpName" runat="server" Text='<%#Eval("EmpName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="40%" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No">
                                        <ItemTemplate>
                                             <asp:Label ID="MobileNo" runat="server" Text='<%#Eval("MobileNo")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department">
                                        <ItemTemplate>
                                             <asp:Label ID="Dept" runat="server" Text='<%#Eval("Dept") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" height="30">
                                <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                    onclick="Button1_Click" Text="Send" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style5" height="30">
                                <asp:Label ID="Label2" runat="server"> </asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table> 
      
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

