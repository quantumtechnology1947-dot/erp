<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DEPARTMENTAL_WORKING_PLAN.aspx.cs" Inherits="Module_DailyReportingSystem_Reports_DEPARTMENTAL_WORKING_PLAN" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <link href="../../../Css/yui-datatable.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/StyleSheet.css" rel="stylesheet" type="text/css" />

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
    <center>
    </center>&nbsp;<table width="100%" align="center" cellpadding="0" cellspacing="0" Class="fontcss">
       
                
                    <tr height="21">
                        <td style="background-color:gainsboro" class="fontcsswhite" ><strong style="background-color: #006699">&nbsp;Project Summary </strong>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    
                 <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="420px"
Width="100%"  AutoPostBack="True" onactivetabchanged="TabContainer1_ActiveTabChanged">
<cc1:TabPanel runat="server" HeaderText="W/o Wise" ID="TabPanel1">
    <HeaderTemplate>
        Wo_Wise
    </HeaderTemplate>
    <ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0">

            
             <tr>
            <td class="fontcsswhite" height="25" >
             <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" ID="DropDownList2" Width="180px">
                 <asp:ListItem Value="1">WO No</asp:ListItem>
                 
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
                    onpageindexchanging="SearchGridView1_PageIndexChanging" Width="100%" 
                    PageSize="15" onrowcommand="SearchGridView1_RowCommand" EnableModelValidation="True" >
            
                    <PagerSettings PageButtonCount="40" />
            
            <Columns>
                
                <asp:BoundField DataField="E_name" HeaderText="Employee" SortExpression="E_name" />
                <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation" />
                <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                <asp:BoundField DataField="IdDate" HeaderText="Date" SortExpression="IdDate" />
                <asp:BoundField DataField="IdWo" HeaderText="WoNo" SortExpression="IdWo" />
                <asp:BoundField DataField="IdActivity" HeaderText="Activity" SortExpression="IdActivity" />
                <asp:BoundField DataField="IdStatus" HeaderText="Status" SortExpression="IdStatus" />
                <asp:BoundField DataField="IDperc" HeaderText="%Completed" SortExpression="IDperc" />
                <asp:BoundField DataField="Idrmk" HeaderText="Remarks" SortExpression="Idrmk" />
                            
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
     <HeaderTemplate>
         Department Wise
     </HeaderTemplate>
 <ContentTemplate>  
   
 
       <table align="center" cellpadding="0" cellspacing="0" width="100%">
                                       
                    <tr>
                        <td height="25">
                            &nbsp;<asp:DropDownList ID="drpfield" runat="server" CssClass="box3" 
                                AutoPostBack="True" onselectedindexchanged="drpfield_SelectedIndexChanged">
                                <asp:ListItem Value="0">Department</asp:ListItem>
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
                        <td>                       
                            <asp:Panel ID="Panel1" runat="server" Height="375px" ScrollBars="Auto">
                <asp:GridView ID="GridView1" runat="server"  
                                    AutoGenerateColumns="False" 
                    CssClass="yui-datatable-theme" DataKeyNames="WOId"  Width="100%" EnableModelValidation="True">
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
                        
                        <asp:TemplateField HeaderText="Employee Name" >
                            <ItemTemplate>
                                <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Designation" >
                            <ItemTemplate>
                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Code") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
      
                        <asp:TemplateField HeaderText="Department Name">
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
 
 
 
 <cc1:TabPanel runat="server" HeaderText="Shortage Wise" ID="TabPanel3">
     <HeaderTemplate>
         Indivisual name Wise
     </HeaderTemplate>
     <ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0">

            
             <tr>
            <td class="fontcsswhite" height="25" >
             <asp:DropDownList runat="server" AutoPostBack="True" CssClass="box3" ID="DropDownList4" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Width="180px">
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
                    PageSize="15" onrowcommand="SearchGridView2_RowCommand" EnableModelValidation="True" >
            
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
                                  <asp:TemplateField HeaderText="WO No">
                <ItemTemplate>
                    <%--<asp:HyperLink ID="HyperLink2" runat="server" 
                                              NavigateUrl='<%# Eval("CustomerId", "~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?CustomerId={0}&WONo={2}&ModId=&SubModId=") %>' 
                                              Text='<%# Eval("WONo") %>'></asp:HyperLink>--%>
                    <asp:LinkButton ID="BtnWONoSH" runat="server" CommandName="NavigateToSH" Text='<%# Eval("WONo") %>'></asp:LinkButton>
                </ItemTemplate>

                </asp:TemplateField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" Visible="False" >
                                  
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
 
 
 
 
 <cc1:TabPanel runat="server" HeaderText="Supplier Wise" ID="TabPanel4">
     <HeaderTemplate>
         Date Wise
     </HeaderTemplate>
     <ContentTemplate>   
                    
                    
                    
<table width="100%" align="center" cellpadding="0" cellspacing="0">

            
             <tr>
            <td class="fontcsswhite" height="25" >
            
            
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
            Text="Search" CssClass="redbox"   />            
            &nbsp;&nbsp;&nbsp;
                        </td>
             </tr>
 <tr>
            <td>
                     
                <asp:GridView ID="GridViewSup" runat="server" AllowPaging="True" 
                    AllowSorting="True" AutoGenerateColumns="False" CssClass="yui-datatable-theme"
                    DataKeyNames="WONo"                  
                   Width="100%" PageSize="15" EnableModelValidation="True" >
            
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
                                  <asp:TemplateField HeaderText="WO No">
                <ItemTemplate>
                    <%--<asp:HyperLink ID="HyperLink2" runat="server" 
                                              NavigateUrl='<%# Eval("CustomerId", "~/Module/ProjectManagement/Reports/ProjectSummary_Details_Grid.aspx?CustomerId={0}&WONo={2}&ModId=&SubModId=") %>' 
                                              Text='<%# Eval("WONo") %>'></asp:HyperLink>--%>
                    <asp:LinkButton ID="BtnWONoSup" runat="server" CommandName="Sup" Text='<%# Eval("WONo") %>'></asp:LinkButton>
                </ItemTemplate>

                </asp:TemplateField>
                                  <asp:BoundField DataField="SysDate" HeaderText="Gen. Date" />
                                  <asp:BoundField DataField="EmployeeName" HeaderText="Gen. By" Visible="False" >
                                  
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
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder4" Runat="Server">
</asp:Content>

