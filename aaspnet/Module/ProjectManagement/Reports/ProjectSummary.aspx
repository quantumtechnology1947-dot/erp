<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectSummary.aspx.cs" Inherits="Module_ProjectManagement_Reports_ProjectSummary" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../../../Javascript/loadingNotifier.js" type="text/javascript"></script>
    
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


<%--<script type="text/javascript">
var prm = Sys.WebForms.PageRequestManager.getInstance();
//Raised before processing of an asynchronous postback starts and the postback request is sent to the server.
prm.add_beginRequest(BeginRequestHandler);
// Raised after an asynchronous postback is finished and control has been returned to the browser.
prm.add_endRequest(EndRequestHandler);
function BeginRequestHandler(sender, args) {
//Shows the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.show();
}
}

function EndRequestHandler(sender, args) {
//Hide the modal popup - the update progress
var popup = $find('<%= modalPopup.ClientID %>');
if (popup != null) {
popup.hide();
}
}
</script>-

<%--<%--div>   
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
<ProgressTemplate>
<asp:Image ID="Image1" ImageUrl="~/images/spinner-big.gif" AlternateText="Processing" runat="server" />
</ProgressTemplate>
</asp:UpdateProgress>
<cc1:ModalPopupExtender ID="modalPopup" runat="server" TargetControlID="UpdateProgress"
PopupControlID="UpdateProgress" BackgroundCssClass="modalPopup" />
<asp:UpdatePanel ID="pnlData" runat="server" UpdateMode="Conditional">
   <ContentTemplate> --%>

<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
       
                
                    <tr height="21">
                        <td style="background:url(../../../images/hdbg.JPG)" class="fontcsswhite" ><strong>&nbsp;Project Summary </strong>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    
                 <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="420px"
Width="100%"  AutoPostBack="True" onactivetabchanged="TabContainer1_ActiveTabChanged">
<cc1:TabPanel runat="server" HeaderText="Item Wise" ID="TabPanel1"><ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0">

            
             <tr>
            <td class="fontcsswhite" height="25" >
             <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType" OnSelectedIndexChanged="DDLTaskWOType_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="180px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AutoPostBack="True">
                 <asp:ListItem Value="3">WO No</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                     <asp:ListItem Value="2">PO No</asp:ListItem>
                       
                </asp:DropDownList>
            
                <asp:TextBox ID="txtEnqId" runat="server" CssClass="box3" 
                    Width="150px"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchValue" runat="server" CssClass="box3"  
                    Visible="False" Width="350px"></asp:TextBox>
                      <cc1:AutoCompleteExtender ID="TxtSearchValue_AutoCompleteExtender" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchValue" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                    
                
        <asp:Button ID="btnSearch" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearch_Click"  />            
            &nbsp;&nbsp;&nbsp;
                        </td>
             </tr>
 <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView1" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo"                  
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    PageSize="15" onrowcommand="SearchGridView1_RowCommand" >
            
                    <PagerSettings PageButtonCount="40" />
            
            <Columns>
                
                <asp:TemplateField HeaderText="SN">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:BoundField>
                                  <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" />
                                  
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" />
                                  
                                  <asp:BoundField DataField="POId" HeaderText="PO Id" 
                    Visible="False"/>
                                  <asp:TemplateField HeaderText=" ">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList2"  runat="server">                                      
                    <asp:ListItem Text="Bought Out"  Value="1"/> 
                     <asp:ListItem Text="Manufacturing"  Value="2"/> 
                     <asp:ListItem Text="Hardware" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="WO No">
                                      <ItemTemplate>
                                      
                                      <%--<asp:HyperLink ID="HyperLink2" runat="server" 
                                              NavigateUrl='<%# Eval("CustomerId", "~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?CustomerId={0}&WONo={2}&ModId=&SubModId=") %>' 
                                              Text='<%# Eval("WONo") %>'></asp:HyperLink>--%>
                                          <asp:LinkButton ID="BtnWONo" CommandName="NavigateTo" runat="server" Text='<%# Eval("WONo") %>'></asp:LinkButton>
                                      </ItemTemplate>
                </asp:TemplateField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" 
                    Visible="False" >
                            
                                      <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            
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
            
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>

            </td>
             </tr>
              </table>
 </ContentTemplate>
 </cc1:TabPanel>
 
 <cc1:TabPanel runat="server" HeaderText="Quantity Wise" ID="TabPanel2">
 <ContentTemplate>  
   
 
       <table align="center" cellpadding="0" cellspacing="0" width="100%">
                                       
                    <tr>
                        <td height="25">
                       &nbsp; <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOType1" OnSelectedIndexChanged="DDLTaskWOType1_SelectedIndexChanged"></asp:DropDownList>&nbsp; &nbsp;
                       &nbsp;<asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                AutoPostBack="True" onselectedindexchanged="drpfield_SelectedIndexChanged">
                                <asp:ListItem Value="0">Customer</asp:ListItem>
                                <asp:ListItem Value="1">WO No</asp:ListItem>
                                <asp:ListItem Value="2">Project Title</asp:ListItem>
                            </asp:DropDownList>
