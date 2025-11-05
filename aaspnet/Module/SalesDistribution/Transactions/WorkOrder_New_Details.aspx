<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkOrder_New_Details.aspx.cs" Inherits="Module_SalesDistribution_Transactions_WorkOrder_New_Details" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cp3" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cp1" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cp2" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
 <table align="center" cellpadding="0" cellspacing="0" width="100%" >
    <tr height="21">
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Work 
            Order - New</b>
        </td>
    </tr>
        <tr>
            <td align="left">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>Task Execution
                    </HeaderTemplate>
                        
<ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr>
    <td colspan="2" align="left" valign="middle" height="25">&nbsp;Customer Name: <asp:Label ID="lblCustomerName" runat="server"></asp:Label><asp:Label ID="hfCustId" runat="server" Visible="False"></asp:Label><asp:Label ID="hfPoNo" runat="server" Visible="False"></asp:Label></td>
    <td align="left" colspan="2" height="25" valign="middle">
        PO No. :<asp:Label ID="lblPONo" runat="server" style="font-weight: 700"></asp:Label>
    </td>
    </tr><tr><td align="left" valign="middle" 
            height="25">&nbsp;Enquiry No: <asp:Label ID="hfEnqId" runat="server"></asp:Label></td><td align="left" height="25" style="width: -75%" valign="middle" width="30%">Category :<asp:DropDownList ID="DDLTaskWOType" runat="server" 
                AutoPostBack="True" CssClass="box3" 
                DataTextField="CName" DataValueField="CId" 
                onselectedindexchanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqWoType" runat="server" 
                ControlToValidate="DDLTaskWOType" ErrorMessage="*" InitialValue="Select" 
                ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td align="left" height="25" style="width: -22%" valign="middle" width="30%">
            <asp:DropDownList ID="DDLSubcategory" runat="server" 
                AutoPostBack="True" CssClass="box3" DataTextField="SCName" 
                DataValueField="SCId" Visible="False"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqWoType0" runat="server" 
                ControlToValidate="DDLSubcategory" ErrorMessage="*" InitialValue="Select" 
                ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td align="left" height="25" style="width: -5%" valign="middle" width="30%">Date of WO :<asp:TextBox ID="txtWorkOrderDate" runat="server" CssClass="box3" 
                Width="90px"></asp:TextBox>
                
              <cc1:CalendarExtender ID="txtWorkOrderDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtWorkOrderDate"></cc1:CalendarExtender>
                
                
                <asp:RequiredFieldValidator ID="ReqWoDate" runat="server" 
                ControlToValidate="txtWorkOrderDate" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegWorkOrderDate" runat="server" 
                ControlToValidate="txtWorkOrderDate" ErrorMessage="*" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td colspan="4" align="left" valign="middle" height="25">&#160;Project Title: <asp:TextBox 
                                    ID="txtProjectTitle" runat="server" CssClass="box3" Width="400px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjectTitle" runat="server" 
                                    ControlToValidate="txtProjectTitle" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr>
                                    <tr>
                                    <td align="left" valign="middle" height="25" colspan="3">&#160;Project Leader:
                                     <asp:TextBox ID="txtProjectLeader" runat="server" CssClass="box3" Width="300px"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="ReqProLead" runat="server" 
                                    ControlToValidate="txtProjectLeader" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" height="25" valign="middle">Business Group:<asp:DropDownList ID="DDLBusinessGroup" runat="server" 
                CssClass="box3"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqBG" runat="server" 
                ControlToValidate="DDLBusinessGroup" ErrorMessage="*" InitialValue="Select" 
                ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr>
                
                
                <tr>
                 <td align="left" valign="middle" height="25" colspan="3">&#160;Critics:
                 
                 <asp:TextBox runat="server" ID="txtcri" CssClass="box3" Width="300px"></asp:TextBox>
                 
                 </td>
                
                </tr>
                
                <tr><td colspan="4" align="center" valign="middle"><table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td align="left" valign="middle" height="25">&nbsp;Target DAP Date </td><td align="left" valign="middle" width="80%" height="25">From <asp:TextBox ID="txtTaskTargetDAP_FDate" runat="server" CssClass="box3" 
                                Width="90px"></asp:TextBox>
                                
                                <cc1:CalendarExtender ID="txtTaskTargetDAP_FDate_CalendarExtender" CssClass="cal_Theme2" PopupPosition="BottomRight"
                                        runat="server" Enabled="True" Format="dd-MM-yyyy" 
                                        TargetControlID="txtTaskTargetDAP_FDate"></cc1:CalendarExtender>
                                        
                                        <asp:RequiredFieldValidator ID="ReqDapFdt" runat="server" 
                                        ControlToValidate="txtTaskTargetDAP_FDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDAP_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetDAP_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskTargetDAP_TDate" runat="server" CssClass="box3" 
                                Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDAP_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetDAP_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                        
                        <asp:RequiredFieldValidator ID="ReqDApToDt" runat="server" 
                                        ControlToValidate="txtTaskCustInspection_TDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDAP_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetDAP_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle" class="style4">&#160;Design Finalization Date </td><td align="left" valign="middle" height="25">From <asp:TextBox ID="txtTaskDesignFinalization_FDate" runat="server" 
                                    CssClass="box3" Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskDesignFinalization_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskDesignFinalization_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqFinFDt" runat="server" 
                                        ControlToValidate="txtTaskDesignFinalization_FDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskDesignFinalization_FDate" 
                                        runat="server" ControlToValidate="txtTaskDesignFinalization_FDate" 
                                        ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskDesignFinalization_TDate" runat="server" 
                                    CssClass="box3" Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskDesignFinalization_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskDesignFinalization_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqFinToDt" runat="server" 
                                        ControlToValidate="txtTaskDesignFinalization_TDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskDesignFinalization_TDate" 
                                        runat="server" ControlToValidate="txtTaskDesignFinalization_TDate" 
                                        ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle" class="style4">&nbsp;Target Manufg. Date </td><td align="left" valign="middle" height="25">From <asp:TextBox ID="txtTaskTargetManufg_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetManufg_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetManufg_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqMfgFrDt" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_FDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetManufg_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskTargetManufg_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetManufg_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetManufg_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqMfgToDt" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_TDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetManufg_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle" class="style4">&nbsp;Target Try-out Date </td><td align="left" valign="middle" height="25">From <asp:TextBox ID="txtTaskTargetTryOut_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetTryOut_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetTryOut_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqTryOutFrDt" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_FDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetTryOut_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskTargetTryOut_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetTryOut_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetTryOut_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqTryOutTODt" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_TDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetTryOut_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle" class="style4">&nbsp;Target Despatch Date </td><td align="left" valign="middle" height="25">From <asp:TextBox ID="txtTaskTargetDespach_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDespach_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetDespach_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender>
                        
                        
                        <asp:RequiredFieldValidator ID="ReqDesptFrDt" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_FDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDespach_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskTargetDespach_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDespach_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetDespach_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqDisptToDt" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_TDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDespach_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle" class="style4">&nbsp;Target Assembly Date </td><td align="left" valign="middle" height="25">From <asp:TextBox ID="txtTaskTargetAssembly_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetAssembly_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetAssembly_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqAssFrDt" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_FDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetAssembly_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskTargetAssembly_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetAssembly_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetAssembly_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqAssToDt" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_TDate" ErrorMessage="*" 
                                        ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetAssembly_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" class="style4" height="22" valign="middle">Target Installation Date</td><td align="left" height="25" valign="middle">From <asp:TextBox ID="txtTaskTargetInstalation_FDate" runat="server" CssClass="box3" 
                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetInstalation_FDate_CalendarExtender" 
                    runat="server" Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="TopRight"
                    TargetControlID="txtTaskTargetInstalation_FDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqInstallFrDt" runat="server" 
                    ControlToValidate="txtTaskTargetInstalation_FDate" ErrorMessage="*" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetInstalation_FDate" 
                    runat="server" ControlToValidate="txtTaskTargetInstalation_FDate" 
                    ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskTargetInstalation_TDate" runat="server" 
                    CssClass="box3" Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetInstalation_TDate_CalendarExtender" 
                    runat="server" Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="TopRight"
                    TargetControlID="txtTaskTargetInstalation_TDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqInstalFrDt" runat="server" 
                    ControlToValidate="txtTaskCustInspection_TDate" ErrorMessage="*" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetInstalation_TDate" 
                    runat="server" ControlToValidate="txtTaskTargetInstalation_TDate" 
                    ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" class="style4" height="22" valign="middle">Cust. Inspection Date</td><td align="left" height="25" valign="middle">From <asp:TextBox ID="txtTaskCustInspection_FDate" runat="server" CssClass="box3" 
                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskCustInspection_FDate_CalendarExtender" 
                    runat="server" Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="TopRight"
                    TargetControlID="txtTaskCustInspection_FDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqInsptFrDt" runat="server" 
                    ControlToValidate="txtTaskCustInspection_FDate" ErrorMessage="*" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskCustInspection_FDate" runat="server" 
                    ControlToValidate="txtTaskCustInspection_FDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="Submit"></asp:RegularExpressionValidator>To <asp:TextBox ID="txtTaskCustInspection_TDate" runat="server" CssClass="box3" 
                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskCustInspection_TDate_CalendarExtender" 
                    runat="server" Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="TopRight"
                    TargetControlID="txtTaskCustInspection_TDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqInspFrDt" runat="server" 
                    ControlToValidate="txtTaskCustInspection_TDate" ErrorMessage="*" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskCustInspection_TDate" runat="server" 
                    ControlToValidate="txtTaskCustInspection_TDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr><tr><td align="left" class="style4" height="22" valign="middle"><asp:Label ID="lblMaterialProcurement" runat="server" 
                    style="font-weight: 700; font-size: 12px" Text="Material Procurement"></asp:Label></td><td align="left" height="25" valign="middle">&#160;</td></tr><tr><td align="left" class="style4" height="22" valign="middle">Manufacturing Material</td><td align="left" height="25" valign="middle">Date <asp:TextBox ID="txtManufMaterialDate" runat="server" CssClass="box3" 
                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtManufMaterialDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                    Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtManufMaterialDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqManufMaterialDate" runat="server" 
                    ControlToValidate="txtManufMaterialDate" ErrorMessage="*" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegManufMaterialDate" runat="server" 
                    ControlToValidate="txtManufMaterialDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="Submit"></asp:RegularExpressionValidator>Buyer <asp:DropDownList ID="DDLBuyer" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqBuyer" runat="server" 
                    ControlToValidate="DDLBuyer" ErrorMessage="*" InitialValue="Select" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" class="style4" height="22" valign="middle">Boughtout Material</td><td align="left" height="25" valign="middle">Date <asp:TextBox ID="txtBoughtoutMaterialDate" runat="server" CssClass="box3" 
                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtBoughtoutMaterialDate_CalendarExtender" 
                    runat="server" Enabled="True" Format="dd-MM-yyyy" CssClass="cal_Theme2" PopupPosition="TopRight"
                    TargetControlID="txtBoughtoutMaterialDate"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqBoughtoutMaterialDate" runat="server" 
                    ControlToValidate="txtBoughtoutMaterialDate" ErrorMessage="*" 
                    ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegBoughtoutMaterialDate" runat="server" 
                    ControlToValidate="txtBoughtoutMaterialDate" ErrorMessage="*" 
                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                    ValidationGroup="Submit"></asp:RegularExpressionValidator></td></tr></table>&nbsp;</td></tr><tr><td align="right" colspan="4" valign="middle"><asp:Button 
                                    ID="btnTaskNext" runat="server" CssClass="redbox" Text="Next  " 
                                    onclick="btnTaskNext_Click" />&nbsp;</td></tr></table>
                        </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>Shipping
                    </HeaderTemplate>
                        
<ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td valign="top" align="left" rowspan="3" width="6%">Address</td><td width="44%" rowspan="3" align="left" valign="top"><asp:TextBox ID="txtShippingAdd" runat="server" CssClass="box3" Height="60px" 
            TextMode="MultiLine" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipAdd" runat="server" 
        ControlToValidate="txtShippingAdd" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td width="11%" align="left" valign="middle">Country</td><td width="39%" align="left" valign="middle">:<asp:DropDownList ID="DDLShippingCountry" 
            runat="server" CssClass="box3" AutoPostBack="True" 
                                    onselectedindexchanged="DDLShippingCountry_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqShipCountry" runat="server" 
        ControlToValidate="DDLShippingCountry" ErrorMessage="*" InitialValue="Select" 
        ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">State</td><td align="left" valign="middle">:<asp:DropDownList 
                                    ID="DDLShippingState" runat="server" CssClass="box3" AutoPostBack="True" 
                                    onselectedindexchanged="DDLShippingState_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqShipState" runat="server" 
            ControlToValidate="DDLShippingState" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">City</td><td align="left" valign="middle">:<asp:DropDownList ID="DDLShippingCity" 
                                        runat="server" CssClass="box3" 
                                    
            onselectedindexchanged="DDLShippingCity_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqShipCity" runat="server" 
            ControlToValidate="DDLShippingCity" ErrorMessage="*" InitialValue="Select" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td valign="top" colspan="4"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td width="14%" align="left" valign="middle" height="24">Contact Person 1 </td><td width="36%" align="left" valign="middle">:<asp:TextBox ID="txtShippingContactPerson1" 
                runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipContPer" runat="server" 
            ControlToValidate="txtShippingContactPerson1" ErrorMessage="*" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td width="11%" align="left" valign="middle">Contact No </td><td width="39%" align="left" valign="middle">:<asp:TextBox ID="txtShippingContactNo1" 
                runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipContNo1" runat="server" 
            ControlToValidate="txtShippingContactNo1" ErrorMessage="*" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">Email</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingEmail1" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipMail1" runat="server" 
                ControlToValidate="txtShippingEmail1" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegEmail1" runat="server" 
                ControlToValidate="txtShippingEmail1" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Submit"></asp:RegularExpressionValidator></td><td align="left" valign="middle">&#160;</td><td align="left" valign="middle">&nbsp;</td></tr><tr><td align="left" valign="middle" height="24">Contact Person 2 </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingContactPerson2" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipContper2" runat="server" 
            ControlToValidate="txtShippingContactPerson2" ErrorMessage="*" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td align="left" valign="middle">Contact No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingContactNo2" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipContNo2" runat="server" 
            ControlToValidate="txtShippingContactNo2" ErrorMessage="*" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">Email</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingEmail2" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqshipMail2" runat="server" 
                ControlToValidate="txtShippingEmail2" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegEmail2" runat="server" 
                ControlToValidate="txtShippingEmail2" ErrorMessage="*" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ValidationGroup="Submit"></asp:RegularExpressionValidator></td><td align="left" valign="middle">&#160;</td><td align="left" valign="middle">&nbsp;</td></tr><tr><td align="left" valign="middle" height="24">Fax No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingFaxNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipFax" runat="server" 
            ControlToValidate="txtShippingFaxNo" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td align="left" valign="middle">ECC No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingEccNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipECC" runat="server" 
            ControlToValidate="txtShippingEccNo" ErrorMessage="*" ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">TIN/CST No.</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingTinCstNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipTinCst" runat="server" 
                ControlToValidate="txtShippingTinCstNo" ErrorMessage="*" 
                ValidationGroup="Submit"></asp:RequiredFieldValidator></td><td align="left" valign="middle">TIN/VAT No.</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingTinVatNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqShipTinVat" runat="server" 
                ControlToValidate="txtShippingTinVatNo" ErrorMessage="*" 
                ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td valign="middle">&#160;</td><td valign="middle">&nbsp;</td><td valign="middle">&nbsp;</td><td align="right" valign="middle"><asp:Button 
                                        ID="btnShippingNext" runat="server" CssClass="redbox" Text="Next  " 
                                        onclick="btnShippingNext_Click" />&nbsp;</td></tr></table></td></tr></table>
                        </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>Products
                    </HeaderTemplate>
                    
<ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td align="center" valign="top" width="30%"><table align="left" cellpadding="0" cellspacing="0" width="98%"><tr><td align="left" class="style4">Item Code </td><td align="left" class="style4" width="80%"><asp:TextBox ID="txtItemCode" runat="server" CssClass="box3" Width="180px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqItemCode" runat="server" 
                            ControlToValidate="txtItemCode" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td></tr><tr><td align="left" colspan="2" valign="top">Desc.of Item </td></tr><tr><td align="left" valign="top"></td><td align="left"><asp:TextBox ID="txtDescOfItem" runat="server" CssClass="box3" 
                            TextMode="MultiLine" Width="300px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqItemDesc" runat="server" 
                            ControlToValidate="txtDescOfItem" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td></tr><tr><td align="left">Qty</td><td align="left" height="24"><asp:TextBox ID="txtQty" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqItemQty" runat="server" 
                            ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegQty" runat="server" 
                            ControlToValidate="txtQty" ErrorMessage="*" 
                            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator></td></tr><tr><td>&#160;</td><td align="left" height="27" width="50%"><asp:Button ID="btnProductSubmit" runat="server" CssClass="redbox" 
                            OnClick="btnProductSubmit_Click" OnClientClick="return confirmationAdd()" 
                            Text="Submit" ValidationGroup="B" /><asp:Button ID="btnProductNext" runat="server" CssClass="redbox" 
                            OnClick="btnProductNext_Click" Text="Next  " /></td></tr></table></td><td align="center" valign="top" width="60%"><asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CssClass="yui-datatable-theme" DataKeyNames="Id" 
                OnPageIndexChanging="GridView1_PageIndexChanging" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
                PageSize="17" Width="98%"><Columns><asp:TemplateField HeaderText="SN"><ItemTemplate></ItemTemplate><ItemStyle HorizontalAlign="Right" Width="4%" /></asp:TemplateField><asp:CommandField ShowEditButton="True" ValidationGroup="edit"><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:CommandField><asp:CommandField ShowDeleteButton="True"><ItemStyle HorizontalAlign="Center" Width="7%" /></asp:CommandField><asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' /></ItemTemplate><ItemStyle Width="8%" /></asp:TemplateField><asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>' /></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtItemCode" runat="server" Text='<%#Eval("ItemCode") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtItemCode" ErrorMessage="*" ValidationGroup="edit"> </asp:RequiredFieldValidator></EditItemTemplate><ItemStyle Width="12%" /></asp:TemplateField><asp:TemplateField HeaderText="Description"><ItemTemplate><asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>' /></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtDesc" runat="server" Text='<%#Eval("Description") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtDesc" ErrorMessage="*" ValidationGroup="edit"> </asp:RequiredFieldValidator></EditItemTemplate><ItemStyle Width="40%" /></asp:TemplateField><asp:TemplateField HeaderText="Quantity"><ItemTemplate><asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>' /></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtQty" runat="server" Text='<%#Eval("Qty") %>'> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="edit"> </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegQty1" runat="server" 
                                ControlToValidate="txtQty" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit"></asp:RegularExpressionValidator></EditItemTemplate><ItemStyle HorizontalAlign="Right" Width="10%" /></asp:TemplateField></Columns><EmptyDataTemplate><table class="fontcss" width="100%"><tr><td align="center"><asp:Label ID="Label1" runat="server" Font-Size="Larger" ForeColor="maroon" 
                                    Text="No data to display !"> </asp:Label></td></tr></table></EmptyDataTemplate></asp:GridView></td></tr><tr><td align="center" valign="middle">&nbsp;</td><td align="left" valign="middle"><asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label></td></tr></table>
                        
                    </ContentTemplate>
                    
</cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>Instructions
                    </HeaderTemplate>
                          
<ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="29%" align="left" valign="middle" height="24">Primer Painting to be done.</td><td width="71%" align="left" valign="middle"><asp:CheckBox ID="CKInstractionPrimerPainting" runat="server" /></td></tr><tr><td align="left" valign="middle" height="24">Painting to be done.</td><td align="left" valign="middle"><asp:CheckBox ID="CKInstractionPainting" runat="server" /></td></tr><tr><td align="left" valign="middle" height="24">Self Certification Report to be submitted.</td><td align="left" valign="middle"><asp:CheckBox ID="CKInstractionSelfCertRept" runat="server" /></td></tr><tr><td align="left" valign="top" height="24">others</td><td align="left" valign="middle"><asp:TextBox 
                                  ID="txtInstractionOther" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqDesptFrDt0" runat="server" 
                                  ControlToValidate="txtInstractionOther" ErrorMessage="*" 
                                  ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">Export Case Mark</td><td align="left" valign="middle"><asp:TextBox ID="txtInstractionExportCaseMark" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqDesptFrDt1" runat="server" 
            ControlToValidate="txtInstractionExportCaseMark" ErrorMessage="*" 
            ValidationGroup="Submit"></asp:RequiredFieldValidator></td></tr><tr><td colspan="2" align="left" valign="middle" height="24">Attach Annexure</td></tr><tr><td colspan="2" align="left" valign="top" height="110"></td></tr><tr><td colspan="2" align="left" valign="middle">*Packing Instructions&#160;: Export Seaworthy / Wooden / Corrugated 7 day before desp.</td></tr><tr><td align="right" colspan="2" valign="middle">&#160;</td></tr></table>
                        </ContentTemplate>
                    
</cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td align="center" height="25" valign="middle">
                <asp:Button runat="server" OnClientClick="return confirmationAdd()" Text="Submit" ValidationGroup="Submit" CssClass="redbox" ID="btnSubmit" OnClick="btnSubmit_Click">
                </asp:Button>
&nbsp;<asp:Button runat="server" Text="Cancel" CssClass="redbox" ID="btnCancel" OnClick="btnCancel_Click">
                </asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

