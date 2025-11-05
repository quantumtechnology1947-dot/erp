<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_TourIntimation_Edit_Details, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="TimePicker" namespace="MKB.TimePicker" tagprefix="MKB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />   
    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
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
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
            <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite">
            <b>&nbsp;Tour Intimation Edit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                TI No&nbsp; :&nbsp; </b>
                <asp:Label ID="LblTINo" runat="server" Font-Bold="True"></asp:Label>
            </td>
    </tr>
 <tr>
 <td>
     <table class="style2">
         <tr>
             <td width="2%">
                 </td>
             <td width="10%">
                 </td>
             <td width="20%" colspan="2">
                 </td>
             <td width="2%">
                 &nbsp;</td>
             <td width="18%">
                 </td>
             <td width="30%" colspan="3">
                 &nbsp;</td>
             <td width="2%">
                 </td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Employee Name</td>
             <td colspan="2">
                 :<asp:TextBox ID="TextEmpName" runat="server" CssClass="box3" 
                     Text='<%# Eval("EmpName") %>' Width="90%"></asp:TextBox>
                 <cc1:AutoCompleteExtender ID="Txt_AutoCompleteExtender" runat="server" 
                     CompletionInterval="100" CompletionListCssClass="almt" 
                     CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                     CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                     EnableViewState="true" FirstRowSelected="True" MinimumPrefixLength="1" 
                     ServiceMethod="GetCompletionList" ServicePath="" 
                     ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TextEmpName" 
                     UseContextKey="True">
                 </cc1:AutoCompleteExtender>
                 <asp:RequiredFieldValidator ID="ReqTextEmpName" runat="server" 
                     ControlToValidate="TextEmpName" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:RadioButtonList ID="RadioButtonWONoGroup" runat="server" 
                     AutoPostBack="True" 
                     onselectedindexchanged="RadioButtonWONoGroup_SelectedIndexChanged" 
                     RepeatDirection="Horizontal">
                     <asp:ListItem Selected="True" Value="0">WO No</asp:ListItem>
                     <asp:ListItem Value="1"> BG Group</asp:ListItem>
                 </asp:RadioButtonList>
             </td>
             <td colspan="3">
                 :<asp:TextBox ID="txtWONo" runat="server" CssClass="box3"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldtxtWONo" runat="server" 
                     ControlToValidate="txtWONo" ErrorMessage="*" ValidationGroup="B">
                 </asp:RequiredFieldValidator>
                 <asp:DropDownList ID="drpGroup" runat="server">
                 </asp:DropDownList>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Project Name</td>
             <td colspan="2">
                 :<asp:TextBox ID="txtProjectName" runat="server" CssClass="box3" Width="90%"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqtxtProjectName" runat="server" 
                     ControlToValidate="txtProjectName" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Place of&nbsp; Tour</td>
             <td colspan="3">
                 :<asp:DropDownList ID="ddlPlaceOfTourCountry" runat="server" 
                     AutoPostBack="True" CssClass="box3" 
                     onselectedindexchanged="ddlPlaceOfTourCountry_SelectedIndexChanged">
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="PlaceOfTourCountry" runat="server" 
                     ControlToValidate="ddlPlaceOfTourCountry" ErrorMessage="*" 
                     InitialValue="Select" ValidationGroup="B"></asp:RequiredFieldValidator>
                 <asp:DropDownList ID="ddlPlaceOfTourState" runat="server" AutoPostBack="True" 
                     CssClass="box3" 
                     onselectedindexchanged="ddlPlaceOfTourState_SelectedIndexChanged">
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="PlaceOfTourState" runat="server" 
                     ControlToValidate="ddlPlaceOfTourState" ErrorMessage="*" InitialValue="Select" 
                     ValidationGroup="B"></asp:RequiredFieldValidator>
                 <asp:DropDownList ID="ddlPlaceOfTourCity" runat="server" CssClass="box3">
                 </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="PlaceOfTourCity" runat="server" 
                     ControlToValidate="ddlPlaceOfTourCity" ErrorMessage="*" InitialValue="Select" 
                     ValidationGroup="B"></asp:RequiredFieldValidator>
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
                 :<asp:TextBox ID="textStartDate" runat="server" CssClass="box3" Width="70px"></asp:TextBox>
                 <cc1:CalendarExtender ID="textStartDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                     Enabled="True" Format="dd-MM-yyyy" TargetControlID="textStartDate">
                 </cc1:CalendarExtender>
                 <asp:RequiredFieldValidator ID="ReqtextStartDate" runat="server" 
                     ControlToValidate="textStartDate" ErrorMessage="*" ValidationGroup="B">
                 </asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegtextStartDate" runat="server" 
                     ControlToValidate="textStartDate" ErrorMessage="*" 
                     ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                     ValidationGroup="B">
                 </asp:RegularExpressionValidator>
                 &nbsp;Time :</td>
             <td>
                 <MKB:TimeSelector ID="TimeSelector1" runat="server" AmPm="AM" 
                     MinuteIncrement="1">
                 </MKB:TimeSelector>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Tour End Date</td>
             <td>
                 :<asp:TextBox ID="textEndDate" runat="server" CssClass="box3" Width="70px"></asp:TextBox>
                 <cc1:CalendarExtender ID="textEndDate_CalendarExtender0" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                     Enabled="True" Format="dd-MM-yyyy" TargetControlID="textEndDate">
                 </cc1:CalendarExtender>
                 <asp:RequiredFieldValidator ID="ReqtextEndDate" runat="server" 
                     ControlToValidate="textEndDate" ErrorMessage="*" ValidationGroup="B">
                 </asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegtextEndDate" runat="server" 
                     ControlToValidate="textEndDate" ErrorMessage="*" 
                     ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                     ValidationGroup="B">
                 </asp:RegularExpressionValidator>
                 &nbsp;</td>
             <td>
                 Time :</td>
             <td>
                 <MKB:TimeSelector ID="TimeSelector2" runat="server" AmPm="AM" 
                     MinuteIncrement="1">
                 </MKB:TimeSelector>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 No of Days</td>
             <td colspan="2">
                 :<asp:TextBox ID="txtNoOfDays" runat="server" CssClass="box3"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqNoOfDays" runat="server" 
                     ControlToValidate="txtNoOfDays" ErrorMessage="*" ValidationGroup="B">
                     </asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegtxtNoOfDays" runat="server" 
             ValidationGroup="B" ControlToValidate="txtNoOfDays" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Name &amp; Address of Accommodation service provider</td>
             <td colspan="3">
                 :<asp:TextBox ID="txtNameAndAddress" runat="server" CssClass="box3" TextMode="MultiLine" 
                     Width="90%" Height="30px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqtxtNameAndAddress" runat="server" 
                     ControlToValidate="txtNameAndAddress" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Contact Person</td>
             <td colspan="2">
                 :<asp:TextBox ID="txtContactPerson" runat="server" CssClass="box3" Width="90%"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqtxtContactPerson" runat="server" 
                     ControlToValidate="txtContactPerson" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 Contact No</td>
             <td colspan="3">
                 :<asp:TextBox ID="txtContactNo" runat="server" CssClass="box3" Width="90%"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="ReqtxtContactNo" runat="server" 
                     ControlToValidate="txtContactNo" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 Email </td>
             <td colspan="2">
                 :<asp:TextBox ID="txtEmail" runat="server" CssClass="box3" Width="75%"></asp:TextBox>
             </td>
             <td>
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
             <td colspan="3">
                 &nbsp;</td>
             <td>
                 &nbsp;</td>
         </tr>
         </table>
 </td>
 </tr>
  <tr>
 <td height="15px">
 </td>
 </tr>
