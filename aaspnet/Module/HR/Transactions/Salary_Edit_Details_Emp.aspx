<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_Salary_Edit_Details_Emp, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    
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

    <table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="middle" 
            style="background:url(../../../images/hdbg.JPG)" height="21" 
            class="fontcsswhite" colspan="14"><b>&nbsp;Salary Edit</b></td>
    </tr>
    <tr>
    <td>
     <table align="center" width="99%">

    <tr> <td colspan="2" width="30%">&nbsp; Salary for the Month of&nbsp;
        <asp:Label ID="lblMonthName" runat="server" style="font-weight: 700"></asp:Label>
        </td> <td colspan="3" width="10%">Days of Month : <asp:Label ID="lblDaysM" 
                runat="server" style="font-weight: 700"></asp:Label>
        </td> <td colspan="2" width="20%">Sundays : <asp:Label ID="lblSunM" runat="server" 
                style="font-weight: 700"></asp:Label>
        </td> <td colspan="3" width="20%">Holidays : <asp:Label ID="lblHolidayM" 
                runat="server" style="font-weight: 700"></asp:Label>
        </td> <td colspan="2" width="30%">Working Days : <asp:Label ID="lblWDayM" 
                runat="server" style="font-weight: 700"></asp:Label>
        </td></tr>
    <tr bgcolor="#CCCCCC"> <td align="center" colspan="3" width="32%" height="20px" 
            
            
            style="border-left-style: solid; border-left-color: #C0C0C0; border-right-style: solid; border-right-color: #C0C0C0;"><b>Employee 
        Details</b></td> 
        <td align="center" colspan="3" width="31%" 
            style="border-right-style: solid; border-right-color: #C0C0C0"><b>Attendance Details</b></td> 
        <td align="center" colspan="6" width="36%" 
            style="border-right-style: solid; border-right-color: #C0C0C0"><b>Miscellanies</b></td></tr>
    <tr> 
        <td width="14%" 
            style="border-left-style: solid; border-left-color: #C0C0C0" rowspan="4" 
            valign="top">     
                 &nbsp;&nbsp;           
                 <asp:Image ID="Image1" runat="server" Height="100px" Width="80px" />                      
        </td> 
        <td colspan="2" width="18%" 
            style="border-right-style: solid; border-right-color: #C0C0C0">
        <asp:Label 
            ID="lblNameOfEmployee" runat="server" style="font-weight: 700"></asp:Label>
        </td> <td width="15%">&nbsp; Present</td> 
        <td colspan="2" width="16%" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtPresent" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtPresent" runat="server" 
                                        ControlToValidate="txtPresent" ErrorMessage="*" 
                ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtPresent" runat="server" 
                                        ControlToValidate="txtPresent" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2" width="10%">&nbsp; Bank Loan</td> <td colspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0" width="90%">:
        <asp:Label ID="lblBLoan" runat="server" style="font-weight: 700"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Inst. Paid :
            <asp:Label ID="lblBalance" runat="server" style="font-weight: 700"></asp:Label>
        </td> </tr>
    <tr>  
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">Swap Card No:
        <asp:Label ID="lblSCNo" runat="server"></asp:Label>
        </td> <td>&nbsp; Absent</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtAbsent" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtAbsent" runat="server" 
                                        ControlToValidate="txtAbsent" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtAbsent" runat="server" 
                                        ControlToValidate="txtAbsent" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp; ESI</td> 
        <td colspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
            <asp:TextBox ID="txtInstallment" runat="server" CssClass="box3" Width="100px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtInstallment" runat="server" 
                                        ControlToValidate="txtInstallment" 
                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtInstallment" runat="server" 
                                        ControlToValidate="txtInstallment" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </td></tr>
    <tr>  
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">
            Department:
        <asp:Label ID="lblDept" runat="server"></asp:Label>
        </td> <td>&nbsp; Late In</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtLateIn" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtLateIn" runat="server" 
                                        ControlToValidate="txtLateIn" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtLateIn" runat="server" 
                                        ControlToValidate="txtLateIn" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp; Mobile Bill</td> <td colspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0">: Limit :
        <asp:Label ID="lblLimit" runat="server" style="font-weight: 700"></asp:Label>
        &nbsp;Bill Amt :
            <asp:Label ID="lblBill" runat="server" style="font-weight: 700"></asp:Label>
        &nbsp; Exe.Amt :
        <asp:TextBox ID="txtMobExeAmt" runat="server" CssClass="box3" Width="50px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtMobExeAmt" runat="server" 
                                        ControlToValidate="txtMobExeAmt" 
            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtMobExeAmt" runat="server" 
                                        ControlToValidate="txtMobExeAmt" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> </tr>
    <tr>  
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">&nbsp;</td> <td>&nbsp; Half Day</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtHalfDay" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtHalfDay" runat="server" 
                                        ControlToValidate="txtHalfDay" 
            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtHalfDay" runat="server" 
                                        ControlToValidate="txtHalfDay" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp; Addition</td> 
        <td colspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0">&nbsp;
        <asp:TextBox ID="txtAddition" runat="server" CssClass="box3" Width="100px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtAddition" runat="server" 
                                        ControlToValidate="txtAddition" ErrorMessage="*" 
                ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtAddition" runat="server" 
                                        ControlToValidate="txtAddition" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </td></tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; Desigation</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblDesig" runat="server"></asp:Label>
        </td> <td>&nbsp; Sunday</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtSunday" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtSunday" runat="server" 
                                        ControlToValidate="txtSunday" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtSunday" runat="server" 
                                        ControlToValidate="txtSunday" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp; Remarks</td> 
        <td colspan="4" rowspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0" 
            valign="top">&nbsp;
        <asp:TextBox ID="txtRemarks1" runat="server" CssClass="box3" Height="45px" 
            TextMode="MultiLine" Width="250px"></asp:TextBox>
        </td></tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; Grade</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblGrade" runat="server"></asp:Label>
        </td> <td>&nbsp; C-off</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtCoff" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtCoff" runat="server" 
                                        ControlToValidate="txtCoff" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtCoff" runat="server" 
                                        ControlToValidate="txtCoff" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp;</td></tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; Status</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </td> <td>&nbsp; PL</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtPL" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtPL" runat="server" 
                                        ControlToValidate="txtPL" ErrorMessage="*" 
            ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtPL" runat="server" 
                                        ControlToValidate="txtPL" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp;&nbsp;Deduction</td> 
        <td colspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0" 
            valign="top">&nbsp;&nbsp;
        <asp:TextBox ID="txtDeduction" runat="server" CssClass="box3" Width="100px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtDeduction" runat="server" 
                                        ControlToValidate="txtDeduction" ErrorMessage="*" 
                ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtDeduction" runat="server" 
                                        ControlToValidate="txtDeduction" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
                ValidationGroup="A"></asp:RegularExpressionValidator>
        </td></tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; Duty Hrs.</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblDutyHrs" runat="server"></asp:Label>
        </td> <td>&nbsp; Over Time Hrs.</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:TextBox ID="txtOverTimeHrs" runat="server" CssClass="box3" Width="70px">0</asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtOverTimeHrs" runat="server" 
                                        ControlToValidate="txtOverTimeHrs" 
            ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegtxtOverTimeHrs" runat="server" 
                                        ControlToValidate="txtOverTimeHrs" ErrorMessage="*" 
                                        ValidationExpression="^\d{1,15}(\.\d{0,3})?$" 
            ValidationGroup="A"></asp:RegularExpressionValidator>
        </td> <td colspan="2">&nbsp;Remarks</td> 
        <td colspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0" rowspan="2">&nbsp;
        <asp:TextBox ID="txtRemarks2" runat="server" CssClass="box3" Height="45px" 
            TextMode="MultiLine" Width="250px"></asp:TextBox>
            &nbsp;
        </td></tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; Over Time Hrs.</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblEOTHrs" runat="server"></asp:Label>
        </td> <td>&nbsp; Over Time Rate</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblOverTimeRate" runat="server"></asp:Label>
        </td> <td colspan="2">&nbsp;</td> </tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; A/C No.</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblACNo" runat="server"></asp:Label>
        </td> <td>&nbsp;</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">&nbsp;</td> 
        <td colspan="6" rowspan="4" 
            style="border-right-style: solid; border-right-color: #C0C0C0" valign="top">
            <asp:Panel ID="Panel1" runat="server" Height="120px" Width="100%" 
                ScrollBars="Auto">
            
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
DataKeyNames="Id" CssClass="yui-datatable-theme" Width ="99%">
<PagerSettings PageButtonCount="20" />
<Columns>


 <asp:TemplateField HeaderText="SN">
<ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="3%" />                                      
</asp:TemplateField>

<asp:TemplateField HeaderText="Include In">
  <ItemTemplate>
  <asp:Label ID="lblIncludesInId" runat="server" Text='<%#Eval("IncludesIn")%>' Visible="false"></asp:Label>
  <asp:Label ID="lblIncludesIn" runat="server"></asp:Label></ItemTemplate>

    <ItemStyle Width="20%" />

  </asp:TemplateField>
  
<asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" 
    ReadOnly="True" SortExpression="Id" Visible="False">
</asp:BoundField>

  <asp:TemplateField HeaderText="Perticulars" SortExpression="Perticulars">

      <ItemTemplate>
          <asp:Label ID="Label3" runat="server" Text='<%# Bind("Perticulars") %>'></asp:Label>
      </ItemTemplate>
      
      <ItemStyle Width="40%" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Qty" SortExpression="Qty">
  
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
    </ItemTemplate>
    
    
    <ItemStyle Width="13%" HorizontalAlign="Right" />
    
</asp:TemplateField>



<asp:TemplateField HeaderText="Amount" SortExpression="Amount">
  
    <ItemTemplate>
        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
    </ItemTemplate>
   
    
    <ItemStyle Width="12%" HorizontalAlign="Right" />
    
</asp:TemplateField>

  <asp:TemplateField HeaderText="Total" SortExpression="Total">
      <ItemTemplate>
          <asp:Label ID="Label4" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
      </ItemTemplate>
        <ItemStyle Width="12%" HorizontalAlign="Right" />
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
        </td></tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; PF No.</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblPFNo" runat="server"></asp:Label>
        </td> <td>&nbsp;</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">&nbsp;</td> </tr>
    <tr> <td height="25px" style="border-left-style: solid; border-left-color: #C0C0C0">&nbsp; PAN No.</td> 
        <td colspan="2" style="border-right-style: solid; border-right-color: #C0C0C0">:
        <asp:Label ID="lblPANNo" runat="server"></asp:Label>
        </td> <td>&nbsp;</td> <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0">&nbsp;</td> </tr>
    <tr> 
        <td height="25px" 
            style="border-left-style: solid; border-left-color: #C0C0C0; ">&nbsp; Email</td> 
        <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0;">&nbsp;:
        <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </td> <td>&nbsp;</td> 
        <td colspan="2" 
            style="border-right-style: solid; border-right-color: #C0C0C0;">
            &nbsp;</td> </tr>
    <tr> <td height="25px" 
            style="border-left-style: solid; border-left-color: #C0C0C0; border-bottom-style: solid; border-bottom-color: #C0C0C0">&nbsp; Mobile No.</td> 
        <td colspan="2" 
            style="border-bottom-style: solid; border-bottom-color: #C0C0C0; border-right-style: solid; border-right-color: #C0C0C0;">
            :
        <asp:Label ID="lblMobNo" runat="server"></asp:Label>
        </td> <td style="border-bottom-style: solid; border-bottom-color: #C0C0C0;">&nbsp;</td> 
        <td colspan="2" 
            style="border-bottom-style: solid; border-bottom-color: #C0C0C0; border-right-style: solid; border-right-color: #C0C0C0;">
            &nbsp;</td> <td colspan="2" 
            style="border-bottom-style: solid; border-bottom-color: #C0C0C0;">&nbsp;</td> 
        <td 
            
            style="border-bottom-style: solid; border-bottom-color: #C0C0C0; ">
            &nbsp;</td> 
        <td colspan="2" 
            
            style="border-bottom-style: solid; border-bottom-color: #C0C0C0; ">
            &nbsp;</td> 
        <td 
            
            
            style="border-bottom-style: solid; border-bottom-color: #C0C0C0; border-right-style: solid; border-right-color: #C0C0C0;">
            &nbsp;</td></tr>
    <tr> <td align="center" colspan="12" height="30px" valign="middle">
        <asp:Button ID="btnProceed" runat="server" CssClass="redbox" Text="Update" 
            ValidationGroup="A" onclick="btnProceed_Click" />
&nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
            onclick="btnCancel_Click" Text="Cancel" />
        </td></tr>
        
    </table>
     </td>
    </tr>
    </table>
   
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>
