<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Salary_Print.aspx.cs" Inherits="Module_HR_Transactions_Salary_Print" Title="ERP" Theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style2
        {
            font-weight: bold;
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
            <td align="left" valign="middle" 
                    style="background:url(../../../images/hdbg.JPG)" height="21" 
                    class="fontcsswhite" colspan="4"><b>&nbsp;PayRoll - Print</b></td>
        </tr>
        <tr> 
        <td width="20%">
        
        </td>
         
        <td width="10%">
            &nbsp;</td>
        <td width="80%">
        
            &nbsp;</td>
        <td width="5%">
        
        </td>
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
         &nbsp;<b><asp:Label ID="Label4" runat="server" Text="Select Month"></asp:Label></b>
            </td>
        <td>
        
           <asp:DropDownList ID="ddlMonth" runat="server" CssClass="box3" 
                                AutoPostBack="True" 
                onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblBGGroup" runat="server" Font-Bold="True" Text="BG Group"></asp:Label>
&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlBGGroup" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="Dept" DataValueField="Id" CssClass="box3">
                    </asp:DropDownList>
            </td>
        <td>
        
            &nbsp;</td>
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td rowspan="8">
        
             <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="260px" 
                 AutoPostBack="True">
                                <asp:ListItem Value="0" Selected="True">Salary Slip</asp:ListItem>
                                <asp:ListItem Value="1">Salary Slip of All Employees</asp:ListItem>
                                <asp:ListItem Value="2">On Cash Report</asp:ListItem>
                                <asp:ListItem Value="3">Over Time Report</asp:ListItem>
                                <asp:ListItem Value="4">SAPL Summary Report</asp:ListItem>
                                <asp:ListItem Value="5">Neha Summary Report</asp:ListItem>
                                <asp:ListItem Value="6">Bank Statement</asp:ListItem>
                                <asp:ListItem Value="7">All Month Summary Report</asp:ListItem>
                                <asp:ListItem Value="8">Consolidated Summary Report</asp:ListItem>
                                <asp:ListItem Value="9">Salary Summery Report</asp:ListItem>
                            </asp:RadioButtonList></td>
        <td>
        
              <asp:TextBox ID="TxtEmpSearch" runat="server" CssClass="box3" Width="400px"></asp:TextBox>                                    
                                        
                                        <cc1:AutoCompleteExtender ID="TxtEmpSearch_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpSearch" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" 
                                            CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" 
                                            CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender></td>
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
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
            &nbsp;</td>
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
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
            &nbsp;</td>
        <td>
        
            &nbsp;</td>
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
            <asp:Label ID="Label2" runat="server" CssClass="style2" Text="Cheque No."></asp:Label>
                                        &nbsp;<b>:</b>
                                        <asp:TextBox ID="txtChequeNo" runat="server" CssClass="box3" Width="170px"></asp:TextBox>
            
          
&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" CssClass="style2" Text="Date"></asp:Label>
                                        &nbsp;<b>:</b>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="box3" Width="100px">
                                        </asp:TextBox>
                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server"
                                         Enabled="True" CssClass="cal_Theme2" PopupPosition="BottomRight"
Format="dd-MM-yyyy" TargetControlID="txtDate">
</cc1:CalendarExtender>

 <asp:RegularExpressionValidator ID="RegtxtDate" runat="server" 
ControlToValidate="txtDate" ErrorMessage="*" 
ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
ValidationGroup="SG">
 </asp:RegularExpressionValidator>
                                     
            
            </td>
        <td>
        
            &nbsp;</td>
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
        <b>Bank Name : 
            <asp:DropDownList ID="ddlBankName" runat="server" CssClass="box3" 
                DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="Id">
                                        </asp:DropDownList>   
            
            <asp:DropDownList ID="ddlEmpOrDirect" runat="server" CssClass="box3">
            <asp:ListItem Value="0" Selected="True">Employee</asp:ListItem>
             <asp:ListItem Value="1">Directors</asp:ListItem>
            </asp:DropDownList></b> 
                                     
            
            </td>
        <td>       
            &nbsp;</td>
        </tr>
        <tr>
        <td>
        
            &nbsp;</td>
        <td>
        
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ connectionStrings:LocalSqlServer %>" 
                ProviderName="System.Data.SqlClient" 
                SelectCommand="Select Id, Symbol as Dept from BusinessGroup">
            </asp:SqlDataSource>
        
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                SelectCommand="SELECT [Id], [Name] FROM [tblACC_Bank] WHERE [Id]!='4'"></asp:SqlDataSource>
                                     
            
            </td>
        <td>       
            &nbsp;</td>
        </tr>
        <tr>
        <td align="center" colspan="4" height="25px" valign="middle">
         <asp:Button ID="btnProceed" runat="server" CssClass="redbox" Text="Proceed" 
                                            onclick="Button1_Click" />
        </td>
        
        </tr>
        <tr>
        <td colspan="4" align="center">
      <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical"  Height="220px"  
                Width="63%">         

         
             <asp:GridView ID="GridView2" runat="server" 
        CssClass="yui-datatable-theme" AutoGenerateColumns="False" Width="100%" 
                 onrowcommand="GridView2_RowCommand" >
       
      <Columns>
      <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center">
      <ItemTemplate> <%# Container.DataItemIndex + 1%> 
                        </ItemTemplate>
        <ItemStyle HorizontalAlign="Right" Width="2%"></ItemStyle>
        </asp:TemplateField>
      
                  
            <asp:TemplateField HeaderText="">
            <ItemTemplate>
            <asp:LinkButton ID="btnSelect" runat="Server" CommandName="Sel"  Text="Select" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="6%" />
            </asp:TemplateField>
            
                        
            <asp:TemplateField HeaderText="">
            <ItemTemplate>
             <asp:LinkButton ID="btnPrint" runat="Server" CommandName="Print"  Text="Print" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="6%" />
            </asp:TemplateField>            
            
            <asp:TemplateField HeaderText="ChequeNo">
            <ItemTemplate>
            <asp:Label ID="lblChequeNo" runat="server" Text='<%# Eval("ChequeNo") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Cheque Date">
            <ItemTemplate>
            <asp:Label ID="lblChequeNoDate" runat="server" Text='<%# Eval("ChequeNoDate") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="BankName">
            <ItemTemplate>
            <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("BankName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="50%"/>
            </asp:TemplateField>
             
            <asp:TemplateField HeaderText="TransNo"  Visible ="false" >
            <ItemTemplate>
            <asp:Label ID="lblTransNo" runat="server" Text='<%# Eval("TransNo") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="BankId"  Visible ="false">
            <ItemTemplate>
            <asp:Label ID="lblBankId" runat="server" Text='<%# Eval("BankId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>           
            
            <asp:TemplateField HeaderText="Type" Visible ="false" >
            <ItemTemplate>
            <asp:Label ID="lblType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
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
        </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

