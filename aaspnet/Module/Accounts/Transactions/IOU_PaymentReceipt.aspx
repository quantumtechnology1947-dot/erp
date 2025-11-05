<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_IOU_PaymentReceipt, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
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
 <table cellpadding="2" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;IOU:Payment/Receipt</b></td>
        </tr>
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    AutoPostBack="true"
                    Width="100%" >
                    <cc1:TabPanel runat="server" HeaderText="Payment" ID="Add">  
                        <ContentTemplate>
                        
                        <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server"         Height="430px"><asp:GridView ID="GridView2" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" DataKeyNames="Id" 
                    OnPageIndexChanging="GridView2_PageIndexChanging" 
                        onselectedindexchanged="GridView2_SelectedIndexChanged" 
         Width="100%" PageSize="20" 
         onrowcancelingedit="GridView2_RowCancelingEdit" 
         onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" 
         onrowcommand="GridView2_RowCommand" onrowdeleting="GridView2_RowDeleting"><Columns><asp:TemplateField ShowHeader="False"><EditItemTemplate><asp:LinkButton ID="LinkButton3" ValidationGroup="B" OnClientClick="return confirmationUpdate();"  runat="server"  CausesValidation="True" 
                                        CommandName="Update" Text="Update"></asp:LinkButton>&#160;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                        CommandName="Cancel" Text="Cancel"></asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="LinkButton1" OnClientClick="return confirmationUpdate();" runat="server" CausesValidation="False" 
                                        CommandName="Edit" Text="Edit"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="5%" /></asp:TemplateField><asp:TemplateField ShowHeader="False"><ItemTemplate><asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationDelete();"  runat="server" CausesValidation="False" 
                                        CommandName="Delete" Text="Delete"></asp:LinkButton></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" /></asp:TemplateField><asp:TemplateField HeaderText="SN" ><EditItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label></EditItemTemplate><ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle></asp:TemplateField><asp:TemplateField HeaderText="Date"><ItemTemplate><asp:Label ID="lblDate" Text='<%# Eval("PaymentDate") %>' runat="server"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Employee Name"><ItemTemplate><asp:Label ID="lblEmpName" Text='<%# Eval("EmpName") %>' runat="server"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="15%" /></asp:TemplateField><asp:TemplateField HeaderText="Amount"><EditItemTemplate><asp:TextBox ID="TextBox2"  Width="80px" CssClass="box3" Text='<%# Eval("Amount") %>' runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="ReqAmt2" runat="server" 
                                      ControlToValidate="TextBox2" ErrorMessage="*" ValidationGroup="B"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpValAmount" runat="server" 
                                                 ValidationGroup="B" ControlToValidate="TextBox2" ErrorMessage="*" 
                                                 ValidationExpression="^\d{1,15}(\.\d{0,3})?$"> </asp:RegularExpressionValidator></EditItemTemplate><ItemTemplate><asp:Label ID="lblAmt" Text='<%# Eval("Amount") %>' runat="server"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%" /></asp:TemplateField><asp:TemplateField HeaderText="Reason"><EditItemTemplate><asp:Label ID="lblReason2" Visible="false" Text='<%# Eval("ReasonId") %>' runat="server"></asp:Label><asp:DropDownList ID="DrpReason2" DataValueField="Id" DataTextField="Terms" DataSourceID="SqlDataSource1"   CssClass="box3" Width="92%" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqReason2" runat="server" 
                                                ControlToValidate="DrpReason2" InitialValue="Select" ErrorMessage="*" ValidationGroup="B"> </asp:RequiredFieldValidator></EditItemTemplate><ItemTemplate><asp:Label ID="lblReason" Text='<%# Eval("reason") %>' runat="server"></asp:Label></ItemTemplate><ItemStyle HorizontalAlign="Left" Width="10%" /></asp:TemplateField><asp:TemplateField HeaderText="Narration"><EditItemTemplate><asp:TextBox ID="TextBox4" Width="100%" CssClass="box3" Text='<%# Eval("Narration") %>' runat="server"></asp:TextBox></EditItemTemplate><ItemTemplate><asp:Label ID="lblNarration" Text='<%# Eval("Narration") %>'  runat="server"></asp:Label></ItemTemplate><ItemStyle Width="10%" /></asp:TemplateField>
              <asp:TemplateField HeaderText="Authorize">
              <ItemTemplate>
              <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" 
                        oncheckedchanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                        
                        <EditItemTemplate>
                        <asp:Label ID="lblAuth" Visible="false" Text='<%# Eval("Authorized") %>' runat="server"></asp:Label>
                        <asp:CheckBox ID="CheckBox1"  runat="server" />
                        <asp:CheckBox ID="CheckBox2"  runat="server" />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                        
                        </Columns>
                        
                        <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate><PagerSettings PageButtonCount="40" /></asp:GridView></asp:Panel>
                       </ContentTemplate></cc1:TabPanel>
                    <cc1:TabPanel ID="View" runat="server" HeaderText="Receipt">
                            
                        <ContentTemplate>
                        <asp:Panel ID="Panel2" ScrollBars="Auto"     Height="430px" runat="server">
                        <asp:GridView ID="GridView1" 
                        runat="server" 
                    CssClass="yui-datatable-theme" AutoGenerateColumns="False" DataKeyNames="IdR" 
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                         
         Width="100%" PageSize="20"  AllowPaging="True"
         onrowcancelingedit="GridView1_RowCancelingEdit" 
         onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
         onrowcommand="GridView1_RowCommand" >
                             
                             <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                    
                                    <asp:LinkButton ID="LinkButton1"  Visible="false"  runat="server" Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" ValidationGroup="B1" OnClientClick="return confirmationUpdate();" 
                                    runat="server"  CausesValidation="True"  CommandName="Update" Text="Update">
                                    </asp:LinkButton>&#160;
                                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel">
                                    </asp:LinkButton>

                                    </EditItemTemplate>

                                    <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirmationUpdate();" 
                                    runat="server" CausesValidation="False" 
                                    CommandName="Edit" Text="Edit">
                                    </asp:LinkButton>

                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center" Width="6%" />
                                    </asp:TemplateField>
                                               

                                    <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationDelete();" 
                                     runat="server" CausesValidation="False" 
                                    CommandName="del" Text="Delete">
                                    </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                    </asp:TemplateField>
                                                     
                                                                     
                                    <asp:TemplateField HeaderText="SN">
                                    <EditItemTemplate>
                                    <asp:Label ID="lblIdR" runat="server" Text='<%# Bind("IdR") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblIdR" runat="server" Text='<%# Bind("IdR") %>'></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" />
                                    </asp:TemplateField>

                                                        
                                    <asp:TemplateField HeaderText="Pay. Date">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPaymentDateR" Text='<%# Eval("PaymentDateR") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                    </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                    <asp:Label ID="lblEmpNameR" Text='<%# Eval("EmpNameR") %>' runat="server"></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Reason">
                                    <ItemTemplate>                                
                                      <asp:Label ID="lblReasonR" Text='<%# Eval("ReasonR") %>' runat="server"></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Left" Width="10%" />
                                      </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Narration">
                                   
                                    <ItemTemplate>
                                    <asp:Label ID="lblNarrationR" Text='<%# Eval("NarrationR") %>'  runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                    <asp:Label ID="lblAmountR" Text='<%# Eval("AmountR") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" Width="4%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Authoriz" Visible="False">
                                    <EditItemTemplate>
                                    <asp:Label ID="lblAuthoR" runat="server" Text='<%# Bind("AuthorizedR") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                    <asp:Label ID="lblAuthoR" runat="server" Text='<%# Bind("AuthorizedR") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />                                    
                                    </asp:TemplateField>
                                    
                                    
                                    
                                    
                                    <asp:TemplateField HeaderText="Rec. Amt">                                                                                                        
                                    <ItemTemplate>
                                    <asp:Label ID="lblRecivedAmtR" Visible="true" Text='<%# Eval("RecivedAmtR") %>' runat="server"> </asp:Label>
                                    <asp:TextBox ID="txtRecivedAmtR"  CssClass="box3" Text='<%# Eval("RecivedAmtR") %>' 
                                    Visible="true" Width="75%" ValidationGroup="A1" runat="server">
                                    </asp:TextBox>
                                    </ItemTemplate>
                                    
                                    <EditItemTemplate>  
                                    <asp:Label ID="lblRecivedAmtR" Visible="true"  runat="server"> </asp:Label>
                                                                      
                                     <asp:TextBox ID="txtRecivedAmtR"  CssClass="box3"  
                                    Visible="true" Width="75%" ValidationGroup="A1" runat="server">
                                    </asp:TextBox>
                                    
                                    
                                    <asp:TextBox ID="txtRecivedAmtR1" Text='<%# Eval("RecivedAmtR") %>' CssClass="box3" Width="75%" 
                                       Visible ="true" runat="server"> 
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqtxtRecivedAmtR1" runat="server" 
                                    ControlToValidate="txtRecivedAmtR1"  ErrorMessage="*" ValidationGroup="B1"> 
                                    </asp:RequiredFieldValidator>
                                    
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  
                                    ValidationGroup="B1" ControlToValidate="txtRecivedAmtR1" ErrorMessage="*"
                                    ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
                                    </asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                   
                                    
                                    <ItemStyle HorizontalAlign="Left" Width="6%" />
                                    </asp:TemplateField>
                                    
                                    
                                    
                                                                        
                                    <asp:TemplateField HeaderText=" Receipt Date">
                                    <ItemTemplate>
                                    <asp:Label ID="lblReceiptDate" runat="server" Text='<%# Eval("ReceiptDateR") %>'></asp:Label>
                                    <asp:TextBox ID="txtReceiptDate" runat="server" CssClass="box3" ValidationGroup="A1" 
                                     Width="75%" Visible="True"> 
                                    </asp:TextBox>
                                    
                                    <cc1:CalendarExtender ID="ReceiptDate_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtReceiptDate">
                                    </cc1:CalendarExtender>
                                   
                                    <asp:RegularExpressionValidator ID="RegReceiptDate" ValidationGroup="A1" runat="server" 
                                    ControlToValidate="txtReceiptDate" ErrorMessage="*"
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"> 
                                    </asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                    
                                    <EditItemTemplate>
                                    
                                     <asp:TextBox ID="txtReceiptDate" runat="server" CssClass="box3" ValidationGroup="A1" 
                                     Width="75%" Visible="True"> 
                                    </asp:TextBox>
                                    
                                    
                                     <asp:TextBox ID="txtReceiptDate1" runat="server" CssClass="box3" ValidationGroup="B1"
                                    Width="75%" Visible="true" Text='<%# Eval("ReceiptDateR") %>'> </asp:TextBox>
                                    <cc1:CalendarExtender ID="ReceiptDate1_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtReceiptDate1">
                                    </cc1:CalendarExtender>
                                   
                                    <asp:RegularExpressionValidator ID="RegtxtReceiptDate1" ValidationGroup="B1" runat="server" 
                                    ControlToValidate="txtReceiptDate1" ErrorMessage="*"
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"> 
                                    </asp:RegularExpressionValidator>
                                    
                                    </EditItemTemplate>
                                    
                                    
                                    <ItemStyle HorizontalAlign="Left" Width="7%" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                    <asp:Button ID="btnAddReceipt" CssClass="redbox" Visible="false" CommandName="Add" 
                                    OnClientClick="return confirmationAdd();" ValidationGroup="A1" runat="server" Text="Add" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="DIdR" Visible ="False">
                                    <EditItemTemplate>
                                    <asp:Label ID="lblDIdR" runat="server" Text='<%# Bind("DIdR") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblDIdR" runat="server" Text='<%# Bind("DIdR") %>'></asp:Label>
                                    </ItemTemplate><ItemStyle HorizontalAlign="Center" Width="3%" />
                                    </asp:TemplateField>
                                    
                                    
                                    </Columns>
                                    
                                    <EmptyDataTemplate>
                                    <table width="100%" class="fontcss"><tr><td align="center">
                                    <asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon">
                                    </asp:Label>
                                    </td>
                                    </tr>
                                    </table>
                                    </EmptyDataTemplate>
                                    
                                    <PagerSettings PageButtonCount="40" />
                                    </asp:GridView>
                                    </asp:Panel>
                           </ContentTemplate></cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>"
         ProviderName="System.Data.SqlClient" 
         SelectCommand="SELECT * FROM [tblACC_IOU_Reasons]"></asp:SqlDataSource>
        </tr>
        </table>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

