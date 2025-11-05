<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_HR_Transactions_OfficeStaff_Edit_Deatails, newerp_deploy" title="ERP" theme="Default" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
<script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
</script>
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

    <table align="left" cellpadding="0" cellspacing="0" width="100%" 
        style="height: 301px">
    <tr>
        <td align="left" valign="middle" style="background:url(../../../images/hdbg.JPG)" height="21" class="fontcsswhite"><b>&nbsp;Staff - Edit</b></td>
    </tr>
    <tr>
        <td valign="top">
   
    <cc1:TabContainer ID="TabContainer1"  runat="server" ActiveTabIndex="0"  Height="300px" 
                Width="100%" onactivetabchanged="TabContainer1_ActiveTabChanged" 
                >
        <cc1:TabPanel runat="server" HeaderText="Official Info" ID="TabPanel1" Height="300">
            <HeaderTemplate>Official Info
            </HeaderTemplate>
            <ContentTemplate><table align="left" cellpadding="0" cellspacing="0" width="100%"><tr><td class="style12" height="25"><asp:Label ID="Label2" runat="server" Text="Emp Id"></asp:Label></td><td class="style11"><asp:Label ID="lblEmpId" runat="server"></asp:Label></td><td class="style10"><asp:Label ID="Label58" runat="server" Text="Offer Id"></asp:Label></td><td><asp:Label ID="lbloffid" runat="server"></asp:Label></td></tr><tr><td class="style12" height="25"><asp:Label ID="Label4" runat="server" Text="Name of  Employee"></asp:Label></td><td colspan="3"><asp:DropDownList ID="DrpEmpTitle" runat="server" CssClass="box3"><asp:ListItem>Mr</asp:ListItem><asp:ListItem>Mrs</asp:ListItem><asp:ListItem>Miss</asp:ListItem></asp:DropDownList><asp:TextBox ID="TxtEmpName" runat="server" style="margin-bottom: 0px" CssClass="box3" 
                            Width="300px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="TxtEmpName" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator></td></tr><tr><td class="style12" height="25"><asp:Label ID="Label11" runat="server" Text="Designation"></asp:Label></td><td class="style11">
                    <asp:DropDownList ID="DrpDesignation" runat="server" CssClass="box3" Width="180px"
                        DataSourceID="SqlDesignation" DataTextField="Designation" 
                        DataValueField="Id"></asp:DropDownList><asp:SqlDataSource ID="SqlDesignation" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT Id, [Type] + ' - ' + [Symbol] AS Designation FROM tblHR_Designation"></asp:SqlDataSource><asp:RequiredFieldValidator ID="ReqDesign" runat="server" 
                            ControlToValidate="DrpDesignation" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator></td><td class="style10"><asp:Label ID="Label9" runat="server" Text="Department"></asp:Label></td><td><asp:DropDownList ID="DrpDepartment" runat="server" CssClass="box3"
                        DataSourceID="SqlDept" DataTextField="DeptName" DataValueField="Id"></asp:DropDownList><asp:SqlDataSource ID="SqlDept" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                        SelectCommand="SELECT Id, Symbol AS DeptName FROM tblHR_Departments"></asp:SqlDataSource><asp:RequiredFieldValidator ID="ReqDept" runat="server" 
                            ControlToValidate="DrpDepartment" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator></td></tr>
                            
                            <tr>
                            
                            <td class="style12" height="25"><asp:Label ID="Label7" runat="server" Text="Swap Card No"></asp:Label></td>
           <td >
                            <asp:DropDownList ID="DrpSwapcardNo" runat="server" CssClass="box3"  >
                            </asp:DropDownList>                            
                            <asp:RequiredFieldValidator ID="ReqSwapNo" runat="server" 
                            ControlToValidate="DrpSwapcardNo" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator>
                            </td>
                            
                            <td class="style10"><asp:Label ID="Label13" runat="server" Text="Director of Dept."></asp:Label></td><td>
                            
                            <asp:DropDownList ID="DrpDirectorName" runat="server" CssClass="box3"
                            ></asp:DropDownList> 
                            
                            <tr><td class="style12" height="25"><asp:Label ID="Label10" runat="server" Text="Under BG"></asp:Label></td>                            
                            <td class="style11"><asp:DropDownList ID="DrpBGGroup" runat="server" CssClass="box3"
                            DataSourceID="SqlBGGroup" DataTextField="Symbol" DataValueField="Id"></asp:DropDownList><asp:SqlDataSource ID="SqlBGGroup" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT [Id], [Name] + ' - ' + [Symbol] As Symbol  FROM [BusinessGroup]"></asp:SqlDataSource><asp:RequiredFieldValidator ID="ReqBGgroup" runat="server" 
                            ControlToValidate="DrpBGGroup" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator></td>                            
                            
                            <td class="style10"><asp:Label ID="lblGRPLDR" runat="server" Text="Group Leader"></asp:Label></td><td>
                            
                            <asp:DropDownList ID="DrpGroupLeader" runat="server" CssClass="box3"
                             ></asp:DropDownList>                           
                            
                            
                            </tr><tr>
                            
                            <td class="style12" height="25"><asp:Label ID="Label15" runat="server" Text="Dept.  Head"></asp:Label></td>
                            
                            <td class="style11"><asp:DropDownList ID="DrpDeptHead" runat="server" CssClass="box3"
                             DataTextField="EmployeeName" 
                            DataValueField="UserID" Width="180px"></asp:DropDownList> 
                            
                            </td>
                            <td class="style10"><asp:Label ID="Label12" runat="server" Text="Corp. Mobile No."></asp:Label></td><td>
                            <asp:DropDownList ID="DrpMobileNo" runat="server" CssClass="box3" >
                            </asp:DropDownList>
                            
                            <asp:RequiredFieldValidator ID="ReqBGgroup4" runat="server" 
                            ControlToValidate="DrpMobileNo" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator>
                            </td></tr><tr><td class="style12" height="25"><asp:Label ID="Label16" runat="server" Text="Grade"></asp:Label></td><td class="style11"><asp:DropDownList ID="DrpGrade" runat="server" CssClass="box3"
                            DataSourceID="SqlGrade" DataTextField="Symbol" DataValueField="Id"></asp:DropDownList><asp:SqlDataSource ID="SqlGrade" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT [Id], [Description] + ' - ' + [Symbol] As Symbol  FROM [tblHR_Grade]"></asp:SqlDataSource><asp:RequiredFieldValidator ID="ReqGrade" runat="server" 
                            ControlToValidate="DrpGrade" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator></td><td class="style10"><asp:Label ID="Label23" runat="server" Text="Contact No."></asp:Label></td><td><asp:TextBox ID="TxtContactNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TxtContactNo" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator></td></tr><tr><td class="style12" height="25"><asp:Label ID="Label6" runat="server" Text="E-Mail"></asp:Label></td><td class="style11"><asp:TextBox ID="TxtMail" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RegularExpressionValidator ID="RegEmail" runat="server" 
                            ControlToValidate="TxtMail" ErrorMessage="*" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="acbd"></asp:RegularExpressionValidator></td><td class="style10"><asp:Label ID="Label24" runat="server" Text="ERP-Mail"></asp:Label></td><td><asp:TextBox ID="TxtERPMail" runat="server" CssClass="box3"></asp:TextBox><asp:RegularExpressionValidator ID="RegEmail0" runat="server" 
                            ControlToValidate="TxtERPMail" ErrorMessage="*" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="acbd"></asp:RegularExpressionValidator></td></tr><tr><td class="style12" height="25"><asp:Label ID="Label18" runat="server" Text="Extension No."></asp:Label></td><td class="style11"><asp:DropDownList ID="DrpExtensionNo" runat="server" CssClass="box3"
                            DataSourceID="SqlExtension" DataTextField="ExtNo" DataValueField="Id"></asp:DropDownList><asp:SqlDataSource ID="SqlExtension" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
                            SelectCommand="SELECT [ExtNo], [Id] FROM [tblHR_IntercomExt]"></asp:SqlDataSource><asp:RequiredFieldValidator ID="ReqExtNo" runat="server" 
                            ControlToValidate="DrpExtensionNo" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator></td><td class="style10"><asp:Label ID="Label25" runat="server" Text="Joining Date"></asp:Label></td><td><asp:TextBox ID="TxtJoinDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtJoinDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight" 
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtJoinDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="acbd" 
                        ControlToValidate="TxtJoinDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegJoinDateVal" runat="server" 
                                    ControlToValidate="TxtJoinDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="acbd"></asp:RegularExpressionValidator>
                        </td>
                        </tr>
                        <tr><td class="style12" height="25"><asp:Label ID="Label19" runat="server" Text="Resignation Date"></asp:Label></td><td class="style11"><asp:TextBox ID="TxtResignDate" runat="server" Width="80px" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtResignDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtResignDate"></cc1:CalendarExtender>
                            
                            <asp:Label ID="Label59" runat="server" Font-Size="Small" ForeColor="Red" 
                                     Text="* Reset Swap Card No and Corp. Mobile No. to Not Applicable."></asp:Label>
                            </td><td class="style10">&nbsp;</td><td>&nbsp;</td></tr><tr><td class="style12" height="25">&#160;</td><td class="style11">&#160;</td><td class="style10">&#160;</td><td><asp:Button ID="btnNext1" runat="server" CssClass="redbox" 
                            OnClick="btnNext1_Click" Text="Next" /><asp:Button ID="BtnCancel2" runat="server" CssClass="redbox" 
                            OnClick="BtnCancel_Click" Text="Cancel" /></td></tr></table>
            </ContentTemplate>
        
        
