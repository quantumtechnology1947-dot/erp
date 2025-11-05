<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_SysConfig_Default, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    <script type="text/javascript">
        function OnChanged(sender, args)
        {
            ServerUtilities.SetTabIndex(sender.get_activeTabIndex());
        }
    </script>
    <style type="text/css">
        .style2
        {
            width: 100%;
            float: left;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cp3" Runat="Server"> 
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp2" Runat="Server">
    &nbsp;System Configuration&nbsp; 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

<asp:Content ID="Content9" runat="server" contentplaceholderid="ContentPlaceHolder3">
       
       
        
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <cc1:TabContainer ID="TabContainer1" runat="server"  Height="420px" ActiveTabIndex="0"
                        Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
                        <cc1:TabPanel runat="server" headertext="New" id="New">
                            <HeaderTemplate>  
                        
                        New</HeaderTemplate><ContentTemplate><table cellpadding="0" cellspacing="0" width="100%" ><tr><td align="right" valign="middle"><asp:Button runat="server" Text="Save" ValidationGroup="New1" CssClass="redbox" OnClientClick=" return confirmationAdd()" 
    ID="btnSave" onclick="btnSave_Click"></asp:Button>&nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" 
            onclick="Button1_Click" Text="Cancel" />&nbsp;</td></tr><tr><td valign="middle">Name of Company&#160;&#160;&#160; <asp:TextBox runat="server" CssClass="box3" Width="300px" ID="txtCompanyName" 
            ></asp:TextBox>&#160;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtCompanyName" ErrorMessage="*" ValidationGroup="New1">*</asp:RequiredFieldValidator>&#160;Upload Logo <asp:FileUpload runat="server" CssClass="box3" ID="FileUpload1"></asp:FileUpload><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="FileUpload1" ErrorMessage="*" ValidationGroup="New1">*</asp:RequiredFieldValidator></td></tr><tr><td bgcolor="#CCCCCC"><b>Registered Office Details</b></td></tr><tr><td><table cellpadding="0" cellspacing="1" width="100%"><tr><td rowspan="3" valign="top" width="10%">Address</td><td rowspan="3" valign="top" width="29%"><asp:TextBox runat="server" 
                TextMode="MultiLine" CssClass="box3" Height="56px" Width="240px" 
                ID="txtRegdNewAdd"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="txtRegdNewAdd" ErrorMessage="*" ValidationGroup="New1">*</asp:RequiredFieldValidator></td><td width="11%" height="25">Country</td><td width="18%" colspan="2"><asp:DropDownList runat="server" CssClass="box3" 
                ID="DropDownRegdCountry" AutoPostBack="True" 
                onselectedindexchanged="DropDownRegdCountry_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="New1"
                ControlToValidate="DropDownRegdCountry" ErrorMessage="*" InitialValue="Select">*</asp:RequiredFieldValidator></td><td class="style3">Pin Code</td><td width="21%"><asp:TextBox runat="server" CssClass="box3" ID="txtRegdPinCode" 
                MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="New1"
                ControlToValidate="txtRegdPinCode" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td height="25">State</td><td colspan="2"><asp:DropDownList runat="server" CssClass="box3" ID="DropDownRegdState" 
                AutoPostBack="True" 
                onselectedindexchanged="DropDownRegdState_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="New1"
                ControlToValidate="DropDownRegdState" ErrorMessage="*" InitialValue="Select">*</asp:RequiredFieldValidator></td><td class="style3">Fax No</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtRegdFaxNo"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="New1" 
                ControlToValidate="txtRegdFaxNo" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td height="25">City</td><td colspan="2"><asp:DropDownList runat="server" CssClass="box3" ID="DropDownRegdCity" 
                onselectedindexchanged="DropDownRegdCity_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="New1"
                ControlToValidate="DropDownRegdCity" ErrorMessage="*" InitialValue="Select">*</asp:RequiredFieldValidator></td><td class="style3">Contact No</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtRegdContactNo"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="New1"
                ControlToValidate="txtRegdContactNo" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td>Email</td><td colspan="3" height="25"><asp:TextBox runat="server" CssClass="box3" Width="270px" 
                ID="txtRegdEmail"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="New1"
                ControlToValidate="txtRegdEmail" ErrorMessage="*">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="New1"
                ControlToValidate="txtRegdEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td><td>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </td><td class="style3">Server Ip</td><td><asp:TextBox ID="txtIpNew" runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td>&#160;</td><td colspan="3">&#160;</td><td>&#160;</td><td class="style3">&#160;</td><td>&#160;</td></tr></table></td></tr><tr><td bgcolor="#CCCCCC"><b>Plant/Work Details</b></td></tr><tr><td><table cellpadding="0" cellspacing="1" width="100%"><tr><td rowspan="3" valign="top" width="10%">Address</td><td rowspan="3" valign="top" width="29%"><asp:TextBox runat="server" 
                TextMode="MultiLine" CssClass="box3" Height="65px" Width="260px" 
                ID="txtPlntAdd"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="New1"
                ControlToValidate="txtPlntAdd" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td width="11%" height="25">Country</td><td width="18%"><asp:DropDownList runat="server" CssClass="box3" 
                ID="DropDownPlntCnt" AutoPostBack="True" 
                onselectedindexchanged="DropDownPlntCnt_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="New1"
                ControlToValidate="DropDownPlntCnt" ErrorMessage="*" InitialValue="Select">*</asp:RequiredFieldValidator></td><td width="11%">Pin Code</td><td width="21%"><asp:TextBox runat="server" CssClass="box3" ID="txtPlntPincode" 
                MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="New1"
                ControlToValidate="txtPlntPincode" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td height="25">State</td><td><asp:DropDownList runat="server" CssClass="box3" ID="DropDownPlntSta" 
                AutoPostBack="True" 
                onselectedindexchanged="DropDownPlntSta_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="New1"
                ControlToValidate="DropDownPlntSta" ErrorMessage="*" InitialValue="Select">*</asp:RequiredFieldValidator></td><td>Fax No</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtPlntFax"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="New1"
                ControlToValidate="txtPlntFax" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td height="25">City</td><td><asp:DropDownList runat="server" ID="DropDownPlntCity" 
                onselectedindexchanged="DropDownPlntCity_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="New1"
                ControlToValidate="DropDownPlntCity" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td>Contact No</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtPlantContNo"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ValidationGroup="New1"
                ControlToValidate="txtPlantContNo" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td>Email</td><td colspan="2" height="25"><asp:TextBox runat="server" CssClass="box3" Width="270px" 
                ID="txtPlntEmail"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ValidationGroup="New1" 
                ControlToValidate="txtPlntEmail" ErrorMessage="*">*</asp:RequiredFieldValidator>&#160;<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"  ValidationGroup="New1"
                ControlToValidate="txtPlntEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td><td>&#160;</td><td>Item Code Limit</td><td><asp:TextBox ID="txtItemCodeLimitNew" runat="server" CssClass="box3" 
                                            Width="10%"></asp:TextBox>&#160;(&gt;1 and &lt;=15)<asp:RequiredFieldValidator ID="ReqItemCodeLimit0" runat="server" 
                                            ControlToValidate="txtItemCodeLimitNew" ErrorMessage="*" 
                                            ValidationGroup="New1">*</asp:RequiredFieldValidator><asp:RangeValidator ID="RangeValItemCode0" runat="server" 
                                            ControlToValidate="txtItemCodeLimitNew" ErrorMessage="*" MaximumValue="15" 
                                            MinimumValue="1" ValidationGroup="New1" Type="Integer"></asp:RangeValidator></td></tr><tr><td>Ecc No</td><td height="25"><asp:TextBox runat="server" CssClass="box3" ID="txtEccNo"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ValidationGroup="New1"
                ControlToValidate="txtEccNo" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td>Commissionerate</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtComm"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ValidationGroup="New1"
                ControlToValidate="txtComm" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td>Range</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtRange" 
                ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ValidationGroup="New1"
                ControlToValidate="txtRange" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td>Division</td><td height="25"><asp:TextBox runat="server" CssClass="box3" ID="txtDiv"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ValidationGroup="New1"
                ControlToValidate="txtDiv" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td>VAT No</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtVat"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ValidationGroup="New1"
                ControlToValidate="txtVat" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td>CST No</td><td><asp:TextBox runat="server" CssClass="box3" ID="txtCst"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ValidationGroup="New1"
                ControlToValidate="txtCst" ErrorMessage="*">*</asp:RequiredFieldValidator></td><tr><td>Licence Nos</td><td><asp:TextBox ID="txtLicenceNo" runat="server" CssClass="box3" MaxLength="5" 
                      Width="50px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ValidationGroup="New1"
                      ControlToValidate="txtLicenceNo" ErrorMessage="*">*</asp:RequiredFieldValidator><asp:CheckBox ID="ChknewDefaultComp" runat="server" Text="Default Company" /></td><td valign="middle">PAN No</td><td><asp:TextBox ID="txtPANNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" 
                      ControlToValidate="txtPANNo" ErrorMessage="*" ValidationGroup="New1"></asp:RequiredFieldValidator></td><td>Prefix</td><td><asp:TextBox ID="txtPrefix" runat="server" CssClass="box3" Wrap="False" 
                                            Width="20%"></asp:TextBox>&nbsp;<span class="style6">(Emp.No Start)</span><asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" 
                      ControlToValidate="txtPrefix" ErrorMessage="*" ValidationGroup="New1"></asp:RequiredFieldValidator></td></tr></tr><tr><td headers="30">Date From</td><td height="25"><asp:TextBox ID="txtFDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="txtFDate_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" PopupPosition="TopLeft" 
                                            TargetControlID="txtFDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqFrmDt" runat="server" 
                                            ControlToValidate="txtFDate" ErrorMessage="*" ValidationGroup="New1"></asp:RequiredFieldValidator></td><td valign="middle">To</td><td><asp:TextBox ID="txtTDate" runat="server" CssClass="box3" Width="80px"></asp:TextBox><cc1:CalendarExtender ID="txtTDate_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd-MM-yyyy" PopupPosition="TopLeft" 
                                            TargetControlID="txtTDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqToDt" runat="server" 
                                            ControlToValidate="txtTDate" ErrorMessage="*" ValidationGroup="New1"></asp:RequiredFieldValidator></td><td>ERP Mail</td><td><asp:TextBox ID="txterpsysmail" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="reqerpmail" runat="server" 
                                            ControlToValidate="txterpsysmail" ErrorMessage="*" ValidationGroup="New1">*</asp:RequiredFieldValidator></td></tr><tr><td height="25">Mobile No.</td><td><asp:TextBox ID="txtMobileNo" runat="server" CssClass="box3" MaxLength="10" 
                                            Width="189px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqFrmDt0" runat="server" 
                                            ControlToValidate="txtMobileNo" ErrorMessage="*" ValidationGroup="New1"></asp:RequiredFieldValidator></td><td valign="middle">Password</td><td><asp:TextBox ID="txtPassword" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqFrmDt1" runat="server" 
                                            ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="New1"></asp:RequiredFieldValidator></td><td>Mail Server Ip</td><td><asp:TextBox ID="txtMailServerIp" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="reqMailServerIp" runat="server" 
                                            ControlToValidate="txtMailServerIp" ErrorMessage="*" ValidationGroup="New1">*</asp:RequiredFieldValidator></td></tr></table></td></tr></table>                         
                        
                        
                        </ContentTemplate>
     




</cc1:TabPanel>
<cc1:TabPanel ID="Edit" runat="server" HeaderText="Edit"><HeaderTemplate>Edit</HeaderTemplate>

<ContentTemplate><table cellpadding="0" cellspacing="0" width="100%"><tr><td align="right" valign="middle"><asp:Button runat="server" Text="Update"  OnClientClick=" return confirmationUpdate()"  
            CssClass="redbox" ID="Update" ValidationGroup="Edit1" OnClick="Update_Click"></asp:Button>&#160;<asp:Button runat="server" Text="Delete"  CssClass="redbox" ID="Delete"  OnClientClick=" return confirmationDelete()" 
            onclick="Delete_Click"></asp:Button>&nbsp;</td></tr><tr><td valign="middle" 
            height="25">Name of Company <asp:DropDownList runat="server" DataValueField="CompId" 
            DataTextField="CompanyName" CssClass="box3" ID="DropDownEditCompanyName" 
            onselectedindexchanged="DropDownEditCompanyName_SelectedIndexChanged" 
            AutoPostBack="True"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator 
            ID="RequiredFieldValidator52" runat="server" 
            ControlToValidate="DropDownEditCompanyName" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="Edit1">*</asp:RequiredFieldValidator>&nbsp; Upload Logo:&nbsp;<asp:FileUpload runat="server" CssClass="box3" ID="FileUpload2"></asp:FileUpload>&nbsp;<asp:Label 
            ID="lblImageUploadEdit" runat="server"></asp:Label><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cross.gif" 
            onclick="ImageButton1_Click" style="width: 13px" Visible="False" Width="16px" /></td></tr><tr><td bgcolor="#CCCCCC"><b>Registered Office Details</b></td></tr><tr><td><table 
        cellpadding="0" cellspacing="1" width="100%"><tr><td rowspan="3" valign="top" 
            width="10%">Address</td><td class="style4" rowspan="3" valign="top"><asp:TextBox 
                ID="txtEditRegdAdd" runat="server" CssClass="box3" Height="65px" 
                TextMode="MultiLine" Width="260px"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtEditRange" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td 
            width="11%">Country</td><td height="25" width="18%"><asp:DropDownList 
                ID="EditDropDownRegdCountry" runat="server" AutoPostBack="True" CssClass="box3" 
                OnSelectedIndexChanged="EditDropDownRegdCountry_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator28" 
                runat="server" ControlToValidate="EditDropDownRegdCountry" ErrorMessage="*" 
                InitialValue="Select" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td 
            width="11%">Pin Code</td><td width="21%"><asp:TextBox ID="txtEditRegdPinCode" 
                runat="server" CssClass="box3" MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator31" runat="server" 
                ControlToValidate="txtEditRegdPinCode" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td></tr><tr><td>State</td><td 
            height="25"><asp:DropDownList ID="EditDropDownRegdState" runat="server" 
            AutoPostBack="True" CssClass="box3" 
            OnSelectedIndexChanged="EditDropDownRegdState_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator29" 
            runat="server" ControlToValidate="EditDropDownRegdState" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Fax No</td><td><asp:TextBox 
            ID="txtEditRegdFaxNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
            ID="RequiredFieldValidator32" runat="server" 
            ControlToValidate="txtEditRegdFaxNo" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td></tr><tr><td>City</td><td 
            height="25"><asp:DropDownList ID="EditDropDownRegdCity" runat="server" 
            AutoPostBack="True" CssClass="box3" 
            OnSelectedIndexChanged="EditDropDownRegdCity_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator30" 
            runat="server" ControlToValidate="EditDropDownRegdCity" ErrorMessage="*" 
            InitialValue="Select" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Contact No</td><td><asp:TextBox 
            ID="txtEditRegdContactNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
            ID="RequiredFieldValidator33" runat="server" 
            ControlToValidate="txtEditRegdContactNo" ErrorMessage="*" 
            ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td></tr><tr><td 
            class="style1">Email</td><td><asp:TextBox ID="txtEditRegdEmail" runat="server" 
                CssClass="box3" Width="260px"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator34" runat="server" 
                ControlToValidate="txtEditRegdEmail" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEditRegdEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Edit1">*</asp:RegularExpressionValidator></td><td>&#160;</td><td 
            headers="25">&#160;</td><td>Server Ip</td><td><asp:TextBox ID="txtIpEdit" 
            runat="server" CssClass="box3"></asp:TextBox></td></tr><tr><td 
            class="style1">&#160;</td><td>&#160;</td><td>&#160;</td><td headers="25">&#160;</td><td>&#160;</td><td>&#160;</td></tr></table></td></tr><tr><td 
        bgcolor="#CCCCCC"><b>Plant/Work Details</b></td></tr><tr><td><table cellpadding="0" cellspacing="1" width="100%"><tr><td rowspan="3" valign="top" width="10%">Address</td><td rowspan="3" valign="top" width="29%"><asp:TextBox runat="server" 
                TextMode="MultiLine" CssClass="box3" Height="57px" Width="236px" 
                ID="txtEditPlntAdd"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ValidationGroup="Edit1"
                ControlToValidate="txtEditPlntAdd" ErrorMessage="*">*</asp:RequiredFieldValidator></td><td width="11%">Country</td><td width="18%" height="25"><asp:DropDownList runat="server" CssClass="box3" OnSelectedIndexChanged="EditDropDownPlntCnt_SelectedIndexChanged" 
                ID="EditDropDownPlntCountry" AutoPostBack="True"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ValidationGroup="Edit1"
                ControlToValidate="EditDropDownPlntCountry" ErrorMessage="*" 
        InitialValue="Select">*</asp:RequiredFieldValidator></td><td width="11%">Pin Code</td><td width="21%"><asp:TextBox runat="server" CssClass="box3" ID="txtEditPlntPinCode" 
                MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ValidationGroup="Edit1"
                ControlToValidate="txtEditPlntPinCode" ErrorMessage="*">*</asp:RequiredFieldValidator></td></tr><tr><td>State</td><td 
                height="25"><asp:DropDownList ID="EditDropDownPlntState" runat="server" 
                AutoPostBack="True" CssClass="box3" 
                OnSelectedIndexChanged="EditDropDownPlntSta_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator38" 
                runat="server" ControlToValidate="EditDropDownPlntState" ErrorMessage="*" 
                InitialValue="Select" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Fax No</td><td><asp:TextBox 
                ID="txtEditPlntFaxNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator41" runat="server" 
                ControlToValidate="txtEditPlntFaxNo" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td></tr><tr><td>City</td><td 
                height="25"><asp:DropDownList ID="EditDropDownPlntCity" runat="server" 
                AutoPostBack="True" 
                OnSelectedIndexChanged="EditDropDownPlntCity_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator39" 
                runat="server" ControlToValidate="EditDropDownPlntCity" ErrorMessage="*" 
                InitialValue="Select" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Contact No</td><td><asp:TextBox 
                ID="txtEditPlntContNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator42" runat="server" 
                ControlToValidate="txtEditPlntContNo" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td></tr><tr><td>Email</td><td><asp:TextBox 
                ID="txtEditPlntEmail" runat="server" CssClass="box3" Width="280px"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator36" runat="server" 
                ControlToValidate="txtEditPlntEmail" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator 
                ID="RegularExpressionValidator7" runat="server" 
                ControlToValidate="txtEditPlntEmail" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Edit1">*</asp:RegularExpressionValidator></td><td>ERP Mail</td><td 
                height="25"><asp:TextBox ID="txtErpMailEdit" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqERPMailEdit" runat="server" 
                ControlToValidate="txtErpMailEdit" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Item Code Limit</td><td><asp:TextBox 
                ID="txtItemCodeLimitEdit" runat="server" CssClass="box3" Width="10%"></asp:TextBox><span 
                class="style6">&#160;(&gt;1 and &lt;=15)</span><asp:RangeValidator 
                ID="RangeValItemCode" runat="server" ControlToValidate="txtItemCodeLimitEdit" 
                ErrorMessage="*" MaximumValue="15" MinimumValue="1" Type="Integer" 
                ValidationGroup="Edit1"></asp:RangeValidator></td></tr><tr><td>Ecc No</td><td><asp:TextBox 
                ID="txtEditEccNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator43" runat="server" ControlToValidate="txtEditEccNo" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Commissionerate</td><td 
                height="25"><asp:TextBox ID="txtEditComm" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtEditComm" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>Range</td><td><asp:TextBox 
                ID="txtEditRange" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtEditRange" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td></tr><tr><td>Division</td><td><asp:TextBox 
                ID="txtEditDiv" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtEditDiv" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>VAT No</td><td 
                height="25"><asp:TextBox ID="txtEditVat" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtEditVat" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><td>CST No</td><td><asp:TextBox 
                ID="txtEditCstNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtEditCstNo" 
                ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator></td><tr><td>Licence Nos</td><td><asp:TextBox 
                    ID="txtEditLicenceNo" runat="server" CssClass="box3" MaxLength="5" Width="50px"></asp:TextBox><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator50" runat="server" 
                    ControlToValidate="txtEditLicenceNo" ErrorMessage="*" ValidationGroup="Edit1">*</asp:RequiredFieldValidator><asp:CheckBox 
                    ID="ChkEditComp" runat="server" Text="Default Company"></asp:CheckBox></td><td>PAN No</td><td height="25"><asp:TextBox 
                    ID="txtEditPANNo" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtEditPANNo" 
                    ErrorMessage="*" ValidationGroup="Edit1"></asp:RequiredFieldValidator></td><td>Prefix</td><td><asp:TextBox 
                    ID="txtPrefixEdit" runat="server" CssClass="box3" Width="20%"></asp:TextBox><span 
                    class="style6">&#160;(Emp.No Start)</span><asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtPrefixEdit" 
                    ErrorMessage="*" ValidationGroup="Edit1"></asp:RequiredFieldValidator></td></tr></tr><tr><td>Mobile No.</td><td><asp:TextBox 
                ID="txtupMobileNo" runat="server" CssClass="box3" Width="189px"></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtupMobileNo" 
                ErrorMessage="*" ValidationGroup="Edit1"></asp:RequiredFieldValidator></td><td>Password</td><td 
                height="25"><asp:TextBox ID="txtupPassword" runat="server" CssClass="box3" 
                ></asp:TextBox><asp:RequiredFieldValidator 
                ID="RequiredFieldValidator58" runat="server" ControlToValidate="txtupPassword" 
                ErrorMessage="*" ValidationGroup="Edit1"></asp:RequiredFieldValidator></td><td>Mail Server Ip</td><td><asp:TextBox ID="txtMailServerIpEdit" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqMailServerIPedit" runat="server" 
                    ControlToValidate="txtMailServerIpEdit" ErrorMessage="*" 
                    ValidationGroup="Edit1"></asp:RequiredFieldValidator></td></tr></table></td></tr></table>
                        
                                          
                        </ContentTemplate></cc1:TabPanel>
                        
                       <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Extra"><HeaderTemplate>Asp.Net Configuration
                        </HeaderTemplate>
                        <ContentTemplate>


<table cellpadding="0" cellspacing="0" class="style2"><tr><td><asp:LinkButton 
        ID="linkAddRoles" runat="server" onclick="linkAddRoles_Click" 
        PostBackUrl="~/Admin/Access/roles.aspx">Add Roles</asp:LinkButton></td><td>&#160;</td></tr><tr><td>&#160;</td><td>&#160;</td></tr></table></ContentTemplate>
</cc1:TabPanel>
                        
                    </cc1:TabContainer>
                    
                    </td>
            </tr>
        </table>
  

</asp:Content>