<tr>
            <td>
            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="99%" >
            <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1"> 
            <HeaderTemplate>Advance Details  </HeaderTemplate>
            <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="95%"  Height="230px">
<asp:GridView ID="GridView2" runat="server" CssClass="yui-datatable-theme" 
        Width="100%" AutoGenerateColumns="False" DataKeyNames="Id" >
        
        <Columns>
        
                
            <asp:TemplateField HeaderText="SN">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1%>
            </ItemTemplate>
            <ItemStyle Width="4%"  HorizontalAlign="Right"/>
            </asp:TemplateField>
                                                  
           
                
             <asp:TemplateField HeaderText="Id" Visible="False">
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
            </asp:TemplateField>
               <asp:TemplateField HeaderText="ExpensesId"  Visible="False" >
            <ItemTemplate>
                <asp:Label ID="lblExpencessId" runat="server" Text='<%# Bind("ExpencessId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="2%" />
            </asp:TemplateField>
                 
            <asp:BoundField DataField="Terms" HeaderText="Terms" SortExpression="Terms" />
                        
             <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
            <asp:TextBox ID="txtAmount" CssClass="box3"  Text='<%# Bind("Amount") %>'    Width="85%" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqtxtAmount" runat="server" 
            ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="A">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegtxtAmount" runat="server" 
             ValidationGroup="A" ControlToValidate="txtAmount" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="20%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>
            <asp:TextBox ID="txtRemarks" CssClass="box3"   Text='<%# Bind("Remarks") %>'  Width="85%" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqtxtRemarks" runat="server" 
            ControlToValidate="txtRemarks" ErrorMessage="*" ValidationGroup="A">
            </asp:RequiredFieldValidator>
            
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="20%" />
            </asp:TemplateField>
        </Columns>
        
        <PagerSettings PageButtonCount="40" />
    </asp:GridView>
            </asp:Panel>
            </ContentTemplate>
            </cc1:TabPanel>

            <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel2">              
            <HeaderTemplate>Advance Trans. To</HeaderTemplate>
            <ContentTemplate>
            <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto" Width="90%" Height="230px">
             <asp:GridView ID="GridView1" runat="server" CssClass="yui-datatable-theme" 
        Width="100%" AutoGenerateColumns="False" DataKeyNames="Id" 
       ShowFooter="True"   onrowcancelingedit="GridView1_RowCancelingEdit" 
        onrowcommand="GridView1_RowCommand" onrowdeleting="GridView1_RowDeleting" 
        onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
        AllowPaging="True" PageSize="9" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <Columns>
        
        
                    <asp:TemplateField ShowHeader="False">

                    <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" OnClientClick="return confirmationUpdate();" runat="server" 
                    CausesValidation="False" 
                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton3" OnClientClick="return confirmationUpdate();"  
                    runat="server" CausesValidation="True" ValidationGroup="B"
                    CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp; <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                    CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:TemplateField>

                    <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" OnClientClick="return confirmationDelete();"  runat="server" 
                    CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                
            <asp:TemplateField HeaderText="SN">
            <ItemTemplate>
            <%# Container.DataItemIndex + 1%>
            </ItemTemplate>
            <ItemStyle Width="2%"  HorizontalAlign="Right"/>
            </asp:TemplateField> 
                                                             
                <asp:TemplateField HeaderText="Id" Visible ="False">
                <ItemTemplate>
                <asp:Label ID="lblId" Text='<%# Bind("Id") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="4%" /> 
                </asp:TemplateField>
                           
            
                    <asp:TemplateField HeaderText="Employee Name">

                    <ItemTemplate>
                    <asp:Label ID="lblEmpName" Text='<%# Bind("EmpName") %>' runat="server"></asp:Label>
                    </ItemTemplate>

                     <EditItemTemplate>
                     <asp:Label ID="lblEmpName1" Text='<%# Bind("EmpName") %>' runat="server"></asp:Label>
                    </EditItemTemplate>
                    
                    <FooterTemplate>
                    <asp:TextBox ID="TextEmpName" runat="server" CssClass="box3" ValidationGroup="A" 
                    Width="95%"></asp:TextBox>

                    <cc1:AutoCompleteExtender ID="TextEmpName_AutoCompleteExtender" runat="server" 
                    DelimiterCharacters="" 
                    Enabled="True" ServiceMethod="GetCompletionList"  EnableViewState="true"
                    ServicePath="" TargetControlID="TextEmpName" UseContextKey="True"
                    CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" 
                    ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg"
                     CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                     </cc1:AutoCompleteExtender>
                                       
                    </FooterTemplate>
                    
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                    </asp:TemplateField>
            
            
                     
             <asp:TemplateField HeaderText="Amount">
            <ItemTemplate>
                 <asp:Label ID="lblAmount" Text='<%# Bind("Amount") %>' runat="server"></asp:Label>     
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtAmt1" CssClass="box3" Text='<%# Bind("Amount") %>' Width="90%" runat="server">
            </asp:TextBox> 
            <asp:RegularExpressionValidator ID="RegtxtAmt1" runat="server" 
             ValidationGroup="B" ControlToValidate="txtAmt1" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
            </EditItemTemplate>
            
            <FooterTemplate>
            <asp:TextBox ID="txtAmt" CssClass="box3" Text=""  Width="90%" runat="server">
            </asp:TextBox> 
            <asp:RegularExpressionValidator ID="RegtxtAmt" runat="server" 
             ValidationGroup="A" ControlToValidate="txtAmt" ErrorMessage="*" ValidationExpression="^\d{1,15}(\.\d{0,3})?$">
            </asp:RegularExpressionValidator>
            </FooterTemplate>
            
            <ItemStyle HorizontalAlign="Right" Width="15%" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>
            <asp:Label ID="lblRemark" Text='<%# Bind("Remarks") %>' runat="server"></asp:Label>     
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtRemark1" CssClass="box3" Text='<%# Bind("Remarks") %>'  Width="90%" runat="server">
            </asp:TextBox>
            </EditItemTemplate>
            <FooterTemplate>
            <asp:TextBox ID="txtRemark" CssClass="box3" Text=""  Width="95%" runat="server">
            </asp:TextBox>
            </FooterTemplate>
            
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:TemplateField>
            
             <asp:TemplateField HeaderText=" ">
           
            <FooterTemplate>
             <asp:Button ID="btnAdd" runat="server" CommandName="Add"  Text=" Add "  OnClientClick="return confirmationAdd();"
              CssClass="redbox"  />   
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Center" Width="4%" />
            </asp:TemplateField>
        </Columns>


                <EmptyDataTemplate>
                <table width="100%" border="1" style="border-color:Gray"  class="fontcss">
                 
                 <tr>  
                     <th>
                         SN
                     </th>
                     <th>
                         Employee Name
                     </th>
                     <th>
                         Amount
                     </th>
                     <th>
                         Remarks
                     </th>
                     <th>
                     </th>
                                    
                </tr>

                <tr> 
                    <td align="right" style="width:1%">
                        1
                    </td>
                    <td align="left" style="width:20%">
                        <asp:TextBox ID="TxtEmp" runat="server" CssClass="box3" ValidationGroup="E" 
                            Width="90%">
                        </asp:TextBox>
                        <cc1:AutoCompleteExtender ID="TxtEmp_AutoCompleteExtender" runat="server" 
                            CompletionInterval="100" CompletionListCssClass="almt" 
                            CompletionListHighlightedItemCssClass="bgtext" CompletionListItemCssClass="bg" 
                            CompletionSetCount="2" DelimiterCharacters="" Enabled="True" 
                            EnableViewState="true" FirstRowSelected="True" MinimumPrefixLength="1" 
                            ServiceMethod="GetCompletionList" ServicePath="" 
                            ShowOnlyCurrentWordInCompletionListItem="True" TargetControlID="TxtEmp" 
                            UseContextKey="True">
                        </cc1:AutoCompleteExtender>
                    </td>
                    <td align="center" style="width:5%">
                        <asp:TextBox ID="TxtAmt2" runat="server" CssClass="box3" Width="85%">
                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegAmt" runat="server" 
                            ControlToValidate="TxtAmt2" ErrorMessage="*" 
                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="E">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td align="center" style="width:15%">
                        <asp:TextBox ID="TxtRemarks2" runat="server" CssClass="box3" 
                            ValidationGroup="E" Width="90%">
                        </asp:TextBox>
                    </td>
                    <td align="center" style="width:2%">
                        <asp:Button ID="BtnAdd1" runat="server" CommandName="Add1" CssClass="redbox" 
                            OnClientClick="return confirmationAdd();" Text="Add" ValidationGroup="E" />
                    </td>
                </tr>
                 
                </table>
                </EmptyDataTemplate>
        
        
        <PagerSettings PageButtonCount="40" />
        
        
    </asp:GridView>
            </asp:Panel>
            </ContentTemplate>
            </cc1:TabPanel>
            </cc1:TabContainer>
            </td>
 </tr>
<tr>
<td align="center" height="25px" valign="middle">
    <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="redbox" ValidationGroup="B" OnClientClick="return confirmationAdd();"
        onclick="btnSubmit_Click" />
 &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="redbox"
        onclick="btnCancel_Click" />
 </td>
 </tr>
<tr>
<td>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
       ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
         SelectCommand="SELECT * FROM [tblACC_TourExpencessType]"></asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
       ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
         SelectCommand="SELECT * FROM [tblACC_TourAdvance_Temp]"></asp:SqlDataSource>

 </td>
 </tr>
  </table>   

                </asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

