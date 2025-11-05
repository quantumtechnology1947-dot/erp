<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_Salary_BankStatement_CheckEdit, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>

    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .style2
    {
        width: 100%;
        
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
    <table align="left" cellpadding="0" cellspacing="0" class="style2">
    <tr><td height="25px">
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="True" Font-Bold="True" 
            Font-Size="16px" oncheckedchanged="chkAll_CheckedChanged" Text="Check All" />
        
        </td></tr>
    <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="440px" 
                Width="99%">         

         
             <asp:GridView ID="GridView2" runat="server" 
        CssClass="yui-datatable-theme" AutoGenerateColumns="False" Width="100%" >
       
      <Columns>
      <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center">
      <ItemTemplate> <%# Container.DataItemIndex + 1%> 
                        </ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="">
            <ItemTemplate>
            <asp:CheckBox ID="CheckBox1" runat="server" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="3%" />
            </asp:TemplateField>
            
                       
            <asp:TemplateField HeaderText="Id" Visible ="true">
            <ItemTemplate>
            <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="10%"/>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Employee Name">
            <ItemTemplate>
            <asp:Label ID="lblEmployeeName" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="A/C Number">
            <ItemTemplate>
            <asp:Label ID="lblEmpACNo" runat="server" Text='<%# Eval("EmpACNo") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("NetPay") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="10%"/>
            </asp:TemplateField>                            
          
      </Columns>
       <EmptyDataTemplate>
                    <table width="100%" class="fontcss">
                    <tr>
                    <td align="center">
                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                    </asp:Label>
                    </td>
                    </tr>
                    </table>
                    </EmptyDataTemplate>
      
    </asp:GridView>
    
     </asp:Panel>
        </td>       
    </tr>
    <tr>
     <td  align="center" valign="middle" height="25">
            <asp:Button ID="btnUpdate" runat="server" CssClass="redbox" Text="Update" 
                onclick="btnUpdate_Click" />
            <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="redbox" onclick="Cancel_Click" /></td>
    </tr>
</table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
