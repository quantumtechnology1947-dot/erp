<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Module_MaterialManagement_Reports_RateLockUnlock, newerp_deploy" title="ERP" theme="Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" /> 
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="../../../Javascript/PopUpMsg.js" type="text/javascript"></script>
     <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
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
                   
                    <table width="100%" cellpadding="0" cellspacing="0">
                      <tr>
                        <td   align="left" valign="middle"  scope="col" class="fontcsswhite" 
                            style="background:url(../../../images/hdbg.JPG)" height="21">
                    &nbsp;<b>Rate Lock Unlock &nbsp;</b></td>
                    </tr>
                   
                    <tr>
                    <td  height="25" valign="middle" >

                    &nbsp;<asp:DropDownList ID="DrpType" runat="server" AutoPostBack="True" 
                    Height="21px" Width="100px" CssClass="box3" 
                    onselectedindexchanged="DrpType_SelectedIndexChanged">
                     <asp:ListItem>Select</asp:ListItem>
                     <asp:ListItem Value="Category">Category</asp:ListItem>
                     <asp:ListItem Value="WOItems">WO Items</asp:ListItem>                    
                </asp:DropDownList>
                <asp:DropDownList ID="DrpCategory1" runat="server" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DrpCategory1_SelectedIndexChanged" Height="21px" 
                    CssClass="box3">
                    
                </asp:DropDownList> 
                
                 <asp:DropDownList ID="DrpSearchCode" runat="server" Width="200px" 
                    CssClass="box3" AutoPostBack="True" 
                    onselectedindexchanged="DrpSearchCode_SelectedIndexChanged">
                     <asp:ListItem Value="Select">Select</asp:ListItem>
                     <asp:ListItem Value="1">Item Code</asp:ListItem>
                     <asp:ListItem Value="2">Description</asp:ListItem>                    
                     
                </asp:DropDownList>
                
            
                <asp:TextBox ID="txtSearchItemCode" runat="server" Width="207px" 
                    CssClass="box3"></asp:TextBox>
                
                        &nbsp;</td>
                    </tr>
                    <tr>
                    <td height="25" valign="middle">
                        &nbsp;From Date :<asp:TextBox ID="Txtfromdate" runat="server" CssClass="box3" 
                            Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="Txtfromdate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="Txtfromdate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqFrDate" runat="server" 
                    ControlToValidate="Txtfromdate" ErrorMessage="*" ValidationGroup="view">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="Txtfromdate" ErrorMessage="*" ValidationGroup="view" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
                    
                    
            &nbsp;&nbsp;&nbsp;&nbsp;To Date:
                <asp:TextBox ID="TxtTodate" runat="server" CssClass="box3" Width="80px"></asp:TextBox>
                <cc1:CalendarExtender ID="TxtTodate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="TxtTodate" Format="dd-MM-yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="ReqTODate" runat="server" 
                    ControlToValidate="TxtTodate" ErrorMessage="*" ValidationGroup="view"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="TxtTodate" ErrorMessage="*" ValidationGroup="view" 
                ValidationExpression="^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$"></asp:RegularExpressionValidator>
                    
                    
&nbsp; Lock by User :
                        
                     <asp:TextBox ID="TxtEmpName" runat="server" Width="250px" CssClass="box3"></asp:TextBox>
                                          
                          <cc1:AutoCompleteExtender ID="TxtEmpName_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="TxtEmpName" UseContextKey="True"
                             CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                        
                        
                    &nbsp;<asp:Button ID="btnSearch" runat="server" 
                    Text="  View  " CssClass="redbox" onclick="btnSearch_Click"  />
                        
                        
                    </td>
                    </tr>
                   
                    <tr>
                    <td>
                    <iframe id="Iframe1"  runat ="server" width="100%" height="390px" frameborder="0" scrolling="auto" ></iframe>
                    </td>   
                    </tr>
                    </table>       
                           
                      
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