</cc1:TabPanel>
             
         <cc1:TabPanel runat="server" HeaderText="Personal Info" ID="TabPanel2">
        <ContentTemplate><table style="width: 99%"  ><tr><td colspan="2" height="25"><asp:Label ID="Label29" runat="server" Text="Permanent Address"></asp:Label></td><td colspan="2"><asp:Label ID="Label32" runat="server" Text="Correspondence Address"></asp:Label></td></tr><tr><td colspan="2"><asp:TextBox ID="TxtPermanentAddress" runat="server" TextMode="MultiLine" CssClass="box3"
                    Width="374px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqPersonalEmail6" runat="server" 
                    ControlToValidate="TxtPermanentAddress" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator></td><td colspan="2"><asp:TextBox ID="TxtCAddress" runat="server" TextMode="MultiLine" Width="408px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqPersonalEmail7" runat="server" 
                    ControlToValidate="TxtCAddress" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator></td></tr><tr><td class="style4" height="25"><asp:Label ID="Label31" runat="server" Text="E-Mail"></asp:Label></td><td class="style3"><asp:TextBox ID="TxtEmail" runat="server" CssClass="box3" Width="200px"></asp:TextBox><asp:RegularExpressionValidator ID="RegEmail1" runat="server" 
                    ControlToValidate="TxtEmail" ErrorMessage="*" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="acbd"></asp:RegularExpressionValidator></td><td class="style2"><asp:Label ID="Label30" runat="server" Text="Date Of Birth"></asp:Label></td><td><asp:TextBox 
                    ID="TxtDateofBirth" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtDateofBirth_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtDateofBirth"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDOB" runat="server" 
                        ControlToValidate="TxtDateofBirth" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularBirth" runat="server" 
                                    ControlToValidate="TxtDateofBirth" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="acbd"></asp:RegularExpressionValidator>
                        </td></tr><tr><td class="style4" height="25"><asp:Label ID="Label36" runat="server" Text="Gender"></asp:Label></td><td class="style3">
                        <asp:DropDownList ID="DrpGender" runat="server" CssClass="box3"><asp:ListItem Value="Select">Select</asp:ListItem><asp:ListItem Value="M">Male</asp:ListItem><asp:ListItem Value="F">Female</asp:ListItem></asp:DropDownList><asp:RequiredFieldValidator ID="ReqGender" runat="server" 
                        ControlToValidate="DrpGender" ErrorMessage="*" InitialValue="Select" 
                        ValidationGroup="acbd"></asp:RequiredFieldValidator></td><td class="style2" ><asp:Label ID="Label34" runat="server" Text="Martial Status"></asp:Label></td><td><asp:RadioButton ID="RdbtnMarried" runat="server" GroupName="Marriage" 
                        Text="Married"></asp:RadioButton><asp:RadioButton ID="RdbtnUnmarried" runat="server" GroupName="Marriage" 
                        Text="Unmarried" />
                <tr>
                    <td class="style4" height="25">
                        <asp:Label ID="Label33" runat="server" Text="Blood Group"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:DropDownList ID="DrpBloodGroup" runat="server" CssClass="box3">
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem Value="Not Known">Not Known</asp:ListItem>
                            <asp:ListItem Value="O+">O+</asp:ListItem>
                            <asp:ListItem Value="O-">O-</asp:ListItem>
                            <asp:ListItem>A+</asp:ListItem>
                            <asp:ListItem>A-</asp:ListItem>
                            <asp:ListItem>B+</asp:ListItem>
                            <asp:ListItem>B-</asp:ListItem>
                            <asp:ListItem>AB+</asp:ListItem>
                            <asp:ListItem>AB-</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="ReqPersonalEmail0" runat="server" 
                            ControlToValidate="DrpBloodGroup" ErrorMessage="*" InitialValue="Select" 
                            ValidationGroup="acbd"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label35" runat="server" Text="Height"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtHeight" runat="server" CssClass="box3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqPersonalEmail4" runat="server" 
                            ControlToValidate="TxtHeight" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4" height="25">
                        <asp:Label ID="Label39" runat="server" Text="Weight"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="TxtWeight" runat="server" CssClass="box3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqPersonalEmail1" runat="server" 
                            ControlToValidate="TxtWeight" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label41" runat="server" Text="Physically Handicapped"></asp:Label>
                        <asp:RadioButton ID="RdbtnYes" runat="server" GroupName="Physicllyhandicapped" 
                            Text="Yes" />
                        <asp:RadioButton ID="RdbtnNo" runat="server" GroupName="Physicllyhandicapped" 
                            Text="No" />
                    </td>
                </tr>
                <tr>
                    <td class="style4" height="25">
                        <asp:Label ID="Label37" runat="server" Text="Religion"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="TxtReligion" runat="server" CssClass="box3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqPersonalEmail2" runat="server" 
                            ControlToValidate="TxtReligion" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style2">
                        <asp:Label ID="Label38" runat="server" Text="Cast"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtCast" runat="server" CssClass="box3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqPersonalEmail3" runat="server" 
                            ControlToValidate="TxtCast" ErrorMessage="*" ValidationGroup="acbd"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td align="right">
                        <asp:Button ID="btnNext2" runat="server" CssClass="redbox" 
                            OnClick="btnNext2_Click" Text="Next" />
                        <asp:Button ID="Button1" runat="server" CssClass="redbox" 
                            OnClick="Button1_Click" Text="Cancel" />
                    </td>
                </tr>
                </td></tr></table>
        
            </ContentTemplate>
        
        