&nbsp;<asp:TextBox ID="txtSupplier" runat="server" CssClass="box3"  Width="250px"></asp:TextBox>
                            <cc1:AutoCompleteExtender ID="txtSupplier_AutoCompleteExtender" runat="server" 
                                DelimiterCharacters="" Enabled="True" ServiceMethod="GetCompletionList" 
                                ServicePath="" TargetControlID="txtSupplier" UseContextKey="True" CompletionInterval="100" CompletionSetCount="2" FirstRowSelected="True" MinimumPrefixLength="1" ShowOnlyCurrentWordInCompletionListItem="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                            </cc1:AutoCompleteExtender>
                            &nbsp;<asp:TextBox ID="txtPONo" runat="server" Visible="False" CssClass="box3" 
                                Width="250px"></asp:TextBox>
                        &nbsp;<asp:CheckBox ID="SelectAll" runat="server" Text="Select All Work Order"  AutoPostBack="True" 
                                oncheckedchanged="SelectAll_CheckedChanged" />&nbsp;
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="redbox" Text="Search" onclick="Button1_Click" />  &nbsp;                   </td>
                     
                    </tr>
                    
                    <tr>
                        <td colspan="2">                       
                            <asp:Panel ID="Panel1" runat="server" Height="375px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server"  
                                    AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="WOId"  Width="100%">
                    <PagerSettings PageButtonCount="40" />
                    <Columns>
                        <asp:TemplateField HeaderText="SN" >
                            <ItemTemplate>
                    <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>      
                             <ItemStyle HorizontalAlign="Right" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </ItemTemplate>
                          <ItemStyle HorizontalAlign="Center" Width="2%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WOId" SortExpression="Id" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblWOId" runat="server" Text='<%#Eval("WOId") %>'> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="WO No"  >
                            <ItemTemplate>
                                <asp:Label ID="lblWONo" runat="server" Text='<%#Eval("WONo") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                        </asp:TemplateField>

                    
                    
                        <asp:TemplateField HeaderText="Project Title" >
                            <ItemTemplate>
                                <asp:Label ID="lblProjectTitle" runat="server" Text='<%#Eval("ProjectTitle") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Customer Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Code" >
                            <ItemTemplate>
                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
      
                    </Columns>
                    <EmptyDataTemplate>
                        <table class="fontcss" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Names="Calibri" 
                                        ForeColor="red" Text="No  data found to display"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <FooterStyle Wrap="True" />
                </asp:GridView>
                
                
               </asp:Panel>
                        </td>
                    </tr> 
                    <tr>
        <td align="center" height="25px" valign="middle">
        
                <asp:Button ID="btnPrint" runat="server" CssClass="redbox" Text="Proceed" 
                    onclick="btnPrint_Click" />
        </td>
        </tr>
                </table>
        

 </ContentTemplate>
 </cc1:TabPanel>
 
 
 
 <cc1:TabPanel runat="server" HeaderText="Shortage Wise" ID="TabPanel3"><ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0">

            
             <tr>
            <td class="fontcsswhite" height="25" >
             <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DDLTaskWOTypeSH" OnSelectedIndexChanged="DDLTaskWOTypeSH_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="DropDownList4" runat="server" Width="180px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                    AutoPostBack="True">
                 <asp:ListItem Value="3">WO No</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                     <asp:ListItem Value="2">PO No</asp:ListItem>
                       
                </asp:DropDownList>
            
                <asp:TextBox ID="txtEnqSH" runat="server" CssClass="box3" 
                    Width="150px"></asp:TextBox>
                 <asp:TextBox ID="TxtSearchSH" runat="server" CssClass="box3"  
                    Visible="False" Width="350px"></asp:TextBox>
                      <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TxtSearchSH" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                    
                
        <asp:Button ID="btnSearchSH" runat="server" 
            Text="Search" CssClass="redbox" onclick="btnSearchSH_Click"  />            
            &nbsp;&nbsp;&nbsp;
                        </td>
             </tr>
 <tr>
            <td>
                     
                <asp:GridView ID="SearchGridView2" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo"                  
                    onpageindexchanging="SearchGridView2_PageIndexChanging" Width="100%" 
                    PageSize="15" onrowcommand="SearchGridView2_RowCommand" >
            
                    <PagerSettings PageButtonCount="40" />
            
            <Columns>
                
                <asp:TemplateField HeaderText="SN">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:BoundField>
                                  <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" />
                                  
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" />
                                  
                                  <asp:BoundField DataField="POId" HeaderText="PO Id" 
                    Visible="False"/>
                                  <asp:TemplateField HeaderText=" ">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownListSH"  runat="server">                                      
                    <asp:ListItem Text="Bought Out"  Value="1"/> 
                     <asp:ListItem Text="Manufacturing"  Value="2"/> 
                     <asp:ListItem Text="Hardware" Value="3"></asp:ListItem>
                     
                    </asp:DropDownList>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="WO No">
                                      <ItemTemplate>
                                      
                                      <%--<asp:HyperLink ID="HyperLink2" runat="server" 
                                              NavigateUrl='<%# Eval("CustomerId", "~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?CustomerId={0}&WONo={2}&ModId=&SubModId=") %>' 
                                              Text='<%# Eval("WONo") %>'></asp:HyperLink>--%>
                                          <asp:LinkButton ID="BtnWONoSH" CommandName="NavigateToSH" runat="server" Text='<%# Eval("WONo") %>'></asp:LinkButton>
                                      </ItemTemplate>
                </asp:TemplateField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" 
                    Visible="False" >
                            
                                      <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            
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
            
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>

            </td>
             </tr>
              </table>
 </ContentTemplate>
 </cc1:TabPanel>
 
 
 
 
 <cc1:TabPanel runat="server" HeaderText="Supplier Wise" ID="TabPanel4"><ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0">

            
             <tr>
            <td class="fontcsswhite" height="25" >
             <asp:DropDownList runat="server" AutoPostBack="True" DataTextField="CName" DataValueField="CId" CssClass="box3" ID="DropDownSupWO" OnSelectedIndexChanged="DropDownSupWO_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="DropDownSup" runat="server" Width="180px" 
                    CssClass="box3" 
                    onselectedindexchanged="DropDownSup_SelectedIndexChanged" 
                    AutoPostBack="True">
                 <asp:ListItem Value="3">WO No</asp:ListItem>
                    <asp:ListItem Value="0">Customer Name</asp:ListItem>
                    <asp:ListItem Value="1">Enquiry No</asp:ListItem>
                     <asp:ListItem Value="2">PO No</asp:ListItem>
                       
                </asp:DropDownList>
            
                <asp:TextBox ID="TextSupWONo" runat="server" CssClass="box3" 
                    Width="150px"></asp:TextBox>
                 <asp:TextBox ID="TextSupCust" runat="server" CssClass="box3"  
                    Visible="False" Width="350px"></asp:TextBox>
                      <cc1:AutoCompleteExtender ID="AutoCompleteExtender12" 
                    runat="server" CompletionInterval="100" CompletionSetCount="1" 
                                            DelimiterCharacters="" Enabled="True" FirstRowSelected="True" 
                                            MinimumPrefixLength="1" ServiceMethod="sql" ServicePath="" 
                                            ShowOnlyCurrentWordInCompletionListItem="True" 
                                            TargetControlID="TextSupCust" UseContextKey="True" CompletionListItemCssClass="bg" CompletionListHighlightedItemCssClass="bgtext" CompletionListCssClass="almt">
                </cc1:AutoCompleteExtender> 
                    
                
        <asp:Button ID="BtnSup" runat="server" 
            Text="Search" CssClass="redbox" onclick="BtnSup_Click"  />            
            &nbsp;&nbsp;&nbsp;
                        </td>
             </tr>
 <tr>
            <td>
                     
                <asp:GridView ID="GridViewSup" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo"                  
                    onpageindexchanging="GridViewSup_PageIndexChanging" Width="100%" 
                    PageSize="15" onrowcommand="GridViewSup_RowCommand" >
            
                    <PagerSettings PageButtonCount="40" />
            
            <Columns>
                
                <asp:TemplateField HeaderText="SN">
                <ItemTemplate>
                <%#Container.DataItemIndex+1  %>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateField>
                                  <asp:BoundField DataField="FinYear" HeaderText="Fin Yrs">
                                      <ItemStyle HorizontalAlign="Center" Width="8%" />
                </asp:BoundField>
                                  <asp:BoundField HeaderText="Customer Name" 
                    DataField="CustomerName">
                                      <ItemStyle HorizontalAlign="Left" Width="25%" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="CustomerId" HeaderText="Code" />
                                  <asp:BoundField DataField="EnqId" HeaderText="Enquiry No" />
                                  
                                  <asp:BoundField DataField="PONo" HeaderText="PO No" />
                                  
                                  <asp:BoundField DataField="POId" HeaderText="PO Id" 
                    Visible="False"/>
                                  <asp:TemplateField HeaderText=" ">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownSuptype"  runat="server">                                      
                    <asp:ListItem Text="Bought Out"  Value="1"/> 
                     <asp:ListItem Text="Manufacturing"  Value="2"/> 
                     <asp:ListItem Text="Hardwear" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="WO No">
                                      <ItemTemplate>
                                      
                                      <%--<asp:HyperLink ID="HyperLink2" runat="server" 
                                              NavigateUrl='<%# Eval("CustomerId", "~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?CustomerId={0}&WONo={2}&ModId=&SubModId=") %>' 
                                              Text='<%# Eval("WONo") %>'></asp:HyperLink>--%>
                                          <asp:LinkButton ID="BtnWONoSup" CommandName="Sup" runat="server" Text='<%# Eval("WONo") %>'></asp:LinkButton>
                                      </ItemTemplate>
                </asp:TemplateField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" 
                    Visible="False" >
                            
                                      <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            
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
            
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>

            </td>
             </tr>
              </table>
 </ContentTemplate>
 </cc1:TabPanel>
 
  
 </cc1:TabContainer>
            </td>
        </tr>
        
        </table>
 
 <%--</-ContentTemplate>
    </asp:UpdatePanel>
</div>--%>
 

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

