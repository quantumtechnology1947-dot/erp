<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_ProjectManagement_Transactions_ManPowerPlanning_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            height: 23px;
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
            <td height="20" align="left" valign="middle"  scope="col" class="fontcsswhite" 
                style="background:url(../../../images/hdbg.JPG)">
        &nbsp;<b>Man Power Planning - Edit</b></td>
        </tr>
         <tr>
        <td>
        
        
  <%--  </asp:Panel>--%>
        <table class="style3">
            <tr>
                <td width="10%">
                    &#160;</td>
                <td width="10%">
                    &#160;</td>
                <td width="30%">
                    &#160;</td>
                <td width="10%">
                    &#160;</td>
                <td width="30%">
                    &#160;</td>
                <td width="10%">
                    &#160;</td>
            </tr>
            <tr>
                <td>
                    &#160;</td>
                <td>
                    Name</td>
                <td>
                    <asp:Label ID="LName" runat="server"></asp:Label>
                </td>
                <td>
                    Wono</td>
                <td>
                    <asp:TextBox ID="TWONo" runat="server" CssClass="box3" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldTWONo" runat="server" 
                                    ControlToValidate="TWONo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td>
                    &#160;</td>
            </tr>
            <tr>
                <td>
                    &#160;</td>
                <td>
                    Designation</td>
                <td>
                    <asp:Label ID="LDesignation" runat="server"></asp:Label>
                </td>
                <td>
                    Dept</td>
                <td>
                    <asp:DropDownList ID="DrpDepartment" runat="server" CssClass="box3" 
                        DataSourceID="SqlDept" DataTextField="DeptName" DataValueField="Id">
                    </asp:DropDownList>
                </td>
                <td>
                    &#160;</td>
            </tr>
            <tr>
                <td>
                    &#160;</td>
                <td>
                    Date</td>
                <td>
                    <asp:Label ID="Ldate" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Planed HRS"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TAHrs" runat="server" CssClass="box3" Width="150px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValTAHrs" runat="server" 
                                    ControlToValidate="TAHrs" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularTAHrs" runat="server" 
                                    ControlToValidate="TAHrs" ErrorMessage="*" 
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="A"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &#160;</td>
              
            </tr>
            <tr>
                <td>
                    &#160;</td>
                <td>
                    Type</td>
                <td>
                    <asp:DropDownList ID="Drptype" runat="server" CssClass="box3">
                        <asp:ListItem Text="Present" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Absent" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Onsite" Value="3"></asp:ListItem>
                        <asp:ListItem Text="PL" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Planed"></asp:Label>
                </td>
                <td rowspan="2">
                    <asp:TextBox ID="TDescription" runat="server" CssClass="box3" 
                        TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td>
                    &#160;</td>
            </tr>
            <tr>
                <td class="style4">
                    </td>
                <td class="style4">
                    </td>
                <td class="style4">
                    </td>
                <td class="style4">
                    </td>
                <td class="style4">
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="left">
                    <asp:Label ID="Label4" runat="server" Text="Actual Desc"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TActualDesc" runat="server" CssClass="box3" 
                        TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" colspan="4" height="100">
                    <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox" 
                        onclick="BtnUpdate_Click" Text="Update" ValidationGroup="A" />
                    &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                        onclick="BtnCancel_Click" Text="Cancel" />
            
             <asp:SqlDataSource ID="SqlDept" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT Id, Symbol AS DeptName FROM BusinessGroup">
            </asp:SqlDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
   <%--  </asp:Panel>--%>
      </td>
        
        </tr>
    
         <tr>
        <td align="center">
           
            
             </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