</cc1:TabPanel>
        
        <cc1:TabPanel runat="server" HeaderText="Edu. Quali. & Work Experience" ID="TabPanel3">
        <ContentTemplate><table style="width: 521px"  ><tr><td class="style3" height="25"><asp:Label ID="Label44" runat="server" Text="Educational Qualification"></asp:Label></td><td><asp:TextBox ID="TxtEducatinalQualificatin" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqEduQual" runat="server" 
                    ControlToValidate="TxtEducatinalQualificatin" ErrorMessage="*" 
                    ValidationGroup="acbd"></asp:RequiredFieldValidator></td></tr><tr><td class="style3" valign="top"><asp:Label ID="Label42" runat="server" Text="Additional Qualification"></asp:Label></td><td><asp:TextBox ID="TxtAdditionalQualification" runat="server" CssClass="box3" 
                        Height="68px" TextMode="MultiLine" Width="336px"></asp:TextBox></td></tr><tr><td class="style3" height="25"><asp:Label ID="Label48" runat="server" Text="Last Company Name"></asp:Label></td><td><asp:TextBox ID="TxtLastCompanyName" runat="server" CssClass="box3" 
                        Width="250px"></asp:TextBox></td></tr><tr><td class="style3" height="25"><asp:Label ID="Label46" runat="server" Text="Total Experience"></asp:Label></td><td><asp:TextBox ID="TxtTotalExperience" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td class="style3" height="25"><asp:Label ID="Label49" runat="server" Text="Working Duration"></asp:Label></td><td><asp:TextBox ID="TxtWorkingDuration" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td class="style3">&#160;</td><td align="right" class="style2">&#160;</td></tr><tr><td class="style3"></td><td align="right" class="style2"><asp:Button ID="btnNext3" runat="server" CssClass="redbox" 
                        OnClick="btnNext3_Click" Text="Next" /><asp:Button ID="btnCancel3" runat="server" CssClass="redbox" 
                        OnClick="btnCancel_Click" Text="Cancel" /></td></tr></table>
         
        
         
        
            </ContentTemplate>
        
