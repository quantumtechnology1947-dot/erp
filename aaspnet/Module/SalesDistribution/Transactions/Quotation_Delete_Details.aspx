<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_Quotation_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr height="21">
      <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<b>Customer  Quotation-Delete</b></td>
    </tr>
        <tr>
            <td>
      <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
        <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
        <HeaderTemplate>
        Customer Details</HeaderTemplate>
        <ContentTemplate>
        
         
         
         <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
    <td 
                                colspan="1" align="left" valign="middle" 
        height="24" width="15%">Qutation No</td>
    <td align="left" height="24" valign="middle" width="85%">
        :<asp:Label ID="LblQuoteNo" runat="server" style="font-weight: 700"></asp:Label>
    </td>
    </tr>
             <tr>
                 <td align="left" colspan="1" height="24" valign="middle" width="15%">
                     Enquiry No
                 </td>
                 <td align="left" height="24" valign="middle" width="25%">
                     :<asp:Label ID="LblEnquiry" runat="server" style="font-weight: 700"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td align="left" colspan="1" height="24" valign="middle" width="15%">
                     Name of Customer&nbsp;&nbsp;&nbsp;</td>
                 <td align="left" height="24" valign="middle" width="25%">
                     :<asp:Label ID="LblName" runat="server" style="font-weight: 700"></asp:Label>
                     <asp:Label ID="Lblpoid" runat="server" Visible="False" style="font-weight: 700"></asp:Label>
                     <asp:Label ID="LblCustId" runat="server" Visible="False" 
                         style="font-weight: 700"></asp:Label>
                 </td>
             </tr>
             <tr>
        <td 
            align="left" valign="top" height="20">Regd. Office Address&#160;</td>
        <td align="left" valign="top" height="25">:<asp:Label ID="LblAddress" 
                runat="server" style="font-weight: 700"></asp:Label></td>
    </tr><tr>
        <td align="left" 
                                valign="middle" height="20" class="style1">&nbsp;</td>
    <td valign="middle" 
                    align="left">&nbsp;</td>
    </tr>
             <tr>
                 <td align="left" class="style1" height="23" valign="middle">
                     &nbsp;</td>
                 <td align="left" valign="middle">
                     <asp:Button ID="BtnCustomerNext" runat="server" CssClass="redbox" 
                         OnClick="BtnCustomerNext_Click" Text="  Next  " />
                     <asp:Button ID="BtnCustomerCancel" runat="server" CssClass="redbox" 
                         OnClick="BtnCustomerCancel_Click" Text="Cancel" />
                 </td>
             </tr>
            </table>
         
         
         
         
         
         
                        </ContentTemplate></cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
            Goods Details</HeaderTemplate>
             <ContentTemplate><table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss"><tr><td>
                 <table align="left" cellpadding="0" cellspacing="0" width="100%">
                     <tr>
                         <td align="left">
                             <br />
                             <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                 AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                                 PageSize="17" Width="60%" 
                                 onpageindexchanging="GridView1_PageIndexChanging">
                                 <Columns>
                                     <asp:TemplateField HeaderText="SN">
                                         <ItemTemplate>
                                             <%# Container.DataItemIndex+1 %>
                                         </ItemTemplate>
                                         <ItemStyle HorizontalAlign="Right" Width="3%" />
                                     </asp:TemplateField>
                                     <asp:BoundField DataField="ItemDesc" HeaderText="Description" 
                                         SortExpression="ItemDesc">
                                         <ItemStyle HorizontalAlign="Left" Width="40%" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="TotalQty" HeaderText="Quantity" 
                                         SortExpression="TotalQty">
                                         <ItemStyle HorizontalAlign="Right" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Symbol" HeaderText="Unit" SortExpression="Unit">
                                         <ItemStyle HorizontalAlign="Center" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate">
                                         <ItemStyle HorizontalAlign="Right" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="Discount" HeaderText="Discount" 
                                         SortExpression="Discount">
                                         <ItemStyle HorizontalAlign="Right" />
                                     </asp:BoundField>
                                 </Columns>
                                 <EmptyDataTemplate>
                                     <table class="fontcss" width="100%">
                                         <tr>
                                             <td align="center">
                                                 <asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                                     Text="No data to display !"> </asp:Label>
                                             </td>
                                         </tr>
                                     </table>
                                 </EmptyDataTemplate>
                             </asp:GridView>
                         </td>
                     </tr>
                     <tr>
                         <td align="left" height="22">
                             <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                                 onclick="Button1_Click" Text=" Next " />
                             <asp:Button ID="Button2" runat="server" CssClass="redbox" 
                                 onclick="Button2_Click" Text="Cancel" />
                         </td>
                     </tr>
                 </table>
                 </td></tr></table>
                        </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
            Terms &amp; Conditions</HeaderTemplate>
             <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="14%" align="left" valign="middle">
                 &nbsp;Payment Terms</td><td colspan="3" align="left" valign="middle" height="22">: 
                     <asp:TextBox ID="TxtPayments" 
                            runat="server" Width="200px" CssClass="box3" ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" valign="middle">
                     &nbsp;P &amp; F</td><td width="36%" align="left" valign="middle" height="22">: 
                         <asp:TextBox ID="TxtPF" 
                            runat="server" CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox></td><td width="14%" align="left" valign="middle">&nbsp;Excise / Service Tax </td><td width="36%" align="left" valign="middle">: 
                     <asp:TextBox ID="TxtExcise" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox></td></tr><tr><td align="left" valign="middle">
                     &nbsp;VAT/CST</td><td align="left" valign="middle" height="22">: 
                         <asp:TextBox 
                         ID="TxtVAT" runat="server" 
                            CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox></td><td align="left" valign="middle">&nbsp;Octroi</td><td align="left" valign="middle">: 
                     <asp:TextBox ID="TxtOctroi" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox></td></tr><tr><td align="left" valign="middle">
                     &nbsp;Warrenty</td><td align="left" valign="middle" height="22">: 
                         <asp:TextBox 
                         ID="TxtWarrenty" runat="server" 
                            CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox></td><td align="left" valign="middle">&nbsp;Insurance</td><td align="left" valign="middle">: 
                     <asp:TextBox ID="TxtInsurance" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox></td></tr><tr><td align="left" valign="middle">
                     &nbsp;Mode of Transport </td><td align="left" valign="middle" height="22">: 
                         <asp:TextBox 
                         ID="TxtTransPort" runat="server" 
                            CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox></td><td align="left" valign="middle">&nbsp;R.R./G.C. Note No.</td><td align="left" valign="middle">: 
                     <asp:TextBox ID="TxtNoteNo" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox></td></tr><tr>
                     <td align="left" valign="middle" height="22">&nbsp;If by motor vehicle,it&#39;s &nbsp;registr. no</td>
                     <td align="left" valign="middle" height="22">: 
                         <asp:TextBox ID="TxtRegdNo" 
                             runat="server" CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox>
                         
                     </td><td align="left" valign="middle">&nbsp;Freight</td>
                     <td align="left" valign="middle">
                         :
                         <asp:TextBox ID="TxtFreight" runat="server" CssClass="box3" ReadOnly="True" 
                             Width="200px"></asp:TextBox>
                        
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top">
                         &nbsp;Due Date&nbsp;&nbsp;</td>
                     <td align="left" valign="middle">
                         :
                         <asp:TextBox ID="TxtDueDate" runat="server" CssClass="box3" ReadOnly="True"
                             Width="200px"></asp:TextBox>
                        <%-- <cc1:CalendarExtender ID="TxtDueDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomRight"
                             Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDueDate">
                         </cc1:CalendarExtender>--%>
                     </td>
                     <td align="left" valign="middle">
                         Validity</td>
                     <td align="right" style="text-align: left" valign="top">
                         :
                         <asp:TextBox ID="Txtvalidity" runat="server" CssClass="box3" Width="200px" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top">
                         Other Charges</td>
                     <td align="left" valign="middle" height="25px">
                         : <asp:TextBox ID="Txtocharges" runat="server" CssClass="box3" Width="200px" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                     
                     <td align="left" valign="middle">
                         Delivery Terms</td>
                     <td align="left" valign="middle" height="25px">
                         :
                        <asp:TextBox ID="TxtDelTerms" runat="server" CssClass="box3" Width="200px" 
                             ReadOnly="True"></asp:TextBox>
           </td>
                 </tr>
                 
                 
                 
                 
                 
                 
                 
                 <tr>
                     <td align="left" valign="top">
                         &nbsp;Remarks</td>
                     <td align="left" colspan="2" valign="top">
                         :
                         <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Height="52px" 
                             TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                     </td>
                     <td align="right" valign="bottom">
                         <asp:Button ID="BtnDelete" runat="server" CssClass="redbox" 
                             OnClick="BtnDelete_Click" OnClientClick="return confirmationDelete()" 
                             Text="Delete" />
                             <asp:Button ID="BtnTermsCancel" runat="server" CssClass="redbox" 
                             OnClick="BtnTermsCancel_Click" Text="Cancel" />
                             <asp:Label ID="lblpo" runat="server" Visible="False" Font-Bold="True" 
                             ForeColor="Red"></asp:Label>
                         &nbsp;</td>
                 </tr>
                 </table>
                        
                        </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    </td>
    </tr>
    </table>
    
    
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

