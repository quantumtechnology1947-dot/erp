<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SalesDistribution_Transactions_CustPO_Delete_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
<script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
    <style type="text/css">
        .style1
        {
            height: 24px;
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
    <p><br /></p><p></p>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
<table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr height="21">
      <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite">&nbsp;<b>Customer  PO-Delete</b></td>
    </tr>
        <tr>
            <td>
      <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
        Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
        <cc1:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
        <HeaderTemplate>
        Customer Details</HeaderTemplate>
        <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
            <td 
                                colspan="2" align="left" valign="middle" height="24">&nbsp;Name of 
                Customer&nbsp;</td>
            <td align="left" height="24" valign="middle">
                :
                <asp:Label ID="LblName" runat="server"></asp:Label>
                <asp:Label ID="Lblpoid" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="LblCustId" runat="server" Visible="False"></asp:Label>
            </td>
            <td align="left" colspan="2" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" height="24" valign="middle">
                &nbsp;</td>
            <td align="left" colspan="2" height="24" valign="middle">
                &nbsp;</td>
            </tr><tr><td align="left" valign="middle">
                Regd. Office Address</td><td align="left" colspan="7" valign="top" rowspan="3">: <asp:Label ID="LblAddress" runat="server"></asp:Label></td></tr>
            <tr>
                <td align="left" valign="middle">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left" valign="middle">
                    &nbsp;</td>
            </tr>
            <tr><td align="left" 
                                valign="middle" class="style1">&nbsp;Enquiry No</td>
                <td valign="middle" 
                    align="left" colspan="3" class="style1">: <asp:Label ID="LblEnquiry" runat="server"></asp:Label></td>
                <td valign="top" align="left" colspan="3" class="style1">
                Quotation No.&nbsp;</td><td valign="top" align="left" class="style1">
                    :
                    <asp:Label ID="lblquoteNo" runat="server"></asp:Label>
            </td></tr><tr><td align="left" valign="middle" height="24" width="14%">&nbsp;PO No</td>
                <td valign="top" colspan="3" width="27%">
                    :
            <asp:TextBox ID="TxtPONo" 
                        runat="server" CssClass="box3" 
                                        Width="200px" ReadOnly="True"></asp:TextBox></td>
                <td height="20" 
                    valign="middle" colspan="3" width="13%">PO Date</td>
                <td valign="top" 
                    height="20" width="46%">
                    :
                <asp:TextBox ID="TxtPODate" runat="server" CssClass="box3" 
                                        Width="80px" ReadOnly="True"></asp:TextBox>
                                        
                                        
                        <%--                <cc1:CalendarExtender ID="TxtPODate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomRight"  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtPODate"></cc1:CalendarExtender>--%>
                        
                        
                        </td></tr><tr><td align="left" height="24" valign="middle">&nbsp;PO Received Date </td>
                <td colspan="3" valign="top">
                    :
                <asp:TextBox ID="TxtPORecDate" runat="server" 
                        CssClass="box3" Width="80px" ReadOnly="True"></asp:TextBox>
                        
                        
          <%--              <cc1:CalendarExtender ID="TxtPORecDate_CalendarExtender" runat="server"  CssClass="cal_Theme2" PopupPosition="BottomRight"  Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtPORecDate"></cc1:CalendarExtender>--%>
                        
                        </td>
                <td height="20" colspan="3" valign="middle">
                    Our Vendor Code</td><td valign="top">: <asp:TextBox ID="TxtVendorCode" 
                        runat="server" CssClass="box3" 
                        Width="200px" ReadOnly="True"></asp:TextBox></td></tr><tr><td align="left" height="20" valign="top">&#160;</td>
                <td colspan="3">&#160;</td><td colspan="3" height="20">&#160;</td><td align="right"><asp:Button ID="BtnCustomerNext" runat="server" CssClass="redbox" 
                        OnClick="BtnCustomerNext_Click" Text="  Next  " />&nbsp;<asp:Button ID="BtnCustomerCancel" runat="server" CssClass="redbox" 
                        OnClick="BtnCustomerCancel_Click" Text="Cancel" /></td></tr></table>
                        </ContentTemplate></cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>
            Goods Details</HeaderTemplate>
             <ContentTemplate><table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss"><tr><td><table width="98%" align="center" cellpadding="0" cellspacing="0"><tr><td height="19" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr>
                 <td align="center" valign="middle"><table align="left" cellpadding="0" 
                         cellspacing="0" style="width: 952px"><tr><td align="left">
                         <br />
                         <asp:GridView ID="GridView1" runat="server" AllowPaging="True"  PageSize="20" 
                             AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                             Width="85%" onpageindexchanging="GridView1_PageIndexChanging">
                             <Columns>
                              <asp:TemplateField HeaderText="SN"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
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
                                 <asp:BoundField DataField="Discount" HeaderText="Discount(%)" SortExpression="Discount">
                                     <ItemStyle HorizontalAlign="Right" Width="10%" />
                                 </asp:BoundField>
                                 
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'> </asp:Label>
                                            </ItemTemplate>                                          
                                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        </asp:TemplateField>       
                                 
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
                         </td></tr></table></td></tr></table></td></tr></table></td></tr></table>
                        </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
            Terms &amp; Conditions</HeaderTemplate>
             <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="14%" align="left" valign="middle">
                 &nbsp;Payment Terms</td><td colspan="3" align="left" valign="top" height="22">: <asp:TextBox ID="TxtPayments" 
                            runat="server" Width="200px" CssClass="box3" ReadOnly="True"></asp:TextBox><cc1:DropDownExtender ID="TxtPayments_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtPayments"></cc1:DropDownExtender></td></tr><tr><td align="left" valign="middle">
                     &nbsp;P &amp; F</td><td width="36%" align="left" valign="top" height="22">: <asp:TextBox ID="TxtPF" 
                            runat="server" CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtPF_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtPF"></cc1:DropDownExtender></td><td width="14%" align="left" valign="middle">&nbsp;Excise / Service Tax </td><td width="36%" align="left" valign="middle">: 
                     <asp:TextBox ID="TxtExcise" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtExcise_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtExcise"></cc1:DropDownExtender></td></tr><tr><td align="left" valign="middle">
                     &nbsp;VAT</td><td align="left" valign="top" height="22">: <asp:TextBox 
                         ID="TxtVAT" runat="server" 
                            CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtVAT_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtVAT"></cc1:DropDownExtender></td><td align="left" valign="middle">&nbsp;Octroi</td><td align="left" valign="middle">: 
                     <asp:TextBox ID="TxtOctroi" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtOctroi_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtOctroi"></cc1:DropDownExtender></td></tr><tr><td align="left" valign="middle">
                     &nbsp;Warrenty</td><td align="left" valign="top" height="22">: <asp:TextBox 
                         ID="TxtWarrenty" runat="server" 
                            CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtWarrenty_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtWarrenty"></cc1:DropDownExtender></td><td align="left" valign="middle">&nbsp;Insurance</td><td align="left" valign="middle">: 
                     <asp:TextBox ID="TxtInsurance" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtInsurance_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtInsurance"></cc1:DropDownExtender></td></tr><tr><td align="left" valign="middle">
                     &nbsp;Mode of Transport </td><td align="left" valign="top" height="22">: <asp:TextBox 
                         ID="TxtTransPort" runat="server" 
                            CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtTransPort_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtTransPort"></cc1:DropDownExtender></td><td align="left" valign="middle">&nbsp;R.R./G.C. Note No.</td><td align="left" valign="middle">: 
                     <asp:TextBox ID="TxtNoteNo" runat="server" CssClass="box3" ReadOnly="True" 
                         Width="200px"></asp:TextBox><cc1:DropDownExtender ID="TxtNoteNo_DropDownExtender" runat="server" 
                            DynamicServicePath="" Enabled="True" TargetControlID="TxtNoteNo"></cc1:DropDownExtender></td></tr><tr>
                     <td align="left" valign="middle" height="22">&nbsp;If by motor vehicle, it&#39;s &nbsp;registr. 
                         no: 
                     </td><td align="left" valign="middle" height="22">: <asp:TextBox ID="TxtRegdNo" 
                             runat="server" CssClass="box3" ReadOnly="True" Width="200px"></asp:TextBox>
                         <cc1:DropDownExtender ID="TxtRegdNo_DropDownExtender" runat="server" 
                             DynamicServicePath="" Enabled="True" TargetControlID="TxtRegdNo">
                         </cc1:DropDownExtender>
                     </td><td align="left" valign="middle">&nbsp;Freight</td>
                     <td align="left" valign="middle">
                         :
                         <asp:TextBox ID="TxtFreight" runat="server" CssClass="box3" ReadOnly="True" 
                             Width="200px"></asp:TextBox>
                         <cc1:DropDownExtender ID="TxtFreight_DropDownExtender" runat="server" 
                             DynamicServicePath="" Enabled="True" TargetControlID="TxtFreight">
                         </cc1:DropDownExtender>
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="middle" class="style1">
                         CST</td>
                     <td align="left" valign="top" class="style1">
                         :
                         <asp:TextBox ID="Txtcst" runat="server" Width="200px" CssClass="box3" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                     <td align="left" valign="middle" class="style1">
                         Validity</td>
                     <td align="right" style="text-align: left" valign="top" class="style1">
                         :
                         <asp:TextBox ID="Txtvalidity" runat="server" Width="200px" CssClass="box3" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top" class="style1">
                         Other Charges</td>
                     <td align="left" valign="top" class="style1">
                         :
                         <asp:TextBox ID="Txtocharges" runat="server" Width="200px" CssClass="box3" 
                             ReadOnly="True"></asp:TextBox>
                     </td>
                     <td align="left" valign="middle" class="style1">
                         </td>
                     <td align="right" valign="top" class="style1">
                         </td>
                 </tr>
                 <tr>
                     <td align="left" valign="top">
                         &nbsp;Remarks</td>
                     <td align="left" colspan="2" valign="top">
                         :
                         <asp:TextBox ID="TxtRemarks" runat="server" CssClass="box3" Height="65px" 
                             TextMode="MultiLine" Width="400px" ReadOnly="True"></asp:TextBox>
                     </td>
                     <td align="center" valign="bottom">
                         <asp:Button ID="BtnDelete" runat="server" CssClass="redbox" 
                             OnClick="BtnDelete_Click" OnClientClick="return confirmationDelete()" 
                             Text="Delete" />
                         &nbsp;<asp:Button ID="BtnTermsCancel" runat="server" CssClass="redbox" 
                             OnClick="BtnTermsCancel_Click" Text="Cancel" />
                     </td>
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

