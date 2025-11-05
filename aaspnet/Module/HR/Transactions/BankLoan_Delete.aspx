<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_BankLoan_Delete, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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

    <table class="style2">
    <tr>
            <td align="left" valign="middle" 
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite"><b>&nbsp;Bank Loan - Delete</b></td>
        </tr>
        <tr>
             <td align="left">
        
            <asp:DropDownList ID="DrpField" runat="server" 
                onselectedindexchanged="DrpField_SelectedIndexChanged" AutoPostBack="True" 
                CssClass="box3">
              <%--  <asp:ListItem>Select</asp:ListItem>--%>
               <asp:ListItem Value="0">Employee Name</asp:ListItem>
               <%--<asp:ListItem Value="1">Dept Name</asp:ListItem>
               <asp:ListItem Value="2">BG Group </asp:ListItem>--%>  
                               
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="TxtMrs" runat="server" Width="150px" CssClass="box3"></asp:TextBox>
            &nbsp;<asp:TextBox ID="TxtEmpName" runat="server" Width="350px" CssClass="box3"></asp:TextBox>
                  
        <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                                 CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
        
            &nbsp;&nbsp;&nbsp;
        
                    
            <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                onclick="Button1_Click" Text="Search" />
            
        
            &nbsp;
                 <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            
        
            </td>
        </tr>
        <tr>
            <td>

<asp:Panel ID="Panel1"  ScrollBars="Auto" Height="410px" runat="server">
    <asp:GridView 
        ID="GridView2" runat="server" 
        CssClass="yui-datatable-theme" AutoGenerateColumns="False"  ShowFooter="false"
        AllowPaging="True" Width="99%" onpageindexchanging="GridView2_PageIndexChanging" 
                    onselectedindexchanged="GridView2_SelectedIndexChanged" PageSize="15" 
                    onrowcommand="GridView2_RowCommand">
        <PagerSettings 
            PageButtonCount="40" />
        <Columns>
            <asp:TemplateField HeaderText="SN" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" Width="4%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" 
                                OnCheckedChanged="CheckBox1_CheckedChanged" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Id" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EmpId"  >
                <ItemTemplate>
                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Eval("EmpId") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"   Width="6%"/>
            </asp:TemplateField>
            <asp:BoundField DataField="EmployeeName" HeaderText="Emp Name" 
              SortExpression="EmployeeName">
                <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:BoundField>
           
            <asp:TemplateField HeaderText="Bank Name"  >
                <ItemTemplate>
                 <asp:Label ID="lblBank" runat="server" Text='<%# Eval("BankName") %>'></asp:Label>
                
                  
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"   Width="18%"/>
                </asp:TemplateField>
          
        
          
          
          <asp:TemplateField HeaderText="Branch" >
                <ItemTemplate>
                
                
                 <asp:Label ID="lblBranch" runat="server" Text='<%# Eval("Branch") %>'></asp:Label>
                   
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  Width="10%" />
                </asp:TemplateField>
          
          
          <asp:TemplateField HeaderText="Amount" >
                <ItemTemplate>
                
                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                  
      
                    
                    
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%"  />
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Installment"   >
                <ItemTemplate>
                
                 <asp:Label ID="lblInstallment" runat="server" Text='<%# Eval("Installment") %>'></asp:Label>
                   
      
                    
                    
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:TemplateField>
                
                
                <asp:TemplateField HeaderText="From Date" >
                <ItemTemplate>
                
                 <asp:Label ID="lblFromDate" runat="server" Text='<%# Eval("fromDate") %>'></asp:Label>
                  
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left"  Width="8%"/>
                
                
                </asp:TemplateField>
                <asp:TemplateField HeaderText="To Date" >
                <ItemTemplate>
                   <asp:Label ID="lblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                
                      
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="8%" />
                          
                </asp:TemplateField>
             
        </Columns>
        <EmptyDataTemplate>
            <table width="100%" class="fontcss">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label1" runat="server"  Text="No data to display !" 
                            Font-Size="Larger" ForeColor="maroon"> </asp:Label>
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    
         </asp:Panel>
     
            </td>
        </tr>     <tr>
            <td align="center">

               <asp:Button ID="BtnSubmit"    runat="server" Text="Delete" CssClass="redbox" OnClientClick="return confirmationDelete()" 
                    onclick="BtnSubmit_Click" />
            </td>
            </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