</cc1:TabPanel>
        
        
        
         <cc1:TabPanel runat="server" HeaderText="Others" ID="TabPanel4">
        <ContentTemplate><table align="left" cellpadding="2" cellspacing="2" width="50%"><tr><td colspan="4" valign="top"><table align="left" cellpadding="0" cellspacing="0"  width="100%"><tr><td height="25"><asp:Label ID="Label51" runat="server" Text="Current CTC"></asp:Label></td><td><asp:TextBox ID="TxtCurrentCTC" runat="server" CssClass="box3"></asp:TextBox></td><td><asp:Label ID="Label54" runat="server" Text="Bank Acc No."></asp:Label></td><td><asp:TextBox ID="TxtBankAccNo" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td height="25"><asp:Label ID="Label53" runat="server" Text="PF  No."></asp:Label></td><td><asp:TextBox ID="TxtPFNo" runat="server" CssClass="box3"></asp:TextBox></td><td><asp:Label ID="Label55" runat="server" Text="PAN No."></asp:Label></td><td><asp:TextBox ID="TxtPANNo" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td height="25"><asp:Label ID="Label56" runat="server" Text="Passport No."></asp:Label></td><td><asp:TextBox ID="TxtPassportNo" runat="server" CssClass="box3"></asp:TextBox></td><td><asp:Label ID="Label52" runat="server" Text="Expiry Date"></asp:Label></td><td><asp:TextBox ID="TxtExpiryDate" runat="server" CssClass="box3"></asp:TextBox><cc1:CalendarExtender ID="TxtExpiryDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="TxtExpiryDate"></cc1:CalendarExtender>
                                        <asp:RegularExpressionValidator ID="RegTxtExpiryDate" runat="server" 
                                    ControlToValidate="TxtExpiryDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="acbd"></asp:RegularExpressionValidator>
                                        </td></tr></table></td></tr><tr><td class="style10" colspan="4" valign="top" height="25"><asp:Label ID="Label57" runat="server" Text="Additional Information"></asp:Label></td></tr><tr><td class="style14" colspan="4" valign="top"><asp:TextBox ID="TxtAdditionalInformation" runat="server" CssClass="box3" 
                            Height="66px" TextMode="MultiLine" Width="325px"></asp:TextBox></td></tr>
                            <tr><td class="style16" height="25"><asp:Label ID="Label27" runat="server" Text="Upload Photo"></asp:Label></td>
                            <td class="style13" colspan="3"><asp:FileUpload ID="FileUploadPhoto" runat="server" /><asp:Label ID="lblcv" runat="server"></asp:Label><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/cross.gif" 
                            OnClick="ImageButton2_Click" /></td>
                                <tr>
                                    <td class="style16" height="25">
                                        <asp:Label ID="Label28" runat="server" Text="Upload CV"></asp:Label>
                                    </td>
                                    <td class="style13" colspan="3">
                                        <asp:FileUpload ID="FileUploadControl" runat="server" />
                                        <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink>
                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cross.gif" 
                                            OnClick="ImageButton1_Click" />
                                    </td>
                                    <tr>
                                        <td class="style16">
                                            &nbsp;</td>
                                        <td class="style15">
                                            &nbsp;</td>
                                        <td class="style17">
                                            &nbsp;</td>
                                        <td align="right" class="style11">
                                            <asp:Button ID="BtnUpdate" runat="server" CssClass="redbox" 
                                                OnClick="BtnUpdate_Click" OnClientClick="return confirmationUpdate()" 
                                                Text="Update" ValidationGroup="acbd" />
                                            <asp:Button ID="BtnCancel" runat="server" CssClass="redbox" 
                                                OnClick="BtnCancel_Click1" Text="Cancel" />
                                        </td>
                                    </tr>
                                </tr>
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

