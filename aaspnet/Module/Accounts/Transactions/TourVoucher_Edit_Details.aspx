<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_Accounts_Transactions_TourVoucher_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    
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
<table align="left" cellpadding="0" cellspacing="0" width="100%">
      <tr>
            <td align="left" height="21" style="background:url(../../../images/hdbg.JPG)" height="21" 
                class="fontcsswhite">
                <b>&nbsp;Tour Voucher Edit Details </b></td>
               
        </tr>
        
 <tr>
 <td>
     <table class="style2">
         <tr>
             <td width="5%">
                 </td>
             <td width="10%">
                 </td>
             <td width="25%">
                 </td>
             <td width="2%">
                 &nbsp;</td>
             <td width="20%">
                 </td>
             <td width="22%">
                 &nbsp;</td>
             <td width="5%">
                 </td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Employee Name</td>
             <td>
                 :
                 <asp:Label ID="lblEmpName" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:Label ID="lblWONoBGGroup" runat="server"></asp:Label>
             </td>
             <td>
                 :
                 <asp:Label ID="lblWONoBGGroup1" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Project Name</td>
             <td>
                 :
                 <asp:Label ID="lblProjectName" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Place of&nbsp; Tour</td>
             <td>
                 :
                 <asp:Label ID="lblPlaceOfTour" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Tour Start Date</td>
             <td>
                 :&nbsp;<asp:Label ID="lblSDate" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 Time :&nbsp; <asp:Label ID="lblSTime" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Tour End Date</td>
             <td>
                 :
                 <asp:Label ID="lblEDate" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 Time :&nbsp; <asp:Label ID="lblETime" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 No of Days</td>
             <td>
                 :
                 <asp:Label ID="lblNoOfDays" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Name &amp; Address of Accommodation service provider</td>
             <td>
                 :
                 <asp:Label ID="lblNameAndAddress" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Contact Person</td>
             <td>
                 :
                 <asp:Label ID="lblContactPerson" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Contact No</td>
             <td>
                 :
                 <asp:Label ID="lblContactNo" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Email </td>
             <td>
                 :
                 <asp:Label ID="lblEmail" runat="server"></asp:Label>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         </table>
 </td>
 </tr>
 
<tr>
<td height="10px">
    &nbsp;</td>
 </tr>
<tr>
<td height="10px">
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  Width="99%" >
            <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"> 
            <HeaderTemplate>Advance Details   </HeaderTemplate>
            <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto" Width="95%"  Height="210px">
             <asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
        Width="100%" AutoGenerateColumns="False" DataKeyNames="TVADId" ShowFooter="True" >
        
        <PagerSettings PageButtonCount="40" />
        <Columns>
        
                
            <asp:TemplateField HeaderText="SN">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1%>
            </ItemTemplate>
            <ItemStyle Width="2%"  HorizontalAlign="Right"/>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="TVADId" Visible="False">
            <ItemTemplate>
                <asp:Label ID="lblTVADId" runat="server" Text='<%# Bind("TVADId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
            </asp:TemplateField> 
             
             <asp:TemplateField HeaderText="TDMId" Visible="False">
            <ItemTemplate>
                <asp:Label ID="lblTDMId" runat="server" Text='<%# Bind("TDMId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
            </asp:TemplateField>          
                            
            <asp:TemplateField HeaderText="Terms">
            <ItemTemplate>
            <asp:Label ID="lblTerms" runat="server" Text='<%# Bind("Terms") %>' ></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
            <asp:Label ID="lblADTotalAmt" runat="server" Text="TotalAmount : " ></asp:Label>
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" Font-Bold="True" />         
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>          
                <asp:Label ID="lblADAmount" runat="server" Text='<%# Bind("Amount") %>' ></asp:Label>
            </ItemTemplate>
             <FooterTemplate>
        <asp:Label ID="lblADTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' ></asp:Label>
        </FooterTemplate>
        <FooterStyle HorizontalAlign="Right" Font-Bold="True" /> 
            
            <ItemStyle HorizontalAlign="Right" Width="10%" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>          
                <asp:Label ID="lblADRemarks" runat="server" Text='<%# Bind("Remarks") %>' ></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:TemplateField>                 
                    
                        
             <asp:TemplateField HeaderText="Sanctioned Amount">
            <ItemTemplate>
            <asp:TextBox ID="txtAmount" CssClass="box3"  Text='<%# Bind("SanctionedAmount") %>'  Width="85%" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqtxtAmount" runat="server" 
            ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="A">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegtxtAmount" runat="server" 
             ValidationGroup="A" ControlToValidate="txtAmount" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="15%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>
            <asp:TextBox ID="txtRemarks" CssClass="box3"   Text='<%# Bind("SanctionedRemarks") %>'  Width="98%" runat="server">
            </asp:TextBox>        
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="20%" />
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
            </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">              
            <HeaderTemplate> Advance Trans. To</HeaderTemplate>
            <ContentTemplate>
            <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto" Width="95%" Height="210px">
<asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
        Width="100%" AutoGenerateColumns="False" DataKeyNames="TVTId" PageSize="3" 
                    ShowFooter="True">
        <PagerSettings PageButtonCount="40" />
        <Columns>
        
        
            <asp:TemplateField HeaderText="SN">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1%>
            </ItemTemplate>
            <ItemStyle Width="2%"  HorizontalAlign="Right"/>
            </asp:TemplateField> 
                
                   <asp:TemplateField HeaderText="TVADId" Visible="False">
            <ItemTemplate>
                <asp:Label ID="lblTVTId" runat="server" Text='<%# Bind("TVTId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
            </asp:TemplateField> 
                                        
                <asp:TemplateField HeaderText="TATId" Visible ="False">
                <ItemTemplate>
                <asp:Label ID="lblTATId" Text='<%# Bind("TATId") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="2%" /> 
                </asp:TemplateField>
                           
            
                    <asp:TemplateField HeaderText="Employee Name">
                    <ItemTemplate>
                    <asp:Label ID="lblATEmpName" Text='<%# Bind("EmpName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                     
                    <FooterTemplate>
                    <asp:Label ID="lblATTotalAmt" runat="server" Text="TotalAmount : " ></asp:Label>
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Right" Font-Bold="True" />   
                    
                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                    </asp:TemplateField>
            
            
                     
             <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
                 <asp:Label ID="lblATAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>     
            </ItemTemplate> 
             <FooterTemplate>
           <asp:Label ID="lblATTotalAmount" runat="server" Text='<%# Bind("TotalAmount") %>' ></asp:Label>
            </FooterTemplate>
            <FooterStyle HorizontalAlign="Right" Font-Bold="True" />  
            
            <ItemStyle HorizontalAlign="Right" Width="10%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>
            <asp:Label ID="lblATRemark" Text='<%# Bind("Remarks") %>' runat="server"></asp:Label>     
            </ItemTemplate>                   
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:TemplateField>           
            
             <asp:TemplateField HeaderText="Sanctioned Amount">
            <ItemTemplate>
            <asp:TextBox ID="txtATAmount" CssClass="box3" Text='<%# Bind("SanctionedAmount") %>' Width="85%" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqtxtATAmount" runat="server" 
            ControlToValidate="txtATAmount" ErrorMessage="*" ValidationGroup="A">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegtxtATAmount" runat="server" 
             ValidationGroup="A" ControlToValidate="txtATAmount" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="15%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>
            <asp:TextBox ID="txtATRemarks" CssClass="box3"   Text='<%# Bind("SanctionedRemarks") %>'  Width="90%" runat="server">
            </asp:TextBox>            
            
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" Width="20%" />
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
            </ContentTemplate>
            </cc1:TabPanel>
            </cc1:TabContainer>
            </td>
 </tr>
<tr>
<td height="10px">
    &nbsp;</td>
 </tr>
<tr>
<td height="10px">
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblTAmt" runat="server" style="font-weight: 700" 
        Text="Total Advance Amt :"></asp:Label>
    <asp:Label ID="lblTAmt1" runat="server" style="font-weight: 700" Text="0"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblTSAmt" runat="server" style="font-weight: 700" 
        Text="Total Sanctioned Amount : "></asp:Label>
    <asp:Label ID="lblTSAmt1" runat="server" style="font-weight: 700" Text="0"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
        Text="Amt. Bal Towards Company : "></asp:Label>
    <asp:TextBox ID="txtAmtBalTowardsCompany" runat="server" CssClass="box3" 
        Width="100px" ValidationGroup="A" Enabled="False">0</asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqtxtAmtBalTowardsCompany" runat="server" 
            ControlToValidate="txtAmtBalTowardsCompany" ErrorMessage="*" ValidationGroup="A">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegtxtAmtBalTowardsCompany" runat="server" 
             ValidationGroup="A" ControlToValidate="txtAmtBalTowardsCompany" ErrorMessage="*" 
             ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
        Text="Amt. Bal Towards Employee : "></asp:Label>
    <asp:TextBox ID="txtAmtBalTowardsEmployee" runat="server" CssClass="box3" 
        Width="100px" ValidationGroup="A" Enabled="False">0</asp:TextBox>
        <asp:RequiredFieldValidator ID="ReqtxtAmtBalTowardsEmployee" runat="server" 
            ControlToValidate="txtAmtBalTowardsEmployee" ErrorMessage="*" ValidationGroup="A">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegtxtAmtBalTowardsEmployee" runat="server" 
             ValidationGroup="A" ControlToValidate="txtAmtBalTowardsEmployee" ErrorMessage="*"
              ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
    </td>
 </tr>
<tr>
<td align="center" height="10px" valign="middle">
    &nbsp;</td>
 </tr>

 
<tr>
<td align="center" height="25px" valign="middle">
    <asp:Button ID="btnSum" runat="server" onclick="btnSum_Click" 
        Text="Calculate" CssClass="redbox" />
    &nbsp;
    <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="redbox" 
        ValidationGroup="A" OnClientClick="return confirmationUpdate();"
        onclick="btnSubmit_Click" />
 &nbsp;
    <asp:Button ID="btnCancel" runat="server" CssClass="redbox" 
        onclick="btnCancel_Click" Text="Cancel" />
 </td>
 </tr>

 
    </table>




</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

