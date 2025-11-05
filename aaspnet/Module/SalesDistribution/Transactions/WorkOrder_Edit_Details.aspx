<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkOrder_Edit_Details.aspx.cs" Inherits="Module_SalesDistribution_Transactions_WorkOrder_Edit_Details" Title="ERP" Theme ="Default" %>

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
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">

   <table align="center" cellpadding="0" cellspacing="0" width="100%" >
    <tr height="21">
        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" >&nbsp;<b>Work 
            Order - Edit</b></td>
    </tr>
        <tr>
            <td align="left">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="99%" onactivetabchanged="TabContainer1_ActiveTabChanged" >
                    
                    <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                        <HeaderTemplate>Task Execution</HeaderTemplate>
                        <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td colspan="2" align="left" valign="middle" height="25">&nbsp;Customer Name: <asp:Label ID="lblCustomerName" runat="server" style="font-weight: 700"></asp:Label><asp:Label ID="hfCustId" runat="server" Visible="False"></asp:Label><asp:Label ID="hfPoNo" runat="server" Visible="False"></asp:Label></td>
                            <td align="left" height="25" valign="middle">Work Order No: <asp:Label ID="lblWONo" runat="server" style="font-weight: 700"></asp:Label></td>
                            <td align="left" height="25" valign="middle">
                                PO No. :<asp:Label ID="lblPONo" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                            </tr><tr>
                            <td align="left" valign="middle" height="24">Enquiry No:
                                <asp:Label ID="hfEnqId" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                            <td align="left" height="24" valign="middle">
                                Category :
                                <asp:Label ID="lblCategory" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                            <td align="left" height="24" valign="middle">
                                <asp:Label ID="lblSubCategory" runat="server" style="font-weight: 700"></asp:Label>
                            </td>
                            <td align="left" height="24" valign="middle">
                                Date of WO:
                                <asp:TextBox ID="txtWorkOrderDate" runat="server" CssClass="box3" Width="90px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtWorkOrderDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtWorkOrderDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="ReqProjTitle1" runat="server" 
                                    ControlToValidate="txtWorkOrderDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegWorkOrderDate" runat="server" 
                                    ControlToValidate="txtWorkOrderDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                            </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" height="24" valign="middle">
                                    &nbsp;Project Title :<asp:TextBox ID="txtProjectTitle" runat="server" 
                                        CssClass="box3" Width="400px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqProjTitle" runat="server" 
                                        ControlToValidate="txtProjectTitle" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr><td align="left" valign="middle" height="22" colspan="2">&nbsp;Project Leader :<asp:TextBox 
            ID="txtProjectLeader" runat="server" CssClass="box3" Width="300px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle2" runat="server" 
                                    ControlToValidate="txtProjectLeader" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td>
                                <td align="left" colspan="2" height="22" valign="middle">
                                    Business Group:
                                    <asp:DropDownList ID="DDLBusinessGroup" runat="server" CssClass="box3" 
                                        OnSelectedIndexChanged="DDLBusinessGroup_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ReqProjTitle4" runat="server" 
                                        ControlToValidate="DDLBusinessGroup" ErrorMessage="*" InitialValue="Select" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                          <tr>
                            <td>
                                <asp:Label runat="server" Text="Critics" ID="lbledcri"></asp:Label>
                            </td>
                            
                            
                            <td>
                                <asp:TextBox runat="server" ID="txtedcri" CssClass="box3" Width="300px"></asp:TextBox>
                            </td>
                            
                          </tr>
                            
                            
                            <tr><td colspan="4" align="center" valign="middle"><table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td align="left" height="22" valign="middle" width="20%">&#160;Target DAP Date </td><td align="left" valign="middle" width="80%" height="25">&#160;From <asp:TextBox ID="txtTaskTargetDAP_FDate" runat="server" CssClass="box3" 
                                Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDAP_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetDAP_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle5" runat="server" 
                                    ControlToValidate="txtTaskTargetDAP_FDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDAP_FDate" runat="server" 
                                    ControlToValidate="txtTaskTargetDAP_FDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskTargetDAP_TDate" runat="server" CssClass="box3" 
                                Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDAP_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetDAP_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle6" runat="server" 
                                    ControlToValidate="txtTaskTargetDAP_TDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDAP_TDate" runat="server" 
                                    ControlToValidate="txtTaskTargetDAP_TDate" ErrorMessage="*" 
                                    ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                    ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Design Finalization Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskDesignFinalization_FDate" runat="server" 
                                    CssClass="box3" Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskDesignFinalization_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskDesignFinalization_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle7" runat="server" 
                                        ControlToValidate="txtTaskDesignFinalization_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskDesignFinalization_FDate" 
                                        runat="server" ControlToValidate="txtTaskDesignFinalization_FDate" 
                                        ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskDesignFinalization_TDate" runat="server" 
                                    CssClass="box3" Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskDesignFinalization_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskDesignFinalization_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle8" runat="server" 
                                        ControlToValidate="txtTaskDesignFinalization_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskDesignFinalization_TDate" 
                                        runat="server" ControlToValidate="txtTaskDesignFinalization_TDate" 
                                        ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Manufg. Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskTargetManufg_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetManufg_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetManufg_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle9" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetManufg_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskTargetManufg_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetManufg_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetManufg_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle10" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetManufg_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetManufg_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Try-out Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskTargetTryOut_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetTryOut_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetTryOut_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle11" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetTryOut_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskTargetTryOut_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetTryOut_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="BottomRight"
                        Enabled="True" TargetControlID="txtTaskTargetTryOut_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle12" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetTryOut_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetTryOut_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Despatch Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskTargetDespach_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDespach_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskTargetDespach_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle13" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDespach_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskTargetDespach_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetDespach_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskTargetDespach_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle14" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetDespach_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetDespach_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Assembly Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskTargetAssembly_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetAssembly_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskTargetAssembly_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle16" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetAssembly_FDate" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskTargetAssembly_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetAssembly_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskTargetAssembly_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle15" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetAssembly_TDate" runat="server" 
                                        ControlToValidate="txtTaskTargetAssembly_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Target Installation Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskTargetInstalation_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetInstalation_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskTargetInstalation_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle17" runat="server" 
                                        ControlToValidate="txtTaskTargetInstalation_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetInstalation_FDate" 
                                        runat="server" ControlToValidate="txtTaskTargetInstalation_FDate" 
                                        ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskTargetInstalation_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskTargetInstalation_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskTargetInstalation_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle18" runat="server" 
                                        ControlToValidate="txtTaskTargetInstalation_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskTargetInstalation_TDate" 
                                        runat="server" ControlToValidate="txtTaskTargetInstalation_TDate" 
                                        ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr><tr><td align="left" height="22" valign="middle">&#160;Cust. Inspection Date </td><td align="left" valign="middle" height="25">&#160;From <asp:TextBox ID="txtTaskCustInspection_FDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskCustInspection_FDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskCustInspection_FDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle19" runat="server" 
                                        ControlToValidate="txtTaskCustInspection_FDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskCustInspection_FDate" runat="server" 
                                        ControlToValidate="txtTaskCustInspection_FDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator>&#160; To&#160; <asp:TextBox ID="txtTaskCustInspection_TDate" runat="server" CssClass="box3" 
                                    Width="90px"></asp:TextBox><cc1:CalendarExtender ID="txtTaskCustInspection_TDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                        Enabled="True" TargetControlID="txtTaskCustInspection_TDate" Format="dd-MM-yyyy"></cc1:CalendarExtender><asp:RequiredFieldValidator ID="ReqProjTitle20" runat="server" 
                                        ControlToValidate="txtTaskCustInspection_TDate" ErrorMessage="*" 
                                        ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegTaskCustInspection_TDate" runat="server" 
                                        ControlToValidate="txtTaskCustInspection_TDate" ErrorMessage="*" 
                                        ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td></tr>
                                <tr>
                                    <td align="left" height="22" valign="middle">
                                        <asp:Label ID="lblMaterialProcurement" runat="server" 
                                            style="font-weight: 700; font-size: 12px" Text="Material Procurement"></asp:Label>
                                    </td>
                                    <td align="left" height="25" valign="middle">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" height="22" valign="middle">
                                        Manufacturing Material</td>
                                    <td align="left" height="25" valign="middle">
                                        Date
                                        <asp:TextBox ID="txtManufMaterialDate" runat="server" CssClass="box3" 
                                            Width="90px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtManufMaterialDate_CalendarExtender" runat="server" CssClass="cal_Theme2" PopupPosition="TopRight"
                                            Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtManufMaterialDate">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqManufMaterialDate" runat="server" 
                                            ControlToValidate="txtManufMaterialDate" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegManufMaterialDate" runat="server" 
                                            ControlToValidate="txtManufMaterialDate" ErrorMessage="*" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                        Buyer
                                        <asp:DropDownList ID="DDLBuyer" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqBuyer" runat="server" 
                                            ControlToValidate="DDLBuyer" ErrorMessage="*" InitialValue="Select" 
                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" height="22" valign="middle">
                                        Boughtout Material</td>
                                    <td align="left" height="25" valign="middle">
                                        Date
                                        <asp:TextBox ID="txtBoughtoutMaterialDate" runat="server" CssClass="box3" 
                                            Width="90px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtBoughtoutMaterialDate_CalendarExtender" CssClass="cal_Theme2" PopupPosition="TopRight"
                                            runat="server" Enabled="True" Format="dd-MM-yyyy" 
                                            TargetControlID="txtBoughtoutMaterialDate">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqBoughtoutMaterialDate" runat="server" 
                                            ControlToValidate="txtBoughtoutMaterialDate" ErrorMessage="*" 
                                            ValidationGroup="A"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegBoughtoutMaterialDate" runat="server" 
                                            ControlToValidate="txtBoughtoutMaterialDate" ErrorMessage="*" 
                                            ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$" 
                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                </table>&#160;</td></tr><tr><td align="right" colspan="4" 
                                    valign="middle"><asp:Button 
                                    ID="btnTaskNext" runat="server" CssClass="redbox" Text="Next  " 
                                    onclick="btnTaskNext_Click" />&nbsp;<asp:Button ID="btnTaskCancel" runat="server" 
                                    CssClass="redbox" Text="Cancel" onclick="btnTaskCancel_Click" /></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                        <HeaderTemplate>Shipping</HeaderTemplate>
                        <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="6%" rowspan="3" align="left" valign="top">Address</td><td width="44%" rowspan="3" align="left" valign="top"><asp:TextBox ID="txtShippingAdd" runat="server" CssClass="box3" Height="60px" 
            TextMode="MultiLine" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle26" runat="server" 
                                ControlToValidate="txtShippingAdd" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td width="11%" align="left" valign="middle">Country</td><td width="39%" align="left" valign="middle" height="25">:<asp:DropDownList ID="DDLShippingCountry" 
            runat="server" CssClass="box3" AutoPostBack="True" 
                                    onselectedindexchanged="DDLShippingCountry_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqProjTitle37" runat="server" 
                                ControlToValidate="DDLShippingCountry" ErrorMessage="*" InitialValue="Select" 
                                ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">State</td><td align="left" valign="middle" height="25">:<asp:DropDownList 
                                    ID="DDLShippingState" runat="server" CssClass="box3" AutoPostBack="True" 
                                    onselectedindexchanged="DDLShippingState_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqProjTitle38" runat="server" 
                                    ControlToValidate="DDLShippingState" ErrorMessage="*" InitialValue="Select" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle">City</td><td align="left" valign="middle" height="25">:<asp:DropDownList ID="DDLShippingCity" 
                                        runat="server" CssClass="box3" 
                                    onselectedindexchanged="DDLShippingCity_SelectedIndexChanged"></asp:DropDownList><asp:RequiredFieldValidator ID="ReqProjTitle39" runat="server" 
                                    ControlToValidate="DDLShippingCity" ErrorMessage="*" InitialValue="Select" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td colspan="4" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td width="14%" align="left" valign="middle" height="24">Contact Person 1 </td><td width="36%" align="left" valign="middle" height="25">:<asp:TextBox ID="txtShippingContactPerson1" 
                runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle27" runat="server" 
                                    ControlToValidate="txtShippingContactPerson1" ErrorMessage="*" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator></td><td width="11%" align="left" valign="middle">Contact No </td><td width="39%" align="left" valign="middle" height="25">:<asp:TextBox ID="txtShippingContactNo1" 
                runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle33" runat="server" 
                                    ControlToValidate="txtShippingContactNo1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">Email</td><td align="left" valign="middle" height="25">:<asp:TextBox 
                                        ID="txtShippingEmail1" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle28" runat="server" 
                                        ControlToValidate="txtShippingEmail1" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegEmail1" runat="server" 
                                        ErrorMessage="*" ControlToValidate="txtShippingEmail1" ValidationGroup="A" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator></td><td align="left" valign="middle">&nbsp;</td><td align="left" valign="middle">&nbsp;</td></tr><tr><td align="left" valign="middle" height="24">Contact Person 2 </td><td align="left" valign="middle" height="25">:<asp:TextBox 
                                    ID="txtShippingContactPerson2" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle29" runat="server" 
                                    ControlToValidate="txtShippingContactPerson2" ErrorMessage="*" 
                                    ValidationGroup="A"></asp:RequiredFieldValidator></td><td align="left" valign="middle">Contact No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingContactNo2" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle34" runat="server" 
                                    ControlToValidate="txtShippingContactNo2" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">Email</td><td align="left" valign="middle" height="25">:<asp:TextBox 
                                        ID="txtShippingEmail2" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle30" runat="server" 
                                        ControlToValidate="txtShippingEmail2" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegEmail2" runat="server" 
                                        ControlToValidate="txtShippingEmail2" ErrorMessage="*" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                        ValidationGroup="A"></asp:RegularExpressionValidator></td><td align="left" valign="middle">&nbsp;</td><td align="left" valign="middle">&nbsp;</td></tr><tr><td align="left" valign="middle" height="24">Fax No </td><td align="left" valign="middle" height="25">:<asp:TextBox 
                                    ID="txtShippingFaxNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle31" runat="server" 
                                    ControlToValidate="txtShippingFaxNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td align="left" valign="middle">ECC No </td><td align="left" valign="middle">:<asp:TextBox 
                                    ID="txtShippingEccNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle35" runat="server" 
                                    ControlToValidate="txtShippingEccNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">TIN/CST No.</td><td align="left" valign="middle" height="25">:<asp:TextBox 
                                        ID="txtShippingTinCstNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle32" runat="server" 
                                        ControlToValidate="txtShippingTinCstNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td><td align="left" valign="middle">TIN/VAT No.</td><td align="left" valign="middle">:<asp:TextBox 
                                        ID="txtShippingTinVatNo" runat="server" 
                CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle36" runat="server" 
                                        ControlToValidate="txtShippingTinVatNo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td valign="middle">&nbsp;</td><td valign="middle">&nbsp;</td><td valign="middle">&nbsp;</td><td align="right" valign="middle"><asp:Button 
                                        ID="btnShippingNext" runat="server" CssClass="redbox" Text="Next  " 
                                        onclick="btnShippingNext_Click" />&nbsp;<asp:Button ID="btnShippingCancel" 
                                        runat="server" CssClass="redbox" Text="Cancel" 
                                        onclick="btnShippingCancel_Click" /></td></tr></table></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                    
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>Products</HeaderTemplate>
                    <ContentTemplate>
                    
                    
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="22%" align="center" valign="middle">Item Code </td><td width="38%" align="center" valign="middle">Desc.of Item </td><td width="17%" align="center" valign="middle">Qty</td><td width="23%" align="left" valign="middle">&nbsp;</td></tr><tr><td 
                            align="center" valign="middle"><asp:TextBox ID="txtItemCode" runat="server" 
                            CssClass="box3" Width="180px"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle23" runat="server" 
                            ControlToValidate="txtItemCode" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td align="center" 
                            valign="middle"><asp:TextBox ID="txtDescOfItem" runat="server" TextMode="MultiLine" 
                                Width="300px" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle24" runat="server" 
                                ControlToValidate="txtDescOfItem" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator></td><td align="center" valign="middle"><asp:TextBox 
                                ID="txtQty" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle25" runat="server" 
                                ControlToValidate="txtQty" ErrorMessage="*" ValidationGroup="B"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegQty" runat="server" 
                                ControlToValidate="txtQty" ErrorMessage="*" 
                                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="B"></asp:RegularExpressionValidator></td><td align="center" valign="middle"><asp:Button 
                                ID="btnProductSubmit" runat="server" OnClientClick="return confirmationAdd()" onclick="btnProductSubmit_Click" CssClass="redbox"
                                Text="Submit" ValidationGroup="B" />&nbsp;<asp:Button ID="btnProductNext" runat="server" CssClass="redbox" Text="Next  " 
                                onclick="btnProductNext_Click" />&nbsp;<asp:Button ID="btnProductCancel" 
                                runat="server" CssClass="redbox" Text="Cancel" 
                                onclick="btnProductCancel_Click" /></td></tr><tr><td align="left" 
                                colspan="4" valign="middle"><br />
                                
                                <asp:GridView ID="GridView1" runat="server" Width="70%" AutoGenerateColumns="False" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowcancelingedit="GridView1_RowCancelingEdit"  DataKeyNames="Id" CssClass="yui-datatable-theme"
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" AllowPaging="True" PageSize="5" 
                                onrowdatabound="GridView1_RowDataBound"  >
                                
                                <Columns>
                            <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                            </asp:TemplateField>
                  
                  
                  <asp:CommandField ShowEditButton="True"  ValidationGroup="edit"><ItemStyle Width="4%" HorizontalAlign="Center" /></asp:CommandField>
                  
                  <asp:CommandField ShowDeleteButton="True"><ItemStyle Width="4%" HorizontalAlign="Center" /></asp:CommandField>
             
             <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>' /></ItemTemplate><ItemStyle Width="8%" /></asp:TemplateField>
             
             <asp:TemplateField HeaderText="Item Code" ><ItemTemplate><asp:Label ID="lblCode" runat="server" Text='<%#Eval("ItemCode") %>' /></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtItemCode" Text='<%#Eval("ItemCode") %>' runat="server"> </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="edit" ControlToValidate="txtItemCode" runat="server" ErrorMessage="*"> </asp:RequiredFieldValidator></EditItemTemplate><ItemStyle Width="12%" /></asp:TemplateField>
             
             <asp:TemplateField HeaderText="Description" >
             <ItemTemplate>
             <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>' />
             </ItemTemplate>
             <EditItemTemplate>
             <asp:TextBox ID="txtDesc" Text='<%#Eval("Description") %>' runat="server" Width="95%"> </asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
             ValidationGroup="edit" ControlToValidate="txtDesc" ErrorMessage="*"> </asp:RequiredFieldValidator>
             </EditItemTemplate>
             <ItemStyle Width="40%" />
             </asp:TemplateField>
             
            <asp:TemplateField HeaderText="Quantity" >
            <ItemTemplate>
            <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>' />
            </ItemTemplate>
            <EditItemTemplate>
            <asp:TextBox ID="txtQty" Text='<%#Eval("Qty") %>' runat="server"  Width="80%" >  </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="edit" 
            ControlToValidate="txtQty"  runat="server" ErrorMessage="*"> 
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegQty1" runat="server" 
            ControlToValidate="txtQty" ErrorMessage="*" 
            ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit">
            </asp:RegularExpressionValidator>
            </EditItemTemplate>
            <ItemStyle HorizontalAlign="Right" Width="10%" />
            </asp:TemplateField>
                                
                                
                                </Columns>
                                
                                <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table>
                                </EmptyDataTemplate>
                                
                                </asp:GridView>
                                
                                
                                <asp:Label ID="lblMessage" runat="server" ForeColor="#CC0000"></asp:Label>
                                
                                <br /><br /></td></tr>
                                <tr>
                                <td align="left" colspan="4" valign="middle">
                                    <asp:GridView ID="GridView2" 
                                        runat="server" AutoGenerateColumns="False" 
                                    CssClass="yui-datatable-theme" DataKeyNames="Id" DataSourceID="SqlDataSource1"
                                    HorizontalAlign="Left" OnRowCancelingEdit="GridView2_RowCancelingEdit" 
                                    OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" 
                                    OnRowEditing="GridView2_RowEditing" OnRowUpdated="GridView2_RowUpdated" 
                                    OnRowUpdating="GridView2_RowUpdating" Width="70%" AllowPaging="True" 
                                        PageSize="5">
                                    <Columns>
                            <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="4%" />
                            </asp:TemplateField>
                                    
                                    <asp:CommandField ShowEditButton="True"   ValidationGroup="edit"><ItemStyle HorizontalAlign="Center" Width="4%"  /></asp:CommandField>
                                    <asp:CommandField ShowDeleteButton="True"><ItemStyle HorizontalAlign="Center" Width="4%" /></asp:CommandField>
                   
                   <asp:TemplateField HeaderText="Item Code"><ItemTemplate><asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtItemCode0" runat="server" Text='<%#Eval("ItemCode") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqItemCode" runat="server" 
                                                    ControlToValidate="txtItemCode0" ErrorMessage="*" ValidationGroup="edit"></asp:RequiredFieldValidator></EditItemTemplate>
                                                    
                                                    <ItemStyle Width="12%" />
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Id" Visible="False"><ItemTemplate><asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                    
                <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                
                <EditItemTemplate>
                <asp:TextBox ID="txtDescription0" runat="server" Width="95%"
                Text='<%#Eval("Description") %>'>
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqDescription" runat="server" 
                ControlToValidate="txtDescription0" ErrorMessage="*" ValidationGroup="edit">
                </asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemStyle Width="40%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty") %>'>
                </asp:Label>
                </ItemTemplate>
                
                <EditItemTemplate>
                <asp:TextBox ID="txtQty0" runat="server" Width="80%" Text='<%#Eval("Qty") %>'> </asp:TextBox>
                <asp:RequiredFieldValidator ID="ReqQty" runat="server" 
                ControlToValidate="txtQty0" ErrorMessage="*" ValidationGroup="edit"> 
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegQty0" runat="server" 
                ControlToValidate="txtQty0" ErrorMessage="*" 
                ValidationExpression="^\d{1,15}(\.\d{0,3})?$" ValidationGroup="edit">
                </asp:RegularExpressionValidator>
                </EditItemTemplate>
                
                <ItemStyle HorizontalAlign="Right" Width="10%"/>
                </asp:TemplateField>
                                
                                </Columns>
                                <EmptyDataTemplate><table width="100%" class="fontcss"><tr><td align="center"><asp:Label ID="Label1" runat="server"  Text="No data to display !" Font-Size="Larger" ForeColor="maroon"> </asp:Label></td></tr></table></EmptyDataTemplate>
                                
                                </asp:GridView>
                                
                                </td></tr></table>
                                
                                

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LocalSqlServer %>" 
            DeleteCommand="DELETE FROM [SD_Cust_WorkOrder_Products_Details] WHERE [Id] = @Id" 
            InsertCommand="INSERT INTO [SD_Cust_WorkOrder_Products_Details] ([ItemCode], [Description], [Qty]) VALUES (@ItemCode, @Description, @Qty)" 
            ProviderName="System.Data.SqlClient" 
            SelectCommand="SELECT [ItemCode], [Description], [Qty], [Id] FROM [SD_Cust_WorkOrder_Products_Details] WHERE ([MId] = @Id) order by Id Desc" 
            UpdateCommand="UPDATE [SD_Cust_WorkOrder_Products_Details] SET [ItemCode] = @ItemCode, [Description] = @Description, [Qty] = @Qty WHERE [Id] = @Id">
            <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            
            <InsertParameters>
            <asp:Parameter Name="ItemCode" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Qty" Type="String" />
            </InsertParameters>
            
            <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />
            </SelectParameters>
            
            <UpdateParameters>
            <asp:Parameter Name="ItemCode" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Qty" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters></asp:SqlDataSource>             
                         
                        
                    </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>Instructions</HeaderTemplate>
                          <ContentTemplate><table width="100%" border="0" cellspacing="0" cellpadding="0" class="fontcss"><tr><td width="29%" align="left" valign="middle" height="24">Primer Painting to be done.</td><td width="71%" align="left" valign="middle"><asp:CheckBox ID="CKInstractionPrimerPainting" runat="server" /></td></tr><tr><td align="left" valign="middle" height="24">Painting to be done.</td><td align="left" valign="middle"><asp:CheckBox ID="CKInstractionPainting" runat="server" /></td></tr><tr><td align="left" valign="middle" height="24">Self Certification Report to be submitted.</td><td align="left" valign="middle"><asp:CheckBox ID="CKInstractionSelfCertRept" runat="server" /></td></tr><tr><td align="left" valign="top" height="24">others</td><td align="left" valign="middle"><asp:TextBox 
                                  ID="txtInstractionOther" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle21" runat="server" 
                                  ControlToValidate="txtInstractionOther" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td align="left" valign="middle" height="24">Export Case Mark</td><td align="left" valign="middle"><asp:TextBox ID="txtInstractionExportCaseMark" runat="server" CssClass="box3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqProjTitle22" runat="server" 
                                      ControlToValidate="txtInstractionExportCaseMark" ErrorMessage="*" 
                                      ValidationGroup="A"></asp:RequiredFieldValidator></td></tr><tr><td colspan="2" align="left" valign="middle" height="24">Attach Annexure</td></tr><tr><td colspan="2" align="left" valign="top" height="110">&nbsp;</td></tr><tr><td colspan="2" align="left" valign="middle">*Packing Instructions&#160;: Export Seaworthy / Wooden / Corrugated 7 day before desp.</td></tr><tr><td align="right" colspan="2" valign="middle"><asp:Button ID="btnUpdate" runat="server" CssClass="redbox" Text="Update" OnClientClick="return confirmationUpdate()"
                                  onclick="btnUpdate_Click" ValidationGroup="A" 
                                   />&nbsp;<asp:Button ID="btnCancel" runat="server" 
                                  CssClass="redbox" Text="Cancel" onclick="btnCancel_Click" /></td></tr></table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

