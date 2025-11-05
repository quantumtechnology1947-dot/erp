<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_Salary_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
    </style> 
     <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
    <table class="style2" cellpadding="0" cellspacing="0">
       <tr>
            <td align="left" valign="middle"  
                style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite">&nbsp;&nbsp; <b>
                Salary Delete</b></td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="GridView2" runat="server" 
                    AutoGenerateColumns="False" DataKeyNames="Id" 
                     CssClass="yui-datatable-theme" Width="100%" 
                    onrowdatabound="GridView2_RowDataBound" PageSize="20" 
                    onpageindexchanging="GridView2_PageIndexChanging" 
                    onrowcommand="GridView2_RowCommand" >
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                    CommandName="Del" Text="Delete"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                      <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" Width="2%" />                                      
                                    </asp:TemplateField>
                                    
                                 <asp:TemplateField HeaderText="Id" Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="MId" Visible="false"  >
                            <ItemTemplate>
                                <asp:Label ID="lblMId" runat="server" Text='<%# Bind("MId") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>     
                                    
                        <asp:TemplateField HeaderText="Month">
                        <ItemTemplate>
                            <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("Month")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="DOM">
                        <ItemTemplate>
                            <asp:Label ID="lblDaysOfMonth" runat="server" Text='<%#Eval("DaysOfMonth")%>'></asp:Label>
                        </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField  HeaderText="HD">
                            <ItemTemplate>
                                <asp:Label ID="lblHolidays" runat="server" Text='<%# Bind("Holidays") %>'></asp:Label>
                            </ItemTemplate>                           
                             <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Sun.">
                            <ItemTemplate>
                                <asp:Label ID="lblMonthSunday" runat="server" Text='<%# Bind("MonthSunday") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WO Days">
                         <ItemTemplate>
                                <asp:Label ID="lblWorkingDays" runat="server" Text='<%# Bind("WorkingDays") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="P">
                        <ItemTemplate>
                                <asp:Label ID="lblPresent" runat="server" Text='<%# Bind("Present") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="A">
                        <ItemTemplate>
                                <asp:Label ID="lblAbsent" runat="server" Text='<%# Bind("Absent") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" Width="3%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="L">
                        <ItemTemplate>
                                <asp:Label ID="lblLateIn" runat="server" Text='<%# Bind("LateIn") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="H">
                         <ItemTemplate>
                                <asp:Label ID="lblHalfDay" runat="server" Text='<%# Bind("HalfDay") %>'></asp:Label>
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WO Sun">
                         <ItemTemplate>
                                <asp:Label ID="lblSunday" runat="server" Text='<%# Bind("Sunday") %>'></asp:Label>
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                             
                        <asp:TemplateField HeaderText="Coff">
                         <ItemTemplate>
                                <asp:Label ID="lblCoff" runat="server" Text='<%# Bind("Coff") %>'></asp:Label>
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="PL">
                         <ItemTemplate>
                                <asp:Label ID="lblPL" runat="server" Text='<%# Bind("PL") %>'></asp:Label>
                            </ItemTemplate>
                           <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="OT Hrs">
                         <ItemTemplate>
                                <asp:Label ID="lblOverTimeHrs" runat="server" Text='<%# Bind("OverTimeHrs") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="OT Rate">
                         <ItemTemplate>
                                <asp:Label ID="lblOverTimeRate" runat="server" Text='<%# Bind("OverTimeRate") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="Bank Loan">
                         <ItemTemplate>
                                <asp:Label ID="lblBankLoan" runat="server" Text='<%# Bind("BankLoan") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" Width="8%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="Inst.">
                         <ItemTemplate>
                                <asp:Label ID="lblInstallment" runat="server" Text='<%# Bind("Installment") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="Mob Amt">
                         <ItemTemplate>
                                <asp:Label ID="lblMobileExeAmt" runat="server" Text='<%# Bind("MobileExeAmt") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="Add">
                         <ItemTemplate>
                                <asp:Label ID="lblAddition" runat="server" Text='<%# Bind("Addition") %>'></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Right" Width="4%" />
                        </asp:TemplateField>
                        
                                                
                        <asp:TemplateField HeaderText="Deduct">
                         <ItemTemplate>
                                <asp:Label ID="lblDeduction" runat="server" Text='<%# Bind("Deduction") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
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
             
                
            </td>
        </tr>
        <tr>
        <td align="center" height="30" valign="middle">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="redbox" 
                onclick="btnCancel_Click"  />
        </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

